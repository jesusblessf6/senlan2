using System;
using Client.Base.BaseClientVM;
using Client.RoleServiceReference;
using Client.View.SystemSetting.RoleSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.RoleSetting
{
    public class RoleDetailVM : BaseVM
    {
        #region Members

        private string _description;
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        #endregion

        #region Constructor

        public RoleDetailVM()
        {
            ObjectId = 0;
            _name = string.Empty;
            _description = string.Empty;
        }

        public RoleDetailVM(int roleId)
        {
            Role role;
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                role = roleService.GetById(roleId);
            }

            if (role != null)
            {
                ObjectId = roleId;
                _name = role.Name;
                _description = role.Description;
            }
            else
            {
                ObjectId = 0;
                _name = string.Empty;
                _description = string.Empty;
            }
        }

        #endregion

        #region Method

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception(ResRoleSetting.RoleNameRequired);
            }

            return true;
        }

        protected override void Create()
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                var role = new Role {Name = Name, Description = Description};
                roleService.AddNewRole(role, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                Role role = roleService.GetById(ObjectId);
                role.Name = Name;
                role.Description = Description;
                roleService.UpdateRole(role, CurrentUser.Id);
            }
        }

        public void Reset()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        #endregion
    }
}