using System;
using System.Windows;
using Client.ViewModel.SystemSetting.LogRegister;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.LogRegister
{
    /// <summary>
    /// Interaction logic for LogRegister.xaml
    /// </summary>
    public sealed partial class LogRegister
    {
        #region Property

        public LogRegisterVM VM { get; set; }

        #endregion

        #region Constructor

        public LogRegister()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "LogRegistration";
            VM = new LogRegisterVM();
            BindData();
        }

        public LogRegister(PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "LogRegistration";
            VM = new LogRegisterVM();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Method

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    VM.Save();
                    MessageBox.Show(Properties.Resources.SaveSuccessfully);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        #endregion
    }
}