using Client.ViewModel.SystemSetting.WarehouseSetting;
using DBEntity.EnumEntity;
using System;
using System.Windows;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;
using System.Windows.Input;

namespace Client.View.SystemSetting.WarehouseSetting
{
    /// <summary>
    /// Interaction logic for WarehouseDetail.xaml
    /// </summary>
    public sealed partial class WarehouseDetail
    {
        #region Constructor

        public WarehouseDetail()
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            VM = new WarehouseDetailVM();
            BindData();
        }

        public WarehouseDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Warehouse)
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            VM = new WarehouseDetailVM();
            BindData();
        }

        public WarehouseDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.Warehouse)
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            VM = new WarehouseDetailVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.DataContext = ((WarehouseDetailVM)VM).AllStorageFeeRules;
            dataGrid1.Items.Refresh();
        }

        public override void Refresh()
        {
            dataGrid1.DataContext = ((WarehouseDetailVM)VM).AllStorageFeeRules;
            dataGrid1.Items.Refresh();
        }
        #endregion

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var sf = new StorageFeeDetail(PageMode.AddMode, ((WarehouseDetailVM)VM).AllStorageFeeRules, ((WarehouseDetailVM)VM).AddStorageFeeRules);
                sf.ShowDialog();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void StorageFeeRuleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            e.CanExecute = id != 0;
            e.Handled = true;
        }

        private void StorageFeeRuleEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0)
            {
                var sf = new StorageFeeDetail(id, PageMode.EditMode, ((WarehouseDetailVM)VM).AllStorageFeeRules, ((WarehouseDetailVM)VM).AddStorageFeeRules, ((WarehouseDetailVM)VM).UpdateStorageFeeRules);
                sf.ShowDialog();
                Refresh();
            }
        }

        private void StorageFeeRuleDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    ((WarehouseDetailVM)VM).DeleteStorageFeeRule(id);
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
    }
}