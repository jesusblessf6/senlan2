using System;
using System.Data;
using System.Windows;
using Client.View.Physical.Deliveries;
using Client.ViewModel.Physical.InventoryReport;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using DBEntity;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.View.Physical.InventoryReport
{
    /// <summary>
    /// Interaction logic for InventoryReportHome.xaml
    /// </summary>
    public sealed partial class InventoryReportHome
    {
        #region Property

        public InventoryReportHomeVM VM { get; set; }

        #endregion

        public InventoryReportHome()
        {
            InitializeComponent();
            ModuleName = "InventoryReportHome";
            VM = new InventoryReportHomeVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            waitingBox.Show();
            try
            {
                if (VM.Validate())
                {
                    VM.Init();
                    warehouseInventory.ItemsSource = VM.DT.AsDataView();
                    internalTDList.DataContext = VM.InternalTDList;
                    externalTDList.DataContext = VM.ExternalTDList;
                }
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

        private void ShowCirculDetailCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ShowCirculDetailExecute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var circulNo = e.Parameter as string;
            var win = new DeliveryListOfSameFlow(ModuleName, circulNo);
            win.Show();
        }

        private void DataGridAPARLoadingRow(object sender, DataGridRowEventArgs e)
        {
            var item = e.Row.DataContext as DeliveryLine;
            if (item != null)
            {
                if (item.Id == 0)
                {
                    e.Row.Foreground = Brushes.Red;
                }
            }
        }

        private void externalTDList_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var item = e.Row.DataContext as DeliveryLine;
            if (item != null)
            {
                if (item.Id == 0)
                {
                    e.Row.Foreground = Brushes.Red;
                }
            }
        }
    }
}