using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using PriceDBEntity;
using Services.Base;
using Services.Helper.MarketPrice;
using Services.Physical.Pricings;
using Services.SystemSetting;
using Utility.ErrorManagement;
using Utility.Misc;
using Services.Physical.WarehouseOuts;
using Services.Finance.FundFlows;

namespace Services.Physical.Contracts
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“QuotaService”。
    public class QuotaService : BaseService<Quota>, IQuotaService
    {
        #region IQuotaService Members

        private readonly Dictionary<int, decimal> _cnyRate = new Dictionary<int, decimal>();
        private readonly Dictionary<int, int> _pricingBasises = new Dictionary<int, int>();
        private readonly Dictionary<int, decimal> _usdRate = new Dictionary<int, decimal>();
        private decimal _cny2USDRate;
        private Dictionary<string, decimal> _commodityDictionary = new Dictionary<string, decimal>();
        private decimal _usd2CNYRate;

        public decimal GetPricedQuantity(int quotaId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    ICollection<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quotaId);
                    if (pricings != null)
                    {
                        return pricings.Sum(o => o.PricingQuantity).Value;
                    }
                    return 0;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public QuotaEnableProperty SetElementsEnableProperty(int id)
        {
            var qrp = new QuotaEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == id);

                    //先查点价逻辑
                    //均价点价，点价完成不能修改履约日期
                    if (quota.PricingType == (int)PricingType.Average &&
                        quota.PricingStatus == (int)PricingStatus.Complete)
                    {
                        qrp.IsImplDateEnable = false;
                    }

                    //如果是均价点价，手工点价，且有点价记录，不能修改升贴水和点价起始日期等信息
                    if (quota.PricingType == (int)PricingType.Manual ||
                        quota.PricingType == (int)PricingType.Average)
                    {
                        if (QueryForObjs(GetObjQuery<Pricing>(ctx), p => p.QuotaId == quota.Id).Count > 0)
                        {
                            qrp.IsPremiumEnable = false;
                            qrp.IsPricingBasisEnable = false;
                            qrp.IsPricingEndDateEnable = false;
                            qrp.IsPricingStartDateEnable = false;
                            qrp.IsPricingTypeEnable = false;
                            qrp.IsQuantityEnable = false;
                        }
                    }

                    //如果有后续单据，不能修改金属种类，数量,单价
                    //delivery
                    if (QueryForObjs(GetObjQuery<Delivery>(ctx), del => del.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //warehouseout
                    if (QueryForObjs(GetObjQuery<WarehouseOut>(ctx), wo => wo.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //付款申请
                    if (QueryForObjs(GetObjQuery<PaymentRequest>(ctx), py => py.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        //qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //商业发票
                    if (QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), ci => ci.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //增税开票申请
                    if (
                        QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx), vatRL => vatRL.QuotaId == quota.Id).Count >
                        0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //增税发票
                    if (QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), vatL => vatL.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //现金收付
                    if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        //qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //LC
                    if (QueryForObjs(GetObjQuery<LetterOfCredit>(ctx), lc => lc.QuotaId == quota.Id).Count > 0)
                    {
                        qrp.IsCommodityEnable = false;
                        //qrp.IsPricingBasisEnable = false;
                        qrp.IsQuantityEnable = false;
                        //qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    //参与分组保值,且结算后不可以修改批次
                    HedgeLineQuota hlq =
                        QueryForObjs(GetObjQuery<HedgeLineQuota>(ctx, new List<string> { "HedgeGroup" }),
                                     q => q.QuotaId == quota.Id).FirstOrDefault();
                    if (hlq != null && hlq.HedgeGroup.Status == (int)HedgeGroupStatus.Settled)
                    {
                        qrp.IsCommodityEnable = false;
                        qrp.IsPremiumEnable = false;
                        qrp.IsPriceEnable = false;
                        qrp.IsPricingBasisEnable = false;
                        qrp.IsPricingEndDateEnable = false;
                        qrp.IsPricingStartDateEnable = false;
                        qrp.IsQuantityEnable = false;
                        qrp.IsPricingTypeEnable = false;
                        return qrp;
                    }

                    return qrp;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        ///     Get the quotas approaching to the end date of pricing.
        /// </summary>
        /// <returns></returns>
        public List<Quota> GetQuotasApproachingPricingEnd()
        {
            using (var ctx = new SenLan2Entities())
            {
                SystemParameter sp = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                decimal? pricingAlert = sp == null ? 0 : sp.PricingAlert;

                List<Quota> quotas =
                    QueryForObjs(
                        GetObjQuery<Quota>(ctx,
                                           new List<string>
                                               {
                                                   "Pricings",
                                                   "Contract",
                                                   "Contract.BusinessPartner",
                                                   "Contract.InternalCustomer"
                                               }),
                        o =>
                        o.PricingStatus != (int)PricingStatus.Complete && !o.IsDraft &&
                        (o.PricingType == (int)PricingType.Average ||
                         o.PricingType == (int)PricingType.Manual)).ToList();

                quotas =
                    quotas.Where(
                        o => ((o.PricingEndDate ?? SqlDateTime.MaxValue.Value) - DateTime.Today).Days <= pricingAlert).
                           ToList();

                return quotas;
            }
        }

        public List<Quota> GetPurchaseAmount(DateTime? startDate, DateTime? endDate, int internalCustomerID)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<Quota> list =
                        QueryForObjs(
                            GetObjQuery<Quota>(ctx,
                                               new List<string>
                                                   {
                                                       "Pricings",
                                                       "Commodity",
                                                       "Contract",
                                                       "Unpricings",
                                                       "Currency"
                                                   }),
                            c =>
                            c.ImplementedDate <= endDate && c.ImplementedDate >= startDate &&
                            c.Contract.InternalCustomerId == internalCustomerID &&
                            (c.ApproveStatus == (int)ApproveStatus.NoApproveNeeded ||
                             c.ApproveStatus == (int)ApproveStatus.Approved)).ToList();
                    return list;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void UpdateQuotaStatusWithVerifiedQuantityByQuotaId(Quota quota, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateStatusQuota(quota, null, userId); //更改批次的货运状态和财务状态
                    UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(quota.Id, userId); //更改批次的实际数量
                    //更新自动生成合同的相关字段
                    using (var ctx = new SenLan2Entities())
                    {
                        List<Quota> autoQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), q => q.RelQuotaId == quota.Id).ToList();
                        foreach (Quota q in autoQuotas)
                        {
                            UpdateStatusQuota(q, quota, userId); //更改批次的货运状态和财务状态
                            UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(q.Id, userId); //更改批次的实际数量
                        }
                    }
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

        /// <summary>
        ///     根据批次Id获取该批次的实际数量
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetVerifiedQuantity(int quotaId, int userId)
        {
            //采购批次实际数量：
            //1、批次货运状态完成：批次实际数量 = 提单实际数量和
            //    提单实际数量 -> 提单行实际数量和	
            //    提单行的实际数量 -> 1、提单行货运状态完成，则取提单行对应的所有入库行的数量和。
            //                       2、提单行货运状态未完成，则取提单行的实际数量/净重（内贸取实际数量，外贸取净重）。
            //2、批次货运状态未完成：批次实际数量 = 批次数量

            //销售批次实际数量：
            //批次实际数量 = 发货单实际数量/净重和（内贸取实际数量，外贸取净重） + 出库数量和

            decimal verifiedQuantity = 0M;

            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), q => q.Id == quotaId);
                //批次货运状态未完成取批次自身的数量
                if (quota.DeliveryStatus == false)
                {
                    if (quota.Quantity != null) verifiedQuantity = quota.Quantity.Value;
                }
                else
                {
                    if (quota.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        #region 采购货运状态完成

                        //货运状态完成
                        List<Delivery> deliveries =
                            QueryForObjs(GetObjQuery<Delivery>(ctx),
                                         d =>
                                         d.QuotaId == quotaId && d.IsDeleted == false &&
                                         (d.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                                          d.DeliveryType == (int)DeliveryType.ExternalTDWW ||
                                          d.DeliveryType == (int)DeliveryType.InternalTDBOL ||
                                          d.DeliveryType == (int)DeliveryType.InternalTDWW)).ToList();
                        foreach (Delivery delivery in deliveries)
                        {
                            if (delivery.WarrantId.HasValue && delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL)
                                continue;
                            string sql = "it.DeliveryId==" + delivery.Id;
                            if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                                delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                            {
                                //外贸
                                verifiedQuantity += GetSum<DeliveryLine>(sql, null, o => o.NetWeight);
                            }
                            else
                            {
                                //内贸
                                verifiedQuantity += GetSum<DeliveryLine>(sql, null, o => o.VerifiedWeight);
                            }
                        }
                    }
                        #endregion

                    else if (quota.Contract.ContractType == (int)ContractType.Sales)
                    {
                        #region 销售批次货运状态完成

                        //销售批次(出库数量+发货单数量)
                        //1.出库数量
                        verifiedQuantity += GetWarehouseOutQuantity(quotaId, userId);

                        //2.发货单数量
                        List<Delivery> deliveries =
                            QueryForObjs(GetObjQuery<Delivery>(ctx),
                                         d =>
                                         d.QuotaId == quotaId &&
                                         (d.DeliveryType == (int)DeliveryType.ExternalMDBOL ||
                                          d.DeliveryType == (int)DeliveryType.ExternalMDWW ||
                                          d.DeliveryType == (int)DeliveryType.InternalMDBOL ||
                                          d.DeliveryType == (int)DeliveryType.InternalMDWW)).ToList();

                        foreach (Delivery delivery in deliveries)
                        {
                            if (delivery.WarrantId.HasValue && delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL)
                                continue;
                            int deliveryId = delivery.Id;
                            string sql = "it.DeliveryId==" + deliveryId;
                            if (delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL ||
                                delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
                            {
                                //外贸，取净重
                                verifiedQuantity += GetSum<DeliveryLine>(sql, null, o => o.NetWeight);
                            }
                            else
                            {
                                //内贸,取实际数量
                                verifiedQuantity += GetSum<DeliveryLine>(sql, null, o => o.VerifiedWeight);
                            }
                        }

                        #endregion
                    }
                }
            }

            return verifiedQuantity;
        }

        /// <summary>
        ///     取点价完成的批次的点价价格的加权平均值（手工点价加权平均，其余直接取最终价格，币种按照价格币种）
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetPriceByQuotaPricing(int quotaId, int userId)
        {
            //1、固定价/平均价：对应的唯一一条点价记录的最终价格
            //2、手工点价：对应的所有点价记录的最终价格加权平均

            decimal price = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == quotaId);
                if (quota.PricingType != (int)PricingType.Fixed)
                {
                    //平均价和手工点价
                    decimal sumMoney = GetSum<Pricing>("it.QuotaId=" + quota.Id, null,
                                                       o => o.FinalPrice * o.PricingQuantity);
                    decimal sumUnpricingMoney = GetSum<Unpricing>("it.QuotaId=" + quotaId, null, o => (o.UnpricingQuantity ?? 0) * (quota.TempPrice ?? 0));

                    decimal sumQuantity = GetSum<Pricing>("it.QuotaId=" + quota.Id, null, o => o.PricingQuantity);

                    decimal sumUnpricingQuantity = GetSum<Unpricing>("it.QuotaId=" + quotaId, null, o => o.UnpricingQuantity ?? 0);

                    if (sumQuantity == 0)
                        return (quota.TempPrice ?? 0);

                    price = (sumMoney + sumUnpricingMoney) / (sumQuantity + sumUnpricingQuantity);
                }
                else
                {
                    //固定价
                    Pricing pricing = QueryForObj(GetObjQuery<Pricing>(ctx), p => p.QuotaId == quotaId);
                    if (pricing != null && pricing.FinalPrice != null)
                    {
                        price = pricing.FinalPrice.Value;
                    }
                }
            }

            return price;
        }

        /// <summary>
        ///     返回内贸用于计算应收应付的价格
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetPriceByQuotaPricingWithRate(int quotaId, int userId)
        {
            decimal price = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == quotaId);
                if (quota.PricingType != (int)PricingType.Fixed)
                {
                    //平均价和手工点价
                    decimal sumMoney = GetSum<Pricing>("it.QuotaId=" + quotaId, null,
                                                       o => o.FinalPrice * o.PricingQuantity * o.ExchangeRate);
                    decimal sumUnpricingMoney = GetSum<Unpricing>("it.QuotaId=" + quotaId, null, o => (o.UnpricingQuantity ?? 0) * (quota.TempPrice ?? 0));
                    decimal sumQuantity = GetSum<Pricing>("it.QuotaId=" + quotaId, null, o => o.PricingQuantity);
                    decimal sumUnpricingQuantity = GetSum<Unpricing>("it.QuotaId=" + quotaId, null, o => o.UnpricingQuantity ?? 0);
                    if (sumQuantity == 0)   //未点价直接返回暂定价
                        return (quota.TempPrice ?? 0);
                    price = (sumMoney + sumUnpricingMoney) / (sumQuantity + sumUnpricingQuantity);
                }
                else
                {
                    //固定价
                    Pricing pricing = QueryForObj(GetObjQuery<Pricing>(ctx), p => p.QuotaId == quotaId);
                    if (pricing != null && pricing.FinalPrice != null && pricing.ExchangeRate.HasValue)
                    {
                        price = pricing.FinalPrice.Value * pricing.ExchangeRate.Value;
                    }
                }
            }

            return price;
        }

        /// <summary>
        ///     计算外贸批次应收应付，外贸 = 最终发票金额 + 没有被调整的临时发票的金额，按结算币种换算
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        public decimal GetAmountByQuotaId(int quotaId, int userId)
        {
            decimal amount = 0M;

            //临时发票金额
            amount +=
                GetSum<CommercialInvoice>(
                    "it.QuotaId ==" + quotaId + " and it.InvoiceType ==" + (int)CommercialInvoiceType.Provisional +
                    " and it.FinalInvoiceId is null", null, o => o.Amount);
            //最终发票金额
            amount +=
                GetSum<CommercialInvoice>(
                    "it.QuotaId ==" + quotaId + " and it.InvoiceType ==" + (int)CommercialInvoiceType.Final, null,
                    o => o.Amount);

            //商业发票金额
            amount +=
                GetSum<CommercialInvoice>(
                "it.QuotaId ==" + quotaId + " and it.InvoiceType ==" + (int)CommercialInvoiceType.FinalCommercial, null,
                    o => o.Amount
                );
            return amount;
        }

        /// <summary>
        ///     根据批次Id获取已付款金额，信用证交单金额+现金付款，按结算币种换算
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        public decimal GetPayAmountByQuotaId(int quotaId, int userId)
        {
            decimal amount = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), p => p.Id == quotaId);
                if (quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    //采购
                    amount += GetPresentAmount(quotaId, userId);
                }
                amount += GetPayFundFlowAmount(quotaId, userId);
            }
            return amount;
        }

        /// <summary>
        ///     根据批次Id获取已收款金额，信用证交单金额+现金收款，按结算币种换算
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetReceivableAmountByQuotaId(int quotaId, int userId)
        {
            decimal amount = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), p => p.Id == quotaId);
                if (quota.Contract.ContractType == (int)ContractType.Sales)
                {
                    //销售
                    amount += GetPresentAmount(quotaId, userId);
                }
                amount += GetReciveFundFlowAmount(quotaId, userId);
            }

            return amount;
        }

        /// <summary>
        ///     根据批次ID查询价格币种
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public string GetCurrencyByPricing(int quotaId)
        {
            string value = string.Empty;
            using (var ctx = new SenLan2Entities())
            {
                List<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quotaId).ToList();
                if (pricings.Count > 0)
                {
                    Pricing pricing = pricings[0];
                    if (pricing.CurrencyId.HasValue)
                    {
                        int cId = pricing.CurrencyId.Value;
                        Currency currency = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Id == cId);
                        value = currency.Name;
                    }
                }
            }

            return value;
        }

        /// <summary>
        ///     根据批次ID查询结算币种，外贸批次结算币种 = 商业发票的结算币种，如果没有商业发票，取点价币种。内贸统一用人民币
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public Currency GetSettlementCurrencyByQuotaId(int quotaId)
        {
            using (var ctx = new SenLan2Entities())
            {
                Quota q = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Currency" }),
                                      c => c.Id == quotaId);
                if (q.Contract.TradeType == (int)TradeType.LongForeignTrade ||
                    q.Contract.TradeType == (int)TradeType.ShortForeignTrade)
                {
                    List<CommercialInvoice> list =
                        QueryForObjs(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "Currency" }),
                                     c => c.QuotaId == quotaId).ToList();

                    if (list.Count > 0)
                        return list[0].Currency;

                    return q.Currency;
                }
                if (_cnyCurrency == null)
                {
                    Currency cu = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == "CNY");
                    _cnyCurrency = cu;
                    return cu;
                }

                return _cnyCurrency;
            }
        }

        /// <summary>
        ///     根据批次获取实际数量、价格、应付应收、已付已收、余额、已开票数量
        /// </summary>
        /// <param name="quota">批次</param>
        /// <param name="userId">用户Id</param>
        /// <param name="price">价格</param>
        /// <param name="yingf">应付</param>
        /// <param name="yings">应收</param>
        /// <param name="yif">已付</param>
        /// <param name="yis">已收</param>
        /// <param name="ye">余额</param>
        /// <param name="pricingCurrencyName">点价币种名称</param>
        /// <param name="currencyName">结算币种名称</param>
        /// <param name="currencyId">结算币种Id</param>
        /// <param name="yik">已开票数量</param>
        /// <returns>实际数量</returns>
        public decimal GetAparReportDataByQuota(Quota quota, int userId, out decimal? price, out decimal? yingf,
                                                out decimal? yings, out decimal? yif, out decimal? yis,
                                                out decimal? ye, out string pricingCurrencyName,
                                                out string currencyName, out int currencyId, out decimal yik)
        {
            yingf = null;
            yings = null;

            pricingCurrencyName = quota.Currency.Name;
            decimal quantity = quota.VerifiedQuantity;
            price = quota.FinalPrice ?? 0;
            if (quota.Contract.ContractType == (int)ContractType.Purchase)
            {
                //采购批次(应付、已付、已收)
                if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                    quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    //内贸
                    yingf = quota.Equality ?? 0;

                    if (_cnyCurrency == null)
                    {
                        Currency cny = GetCurrencyByCode(userId, "CNY");
                        _cnyCurrency = cny;
                    }
                    currencyId = _cnyCurrency.Id;
                    currencyName = "人民币";
                }
                else
                {
                    //外贸
                    yingf = quota.Equality ?? 0;
                    Currency c = GetSettlementCurrencyByQuota(quota);
                    currencyName = c != null ? c.Name : "";
                    currencyId = c.Id;
                }
                yif = quota.PaidAmount ?? 0; //已付
                yis = quota.ReceivedAmount ?? 0; //已收
                ye = -(yingf - yif + yis); //余额=应付-已付+已收
            }
            else
            {
                //销售批次(应收、已收、已付)
                if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                    quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    //内贸
                    yings = quota.Equality ?? 0;
                    if (_cnyCurrency == null)
                    {
                        Currency cny = GetCurrencyByCode(userId, "CNY");
                        _cnyCurrency = cny;
                    }
                    currencyId = _cnyCurrency.Id;
                    currencyName = "人民币";
                }
                else
                {
                    //外贸
                    yings = quota.Equality ?? 0;
                    Currency c = GetSettlementCurrencyByQuota(quota);
                    currencyId = c.Id;
                    currencyName = c != null ? c.Name : "";
                }
                yif = quota.PaidAmount ?? 0; //已付
                yis = quota.ReceivedAmount ?? 0; //已收
                ye = yings - yis + yif; //余额=应收-已收+已付
            }
            yik = quota.VATInvoicedQuantity ?? 0; //已开票数量(批次货运财务状态变更报表使用)


            return quantity;
        }

        /// <summary>
        ///     根据批次获取点价和未点价的总金额
        /// </summary>
        /// <param name="quota"></param>
        /// <param name="commodityDictionary"></param>
        /// <param name="qtyCount">数量</param>
        /// <param name="avgPrice">均价</param>
        /// <param name="userId"></param>
        /// <param name="containsUnPricing">true：包括未点价 false:不包括未点价</param>
        /// <param name="containsRate">true：计算汇率，内贸返回人民币币种 外贸返回美元 false:不计算汇率</param>
        /// <param name="convertCurrency">true：内贸返回人民币币种 外贸返回美元 false:外贸返回人民币</param>
        /// <returns></returns>
        public decimal GetQuotaAmount(Quota quota, ref Dictionary<string, decimal> commodityDictionary,
                                      ref decimal qtyCount, ref decimal avgPrice, int userId,
                                      bool containsUnPricing = false,
                                      bool containsRate = false, bool convertCurrency = true)
        {
            decimal amount = 0;

            using (var ctx = new SenLan2Entities())
            {
                if (_usdCurrency == null)
                {
                    _usdCurrency = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == "USD");
                }
                if (_cnyCurrency == null)
                    _cnyCurrency = QueryForObj(GetObjQuery<Currency>(ctx),
                                              c => c.Code == "CNY");
                if (_cny2USDRate == 0)
                {
                    _cny2USDRate = GetExchangeRate(_cnyCurrency.Id, _usdCurrency.Id, userId);
                }
                if (_usd2CNYRate == 0)
                {
                    _usd2CNYRate = GetExchangeRate(_usdCurrency.Id, _cnyCurrency.Id, userId);
                }
                //点价的金额
                List<Pricing> pricingList = quota.Pricings.Where(o => o.IsDeleted == false).ToList();
                if (!containsRate)
                {
                    //不计算汇率

                    amount +=
                        quota.Pricings.Where(o => o.IsDeleted == false)
                             .Sum(o => (o.PricingQuantity ?? 0) * (o.FinalPrice ?? 0));
                }
                else
                {
                    //计算汇率
                    if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                        quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                    {
                        //内贸,直接取点价表里边的汇率
                        amount +=
                            quota.Pricings.Where(o => o.IsDeleted == false)
                                 .Sum(o => (o.PricingQuantity ?? 0) * (o.FinalPrice ?? 0) * (o.ExchangeRate ?? 0));
                    }
                    else
                    {
                        //外贸，金额转成美元

                        if (pricingList.Count > 0)
                        {
                            decimal pricingAmount;
                            if (convertCurrency)
                            {
                                //转成美元
                                if (quota.PricingCurrencyId == _usdCurrency.Id)
                                {
                                    //点价币种是美元,不变
                                    pricingAmount = pricingList.Sum(o => (o.PricingQuantity * o.FinalPrice) ?? 0);
                                }
                                else
                                {
                                    //点价币种不是美元，根据人民币转成美元
                                    pricingAmount =
                                        pricingList.Sum(
                                            o => (o.PricingQuantity * o.FinalPrice * o.ExchangeRate * _cny2USDRate) ?? 0);
                                }
                            }
                            else
                            {
                                //转成人民币 
                                if (quota.PricingCurrencyId == _cnyCurrency.Id)
                                {
                                    pricingAmount = pricingList.Sum(o => (o.PricingQuantity * o.FinalPrice) ?? 0);
                                }
                                else
                                {
                                    //不是人民币，转成人民币
                                    pricingAmount =
                                        pricingList.Sum(o => (o.PricingQuantity * o.FinalPrice * o.ExchangeRate) ?? 0);
                                }
                            }
                            amount += pricingAmount;
                        }
                    }
                }
                qtyCount += pricingList.Sum(o => o.PricingQuantity ?? 0);

                if (quota.PricingStatus == (int)PricingStatus.Complete)
                {
                    //点价完成，金额=点价价格的加权平均 * 批次的实际数量
                    avgPrice = amount / qtyCount;
                    amount = avgPrice * quota.VerifiedQuantity;
                    return amount;
                }

                if (containsUnPricing)
                {
                    if (quota.PricingStatus != (int)PricingStatus.Complete)
                    {
                        //未点价的金额
                        if (quota.PricingType != (int)PricingType.Fixed)
                        {
                            string key = quota.CommodityId + " " + quota.PricingBasis;
                            List<Unpricing> unpricings = quota.Unpricings.Where(o => o.IsDeleted == false).ToList();
                            foreach (Unpricing unpricing in unpricings)
                            {
                                if (unpricing.UnpricingQuantity != null && unpricing.UnpricingQuantity != 0)
                                {
                                    decimal qty = unpricing.UnpricingQuantity.Value;
                                    qtyCount += qty;
                                    //decimal currentPrice = commodityDictionary.ContainsKey(key)
                                    //                           ? commodityDictionary[key]
                                    //                           : GetQuotaCurrentPrice(quota, ctx,
                                    //                                                  ref commodityDictionary);
                                    decimal currentPrice = quota.TempPrice == null ? 0 : quota.TempPrice.Value;
                                    if (currentPrice != 0 && currentPrice != -1)
                                    {
                                        if (quota.Premium != null) currentPrice += quota.Premium.Value;
                                    }
                                    if (containsRate)
                                    {
                                        int pricingBasisCurrentId;
                                        if (!_pricingBasises.ContainsKey(quota.PricingBasis.Value))
                                        {
                                            var pricingService = new PricingService();
                                            pricingBasisCurrentId =
                                                pricingService.GetCurrencyByPricingBasis(
                                                    (PricingBasis)quota.PricingBasis).Id;
                                            _pricingBasises.Add(quota.PricingBasis.Value, pricingBasisCurrentId);
                                        }
                                        else
                                        {
                                            pricingBasisCurrentId = _pricingBasises[quota.PricingBasis.Value];
                                        }
                                        decimal rate;
                                        if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                                            quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                                        {
                                            //内贸,用人民币计算

                                            if (!_cnyRate.ContainsKey(pricingBasisCurrentId))
                                            {
                                                rate = GetExchangeRate(_cnyCurrency.Id, pricingBasisCurrentId, userId);
                                                _cnyRate.Add(pricingBasisCurrentId, rate);
                                            }
                                        }
                                        else
                                        {
                                            //外贸，用美元计算

                                            if (_usdCurrency == null)
                                                _usdCurrency = QueryForObj(GetObjQuery<Currency>(ctx),
                                                                          c => c.Code == "USD");


                                            if (!_usdRate.ContainsKey(pricingBasisCurrentId))
                                            {
                                                rate = GetExchangeRate(_usdCurrency.Id, pricingBasisCurrentId, userId);
                                                _usdRate.Add(pricingBasisCurrentId, rate);
                                            }
                                        }
                                        if (convertCurrency)
                                        {
                                            //美元
                                            if (pricingBasisCurrentId == _usdCurrency.Id)
                                            {
                                                //点价基准是美元
                                                amount += qty * currentPrice;
                                            }
                                            else
                                            {
                                                amount += qty * currentPrice * _cny2USDRate;
                                            }
                                        }
                                        else
                                        {
                                            //人民币
                                            if (pricingBasisCurrentId == _cnyCurrency.Id)
                                            {
                                                amount += qty * currentPrice;
                                            }
                                            else
                                            {
                                                amount += qty * currentPrice * _usd2CNYRate;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //不计算汇率
                                        amount += qty * currentPrice;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            avgPrice = qtyCount == 0 ? 0 : amount / qtyCount;
            return amount;
        }

        public decimal GetQuotaAmountsByQuota(List<Quota> quotas, int userId)
        {
            decimal amount = 0;
            foreach (Quota quota in quotas)
            {
                decimal qty = 0;
                decimal price = 0;
                amount += GetQuotaAmount(quota, ref _commodityDictionary, ref qty, ref price, userId, true, false, false);
            }
            return amount;
        }

        /// <summary>
        ///     根据履约日期、金属、内部客户查询所有批次（审批未通过、删除、作废的除外）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="commodityId"></param>
        /// <param name="internalCustomerID"></param>
        /// <returns></returns>
        public List<Quota> GetAllQuotaListByDateAndCommodity(DateTime? startDate, DateTime endDate, int? commodityId,
                                                             int internalCustomerID)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    IEnumerable<Quota> list =
                        QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Pricings", "Unpricings" }),
                                     c =>
                                     c.Contract.InternalCustomerId == internalCustomerID &&
                                     (c.ApproveStatus == (int)ApproveStatus.NoApproveNeeded ||
                                      c.ApproveStatus == (int)ApproveStatus.Approved) &&
                                     c.ImplementedDate <= endDate.Date);
                    if (startDate != null)
                        list = list.Where(c => c.ImplementedDate >= startDate);
                    if (commodityId != null && commodityId != 0)
                        list = list.Where(c => c.CommodityId == commodityId);
                    return list.ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 获取满足条件的所有批次的数量和(合同列表合计行用)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        /// <param name="eagorLoad"></param>
        /// <returns></returns>
        public decimal GetQuotaSumQty(string str, List<object> param, List<string> eagorLoad)
        {
            return SelectSum<Quota>(str, param, eagorLoad, o => o.Quantity);
        }

        /// <summary>
        /// 获取满足条件的所有批次的金额和(合同列表合计行用)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        /// <param name="eagorLoad"></param>
        /// <returns></returns>
        public decimal GetQuotaSumAmount(string str, List<object> param, List<string> eagorLoad, out decimal sumQty)
        {
            if (!eagorLoad.Contains("Pricings"))
            {
                eagorLoad.Add("Pricings");
            }
            List<Quota> quotas = Select(str, param, eagorLoad).ToList();
            sumQty = quotas.Sum(o => o.Quantity ?? 0);
            decimal amount = 0;
            amount = quotas.Sum(c => c.Quantity * c.FinalPrice) ?? 0;
            //PricingService pricing = new PricingService();
            //foreach (var quota in quotas)
            //{
            //    EntityUtil.FilterDeletedEntity(quota.Pricings);
            //    decimal avgPrice = GetAvgPricing(quota);
            //    amount += quota.VerifiedQuantity * avgPrice;
            //}

            return amount;
        }

        private decimal GetAvgPricing(Quota quota)
        {
            decimal avgPrice = 0;

            decimal sumQty = 0;
            decimal sumAmount = 0;
            foreach (var pricing in quota.Pricings)
            {
                sumQty += pricing.PricingQuantity ?? 0;
                sumAmount += (pricing.PricingQuantity ?? 0) * (pricing.FinalPrice ?? 0) * (pricing.ExchangeRate ?? 0);
            }

            if (sumQty == 0)
                return 0;

            avgPrice = sumAmount / sumQty;
            return avgPrice;
        }

        /// <summary>
        ///     根据批次查询结算币种，外贸批次结算币种 = 商业发票的结算币种，如果没有商业发票，取点价币种。内贸统一用人民币
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public Currency GetSettlementCurrencyByQuota(Quota q)
        {
            using (var ctx = new SenLan2Entities())
            {
                if (q.Contract.TradeType == (int)TradeType.LongForeignTrade ||
                    q.Contract.TradeType == (int)TradeType.ShortForeignTrade)
                {
                    var list = new List<CommercialInvoice>();
                    if (q.CommercialInvoices != null && q.CommercialInvoices.Count > 0)
                    {
                        list.AddRange(q.CommercialInvoices.Where(invoice => !invoice.IsDeleted));
                    }
                    if (list.Count > 0)
                    {
                        return list[0].Currency;
                    }

                    return q.Currency;
                }

                if (_cnyCurrency == null)
                {
                    Currency cu = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == "CNY");
                    _cnyCurrency = cu;
                    return cu;
                }

                return _cnyCurrency;
            }
        }

        /// <summary>
        ///     根据批次Id获取实际数量、价格、应付应收、已付已收、余额、已开票数量
        /// </summary>
        /// <param name="quotaId">批次Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="price">价格</param>
        /// <param name="yingf">应付</param>
        /// <param name="yings">应收</param>
        /// <param name="yif">已付</param>
        /// <param name="yis">已收</param>
        /// <param name="ye">余额</param>
        /// <param name="pricingCurrencyName">点价币种名称</param>
        /// <param name="currencyName">结算币种名称</param>
        /// <param name="yik">已开票数量</param>
        /// <returns>实际数量</returns>
        public decimal GetAparReportDataByQuotaId(int quotaId, int userId, out decimal? price, out decimal? yingf,
                                                  out decimal? yings, out decimal? yif, out decimal? yis,
                                                  out decimal? ye, out string pricingCurrencyName,
                                                  out string currencyName, out decimal yik)
        {
            decimal quantity;
            yingf = null;
            yings = null;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota =
                    QueryForObj(
                        GetObjQuery<Quota>(ctx,
                                           new List<string>
                                               {
                                                   "Contract",
                                                   "Currency",
                                                   "CommercialInvoices",
                                                   "CommercialInvoices.Currency"
                                               }),
                        o => o.Id == quotaId);
                pricingCurrencyName = quota.Currency.Name;
                quantity = quota.VerifiedQuantity; //实际数量
                price = quota.FinalPrice ?? 0;
                if (quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    // //采购批次(应付、已付、已收)
                    if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                        quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                    {
                        //内贸
                        yingf = quota.Equality ?? 0;
                        currencyName = "人民币";
                    }
                    else
                    {
                        //外贸
                        yingf = quota.Equality ?? 0;
                        Currency c = GetSettlementCurrencyByQuota(quota);
                        currencyName = c != null ? c.Name : "";
                    }
                    yif = quota.PaidAmount ?? 0; //已付
                    yis = quota.ReceivedAmount ?? 0; //已收
                    ye = -(yingf - yif + yis); //余额=应付-已付+已收
                }
                else
                {
                    //销售批次(应收、已收、已付)
                    if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                        quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                    {
                        //内贸
                        yings = quota.Equality ?? 0;
                        currencyName = "人民币";
                    }
                    else
                    {
                        //外贸
                        yings = quota.Equality ?? 0;
                        Currency c = GetSettlementCurrencyByQuota(quota);
                        currencyName = c != null ? c.Name : "";
                    }
                    yif = quota.PaidAmount ?? 0; //已付
                    yis = quota.ReceivedAmount ?? 0; //已收
                    ye = yings - yis + yif; //余额=应收-已收+已付
                }
                yik = quota.VATInvoicedQuantity ?? 0; //已开票数量(批次货运财务状态变更报表使用)
            }

            return quantity;
        }

        public void UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(int quotaId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                if (quota != null)
                {
                    decimal verQty = GetVerifiedQuantity(quotaId, userId);
                    quota.VerifiedQuantity = verQty;

                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();

                    //修改应收应付金额字段
                    SetEqualityByQuotaId(quotaId, userId);

                    //维护批次的开票状态
                    //Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                    if (((quota.VATInvoicedQuantity ?? 0) != 0) && quota.VATInvoicedQuantity == quota.VerifiedQuantity)
                    {
                        quota.VATStatus = (int)QuotaVATStatus.Complete;
                    }
                    else if (quota.VATInvoicedQuantity == 0)
                    {
                        quota.VATStatus = (int)QuotaVATStatus.NotAtAll;
                    }
                    else
                    {
                        quota.VATStatus = (int)QuotaVATStatus.Partial;
                    }
                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();
                }
            }
        }

        private void UpdateStatusQuota(Quota quota, Quota masterQuoa, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == quota.Id);
                if (masterQuoa == null)
                {
                    oldQuota.DeliveryStatus = quota.DeliveryStatus; //货运状态
                    oldQuota.FinanceStatus = quota.FinanceStatus; //财务状态
                }
                else
                {
                    oldQuota.DeliveryStatus = masterQuoa.DeliveryStatus; //货运状态
                    oldQuota.FinanceStatus = masterQuoa.FinanceStatus; //财务状态
                }

                Update(GetObjSet<Quota>(ctx), oldQuota);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        ///     根据履约日期、金属、内部客户查询所有批次（审批未通过、删除、作废的除外）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="commodityId"></param>
        /// <param name="internalCustomerID"></param>
        /// <param name="innerTrade"></param>
        /// <returns></returns>
        public List<Quota> GetAllQuotaListByDateAndCommodity(DateTime? startDate, DateTime endDate, int? commodityId,
                                                             int internalCustomerID, bool innerTrade)
        {
            List<object> parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
            sb.AppendFormat("it.Contract.InternalCustomerId = @p{0} ", num++);
            parameters.Add(internalCustomerID);

            sb.AppendFormat(" and (it.ApproveStatus = @p{0} ", num++);
            sb.AppendFormat(" or it.ApproveStatus = @p{0}) ", num++);
            parameters.Add((int)ApproveStatus.NoApproveNeeded);
            parameters.Add((int)ApproveStatus.Approved);

            sb.AppendFormat("and it.ImplementedDate <= @p{0} ", num++);
            parameters.Add(endDate.Date);

            sb.AppendFormat(" and (it.Contract.TradeType = @p{0} ", num++);
            sb.AppendFormat(" or it.Contract.TradeType = @p{0}) ", num++);
            if (innerTrade)
            {
                parameters.Add((int)TradeType.LongDomesticTrade);
                parameters.Add((int)TradeType.ShortDomesticTrade);
            }
            else
            {
                parameters.Add((int)TradeType.LongForeignTrade);
                parameters.Add((int)TradeType.ShortForeignTrade);
            }

            if (startDate != null)
            {
                sb.AppendFormat("and it.ImplementedDate >= @p{0} ", num++);
                parameters.Add(startDate.Value);
            }

            if (commodityId != null && commodityId != 0)
            {
                sb.AppendFormat("and it.CommodityId = @p{0} ", num++);
                parameters.Add(commodityId.Value);
            }

            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<Quota> list = Select(sb.ToString(), parameters, new List<string> { "Contract", "Pricings", "UnPricings" }).ToList();

                    return list;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        private List<int> _financialAccountList = new List<int>();

        /// <summary>
        ///     获得货款的会计科目Id及子科目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<int> GetFinancialAccount(int userId)
        {
            if (_financialAccountList.Count > 0)
            {
                return _financialAccountList;
            }
            var financialAccount = new List<int>();

            using (var ctx = new SenLan2Entities(userId))
            {
                List<FinancialAccount> financialAccounts =
                    QueryForObjs(GetObjQuery<FinancialAccount>(ctx), o => o.IsDeleted == false).ToList();

                FinancialAccount fa = QueryForObj(GetObjQuery<FinancialAccount>(ctx), o => o.Name.Trim() == "货款");

                int id = fa.Id; //货款科目的Id
                IEnumerable<FinancialAccount> list = GetList(id, financialAccounts);
                financialAccount.Add(id);
                financialAccount.AddRange(list.Select(account => account.Id));
            }
            _financialAccountList = financialAccount;
            return financialAccount;
        }

        public decimal GetExchangeRate(int? settleCurr, int curr, int userId)
        {
            if (!settleCurr.HasValue)
                return 1;
            var rateService = new RateService();
            decimal? rate = rateService.GetExchangeRate(curr, settleCurr.Value, userId);
            return rate.HasValue ? rate.Value : 1;
        }

        /// <summary>
        ///     根据批次Id取出库数量
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetWarehouseOutQuantity(int quotaId, int userId)
        {
            decimal quantity = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                List<WarehouseOut> warehouseOuts =
                    QueryForObjs(GetObjQuery<WarehouseOut>(ctx), w => w.QuotaId == quotaId).ToList();
                foreach (WarehouseOut warehouseOut in warehouseOuts)
                {
                    int warehouseOutId = warehouseOut.Id;
                    quantity += GetSum<WarehouseOutLine>("it.WarehouseOutId==" + warehouseOutId, null,
                                                         o => o.VerifiedQuantity);
                }
            }
            return quantity;
        }

        /// <summary>
        /// 和合同关联的信用证都算入已收已付
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetPresentAmount(int quotaId, int userId)
        {
            return SelectSum<LetterOfCredit>("it.QuotaId == " + quotaId, null, null, l => l.PresentAmount);
            //decimal presentAmount = 0M;

            //int commercialInvoiceCount = GetCount<CommercialInvoice>("it.QuotaId ==" + quotaId, null);
            //if (commercialInvoiceCount > 0)
            //{
            //    //如果没有开商业发票，则不计算信用证的交单金额
            //    using (var ctx = new SenLan2Entities(userId))
            //    {
            //        List<CommercialInvoice> provisionalInvoices =
            //            QueryForObjs(GetObjQuery<CommercialInvoice>(ctx),
            //                         o =>
            //                         o.QuotaId == quotaId && o.InvoiceType == (int)CommercialInvoiceType.Provisional)
            //                .ToList();
            //        foreach (CommercialInvoice invoice in provisionalInvoices)
            //        {
            //            List<LCCIRel> rels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == invoice.Id).ToList();
            //            presentAmount += rels.Sum(o => o.AllocationAmount ?? 0);
            //        }
            //        List<CommercialInvoice> finalCommercialInvoices =
            //            QueryForObjs(GetObjQuery<CommercialInvoice>(ctx),
            //                         o =>
            //                         o.QuotaId == quotaId && o.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
            //                .ToList();
            //        foreach (CommercialInvoice invoice in finalCommercialInvoices)
            //        {
            //            List<LCCIRel> rels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == invoice.Id).ToList();
            //            presentAmount += rels.Sum(o => o.AllocationAmount ?? 0);
            //        }
            //    }
            //}

            //return presentAmount;
        }

        /// <summary>
        /// 获取现金付款的金额，按结算币种换算
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetPayFundFlowAmount(int quotaId, int userId)
        {
            decimal amount = 0M;
            decimal quotaGroupQuantity = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota q = GetById(GetObjQuery<Quota>(ctx), quotaId);
                IEnumerable<int> list = GetFinancialAccount(userId);
                string strFinancialAccountId = GetQueryFinancialAccountId(list);
                amount += SelectSum<FundFlow>("it.Quota.QuotaGroupId == " + q.QuotaGroupId + " and it.RorP == " + (int)FundFlowType.Pay + " and " +
                      strFinancialAccountId, null, new List<string> { "Quota" }, o => o.Amount * o.Rate);

                quotaGroupQuantity = GetQuotaGroupQuantityByGroupId(q.QuotaGroupId);
                return Math.Round(amount * q.VerifiedQuantity / quotaGroupQuantity, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
            }
        }

        private string GetQueryFinancialAccountId(IEnumerable<int> list)
        {
            var sb = new StringBuilder("(");
            foreach (int i in list)
            {
                if (sb.Length > 1)
                    sb.Append(" or ");
                sb.Append("it.FinancialAccountId == " + i);
            }
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        ///     获取现金收款的金额，按结算币种换算
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetReciveFundFlowAmount(int quotaId, int userId)
        {
            decimal amount = 0M;
            decimal quotaGroupQuantity = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota q = GetById(GetObjQuery<Quota>(ctx), quotaId);
                IEnumerable<int> list = GetFinancialAccount(userId);
                string strFinancialAccountId = GetQueryFinancialAccountId(list);
                amount += SelectSum<FundFlow>("it.Quota.QuotaGroupId == " + q.QuotaGroupId + " and it.RorP == " + (int)FundFlowType.Receive + " and " +
                    strFinancialAccountId, null, new List<string> { "Quota" }, o => o.Amount * o.Rate);

                quotaGroupQuantity = GetQuotaGroupQuantityByGroupId(q.QuotaGroupId);
                return Math.Round(amount * q.VerifiedQuantity / quotaGroupQuantity, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
            }
        }

        /// <summary>
        /// 递归获取货款子科目
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private IEnumerable<FinancialAccount> GetList(int id, IEnumerable<FinancialAccount> list)
        {
            IEnumerable<FinancialAccount> query = from fa in list where fa.ParentId == id select fa;
            return query.Concat(query.SelectMany(t => GetList(t.Id, list)));
        }


        private decimal GetQuotaCurrentPrice(Quota quota, SenLan2Entities ctx,
                                             ref Dictionary<string, decimal> commodityDictionary)
        {
            decimal price = 0;
            if (quota != null)
            {
                string key = quota.CommodityId + " " + quota.PricingBasis;
                Commodity comm = GetById(GetObjQuery<Commodity>(ctx), quota.CommodityId ?? 0);
                CurrentPrice cp = MarketPriceManager.GetCurrentPrice(quota.PricingBasis ?? 0, comm);
                price = cp.Price;
                commodityDictionary.Add(key, price);
            }
            return price;
        }

        #region 批次多品牌计算加权平均价

        public decimal GetAvgPrice(List<QuotaBrandRel> list)
        {
            decimal price = 0;
            decimal totalQty = 0;
            decimal totalAmount = 0;
            if (list.Count > 0)
            {
                foreach (QuotaBrandRel brandRel in list)
                {
                    if (!brandRel.IsDeleted)
                    {
                        totalQty += brandRel.Quantity.Value;
                        totalAmount += (brandRel.Quantity.Value * brandRel.Price.Value);
                    }
                }
            }
            if (totalQty != 0)
            {
                price = totalAmount / totalQty;
            }
            return price;
        }

        #endregion

        #region 应收应付账款批次查询

        public List<ARAPClass> GetARAPReportData(int bPId, int innerCustomerId, int commodityId, DateTime? startDate,
                                                 DateTime? endDate, string quotaNo, int userId)
        {
            var Templist = new List<ARAPClass>();
            List<ARAPClass> ListAraps = new List<ARAPClass>();
            List<object> parameters = new List<object>();
            var sb = new StringBuilder();
            string queryStr;
            int num = 1;
            sb.AppendFormat("it.FinanceStatus = @p{0} ", num++);
            sb.AppendFormat(" and (it.ApproveStatus = @p{0} ", num++);
            sb.AppendFormat(" or it.ApproveStatus = @p{0}) ", num++);
            parameters.Add(false);
            parameters.Add((int)ApproveStatus.NoApproveNeeded);
            parameters.Add((int)ApproveStatus.Approved);

            if (bPId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.BPId = @p{0}", num++);
                parameters.Add(bPId);
            }

            if (innerCustomerId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.InternalCustomerId = @p{0}", num++);
                parameters.Add(innerCustomerId);
            }

            if (commodityId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0}", num++);
                parameters.Add(commodityId);
            }

            //if (startDate != null)
            //{
            //    if (sb.Length != 0)
            //    {
            //        sb.Append(" and ");
            //    }
            //    sb.AppendFormat("it.Contract.SignDate >= @p{0}", num++);
            //    parameters.Add(startDate);
            //}

            if (endDate != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.SignDate <= @p{0}", num++);
                parameters.Add(endDate);
            }
            if (!string.IsNullOrWhiteSpace(quotaNo))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.QuotaNo Like @p{0}", num);
                parameters.Add("%" + quotaNo.Trim() + "%");
            }
            queryStr = sb.ToString();
            using (var ctx = new SenLan2Entities())
            {
                IEnumerable<Quota> quotas = Select(queryStr, parameters, new List<string>
                                               {
                                                   //"Contract",
                                                   "Currency",
                                                   "Brand",
                                                   "Commodity",
                                                   "CommercialInvoices",
                                                   "CommercialInvoices.Currency",
                                                   "Contract.InternalCustomer",
                                                   "Contract.BusinessPartner"
                                                   //"QuotaBrandRels",
                                                   //"QuotaBrandRels.Brand"
                                               });

                User currentUser = QueryForObj(GetObjQuery<User>(ctx, new List<string> { "UserICLinks" }), o => o.Id == userId);
                List<UserICLink> userICLink = currentUser.UserICLinks.ToList();
                List<int> idList = userICLink.Select(o => o.BusinessPartnerId).ToList();
                quotas = quotas.Where(c => idList.Contains(c.Contract.InternalCustomerId.Value)).ToList();
                foreach (Quota quota in quotas)
                {
                    ARAPClass item = GetARAPClassByQuota(quota, userId);
                    if (item != null)
                        Templist.Add(item);
                }
            }

            FundFlowService fundflowService = new FundFlowService();
            List<FundFlow> fundFlowList = new List<FundFlow>();
            fundFlowList = fundflowService.GetListByParameter(innerCustomerId, bPId, null, endDate, userId);

            if (fundFlowList.Count > 0)
            {
                foreach (FundFlow f in fundFlowList)
                {
                    var item = new ARAPClass
                    {
                        InnerCustomerName = f.InternalCustomer.ShortName,
                        BusinessPartnerName = f.BusinessPartner.ShortName
                    };
                    item.Title = item.InnerCustomerName + item.BusinessPartnerName;
                    item.QuotaNo = f.FinancialAccount.Name;
                    if (f.RorP == (int)FundFlowType.Receive)
                    {
                        item.SReceived = f.Amount;
                        item.AmountRemain = -f.Amount;
                        item.VatInvoiceAmountRemain = -f.Amount;
                    }
                    else
                    {
                        item.SPaid = f.Amount;
                        item.AmountRemain = f.Amount;
                        item.VatInvoiceAmountRemain = f.Amount;
                    }
                    item.AmountRemainCNY = item.AmountRemain * f.Rate;
                    item.Date = f.TradeDate;
                    item.SettleCurrency = f.Currency.Name;
                    Templist.Add(item);
                }
            }

            if (Templist.Count > 0)
            {
                var groups = Templist.GroupBy(o => o.Title);
                foreach (var group in groups)
                {
                    decimal beforeAmount = 0M;
                    bool hasRow = false;
                    List<ARAPClass> list = group.ToList();
                    decimal amountRemain = 0;
                    decimal? totalVatInvoiceQty = 0;
                    decimal? totalVatInvoiceAmount = 0;
                    decimal? totalVatInvoiceAmountRemain = 0;
                    decimal? totalBReceived = 0;
                    decimal? totalBPaid = 0;
                    decimal? totalSReceived = 0;
                    decimal? totalSPaid = 0;
                    decimal? totalVerQty = 0;
                    if (list.Count > 0)
                    {
                        string innerCustomerName = list[0].InnerCustomerName;
                        string businessPartnerName = list[0].BusinessPartnerName;
                        int? internalCustomerId = list[0].InternalCustomerId;
                        int? customerId = list[0].CustomerId;
                        var titleItem = new ARAPClass
                        {
                            Title = "-1",
                            QuotaNo = "内部客户:" + innerCustomerName,
                            CommodityName = "客户名称:" + businessPartnerName,
                            CustomerId = customerId,
                            InternalCustomerId = internalCustomerId
                        };
                        ListAraps.Add(titleItem);
                        if (startDate != null)
                            hasRow = list.Where(o => o.Date.Value >= startDate.Value).Count() > 0;
                        else
                            hasRow = true;
                        foreach (var item in list)
                        {
                            if (startDate != null)
                            {
                                if (item.Date.Value < startDate.Value)
                                {
                                    beforeAmount += (item.AmountRemainCNY ?? 0);
                                    amountRemain += item.AmountRemainCNY ?? 0;
                                }
                                else
                                {
                                    item.Title = "0";
                                    amountRemain += item.AmountRemainCNY ?? 0;
                                    totalVatInvoiceQty += item.VatInvoiceQty ?? 0;
                                    totalVatInvoiceAmount += item.VatInvoiceAmount ?? 0;
                                    totalVatInvoiceAmountRemain += item.VatInvoiceAmountRemain ?? 0;
                                    totalBReceived += item.BReceived ?? 0;
                                    totalBPaid += item.BPaid ?? 0;
                                    totalSReceived += item.SReceived ?? 0;
                                    totalSPaid += item.SPaid ?? 0;
                                    totalVerQty += item.VerQty ?? 0;
                                    ListAraps.Add(item);
                                }
                            }
                            else
                            {
                                item.Title = "0";
                                beforeAmount += (item.AmountRemainCNY ?? 0);
                                amountRemain += item.AmountRemainCNY ?? 0;
                                totalVatInvoiceQty += item.VatInvoiceQty ?? 0;
                                totalVatInvoiceAmount += item.VatInvoiceAmount ?? 0;
                                totalVatInvoiceAmountRemain += item.VatInvoiceAmountRemain ?? 0;
                                totalBReceived += item.BReceived ?? 0;
                                totalBPaid += item.BPaid ?? 0;
                                totalSReceived += item.SReceived ?? 0;
                                totalSPaid += item.SPaid ?? 0;
                                totalVerQty += item.VerQty ?? 0;
                                ListAraps.Add(item);
                            }
                        }
                        if (hasRow)
                        {
                            titleItem.AmountRemain = amountRemain;
                            titleItem.VatInvoiceAmount = totalVatInvoiceAmount;
                            titleItem.VatInvoiceQty = totalVatInvoiceQty;
                            titleItem.BrandName = "增票余额：" + (totalVatInvoiceAmountRemain ?? 0).ToString("N2");
                            titleItem.BReceived = totalBReceived;
                            titleItem.BPaid = totalBPaid;
                            titleItem.SReceived = totalSReceived;
                            titleItem.SPaid = totalSPaid;
                            titleItem.VerQty = totalVerQty;
                            titleItem.SettleCurrency = "期初余额：" + beforeAmount.ToString("N2");
                        }
                        else
                        {
                            titleItem.AmountRemain = beforeAmount;
                            decimal bAmount = decimal.Parse(beforeAmount.ToString("N2"));
                            if (bAmount == 0)
                            {
                                ListAraps.Remove(titleItem);
                            }
                            else
                            {
                                titleItem.SettleCurrency = "期初余额：" + beforeAmount.ToString("N2");
                            }
                        }
                    }
                }
            }

            return ListAraps;
        }

        private Currency GetCurrencyByCode(int userId, string code)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Currency cny = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == code);
                return cny;
            }
        }

        private ARAPClass GetARAPClassByQuota(Quota quota, int userId)
        {
            //if ((quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
            //     quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade) &&
            //    quota.PricingStatus != (int)PricingStatus.Complete)
            //{
            //    //内贸点价未完成的不显示在应收应付报表里
            //    return null;
            //}

            decimal? price;
            decimal? yingf;
            decimal? yings;
            decimal? yif;
            decimal? yis;
            decimal? ye;
            string pricingCurrencyName;
            string currencyName;
            int currencyId;
            decimal yik;

            var item = new ARAPClass
                           {
                               InnerCustomerName = quota.Contract.InternalCustomer.ShortName,
                               BusinessPartnerName = quota.Contract.BusinessPartner.ShortName
                           };
            item.Title = item.InnerCustomerName + item.BusinessPartnerName;
            item.QuotaNo = quota.QuotaNo;
            item.CommodityName = quota.Commodity.Name;
            item.BrandName = quota.TotalBrands;
            item.InternalCustomerId = quota.Contract.InternalCustomerId;
            item.CustomerId = quota.Contract.BusinessPartner.Id;
            item.Date = quota.ImplementedDate;
            item.VatInvoiceQty = quota.VATInvoicedQuantity;
            item.VatInvoiceAmount = quota.VatInvoicedAmount;

            decimal verQty = GetAparReportDataByQuota(quota, userId, out price, out yingf, out yings, out yif,
                                                      out yis, out ye, out pricingCurrencyName, out currencyName, out currencyId,
                                                      out yik); //实际数量

            item.VerQty = verQty;
            item.Price = price;
            item.PricingCurrency = pricingCurrencyName;
            item.BReceived = yings;
            item.BPaid = yingf;
            item.SReceived = yis;
            item.SPaid = yif;
            item.AmountRemain = ye;
            item.SettleCurrency = currencyName;

            if (_cnyCurrency == null)
            {
                Currency cny = GetCurrencyByCode(userId, "CNY");
                _cnyCurrency = cny;
            }
            decimal rate = 1M;
            if (_cnyCurrency.Id != currencyId)
            {
                //结算币种不是人民币,需要转成人民币
                if (_cnyRate.ContainsKey(currencyId))
                {
                    //allProfit += (ledgerClass.Profit ?? 0) * _cnyRate[sCurrency.Id];
                    rate = _cnyRate[currencyId];
                }
                else
                {
                    RateService rateService = new RateService();
                    decimal? rateCNY = rateService.GetExchangeRate(_cnyCurrency.Id, currencyId, userId);
                    if (rateCNY.HasValue)
                    {
                        _cnyRate.Add(currencyId, rateCNY.Value);
                        rate = rateCNY.Value;
                    }
                }
            }
            item.AmountRemainCNY = ye * rate;
            return item;
        }

        #endregion

        #region Ledger

        private Currency _cnyCurrency;
        private Currency _usdCurrency;

        public List<LedgerClass> GetLedgerData(DateTime startTime, DateTime endTime, int commodityId,
                                               int internalCustomersId, int bpId, int purchaseCustomerId, int userId)
        {
            decimal allProfit = 0;
            var ledgerClasses = new List<LedgerClass>();

            var ctx = new SenLan2Entities();
            if (_cnyCurrency == null)
            {
                Currency cny = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == "CNY");
                _cnyCurrency = cny;
            }

            var rateService = new RateService();

            IEnumerable<Quota> quotas = GetSalesQuotas(startTime, endTime, commodityId, internalCustomersId, bpId);

            bool emptyFlag = false;
            foreach (Quota sQuota in quotas)
            {
                //采购销售完全点价才计算毛利
                bool isAllPurchasePriced = true;
                bool isAllSalesPriced = true;
                decimal saleQty = 0M;
                //Get the Settle Currency
                Currency sCurrency = GetSettlementCurrencyByQuota(sQuota);

                decimal sPrice = 0;
                //if (sQuota.PricingStatus == (int)PricingStatus.Complete)
                //{
                    sPrice = sQuota.FinalPrice ?? 0;
                //}

                decimal pSumAmount = 0; //采购应付金额汇总（采购价格 × 对应的销售数量），用于计算利润
                List<PSQuotaRel> rels;
                if (purchaseCustomerId != 0)
                {
                    rels =
                        sQuota.PSQuotaRels1.Where(
                            o => o.IsDeleted == false && o.Quota.Contract.BPId == purchaseCustomerId).ToList();
                }
                else
                {
                    rels = sQuota.PSQuotaRels1.Where(o => o.IsDeleted == false).ToList();
                }

                if (rels != null && rels.Count > 0)
                {

                    bool currencyFlag = true; //标志所有采购批次的结算币种是否全部都有值，如果有结算币种没有值，那么就不计算利润
                    for (int i = 0; i < rels.Count; i++)
                    {
                        #region 采购部分

                        Quota q = rels[i].Quota;
                        Currency pCurrency = GetSettlementCurrencyByQuota(q); //采购批次的结算币种
                        if (pCurrency == null)
                            currencyFlag = false;
                        var ledgerClass = new LedgerClass
                                              {
                                                  PQuotaNo = q.QuotaNo,
                                                  PQuotaDate = q.ImplementedDate,
                                                  PQuotaSupplier = q.Contract.BusinessPartner.ShortName,
                                                  MetalName = q.Commodity.Name
                                              };
                        if (q.TotalBrands != null)
                            ledgerClass.PBrandName = q.TotalBrands;
                        ledgerClass.PQty = q.Quantity;

                        ledgerClass.PVerifiedQty = q.VerifiedQuantity;
                        ledgerClass.PSalesQty = rels[i].P2SVerQuantity;
                        ledgerClass.PPaid = q.PaidAmount ?? 0; //已付
                        ledgerClass.PReceived = q.ReceivedAmount ?? 0; //已收

                        decimal qty = 0M;
                        if (q.DeliveryStatus)
                        {
                            //货运状态完成
                            qty = rels[i].P2SVerQuantity;
                            saleQty += rels[i].P2SVerQuantity;
                        }
                        else
                        {
                            //货运状态未完成
                            qty = rels[i].P2SQuantity;
                            saleQty += rels[i].P2SQuantity;
                        }

                        //if (q.PricingStatus == (int)PricingStatus.Complete)
                        //{
                            decimal pPrice = q.FinalPrice ?? 0;
                            ledgerClass.PPrice = pPrice.ToString(RoundRules.STR_PRICE);

                            decimal pPay = q.Equality ?? 0;
                            ledgerClass.PPay = pPay;
                            ledgerClass.PSettle = pPay - ledgerClass.PPaid + ledgerClass.PReceived;
                            if (currencyFlag && sCurrency != null &&
                                pCurrency.Id == sCurrency.Id)
                                pSumAmount += ledgerClass.PVerifiedQty == 0
                                                  ? 0
                                                  : (pPay * qty / (decimal)ledgerClass.PVerifiedQty);
                            //采购金额汇总，用于计算利润
                            else if (currencyFlag && sCurrency != null &&
                                     pCurrency.Id != sCurrency.Id)
                            {
                                decimal rate = rateService.GetExchangeRate(sCurrency.Id, pCurrency.Id, userId) ?? 1;
                                pSumAmount += ledgerClass.PVerifiedQty == 0
                                                  ? 0
                                                  : (pPay * qty / (decimal)ledgerClass.PVerifiedQty * rate);
                            }
                        //}
                        //else if (q.PricingStatus == (int)PricingStatus.Partial)
                        //{
                        //    ledgerClass.PPrice = "部分点价";
                        //    isAllPurchasePriced = false;
                        //}
                        //else
                        //{
                        //    ledgerClass.PPrice = "未点价";
                        //    isAllPurchasePriced = false;
                        //}

                        ledgerClass.PCurrency = q.Currency.Name;

                        ledgerClass.PSettleCurrency = pCurrency != null ? pCurrency.Name : "";

                        #endregion

                        #region 销售部分

                        if (i == rels.Count - 1)
                        {
                            ledgerClass.SQuotaNo = sQuota.QuotaNo;
                            ledgerClass.SQuotaDate = sQuota.ImplementedDate;
                            ledgerClass.SQuotaBuyer = sQuota.Contract.BusinessPartner.ShortName;
                            if (sQuota.TotalBrands != null)
                                ledgerClass.SBrandName = sQuota.TotalBrands;
                            ledgerClass.SQty = sQuota.Quantity;
                            ledgerClass.SVerifiedQty = sQuota.VerifiedQuantity;
                            ledgerClass.SReceived = sQuota.ReceivedAmount ?? 0; //已收
                            ledgerClass.SPaid = sQuota.PaidAmount ?? 0; //已付

                            decimal sReceive = 0;
                            //if (sQuota.PricingStatus == (int)PricingStatus.Complete)
                            //{
                                ledgerClass.SPrice = sPrice.ToString(RoundRules.STR_PRICE);
                                //List<PSQuotaRel> sQuotaRels = QueryForObjs(GetObjSet<PSQuotaRel>(ctx), o => o.SQuotaId == sQuota.Id).ToList();
                                //decimal verQty = sQuotaRels.Sum(o => o.P2SVerQuantity);
                                //decimal qty = sQuotaRels.Sum(o => o.P2SVerQuantity);
                                sReceive = sQuota.VerifiedQuantity == 0 ? 0 : (sQuota.Equality ?? 0) * saleQty / sQuota.VerifiedQuantity;
                                //sReceive = sQuota.Equality ?? 0;
                                ledgerClass.SReceive = sReceive;
                                ledgerClass.SSettle = sReceive - ledgerClass.SReceived + ledgerClass.SPaid;
                            //}
                            //else if (sQuota.PricingStatus == (int)PricingStatus.Partial)
                            //{
                            //    ledgerClass.SPrice = "部分点价";
                            //    isAllSalesPriced = false;
                            //}
                            //else
                            //{
                            //    ledgerClass.SPrice = "未点价";
                            //    isAllSalesPriced = false;
                            //}

                            ledgerClass.SCurrency = sQuota.Currency.Name;
                            ledgerClass.SSettleCurrency = sCurrency != null ? sCurrency.Name : "";
                            if (currencyFlag && isAllSalesPriced == true && isAllPurchasePriced == true)
                                ledgerClass.Profit = sReceive - pSumAmount; //现货利润 = 应收 - 应付

                            if (sCurrency.Id != _cnyCurrency.Id)
                            {
                                //结算币种不是人民币,需要转成人民币
                                if (_cnyRate.ContainsKey(sCurrency.Id))
                                {
                                    allProfit += (ledgerClass.Profit ?? 0) * _cnyRate[sCurrency.Id];
                                }
                                else
                                {

                                    decimal? rate = rateService.GetExchangeRate(_cnyCurrency.Id, sCurrency.Id, userId);
                                    if (rate.HasValue)
                                    {
                                        _cnyRate.Add(sCurrency.Id, rate.Value);
                                        allProfit += (ledgerClass.Profit ?? 0) * rate.Value;
                                    }
                                }
                            }
                            else
                            {
                                allProfit += (ledgerClass.Profit ?? 0);
                            }
                        }

                        #endregion
                        ledgerClasses.Add(ledgerClass);

                        emptyFlag = true;
                    }
                }
                if (emptyFlag)
                {
                    ledgerClasses.Add(new LedgerClass());
                    emptyFlag = false;
                }
            }
            if (allProfit != 0)
            {
                LedgerClass sumClass = new LedgerClass() { SSettleCurrency = "毛利合计：", Profit = allProfit };
                ledgerClasses.Add(sumClass);
            }
            return ledgerClasses;
        }

        private IEnumerable<Quota> GetSalesQuotas(DateTime startTime, DateTime endTime, int commodityId,
                                                  int internalCustomerId, int bpId)
        {
            string condition =
                "it.Contract.ContractType = @p1 and (it.ApproveStatus = @p2 or it.ApproveStatus = @p3) " +
                "and it.IsDraft = @p4 and it.CommodityId = @p5 and it.Contract.InternalCustomerId = @p6 " +
                "and it.ImplementedDate >= @p7 and it.ImplementedDate <= @p8";
            var parameters = new List<object>
                                 {
                                     (int) ContractType.Sales,
                                     (int) ApproveStatus.NoApproveNeeded,
                                     (int) ApproveStatus.Approved,
                                     false,
                                     commodityId,
                                     internalCustomerId,
                                     startTime,
                                     endTime
                                 };
            if (bpId > 0)
            {
                condition += " and it.Contract.BPId = @p9";
                parameters.Add(bpId);
            }
            return SelectWithMultiOrderLazyLoad(condition, parameters,
                                                new List<SortCol>
                                                {
                                                    new SortCol { ColName = "ImplementedDate", ByDescending = true }
                                                },
                                                new List<string>
                                                {
                                                    "Contract",
                                                    "Contract.BusinessPartner",
                                                    "Currency",
                                                    "Brand",
                                                    "QuotaBrandRels",
                                                    "QuotaBrandRels.Brand",
                                                    "CommercialInvoices",
                                                    "CommercialInvoices.Currency",
                                                    "PSQuotaRels1",
                                                    "PSQuotaRels1.Quota",
                                                    "PSQuotaRels1.Quota.Commodity",
                                                    "PSQuotaRels1.Quota.Contract",
                                                    "PSQuotaRels1.Quota.Contract.BusinessPartner",
                                                    "PSQuotaRels1.Quota.Currency",
                                                    "PSQuotaRels1.Quota.CommercialInvoices",
                                                    "PSQuotaRels1.Quota.CommercialInvoices.Currency"
                                                }, null);
        }

        #endregion

        #region 期现货盈亏

        private Dictionary<string, decimal> _comList = new Dictionary<string, decimal>();

        public void GetPhysicalPNLData(DateTime? startTime, DateTime endTime, int commodityId,
                                       int internalCustomersId,
                                       List<Commodity> selectedCommodityList, int userid,
                                       ref List<PhysicalPNLClass> innerList, ref List<PhysicalPNLClass> outList)
        {
            innerList = GetInnerPhysicalPNLData(startTime, endTime, commodityId, internalCustomersId,
                                                selectedCommodityList, userid);
            outList = GetAboardPhysicalPNLData(startTime, endTime, commodityId, internalCustomersId,
                                               selectedCommodityList, userid);
        }

        private List<PhysicalPNLClass> GetInnerPhysicalPNLData(DateTime? startTime, DateTime endTime, int commodityId,
                                                               int internalCustomersId,
                                                               IEnumerable<Commodity> selectedCommodityList, int userid)
        {
            //内贸
            List<Quota> listQuota = GetAllQuotaListByDateAndCommodity(startTime, endTime, commodityId,
                                                                      internalCustomersId, true);
            var physicalPnlClasses = new List<PhysicalPNLClass>();

            decimal sumSellPNL = 0;
            decimal sumFloatPNL = 0;
            decimal sumTotalPNL = 0;

            foreach (Commodity c in selectedCommodityList)
            {
                if (c.Id == 0)
                    continue;

                decimal buyVerQty = 0;
                decimal buySumAvgPrice = 0;

                decimal sellVerQty = 0;
                decimal sellSumAvgPrice = 0;

                bool flag = false;
                List<Quota> cList = listQuota.Where(h => h.CommodityId == c.Id).ToList();
                if (cList.Count == 0)
                    continue;
                foreach (Quota q in cList)
                {
                    decimal verQty = q.VerifiedQuantity; //批次实际数量
                    decimal qty = 0; //批次数量
                    decimal avgPrice = 0;
                    flag = true;
                    if (q.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        #region 采购

                        buyVerQty += verQty;
                        GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userid, true, true, false);
                        buySumAvgPrice += avgPrice * q.VerifiedQuantity;

                        #endregion
                    }
                    else
                    {
                        #region 销售

                        sellVerQty += verQty;
                        GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userid, true, true, false);
                        sellSumAvgPrice += avgPrice * q.VerifiedQuantity;

                        #endregion
                    }
                }

                if (flag)
                {
                    decimal buyAvgPrice = buyVerQty == 0 ? 0 : buySumAvgPrice / buyVerQty;
                    decimal sellAvgPrice = sellVerQty == 0 ? 0 : sellSumAvgPrice / sellVerQty;
                    //销售盈亏=（销售均价-采购均价）*min(销售数量，采购数量)
                    decimal sellPNL;
                    decimal floatPNL;
                    decimal inventorySumQty = buyVerQty - sellVerQty;
                    decimal latestPrice = GetDomesticPhysicalPrice(c, userid);
                    if (sellVerQty < buyVerQty)
                    {
                        //(销售数量 < 采购数量),库存为正
                        sellPNL = (sellAvgPrice - buyAvgPrice) * sellVerQty;
                        //浮动盈亏=(最新价 – 采购均价)* 库存
                        floatPNL = inventorySumQty * (latestPrice - buyAvgPrice);
                    }
                    else
                    {
                        //库存为负
                        sellPNL = (sellAvgPrice - buyAvgPrice) * buyVerQty;
                        //浮动盈亏=(销售均价 – 最新价)* 库存
                        floatPNL = Math.Abs(inventorySumQty) * (sellAvgPrice - latestPrice);
                    }
                    decimal totalPNL = sellPNL + floatPNL;

                    var item = new PhysicalPNLClass
                                   {
                                       CommodityName = c.Name,
                                       BuySumQty = buyVerQty,
                                       BuyAvgPrice = buyAvgPrice,
                                       SellSumQty = sellVerQty,
                                       SellAvgPrice = sellAvgPrice,
                                       SellPNL = sellPNL,
                                       InventorySumQty = inventorySumQty,
                                       LatestPrice = latestPrice,
                                       FloatPNL = floatPNL,
                                       TotalPNL = totalPNL
                                   };
                    physicalPnlClasses.Add(item);

                    sumSellPNL += sellPNL;
                    sumFloatPNL += floatPNL;
                    sumTotalPNL += totalPNL;
                }
            }

            #region 小计

            var sumItem = new PhysicalPNLClass
                              {
                                  CommodityName = "合计",
                                  SellPNL = sumSellPNL,
                                  FloatPNL = sumFloatPNL,
                                  TotalPNL = sumTotalPNL
                              };
            physicalPnlClasses.Add(sumItem);

            #endregion

            return physicalPnlClasses;
        }

        private List<PhysicalPNLClass> GetAboardPhysicalPNLData(DateTime? startTime, DateTime endTime, int commodityId,
                                                                int internalCustomersId,
                                                                IEnumerable<Commodity> selectedCommodityList, int userid)
        {
            //外贸
            var physicalPnlClasses = new List<PhysicalPNLClass>();
            List<Quota> listQuota = GetAllQuotaListByDateAndCommodity(startTime, endTime, commodityId,
                                                                      internalCustomersId, false);

            decimal sumSellPNLExternal = 0;
            decimal sumFloatPNLExternal = 0;
            decimal sumTotalPNLExternal = 0;

            foreach (Commodity c in selectedCommodityList)
            {
                if (c.Id == 0)
                    continue;

                decimal buyVerQtyExternal = 0;
                decimal buySumAvgPriceExternal = 0;

                decimal sellVerQtyExternal = 0;
                decimal sellSumAvgPriceExternal = 0;

                bool flag = false;
                List<Quota> cList = listQuota.Where(h => h.CommodityId == c.Id).ToList();
                if (cList.Count == 0)
                    continue;
                foreach (Quota q in cList)
                {
                    decimal verQty = q.VerifiedQuantity; //批次实际数量
                    decimal qty = 0; //批次数量
                    decimal avgPrice = 0;
                    flag = true;
                    if (q.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        #region 采购

                        buyVerQtyExternal += verQty;
                        GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userid, true, true);
                        buySumAvgPriceExternal += avgPrice * q.VerifiedQuantity;

                        #endregion
                    }
                    else
                    {
                        #region 销售

                        sellVerQtyExternal += verQty;
                        GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userid, true,
                                       true);
                        sellSumAvgPriceExternal += avgPrice * q.VerifiedQuantity;

                        #endregion
                    }
                }
                if (flag)
                {
                    decimal buyAvgPriceExternal = buyVerQtyExternal == 0 ? 0 : buySumAvgPriceExternal / buyVerQtyExternal;
                    decimal sellAvgPriceExternal = sellVerQtyExternal == 0
                                                       ? 0
                                                       : sellSumAvgPriceExternal / sellVerQtyExternal;
                    //销售盈亏=（销售均价-采购均价）*min(销售数量，采购数量)
                    decimal sellPNLExternal;
                    decimal floatPNLExternal;
                    //库存=采购数量-销售数量
                    decimal inventorySumQtyExternal = buyVerQtyExternal - sellVerQtyExternal;
                    decimal latestPriceExternal = GetLMEPhysicalPrice(c, userid);

                    if (sellVerQtyExternal < buyVerQtyExternal)
                    {
                        //(销售数量 < 采购数量),库存为正
                        sellPNLExternal = (sellAvgPriceExternal - buyAvgPriceExternal) * sellVerQtyExternal;
                        //浮动盈亏=(最新价 – 采购均价)* 库存
                        floatPNLExternal = inventorySumQtyExternal * (latestPriceExternal - buyAvgPriceExternal);
                    }
                    else
                    {
                        //库存为负
                        sellPNLExternal = (sellAvgPriceExternal - buyAvgPriceExternal) * buyVerQtyExternal;
                        //浮动盈亏=(销售均价 – 最新价)* 库存
                        floatPNLExternal = Math.Abs(inventorySumQtyExternal) *
                                           (sellAvgPriceExternal - latestPriceExternal);
                    }

                    decimal totalPNLExternal = sellPNLExternal + floatPNLExternal;

                    var itemExternal = new PhysicalPNLClass
                                           {
                                               CommodityName = c.Name,
                                               BuySumQty = buyVerQtyExternal,
                                               BuyAvgPrice = buyAvgPriceExternal,
                                               SellSumQty = sellVerQtyExternal,
                                               SellAvgPrice = sellAvgPriceExternal,
                                               SellPNL = sellPNLExternal,
                                               InventorySumQty = inventorySumQtyExternal,
                                               LatestPrice = latestPriceExternal,
                                               FloatPNL = floatPNLExternal,
                                               TotalPNL = totalPNLExternal
                                           };
                    physicalPnlClasses.Add(itemExternal);

                    sumSellPNLExternal += sellPNLExternal;
                    sumFloatPNLExternal += floatPNLExternal;
                    sumTotalPNLExternal += totalPNLExternal;
                }
            }

            #region 小计

            var sumItemExternal = new PhysicalPNLClass
                                      {
                                          CommodityName = "合计",
                                          SellPNL = sumSellPNLExternal,
                                          FloatPNL = sumFloatPNLExternal,
                                          TotalPNL = sumTotalPNLExternal
                                      };
            physicalPnlClasses.Add(sumItemExternal);

            #endregion

            return physicalPnlClasses;
        }

        /// <summary>
        ///     根据金属查询上海金属网最新现货价(不含升贴水)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetDomesticPhysicalPrice(Commodity c, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int id = c.Id;
                const int shx = (int)PricingBasis.SHX; //上海金属网
                var quota = new Quota { CommodityId = id, PricingBasis = shx };
                string key = quota.CommodityId + " " + quota.PricingBasis;
                decimal price = _comList.ContainsKey(key)
                                    ? _comList[key]
                                    : GetQuotaCurrentPrice(quota, ctx,
                                                           ref _comList);
                return price;
            }
        }

        /// <summary>
        ///     根据金属查询LME最新现货价(不含升贴水)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetLMEPhysicalPrice(Commodity c, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int id = c.Id;
                const int lmeCash = (int)PricingBasis.LMECash; //Lme现货价
                var quota = new Quota { CommodityId = id, PricingBasis = lmeCash };
                string key = quota.CommodityId + " " + quota.PricingBasis;
                decimal price = _comList.ContainsKey(key)
                                    ? _comList[key]
                                    : GetQuotaCurrentPrice(quota, ctx,
                                                           ref _comList);
                return price;
            }
        }

        #endregion

        #region 现货点价保证金

        private FinancialAccount _fa;

        public void GetPricingMarginReportData(int commodityId, int internalCustomerId, decimal rate,
                                               DateTime? startDate, DateTime? endDate,
                                               ref List<MarginLineClass> pOursList,
                                               ref List<MarginLineClass> sOursList,
                                               ref List<MarginLineClass> pTheirsList,
                                               ref List<MarginLineClass> sTheirsList)
        {
            List<Quota> quotas = GetPricingQuotas(commodityId, internalCustomerId, startDate, endDate);
            if (quotas.Count > 0)
            {
                foreach (Quota item in quotas)
                {
                    if (item.PricingSide == (int)PricingSide.OurSide)
                    {
                        //对方点价
                        if (item.Contract.ContractType == (int)ContractType.Purchase)
                        {
                            //采购
                            MarginLineClass pOur = CreateMarginLine(item, rate);
                            pOursList.Add(pOur);
                        }
                        else
                        {
                            //销售
                            MarginLineClass sOur = CreateMarginLine(item, rate);
                            sOursList.Add(sOur);
                        }
                    }
                    else if (item.PricingSide == (int)PricingSide.TheirSide)
                    {
                        //我方点价
                        if (item.Contract.ContractType == (int)ContractType.Purchase)
                        {
                            //采购
                            MarginLineClass pTheir = CreateMarginLine(item, rate);
                            pTheirsList.Add(pTheir);
                        }
                        else
                        {
                            //销售
                            MarginLineClass sTheir = CreateMarginLine(item, rate);
                            sTheirsList.Add(sTheir);
                        }
                    }
                }
            }
        }

        private MarginLineClass CreateMarginLine(Quota quota, decimal marginRatio)
        {
            FinancialAccount fa = GetFinancialAccountByPricingMargin();
            List<FundFlow> fundFlows =
                quota.FundFlows.Where(o => o.IsDeleted == false && o.FinancialAccountId == fa.Id).ToList();
            marginRatio = marginRatio * 0.01M;
            decimal? pricingQuantity = quota.Pricings.Where(o => o.IsDeleted == false).Sum(p => p.PricingQuantity);
            //已点数量
            var marginLine = new MarginLineClass
                                 {
                                     QuotaId = quota.Id,
                                     BPartnerId = quota.Contract.BusinessPartner.Id,
                                     BPName = quota.Contract.BusinessPartner.ShortName,
                                     QuotaNo = quota.QuotaNo, //批次号
                                     QuotaQuantity = quota.Quantity, //批次数量
                                     PricingQuantity = pricingQuantity //已点数量
                                 };

            decimal amount;
            decimal payment = 0;
            decimal deliveryAmount;
            decimal unpricingQuantity = GetUnPricingQuantity(quota); //未点数量
            decimal lastPrice = GetLastPriceByQuota(quota);
            decimal pricingAmount = GetPricingAmount(quota);
            marginLine.LastPrice = lastPrice;

            if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
            {
                //内贸
                foreach (Delivery delivery in quota.Deliveries)
                {
                    if (delivery.IsDeleted)
                        continue;
                    foreach (DeliveryLine line in delivery.DeliveryLines)
                    {
                        if (line.IsDeleted)
                            continue;
                        if (line.TempUnitPrice.HasValue)
                            payment += line.VerifiedWeight.Value * line.TempUnitPrice.Value;//提单行实际数量*暂定价
                        else
                            throw new FaultException(ErrCode.DeliveryLineNotHasTempUnitPrice.ToString());
                    }
                }
                if (payment > 0)
                {
                    marginLine.PaymentStr = string.Format("{0:N}", payment) +
                                            quota.Currency.Name;
                }
                deliveryAmount = payment;
                if (quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    //采购
                    if (quota.PricingSide == (int)PricingSide.OurSide)
                    {
                        //我方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 + marginRatio); //初始点价保证金
                        marginLine.OurAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已追加保证金
                        marginLine.TheirReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount + marginLine.OurAppendMargin -
                                                marginLine.TheirReturnMargin - pricingAmount) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 + marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.OurNeedToAppendMargin = amount; //我方需追加保证金
                        }
                        else
                        {
                            marginLine.TheirNeedToReturnMargin = Math.Abs(amount); //对方需退还保证金
                        }
                    }
                    else
                    {
                        //对方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 - marginRatio); //初始点价保证金
                        marginLine.TheirAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已追加保证金
                        marginLine.OurReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount - marginLine.TheirAppendMargin +
                                                marginLine.OurReturnMargin - pricingAmount) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 - marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.OurNeedToReturnMargin = amount; //我方需退还保证金
                        }
                        else
                        {
                            marginLine.TheirNeedToAppendMargin = Math.Abs(amount); //对方需追加保证金
                        }
                    }
                }
                else
                {
                    //销售
                    if (quota.PricingSide == (int)PricingSide.OurSide)
                    {
                        //我方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 - marginRatio); //初始点价保证金
                        marginLine.OurAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已追加保证金
                        marginLine.TheirReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount - pricingAmount - marginLine.OurAppendMargin +
                                                marginLine.TheirReturnMargin) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 - marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.TheirNeedToReturnMargin = amount; //对方需退还保证金
                        }
                        else
                        {
                            marginLine.OurNeedToAppendMargin = Math.Abs(amount); //我方需追加保证金
                        }
                    }
                    else
                    {
                        //对方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 + marginRatio); //初始点价保证金
                        marginLine.OurReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已退还保证金
                        marginLine.TheirAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已追加保证金
                        marginLine.ExitPrice = (deliveryAmount - pricingAmount + marginLine.TheirAppendMargin -
                                                marginLine.OurReturnMargin) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 + marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.TheirNeedToAppendMargin = amount; //对方需追加保证金
                        }
                        else
                        {
                            marginLine.OurNeedToReturnMargin = Math.Abs(amount); //我方需退还保证金
                        }
                    }
                }
            }
            else
            {
                //外贸
                //因为外贸计算初始点价保证金和止损价需要用临时商业发票金额/临时商业发票汇率，随意此处把汇率为0的商业发票过滤掉，以免报错。
                List<CommercialInvoice> commercialInvoices =
                    quota.CommercialInvoices.Where(
                        t =>
                        t.InvoiceType == (int)CommercialInvoiceType.Provisional && t.IsDeleted == false &&
                        t.ExchangeRate != 0).ToList();
                payment = commercialInvoices.Sum(p => p.Amount ?? 0);

                if (commercialInvoices.Count > 0)
                {
                    marginLine.PaymentStr = string.Format("{0:N}", payment) +
                                            quota.CommercialInvoices.FirstOrDefault().Currency.Name;
                }
                deliveryAmount = ProvisionalInvoiceTotal(commercialInvoices);

                if (quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    //采购
                    if (quota.PricingSide == (int)PricingSide.OurSide)
                    {
                        //我方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 + marginRatio); //初始点价保证金
                        marginLine.OurAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已追加保证金
                        marginLine.TheirReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount + marginLine.OurAppendMargin -
                                                marginLine.TheirReturnMargin - pricingAmount) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 + marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.OurNeedToAppendMargin = amount; //我方需追加保证金
                        }
                        else
                        {
                            marginLine.TheirNeedToReturnMargin = Math.Abs(amount); //对方需退还保证金
                        }
                    }
                    else
                    {
                        //对方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 - marginRatio); //初始点价保证金
                        marginLine.TheirAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已追加保证金
                        marginLine.OurReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount - marginLine.TheirAppendMargin +
                                                marginLine.OurReturnMargin - pricingAmount) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 - marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.OurNeedToReturnMargin = amount; //我方需退还保证金
                        }
                        else
                        {
                            marginLine.TheirNeedToAppendMargin = Math.Abs(amount); //对方需追加保证金
                        }
                    }
                }
                else
                {
                    //销售
                    if (quota.PricingSide == (int)PricingSide.OurSide)
                    {
                        //我方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 - marginRatio); //初始点价保证金
                        marginLine.OurAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已追加保证金
                        marginLine.TheirReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已退还保证金
                        marginLine.ExitPrice = (deliveryAmount - pricingAmount - marginLine.OurAppendMargin +
                                                marginLine.TheirReturnMargin) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 - marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.TheirNeedToReturnMargin = amount; //对方需退还保证金
                        }
                        else
                        {
                            marginLine.OurNeedToAppendMargin = Math.Abs(amount); //我方需追加保证金
                        }
                    }
                    else
                    {
                        //对方点价
                        marginLine.InitMargin = deliveryAmount * marginRatio / (1 + marginRatio); //初始点价保证金
                        marginLine.OurReturnMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Pay); //我方已退还保证金
                        marginLine.TheirAppendMargin = GetFundFlowAmount(fundFlows, (int)FundFlowType.Receive);
                        //对方已追加保证金
                        marginLine.ExitPrice = (deliveryAmount - pricingAmount - marginLine.OurReturnMargin +
                                                marginLine.TheirAppendMargin) / unpricingQuantity; //止损价
                        amount = lastPrice * unpricingQuantity * (1 + marginRatio) -
                                 ((marginLine.ExitPrice ?? 0) * unpricingQuantity); //金额
                        if (amount > 0)
                        {
                            marginLine.TheirNeedToAppendMargin = amount; //对方需追加保证金
                        }
                        else
                        {
                            marginLine.OurNeedToReturnMargin = Math.Abs(amount); //我方需退还保证金
                        }
                    }
                }
            }

            return marginLine;
        }

        private decimal GetLastPriceByQuota(Quota quota)
        {
            using (var ctx = new SenLan2Entities())
            {
                decimal lastPrice = 0M;

                if (quota.PricingBasis.Value == (int)PricingBasis.LME3M ||
                    quota.PricingBasis.Value == (int)PricingBasis.LMECash ||
                    (quota.PricingBasis.Value <= (int)PricingBasis.SHFE12 &&
                     quota.PricingBasis.Value >= (int)PricingBasis.SHFE01))
                {
                    string key = quota.CommodityId + " " + quota.PricingBasis;
                    lastPrice = _comList.ContainsKey(key)
                                    ? _comList[key]
                                    : GetQuotaCurrentPrice(quota, ctx,
                                                           ref _comList);
                    if (lastPrice != 0 && lastPrice != -1)
                    {
                        if (quota.Premium != null) lastPrice += quota.Premium.Value;
                    }
                }

                return lastPrice;
            }
        }

        private List<Quota> GetPricingQuotas(int commodityId, int internalCustomerId, DateTime? startDate,
                                             DateTime? endDate)
        {
            List<Quota> quotas;
            using (var ctx = new SenLan2Entities())
            {
                if (startDate.HasValue && endDate.HasValue)
                {
                    quotas =
                        QueryForObjs(
                            GetObjQuery<Quota>(ctx,
                                               new List<string>
                                                   {
                                                       "Contract",
                                                       "Contract.BusinessPartner",
                                                       "Commodity",
                                                       "Pricings",
                                                       "CommercialInvoices",
                                                       "CommercialInvoices.Currency",
                                                       "FundFlows",
                                                       "Unpricings",
                                                       "Deliveries",
                                                       "Deliveries.DeliveryLines",
                                                       "Currency"
                                                   }),
                            o =>
                            o.CommodityId == commodityId && o.Contract.InternalCustomerId == internalCustomerId &&
                            o.PricingStatus != (int)PricingStatus.Complete && o.PricingType == (int)PricingType.Manual &&
                            (o.ApproveStatus == (int)ApproveStatus.Approved ||
                             o.ApproveStatus == (int)ApproveStatus.NoApproveNeeded) &&
                            (o.PricingBasis == (int)PricingBasis.LME3M || o.PricingBasis == (int)PricingBasis.LMECash ||
                             (o.PricingBasis <= (int)PricingBasis.SHFE12 && o.PricingBasis >= (int)PricingBasis.SHFE01)) &&
                            o.ImplementedDate >= startDate && o.ImplementedDate <= endDate).ToList();
                }
                else if (startDate.HasValue)
                {
                    quotas =
                        QueryForObjs(
                            GetObjQuery<Quota>(ctx,
                                               new List<string>
                                                   {
                                                       "Contract",
                                                       "Contract.BusinessPartner",
                                                       "Commodity",
                                                       "Pricings",
                                                       "CommercialInvoices",
                                                       "CommercialInvoices.Currency",
                                                       "FundFlows",
                                                       "Unpricings",
                                                       "Deliveries",
                                                       "Deliveries.DeliveryLines",
                                                       "Currency"
                                                   }),
                            o =>
                            o.CommodityId == commodityId && o.Contract.InternalCustomerId == internalCustomerId &&
                            o.PricingStatus != (int)PricingStatus.Complete && o.PricingType == (int)PricingType.Manual &&
                            (o.ApproveStatus == (int)ApproveStatus.Approved ||
                             o.ApproveStatus == (int)ApproveStatus.NoApproveNeeded) &&
                            (o.PricingBasis == (int)PricingBasis.LME3M || o.PricingBasis == (int)PricingBasis.LMECash ||
                             (o.PricingBasis <= (int)PricingBasis.SHFE12 && o.PricingBasis >= (int)PricingBasis.SHFE01)) &&
                            o.ImplementedDate >= startDate).ToList();
                }
                else if (endDate.HasValue)
                {
                    quotas =
                        QueryForObjs(
                            GetObjQuery<Quota>(ctx,
                                               new List<string>
                                                   {
                                                       "Contract",
                                                       "Contract.BusinessPartner",
                                                       "Commodity",
                                                       "Pricings",
                                                       "CommercialInvoices",
                                                       "CommercialInvoices.Currency",
                                                       "FundFlows",
                                                       "Unpricings",
                                                       "Deliveries",
                                                       "Deliveries.DeliveryLines",
                                                       "Currency"
                                                   }),
                            o =>
                            o.CommodityId == commodityId && o.Contract.InternalCustomerId == internalCustomerId &&
                            o.PricingStatus != (int)PricingStatus.Complete && o.PricingType == (int)PricingType.Manual &&
                            (o.ApproveStatus == (int)ApproveStatus.Approved ||
                             o.ApproveStatus == (int)ApproveStatus.NoApproveNeeded) &&
                            (o.PricingBasis == (int)PricingBasis.LME3M || o.PricingBasis == (int)PricingBasis.LMECash ||
                             (o.PricingBasis <= (int)PricingBasis.SHFE12 && o.PricingBasis >= (int)PricingBasis.SHFE01)) &&
                            o.ImplementedDate <= endDate)
                            .ToList();
                }
                else
                {
                    quotas =
                        QueryForObjs(
                            GetObjQuery<Quota>(ctx,
                                               new List<string>
                                                   {
                                                       "Contract",
                                                       "Contract.BusinessPartner",
                                                       "Commodity",
                                                       "Pricings",
                                                       "CommercialInvoices",
                                                       "CommercialInvoices.Currency",
                                                       "FundFlows",
                                                       "Unpricings",
                                                       "Deliveries",
                                                       "Deliveries.DeliveryLines",
                                                       "Currency"
                                                   }),
                            o =>
                            o.CommodityId == commodityId && o.Contract.InternalCustomerId == internalCustomerId &&
                            o.PricingStatus != (int)PricingStatus.Complete && o.PricingType == (int)PricingType.Manual &&
                            (o.ApproveStatus == (int)ApproveStatus.Approved ||
                             o.ApproveStatus == (int)ApproveStatus.NoApproveNeeded) &&
                            (o.PricingBasis == (int)PricingBasis.LME3M || o.PricingBasis == (int)PricingBasis.LMECash ||
                             (o.PricingBasis <= (int)PricingBasis.SHFE12 && o.PricingBasis >= (int)PricingBasis.SHFE01)))
                            .ToList();
                }
            }

            return quotas;
        }

        // ∑（临时发票金额 / 临时发票比率）
        private decimal ProvisionalInvoiceTotal(IEnumerable<CommercialInvoice> invoices)
        {
            decimal amt = 0;

            if (invoices != null)
            {
                amt = invoices.Sum(o => ((o.Amount ?? 0) / o.ExchangeRate.Value));
            }
            return amt;
        }

        private FinancialAccount GetFinancialAccountByPricingMargin()
        {
            using (var ctx = new SenLan2Entities())
            {
                return _fa ?? (_fa = QueryForObj(GetObjQuery<FinancialAccount>(ctx), o => o.Name.Trim() == "现货点价保证金"));
            }
        }

        /// <summary>
        ///     获取已追加/退还保证金 由现金科目为“现货点价保证金”的现金收付款
        /// </summary>
        /// <param name="fundFlows"></param>
        /// <param name="rorP">R收款 P付款</param>
        /// <returns></returns>
        private decimal GetFundFlowAmount(IEnumerable<FundFlow> fundFlows, int rorP)
        {
            decimal amt = 0;
            if (fundFlows != null)
            {
                amt = fundFlows.Where(o => o.RorP == rorP).Sum(o => o.Amount ?? 0);
            }

            return amt;
        }

        //∑（已点数量 * 点价价格）
        private decimal GetPricingAmount(Quota quota)
        {
            decimal amt = 0;
            if (quota.Pricings != null)
            {
                amt =
                    quota.Pricings.Where(o => o.IsDeleted == false)
                         .Sum(o => (o.PricingQuantity ?? 0) * (o.FinalPrice ?? 0));
            }
            return amt;
        }

        //未点数量
        private decimal GetUnPricingQuantity(Quota quota)
        {
            decimal qty = 0;
            if (quota.Unpricings != null)
            {
                qty = quota.Unpricings.Where(o => o.IsDeleted == false).Sum(o => o.UnpricingQuantity ?? 0);
            }
            return qty;
        }

        #endregion

        #region 更改批次的已收已付字段

        /// <summary>
        ///     更改批次的已付已收金额字段
        /// </summary>
        /// <param name="quotaId">批次号</param>
        /// <param name="userId"></param>
        public void SetPaidAndReceivedAmount(int? quotaId, int userId)
        {
            if (!quotaId.HasValue || quotaId == 0)
                return;

            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                if (quota.QuotaGroupId.HasValue)
                {
                    List<Quota> quotaGroup = GetQuotaListByGroupId(quota.QuotaGroupId, ctx);
                    foreach (Quota q in quotaGroup)
                    {
                        decimal paidAmount = GetPayAmountByQuotaId(q.Id, userId);
                        decimal receivedAmount = GetReceivableAmountByQuotaId(q.Id, userId);
                        q.PaidAmount = paidAmount;
                        q.ReceivedAmount = receivedAmount;
                        Update(GetObjSet<Quota>(ctx), q);
                    }
                    ctx.SaveChanges();
                }
                else
                {
                    decimal paidAmount = GetPayAmountByQuotaId(quota.Id, userId);
                    decimal receivedAmount = GetReceivableAmountByQuotaId(quota.Id, userId);
                    quota.PaidAmount = paidAmount;
                    quota.ReceivedAmount = receivedAmount;
                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();
                }
            }
        }

        #endregion

        #region 更改批次的应收应付字段

        private decimal GetEqualityByQuotaId(Quota quota, int userId)
        {
            decimal equality;

            //采购
            if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
            {
                //内贸
                decimal price = GetPriceByQuotaPricingWithRate(quota.Id, userId);
                decimal? rate = 1;
                if (quota.PricingType != (int)PricingType.Fixed)
                {
                    if (_cnyCurrency == null)
                    {
                        using (var ctx = new SenLan2Entities(userId))
                        {
                            Currency cu = QueryForObj(GetObjQuery<Currency>(ctx), c => c.Code == "CNY");
                            _cnyCurrency = cu;
                        }
                    }
                    if (quota.PricingCurrencyId.Value != _cnyCurrency.Id)
                    {
                        RateService rateService = new RateService();
                        rate = rateService.GetExchangeRate(_cnyCurrency.Id, quota.PricingCurrencyId.Value, userId);
                    }
                }
                equality = price * quota.VerifiedQuantity * (rate ?? 1M);
            }
            else
            {
                //外贸
                equality = GetAmountByQuotaId(quota.Id, userId);
            }

            return equality;
        }

        /// <summary>
        ///     修改批次的应收应付字段
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        public void SetEqualityByQuotaId(int? quotaId, int userId)
        {
            if (!quotaId.HasValue || quotaId == 0)
                return;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Currency" }), o => o.Id == quotaId);
                decimal equality = GetEqualityByQuotaId(quota, userId);
                quota.Equality = equality;
                Update(GetObjSet<Quota>(ctx), quota);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        ///     修改批次的最终价格
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        public void UpdateQuotaFinalPriceByQuotaId(int quotaId, int userId)
        {
            decimal price = GetPriceByQuotaPricing(quotaId, userId);
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                quota.FinalPrice = price;
                Update(GetObjSet<Quota>(ctx), quota);
                ctx.SaveChanges();
            }
        }

        #endregion

        #region 平均点价

        /// <summary>
        ///     完成点价
        /// </summary>
        /// <param name="unpricingId"></param>
        /// <param name="pricing"></param>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        public void CompleteUnpricingtoPricing(int unpricingId, Pricing pricing, int quotaId, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateUnpricing(unpricingId, userId);
                    CreatePricing(pricing, userId);
                    UpdateQuota(quotaId, userId);

                    //修改批次的应收应付金额字段
                    SetEqualityByQuotaId(quotaId, userId);
                    UpdateQuotaFinalPriceByQuotaId(quotaId, userId);
                    var psQuotaRelService = new PSQuotaRelService();
                    psQuotaRelService.SetRelStrByQuotaId(userId, quotaId);
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

        public void UpdatePricing(Pricing pricing, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<Pricing> os = GetObjSet<Pricing>(ctx);
                        Pricing tmp = QueryForObj(GetObjQuery<Pricing>(ctx), o => o.Id == pricing.Id);
                        tmp.FinalPrice = pricing.FinalPrice;
                        tmp.ExchangeRate = pricing.ExchangeRate;
                        tmp.PricingDate = pricing.PricingDate;
                        Update(os, tmp);
                        ctx.SaveChanges();

                        //修改批次的应收应付金额字段
                        SetEqualityByQuotaId(pricing.QuotaId, userId);
                        UpdateQuotaFinalPriceByQuotaId(pricing.QuotaId, userId);
                        var psQuotaRelService = new PSQuotaRelService();
                        psQuotaRelService.SetRelStrByQuotaId(userId, pricing.QuotaId);
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
        ///     创建点价完成
        /// </summary>
        /// <param name="pricing"></param>
        /// <param name="userId"></param>
        private void CreatePricing(Pricing pricing, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<Pricing>(ctx), pricing);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        ///     修改Unpricing的未点价数量
        /// </summary>
        /// <param name="unpricingId"></param>
        /// <param name="userId"></param>
        private void UpdateUnpricing(int unpricingId, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    ObjectSet<Unpricing> os = GetObjSet<Unpricing>(ctx);
                    Unpricing tmp = QueryForObj(GetObjQuery<Unpricing>(ctx), o => o.Id == unpricingId);
                    tmp.UnpricingQuantity = 0;
                    Update(os, tmp);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        ///     更改批次点价完成状态完成
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        private void UpdateQuota(int quotaId, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    ObjectSet<Quota> os = GetObjSet<Quota>(ctx);
                    Quota tmp = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                    tmp.PricingStatus = (int)PricingStatus.Complete;
                    Update(os, tmp);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        #region 仪表盘

        public List<DashBoardClass> GetDashBoard(DateTime? startDate, DateTime? endDate, int internalCustomerID,
                                                 int userId,
                                                 ref List<Currency> currencyList, ref List<Commodity> commodityList,
                                                 ref List<DashBoardTotalClass> totals)
        {
            var list = new List<DashBoardClass>();

            List<Quota> quotaList = GetPurchaseAmount(startDate, endDate, internalCustomerID);

            currencyList = quotaList.Select(c => c.Currency).Distinct().ToList();

            commodityList = quotaList.Select(c => c.Commodity).Distinct().ToList();

            foreach (Currency currency in currencyList)
            {
                foreach (Commodity c in commodityList)
                {
                    if (quotaList.Count > 0)
                    {
                        List<Quota> listByCommodity =
                            quotaList.Where(o => o.CommodityId == c.Id && o.PricingCurrencyId == currency.Id).ToList();

                        List<Quota> listPID =
                            listByCommodity.Where(o => o.Contract.ContractType == (int)ContractType.Purchase)
                                           .Select(a => a)
                                           .ToList();
                        List<Quota> listSID =
                            listByCommodity.Where(o => o.Contract.ContractType == (int)ContractType.Sales)
                                           .Select(a => a)
                                           .ToList();

                        decimal amountPurchase = GetQuotaAmountsByQuota(listPID, userId);
                        decimal amountSale = GetQuotaAmountsByQuota(listSID, userId);

                        var data = new DashBoardClass
                                       {
                                           CurrencyName = currency.Name,
                                           CurrencyId = currency.Id,
                                           CommodityName = c.Name,
                                           CommodityId = c.Id,
                                           PurchaseAmount = amountPurchase,
                                           SaleAmount = amountSale
                                       };
                        list.Add(data);
                    }
                }
            }

            #region 计算采购销售数量

            foreach (Commodity c in commodityList)
            {
                var total = new DashBoardTotalClass();
                decimal quantityP = quotaList.Where(
                    o => o.Contract.ContractType == (int)ContractType.Purchase && o.CommodityId == c.Id).Sum(
                        o => o.VerifiedQuantity);

                decimal quantityS = quotaList.Where(
                    o => o.Contract.ContractType == (int)ContractType.Sales && o.CommodityId == c.Id).Sum(
                        o => o.VerifiedQuantity);
                total.CommodityId = c.Id;
                total.CommodityName = c.Name;
                total.PurchaseQty = quantityP;
                total.SaleQty = quantityS;
                totals.Add(total);
            }

            #endregion

            return list;
        }

        #endregion

        #region 客户购销排行表

        public List<BPartnerContractOrder> GetContractOrderList(string queryStr, List<object> parameters, int userId)
        {
            var contractOrderList = new List<BPartnerContractOrder>();

            if (queryStr != string.Empty)
            {
                List<Quota> quotaList = Select(queryStr, parameters, new List<string>
                                                                            {
                                                                                "Contract.BusinessPartner",
                                                                                "Currency",
                                                                                "Pricings",
                                                                                "Unpricings"
                                                                            }).ToList();
                List<BusinessPartner> bPartners =
                    quotaList.Select(c => c.Contract.BusinessPartner).Distinct().ToList();
                foreach (BusinessPartner bpartner in bPartners)
                {
                    var contractOrder = new BPartnerContractOrder();
                    List<Quota> quotas = quotaList.Where(c => c.Contract.BusinessPartner.Id == bpartner.Id).ToList();
                    decimal totalQty = 0;
                    decimal totalAmount = 0;
                    decimal avgPrice = 0;
                    var commodityDictionary = new Dictionary<string, decimal>();
                    foreach (Quota quota in quotas)
                    {
                        totalQty += quota.VerifiedQuantity;
                        decimal qty = 0;
                        decimal amount = GetQuotaAmount(quota, ref commodityDictionary, ref qty, ref avgPrice, userId, true,
                                                        true, false);
                        totalAmount += amount;
                    }
                    if (totalQty != 0)
                    {
                        avgPrice = totalAmount / totalQty;
                    }

                    contractOrder.BusinessParnterName = bpartner.ShortName;
                    contractOrder.Qty = totalQty;
                    contractOrder.Amount = totalAmount;
                    contractOrder.AvgPrice = avgPrice;
                    contractOrderList.Add(contractOrder);
                }
                contractOrderList = contractOrderList.OrderByDescending(c => c.Amount).ToList();
            }

            return contractOrderList;
        }

        #endregion

        /// <summary>
        /// 被拆分的批次会和原始批次在一个分组，传入分组号，返回该分组中的所有批次的实际数量和
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private decimal GetQuotaGroupQuantityByGroupId(int? groupId)
        {
            return GetSum<Quota>("it.QuotaGroupId ==" + groupId, null, q => q.VerifiedQuantity);
        }

        private List<Quota> GetQuotaListByGroupId(int? groupId, SenLan2Entities ctx)
        {
            return QueryForObjs(GetObjQuery<Quota>(ctx), q => q.QuotaGroupId == groupId).ToList();
        }
    }

    public class LedgerPQuotaItem
    {
        public Quota PQuota { get; set; }
        public decimal? Qty { get; set; }
    }
}