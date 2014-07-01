using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IModuleService" in both code and config file together.
    [ServiceContract]
    public interface IModuleService : IService<Module>
    {
        [OperationContract]
        void UpdatePermOptions(int moduleId, Dictionary<string, bool> permState, int userId);
    }
}