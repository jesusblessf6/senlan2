using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Utility.ErrorManagement;
using Services.Physical.Contracts;
using DBEntity.EnableProperty;
using Services.Helper.DeliveryNoFormulaHelper;

namespace Services.Physical.WarehouseOuts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarehouseOutService" in code, svc and config file together.
    public class WarehouseOutService : BaseService<WarehouseOut>, IWarehouseOutService
    {
        #region IWarehouseOutService Members

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
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        WarehouseOutLine line =
                            QueryForObj(
                                GetObjQuery<WarehouseOutLine>(ctx, new List<string> { "WarehouseOutDeliveryPersons","WarehouseOut" }),
                                c => c.Id == id);
                        foreach (WarehouseOutDeliveryPerson deliveryPerson in line.WarehouseOutDeliveryPersons)
                        {
                            if (!deliveryPerson.IsDeleted)
                            {
                                DeleteDeliveryPerson(userId, deliveryPerson.Id);
                            }   
                        }
                        DeleteLine(userId, id);
                        var qs = new QuotaService();
                        qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(line.WarehouseOut.QuotaId, userId);

                        //更改采购销售批次对应表
                        var relService = new PSQuotaRelService();
                        relService.SetPSQuotaRel(line.WarehouseOut.QuotaId, userId);

                        //Update the Verified Status
                        UpdateVerifiedStatus(line.WarehouseOutId);

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

        public void AddNewWarehouseOutLine(WarehouseOut warehouseOut, WarehouseOutLine outLine, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (warehouseOut.Id > 0)
                    {
                        Update(warehouseOut);
                    }
                    else
                    {
                        CreateNew(warehouseOut, userId);
                    }
                    Create(GetObjSet<WarehouseOutLine>(ctx), outLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }


        public void UpdateWarehosueOut(WarehouseOut warehouseOut, WarehouseOutLine outLine, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    WarehouseOutLine oldWarehouseOutLine = QueryForObj(GetObjQuery<WarehouseOutLine>(ctx),
                                                                       o => o.Id == outLine.Id);
                    oldWarehouseOutLine.BrandId = outLine.BrandId;
                    oldWarehouseOutLine.Comment = outLine.Comment;
                    oldWarehouseOutLine.CommodityTypeId = outLine.CommodityTypeId;
                    oldWarehouseOutLine.IsDeleted = outLine.IsDeleted;
                    oldWarehouseOutLine.IsDraft = outLine.IsDraft;
                    oldWarehouseOutLine.IsVerified = outLine.IsVerified;
                    oldWarehouseOutLine.PackingQuantity = outLine.PackingQuantity;
                    oldWarehouseOutLine.Quantity = outLine.Quantity;
                    oldWarehouseOutLine.SpecificationId = outLine.SpecificationId;
                    oldWarehouseOutLine.VerifiedQuantity = outLine.VerifiedQuantity;
                    oldWarehouseOutLine.WarehouseInLineId = outLine.WarehouseInLineId;
                    oldWarehouseOutLine.WarehouseOutId = outLine.WarehouseOutId;
                    oldWarehouseOutLine.WarehouseOutDeliveryPersons = outLine.WarehouseOutDeliveryPersons;
                    Update(warehouseOut);
                    Update(GetObjSet<WarehouseOutLine>(ctx), oldWarehouseOutLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        private Inventory GetInventoryByParameters(SenLan2Entities ctx, int bpID, int commodityID, int commodityTypeID,
                                                   int brandID, int specificationID, string pbNo, int warehouseID,
                                                   bool isWarrant)
        {
            try
            {
                Inventory inventory = QueryForObj(GetObjQuery<Inventory>(ctx),
                                                  c => c.OwnerPartyId == bpID && c.BrandId == brandID &&
                                                       c.CommodityId == commodityID &&
                                                       c.CommodityTypeId == commodityTypeID &&
                                                       c.SpecificationId == specificationID &&
                                                       c.WarehouseId == warehouseID && c.PBNo == pbNo &&
                                                       c.IsWarehouseWarranty == isWarrant);
                return inventory;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #region 增删改

        public void CreateDocument(int userId, WarehouseOut header, List<WarehouseOutLine> addedLines,
                                   List<WarehouseInLine> inLines, int quotaID)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var qs = new QuotaService();
                    var relService = new PSQuotaRelService();
                    header.WarehouseOutNo = DeliveryNoFormulaHelper.GetWarehouseNo(userId);
                    CreateHeader(userId, header);
                    UpdateSystemParameter(userId, header);
                    foreach (WarehouseOutLine line in addedLines)
                    {
                        CreateLine(userId, header, line, inLines, quotaID);
                    }
                    qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(header.QuotaId, userId);
                    
                    //更改采购销售批次对应表
                    relService.SetPSQuotaRel(header.QuotaId, userId);

                    //Update the Verified Status
                    UpdateVerifiedStatus(header.Id);

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

        private void UpdateVerifiedStatus(int warehouseOutId)
        {
            using (var ctx = new SenLan2Entities())
            {
                var lines = QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx), o => o.WarehouseOutId == warehouseOutId);
                var wo = GetById(GetObjQuery<WarehouseOut>(ctx), warehouseOutId);
                if (wo != null)
                {
                    wo.IsVerified = lines.Count > 0 && lines.All(o => o.IsVerified == true);
                }
                ctx.SaveChanges();
            }
        }

        public void UpdateDocument(int userId, WarehouseOut header, List<WarehouseOutLine> addedLines,
                                   List<WarehouseOutLine> updatedLines, List<WarehouseOutLine> deletedLines,
                                   List<WarehouseInLine> inLines, int quotaID)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(userId, header);
                    foreach (WarehouseOutLine line in addedLines)
                    {
                        CreateLine(userId, header, line, inLines, quotaID);
                    }
                    foreach (WarehouseOutLine line in updatedLines)
                    {
                        UpdateLine(userId, line, inLines, quotaID);
                        foreach (WarehouseOutDeliveryPerson deliveryPerson in line.WarehouseOutDeliveryPersons)
                        {
                            UpdateDeliveryPerson(userId, line, deliveryPerson);
                        }
                    }
                    foreach (WarehouseOutLine line in deletedLines)
                    {
                        DeleteLine(userId, line.Id);
                    }

                    var qs = new QuotaService();
                    qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(header.QuotaId, userId);

                    //更改采购销售批次对应表
                    var relService = new PSQuotaRelService();
                    relService.SetPSQuotaRel(header.QuotaId, userId);

                    //Update the Verified Status
                    UpdateVerifiedStatus(header.Id);

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
        /// 新增入库
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        private void CreateHeader(int userId, WarehouseOut header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<WarehouseOut>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void UpdateSystemParameter(int userId, WarehouseOut header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<SystemParameter> systemParameterList = QueryForObjs(GetObjQuery<SystemParameter>(ctx), c => c.IsDeleted == false).ToList();
                    if (systemParameterList.Count > 0)
                    {
                        SystemParameter systemParameter = systemParameterList[0];
                        systemParameter.WarehouseOutNo = header.WarehouseOutNo;
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

        /// <summary>
        /// 新增出库行 更新入库信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="outLine"></param>
        /// <param name="inLines"> </param>
        /// <param name="quotaID"> </param>
        private void CreateLine(int userId, WarehouseOut header, WarehouseOutLine outLine, IEnumerable<WarehouseInLine> inLines,
                                int quotaID)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<WarehouseInLine> lines = inLines.Where(c => c.Id == outLine.WarehouseInLineId).ToList();
                    if (lines.Count > 0)
                    {
                        WarehouseInLine inLine = lines[0];
                        bool isWW = inLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                                    inLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                        Inventory inventory = GetInventoryByParameters(ctx,
                                                                       inLine.DeliveryLine.Delivery.Quota.Contract.
                                                                           InternalCustomerId ?? 0,
                                                                       inLine.DeliveryLine.Delivery.Quota.CommodityId ??
                                                                       0, (int)inLine.CommodityTypeId,
                                                                       (int)inLine.BrandId,
                                                                       (int)inLine.SpecificationId, inLine.PBNo,
                                                                       inLine.WarehouseIn.WarehouseId, isWW);
                        if (inventory != null)
                        {
                            if (inLine.IsPBCleared != null && (bool)inLine.IsPBCleared)
                            {
                                decimal onlyQty = GetWarehouseInLineOnlyQty(userId, inLine.Id, outLine);
                                inventory.Quantity = inventory.Quantity - onlyQty;
                            }
                            else
                            {
                                inventory.Quantity -= outLine.VerifiedQuantity;
                            }
                            Update(GetObjSet<Inventory>(ctx), inventory);
                        }
                        WarehouseInLine oldInLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx),
                                                                c => c.Id == inLine.Id);
                        oldInLine.IsPBCleared = inLine.IsPBCleared;
                        Update(GetObjSet<WarehouseInLine>(ctx), oldInLine);
                    }

                    #region 更改批次货运状态

                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaID);
                    decimal systemParameter = GetSystemParameter(ctx);
                    decimal totalDeliveryQty = GetAllQtyByQuotaID(ctx, quotaID);
                    decimal totalWarehouseOutQty = GetAllWarehouseOutQtyByQuotaID(ctx, quotaID);
                    totalWarehouseOutQty += (outLine.VerifiedQuantity == null ? 0 : (decimal)outLine.VerifiedQuantity);
                    decimal totalQty = totalDeliveryQty + totalWarehouseOutQty;

                    if (quota.Quantity != null && quota.Quantity > 0)
                    {
                        var qty = (decimal)quota.Quantity;
                        if (qty > 0)
                        {
                            if (Math.Abs((qty - totalQty) / qty) <= Math.Abs(systemParameter / 100))
                            {
                                quota.DeliveryStatus = true;
                            }
                            else
                            {
                                quota.DeliveryStatus = false;
                            }
                        }
                    }
                    Update(GetObjSet<Quota>(ctx), quota);

                    #endregion

                    var line = new WarehouseOutLine
                                   {
                                       BrandId = outLine.BrandId,
                                       Comment = outLine.Comment,
                                       CommodityTypeId = outLine.CommodityTypeId,
                                       IsVerified = outLine.IsVerified,
                                       PackingQuantity = outLine.PackingQuantity,
                                       Quantity = outLine.Quantity,
                                       SpecificationId = outLine.SpecificationId,
                                       VerifiedQuantity = outLine.VerifiedQuantity,
                                       WarehouseInLineId = outLine.WarehouseInLineId,
                                       WarehouseOutId = header.Id
                                   };
                    Create(GetObjSet<WarehouseOutLine>(ctx), line);
                    ctx.SaveChanges();

                    foreach (WarehouseOutDeliveryPerson deliveryPerson in outLine.WarehouseOutDeliveryPersons)
                    {
                        CreateDeliveryPerson(userId, line, deliveryPerson);
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void CreateDeliveryPerson(int userId, WarehouseOutLine outLine,
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
                                         WarehouseOutLineId = outLine.Id,
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
        /// 更新入库
        /// </summary>
        /// <param name="userId"> </param>
        /// <param name="header"></param>
        private void UpdateHeader(int userId, WarehouseOut header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    WarehouseOut warehouseOut = QueryForObj(GetObjQuery<WarehouseOut>(ctx), c => c.Id == header.Id);
                    warehouseOut.Comment = header.Comment;
                    warehouseOut.QuotaId = header.QuotaId;
                    warehouseOut.WarehouseId = header.WarehouseId;
                    warehouseOut.WarehouseOutDate = header.WarehouseOutDate;
                    warehouseOut.ActualDeliveryBPId = header.ActualDeliveryBPId;
                    Update(GetObjSet<WarehouseOut>(ctx), warehouseOut);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新出库行和对应的库存信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="outLine"></param>
        /// <param name="warehouseInLines"> </param>
        /// <param name="quotaID"> </param>
        public void UpdateLine(int userId, WarehouseOutLine outLine,
                                IEnumerable<WarehouseInLine> warehouseInLines, int quotaID)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    WarehouseOutLine oldOutLine =
                        QueryForObj(GetObjQuery<WarehouseOutLine>(ctx, new List<string> { "WarehouseOut" }),
                                    c => c.Id == outLine.Id);
                    WarehouseInLine oldLine =
                        QueryForObj(
                            GetObjQuery<WarehouseInLine>(ctx,
                                                         new List<string>
                                                             {
                                                                 "WarehouseIn",
                                                                 "WarehouseIn.Warehouse",
                                                                 "Brand",
                                                                 "DeliveryLine.Delivery",
                                                                 "DeliveryLine.Delivery.Quota.Contract.InternalCustomer",
                                                                 "DeliveryLine.Delivery.Quota.Contract.BusinessPartner",
                                                                 "DeliveryLine.Delivery.Quota.Commodity",
                                                                 "WarehouseOutLines"
                                                             }),
                            c => c.Id == oldOutLine.WarehouseInLineId);//没更新之前出库对应的入库
                    bool isWW = oldLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                                oldLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                    Inventory oldInventory = GetInventoryByParameters(ctx,
                                                                      oldLine.DeliveryLine.Delivery.Quota.Contract.
                                                                          InternalCustomerId ?? 0,
                                                                      oldLine.DeliveryLine.Delivery.Quota.CommodityId ??
                                                                      0, (int)oldLine.CommodityTypeId,
                                                                      (int)oldLine.BrandId,
                                                                      (int)oldLine.SpecificationId, oldLine.PBNo,
                                                                      oldLine.WarehouseIn.WarehouseId, isWW);//没更新之前的库存
                    if (oldInventory != null)
                    {
                        if (oldLine.IsPBCleared != null && (bool)oldLine.IsPBCleared)
                        {
                            decimal onlyQty = GetWarehouseInLineOnlyQty(userId, oldLine.Id, oldOutLine);
                            oldInventory.Quantity += (onlyQty + oldOutLine.VerifiedQuantity.Value);
                        }
                        else
                        {
                            oldInventory.Quantity += oldOutLine.VerifiedQuantity;
                        }
                    }
                    oldLine.IsPBCleared = false;
                    Update(GetObjSet<WarehouseInLine>(ctx), oldLine);
                    List<WarehouseInLine> inLines =
                        warehouseInLines.Where(c => c.Id == outLine.WarehouseInLineId).ToList();
                    if (inLines.Count > 0)
                    {
                        WarehouseInLine line = inLines[0];
                        bool isWarrant = line.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                                         line.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                        Inventory inventory = GetInventoryByParameters(ctx,
                                                                       line.DeliveryLine.Delivery.Quota.Contract.
                                                                           InternalCustomerId ?? 0,
                                                                       line.DeliveryLine.Delivery.Quota.CommodityId ?? 0,
                                                                       (int)line.CommodityTypeId, (int)line.BrandId,
                                                                       (int)line.SpecificationId, line.PBNo,
                                                                       line.WarehouseIn.WarehouseId, isWarrant);
                        if (inventory != null)
                        {
                            if (oldInventory.Id == inventory.Id)//更新前后库存是同一条
                            {
                                if (line.IsPBCleared != null && (bool)line.IsPBCleared)
                                {
                                    decimal onlyQty = GetWarehouseInLineOnlyQty(userId, line.Id, outLine);
                                    oldInventory.Quantity = oldInventory.Quantity - outLine.VerifiedQuantity.Value - onlyQty;
                                }
                                else
                                {
                                    oldInventory.Quantity -= outLine.VerifiedQuantity;
                                }
                            }
                            else
                            {
                                if (line.IsPBCleared != null && (bool)line.IsPBCleared)
                                {
                                    inventory.Quantity = inventory.Quantity - line.VerifiedQuantity;
                                }
                                else
                                {
                                    inventory.Quantity -= outLine.VerifiedQuantity;
                                }
                                Update(GetObjSet<Inventory>(ctx), inventory);
                            }
                        }
                        WarehouseInLine updatedInLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx),
                                                                    c => c.Id == line.Id);
                        updatedInLine.IsPBCleared = line.IsPBCleared;
                        if (oldInventory != null)
                        {
                            Update(GetObjSet<Inventory>(ctx), oldInventory);
                        }
                        Update(GetObjSet<WarehouseInLine>(ctx), updatedInLine);
                    }

                    #region 更改批次货运状态

                    Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == oldOutLine.WarehouseOut.QuotaId);
                    decimal systemParameter = GetSystemParameter(ctx);
                    decimal oldDeliveryQty = GetAllQtyByQuotaID(ctx, oldOutLine.WarehouseOut.QuotaId);
                    decimal oldWarehouseOutQty = GetAllWarehouseOutQtyByQuotaID(ctx, oldOutLine.WarehouseOut.QuotaId);
                    decimal oldQty = (oldOutLine.VerifiedQuantity == null ? 0 : (decimal)oldOutLine.VerifiedQuantity);
                    oldWarehouseOutQty -= oldQty;
                    decimal totalQty = oldDeliveryQty + oldWarehouseOutQty;

                    if (oldQuota.Quantity != null && oldQuota.Quantity > 0)
                    {
                        var quotaQty = (decimal)oldQuota.Quantity;
                        if (quotaQty > 0)
                        {
                            if (Math.Abs((quotaQty - totalQty) / quotaQty) <= Math.Abs(systemParameter / 100))
                            {
                                oldQuota.DeliveryStatus = true;
                            }
                            else
                            {
                                oldQuota.DeliveryStatus = false;
                            }
                        }
                    }
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == quotaID);
                    decimal deliveryQty = GetAllQtyByQuotaID(ctx, quotaID);
                    decimal warehouseOutQty = GetAllWarehouseOutQtyByQuotaID(ctx, quotaID);
                    decimal qty = (outLine.VerifiedQuantity == null ? 0 : (decimal)outLine.VerifiedQuantity);

                    if (oldOutLine.WarehouseOut.QuotaId == quotaID)
                    {
                        warehouseOutQty = warehouseOutQty - oldQty + qty;
                    }
                    else
                    {
                        warehouseOutQty += qty;
                    }
                    decimal resultQty = deliveryQty + warehouseOutQty;
                    if (quota.Quantity != null && quota.Quantity > 0)
                    {
                        var quantity = (decimal)quota.Quantity;
                        if (quantity > 0)
                        {
                            if (Math.Abs((quantity - resultQty) / quantity) <= Math.Abs(systemParameter / 100))
                            {
                                quota.DeliveryStatus = true;
                            }
                            else
                            {
                                quota.DeliveryStatus = false;
                            }
                        }
                    }
                    Update(GetObjSet<Quota>(ctx), quota);

                    #endregion

                    oldOutLine.BrandId = outLine.BrandId;
                    oldOutLine.Comment = outLine.Comment;
                    oldOutLine.CommodityTypeId = outLine.CommodityTypeId;
                    oldOutLine.IsVerified = outLine.IsVerified;
                    oldOutLine.PackingQuantity = outLine.PackingQuantity;
                    oldOutLine.Quantity = outLine.Quantity;
                    oldOutLine.SpecificationId = outLine.SpecificationId;
                    oldOutLine.VerifiedQuantity = outLine.VerifiedQuantity;
                    oldOutLine.WarehouseInLineId = outLine.WarehouseInLineId;
                    oldOutLine.WarehouseOutId = outLine.WarehouseOutId;
                    Update(GetObjSet<WarehouseOutLine>(ctx), oldOutLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void UpdateDeliveryPerson(int userId, WarehouseOutLine outLine,
                                          WarehouseOutDeliveryPerson deliveryPerson)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (deliveryPerson.Id <= 0)
                    {
                        CreateDeliveryPerson(userId, outLine, deliveryPerson);
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
                        oldDeliveryPerson.WarehouseOutLineId = deliveryPerson.WarehouseOutLineId;
                        oldDeliveryPerson.IsDeleted = deliveryPerson.IsDeleted;
                        oldDeliveryPerson.Tel = deliveryPerson.Tel;
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
        /// 删除出库行
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        public void DeleteLine(int userId, int id)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //1. 由于出库没有后续单据，不需要关联单据的查询
                //2. 是否需要删除出库
                WarehouseOutLine wol =
                    QueryForObj(
                        GetObjQuery<WarehouseOutLine>(ctx,
                                                      new List<string>
                                                          {
                                                              "WarehouseOut",
                                                              "WarehouseOut.Quota",
                                                              "WarehouseInLine",
                                                              "WarehouseInLine.WarehouseIn",
                                                              "WarehouseInLine.DeliveryLine",
                                                              "WarehouseInLine.DeliveryLine.Delivery",
                                                              "WarehouseInLine.DeliveryLine.Delivery.Quota.Contract",
                                                              "WarehouseInLine.WarehouseOutLines"
                                                          }),
                        w => w.Id == id);

                #region 更改批次货运状态

                Quota quota =
                    QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Deliveries", "Deliveries.DeliveryLines" }),
                                c => c.Id == wol.WarehouseOut.QuotaId);
                decimal systemParameter = GetSystemParameter(ctx);
                decimal allDeliveryQty = GetAllQtyByQuotaID(ctx, wol.WarehouseOut.QuotaId);
                decimal qty1 = GetAllWarehouseOutQtyByQuotaID(ctx, wol.WarehouseOut.QuotaId);
                decimal qty2 = (wol.VerifiedQuantity == null ? 0 : (decimal)wol.VerifiedQuantity);
                decimal warehouseOutQty = qty1 - qty2;
                decimal allQty = allDeliveryQty + warehouseOutQty; //对应所有发货单的数量+出库数量
                if (quota.Quantity != null && quota.Quantity > 0)
                {
                    var qty = (decimal)quota.Quantity;

                    if (qty > 0)
                    {
                        if (Math.Abs((qty - allQty) / qty) <= Math.Abs(systemParameter / 100))
                        {
                            quota.DeliveryStatus = true;
                        }
                        else
                        {
                            quota.DeliveryStatus = false;
                        }
                    }
                }

                #endregion

                wol.IsDeleted = true;
                if (
                    QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx),
                                 w => w.WarehouseOutId == wol.WarehouseOutId && w.Id != wol.Id).Count == 0)
                {
                    wol.WarehouseOut.IsDeleted = true;
                }
                //3. 更新库存
                bool isWW = wol.WarehouseInLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                            wol.WarehouseInLine.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                Inventory inv = GetInventoryByParameters(ctx,
                                                         wol.WarehouseInLine.DeliveryLine.Delivery.Quota.Contract.
                                                             InternalCustomerId ?? 0,
                                                         wol.WarehouseOut.Quota.CommodityId ?? 0, wol.CommodityTypeId,
                                                         wol.BrandId, wol.SpecificationId,
                                                         wol.WarehouseInLine.PBNo,
                                                         wol.WarehouseInLine.WarehouseIn.WarehouseId, isWW);
                if (inv != null)
                {
                    if (wol.WarehouseInLine.IsPBCleared.Value)
                    {
                        wol.WarehouseInLine.IsPBCleared = false;
                       //List<WarehouseOutLine> lines = wol.WarehouseInLine.WarehouseOutLines.Where(c => !c.IsDeleted && c.Id != wol.Id).ToList();
                        inv.Quantity += (inv.Quantity + (wol.WarehouseInLine.VerifiedQuantity - wol.WarehouseInLine.WarehouseOutLines.Where(c => !c.IsDeleted).Sum(c => c.VerifiedQuantity)));
                    }
                    else
                    {
                        inv.Quantity += wol.VerifiedQuantity;
                    }
                }

                ctx.SaveChanges();
            }
        }

        public void DeleteDeliveryPerson(int userId, int id)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                WarehouseOutDeliveryPerson deliveryPerson = QueryForObj(GetObjQuery<WarehouseOutDeliveryPerson>(ctx),
                                                                        c => c.Id == id);
                deliveryPerson.IsDeleted = true;
                ctx.SaveChanges();
            }
        }

        #endregion
        //入库剩余数量
        private decimal GetWarehouseInLineOnlyQty(int userId, int id, WarehouseOutLine currentOutLine)
        {
            decimal onlyQty;
            using (var ctx = new SenLan2Entities(userId))
            {
                WarehouseInLine inLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx, new List<string> { "WarehouseOutLines" }), c => c.Id == id);
                decimal outLineQty = 0;
                if (inLine.WarehouseOutLines.Count > 0)
                {
                    foreach (WarehouseOutLine outLine in inLine.WarehouseOutLines)
                    {
                        if (!outLine.IsDeleted)
                        {
                            if (outLine.Id == currentOutLine.Id)
                            {
                                outLineQty += currentOutLine.VerifiedQuantity.Value;
                            }
                            else
                            {
                                outLineQty += outLine.VerifiedQuantity.Value;
                            }

                        }
                    }
                }

                onlyQty = inLine.VerifiedQuantity.Value - outLineQty;
            }
            return onlyQty;
        }

        #region 更改批次货运状态

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private decimal GetSystemParameter(SenLan2Entities ctx)
        {
            List<SystemParameter> sList =
                QueryForObjs(GetObjQuery<SystemParameter>(ctx), o => o.IsDeleted == false).ToList();
            if (sList.Count > 0)
            {
                SystemParameter sp = sList[0];
                return sp.Delivery2Quota;
            }

            return 0;
        }

        /// <summary>
        /// 根据批次ID获取批次对应发货单的数量
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="quotaID"></param>
        /// <returns></returns>
        private decimal GetAllQtyByQuotaID(SenLan2Entities ctx, int quotaID)
        {
            decimal totalDeliveryQty = 0;
            Quota quota =
                QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Deliveries", "Deliveries.DeliveryLines" }),
                            c => c.Id == quotaID);
            foreach (Delivery d in quota.Deliveries)
            {
                totalDeliveryQty +=
                    d.DeliveryLines.Where(o => o.IsDeleted == false).Sum(
                        c => c.VerifiedWeight == null ? 0 : (decimal)c.VerifiedWeight);
            }

            return totalDeliveryQty;
        }

        /// <summary>
        /// 根据批次ID获取所有出库行数量
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="quotaID"></param>
        /// <returns></returns>
        private decimal GetAllWarehouseOutQtyByQuotaID(SenLan2Entities ctx, int quotaID)
        {
            decimal totalQty = 0;
            Quota quota =
                QueryForObj(
                    GetObjQuery<Quota>(ctx, new List<string> { "WarehouseOuts", "WarehouseOuts.WarehouseOutLines" }),
                    c => c.Id == quotaID);
            foreach (WarehouseOut o in quota.WarehouseOuts)
            {
                if (!o.IsDeleted)
                {
                    totalQty +=
                        o.WarehouseOutLines.Sum(c => c.VerifiedQuantity == null ? 0 : (decimal)c.VerifiedQuantity);
                }
            }

            return totalQty;
        }

        #endregion

        /// <summary>
        /// 出库的编辑逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WarehouseOutEnableProperty SetElementsEnableProperty(int id)
        {
            var woep = new WarehouseOutEnableProperty();
            try
            {
                woep.IsQuotaEnable = false;
                woep.IsWarehouseEnable = false;
                return woep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
