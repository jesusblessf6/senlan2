using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Client.View.PrintTemplate.DomesticWarehouseOutTemplate;
using Client.ViewModel.Physical.WarehouseOuts;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Utility.QueryManagement;

namespace Client.View.Physical.WarehouseOuts
{
    /// <summary>
    /// Interaction logic for WarehouseOutList.xaml
    /// </summary>
    public sealed partial class WarehouseOutList
    {
        #region Property

        public override bool IsLazy
        {
            get
            {
                return true;
            }
        }
        
        #endregion

        #region Constructor

        public WarehouseOutList(List<QueryElement> cons)
            : base("WarehouseOutHome")
        {
            InitializeComponent();
            VM = new WarehouseOutListVM(cons);
            cbSelectAll.DataContext = VM;
        }

        #endregion

        #region Event

        private void WarehouseOutEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                int warehouseOutID = ((WarehouseOutListVM)VM).GetWarehouseOutIdByLineID(id);
                var wd = new WarehouseOutDetail(warehouseOutID);
                RedirectTo(wd);
            }
        }

        private void WarehouseOutDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    ((WarehouseOutListVM)VM).DelWarehouseOutLine(id);
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

        private void PrintWarehouseOutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            var printWarehouseOut = new PrintWarehouseOutTemplate(id, ModuleName,"出库");
            RedirectTo(printWarehouseOut);
        }

        private void WarehouseOutPrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            var printInOut = new PrintInOutTemplate(id, ModuleName, "打印出库单");
            RedirectTo(printInOut);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WarehouseOutListVM)VM).PrintSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPrintWarehouseOutClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WarehouseOutListVM)VM).PrintSelectedWarehouseOut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}