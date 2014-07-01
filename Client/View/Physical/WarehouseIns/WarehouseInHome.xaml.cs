using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseIns;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.WarehouseIns
{
    /// <summary>
    /// Interaction logic for WarehouseInHome.xaml
    /// </summary>
    public sealed partial class WarehouseInHome
    {
        #region Property

        public WarehouseInHomeVM VM { get; set; }
        public Warehouse Warehouse { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Constructor

        public WarehouseInHome()
        {
            ModuleName = "WarehouseInHome";
            InitializeComponent();
            VM = new WarehouseInHomeVM();
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

        private void Button3Click(object sender, RoutedEventArgs e)
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

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var wi = new WarehouseInDetail(DeliveryTypeWarehouseIn.InternalWarehouseIn);
            RedirectTo(wi);
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var wi = new WarehouseInDetail(DeliveryTypeWarehouseIn.ExternalWarehouseIn);
            RedirectTo(wi);
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            Warehouse = dialog.SelectedItem as Warehouse;
            if (Warehouse != null)
            {
                VM.WarehouseId = Warehouse.Id;
                VM.WarehouseName = Warehouse.Name;
            }
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch(comboBox1.SelectedValue.ToString(), WarehouseInSearchType.DefaultSearch);
            var wis = new WarehouseInList(ModuleName, VM.SearchVM);
            RedirectTo(wis);
        }

        private void BtnCurrentMonthListClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch(comboBox1.SelectedValue.ToString(), WarehouseInSearchType.CurrentMonth);
            var wis = new WarehouseInList(ModuleName, VM.SearchVM);
            RedirectTo(wis);
        }

        private void BtnLastMonthListClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch(comboBox1.SelectedValue.ToString(), WarehouseInSearchType.LastMonth);
            var wis = new WarehouseInList(ModuleName, VM.SearchVM);
            RedirectTo(wis);
        }

        private void BtnCurrentYearListClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch(comboBox1.SelectedValue.ToString(), WarehouseInSearchType.CurrentYear);
            var wis = new WarehouseInList(ModuleName, VM.SearchVM);
            RedirectTo(wis);
        }

        private void BtnLastYearListClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch(comboBox1.SelectedValue.ToString(), WarehouseInSearchType.LastYear);
            var wis = new WarehouseInList(ModuleName, VM.SearchVM);
            RedirectTo(wis);
        }

        #endregion
    }
}