using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Contracts;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for MoreDetail.xaml
    /// </summary>
    public sealed partial class MoreDetail
    {
        #region Property

        public Warehouse Warehouse { get; set; }

        #endregion

        public MoreDetail(int? commodityID, int? commodityTypeID, List<QuotaBrandRel> allList,
                          List<QuotaBrandRel> addList, PageMode pageMode, string moduleName, int pricingType)
            : base(pageMode, ResContract.MultiBrand)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new MoreDetailVM(commodityID, commodityTypeID, allList, addList, pricingType);
            BindData();
            SetVisible(pricingType);
        }

        public MoreDetail(int id, int? commodityID, int? commodityTypeID, List<QuotaBrandRel> allList,
                          List<QuotaBrandRel> addList, List<QuotaBrandRel> updateList, PageMode pageMode,
                          string moduleName, int pricingType)
            : base(pageMode, ResContract.MultiBrand)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new MoreDetailVM(id, commodityID, commodityTypeID, allList, addList, updateList, pricingType);
            BindData();
            SetVisible(pricingType);
        }

        public void SetVisible(int pricingType)
        {
            if (pricingType != (int) PricingType.Fixed)
            {
                label4.Visibility = Visibility.Collapsed;
                currencyTextBox2.Visibility = Visibility.Collapsed;
            }
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            Warehouse = dialog.SelectedItem as Warehouse;
            if (Warehouse != null)
            {
                ((MoreDetailVM)VM).WarehouseId = Warehouse.Id;
                ((MoreDetailVM)VM).WarehouseName = Warehouse.Name;
            }
        }
    }
}