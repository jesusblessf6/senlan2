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
    /// ExportWRDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class ExportWRDetail
    {
        #region Property

        public DeliveryVM VM { get; set; }
        public Quota Quota { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Constructor

        public ExportWRDetail()
        {
            InitializeComponent();
            ModuleName = "SalesDelivery";
            VM = new DeliveryVM(DeliveryType.ExternalMDWW);
            BindData();
        }

        public ExportWRDetail(int deliveryId)
        {
            InitializeComponent();
            ModuleName = "SalesDelivery";
            VM = new DeliveryVM(deliveryId);
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

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new SalesDeliveryHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                //TODO:调试后删除
                //Logger.write("新增转口仓单失败，" + ex.Message);
                //if (ex.InnerException != null)
                //    Logger.write("新增转口仓单失败，" + ex.InnerException.Message);
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
        /// 仓库弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWarehouseClick(object sender, RoutedEventArgs e)
        {
            VM.ShowWarehouseDialog();
        }

        /// <summary>
        /// 提单/仓单弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTDClick(object sender, RoutedEventArgs e)
        {
            if (VM.QuotaId <= 0 || VM.QuotaId == null)
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            else
            {
                VM.ShowTDDialog();
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
                MessageBox.Show(Properties.Resources.SelectQuotaWarning);
            else
            {
                VM.AddDeliveryLine(ModuleName, DeliveryType.ExternalMDWW);
                RefreshDeliveryLines();
            }
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
                VM.EditDeliveryLine(id, ModuleName, DeliveryType.ExternalMDWW);
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

        #endregion
    }
}