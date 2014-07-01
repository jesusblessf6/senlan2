using System.Windows;
using System.Windows.Input;
using Client.View.Attachments;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.ForeignDeliveryPools;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.View.Physical.ForeignDeliveryPools
{
    /// <summary>
    /// Interaction logic for ForeignDeliveryPoolDetail.xaml
    /// </summary>
    public sealed partial class ForeignDeliveryPoolDetail
    {
        #region Members & Properties

        private readonly string _deliveryTypeName;
        private readonly bool _canEdit;

        #endregion

        #region Constructor

        public ForeignDeliveryPoolDetail(EnumItem deliveryType)
            : base(PageMode.AddMode, deliveryType.Name)
        {
            InitializeComponent();
            VM = new ForeignDeliveryPoolDetailVM(deliveryType.Id);
            ModuleName = "ForeignDeliveryPool";
            _deliveryTypeName = deliveryType.Name;
            _canEdit = CheckPerm(PageMode.EditMode);
            BindData();
        }

        public ForeignDeliveryPoolDetail(PageMode pageMode, EnumItem deliveryType)
            : base(pageMode, deliveryType.Name)
        {
            InitializeComponent();
            VM = new ForeignDeliveryPoolDetailVM(deliveryType.Id);
            ModuleName = "ForeignDeliveryPool";
            _deliveryTypeName = deliveryType.Name;
            _canEdit = CheckPerm(PageMode.EditMode);
            BindData();
        }

        public ForeignDeliveryPoolDetail(PageMode pagemode, EnumItem deliveryType, int id)
            : base(pagemode, deliveryType.Name)
        {
            InitializeComponent();
            VM = new ForeignDeliveryPoolDetailVM(id, deliveryType.Id);
            ModuleName = "ForeignDeliveryPool";
            _deliveryTypeName = deliveryType.Name;
            _canEdit = CheckPerm(PageMode.EditMode);
            BindData();
        }

        #endregion

        #region Event

        /// <summary>
        /// 发货人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SetPropertyValue("ShipperId", bp.Id);
                VM.SetPropertyValue("ShipperName", bp.ShortName);
            }
        }

        /// <summary>
        /// 承运商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SetPropertyValue("ShipperPartyId", bp.Id);
                VM.SetPropertyValue("ShipperPartyName", bp.ShortName);
            }
        }

        /// <summary>
        /// 通知人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SetPropertyValue("NotifyPartyId", bp.Id);
                VM.SetPropertyValue("NotifyPartyName", bp.ShortName);
            }
        }

        /// <summary>
        /// 仓储商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.SetPropertyValue("WarehouseProviderId", bp.Id);
                VM.SetPropertyValue("WarehouseProviderName", bp.ShortName);
            }
        }

        /// <summary>
        /// 仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var wh = dialog.SelectedItem as Warehouse;
            if (wh != null)
            {
                VM.SetPropertyValue("WarehouseId", wh.Id);
                VM.SetPropertyValue("WarehouseName", wh.Name);
            }
        }

        /// <summary>
        /// Add Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4Click(object sender, RoutedEventArgs e)
        {
            if (cbCommodity.SelectedIndex == 0)
            {
                MessageBox.Show("请先选择金属");
                return;
            }
            var w = new ForeignDeliveryPoolLineDetail(_deliveryTypeName + "明细", (ForeignDeliveryPoolDetailVM)VM);
            w.Show();
        }

        /// <summary>
        /// Add Attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7Click(object sender, RoutedEventArgs e)
        {
            var frm = new FileUpload {Header = Properties.Resources.AttachmentUpload, Owner = MainWindow};
            frm.ShowDialog();

            if (!string.IsNullOrWhiteSpace(frm.FileName) && frm.SaveFile)
            {
                var attachment = new Attachment { FileName = frm.SavePath, DocumentId = 3 };
                ((ForeignDeliveryPoolDetailVM) VM).NewAddAttachments.Add(attachment);
                ((ForeignDeliveryPoolDetailVM)VM).Attachments.Add(attachment);
                ((ForeignDeliveryPoolDetailVM) VM).ChangeAttFileName();
                Refresh();
            }
        }

        private void DetailLineEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void DetailLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var w = new ForeignDeliveryPoolLineDetail(_deliveryTypeName + "明细", id, (ForeignDeliveryPoolDetailVM) VM,
                                                      PageMode.EditMode);
            w.Show();
            e.Handled = true;
        }

        private void DetailLineDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ForeignDeliveryPoolDetailVM)VM).IsLineDeleteBtnEnable;
            e.Handled = true;
        }

        private void DetailLineDeleteExeCuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                ((ForeignDeliveryPoolDetailVM) VM).RemoveDetailLine(id);
                Refresh();
            }
            e.Handled = true;
        }

        private void AttachmentDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                ((ForeignDeliveryPoolDetailVM) VM).RemoveAttachment(id);
                Refresh();
            }
            e.Handled = true;
        }

        private void AttachmentDownloadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void AttachmentDownloadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            var attachmentFileName = ((ForeignDeliveryPoolDetailVM) VM).GetAttachmentFileName(id);
            if (attachmentFileName != null)
            {
                var frm = new FileDownload(attachmentFileName);
                frm.ShowDialog();
            }
            e.Handled = true;
        }

        private void StorageDateEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void StorageDateEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var w = new StorageFeeDateDetail((ForeignDeliveryPoolDetailVM) VM, id, PageMode.EditMode);
            w.Show();
            e.Handled = true;
        }

        private void StorageDateDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void StorageDateDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                ((ForeignDeliveryPoolDetailVM) VM).RemoveStorageDateById(id);
                Refresh();
            }
            e.Handled = true;
        }

        private void Button10Click(object sender, RoutedEventArgs e)
        {
            var w = new StorageFeeDateDetail((ForeignDeliveryPoolDetailVM) VM);
            w.Show();
        }

        #endregion

        #region Method

        public override void Refresh()
        {
            dgDetail.Items.Refresh();
            dgAttachment.Items.Refresh();
            dgStorageDates.Items.Refresh();
        }

        #endregion

        
    }
}
