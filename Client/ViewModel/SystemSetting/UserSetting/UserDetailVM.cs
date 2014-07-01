using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.RoleServiceReference;
using Client.UserServiceReference;
using Client.View.SystemSetting.UserSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.UserSetting
{
    public class UserDetailVM : BaseVM
    {
        #region Members

        private string _description;
        private string _loginName;
        private string _name;
        private List<Role> _roles;
        private int _selectedRoleId;
        private bool _isSales;
        #endregion

        #region Property
        public bool IsSales
        {
            get { return _isSales; }
            set { 
                if(_isSales != value)
                {
                    _isSales = value;
                    Notify("IsSales");
                }
            }
        }

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

        public int SelectedRoleId
        {
            get { return _selectedRoleId; }
            set
            {
                if (_selectedRoleId != value)
                {
                    _selectedRoleId = value;
                    Notify("SelectedRoleId");
                }
            }
        }

        public List<Role> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                Notify("Roles");
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

        public string LoginName
        {
            get { return _loginName; }
            set
            {
                if (_loginName != value)
                {
                    _loginName = value;
                    Notify("LoginName");
                }
            }
        }

        #endregion

        #region Constructor

        public UserDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public UserDetailVM(int userId)
        {
            ObjectId = userId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                _roles = roleService.GetAll();
                _roles.Insert(0, new Role {Id = 0, Name = string.Empty});
            }

            if (ObjectId > 0)
            {
                using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
                {
                    User u = userService.GetById(ObjectId);
                    if (u != null)
                    {
                        Name = u.Name;
                        LoginName = u.LoginName;
                        Description = u.Description;
                        SelectedRoleId = u.RoleId ?? 0;
                        IsSales = u.IsSales == null ? false : u.IsSales.Value;
                    }
                }
            }
        }

        protected override void Create()
        {
            var user = new User
                           {
                               Name = Name,
                               LoginName = LoginName,
                               RoleId = SelectedRoleId,
                               Description = Description,
                               IsSales = IsSales
                           };

            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                userService.AddNewUser(user, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                User user = userService.GetById(ObjectId);

                if (user != null)
                {
                    user.Name = Name;
                    user.LoginName = LoginName;
                    user.Description = Description;
                    user.RoleId = SelectedRoleId;
                    user.IsSales = IsSales;
                    userService.UpdateUser(user, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResUserSetting.UserNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResUserSetting.UserNameRequired);
            }

            if (string.IsNullOrWhiteSpace(LoginName))
            {
                throw new Exception(ResUserSetting.LoginNameRequired);
            }

            if (SelectedRoleId == 0)
            {
                throw new Exception(ResUserSetting.RoleRequired);
            }

            return true;
        }

        #endregion
    }
}