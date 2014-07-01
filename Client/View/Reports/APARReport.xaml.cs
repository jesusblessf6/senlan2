using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Client.QuotaServiceReference;
using System.Windows.Media;
using System.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for APARReport.xaml
    /// </summary>
    public sealed partial class APARReport
    {
        public APARReport()
        {
            InitializeComponent();
            ModuleName = "APARReport";
            VM = new APARReportVM();
            BindData();
        }

        public APARReportVM VM { get; set; }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            cbSelectAll.DataContext = VM;
        }

        /// <summary>
        /// 客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            VM.ShowCustomerDialog();
            rootGrid.DataContext = VM;
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            waitingBox.Show();
            try
            {
                VM.Search();
                //dataGridAPAR.ItemsSource = VM.APARView;listAraps
                //dataGridAPAR.ItemsSource = VM.ListAraps;
                dataGridAPAR.ItemsSource = VM.FinalList;
                dataGridAPAR.Items.Refresh();
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

        private void DataGridAPARLoadingRow(object sender, DataGridRowEventArgs e)
        {
            //var item = e.Row.DataContext as ARAPClass;
            var item = e.Row.DataContext as ARAPClassForPrint;
            if (item != null)
            {
                if (item.Title == "-1")
                {
                    e.Row.Background = Brushes.SteelBlue;
                    e.Row.FontSize = 15;
                    e.Row.Foreground = Brushes.Orange;
                }
                else
                {
                    e.Row.Background = Brushes.White;
                    e.Row.Foreground = Brushes.Black;
                    e.Row.FontSize = 13;
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (VM.FinalList != null && VM.FinalList.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "应收应付报表.xls"
                };

                if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string _localFilePath = _sfd.FileName; //获得文件路径 
                    //获取文件名，不带路径
                    string _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    DataTable dt = new DataTable();

                    dt.Columns.Add("QuotaNo");
                    dt.Columns.Add("Commodity");
                    dt.Columns.Add("Brand");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("ActualQuantity");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("PricingCurrency");
                    dt.Columns.Add("VatInvoiceQty");
                    dt.Columns.Add("VatInvoiceAmount");
                    dt.Columns.Add("Receivable");
                    dt.Columns.Add("Payable");
                    dt.Columns.Add("Received");
                    dt.Columns.Add("Paid");
                    dt.Columns.Add("AmountRemain");
                    dt.Columns.Add("SettleCurrency");

                    string QuotaNo = Client.Properties.Resources.QuotaNo;
                    string Commodity = Client.Properties.Resources.Commodity;
                    string Brand = Client.Properties.Resources.Brand;
                    string Date = Client.Properties.Resources.Date;
                    string ActualQuantity = Client.Properties.Resources.ActualQuantity;
                    string Price = Client.Properties.Resources.Price;
                    string PricingCurrency = Client.Properties.Resources.PricingCurrency;
                    string VatInvoiceQty = "开票数量";
                    string VatInvoiceAmount = "开票金额";
                    string Receivable = Client.Properties.Resources.Receivable;
                    string Payable = Client.Properties.Resources.Payable;
                    string Received = Client.View.Reports.ResReport.Received;
                    string Paid = Client.View.Reports.ResReport.Paid;
                    string AmountRemain = Client.View.Reports.ResReport.AmountRemain;
                    string SettleCurrency = Client.Properties.Resources.SettleCurrency;

                    DataRow dr = dt.NewRow();
                    dr["QuotaNo"] = QuotaNo;
                    dr["Commodity"] = Commodity;
                    dr["Brand"] = Brand;
                    dr["Date"] = Date;
                    dr["ActualQuantity"] = ActualQuantity;
                    dr["Price"] = Price;
                    dr["PricingCurrency"] = PricingCurrency;
                    dr["VatInvoiceQty"] = VatInvoiceQty;
                    dr["VatInvoiceAmount"] = VatInvoiceAmount;
                    dr["Receivable"] = Receivable;
                    dr["Payable"] = Payable;
                    dr["Received"] = Received;
                    dr["Paid"] = Paid;
                    dr["AmountRemain"] = AmountRemain;
                    dr["SettleCurrency"] = SettleCurrency;
                    dt.Rows.Add(dr);

                    foreach (var apar in VM.FinalList)
                    {
                        dr = dt.NewRow();
                        
                        dr["QuotaNo"] = apar.QuotaNoStr;
                        dr["Commodity"] = apar.CommodityName;
                        dr["Brand"] = apar.BrandName;
                        dr["Date"] = apar.Date.HasValue ? Convert.ToDateTime(apar.Date.Value).ToString("yyyy-MM-dd") : "";
                        dr["ActualQuantity"] = apar.VerQty.HasValue ? apar.VerQty.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["Price"] = apar.NPrice.HasValue ? apar.NPrice.Value.ToString(RoundRules.STR_PRICE) : "";
                        dr["PricingCurrency"] = apar.PricingCurrency;
                        dr["VatInvoiceQty"] = apar.VatInvoiceQty.HasValue ? apar.VatInvoiceQty.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["VatInvoiceAmount"] = apar.VatInvoiceAmount.HasValue ? apar.VatInvoiceAmount.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["Receivable"] = apar.BReceived.HasValue ? apar.BReceived.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["Payable"] = apar.BPaid.HasValue ? apar.BPaid.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["Received"] = apar.SReceived.HasValue ? apar.SReceived.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["Paid"] = apar.SPaid.HasValue ? apar.SPaid.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["AmountRemain"] = apar.AmountRemain.HasValue ? apar.AmountRemain.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["SettleCurrency"] = apar.SettleCurrency;

                        dt.Rows.Add(dr);
                    }

                    RenderToExcel excelHelper = new RenderToExcel();
                    excelHelper.DataTableToExcel(dt, _localFilePath);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.PrintSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class ListViewItemStyleSelector : StyleSelector
    {
        public Style FirstStyle { get; set; }
        public Style SecondStyle { get; set; }
        public Style ThirdStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            string s = ((CollectionViewGroup) (item)).Name.ToString();
            Style style;
            if (s.IndexOf(Properties.Resources.InternalCustomer, StringComparison.Ordinal) == 0)
            {
                //内部客户header
                style = FirstStyle;
            }
            else if (s.IndexOf(Properties.Resources.CustomerName, StringComparison.Ordinal) == 0)
            {
                //客户名称header
                style = SecondStyle;
            }
            else
            {
                //内贸外贸
                style = ThirdStyle;
            }
            return style;
        }
    }
}