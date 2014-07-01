using System;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.CommissionSetting;
using DBEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CommissionSetting
{
    /// <summary>
    /// Interaction logic for CommissionSearch.xaml
    /// </summary>
    public sealed partial class CommissionSearch
    {
        private const int ContractPerPage = 10;

        public CommissionSearch(CommissionSearchVM searchVM)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            if (searchVM == null)
                return;
            VM = searchVM;
            pagerContract.OnNewPage += pagerContract_OnNewPage;
            pagerContract.Init(VM.CommissionCount, ContractPerPage);
            BindData();
        }

        public CommissionSearchVM VM { get; set; }

        public override void BindData()
        {
            commissionGrid.ItemsSource = VM.CommissionList;
        }

        private void pagerContract_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.CommissionFrom = e.From;
            VM.CommissionTo = e.To;
            VM.Init();
            commissionGrid.ItemsSource = VM.CommissionList;
            commissionGrid.Items.Refresh();
        }

        public override void Refresh()
        {
            VM.LoadCommissionCount();
            pagerContract.Init(VM.CommissionCount, ContractPerPage);
        }

        private void CommissionLineCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != 0;
            e.Handled = true;
        }

        private void CommissionLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                Commission commission = VM.GetCommissionIdByLineID(id);
                if (commission.IsDefaultRule)
                {
                    var c = new DefaultCommissionDetail(commission.Id, commission.CommissionType, true);
                    RedirectTo(c);
                }
                else
                {
                    var cd = new CommissionDetail(commission.CommissionType, commission.Id, commission.IsDefaultRule);
                    RedirectTo(cd);
                }
            }
        }

        private void CommissionLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DelCommissionLine(id);
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
    }
}