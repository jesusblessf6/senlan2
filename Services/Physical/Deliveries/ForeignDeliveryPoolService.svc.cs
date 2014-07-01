using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using DBEntity.EnumEntity;
using DBEntity.EnableProperty;

namespace Services.Physical.Deliveries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ForeignDeliveryPoolService" in code, svc and config file together.
    public class ForeignDeliveryPoolService : BaseService<ForeignDeliveryPool>, IForeignDeliveryPoolService
    {
        public List<ForeignDeliveryPoolLine> GetDetailLinesById(int id)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return
                        QueryForObjs(GetObjQuery<ForeignDeliveryPoolLine>(ctx), o => o.ForeignDeliveryPoolId == id)
                            .ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public ForeignDeliveryPool CreateDocument(ForeignDeliveryPool dp, List<ForeignDeliveryPoolLine> lines,
            List<Attachment> attachments, List<FDPStorageFeeSEDate> storageDates, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var newDp = AddHeader(dp, userId);
                    AddLines(newDp.Id, lines, userId);
                    AddAttachments(newDp.Id, newDp.DocumentId, attachments, userId);
                    AddStorageDates(newDp.Id, storageDates, userId);
                    CalculateSums(newDp.Id);
                    CalculateStorageFee(newDp.Id);

                    ts.Complete();

                    return newDp;
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

        public ForeignDeliveryPool UpdateDocument(ForeignDeliveryPool dp, List<ForeignDeliveryPoolLine> newLines, List<ForeignDeliveryPoolLine> modifiedLines, List<ForeignDeliveryPoolLine> deletedLines,
                                                  List<Attachment> newAttachments, List<Attachment> deletedAttachments, List<FDPStorageFeeSEDate> newStorageDates,
                                           List<FDPStorageFeeSEDate> modifiedStorageDates, List<FDPStorageFeeSEDate> deletedStorageDates, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(dp, userId);
                    AddLines(dp.Id, newLines, userId);
                    ModifyLines(modifiedLines, userId);
                    DeleteLines(deletedLines);
                    AddAttachments(dp.Id, dp.DocumentId, newAttachments, userId);
                    DeleteAttachments(deletedAttachments);
                    AddStorageDates(dp.Id, newStorageDates, userId);
                    ModifyStorageDates(modifiedStorageDates, userId);
                    DeletedStorageDates(deletedStorageDates);
                    CalculateSums(dp.Id);
                    CalculateStorageFee(dp.Id);
                    UpdateDeliveries(dp, modifiedLines, userId);

                    ts.Complete();
                    return dp;
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

        private void UpdateDeliveries(ForeignDeliveryPool dp, List<ForeignDeliveryPoolLine> modifiedFDPLines, int userId)
        {
            var ctx = new SenLan2Entities();
            var deliveries = QueryForObjs(GetObjQuery<Delivery>(ctx, new Collection<string> { "DeliveryLines" }),
                                          o => o.FDPId == dp.Id);
            var deliverySvc = new DeliveryService();
            var idList = modifiedFDPLines.Select(o => o.Id).ToList();
            foreach (var delivery in deliveries)
            {
                CopyToDelivery(delivery, dp);
                var lines = delivery.DeliveryLines.ToList();
                var modifiedLines = new List<DeliveryLine>();

                foreach (var deliveryLine in lines)
                {
                    if (deliveryLine.IsDeleted)
                        continue;

                    if (idList.Contains(deliveryLine.FDPLineId ?? 0))
                    {
                        var fdpLine = modifiedFDPLines.Single(o => o.Id == deliveryLine.FDPLineId);
                        CopyToDeliveryLine(deliveryLine, fdpLine);
                        modifiedLines.Add(deliveryLine);
                    }
                }
                if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                    deliverySvc.UpdateDocument(userId, delivery, null, modifiedLines, null, null, null);

                #region 转仓单后置删除标识的提单
                //if (delivery.WarrantId.HasValue)
                //{
                //    Delivery td = QueryForObj(GetObjQueryWithDeleted<Delivery>(ctx, new Collection<string> { "DeliveryLines" }), o => o.Id == delivery.WarrantId.Value);
                //    CopyToDelivery(td, dp);
                //    lines = td.DeliveryLines.ToList();
                //    modifiedLines = new List<DeliveryLine>();
                //    foreach (var deliveryLine in lines)
                //    {
                //        //if (deliveryLine.IsDeleted)
                //        //    continue;

                //        if (idList.Contains(deliveryLine.FDPLineId ?? 0))
                //        {
                //            var fdpLine = modifiedFDPLines.Single(o => o.Id == deliveryLine.FDPLineId);
                //            CopyToDeliveryLine(deliveryLine, fdpLine);
                //            modifiedLines.Add(deliveryLine);
                //        }
                //    }
                //    deliverySvc.UpdateItemWithDeleted(userId, td, null, modifiedLines, null, null, null);
                //}
                #endregion
            }
        }

        private void CopyToDeliveryLine(DeliveryLine deliveryLine, ForeignDeliveryPoolLine fdpLine)
        {
            deliveryLine.BrandId = fdpLine.BrandId;
            deliveryLine.Comment = fdpLine.Comment;
            deliveryLine.CommodityTypeId = fdpLine.CommodityTypeId;
            deliveryLine.GrossWeight = fdpLine.GrossWeight;
            deliveryLine.NetWeight = fdpLine.NetWeight;
            deliveryLine.CountryId = fdpLine.OriginCountryId;
            deliveryLine.PBNo = fdpLine.PBNo;
            deliveryLine.PackingQuantity = fdpLine.PackingQuantity;
            deliveryLine.SpecificationId = fdpLine.SpecificationId;
        }

        private void CopyToDelivery(Delivery delivery, ForeignDeliveryPool fdp)
        {
            delivery.DeliveryNo = fdp.DeliveryNo;
            delivery.IssueDate = fdp.IssueDate;
            delivery.WarehouseProviderId = fdp.WarehouseProviderId;
            if (fdp.DeliveryType == (int)DeliveryType.ExternalTDWW)
            {
                //外贸仓单
                delivery.WarehouseId = fdp.WarehouseId;
            }
            else
            {
                //外贸提单
                delivery.WarehouseId = -1;
            }
            delivery.Comment = fdp.Comment;
            delivery.ShipperId = fdp.ShipperId;
            delivery.NotifyPartyId = fdp.NotifyPartyId;
            delivery.ShippingPartyId = fdp.ShippingPartyId;
            delivery.OnBoardDate = fdp.OnBoardDate;
            delivery.VesselNo = fdp.VesselNo;
            delivery.LoadingPortId = fdp.LoadingPortId;
            delivery.LoadingPlaceId = fdp.LoadingPlaceId;
            delivery.DischargePlaceId = fdp.DischargePlaceId;
            delivery.DischargePortId = fdp.DischargePortId;
            delivery.PackingStandard = fdp.PackingStandard;

        }


        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        var pool = QueryForObj(GetObjQuery<ForeignDeliveryPool>(ctx), o => o.Id == id);
                        if (pool != null)
                        {
                            pool.IsDeleted = true;
                        }

                        var lines = QueryForObjs(GetObjQuery<ForeignDeliveryPoolLine>(ctx),
                                                 o => o.ForeignDeliveryPoolId == id);
                        foreach (var line in lines)
                        {
                            line.IsDeleted = true;
                        }

                        var storageDates = QueryForObjs(GetObjQuery<FDPStorageFeeSEDate>(ctx),
                                                        o => o.DeliveryPoolId == id);
                        foreach (var fdpStorageFeeSeDate in storageDates)
                        {
                            fdpStorageFeeSeDate.IsDeleted = true;
                        }

                        var attachments = QueryForObjs(GetObjQuery<Attachment>(ctx),
                                                       o => o.DocumentId == pool.DocumentId && o.RecordId == id);
                        foreach (var attachment in attachments)
                        {
                            attachment.IsDeleted = true;
                        }

                        ctx.SaveChanges();
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

        private ForeignDeliveryPool AddHeader(ForeignDeliveryPool dp, int userId)
        {
            var newDP = new ForeignDeliveryPool
                            {
                                DeliveryNo = dp.DeliveryNo,
                                DeliveryType = dp.DeliveryType,
                                IssueDate = dp.IssueDate,
                                WarehouseProviderId = dp.WarehouseProviderId,
                                WarehouseId = dp.WarehouseId,
                                Comment = dp.Comment,
                                ShipperId = dp.ShipperId,
                                NotifyPartyId = dp.NotifyPartyId,
                                ShippingPartyId = dp.ShippingPartyId,
                                OnBoardDate = dp.OnBoardDate,
                                VesselNo = dp.VesselNo,
                                LoadingPlaceId = dp.LoadingPlaceId,
                                LoadingPortId = dp.LoadingPortId,
                                DischargePlaceId = dp.DischargePlaceId,
                                DischargePortId = dp.DischargePortId,
                                PackingStandard = dp.PackingStandard,
                                CommodityId = dp.CommodityId,
                                MarkNo = dp.MarkNo
                            };

            using (var ctx = new SenLan2Entities())
            {
                if (QueryForObjs(GetObjQuery<ForeignDeliveryPool>(ctx), o => o.DeliveryNo == dp.DeliveryNo).Count > 0)
                {
                    throw new FaultException(ErrCode.DuplicatedDeliveryNo.ToString());
                }
                var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "ForeignDeliveryPool");
                newDP.DocumentId = doc.Id;
            }

            return CreateNew(newDP, userId);
        }

        private void UpdateHeader(ForeignDeliveryPool header, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                if (QueryForObjs(GetObjQuery<ForeignDeliveryPool>(ctx), o => o.DeliveryNo == header.DeliveryNo && o.Id != header.Id).Count > 0)
                {
                    throw new FaultException(ErrCode.DuplicatedDeliveryNo.ToString());
                }

                var oldDP = GetById(GetObjQuery<ForeignDeliveryPool>(ctx), header.Id);

                if (oldDP == null)
                {
                    throw new FaultException(ErrCode.ForeignDeliveryPoolNotFound.ToString());
                }
                oldDP.DeliveryNo = header.DeliveryNo;
                oldDP.DeliveryType = header.DeliveryType;
                oldDP.IssueDate = header.IssueDate;
                oldDP.WarehouseProviderId = header.WarehouseProviderId;
                oldDP.WarehouseId = header.WarehouseId;
                oldDP.Comment = header.Comment;
                oldDP.ShipperId = header.ShipperId;
                oldDP.NotifyPartyId = header.NotifyPartyId;
                oldDP.ShippingPartyId = header.ShippingPartyId;
                oldDP.OnBoardDate = header.OnBoardDate;
                oldDP.VesselNo = header.VesselNo;
                oldDP.LoadingPlaceId = header.LoadingPlaceId;
                oldDP.LoadingPortId = header.LoadingPortId;
                oldDP.DischargePlaceId = header.DischargePlaceId;
                oldDP.DischargePortId = header.DischargePortId;
                oldDP.PackingStandard = header.PackingStandard;
                oldDP.CommodityId = header.CommodityId;
                oldDP.MarkNo = header.MarkNo;

                ctx.SaveChanges();
            }
        }

        private void AddLines(int dpId, IEnumerable<ForeignDeliveryPoolLine> lines, int userId)
        {
            var ctx = new SenLan2Entities(userId);
            foreach (var line in lines)
            {
                var newLine = new ForeignDeliveryPoolLine
                                  {
                                      CommodityTypeId = line.CommodityTypeId,
                                      SpecificationId = line.SpecificationId,
                                      OriginCountryId = line.OriginCountryId,
                                      NetWeight = line.NetWeight,
                                      GrossWeight = line.GrossWeight,
                                      ForeignDeliveryPoolId = dpId,
                                      PackingQuantity = line.PackingQuantity,
                                      Comment = line.Comment,
                                      BrandId = line.BrandId,
                                      PBNo = line.PBNo
                                  };

                Create(GetObjSet<ForeignDeliveryPoolLine>(ctx), newLine);
                ctx.SaveChanges();
            }
        }

        private void ModifyLines(IEnumerable<ForeignDeliveryPoolLine> modifiedLines, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var line in modifiedLines)
                {
                    var oldLine = GetById(GetObjQuery<ForeignDeliveryPoolLine>(ctx), line.Id);

                    oldLine.BrandId = line.BrandId;
                    oldLine.Comment = line.Comment;
                    oldLine.CommodityTypeId = line.CommodityTypeId;
                    oldLine.GrossWeight = line.GrossWeight;
                    oldLine.NetWeight = line.NetWeight;
                    oldLine.OriginCountryId = line.OriginCountryId;
                    oldLine.PBNo = line.PBNo;
                    oldLine.PackingQuantity = line.PackingQuantity;
                    oldLine.SpecificationId = line.SpecificationId;

                    ctx.SaveChanges();

                }
            }
        }

        private void DeleteLines(IEnumerable<ForeignDeliveryPoolLine> deletedLines)
        {
            using (var ctx = new SenLan2Entities())
            {
                foreach (var line in deletedLines)
                {
                    Delete(GetObjSet<ForeignDeliveryPoolLine>(ctx), line.Id);
                }
                ctx.SaveChanges();
            }
        }

        private void AddAttachments(int dpId, int docId, IEnumerable<Attachment> attachments, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var line in attachments)
                {
                    var newLine = new Attachment
                    {
                        DocumentId = docId,
                        RecordId = dpId,
                        Comment = line.Comment,
                        FileName = line.FileName
                    };

                    Create(GetObjSet<Attachment>(ctx), newLine);
                    ctx.SaveChanges();
                }
            }
        }

        private void DeleteAttachments(IEnumerable<Attachment> deletedAttachments)
        {
            using (var ctx = new SenLan2Entities())
            {
                foreach (var a in deletedAttachments)
                {
                    Delete(GetObjSet<Attachment>(ctx), a.Id);
                }
                ctx.SaveChanges();
            }
        }

        private void AddStorageDates(int id, IEnumerable<FDPStorageFeeSEDate> storageDates, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var line in storageDates)
                {
                    var s = new FDPStorageFeeSEDate
                                {
                                    StartDate = line.StartDate,
                                    EndDate = line.EndDate,
                                    Comment = line.Comment,
                                    DeliveryPoolId = id
                                };

                    Create(GetObjSet<FDPStorageFeeSEDate>(ctx), s);
                    ctx.SaveChanges();
                }
            }
        }

        private void DeletedStorageDates(IEnumerable<FDPStorageFeeSEDate> deletedStorageDates)
        {
            using (var ctx = new SenLan2Entities())
            {
                foreach (var line in deletedStorageDates)
                {
                    Delete(GetObjSet<FDPStorageFeeSEDate>(ctx), line.Id);
                    ctx.SaveChanges();
                }
            }
        }

        private void ModifyStorageDates(IEnumerable<FDPStorageFeeSEDate> modifiedLines, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var line in modifiedLines)
                {
                    var oldLine = GetById(GetObjQuery<FDPStorageFeeSEDate>(ctx), line.Id);
                    oldLine.StartDate = line.StartDate;
                    oldLine.EndDate = line.EndDate;
                    oldLine.Comment = line.Comment;
                }
                ctx.SaveChanges();
            }
        }

        private void CalculateStorageFee(int id)
        {
            List<FDPStorageFeeSEDate> storages;
            using (var ctx = new SenLan2Entities())
            {
                storages = QueryForObjs(GetObjQuery<FDPStorageFeeSEDate>(ctx), o => o.DeliveryPoolId == id).ToList();
            }
            UpdateStorageFee(storages);
        }

        private void UpdateStorageFee(List<FDPStorageFeeSEDate> storages)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    if (storages != null && storages.Count > 0)
                    {
                        int deliveryPoolId = storages[0].DeliveryPoolId;
                        var deliveryPool = QueryForObj(GetObjQuery<ForeignDeliveryPool>(ctx, new List<string> { "ForeignDeliveryPoolLines", "Commodity", "Warehouse" }), c => c.Id == deliveryPoolId);
                        decimal? totalGrossWeight = deliveryPool.TotalGrossWeight;

                        if (deliveryPool.Warehouse != null && deliveryPool.WarehouseId > 0)
                        {
                            foreach (FDPStorageFeeSEDate seDate in storages)
                            {
                                List<StorageFeeRule> feeRuleList = QueryForObjs(GetObjQuery<StorageFeeRule>(ctx), c => c.StartDate <= seDate.StartDate && c.EndDate >= seDate.StartDate && c.CommodityId == deliveryPool.CommodityId && c.WarehouseId == deliveryPool.WarehouseId).ToList();
                                FDPStorageFeeSEDate oldSEDate = QueryForObj(GetObjQuery<FDPStorageFeeSEDate>(ctx), c => c.Id == seDate.Id);
                                if (feeRuleList.Count > 0)
                                {
                                    StorageFeeRule feeRule = feeRuleList[0];
                                    if (seDate.EndDate.HasValue)
                                    {
                                        TimeSpan ts = seDate.EndDate.Value - seDate.StartDate.Value;
                                        int days = ts.Days + 1;
                                        decimal? storageFee = days * (feeRule.PricePerUnit ?? 0) * (totalGrossWeight ?? 0);

                                        oldSEDate.StorageFee = storageFee;
                                    }
                                    else
                                    {
                                        oldSEDate.StorageFee = 0;
                                    }
                                    oldSEDate.TransferFee = feeRule.TransferFee;
                                    oldSEDate.WarrantFee = feeRule.WarrantFee;

                                    ctx.SaveChanges();
                                }
                                else
                                {
                                    oldSEDate.StorageFee = 0;
                                    oldSEDate.TransferFee = 0;
                                    oldSEDate.WarrantFee = 0;
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            foreach (FDPStorageFeeSEDate seDate in storages)
                            {
                                FDPStorageFeeSEDate oldSEDate = QueryForObj(GetObjQuery<FDPStorageFeeSEDate>(ctx), c => c.Id == seDate.Id);
                                oldSEDate.StorageFee = 0;
                                oldSEDate.TransferFee = 0;
                                oldSEDate.WarrantFee = 0;
                                ctx.SaveChanges();
                            }
                        }
                    }
                }

            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<FDPStorageFeeDetailReport> GetDataList(string deliveryNo, int? warehouseId, DateTime? startDate, DateTime? endDate, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var list = new List<FDPStorageFeeDetailReport>();
                    List<ForeignDeliveryPool> poolList = QueryForObjs(GetObjQuery<ForeignDeliveryPool>(ctx, new List<string> { "FDPStorageFeeSEDates", "ForeignDeliveryPoolLines", "Warehouse", "Warehouse.Currency" }), c => c.DeliveryType == (int)DeliveryType.ExternalTDWW).ToList();

                    if (!string.IsNullOrEmpty(deliveryNo))
                    {
                        poolList = poolList.Where(c => c.DeliveryNo.Contains(deliveryNo)).ToList();
                    }
                    if (warehouseId != 0)
                    {
                        poolList = poolList.Where(c => c.WarehouseId == warehouseId.Value).ToList();
                    }

                    foreach (ForeignDeliveryPool pool in poolList)
                    {
                        if (pool.FDPStorageFeeSEDates.Count > 0)
                        {
                            List<FDPStorageFeeSEDate> seDateList = pool.FDPStorageFeeSEDates.ToList();
                            if (startDate.HasValue)
                            {
                                seDateList = seDateList.Where(c => c.StartDate >= startDate.Value).ToList();
                            }
                            if (endDate.HasValue)
                            {
                                seDateList = seDateList.Where(c => c.EndDate <= endDate.Value).ToList();
                            }

                            if (seDateList.Count > 0)
                            {
                                foreach (FDPStorageFeeSEDate seDate in seDateList)
                                {
                                    var report = new FDPStorageFeeDetailReport();
                                    decimal storageFee = seDate.StorageFee == null ? 0 : seDate.StorageFee.Value;
                                    decimal transferFee = seDate.TransferFee == null ? 0 : seDate.TransferFee.Value;
                                    decimal warrantFee = seDate.WarrantFee == null ? 0 : seDate.WarrantFee.Value;
                                    report.DeliveryNo = pool.DeliveryNo;
                                    report.GrossWeight = (pool.TotalGrossWeight == null ? "" : string.Format("{0:#,##0.0000}", pool.TotalGrossWeight.Value));
                                    report.NetWeight = (pool.TotalNetWeight == null ? "" : string.Format("{0:#,##0.0000}", pool.TotalNetWeight.Value));
                                    report.Bundle = (pool.TotalPackingQuantity == null ? "" : string.Format("{0:#,##0.0000}", pool.TotalPackingQuantity));
                                    report.WarehouseName = (pool.Warehouse == null ? "" : pool.Warehouse.Name);
                                    report.StartDate = seDate.StartDate;
                                    report.EndDate = seDate.EndDate;
                                    report.StorageFee = string.Format("{0:#,##0.00}", storageFee);
                                    report.TransferFee = string.Format("{0:#,##0.00}", transferFee);
                                    report.WarrantFee = string.Format("{0:#,##0.00}", warrantFee);
                                    decimal totalFee = warrantFee + transferFee + storageFee;
                                    report.TotalFee = string.Format("{0:#,##0.00}", totalFee);
                                    report.Comment = pool.Comment;
                                    report.CurrencyName = (pool.Warehouse == null ? "" : pool.Warehouse.Currency == null ? "" : pool.Warehouse.Currency.Name);
                                    list.Add(report);
                                }
                            }
                        }
                    }

                    return list;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<FDPStorageFeeSEDate> GetStorageDates(int fdpId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<FDPStorageFeeSEDate>(ctx), o => o.DeliveryPoolId == fdpId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void CalculateSums(int id)
        {
            using (var ctx = new SenLan2Entities())
            {
                var lines =
                    QueryForObjs(GetObjQuery<ForeignDeliveryPoolLine>(ctx), o => o.ForeignDeliveryPoolId == id).ToList();

                var header = GetById(GetObjQuery<ForeignDeliveryPool>(ctx), id);
                header.TotalGrossWeight = lines.Sum(o => o.GrossWeight);
                header.TotalNetWeight = lines.Sum(o => o.NetWeight);
                header.TotalPackingQuantity = lines.Sum(o => o.PackingQuantity);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 控件编辑属性设置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ForeignDeliveryPoolEnableProperty SetElementsEnableProperty(int id)
        {
            try
            {
                var fdpep = new ForeignDeliveryPoolEnableProperty();
                using (var ctx = new SenLan2Entities())
                {
                    //如果有提单和提单池单据关联，则提单池单据的金属不可以编辑
                    if (QueryForObjs(GetObjQuery<Delivery>(ctx), d => d.FDPId == id).Any())
                    {
                        fdpep.IsCommodityEnable = false;
                        fdpep.IsLineDeleteBtnEnable = false;
                        fdpep.IsLineNewBtnEnable = false;
                    }
                    //如果有多行也不能修改金属
                    if (QueryForObjs(GetObjQuery<ForeignDeliveryPoolLine>(ctx), fdpl => fdpl.ForeignDeliveryPoolId == id).Any())
                    {
                        fdpep.IsCommodityEnable = false;
                    }
                    return fdpep;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }

}
