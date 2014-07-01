using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Services.Base;
using Utility.ErrorManagement;
using Utility.Misc;
using Services.Physical.Contracts;
using Services.Helper.DeliveryLineStatusHelper;

namespace Services.Physical.WarehouseIns
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarehouseInService" in code, svc and config file together.
    public class WarehouseInService : BaseService<WarehouseIn>, IWarehouseInService
    {
        #region IWarehouseInService Members

        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    WarehouseInLine inLine;
                    using (var ctx = new SenLan2Entities())
                    {
                         inLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx, new List<string> { "WarehouseIn" }), o => o.Id == id);
                    }
                    DeleteLine(userId, id, inLine.WarehouseIn);

                    //Update the Verified Status
                    UpdateVerifiedStatus(inLine.WarehouseInId);

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

        public int GetWarehouseInLineAllCount()
        {
            try
            {
                var b = new BaseService<WarehouseInLine>();
                int allCount = b.GetAllCount();
                return allCount;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public int GetWarehouseInLineCount(string predicate, List<object> parameters)
        {
            try
            {
                var b = new BaseService<WarehouseInLine>();
                int allCount = b.GetCount(predicate, parameters);
                return allCount;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<WarehouseInLine> SelectByRangeWithOrderW(string predicate, List<object> parameters, SortCol sortcol,
                                                             int from, int to, List<string> a)
        {
            try
            {
                var b = new BaseService<WarehouseInLine>();
                List<WarehouseInLine> lines =
                    b.SelectByRangeWithOrder(predicate, parameters, sortcol, from, to, a).ToList();
                return lines;
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

        public void CreateDocument(int userId, WarehouseIn header, List<WarehouseInLine> addedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateHeader(userId, header);
                    foreach (WarehouseInLine line in addedLines)
                    {
                        CreateLine(userId, header, line);
                    }

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

        public void UpdateVerifiedStatus(int id)
        {
            using (var ctx = new SenLan2Entities())
            {
                var lines = QueryForObjs(GetObjQuery<WarehouseInLine>(ctx), o => o.WarehouseInId == id);
                var wi = GetById(GetObjQuery<WarehouseIn>(ctx), id);
                if (wi != null)
                {
                    wi.IsVerified = lines.All(o => o.IsVerified == true);
                }
                ctx.SaveChanges();
            }
        }

        public void UpdateDocument(int userId, WarehouseIn header, List<WarehouseInLine> addedLines,
                                   List<WarehouseInLine> updatedLines, List<WarehouseInLine> deletedLines, List<WarehouseInLine> allLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    WarehouseIn oldWarehouseIn;
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        oldWarehouseIn = QueryForObj(GetObjQuery<WarehouseIn>(ctx), c => c.Id == header.Id);
                    }
                    UpdateHeader(userId, header);

                    if (oldWarehouseIn.WarehouseId != header.WarehouseId)
                    {
                        updatedLines.Clear();
                        updatedLines = allLines;
                    }

                    foreach (WarehouseInLine line in addedLines)
                    {
                        CreateLine(userId, header, line);
                    }
                    foreach (WarehouseInLine line in updatedLines)
                    {
                        UpdateLine(userId, header, line, oldWarehouseIn);

                    }
                    foreach (WarehouseInLine line in deletedLines)
                    {
                        DeleteLine(userId, line.Id, oldWarehouseIn);
                    }

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
        /// 入库的编辑逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WarehouseInEnableProperty SetElementsEnableProperty(int id)
        {
            var wiep = new WarehouseInEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //如果存在入库行已经有出库不允许修改仓库
                    ICollection<WarehouseInLine> wils = QueryForObjs(GetObjQuery<WarehouseInLine>(ctx),
                                                                     wil => wil.WarehouseInId == id);
                    foreach (WarehouseInLine wil in wils)
                    {
                        WarehouseInLine wil1 = wil;
                        if (
                            QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx), wol => wol.WarehouseInLineId == wil1.Id).
                                Count > 0)
                        {
                            wiep.IsWarehouseEnable = false;
                            return wiep;
                        }
                    }
                    return wiep;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 新增入库
        /// </summary>
        /// <param name="userId"> </param>
        /// <param name="header"></param>
        private void CreateHeader(int userId, WarehouseIn header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<WarehouseIn>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 新增入库行 更新入库信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="inLine"> </param>
        private void CreateLine(int userId, WarehouseIn header, WarehouseInLine inLine)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    DeliveryLine deliveryLine =
                        QueryForObj(
                            GetObjQuery<DeliveryLine>(ctx,
                                                      new List<string> { "WarehouseInLines", "Delivery", "Delivery.Quota.Contract" }),
                            c => c.Id == inLine.DeliveryLineId);

                    bool isWW = deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                                deliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                    Inventory inventory = GetInventoryByParameters(ctx,
                                                                   deliveryLine.Delivery.Quota.Contract.
                                                                       InternalCustomerId ?? 0,
                                                                   deliveryLine.Delivery.Quota.CommodityId ?? 0,
                                                                   (int)inLine.CommodityTypeId, (int)inLine.BrandId,
                                                                   (int)inLine.SpecificationId, inLine.PBNo,
                                                                   header.WarehouseId, isWW);
                    if (inventory != null)
                    {
                        inventory.Quantity += inLine.VerifiedQuantity;
                    }
                    else
                    {
                        inventory = new Inventory
                                        {
                                            CommodityId = deliveryLine.Delivery.Quota.CommodityId ?? 0,
                                            SpecificationId = inLine.SpecificationId,
                                            IsWarehouseWarranty = isWW,
                                            PBNo = inLine.PBNo,
                                            WarehouseId = header.WarehouseId,
                                            OwnerPartyId =
                                                deliveryLine.Delivery.Quota.Contract.InternalCustomerId ?? 0,
                                            CommodityTypeId = Convert.ToInt32(inLine.CommodityTypeId),
                                            BrandId = Convert.ToInt32(inLine.BrandId),
                                            Quantity = inLine.VerifiedQuantity
                                        };

                        Create(GetObjSet<Inventory>(ctx), inventory);
                    }

                    //#region 更改提单货运状态

                    //decimal systemParameter = GetSystemParameter(ctx);
                    ////DeliveryLine deliveryLine =
                    ////    QueryForObj(
                    ////        GetObjQuery<DeliveryLine>(ctx,
                    ////                                  new List<string>
                    ////                                      {"WarehouseInLines", "Delivery", "Delivery.Quota.Contract"}),
                    ////        c => c.Id == inLine.DeliveryLineId);
                    //decimal warehouseInQty = GetWarehouseInLineQtyByDeliveryLine(deliveryLine);
                    //decimal qty;
                    //if (deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                    //    deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL) //内贸提单
                    //{
                    //    qty = deliveryLine.VerifiedWeight == null ? 0 : (decimal)deliveryLine.VerifiedWeight;
                    //}
                    //else
                    //{
                    //    qty = deliveryLine.NetWeight == null ? 0 : (decimal)deliveryLine.NetWeight;
                    //}
                    //warehouseInQty = warehouseInQty +
                    //                 (inLine.VerifiedQuantity == null ? 0 : (decimal)inLine.VerifiedQuantity);

                    //if (qty > 0)
                    //{
                    //    if (Math.Abs((qty - warehouseInQty) / qty) <= Math.Abs(systemParameter / 100))
                    //    {
                    //        deliveryLine.DeliveryStatus = true;
                    //    }
                    //    else
                    //    {
                    //        deliveryLine.DeliveryStatus = false;
                    //    }
                    //}
                    //Update(GetObjSet<DeliveryLine>(ctx), deliveryLine);

                    //#endregion

                    //如果是内贸提单，更改提单是否入库的标识
                    Contract contract = deliveryLine.Delivery.Quota.Contract;
                    Delivery del = deliveryLine.Delivery;

                    var addLine = new WarehouseInLine
                                      {
                                          BrandId = inLine.BrandId,
                                          CommodityTypeId = inLine.CommodityTypeId,
                                          DeliveryLineId = inLine.DeliveryLineId,
                                          IsVerified = inLine.IsVerified,
                                          PackingQuantity = inLine.PackingQuantity,
                                          PBNo = inLine.PBNo,
                                          Quantity = inLine.Quantity,
                                          SpecificationId = inLine.SpecificationId,
                                          VerifiedQuantity = inLine.VerifiedQuantity,
                                          IsPBCleared = inLine.IsPBCleared,
                                          Comment = inLine.Comment,
                                          WarehouseInId = header.Id
                                      };
                    Create(GetObjSet<WarehouseInLine>(ctx), addLine);
                    ctx.SaveChanges();
                    DeliveryLineStatusHelper.GetDeliveryLineStatus(inLine.DeliveryLineId, userId);
                    var qs = new QuotaService();
                    qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(deliveryLine.Delivery.QuotaId, userId);
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
        private void UpdateHeader(int userId, WarehouseIn header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    WarehouseIn oldWarehouseIn = QueryForObj(GetObjQuery<WarehouseIn>(ctx), c => c.Id == header.Id);
                    oldWarehouseIn.Comment = header.Comment;
                    oldWarehouseIn.WarehouseId = header.WarehouseId;
                    oldWarehouseIn.WarehouseInDate = header.WarehouseInDate;
                    oldWarehouseIn.CommodityId = header.CommodityId;
                    Update(GetObjSet<WarehouseIn>(ctx), oldWarehouseIn);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 更新入库行和对应的库存信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="header"></param>
        /// <param name="inLine"></param>
        /// <param name="oldWarehouseIn"></param>
        public void UpdateLine(int userId, WarehouseIn header, WarehouseInLine inLine, WarehouseIn oldWarehouseIn)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    DeliveryLine newDeliveryLine = null;

                    WarehouseInLine oldWarehouseInLine =
                        QueryForObj(
                            GetObjQuery<WarehouseInLine>(ctx,
                                                         new List<string>
                                                             {
                                                                 "WarehouseIn",
                                                                 "DeliveryLine.Delivery.Quota",
                                                                 "DeliveryLine.Delivery.Quota.Contract"
                                                             }),
                            o => o.Id == inLine.Id);
                    DeliveryLine line =
                            QueryForObj(GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines", "Delivery", "Delivery.Quota.Contract", "Delivery.Quota" }),
                                        c => c.Id == inLine.DeliveryLineId);//由于没有把提单行外键对象带过来所以要重新读取
                    if (oldWarehouseInLine.IsPBCleared == null || !oldWarehouseInLine.IsPBCleared.Value)//如果入库行已经被清卡 此时库存数量为0 但是用户又编辑入库 为了避免库存计算错误 需要重新计算一遍库存
                    {
                        bool isWWOld = oldWarehouseInLine.DeliveryLine.Delivery.DeliveryType ==
                                       (int)DeliveryType.InternalTDWW ||
                                       oldWarehouseInLine.DeliveryLine.Delivery.DeliveryType ==
                                       (int)DeliveryType.ExternalTDWW;
                        Inventory inventoryOld = GetInventoryByParameters(ctx,
                                                                          oldWarehouseInLine.DeliveryLine.Delivery.Quota.
                                                                              Contract.InternalCustomerId ?? 0,
                                                                          oldWarehouseInLine.DeliveryLine.Delivery.Quota.
                                                                              CommodityId ?? 0,
                                                                          (int)oldWarehouseInLine.CommodityTypeId,
                                                                          (int)oldWarehouseInLine.BrandId,
                                                                          (int)oldWarehouseInLine.SpecificationId,
                                                                          oldWarehouseInLine.PBNo,
                                                                          oldWarehouseIn.WarehouseId,
                                                                          isWWOld);
                        if (inventoryOld != null)
                        {
                            //if(oldWarehouseInLine.IsPBCleared != null && oldWarehouseInLine.IsPBCleared.Value)//如果入库行已经被清卡 此时库存数量为0 但是用户又编辑入库 为了避免库存计算错误 需要重新计算一遍库存
                            //{
                            //    decimal? qty = GetWarehouseOutQty(oldWarehouseInLine.Id, ctx);
                            //    inventoryOld.Quantity += (oldWarehouseInLine.VerifiedQuantity - qty);
                            //}
                            inventoryOld.Quantity -= oldWarehouseInLine.VerifiedQuantity;
                        }

                        bool isWW = line.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                                    line.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                        Inventory inventory = GetInventoryByParameters(ctx,
                                                                       line.Delivery.Quota.Contract.
                                                                           InternalCustomerId ?? 0,
                                                                       line.Delivery.Quota.CommodityId ?? 0,
                                                                       (int)inLine.CommodityTypeId, (int)inLine.BrandId,
                                                                       (int)inLine.SpecificationId, inLine.PBNo,
                                                                       header.WarehouseId, isWW);
                        if (inventory != null)
                        {
                            inventory.Quantity += inLine.VerifiedQuantity;
                        }
                        else
                        {
                            inventory = new Inventory
                                            {
                                                BrandId = (int)inLine.BrandId,
                                                CommodityId = line.Delivery.Quota.CommodityId ?? 0,
                                                CommodityTypeId = (int)inLine.CommodityTypeId,
                                                SpecificationId = inLine.SpecificationId,
                                                IsWarehouseWarranty = isWW,
                                                OwnerPartyId =
                                                    line.Delivery.Quota.Contract.InternalCustomerId ?? 0,
                                                PBNo = inLine.PBNo,
                                                WarehouseId = header.WarehouseId,
                                                Quantity = inLine.VerifiedQuantity
                                            };
                            Create(GetObjSet<Inventory>(ctx), inventory);
                        }
                    }
                    //#region 更改提单货运状态

                    ////对于入库行的数量 如果勾选了已确认就用已确认的数量 否则就用数量来进行相关的计算
                    ////如果修改了入库行对应的提单行 就对原来的提单行和修改后的提单行货运状态都进行更新 如果仍是同一个提单行就只更新一个
                    //decimal systemParameter = GetSystemParameter(ctx);
                    //DeliveryLine oldDeliveryLine =
                    //    QueryForObj(GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines", "Delivery" }),
                    //                c => c.Id == oldWarehouseInLine.DeliveryLineId);
                    //decimal oldWarehouseInQty = GetWarehouseInLineQtyByDeliveryLine(oldDeliveryLine);
                    //decimal oldQty;
                    //if (oldDeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                    //    oldDeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL) //内贸提单
                    //{
                    //    oldQty = oldDeliveryLine.VerifiedWeight == null ? 0 : (decimal)oldDeliveryLine.VerifiedWeight;
                    //}
                    //else
                    //{
                    //    oldQty = oldDeliveryLine.NetWeight == null ? 0 : (decimal)oldDeliveryLine.NetWeight;
                    //}
                    //oldWarehouseInQty = oldWarehouseInQty - (oldWarehouseInLine.VerifiedQuantity == null
                    //                        ? 0
                    //                        : (decimal)oldWarehouseInLine.VerifiedQuantity);
                    //if (oldWarehouseInLine.DeliveryLineId == inLine.DeliveryLineId)
                    //{
                    //    oldWarehouseInQty = oldWarehouseInQty +
                    //                        (inLine.VerifiedQuantity == null ? 0 : (decimal)inLine.VerifiedQuantity);
                    //}
                    //else
                    //{
                    //    newDeliveryLine =
                    //        QueryForObj(
                    //            GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines", "Delivery" }),
                    //            c => c.Id == inLine.DeliveryLineId);
                    //    decimal warehouseInQty = GetWarehouseInLineQtyByDeliveryLine(newDeliveryLine);
                    //    decimal qty;
                    //    if (newDeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                    //        newDeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL) //内贸提单
                    //    {
                    //        qty = newDeliveryLine.VerifiedWeight == null ? 0 : (decimal)newDeliveryLine.VerifiedWeight;
                    //    }
                    //    else
                    //    {
                    //        qty = newDeliveryLine.NetWeight == null ? 0 : (decimal)newDeliveryLine.NetWeight;
                    //    }
                    //    warehouseInQty = warehouseInQty +
                    //                     (inLine.VerifiedQuantity == null ? 0 : (decimal)inLine.VerifiedQuantity);

                    //    if (qty > 0)
                    //    {
                    //        if (Math.Abs((qty - warehouseInQty) / qty) <= Math.Abs(systemParameter / 100))
                    //        {
                    //            newDeliveryLine.DeliveryStatus = true;
                    //        }
                    //        else
                    //        {
                    //            newDeliveryLine.DeliveryStatus = false;
                    //        }
                    //    }
                    //    Update(GetObjSet<DeliveryLine>(ctx), newDeliveryLine);
                    //}

                    //if (oldQty > 0)
                    //{
                    //    if (Math.Abs((oldQty - oldWarehouseInQty) / oldQty) <= Math.Abs(systemParameter / 100))
                    //    {
                    //        oldDeliveryLine.DeliveryStatus = true;
                    //    }
                    //    else
                    //    {
                    //        oldDeliveryLine.DeliveryStatus = false;
                    //    }
                    //}
                    //Update(GetObjSet<DeliveryLine>(ctx), oldDeliveryLine);

                    //#endregion

                    oldWarehouseInLine.BrandId = inLine.BrandId;
                    oldWarehouseInLine.Comment = inLine.Comment;
                    oldWarehouseInLine.CommodityTypeId = inLine.CommodityTypeId;
                    oldWarehouseInLine.DeliveryLineId = inLine.DeliveryLineId;
                    oldWarehouseInLine.IsDeleted = inLine.IsDeleted;
                    oldWarehouseInLine.IsDraft = inLine.IsDraft;
                    oldWarehouseInLine.PBNo = inLine.PBNo;
                    oldWarehouseInLine.Quantity = inLine.Quantity;
                    oldWarehouseInLine.SpecificationId = inLine.SpecificationId;
                    oldWarehouseInLine.WarehouseInId = inLine.WarehouseInId;
                    oldWarehouseInLine.VerifiedQuantity = inLine.VerifiedQuantity;
                    oldWarehouseInLine.IsVerified = inLine.IsVerified;
                    oldWarehouseInLine.PackingQuantity = inLine.PackingQuantity;
                    Update(GetObjSet<WarehouseInLine>(ctx), oldWarehouseInLine);
                    ctx.SaveChanges();
                    DeliveryLineStatusHelper.GetDeliveryLineStatus(inLine.DeliveryLineId, userId);
                    var qs = new QuotaService();
                    if (newDeliveryLine != null)
                    {
                        qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(newDeliveryLine.Delivery.QuotaId, userId);//如果修改以后跟修改前不是同一个提单行 有可能对应批次不同 
                    }
                    qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(line.Delivery.QuotaId, userId);
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private decimal? GetWarehouseOutQty(int id, SenLan2Entities ctx)
        {
            try {
                decimal? qty = 0;
                WarehouseInLine inLine = QueryForObj(GetObjQuery<WarehouseInLine>(ctx, new List<string> { "WarehouseOutLines" }), c => c.Id == id);
                if(inLine.WarehouseOutLines != null && inLine.WarehouseOutLines.Count > 0)
                {
                    qty = inLine.WarehouseOutLines.Sum(c => c.VerifiedQuantity);  
                }                  
                return qty;
            } 
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void DeleteLine(int userId, int id, WarehouseIn oldWarehouseIn)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                //检查关联
                WarehouseInLine wil =
                    QueryForObj(
                        GetObjQuery<WarehouseInLine>(ctx,
                                                     new List<string>
                                                         {
                                                             "WarehouseIn",
                                                             "DeliveryLine.Delivery.Quota",
                                                             "DeliveryLine.Delivery.Quota.Contract",
                                                             "DeliveryLine",
                                                             "DeliveryLine.Delivery"
                                                         }), w => w.Id == id);

                //#region 删除入库行 更改提单状态

                //DeliveryLine deliveryLine =
                //    QueryForObj(GetObjQuery<DeliveryLine>(ctx, new List<string> { "WarehouseInLines", "Delivery" }),
                //                c => c.Id == wil.DeliveryLineId);
                //decimal systemParameter = GetSystemParameter(ctx);
                //decimal qty1 = GetWarehouseInLineQtyByDeliveryLine(deliveryLine); //根据提单行得到所有入库数量
                //decimal qty2 = (wil.VerifiedQuantity == null ? 0 : (decimal)wil.VerifiedQuantity); //当前删除的入库的数量
                //decimal warehouseInQty = qty1 - qty2; //当前提单剩余的入库数量
                //decimal qty;
                //if (deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                //    deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL) //内贸提单
                //{
                //    qty = deliveryLine.VerifiedWeight == null ? 0 : (decimal)deliveryLine.VerifiedWeight;
                //}
                //else
                //{
                //    qty = deliveryLine.NetWeight == null ? 0 : (decimal)deliveryLine.NetWeight;
                //}

                //if (qty > 0)
                //{
                //    if (Math.Abs((qty - warehouseInQty) / qty) <= Math.Abs(systemParameter / 100))
                //    {
                //        deliveryLine.DeliveryStatus = true;
                //    }
                //    else
                //    {
                //        deliveryLine.DeliveryStatus = false;
                //    }
                //}
                //Update(GetObjSet<DeliveryLine>(ctx), deliveryLine);

                //#endregion

                //1. 是否有出库
                if (QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx), wol => wol.WarehouseInLineId == wil.Id).Count > 0)
                {
                    throw new FaultException(ErrCode.WarehouseInWarehouseOutConnected.ToString());
                }
                wil.IsDeleted = true;
                //2. 检查是否删除入库:如果其他的入库行都已删除，则删除入库
                if (
                    QueryForObjs(GetObjQuery<WarehouseInLine>(ctx),
                                 w => w.WarehouseInId == wil.WarehouseInId && w.Id != wil.Id).Count == 0)
                {
                    wil.WarehouseIn.IsDeleted = true;
                }
                //3. 更新库存
                bool isWW = wil.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                            wil.DeliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW;
                Inventory inv = GetInventoryByParameters(ctx,
                                                         wil.DeliveryLine.Delivery.Quota.Contract.InternalCustomerId ??
                                                         0,
                                                         wil.DeliveryLine.Delivery.Quota.CommodityId ?? 0,
                                                         (int)wil.CommodityTypeId,
                                                         (int)wil.BrandId, (int)wil.SpecificationId, wil.PBNo,
                                                         oldWarehouseIn.WarehouseId, isWW);
                if (inv != null)
                {
                    inv.Quantity -= wil.VerifiedQuantity;
                }
                ctx.SaveChanges();
                DeliveryLineStatusHelper.GetDeliveryLineStatus(wil.DeliveryLineId, userId);
                var qs = new QuotaService();
                qs.UpdateVerifiedQtyAndEqualityAndVATStatusByQuotaId(wil.DeliveryLine.Delivery.QuotaId, userId);
            }
        }

        private decimal GetSystemParameter(SenLan2Entities ctx)
        {
            List<SystemParameter> sList =
                QueryForObjs(GetObjQuery<SystemParameter>(ctx), o => o.IsDeleted == false).ToList();
            if (sList.Count > 0)
            {
                SystemParameter sp = sList[0];
                return sp.Inventory2Delivery;
            }

            return 0;
        }

        private decimal GetWarehouseInLineQtyByDeliveryLine(DeliveryLine deliveryLine)
        {
            decimal totalQty = 0;
            foreach (WarehouseInLine line in deliveryLine.WarehouseInLines)
            {
                if (!line.IsDeleted)
                {
                    totalQty += (line.VerifiedQuantity == null ? 0 : (decimal)line.VerifiedQuantity);
                }
            }
            return totalQty;
        }

        #endregion
    }
}