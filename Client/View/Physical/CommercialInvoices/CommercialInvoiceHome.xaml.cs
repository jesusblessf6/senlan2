using System;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.CommercialInvoices;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    /// Interaction logic for CommercialInvoiceHome.xaml
    /// </summary>
    public sealed partial class CommercialInvoiceHome
    {
        #region Property
        public CommercialInvoiceHomeVM VM { get; set; }
        public ContractType ContractType { get; set; }
        #endregion

        public CommercialInvoiceHome()
        {
            InitializeComponent();
            VM = new CommercialInvoiceHomeVM();
        }

        public CommercialInvoiceHome(ContractType contractType)
        {
            InitializeComponent();
            if (contractType == ContractType.Purchase)
            {
                ModuleName = "PurchaseCommercialInvoice";
                lbTitle.Content = ResCommercialInvoice.PurchaseCommercialInvoiceHome;
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (contractType == ContractType.Sales)
            {
                ModuleName = "SaleCommercialInvoice";
                lbTitle.Content = ResCommercialInvoice.SalesCommercialInvoiceHome;
                lbSupplier.Content = Properties.Resources.Buyer;
            }
            ContractType = contractType;
            VM = new CommercialInvoiceHomeVM {ContractType = ContractType};
            BindData();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            VM.SearchData();
            RedirectTo(new CommercialInvoiceList(ModuleName,VM.SearchVM, ContractType));
        }

        /// <summary>
        /// 供应商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            const string queryStr = "it.CustomerType=1 or it.CustomerType=3";
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SId = bp.Id;
                VM.SName = bp.ShortName;
            }
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        /// <summary>
        /// 临时发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTemporaryClick(object sender, RoutedEventArgs e)
        {
            RedirectTo(new ProvisionalCommercialInvoice(ContractType));
        }

        /// <summary>
        /// 最终发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinalClick(object sender, RoutedEventArgs e)
        {
            RedirectTo(new FinalCommercialInvoice(ContractType));
        }

        /// <summary>
        /// 本月临时发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentMonthTemporaryListClick(object sender, RoutedEventArgs e)
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            VM.SearchDataByDate((int) CommercialInvoiceType.Provisional, ContractType, start, end);
            RedirectTo(new CommercialInvoiceList(ModuleName, VM.SearchVM, ContractType));
        }

        /// <summary>
        /// 本月最终发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrenttMonthFinalListClick(object sender, RoutedEventArgs e)
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            VM.SearchDataByDate((int)CommercialInvoiceType.Final, ContractType, start, end);
            RedirectTo(new CommercialInvoiceList(ModuleName, VM.SearchVM, ContractType));
        }

        /// <summary>
        /// 商业发票新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(new ProvisionalCommercialInvoice(ContractType, true));
        }

        /// <summary>
        /// 本月商业发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            VM.SearchDataByDate((int)CommercialInvoiceType.FinalCommercial, ContractType, start, end);
            RedirectTo(new CommercialInvoiceList(ModuleName, VM.SearchVM, ContractType));
        }
    }
}
