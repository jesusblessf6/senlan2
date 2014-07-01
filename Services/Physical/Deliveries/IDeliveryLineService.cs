using System.ServiceModel;
using Services.Base;
using DBEntity;
using DBEntity.EnableProperty;

namespace Services.Physical.Deliveries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeliveryLineService" in both code and config file together.
    [ServiceContract]
    public interface IDeliveryLineService : IService<DeliveryLine>
    {
        [OperationContract]
        DeliveryLineEnableProperty SetElementsEnableProperty(int id);
    }
}
