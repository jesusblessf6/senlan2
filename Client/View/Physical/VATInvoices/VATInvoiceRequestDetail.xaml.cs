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
    /// VATInvoiceRequestDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceRequestDetail
    {
        #region Member

        private const int PerPage = 10;
        private object _pageToReturn = null;

        #endregion

        #region Property

        public VATInvoiceRequestDetailVM VM { get; set; }

        #endregion

        #region Custructor

        public VATInvoiceRequestDetail()
        {
            InitializeComponent();
            ModuleName = "VATInvoiceRequest";
            VM = new VATInvoiceRequestDetailVM();
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        public VATInvoiceRequestDetail(int id, PageMode pageMode, object pageToReturn = null)
            :base(pageMode)
        {
            _pageToReturn = pageToReturn;
            InitializeComponent();
            ModuleName = "VATInvoiceRequest";
            VM = new VATInvoiceRequestDetailVM(id);
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        #endregion

        #region Method

        private void pagerList_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceRequestLines;
            vatdataGrid.Items.Refresh();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceRequestLines;
            vatdataGrid.Items.Refresh();
        }

        public override void Refresh()
        {
            rootGrid.DataContext = VM;
            vatdataGrid.ItemsSource = VM.ShowVATInvoiceRequestLines;
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

            //if (id > 0 && !VM.CanLineEdit(id))
            //{
            //    MessageBox.Show("该增票申请行不能编辑！");
            //    return;
            //}
            if (id != 0)
            {
                var frm = new VATInvoiceRequestLineDetail(id, VM.BPId, VM.InternalBPId, ModuleName, PageMode.EditMode,
                                                          VM.ShowVATInvoiceRequestLines, VM.AddVATInvoiceRequestLines,
                                                          VM.UpdateVATInvoiceRequestLines, VM.QuotaList);
                frm.ShowDialog();
                VM.AddVATInvoiceRequestLines = frm.VM.AddVATInvoiceRequestLines;
                VM.UpdateVATInvoiceRequestLines = frm.VM.UpdateVATInvoiceRequestLines;
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
            if (id > 0 && !VM.CanLineDelete(id))
            {
                MessageBox.Show("该增票申请行不能删除！");
                return;
            }
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
                    var frm = new VATInvoiceRequestLineDetail(VM.BPId, VM.InternalBPId, ModuleName, PageMode.AddMode,
                                                              VM.ShowVATInvoiceRequestLines,
                                                              VM.AddVATInvoiceRequestLines, VM.QuotaList);
                    frm.ShowDialog();
                    VM.ShowVATInvoiceRequestLines = frm.VM.ShowVATInvoiceRequestLines;
                    VM.AddVATInvoiceRequestLines = frm.VM.AddVATInvoiceRequestLines;
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
                if(_pageToReturn != null)
                    RedirectTo(_pageToReturn);
                else
                    RedirectTo(new VATInvoiceRequestHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            //RedirectTo(new VATInvoiceRequestHome());
            if (_pageToReturn != null)
                RedirectTo(_pageToReturn);
            else
                RedirectTo(new VATInvoiceRequestHome());
        }

        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VM.CreateQuotaValidate())
                {
                    VM.GetInvoiceRequestDetailsByQuotas();
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
           
        }
    }
}