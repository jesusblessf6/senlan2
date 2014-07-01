using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.FinancialAccountSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.FinancialAccountSetting
{
    /// <summary>
    /// FinancialAccountHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class FinancialAccountHome
    {
        #region Members

        private readonly FinancialAccountHomeVM _financialAccountHomeVM;
        private const int FinancialAccountPerPage = 10;
        private readonly bool _canDelete;

        #endregion

        #region Property

        public FinancialAccountHomeVM FinancialAccountHomeVM
        {
            get { return _financialAccountHomeVM; }
        }

        #endregion

        #region Constructor

        public FinancialAccountHome(PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            _financialAccountHomeVM = new FinancialAccountHomeVM();
            _financialAccountHomeVM.Load();
            _canDelete = CheckPerm(PageMode.DeleteMode);
            BindData();
        }

        public FinancialAccountHome()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            VisibilityCollapsed();
            _financialAccountHomeVM = new FinancialAccountHomeVM();
            _financialAccountHomeVM.Load();
            _canDelete = CheckPerm(PageMode.DeleteMode);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            tvFinancialAccount.ItemsSource = _financialAccountHomeVM.FinancialAccounts3;
            lbSelectedFinancialAccountName.DataContext = _financialAccountHomeVM;
            _financialAccountHomeVM.LoadFinancialAccountCount();
            pagingControl1.Init(_financialAccountHomeVM.FinancialAccountCount, FinancialAccountPerPage);
        }

        public override void Refresh()
        {
            _financialAccountHomeVM.Load();
            BindData();
        }

        /// <summary>
        /// 隐藏编辑、删除控件
        /// </summary>
        private void VisibilityCollapsed()
        {
            button2.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 显示编辑、删除控件
        /// </summary>
        private void VisibilityVisible()
        {
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
        }
        #endregion

        #region Event

        private void TvFinancialAccountSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is FinancialAccount)
            {
                #region 判断如果为根目录编辑、删除控件隐藏掉，否则显示。
                if (((FinancialAccount)e.NewValue).ParentId == null || ((FinancialAccount)e.NewValue).ParentId == 0)
                {
                    VisibilityCollapsed();
                }
                else
                {
                    VisibilityVisible();
                }
                #endregion

                _financialAccountHomeVM.FinancialAccount = (FinancialAccount) e.NewValue;
            }
            else
            {
                _financialAccountHomeVM.FinancialAccount = null;
            }

            _financialAccountHomeVM.LoadSelectedFinancialAccountName();
            _financialAccountHomeVM.LoadFinancialAccountCount();
            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl1.Init(_financialAccountHomeVM.FinancialAccountCount, FinancialAccountPerPage);
            pagingControl1.OnNewPage -= pagingControl1_OnNewPage;
        }


        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            _financialAccountHomeVM.FinancialAccountFrom = e.From;
            _financialAccountHomeVM.FinancialAccountTo = e.To;
            _financialAccountHomeVM.LoadFinancialAccountDetails();
            dgFinancialAccountDetails.ItemsSource = _financialAccountHomeVM.FinancialAccounts4;
            dgFinancialAccountDetails.Items.Refresh();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var md = new FinancialAccountDetail(PageMode.AddMode);
            md.Show();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(tvFinancialAccount.SelectedValue);
            var md = new FinancialAccountDetail(id, PageMode.EditMode);
            md.Show();
        }

        private void BtDeteleClick(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(tvFinancialAccount.SelectedValue);
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    _financialAccountHomeVM.DeleteFinancialAccount(id);
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

        private void EditFinancialAccountCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void EditFinancialAccountCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var moduleId = (int) e.Parameter;
            var md = new FinancialAccountDetail(moduleId, PageMode.EditMode);
            md.Show();
            e.Handled = true;
        }

        private void DeleteFinancialAccountCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DeleteFinancialAccountCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    _financialAccountHomeVM.DeleteFinancialAccount(id);
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

        private void DgFinancialAccountDetailsLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * FinancialAccountPerPage + e.Row.GetIndex() + 1;
        }

        #endregion
    }
}
