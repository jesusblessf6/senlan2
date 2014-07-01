using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.BankAccountSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using Client.View.PopUpDialog;
using DBEntity;

namespace Client.View.SystemSetting.BankAccountSetting
{
    /// <summary>
    /// Interaction logic for BankAccountHome.xaml
    /// </summary>
    public partial class BankAccountHome
    {
        #region Member

        private const int BankPerPage = 10;
        private const int AccountPerPage = 10;
        private readonly bool _canBeDeleted;
        private readonly bool _canBeEdited;
        private readonly bool _canBeViewed;

        #endregion

        #region Property

        public BankAccountSettingVM VM { get; set; }

        #endregion

        #region Constructor

        public BankAccountHome()
        {
            InitializeComponent();

            ModuleName = "BankAccountSetting";
            VM = new BankAccountSettingVM();
            button1.IsEnabled = CheckPerm(PageMode.AddMode);
            button2.IsEnabled = CheckPerm(PageMode.AddMode);

            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl2.OnNewPage += pagingControl2_OnNewPage;
            pagingControl1.Init(VM.BankCount, BankPerPage);

            _canBeEdited = CheckPerm(PageMode.EditMode);
            _canBeDeleted = CheckPerm(PageMode.DeleteMode);
            _canBeViewed = CheckPerm(PageMode.ViewMode);
        }

        #endregion

        #region Method

        /// <summary>
        /// Bind Data
        /// </summary>
        public override void BindData()
        {
        }

        /// <summary>
        /// Refresh the page
        /// </summary>
        public override void Refresh()
        {
            VM.LoadCount();
            pagingControl1.Init(VM.BankCount, BankPerPage);
            pagingControl2.Init(VM.AccountCount, AccountPerPage);
        }

        #endregion

        #region Event

        /// <summary>
        /// whether able to edit the bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeEdited;
            e.Handled = true;
        }

        /// <summary>
        /// Edit bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var bankId = (int) e.Parameter;
            var bd = new BankDetail(bankId, PageMode.EditMode);
            bd.Show();
            e.Handled = true;
        }

        /// <summary>
        /// whether able to delete bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeDeleted;
            e.Handled = true;
        }

        /// <summary>
        /// delete bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteBank(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// whether able to view bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeViewed;
            e.Handled = true;
        }

        /// <summary>
        /// View Bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var bankId = (int) e.Parameter;
            var bd = new BankDetail(bankId, PageMode.ViewMode);
            bd.Show();
            e.Handled = true;
        }

        /// <summary>
        /// whether able to edit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeEdited;
            e.Handled = true;
        }

        /// <summary>
        /// edit account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var accountId = (int) e.Parameter;
            var ba = new BankAccountDetail(PageMode.EditMode, accountId);
            ba.Show();
            e.Handled = true;
        }

        /// <summary>
        /// whether able to delete account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeDeleted;
            e.Handled = true;
        }

        /// <summary>
        /// delete account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteAccount(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// whether able to view account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canBeViewed;
            e.Handled = true;
        }

        /// <summary>
        /// view account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var accountId = (int) e.Parameter;
            var ba = new BankAccountDetail(PageMode.ViewMode, accountId);
            ba.Show();
            e.Handled = true;
        }

        /// <summary>
        /// when bank tab get focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiBankGotFocus(object sender, RoutedEventArgs e)
        {
            if (VM.Banks == null || VM.Banks.Count == 0)
            {
                pagingControl1.Init(VM.BankCount, BankPerPage);
            }
        }

        /// <summary>
        /// when account tab get focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiAccountGotFocus(object sender, RoutedEventArgs e)
        {
            if (VM.BankAccounts == null || VM.BankAccounts.Count == 0)
            {
                pagingControl2.Init(VM.AccountCount, AccountPerPage);
            }
        }

        /// <summary>
        /// add new bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var bd = new BankDetail(PageMode.AddMode);
            bd.Show();
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            bool searchState = txtName.Text.Trim() != string.Empty;
            VM.SearchName = txtName.Text.Trim();
            VM.SearchBanks(searchState);
            pagingControl1.Init(VM.BankCount, BankPerPage);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchAccountClick(object sender, RoutedEventArgs e)
        {
            bool searchState = (txtBAName.Text.Trim() != string.Empty || VM.SearchCustomerId>0);
            VM.SearchBankAccountName = txtBAName.Text.Trim();
            VM.SearchBankAccounts(searchState);
            pagingControl2.Init(VM.AccountCount, AccountPerPage);
        }

        /// <summary>
        /// set line no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1)*BankPerPage + e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// Add new account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var ba = new BankAccountDetail(PageMode.AddMode);
            ba.Show();
        }

        /// <summary>
        /// set line no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid2LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl2.CurPageNo - 1)*AccountPerPage + e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// when going to new page of bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.BankFrom = e.From;
            VM.BankTo = e.To;
            VM.LoadBank();
            dataGrid1.ItemsSource = VM.Banks;
            dataGrid1.Items.Refresh();
        }

        /// <summary>
        /// when going to new page of account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagingControl2_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.AccountFrom = e.From;
            VM.AccountTo = e.To;
            VM.LoadBankAccount();
            dataGrid2.ItemsSource = VM.BankAccounts;
            dataGrid2.Items.Refresh();
        }

        #endregion

        /// <summary>
        /// 客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int)BusinessPartnerType.Customer,
                                            (int)BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SearchCustomerName = bp.ShortName;
                VM.SearchCustomerId = bp.Id;
                textBox5.Text = bp.ShortName;
            }
        }
    }
}