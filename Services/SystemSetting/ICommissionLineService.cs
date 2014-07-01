using System.ServiceModel;
using Services.Base;
using DBEntity;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommissionLineService" in both code and config file together.
    [ServiceContract]
    public interface ICommissionLineService : IService<CommissionLine>
    {
        
    }
}
