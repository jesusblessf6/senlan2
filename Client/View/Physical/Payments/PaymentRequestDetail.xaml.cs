using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Payments;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.Payments
{
    /// <summary>
    /// PaymentRequestDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentRequestDetail
    {
        #region Member

        private const int DeliveryPerPage = 10;
        private readonly bool _canDelete;

        #endregion

        #region Property

        public PaymentRequestDetailVM VM { get; set; }
        public Quota Quota { get; set; }
        public BusinessPartner BusinessPartner { get; set; }
        public Delivery Delivery { get; set; }

        #endregion

        #region Custructor

        public PaymentRequestDetail()
        {
            InitializeComponent();
            ModuleName = "PaymentRequest";
            VM = new PaymentRequestDetailVM();
            _canDelete = CheckPerm(PageMode.DeleteMode);
            BindData();
        }

        public PaymentRequestDetail(int id, PageMode pageMode)
            :base(pageMode)
        {
            InitializeComponent();
            ModuleName = "PaymentRequest";
            VM = new PaymentRequestDetailVM(id);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            BindData();
            VM.LoadDeliveryLineCount();
            VM.LoadDelDeliveryLines();
            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl1.Init(VM.DeliveryLineCount, DeliveryPerPage);
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new PaymentRequestHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void DraftSave(object sender, RoutedEventArgs e)
        {
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            RedirectTo(new PaymentRequestHome());
        }

        private void DeliveryDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DeliveryDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (VM.ObjectId != 0)
            {
                Delivery dl = VM.Deliverys.FirstOrDefault(o => o.Id == id);
                if (dl != null)
                {
                    if (VM.DelDeliverys.All(c => c.Id != dl.Id))
                    {
                        VM.DelDeliverys.Add(dl);
                    }
                }
            }
            VM.Deliverys.Remove(VM.Deliverys.FirstOrDefault(o => o.Id == id));
            deliverydataGrid.ItemsSource = VM.Deliverys;
            deliverydataGrid.Items.Refresh();
        }

        private void PRDeliverySearch(object sender, RoutedEventArgs e)
        {
            string queryStr = "it.PaymentRequestId is null and it.QuotaId=" + Convert.ToInt32(VM.QuotaId);
            PopDialog dialog = PopDialogCreater.CreateDialog("Delivery", queryStr, null);
            dialog.ShowDialog();

            var delivery = dialog.SelectedItem as Delivery;
            if (delivery != null)
            {
                if (VM.Deliverys.Any(o => o.Id == delivery.Id))
                {
                    MessageBox.Show(ResPayment.DeliveryLineExisted);
                }
                else
                {
                    VM.Deliverys.Add(delivery);
                    if (VM.ObjectId == 0)
                    {
                        VM.LoadDeliveryLineCount();
                    }
                    pagingControl1.OnNewPage += pagingControl1_OnNewPage;
                    pagingControl1.Init(VM.DeliveryLineCount, DeliveryPerPage);
                }
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// 币种关联收付款账号下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxCurrencySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.LoadPayBankAccounts();
            VM.LoadReceiveBankAccounts();
        }

        /// <summary>
        /// 币种关联收付款账号下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxPayBPSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.LoadPayBankAccounts();
        }

        /// <summary>
        /// 付款用途
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxPaymentUsagesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.LoadPaymentMeans();
        }

        /// <summary>
        /// 采购批次弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPurchaseQuotaClick(object sender, RoutedEventArgs e)
        {
            string queryStr = "(it.ApproveStatus=@p2 or it.ApproveStatus=@p3) and it.FinanceStatus = false and (it.IsPaymentRequestFinished is null or it.IsPaymentRequestFinished = false) and ((it.Contract.ContractType = @p1 and (it.Contract.TradeType = @p4 or it.Contract.TradeType = @p5)) or (it.Contract.TradeType = @p6) or (it.Contract.TradeType = @p7))";
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

            //针对长然仅对制定关联公司做付款申请，其他公司暂时去掉
            //queryStr += (" and it.Contract.InternalCustomer.IsDefault = true");
            var parameters = new List<object>
                                 {
                                     Convert.ToInt32(ContractType.Purchase),
                                     Convert.ToInt32(ApproveStatus.Approved),
                                     Convert.ToInt32(ApproveStatus.NoApproveNeeded),
                                     Convert.ToInt32(TradeType.LongDomesticTrade),
                                     Convert.ToInt32(TradeType.ShortDomesticTrade),
                                     Convert.ToInt32(TradeType.LongForeignTrade),
                                     Convert.ToInt32(TradeType.ShortForeignTrade)
                                 };
            var includes = new List<string> { "PaymentRequests", "PaymentRequests.PaymentUsage", "PaymentRequests.PaymentUsage.FinancialAccount" };
            PopDialog dialog = PopDialogCreater.CreateDialog("QuotaForPayment", queryStr, parameters,null,null,0,0,false,includes);
            dialog.ShowDialog();
            Quota = dialog.SelectedItem as Quota;
            if (Quota != null)
            {
                VM.InvoiceId = null;
                VM.InvoiceNo = string.Empty;
                VM.RequestAmount = 0;
                VM.QuotaId = Quota.Id;
                VM.QuotaNo = Quota.QuotaNo;
                VM.TradeTypeId = Quota.Contract.TradeType;
                VM.GetQuotaDetail(Quota);
                comboBox1.SelectedValue = Quota.Contract.InternalCustomerId;
                VM.ReceiveBPId = Quota.Contract.BPId;
                VM.ShortName = Quota.Contract.BusinessPartner.ShortName;
                //VM.LoadPayBankAccounts();
                VM.LoadReceiveBankAccounts();
                VM.LoadDeliveryLines();
                VM.LoadDelDeliveryLines();
                if (VM.ObjectId != 0)
                {
                    if (VM.QuotaId == VM.SelectDeliveryLine())
                    {
                        VM.LoadDeliveryLineCount();
                    }
                    else
                    {
                        VM.LoadDeliveryLineCount();
                        VM.LoadDelDeliveryLines();

                        if (VM.DeliveryLineCount > 0)
                        {
                            foreach (Delivery dl in VM.Deliverys)
                            {
                                VM.DelDeliverys.Add(dl);
                            }
                        }
                        VM.LoadDeliveryLines();
                    }
                }
                pagingControl1.OnNewPage += pagingControl1_OnNewPage;
                pagingControl1.Init(VM.DeliveryLineCount, DeliveryPerPage);
            }
        }

        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.DeliveryLineFrom = e.From;
            VM.DeliveryLineTo = e.To;

            deliverydataGrid.ItemsSource = VM.Deliverys;
            deliverydataGrid.Items.Refresh();
        }

        /// <summary>
        /// 收款客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();

            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                VM.ReceiveBPId = BusinessPartner.Id;
                VM.ShortName = BusinessPartner.ShortName;
                VM.LoadReceiveBankAccounts();
            }
        }

        /// <summary>
        /// 商业发票弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (!VM.QuotaId.HasValue)
            {
                MessageBox.Show("请选择批次！");
            }
            else
            {
                string queryStr = " it.QuotaId = " + VM.QuotaId;
                PopDialog dialog = PopDialogCreater.CreateDialog("Invoice",queryStr,null);
                dialog.ShowDialog();

                CommercialInvoice invoice = dialog.SelectedItem as CommercialInvoice;
                if (invoice != null)
                {
                    VM.GetInvoiceDetail(invoice);

                }
            }
        }
        #endregion
    }
}