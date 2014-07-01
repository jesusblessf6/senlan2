using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogRegistrationService" in both code and config file together.
    [ServiceContract]
    public interface ILogRegistrationService : IService<LogRegistration>
    {
        [OperationContract]
        List<LogRegistration> GetRegsByUser(int userId);

        [OperationContract]
        void UpdateUserRegistration(List<LogRegistration> regs, int userId);
    }
}
