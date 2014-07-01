using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.Physical.Inventories
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService : IService<Inventory>
    {
        [OperationContract]
        Inventory GetInventoryByParameter(int userId, int bpID, int? commodityID, int commodityTypeID, int brandID, int specificationID, string pbNo, int warehouseID, bool isWarrant);

        [OperationContract]
        List<DeliveryLine> GetInternalTDList(int? commodityID, int internalCustomerID, int userId);

        [OperationContract]
        List<DeliveryLine> GetExternalTDList(int? commodityID, int internalCustomerID, int userId);

        [OperationContract]
        List<Inventory> GetInventoriesByInternalCustomer(int userId, int internalCustomerID);

        [OperationContract]
        List<Inventory> GetInventoriesByCommodityAndInternalCustomer(int internalCustomerID, int commodityID);
    }
}
