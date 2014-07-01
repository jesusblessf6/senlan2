using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.WarehouseSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.WarehouseSetting
{
    /// <summary>
    /// Interaction logic for WarehouseSettingHome.xaml
    /// </summary>
    public partial class WarehouseSettingHome
    {
        #region Member

        private const int WarehousePerPage = 10;
        private readonly bool _canView;
        private readonly bool _canEdit;
        private readonly bool _canDelete;

        #endregion

        #region Property

        public WarehouseSettingVM VM { get; set; }

        #endregion

        #region Constructor

        public WarehouseSettingHome()
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            VM = new WarehouseSettingVM();

            _canView = CheckPerm(PageMode.ViewMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            button1.IsEnabled = CheckPerm(PageMode.AddMode);

            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl1.Init(VM.WarehouseCount, WarehousePerPage);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.Warehouses;
            dataGrid1.Items.Refresh();
        }

        public override void Refresh()
        {
            VM.LoadWarehouseCount();
            pagingControl1.Init(VM.WarehouseCount, WarehousePerPage);
            dataGrid1.ItemsSource = VM.Warehouses;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var wd = new WarehouseDetail(PageMode.AddMode);
            wd.Show();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1)*WarehousePerPage + e.Row.GetIndex() + 1;
        }

        private void WarehouseEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void WarehouseEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var warehouseId = (int) e.Parameter;
            var bd = new WarehouseDetail(warehouseId, PageMode.EditMode);
            bd.Show();
            e.Handled = true;
        }

        private void WarehouseDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void WarehouseDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteWarehouse(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
            }
            e.Handled = true;
        }

        private void WarehouseViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void WarehouseViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var warehouseId = (int) e.Parameter;
            var bd = new WarehouseDetail(warehouseId, PageMode.ViewMode);
            bd.Show();
            e.Handled = true;
        }

        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.WarehouseFrom = e.From;
            VM.WarehouseTo = e.To;
            VM.LoadWarehouse();
            dataGrid1.ItemsSource = VM.Warehouses;
            dataGrid1.Items.Refresh();
        }

        #endregion

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
    }
}