using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“VATInvoice”。
    public class VATInvoiceRequestService : BaseService<VATInvoiceRequest>, IVATInvoiceRequestService
    {
        #region IVATInvoiceRequestService Members

        public void UpdateInvoiceRequestAndInvoiceRequestLines(VATInvoiceRequest varRequest, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    VATInvoiceRequest oldRequest = QueryForObj(GetObjQuery<VATInvoiceRequest>(ctx),
                                                               o => o.Id == varRequest.Id);
                    oldRequest.BPId = varRequest.BPId;
                    oldRequest.InternalBPId = varRequest.InternalBPId;
                    oldRequest.Comment = varRequest.Comment;
                    oldRequest.RequestDate = varRequest.RequestDate;
                    SetLines(oldRequest.VATInvoiceRequestLines, varRequest.VATInvoiceRequestLines);
                    Update(GetObjSet<VATInvoiceRequest>(ctx), oldRequest);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        private void SetLines(TrackableCollection<VATInvoiceRequestLine> oldLines,
                              TrackableCollection<VATInvoiceRequestLine> lines)
        {
            //删除
            for (int i = oldLines.Count - 1; i >= 0; i--)
            {
                int id = oldLines[i].Id;
                VATInvoiceRequestLine line = lines.FirstOrDefault(o => o.Id == id);
                if (line == null)
                {
                    oldLines[i].IsDeleted = true;
                }
            }
            //修改
            for (int i = 0; i < oldLines.Count; i++)
            {
                if (oldLines[i].IsDeleted)
                    continue;
                int id = oldLines[i].Id;
                VATInvoiceRequestLine line = lines.Single(o => o.Id == id);
                if (line != null)
                {
                    oldLines[i].Comment = lines[i].Comment;
                    oldLines[i].QuotaId = lines[i].QuotaId;
                    oldLines[i].RequestQuantity = lines[i].RequestQuantity;
                    oldLines[i].RequestAmount = lines[i].RequestAmount;
                    oldLines[i].RequestPrice = lines[i].RequestPrice;
                    oldLines[i].VATInvoiceRequestId = lines[i].VATInvoiceRequestId;
                }
            }

            //新增
            IEnumerable<VATInvoiceRequestLine> query = from line in lines
                                                       where line.Id == 0
                                                       select line;

            List<VATInvoiceRequestLine> newLines = query.ToList();

            var ctx = new SenLan2Entities();
            Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "VATInvoiceRequestLine");

            foreach (VATInvoiceRequestLine newLine in newLines)
            {
                newLine.DocumentId = doc.Id;
                oldLines.Add(newLine);
            }
        }

        #region 增删改

        public void CreateDocument(int userId, VATInvoiceRequest header, List<VATInvoiceRequestLine> addedLines, List<Quota> quotaList)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateHeader(header, userId);
                    foreach (VATInvoiceRequestLine line in addedLines)
                    {
                        CreateLine(header, line, userId, quotaList);
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

        public void UpdateDocument(int userId, VATInvoiceRequest header, List<VATInvoiceRequestLine> addedLines,
                                   List<VATInvoiceRequestLine> updatedLines, List<VATInvoiceRequestLine> deletedLines, List<Quota> quotaList)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(header, userId);
                    if (addedLines != null)
                    {
                        foreach (VATInvoiceRequestLine line in addedLines)
                        {
                            CreateLine(header, line, userId, quotaList);
                        }
                    }
                    if (updatedLines != null)
                    {
                        foreach (VATInvoiceRequestLine line in updatedLines)
                        {
                            UpdateLine(line, userId, quotaList);
                        }
                    }
                    if (deletedLines != null)
                    {
                        foreach (VATInvoiceRequestLine line in deletedLines)
                        {
                            DeleteLine(line.Id, userId);
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
            DeleteVATLine(id, userId);
        }

        /// <summary>
        /// 新增增值税申请
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"> </param>
        private void CreateHeader(VATInvoiceRequest header, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<VATInvoiceRequest>(ctx), header);
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
        private void CreateLine(VATInvoiceRequest header, VATInvoiceRequestLine inLine, int userId, List<Quota> quotaList)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Quota> newQuotaList = quotaList.Where(c => c.Id == inLine.QuotaId).ToList();
                    if(newQuotaList.Count > 0)
                    {
                        Quota newQuota = newQuotaList[0];
                        Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == inLine.QuotaId);
                        oldQuota.IsVatRequestFinished = newQuota.IsVatRequestFinished;
                        Update(GetObjSet<Quota>(ctx), oldQuota);
                    }
                    Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "VATInvoiceRequestLine");

                    var addLine = new VATInvoiceRequestLine
                                      {
                                          Comment = inLine.Comment,
                                          QuotaId = inLine.QuotaId,
                                          RequestQuantity = inLine.RequestQuantity,
                                          RequestAmount = inLine.RequestAmount,
                                          RequestPrice = inLine.RequestPrice,
                                          VATInvoiceRequestId = inLine.VATInvoiceRequestId,
                                          DocumentId = doc.Id,
                                          VATStatus=(int)DBEntity.EnumEntity.VATStatus.NotAtAll,
                                          VATInvoicedQuantity=0
                                      };
                    if (header.Id > 0)
                    {
                        addLine.VATInvoiceRequestId = header.Id;
                    }
                    Create(GetObjSet<VATInvoiceRequestLine>(ctx), addLine);
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
        private void UpdateHeader(VATInvoiceRequest header, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    VATInvoiceRequest oldRequest = QueryForObj(GetObjQuery<VATInvoiceRequest>(ctx),
                                                               c => c.Id == header.Id);
                    oldRequest.BPId = header.BPId;
                    oldRequest.InternalBPId = header.InternalBPId;
                    oldRequest.Comment = header.Comment;
                    oldRequest.RequestDate = header.RequestDate;
                    Update(GetObjSet<VATInvoiceRequest>(ctx), oldRequest);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新行和对应信息
        /// </summary>
        /// <param name="inLine"> </param>
        /// <param name="userId"> </param>
        private void UpdateLine(VATInvoiceRequestLine inLine, int userId, List<Quota> quotaList)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Quota> newQuotaList = quotaList.Where(c => c.Id == inLine.QuotaId).ToList();
                    if (newQuotaList.Count > 0)
                    {
                        Quota newQuota = newQuotaList[0];
                        Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == inLine.QuotaId);
                        oldQuota.IsVatRequestFinished = newQuota.IsVatRequestFinished;
                        Update(GetObjSet<Quota>(ctx), oldQuota);
                    }

                    VATInvoiceRequestLine oldInLine =
                        QueryForObj(
                            GetObjQuery<VATInvoiceRequestLine>(ctx,
                                                               new List<string>
                                                                   {
                                                                       "VATInvoiceRequest",
                                                                       "VATInvoiceRequest.BusinessPartner",
                                                                       "VATInvoiceRequest.InternalCustomer"
                                                                   }), o => o.Id == inLine.Id);
                    oldInLine.StartTracking();
                    oldInLine.Comment = inLine.Comment;
                    oldInLine.QuotaId = inLine.QuotaId;
                    oldInLine.RequestQuantity = inLine.RequestQuantity;
                    oldInLine.RequestAmount = inLine.RequestAmount;
                    oldInLine.RequestPrice = inLine.RequestPrice;
                    oldInLine.VATInvoiceRequestId = inLine.VATInvoiceRequestId;
                    Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "VATInvoiceRequestLine");
                    oldInLine.DocumentId = doc.Id;
                    //获取增票申请状态 由增票申请行ID
                    int vatStatus = GetVATStatusByRequestLineId(inLine.Id,inLine.RequestQuantity,ctx);
                    if (vatStatus > 0)
                    {
                        oldInLine.VATStatus = vatStatus;
                    }

                    if (oldInLine.ChangeTracker.State == ObjectState.Modified)
                    {
                        ctx.ObjectStateManager.ChangeObjectState(oldInLine, EntityState.Modified);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void DeleteLine(int id, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //检查关联
                VATInvoiceRequestLine wil =
                    QueryForObj(
                        GetObjQuery<VATInvoiceRequestLine>(ctx,
                                                           new List<string>
                                                               {
                                                                   "VATInvoiceRequest",
                                                                   "VATInvoiceRequest.BusinessPartner",
                                                                   "VATInvoiceRequest.InternalCustomer",
                                                                   "Quota"
                                                               }), w => w.Id == id);
                wil.IsDeleted = true;
                if (wil.Quota.IsVatRequestFinished.HasValue && wil.Quota.IsVatRequestFinished.Value)
                {
                    wil.Quota.IsVatRequestFinished = false;
                }
                ctx.SaveChanges();
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
                    //检查是否有关联单据
                    VATInvoiceRequestLine line =
                        QueryForObj(GetObjQuery<VATInvoiceRequestLine>(ctx, new List<string> { "VATInvoiceRequest", "Quota" }),
                                    q => q.Id == id);
                    line.IsDeleted = true;
                    //1. 检查关联的增值税发票
                    if (QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx),
                                     d => d.VATInvoiceRequestLineId == id).Count > 0)
                    {
                        throw new FaultException(ErrCode.VATInvoiceRequestLineConnected.ToString());
                    }
                    //如果是最后一个删除的批次，合同也置为删除
                    if (QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx),
                                     q => q.VATInvoiceRequestId == line.VATInvoiceRequestId && q.Id != line.Id).Count == 0)
                    {
                        line.VATInvoiceRequest.IsDeleted = true;
                    }

                    if (line.Quota.IsVatRequestFinished.HasValue && line.Quota.IsVatRequestFinished.Value)
                    {
                        line.Quota.IsVatRequestFinished = false;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 获取增票申请状态 由增票申请行ID
        /// </summary>
        /// <param name="requestQuantity"></param>
        /// <param name="ctx"></param>
        /// <param name="rqLineId"></param>
        /// <returns></returns>
        private int GetVATStatusByRequestLineId(int rqLineId,decimal? requestQuantity,SenLan2Entities ctx) 
        {
            List<VATInvoiceLine> vatInvoiceLines = QueryForObjs(GetObjQuery<VATInvoiceLine>(ctx), o => o.VATInvoiceRequestLineId == rqLineId).ToList();
            if (vatInvoiceLines.Count>0)
            {
                if (vatInvoiceLines.Sum(t => (t.VATInvoiceQuantity ?? 0)) == (requestQuantity ?? 0))
                {
                    return (int)DBEntity.EnumEntity.VATStatus.Complete;
                }
                
                return (int)DBEntity.EnumEntity.VATStatus.Partial;
            }
            return 0;
        }
        #endregion
    }
}