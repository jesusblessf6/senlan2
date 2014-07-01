using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using System.Data;
using Client.Converters;
using Utility.Misc;

namespace Client.View.Physical.VATInvoices
{
    /// <summary>
    /// VATInvoiceList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceList
    {
        #region Member

        private const int PerPage = 20;
        private bool _queried = false;

        #endregion

        #region Property

        public VATInvoiceListVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            listGrid.ItemsSource = VM.VATInvoiceLines;
        }

        public override void Refresh()
        {
            VM.LoadListCount();
            pagerList.Init(VM.ListTotleCount, PerPage);
        }

        #endregion

        #region Constructor

        public VATInvoiceList(string moduleName, VATInvoiceListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        #endregion

        #region Event

        private void pagerList_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            VM.LoadList();
            listGrid.ItemsSource = VM.VATInvoiceLines;
            listGrid.Items.Refresh();
        }

        private void ListEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ListDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            VATInvoice vatr = VM.GetItByLineId(id);
            if (vatr != null)
            {
                _queried = true;
                var frm = new VATInvoiceDetail(vatr.Id, PageMode.EditMode, this);
                RedirectTo(frm);
            }
        }

        private void ListDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            try
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    VM.RemoveVATInvoice(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    //RedirectTo(new VATInvoiceHome());
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void ListGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagerList.CurPageNo - 1)*20 + e.Row.GetIndex() + 1;
        }

        private void RootGridIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_queried && (bool)e.OldValue == false && (bool)e.NewValue)
            {
                VM.LoadListCount();
                pagerList.Init(VM.ListTotleCount, PerPage);
            }
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VM.LoadListAll();
            if (VM.AllLines != null && VM.AllLines.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "增值税发票.xls"
                };

                if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string _localFilePath = _sfd.FileName; //获得文件路径 
                    //获取文件名，不带路径
                    string _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    DataTable dt = new DataTable();

                    dt.Columns.Add("QuotaNo");
                    dt.Columns.Add("Supplier");
                    dt.Columns.Add("InvoiceBP");
                    dt.Columns.Add("InvoiceDate");
                    dt.Columns.Add("UnOpenedQuantity");
                    dt.Columns.Add("InvoiceQty");
                    dt.Columns.Add("InvoiceAmount");
                    dt.Columns.Add("InvoicePrice");
                    dt.Columns.Add("OpenInvoiceStatus");
                    dt.Columns.Add("VATInvoiceType");

                    string QuotaNo = Client.Properties.Resources.QuotaNo;
                    string Supplier = Client.Properties.Resources.Supplier;
                    string InvoiceBP = ResVATInvoice.InvoiceBP;
                    string InvoiceDate = Client.Properties.Resources.InvoiceDate;
                    string UnOpenedQuantity = "未开数量";
                    string InvoiceQty = Client.View.Physical.VATInvoices.ResVATInvoice.InvoiceQty;
                    string InvoiceAmount = Client.View.Physical.VATInvoices.ResVATInvoice.InvoiceAmount;
                    string InvoicePrice = Client.View.Physical.VATInvoices.ResVATInvoice.InvoicePrice;
                    string OpenInvoiceStatus = Client.View.Physical.VATInvoices.ResVATInvoice.OpenInvoiceStatus;
                    string VATInvoiceType = "开/收票";

                    DataRow dr = dt.NewRow();
                    dr["QuotaNo"] = QuotaNo;
                    dr["Supplier"] = Supplier;
                    dr["InvoiceBP"] = InvoiceBP;
                    dr["InvoiceDate"] = InvoiceDate;
                    dr["UnOpenedQuantity"] = UnOpenedQuantity;
                    dr["InvoiceQty"] = InvoiceQty;
                    dr["InvoiceAmount"] = InvoiceAmount;
                    dr["InvoicePrice"] = InvoicePrice;
                    dr["OpenInvoiceStatus"] = OpenInvoiceStatus;
                    dr["VATInvoiceType"] = VATInvoiceType;
                    dt.Rows.Add(dr);

                    foreach(var line in VM.AllLines)
                    {
                        dr = dt.NewRow();
                        dr["QuotaNo"] = line.Quota.QuotaNo;
                        dr["Supplier"] = line.VATInvoice.BusinessPartner.Name;
                        dr["InvoiceBP"] = line.VATInvoice.BusinessPartner1.Name;
                        dr["InvoiceDate"] = line.VATInvoice.InvoicedDate.HasValue ? Convert.ToDateTime(line.VATInvoice.InvoicedDate.Value).ToString("yyyy-MM-dd") : "";
                        dr["UnOpenedQuantity"] = line.UnOpenedQuantity.HasValue ? line.UnOpenedQuantity.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["InvoiceQty"] = line.VATInvoiceQuantity.HasValue ? line.VATInvoiceQuantity.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["InvoiceAmount"] = line.VATAmount.HasValue ? line.VATAmount.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["InvoicePrice"] = line.VATPrice.HasValue ? line.VATPrice.Value.ToString(RoundRules.STR_PRICE) : "";
                        VATStatusConverter statusConverter = new VATStatusConverter();
                        dr["OpenInvoiceStatus"] = statusConverter.Convert(line.Quota.VATStatus, null, null, null);
                        VATInvoiceTypeConverter typeConverter = new VATInvoiceTypeConverter();
                        dr["VATInvoiceType"] = typeConverter.Convert(line.VATInvoice.VATInvoiceType, null, null, null);

                        dt.Rows.Add(dr);
                    }
                    RenderToExcel excelHelper = new RenderToExcel();
                    excelHelper.DataTableToExcel(dt, _localFilePath);

                }
            }
        }
    }
}