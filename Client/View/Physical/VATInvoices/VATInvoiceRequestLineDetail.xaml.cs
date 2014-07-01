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
    /// VATInvoiceRequestLineDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceRequestLineDetail
    {
        #region Member

        private bool _saveStatus;

        #endregion

        #region Property

        public new VATInvoiceRequestLineDetailVM VM { get; set; }

        public int? VATInvoiceBPId { get; set; }

        public int? VATInvoiceInternalBPId { get; set; }

        public bool SaveStatus
        {
            get { return _saveStatus; }
            set { _saveStatus = value; }
        }

        #endregion

        #region Constructor

        public VATInvoiceRequestLineDetail()
        {
            InitializeComponent();
        }

        public VATInvoiceRequestLineDetail(int vatInvoiceBPId, int vatInvoiceInternalBPId, string moduleName,
                                           PageMode pageMode, List<VATInvoiceRequestLine> showList,
                                           List<VATInvoiceRequestLine> addList, List<Quota> quotaList)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            VATInvoiceInternalBPId = vatInvoiceInternalBPId;
            VATInvoiceBPId = vatInvoiceBPId;
            InitializeComponent();
            ModuleName = moduleName;
            VM = new VATInvoiceRequestLineDetailVM
                     {AddVATInvoiceRequestLines = addList, ShowVATInvoiceRequestLines = showList, QuotaList = quotaList};
            BindData();
        }

        public VATInvoiceRequestLineDetail(int id, int vatInvoiceBPId, int vatInvoiceInternalBPId, string moduleName,
                                           PageMode pageMode, List<VATInvoiceRequestLine> showList,
                                           List<VATInvoiceRequestLine> addList, List<VATInvoiceRequestLine> updateList, List<Quota> quotaList)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            VATInvoiceInternalBPId = vatInvoiceInternalBPId;
            VATInvoiceBPId = vatInvoiceBPId;
            InitializeComponent();
            ModuleName = moduleName;
            VM = new VATInvoiceRequestLineDetailVM(id, showList, addList, updateList, quotaList);
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
                VM.Save();
                _saveStatus = true;
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

        private void BtnQoutaClick(object sender, RoutedEventArgs e)
        {
            //审核通过，财务状态未完成，货运状态完成，点价完成，选中采购商的销售内贸批次,增票开票状态是未开票和部分开票
            string queryStr =
                string.Format(
                    "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.Contract.ContractType={2} and it.FinanceStatus=false and it.DeliveryStatus=true and it.PricingStatus={3} and (it.VATStatus!={4}) and (it.Contract.TradeType={5} or it.Contract.TradeType={6}) and it.Contract.BPId={7} and it.Contract.InternalCustomerId={8} and (it.IsVatRequestFinished = false or it.IsVatRequestFinished is null)",
                    (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded, (int) ContractType.Sales,
                    (int) PricingStatus.Complete, (int) QuotaVATStatus.Complete, (int) TradeType.LongDomesticTrade,
                    (int) TradeType.ShortDomesticTrade, VATInvoiceBPId, VATInvoiceInternalBPId);
            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Quota;
            if (bp == null) return;
            VM.QuotaId = bp.Id;
            VM.QuotaNo = bp.QuotaNo;
        }

        #endregion
    }
}