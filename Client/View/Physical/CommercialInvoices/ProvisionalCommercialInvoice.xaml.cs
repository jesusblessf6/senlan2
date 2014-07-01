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
using Utility.Misc;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    /// Interaction logic for ProvisionalCommercialInvoice.xaml
    /// </summary>
    public sealed partial class ProvisionalCommercialInvoice
    {
        #region Property

        private readonly bool _canView;
        private readonly bool _canEdit;

        #endregion


        public ProvisionalCommercialInvoice()
        {
            InitializeComponent();

        }

        public ProvisionalCommercialInvoice(ContractType contractType, bool isFinalCommercialInv = false)
        {
            InitializeComponent();
            ContractType = contractType;
            ModuleName = ContractType == ContractType.Purchase ? "PurchaseCommercialInvoice" : "SaleCommercialInvoice";
            _canEdit = CheckPerm(PageMode.EditMode);
            _canView = CheckPerm(PageMode.ViewMode);

            InitTitle(isFinalCommercialInv);
            VM = new ProvisionalCommercialInvoiceVM(contractType, isFinalCommercialInv) { ContractType = contractType };
            BindData();
        }

        public ProvisionalCommercialInvoice(ContractType contractType, int id, bool isFinalCommercialInv = false)
        {
            InitializeComponent();
            ContractType = contractType;
            ModuleName = ContractType == ContractType.Purchase ? "PurchaseCommercialInvoice" : "SaleCommercialInvoice";
            _canEdit = CheckPerm(PageMode.EditMode);
            _canView = CheckPerm(PageMode.ViewMode);

            InitTitle(isFinalCommercialInv);
            VM = new ProvisionalCommercialInvoiceVM(id, contractType, isFinalCommercialInv) { ContractType = contractType };
            BindData();
        }

        public ContractType ContractType { get; set; }
        public ProvisionalCommercialInvoiceVM VM { get; set; }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            RefreshLetterOfCredits();
            RefreshDelivery();
            DataGridAttachmentRefresh();
        }

        private void InitTitle(bool isFinalCommercialInv = false)
        {
            if (ContractType == ContractType.Purchase)
            {
                lbTitle.Content = isFinalCommercialInv ? "采购商业发票" : ResCommercialInvoice.PurchaseCommercialInvoiceProvisional;
                deliverieName.Content = Properties.Resources.BL;
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (ContractType == ContractType.Sales)
            {
                lbTitle.Content = isFinalCommercialInv ? "销售商业发票" : ResCommercialInvoice.SalesCommercialInvoiceProvisional;
                deliverieName.Content = Properties.Resources.DeliveryForm;
                lbSupplier.Content = Properties.Resources.Buyer;
            }
        }

        /// <summary>
        /// 批次弹出框（弹出审批完成且财务状态未完成的批次）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    VM.Price = 0;
                    VM.SelectCurrencyId = 0;
                    VM.SettlementRate = 0;
                    if (quota.PricingStatus == (int)PricingStatus.Complete)
                    {
                        VM.SelectCurrencyId = quota.PricingCurrencyId ?? 0;
                        VM.QuotaCurrencyId = quota.PricingCurrencyId ?? 0;
                        VM.Currency = quota.Currency.Name;
                        if (VM.SelectCurrencyId != 0)
                        {
                            VM.SettlementRate = 1;
                        }
                        VM.Price = quota.FinalPrice ?? 0;
                    }
                    else
                    {
                        if (quota.PricingCurrencyId != null)
                        {
                            VM.QuotaCurrencyId = (int)quota.PricingCurrencyId;
                            VM.Currency = quota.Currency.Name;
                        }
                    }
                    VM.Currency = quota.Currency.Name;

                    VM.QuotaId = quota.Id;
                    VM.QuotaNo = quota.QuotaNo;
                    VM.SupplierName = quota.Contract.BusinessPartner.ShortName;

                    VM.DeliveryTerm = quota.ShipTerm;


                    VM.LetterOfCredits = null;
                    VM.AddLetterOfCredit = null;
                    VM.DeleteLetterOfCredit = null;
                    VM.Deliveries = null;
                    VM.AddDelivery = null;
                    VM.DeleteDelivery = null;
                    VM.NetWeights = 0;
                    VM.GrossWeight = 0;
                    VM.Interest = 0;
                    VM.SelectPaymentMeanId = 0;


                    VM.SelectedBankAccountID = 0;
                    VM.Money = 0;
                    VM.SetWeights();
                    VM.SetInterest();
                    RefreshLetterOfCredits();
                    RefreshDelivery();
                    VM.ChangeQuota = true;//更改批次标志

                    VM.GetDeliveryByQuota(quota.Id);
                    RefreshDelivery();
                    if (quota.PaymentMeanId.HasValue)
                    {
                        VM.SelectPaymentMeanId = quota.PaymentMeanId.Value;
                    }
                }
                VM.GetBankAccount(quota.Id);
            }
        }

        private string GetQueryStr()
        {
            string queryStr = "(it.ApproveStatus == " + (int)ApproveStatus.NoApproveNeeded +
                   "  or it.ApproveStatus == " + (int)ApproveStatus.Approved +
                   " ) and  it.FinanceStatus==False and it.Contract.ContractType==" + (int)ContractType +
                   " and (it.Contract.TradeType==" + (int)TradeType.LongForeignTrade + " or it.Contract.TradeType==" +
                   (int)TradeType.ShortForeignTrade + ") and (it.IsCIFinished = false or it.IsCIFinished is NULL) ";
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

            if (VM.IsFinalCommercialInv)
            {
                queryStr += " and (it.PricingStatus = " + (int)PricingStatus.Complete + " or it.PricingStatus == " + (int)PricingStatus.Partial + ") and " + "(it.IsCIFinished = false or it.IsCIFinished is NULL)";
            }

            return queryStr;
        }

        /// <summary>
        /// 信用证弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId.HasValue)
            {
                string str = "it.FinancialStatus = False and it.QuotaId =" + VM.QuotaId;
                PopDialog dialog = PopDialogCreater.CreateDialog("LetterOfCredit", str, null);
                dialog.ShowDialog();
                var letterOfCredit = dialog.SelectedItem as LetterOfCredit;
                if (letterOfCredit != null)
                {
                    var frm = new LCDistribution(letterOfCredit, VM.AddRels, VM.DeleteRels);
                    frm.ShowDialog();
                    if (frm.VM.SaveStatus)
                    {
                        VM.AppendLetterOfCredit(frm.AddRel);
                        RefreshLetterOfCredits();
                    }
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            }
        }

        /// <summary>
        /// 提单(发货单)弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId.HasValue)
            {
                string str = "it.CommercialInvoiceId is null and (it.WarrantId is null or (it.WarrantId is not null and it.DeliveryType = " + (int)DeliveryType.ExternalTDBOL + ")) and it.QuotaId =" + VM.QuotaId;
                PopDialog dialog = PopDialogCreater.CreateDialog("Delivery", str, null, null, null, 0, 0, false, null, new List<SortCol> { new SortCol { ColName = "IssueDate", ByDescending = true } });
                dialog.ShowDialog();
                var delivery = dialog.SelectedItem as Delivery;
                if (delivery != null)
                {
                    VM.AppendDeliveries(delivery);
                    RefreshDelivery();

                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            }
        }

        private void RefreshLetterOfCredits()
        {
            dataGrid1.DataContext = VM.LCCIRels;
            dataGrid1.Items.Refresh();
        }

        private void RefreshDelivery()
        {
            dataGrid2.DataContext = VM.Deliveries;
            dataGrid2.Items.Refresh();
        }

        private void CurrencyTextBox1LostFocus(object sender, RoutedEventArgs e)
        {

            VM.SetPrice();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void DeliveryDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit && VM.IsDeliveryDeleteEnable;
            e.Handled = true;
        }

        private void DeliveryDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (id != 0)
            {
                VM.RemoveDeliveries(id);
                RefreshDelivery();
            }
            e.Handled = true;
        }

        private void LetterOfCreditDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = VM.IsLCDeleteEnable;
            e.Handled = true;
        }

        private void LetterOfCreditDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (id != 0)
            {
                VM.RemoveLetterOfCredit(id);
                RefreshLetterOfCredits();
            }
            e.Handled = true;
        }

        private void ComboBox1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.LoadRate();
            if (VM.LoadCount++ == 0)
                return;
            VM.SetMoney();
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        private void CurrencyTextBox2LostFocus(object sender, RoutedEventArgs e)
        {
            VM.SetMoney();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload { Header = Properties.Resources.AttachmentUpload };
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment { FileName = frm.SavePath, DocumentId = 12 };
                VM.AddAttachment(attachment);
                DataGridAttachmentRefresh();
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
            Attachment attachment = VM.GetAttachmentById(id, VM.Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
            e.Handled = true;
        }

        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                VM.RemoveAttachment(id);
                DataGridAttachmentRefresh();
            }
            e.Handled = true;
        }

        /// <summary>
        /// 刷新附件列表
        /// </summary>
        private void DataGridAttachmentRefresh()
        {
            dataGridAttachment.Items.Refresh();
        }

        private void CurrencyTextBoxNetWeightLostFocus(object sender, RoutedEventArgs e)
        {
            VM.ChangeNetWeight();
        }
    }
}