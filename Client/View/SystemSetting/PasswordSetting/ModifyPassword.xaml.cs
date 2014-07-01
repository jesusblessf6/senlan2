using System;
using System.Windows;
using Client.ViewModel.SystemSetting.PasswordSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.PasswordSetting
{
    /// <summary>
    /// Interaction logic for ModifyPassword.xaml
    /// </summary>
    public partial class ModifyPassword
    {
        #region Property

        public ModifyPasswordVM VM { get; set; }

        #endregion

        #region Constructor

        public ModifyPassword() : 
            base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "ModifyPassword";
            VM = new ModifyPasswordVM();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            
        }

        #endregion

        #region Event

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.OldPassword = passwordBox1.Password.Trim();
                VM.NewPassword = passwordBox2.Password.Trim();
                VM.Confirm = passwordBox3.Password.Trim();

                VM.Save();
                MessageBox.Show(ResPasswordSetting.ModificationSucceed);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
