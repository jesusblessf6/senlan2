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
    /// ImportWRDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class ImportWRDetail
    {
        #region Property

        public DeliveryVM VM { get; set; }
        public Quota Quota { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Custructor

        public ImportWRDetail(PageMode pm) : base(pm)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryVM(DeliveryType.ExternalTDWW);
            BindData();
        }

        public ImportWRDetail(int deliveryId, PageMode pm) : base(pm)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryVM(deliveryId);
            if (VM.IsConvertWR)
            {
                SetConvertWREnabledStatus();
            }
            BindData();
        }

        public ImportWRDetail(PageMode pm,int tdId)
            : base(pm)
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            VM = new DeliveryVM(DeliveryType.ExternalTDWW,tdId);
            SetConvertWRControlEnabledStatus(tdId);
            BindData();
        }

        #endregion

        #region Method
        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGridDeliveryLines.DataContext = VM.DeliveryLines;
            RefreshAttachment();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new PurchaseDeliveryHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                //TODO:调试后删除
                //Logger.write("新增进口仓单失败，" + ex.Message);
                //if (ex.InnerException != null)
                //    Logger.write("新增进口仓单失败，" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 刷新附件列表
        /// </summary>
        public void RefreshAttachment()
        {
            dataGridAttachment.DataContext = VM.Attachments;
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
            VM.ShowQuotaDialog();
            RefreshDeliveryLines();
        }

        /// <summary>
        /// 仓储商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWarehouseCompanyClick(object sender, RoutedEventArgs e)
        {
            VM.ShowWarehouseProviderDialog();
        }

        /// <summary>
        /// 仓库弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWarehouseClick(object sender, RoutedEventArgs e)
        {
            VM.ShowWarehouseDialog();
        }

        private void RefreshDeliveryLines()
        {
            VM.AddSumLine();
            dataGridDeliveryLines.DataContext = VM.DeliveryLines;
            dataGridDeliveryLines.Items.Refresh();
        }

        /// <summary>
        /// 新增提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId <= 0 || VM.QuotaId == null)
            {
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            }
            else
            {
                VM.AddDeliveryLine(ModuleName, DeliveryType.ExternalTDWW);
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
                VM.EditDeliveryLine(id, ModuleName, DeliveryType.ExternalTDWW);
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
                    VM.DeleteDeliveryLine(id);
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
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            Attachment attachment = VM.GetAttachmentById(id, VM.Attachments);
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
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm, Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                VM.RemoveAttachment(id);
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
            var frm = new FileUpload { Header = Properties.Resources.AttachmentUpload };
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment { FileName = frm.SavePath, DocumentId = 3 };
                VM.AddAttachment(attachment);
                RefreshAttachment();
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        private void ImportWRLoaded(object sender, RoutedEventArgs e)
        {
            //if (PageMode.EditMode == PageMode && VM.IsReexport())
            //{
            //    if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            //    {
            //        var root = FindName("rootGrid") as Grid;
            //        if (root != null) root.IsEnabled = false;
            //    }
            //}
        }

        #endregion   

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId == null || VM.QuotaId <= 0)
            {
                MessageBox.Show("请先选择批次");
                return;
            }

            string queryStr = "it.DeliveryType = " + (int)VM.DeliveryType + " and it.CommodityId = " + VM.Commodity.Id;
            var dialog = PopUpDialog.PopDialogCreater.CreateDialog("ForeignDeliveryPool", queryStr, null);
            dialog.ShowDialog();
            var item = dialog.SelectedItem as ForeignDeliveryPool;
            if (item != null)
            {
                VM.CopyFromFDP(item);
                RefreshDeliveryLines();
                RefreshAttachment();
            }
        }

        /// <summary>
        /// 提单转仓单的页面逻辑
        /// </summary>
        /// <param name="tdId"></param>
        private void SetConvertWRControlEnabledStatus(int tdId)
        {
            if (tdId > 0)
            {
                SetConvertWREnabledStatus();
            }
        }

        private void SetConvertWREnabledStatus()
        {
            //批次弹出框按钮
            btnOrderLine.IsEnabled = false;

            //仓单号文本框
            tbDeliveryNo.IsReadOnly = false;
            tbDeliveryNo.IsEnabled = true;

            //仓单号弹出框按钮
            button2.Visibility = System.Windows.Visibility.Collapsed;

            //仓库弹出框
            btnWarehouse.Visibility = System.Windows.Visibility.Visible;

            //仓储商弹出框
            btnWarehouseCompany.Visibility = System.Windows.Visibility.Visible;
        }
    }
}