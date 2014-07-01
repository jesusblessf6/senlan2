using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoleService" in both code and config file together.
    [ServiceContract]
    public interface IRoleService : IService<Role>
    {
        [OperationContract]
        List<Function> GetRolesFunctions(int roleId);

        [OperationContract]
        bool UpdatePerms(List<RoleFunctionLink> links, int roleId);

        [OperationContract]
        List<Function> GetPermsByRole(int roleId);

        [OperationContract]
        Role AddNewRole(Role role, int userId);

        [OperationContract]
        Role UpdateRole(Role role, int userId);
    }
}