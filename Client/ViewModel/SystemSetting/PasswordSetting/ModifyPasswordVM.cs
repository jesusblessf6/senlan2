using System;
using Client.Base.BaseClientVM;
using Client.UserServiceReference;
using Client.View.SystemSetting.PasswordSetting;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.PasswordSetting
{
    public class ModifyPasswordVM : BaseVM
    {
        #region Property

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Confirm { get; set; }

        #endregion

        #region Constrcutor

        public ModifyPasswordVM()
        {
            ObjectId = CurrentUser.Id;
        }

        #endregion

        #region Method

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(OldPassword))
            {
                throw new Exception(ResPasswordSetting.OldPasswordRequired);
            }

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                throw new Exception(ResPasswordSetting.NewPasswordRequired);
            }

            if (string.IsNullOrWhiteSpace(Confirm))
            {
                throw new Exception(ResPasswordSetting.ConfirmRequired);
            }

            if (NewPassword.Length > 16)
            {
                throw new Exception(ResPasswordSetting.LengthLimit);
            }

            if (NewPassword != Confirm)
            {
                throw new Exception(ResPasswordSetting.ConfirmationError);
            }

            return true;
        }

        protected override void Update()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                userService.ChangePassword(OldPassword, NewPassword, CurrentUser.Id);
            }
        }

        #endregion
    }
}