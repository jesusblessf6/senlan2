using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.ViewModel.Reports;
using Client.View.PopUpDialog;
using DBEntity;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for FDPStorageFeeDetail.xaml
    /// </summary>
    public sealed partial class FDPStorageFeeDetail
    {
        public FDPStorageFeeDetailVM FDVM { get; set; }
        public Warehouse Warehouse { get; set; }

        public FDPStorageFeeDetail()
        {
            InitializeComponent();
            ModuleName = "FDPStorageFeeDetail";
            FDVM = new FDPStorageFeeDetailVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = FDVM;
            dataGrid1.DataContext = FDVM.StorageFeeList;
            dataGrid1.Items.Refresh();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            Warehouse = dialog.SelectedItem as Warehouse;
            if (Warehouse != null)
            {
                FDVM.WarehouseId = Warehouse.Id;
                FDVM.WarehouseName = Warehouse.Name;
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                waitingBox.Show();
                FDVM.GetData();
                dataGrid1.DataContext = FDVM.StorageFeeList;
                dataGrid1.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
        }
    }
}
