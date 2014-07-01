using System;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Reports;
using DBEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using System.Data;
using Client.Converters;
using Utility.Misc;
using System.Collections.Generic;
using System.Linq;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for QuotaInvoiceDetailReport.xaml
    /// </summary>
    public sealed partial class QuotaInvoiceDetailReport
    {
        #region Property

        private const int RecPerPage = 10;
        public QuotaInvoiceDetailReportVM VM { get; set; }

        #endregion

        #region Constructor

        public QuotaInvoiceDetailReport()
        {
            InitializeComponent();
            ModuleName = "QuotaInvoiceDetailReport";
            VM = new QuotaInvoiceDetailReportVM();

            //pagingControl1.OnNewPage += PagingControl1OnOnNewPage;

            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.QuotasView;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                VM.Validate();
                
                waitingBox.Show();
                //VM.LoadCount();
                VM.Load();
                //pagingControl1.CurPageNo = 1;
                //pagingControl1.Init(VM.Count, RecPerPage);
                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var selectedItem = (BusinessPartner) dialog.SelectedItem;
            if (selectedItem != null)
            {
                VM.BPId = selectedItem.Id;
                VM.BPName = selectedItem.ShortName;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (VM.QuotasView != null && VM.QuotasView.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "增值税发票开收票明细.xls"
                };
                 if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     string _localFilePath = _sfd.FileName; //获得文件路径 
                     //获取文件名，不带路径
                     string _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                     DataTable dt = new DataTable();

                     dt.Columns.Add("BusinessPartner");
                     dt.Columns.Add("QuotaNo");
                     dt.Columns.Add("Commodity");
                     dt.Columns.Add("Brand");
                     dt.Columns.Add("Quantity");
                     dt.Columns.Add("ActualQuantity");
                     dt.Columns.Add("Price");
                     dt.Columns.Add("InvoicedQty");
                     dt.Columns.Add("InvoicedStatus");

                     string BusinessPartner = Client.Properties.Resources.Customer;
                     string QuotaNo = Client.Properties.Resources.QuotaNo;
                     string Commodity = Client.Properties.Resources.Commodity;
                     string Brand = Client.Properties.Resources.Brand;
                     string Quantity = Client.Properties.Resources.Quantity;
                     string ActualQuantity = Client.Properties.Resources.ActualQuantity;
                     string Price = Client.Properties.Resources.Price;
                     string InvoicedQty = Client.View.Reports.ResReport.InvoicedQty;
                     string InvoicedStatus = Client.Properties.Resources.InvoicedStatus;

                     DataRow dr = dt.NewRow();
                     dr["BusinessPartner"] = BusinessPartner;
                     dr["QuotaNo"] = QuotaNo;
                     dr["Commodity"] = Commodity;
                     dr["Brand"] = Brand;
                     dr["Quantity"] = Quantity;
                     dr["ActualQuantity"] = ActualQuantity;
                     dr["Price"] = Price;
                     dr["InvoicedQty"] = InvoicedQty;
                     dr["InvoicedStatus"] = InvoicedStatus;
                     dt.Rows.Add(dr);
                    
                     //VM.QuotasView.
                     foreach (Quota quota in VM.QuotasView)
                     {
                         dr = dt.NewRow();

                         dr["BusinessPartner"] = quota.Contract.BusinessPartner.ShortName;
                         dr["QuotaNo"] = quota.QuotaNo;
                         dr["Commodity"] = quota.Commodity == null ? "" : quota.Commodity.Name;
                         dr["Brand"] = quota.Brand == null ? "" : quota.Brand.Name;
                         dr["Quantity"] = quota.Quantity;
                         dr["ActualQuantity"] = quota.VerifiedQuantity;
                         dr["Price"] = quota.FinalPrice;
                         dr["InvoicedQty"] = quota.VATInvoicedQuantity;
                         VATStatusConverter vatStatusConverter = new VATStatusConverter();
                         dr["InvoicedStatus"] = vatStatusConverter.Convert(quota.VATStatus, null, null, null);

                         dt.Rows.Add(dr);
                     }

                     RenderToExcel excelHelper = new RenderToExcel();
                     excelHelper.DataTableToExcel(dt, _localFilePath);

                 }
            }
        }

        //private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        //{
        //    VM.From = e.From;
        //    VM.To = e.To;
        //    VM.Load();
        //    dataGrid1.ItemsSource = VM.QuotasView;
        //    dataGrid1.Items.Refresh();
        //}

        #endregion
    }
}