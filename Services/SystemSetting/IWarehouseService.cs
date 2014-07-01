using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseService : IService<Warehouse>
    {
        [OperationContract]
        void AddNewWarehouse(Warehouse warehouse, List<StorageFeeRule> addStorageFeeRules, int userId);

        [OperationContract]
        void UpdateExistedWarehouse(Warehouse warehouse,List<StorageFeeRule> addStorageFeeRules,List<StorageFeeRule> updateStorageFeeRules,List<StorageFeeRule> deleteStorageFeeRules, int userId);

    }
}