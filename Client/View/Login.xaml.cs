using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Client.Base.BaseClient;
using Client.ViewModel;
using DBEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : IBindingData
    {
        #region Property

        public LoginVM VM { get; set; }

        #endregion

        #region Constructor

        public Login()
        {
            InitializeComponent();
            tbLoginName.Focus();

            if (CultureManager.UICulture.Name == "en")
            {
                radioButton2.IsChecked = true;
                radioButton1.IsChecked = false;
            }
            else
            {
                radioButton1.IsChecked = true;
                radioButton2.IsChecked = false;
            }

            VM = new LoginVM();
            BindData();
        }

        #endregion

        #region Event

        private void BtCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void LoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginWindow();
            }
        }

        private void BtLoginClick(object sender, RoutedEventArgs e)
        {
            LoginWindow();
        }

        private void RadioButton1Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked.HasValue && radioButton1.IsChecked.Value)
            {
                radioButton2.IsChecked = false;
                CultureManager.UICulture = new CultureInfo("zh-CN");
                tbLoginName.Focus();
            }
        }

        private void RadioButton2Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton2.IsChecked.HasValue && radioButton2.IsChecked.Value)
            {
                radioButton1.IsChecked = false;
                CultureManager.UICulture = new CultureInfo("en");
                tbLoginName.Focus();
            }
        }

        #endregion

        #region Method

        public void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void LoginWindow()
        {
            VM.Password = tbPassword.Password;
            try
            {
                User user = VM.Login();

                Application.Current.Properties["CurrentUser"] = user;

                var main = new Main();
                Close();
                main.Show();

                main.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        #endregion

        
    }
}