using System;
using System.Windows;
using System.Windows.Input;
using Client.View.Attachments;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// ImportDeliveryDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class ImportDeliveryDetail
    {
        #region Property

        public Quota Quota { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Custructor

        public ImportDeliveryDetail(PageMode pageMode)
            : base(pageMode, ResDelivery.ImportDelivery)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryVM(DeliveryType.ExternalTDBOL);
            BindData();
        }

        public ImportDeliveryDetail(int deliveryId, PageMode pageMode)
            : base(pageMode, ResDelivery.ImportDelivery)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryVM(deliveryId);
            BindData();
        }

        #endregion

        #region Method
        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGridDeliveryLines.DataContext = ((DeliveryVM) VM).DeliveryLines;
            RefreshAttachment();
        }

        private new void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
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

        /// <summary>
        /// 刷新附件列表
        /// </summary>
        public void RefreshAttachment()
        {
            dataGridAttachment.DataContext = ((DeliveryVM)VM).Attachments;
            dataGridAttachment.Items.Refresh();
        }

        #endregion

        #region Event

        /// <summary>
        /// 批次弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrderLineClick(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM) VM).ShowQuotaDialog();
            RefreshDeliveryLines();
        }

        /// <summary>
        /// 发货人弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShipperClick(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM) VM).ShowShipperDialog();
        }

        /// <summary>
        /// 承运商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShippingPartyClick(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM) VM).ShowShippingPartyDialog();
        }

        /// <summary>
        /// 通知人弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLinkmanClick(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM) VM).ShowNotifyPartyDialog();
        }

        /// <summary>
        /// 新增提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            if (((DeliveryVM) VM).QuotaId <= 0 || ((DeliveryVM) VM).QuotaId == null)
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            }
            else
            {
                ((DeliveryVM) VM).AddDeliveryLine(ModuleName, DeliveryType.ExternalTDBOL);
                RefreshDeliveryLines();
            }
        }

        /// <summary>
        /// 提单行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryLineCanEditExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != -Int32.MaxValue;
            e.Handled = true;
        }

        /// <summary>
        /// 提单行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryLineCanDeleteExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != -Int32.MaxValue;
            e.Handled = true;
        }

        private void RefreshDeliveryLines()
        {
            ((DeliveryVM) VM).AddSumLine();
            dataGridDeliveryLines.DataContext = ((DeliveryVM) VM).DeliveryLines;
            dataGridDeliveryLines.Items.Refresh();
        }

        /// <summary>
        /// 编辑提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                ((DeliveryVM) VM).EditDeliveryLine(id, ModuleName, DeliveryType.ExternalTDBOL);
                RefreshDeliveryLines();
            }
        }

        /// <summary>
        /// 删除提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    ((DeliveryVM) VM).DeleteDeliveryLine(id);
                    RefreshDeliveryLines();
                }
            }
        }

        private void AttachmentDownLoadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AttachmentDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            Attachment attachment = ((DeliveryVM) VM).GetAttachmentById(id, ((DeliveryVM) VM).Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 附件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ((DeliveryVM) VM).RemoveAttachment(id);
                RefreshAttachment();
            }
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload {Header = Properties.Resources.AttachmentUpload};
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment {FileName = frm.SavePath, DocumentId = 3};
                ((DeliveryVM) VM).AddAttachment(attachment);
                RefreshAttachment();
            }
        }

        private void ObjectBasePageLoaded(object sender, RoutedEventArgs e)
        {
            //if (PageMode.EditMode == PageMode && ((DeliveryVM)VM).IsReexport())
            //{
            //    if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            //    {
            //        var root = FindName("rootGrid") as Grid;
            //        if (root != null) root.IsEnabled = false;
            //    }
            //}
        }

        #endregion

        /// <summary>
        /// 从提单池中选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (((DeliveryVM)VM).QuotaId == null || ((DeliveryVM)VM).QuotaId <= 0)
            {
                MessageBox.Show("请先选择批次");
                return;
            }

            string queryStr = "it.DeliveryType = " + (int)((DeliveryVM)VM).DeliveryType + " and it.CommodityId = " + ((DeliveryVM)VM).Commodity.Id;
            var dialog = PopUpDialog.PopDialogCreater.CreateDialog("ForeignDeliveryPool", queryStr, null);
            dialog.ShowDialog();
            var item = dialog.SelectedItem as ForeignDeliveryPool;
            if (item != null)
            {
                ((DeliveryVM)VM).CopyFromFDP(item);
                RefreshDeliveryLines();
                RefreshAttachment();
            }
        }
    }
}