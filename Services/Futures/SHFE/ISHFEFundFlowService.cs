using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.Futures.SHFE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISHFEFundFlowService" in both code and config file together.
    [ServiceContract]
    public interface ISHFEFundFlowService : IService<SHFEFundFlow>
    {
        
    }
}
