using System;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Contracts;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Utility.Misc;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for ContractHome.xaml
    /// </summary>
    public sealed partial class ContractHome
    {
        #region Property

        public ContractHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public ContractHome(ContractType contractType)
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            VM = new ContractHomeVM(contractType);
            InitPage();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        /// <summary>
        /// set some label content by the contract type
        /// </summary>
        private void InitPage()
        {
            if (VM.ContractType == ContractType.Purchase)
            {
                //采购
                lbTitle.Content = ResContract.PurchaseContractHome;
                Title = ResContract.PurchaseContractHome;
                btnCurrentMonth.Content = ResContract.PurchaseAmountOfTheMonth;
                btnLastMonth.Content = ResContract.PurchaseAmountOfLastMonth;
                btnCurrentYear.Content = ResContract.PurchaseAmountOfTheYear;
                btnLastYear.Content = ResContract.PurchaseAmountOfLastYear;
                btnPurchaseChart.Content = ResContract.DashboardOfPurchase;
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (VM.ContractType == ContractType.Sales)
            {
                //销售
                lbTitle.Content = ResContract.SalesContractHome;
                Title = ResContract.SalesContractHome;
                btnCurrentMonth.Content = ResContract.SalesAmountOfTheMonth;
                btnLastMonth.Content = ResContract.SalesAmountOfLastMonth;
                btnCurrentYear.Content = ResContract.SalesAmountOfTheYear;
                btnLastYear.Content = ResContract.SalesAmountOfLastYear;
                btnPurchaseChart.Content = ResContract.DashboardOfSales;
                lbSupplier.Content = Properties.Resources.Buyer;
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.Free);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        /// <summary>
        /// 本月合同列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentMonthListClick(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.CurrentMonth);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        /// <summary>
        /// 上月合同列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLastMonthListClick(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.LastMonth);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        /// <summary>
        /// 本年合同列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentYearListClick(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.CurrentYear);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        /// <summary>
        /// 去年合同列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLastYearListClick(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.LastYear);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        #region PopUpdialog

        /// <summary>
        /// Popup window of suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupplierClick(object sender, RoutedEventArgs e)
        {
            string queryStr = "it.CustomerType = " + (int) BusinessPartnerType.Customer + " or it.CustomerType = " +
                              (int) BusinessPartnerType.InternalCustomer;
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SupplierId = bp.Id;
                VM.SupplierName = bp.ShortName;
            }
        }

        #endregion

        /// <summary>
        /// 内贸短单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShortDomesticClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string pageName = EnumHelper.GetDescriptionByCulture(VM.ContractType) +
                                  EnumHelper.GetDescriptionByCulture(TradeType.ShortDomesticTrade);
                var frm = new ShortContractDetail(TradeType.ShortDomesticTrade, VM.ContractType, PageMode.AddMode, pageName);
                RedirectTo(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// 内贸长单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLongDomesticClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string pageName = EnumHelper.GetDescriptionByCulture(VM.ContractType) +
                                  EnumHelper.GetDescriptionByCulture(TradeType.LongDomesticTrade);
                var frm = new LongContractDetail(TradeType.LongDomesticTrade, VM.ContractType, PageMode.AddMode, pageName);
                RedirectTo(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// 进口/转口短单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShortForeignClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string pageName = EnumHelper.GetDescriptionByCulture(VM.ContractType) +
                                  EnumHelper.GetDescriptionByCulture(TradeType.ShortForeignTrade);
                var frm = new ShortContractDetail(TradeType.ShortForeignTrade, VM.ContractType, PageMode.AddMode, pageName);
                RedirectTo(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// 进口/转口长单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLongForeignClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string pageName = EnumHelper.GetDescriptionByCulture(VM.ContractType) + 
                                  EnumHelper.GetDescriptionByCulture(TradeType.LongForeignTrade);
                var frm = new LongContractDetail(TradeType.LongForeignTrade, VM.ContractType, PageMode.AddMode, pageName);
                RedirectTo(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// 本人草稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var conditions = VM.BuildConditions(ContractSearchType.Draft);
            var cl = new ContractList(conditions, VM.ContractType);
            RedirectTo(cl);
        }

        /// <summary>
        /// Reset button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            VM.Reset();
        }

        #endregion
    }
}