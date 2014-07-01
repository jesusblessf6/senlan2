using System;
using Client.UserServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel
{
    public class LoginVM
    {
        #region Property

        public string LoginName { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructor

        public LoginVM()
        {
            LoginName = null;
            Password = null;
        }

        #endregion

        #region Method

        public User Login()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                User user = userService.Login(LoginName, Password);
                if (user == null)
                {
                    throw (new Exception("用户名或密码有误"));
                }

                return user;
            }
        }

        #endregion
    }
}