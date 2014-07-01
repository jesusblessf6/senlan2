using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Services.Base;
using Services.Helper.LogHelper;
using Services.Helper.MarketPrice;
using Services.Helper.Pricings;
using Utility.ErrorManagement;
using System.Transactions;
using Services.SystemSetting;
using Services.Physical.WarehouseOuts;
using Services.Helper.DocumentNoGenerator;

namespace Services.Physical.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContractService" in code, svc and config file together.
    public class ContractService : BaseService<Contract>, IContractService
    {
        /// <summary>
        /// 批次作废
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public void RemoveQuotaById(int id, int userId)
        {
            DeleteQuota(id, userId);
        }

        /// <summary>
        /// 设置在不需要审批的情况下的控件编辑属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContractEnableProperty SetElementsEnableProperty(int id)
        {
            var crp = new ContractEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //只要编辑，就不允许修改关联公司
                    //crp.IsRelTransactionDeleteBtnEnable = false;
                    //crp.IsRelTransactionEditBtnEnable = false;
                    //如果是短单，且是均价点价，点价完成，签署日期不可以修改
                    Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == id);
                    ICollection<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), q => q.ContractId == id);
                    if (contract != null && (contract.TradeType == (int)TradeType.ShortDomesticTrade || contract.TradeType == (int)TradeType.ShortForeignTrade))
                    {
                        Quota quota = quotas.FirstOrDefault();
                        if (quota != null && quota.PricingType == (int)PricingType.Average && quota.PricingStatus == (int)PricingStatus.Complete)
                        {
                            crp.IsSignDateEnable = false;
                        }
                    }

                    //通过判断关联合同是否有关联单据判断关联交易的控件是否可以编辑
                    if (contract != null && contract.TradeType == (int)TradeType.ShortDomesticTrade)
                    {
                        Quota quota = quotas.FirstOrDefault();
                        ICollection<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), q => q.RelQuotaId == quota.Id);
                        foreach (Quota q in relQuotas)
                        {
                            //关联合同关联了付款申请
                            Quota q1 = q;
                            if (QueryForObjs(GetObjQuery<PaymentRequest>(ctx), py => py.QuotaId == q1.Id).Count > 0)
                            {
                                //crp.IsRelTransactionDeleteBtnEnable = false;
                                //crp.IsRelTransactionEditBtnEnable = false;
                                //crp.IsRelTransactionNewBtnEnable = false;
                                crp.IsSignBPEnable = false;
                                break;
                            }
                            //关联合同关联了收付款
                            if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.QuotaId == q1.Id).Count > 0)
                            {
                                //crp.IsRelTransactionDeleteBtnEnable = false;
                                //crp.IsRelTransactionEditBtnEnable = false;
                                //crp.IsRelTransactionNewBtnEnable = false;
                                crp.IsSignBPEnable = false;
                                break;
                            }
                        }
                    }

                    //如果下辖批次有后续单据，则不可以编辑内部客户和业务伙伴
                    //合同的后续单据目前包括：delivery，warehousein/out，付款申请，增税开票申请，增税发票，LC，现金收付
                    //其他的后续单据不保存客户和内部客户的信息，应该可以变更
                    foreach (Quota quota in quotas)
                    {
                        //delivery
                        Quota q = quota;
                        q.StartTracking();
                        if (QueryForObjs(GetObjQuery<Delivery>(ctx), del => del.QuotaId == q.Id).Count > 0)
                        {
                            //crp.IsBPEnable = false;
                            //crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //warehouseout
                        if (QueryForObjs(GetObjQuery<WarehouseOut>(ctx), wo => wo.QuotaId == q.Id).Count > 0)
                        {
                            //crp.IsBPEnable = false;
                            //crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //付款申请
                        if (QueryForObjs(GetObjQuery<PaymentRequest>(ctx), py => py.QuotaId == q.Id).Count > 0)
                        {
                            //crp.IsBPEnable = false;
                            //crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //商业发票
                        if (QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), ci => ci.QuotaId == q.Id).Count > 0)
                        {
                            crp.IsBPEnable = false;
                            //crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //增税开票申请
                        if (QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx), vatRL => vatRL.QuotaId == q.Id).Count > 0)
                        {
                            crp.IsBPEnable = false;
                            crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //增税发票
                        if (QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), vatL => vatL.QuotaId == q.Id).Count > 0)
                        {
                            crp.IsBPEnable = false;
                            crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //现金收付
                        if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.QuotaId == q.Id).Count > 0)
                        {
                            //crp.IsBPEnable = false;
                            crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                        //LC
                        if (QueryForObjs(GetObjQuery<LetterOfCredit>(ctx), lc => lc.QuotaId == q.Id).Count > 0)
                        {
                            crp.IsBPEnable = false;
                            //crp.IsSignBPEnable = false;
                            //crp.IsRelTransactionDeleteBtnEnable = false;
                            //crp.IsRelTransactionEditBtnEnable = false;
                            //crp.IsRelTransactionNewBtnEnable = false;
                            return crp;
                        }
                    }
                    return crp;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        //关联交易的窗口的控件编辑属性
        public RelTransactionEnableProperty SetRelTransactionEnableProperty()
        {
            var rtep = new RelTransactionEnableProperty();
            try
            {
                rtep.IsDateEnable = true;
                rtep.IsPriceEnable = true;
                rtep.IsRelBPEnable = true;
                return rtep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #region 单据增删改

        private string GetheaderRelQuotaStr(int userId, Contract header)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                string relQuotaStr = string.Empty;
                BusinessPartner bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx), o => o.Id == header.BPId);
                BusinessPartner ic = QueryForObj(GetObjQuery<BusinessPartner>(ctx), o => o.Id == header.InternalCustomerId);
                if (header.ContractType == (int)ContractType.Purchase)
                {
                    relQuotaStr = bp.ShortName + "->" + ic.ShortName;
                }
                else
                {
                    relQuotaStr = ic.ShortName + "->" + bp.ShortName;
                }
                return relQuotaStr;
            }
        }

        private string GetBpName(int userId, Contract header)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                BusinessPartner bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx), o => o.Id == header.BPId);
                return bp.ShortName;
            }
        }

        private string GetInnerCustomerName(int userId, Contract header)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                BusinessPartner bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx), o => o.Id == header.InternalCustomerId);
                return bp.ShortName;
            }
        }

        int? QuotaGroupId;
        int _groupId;
        private void SetPaymentFinish(int userId, int quotaId, int groupId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == groupId);
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                quota.IsPaymentRequestFinished = oldQuota.IsPaymentRequestFinished;
                Update(GetObjSet<Quota>(ctx), quota);
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == quota.Id).ToList();
                foreach (var q in quotas)
                {
                    q.IsPaymentRequestFinished = oldQuota.IsPaymentRequestFinished;
                    Update(GetObjSet<Quota>(ctx), q);
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 新增合同
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedQuotas"></param>
        /// <param name="addedAttachments"></param>
        /// <param name="relQuotas"></param>
        public void CreateDocument(int userId, Contract header, List<Quota> addedQuotas,
                                   List<Attachment> addedAttachments, List<RelQuota> relQuotas, int? groupId)
        {
            QuotaGroupId = groupId;
            GetQuotaCurrentPrice(addedQuotas);
            string bpName = GetBpName(userId, header);
            string icName = GetInnerCustomerName(userId, header); 

            int maxStage = 0;
            List<Quota> oldRelQuotas = new List<Quota>();
            if (groupId.HasValue)
            {
                maxStage = GetMaxStageByQuotaId(userId, groupId.Value);
                oldRelQuotas = GetAllRelQuotas(userId, groupId.Value);
            }

            using (var ts = new TransactionScope())
            {
                try
                {
                    if (!header.IsDraft)
                    {
                        _commodityId = addedQuotas[0].CommodityId ?? 0;
                    }

                    AddContractAndQuota(userId, header, addedQuotas, addedAttachments);

                    //采购内贸短单，流转信息
                    if (header.ContractType == (int)ContractType.Purchase && header.TradeType == (int)TradeType.ShortDomesticTrade)
                    {
                        int quotaGroupId = addedQuotas[0].Id;
                        if (groupId.HasValue)
                        {
                            quotaGroupId = groupId.Value;
                        }

                        if (relQuotas != null && relQuotas.Count > 0)
                        {
                            //目前应该只有内贸短单才有，所以批次应该只有一个
                            relQuotas = relQuotas.OrderBy(o => o.QuotaStage).ToList();
                            int internalCustomerId = header.InternalCustomerId.Value;

                            foreach (var relQuota in relQuotas)
                            {
                                int stage = relQuota.QuotaStage;
                                Contract contractPurchase = CloneContract(header);
                                contractPurchase.BPId = internalCustomerId;
                                contractPurchase.ContractType = (int)ContractType.Purchase;
                                contractPurchase.InternalCustomerId = relQuota.BusinessParnterId;
                                contractPurchase.SignDate = relQuota.SignDate;
                                List<Quota> quotas = CloneQuotas(addedQuotas, addedQuotas[0].Id, relQuota, userId);
                                if (groupId.HasValue)
                                {
                                    //是拆分的
                                    Quota quota = oldRelQuotas.Where(o => o.RelQuotaStage == stage && o.Contract.ContractType == (int)ContractType.Purchase).FirstOrDefault();
                                    if (stage <= maxStage)
                                    {
                                        _groupId = quota.Id;
                                    }
                                    else
                                    {
                                        _groupId = 0;
                                    }
                                }
                                else
                                {
                                    //不是拆分的
                                    _groupId = 0;
                                }
                                AddContractAndQuota(userId, contractPurchase, quotas, null);


                                Contract contractSales = CloneContract(header);
                                contractSales.BPId = relQuota.BusinessParnterId;
                                contractSales.ContractType = (int)ContractType.Sales;
                                contractSales.InternalCustomerId = internalCustomerId;
                                contractSales.SignDate = relQuota.SignDate;
                                quotas = CloneQuotas(addedQuotas, addedQuotas[0].Id, relQuota, userId);
                                if (groupId.HasValue)
                                {
                                    //是拆分的
                                    Quota quota = oldRelQuotas.Where(o => o.RelQuotaStage == stage && o.Contract.ContractType == (int)ContractType.Sales).FirstOrDefault();
                                    if (stage <= maxStage)
                                    {
                                        _groupId = quota.Id;
                                    }
                                    else
                                    {
                                        _groupId = 0;
                                    }
                                }
                                else
                                {
                                    //不是拆分的
                                    _groupId = 0;
                                }
                                AddContractAndQuota(userId, contractSales, quotas, null);
                                //if (groupId.HasValue)
                                //{
                                //    //是拆分的
                                //    Quota quota = oldRelQuotas.Where(o => o.RelQuotaStage == stage && o.Contract.ContractType == (int)ContractType.Sales).FirstOrDefault();
                                //    if (stage <= maxStage)
                                //    {
                                //        SetQuotaGroupId(userId, quotas.FirstOrDefault().Id, quota.Id);
                                //    }
                                //    else
                                //    {
                                //        SetQuotaGroupId(userId, quotas.FirstOrDefault().Id, quotas.FirstOrDefault().Id);
                                //    }
                                //}
                                //else
                                //{
                                //    //不是拆分的
                                //    SetQuotaGroupId(userId, quotas.FirstOrDefault().Id, quotas.FirstOrDefault().Id);
                                //}
                                internalCustomerId = relQuota.BusinessParnterId;
                            }
                        }

                        SetPaymentFinish(userId, addedQuotas[0].Id, quotaGroupId);
                    }

                    //外贸 内部客户复制合同和批次
                    if (header.TradeType == (int)TradeType.ShortForeignTrade || header.TradeType == (int)TradeType.LongForeignTrade)
                    {
                        CopyContractAndQuota(userId, header, addedQuotas);
                    }

                    SetRelQuotaStr(userId, header.Id);
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

        private void SetQuotaGroupId(int userId, int quotaId, int quotaGroupId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                quota.QuotaGroupId = quotaGroupId;
                Update(GetObjSet<Quota>(ctx), quota);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 复制合同和批次
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedQuotas"></param>
        private void CopyContractAndQuota(int userId, Contract header, List<Quota> addedQuotas)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var x = QueryForObjs(GetObjQuery<UserICLink>(ctx), o => o.UserId == userId).ToList();
                List<int> bps = x.Select(o => o.BusinessPartnerId).Distinct().ToList();
                CopyContractWithBP(userId, header, addedQuotas, ctx, bps);
            }
        }

        private void CopyContractWithBP(int userId, Contract header, List<Quota> addedQuotas, SenLan2Entities ctx, List<int> bps)
        {
            if (bps.Contains(header.BPId.Value) && header.IsNeedAutoGenerated.HasValue && header.IsNeedAutoGenerated.Value)
            {
                //业务伙伴是内部客户，复制合同
                List<Quota> oldQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).ToList();
                Contract contract = CloneContract(header);
                
                contract.BPId = header.InternalCustomerId;
                contract.ContractType = header.ContractType == (int)ContractType.Purchase ? (int)ContractType.Sales : (int)ContractType.Purchase;
                contract.InternalCustomerId = header.BPId;
                contract.ContractNo = header.AutoContractNo;
                var quotas = new List<Quota>();
                if (addedQuotas != null && addedQuotas.Count > 0)
                {
                    foreach (var quota in addedQuotas)
                    {
                        var q = new Quota
                                    {
                                        ApprovalId = quota.ApprovalId,
                                        ApprovalStageIndex = quota.ApprovalStageIndex,
                                        ApproveStatus = quota.ApproveStatus,
                                        BrandId = quota.BrandId,
                                        CommodityId = quota.CommodityId,
                                        CommodityTypeId = quota.CommodityTypeId,
                                        Created = quota.Created,
                                        CreatedBy = quota.CreatedBy,
                                        DeliveryDate = quota.DeliveryDate,
                                        //DeliveryStatus = quota.DeliveryStatus,
                                        DocumentId = quota.DocumentId,
                                        //FinanceStatus = quota.FinanceStatus,
                                        ImplementedDate = quota.ImplementedDate,
                                        PricingCurrencyId = quota.PricingCurrencyId,
                                        PricingType = quota.PricingType,
                                        Quantity = quota.Quantity,
                                        ShipTerm = quota.ShipTerm,
                                        SpecificationId = quota.SpecificationId,
                                        Updated = quota.Updated,
                                        UpdatedBy = quota.UpdatedBy,
                                        //QuotaNo = quota.QuotaNo
                                        QuotaNo = quota.AutoQuotaNo,
                                        ExQuotaNo = quota.ExQuotaNo
                                    };
                        if (quota.PricingSide != 0)
                        {
                            //自动生成的点价方需要相反
                            if (quota.PricingSide == (int)PricingSide.OurSide)
                            {
                                q.PricingSide = (int)PricingSide.TheirSide;
                            }
                            else
                            {
                                q.PricingSide = (int)PricingSide.OurSide;
                            }
                        }
                        q.PricingStartDate = quota.PricingStartDate;
                        q.PricingEndDate = quota.PricingEndDate;
                        //q.VATStatus = (int)VATStatus.NotAtAll;
                        q.WarehouseId = quota.WarehouseId;
                        q.ContractId = contract.Id;
                        q.Premium = quota.Premium;
                        q.PricingBasis = quota.PricingBasis;
                        q.IsAutoGenerated = true;//是自动生成的
                        q.PaymentMeanId = quota.PaymentMeanId;
                        if (quota.PricingType != (int)PricingType.Fixed)
                        {
                            q.QuotaCurrentPrice = quota.QuotaCurrentPrice;
                        }

                        if (quota.Price == 0 && quota.PricingType == (int)PricingType.Fixed)
                        {
                            Pricing p = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quota.Id).FirstOrDefault();
                            //Pricing p = quota.Pricings.FirstOrDefault(o => o.IsDeleted == false);
                            q.Price = p.FinalPrice ?? 0;
                            q.SettlementRate = p.ExchangeRate;

                        }
                        else
                        {
                            q.Price = quota.Price;
                            q.SettlementRate = quota.SettlementRate;
                        }
                        q.RelQuotaId = quota.Id;
                        quotas.Add(q);
                    }

                    AddContractAndQuota(userId, contract, quotas, null);

                    foreach (var q in oldQuotas)
                    {
                        Quota newQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == q.Id);
                        q.RelQuotaId = newQuota.Id;
                        Update(GetObjSet<Quota>(ctx), q);
                    }

                    ctx.SaveChanges();
                }
                SetRelQuotaStr(userId, contract.Id);
            }
        }

        private Contract CloneContract(Contract contract)
        {
            var header = new Contract
                             {
                                 ContractUDF = contract.ContractUDF,
                                 Created = contract.Created,
                                 CreatedBy = contract.CreatedBy,
                                 Description = contract.Description,
                                 SignDate = contract.SignDate,
                                 TradeType = contract.TradeType,
                                 UDFId = contract.UDFId,
                                 ExContractNo = contract.ExContractNo,
                                 QtyLimit = contract.QtyLimit,
                                 Sales = contract.Sales
                             };
            return header;
        }


        decimal _rate;
        private decimal GetSettlementRateByPricingCurrencyWithCNY(int userId, int? pricingCurrencyId)
        {
            if (_rate == 0)
            {
                _rate = 1;
                if (pricingCurrencyId.HasValue)
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        Currency cny = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Code == "CNY");
                        Currency pricingCurrency = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Id == pricingCurrencyId.Value);
                        var rateService = new RateService();
                        _rate = rateService.GetExchangeRate(cny.Id, pricingCurrency.Id, userId).Value;
                    }
                }
            }
            return _rate;
        }

        /// <summary>
        /// 目前只有内贸短单
        /// </summary>
        /// <param name="addedQuotas"></param>
        /// <param name="quotaId"></param>
        /// <param name="relQuota"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<Quota> CloneQuotas(List<Quota> addedQuotas, int quotaId, RelQuota relQuota, int userId)
        {
            var quotas = new List<Quota>();
            if (addedQuotas != null && addedQuotas.Count > 0)
            {
                foreach (var quota in addedQuotas)
                {
                    var q = new Quota
                                {
                                    ApprovalId = quota.ApprovalId,
                                    ApprovalStageIndex = quota.ApprovalStageIndex,
                                    ApproveStatus = quota.ApproveStatus,
                                    BrandId = quota.BrandId,
                                    CommodityId = quota.CommodityId,
                                    CommodityTypeId = quota.CommodityTypeId,
                                    Created = quota.Created,
                                    CreatedBy = quota.CreatedBy,
                                    DeliveryDate = quota.DeliveryDate,
                                    DeliveryStatus = false,
                                    DocumentId = quota.DocumentId,
                                    FinanceStatus = false,
                                    ImplementedDate = relQuota.SignDate,
                                    PricingCurrencyId = quota.PricingCurrencyId,
                                    PricingType = (int)PricingType.Fixed,
                                    Quantity = quota.Quantity
                                };
                    q.SettlementRate = GetSettlementRateByPricingCurrencyWithCNY(userId, q.PricingCurrencyId);
                    q.ShipTerm = quota.ShipTerm;
                    q.SpecificationId = quota.SpecificationId;
                    q.Updated = quota.Updated;
                    q.UpdatedBy = quota.UpdatedBy;
                    q.VATStatus = (int)VATStatus.NotAtAll;
                    q.WarehouseId = quota.WarehouseId;
                    q.RelQuotaId = quotaId;
                    q.RelQuotaStr = quota.RelQuotaStr;
                    q.IsAutoGenerated = true;//自动生成
                    q.IsPaymentRequestFinished = quota.IsPaymentRequestFinished;
                    q.PaymentMeanId = quota.PaymentMeanId;
                    if (relQuota != null)
                    {
                        q.Price = relQuota.Price.Value;
                        q.RelPrice = relQuota.Price;
                        q.RelQuotaStage = relQuota.QuotaStage;
                        q.VATInvoiceDate = relQuota.VATInvoiceDate;
                    }

                    quotas.Add(q);
                }
            }
            return quotas;
        }

        private List<Attachment> CloneAttachment(IEnumerable<Attachment> addedAttachment)
        {
            var attachments = new List<Attachment>();
            if (attachments.Count > 0)
            {
                attachments.AddRange(addedAttachment.Select(att => new Attachment
                                                                       {
                                                                           Comment = att.Comment,
                                                                           Created = att.Created,
                                                                           CreatedBy = att.CreatedBy,
                                                                           FileName = att.FileName,
                                                                           Name = att.Name,
                                                                           Updated = att.Updated,
                                                                           UpdatedBy = att.UpdatedBy
                                                                       }));
            }
            return attachments;
        }

        private void AddContractAndQuota(int userId, Contract header, List<Quota> addedQuotas,
                                   IEnumerable<Attachment> addedAttachments)
        {
            CreateContract(header, userId);

            if (addedQuotas != null && addedQuotas.Count > 0)
            {
                //新增批次
                foreach (Quota quota in addedQuotas)
                {
                    CreateQuota(header, quota, userId);
                }
            }

            if (addedAttachments != null)
            {
                //有附件
                foreach (Attachment attachment in addedAttachments)
                {
                    CreateAttachment(header.Id, attachment, userId);
                }
            }
        }

        /// <summary>
        /// 新增合同
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="userId"> </param>
        private void CreateContract(Contract contract, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (contract != null)
                    {
                        //Handle Pricing
                        foreach (Quota q in contract.Quotas)
                        {
                            q.Id = 0;
                            q.Commodity = null;
                            q.Brand = null;
                            q.CommodityType = null;
                            q.Specification = null;
                            IPricingHandler h = PricingHelper.GetPricingHandler(q, ctx);
                            h.Handle();
                        }

                        if (string.IsNullOrWhiteSpace(contract.ContractNo) && !contract.IsDraft)
                        {
                            contract.ContractNo = GetContractNo(contract, ctx);
                        }
                        if (string.IsNullOrWhiteSpace(contract.ExContractNo) && !contract.IsDraft)
                        {
                            contract.ExContractNo = contract.ContractNo;
                        }

                        if (contract.IsDraft)
                        {
                            if (contract.BPId == 0) contract.BPId = null;
                            if (contract.InternalCustomerId == 0) contract.InternalCustomerId = null;
                        }

                        Create(GetObjSet<Contract>(ctx), contract);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 修改合同(Header)
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="userId"> </param>
        private void UpdateContract(Contract contract, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (!contract.IsDraft)
                {
                    if (string.IsNullOrWhiteSpace(contract.ExContractNo))
                    {
                        //生成原始合同号
                        contract.ExContractNo = GetContractNo(contract, ctx);
                    }
                    else
                    {
                        Contract contractSeeExNo = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contract.Id);
                        if (contractSeeExNo.ExContractNo != contract.ExContractNo)
                        {
                            ICollection<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contract.Id);
                            foreach (Quota quota in quotas)
                            {
                                UpdateExQuotaNo(quota.Id, contract.ExContractNo, userId);
                            }
                            if (_updatedQuotas != null)
                            {
                                foreach (Quota updatedQuota in _updatedQuotas)
                                {
                                    string qExNo = updatedQuota.ExQuotaNo;
                                    if (qExNo.IndexOf('/') != -1)
                                    {
                                        string n = qExNo.Substring(qExNo.Length - 3, 3);
                                        updatedQuota.ExQuotaNo = contract.ExContractNo + "/" + n;
                                    }
                                }
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(contract.ContractNo))
                    {
                        //生成合同号
                        contract.ContractNo = GetContractNo(contract, ctx);
                    }
                    else
                    {
                        Contract contractSeeNo = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contract.Id);
                        if (contractSeeNo.ContractNo != contract.ContractNo)
                        {
                            ICollection<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contract.Id);
                            foreach (Quota quota in quotas)
                            {
                                UpdateQuotaNo(quota.Id, contract.ContractNo, userId);
                            }
                            if (_updatedQuotas != null)
                            {
                                foreach (Quota updatedQuota in _updatedQuotas)
                                {
                                    string qNo = updatedQuota.QuotaNo;
                                    if (qNo.IndexOf('/') != -1)
                                    {
                                        string n = qNo.Substring(qNo.Length - 3, 3);
                                        updatedQuota.QuotaNo = contract.ContractNo + "/" + n;
                                    }
                                }
                            }
                        }
                    }
                }


                Contract oldContract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contract.Id);

                oldContract.BPId = contract.BPId;
                oldContract.ContractNo = contract.ContractNo;
                oldContract.ExContractNo = contract.ExContractNo;
                oldContract.ContractType = contract.ContractType;
                oldContract.Description = contract.Description;
                oldContract.InternalCustomerId = contract.InternalCustomerId;
                oldContract.SignDate = contract.SignDate;
                oldContract.TradeType = contract.TradeType;
                oldContract.IsDraft = contract.IsDraft;
                oldContract.QtyLimit = contract.QtyLimit;
                oldContract.UDFId = contract.UDFId;
                oldContract.IsNeedAutoGenerated = contract.IsNeedAutoGenerated;
                oldContract.BankAccountId = contract.BankAccountId;
                oldContract.Sales = contract.Sales;
                if (contract.IsDraft)
                {
                    if (contract.BPId == 0) oldContract.BPId = null;
                    if (contract.InternalCustomerId == 0) oldContract.InternalCustomerId = null;
                }

                Update(GetObjSet<Contract>(ctx), oldContract);
                ctx.SaveChanges();
            }
        }

        private void UpdateQuotaNo(int quotaId, string contractNo, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                //更改了ContractNo也把批次的QuotaNo更改掉
                string qNo = quota.QuotaNo;
                if (qNo.IndexOf('/') != -1)
                {
                    string n = qNo.Substring(qNo.Length - 3, 3);
                    quota.QuotaNo = contractNo + "/" + n;
                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();
                }
            }
        }

        private void UpdateExQuotaNo(int quotaId, string exContractNo, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                //更改了ContractNo也把批次的QuotaNo更改掉
                string qNo = quota.ExQuotaNo;
                if (qNo.IndexOf('/') != -1)
                {
                    string n = qNo.Substring(qNo.Length - 3, 3);
                    quota.ExQuotaNo = exContractNo + "/" + n;
                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 新增批次
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="quota"></param>
        /// <param name="userId"></param>
        private void CreateQuota(Contract contract, Quota quota, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<QuotaBrandRel> brandList = quota.QuotaBrandRels.ToList();
                quota.QuotaBrandRels.Clear();
                if (quota.IsDraft)
                {
                    if (quota.CommodityId == 0) quota.CommodityId = null;
                    if (quota.CommodityTypeId == 0) quota.CommodityTypeId = null;
                    if (quota.BrandId == 0) quota.BrandId = null;
                    if (quota.SpecificationId == 0) quota.SpecificationId = null;
                    if (quota.PricingCurrencyId == 0) quota.PricingCurrencyId = null;
                }

                IPricingHandler h = PricingHelper.GetPricingHandler(quota, ctx);
                h.Handle();
                if (string.IsNullOrWhiteSpace(quota.QuotaNo))
                {
                    //设置批次的批次号
                    quota.QuotaNo = GetQuotaNo(contract,userId);
                }
                if (string.IsNullOrWhiteSpace(quota.ExQuotaNo))
                {
                    //设置批次的批次号
                    quota.ExQuotaNo = GetExQuotaNo(contract,userId);
                }
                quota.Id = 0;
                quota.ContractId = contract.Id;

                int? commodityId = quota.CommodityId;
                int? commodityTypeId = quota.CommodityTypeId;
                int? brandId = quota.BrandId == 0 ? null : quota.BrandId;
                int? specificationId = quota.SpecificationId == 0 ? null : quota.SpecificationId;
                quota.Commodity = null;
                quota.CommodityType = null;
                quota.Brand = null;
                quota.Specification = null;
                quota.CommodityId = commodityId;
                quota.CommodityTypeId = commodityTypeId;
                quota.BrandId = brandId;
                quota.SpecificationId = specificationId;
                quota.VerifiedQuantity = 0;

                //初始化批次的若干状态
                quota.VATStatus = (int)QuotaVATStatus.NotAtAll;
                quota.DeliveryStatus = false;
                quota.FinanceStatus = false;
                quota.IsCIFinished = false;
                quota.IsFundflowFinished = false;
                quota.IsPaymentRequestFinished = false;
                quota.IsVatRequestFinished = false;

                quota.VATInvoicedQuantity = 0;

                if (quota.PaymentMeanId.HasValue && quota.PaymentMeanId == 0)
                {
                    quota.PaymentMeanId = null;
                }
                //if (contract.TradeType == (int)DBEntity.EnumEntity.TradeType.LongDomesticTrade || contract.TradeType == (int)DBEntity.EnumEntity.TradeType.ShortDomesticTrade)
                //{
                if (quota.PricingType != (int)PricingType.Fixed)
                {
                    //手工点价
                    quota.TempPrice = quota.Price;
                    quota.Price = 0;
                }
                //}
                //Calculate the amount for approval
                var sp = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                if (sp != null && sp.QuotaApprove)
                {
                    if (quota.PricingType == (int)PricingType.Fixed)
                    {
                        //Fix pricing's currency has been set in the pricing handler
                        quota.AmountForApproval = quota.Price * (quota.Quantity ?? 0);
                        quota.CurrencyIdForApproval = quota.PricingCurrencyId ?? 0;
                    }
                    else
                    {
                        Currency c = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Code == quota.QuotaCurrentPrice.Currency);
                        quota.CurrencyIdForApproval = c != null ? c.Id : 0;
                        quota.AmountForApproval = (quota.TempPrice??0) * (quota.Quantity ?? 0);
                    }
                }

                //设置DocumentId
                Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Quota");
                quota.DocumentId = doc.Id;

                Create(GetObjSet<Quota>(ctx), quota);
                ctx.SaveChanges();

                foreach (QuotaBrandRel brandRel in brandList)
                {
                    CreateQuotaBrandRel(userId, brandRel, quota);
                }

                if (!quota.IsAutoGenerated)
                {
                    int groupId = quota.Id;
                    if (QuotaGroupId.HasValue)
                    {
                        groupId = QuotaGroupId.Value;
                    }
                    SetQuotaGroupId(userId, quota.Id, groupId);
                }
                else
                {
                    if (_groupId == 0)
                    {
                        SetQuotaGroupId(userId, quota.Id, quota.Id);
                    }
                    else
                    {
                        SetQuotaGroupId(userId, quota.Id, _groupId);
                    }
                }

                var quotaService = new QuotaService();
                quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(quota.Id, userId);
                //quotaService.SetEqualityByQuotaId(quota.Id, userId);
                //修改价格(点价表加权平均)
                quotaService.UpdateQuotaFinalPriceByQuotaId(quota.Id, userId);
                quotaService.SetPaidAndReceivedAmount(quota.Id, userId);
                LogManager.WriteLog("Quota", "Create", quota.Id, userId, null);
            }
        }
        //多品牌新增
        private void CreateQuotaBrandRel(int userId, QuotaBrandRel quotaBrandRel, Quota quota)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var person = new QuotaBrandRel
                    {
                        BrandId = quotaBrandRel.BrandId,
                        SpecificationId = quotaBrandRel.SpecificationId == null ? null : quotaBrandRel.SpecificationId.Value <= 0 ? null : quotaBrandRel.SpecificationId,
                        Quantity = quotaBrandRel.Quantity,
                        Price = quotaBrandRel.Price,
                        WarehouseId = quotaBrandRel.WarehouseId,
                        QuotaId = quota.Id
                    };
                    Create(GetObjSet<QuotaBrandRel>(ctx), person);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        //修改多品牌
        private void UpdateQuotaBrandRel(int userId, QuotaBrandRel quotaBrandRel, Quota quota)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (quotaBrandRel.Id <= 0)
                    {
                        CreateQuotaBrandRel(userId, quotaBrandRel, quota);
                    }
                    else
                    {
                        QuotaBrandRel oldQuotaBrandRel =
                            QueryForObj(
                                GetObjQuery<QuotaBrandRel>(ctx, new List<string> { "Warehouse", "Brand", "Specification", "Quota" }),
                                c => c.Id == quotaBrandRel.Id);
                        oldQuotaBrandRel.BrandId = quotaBrandRel.BrandId;
                        oldQuotaBrandRel.SpecificationId = quotaBrandRel.SpecificationId;
                        oldQuotaBrandRel.Quantity = quotaBrandRel.Quantity;
                        oldQuotaBrandRel.Price = quotaBrandRel.Price;
                        oldQuotaBrandRel.WarehouseId = quotaBrandRel.WarehouseId;
                        oldQuotaBrandRel.IsDeleted = quotaBrandRel.IsDeleted;
                        oldQuotaBrandRel.QuotaId = quota.Id;
                        Update(GetObjSet<QuotaBrandRel>(ctx), oldQuotaBrandRel);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 修改批次
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="quota"> </param>
        /// <param name="userId"> </param>
        private void UpdateQuota(Contract contract, Quota quota, int userId)
        {
            int contractid = contract.Id;
            using (var ctx = new SenLan2Entities(userId))
            {
                IPricingHandler h = PricingHelper.GetPricingHandler(quota, ctx);
                h.Handle();
                if (string.IsNullOrWhiteSpace(quota.QuotaNo))
                {
                    if (contract.TradeType != (int)TradeType.ShortForeignTrade || contract.TradeType != (int)TradeType.ShortDomesticTrade)
                    //{
                    //    quota.QuotaNo = contract.ContractNo + "/001";
                    //}
                    //else
                    {
                        quota.QuotaNo = GetQuotaNo(contract,userId);
                    }
                }
                //else
                //{

                //}
                if (string.IsNullOrWhiteSpace(quota.ExQuotaNo))
                {
                    if (contract.TradeType != (int)TradeType.ShortForeignTrade || contract.TradeType != (int)TradeType.ShortDomesticTrade)
                    //{
                    //    quota.ExQuotaNo = contract.ExContractNo + "/001";
                    //}
                    //else
                    {
                        quota.ExQuotaNo = GetExQuotaNo(contract,userId);
                    }
                }

                if (contract.TradeType == (int)TradeType.ShortForeignTrade || contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    quota.QuotaNo = contract.ContractNo;
                    quota.ExQuotaNo = contract.ExContractNo;
                }

                Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.Id);
                oldQuota.StartTracking();
                oldQuota.ApprovalId = quota.ApprovalId;
                oldQuota.ApproveStatus = quota.ApproveStatus;
                oldQuota.BrandId = quota.BrandId;
                oldQuota.CommodityId = quota.CommodityId;
                oldQuota.CommodityTypeId = quota.CommodityTypeId;
                oldQuota.ContractId = contractid;
                oldQuota.PaymentMeanId = quota.PaymentMeanId;
                if (quota.DocumentId != null)
                {
                    oldQuota.DocumentId = quota.DocumentId;
                }

                //oldQuota.FinanceStatus = quota.FinanceStatus;
                //oldQuota.DeliveryStatus = quota.DeliveryStatus;
                oldQuota.ImplementedDate = quota.ImplementedDate;
                oldQuota.Premium = quota.Premium;
                oldQuota.Price = quota.Price;
                oldQuota.PricingBasis = quota.PricingBasis;
                oldQuota.PricingCurrencyId = quota.PricingCurrencyId;
                oldQuota.PricingEndDate = quota.PricingEndDate;
                oldQuota.PricingSide = quota.PricingSide;
                oldQuota.PricingStartDate = quota.PricingStartDate;
                oldQuota.PricingType = quota.PricingType;
                oldQuota.Quantity = quota.Quantity;
                oldQuota.QuotaNo = quota.QuotaNo;
                oldQuota.ExQuotaNo = quota.ExQuotaNo;
                oldQuota.PricingCurrencyId = quota.PricingCurrencyId;
                oldQuota.SpecificationId = quota.SpecificationId;
                oldQuota.WarehouseId = quota.WarehouseId;
                oldQuota.DeliveryDate = quota.DeliveryDate;

                if (quota.PricingStatus != null)
                {
                    oldQuota.PricingStatus = quota.PricingStatus;
                }

                oldQuota.IsDraft = quota.IsDraft;
                oldQuota.ShipTerm = quota.ShipTerm;

                if (quota.IsDraft)
                {
                    if (quota.CommodityId == 0) oldQuota.CommodityId = null;
                    if (quota.CommodityTypeId == 0) oldQuota.CommodityTypeId = null;
                    if (quota.PricingCurrencyId == 0) oldQuota.PricingCurrencyId = null;
                }

                if (quota.BrandId == 0) oldQuota.BrandId = null;
                if (quota.SpecificationId == 0) oldQuota.SpecificationId = null;
                //if (contract.TradeType == (int)DBEntity.EnumEntity.TradeType.LongDomesticTrade || contract.TradeType == (int)DBEntity.EnumEntity.TradeType.ShortDomesticTrade)
                //{
                    if (oldQuota.PricingType != (int)PricingType.Fixed)
                    {
                        //手工点价
                        oldQuota.TempPrice = quota.Price;
                        oldQuota.Price = 0;
                    }
                //}
                //Calculate the amount for approval
                var sp = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                if (sp != null && sp.QuotaApprove)
                {
                    if (oldQuota.PricingType == (int)PricingType.Fixed)
                    {
                        //Fix pricing's currency has been set in the pricing handler
                        oldQuota.AmountForApproval = oldQuota.Price* (oldQuota.Quantity ?? 0);
                        oldQuota.CurrencyIdForApproval = oldQuota.PricingCurrencyId ?? 0;
                    }
                    else
                    {
                        Currency c = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Code == quota.QuotaCurrentPrice.Currency);
                        oldQuota.CurrencyIdForApproval = c != null ? c.Id : 0;

                        //oldQuota.AmountForApproval = (quota.TempPrice??0) * (oldQuota.Quantity ?? 0);
                        oldQuota.AmountForApproval = (oldQuota.TempPrice ?? 0) * (oldQuota.Quantity ?? 0);
                    }
                }

                oldQuota.VATInvoiceDate = quota.VATInvoiceDate;

                //设置DocumentId
                Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Quota");
                oldQuota.DocumentId = doc.Id;

                if (oldQuota.ChangeTracker.State == ObjectState.Modified)
                {
                    ctx.ObjectStateManager.ChangeObjectState(oldQuota, EntityState.Modified);
                }

                //Update(GetObjSet<Quota>(ctx), oldQuota);

                ctx.SaveChanges();

                var quotaService = new QuotaService();
                quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(oldQuota.Id, userId);
                quotaService.UpdateQuotaFinalPriceByQuotaId(oldQuota.Id, userId);
                quotaService.SetPaidAndReceivedAmount(oldQuota.Id, userId);
                LogManager.WriteLog("Quota", "Update", oldQuota.Id, userId, null);
            }
        }

        private bool CanBeDelete(SenLan2Entities ctx, Quota quota)
        {
            try
            {
                CheckDocument(ctx, quota);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 合同能否编辑
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public bool ContractCanBeEditWithCopyContract(int userId, int quotaId)
        {
            bool canEdit = true;
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                Contract contract = QueryForObj(GetObjQuery<Contract>(ctx, new List<string> { "Quotas" }), o => o.Id == quota.ContractId);

                //TODO::111
                //if (contract.RelContractId.HasValue)
                //{
                //    Contract relContract = QueryForObj<Contract>(GetObjQuery<Contract>(ctx, new List<string>() { "Quotas" }), o => o.Id == contract.RelContractId.Value);

                //    foreach (Quota q in contract.Quotas)
                //    {
                //        if (q.IsDeleted)
                //            continue;
                //        bool result = CanBeDelete(ctx, q);
                //        if (!result)
                //        {
                //            return false;
                //        }
                //    }

                //    foreach (Quota q in relContract.Quotas)
                //    {
                //        if (q.IsDeleted)
                //            continue;
                //        bool result = CanBeDelete(ctx, q);
                //        if (!result)
                //        {
                //            return false;
                //        }
                //    }
                //}
            }


            return canEdit;
        }

        /// <summary>
        /// 删除批次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"> </param>
        private void DeleteQuota(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        //检查是否有关联单据
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), q => q.Id == id);

                        CheckDocument(ctx, quota);

                        DeleteQuota(userId, ctx, quota);

                        if (quota.Contract.TradeType == (int)TradeType.LongForeignTrade || quota.Contract.TradeType == (int)TradeType.ShortForeignTrade)
                        {
                            if (quota.RelQuotaId.HasValue)
                            {
                                Quota q = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), o => o.Id == quota.RelQuotaId.Value);
                                CheckDocument(ctx, q);

                                DeleteQuota(userId, ctx, q);
                            }
                        }

                        LogManager.WriteLog("Quota", "Delete", quota.Id, userId, null);

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
        /// 删除流转的合同的点价、未点价、批次、合同
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ctx"></param>
        /// <param name="quota"></param>
        private void DeleteQuota(int userId, SenLan2Entities ctx, Quota quota)
        {
            ICollection<Pricing> ps = QueryForObjs(GetObjQuery<Pricing>(ctx), d => d.QuotaId == quota.Id);
            ICollection<Unpricing> ups = QueryForObjs(GetObjQuery<Unpricing>(ctx), d => d.QuotaId == quota.Id);
            if (quota.PricingType == (int)PricingType.Fixed)
            {
                if (ps.Count > 0)
                {
                    Pricing firstOrDefault = ps.FirstOrDefault();
                    if (firstOrDefault != null) firstOrDefault.IsDeleted = true;
                }
            }
            else
            {
                //如果不是固定价点价且有点价记录，前边检查相关单据已抛出异常
                if (ups.Count > 0)
                {
                    Unpricing firstOrDefault = ups.FirstOrDefault();
                    if (firstOrDefault != null) firstOrDefault.IsDeleted = true;
                }
            }

            int quotaId = quota.Id;
            if (quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
            {
                List<Quota> oldRelQuotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), o => o.RelQuotaId == quotaId && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).ToList();
                List<Contract> oldContracts = oldRelQuotas.Select(o => o.Contract).Distinct().ToList();
                //删除以前自动生成的合同、批次、点价、未点价记录
                DeleteRelPricing(oldRelQuotas, userId);
                DeleteRelUnPricing(oldRelQuotas, userId);
                DeleteRelQuota(oldRelQuotas, userId);
                DeleteRelContract(oldContracts, userId);
            }
            quota.IsDeleted = true;
            //如果是最后一个删除的批次，合同也置为删除
            if (QueryForObjs(GetObjQuery<Quota>(ctx), q => q.ContractId == quota.ContractId && q.Id != quota.Id).Count == 0)
            {
                quota.Contract.IsDeleted = true;
            }
            ctx.SaveChanges();
        }

        /// <summary>
        /// 检查相关单据,批次能否删除
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="quota"></param>
        private void CheckDocument(SenLan2Entities ctx, Quota quota)
        {
            //1. 检查是否是关联客户自动生成的单据
            Contract c = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == quota.ContractId);
            //if (quota.RelQuotaId != null && c.TradeType == (int)TradeType.ShortDomesticTrade)
            //{
            //    throw new FaultException(ErrCode.DeleteRelQuotaConnected.ToString());
            //}
            //2. 检查关联的提单和发货单
            if (QueryForObjs(GetObjQuery<Delivery>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaDeliveryConnected.ToString());
            }
            //3. 检查关联的出库
            if (QueryForObjs(GetObjQuery<WarehouseOut>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaWarehouseOutConnected.ToString());
            }
            //4. 检查关联的付款申请
            if (QueryForObjs(GetObjQuery<PaymentRequest>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaPaymentRequestConnected.ToString());
            }
            //5. 检查关联的信用证
            if (QueryForObjs(GetObjQuery<LetterOfCredit>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaLetterOfCreditConnected.ToString());
            }
            //6. 检查关联的现金收付
            if (QueryForObjs(GetObjQuery<FundFlow>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaFundFlowConnected.ToString());
            }
            //7. 检查关联的增值税开票申请
            if (QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaVATInvoiceRequestConnected.ToString());
            }
            //8. 检查关联的增值税发票
            if (QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), d => d.QuotaId == quota.Id).Count > 0)
            {
                throw new FaultException(ErrCode.QuotaVATInvoiceConnected.ToString());
            }

            //9. 检查关联的报纸分组
            if (quota.IsHedged)
            {
                throw new FaultException(ErrCode.QuotaHedgedNotAbleToDeleteModify.ToString());
            }

            //10. 检查关联的点价
            //如果是固定价点价，直接删除点价记录
            //否则抛出异常
            ICollection<Pricing> ps = QueryForObjs(GetObjQuery<Pricing>(ctx), d => d.QuotaId == quota.Id);
            if (quota.PricingType != (int)PricingType.Fixed && ps.Count > 0)
            {
                throw new FaultException(ErrCode.QuotaPricingConnected.ToString());
            }
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="attachment"></param>
        /// <param name="userId"></param>
        private void CreateAttachment(int contractId, Attachment attachment, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (attachment != null)
                    {
                        //设置DocumentId
                        Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Contract");
                        attachment.Id = 0;
                        attachment.DocumentId = doc.Id;
                        attachment.RecordId = contractId;
                        Create(GetObjSet<Attachment>(ctx), attachment);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="attachment"></param>
        private void DeleteAttachment(SenLan2Entities ctx, Attachment attachment)
        {
            if (attachment != null)
            {
                attachment.IsDeleted = true;
                Update(GetObjSet<Attachment>(ctx), attachment);
                ctx.SaveChanges();
            }
        }

        private List<Quota> _updatedQuotas;

        /// <summary>
        /// 修改合同
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedQuotas"></param>
        /// <param name="updatedQuotas"></param>
        /// <param name="deletedQuotas"></param>
        /// <param name="addedAttachments"></param>
        /// <param name="deletedAttachments"></param>
        /// <param name="relQuotas"></param>
        public void UpdateDocument(int userId, Contract header, List<Quota> addedQuotas, List<Quota> updatedQuotas,
                                   List<Quota> deletedQuotas, List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments, List<RelQuota> relQuotas, int? groupId)
        {
            //获取合同未修改前的所有批次，用于非固定价的批次审批时候取价格
            List<Quota> oldQuotas = GetOldQuotasByContractId(userId, header.Id);

            GetQuotaCurrentPrice(oldQuotas);
            GetQuotaCurrentPrice(addedQuotas);
            GetQuotaCurrentPrice(updatedQuotas);
            _updatedQuotas = updatedQuotas;

            //string relQtotaStr = GetheaderRelQuotaStr(userId, header);

            //if (relQuotas != null && relQuotas.Count > 0)
            //{
            //    relQtotaStr += " " + updatedQuotas[0].Price;
            //    relQtotaStr = relQuotas.Aggregate(relQtotaStr, (current, relQuota) => current + ("->" + relQuota.BusinessParnterName + " " + relQuota.Price));
            //}

            int maxStage = GetMaxStageByContractId(userId, header.Id);

            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        //获取自动生成的合同Id
                        int generateContractId = GetGenerateContractId(userId, header);

                        GetCommodityId(ctx, header.Id, addedQuotas, updatedQuotas);

                        Contract oldContract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == header.Id);
                        List<Quota> oldQuotasList = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).ToList();
                        UpdateContractAndQuota(userId, header, addedQuotas, updatedQuotas, deletedQuotas, addedAttachments, deletedAttachments, ctx);

                        if (relQuotas != null && relQuotas.Count > 0)
                        {
                            int max = relQuotas.Max(o => o.QuotaStage);


                            //有增加关联交易
                            //只有内贸短单，所以只有一个批次
                            Quota quota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).FirstOrDefault();


                            if (quota != null)
                            {
                                int quotaId = quota.Id;

                                //DeleteRelQuotaAndContract(userId, ctx, quotaId);

                                List<Quota> addQuotas = new List<Quota>();
                                //重新生成合同和批次
                                if (addedQuotas != null && addedQuotas.Count > 0)
                                {
                                    addQuotas = addedQuotas;
                                }
                                else if (updatedQuotas != null && updatedQuotas.Count > 0)
                                {
                                    addQuotas = updatedQuotas;
                                }
                                else
                                {
                                    addQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.Id == quotaId).ToList();
                                }
                                //List<Quota> addQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.Id == quotaId).ToList();
                                Quota addquota = addQuotas.FirstOrDefault();
                                if (addquota.ApprovalId == null)
                                {
                                    addquota.ApprovalId = quota.ApprovalId;
                                    addquota.ApprovalStageIndex = quota.ApprovalStageIndex;
                                    addquota.ApproveStatus = quota.ApproveStatus;
                                }

                                int stage = maxStage;

                                if (max < maxStage)
                                {
                                    //有删掉关联交易
                                    for (int i = maxStage; i > max; i--)
                                    {
                                        List<Quota> stageQuotas = GetQuotaListByStageAndContractId(userId, i, header.Id);
                                        foreach (var q in stageQuotas)
                                        {
                                            DeleteRelQuotaByQuotaId(userId, q.Id);
                                        }
                                    }
                                    stage = max;
                                }

                                else if (header.TradeType == (int)TradeType.ShortDomesticTrade && header.ContractType == (int)ContractType.Purchase)
                                {
                                    UpdateRelQuotas(userId, addquota, relQuotas, stage, header);
                                }

                                relQuotas = relQuotas.OrderBy(o => o.QuotaStage).ToList();

                                if (max > maxStage)
                                {

                                    List<RelQuota> addRelQuota = relQuotas.Where(o => o.QuotaStage > maxStage).OrderBy(o => o.QuotaStage).ToList();

                                    //int internalCustomerId = header.InternalCustomerId.Value;
                                    int internalCustomerId;
                                    if (maxStage == 0)
                                    {
                                        internalCustomerId = header.InternalCustomerId.Value;
                                    }
                                    else
                                    {
                                        internalCustomerId = GetQuotaByStageAndContractId(userId, maxStage, header.Id).Contract.InternalCustomerId.Value;
                                    }

                                    Quota oldQuota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).FirstOrDefault();
                                    foreach (var q in addQuotas)
                                    {
                                        q.IsPaymentRequestFinished = oldQuota.IsPaymentRequestFinished;
                                        q.DeliveryStatus = false;
                                        q.FinanceStatus = false;
                                    }

                                    foreach (var relQuota in addRelQuota)
                                    {

                                        Contract contractPurchase = CloneContract(header);
                                        contractPurchase.BPId = internalCustomerId;
                                        contractPurchase.ContractType = (int)ContractType.Purchase;
                                        contractPurchase.InternalCustomerId = relQuota.BusinessParnterId;
                                        List<Quota> quotas = CloneQuotas(addQuotas, quotaId, relQuota, userId);
                                        quotas.ForEach(o => o.DeliveryStatus = false);
                                        contractPurchase.SignDate = relQuota.SignDate;
                                        AddContractAndQuota(userId, contractPurchase, quotas, null);
                                        SetQuotaGroupId(userId, quotas.FirstOrDefault().Id, quotas.FirstOrDefault().Id);

                                        Contract contractSales = CloneContract(header);
                                        contractSales.BPId = relQuota.BusinessParnterId;
                                        contractSales.ContractType = (int)ContractType.Sales;
                                        contractSales.InternalCustomerId = internalCustomerId;
                                        quotas = CloneQuotas(addQuotas, quotaId, relQuota, userId);
                                        quotas.ForEach(o => o.DeliveryStatus = false);
                                        contractSales.SignDate = relQuota.SignDate;
                                        AddContractAndQuota(userId, contractSales, quotas, null);
                                        SetQuotaGroupId(userId, quotas.FirstOrDefault().Id, quotas.FirstOrDefault().Id);

                                        internalCustomerId = relQuota.BusinessParnterId;
                                    }
                                }
                            }
                        }
                        else if (header.TradeType == (int)TradeType.ShortDomesticTrade && header.ContractType == (int)ContractType.Purchase)
                        {
                            //没有关联交易
                            if (oldQuotasList.Count > 0)
                            {
                                DeleteRelQuotaAndContract(userId, ctx, oldQuotasList[0].Id);
                            }

                        }
                        if (header.TradeType == (int)TradeType.ShortForeignTrade || header.TradeType == (int)TradeType.LongForeignTrade)
                        {
                            //外贸自动生成的单据
                            ResetRelContract(userId, generateContractId, header, addedQuotas, updatedQuotas, deletedQuotas, oldQuotas);
                        }

                        //UpdateRelQuotaStr(userId, header.Id, relQtotaStr);
                        SetRelQuotaStr(userId, header.Id);
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

        private void SetRelQuotaStr(int userId, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contractId);
                if (contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    Quota quota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault();
                    PSQuotaRelService psService = new PSQuotaRelService();
                    if (contract.ContractType == (int)ContractType.Purchase)
                    {
                        //采购批次
                        psService.SetRelStrByPurchaseQuotaId(userId, quota.Id);
                    }
                    else
                    {
                        //销售批次
                        psService.SetRelStrBySaleQuotaId(userId, quota.Id);
                    }
                }
                else
                {
                    List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).ToList();
                    string quotaStr = GetheaderRelQuotaStr(userId, contract);
                    foreach (var q in quotas)
                    {
                        string str = quotaStr;
                        decimal price = 0;
                        if (q.PricingType == (int)PricingType.Fixed)
                        {
                            //固定价
                            Pricing pricing = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == q.Id).FirstOrDefault();
                            if (pricing != null)
                                price = pricing.FinalPrice.Value;
                            str += " " + price.ToString(RoundRules.STR_PRICE);
                        }
                        q.RelQuotaStr = str;
                        Update(GetObjSet<Quota>(ctx), q);
                    }
                }
                ctx.SaveChanges();

            }
        }

        private void DeleteRelQuotaAndContract(int userId, SenLan2Entities ctx, int quotaId)
        {
            List<Quota> oldRelQuotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }),
                o => o.RelQuotaId == quotaId && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).ToList();
            if (oldRelQuotas.Count > 0)
            {
                List<Contract> oldContracts = oldRelQuotas.Select(o => o.Contract).Distinct().ToList();

                //删除以前自动生成的合同、批次、点价、未点价记录
                DeleteRelPricing(oldRelQuotas, userId);
                DeleteRelUnPricing(oldRelQuotas, userId);
                DeletePSRelQuota(oldRelQuotas, userId);
                DeleteRelQuota(oldRelQuotas, userId);
                DeleteRelContract(oldContracts, userId);
            }
        }

        private void DeletePSRelQuota(List<Quota> quotas, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var quota in quotas)
                {
                    List<PSQuotaRel> rels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.PQuotaId == quota.Id || o.SQuotaId == quota.Id).ToList();
                    foreach (var rel in rels)
                    {
                        rel.IsDeleted = true;
                        Update(GetObjSet<PSQuotaRel>(ctx), rel);
                    }
                }
                ctx.SaveChanges();
            }
        }

        private void UpdateRelQuotas(int userId, Quota addQuota, List<RelQuota> relQuotas, int maxStage, Contract header)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == addQuota.Id).OrderBy(o => o.RelQuotaStage).ToList();
                Quota updatedQuota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == addQuota.Id);
                int BpId = header.InternalCustomerId.Value;
                foreach (var quota in quotas)
                {
                    if (quota.RelQuotaStage.HasValue)
                    {
                        int stage = quota.RelQuotaStage.Value;
                        RelQuota rel = relQuotas.Where(o => o.QuotaStage == stage).FirstOrDefault();
                        if (stage > 1)
                        {
                            RelQuota preRel = relQuotas.Where(o => o.QuotaStage == stage - 1).FirstOrDefault();
                            BpId = preRel.BusinessParnterId;
                        }

                        List<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quota.Id).ToList();
                        foreach (var pricing in pricings)
                        {
                            pricing.FinalPrice = rel.Price.Value;
                            if (addQuota.PricingType == (int)PricingType.Fixed)
                            {
                                //固定价
                                pricing.CurrencyId = addQuota.PricingCurrencyId;
                                pricing.ExchangeRate = addQuota.SettlementRate;
                            }
                            Update(GetObjSet<Pricing>(ctx), pricing);
                        }
                        quota.ImplementedDate = rel.SignDate;
                        quota.RelPrice = rel.Price.Value;
                        quota.VATInvoiceDate = rel.VATInvoiceDate;
                        Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == quota.ContractId);
                        contract.SignDate = rel.SignDate;
                        if (contract.ContractType == (int)ContractType.Purchase)
                        {
                            //采购合同
                            contract.BPId = BpId;
                            contract.InternalCustomerId = rel.BusinessParnterId;
                        }
                        else
                        {
                            //销售合同
                            contract.BPId = rel.BusinessParnterId;
                            contract.InternalCustomerId = BpId;
                        }
                        Update(GetObjSet<Contract>(ctx), contract);
                    }
                    else
                    {
                        quota.ImplementedDate = updatedQuota.ImplementedDate;
                    }
                    quota.ApprovalId = updatedQuota.ApprovalId;
                    quota.ApprovalStageIndex = updatedQuota.ApprovalStageIndex;
                    quota.ApproveStatus = updatedQuota.ApproveStatus;
                    quota.BrandId = updatedQuota.BrandId;
                    quota.CommodityId = updatedQuota.CommodityId;
                    quota.CommodityTypeId = updatedQuota.CommodityTypeId;
                    quota.DeliveryDate = updatedQuota.DeliveryDate;
                    //quota.DeliveryStatus = updatedQuota.DeliveryStatus;

                    //quota.FinanceStatus = updatedQuota.FinanceStatus;
                    quota.PricingCurrencyId = updatedQuota.PricingCurrencyId;
                    quota.Premium = updatedQuota.Premium;
                    quota.Quantity = updatedQuota.Quantity;
                    quota.SettlementRate = GetSettlementRateByPricingCurrencyWithCNY(userId, updatedQuota.PricingCurrencyId);
                    quota.ShipTerm = updatedQuota.ShipTerm;
                    quota.SpecificationId = updatedQuota.SpecificationId;
                    quota.WarehouseId = updatedQuota.WarehouseId;
                    quota.PaymentMeanId = updatedQuota.PaymentMeanId;
                    if (quota.BrandId == 0)
                    {
                        quota.BrandId = null;
                    }
                    if (quota.SpecificationId == 0)
                    {
                        quota.SpecificationId = null;
                    }
                    Update(GetObjSet<Quota>(ctx), quota);
                }
                ctx.SaveChanges();
                var quotaService = new QuotaService();
                foreach (var quota in quotas)
                {
                    quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(quota.Id, userId);
                    //quotaService.SetEqualityByQuotaId(quota.Id, userId);
                    //修改价格(点价表加权平均)
                    quotaService.UpdateQuotaFinalPriceByQuotaId(quota.Id, userId);
                    quotaService.SetPaidAndReceivedAmount(quota.Id, userId);
                }
            }
        }

        /// <summary>
        /// 获取合同为修改前的所有批次
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contractId"></param>
        /// <returns></returns>
        private List<Quota> GetOldQuotasByContractId(int userId, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).ToList();
                return quotas;
            }
        }

        private void UpdateContractAndQuota(int userId, Contract header, IEnumerable<Quota> addedQuotas, IEnumerable<Quota> updatedQuotas, IEnumerable<Quota> deletedQuotas, IEnumerable<Attachment> addedAttachments, IEnumerable<Attachment> deletedAttachments, SenLan2Entities ctx)
        {
            UpdateContract(header, userId);

            if (addedQuotas != null)
            {
                foreach (Quota addedQuota in addedQuotas)
                {
                    CreateQuota(header, addedQuota, userId);
                }
            }
            if (updatedQuotas != null)
            {
                foreach (Quota updatedQuota in updatedQuotas)
                {
                    UpdateQuota(header, updatedQuota, userId);
                    foreach (QuotaBrandRel quotaBrandRel in updatedQuota.QuotaBrandRels)
                    {
                        UpdateQuotaBrandRel(userId, quotaBrandRel, updatedQuota);
                    }
                }
            }
            if (deletedQuotas != null)
            {
                foreach (Quota deletedQuota in deletedQuotas)
                {
                    DeleteQuota(deletedQuota.Id, userId);
                }
            }
            if (addedAttachments != null)
            {
                //有附件
                foreach (Attachment attachment in addedAttachments)
                {
                    CreateAttachment(header.Id, attachment, userId);
                }
            }
            if (deletedAttachments != null)
            {
                //有附件
                foreach (Attachment attachment in deletedAttachments)
                {
                    DeleteAttachment(ctx, attachment);
                }
            }

        }

        private int GetGenerateContractId(int userId, Contract header)
        {
            int id = 0;
            if (header.TradeType == (int)TradeType.ShortForeignTrade || header.TradeType == (int)TradeType.LongForeignTrade)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Quota quota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).FirstOrDefault();
                    if (quota.RelQuotaId.HasValue)
                    {
                        Quota copyQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                        Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == copyQuota.ContractId);
                        id = contract.Id;
                    }
                }
            }
            return id;
        }

        private void ResetRelContract(int userId, int contractId, Contract header, List<Quota> addedQuotas, List<Quota> updatedQuotas, List<Quota> deletedQuotas, List<Quota> oldQuotaList)
        {

            using (var ctx = new SenLan2Entities(userId))
            {
                Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contractId);

                var x = QueryForObjs(GetObjQuery<UserICLink>(ctx), o => o.UserId == userId).ToList();
                List<int> bps = x.Select(o => o.BusinessPartnerId).Distinct().ToList();
                if (contractId != 0)
                {
                    //有自动生成的单据
                    if (bps.Contains(header.BPId.Value))
                    {
                        //业务伙伴是内部客户，复制合同
                        contract.BPId = header.BPId;
                        contract.ContractUDF = header.ContractUDF;
                        contract.Description = header.Description;
                        contract.ExContractNo = header.ExContractNo;
                        contract.InternalCustomerId = header.InternalCustomerId;
                        contract.SignDate = header.SignDate;
                        contract.UDFId = header.UDFId;
                        contract.Updated = header.Updated;
                        contract.UpdatedBy = header.UpdatedBy;
                        contract.BPId = header.InternalCustomerId;
                        contract.ContractType = header.ContractType == (int)ContractType.Purchase ? (int)ContractType.Sales : (int)ContractType.Purchase;
                        contract.InternalCustomerId = header.BPId;
                        contract.BankAccountId = header.BankAccountId;
                        //contract.ContractNo = header.ContractNo;
                        contract.ContractNo = header.AutoContractNo;

                        addedQuotas = GetAddedQuota(userId, addedQuotas, contract.Id);
                        updatedQuotas = GetUpdateQuota(userId, updatedQuotas, contract.Id);
                        deletedQuotas = GetDeleteQuota(userId, deletedQuotas);
                        UpdateContractAndQuota(userId, contract, addedQuotas, updatedQuotas, deletedQuotas, null, null, ctx);

                        SetRelQuotaId(userId, contractId, header.Id);
                        SetRelQuotaStr(userId, contract.Id);
                    }
                    else
                    {
                        //业务伙伴更改为不是内部客户的了，需要删掉以前生成的合同和批次
                        List<Quota> oldQuotas = QueryForObjs<Quota>(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).ToList();
                        foreach (var oldQuota in oldQuotas)
                        {
                            oldQuota.IsDeleted = true;
                            Update(GetObjSet<Quota>(ctx), oldQuota);
                        }
                        contract.IsDeleted = true;
                        Update(GetObjSet<Contract>(ctx), contract);

                        List<Quota> newQuotas = QueryForObjs<Quota>(GetObjQuery<Quota>(ctx), o => o.ContractId == header.Id).ToList();
                        foreach (var newQuota in newQuotas)
                        {
                            newQuota.RelQuotaId = null;
                            newQuota.IsAutoGenerated = false;
                            Update(GetObjSet<Quota>(ctx), newQuota);
                        }

                        ctx.SaveChanges();
                    }
                }
                else
                {
                    //需要看更改后的合同的业务伙伴是否是内部客户，如果是的也要再生成一份对应的合同
                    if (bps.Contains(header.BPId.Value))
                    {
                        //此处构造addedQuotas
                        if (deletedQuotas != null && deletedQuotas.Count > 0)
                        {
                            foreach (var deleteQuota in deletedQuotas)
                            {
                                Quota quota = oldQuotaList.Find(o => o.Id == deleteQuota.Id);
                                oldQuotaList.Remove(quota);
                            }
                        }

                        if (updatedQuotas != null && updatedQuotas.Count > 0)
                        {
                            foreach (var updatedQuota in updatedQuotas)
                            {
                                Quota quota = oldQuotaList.Find(o => o.Id == updatedQuota.Id);
                                oldQuotaList.Remove(quota);
                                oldQuotaList.Add(updatedQuota);
                            }
                        }

                        if (addedQuotas != null && addedQuotas.Count > 0)
                        {
                            oldQuotaList.AddRange(addedQuotas);
                        }

                        CopyContractWithBP(userId, header, oldQuotaList, ctx, bps);
                    }
                }
            }
        }

        private void SetRelQuotaId(int userId, int contractId, int oldContractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).ToList();
                List<Quota> oldQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == oldContractId).ToList();
                foreach (var q in oldQuotas)
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == q.Id);
                    q.RelQuotaId = quota.Id;
                    Update(GetObjSet<Quota>(ctx), q);
                }
                ctx.SaveChanges();
            }
        }

        private void DeleteRelPricing(List<Quota> relQuotas, int userId)
        {
            if (relQuotas != null && relQuotas.Count > 0)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    foreach (Quota oldQuota in relQuotas)
                    {
                        List<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == oldQuota.Id).ToList();
                        if (pricings != null && pricings.Count > 0)
                        {
                            foreach (var pricing in pricings)
                            {
                                pricing.IsDeleted = true;
                                Update(GetObjSet<Pricing>(ctx), pricing);
                            }
                        }
                    }
                    ctx.SaveChanges();
                }
            }
        }

        private void DeleteRelUnPricing(List<Quota> relQuotas, int userId)
        {
            if (relQuotas != null && relQuotas.Count > 0)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    foreach (Quota oldQuota in relQuotas)
                    {
                        List<Unpricing> unPricings = QueryForObjs(GetObjQuery<Unpricing>(ctx), o => o.QuotaId == oldQuota.Id).ToList();
                        if (unPricings != null && unPricings.Count > 0)
                        {
                            foreach (var unPricing in unPricings)
                            {
                                unPricing.IsDeleted = true;
                                Update(GetObjSet<Unpricing>(ctx), unPricing);
                            }
                        }
                    }
                    ctx.SaveChanges();
                }
            }
        }

        private void DeleteRelQuota(List<Quota> relQuotas, int userId)
        {
            if (relQuotas != null && relQuotas.Count > 0)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    foreach (Quota oldQuota in relQuotas)
                    {
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == oldQuota.Id);
                        quota.IsDeleted = true;
                        Update(GetObjSet<Quota>(ctx), quota);
                    }
                    ctx.SaveChanges();
                }
            }
        }

        private void DeleteRelContract(List<Contract> relContract, int userId)
        {
            if (relContract != null && relContract.Count > 0)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    foreach (Contract oldContract in relContract)
                    {
                        Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == oldContract.Id);
                        contract.IsDeleted = true;
                        Update(GetObjSet<Contract>(ctx), contract);
                    }
                    ctx.SaveChanges();
                }
            }
        }

        #endregion

        #region 生成单据号

        private int _commodityId;   //记录金属Id,生成合同号用

        /// <summary>
        /// 为生成单据号做准备
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="contractId"></param>
        /// <param name="addedQuotas"></param>
        /// <param name="updatedQuotas"></param>
        private void GetCommodityId(SenLan2Entities ctx, int contractId, List<Quota> addedQuotas,
                                    List<Quota> updatedQuotas)
        {
            if (addedQuotas != null)
            {
                _commodityId = addedQuotas[0].CommodityId ?? 0;
            }
            else if (updatedQuotas != null)
            {
                _commodityId = updatedQuotas[0].CommodityId ?? 0;
            }
            else
            {
                _commodityId = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault().CommodityId ?? 0;
            }
        }

        /// <summary>
        /// 生成批次号
        /// </summary>
        private string GetQuotaNo(Contract contract, int userId)
        {
            DocumentNoGenerator documentNoHelper = new AMERDocumentNoGenerator();
            string no = documentNoHelper.QuotaNoGenerator(contract.Id);
            return no;
            //if (contract.TradeType == (int)TradeType.ShortDomesticTrade || contract.TradeType == (int)TradeType.ShortForeignTrade)
            //{
            //    return contract.ContractNo;
            //}
            //using (var ctx = new SenLan2Entities(userId))
            //{
            //    int quotaCount = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contract.Id && o.Contract.ContractType == contract.ContractType && o.Contract.TradeType == contract.TradeType).Count;
            //    quotaCount++;
            //    return contract.ContractNo + "/" + quotaCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            //}
        }

        /// <summary>
        /// 生成原始批次号
        /// </summary>
        private string GetExQuotaNo(Contract contract, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int quotaCount = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contract.Id && o.Contract.ContractType == contract.ContractType && o.Contract.TradeType == contract.TradeType).Count;
                quotaCount++;
                if (contract.TradeType == (int)TradeType.ShortDomesticTrade || contract.TradeType == (int)TradeType.ShortForeignTrade)
                {
                    if (string.IsNullOrEmpty(contract.ExContractNo))
                    {
                        return contract.ContractNo;
                    }
                    return contract.ExContractNo;
                }
                else
                {
                    if (string.IsNullOrEmpty(contract.ExContractNo))
                    {
                        return contract.ContractNo + "/" + quotaCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                    }
                    return contract.ExContractNo + "/" + quotaCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                }
            }
        }

        /// <summary>
        /// 自动生成合同号
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private string GetContractNo(Contract contract, SenLan2Entities ctx)
        {
            //string datetime = contract.SignDate.Value.ToString("yyyyMMdd");
            string no;

            //BusinessPartner businessPartner = QueryForObj(GetObjQuery<BusinessPartner>(ctx),
            //                                              o => o.Id == contract.InternalCustomerId);

            if (_commodityId == 0)
            {
                GetCommodityId(ctx, contract.Id, null, null);
            }

            DocumentNoGenerator documentNoHelper = new AMERDocumentNoGenerator();
            no = documentNoHelper.ContractNoGenerator(contract.SignDate.Value, contract.ContractType, _commodityId, contract.InternalCustomerId.Value, contract.TradeType);

            //Commodity commodity = QueryForObj(GetObjQuery<Commodity>(ctx),
            //                                  c => c.Id == _commodityId);



            //if (contract.ContractType == (int)ContractType.Purchase)
            //{
            //    int count = GetContractCountToday(ctx, contract, ContractType.Purchase);
            //    no = businessPartner.Code + "-" + commodity.Code + "-" + "P" + datetime + "-" +
            //            count.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            //}
            //else
            //{
            //    int count = GetContractCountToday(ctx, contract, ContractType.Sales);
            //    no = businessPartner.Code + "-" + commodity.Code + "-" + "S" + datetime + "-" +
            //            count.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            //}
            return no;
        }

        ///// <summary>
        ///// 获取当天新增的合同数量（生成合同号用）
        ///// </summary>
        ///// <param name="ctx"></param>
        ///// <param name="contract"></param>
        ///// <param name="contractType"></param>
        ///// <returns></returns>
        //private int GetContractCountToday(SenLan2Entities ctx, Contract contract, ContractType contractType)
        //{
        //    DateTime startTime = Convert.ToDateTime(contract.SignDate.Value.ToShortDateString());
        //    DateTime endTime = startTime.AddDays(1);
        //    List<Contract> contracts = QueryForObjs(GetObjQueryWithDeleted<Contract>(ctx),
        //                                            o => o.SignDate >= startTime && o.SignDate < endTime && o.ContractType == (int)contractType).ToList();
        //    return contracts.Count + 1;
        //}
        #endregion

        /// <summary>
        /// Fill the current price for non-fixed-price quota
        /// </summary>
        /// <param name="quotas"></param>
        public void GetQuotaCurrentPrice(List<Quota> quotas)
        {
            if (quotas != null)
            {
                var senlan2CTX = new SenLan2Entities();
                var sp = GetAll(GetObjQuery<SystemParameter>(senlan2CTX)).FirstOrDefault();

                if (sp != null && sp.QuotaApprove)
                {
                    foreach (var quota in quotas)
                    {
                        if (quota.PricingType != (int)PricingType.Fixed)
                        {
                            var comm = GetById(GetObjQuery<Commodity>(senlan2CTX), quota.CommodityId ?? 0);
                            var cp = MarketPriceManager.GetCurrentPrice(quota.PricingBasis ?? 0, comm);
                            quota.QuotaCurrentPrice = cp;
                            quota.QuotaCurrentPrice.Price += quota.Premium ?? 0;
                        }
                    }
                }
            }
        }

        #region 合同流转公用方法
        private int GetMaxStageByContractId(int userId, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int maxStage = 0;
                Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == contractId);
                if (contract.ContractType == (int)ContractType.Purchase && contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    Quota quota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault();
                    maxStage = GetMaxStageByQuotaId(userId, quota.Id);
                }
                return maxStage;
            }
        }

        private Quota GetFirstQuotaByContractId(int userId, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault();
                return quota;
            }
        }

        private int GetMaxStageByQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int maxStage = 0;
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                List<Quota> quotas = GetAllRelQuotas(userId, quota);
                if (quotas.Count > 0)
                {
                    maxStage = quotas.Max(o => o.RelQuotaStage.Value);
                }
                return maxStage;
            }
        }

        private Quota GetFirstQuotaByQuota(int userId, Quota quota)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (quota.RelQuotaId.HasValue)
                {
                    quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                }
                return quota;
            }
        }

        private List<Quota> GetAllRelQuotas(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                return GetAllRelQuotas(userId, quota);
            }
        }

        private List<Quota> GetAllRelQuotas(int userId, Quota quota)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota firstQuota = GetFirstQuotaByQuota(userId, quota);
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string>() { "Contract" }),
                    o => o.RelQuotaId == firstQuota.Id).ToList();
                return quotas;
            }
        }

        private Quota GetQuotaByStageAndContractId(int userId, int stage, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota firstQuota = GetFirstQuotaByContractId(userId, contractId);
                List<Quota> quotas = GetAllRelQuotas(userId, firstQuota);
                if (quotas.Count > 0)
                {
                    if (quotas.Max(o => o.RelQuotaStage.Value) >= stage)
                    {
                        Quota quota = quotas.Where(o => o.RelQuotaStage == stage && o.Contract.ContractType == (int)ContractType.Purchase).FirstOrDefault();
                        return quota;
                    }
                }
                return null;
            }
        }

        private List<Quota> GetQuotaListByStageAndContractId(int userId, int stage, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota firstQuota = GetFirstQuotaByContractId(userId, contractId);
                List<Quota> quotas = GetAllRelQuotas(userId, firstQuota);
                if (quotas.Count > 0)
                {
                    if (quotas.Max(o => o.RelQuotaStage.Value) >= stage)
                    {
                        List<Quota> stageQuota = quotas.Where(o => o.RelQuotaStage == stage).ToList();
                        return stageQuota;
                    }
                }
                return null;
            }
        }

        private void DeleteRelQuotaByQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                List<Pricing> pricings = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == quotaId).ToList();
                List<Unpricing> unPricings = QueryForObjs(GetObjQuery<Unpricing>(ctx), o => o.QuotaId == quotaId).ToList();
                foreach (var pricing in pricings)
                {
                    pricing.IsDeleted = true;
                    Update(GetObjSet<Pricing>(ctx), pricing);
                }
                foreach (var unPricing in unPricings)
                {
                    unPricing.IsDeleted = true;
                    Update(GetObjSet<Unpricing>(ctx), unPricing);
                }
                Contract contract = QueryForObj(GetObjQuery<Contract>(ctx), o => o.Id == quota.ContractId);
                List<PSQuotaRel> rels = new List<PSQuotaRel>();
                if (contract.ContractType == (int)ContractType.Purchase)
                {
                    //采购
                    rels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.PQuotaId == quota.Id).ToList();
                }
                else
                {
                    //销售
                    rels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.SQuotaId == quota.Id).ToList();
                }
                foreach (var rel in rels)
                {
                    rel.IsDeleted = true;
                    Update(GetObjSet<PSQuotaRel>(ctx), rel);
                }
                contract.IsDeleted = true;
                quota.IsDeleted = true;
                Update(GetObjSet<Quota>(ctx), quota);
                Update(GetObjSet<Contract>(ctx), contract);
                ctx.SaveChanges();
            }
        }

        private void ResetRelQuotaStr(int userId, int quotaId)
        {
            PSQuotaRelService psQuotaRelService = new PSQuotaRelService();
            psQuotaRelService.SetRelStrByPurchaseQuotaId(userId, quotaId);
        }

        public bool RelQuotaCanBeDelete(int userId, int stage, int contractId)
        {
            bool flag = true;
            using (var ctx = new SenLan2Entities(userId))
            {
                if (contractId != 0)
                {
                    List<Quota> quotas = GetQuotaListByStageAndContractId(userId, stage, contractId);
                    foreach (var q in quotas)
                    {
                        CheckDocument(ctx, q);
                        //flag = CanBeDelete(ctx, q);
                        //if (!flag)
                        //{
                        //    break;
                        //}
                    }
                }
            }
            return flag;
        }
        #endregion

        #region 外贸合同的复制用的方法

        private List<Quota> GetAddedQuota(int userId, List<Quota> addedQuotas, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = new List<Quota>();
                if (addedQuotas != null && addedQuotas.Count > 0)
                {
                    Quota oldQuota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault();
                    bool isAutoGenerated = oldQuota.IsAutoGenerated;
                    foreach (var q in addedQuotas)
                    {
                        Quota quota = new Quota();
                        if (quota != null)
                        {
                            //quota.ApprovalId = q.ApprovalId;
                            //quota.ApprovalStageIndex = q.ApprovalStageIndex;
                            //quota.ApproveStatus = q.ApproveStatus;
                            quota.BrandId = q.BrandId;
                            quota.CommodityId = q.CommodityId;
                            quota.CommodityTypeId = q.CommodityTypeId;
                            quota.ContractId = contractId;
                            quota.DeliveryDate = q.DeliveryDate;
                            quota.DeliveryStatus = q.DeliveryStatus;
                            quota.ExQuotaNo = q.ExQuotaNo;
                            quota.FinanceStatus = q.FinanceStatus;
                            quota.ImplementedDate = q.ImplementedDate;
                            quota.Premium = q.Premium;
                            //quota.Price = q.Price;
                            if (q.Price == 0 && q.PricingType == (int)PricingType.Fixed)
                            {
                                Pricing p = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == q.Id).FirstOrDefault();
                                //Pricing p = q.Pricings.FirstOrDefault(o => o.IsDeleted == false);
                                quota.Price = p.FinalPrice ?? 0;
                                quota.SettlementRate = p.ExchangeRate;
                            }
                            else
                            {
                                quota.Price = q.Price;
                                quota.SettlementRate = q.SettlementRate;
                            }
                            quota.PricingBasis = q.PricingBasis;
                            quota.PricingCurrencyId = q.PricingCurrencyId;
                            quota.PricingEndDate = q.PricingEndDate;
                            if (q.PricingSide != 0)
                            {
                                //自动生成的点价方需要相反
                                if (q.PricingSide == (int)PricingSide.OurSide)
                                {
                                    quota.PricingSide = (int)PricingSide.TheirSide;
                                }
                                else
                                {
                                    quota.PricingSide = (int)PricingSide.OurSide;
                                }
                            }
                            quota.PricingStartDate = q.PricingStartDate;
                            quota.PricingType = q.PricingType;
                            quota.Quantity = q.Quantity;
                            quota.SettlementRate = q.SettlementRate;
                            quota.ShipTerm = q.ShipTerm;
                            quota.SpecificationId = q.SpecificationId;
                            quota.VerifiedQuantity = q.VerifiedQuantity;
                            quota.WarehouseId = q.WarehouseId;
                            quota.RelQuotaId = q.Id;
                            if (q.QuotaCurrentPrice != null)
                            {
                                quota.QuotaCurrentPrice = q.QuotaCurrentPrice;
                            }
                            quota.IsAutoGenerated = isAutoGenerated;
                            quota.PaymentMeanId = q.PaymentMeanId;
                            //quota.QuotaNo = q.QuotaNo;
                            quota.QuotaNo = q.AutoQuotaNo;
                            quotas.Add(quota);
                        }
                    }
                }
                return quotas;
            }
        }

        private List<Quota> GetUpdateQuota(int userId, List<Quota> updateQuotas, int contractId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = new List<Quota>();
                if (updateQuotas != null && updateQuotas.Count > 0)
                {
                    Quota oldQuota = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ContractId == contractId).FirstOrDefault();
                    bool isAutoGenerated = oldQuota.IsAutoGenerated;
                    foreach (var q in updateQuotas)
                    {
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == q.Id);
                        if (quota != null)
                        {
                            //quota.ApprovalId = q.ApprovalId;
                            //quota.ApprovalStageIndex = q.ApprovalStageIndex;
                            //quota.ApproveStatus = q.ApproveStatus;
                            quota.BrandId = q.BrandId;
                            quota.CommodityId = q.CommodityId;
                            quota.CommodityTypeId = q.CommodityTypeId;
                            quota.ContractId = contractId;
                            quota.DeliveryDate = q.DeliveryDate;
                            quota.DeliveryStatus = q.DeliveryStatus;
                            quota.ExQuotaNo = q.ExQuotaNo;
                            quota.FinanceStatus = q.FinanceStatus;
                            quota.ImplementedDate = q.ImplementedDate;
                            quota.Premium = q.Premium;
                            //quota.Price = q.Price;
                            if (q.Price == 0 && q.PricingType == (int)PricingType.Fixed)
                            {
                                Pricing p = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.QuotaId == q.Id).FirstOrDefault();
                                //Pricing p = q.Pricings.FirstOrDefault(o => o.IsDeleted == false);
                                quota.Price = p.FinalPrice ?? 0;
                                quota.SettlementRate = p.ExchangeRate;
                            }
                            else
                            {
                                quota.Price = q.Price;
                                quota.SettlementRate = q.SettlementRate;
                            }
                            quota.PricingBasis = q.PricingBasis;
                            quota.PricingCurrencyId = q.PricingCurrencyId;
                            quota.PricingEndDate = q.PricingEndDate;
                            if (q.PricingSide != 0)
                            {
                                //自动生成的点价方需要相反
                                if (q.PricingSide == (int)PricingSide.OurSide)
                                {
                                    quota.PricingSide = (int)PricingSide.TheirSide;
                                }
                                else
                                {
                                    quota.PricingSide = (int)PricingSide.OurSide;
                                }
                            }
                            quota.PricingStartDate = q.PricingStartDate;
                            quota.PricingType = q.PricingType;
                            quota.Quantity = q.Quantity;
                            quota.SettlementRate = q.SettlementRate;
                            quota.ShipTerm = q.ShipTerm;
                            quota.SpecificationId = q.SpecificationId;
                            quota.VerifiedQuantity = q.VerifiedQuantity;
                            quota.WarehouseId = q.WarehouseId;
                            if (q.QuotaCurrentPrice != null)
                            {
                                quota.QuotaCurrentPrice = q.QuotaCurrentPrice;
                            }
                            quota.IsAutoGenerated = isAutoGenerated;
                            quota.PaymentMeanId = q.PaymentMeanId;
                            //quota.QuotaNo = q.QuotaNo;
                            quota.QuotaNo = q.AutoQuotaNo;
                            quotas.Add(quota);
                        }
                    }
                }
                return quotas;
            }
        }

        private List<Quota> GetDeleteQuota(int userId, List<Quota> deleteQuotas)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> quotas = new List<Quota>();
                if (deleteQuotas != null && deleteQuotas.Count > 0)
                {
                    foreach (var q in deleteQuotas)
                    {
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == q.Id);
                        quotas.Add(quota);
                    }
                }
                return quotas;
            }
        }

        #endregion
    }
}
