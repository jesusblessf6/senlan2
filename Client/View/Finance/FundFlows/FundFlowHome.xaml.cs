using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Finance.FundFlows;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Finance.FundFlows
{
    /// <summary>
    /// FundFlowHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class FundFlowHome
    {
        #region Constructor
        public FundFlowHome()
        {
            InitializeComponent();
            ModuleName = "FundFlowSetting";
            VM = new FundFlowHomeVM();
            BindData();
        }
        #endregion

        #region Event
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Query(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(FundFlowHomeVM.FundFlowSearchType.Free);
            var list = new FundFlowList(cons);
            RedirectTo(list);
        }

        private void BtnCurrentMonthReceivablesClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(FundFlowHomeVM.FundFlowSearchType.CurrentMontRecpt);
            var list = new FundFlowList(cons);
            RedirectTo(list);
        }

        private void BtnCurrentMonthPaymentClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(FundFlowHomeVM.FundFlowSearchType.CurrentMonthPmt);
            var list = new FundFlowList(cons);
            RedirectTo(list);
        }

        private void BtnCurrentYearReceivablesClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(FundFlowHomeVM.FundFlowSearchType.CurrentYearRecpt);
            var list = new FundFlowList(cons);
            RedirectTo(list);
        }

        private void BtnCurrentYearPaymentClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(FundFlowHomeVM.FundFlowSearchType.CurrentYearPmt);
            var list = new FundFlowList(cons);
            RedirectTo(list);
        }

        private void BtnCreatePaymentClick(object sender, RoutedEventArgs e)
        {
            var frm = new PaymentDetail(PageMode.AddMode);
            RedirectTo(frm);
        }

        private void BtnCreateReceiveClick(object sender, RoutedEventArgs e)
        {
            var frm = new ReceiptDetail(PageMode.AddMode);
            RedirectTo(frm);
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.SetPropertyValue("SelectedBPartnerId", bp.Id);
            VM.SetPropertyValue("BPartnerName", bp.ShortName);
        }

        private void BtnFinancialAccountClick(object sender, RoutedEventArgs e)
        {
            var dialog = new TreeViewDialog();
            dialog.ShowDialog();
            var financialAccount = dialog.SelectedItems as FinancialAccount;
            if (financialAccount != null)
            {
                VM.SetPropertyValue("SelectedFinancialAccountId", financialAccount.Id);
                VM.SetPropertyValue("FinancialAccountName", financialAccount.Name);
            }
        }

        #endregion
    }
}
