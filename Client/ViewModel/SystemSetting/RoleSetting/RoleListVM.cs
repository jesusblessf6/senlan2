using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.RoleServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.RoleSetting
{
    public class RoleListVM : BaseVM
    {
        private List<Role> _roles;

        #region Property

        public List<Role> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                Notify("Roles");
            }
        }

        #endregion

        #region Method

        public void Load()
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                Roles = roleService.GetAll();
            }
        }

        public void DeleteRole(int id)
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                roleService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}