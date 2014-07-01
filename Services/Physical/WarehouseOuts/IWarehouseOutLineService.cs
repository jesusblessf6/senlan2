using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;

namespace Services.Physical.WarehouseOuts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseOutLineService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseOutLineService : IService<WarehouseOutLine>
    {
        [OperationContract]
        WarehouseOutLineEnableProperty SetElementsEnableProperty(int id);
    }
}