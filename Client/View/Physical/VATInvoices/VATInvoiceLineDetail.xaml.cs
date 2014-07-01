using System;
using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.VATInvoices
{
    /// <summary>
    /// VATInvoiceLineDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceLineDetail
    {
        #region Property

        public new VATInvoiceLineDetailVM VM { get; set; }
        public bool SaveStatus { get; set; }
        public int? VATInvoiceBPId { get; set; }
        public int? VATInvoiceInternalBPId { get; set; }
        public int VATInvoiceType { get; set; }

        #endregion

        #region Constructor

        public VATInvoiceLineDetail()
        {
            InitializeComponent();
        }

        public VATInvoiceLineDetail(int vatInvoiceBPId, int vatInvoiceInternalBPId, string moduleName, PageMode pageMode,
                                    List<VATInvoiceLine> showList, List<VATInvoiceLine> addList, int vtaInvoiceType)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            VATInvoiceType = vtaInvoiceType;
            VATInvoiceBPId = vatInvoiceBPId;
            VATInvoiceInternalBPId = vatInvoiceInternalBPId;
            InitializeComponent();
            ModuleName = moduleName;
            VM = new VATInvoiceLineDetailVM(VATInvoiceType) {AddVATInvoiceLines = addList, ShowVATInvoiceLines = showList};
            BindData();
            button2.IsEnabled = true;
        }

        public VATInvoiceLineDetail(int id, int vatInvoiceBPId, int vatInvoiceInternalBPId, string moduleName,
                                    PageMode pageMode, List<VATInvoiceLine> showList, List<VATInvoiceLine> addList,
                                    List<VATInvoiceLine> updateList, int vtaInvoiceType)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            VATInvoiceType = vtaInvoiceType;
            VATInvoiceBPId = vatInvoiceBPId;
            VATInvoiceInternalBPId = vatInvoiceInternalBPId;
            InitializeComponent();
            ModuleName = moduleName;
            VM = new VATInvoiceLineDetailVM(id, showList, addList, updateList,VATInvoiceType);
            BindData();
            button2.IsEnabled = false;
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
                VM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private new void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnQuotaClick(object sender, RoutedEventArgs e)
        {
            //审核通过，财务状态未完成，货运状态完成，点价完成，选中采购商的销售内贸批次,增票开票状态是未开票和部分开票
            int contractType = 0;
            if (VATInvoiceType == (int) DBEntity.EnumEntity.VATInvoiceType.Issue)
            {
                contractType = (int) ContractType.Sales;
            }
            else if (VATInvoiceType == (int) DBEntity.EnumEntity.VATInvoiceType.Receive)
            {
                contractType = (int) ContractType.Purchase;
            }
            string queryStr =
                string.Format(
                    "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.Contract.ContractType={2} and it.FinanceStatus=false and it.DeliveryStatus=true and it.PricingStatus={3} and (it.VATStatus!={4}) and (it.Contract.TradeType={5} or it.Contract.TradeType={6}) and it.Contract.BPId={7} and it.Contract.InternalCustomerId={8}",
                    (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded, contractType,
                    (int) PricingStatus.Complete, (int) QuotaVATStatus.Complete, (int) TradeType.LongDomesticTrade,
                    (int) TradeType.ShortDomesticTrade, VATInvoiceBPId, VATInvoiceInternalBPId);
            PopDialog dialog = PopDialogCreater.CreateDialog("QuotaForVATInvoice", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Quota;
            if (bp == null) return;
            VM.QuotaId = bp.Id;
            VM.QuotaNo = bp.QuotaNo;
        }

        #endregion
    }
}