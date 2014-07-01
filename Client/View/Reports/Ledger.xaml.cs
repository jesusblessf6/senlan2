using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using System.Data;
using System.Windows.Forms;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.View.Reports
{
    /// <summary>
    /// Ledger.xaml 的交互逻辑
    /// </summary>
    public sealed partial class Ledger
    {
        #region Property

        public LedgerVM VM { get; set; }

        #endregion

        #region Constructor

        public Ledger()
        {
            InitializeComponent();
            ModuleName = "Ledger";
            VM = new LedgerVM();
            BindData();
        }

        #endregion

        #region Event

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                //添加在线程外的校验，线程内的校验暂不去掉
                VM.Validate();
                waitingBox.Show();
                
                VM.ShowLedgerGridNew();
                //dataGrid1.DataContext = VM.Ledgers;
                //dataGrid1.Items.Refresh();
                lvGrid.ItemsSource = VM.Ledgers;
                lvGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
        }

        //导出Excel
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            if (VM.Ledgers != null && VM.Ledgers.Count > 0)
            {
                SaveFileDialog _sfd = new SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "现货台账.xls"
                };
                if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string _localFilePath = _sfd.FileName; //获得文件路径 
                    //获取文件名，不带路径
                    string _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    DataTable dt = new DataTable();

                    dt.Columns.Add("pQuotaNo");
                    dt.Columns.Add("pQuotaDate");
                    dt.Columns.Add("pQuotaSupplier");
                    dt.Columns.Add("metalName");
                    dt.Columns.Add("pBrandName");
                    dt.Columns.Add("pQtyStr");
                    dt.Columns.Add("pVerifiedQty");
                    dt.Columns.Add("pSalesQty");
                    dt.Columns.Add("pPrice");
                    dt.Columns.Add("pCurrency");
                    dt.Columns.Add("pPay");
                    dt.Columns.Add("pPaid");
                    dt.Columns.Add("pReceived");
                    dt.Columns.Add("pSettle");
                    dt.Columns.Add("pSettleCurrency");
                    dt.Columns.Add("Split");
                    dt.Columns.Add("sQuotaNo");
                    dt.Columns.Add("sQuotaDate");
                    dt.Columns.Add("sQuotaBuyer");
                    dt.Columns.Add("sBrandName");
                    dt.Columns.Add("sQtyStr");
                    dt.Columns.Add("sVerifiedQty");
                    dt.Columns.Add("sPrice");
                    dt.Columns.Add("sCurrency");
                    dt.Columns.Add("sReceive");
                    dt.Columns.Add("sReceived");
                    dt.Columns.Add("sPaid");
                    dt.Columns.Add("sSettle");
                    dt.Columns.Add("sSettleCurrency");
                    dt.Columns.Add("profit");



                    string PurchaseQuotaNo = ResReport.PurchaseQuotaNo;
                    string PurchaseDate = ResReport.PurchaseDate;
                    string Supplier = Properties.Resources.Supplier;
                    string Commodity = Properties.Resources.Commodity;
                    string Brand = Properties.Resources.Brand;
                    string QuotaQuantity = Properties.Resources.QuotaQuantity;
                    string ActualQuantity = Properties.Resources.ActualQuantity;
                    string SalesQty = Properties.Resources.SalesQty;
                    string Price = Properties.Resources.Price;
                    string Currency = Properties.Resources.Currency;
                    string Payable = Properties.Resources.Payable;
                    string PaidAmount = Properties.Resources.PaidAmount;
                    string Received = ResReport.Received;
                    string Settlement = Properties.Resources.Settlement;
                    string SettleCurrency = Properties.Resources.SettleCurrency;

                    string Split = "";

                    string SalesQuotaNo = ResReport.SalesQuotaNo;
                    string SalesDate = ResReport.SalesDate;
                    string Buyer = Properties.Resources.Buyer;
                    string Receivable = Properties.Resources.Receivable;
                    string PhysicalGrossProfit = ResReport.PhysicalGrossProfit;

                    DataRow dr = dt.NewRow();
                    dr["pQuotaNo"] = PurchaseQuotaNo;
                    dr["pQuotaDate"] = PurchaseDate;
                    dr["pQuotaSupplier"] = Supplier;
                    dr["metalName"] = Commodity;
                    dr["pBrandName"] = Brand;
                    dr["pQtyStr"] = QuotaQuantity;
                    dr["pVerifiedQty"] = ActualQuantity;
                    dr["pSalesQty"] = SalesQty;
                    dr["pPrice"] = Price;
                    dr["pCurrency"] = Currency;
                    dr["pPay"] = Payable;
                    dr["pPaid"] = PaidAmount;
                    dr["pReceived"] = Received;
                    dr["pSettle"] = Settlement;
                    dr["pSettleCurrency"] = SettleCurrency;
                    dr["Split"] = Split;
                    dr["sQuotaNo"] = SalesQuotaNo;
                    dr["sQuotaDate"] = SalesDate;
                    dr["sQuotaBuyer"] = Buyer;
                    dr["sBrandName"] = Brand;
                    dr["sQtyStr"] = QuotaQuantity;
                    dr["sVerifiedQty"] = ActualQuantity;
                    dr["sPrice"] = Price;
                    dr["sCurrency"] = Currency;
                    dr["sReceive"] = Receivable;
                    dr["sReceived"] = Received;
                    dr["sPaid"] = PaidAmount;
                    dr["sSettle"] = Settlement;
                    dr["sSettleCurrency"] = SettleCurrency;
                    dr["profit"] = PhysicalGrossProfit;

                    dt.Rows.Add(dr);

                    foreach (var item in VM.Ledgers)
                    {
                        dr = dt.NewRow();
                        decimal temp = 0;
                        dr["pQuotaNo"] = item.PQuotaNo;
                        dr["pQuotaDate"] = item.PQuotaDate.HasValue ? Convert.ToDateTime(item.PQuotaDate).ToString("yyyy-MM-dd") : "";
                        dr["pQuotaSupplier"] = item.PQuotaSupplier;
                        dr["metalName"] = item.MetalName;
                        dr["pBrandName"] = item.PBrandName;
                        dr["pQtyStr"] = item.PQty;
                        dr["pVerifiedQty"] = item.PVerifiedQty.HasValue ? item.PVerifiedQty.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["pSalesQty"] = item.PSalesQty.HasValue ? item.PSalesQty.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["pPrice"] = Decimal.TryParse(item.PPrice, out temp) ? temp.ToString(RoundRules.STR_PRICE) : item.PPrice;
                        dr["pCurrency"] = item.PCurrency;
                        dr["pPay"] = item.PPay.HasValue ? item.PPay.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["pPaid"] = item.PPaid.HasValue ? item.PPaid.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["pReceived"] = item.PReceived.HasValue ? item.PReceived.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["pSettle"] = item.PSettle.HasValue ? item.PSettle.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["pSettleCurrency"] = item.PSettleCurrency;
                        dr["Split"] = "";
                        dr["sQuotaNo"] = item.SQuotaNo;
                        dr["sQuotaDate"] = item.SQuotaDate.HasValue ? Convert.ToDateTime(item.SQuotaDate).ToString("yyyy-MM-dd") : "";
                        dr["sQuotaBuyer"] = item.SQuotaBuyer;
                        dr["sBrandName"] = item.SBrandName;
                        dr["sQtyStr"] = item.SQty;
                        dr["sVerifiedQty"] = item.SVerifiedQty.HasValue ? item.SVerifiedQty.Value.ToString(RoundRules.STR_QUANTITY) : "";
                        dr["sPrice"] = Decimal.TryParse(item.SPrice, out temp) ? temp.ToString(RoundRules.STR_PRICE) : item.SPrice;
                        dr["sCurrency"] = item.SCurrency;
                        dr["sReceive"] = item.SReceive.HasValue ? item.SReceive.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["sReceived"] = item.SReceived.HasValue ? item.SReceived.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["sPaid"] = item.SPaid.HasValue ? item.SPaid.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["sSettle"] = item.SSettle.HasValue ? item.SSettle.Value.ToString(RoundRules.STR_AMOUNT) : "";
                        dr["sSettleCurrency"] = item.SSettleCurrency;
                        dr["profit"] = item.Profit.HasValue ? item.Profit.Value.ToString(RoundRules.STR_AMOUNT) : "";

                        dt.Rows.Add(dr);
                    }

                    RenderToExcel excelHelper = new RenderToExcel();
                    excelHelper.DataTableToExcel(dt, _localFilePath);
                }
            }
        }
        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region PopUpdialog

        /// <summary>
        /// 客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            VM.ShowCustomerDialog();
        }

        private void ButtonPurchaseCustomerClick(object sender, RoutedEventArgs e)
        {
            VM.ShowPurchaseCustomerDialog();
        }

        #endregion

        private void LvGridLoaded(object sender, RoutedEventArgs e)
        {
        }

    }
}