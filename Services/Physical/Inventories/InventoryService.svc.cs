using System.Data;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Collections.Generic;
using System.Linq;
using DBEntity.EnumEntity;

namespace Services.Physical.Inventories
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
    public class InventoryService : BaseService<Inventory>, IInventoryService
    {
        public Inventory GetInventoryByParameter(int userId, int bpID, int? commodityID, int commodityTypeID, int brandID,
                                                 int specificationID, string pbNo, int warehouseID, bool isWarrant)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Inventory inventory = QueryForObj(GetObjQuery<Inventory>(ctx),
                                                      c =>
                                                      c.BrandId == bpID && c.CommodityId == commodityID &&
                                                      c.CommodityTypeId == commodityTypeID &&
                                                      c.SpecificationId == specificationID &&
                                                      c.WarehouseId == warehouseID && c.PBNo == pbNo &&
                                                      c.IsWarehouseWarranty == isWarrant);
                    return inventory;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<DeliveryLine> GetInternalTDList(int? commodityID, int internalCustomerID, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<DeliveryLine> deliveryLineList;
                    if (commodityID == null)
                    {
                        deliveryLineList = QueryForObjs(GetObjQuery<DeliveryLine>(ctx,
                            new List<string> { "Delivery.Warehouse", "Delivery.Quota.Commodity", 
                                "Brand", "Delivery", "WarehouseInLines", "Delivery.Quota.Contract","SalesDeliveryLines" }),
                                c => c.Delivery.Quota.Contract.InternalCustomerId == internalCustomerID &&
                                    (c.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || c.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                                    && c.DeliveryStatus == false
                                    && (c.Delivery.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || c.Delivery.ApproveStatus == (int)ApproveStatus.Approved)).ToList();
                    }
                    else
                    {
                        deliveryLineList = QueryForObjs(GetObjQuery<DeliveryLine>(ctx,
                            new List<string> { "Delivery.Warehouse", "Delivery.Quota.Commodity", 
                                "Brand", "Delivery", "WarehouseInLines", "Delivery.Quota.Contract","SalesDeliveryLines" }),
                                c => c.Delivery.Quota.CommodityId == commodityID && c.Delivery.Quota.Contract.InternalCustomerId == internalCustomerID &&
                                    (c.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || c.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                                    && c.DeliveryStatus == false
                                    && (c.Delivery.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || c.Delivery.ApproveStatus == (int)ApproveStatus.Approved)).ToList();
                    }
                    deliveryLineList = deliveryLineList.OrderBy(c => c.Delivery.Id).ToList();
                    return deliveryLineList;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<DeliveryLine> GetExternalTDList(int? commodityID, int internalCustomerID, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<DeliveryLine> deliveryLineList;
                    if (commodityID == null)
                    {
                        deliveryLineList = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "Delivery.Warehouse", "Delivery.Quota.Commodity", "Brand", "WarehouseInLines", "Delivery", "Delivery.Quota.Contract", "SalesDeliveryLines" }), c =>
                            c.Delivery.Quota.Contract.InternalCustomerId == internalCustomerID &&
                            (c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                            && c.Delivery.IsCopy == false
                            && c.DeliveryStatus == false
                            && (c.Delivery.WarrantId == null || (c.Delivery.WarrantId.HasValue && c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW))
                            && (c.Delivery.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || c.Delivery.ApproveStatus == (int)ApproveStatus.Approved)).ToList();
                    }
                    else
                    {
                        deliveryLineList = QueryForObjs(GetObjQuery<DeliveryLine>(ctx, new List<string> { "Delivery.Warehouse", "Delivery.Quota.Commodity", "Brand", "WarehouseInLines", "Delivery", "Delivery.Quota.Contract", "SalesDeliveryLines" }), c =>
                            c.Delivery.Quota.CommodityId == commodityID
                            && c.Delivery.Quota.Contract.InternalCustomerId == internalCustomerID
                            && (c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                            && c.Delivery.IsCopy == false
                            && c.DeliveryStatus == false
                            && (c.Delivery.WarrantId == null || (c.Delivery.WarrantId.HasValue && c.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW))
                            && (c.Delivery.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || c.Delivery.ApproveStatus == (int)ApproveStatus.Approved)).ToList();
                    }
                    deliveryLineList = deliveryLineList.OrderBy(c => c.Delivery.Id).ToList();
                    return deliveryLineList;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Inventory> GetInventoriesByInternalCustomer(int userId, int internalCustomerID)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Inventory> list = QueryForObjs(GetObjQuery<Inventory>(ctx, new List<string> { "Commodity" }), c => c.OwnerPartyId == internalCustomerID).ToList();
                    return list;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Inventory> GetInventoriesByCommodityAndInternalCustomer(int internalCustomerID, int commodityID)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<Inventory> list = QueryForObjs(GetObjQuery<Inventory>(ctx, new List<string> { "Commodity" }), c => c.OwnerPartyId == internalCustomerID && c.CommodityId == commodityID).ToList();
                    return list;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
