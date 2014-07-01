using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Client.FinancialAccountServiceReference;
using Client.ViewModel.SystemSetting.FinancialAccountSetting;
using Utility.ServiceManagement;

namespace Client.View.PopUpDialog
{
    //todo 使用新的VM，而不是重用FinancialAccountHomeVM
    /// <summary>
    /// TreeViewDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewDialog
    {
        #region Members

        private readonly FinancialAccountHomeVM _financialAccountHomeVM;

        #endregion

        #region Property

        public FinancialAccountHomeVM FinancialAccountHomeVM
        {
            get { return _financialAccountHomeVM; }
        }

        public Object SelectedItems { get; set; }

        #endregion

        public TreeViewDialog()
        {
            InitializeComponent();
            _financialAccountHomeVM = new FinancialAccountHomeVM();
            _financialAccountHomeVM.Load();
            BindData();
        }

        public TreeViewDialog(bool isroot)
        {
            InitializeComponent();
            _financialAccountHomeVM = new FinancialAccountHomeVM {IsRoot = isroot};
            _financialAccountHomeVM.Load();
            BindData();
        }

        #region Method

        public void BindData()
        {
            tvFinancialAccount.ItemsSource = _financialAccountHomeVM.FinancialAccounts3;
        }

        #endregion

        #region Event

        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            const string condition = "it.ParentId = @p1";

            var parameters = new List<object>
                                 {tvFinancialAccount.SelectedValue ?? 0};

            using (var financialaccountService =SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                var financialaccounts = financialaccountService.Query(condition, parameters);
                if (_financialAccountHomeVM.IsRoot == false)
                {
                    if (financialaccounts.Count == 0)
                    {
                        if (e.ChangedButton == MouseButton.Left)
                        {
                            object obj = tvFinancialAccount.SelectedItem;
                            SelectedItems = obj;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(ResPopDialog.FinancialAccountError);
                    }
                }
                else
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        object obj = tvFinancialAccount.SelectedItem;
                        SelectedItems = obj;
                        Close();
                    }
                }
            }
        }

        #endregion
    }
}
