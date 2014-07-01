using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Services.Base;
using Services.Helper.LogHelper;
using Services.Physical.Contracts;
using Utility.ErrorManagement;
using System.Globalization;
using Services.Physical.WarehouseOuts;
using Services.Helper.DeliveryNoFormulaHelper;
using Services.Helper.DeliveryLineStatusHelper;
using Services.Physical.WarehouseIns;

namespace Services.Physical.Deliveries
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeliveryService”。
    public class DeliveryService : BaseService<Delivery>, IDeliveryService
    {
        #region IDeliveryService Members

        /// <summary>
        /// 获取所有提单
        /// </summary>
        /// <returns></returns>
        public List<DeliveryLine> GetAllDeliveryLines()
        {
            try
            {
                var d = new BaseService<DeliveryLine>();
                var lines = (List<DeliveryLine>)d.GetAll();
                return lines;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 删除delivery行
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    DeleteLine(id, userId);
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        var quotaService = new QuotaService();
                        DeliveryLine deliveryLine = QueryForObj(GetObjQueryWithDeleted<DeliveryLine>(ctx), o => o.Id == id);
                        Delivery delivery = QueryForObj(GetObjQueryWithDeleted<Delivery>(ctx), o => o.Id == deliveryLine.DeliveryId);
                        quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(delivery.QuotaId, userId);
                        //更改采购销售批次对应表
                        var relService = new PSQuotaRelService();
                        relService.IsDelete = true;
                        relService.SetPSQuotaRel(delivery.QuotaId, userId);
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

        public override Delivery CreateNew(Delivery obj, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                try
                {
                    ObjectSet<Delivery> os = GetObjSet<Delivery>(ctx);
                    Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Delivery");
                    if (doc != null)
                    {
                        obj.DocumentId = doc.Id;
                    }
                    Create(os, obj);
                    ctx.SaveChanges();
                    return obj;
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
            }
        }

        public DeliveryEnableProperty SetElementsEnableProperty(int id)
        {
            //有后续单据，不可以修改批次
            //有没有入库
            //有没有转掉
            try
            {
                var dep = new DeliveryEnableProperty();
                using (var ctx = new SenLan2Entities())
                {
                    Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx, new List<string> { "Quota.Contract", "DeliveryLines.SalesDeliveryLines" }),
                                                    d => d.Id == id);
                    //任何情况都不可以编辑
                    dep.IsQuotaEnable = false;
                    if (delivery.Quota.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        //转掉
                        bool hasMd = false;
                        EntityUtil.FilterDeletedEntity(delivery.DeliveryLines);
                        foreach (var line in delivery.DeliveryLines)
                        {
                            EntityUtil.FilterDeletedEntity(line.SalesDeliveryLines);
                            if (line.SalesDeliveryLines.Count > 0)
                            {
                                hasMd = true;
                                break;
                            }
                        }

                        if (hasMd)
                        {
                            dep.IsQuotaEnable = false;
                            dep.IsWarehouseEnable = false;
                            dep.IsPoolNoBtnEnable = false;
                            return dep;
                        }
                        //入库
                        ICollection<DeliveryLine> dls = QueryForObjs(GetObjQuery<DeliveryLine>(ctx),
                                                                     dl => dl.DeliveryId == id);
                        foreach (DeliveryLine dl in dls)
                        {
                            DeliveryLine dl1 = dl;
                            if (QueryForObjs(GetObjQuery<WarehouseInLine>(ctx), wil => wil.DeliveryLineId == dl1.Id).Count > 0)
                            {
                                dep.IsWarehouseEnable = false;
                                dep.IsPoolNoBtnEnable = false;
                                return dep;
                            }
                        }
                    }
                    else
                    {
                        dep.IsTDEnable = false;
                        //商业发票
                        if (delivery.CommercialInvoiceId != null && delivery.CommercialInvoiceId > 0)
                        {
                            dep.IsTDEnable = false;
                            dep.IsPoolNoBtnEnable = false;
                            return dep;
                        }
                        //信用证
                        if (delivery.LCId != null && delivery.LCId > 0)
                        {
                            dep.IsTDEnable = false;
                            dep.IsPoolNoBtnEnable = false;
                            return dep;
                        }
                    }
                }
                return dep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 根据发货单ID获取发货单的数量
        /// </summary>
        /// <param name="deliveryId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetSaleDeliveryQuantityById(int deliveryId, int userId)
        {
            decimal value;
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery d = QueryForObj(GetObjQuery<Delivery>(ctx), de => de.Id == deliveryId);
                value = GetSaleDeliveryQuantity(d, userId);
            }
            return value;
        }

        #endregion

        #region 单据增删改
        #region 内贸发货单提单不需要多选提单池的流程 单独方法
        public void CreateDataForInternal(int userId, Delivery header, List<DeliveryLine> addedLines,List<Attachment> addedAttachments)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateDocument(userId, header, addedLines, addedAttachments);
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

        public void UpdateDataForInternal(int userId, Delivery header, List<DeliveryLine> addedLines,
                                   List<DeliveryLine> updatedLines,
                                   List<DeliveryLine> deletedLines, List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateDocument(userId, header, addedLines, updatedLines,
                                   deletedLines,
                                   addedAttachments, deletedAttachments);
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
        #endregion

        public void CreateData(int userId, List<Delivery> deliveryList, List<DeliveryLine> addedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    if (deliveryList != null && addedLines != null)
                    {
                        foreach (Delivery delivery in deliveryList)
                        {
                            List<DeliveryLine> lines = addedLines.Where(c => c.DeliveryPID == delivery.ProvisionalID).ToList();
                            CreateDocument(userId, delivery, lines, null);
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

        public void UpdateData(int userId, List<Delivery> addDeliveryList, List<Delivery> deleteDeliveryList, List<DeliveryLine> addDeliveryLineList, List<DeliveryLine> deleteDeliveryLineList)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    if (addDeliveryList != null && addDeliveryList.Count > 0)
                    {
                        foreach (Delivery delivery in addDeliveryList)
                        {
                            List<DeliveryLine> addLines = addDeliveryLineList.Where(c => c.DeliveryPID == delivery.ProvisionalID).ToList();
                            CreateDocument(userId, delivery, addLines, null);
                        }
                    }
                    if (deleteDeliveryList != null && deleteDeliveryList.Count > 0)
                    {
                        foreach (Delivery delivery in deleteDeliveryList)
                        {
                            List<DeliveryLine> deleteLines = deleteDeliveryLineList.Where(c => c.Id == delivery.Id).ToList();
                            UpdateDocument(userId, delivery, null, null, deleteLines, null, null);
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

        private List<DeliveryLine> GetBaseDeliveryLineIdWithAddedLines(int userId, Delivery header, List<DeliveryLine> addedLines)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW)
                {
                    if (addedLines != null && addedLines.Count > 0)
                    {
                        int lineId = addedLines.FirstOrDefault().Id;
                        DeliveryLine firstLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == lineId);

                        Delivery td = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == firstLine.DeliveryId);
                        //List<Delivery> deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.RelDeliveryId == td.Id).ToList();
                        if (td.RelDeliveryId.HasValue)
                        {
                            //有流转
                            foreach (var line in addedLines)
                            {
                                DeliveryLine oldLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == line.Id);
                                line.BaseDeliveryLineId = oldLine.BaseDeliveryLineId;
                            }
                        }
                        else
                        {
                            //没有流转
                            addedLines.ForEach(o => o.BaseDeliveryLineId = o.Id);
                        }
                    }
                }
                else if (header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW)
                {
                    if (addedLines != null && addedLines.Count > 0)
                    {
                        addedLines.ForEach(o => o.BaseDeliveryLineId = o.Id);
                    }
                }

                return addedLines;
            }
        }

        /// <summary>
        /// 新增提单和提单行，并保存到数据库
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedLines"></param>
        /// <param name="addedAttachments"></param>
        public void CreateDocument(int userId, Delivery header, List<DeliveryLine> addedLines,
                                   List<Attachment> addedAttachments)
        {
            //using (var ts = new TransactionScope())
            //{
                try
                {
                    //提单,设置数量确认
                    SetDlvIsVerified(header, addedLines, null, null, userId);
                    //新增提单
                    if (header.DeliveryType == (int)DeliveryType.InternalMDBOL)
                    {
                        header.DeliveryNo = DeliveryNoFormulaHelper.GetWarehouseNo(userId);
                    }

                    if (header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW ||
                        header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW)
                    {
                        //发货单
                        addedLines = GetBaseDeliveryLineIdWithAddedLines(userId, header, addedLines);
                    }

                    List<DeliveryLine> lines = AddDelivery(header, addedLines, addedAttachments, userId);

                    if (header.DeliveryType == (int)DeliveryType.InternalTDBOL || header.DeliveryType == (int)DeliveryType.InternalTDWW)
                    {
                        //内贸提单
                        lines.ForEach(o => o.BaseDeliveryLineId = o.Id);
                    }


                    //增加关联交易的提单
                    CreateRelDelivery(header, lines, userId);

                    LogManager.WriteLog("Delivery", "Create", header.Id, userId, null);

                    //ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                //finally
                //{
                //    ts.Dispose();
                //}
            //}
        }

        private void CreateRelDelivery(Delivery header, List<DeliveryLine> addedLines, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (header.DeliveryType == (int)DeliveryType.InternalTDBOL || header.DeliveryType == (int)DeliveryType.InternalTDWW)
                {
                    List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), o => o.RelQuotaId == header.QuotaId && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).ToList();
                    if (relQuotas.Count > 0)
                    {
                        var quotas = relQuotas.GroupBy(o => o.RelQuotaStage).OrderBy(o => o.Key);
                        int tDeliveryId = header.Id;
                        foreach (var quotaGroup in quotas)
                        {
                            if (quotaGroup.Key == 0)
                                continue;
                            List<Quota> quotaList = quotaGroup.ToList();
                            Quota pQuota = quotaList.FirstOrDefault(o => o.Contract.ContractType == (int)ContractType.Purchase);
                            Quota sQuota = quotaList.FirstOrDefault(o => o.Contract.ContractType == (int)ContractType.Sales);

                            //发货单
                            Delivery newSaleDelivery = CloneDelivery(header, "MD");
                            newSaleDelivery.QuotaId = sQuota.Id;
                            newSaleDelivery.DeliveryType = (int)DeliveryType.InternalMDBOL;
                            newSaleDelivery.RelDeliveryId = header.Id;
                            addedLines.ForEach(o => o.TDeliveryLineId = o.Id);
                            AddDelivery(newSaleDelivery, addedLines, null, userId);

                            addedLines.ForEach(o => o.TDeliveryLineId = null);
                            //提单
                            Delivery newHeader = CloneDelivery(header, "TD");
                            newHeader.QuotaId = pQuota.Id;
                            newHeader.RelDeliveryId = header.Id;

                            addedLines = AddDelivery(newHeader, addedLines, null, userId);
                            tDeliveryId = newHeader.Id;
                        }
                    }
                }
            }
        }

        private Delivery CloneDelivery(Delivery header, string flag)
        {
            var delivery = new Delivery();

            if (flag == "MD")
            {
                delivery.WarehouseId = header.WarehouseId;
            }
            else if (flag == "TD")
            {
                delivery.WarehouseId = header.WarehouseId;
                delivery.WarehouseProviderId = header.WarehouseProviderId;
                delivery.CommercialInvoiceId = header.CommercialInvoiceId;
                delivery.LCId = header.LCId;
                delivery.PaymentRequestId = header.PaymentRequestId;
            }
            else
            {
                return null;
            }

            delivery.DeliveryNo = header.DeliveryNo;
            delivery.DeliveryType = header.DeliveryType;
            delivery.IssueDate = header.IssueDate;
            delivery.Comment = header.Comment;
            delivery.FinanceStatus = header.FinanceStatus;
            delivery.IsVerified = header.IsVerified;
            delivery.Created = header.Created;
            delivery.CreatedBy = header.CreatedBy;
            delivery.UpdatedBy = header.UpdatedBy;
            delivery.Updated = header.Updated;

            return delivery;
        }

        private List<DeliveryLine> AddDelivery(Delivery header, IEnumerable<DeliveryLine> addedLines, List<Attachment> addedAttachments, int userId)
        {
            CreateHeader(header, userId);

            if (header.DeliveryType == (int)DeliveryType.InternalMDBOL)
            {
                UpdateSystemParameter(userId, header);
            }
            var lines = addedLines.Select(line => CreateLine(header, line, userId)).ToList();

            if (addedAttachments != null && addedAttachments.Count > 0)
            {
                foreach (Attachment attachment in addedAttachments)
                {
                    CreateAttachment(header, attachment, userId);
                }
            }

            ConvertTd(userId, header);
            if (!header.WarrantId.HasValue)
            {
                //提单,设置批次的货运状态
                SetStatus(header, userId);
            }
            SetDeliveryBrandId(userId, header.Id);
            //DeletedTd(userId, header,true);
            //ConvertTd(userId, header, convertDeliveryLines);
            return lines;
        }

        private void SetStatus(Delivery header, int userId)
        {
            //1.设置提单的货运状态

            //2.设置发货单的货运状态
            SetQuotaDeliveryStatus(header.QuotaId, userId);

            var quotaService = new QuotaService();
            quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(header.QuotaId, userId);

            if (header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW
                || header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW)
            {
                //发货单,更改采购销售批次对应表
                var relService = new PSQuotaRelService();
                relService.SetPSQuotaRel(header.QuotaId, userId);
            }
        }

        //private string GetWarehouseNo(int userId)
        //{
        //    try
        //    {
        //        using (var ctx = new SenLan2Entities(userId))
        //        {
        //            string warehouseNo = "";
        //            List<SystemParameter> systemParameterList = QueryForObjs(GetObjQuery<SystemParameter>(ctx), c => c.IsDeleted == false).ToList();
        //            if (systemParameterList.Count > 0)
        //            {
        //                SystemParameter systemParameter = systemParameterList[0];
        //                if (systemParameter != null)
        //                {
        //                    string year = DateTime.Now.ToString("yy");
        //                    if (string.IsNullOrEmpty(systemParameter.WarehouseOutNo))
        //                    {
        //                        warehouseNo = year + "-0001";
        //                    }
        //                    else
        //                    {
        //                        string lastY = systemParameter.WarehouseOutNo.Substring(0, 2);
        //                        if (Math.Abs(Convert.ToDouble(year) - Convert.ToDouble(lastY)) < double.Epsilon)
        //                        {
        //                            string value = systemParameter.WarehouseOutNo.Substring(3);
        //                            int maxValue = Convert.ToInt32(value) + 1;
        //                            string maxResult = maxValue.ToString(CultureInfo.InvariantCulture);
        //                            for (int i = 1; i <= (4 - maxValue.ToString(CultureInfo.InvariantCulture).Length); i++)
        //                            {
        //                                maxResult = ("0" + maxResult);
        //                            }
        //                            warehouseNo = lastY + "-" + maxResult;
        //                        }
        //                        else
        //                        {
        //                            string nowYear = DateTime.Now.ToString("yy");
        //                            warehouseNo = nowYear + "-0001";
        //                        }
        //                    }
        //                }
        //            }
        //            return warehouseNo;
        //        }
        //    }
        //    catch (OptimisticConcurrencyException)
        //    {
        //        throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
        //    }
        //}

        private void UpdateSystemParameter(int userId, Delivery header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    SystemParameter systemParameter = QueryForObjs(GetObjQuery<SystemParameter>(ctx), c => c.IsDeleted == false).FirstOrDefault();
                    if (systemParameter != null)
                    {
                        systemParameter.WarehouseOutNo = header.DeliveryNo;
                        Update(GetObjSet<SystemParameter>(ctx), systemParameter);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private int GetTdId(int userId, Delivery header)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery d = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == header.Id);
                DeliveryLine line = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "PurchaseDeliveryLine.Delivery" }),
                    o => o.DeliveryId == d.Id).FirstOrDefault();
                if (line != null)
                {
                    return line.PurchaseDeliveryLine.Delivery.Id;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 编辑提单和提单行，并保存到数据库
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="addedLines"></param>
        /// <param name="updatedLines"></param>
        /// <param name="deletedLines"></param>
        /// <param name="addedAttachments"></param>
        /// <param name="deletedAttachments"></param>
        public void UpdateDocument(int userId, Delivery header, List<DeliveryLine> addedLines,
                                   List<DeliveryLine> updatedLines,
                                   List<DeliveryLine> deletedLines, List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments)
        {
            //using (var ts = new TransactionScope())
            //{
                try
                {
                    //提单,设置数量确认
                    SetDlvIsVerified(header, addedLines, updatedLines, deletedLines, userId);

                    //获得原始单据的TDelivery,用于后边比较更换提单

                    if (header.DeliveryType == (int)DeliveryType.ExternalMDWW ||
                        header.DeliveryType == (int)DeliveryType.ExternalMDBOL ||
                        header.DeliveryType == (int)DeliveryType.InternalMDBOL ||
                        header.DeliveryType == (int)DeliveryType.InternalMDWW)
                    {
                        //发货单
                        //获取保存前的发货单对应的提单的ID
                        int oldTdId = GetTdId(userId, header);

                        UpdateItem(userId, header, addedLines, updatedLines, deletedLines,
                            addedAttachments, deletedAttachments);

                        SetStatus(header, userId);

                        //发货单,更改采购销售批次对应表
                        var relService = new PSQuotaRelService();
                        relService.SetPSQuotaRel(header.QuotaId, userId);
                        var quotaService = new QuotaService();
                        quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(header.QuotaId, userId);

                        if (addedLines != null && addedLines.Count > 0)
                        {
                            //有新增行，才会有可能更换提单
                            int newTdId = GetTdId(userId, header);
                            if (oldTdId != 0 && oldTdId != newTdId)
                            {
                                ChangedTd(userId, oldTdId);
                            }
                        }
                    }
                    else
                    {
                        //提单

                        UpdateItem(userId, header, addedLines, updatedLines, deletedLines,
                            addedAttachments, deletedAttachments);

                        //提单,设置批次的货运状态
                        SetQuotaDeliveryStatus(header.QuotaId, userId);
                        int changeMdId;
                        var quotaService = new QuotaService();

                        //更改提单的时候同时修改发货单
                        //下家发货单的Id,如果没有则为0,（多个也为0,不修改发货单）或不是流转的,有一个发货单的话就修改发货单
                        int hasSaleStatus;
                        changeMdId = ChangeMdByTd(userId, header.Id, quotaService, addedLines, updatedLines, deletedLines, out hasSaleStatus);

                        UpdateRelDelivery(userId, header, changeMdId, hasSaleStatus);
                        UpdateWarehouseInByOneInTDelivery(userId, header.Id, updatedLines);
                        //实际数量
                        quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(header.QuotaId, userId);
                    }

                    LogManager.WriteLog("Delivery", "Update", header.Id, userId, null);

                    //ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
            //    finally
            //    {
            //        ts.Dispose();
            //    }
            //}
        }



        private void UpdateItem(int userId, Delivery header, IEnumerable<DeliveryLine> addedLines, IEnumerable<DeliveryLine> updatedLines, IEnumerable<DeliveryLine> deletedLines, List<Attachment> addedAttachments, List<Attachment> deletedAttachments, bool withDeleted = false)
        {
            UpdateHeader(header, userId, withDeleted);
            if (addedLines != null)
            {
                foreach (DeliveryLine line in addedLines)
                {
                    CreateLine(header, line, userId);
                }
            }
            if (updatedLines != null)
            {
                foreach (DeliveryLine line in updatedLines)
                {
                    UpdateLine(header, line, userId, withDeleted);
                    foreach (WarehouseOutDeliveryPerson deliveryPerson in line.WarehouseOutDeliveryPersons)
                    {
                        UpdateDeliveryPerson(userId, line, deliveryPerson);
                    }
                }
            }
            if (deletedLines != null)
            {
                foreach (DeliveryLine line in deletedLines)
                {
                    DeleteLine(line.Id, userId);
                }
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

            SetDeliveryBrandId(userId, header.Id);
        }

        private void UpdateWarehouseInByOneInTDelivery(int userId, int headerId, List<DeliveryLine> updateLines)
        {
            int id = 0;
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery header = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == headerId);
                id = GetWarehouseInIdByOneInDelivery(id, ctx, header);
                if (id != 0)
                {
                    UpdateWarehouseIn(userId, id, updateLines);
                }
            }
        }

        /// <summary>
        /// 根据提单更改发货单(一对一修改发货单，否则不修改)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="quotaService"></param>
        /// <returns>返回发货单Id</returns>
        private int ChangeMdByTd(int userId, int headerId, QuotaService quotaService, List<DeliveryLine> addLines, List<DeliveryLine> updateLines,
            List<DeliveryLine> deleteLines, out int hasSaleStatus)
        {
            int id = 0;
            hasSaleStatus = 0;
            bool hasRelDelivery = false;
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery header = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == headerId);
                if (header.DeliveryType == (int)DeliveryType.InternalTDBOL || header.DeliveryType == (int)DeliveryType.InternalTDWW)
                {
                    List<Delivery> deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx, new List<string>() { "Quota", "Quota.Contract" }), o => o.RelDeliveryId == header.Id).ToList();
                    if (deliveries.Count > 0)
                    {
                        //内贸，有关联交易
                        int maxStage = deliveries.Max(o => o.Quota.RelQuotaStage.Value);
                        Delivery delivery = deliveries.Where(o => o.Quota.RelQuotaStage == maxStage && (o.DeliveryType == (int)DeliveryType.InternalTDBOL || o.DeliveryType == (int)DeliveryType.InternalTDWW)).FirstOrDefault();
                        header = delivery;
                        hasRelDelivery = true;
                    }
                }
                id = GetSaleDeliveryIdByOneSaleDelivery(id, ctx, header);

                //删除发货单的提单行
                if (id != 0)
                {
                    UpdateMD(userId, id, addLines, updateLines, deleteLines);
                    Delivery saleDelivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == id);
                    //设置发货单的IsVerified
                    UpdateSaleDelivery(saleDelivery.Id, userId);
                    //设置销售批次的货运状态
                    SetQuotaDeliveryStatus(saleDelivery.QuotaId, userId);
                    //修改销售提单的实际数量
                    quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(saleDelivery.QuotaId, userId);

                    if (hasRelDelivery)
                    {
                        //发货单,更改采购销售批次对应表
                        var relService = new PSQuotaRelService();
                        relService.SetPSQuotaRel(saleDelivery.QuotaId, userId);
                    }
                }
            }
            return id;
        }


        private void UpdateWarehouseIn(int userId, int warehouseInId, List<DeliveryLine> updateLines)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                WarehouseIn warehouseIn = QueryForObj(GetObjQuery<WarehouseIn>(ctx), c => c.Id == warehouseInId);
                var warehouseInService = new WarehouseInService();
                var warehosueOutService = new WarehouseOutService();
                if (updateLines != null && updateLines.Count > 0)
                {
                    foreach (var l in updateLines)
                    {
                        WarehouseInLine oldInLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx), c => c.DeliveryLineId == l.Id);
                        WarehouseInLine inLine = new WarehouseInLine();
                        if (oldInLine != null)
                        {
                            inLine.BrandId = l.BrandId ?? oldInLine.BrandId;
                            inLine.CommodityTypeId = l.CommodityTypeId ?? oldInLine.CommodityTypeId;
                            inLine.SpecificationId = l.SpecificationId ?? oldInLine.SpecificationId;
                            inLine.Quantity = l.NetWeight;
                            inLine.WarehouseInId = warehouseInId;
                            inLine.VerifiedQuantity = l.VerifiedWeight;
                            inLine.PackingQuantity = l.PackingQuantity;
                            inLine.IsVerified = l.IsVerified;
                            inLine.Comment = oldInLine.Comment;
                            inLine.DeliveryLineId = oldInLine.DeliveryLineId;
                            inLine.IsPBCleared = oldInLine.IsPBCleared;
                            inLine.PBNo = oldInLine.PBNo;
                            inLine.Id = oldInLine.Id;
                            warehouseInService.UpdateLine(userId, warehouseIn, inLine, warehouseIn);
                            warehouseInService.UpdateVerifiedStatus(warehouseIn.Id);
                            //int warehouseOutLineID = 0;
                            //warehouseOutLineID = GetWarehouseOutIdByWarehouseIn(warehouseOutLineID, ctx, oldInLine.Id);
                            //if(warehouseOutLineID != 0)
                            //{
                            //    WarehouseInLine warehouseInLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx), c => c.Id == oldInLine.Id);
                            //    WarehouseOutLine oldOutLine = QueryForObj(GetObjQuery<WarehouseOutLine>(ctx, new List<string> { "WarehouseInLine", "WarehouseOut" }), c => c.Id == warehouseOutLineID);
                            //    WarehouseOutLine newOutLine = new WarehouseOutLine();
                            //    List<WarehouseInLine> inList = new List<WarehouseInLine>();
                            //    if(oldOutLine != null)
                            //    {
                            //        newOutLine.Id = oldOutLine.Id;
                            //        newOutLine.BrandId = warehouseInLine.BrandId ?? oldOutLine.BrandId;
                            //        newOutLine.CommodityTypeId = warehouseInLine.CommodityTypeId ?? oldOutLine.CommodityTypeId;
                            //        newOutLine.IsVerified = warehouseInLine.IsVerified;
                            //        newOutLine.PackingQuantity = warehouseInLine.PackingQuantity;
                            //        newOutLine.Quantity = warehouseInLine.Quantity;
                            //        newOutLine.SpecificationId = warehouseInLine.SpecificationId ?? oldOutLine.SpecificationId;
                            //        newOutLine.VerifiedQuantity = warehouseInLine.VerifiedQuantity;
                            //        newOutLine.WarehouseInLineId = warehouseInLine.Id;
                            //        newOutLine.WarehouseOutId = oldOutLine.WarehouseOutId;
                            //        inList.Add(oldOutLine.WarehouseInLine);
                            //        warehosueOutService.UpdateLine(userId, newOutLine,inList, oldOutLine.WarehouseOut.QuotaId);
                            //    }
                            //}
                            //Update(GetObjSet<WarehouseInLine>(ctx), inLine);
                        }
                    }
                }
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// 修改提单的时候修改发货单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mdId"></param>
        /// <param name="addLines"></param>
        /// <param name="updateLines"></param>
        /// <param name="deleteLines"></param>
        private void UpdateMD(int userId, int mdId, List<DeliveryLine> addLines, List<DeliveryLine> updateLines, List<DeliveryLine> deleteLines)
        {

            using (var ctx = new SenLan2Entities(userId))
            {

                Delivery md = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == mdId);
                List<DeliveryLine> mdAddLines = new List<DeliveryLine>();
                List<DeliveryLine> mdUpdateLines = new List<DeliveryLine>();
                List<DeliveryLine> mdDeleteLines = new List<DeliveryLine>();

                if (addLines != null && addLines.Count > 0)
                {
                    foreach (var line in addLines)
                    {
                        DeliveryLine l = new DeliveryLine();
                        l.BrandId = line.BrandId == 0 ? null : line.BrandId;
                        l.Comment = line.Comment;
                        l.CommodityTypeId = line.CommodityTypeId;
                        l.CountryId = line.CountryId;
                        l.DeliveryId = mdId;
                        l.GrossWeight = line.GrossWeight;
                        l.IsDeleted = line.IsDeleted;
                        l.IsVerified = line.IsVerified;
                        l.NetWeight = line.NetWeight;
                        l.PackingQuantity = line.PackingQuantity;
                        l.PBNo = line.PBNo;
                        l.SpecificationId = line.SpecificationId == 0 ? null : line.SpecificationId;
                        l.VerifiedWeight = line.VerifiedWeight;
                        l.DeliveryStatus = line.DeliveryStatus;
                        l.TempUnitPrice = line.TempUnitPrice;
                        l.BaseDeliveryLineId = line.Id;
                        mdAddLines.Add(l);
                    }
                }

                if (updateLines != null && updateLines.Count > 0)
                {
                    foreach (var line in updateLines)
                    {
                        DeliveryLine l = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.TDeliveryLineId.Value == line.Id).FirstOrDefault();
                        l.BrandId = line.BrandId == 0 ? null : line.BrandId;
                        l.Comment = line.Comment;
                        l.CommodityTypeId = line.CommodityTypeId;
                        l.CountryId = line.CountryId;
                        l.DeliveryId = mdId;
                        l.GrossWeight = line.GrossWeight;
                        l.IsDeleted = line.IsDeleted;
                        l.IsVerified = line.IsVerified;
                        l.NetWeight = line.NetWeight;
                        l.PackingQuantity = line.PackingQuantity;
                        l.PBNo = line.PBNo;
                        l.SpecificationId = line.SpecificationId == 0 ? null : line.SpecificationId;
                        l.VerifiedWeight = line.VerifiedWeight;
                        l.DeliveryStatus = line.DeliveryStatus;
                        l.TempUnitPrice = line.TempUnitPrice;
                        mdUpdateLines.Add(l);
                    }
                }

                if (deleteLines != null && deleteLines.Count > 0)
                {
                    foreach (var line in deleteLines)
                    {
                        DeliveryLine l = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.TDeliveryLineId.Value == line.Id).FirstOrDefault();
                        mdDeleteLines.Add(l);
                    }
                }

                UpdateDocument(userId, md, addLines, mdUpdateLines, mdDeleteLines, null, null);
                //if (addLines != null && addLines.Count > 0)
                //{
                //    foreach (var l in addLines)
                //    {
                //        DeliveryLine line = new DeliveryLine();
                //        line.BrandId = l.BrandId == 0 ? null : l.BrandId;
                //        line.Comment = l.Comment;
                //        line.CommodityTypeId = l.CommodityTypeId;
                //        line.CountryId = l.CountryId;
                //        line.DeliveryId = mdId;
                //        line.GrossWeight = l.GrossWeight;
                //        line.IsDeleted = l.IsDeleted;
                //        line.IsVerified = l.IsVerified;
                //        line.NetWeight = l.NetWeight;
                //        line.PackingQuantity = l.PackingQuantity;
                //        line.PBNo = l.PBNo;
                //        line.SpecificationId = l.SpecificationId == 0 ? null : l.SpecificationId;
                //        line.VerifiedWeight = l.VerifiedWeight;
                //        line.DeliveryStatus = l.DeliveryStatus;
                //        line.TempUnitPrice = l.TempUnitPrice;
                //        line.BaseDeliveryLineId = l.Id;
                //        Create(GetObjSet<DeliveryLine>(ctx), line);
                //    }
                //}

                //if (updateLines != null && updateLines.Count > 0)
                //{
                //    foreach (var l in updateLines)
                //    {
                //        DeliveryLine line = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == mdId && o.BaseDeliveryLineId == l.Id);
                //        if (line != null)
                //        {
                //            line.BrandId = l.BrandId == 0 ? null : l.BrandId;
                //            line.Comment = l.Comment;
                //            line.CommodityTypeId = l.CommodityTypeId;
                //            line.CountryId = l.CountryId;
                //            line.DeliveryId = mdId;
                //            line.GrossWeight = l.GrossWeight;
                //            line.IsDeleted = l.IsDeleted;
                //            line.IsVerified = l.IsVerified;
                //            line.NetWeight = l.NetWeight;
                //            line.PackingQuantity = l.PackingQuantity;
                //            line.PBNo = l.PBNo;
                //            line.SpecificationId = l.SpecificationId == 0 ? null : l.SpecificationId;
                //            line.VerifiedWeight = l.VerifiedWeight;
                //            line.DeliveryStatus = l.DeliveryStatus;
                //            line.TempUnitPrice = l.TempUnitPrice;
                //            Update(GetObjSet<DeliveryLine>(ctx), line);
                //        }
                //    }
                //}

                //if (deleteLines != null && deleteLines.Count > 0)
                //{
                //    foreach (var l in deleteLines)
                //    {
                //        DeliveryLine line = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == mdId && o.BaseDeliveryLineId == l.Id);
                //        if (line != null)
                //        {
                //            line.IsDeleted = true;
                //            Update(GetObjSet<DeliveryLine>(ctx), line);
                //        }
                //    }
                //}
                //ctx.SaveChanges();
            }
        }

        //更改入库时 针对只有一个出库的同时更新出库
        //private int GetWarehouseOutIdByWarehouseIn(int id, SenLan2Entities ctx, int warehouseInLineId)
        //{
        //    List<WarehouseOutLine> outLines = QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx), c => c.WarehouseInLineId == warehouseInLineId).ToList();
        //    WarehouseInLine inLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx), c => c.Id == warehouseInLineId);
        //    if (outLines.Count == 1 && inLine.IsPBCleared.Value)
        //    {
        //        id = outLines.FirstOrDefault().Id;
        //    }
        //    else
        //    {
        //        id = 0;
        //    }
        //    return id;
        //}

        //根据提单找出只有一个入库的入库ID
        private int GetWarehouseInIdByOneInDelivery(int id, SenLan2Entities ctx, Delivery delivery)
        {
            //最后一个提单的提单行
            List<DeliveryLine> deliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines" }), o => o.DeliveryId == delivery.Id).ToList();
            //List<Delivery> saleDeliveryList = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.t)
            List<int> warehouseInIDList = new List<int>();
            bool hasSaleDelivery = false;
            foreach (var line in deliveryLines)
            {
                EntityUtil.FilterDeletedEntity(line.WarehouseInLines);
                List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx),
                    o => o.TDeliveryLineId == line.Id).ToList();
                if (lines.Count > 0)
                {
                    hasSaleDelivery = true;
                }

                if (line.WarehouseInLines.Count == 1)
                {
                    WarehouseInLine inLine = line.WarehouseInLines.FirstOrDefault();
                    warehouseInIDList.Add(inLine.WarehouseInId);
                }
            }

            if (warehouseInIDList.Count == 1 && delivery.DeliveryStatus == true && !hasSaleDelivery)
            {
                id = warehouseInIDList.FirstOrDefault();
            }
            else
            {
                id = 0;
            }

            return id;
        }

        private int GetSaleDeliveryIdByOneSaleDelivery(int id, SenLan2Entities ctx, Delivery delivery)
        {
            //最后一个提单的提单行
            List<DeliveryLine> deliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines" }), o => o.DeliveryId == delivery.Id).ToList();
            var saleDelivery = new List<Delivery>();
            bool hasWarehouseInLine = false;
            foreach (var line in deliveryLines)
            {
                EntityUtil.FilterDeletedEntity(line.WarehouseInLines);
                if (!hasWarehouseInLine && line.WarehouseInLines.Count > 0)
                    hasWarehouseInLine = true;
                List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "Delivery" }),
                    o => o.TDeliveryLineId == line.Id).ToList();
                foreach (var mdline in lines)
                {
                    if (!saleDelivery.Contains(mdline.Delivery))
                    {
                        saleDelivery.Add(mdline.Delivery);
                    }
                }
            }

            if (saleDelivery.Count == 1 && delivery.DeliveryStatus == true && !hasWarehouseInLine)
            {
                //有发货单，没有入库，且是一对一，因为要把发货单对应的批次重新生成，所以需要在最后更改发货单，这里只是记录下发货单的id
                id = saleDelivery.FirstOrDefault().Id;
            }
            else
            {
                id = 0;
            }
            return id;
        }

        /// <summary>
        /// 发货单更换提单,设置原来提单的转口状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tdId"></param>
        private void ChangedTd(int userId, int tdId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery td = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == tdId);

                var deliveryList = new List<Delivery>();
                List<DeliveryLine> deliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == td.Id).ToList();
                foreach (var line in deliveryLines)
                {
                    List<DeliveryLine> saleDeliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "Delivery" }), o => o.TDeliveryLineId == line.Id).ToList();
                    if (saleDeliveryLines.Count > 0)
                    {
                        foreach (var saleLine in saleDeliveryLines)
                        {
                            Delivery d = saleLine.Delivery;
                            if (!deliveryList.Contains(d))
                            {
                                deliveryList.Add(d);
                            }
                        }
                    }
                }
                Update(GetObjSet<Delivery>(ctx), td);
                ctx.SaveChanges();
            }
        }

        private void UpdateRelDelivery(int userId, Delivery header, int changeMdId, int hasSaleStatus)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), o => o.RelQuotaId == header.QuotaId
                    && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).ToList();
                if (relQuotas != null && relQuotas.Count > 0)
                {
                    bool oneByone;
                    List<Delivery> mds = HasNotSplitMD(header.Id, out oneByone, userId);
                    //有流转。删掉对应的提单和发货单，重新生成,下家发货单不删除，Id用changeMdId记录
                    DeleteRelDelivery(header, userId);
                    //重新生成流转的提单和发货单，如果changeMdId不为0,把下家的发货单跟流转的最后一个提单对应起来
                    UpdateRelDeliveryByCreate(userId, header, relQuotas, changeMdId, mds, hasSaleStatus);
                }
            }
        }

        private void UpdateRelDeliveryByCreate(int userId, Delivery header, IEnumerable<Quota> relQuotas, int changeMdId, List<Delivery> mds, int hasSaleStatus)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == header.Id).ToList();
                if (lines.Count > 0)
                {
                    lines.ForEach(o => o.BaseDeliveryLineId = o.Id);
                    var quotas = relQuotas.GroupBy(o => o.RelQuotaStage).OrderBy(o => o.Key);
                    //把流转的批次按照RelQuotaStage按照从小到大排序，赋给流转自动生成的提单和发货单的QuotaId
                    int tDeliveryId = header.Id;
                    //按照流转自动生成提单和发货单

                    foreach (var quotaGroup in quotas)
                    {
                        List<Quota> quotaList = quotaGroup.ToList();
                        //采购批次
                        Quota pQuota = quotaList.FirstOrDefault(o => o.Contract.ContractType == (int)ContractType.Purchase);
                        //销售批次
                        Quota sQuota = quotaList.FirstOrDefault(o => o.Contract.ContractType == (int)ContractType.Sales);

                        //发货单
                        Delivery newSaleDelivery = CloneDelivery(header, "MD");
                        newSaleDelivery.QuotaId = sQuota.Id;//销售批次的Id
                        newSaleDelivery.DeliveryType = (int)DeliveryType.InternalMDBOL;

                        newSaleDelivery.RelDeliveryId = header.Id;
                        lines.ForEach(o => o.TDeliveryLineId = o.Id);
                        AddDelivery(newSaleDelivery, lines, null, userId);

                        lines.ForEach(o => o.TDeliveryLineId = null);

                        //提单
                        Delivery newHeader = CloneDelivery(header, "TD");
                        newHeader.QuotaId = pQuota.Id;//采购批次的Id
                        newHeader.RelDeliveryId = header.Id;
                        lines = AddDelivery(newHeader, lines, null, userId);
                        tDeliveryId = newHeader.Id;
                    }

                    if (changeMdId != 0)
                    {
                        //更改下家发货单，并对下家发货单重新与提单关联
                        SetNewMd(userId, changeMdId, tDeliveryId, lines);
                    }
                    else
                    {
                        //不是一对一且有发货单
                        if (mds != null && mds.Count > 0)
                        {
                            //不更改下家发货单，并对下家发货单重新与提单关联（此处假设修改提单的时候不能删除提单行，只能修改实提数或增加提单行）
                            //非流转的不需要改
                            if (lines.Count > 0)
                            {
                                foreach (var md in mds)
                                {
                                    List<DeliveryLine> mdLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == md.Id).ToList();
                                    foreach (var mdLine in mdLines)
                                    {
                                        DeliveryLine firstLine = lines.FirstOrDefault(o => o.BaseDeliveryLineId == mdLine.BaseDeliveryLineId);
                                        if (firstLine == null)
                                            continue;
                                        int id = firstLine.Id;

                                        mdLine.TDeliveryLineId = id;
                                        Update(GetObjSet<DeliveryLine>(ctx), mdLine);
                                    }
                                }
                                ctx.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="md">发货单</param>
        /// <param name="delivery">原始提单</param>
        /// <param name="tdId">流转的最后一家的提单号</param>
        private void SetMdWithNewTd(int userId, Delivery md, Delivery delivery, int tdId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {

            }
        }

        /// <summary>
        /// 返回下家的销售批次Id,用于根据销售批次找采购批次
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mdId"></param>
        /// <param name="tdId"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        private int SetMdTDeliveryWithNewTD(int userId, int mdId, int tdId, List<DeliveryLine> lines)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<DeliveryLine> oldLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == mdId).ToList();
                //if (oldLines.Count > 0)
                //{
                //    //删掉下家发货单的提单行
                //    foreach (var line in oldLines)
                //    {
                //        line.IsDeleted = true;
                //        Update(GetObjSet<DeliveryLine>(ctx), line);
                //    }
                //    ctx.SaveChanges();
                //}
                //发货单
                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == mdId);

                if (oldLines.Count > 0)
                {
                    foreach (var line in oldLines)
                    {
                        DeliveryLine l = lines.Where(o => o.BaseDeliveryLineId == line.BaseDeliveryLineId).FirstOrDefault();
                        if (l != null)
                        {
                            line.TDeliveryLineId = l.Id;
                            Update(GetObjSet<DeliveryLine>(ctx), line);
                        }
                    }
                    ctx.SaveChanges();
                }

                //lines.ForEach(o => o.TDeliveryLineId = o.Id);

                //foreach (DeliveryLine line in lines)
                //{
                //    CreateLine(delivery, line, userId);
                //}

                //bool isVerified = false;
                //if (lines.All(o => o.IsVerified))
                //{
                //    isVerified = true;
                //}

                //delivery.IsVerified = isVerified;
                //Update(GetObjSet<Delivery>(ctx), delivery);
                //ctx.SaveChanges();
                //返回下家的销售批次Id,用于根据销售批次找采购批次
                return delivery.QuotaId;
            }
        }

        private void SetNewMd(int userId, int mdId, int tdId, List<DeliveryLine> lines)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                int quotaId = SetMdTDeliveryWithNewTD(userId, mdId, tdId, lines);

                //设置销售批次的货运状态
                SetQuotaDeliveryStatus(quotaId, userId);
                //修改销售提单的实际数量
                var quotaService = new QuotaService();
                quotaService.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(quotaId, userId);

                //发货单,更改采购销售批次对应表
                var relService = new PSQuotaRelService();
                relService.SetPSQuotaRel(quotaId, userId);
            }
        }

        /// <summary>
        /// 删除流转的提单行和提单
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"></param>
        private void DeleteRelDelivery(Delivery header, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<Delivery> relDeliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.RelDeliveryId == header.Id).ToList();

                if (relDeliveries.Count > 0)
                {
                    foreach (Delivery delivery in relDeliveries)
                    {
                        DeleteRelDeliveryLine(delivery.Id, userId);
                        delivery.IsDeleted = true;
                        Update(GetObjSet<Delivery>(ctx), delivery);
                        ctx.SaveChanges();
                        //维护自动生成的批次的货运状态
                        SetQuotaDeliveryStatus(delivery.QuotaId, userId);
                    }
                }
            }
        }

        private void DeleteRelDeliveryLine(int deliveryId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<DeliveryLine> relDeliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == deliveryId).ToList();
                if (relDeliveryLines.Count > 0)
                {
                    foreach (DeliveryLine line in relDeliveryLines)
                    {
                        line.IsDeleted = true;
                        Update(GetObjSet<DeliveryLine>(ctx), line);
                    }
                    ctx.SaveChanges();
                }
            }
        }

        private List<int> _warehouseOutDeliveryPersonsList = new List<int>();

        private void CopyDeliveryLineFromTDToMD(int tdId, int mdId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == tdId);
                List<DeliveryLine> tdLines =
                    QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == tdId).ToList();
                if (tdLines.Count > 0)
                {
                    int firstMD = 0;
                    foreach (var tdLine in tdLines)
                    {
                        var mdline = new DeliveryLine
                                         {
                                             BrandId = tdLine.BrandId,
                                             Comment = tdLine.Comment,
                                             CommodityTypeId = tdLine.CommodityTypeId,
                                             CountryId = tdLine.CountryId,
                                             DeliveryId = mdId,
                                             DeliveryStatus = true,
                                             GrossWeight = tdLine.GrossWeight,
                                             IsVerified = tdLine.IsVerified,
                                             NetWeight = tdLine.NetWeight,
                                             PackingQuantity = tdLine.PackingQuantity,
                                             PBNo = tdLine.PBNo,
                                             SpecificationId = tdLine.SpecificationId,
                                             VerifiedWeight = tdLine.VerifiedWeight
                                         };
                        if (delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                            delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                        {
                            mdline.TDeliveryLineId = tdLine.Id;
                        }
                        Update(GetObjSet<DeliveryLine>(ctx), mdline);
                        ctx.SaveChanges();
                        if (firstMD == 0)
                        {
                            firstMD = mdline.Id;
                        }
                    }
                    foreach (var i in _warehouseOutDeliveryPersonsList)
                    {
                        WarehouseOutDeliveryPerson person = QueryForObj(GetObjQuery<WarehouseOutDeliveryPerson>(ctx),
                                                                        o => o.Id == i);
                        person.DeliveryLineId = firstMD;
                        Update(GetObjSet<WarehouseOutDeliveryPerson>(ctx), person);
                        ctx.SaveChanges();
                    }
                }

            }
        }

        /// <summary>
        /// 设置批次的货运状态
        /// </summary>
        private void SetQuotaDeliveryStatus(int quotaId, int userId)
        {
            bool status = CalcDeliveryStatus(quotaId, userId);

            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                if (quota != null)
                {
                    quota.DeliveryStatus = status;
                    Update(GetObjSet<Quota>(ctx), quota);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 设置提单数量确认
        /// </summary>
        private void SetDlvIsVerified(Delivery header, List<DeliveryLine> addLine, List<DeliveryLine> updateLine, List<DeliveryLine> deleteLine, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (addLine != null && addLine.Count > 0)
                {
                    if (addLine.Any(t => t.IsVerified == false))
                    {
                        header.IsVerified = false;
                        return;
                    }

                    header.IsVerified = true;
                }
                if (updateLine != null && updateLine.Count > 0)
                {
                    ICollection<DeliveryLine> historyDeliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx),
                                                               o => o.DeliveryId == header.Id);
                    IList<DeliveryLine> deliveryLines = updateLine.ToList();
                    foreach (var oldLine in historyDeliveryLines)
                    {
                        if (updateLine.All(t => t.Id != oldLine.Id))
                        {
                            if (deleteLine != null && deleteLine.Count > 0)
                            {
                                if (!deleteLine.All(t => t.Id != oldLine.Id))
                                {
                                    continue;
                                }
                            }
                            deliveryLines.Add(oldLine);
                        }
                    }

                    bool flag = true;
                    if (deliveryLines.Any(t => !t.IsVerified))
                    {
                        flag = false;
                    }

                    header.IsVerified = flag;
                }
            }
        }


        protected void UpdateSaleDelivery(int deliveryId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx, new List<string> { "DeliveryLines" }), o => o.Id == deliveryId);
                List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == deliveryId).ToList();
                if (delivery != null)
                {
                    if (lines.All(o => o.IsVerified))
                    {
                        delivery.IsVerified = true;
                    }
                    else
                    {
                        delivery.IsVerified = false;
                    }
                    Update(GetObjSet<Delivery>(ctx), delivery);
                    ctx.SaveChanges();
                }
            }
        }


        /// <summary>
        /// 计算批次的货运状态
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private bool CalcDeliveryStatus(int quotaId, int userId)
        {
            const bool status = false;
            decimal param = GetInventory2Delivery(userId);
            using (var ctx = new SenLan2Entities(userId))
            {
                decimal num = 0M;
                ICollection<Delivery> deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.QuotaId == quotaId);
                foreach (Delivery delivery in deliveries)
                {
                    if (delivery.WarrantId.HasValue && delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL)
                        continue;
                    int deliveryId = delivery.Id;
                    ICollection<DeliveryLine> deliveryLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string>() { "WarehouseInLines" }),
                                                                           o => o.DeliveryId == deliveryId);
                    if (delivery.DeliveryType == (int)DeliveryType.InternalTDBOL ||
                        delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                        delivery.DeliveryType == (int)DeliveryType.InternalMDBOL ||
                        delivery.DeliveryType == (int)DeliveryType.InternalMDWW)
                    {
                        //内贸数量按实际数量计算
                        foreach (DeliveryLine deliveryLine in deliveryLines)
                        {
                            List<WarehouseInLine> inLines = deliveryLine.WarehouseInLines.Where(o => o.IsDeleted == false).ToList();
                            if (inLines.Count > 0 && deliveryLine.DeliveryStatus == true)
                            {
                                //有入库，且提单的货运状态是完成，按入库算
                                num += inLines.Sum(o => o.VerifiedQuantity ?? 0);
                                continue;
                            }
                            else if (deliveryLine.VerifiedWeight.HasValue)
                            {
                                num += deliveryLine.VerifiedWeight.Value;
                            }
                        }
                    }
                    else
                    {
                        //外贸按净重
                        foreach (DeliveryLine deliveryLine in deliveryLines)
                        {
                            List<WarehouseInLine> inLines = deliveryLine.WarehouseInLines.Where(o => o.IsDeleted == false).ToList();
                            if (inLines.Count > 0 && deliveryLine.DeliveryStatus == true)
                            {
                                //有入库，且提单的货运状态是完成，按入库算
                                num += inLines.Sum(o => o.VerifiedQuantity ?? 0);
                                continue;
                            }
                            else if (deliveryLine.NetWeight.HasValue)
                            {
                                num += deliveryLine.NetWeight.Value;
                            }
                        }
                    }
                }
                //出库
                decimal warehouseOutQuantity = GetWarehouseOutQuantity(quotaId, userId);
                num += warehouseOutQuantity;
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                if (quota.Quantity != null)
                {
                    decimal quotaNum = quota.Quantity.Value;
                    decimal minNum = (100 - param) * quotaNum / 100;
                    decimal maxNum = (100 + param) * quotaNum / 100;
                    if (num >= minNum && num <= maxNum)
                        return true;
                }
            }
            return status;
        }

        /// <summary>
        /// 创建提单
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"></param>
        protected void CreateHeader(Delivery header, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                try
                {
                    Document doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Delivery");
                    if (doc != null)
                    {
                        header.DocumentId = doc.Id;
                    }
                    ObjectSet<Delivery> os = GetObjSet<Delivery>(ctx);
                    Create(os, header);
                    ctx.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ctx.Dispose();
                }
            }
        }

        /// <summary>
        /// 创建一个提单行
        /// </summary>
        /// <param name="header"></param>
        /// <param name="line"></param>
        /// <param name="userId"></param>
        protected DeliveryLine CreateLine(Delivery header, DeliveryLine line, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                try
                {
                    var addLine = new DeliveryLine
                    {
                        DeliveryId = header.Id,
                        CommodityTypeId = line.CommodityTypeId,
                        CountryId = line.CountryId,
                        Comment = line.Comment,
                        GrossWeight = line.GrossWeight,
                        NetWeight = line.NetWeight,
                        IsVerified = line.IsVerified,
                        IsDeleted = line.IsDeleted,
                        PBNo = line.PBNo,
                        PackingQuantity = line.PackingQuantity,
                        VerifiedWeight = line.VerifiedWeight,
                        DeliveryStatus = line.DeliveryStatus,
                        TempUnitPrice = line.TempUnitPrice,
                        BaseDeliveryLineId = line.BaseDeliveryLineId,
                        FDPLineId = line.FDPLineId
                    };

                    if (header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW ||
                        header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW)
                    {
                        addLine.TDeliveryLineId = line.TDeliveryLineId;
                        addLine.DeliveryStatus = true;
                    }

                    addLine.BrandId = line.BrandId == 0 ? null : line.BrandId;

                    if (line.SpecificationId == 0)
                    {
                        addLine.SpecificationId = null;
                    }
                    else
                    {
                        addLine.SpecificationId = line.SpecificationId;
                    }
                    if (header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW
                        || header.DeliveryType == (int)DeliveryType.ExternalTDBOL || header.DeliveryType == (int)DeliveryType.ExternalTDWW)
                    {
                        addLine.DeliveryStatus = true;
                    }
                    ObjectSet<DeliveryLine> os = GetObjSet<DeliveryLine>(ctx);
                    Create(os, addLine);
                    ctx.SaveChanges();

                    foreach (WarehouseOutDeliveryPerson deliveryPerson in line.WarehouseOutDeliveryPersons)
                    {
                        CreateDeliveryPerson(userId, addLine, deliveryPerson);
                    }
                    int lineId = addLine.Id;
                    if (header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW
                        || header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW)
                    {
                        //发货单,更改提单的DeliveryStatus
                        lineId = addLine.TDeliveryLineId.Value;
                    }
                    DeliveryLineStatusHelper.GetDeliveryLineStatus(lineId, userId);
                    return addLine;
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ctx.Dispose();
                }
            }
        }

        private void CreateDeliveryPerson(int userId, DeliveryLine deliveryLine,
                                         WarehouseOutDeliveryPerson deliveryPerson)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var person = new WarehouseOutDeliveryPerson
                    {
                        Name = deliveryPerson.Name,
                        IdentityCard = deliveryPerson.IdentityCard,
                        VehicleNo = deliveryPerson.VehicleNo,
                        DeliveryQuantity = deliveryPerson.DeliveryQuantity,
                        DeliveryLineId = deliveryLine.Id,
                        Tel = deliveryPerson.Tel
                    };
                    Create(GetObjSet<WarehouseOutDeliveryPerson>(ctx), person);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新提单
        /// </summary>
        /// <param name="header"></param>
        /// <param name="userId"></param>
        protected void UpdateHeader(Delivery header, int userId, bool withDeleted = false)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery oldDelivery = null;
                if (withDeleted)
                {
                    oldDelivery = QueryForObj(GetObjQueryWithDeleted<Delivery>(ctx), o => o.Id == header.Id);
                }
                else
                {
                    oldDelivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == header.Id);
                }
                oldDelivery.ArrivedDate = header.ArrivedDate;
                oldDelivery.Comment = header.Comment;
                //oldDelivery.Delivery2 = header.Delivery2;
                //oldDelivery.DeliveryNo = header.DeliveryNo;
                oldDelivery.DeliveryType = header.DeliveryType;
                oldDelivery.DischargePlaceId = header.DischargePlaceId;
                oldDelivery.DischargePortId = header.DischargePortId;
                oldDelivery.FinanceStatus = header.FinanceStatus;
                oldDelivery.IsCopy = header.IsCopy;
                oldDelivery.IsCustomed = header.IsCustomed;
                oldDelivery.IsDeleted = header.IsDeleted;
                oldDelivery.IsDraft = header.IsDraft;
                //oldDelivery.IssueDate = header.IssueDate;
                oldDelivery.LoadingPlaceId = header.LoadingPlaceId;
                oldDelivery.LoadingPortId = header.LoadingPortId;
                oldDelivery.NotifyPartyId = header.NotifyPartyId;
                oldDelivery.OnBoardDate = header.OnBoardDate;
                oldDelivery.PackingStandard = header.PackingStandard;
                oldDelivery.CirculNo = header.CirculNo;
                oldDelivery.ActualDeliveryBPId = header.ActualDeliveryBPId;

                int oldQuotaId = oldDelivery.QuotaId;
                if (oldQuotaId != header.QuotaId)
                {
                    oldDelivery.QuotaId = header.QuotaId;
                    DeleteOldDeliveryLine(header.Id, userId);
                }
                oldDelivery.IsVerified = header.IsVerified;
                oldDelivery.ShipperId = header.ShipperId;
                oldDelivery.ShippingPartyId = header.ShippingPartyId;
                oldDelivery.VesselNo = header.VesselNo;
                if (header.WarehouseId.HasValue)
                {
                    if (header.WarehouseId.Value > 0)
                    {
                        oldDelivery.WarehouseId = header.WarehouseId;
                        oldDelivery.DeliveryNo = header.DeliveryNo;
                        oldDelivery.IssueDate = header.IssueDate;
                    }
                    else if (header.DeliveryType == (int)DeliveryType.ExternalTDBOL)
                    {
                        oldDelivery.DeliveryNo = header.DeliveryNo;
                    }
                }
                else
                {
                    oldDelivery.WarehouseId = header.WarehouseId;
                    oldDelivery.DeliveryNo = header.DeliveryNo;
                    oldDelivery.IssueDate = header.IssueDate;
                }

                if (header.WarehouseProviderId.HasValue)
                {
                    if (header.WarehouseProviderId.Value > 0)
                        oldDelivery.WarehouseProviderId = header.WarehouseProviderId;
                }
                else
                {
                    oldDelivery.WarehouseProviderId = header.WarehouseProviderId;
                }

                Update(GetObjSet<Delivery>(ctx), oldDelivery);
                ctx.SaveChanges();
            }
        }

        private void DeleteOldDeliveryLine(int id, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<DeliveryLine> deliveryLines =
                    QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == id).ToList();
                foreach (DeliveryLine line in deliveryLines)
                {
                    line.IsDeleted = true;
                    Update(GetObjSet<DeliveryLine>(ctx), line);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 更新提单行
        /// </summary>
        /// <param name="header"></param>
        /// <param name="line"></param>
        /// <param name="userId"></param>
        protected void UpdateLine(Delivery header, DeliveryLine line, int userId, bool withDeleted = false)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (line != null)
                {
                    DeliveryLine oldLine = null;
                    if (withDeleted)
                    {
                        oldLine = QueryForObj(GetObjQueryWithDeleted<DeliveryLine>(ctx), o => o.Id == line.Id);
                    }
                    else
                    {
                        oldLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == line.Id);
                    }
                    if (oldLine != null)
                    {
                        bool oldDeliveryStatus = oldLine.DeliveryStatus;
                        oldLine.BrandId = line.BrandId == 0 ? null : line.BrandId;
                        oldLine.Comment = line.Comment;
                        oldLine.CommodityTypeId = line.CommodityTypeId;
                        oldLine.CountryId = line.CountryId;
                        oldLine.DeliveryId = header.Id;
                        oldLine.GrossWeight = line.GrossWeight;
                        oldLine.IsDeleted = line.IsDeleted;
                        oldLine.IsVerified = line.IsVerified;
                        oldLine.NetWeight = line.NetWeight;
                        oldLine.PackingQuantity = line.PackingQuantity;
                        oldLine.PBNo = line.PBNo;
                        oldLine.SpecificationId = line.SpecificationId == 0 ? null : line.SpecificationId;
                        oldLine.VerifiedWeight = line.VerifiedWeight;
                        oldLine.DeliveryStatus = line.DeliveryStatus;
                        oldLine.TempUnitPrice = line.TempUnitPrice;
                        //oldLine.TDeliveryLineId = line.TDeliveryLineId;

                        Update(GetObjSet<DeliveryLine>(ctx), oldLine);
                        ctx.SaveChanges();
                        if (!withDeleted)
                        {
                            int lineId = line.Id;
                            if (header.DeliveryType == (int)DeliveryType.ExternalMDBOL || header.DeliveryType == (int)DeliveryType.ExternalMDWW
                            || header.DeliveryType == (int)DeliveryType.InternalMDBOL || header.DeliveryType == (int)DeliveryType.InternalMDWW)
                            {
                                //发货单,更改提单的DeliveryStatus
                                lineId = oldLine.TDeliveryLineId.Value;
                            }
                            if (line.DeliveryStatus == oldDeliveryStatus)
                                DeliveryLineStatusHelper.GetDeliveryLineStatus(lineId, userId);
                            else
                            {
                                //直接更改了提单行的货运状态，不根据发货单判断当前提单行货运状态是否完成，更改头的状态
                                List<DeliveryLine> oldLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == header.Id).ToList();
                                bool headerDeliveryStatus = oldLines.All(o => o.DeliveryStatus);
                                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == header.Id);
                                delivery.DeliveryStatus = headerDeliveryStatus;
                                Update(GetObjSet<Delivery>(ctx), delivery);
                                ctx.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        private void UpdateDeliveryPerson(int userId, DeliveryLine deliveryLine,
                                        WarehouseOutDeliveryPerson deliveryPerson)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (deliveryPerson.Id <= 0)
                    {
                        CreateDeliveryPerson(userId, deliveryLine, deliveryPerson);
                    }
                    else
                    {
                        WarehouseOutDeliveryPerson oldDeliveryPerson =
                            QueryForObj(
                                GetObjQuery<WarehouseOutDeliveryPerson>(ctx, new List<string> { "WarehouseOutLine" }),
                                c => c.Id == deliveryPerson.Id);
                        oldDeliveryPerson.DeliveryQuantity = deliveryPerson.DeliveryQuantity;
                        oldDeliveryPerson.Name = deliveryPerson.Name;
                        oldDeliveryPerson.IdentityCard = deliveryPerson.IdentityCard;
                        oldDeliveryPerson.VehicleNo = deliveryPerson.VehicleNo;
                        oldDeliveryPerson.DeliveryLineId = deliveryPerson.DeliveryLineId;
                        oldDeliveryPerson.Tel = deliveryPerson.Tel;
                        oldDeliveryPerson.IsDeleted = deliveryPerson.IsDeleted;
                        Update(GetObjSet<WarehouseOutDeliveryPerson>(ctx), oldDeliveryPerson);
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
        /// 删除提单行
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        protected void DeleteLine(int id, int userId)
        {
            try
            {
                int deliveryId = 0;
                Delivery delivery = null;

                using (var ctx = new SenLan2Entities(userId))
                {
                    DeliveryLine deliveryLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == id);
                    delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == deliveryLine.DeliveryId);
                    deliveryId = delivery.Id;
                    int tdDeliveryId = deliveryId;//提单，用于计算转口状态用
                    if (delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW ||
                        delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW)
                    {
                        //发货单
                        if (delivery.CommercialInvoiceId != null)
                        {
                            //商业发票
                            throw new FaultException(ErrCode.DeliveryCommercialInvoiceConnected.ToString());
                        }
                        if (delivery.LCId != null)
                        {
                            //信用证
                            throw new FaultException(ErrCode.DeliveryLCConnected.ToString());
                        }
                        DeliveryLine mdLine = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "PurchaseDeliveryLine", "PurchaseDeliveryLine.Delivery" }),
                            o => o.DeliveryId == deliveryId).FirstOrDefault();
                        tdDeliveryId = mdLine.PurchaseDeliveryLine.Delivery.Id;
                    }
                    else
                    {
                        //提单
                        //1.有发货单和入库等，不能删除
                        List<Delivery> relDelivery = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.RelDeliveryId == delivery.Id).ToList();
                        Delivery lastDelivery = delivery;
                        DeliveryLine lastDeliveryLine = deliveryLine;
                        if (relDelivery.Count > 0)
                        {
                            //有流转
                            lastDelivery = relDelivery.Where(o => o.Quota.Contract.ContractType == (int)ContractType.Purchase)
                                .OrderByDescending(o => o.Quota.RelQuotaStage.Value).First();
                            lastDeliveryLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == lastDelivery.Id && o.BaseDeliveryLineId == id);
                        }
                        List<DeliveryLine> mdLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.TDeliveryLineId == lastDeliveryLine.Id).ToList();
                        if (mdLines.Count > 0)
                        {
                            //销售了
                            throw new FaultException(ErrCode.SaleDeliveryConnected.ToString());
                        }
                        List<WarehouseInLine> warehouseInLines = QueryForObjs(GetObjQuery<WarehouseInLine>(ctx), o => o.DeliveryLineId == lastDeliveryLine.Id).ToList();
                        if (warehouseInLines.Count > 0)
                        {
                            //入库了
                            throw new FaultException(ErrCode.DeliveryWarehouseInConnected.ToString());
                        }
                        if (lastDelivery.CommercialInvoiceId != null)
                        {
                            //商业发票
                            throw new FaultException(ErrCode.DeliveryCommercialInvoiceConnected.ToString());
                        }
                        if (lastDelivery.PaymentRequestId != null)
                        {
                            //付款申请
                            throw new FaultException(ErrCode.DeliveryPaymentRequestConnected.ToString());
                        }
                        if (lastDelivery.LCId != null)
                        {
                            //信用证
                            throw new FaultException(ErrCode.DeliveryLCConnected.ToString());
                        }
                    }

                    //2.删除所有的该行
                    List<DeliveryLine> baseLines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.BaseDeliveryLineId == id).ToList();
                    foreach (var line in baseLines)
                    {
                        line.IsDeleted = true;
                        Update(GetObjSet<DeliveryLine>(ctx), line);
                    }
                    deliveryLine.IsDeleted = true;
                    Update(GetObjSet<DeliveryLine>(ctx), deliveryLine);
                    ctx.SaveChanges();
                    List<Delivery> relDeliveries = new List<Delivery>();

                    List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == deliveryId).ToList();

                    if (lines.Count == 0 && delivery != null)
                    {
                        relDeliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.RelDeliveryId == delivery.Id).ToList();
                        foreach (var rel in relDeliveries)
                        {
                            rel.IsDeleted = true;
                            Update(GetObjSet<Delivery>(ctx), rel);
                        }
                        delivery.IsDeleted = true;
                        Update(GetObjSet<Delivery>(ctx), delivery);

                        if (delivery.WarrantId.HasValue)
                        {
                            //提单转仓单
                            Delivery td = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == delivery.WarrantId.Value);
                            td.WarrantId = null;
                            Update(GetObjSet<Delivery>(ctx), td);
                        }
                    }
                    ctx.SaveChanges();
                    relDeliveries.Add(delivery);
                    foreach (var rel in relDeliveries)
                    {
                        SetQuotaDeliveryStatus(rel.QuotaId, userId);
                    }

                    PSQuotaRelService relService = new PSQuotaRelService();

                    List<Delivery> mds = relDeliveries.Where(o => o.DeliveryType == (int)DeliveryType.ExternalMDBOL
                        || o.DeliveryType == (int)DeliveryType.ExternalMDWW
                        || o.DeliveryType == (int)DeliveryType.InternalMDBOL
                        || o.DeliveryType == (int)DeliveryType.InternalMDWW).ToList();
                    foreach (var rel in relDeliveries)
                    {
                        relService.SetPSQuotaRel(rel.QuotaId, userId);
                    }
                    SetDeliveryBrandId(userId, delivery.Id);
                    int lineId = deliveryLine.Id;
                    if (delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW ||
                        delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW)
                    {
                        Delivery td = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == tdDeliveryId);
                        relService.SetRelStrByPurchaseQuotaId(userId, td.QuotaId);
                        relService.SetRelStrBySaleQuotaId(userId, delivery.QuotaId);
                        lineId = deliveryLine.TDeliveryLineId.Value;
                    }

                    DeliveryLineStatusHelper.GetDeliveryLineStatus(lineId, userId);
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 取系统参数里的提单货运状态误差参数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetInventory2Delivery(int userId)
        {
            decimal num = 0M;
            using (var ctx = new SenLan2Entities(userId))
            {
                ICollection<SystemParameter> parameters = QueryForObjs(GetObjQuery<SystemParameter>(ctx),
                                                                       o => o.IsDeleted == false);
                if (parameters.Count > 0)
                {
                    foreach (SystemParameter parameter in parameters)
                    {
                        num = parameter.Delivery2Quota;
                        break;
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="delivery"></param>
        /// <param name="attachment"></param>
        /// <param name="userId"></param>
        private void CreateAttachment(Delivery delivery, Attachment attachment, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (attachment != null)
                {
                    attachment.Id = 0;
                    attachment.RecordId = delivery.Id;
                    if (delivery.DocumentId != null) attachment.DocumentId = (int)delivery.DocumentId;
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

        /// <summary>
        /// 获取出库数量
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetWarehouseOutQuantity(int quotaId, int userId)
        {
            decimal warehouseOutQuantity = 0M;

            using (var ctx = new SenLan2Entities(userId))
            {
                List<WarehouseOut> warehouseOutList = QueryForObjs(GetObjQuery<WarehouseOut>(ctx),
                                                        o => o.QuotaId == quotaId).ToList();
                if (warehouseOutList.Count > 0)
                {
                    foreach (WarehouseOut warehouseOut in warehouseOutList)
                    {
                        int warehouseOutId = warehouseOut.Id;
                        ICollection<WarehouseOutLine> warehouseOutLines = QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx),
                                                                                       o =>
                                                                                       o.WarehouseOutId == warehouseOutId);
                        foreach (WarehouseOutLine line in warehouseOutLines)
                        {
                            if (line.VerifiedQuantity.HasValue)
                            {
                                warehouseOutQuantity += line.VerifiedQuantity.Value;
                            }
                        }
                    }
                }
            }

            return warehouseOutQuantity;
        }

        /// <summary>
        /// 获取发货单的数量
        /// </summary>
        /// <param name="delivery"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetSaleDeliveryQuantity(Delivery delivery, int userId)
        {
            if (delivery == null)
                return 0;
            decimal saleDeliveryNum = 0M;
            int deliveryId = delivery.Id;
            int deliveryType = delivery.DeliveryType;

            const string sql = "it.DeliveryId==@p1";
            var param = new List<object> { deliveryId };
            if (deliveryType == (int)DeliveryType.InternalTDBOL || deliveryType == (int)DeliveryType.InternalTDWW ||
                deliveryType == (int)DeliveryType.InternalMDBOL)
            {
                saleDeliveryNum += GetSum<DeliveryLine>(sql, param, o => o.VerifiedWeight);
            }
            else
            {
                saleDeliveryNum += GetSum<DeliveryLine>(sql, param, o => o.NetWeight);
            }

            return saleDeliveryNum;
        }

        /// <summary>
        /// 转口提单仓单不能编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns>true 提示，false  不提示</returns>
        public bool IsReexport(int id, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                bool hasMd = false;
                Delivery del = QueryForObj(GetObjQuery<Delivery>(ctx, new List<string>() { "Quota", "Quota.Contract", "DeliveryLines", "DeliveryLines.SalesDeliveryLines" }),
                                        d => d.Id == id);
                if (del.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                    del.DeliveryType == (int)DeliveryType.ExternalTDWW ||
                    del.DeliveryType == (int)DeliveryType.InternalTDBOL ||
                    del.DeliveryType == (int)DeliveryType.InternalTDWW)
                {
                    EntityUtil.FilterDeletedEntity(del.DeliveryLines);
                    foreach (var line in del.DeliveryLines)
                    {
                        EntityUtil.FilterDeletedEntity(line.SalesDeliveryLines);
                        if (line.SalesDeliveryLines.Count > 0)
                        {
                            if (del.Quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                            {
                                //内贸短单
                                List<Delivery> deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx), o => o.RelDeliveryId == id).ToList();
                                if (deliveries.Count > 0)
                                {
                                    //有流转
                                    int maxStage = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == del.QuotaId).Max(o => o.RelQuotaStage).Value;
                                    Delivery td = QueryForObj(GetObjQuery<Delivery>(ctx, new List<string> { "Quota", "DeliveryLines", "DeliveryLines.SalesDeliveryLines" }), o => o.RelDeliveryId == id && o.Quota.RelQuotaStage == maxStage
                                        && (o.DeliveryType == (int)DeliveryType.InternalTDBOL || o.DeliveryType == (int)DeliveryType.InternalTDWW));
                                    EntityUtil.FilterDeletedEntity(td.DeliveryLines);
                                    foreach (var tdLine in td.DeliveryLines)
                                    {
                                        EntityUtil.FilterDeletedEntity(tdLine.SalesDeliveryLines);
                                        if (tdLine.SalesDeliveryLines.Count > 0)
                                        {
                                            hasMd = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    //没有流转
                                    hasMd = true;
                                }
                            }
                            else
                            {
                                //非内贸短单
                                hasMd = true;
                            }
                        }
                    }
                }
                return hasMd;
            }
        }

        /// <summary>
        /// true 可以编辑,false 不可以编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Delivery> HasNotSplitMD(int id, out bool oneByone, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                oneByone = false;
                var dList = new List<Delivery>();
                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx, new List<string> { "Quota" }), o => o.Id == id);
                if (delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                {
                    List<Delivery> deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx, new List<string> { "Quota" }), o => o.RelDeliveryId == delivery.Id).ToList();
                    if (deliveries.Count > 0)
                    {
                        //有流转,需要找到最后一个提单
                        //Quota pQuota = delivery.Quota;
                        //Quota lastQuota = QueryForObjs(GetObjQuery<Quota>(ctx),
                        //    o => o.RelQuotaId == pQuota.Id && o.Contract.ContractType == (int)ContractType.Purchase)
                        //    .OrderByDescending(o => o.RelQuotaStage).FirstOrDefault();
                        int maxStage = deliveries.Max(o => o.Quota.RelQuotaStage.Value);
                        Delivery lastDelivery = deliveries.Where(o => o.Quota.RelQuotaStage == maxStage && (o.DeliveryType == (int)DeliveryType.InternalTDBOL || o.DeliveryType == (int)DeliveryType.InternalTDWW)).FirstOrDefault();
                        //Delivery lastDelivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.QuotaId == lastQuota.Id && o.RelDeliveryId == delivery.Id);

                        delivery = lastDelivery;
                    }

                    List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx,
                        new List<string> { "WarehouseInLines", "SalesDeliveryLines", "SalesDeliveryLines.Delivery" }),
                        o => o.DeliveryId == delivery.Id).ToList();

                    bool hasWarehouseInLine = false;
                    foreach (var l in lines)
                    {
                        EntityUtil.FilterDeletedEntity(l.WarehouseInLines);
                        EntityUtil.FilterDeletedEntity(l.SalesDeliveryLines);
                        if (!hasWarehouseInLine && l.WarehouseInLines.Count > 0)
                            hasWarehouseInLine = true;
                        foreach (var saleLine in l.SalesDeliveryLines)
                        {
                            Delivery d = saleLine.Delivery;
                            if (!dList.Contains(d))
                            {
                                dList.Add(d);
                            }
                        }
                    }
                    if (dList.Count == 1)
                    {
                        //DeliveryStatus未完成，且没有入库
                        if (delivery.DeliveryStatus == true && !hasWarehouseInLine)
                        {
                            oneByone = true;
                        }
                        else
                        {
                            oneByone = false;
                        }
                    }
                }

                return dList;
            }
        }

        private void SetDeliveryBrandId(int userId, int deliveryId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == deliveryId);
                if (delivery != null)
                {
                    List<DeliveryLine> lines = QueryForObjs(GetObjQuery<DeliveryLine>(ctx), o => o.DeliveryId == deliveryId).ToList();

                    string brandIds = "_";
                    brandIds = lines.Aggregate(brandIds, (current, line) => current + (line.BrandId.ToString() + "_"));

                    delivery.BrandId = brandIds;
                    Update(GetObjSet<Delivery>(ctx), delivery);
                    ctx.SaveChanges();
                }
            }
        }

        #region 提单转仓单
        private void ConvertTd(int userId, Delivery header)
        {
            if (header.WarrantId.HasValue)
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Delivery delivery = QueryForObj(GetObjQuery<Delivery>(ctx), o => o.Id == header.WarrantId.Value);
                    delivery.WarrantId = header.Id;
                    Update(GetObjSet<Delivery>(ctx), delivery);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateItemWithDeleted(int userId, Delivery header, IEnumerable<DeliveryLine> addedLines, IEnumerable<DeliveryLine> updatedLines, IEnumerable<DeliveryLine> deletedLines, List<Attachment> addedAttachments, List<Attachment> deletedAttachments)
        {
            UpdateItem(userId, header, addedLines, updatedLines, deletedLines, addedAttachments, deletedAttachments, true);
        }
        #endregion
    }
}

