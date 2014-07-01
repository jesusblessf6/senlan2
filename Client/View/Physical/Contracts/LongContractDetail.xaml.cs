using System.Windows;
using System.Windows.Input;
using Client.View.Attachments;
using Client.View.Physical.Pricings;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Contracts;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ErrorManagement;
using System;
using Infralution.Localization.Wpf;
using System.Windows.Controls;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for PurchaseContractWithQuotas.xaml
    /// </summary>
    public sealed partial class LongContractDetail
    {
        #region Property

        public ContractType ContractType { get; set; }
        public TradeType TradeType { get; set; }

        private readonly bool _canView;
        private readonly bool _canEdit;
        private readonly bool _canDelete;

        #endregion

        #region Constructor

        public LongContractDetail()
        {
            InitializeComponent();
        }

        public LongContractDetail(TradeType tradeType, ContractType contractType, PageMode pageMode, string pageName)
            : base(pageMode, pageName)
        {
            InitializeComponent();

            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            ContractType = contractType;
            TradeType = tradeType;

            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canView = CheckPerm(PageMode.ViewMode);

            VM = new LongContractDetailVM(tradeType, contractType);
            LoadBPTitle();
            BindData();
        }

        public LongContractDetail(TradeType tradeType, ContractType contractType, int id, PageMode pageMode, string pageName)
            : base(pageMode, pageName)
        {
            InitializeComponent();
            
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            ContractType = contractType;
            TradeType = tradeType;

            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canView = CheckPerm(PageMode.ViewMode);

            VM = new LongContractDetailVM(tradeType, ContractType, id);
            LoadBPTitle();
            BindData();
        }

        #endregion

        #region Method

        private void LoadBPTitle()
        {
            if (ContractType == ContractType.Purchase)
            {
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (ContractType == ContractType.Sales)
            {
                lbSupplier.Content = Properties.Resources.Buyer;
            }
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            Refresh();
        }

        /// <summary>
        /// 刷新附件列表
        /// </summary>
        public override void Refresh()
        {
            dataGridQuotas.Items.Refresh();
            dataGridAttachment.Items.Refresh();
        }

        /// <summary>
        /// After saving, go to the home page
        /// </summary>
        protected override void AfterSave()
        {
            MessageBox.Show(GetSuccessMessage());
            RedirectTo(new ContractHome(ContractType));
        }

        #endregion

        #region Event
        /// <summary>
        /// 币种关联收付款账号下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxPayBPSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((LongContractDetailVM)VM).LoadPayBankAccounts();
        }

        /// <summary>
        /// 新增批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            var frm = new QuotaDetail(TradeType, ContractType, PageMode.AddMode, (LongContractDetailVM)VM);
            frm.ShowDialog();
            ((LongContractDetailVM)VM).Quotas = ((QuotaDetailVM)frm.VM).Quotas;
            ((LongContractDetailVM)VM).AddQuotas = ((QuotaDetailVM)frm.VM).AddedQuotas;
            if (!((LongContractDetailVM)VM).SignDate.HasValue)
            {
                ((LongContractDetailVM)VM).SignDate = ((QuotaDetailVM)frm.VM).ImplementedDate;
            }
            Refresh();
        }

        /// <summary>
        /// 编辑批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;

            if (id > 0 && !((LongContractDetailVM)VM).QuotaCanEditWithApproveStatus(id))
            {
                MessageBox.Show(ResContract.DuringApprovalError);
                return;
            }

            if (id != 0)
            {
                var frm = new QuotaDetail(id, TradeType, ContractType, PageMode.EditMode, (LongContractDetailVM)VM);
                frm.ShowDialog();
                ((LongContractDetailVM)VM).Quotas = ((QuotaDetailVM)frm.VM).Quotas;
                ((LongContractDetailVM)VM).AddQuotas = ((QuotaDetailVM)frm.VM).AddedQuotas;
                ((LongContractDetailVM)VM).UpdateQuotas = ((QuotaDetailVM)frm.VM).UpdatedQuotas;
            }
            Refresh();
        }

        /// <summary>
        /// 删除批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;

            if (id > 0 && !((LongContractDetailVM)VM).QuotaCanEditWithApproveStatus(id))
            {
                MessageBox.Show(ResContract.DuringApprovalError2);
                return;
            }

            if (id != 0)
            {
                if (MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.Nullify, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    ((LongContractDetailVM)VM).DeleteQuota(id);
                    Refresh();
                }
            }
        }

        /// <summary>
        /// 供应商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupplierClick(object sender, RoutedEventArgs e)
        {
            const string queryStr = "it.CustomerType=1 or it.CustomerType=3";
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                ((LongContractDetailVM)VM).SupplierId = bp.Id;
                ((LongContractDetailVM)VM).SupplierName = bp.ShortName;
                ((LongContractDetailVM)VM).Description = bp.Remark;
            }
                
        }

        private void PricingViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void PricingViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var pl = new PricingList(id);
            pl.Show();
            e.Handled = true;
        }

        private void QuotaCanEditExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void QuotaCanDeleteExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload { Header = Properties.Resources.AttachmentUpload };
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment { FileName = frm.SavePath, DocumentId = 3 };
                ((LongContractDetailVM)VM).AddAttachment(attachment);
                Refresh();
            }
        }

        private void AttachmentDownLoadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void AttachmentDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            Attachment attachment = ((LongContractDetailVM)VM).GetAttachmentById(id, ((LongContractDetailVM)VM).Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ((LongContractDetailVM)VM).RemoveAttachment(id);
                Refresh();
            }
        }

        #endregion

        protected override void Save(object sender, RoutedEventArgs e)
        {
            if (((LongContractDetailVM)VM).IsPopupContraryDocumentNoEmptyInfo())
            {
                MessageBoxResult result = MessageBox.Show("关联公司间交易没有填写对手盘合同号，是否要继续？", "提示",
                                                                  MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                    return;
            }
            if (ContractType == DBEntity.EnumEntity.ContractType.Sales && (TradeType == DBEntity.EnumEntity.TradeType.LongDomesticTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortDomesticTrade))
            {
                if (((LongContractDetailVM)VM).PayBankAccountId == null || ((LongContractDetailVM)VM).PayBankAccountId <= 0)
                {
                    MessageBoxResult dr = MessageBox.Show("未选择银行账号，确定保存吗？", "提示", MessageBoxButton.OKCancel);
                    if (dr == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
            }
            base.Save(sender, e);
        }
    }
}
