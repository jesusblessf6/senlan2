using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Client.CategoryServiceReference;
using Client.View.Console.LogMessages;
using Client.View.Console.MonitorCenter;
using Client.View.Finance.FundFlows;
using Client.View.Finance.LCAllocations;
using Client.View.Finance.LetterOfCredits;
using Client.View.Futures.HedgeGroups;
using Client.View.Futures.SHFE;
using Client.View.Physical.CommercialInvoices;
using Client.View.Physical.Contracts;
using Client.View.Physical.Deliveries;
using Client.View.Physical.ForeignDeliveryPools;
using Client.View.Physical.Payments;
using Client.View.Physical.Pricings;
using Client.View.Physical.VATInvoices;
using Client.View.Physical.WarehouseIns;
using Client.View.Physical.WarehouseOuts;
using Client.View.SystemSetting.BankAccountSetting;
using Client.View.SystemSetting.BusinessPartnerSetting;
using Client.View.SystemSetting.CommoditySetting;
using Client.View.SystemSetting.CurrencyRateSetting;
using Client.View.SystemSetting.DataDictSetting;
using Client.View.SystemSetting.LogRegister;
using Client.View.SystemSetting.ModuleSetting;
using Client.View.SystemSetting.PasswordSetting;
using Client.View.SystemSetting.RoleSetting;
using Client.View.SystemSetting.UserSetting;
using Client.View.SystemSetting.WarehouseSetting;
using Client.View.SystemSetting.SystemParameterSetting;
using Client.ViewModel;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.View.SystemSetting.ApprovalSetting;
using Client.View.SystemSetting.FinancialAccountSetting;
using Client.View.Console.ApprovalCenter;
using Client.View.Reports;
using Client.View.Physical.InventoryReport;
using Client.View.SystemSetting.CommissionSetting;
using Client.View.Futures.LME;
using Client.View.Console.DashBoard;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main
    {
        #region Member

        //private RegCountUpdateThread _regCountUpdater;
        
        #endregion

        #region Property

        public MainVM MainVM { get; set; }

        #endregion

        #region Constructor

        public Main()
        {
            InitializeComponent();

            MainVM = new MainVM{Main = this};
            rootGrid.DataContext = MainVM;
            InitMenus();

            Application.Current.Properties.Add("MainVM", MainVM);

            //修复最大化盖住任务栏问题
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        #endregion

        #region Event

        private void BtCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtMaximizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtMinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExpSystemSettingExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander) sender);
        }

        private void ExpPurchasesExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander) sender);
        }

        private void ExpSalesExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander) sender);
        }

        private void ExpInventoryExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander) sender);
        }

        private void ExpControlCenterExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander)sender);
        }

        private void ExpFinancialExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander)sender);
        }

        private void ExpReportExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander)sender);
        }

        private void ExpFuturesExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander)sender);
        }

        private void BtModuleSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ModuleSetting());
        }

        private void BtSystemParameterSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new SystemParameterWindow());
        }

        private void BtRoleSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new RoleList());
        }

        private void BtBankAccountSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new BankAccountHome());
        }

        private void BtDataDictSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new DataDictHome());
        }

        private void BtFinancialAccountSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new FinancialAccountHome());
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new Welcome());

            //_regCountUpdater = new RegCountUpdateThread();
            //_regCountUpdater.Begin(MainVM);
        }

        private void ExpHedgeExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander) sender);
        }

        private void BtUserSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new UserList());
        }

        private void BtCurrencyRateSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new CurrencyRateHome());
        }

        private void BtWarehouseSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new WarehouseSettingHome());
        }

        private void BtCommissionSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new CommissionHome());
        }

        private void BtCommoditySettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new CommodityHome());
        }

        private void BtBusinessPartnerSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new BusinessPartnerHome());
        }

        private void BtPurchaseContractHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ContractHome(ContractType.Purchase));
        }

        private void BtSalesContractHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ContractHome(ContractType.Sales));
        }

        private void BtSalesDeliveryHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new SalesDeliveryHome());
        }

        private void BtVATInvoiceRequestClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new VATInvoiceRequestHome());
        }
        private void BtPurchaseDeliveryHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new PurchaseDeliveryHome());
        }

        private void BtApprovalSetting(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ApprovalList());
        }

        private void BtFundFlowSettingClick(object sender, RoutedEventArgs e) 
        {
            fmMain.Navigate(new FundFlowHome());
        }

        private void BtWarehouseInHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new WarehouseInHome());
        }

        private void BtWarehouseOutHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new WarehouseOutHome());
        }

        private void BtApprovalCenterClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ApprovalCenterHome());
        }

        private void BtPaymentRequestHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new PaymentRequestHome());
        }

        private void ExpPricingExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively((Expander)sender);
        }

        private void BtPricingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new PricingHome());
        }

        private void BtAveragePricingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new AveragePricingHome());
        }
        
        private void BtLetterOfCreditSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new LetterOfCreditHome());
        }
        private void BtVATInvoiceClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new VATInvoiceHome());
        }
        
        private void BtPaymentWorkbenchSettingClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new PaymentWorkbench());
        }

        private void BtPurchaseCommercialInvoiceHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new CommercialInvoiceHome(ContractType.Purchase));
        }

        private void BtSaleCommercialInvoiceHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new CommercialInvoiceHome(ContractType.Sales));
        }


        private void BtLedgerClick(object sender, RoutedEventArgs e)
 		{
            fmMain.Navigate(new Ledger());
        }

        private void BtLMEMarginReportClick(object sender, RoutedEventArgs e)
 		{
            fmMain.Navigate(new LMEMarginReport());
        }
        

        private void BtInventoryReportHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new InventoryReportHome());
        }

        private void BtLmePositionHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new LMEPositionHome());
        }

        private void BtExposureChartClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ExposureChart());
        }

        private void BtDashboardClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new DashBoardChart());
        }

        private void BtModifyPasswordClick(object sender, RoutedEventArgs e)
        {
            var mp = new ModifyPassword();
            mp.Show();
        }

        private void BtSHFEHomeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new SHFEPositionHome());
        }

        private void BtSHFEPositionPLReportClick(object sender, RoutedEventArgs e)
        {
            var r = new SHFEPositionPLReport();
            fmMain.Navigate(r);
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show(ResMain.LogoutConfirm, ResMain.Logout, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var l = new Login();
                l.Show();
                Close();
                Application.Current.Properties.Clear();
            }
        }

        private void BtRegisterLogClick(object sender, RoutedEventArgs e)
        {
            var rl = new LogRegister();
            fmMain.Navigate(rl);
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            //_regCountUpdater.Cancel();
        }

        private void BtLogMessageClick(object sender, RoutedEventArgs e)
        {
            var lm = new LogMessageList();
            fmMain.Navigate(lm);
        }

        private void GoLogMessageListCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void GoLogMessageListExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var lm = new LogMessageList();
            fmMain.Navigate(lm);
            e.Handled = true;
        }

        private void BtMonitorCenterClick(object sender, RoutedEventArgs e)
        {
            var mc = new MonitorCenter();
            fmMain.Navigate(mc);
        }

        private void BtLMEPositionPLReportClick(object sender, RoutedEventArgs e)
        {
            var r = new LMEPositionPLReport();
            fmMain.Navigate(r);
        }

        private void BtHedgeGroupClick(object sender, RoutedEventArgs e)
        {
            var hg = new HedgeGroupHome();
            fmMain.Navigate(hg);
        }

        private void BtAPARHomeClick(object sender, RoutedEventArgs e)
        {
            var frmAPAR = new APARReport();
            fmMain.Navigate(frmAPAR);
        }

        private void BtQuotaInvoiceDetailReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new QuotaInvoiceDetailReport());
        }

        private void BtExternalDeliveryCirculReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ExternalDeliveryCirculReport());
        }

        private void BtQuotaStatusChangeClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new QuotaStatus());
        }


        private void BtPhysicalAndFuturesReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new PhysicalAndFuturesReport());
        }

        private void BtSHFEFundFlowReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new SHFEFundFlowReport());
        }

        private void BtBPartnerContractOrderClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new BusinessPartnerContractOrder());
        }

        private void BtHedgeGroupFloatPNLReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new HedgeGroupPNL());
        }

        private void BtForwardPositionReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ForwardPositionReport());
        }

        private void BtFDPStorageFeeDetailReportClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new FDPStorageFeeDetail());
        }

        private void BtForeignDeliveryPool_OnClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new ForeignDeliveryPoolHome());
        }

        private void BtLCAllocationHome_OnClick(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(new LCAllocationHome());
        }

        #endregion

        #region Method

        private void ExpandExculsively(Expander expander)
        {
            foreach (object child in stackPanel1.Children)
            {
                if (child is Expander && child != expander)
                    ((Expander) child).IsExpanded = false;
            }
        }

        private void InitMenus()
        {
            List<Category> allCategories;
            using (var categoryService = SvcClientManager.GetSvcClient<CategoryServiceClient>(SvcType.CategorySvc))
            {
                allCategories = categoryService.FetchAll(new List<string> {"Modules"});
            }

            foreach (Category c in allCategories)
            {
                if (!MainVM.Categories.Contains(c))
                {
                    var expander = (Expander) (FindName(c.ControlName));
                    if (expander != null)
                        expander.Visibility = Visibility.Collapsed;
                }
                else
                {
                    var category = MainVM.Categories.FirstOrDefault(o => o.Id == c.Id);
                    if (category != null)
                    {
                        List<Module> ms = category.Modules.ToList();
                        foreach (Module m in c.Modules)
                        {
                            if (!ms.Contains(m))
                            {
                                var button = (Button) (FindName(m.ControlName));
                                if (button != null)
                                    button.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }

            var moduleIdMap = allCategories.SelectMany(c => c.Modules).ToDictionary(m => m.Name, m => m.Id);
            Application.Current.Properties.Add("ModuleIdMap", moduleIdMap);
        }

        #endregion
    }

    class RegCountUpdateThread
    {
        private CancellationTokenSource _cts;

        public void Begin(MainVM vm)
        {
            _cts = new CancellationTokenSource();
            var t = new Task(() => Run(_cts.Token, vm), _cts.Token);
            t.Start();
        }

        static void Run(CancellationToken ct, MainVM vm)
        {
            while (!ct.IsCancellationRequested)
            {
                Func<int> regCount = () => MainVM.GetUnreadLogCount(vm.CurrentUser.Id);

                AsyncCallback acbRegCount = i => vm.Dispatcher.Invoke(
                    new Action(() =>
                        {
                            int dResult = regCount.EndInvoke(i);
                            vm.UnreadLogCount = dResult;
                        }
                        ));

                regCount.BeginInvoke(acbRegCount, null);
                Thread.Sleep(120000);
            }
        }

        public void Cancel()
        {
            _cts.Cancel();
        }
    }
}
