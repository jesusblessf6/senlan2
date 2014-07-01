using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;

namespace Services.Physical.WarehouseIns
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseInLineService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseInLineService : IService<WarehouseInLine>
    {
        [OperationContract]
        WarehouseInLineEnableProperty SetElementsEnableProperty(int id);
    }
}
