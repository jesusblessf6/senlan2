using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// SalesDeliveryHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class SalesDeliveryHome
    {
        #region Property

        public DeliveryHomeVM VM { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Constructor

        public SalesDeliveryHome()
        {
            InitializeComponent();
            ModuleName = "SalesDelivery";
            VM = new DeliveryHomeVM(ContractType.Sales);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
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
            VM.LoadSearch();
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        private void BtnCurrentMonthClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSalesDelCurrentMonthSearch();
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        private void BtnLastMonthClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSalesDelLastMonthSearch();
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        private void BtnThisYearClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSalesDelCurrentYearSearch();
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var salesDelivery = new SalesDeliveryDetail();
            RedirectTo(salesDelivery);
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
           //var exportDelivery = new ExportDelivery();
            var exportDelivery = new NewImportDeliveryDetail(PageMode.AddMode, DeliveryType.ExternalMDBOL);
            RedirectTo(exportDelivery);
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            //var exportWR = new ExportWRDetail();
            var exportWR = new NewImportDeliveryDetail(PageMode.AddMode, DeliveryType.ExternalMDWW);
            RedirectTo(exportWR);
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            const string queryStr = "it.CustomerType=1 or it.CustomerType=3";
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                VM.SupplierId = BusinessPartner.Id;
                VM.SupplierName = BusinessPartner.ShortName;
            }
        }

        #endregion

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var warehouse = dialog.SelectedItem as Warehouse;
            if (warehouse != null)
            {
                VM.WarehouseId = warehouse.Id;
                VM.WarehouseName = warehouse.Name;
            }
        }

        private void comboBoxMetal_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            VM.GetBrands();
        }
    }
}