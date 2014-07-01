using System;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseIns;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.WarehouseIns
{
    /// <summary>
    /// Interaction logic for WarehouseInDetail.xaml
    /// </summary>
    public sealed partial class WarehouseInDetail
    {
        #region Property

        private readonly DeliveryTypeWarehouseIn _deliveryTypeWarehouseIn;
        public Warehouse Warehouse { get; set; }
        public WarehouseInDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public WarehouseInDetail(DeliveryTypeWarehouseIn deliveryTypeWarehouseIn)
        {
            InitializeComponent();
            ModuleName = "WarehouseInHome";
            _deliveryTypeWarehouseIn = deliveryTypeWarehouseIn;
            VM = new WarehouseInDetailVM(_deliveryTypeWarehouseIn);
            BindData();
        }

        public WarehouseInDetail(int id)
        {
            InitializeComponent();
            ModuleName = "WarehouseInHome";
            VM = new WarehouseInDetailVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            VM.SetQty();
            dataGrid1.DataContext = VM.Lines;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void Button2Click(object sender, RoutedEventArgs e)
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

        private void WarehouseInLineEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            e.CanExecute = id > 0;
            e.Handled = true;
        }

        private void WarehouseInLineDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            e.CanExecute = id > 0;
            e.Handled = true;
        }

        private void WarehouseInLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                var wid = new WarehouseInLineDetail(VM.DeliveryTypeWarehouseIn, id, PageMode.EditMode,
                                                    VM.AllWarehouseInLines, VM.AddWarehouseInLines,
                                                    VM.UpdateWarehouseInLines, VM.SelectedCommodityId);
                wid.ShowDialog();
                Refresh();
            }
        }

        private void WarehouseInLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DelWarehouseInLine(id);
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

        private void BtWarehouseInLineAddClick(object sender, RoutedEventArgs e)
        {
            var wi = new WarehouseInLineDetail(VM.DeliveryTypeWarehouseIn, PageMode.AddMode, VM.AllWarehouseInLines,
                                               VM.AddWarehouseInLines, VM.SelectedCommodityId);
            wi.ShowDialog();
            Refresh();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                var wih = new WarehouseInHome();
                RedirectTo(wih);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var wih = new WarehouseInHome();
            RedirectTo(wih);
        }

        public override void Refresh()
        {
            VM.SetQty();
            dataGrid1.DataContext = VM.Lines;
            dataGrid1.Items.Refresh();
        }

        #endregion
    }
}