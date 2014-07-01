using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// PurchaseDeliveryHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PurchaseDeliveryHome
    {
        #region Property

        public DeliveryHomeVM VM { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Constructor

        public PurchaseDeliveryHome()
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryHomeVM(ContractType.Purchase);
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

        /// <summary>
        /// 本月内贸提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentMonthDomesticClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearchQuick(true);
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        /// <summary>
        /// 本月外贸提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentMonthForeignClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearchQuick(false);
            var search = new DeliveryList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        /// <summary>
        /// 新增内贸提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var frm = new PurchaseDeliveryDetail(PageMode.AddMode);
            RedirectTo(frm);
        }

        /// <summary>
        /// 新增内贸仓单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var frm = new PurchaseWRDetail(PageMode.AddMode);
            RedirectTo(frm);
        }

        /// <summary>
        /// 新增进口/转口提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            //var frm = new ImportDeliveryDetail(PageMode.AddMode);
            var frm = new NewImportDeliveryDetail(PageMode.AddMode, DeliveryType.ExternalTDBOL);
            RedirectTo(frm);
        }

        /// <summary>
        /// 新增进口/转口仓单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4Click(object sender, RoutedEventArgs e)
        {
            //var frm = new ImportWRDetail(PageMode.AddMode);
            var frm = new NewImportDeliveryDetail(PageMode.AddMode, DeliveryType.ExternalTDWW);
            RedirectTo(frm);
        }

        #endregion

        #region PopUpdialog

        /// <summary>
        /// 供应商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                VM.SupplierId = BusinessPartner.Id;
                VM.SupplierName = BusinessPartner.ShortName;
            }
        }

        #endregion

        private void button5_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 根据金属设置品牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMetal_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            VM.GetBrands();
        }
    }
}