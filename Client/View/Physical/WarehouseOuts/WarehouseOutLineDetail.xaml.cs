using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseOuts;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.WarehouseOuts
{
    /// <summary>
    /// Interaction logic for WarehouseOutLineDetail.xaml
    /// </summary>
    public sealed partial class WarehouseOutLineDetail
    {
        #region Property

        public WarehouseInLine WarehouseInLine { get; set; }
        public WarehouseOutLineDetailVM WVM { get; set; }

        #endregion

        #region Constructor

        public WarehouseOutLineDetail(int quotaId, PageMode pageMode, List<WarehouseOutLine> lines,
                                      List<WarehouseInLine> inLines, List<WarehouseOutLine> addLines,
                                      int internalCustomerID, int warehouseId)
            : base(pageMode, ResWarehouseOut.WarehouseOutLine)
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            WVM = new WarehouseOutLineDetailVM(quotaId, lines, inLines, addLines, internalCustomerID, warehouseId);
            BindData();
        }

        public WarehouseOutLineDetail(int commodityId, int warehouseOutLineId, PageMode pageMode,
                                      List<WarehouseOutLine> lines, List<WarehouseOutLine> addLines,
                                      List<WarehouseOutLine> updateLines, List<WarehouseInLine> inLines,
                                      int internalCustomerID, int warehouseId)
            : base(pageMode, ResWarehouseOut.WarehouseOutLine)
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            WVM = new WarehouseOutLineDetailVM(commodityId, warehouseOutLineId, lines, addLines, updateLines, inLines,
                                         internalCustomerID, warehouseId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = WVM;
            dataGrid1.DataContext = WVM.AllDeliveryPersonList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
        }

        public override void Refresh()
        {
            dataGrid1.DataContext = WVM.AllDeliveryPersonList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void BtSave(object sender, RoutedEventArgs e)
        {
            try
            {
                WVM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            const string str = "it.IsPBCleared = false and it.DeliveryLine.Delivery.Quota.CommodityId = @p1 and it.BrandId = @p2 and it.SpecificationId = @p3 and it.CommodityTypeId = @p4 and it.DeliveryLine.Delivery.Quota.Contract.InternalCustomerId = @p5 and it.WarehouseIn.WarehouseId = @p6";
            var parameters = new List<object>
                                 {
                                     WVM.CommodityId,
                                     WVM.BrandId,
                                     WVM.SpecificationId,
                                     WVM.CommodityTypeId,
                                     WVM.InternalCustomerID,
                                     WVM.WarehouseId
                                 };
            var dialog = PopDialogCreater.CreateDialog("WarehouseInLine", str, parameters);
            dialog.ShowDialog();
            WarehouseInLine = dialog.SelectedItem as WarehouseInLine;
            if (WarehouseInLine != null)
            {
                WVM.WarehouseInLineId = WarehouseInLine.Id;
                WVM.PBNo = WarehouseInLine.PBNo;
                WVM.WarehouseInLine = WarehouseInLine;
                WVM.PackingQuantity = WarehouseInLine.OnlyPackingQty;
                WVM.GetOnlyQty(WarehouseInLine.Id);
            }
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var pd = new DeliveryPersonDetail(WVM.AllDeliveryPersonList, WVM.AddDeliveryPersonList, PageMode.AddMode);
            pd.ShowDialog();
            Refresh();
        }

        private void DeliveryPersonCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != 0;
            e.Handled = true;
        }

        private void DeliveryPersonEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            var pd = new DeliveryPersonDetail(id, WVM.AllDeliveryPersonList, WVM.AddDeliveryPersonList,
                                              WVM.UpdateDeliveryPersonList, PageMode.AddMode);
            pd.ShowDialog();
            Refresh();
        }

        private void DeliveryPersonDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    WVM.DelDeliveryPerson(id);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        #endregion
    }
}