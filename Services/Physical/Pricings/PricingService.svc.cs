using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Utility.ErrorManagement;
using Services.Helper.Pricings;
using Services.Physical.Contracts;
using Services.SystemSetting;
using Services.Futures.LME;
using Services.Futures.SHFE;
using Services.Physical.WarehouseOuts;

namespace Services.Physical.Pricings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PricingService" in code, svc and config file together.
    public class PricingService : BaseService<Pricing>, IPricingService
    {
        /// <summary>
        /// Get the pricing records of the given quota
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public List<Pricing> GetPricingByQuotaId(int quotaId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quotaId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 点价加权平均
        /// </summary>
        /// <returns></returns>
        public decimal GetAvgPricing(int quotaId)
        {
            List<Pricing> pricingList = GetPricingByQuotaId(quotaId);
            decimal pricingQty = 0;
            decimal amount = 0;
            foreach (Pricing item in pricingList)
            {
                if (!item.IsDeleted)
                {
                    amount += (item.PricingQuantity ?? 0) * (item.FinalPrice ?? 0);
                    pricingQty += item.PricingQuantity ?? 0;
                }
            }
            if (pricingQty != 0)
            {
                return amount / pricingQty;
            }

            return 0;
        }

        /// <summary>
        /// Add new pricing
        /// </summary>
        /// <param name="pricing"> </param>
        /// <param name="userId"></param>
        /// <param name="isPricingComplete"></param>
        /// <returns></returns>
        public Pricing AddNewManualPricing(Pricing pricing, int userId, bool isPricingComplete)
        {
                using (var ctx = new SenLan2Entities(userId))
                {
                    using (var ts = new TransactionScope())
                    {
                        try
                        {
                            Unpricing up = GetById(GetObjQuery<Unpricing>(ctx, new List<string> { "Quota" }), pricing.UnpricingId ?? 0);
                            
                            if (up == null)
                            {
                                throw new FaultException(ErrCode.UnpricingNotFound.ToString());
                            }

                            if (pricing.PricingDate > up.Quota.PricingEndDate || pricing.PricingDate < up.Quota.PricingStartDate)
                            {
                                throw new FaultException(ErrCode.ExceedPricingDateRange.ToString());
                            }

                            SystemParameter sp = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                            decimal limit = sp == null ? 0 : sp.Pricing2Quota;
                            var pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == pricing.QuotaId);
                            decimal? pricedQty = pricing.PricingQuantity + pricings.Where(p => p.IsDeleted == false).Sum(c => c.PricingQuantity);
                            if (((pricedQty ?? 0) - (up.Quota.Quantity ?? 0)) / (up.Quota.Quantity ?? 0) > limit / 100)
                            {
                                throw new FaultException(ErrCode.UnpricingQuantityNotEnough.ToString());
                            }

                            if (pricing.CurrencyId != up.Quota.PricingCurrencyId)
                            {
                                throw new FaultException(ErrCode.PricingCurrencyNotMatch.ToString());
                            }

                            //Manual Pricing: Add a Pricing record and deduct the quantity from the unpricing record
                            Create(GetObjSet<Pricing>(ctx), pricing);
                            ctx.SaveChanges();

                            up.UnpricingQuantity -= pricing.PricingQuantity;
                            Update(GetObjSet<Unpricing>(ctx), up);
                            ctx.SaveChanges();

                            Quota quota = GetById(GetObjQuery<Quota>(ctx, new List<string> { "Unpricings" }), pricing.QuotaId);
                            if (quota != null && quota.Unpricings != null)
                            {
                                if (isPricingComplete)
                                {
                                    quota.PricingStatus = (int)PricingStatus.Complete;
                                }
                                else
                                {
                                    decimal? unpricingQtySum = quota.Unpricings.Sum(o => o.UnpricingQuantity);
                                    if (Math.Abs(unpricingQtySum.Value) / quota.Quantity <= limit / 100)
                                    {
                                        quota.PricingStatus = (int)PricingStatus.Complete;
                                    }
                                    else
                                    {
                                        quota.PricingStatus = (int)PricingStatus.Partial;
                                    }
                                }
                            }

                            ctx.SaveChanges();

                            //修改批次的应收应付金额字段
                            var quotaService = new QuotaService();
                            quotaService.SetEqualityByQuotaId(quota.Id, userId);
                            quotaService.UpdateQuotaFinalPriceByQuotaId(quota.Id, userId);
                            var psQuotaRelService = new PSQuotaRelService();
                            psQuotaRelService.SetRelStrByQuotaId(userId, quota.Id);
                            ts.Complete();
                            return pricing;
                        }
                        catch (OptimisticConcurrencyException)
                        {
                            throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                        }
                        finally
                        {
                            ts.Dispose();
                        }
                }
            }
        }

        /// <summary>
        /// 删除手工点价记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        //批次是否点价完成
                        //如果没有完成，直接删除点价
                        //如果已经完成，是否开了增值税发票
                        //没有开票，直接删除，重置批次的点价状态
                        //开票，则不能删除
                        Pricing pri =
                            QueryForObj(
                                GetObjQuery<Pricing>(ctx, new List<string> { "Quota", "Quota.VATInvoiceLines", "Unpricing" }),
                                p => p.Id == id);
                        int vatInvoiceLineCount = pri.Quota.VATInvoiceLines.Where(o => !o.IsDeleted).Count();

                        if (pri.Quota.PricingStatus == (int)PricingStatus.Complete && vatInvoiceLineCount > 0)
                        {
                            throw new FaultException(ErrCode.PricingVATInvoiceConnected.ToString());
                        }

                        pri.IsDeleted = true;
                        //重置批次的点价状态
                        ICollection<Pricing> ps = QueryForObjs(GetObjQuery<Pricing>(ctx),
                                                                p => p.QuotaId == pri.QuotaId && p.Id != pri.Id);
                        if (ps.Count <= 0)
                        {
                            pri.Quota.PricingStatus = (int)PricingStatus.NotAtAll;
                        }
                        else
                        {
                            SystemParameter sysPara = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                            var pQty = ps.Sum(p => p.PricingQuantity);
                            decimal pricingLimit = sysPara == null ? 0 : sysPara.Pricing2Quota;
                            if (Math.Abs(((pri.Quota.Quantity ?? 0) - ((decimal)pQty)) / (pri.Quota.Quantity ?? 0)) <= pricingLimit / 100)
                            {
                                pri.Quota.PricingStatus = (int)PricingStatus.Complete;
                            }
                            else
                            {
                                pri.Quota.PricingStatus = (int)PricingStatus.Partial;
                            }
                        }

                        //还回数量给未点价表
                        pri.Unpricing.UnpricingQuantity += pri.PricingQuantity;
                        ctx.SaveChanges();
                        //修改批次的应收应付金额字段
                        var quotaService = new QuotaService();
                        quotaService.SetEqualityByQuotaId(pri.QuotaId, userId);
                        quotaService.UpdateQuotaFinalPriceByQuotaId(pri.QuotaId, userId);
                        ts.Complete();
                    }
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="userId"></param>
        /// <param name="isPricingComplete"></param>
        public void UpdateManualPricing(Pricing obj, int userId, bool isPricingComplete)
        {
                using (var ctx = new SenLan2Entities(userId))
                {
                    using (var ts = new TransactionScope())
                    {
                        try
                        {
                            Pricing p = GetById(GetObjQuery<Pricing>(ctx, new Collection<string> { "Unpricing", "Quota", "Quota.VATInvoiceLines" }), obj.Id);
                            int vatInvoiceLineCount = p.Quota.VATInvoiceLines.Where(o => !o.IsDeleted).Count();
                            if (vatInvoiceLineCount > 0)
                            {
                                throw new FaultException(ErrCode.PricingVATInvoiceConnected.ToString());
                            }

                            if (obj.PricingDate > p.Quota.PricingEndDate || obj.PricingDate < p.Quota.PricingStartDate)
                            {
                                throw new FaultException(ErrCode.ExceedPricingDateRange.ToString());
                            }

                            if (obj.CurrencyId != p.Quota.PricingCurrencyId)
                            {
                                throw new FaultException(ErrCode.PricingCurrencyNotMatch.ToString());
                            }

                            var sysPara = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                            decimal? deltaQuantity = p.PricingQuantity - obj.PricingQuantity;
                            var pricings = QueryForObjs(GetObjQuery<Pricing>(ctx),
                              o => o.QuotaId == obj.QuotaId && o.Id != obj.Id);
                            decimal pQty = (decimal)pricings.Sum(o => o.PricingQuantity) + (obj.PricingQuantity ?? 0);
                            decimal limit = sysPara == null ? 0 : sysPara.Pricing2Quota;
                            if ((pQty - (p.Quota.Quantity ?? 0)) / (p.Quota.Quantity ?? 0) > limit / 100)
                            {
                                throw new FaultException(ErrCode.UnpricingQuantityNotEnough.ToString());
                            }

                            p.PricingQuantity = obj.PricingQuantity;
                            p.PricingDate = obj.PricingDate;
                            p.PricingBasis = obj.PricingBasis;
                            p.BasicPrice = obj.BasicPrice;
                            p.AdjustQPFee = obj.AdjustQPFee;
                            p.FinalPrice = obj.FinalPrice;
                            p.Description = obj.Description;
                            p.ExchangeRate = obj.ExchangeRate;
                            p.PriceDate = obj.PriceDate;


                            if (isPricingComplete)
                            {
                                p.Quota.PricingStatus = (int)PricingStatus.Complete;
                            }
                            else
                            {
                                if (Math.Abs(((p.Quota.Quantity ?? 0) - pQty) / (p.Quota.Quantity ?? 0)) <= limit / 100)
                                {
                                    p.Quota.PricingStatus = (int)PricingStatus.Complete;
                                }
                                else
                                {
                                    p.Quota.PricingStatus = (int)PricingStatus.Partial;
                                }
                            }


                            if (p.Unpricing != null)
                            {
                                p.Unpricing.UnpricingQuantity += deltaQuantity;
                            }

                            ctx.SaveChanges();

                            //修改批次的应收应付金额字段
                            var quotaService = new QuotaService();
                            quotaService.SetEqualityByQuotaId(p.QuotaId, userId);
                            quotaService.UpdateQuotaFinalPriceByQuotaId(p.QuotaId, userId);
                            var psQuotaRelService = new PSQuotaRelService();
                            psQuotaRelService.SetRelStrByQuotaId(userId, p.QuotaId);
                            ts.Complete();
                        }
                        catch (OptimisticConcurrencyException)
                        {
                            throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                        }
                        finally
                        {
                            ts.Dispose();
                        }
                    }
                }
        }

        /// <summary>
        /// 根据点价基准获取点价币种代码
        /// </summary>
        /// <param name="pb"></param>
        /// <returns></returns>
        public Currency GetCurrencyByPricingBasis(PricingBasis pb)
        {
            return PricingHelper.GetCurrencyByPricingBasis(pb);
        }

        /// <summary>
        /// 计算当天或者在此日期之前的采购/销售点价数量
        /// </summary>
        /// <param name="internalCustomerID"> </param>
        /// <param name="date">日期</param>
        /// <param name="type">区别计算当前的还是在此日期之前的点价数量</param>
        /// <param name="contractType">采购/销售</param>
        /// <param name="userId"></param>
        /// <param name="commodityID"> </param>
        /// <returns></returns>
        public decimal GetQtyByParameters(int commodityID, int internalCustomerID, DateTime? date, string type, int contractType, int userId)
        {
            try
            {
                string sql = "it.Quota.Contract.ContractType = @p1 and it.Quota.CommodityId = @p2 and it.Quota.Contract.InternalCustomerId = @p3 and (it.Quota.ApproveStatus = @p4 or it.Quota.ApproveStatus = @p5)";
                if (type == "CurrentDay")//当天的点价数量
                {
                    sql += " and it.PricingDate = @p6";
                }
                else if (type == "All")
                {
                    sql += " and it.PricingDate <= @p6";
                }
                var parameters = new List<object>
                                         {
                                             contractType,
                                             commodityID,
                                             internalCustomerID,
                                             (int) ApproveStatus.Approved,
                                             (int) ApproveStatus.NoApproveNeeded,
                                             date
                                         };
                decimal qty = GetSum<Pricing>(sql, parameters, o => o.PricingQuantity);

                return qty;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Pricing> GetQtyNew(int commodityID, int internalCustomerID, DateTime? date)
        {
            try
            {
                using (var ctx=new SenLan2Entities())
                {
                    List<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx, new List<string> { "Quota.Contract" }), o => o.Quota.CommodityId == commodityID
                        && o.Quota.Contract.InternalCustomerId == internalCustomerID
                        && (o.Quota.ApproveStatus == (int)ApproveStatus.Approved || o.Quota.ApproveStatus == (int)ApproveStatus.NoApproveNeeded)
                        && o.PricingDate <= date).ToList();
                    return pricings;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #region 期现货敞口走势

        public List<ExposureChartClass> GetLine(DateTime? startDate, DateTime? endDate, int commodityID, int internalCustomerID, decimal? proportionValue, int userId)
        {
            decimal? allQty1 = 0; //小于等于当天的所有现货采购量
            decimal? allQty2 = 0; //小于等于当天的所有现货销售量
            decimal? allLMEQty3 = 0; //小于等于当天的所有LME多头
            decimal? allLMEQty4 = 0;
            decimal? allSHFEQty3 = 0; //小于等于当天的所有SHFE多头
            decimal? allSHFEQty4 = 0;
            var list = new List<ExposureChartClass>();

            TimeSpan? ts = endDate - startDate;
            int days = ts.Value.Days;

            var commodityService = new CommodityService();
            var lmePositionService = new LMEPositionService();
            var shfePositionService = new SHFEPositionService();
            Commodity commodity = commodityService.GetById(commodityID);
            List<Pricing> pricings = GetQtyNew(commodityID, internalCustomerID, endDate);
            List<LMEPosition> lmePositions = lmePositionService.GetQtyNew(commodityID, internalCustomerID, endDate);
            List<SHFEPosition> shfePositions = shfePositionService.GetQtyNew(commodityID, internalCustomerID, endDate);

            for (int i = 0; i < days + 1; i++)
            {
                var c = new ExposureChartClass();

                DateTime? start = startDate.Value.AddDays(i);
                c.X = string.Format("{0:yyyy/MM/dd}", start);
                c.Qty1 = pricings.Where(o => o.PricingDate == start && o.Quota.Contract.ContractType == (int)ContractType.Purchase).Sum(p => p.PricingQuantity);
                c.Qty2 = pricings.Where(o => o.PricingDate == start && o.Quota.Contract.ContractType == (int)ContractType.Sales).Sum(p => p.PricingQuantity);


                c.LmeQty3 = lmePositions.Where(o => o.TradeDirection == (int)PositionDirection.Long && o.TradeDate == start).Sum(p => p.LotAmount) * (commodity.LMEQtyPerHand ?? 1);
                c.LmeQty4 = lmePositions.Where(o => o.TradeDirection == (int)PositionDirection.Short && o.TradeDate == start).Sum(p => p.LotAmount) * (commodity.LMEQtyPerHand ?? 1);


                c.ShfeQty3 = shfePositions.Where(o => o.PositionDirection == (int)PositionDirection.Long && o.SHFECapitalDetail.TradeDate == start).Sum(p => p.LotQuantity) * (commodity.SHFEQtyPerHand ?? 1) * proportionValue;
                c.ShfeQty4 = shfePositions.Where(o => o.PositionDirection == (int)PositionDirection.Short && o.SHFECapitalDetail.TradeDate == start).Sum(p => p.LotQuantity) * (commodity.SHFEQtyPerHand ?? 1) * proportionValue;

                if (start == startDate)
                {
                    allQty1 = pricings.Where(o => o.PricingDate <= start && o.Quota.Contract.ContractType == (int)ContractType.Purchase).Sum(p => p.PricingQuantity);
                    allQty2 = pricings.Where(o => o.PricingDate <= start && o.Quota.Contract.ContractType == (int)ContractType.Sales).Sum(p => p.PricingQuantity);

                    allLMEQty3 = lmePositions.Where(o => o.TradeDirection == (int)PositionDirection.Long && o.TradeDate <= start).Sum(p => p.LotAmount) * (commodity.LMEQtyPerHand?? 1);
                    allLMEQty4 = lmePositions.Where(o => o.TradeDirection == (int)PositionDirection.Short && o.TradeDate <= start).Sum(p => p.LotAmount) * (commodity.LMEQtyPerHand ?? 1);

                    allSHFEQty3 = shfePositions.Where(o => o.PositionDirection == (int)PositionDirection.Long && o.SHFECapitalDetail.TradeDate <= start).Sum(p => p.LotQuantity) * (commodity.SHFEQtyPerHand?? 1);
                    allSHFEQty4 = shfePositions.Where(o => o.PositionDirection == (int)PositionDirection.Short && o.SHFECapitalDetail.TradeDate <= start).Sum(p => p.LotQuantity) * (commodity.SHFEQtyPerHand?? 1);
                }
                else
                {
                    allQty1 = allQty1 + c.Qty1;
                    allQty2 = allQty2 + c.Qty2;

                    allLMEQty3 = allLMEQty3 + c.LmeQty3;
                    allLMEQty4 = allLMEQty4 + c.LmeQty4;

                    allSHFEQty3 = allSHFEQty3 + c.ShfeQty3;
                    allSHFEQty4 = allSHFEQty4 + c.ShfeQty4;
                }

                double result = Convert.ToDouble(allQty1 - allQty2 + allLMEQty3 - allLMEQty4 + (allSHFEQty3 - allSHFEQty4) * proportionValue);

                c.Y = result;
                list.Add(c);
            }

            return list;
        }

        #endregion
    }
}
