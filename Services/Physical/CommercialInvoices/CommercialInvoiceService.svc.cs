using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Services.Helper.QuotaHelper;
using Utility.ErrorManagement;
using System.Transactions;
using Services.Physical.Contracts;
using DBEntity.EnableProperty;
using Services.Helper.DocumentNoGenerator;

namespace Services.Physical.CommercialInvoices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommercialInvoiceService" in code, svc and config file together.
    public class CommercialInvoiceService : BaseService<CommercialInvoice>, ICommercialInvoiceService
    {
        #region ICommercialInvoiceService Members

        /// <summary>
        /// 新增临时发票
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addLCCIRels"></param>
        /// <param name="addDelivery"></param>
        /// <param name="addedAttachments"></param>
        public void CreateCommercialInvoice(int userId, CommercialInvoice header, List<LCCIRel> addLCCIRels,
                                            List<Delivery> addDelivery, List<Attachment> addedAttachments, bool isCIFinished)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        //保存发票
                        header.BankAccount = null;
                        if (header.BankAccountId == 0)
                        {
                            header.BankAccountId = null;
                        }
                        if (header.PaymentMeanId.HasValue && header.PaymentMeanId == 0)
                        {
                            header.PaymentMeanId = null;
                        }
                        if (string.IsNullOrWhiteSpace(header.InvoiceNo))
                        {
                            DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                            if (header.InvoiceType == (int)CommercialInvoiceType.Provisional)
                            {
                                header.InvoiceNo = documentNoHelper.ProvisionalInvoiceNoGenerator(header.QuotaId.Value);
                            }
                            else if (header.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                            {
                                header.InvoiceNo = documentNoHelper.CommercialInvoiceNoGenerator(header.QuotaId.Value);
                                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == header.QuotaId.Value);
                                quota.IsCIFinished = isCIFinished;
                                Update(GetObjSet<Quota>(ctx), quota);
                            }
                        }
                        Create(GetObjSet<CommercialInvoice>(ctx), header);
                        ctx.SaveChanges();
                    }

                    if (addedAttachments != null && addedAttachments.Count > 0)
                    {
                        foreach (Attachment attachment in addedAttachments)
                        {
                            CreateAttachment(header, attachment, userId);
                        }
                    }

                    if (addLCCIRels != null || addDelivery != null)
                    {
                        using (var c = new SenLan2Entities(userId))
                        {
                            if (addLCCIRels != null)
                            {
                                //商业发票信用证关系表
                                foreach (var rel in addLCCIRels)
                                {
                                    rel.LCId = rel.LetterOfCredit.Id;
                                    rel.CIId = header.Id;
                                    rel.LetterOfCredit = null;
                                    rel.Id = 0;
                                    Create(GetObjSet<LCCIRel>(c), rel);
                                }
                            }
                            if (addDelivery != null)
                            {
                                //保存提单的商业发票外键
                                foreach (Delivery delivery in addDelivery)
                                {
                                    int id = delivery.Id;
                                    Delivery oldDelivery = QueryForObj(GetObjQuery<Delivery>(c), o => o.Id == id);
                                    oldDelivery.CommercialInvoiceId = header.Id;
                                    Update(GetObjSet<Delivery>(c), oldDelivery);
                                }
                            }
                            c.SaveChanges();
                        }

                        //修改信用证的财务状态
                        if (addLCCIRels != null && addLCCIRels.Count > 0)
                        {
                            List<int> lcIds = addLCCIRels.Select(o => o.LCId).Distinct().ToList();
                            UpdateLCFinanceStatus(lcIds, userId);
                        }

                    }

                    //更改批次的已收已付金额
                    var quotaService = new QuotaService();
                    quotaService.SetPaidAndReceivedAmount(header.QuotaId, userId);
                    //更改批次的应收应付金额
                    quotaService.SetEqualityByQuotaId(header.QuotaId, userId);

                    //Generate the commercial invoice 
                    header.InvoiceNo = string.Empty;
                    var generatedinv = GenerateCorrespondingInvoice(header, userId, addLCCIRels, addDelivery);
                    if (generatedinv != null)
                    {
                        quotaService.SetPaidAndReceivedAmount(generatedinv.QuotaId, userId);
                        quotaService.SetEqualityByQuotaId(generatedinv.QuotaId, userId);
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

        private CommercialInvoice GenerateCorrespondingInvoice(CommercialInvoice header, int userId, List<LCCIRel> addLCCIRels, List<Delivery> addDelivery)
        {
            switch (header.InvoiceType)
            {
                case (int)CommercialInvoiceType.FinalCommercial:
                    //return FinalInvoiceCreate(header, userId);
                    return SimplyGenerateInvoice(header, userId, addLCCIRels, addDelivery);

                case (int)CommercialInvoiceType.Provisional:
                    return SimplyGenerateInvoice(header, userId, addLCCIRels, addDelivery);

                case (int)CommercialInvoiceType.Final:
                    return GenerateFinalInv(header, userId, addLCCIRels, addDelivery);

                default:
                    return null;
            }
        }

        private CommercialInvoice GenerateFinalInv(CommercialInvoice header, int userId, List<LCCIRel> addLCCIRels, List<Delivery> addDelivery)
        {
            //var generatedHeader = SimplyGenerateInvoice(header, userId, addLCCIRels, addDelivery);
            var generatedHeader = FinalInvoiceCreate(header, userId);

            if (generatedHeader != null)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var invoices = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx, new Collection<string> { "GeneratedInvoices" }),
                                 o => o.FinalInvoiceId == header.Id).SelectMany(o => o.GeneratedInvoices);
                    foreach (var inv in invoices)
                    {
                        inv.FinalInvoiceId = generatedHeader.Id;
                    }
                    ctx.SaveChanges();
                }
            }

            return generatedHeader;
        }


        private CommercialInvoice FinalInvoiceCreate(CommercialInvoice header, int userId)
        {
            CommercialInvoice result = null;
            if (header.QuotaId != null && header.QuotaId > 0)
            {
                int generatedQuotaId = QuotaHelper.GetAutoGeneratedQuotaId(header.QuotaId.Value);

                if (generatedQuotaId > 0)
                {
                    var inv = new CommercialInvoice
                                  {
                                      QuotaId = generatedQuotaId,
                                      //InvoiceNo = header.InvoiceNo,
                                      InvoicedDate = header.InvoicedDate,
                                      DeliveryTerm = header.DeliveryTerm,
                                      PaymentMeanId = header.PaymentMeanId,
                                      Amount = header.Amount,
                                      Price = header.Price,
                                      Comment = header.Comment,
                                      InvoiceType = header.InvoiceType,
                                      ExchangeRate = header.ExchangeRate,
                                      CurrencyId = header.CurrencyId,
                                      BankAccountId = header.BankAccountId,
                                      Ratio = header.Ratio,
                                      BaseCommercialInvoiceId = header.Id
                                  };
                    DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                    if (inv.InvoiceType == (int)CommercialInvoiceType.Provisional)
                    {
                        inv.InvoiceNo = documentNoHelper.ProvisionalInvoiceNoGenerator(inv.QuotaId.Value);
                    }
                    else if (header.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        inv.InvoiceNo = documentNoHelper.CommercialInvoiceNoGenerator(inv.QuotaId.Value);
                    }
                    else if (header.InvoiceType == (int)CommercialInvoiceType.Final)
                    {
                        inv.InvoiceNo = documentNoHelper.FinalInvoiceNoGenerator(inv.QuotaId.Value);
                    }
                    result = CreateNew(inv, userId);
                }
            }
            return result;
        }

        private CommercialInvoice SimplyGenerateInvoice(CommercialInvoice header, int userId, List<LCCIRel> addLCCIRels, List<Delivery> addDelivery)
        {
            CommercialInvoice result = null;
            if (header.QuotaId != null && header.QuotaId > 0)
            {
                int generatedQuotaId = QuotaHelper.GetAutoGeneratedQuotaId(header.QuotaId.Value);

                if (generatedQuotaId > 0)
                {
                    var inv = new CommercialInvoice
                                    {
                                        QuotaId = generatedQuotaId,
                                        //InvoiceNo = header.InvoiceNo,
                                        InvoicedDate = header.InvoicedDate,
                                        DeliveryTerm = header.DeliveryTerm,
                                        PaymentMeanId = header.PaymentMeanId,
                                        Amount = header.Amount,
                                        Price = header.Price,
                                        Comment = header.Comment,
                                        InvoiceType = header.InvoiceType,
                                        ExchangeRate = header.ExchangeRate,
                                        CurrencyId = header.CurrencyId,
                                        BankAccountId = header.BankAccountId,
                                        Ratio = header.Ratio,
                                        BaseCommercialInvoiceId = header.Id
                                    };
                    DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                    if (inv.InvoiceType == (int)CommercialInvoiceType.Provisional)
                    {
                        inv.InvoiceNo = documentNoHelper.ProvisionalInvoiceNoGenerator(inv.QuotaId.Value);
                    }
                    else if (header.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        inv.InvoiceNo = documentNoHelper.CommercialInvoiceNoGenerator(inv.QuotaId.Value);
                    }
                    else if (header.InvoiceType == (int)CommercialInvoiceType.Final)
                    {
                        inv.InvoiceNo = documentNoHelper.FinalInvoiceNoGenerator(inv.QuotaId.Value);
                    }

                    result = CreateNew(inv, userId);

                    if (addLCCIRels != null || addDelivery != null)
                    {
                        using (var c = new SenLan2Entities(userId))
                        {
                            //List<Delivery> autoDeliveryList = QueryForObjs<Delivery>(GetObjQuery<Delivery>(c, null), o => o.QuotaId == generatedQuotaId).ToList();
                            if (addLCCIRels != null)
                            {
                                //商业发票信用证关系表
                                foreach (var rel in addLCCIRels)
                                {
                                    var autoLC = QueryForObj(GetObjQuery<LetterOfCredit>(c), o => o.RelLCId == rel.LCId);
                                    rel.LCId = autoLC.Id;
                                    rel.CIId = inv.Id;
                                    rel.LetterOfCredit = null;
                                    rel.Id = 0;
                                    Create(GetObjSet<LCCIRel>(c), rel);
                                }
                            }
                            c.SaveChanges();
                        }

                        using (var ctx = new SenLan2Entities(userId))
                        {
                            //修改信用证的财务状态
                            if (addLCCIRels != null && addLCCIRels.Count > 0)
                            {
                                var autoIDs = new List<int>();
                                foreach (var rel in addLCCIRels)
                                {
                                    LetterOfCredit auto = QueryForObj(GetObjQuery<LetterOfCredit>(ctx), o => o.Id == rel.LCId);
                                    autoIDs.Add(auto.Id);
                                }
                                UpdateLCFinanceStatus(autoIDs, userId);
                            }
                        }

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 修改临时发票
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addRels"></param>
        /// <param name="deleteRels"></param>
        /// <param name="addDelivery"></param>
        /// <param name="deleteDelivery"></param>
        /// <param name="addedAttachments"></param>
        /// <param name="deletedAttachments"></param>
        /// <param name="changeQuota"></param>
        public void UpdateCommercialInvoice(int userId, CommercialInvoice header, List<LCCIRel> addRels,
                                            List<LCCIRel> deleteRels,
                                            List<Delivery> addDelivery, List<Delivery> deleteDelivery, List<Attachment> addedAttachments,
                                            List<Attachment> deletedAttachments, bool changeQuota, bool isCIFinished)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    header.BankAccount = null;
                    if (header.BankAccountId == 0)
                    {
                        header.BankAccountId = null;
                    }
                    if (header.PaymentMeanId.HasValue && header.PaymentMeanId == 0)
                    {
                        header.PaymentMeanId = null;
                    }
                    if (string.IsNullOrWhiteSpace(header.InvoiceNo))
                    {
                        DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                        if (header.InvoiceType == (int)CommercialInvoiceType.Provisional)
                        {
                            header.InvoiceNo = documentNoHelper.ProvisionalInvoiceNoGenerator(header.QuotaId.Value);
                        }
                        else if (header.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                        {
                            header.InvoiceNo = documentNoHelper.CommercialInvoiceNoGenerator(header.QuotaId.Value);
                        }
                    }
                    int oldQuotaId = 0;

                    var quotaService = new QuotaService();

                    using (var ctx = new SenLan2Entities(userId))
                    {
                        if (changeQuota)
                        {
                            //更换批次,需把原始批次的提单和信用证外键清掉
                            var oldDeliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.CommercialInvoiceId == header.Id);
                            DeleteDeliveryComerId(ctx, oldDeliveries);

                            //清除信用证商业发票关系
                            var oldRels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == header.Id).ToList();
                            DeleteLCCIRel(ctx, oldRels);
                        }

                        CommercialInvoice oldCommer = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new Collection<string> { "GeneratedInvoices" }),
                                                                  o => o.Id == header.Id);
                        if (oldCommer.QuotaId.HasValue)
                            oldQuotaId = oldCommer.QuotaId.Value;
                        oldCommer.QuotaId = header.QuotaId;
                        oldCommer.InvoiceNo = header.InvoiceNo;
                        oldCommer.InvoicedDate = header.InvoicedDate;
                        oldCommer.DeliveryTerm = header.DeliveryTerm;
                        oldCommer.PaymentMeanId = header.PaymentMeanId;
                        oldCommer.Amount = header.Amount;
                        oldCommer.Price = header.Price;
                        oldCommer.Comment = header.Comment;
                        oldCommer.InvoiceType = header.InvoiceType;
                        oldCommer.CurrencyId = header.CurrencyId;
                        oldCommer.ExchangeRate = header.ExchangeRate;
                        oldCommer.BankAccountId = header.BankAccountId;
                        oldCommer.Ratio = header.Ratio;
                        oldCommer.ClearBalanceCurrencyId = header.ClearBalanceCurrencyId;
                        oldCommer.ClearBalanceRate = header.ClearBalanceRate;
                        DeleteDeliveryComerId(ctx, deleteDelivery);
                        UpdateDeliveryComerId(ctx, header.Id, addDelivery);

                        if (addRels != null)
                        {
                            //商业发票信用证关系表
                            foreach (var rel in addRels)
                            {
                                rel.LCId = rel.LetterOfCredit.Id;
                                rel.CIId = header.Id;
                                rel.LetterOfCredit = null;
                                rel.Id = 0;
                                Create(GetObjSet<LCCIRel>(ctx), rel);
                            }
                        }

                        DeleteLCCIRel(ctx, deleteRels);

                        //Update generated invoices
                        if (oldCommer.GeneratedInvoices != null && oldCommer.GeneratedInvoices.Count > 0)
                        {
                            var generatedInv = UpdateCorrespondingInvoice(oldCommer, ctx, userId);
                            //if (generatedInv != null)
                            //{
                            //    quotaService.SetPaidAndReceivedAmount(generatedInv.QuotaId, userId);
                            //    quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);
                            //}
                        }
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == header.QuotaId.Value);
                        quota.IsCIFinished = isCIFinished;
                        Update(GetObjSet<Quota>(ctx), quota);
                        if(oldQuotaId != 0 && oldQuotaId != header.QuotaId.Value)
                        {
                            Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == oldQuotaId);
                            oldQuota.IsCIFinished = false;
                            Update(GetObjSet<Quota>(ctx), oldQuota);
                        }
                        ctx.SaveChanges();
                    }

                    //修改信用证的财务状态
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        List<LCCIRel> rels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == header.Id).ToList();
                        List<int> lcIds = rels.Select(o => o.LCId).Distinct().ToList();
                        UpdateLCFinanceStatus(lcIds, userId);
                    }
                    if (addedAttachments != null)
                    {
                        foreach (Attachment attachment in addedAttachments)
                        {
                            CreateAttachment(header, attachment, userId);
                        }
                    }
                    if (deletedAttachments != null)
                    {
                        foreach (Attachment attachment in deletedAttachments)
                        {
                            DeleteAttachment(attachment, userId);
                        }
                    }
                    //修改批次的已收已付金额
                    quotaService.SetPaidAndReceivedAmount(header.QuotaId.Value, userId);
                    //更改批次的应收应付金额
                    quotaService.SetEqualityByQuotaId(header.QuotaId, userId);
                    if (oldQuotaId != 0)
                    {
                        //修改以前的批次的已收已付金额
                        if (header.QuotaId.HasValue)
                        {
                            if (oldQuotaId != header.QuotaId.Value)
                            {
                                quotaService.SetPaidAndReceivedAmount(oldQuotaId, userId);
                                //更改批次的应收应付金额
                                quotaService.SetEqualityByQuotaId(oldQuotaId, userId);
                            }
                        }
                        else
                        {
                            quotaService.SetPaidAndReceivedAmount(oldQuotaId, userId);
                            //更改批次的应收应付金额
                            quotaService.SetEqualityByQuotaId(oldQuotaId, userId);
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

        private CommercialInvoice UpdateCorrespondingInvoice(CommercialInvoice oldInv, SenLan2Entities ctx, int userId)
        {
            var generatedInv = oldInv.GeneratedInvoices.FirstOrDefault();
            int? oldAutoQuotaId = generatedInv.QuotaId;
            if (generatedInv != null)
            {
                if (oldInv.QuotaId != null)
                {
                    int generatedQuotaId = QuotaHelper.GetAutoGeneratedQuotaId(oldInv.QuotaId.Value);
                    if (generatedQuotaId > 0)
                    {
                        generatedInv.QuotaId = generatedQuotaId;
                    }
                }

                DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                if (generatedInv.InvoiceType == (int)CommercialInvoiceType.Provisional)
                {
                    generatedInv.InvoiceNo = documentNoHelper.ProvisionalInvoiceNoGenerator(generatedInv.QuotaId.Value);
                }
                else if (generatedInv.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                {
                    generatedInv.InvoiceNo = documentNoHelper.CommercialInvoiceNoGenerator(generatedInv.QuotaId.Value);
                }

                //generatedInv.InvoiceNo = oldInv.InvoiceNo;
                generatedInv.InvoicedDate = oldInv.InvoicedDate;
                generatedInv.DeliveryTerm = oldInv.DeliveryTerm;
                generatedInv.PaymentMeanId = oldInv.PaymentMeanId;
                generatedInv.Amount = oldInv.Amount;
                generatedInv.Price = oldInv.Price;
                generatedInv.Comment = oldInv.Comment;
                generatedInv.InvoiceType = oldInv.InvoiceType;
                generatedInv.CurrencyId = oldInv.CurrencyId;
                generatedInv.ExchangeRate = oldInv.ExchangeRate;
                generatedInv.BankAccountId = oldInv.BankAccountId;
                generatedInv.Ratio = oldInv.Ratio;
                generatedInv.ClearBalanceRate = oldInv.ClearBalanceRate;
                generatedInv.ClearBalanceCurrencyId = oldInv.ClearBalanceCurrencyId;

                ctx.SaveChanges();

                if (generatedInv.InvoiceType == (int)CommercialInvoiceType.Final)
                {
                    //unlink
                    var pinvs = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), o => o.FinalInvoiceId == generatedInv.Id);
                    foreach (var commercialInvoice in pinvs)
                    {
                        commercialInvoice.FinalInvoiceId = null;
                    }
                    ctx.SaveChanges();

                    //re-link
                    pinvs =
                        QueryForObjs(GetObjQuery<CommercialInvoice>(ctx, new Collection<string> { "GeneratedInvoices" }),
                                     o => o.FinalInvoiceId == oldInv.Id).SelectMany(o => o.GeneratedInvoices).ToList();
                    foreach (var commercialInvoice in pinvs)
                    {
                        commercialInvoice.FinalInvoiceId = generatedInv.Id;
                    }
                    ctx.SaveChanges();
                }

                #region 修改自动生存商业发票 对应的自动生成信用证的状态
                List<LCCIRel> autoRelList = QueryForObjs(GetObjQuery<LCCIRel>(ctx), c => c.CIId == generatedInv.Id).ToList();//先找到自动生成的商业发票对应的LCCIRels
                DeleteLCCIRel(ctx, autoRelList);//更改自动生成商业发票对应的自动生成信用证的状态为FALSE 然后删除LCCIRELs
                List<LCCIRel> lcRelList = QueryForObjs(GetObjQuery<LCCIRel>(ctx), c => c.CIId == oldInv.Id).ToList();//找到商业发票主数据对应的LCCIRels

                if (lcRelList.Count > 0)//重新为自动生成的商业发票添加对应关系 并修改信用证的状态
                {
                    List<int> autoLCIDs = new List<int>();
                    //商业发票信用证关系表
                    foreach (var rel in lcRelList)
                    {
                        LetterOfCredit autoLC = QueryForObj(GetObjQuery<LetterOfCredit>(ctx), o => o.RelLCId == rel.LCId);
                        LCCIRel newLCCIRel = new LCCIRel();
                        newLCCIRel.LCId = autoLC.Id;
                        newLCCIRel.CIId = generatedInv.Id;
                        newLCCIRel.LetterOfCredit = null;
                        newLCCIRel.AllocationAmount = rel.AllocationAmount;
                        //rel.Id = 0;
                        Create(GetObjSet<LCCIRel>(ctx), newLCCIRel);
                        autoLCIDs.Add(autoLC.Id);
                    }
                    ctx.SaveChanges();
                    UpdateLCFinanceStatus(autoLCIDs, userId);
                }

                #endregion
                var quotaService = new QuotaService();
                //修改批次的已收已付金额
                quotaService.SetPaidAndReceivedAmount(generatedInv.QuotaId.Value, userId);
                //更改批次的应收应付金额
                quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);
                if (oldAutoQuotaId != 0)
                {
                    //修改以前的批次的已收已付金额
                    if (generatedInv.QuotaId.HasValue)
                    {
                        if (oldAutoQuotaId != generatedInv.QuotaId.Value)
                        {
                            quotaService.SetPaidAndReceivedAmount(oldAutoQuotaId, userId);
                            //更改批次的应收应付金额
                            quotaService.SetEqualityByQuotaId(oldAutoQuotaId, userId);
                        }
                    }
                    else
                    {
                        quotaService.SetPaidAndReceivedAmount(oldAutoQuotaId, userId);
                        //更改批次的应收应付金额
                        quotaService.SetEqualityByQuotaId(oldAutoQuotaId, userId);
                    }
                }
            }

            return generatedInv;
        }

        #endregion

        private decimal LCFinanceStatusParameter = -1;

        private void GetLCFinanceStatusParameter()
        {
            using (var ctx = new SenLan2Entities())
            {
                SystemParameter param = GetAll(GetObjQuery<SystemParameter>(ctx)).FirstOrDefault();
                if (param != null)
                {
                    LCFinanceStatusParameter = param.LCFinanceStatusParameter ?? 0;
                }
            }
        }

        private bool GetLCFinancialStatus(int lcId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (LCFinanceStatusParameter == -1)
                {
                    //获取系统参数
                    GetLCFinanceStatusParameter();
                }
                LetterOfCredit lc = QueryForObj(GetObjQuery<LetterOfCredit>(ctx, new List<string> { "LCCIRels" }), o => o.Id == lcId);

                decimal presentAmount = lc.PresentAmount ?? 0;//交单金额

                List<LCCIRel> list = lc.LCCIRels.Where(o => o.IsDeleted == false).ToList();

                decimal allocationAmount = 0;

                if (list.Count > 0)
                {
                    allocationAmount = (decimal)list.Sum(o => o.AllocationAmount);
                }

                bool flag = false;

                decimal maxPresentAmount = (100 + LCFinanceStatusParameter) * presentAmount / 100;
                decimal minPresentAmount = (100 - LCFinanceStatusParameter) * presentAmount / 100;

                if (allocationAmount <= maxPresentAmount && allocationAmount >= minPresentAmount)
                {
                    //在误差范围内
                    flag = true;
                }

                return flag;
            }
        }

        private void UpdateLCFinanceStatus(List<int> lcIds, int userId)
        {
            if (lcIds.Count > 0)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    foreach (int id in lcIds)
                    {

                        LetterOfCredit lc = QueryForObj(GetObjQuery<LetterOfCredit>(ctx), o => o.Id == id);
                        lc.FinancialStatus = GetLCFinancialStatus(id, userId);
                        Update(GetObjSet<LetterOfCredit>(ctx), lc);

                    }
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 保存提单外键
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="commercialId"> </param>
        /// <param name="deliveries"> </param>
        private void UpdateDeliveryComerId(SenLan2Entities ctx, int commercialId, IEnumerable<Delivery> deliveries)
        {
            if (deliveries != null)
            {
                foreach (Delivery delivery in deliveries)
                {
                    int id = delivery.Id;
                    Delivery oldDelivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == id);
                    if (oldDelivery != null)
                    {
                        oldDelivery.CommercialInvoiceId = commercialId;
                        Update(GetObjSet<Delivery>(ctx), oldDelivery);
                    }
                }
            }
        }

        private void DeleteDeliveryComerId(SenLan2Entities ctx, IEnumerable<Delivery> deliveries)
        {
            if (deliveries != null)
            {
                foreach (Delivery delivery in deliveries)
                {
                    int id = delivery.Id;
                    Delivery oldDelivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == id);
                    if (oldDelivery != null)
                    {
                        oldDelivery.CommercialInvoiceId = null;
                        Update(GetObjSet<Delivery>(ctx), oldDelivery);
                    }
                }
            }
        }

        /// <summary>
        /// 清空关系
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="rels"></param>
        private void DeleteLCCIRel(SenLan2Entities ctx, IEnumerable<LCCIRel> rels)
        {
            if (rels != null)
            {
                foreach (LCCIRel rel in rels)
                {
                    LCCIRel oldRel = QueryForObj(GetObjQuery<LCCIRel>(ctx),
                                                                   o => o.Id == rel.Id);
                    if (oldRel != null)
                    {
                        LetterOfCredit lc = QueryForObj(GetObjQuery<LetterOfCredit>(ctx), o => o.Id == oldRel.LCId);
                        lc.FinancialStatus = false;
                        Update(GetObjSet<LetterOfCredit>(ctx), lc);
                        oldRel.IsDeleted = true;
                        Update(GetObjSet<LCCIRel>(ctx), oldRel);
                    }
                }
            }
        }

        #region 最终发票

        /// <summary>
        /// 新增最终发票
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedInvoice"></param>
        /// <param name="addedAttachments"> </param>
        public void CreateFinalCommercialInvoice(int userId, CommercialInvoice header,
                                                 List<CommercialInvoice> addedInvoice, List<Attachment> addedAttachments, bool isCIFinished)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    header.BankAccount = null;
                    if (header.BankAccountId == 0)
                    {
                        header.BankAccountId = null;
                    }
                    if (header.PaymentMeanId.HasValue && header.PaymentMeanId == 0)
                    {
                        header.PaymentMeanId = null;
                    }
                    if (string.IsNullOrWhiteSpace(header.InvoiceNo))
                    {
                        DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                        header.InvoiceNo = documentNoHelper.FinalInvoiceNoGenerator(header.QuotaId.Value);
                    }
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == header.QuotaId.Value);
                        quota.IsCIFinished = isCIFinished;
                        Update(GetObjSet<Quota>(ctx), quota);
                        Create(GetObjSet<CommercialInvoice>(ctx), header);
                        ctx.SaveChanges();
                    }
                    if (addedAttachments != null && addedAttachments.Count > 0)
                    {
                        foreach (Attachment attachment in addedAttachments)
                        {
                            CreateAttachment(header, attachment, userId);
                        }
                    }
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        foreach (CommercialInvoice invoice in addedInvoice)
                        {
                            int id = invoice.Id;
                            CommercialInvoice oldInvoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx), o => o.Id == id);
                            oldInvoice.FinalInvoiceId = header.Id;
                            Update(GetObjSet<CommercialInvoice>(ctx), oldInvoice);
                        }
                        ctx.SaveChanges();
                    }

                    var quotaService = new QuotaService();
                    //更改批次的应收应付金额
                    quotaService.SetEqualityByQuotaId(header.QuotaId, userId);

                    header.InvoiceNo = string.Empty;
                    var generatedInv = GenerateCorrespondingInvoice(header, userId, null, null);
                    if (generatedInv != null)
                    {
                        quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);
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
        /// 修改最终发票
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedInvoice"></param>
        /// <param name="deletedInvoice"></param>
        /// <param name="addedAttachments"> </param>
        /// <param name="deletedAttachments"> </param>
        /// <param name="changeQuota"> </param>
        public void UpdateFinalCommercialInvoice(int userId, CommercialInvoice header,
                                                 List<CommercialInvoice> addedInvoice,
                                                 List<CommercialInvoice> deletedInvoice, List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments, bool changeQuota, bool isCIFinished)
        {
            header.BankAccount = null;
            if (header.BankAccountId == 0)
            {
                header.BankAccountId = null;
            }
            if (header.PaymentMeanId.HasValue && header.PaymentMeanId == 0)
            {
                header.PaymentMeanId = null;
            }
            if (string.IsNullOrWhiteSpace(header.InvoiceNo))
            {
                DocumentNoGenerator documentNoHelper = new CCIGDocumentNoGenerator();
                header.InvoiceNo = documentNoHelper.FinalInvoiceNoGenerator(header.QuotaId.Value);
            }

            using (var ts = new TransactionScope())
            {
                try
                {
                    int oldQuotaId = 0;
                    var quotaService = new QuotaService();
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        if (changeQuota)
                        {
                            //更改批次，需清掉临时发票的外键
                            var oldInvoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new Collection<string> { "GeneratedInvoices" }), o => o.Id == header.Id);
                            oldQuotaId = oldInvoice.QuotaId.Value;
                            var invoices = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), o => o.FinalInvoiceId == header.Id);
                            DeleteInvoice(ctx, invoices);
                            if(oldQuotaId != 0)
                            {
                                Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == oldQuotaId);
                                oldQuota.IsCIFinished = false;
                                Update(GetObjSet<Quota>(ctx), oldQuota);
                            }
                        }

                        var oldcom = UpdateInvoice(ctx, header);
                        UpdateFinalInvoiceId(ctx, header.Id, addedInvoice, deletedInvoice);

                        //Update generated invoices
                        if (oldcom.GeneratedInvoices != null && oldcom.GeneratedInvoices.Count > 0)
                        {
                            var generatedInv = UpdateCorrespondingInvoice(oldcom, ctx, userId);
                            if (generatedInv != null)
                            {
                                quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);
                            }
                        }
                        Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == header.QuotaId);
                        quota.IsCIFinished = isCIFinished;
                        Update(GetObjSet<Quota>(ctx), quota);
                        ctx.SaveChanges();
                    }
                    if (addedAttachments != null)
                    {
                        foreach (Attachment attachment in addedAttachments)
                        {
                            CreateAttachment(header, attachment, userId);
                        }
                    }
                    if (deletedAttachments != null)
                    {
                        foreach (Attachment attachment in deletedAttachments)
                        {
                            DeleteAttachment(attachment, userId);
                        }
                    }
                    //更改批次的应收应付字段

                    quotaService.SetEqualityByQuotaId(header.QuotaId, userId);
                    if (changeQuota)
                    {
                        quotaService.SetEqualityByQuotaId(oldQuotaId, userId);
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

        private void DeleteInvoice(SenLan2Entities ctx, IEnumerable<CommercialInvoice> invoices)
        {
            if (invoices != null)
            {
                foreach (var invoice in invoices)
                {
                    invoice.FinalInvoiceId = null;
                    Update(GetObjSet<CommercialInvoice>(ctx), invoice);
                }
            }
        }

        public void RemoveInvoice(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        var quotaService = new QuotaService();
                        var invoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx), o => o.Id == id);

                        List<LCCIRel> rels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == id).ToList();
                        List<int> lcIds = rels.Select(o => o.LCId).Distinct().ToList();

                        DeleteInvoice(ctx, id);
                        ctx.SaveChanges();

                        var generatedInv = QueryForObjs(
                            GetObjQuery<CommercialInvoice>(ctx), o => o.BaseCommercialInvoiceId == id).FirstOrDefault();
                        if (generatedInv != null)
                        {
                            List<LCCIRel> autoRels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == generatedInv.Id).ToList();
                            List<int> autoLCIds = autoRels.Select(c => c.LCId).Distinct().ToList();
                            DeleteInvoice(ctx, generatedInv.Id);//删除自动生成的商业发票
                            //if (generatedInv != null)
                            //{
                            //    generatedInv.IsDeleted = true;
                            //    quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);
                            //}
                            ctx.SaveChanges();

                            var pinv = QueryForObjs(GetObjQuery<CommercialInvoice>(ctx),
                                                    o => o.FinalInvoiceId == generatedInv.Id);
                            foreach (var commercialInvoice in pinv)
                            {
                                commercialInvoice.FinalInvoiceId = null;
                            }
                            ctx.SaveChanges();

                            //更改自动生成信用证的财务状态
                            UpdateLCFinanceStatus(autoLCIds, userId);

                            //更改批次的应收应付字段
                            quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);

                            //修改批次的已收已付金额
                            quotaService.SetPaidAndReceivedAmount(generatedInv.QuotaId.Value, userId);
                        }
                        //List<LCCIRel> genrels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == generatedInv.Id).ToList();
                        //List<int> genlcIds = genrels.Select(o => o.LCId).Distinct().ToList();

                        //更改信用证的财务状态
                        UpdateLCFinanceStatus(lcIds, userId);
                        //UpdateLCFinanceStatus(genlcIds, userId);


                        //更改批次的应收应付字段
                        quotaService.SetEqualityByQuotaId(invoice.QuotaId, userId);
                        //quotaService.SetEqualityByQuotaId(generatedInv.QuotaId, userId);

                        //修改批次的已收已付金额
                        quotaService.SetPaidAndReceivedAmount(invoice.QuotaId.Value, userId);
                        //quotaService.SetPaidAndReceivedAmount(generatedInv.QuotaId.Value, userId);
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
        /// 修改发票
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="header"></param>
        private CommercialInvoice UpdateInvoice(SenLan2Entities ctx, CommercialInvoice header)
        {
            CommercialInvoice oldCommer = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new Collection<string> { "GeneratedInvoices" }), o => o.Id == header.Id);
            oldCommer.QuotaId = header.QuotaId;
            oldCommer.InvoiceNo = header.InvoiceNo;
            oldCommer.InvoicedDate = header.InvoicedDate;
            oldCommer.DeliveryTerm = header.DeliveryTerm;
            oldCommer.PaymentMeanId = header.PaymentMeanId;
            oldCommer.Amount = header.Amount;
            oldCommer.Price = header.Price;
            oldCommer.Comment = header.Comment;
            oldCommer.InvoiceType = header.InvoiceType;
            oldCommer.CurrencyId = header.CurrencyId;
            oldCommer.ExchangeRate = header.ExchangeRate;
            oldCommer.BankAccountId = header.BankAccountId;
            oldCommer.ClearBalanceCurrencyId = header.ClearBalanceCurrencyId;
            oldCommer.ClearBalanceRate = header.ClearBalanceRate;
            Update(GetObjSet<CommercialInvoice>(ctx), oldCommer);
            return oldCommer;
        }

        /// <summary>
        /// 修改最终发票外键
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="invoiceId"></param>
        /// <param name="addInvoices"></param>
        /// <param name="deleteInvoices"></param>
        private void UpdateFinalInvoiceId(SenLan2Entities ctx, int invoiceId, IEnumerable<CommercialInvoice> addInvoices,
                                          IEnumerable<CommercialInvoice> deleteInvoices)
        {
            if (addInvoices != null)
            {
                foreach (CommercialInvoice invoice in addInvoices)
                {
                    int id = invoice.Id;
                    CommercialInvoice oldInvoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx), o => o.Id == id);
                    oldInvoice.FinalInvoiceId = invoiceId;
                    Update(GetObjSet<CommercialInvoice>(ctx), oldInvoice);
                }
            }
            if (deleteInvoices != null)
            {
                foreach (CommercialInvoice invoice in deleteInvoices)
                {
                    int id = invoice.Id;
                    CommercialInvoice oldInvoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx), o => o.Id == id);
                    oldInvoice.FinalInvoiceId = null;
                    Update(GetObjSet<CommercialInvoice>(ctx), oldInvoice);
                }
            }
        }

        private void DeleteInvoice(SenLan2Entities ctx, int id)
        {
            CommercialInvoice invoice = QueryForObj(GetObjQuery<CommercialInvoice>(ctx, new List<string> { "PaymentRequests" }), o => o.Id == id);
            EntityUtil.FilterDeletedEntity(invoice.PaymentRequests);
            if (invoice.PaymentRequests.Count > 0)
            {
                //有付款申请
                throw new FaultException(ErrCode.InvoiceHasPayMentRequest.ToString());
            }

            //临时发票
            if (invoice.InvoiceType == (int)CommercialInvoiceType.Provisional || invoice.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
            {
                //是否关联最终发票
                if (invoice.FinalInvoiceId.HasValue)
                {
                    throw new FaultException(ErrCode.FinalInvoiceIdExisted.ToString());
                }
                
                List<Delivery> deliveries = QueryForObjs(GetObjQueryWithDeleted<Delivery>(ctx),
                                                                d => d.CommercialInvoiceId == id).ToList();

                List<LCCIRel> rels = QueryForObjs(GetObjQuery<LCCIRel>(ctx), o => o.CIId == id).ToList();

                //清除提单行的发票外键
                foreach (Delivery delivery in deliveries)
                {
                    delivery.CommercialInvoiceId = null;
                    Update(GetObjSet<Delivery>(ctx), delivery);
                }
                //清除信用证商业发票关系
                foreach (var rel in rels)
                {
                    rel.IsDeleted = true;
                    Update(GetObjSet<LCCIRel>(ctx), rel);
                    ctx.SaveChanges();
                }
            }
            else
            {
                List<CommercialInvoice> pInvoices =
                    QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), o => o.FinalInvoiceId == id).ToList();
                foreach (CommercialInvoice pInvoice in pInvoices)
                {
                    pInvoice.FinalInvoiceId = null;
                    Update(GetObjSet<CommercialInvoice>(ctx), pInvoice);
                }
            }
            if (invoice.InvoiceType != (int)CommercialInvoiceType.Provisional)
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == invoice.QuotaId.Value);
                quota.IsCIFinished = false;
                Update(GetObjSet<Quota>(ctx), quota);
            }
            //置删除标志
            invoice.IsDeleted = true;
            Update(GetObjSet<CommercialInvoice>(ctx), invoice);
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="attachment"></param>
        /// <param name="userId"></param>
        private void CreateAttachment(CommercialInvoice invoice, Attachment attachment, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (attachment != null)
                {
                    attachment.Id = 0;
                    attachment.RecordId = invoice.Id;
                    Create(GetObjSet<Attachment>(ctx), attachment);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="attachment"></param>
        /// <param name="userId"></param>
        private void DeleteAttachment(Attachment attachment, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (attachment != null)
                {
                    attachment.IsDeleted = true;
                    Update(GetObjSet<Attachment>(ctx), attachment);
                    ctx.SaveChanges();
                }
            }
        }

        #endregion

        //设置控件的编辑属性
        public PCommercialInvoiceEnableProperty SetElementsEnableProperty(int id)
        {
            var pciep = new PCommercialInvoiceEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //有最终发票的临时发票若干字段不可以修改
                    CommercialInvoice ci = QueryForObj(GetObjQuery<CommercialInvoice>(ctx), q => q.Id == id);
                    if (ci != null)
                    {
                        //是临时发票
                        if (ci.InvoiceType == (int)CommercialInvoiceType.Provisional)
                        {
                            //关联最终发票
                            if (QueryForObjs(GetObjQuery<CommercialInvoice>(ctx), pci => pci.Id == ci.FinalInvoiceId).Count > 0)
                            {
                                pciep.IsAmountEnable = false;
                                pciep.IsDeliveryAddEnable = false;
                                pciep.IsExchangeRateEnable = false;
                                pciep.IsIncludeInterestEnable = false;
                                pciep.IsLCAddEnable = false;
                                pciep.IsPaymentMeansEnable = false;
                                pciep.IsPriceEnable = false;
                                pciep.IsQuotaEnable = false;
                                pciep.IsSettlementCurrencyEnable = false;
                                pciep.IsLCDeleteEnable = false;
                                pciep.IsDeliveryDeleteEnable = false;
                            }

                            //对应的批次已经包含现金收付，则不可以修改结算币种
                            if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.QuotaId == ci.QuotaId).Count > 0)
                            {
                                pciep.IsSettlementCurrencyEnable = false;
                            }
                        }
                    }
                }
                return pciep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Delivery> GetDeliveryByInvoiceId(int userId, int invoiceId)
        {
            List<Delivery> deliveries = new List<Delivery>();
            using (var ctx = new SenLan2Entities(userId))
            {
                deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx, new List<string> { "DeliveryLines","LetterOfCredit", "DeliveryLines.CommodityType", "DeliveryLines.CommodityType.Commodity", "DeliveryLines.Brand" }),
                    o => o.CommercialInvoiceId == invoiceId).ToList();
            }

            return deliveries;
        }
    }
}
