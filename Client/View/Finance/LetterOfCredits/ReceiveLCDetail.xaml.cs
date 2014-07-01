using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.Attachments;
using Client.View.PopUpDialog;
using Client.ViewModel.Finance.LetterOfCredits;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Finance.LetterOfCredits
{
    /// <summary>
    /// PresentationDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PresentationDetail
    {
        #region Property

        public ReceiveLCDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public PresentationDetail()
        {
            InitializeComponent();
            ModuleName = "LetterOfCreditSetting";
            VM = new ReceiveLCDetailVM();
            BindData();
        }

        public PresentationDetail(PageMode pageMode) : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "LetterOfCreditSetting";
            VM = new ReceiveLCDetailVM();
            BindData();
        }

        public PresentationDetail(int id, PageMode pageMode) : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "LetterOfCreditSetting";
            VM = new ReceiveLCDetailVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.Deliveries;
            dataGrid1.Items.Refresh();
            dataGrid2.ItemsSource = VM.ShowCommercialInvoiceLines;
            dataGrid2.Items.Refresh();
            dataGridAttachment.ItemsSource = VM.Attachments;
            dataGridAttachment.Items.Refresh();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new LetterOfCreditHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            RedirectTo(new LetterOfCreditHome());
        }

        #endregion

        #region Event

        private void CommercialInvoiceDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void CommercialInvoiceDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            VM.CommercialInvoiceId = null;
            VM.ShowCommercialInvoiceLines.Clear();
            e.Handled = true;
        }

        private void DeliveryDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void DeliveryDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var deliveryId = (int) e.Parameter;
            for (int i = 0; i < VM.Deliveries.Count; i++)
            {
                if (VM.Deliveries[i].Id == deliveryId)
                {
                    VM.Deliveries.RemoveAt(i);
                }
            }
            if (VM.PromptBasisId == null)
            {
                return;
            }
            VM.Interest = VM.LCRateCalculation((LCPromptBasis)VM.PromptBasisId, VM.PresentAmount, VM.Deliveries,
                                               VM.Float, VM.IBORValue, VM.LCDays, VM.IssueDate);
            e.Handled = true;
        }


        /// <summary>
        /// 刷新附件列表
        /// </summary>
        public override void Refresh()
        {
            dataGrid1.Items.Refresh();
            dataGridAttachment.ItemsSource = VM.Attachments;
            dataGridAttachment.Items.Refresh();
        }


        private void BtnAttachmentClick(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload { Header = Properties.Resources.AttachmentUpload };
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment {FileName = frm.SavePath, DocumentId = 3};
                VM.AddAttachment(attachment);
                Refresh();
            }
        }

        private void AttachmentDownLoadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AttachmentDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            Attachment attachment = VM.GetAttachmentById(id, VM.Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                VM.RemoveAttachment(id);
                Refresh();
            }
        }

        private void LCTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VM.LCType > 0)
            {
                switch (VM.LCType)
                {
                    case ((int) LCType.LCSight):
                        ctxtLCDays.Visibility = Visibility.Hidden;
                        cbxPromptBasis.Visibility = Visibility.Hidden;
                        cbxIC.Visibility = Visibility.Hidden;
                        ctxtFloat.Visibility = Visibility.Hidden;
                        ctxtIBORValue.Visibility = Visibility.Hidden;
                        ctxtInterest.Visibility = Visibility.Hidden;
                        lbAft.Visibility = Visibility.Hidden;
                        lblFloat.Visibility = Visibility.Hidden;
                        lblIC.Visibility = Visibility.Hidden;
                        lblInterest.Visibility = Visibility.Hidden;
                        lblLCDays.Visibility = Visibility.Hidden;
                        lblVlaue.Visibility = Visibility.Hidden;
                        groupBox3.Visibility = Visibility.Collapsed;
                        groupBox4.Visibility = Visibility.Collapsed;
                        break;
                    case ((int) LCType.LCUsance):
                        ctxtLCDays.Visibility = Visibility.Visible;
                        cbxPromptBasis.Visibility = Visibility.Visible;
                        cbxIC.Visibility = Visibility.Visible;
                        ctxtFloat.Visibility = Visibility.Visible;
                        ctxtIBORValue.Visibility = Visibility.Visible;
                        ctxtInterest.Visibility = Visibility.Visible;
                        lbAft.Visibility = Visibility.Visible;
                        lblFloat.Visibility = Visibility.Visible;
                        lblIC.Visibility = Visibility.Visible;
                        lblInterest.Visibility = Visibility.Visible;
                        lblLCDays.Visibility = Visibility.Visible;
                        lblVlaue.Visibility = Visibility.Visible;
                        groupBox3.Visibility = Visibility.Visible;
                        groupBox4.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int) BusinessPartnerType.Customer,
                                            (int) BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.ApplicantId = bp.Id;
            VM.ApplicantName = bp.ShortName;
        }

        private void BtnQoutaClick(object sender, RoutedEventArgs e)
        {
            string queryStr =
                string.Format(
                    "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.Contract.ContractType={2}  and (it.Contract.TradeType={3} or it.Contract.TradeType={4}) and it.FinanceStatus=false and (it.IsFundflowFinished = false or it.IsFundflowFinished is NULL)",
                    (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded, (int) ContractType.Sales,
                    (int) TradeType.ShortForeignTrade, (int) TradeType.LongForeignTrade);
            if (VM.IdList != null && VM.IdList.Count > 0)
            {
                queryStr += string.Format(" and (");
                for (int j = 0; j < VM.IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format(" it.Contract.InternalCustomerId = {0} ", VM.IdList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                }
                queryStr += string.Format(" )");
            }
            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Quota;
            if (bp == null) return;
            VM.SelectedQuotaId = bp.Id;
            VM.QuotaNo = bp.QuotaNo;
            VM.ApplicantId = bp.Contract.BusinessPartner.Id;
            VM.ApplicantName = bp.Contract.BusinessPartner.ShortName;
            VM.BeneficiaryId = bp.Contract.InternalCustomer.Id;
            VM.Deliveries.Clear();
            VM.CommercialInvoiceId = null;
            VM.CommercialInvoiceName = null;
            VM.ShowCommercialInvoiceLines.Clear();
        }

        private void BtnDeliveryClick(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedQuotaId == null || VM.SelectedQuotaId <= 0)
            {
                //获取已审批或无需审批，非复印件,未与LC关联的提单
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
                return;
            }
            
            string queryStr = string.Format(
                "((it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.IsCopy={2} and (it.DeliveryType={3} or it.DeliveryType={4}) and it.QuotaId={5}and it.FinanceStatus=false) and it.LCId is Null",
                (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded, false,
                (int)DeliveryType.ExternalMDBOL, (int)DeliveryType.ExternalMDWW, VM.SelectedQuotaId);
            var dialog = PopDialogCreater.CreateDialog("Delivery", queryStr, null,null,null,0,0,false,
                                                       new List<string> {"LetterOfCredit"});
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Delivery;
            if (bp == null) return;
            int count = 0;
            foreach (Delivery dlvline in VM.Deliveries)
            {
                if (dlvline.Id == bp.Id)
                {
                    count = 1;
                }
            }
            if (count <= 0)
            {
                VM.Deliveries.Add(bp);
            }
            if (VM.PromptBasisId == null)
            {
                return;
            }
            VM.Interest = VM.LCRateCalculation((LCPromptBasis)VM.PromptBasisId, VM.PresentAmount, VM.Deliveries,
                                               VM.Float, VM.IBORValue, VM.LCDays, VM.IssueDate);
        }

        private void BtnInvoiceClick(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedQuotaId == null || VM.SelectedQuotaId <= 0)
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
                return;
            }
            
            string queryStr = string.Format("it.QuotaId={0}", VM.SelectedQuotaId);
            var dialog = PopDialogCreater.CreateDialog("ProvisionalInvoice", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as CommercialInvoice;
            if (bp == null) return;
            VM.CommercialInvoiceId = bp.Id;
            VM.ShowCommercialInvoiceLines.Clear();
            VM.ShowCommercialInvoiceLines.Add(bp);
        }

        #endregion
    }
}