using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.Physical.Deliveries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IForeignDeliveryPoolLineService" in both code and config file together.
    [ServiceContract]
    public interface IForeignDeliveryPoolLineService : IService<ForeignDeliveryPoolLine>
    {
       
    }
}
