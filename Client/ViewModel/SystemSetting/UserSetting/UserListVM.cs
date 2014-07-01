using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.UserServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.UserSetting
{
    public class UserListVM : BaseVM
    {
        #region Member

        private int _userCount;
        private int _userFrom;
        private int _userTo;
        private List<User> _users;

        #endregion

        #region Property

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                Notify("Users");
            }
        }

        public int UserCount
        {
            get { return _userCount; }
            set
            {
                if (_userCount != value)
                {
                    _userCount = value;
                    Notify("UserCount");
                }
            }
        }

        public int UserFrom
        {
            get { return _userFrom; }
            set
            {
                if (_userFrom != value)
                {
                    _userFrom = value;
                    Notify("UserFrom");
                }
            }
        }

        public int UserTo
        {
            get { return _userTo; }
            set
            {
                if (_userTo != value)
                {
                    _userTo = value;
                    Notify("UserTo");
                }
            }
        }

        #endregion

        #region Constructor

        public UserListVM()
        {
            _users = new List<User>();
            LoadCount();
        }

        #endregion

        #region Method

        public void LoadCount()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                UserCount = userService.GetAllCount();
            }
        }

        public void Load()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                Users = userService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"}, UserFrom,
                                                          UserTo, new List<string> {"Role"});
            }
        }

        public void DeleteUser(int id)
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                userService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}