using System;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Finance.FundFlows;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Finance.FundFlows
{
    /// <summary>
    ///     PaymentDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentDetail
    {
        public new FundFlowDetailVM VM { get; set; }
        #region Constructor

        public PaymentDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Payment)
        {
            InitializeComponent();
            ModuleName = "FundFlowSetting";
            VM = new FundFlowDetailVM((int) FundFlowType.Pay);
            BindData();
        }

        public PaymentDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.Payment)
        {
            InitializeComponent();
            ModuleName = "FundFlowSetting";
            VM = new FundFlowDetailVM(id, (int) FundFlowType.Pay);
            BindData();
        }

        //todo : to check this constructor
        public PaymentDetail(FundFlowDetailVM vm, PageMode pageMode)
            : base(pageMode, Properties.Resources.Payment)
        {
            InitializeComponent();
            ModuleName = "FundFlowSetting";
            if (vm == null)
                return;
            VM = vm;
            txtPaymentCurrencyName.IsEnabled = false;
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        protected override void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    if (VM.CheckFinancialAccount())
                    {
                        MessageBoxResult result = MessageBox.Show("货款类会计科目的收付款需要选择批次，是否要继续？", "提示",
                                                                  MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            FundFlowSave();
                        }
                    }
                    else
                    {
                        FundFlowSave();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        public void FundFlowSave()
        {
            VM.Save();
            AfterSave();
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;

            VM.SetPropertyValue("SelectedBPartnerId", bp.Id);
            VM.SetPropertyValue("BPartnerName", bp.ShortName);
        }

        private void BtnQoutaClick(object sender, RoutedEventArgs e)
        {
            if ((VM).SelectedBPartnerId == null || (VM).SelectedBPartnerId <= 0)
            {
                MessageBox.Show(ResFundFlow.ReceiptBPNotNull);
                return;
            }
            string queryStr =
                string.Format(
                    "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.FinanceStatus=false  and (it.IsFundflowFinished = false or it.IsFundflowFinished is NULL)and it.Contract.BPId={2}",
                    (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded,
                    (VM).SelectedBPartnerId);
            if (VM.IdList != null && VM.IdList.Count > 0)
            {
                queryStr += string.Format(" and (");
                for (int j = 0; j < VM.IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format("it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                }
                queryStr += string.Format(")");
            }

            if(VM.SelectedBPartnerId != null && VM.SelectedBPartnerId != 0)
            {
                queryStr += string.Format(" and it.Contract.BPId = {0}", VM.SelectedBPartnerId);
            }
            if (VM.ICId != null && VM.ICId != 0)
            {
                queryStr += string.Format(" and it.Contract.InternalCustomerId = {0}", VM.ICId);
            }

            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Quota;
            if (bp == null) return;
            (VM).SelectedQuotaId = bp.Id;
            (VM).QuotaNo = bp.QuotaNo;
            (VM).SetSettlementCurrencyByQuotaId(bp.Id);
            if (!string.IsNullOrEmpty((VM).SettlementCurrencyName))
            {
                if ((VM).SelectedPaymentCurrencyId != null || (VM).SelectedPaymentCurrencyId > 0)
                {
                    if (bp.Currency.Id == (VM).SelectedPaymentCurrencyId)
                    {
                        (VM).Rate = 1;
                    }
                }
            }
        }

        private void BtnFinancialAccountClick(object sender, RoutedEventArgs e)
        {
            var dialog = new TreeViewDialog();
            dialog.ShowDialog();
            var financialAccount = dialog.SelectedItems as FinancialAccount;
            if (financialAccount != null)
            {
                (VM).SelectedFinancialAccountId = financialAccount.Id;
                (VM).FinancialAccountName = financialAccount.Name;
            }
        }

        #endregion
    }
}