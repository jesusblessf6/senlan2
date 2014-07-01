using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Data;
using System.Data.Objects;
using System.Transactions;
using DBEntity.EnumEntity;
using DBEntity.EnableProperty;
using System;
using System.Globalization;

namespace Services.Physical.Payments
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PaymentRequestService”。
    public class PaymentRequestService : BaseService<PaymentRequest>, IPaymentRequestService
    {
        #region Remove PaymentRequest and update DeliveryLine
        /// <summary>
        /// 删除功能 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    //查找关联单据
                    PaymentRequest pr = GetPaymentRequest(id, userId);
                    //删除PaymentRequest
                    RemovePaymentRequest(pr, userId);
                    //查找对应的提单行
                    ICollection<Delivery> deliverys = pr.Deliveries;
                    //更新提单行的PaymentRequestId关联字段为null
                    UpdateOldDelivery(deliverys, userId);
                    //更新批次的付款申请状态
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        if (pr.QuotaId.HasValue)
                        {
                            Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), q => q.Id == pr.QuotaId);

                            if (quota.RelQuotaId.HasValue)
                            {
                                Quota firstQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                                List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == firstQuota.Id).ToList();
                                if (relQuotas.Count > 0)
                                {
                                    foreach (var relQuota in relQuotas)
                                    {
                                        relQuota.IsPaymentRequestFinished = false;
                                        Update(GetObjSet<Quota>(ctx), relQuota);
                                    }
                                }
                                firstQuota.IsPaymentRequestFinished = false;
                            }
                            else
                            {
                                List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == quota.Id).ToList();
                                if (relQuotas.Count > 0)
                                {
                                    foreach (var relQuota in relQuotas)
                                    {
                                        relQuota.IsPaymentRequestFinished = false;
                                        Update(GetObjSet<Quota>(ctx), relQuota);
                                    }
                                }
                            }
                            quota.IsPaymentRequestFinished = false;
                            Update(GetObjSet<Quota>(ctx), quota);
                            ctx.SaveChanges();
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

        private PaymentRequest GetPaymentRequest(int id, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //查找关联单据
                PaymentRequest pr = QueryForObj(GetObjQuery<PaymentRequest>(ctx).Include("Deliveries"), p => p.Id == id);
                return pr;
            }
        }

        private void RemovePaymentRequest(PaymentRequest pr, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //查找对应的提单行
                //1. 查找现金收付
                if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.PaymentRequestId == pr.Id).Count > 0)
                {
                    throw new FaultException(ErrCode.PaymentRequestFundFlowConnected.ToString());
                }
                //2. 查找信用证
                if (QueryForObjs(GetObjQuery<LetterOfCredit>(ctx), lc => lc.PaymentRequestId == pr.Id).Count > 0)
                {
                    throw new FaultException(ErrCode.PaymentRequestLCConnected.ToString());
                }
                var tmp = QueryForObj(GetObjQuery<PaymentRequest>(ctx), o => o.Id == pr.Id);
                tmp.IsDeleted = true;
                Update(GetObjSet<PaymentRequest>(ctx), tmp);
                ctx.SaveChanges();
            }
        }

        #endregion

        #region Create PaymentRequest and DeliveryLine
        public void CreatePaymentRequestDeliveryLine(PaymentRequest paymentrequest, int userId, List<Delivery> deliveries, bool IsPaymentRequestFinished)
        {
            using (var ts = new TransactionScope())
            {
                try
                {

                    CreatePaymentRequest(paymentrequest, userId);
                    UpdateNewDelivery(deliveries, paymentrequest.Id, userId);
                    if (paymentrequest.QuotaId.HasValue)
                    {
                        UpdateQuotaIsPaymentRequestFinished(userId, paymentrequest.QuotaId.Value, IsPaymentRequestFinished);
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

        private void CreatePaymentRequest(PaymentRequest paymentrequest, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "PaymentRequest");
                    paymentrequest.DocumentId = doc.Id;
                    paymentrequest.PaymentRequestNo = GetPaymentRequestNo(ctx,paymentrequest.RequestDate);
                    Create(GetObjSet<PaymentRequest>(ctx), paymentrequest);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }

        }

        private string GetPaymentRequestNo(SenLan2Entities ctx,DateTime? requestDate)
        {
            string requestNo = string.Empty;
            if(requestDate.HasValue)
            {
                List<PaymentRequest> list = QueryForObjs(GetObjQuery<PaymentRequest>(ctx), o => o.RequestDate == requestDate).ToList();
                int no = list.Count + 1;
                string maxResult = no.ToString(CultureInfo.InvariantCulture);
                string dateFormat = requestDate.Value.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                for (int i = 1; i <= (3 - no.ToString(CultureInfo.InvariantCulture).Length); i++)
                {
                    maxResult = ("0" + maxResult);
                }
                requestNo = dateFormat + maxResult;
            }
            return requestNo;
        }

        private void UpdateQuotaIsPaymentRequestFinished(int userId, int quotaId, bool IsPaymentRequestFinished)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string>() { "Contract" }), o => o.Id == quotaId);
                //if (quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                //{
                if (quota.RelQuotaId.HasValue)
                {
                    Quota firstQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                    List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == firstQuota.Id).ToList();
                    if (relQuotas.Count > 0)
                    {
                        foreach (var relQuota in relQuotas)
                        {
                            relQuota.IsPaymentRequestFinished = IsPaymentRequestFinished;
                            //relQuota.IsFundflowFinished = IsPaymentRequestFinished;
                            Update(GetObjSet<Quota>(ctx), relQuota);
                        }
                    }
                    firstQuota.IsPaymentRequestFinished = IsPaymentRequestFinished;
                    //firstQuota.IsFundflowFinished = IsPaymentRequestFinished;
                }
                else
                {
                    List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == quota.Id).ToList();
                    if (relQuotas.Count > 0)
                    {
                        foreach (var relQuota in relQuotas)
                        {
                            relQuota.IsPaymentRequestFinished = IsPaymentRequestFinished;
                            //relQuota.IsFundflowFinished = IsPaymentRequestFinished;
                            Update(GetObjSet<Quota>(ctx), relQuota);
                        }
                    }
                }
                quota.IsPaymentRequestFinished = IsPaymentRequestFinished;
                //quota.IsFundflowFinished = IsPaymentRequestFinished;//付款申请状态改变 收付款状态跟着改变
                Update(GetObjSet<Quota>(ctx), quota);
                ctx.SaveChanges();
                //}
            }
        }

        #endregion

        #region update PaymentRequest
        public void UpdateExistedPaymentRequest(PaymentRequest paymentrequest, int userId)
        {
            try
            {
                UpdatePaymentRequest(paymentrequest, userId);
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
        #endregion

        #region update PaymentRequest and DeliveryLine
        public void UpdatePaymentRequestDeliveryLine(PaymentRequest paymentrequest, int userId, List<Delivery> newDeliveries, List<Delivery> oldDeliveries, bool IsPaymentRequestFinished)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateOldOrderLineStatus(paymentrequest, userId);//更换批次 把oldQuota的 IsPaymentRequestFinished字段置为false
                    UpdatePaymentRequest(paymentrequest, userId);
                    UpdateOldDelivery(oldDeliveries, userId);
                    UpdateNewDelivery(newDeliveries, paymentrequest.Id, userId);
                    if (paymentrequest.QuotaId.HasValue)
                    {
                        UpdateQuotaIsPaymentRequestFinished(userId, paymentrequest.QuotaId.Value, IsPaymentRequestFinished);
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

        private void UpdateOldOrderLineStatus(PaymentRequest paymentrequest, int userId)
        {
            try{
                using (var ctx = new SenLan2Entities(userId))
                {
                    PaymentRequest oldPayment = QueryForObj(GetObjQuery<PaymentRequest>(ctx), c => c.Id == paymentrequest.Id);
                    if (oldPayment.QuotaId.HasValue)
                    {
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == oldPayment.QuotaId);
                        if (paymentrequest.QuotaId != quota.Id)//付款申请更换了批次
                        {
                            if (quota.RelQuotaId.HasValue)
                            {
                                Quota firstQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                                List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == firstQuota.Id).ToList();
                                if (relQuotas.Count > 0)
                                {
                                    foreach (var relQuota in relQuotas)
                                    {
                                        relQuota.IsPaymentRequestFinished = false;
                                        Update(GetObjSet<Quota>(ctx), relQuota);
                                    }
                                }
                                firstQuota.IsPaymentRequestFinished = false;
                            }
                            else
                            {
                                List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == quota.Id).ToList();
                                if (relQuotas.Count > 0)
                                {
                                    foreach (var relQuota in relQuotas)
                                    {
                                        relQuota.IsPaymentRequestFinished = false;
                                        Update(GetObjSet<Quota>(ctx), relQuota);
                                    }
                                }
                            }
                            quota.IsPaymentRequestFinished = false;
                            Update(GetObjSet<Quota>(ctx), quota);
                            ctx.SaveChanges();
                        }
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 此方法只用于付款工作台的付款完成操作。只修改IsPaid字段
        /// 用之前的UpdatePaymentRequest方法会将审批状态修改成 审批未开始 状态。
        /// </summary>
        /// <param name="paymentrequest"></param>
        /// <param name="userId"></param>
        public void UpdatePaymentRequestIsPaid(PaymentRequest paymentrequest, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    PaymentRequest pr = ctx.PaymentRequests.FirstOrDefault(c => c.Id == paymentrequest.Id);
                    if (pr != null) pr.IsPaid = paymentrequest.IsPaid;
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 修改付款申请
        /// </summary>
        /// <param name="paymentrequest"></param>
        /// <param name="userId"></param>
        private void UpdatePaymentRequest(PaymentRequest paymentrequest, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Update(GetObjSet<PaymentRequest>(ctx), paymentrequest);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 修改提单行PaymentRequestId外键为null
        /// </summary>
        /// <param name="oldDeliveries"></param>
        /// <param name="userId"></param>
        private void UpdateOldDelivery(IEnumerable<Delivery> oldDeliveries, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (oldDeliveries != null)
                    {
                        ObjectSet<Delivery> os = GetObjSet<Delivery>(ctx);
                        foreach (Delivery v in oldDeliveries)
                        {
                            Delivery v1 = v;
                            var tmp = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == v1.Id);
                            tmp.PaymentRequestId = null;
                            Update(os, tmp);
                        }
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
        /// 给提单行重新赋值外键
        /// </summary>
        /// <param name="newDeliveries"></param>
        /// <param name="paymentrequestId"></param>
        /// <param name="userId"></param>
        private void UpdateNewDelivery(IEnumerable<Delivery> newDeliveries, int paymentrequestId, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (newDeliveries != null)
                    {
                        ObjectSet<Delivery> os = GetObjSet<Delivery>(ctx);
                        foreach (Delivery v in newDeliveries)
                        {
                            Delivery v1 = v;
                            var tmp = QueryForObj(GetObjQuery<Delivery>(ctx), c => c.Id == v1.Id);
                            tmp.PaymentRequestId = paymentrequestId;
                            Update(os, tmp);
                        }
                    }
                    ctx.SaveChanges();

                }

            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取批次的已申请金额的和
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetPaymentRequestAmountSumByQuota(int quotaId, int userId)
        {
            return SelectSum<PaymentRequest>("it.QuotaId == " + quotaId, null, null, py => py.RequestAmount);
        }

        public decimal GetPaymentRequestAmountSumByInvoice(int invoiceId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //CommercialInvoice invoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "PaymentRequests","Deliveries", "Deliveries.DeliveryLines",
                                                                                   //"ProvisionalInvoices","ProvisionalInvoices.Deliveries","ProvisionalInvoices.Deliveries.DeliveryLines", "BaseInvoice", "BaseInvoice.Deliveries","LCCIRels", "LCCIRels.LetterOfCredit" }), o => o.Id == invoiceId);
                CommercialInvoice invoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "PaymentRequests" }), o => o.Id == invoiceId);
                decimal amount = 0M;
                decimal paymentRequestAmount = invoice.PaymentRequestAmount;//发票申请过的金额

                amount = (invoice.Amount ?? 0) - paymentRequestAmount;

                if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
                {
                    decimal invoiceAmount = 0M;
                    List<CommercialInvoice> invoiceList = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "LCCIRels", "LCCIRels.LetterOfCredit" }), o => o.FinalInvoiceId == invoiceId).ToList();
                    foreach (CommercialInvoice pInvoice in invoiceList)
                    {
                        EntityUtil.FilterDeletedEntity(pInvoice.LCCIRels);
                        if (pInvoice.Amount.HasValue)
                        {
                            invoiceAmount += (decimal)pInvoice.Amount;
                        }
                    }
                    amount = amount - invoiceAmount;
                }

                //if (invoice.InvoiceType == (int)CommercialInvoiceType.Provisional || invoice.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                //{
                //    //临时发票、商业发票
                //    amount = (invoice.Amount ?? 0) - paymentRequestAmount;
                //}
                //else if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
                //{
                //    //最终发票
                //    //decimal netWeight = invoice.NetWeights;
                //    //decimal interests = 0M;//信用证利息
                //    decimal money = 0M;
                //    decimal invoiceAmount = 0M;
                //    decimal balance = 0M;


                //    List<CommercialInvoice> invoiceList = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "LCCIRels", "LCCIRels.LetterOfCredit"}), o => o.FinalInvoiceId == invoiceId).ToList();
                //    foreach (CommercialInvoice pInvoice in invoiceList)
                //    {
                //        EntityUtil.FilterDeletedEntity(pInvoice.LCCIRels);
                //        //interests += invoice.TotleInterest;
                //        if (pInvoice.Amount.HasValue)
                //        {
                //            invoiceAmount += (decimal)invoice.Amount;
                //        }
                //    }
                //    money = invoice.Amount ?? 0;
                //    balance = money -invoiceAmount;
                //    amount = balance - paymentRequestAmount;
                //}

                return amount;
            }

        }

        public PaymentRequestEnableProperty SetElementsEnableProperty(int id)
        {
            try
            {
                PaymentRequestEnableProperty prep = new PaymentRequestEnableProperty();
                using(SenLan2Entities ctx = new SenLan2Entities())
                {
                    //付款申请和信用证或者现金关联，不可以编辑以下属性
                    if (QueryForObjs(GetObjQuery<LetterOfCredit>(ctx), lc => lc.PaymentRequestId == id).Count > 0
                        || QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.PaymentRequestId == id).Count > 0)
                    {
                        prep.IsQuotaBtnEnable = false;
                        prep.IsCIBtnEnable = false;
                        prep.IsRequestAmountEnable = false;
                        prep.IsCurrencyEnable = false;
                        prep.IsBPPayEnable = false;
                        prep.IsAccountPayEnable = false;
                        prep.IsBPReceiveEnable = false;
                        prep.IsAccountReceiveEnable = false;
                        prep.IsPaymentUsageEnable = false;
                        prep.IsPaymentMeanEnable = false;
                        prep.IsTransferBankEnable = false;
                    }
                }
                return prep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
        #endregion
    }
}
