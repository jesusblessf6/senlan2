using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using System.Data;
using Client.View.Reports;
using Client.Converters;
using Utility.Misc;

namespace Client.View.Physical.VATInvoices
{
    /// <summary>
    /// VATInvoiceRequestList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceRequestList
    {
        #region Member

        private const int PerPage = 25;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private bool _queried = false;
        private bool _requestQuery = false;

        #endregion

        #region Property

        public VATInvoiceRequestListVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            cbSelectAll.DataContext = VM;
            listGrid.ItemsSource = VM.VATInvoiceRequestLines;
        }

        public override void Refresh()
        {
            VM.LoadListCount(false);
            pagerList.Init(VM.ListTotleCount, PerPage);
        }

        #endregion

        #region Constructor

        public VATInvoiceRequestList(string moduleName, VATInvoiceRequestListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);

            VM = vm;
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        public VATInvoiceRequestList(string moduleName, VATInvoiceRequestListVM vm, PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagerList.OnNewPage += pagerList_OnOperationPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            lbTitle.Content = ResVATInvoice.ApprovedInvoiceRequest;
            listGrid.Columns[0].Visibility = Visibility.Visible;
            listGrid.Columns[16].Visibility = Visibility.Hidden;
            listGrid.Columns[17].Visibility = Visibility.Hidden;
            listGrid.Columns[18].Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Visible;
            separator1.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            BindData();
        }

        #endregion

        #region Event

        private void pagerList_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            VM.LoadList(false);
            listGrid.ItemsSource = VM.VATInvoiceRequestLines;
            listGrid.Items.Refresh();
        }

        private void pagerList_OnOperationPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            VM.LoadList(true);
            listGrid.ItemsSource = VM.VATInvoiceRequestLines;
            listGrid.Items.Refresh();
        }

        private void ListEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void ListDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;

            if (!VM.CanLineEditWithApproveStatus(id))
            {
                MessageBox.Show(ResVATInvoice.ApprovalLimit);
                return;
            }

            VATInvoiceRequest vatr = VM.GetItByLineId(id);
            if (vatr != null)
            {
                _queried = true;
                _requestQuery = false;
                var frm = new VATInvoiceRequestDetail(vatr.Id, PageMode.EditMode, this);
                RedirectTo(frm);
            }
        }

        private void ListDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;

            if (!VM.CanLineEditWithApproveStatus(id))
            {
                MessageBox.Show(ResVATInvoice.ApprovalLimit2);
                return;
            }

            try
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    VM.RemoveInvoiceRequest(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    //RedirectTo(new VATInvoiceRequestHome());
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void OperationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void OperationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            VATInvoiceRequest vatr = VM.GetItByLineId(id);
            if (vatr != null)
            {
                _queried = false;
                _requestQuery = true;
                var frm = new VATInvoiceDetail(PageMode.AddMode, vatr, this);
                RedirectTo(frm);
            }
        }

        private void ListGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagerList.CurPageNo - 1) * PerPage + e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            VM.LoadListCount(true);
            pagerList.Init(VM.ListTotleCount, PerPage);
            VM.Load();
            BindData();
        }

        #endregion

        #region PopUpdialog

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

        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VM.LoadVATInvoiceRequestLinesAll();
            if(VM.VATInvoiceRequestLinesAll != null && VM.VATInvoiceRequestLinesAll.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (VM.IsNeedApproved)
                {
                    _sfd.FileName = "审核通过的开票申请.xls";
                }
                else
                {
                    _sfd.FileName = "增值税开票申请列表.xls";
                }
                if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string _localFilePath = _sfd.FileName; //获得文件路径 
                    //获取文件名，不带路径
                    string _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    DataTable dt = new DataTable();

                    dt.Columns.Add("Buyer");
                    dt.Columns.Add("InvoiceBP");
                    dt.Columns.Add("ApplyDate");
                    dt.Columns.Add("QuotaNo");
                    dt.Columns.Add("Commodity");
                    dt.Columns.Add("CommodityType");
                    dt.Columns.Add("Brand");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("ApplyQuantity");
                    dt.Columns.Add("InvoicedQty");
                    dt.Columns.Add("AppliedAmount");
                    dt.Columns.Add("InvoicePrice");

                    string Buyer = Client.Properties.Resources.Buyer;
                    string InvoiceBP = ResVATInvoice.InvoiceBP;
                    string ApplyDate = Client.Properties.Resources.ApplyDate;
                    string QuotaNo = Client.Properties.Resources.QuotaNo;
                    string Commodity = Client.Properties.Resources.Commodity;
                    string CommodityType = Client.Properties.Resources.CommodityType;
                    string Brand = Client.Properties.Resources.Brand;
                    string Quantity = Client.Properties.Resources.Quantity;
                    string ApplyQuantity = Client.Properties.Resources.ApplyQuantity;
                    string InvoicedQty = "申请已开数量";
                    string AppliedAmount = Client.Properties.Resources.AppliedAmount;
                    string InvoicePrice = ResVATInvoice.InvoicePrice;

                    DataRow dr = dt.NewRow();
                    dr["Buyer"] = Buyer;
                    dr["InvoiceBP"] = InvoiceBP;
                    dr["ApplyDate"] = ApplyDate;
                    dr["QuotaNo"] = QuotaNo;
                    dr["Commodity"] = Commodity;
                    dr["CommodityType"] = CommodityType;
                    dr["Brand"] = Brand;
                    dr["Quantity"] = Quantity;
                    dr["ApplyQuantity"] = ApplyQuantity;
                    dr["InvoicedQty"] = InvoicedQty;
                    dr["AppliedAmount"] = AppliedAmount;
                    dr["InvoicePrice"] = InvoicePrice;
                    dt.Rows.Add(dr);

                    foreach(var line in VM.VATInvoiceRequestLinesAll)
                    {
                        dr = dt.NewRow();
                        dr["Buyer"] = line.VATInvoiceRequest.BusinessPartner.Name;
                        dr["InvoiceBP"] = line.VATInvoiceRequest.InternalCustomer.ShortName;
                        dr["ApplyDate"] = line.VATInvoiceRequest.RequestDate.HasValue ? Convert.ToDateTime(line.VATInvoiceRequest.RequestDate.Value).ToString("yyyy-MM-dd") : "";
                        dr["QuotaNo"] = line.Quota.QuotaNo;
                        dr["Commodity"] = line.Quota.Commodity.Name;
                        dr["CommodityType"] = line.Quota.CommodityType.Name;
                        dr["Brand"] = line.Quota.Brand == null ? "" : line.Quota.Brand.Name;
                        dr["Quantity"] = line.Quota.VerifiedQuantity.ToString(RoundRules.STR_QUANTITY);
                        dr["ApplyQuantity"] = line.RequestQuantity.HasValue ? line.RequestQuantity.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["InvoicedQty"] = line.VATInvoicedQuantity.HasValue ? line.VATInvoicedQuantity.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["AppliedAmount"] = line.RequestAmount.HasValue ? line.RequestAmount.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["InvoicePrice"] = line.RequestPrice.HasValue ? line.RequestPrice.Value.ToString(RoundRules.STR_PRICE) : "";

                        dt.Rows.Add(dr);
                    }
                    RenderToExcel excelHelper = new RenderToExcel();
                    excelHelper.DataTableToExcel(dt, _localFilePath);
                }
            }
        }

        private void RootGridIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_queried && (bool)e.OldValue == false && (bool)e.NewValue)
            {
                VM.LoadListCount(false);
                pagerList.Init(VM.ListTotleCount, PerPage);
            }
            if (_requestQuery && (bool)e.OldValue == false && (bool)e.NewValue)
            {
                VM.LoadListCount(true);
                pagerList.Init(VM.ListTotleCount, PerPage);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //批量开票
            try
            {
                VM.BatchInvoiceOperation();
                if (VM.SelectedList != null && VM.SelectedList.Count > 0)
                {
                    MessageBox.Show("批量开票成功！");
                }
                else
                {
                    MessageBox.Show("请勾选增票申请！");
                }
                VM.LoadListCount(true);
                pagerList.Init(VM.ListTotleCount, PerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
    }
}