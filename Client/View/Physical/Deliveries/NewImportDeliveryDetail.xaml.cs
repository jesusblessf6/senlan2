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
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using Client.View.PopUpDialog;
using DBEntity.EnumEntity;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// Interaction logic for NewImportDeliveryDetail.xaml
    /// </summary>
    public sealed partial class NewImportDeliveryDetail
    {
        public DeliveryVM DVM { get; set; }

        public NewImportDeliveryDetail(PageMode pageMode, DeliveryType deliveryType)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            DVM = new DeliveryVM(deliveryType);
            BindData();
        }

        public NewImportDeliveryDetail(int deliveryId, PageMode pageMode)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            DVM = new DeliveryVM(deliveryId);
            BindData();
        }

        #region Method
        public override void BindData()
        {
            rootGrid.DataContext = DVM;
            dataGridDeliveryLines.DataContext = DVM.DeliveryList;
        }

        private void RefreshDeliveryLines()
        {
            //DVM.AddSumLine();
            DVM.GetSumNum();
            dataGridDeliveryLines.DataContext = DVM.DeliveryList;
            dataGridDeliveryLines.Items.Refresh();
        }
        #endregion

        #region Event

        /// <summary>
        /// 提单行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryCanDeleteExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0)
            {
                e.CanExecute = true;
                e.Handled = true;
            }
            else
            {
                e.CanExecute = false;
                e.Handled = false;
            }
        }
        private void DeliveryCanEditExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int PID = e.Parameter is int ? (int)e.Parameter : 0;
            if (PID >= 0)
            {
                e.CanExecute = true;
                e.Handled = true;
            }
            else
            {
                e.CanExecute = false;
                e.Handled = false;
            }
        }

        /// <summary>
        /// 删除提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0)
            {
                if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    DVM.DeleteDelivery(id);
                    RefreshDeliveryLines();
                }
            }
        }
        private void DeliveryEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int PID = e.Parameter is int ? (int)e.Parameter : 0;
            if (PID >= 0)
            {
                var nde = new NewImportDeliveryEdit(PID, DVM.AddedDeliveryLines, DVM.DeliveryList, PageMode.EditMode);
                nde.ShowDialog();
                RefreshDeliveryLines();
            }
        }
        /// <summary>
        /// 批次弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrderLineClick(object sender, RoutedEventArgs e)
        {
            DVM.ShowQuotaDialog();
            //RefreshDeliveryLines();
        }

        /// <summary>
        /// 从提单池中选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (DVM.QuotaId == null || DVM.QuotaId <= 0)
            {
                MessageBox.Show("请先选择批次");
                return;
            }

            if (DVM.DeliveryType == DeliveryType.ExternalTDBOL || DVM.DeliveryType == DeliveryType.ExternalTDWW)
            {
                string queryStr = "it.DeliveryType = " + (int)DVM.DeliveryType + " and it.CommodityId = " + DVM.Commodity.Id;
                //var dialog = PopUpDialog.PopDialogCreater.CreateDialog("ForeignDeliveryPool", queryStr, null);
                PopDialog dialog = PopDialogCreater.CreateDialog("ForeignDeliveryPool", queryStr, null, null, null, 0, 0, true);
                dialog.ShowDialog();
                var itemList = dialog.SelectedItemList;
                if (itemList != null && itemList.Count > 0)
                {
                    DVM.GetData(itemList.Cast<ForeignDeliveryPool>().ToList());
                    RefreshDeliveryLines();
                }
            }
            else if (DVM.DeliveryType == DeliveryType.ExternalMDBOL || DVM.DeliveryType == DeliveryType.ExternalMDWW)
            {
                DVM.ShowTDDialog();
                RefreshDeliveryLines();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                DVM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                //RedirectTo(new PurchaseDeliveryHome());
                GoBackOrHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                //TODO:调试后删除
                //Logger.write("新增进口提单失败，" + ex.Message);
                //if (ex.InnerException != null)
                //    Logger.write("新增进口提单失败，" + ex.InnerException.Message);
            }
        }
        #endregion
    }
}
