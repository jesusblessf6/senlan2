using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseOuts;
using DBEntity;

namespace Client.View.Physical.WarehouseOuts
{
    /// <summary>
    /// Interaction logic for WarehouseOutHome.xaml
    /// </summary>
    public sealed partial class WarehouseOutHome
    {
        #region Constructor

        public WarehouseOutHome()
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            VM = new WarehouseOutHomeVM();
            BindData();
        }

        #endregion

        #region Event

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SetPropertyValue("SupplierId", bp.Id);
                VM.SetPropertyValue("SupplierName", bp.ShortName);
            }
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var warehouse = dialog.SelectedItem as Warehouse;
            if (warehouse != null)
            {
                VM.SetPropertyValue("WarehouseId", warehouse.Id);
                VM.SetPropertyValue("WarehouseName", warehouse.Name);
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var wod = new WarehouseOutDetail();
            RedirectTo(wod);
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(WarehouseOutHomeVM.SearchType.Free);
            var listPage = new WarehouseOutList(cons);
            RedirectTo(listPage);
        }

        private void BtnCurrentMonthListClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(WarehouseOutHomeVM.SearchType.CurrentMonth);
            var listPage = new WarehouseOutList(cons);
            RedirectTo(listPage);
        }

        private void BtnLastMonthListClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(WarehouseOutHomeVM.SearchType.LastMonth);
            var listPage = new WarehouseOutList(cons);
            RedirectTo(listPage);
        }

        private void BtnCurrentYearListClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(WarehouseOutHomeVM.SearchType.CurrentYear);
            var listPage = new WarehouseOutList(cons);
            RedirectTo(listPage);
        }

        private void BtnLastYearListClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(WarehouseOutHomeVM.SearchType.LastYear);
            var listPage = new WarehouseOutList(cons);
            RedirectTo(listPage);
        }

        #endregion
    }
}