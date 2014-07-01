using System;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.Physical.WarehouseIns;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using Client.View.PrintTemplate.DomesticWarehouseOutTemplate;

namespace Client.View.Physical.WarehouseIns
{
    /// <summary>
    /// Interaction logic for WarehouseInList.xaml
    /// </summary>
    public sealed partial class WarehouseInList
    {
        #region Member

        private const int ContractPerPage = 10;

        #endregion

        #region Property

        public WarehouseInListVM VM { get; set; }

        #endregion

        public WarehouseInList()
        {
            InitializeComponent();
            ModuleName = "WarehouseInHome";
            BindData();
        }

        public WarehouseInList(string moduleName, WarehouseInListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagerContract.OnNewPage += pagerContract_OnNewPage;
            pagerContract.Init(VM.WarehouseInAllCount, ContractPerPage);
            BindData();
        }

        #region Method

        public override void BindData()
        {
            warehouseInGrid.DataContext = VM.WarehouseInList;
            cbSelectAll.DataContext = VM;
        }

        public override void Refresh()
        {
            VM.LoadWarehouseInCount();
            pagerContract.Init(VM.WarehouseInAllCount, ContractPerPage);
        }

        #endregion

        #region Event

        private void WarehouseInEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void WarehouseInDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void WarehouseInPrintCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void pagerContract_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.WarehouseInFrom = e.From;
            VM.WarehouseInTo = e.To;
            VM.LoadWarehouseInList();
            warehouseInGrid.ItemsSource = VM.WarehouseInList;
            warehouseInGrid.Items.Refresh();
        }

        private void WarehouseInEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                int warehouseID = VM.GetWarehouseIdByWarehouseInLineID(id);
                var wi = new WarehouseInDetail(warehouseID);
                RedirectTo(wi);
            }
        }

        private void WarehouseInDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DelWarehouseInLine(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
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

        private void WarehouseInPrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            var printInOut = new PrintInOutTemplate(id, ModuleName, "打印入库单");
            RedirectTo(printInOut);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.PrintSelectedWarehouseIn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        
    }
}