using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.CommercialInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Client.View.Attachments;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    /// Interaction logic for FinalCommercialInvoice.xaml
    /// </summary>
    public sealed partial class FinalCommercialInvoice
    {
        public FinalCommercialInvoice()
        {
            InitializeComponent();
        }

        public FinalCommercialInvoice(ContractType contractType)
        {
            InitializeComponent();
            ContractType = contractType;
            ModuleName = ContractType == ContractType.Purchase ? "PurchaseCommercialInvoice" : "SaleCommercialInvoice";
            InitTitle();
            VM = new FinalCommercialInvoiceVM(contractType);
            BindData();
        }

        public FinalCommercialInvoice(ContractType contractType, int id)
        {
            InitializeComponent();
            ContractType = contractType;
            ModuleName = ContractType == ContractType.Purchase ? "PurchaseCommercialInvoice" : "SaleCommercialInvoice";
            InitTitle();
            VM = new FinalCommercialInvoiceVM(id, contractType);
            BindData();
        }

        public ContractType ContractType { get; set; }
        public FinalCommercialInvoiceVM VM { get; set; }

        private void BtnQuotaClick(object sender, RoutedEventArgs e)
        {
            string str = GetQueryStr();
            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", str, null);
            dialog.ShowDialog();
            var quota = dialog.SelectedItem as Quota;
            if (quota != null)
            {
                if (quota.Id != VM.QuotaId)
                {
                    if (quota.PricingStatus == (int) PricingStatus.Complete)
                    {
                        VM.Price = quota.FinalPrice ?? 0;
                    }
                    VM.QuotaId = quota.Id;
                    VM.QuotaNo = quota.QuotaNo;
                    VM.SupplierName = quota.Contract.BusinessPartner.ShortName;
                    VM.Currency = quota.Currency.Name;
                    VM.DeliveryTerm = quota.ShipTerm;
                    VM.SelectCurrencyId = 0;
                    VM.SettlementRate = null;
                    if (quota.PricingCurrencyId != null)
                    {
                        VM.QuotaCurrencyId = (int)quota.PricingCurrencyId;
                        VM.SelectCurrencyId = (int)quota.PricingCurrencyId;
                    }


                    //VM.Price = 0;
                    VM.SelectedBankAccountID = 0;
                    VM.BankAccountList = null;
                    VM.Money = 0;

                    VM.Invoices = null;
                    VM.AddInvoice = null;
                    VM.DeleteInvoice = null;
                    VM.LbName = Properties.Resources.Payable + " / " + Properties.Resources.Receivable;
                    VM.Balance = 0;
                    VM.NetWeights = 0;
                    VM.GrossWeight = 0;
                    VM.Interest = 0;
                    VM.SelectPaymentMeanId = 0;
                    RefreshInvoice();
                    if (quota.PaymentMeanId.HasValue)
                    {
                        VM.SelectPaymentMeanId = quota.PaymentMeanId.Value;
                    }

                    VM.LoadInvoice(quota.Id);
                    RefreshInvoice();

                    VM.ChangeQuota = true;//更改批次标志
                }
                VM.GetBankAccount(quota.Id);
            }
        }

        private void InitTitle()
        {
            if (ContractType == ContractType.Purchase)
            {
                lbTitle.Content = ResCommercialInvoice.PurchaseCommercialInvoiceFinal;
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (ContractType == ContractType.Sales)
            {
                lbTitle.Content = ResCommercialInvoice.SalesCommercialInvoiceFinal;
                lbSupplier.Content = Properties.Resources.Buyer;
            }
        }

        private void RefreshInvoice()
        {
            dataGrid1.DataContext = VM.Invoices;
            dataGrid1.Items.Refresh();
        }

        private string GetQueryStr()
        {
            string queryStr = "(it.ApproveStatus == " + (int)ApproveStatus.NoApproveNeeded +
                   "  or it.ApproveStatus == " + (int)ApproveStatus.Approved +
                   " ) and  it.FinanceStatus==False and it.Contract.ContractType==" + (int)ContractType +
                   " and (it.Contract.TradeType==" + (int)TradeType.LongForeignTrade + " or it.Contract.TradeType==" +
                   (int)TradeType.ShortForeignTrade + ") and (it.PricingStatus==" + (int)PricingStatus.Complete + " or it.PricingStatus == " + (int)PricingStatus.Partial + ") and " +
                   "(it.IsCIFinished = false or it.IsCIFinished is NULL)";
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

            return queryStr;
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            RefreshInvoice();
            RefreshAttachment();
        }

        /// <summary>
        /// 刷新附件列表
        /// </summary>
        public void RefreshAttachment()
        {
            dataGridAttachment.DataContext = VM.Attachments;
            dataGridAttachment.Items.Refresh();
        }

        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            Attachment attachment = VM.GetAttachmentById(id, VM.Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 附件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                VM.RemoveAttachment(id);
                RefreshAttachment();
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

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentClick(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload { Header = Properties.Resources.AttachmentUpload };
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment { FileName = frm.SavePath, DocumentId = 13 };
                VM.AddAttachment(attachment);
                RefreshAttachment();
            }
        }

        /// <summary>
        /// 临时发票弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId.HasValue)
            {
                string str = "it.FinalInvoiceId is null and it.QuotaId =" + VM.QuotaId + " and it.InvoiceType=" +
                             (int) CommercialInvoiceType.Provisional;
                PopDialog dialog = PopDialogCreater.CreateDialog("ProvisionalInvoice", str, null);
                dialog.ShowDialog();
                var invoice = dialog.SelectedItem as CommercialInvoice;
                if (invoice != null)
                {
                    VM.AppendInvoice(invoice);
                    RefreshInvoice();
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            }
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new CommercialInvoiceHome(ContractType));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void InvoiceCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void InvoiceExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            VM.Removeinvoice(id);
            RefreshInvoice();
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }
    }
}