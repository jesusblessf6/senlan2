using System;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.VATInvoices
{
    /// <summary>
    /// VATInvoiceDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceDetail
    {
        #region Member

        private const int PerPage = 10;
        private object _pageToReturn = null;

        #endregion

        #region Property

        public VATInvoiceDetailVM VM { get; set; }

        #endregion

        #region Custructor

        public VATInvoiceDetail(int vatInvoiceType)
        {
            InitializeComponent();
            ModuleName = "VATInvoice";
            VM = new VATInvoiceDetailVM(vatInvoiceType, PageMode.AddMode);
            ShowLbContext();
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        public VATInvoiceDetail(int id, PageMode pageMode, object pageToReturn = null)
            :base(pageMode)
        {
            _pageToReturn = pageToReturn;
            InitializeComponent();
            ModuleName = "VATInvoice";
            VM = new VATInvoiceDetailVM(id);
            ShowLbContext();
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        public VATInvoiceDetail(PageMode pageMode, VATInvoiceRequest vatInvoiceRequset, object pageToReturn = null)
        {
            _pageToReturn = pageToReturn;
            InitializeComponent();
            ModuleName = "VATInvoice";
            VM = new VATInvoiceDetailVM((int) VATInvoiceType.Issue, pageMode);
            VM.BindVATInvoiceVM(vatInvoiceRequset);
            ShowLbContext();
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        #endregion

        #region Method

        public void ShowLbContext()
        {
            if (VM.VATInvoiceType == (int) VATInvoiceType.Issue)
            {
                lbTitle.Content = ResVATInvoice.VATInvoiceIssuing;
                lbPBName.Content = Properties.Resources.Buyer;
                label13.Content = ResVATInvoice.InvoiceBP;
                label9.Content = Properties.Resources.InvoiceDate;
            }
            else if (VM.VATInvoiceType == (int) VATInvoiceType.Receive)
            {
                lbTitle.Content = ResVATInvoice.VATInvoiceCollect;
                lbPBName.Content = Properties.Resources.Supplier;
                label13.Content = ResVATInvoice.CollectBP;
                label9.Content = "收票日期";
            }
        }

        public void pagerList_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceLines;
            vatdataGrid.Items.Refresh();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceLines;
            vatdataGrid.Items.Refresh();
        }

        public override void Refresh()
        {
            rootGrid.DataContext = VM;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceLines;
            vatdataGrid.Items.Refresh();
        }

        #endregion

        #region Event

        private void EditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void EditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            if (id != 0)
            {
                var frm = new VATInvoiceLineDetail(id, VM.BPId, VM.InternalBPId, ModuleName, PageMode.EditMode,
                                                   VM.ShowVATInvoiceLines, VM.AddVATInvoiceLines,
                                                   VM.UpdateVATInvoiceLines, VM.VATInvoiceType);
                frm.ShowDialog();
                VM.AddVATInvoiceLines = frm.VM.AddVATInvoiceLines;
                VM.UpdateVATInvoiceLines = frm.VM.UpdateVATInvoiceLines;
            }
        }

        private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (id != 0)
                {
                    VM.DeleteLine(id);
                    Refresh();
                }
            }

            e.Handled = true;
        }

        private void CreateQuota(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VM.CreateQuotaValidate())
                {
                    var frm = new VATInvoiceLineDetail(VM.BPId, VM.InternalBPId, ModuleName, PageMode.AddMode,
                                                       VM.ShowVATInvoiceLines, VM.AddVATInvoiceLines, VM.VATInvoiceType);
                    frm.ShowDialog();
                    VM.ShowVATInvoiceLines = frm.VM.ShowVATInvoiceLines;
                    VM.AddVATInvoiceLines = frm.VM.AddVATInvoiceLines;
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// 收款客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int) BusinessPartnerType.Customer,
                                            (int) BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.BPId = bp.Id;
                VM.BPName = bp.ShortName;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                if (_pageToReturn != null)
                    RedirectTo(_pageToReturn);
                else
                    RedirectTo(new VATInvoiceHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (_pageToReturn != null)
                RedirectTo(_pageToReturn);
            else
                RedirectTo(new VATInvoiceHome());
        }

        #endregion
    }
}