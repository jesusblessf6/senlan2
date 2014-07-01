using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using DBEntity.EnumEntity;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“VATInvoiceService”。
    public class VATInvoiceService : BaseService<VATInvoice>, IVATInvoiceService
    {
        #region 增删改

        public void CreateDocument(int userId, VATInvoice header, List<VATInvoiceLine> addedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateHeader(header, userId);
                    foreach (VATInvoiceLine line in addedLines)
                    {
                        CreateLine(header, line, userId);
                        SetVATStatus(line.VATInvoiceRequestLineId, userId);
                        SetQuotaVATStatusQuantityAmount(line.QuotaId, userId);
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

        public void UpdateDocument(int userId, VATInvoice header, List<VATInvoiceLine> addedLines,
                                   List<VATInvoiceLine> updatedLines, List<VATInvoiceLine> deletedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(header, userId);
                    if (addedLines != null)
                    {
                        foreach (VATInvoiceLine line in addedLines)
                        {
                            CreateLine(header, line, userId);
                            SetVATStatus(line.VATInvoiceRequestLineId, userId);
                            SetQuotaVATStatusQuantityAmount(line.QuotaId, userId);

                        }
                    }
                    if (updatedLines != null)
                    {
                        foreach (VATInvoiceLine line in updatedLines)
                        {
                            UpdateLine(line, userId);
                            SetVATStatus(line.VATInvoiceRequestLineId, userId);
                            SetQuotaVATStatusQuantityAmount(line.QuotaId, userId);
                        }
                    }
                    if (deletedLines != null)
                    {
                        foreach (VATInvoiceLine line in deletedLines)
                        {
                            int? rqId = line.VATInvoiceRequestLineId;
                            DeleteVATLine(line.Id, userId);
                            SetVATStatus(rqId, userId);
                            SetQuotaVATStatusQuantityAmount(line.QuotaId, userId);
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
        /// 作废
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
                        VATInvoiceLine line = QueryForObj(GetObjQuery<VATInvoiceLine>(ctx), c => c.Id == id);
                        int? rqId = line.VATInvoiceRequestLineId;
                        int? quotaId = line.QuotaId;
                        DeleteVATLine(id, userId);
                        SetVATStatus(rqId, userId);
                        SetQuotaVATStatusQuantityAmount(quotaId, userId);
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
        /// 新增增值税申请
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"> </param>
        private void CreateHeader(VATInvoice header, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<VATInvoice>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 新增新增增值税申请行 更新新增增值税申请信息
        /// </summary>
        /// <param name="header"></param>
        /// <param name="inLine"> </param>
        /// <param name="userId"> </param>
        private void CreateLine(VATInvoice header, VATInvoiceLine inLine, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var addLine = new VATInvoiceLine
                                      {
                                          QuotaId = inLine.QuotaId,
                                          VATInvoiceQuantity = inLine.VATInvoiceQuantity,
                                          VATAmount = inLine.VATAmount,
                                          VATPrice = inLine.VATPrice,
                                          VATInvoiceId = inLine.VATInvoiceId,
                                          VATInvoiceRequestLineId = inLine.VATInvoiceRequestLineId,
                                          VATRateId = inLine.VATRateId,
                                      };
                    if (header.Id > 0)
                    {
                        addLine.VATInvoiceId = header.Id;
                    }
                    Create(GetObjSet<VATInvoiceLine>(ctx), addLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"> </param>
        private void UpdateHeader(VATInvoice header, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    VATInvoice oldRequest = QueryForObj(GetObjQuery<VATInvoice>(ctx), c => c.Id == header.Id);
                    oldRequest.BPId = header.BPId;
                    oldRequest.InternalBPId = header.InternalBPId;
                    oldRequest.Comment = header.Comment;
                    oldRequest.InvoicedDate = header.InvoicedDate;
                    oldRequest.VATInvoiceType = header.VATInvoiceType;
                    oldRequest.InvoiceNo = header.InvoiceNo;
                    oldRequest.VATInvoiceRequestId = header.VATInvoiceRequestId;
                    Update(GetObjSet<VATInvoice>(ctx), oldRequest);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新入库行和对应信息
        /// </summary>
        /// <param name="inLine"> </param>
        /// <param name="userId"> </param>
        private void UpdateLine(VATInvoiceLine inLine, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    VATInvoiceLine oldInLine =
                        QueryForObj(
                            GetObjQuery<VATInvoiceLine>(ctx), o => o.Id == inLine.Id);
                    oldInLine.QuotaId = inLine.QuotaId;
                    oldInLine.VATInvoiceQuantity = inLine.VATInvoiceQuantity;
                    oldInLine.VATAmount = inLine.VATAmount;
                    oldInLine.VATPrice = inLine.VATPrice;
                    oldInLine.VATInvoiceId = inLine.VATInvoiceId;
                    oldInLine.VATInvoiceRequestLineId = inLine.VATInvoiceRequestLineId;
                    oldInLine.VATRateId = inLine.VATRateId;
                    Update(GetObjSet<VATInvoiceLine>(ctx), oldInLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 作废
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"> </param>
        private void DeleteVATLine(int id, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    VATInvoiceLine line = QueryForObj(
                        GetObjQuery<VATInvoiceLine>(ctx, new List<string> { "VATInvoice" }), q => q.Id == id);
                    line.IsDeleted = true;
                    //如果是最后一行，主数据也置为删除
                    if (
                       QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx),
                                    q => q.VATInvoiceId == line.VATInvoiceId && q.Id != line.Id).Count == 0)
                    {
                        line.VATInvoice.IsDeleted = true;
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

        #region IVATInvoiceService Members

        /// <summary>
        /// 已开数量(已开增值税发票数量)
        /// </summary>
        /// <param name="quotaId"> </param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public decimal OpenQty(int quotaId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<VATInvoiceLine> rqLines =
                    QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), it => it.QuotaId == quotaId).ToList();
                return rqLines.Sum(rqLine => (rqLine.VATInvoiceQuantity == null ? 0 : Convert.ToDecimal(rqLine.VATInvoiceQuantity)));
            }
        }

        /// <summary>
        /// 维护增票申请状态和已开数量
        /// </summary>
        /// <param name="vatInvoiceRequestLineId"></param>
        /// <param name="userId"></param>
        private void SetVATStatus(int? vatInvoiceRequestLineId, int userId, VATInvoiceLine line = null)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (vatInvoiceRequestLineId > 0)
                {
                    VATInvoiceRequestLine rqLine = QueryForObj(GetObjQuery<VATInvoiceRequestLine>(ctx), o => o.Id == vatInvoiceRequestLineId);
                    //获取增票申请状态 由增票申请行ID
                    if (rqLine != null)
                    {
                        //取得行
                        List<VATInvoiceLine> vatInvoiceLines = QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), o => o.VATInvoiceRequestLineId == (int)vatInvoiceRequestLineId).ToList();
                        int vatStatus = GetVATStatusByInvoiceLines(vatInvoiceLines, rqLine.RequestQuantity);
                        decimal vatInvoicedQuantity = GetVatInvoicedQuantity(vatInvoiceLines);
                        if (line != null)
                        {
                            if (vatStatus == (int)VATStatus.Complete)
                            {
                                //开票申请完成
                                rqLine.VATStatus = vatStatus;
                            }
                            else
                            {
                                if (line.Quota.VATStatus == (int)VATStatus.Complete)
                                {
                                    //维护申请行开票状态
                                    rqLine.VATStatus = line.Quota.VATStatus;
                                }
                                else
                                {
                                    rqLine.VATStatus = vatStatus;
                                }
                            }
                            //维护申请行已开数量
                            rqLine.VATInvoicedQuantity = vatInvoicedQuantity;
                        }
                        else
                        {
                            if (vatStatus > 0)
                            {
                                //维护申请行开票状态
                                rqLine.VATStatus = vatStatus;
                                //维护申请行已开数量
                                rqLine.VATInvoicedQuantity = vatInvoicedQuantity;
                            }
                        }
                        Update(GetObjSet<VATInvoiceRequestLine>(ctx), rqLine);
                        ctx.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// 维护批次开票状态和批次发票数量
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        private void SetQuotaVATStatusQuantityAmount(int? quotaId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (quotaId > 0)
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                    if (quota != null)
                    {
                        //取得行
                        List<VATInvoiceLine> vatInvoiceLines = QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), o => o.QuotaId == (int)quotaId).ToList();

                        decimal vatInvoicedQuantity = GetVatInvoicedQuantity(vatInvoiceLines);

                        var vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.Partial;
                        if (quota.VerifiedQuantity == vatInvoicedQuantity && vatInvoicedQuantity != 0)
                        {
                            vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.Complete;
                        }
                        else if (vatInvoicedQuantity == 0)
                        {
                            vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.NotAtAll;
                        }

                        //维护批次行开票状态
                        quota.VATStatus = vatStatus;
                        //维护批次行发票数量
                        quota.VATInvoicedQuantity = vatInvoicedQuantity;
                        quota.VatInvoicedAmount = GetQuotaVatInvoicedAmount(vatInvoiceLines);
                        Update(GetObjSet<Quota>(ctx), quota);
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public Quota GetQuotaVATStatus(Quota quota, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<VATInvoiceLine> vatInvoiceLines = QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), o => o.QuotaId == quota.Id).ToList();
                decimal vatInvoicedQuantity = GetVatInvoicedQuantity(vatInvoiceLines);
                var vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.Partial;
                if (quota.VerifiedQuantity == vatInvoicedQuantity && vatInvoicedQuantity != 0)
                {
                    vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.Complete;
                }
                else if (vatInvoicedQuantity == 0)
                {
                    vatStatus = (int)DBEntity.EnumEntity.QuotaVATStatus.NotAtAll;
                }
                //维护批次行开票状态
                quota.VATStatus = vatStatus;
                //维护批次行发票数量
                quota.VATInvoicedQuantity = vatInvoicedQuantity;
            }
            return quota;
        }

        /// <summary>
        /// 获取增票申请状态 由增票行List
        /// </summary>
        /// <param name="requestQuantity"></param>
        /// <param name="vatInvoiceLines"></param>
        /// <returns></returns>
        private int GetVATStatusByInvoiceLines(List<VATInvoiceLine> vatInvoiceLines, decimal? requestQuantity)
        {
            if (vatInvoiceLines != null && vatInvoiceLines.Count > 0)
            {
                if (vatInvoiceLines.Sum(t => (t.VATInvoiceQuantity ?? 0)) == (requestQuantity ?? 0))
                {
                    return (int)DBEntity.EnumEntity.VATStatus.Complete;
                }

                return (int)DBEntity.EnumEntity.VATStatus.Partial;
            }
            return (int)DBEntity.EnumEntity.VATStatus.NotAtAll;
        }

        /// <summary>
        /// 获取增票已开数量 由增票行List
        /// </summary>
        /// <param name="vatInvoiceLines"></param>
        /// <returns></returns>
        private decimal GetVatInvoicedQuantity(IEnumerable<VATInvoiceLine> vatInvoiceLines)
        {
            return (decimal)vatInvoiceLines.Sum(t => t.VATInvoiceQuantity);
        }

        private decimal GetQuotaVatInvoicedAmount(IEnumerable<VATInvoiceLine> vatInvoiceLines)
        {

            return (decimal)vatInvoiceLines.Sum(t => t.VATInvoiceQuantity * t.VATPrice);
        }

        #endregion

        #region 批次开票
        public void CreateDocumentByVATInvoiceBatch(int userId, List<VATInvoiceBatchClass> batch)
        {
            if (batch != null && batch.Count > 0)
            {
                using (var ts = new TransactionScope())
                {
                    try
                    {
                        foreach (var b in batch)
                        {
                            VATInvoice vatInvoice = b.VATInvoice;
                            List<VATInvoiceLine> lines = b.VATInvoiceLines;
                            CreateDocument(userId, vatInvoice, lines);
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
        }

        public List<VATInvoiceBatchClass> GetBatchInvoiceByLines(int userId, List<VATInvoiceRequestLine> list)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var invoices = new List<VATInvoiceBatchClass>();

                VATRate vatRate = QueryForObjs(GetObjQuery<VATRate>(ctx), o => o.Type == 2).OrderBy(o => o.Created).FirstOrDefault();

                foreach (var requestLine in list)
                {
                    var batch = new VATInvoiceBatchClass();

                    VATInvoiceRequestLine r = QueryForObj(GetObjQuery<VATInvoiceRequestLine>(ctx, new List<string> { "VATInvoiceRequest" }),
                        o => o.Id == requestLine.Id);
                    if (r != null)
                    {
                        VATInvoiceRequest request = r.VATInvoiceRequest;

                        var vatInvoice = new VATInvoice
                        {
                            BPId = request.BPId,
                            InternalBPId = request.InternalBPId,
                            Comment = request.Comment,
                            InvoicedDate = DateTime.Today,
                            VATInvoiceType = (int)VATInvoiceType.Issue, // 开票
                            IsDeleted = false,
                            IsDraft = false,
                            VATInvoiceRequestId = request.Id
                        };
                        batch.VATInvoice = vatInvoice;
                        var vatInvoiceLines = new List<VATInvoiceLine>();
                        //foreach (VATInvoiceRequestLine item in request.VATInvoiceRequestLines)
                        //{
                        var line = new VATInvoiceLine();
                        int id = GetLineId(vatInvoiceLines);
                        line.Id = -id;
                        line.QuotaId = requestLine.QuotaId;
                        line.VATInvoiceQuantity = requestLine.RequestQuantity - requestLine.VATInvoicedQuantity;
                        line.UnOpenedQuantity = requestLine.RequestQuantity - requestLine.VATInvoicedQuantity;
                        line.VATAmount = requestLine.RequestAmount;
                        line.VATPrice = requestLine.RequestPrice;
                        line.VATInvoiceRequestLineId = requestLine.Id;
                        if (vatRate != null)
                        {
                            line.VATRateId = vatRate.Id;
                            line.VATRate = vatRate;
                        }

                        Quota qt = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == requestLine.QuotaId);
                        if (qt != null)
                        {
                            line.Quota = qt;
                            //line.Quota.VATStatus = qt.VATStatus;
                            decimal qty = (line.VATInvoiceQuantity ?? 0) + (qt.VATInvoicedQuantity ?? 0);
                            if (qt.VerifiedQuantity == qty)
                            {
                                line.Quota.VATStatus = (int)VATStatus.Complete;
                            }
                            else
                            {
                                if (qty > 0)
                                {
                                    line.Quota.VATStatus = (int)VATStatus.Partial;
                                }
                                else
                                {
                                    line.Quota.VATStatus = (int)VATStatus.NotAtAll;
                                }
                            }
                        }
                        vatInvoiceLines.Add(line);
                        //}
                        batch.VATInvoiceLines = vatInvoiceLines;
                        invoices.Add(batch);
                    }
                }

                return invoices;
            }
        }

        /// <summary>
        /// 自动生成新增的行Id
        /// </summary>
        /// <returns></returns>
        private int GetLineId(List<VATInvoiceLine> ShowVATInvoiceLines)
        {
            if (ShowVATInvoiceLines.Count == 0)
                return 1;
            IEnumerable<int> query = from lines in ShowVATInvoiceLines select Math.Abs(lines.Id);
            int id = query.Max();
            return id + 1;
        }
        #endregion
    }
}