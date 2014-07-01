using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Client.View.PrintTemplate.DomesticWarehouseOutTemplate;
using Utility.ErrorManagement;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// PurchaseDeliverySearch.xaml 的交互逻辑
    /// </summary>
    public sealed partial class DeliveryList
    {
        #region Member

        private const int PerPage = 20;

        #endregion

        #region Property

        public DeliveryListVM VM { get; set; }

        #endregion

        #region Constructor

        public DeliveryList(string moduleName, DeliveryListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagerDelivery.OnNewPage += pagerDelivery_OnNewPage;
            pagerDelivery.Init(VM.DeliveryTotleCount, PerPage);
            BindData();
        }

        public DeliveryList(string moduleName, int tdId)
        {
            InitializeComponent();
            ModuleName = moduleName;
            lbTitle.Content = "发货单列表";
            if (tdId == 0)
                return;
            VM = new DeliveryListVM(tdId);
            //pagerDelivery.OnNewPage += pagerDelivery_OnNewPage;
            //pagerDelivery.Init(VM.DeliveryTotleCount, PerPage);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            deliveryGrid.ItemsSource = VM.BindDeliveries;

            cbSelectAll.DataContext = VM;
        }

        #endregion

        #region Event

        private void pagerDelivery_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.DeliveryFrom = e.From;
            VM.DeliveryTo = e.To;
            VM.LoadDelivery();
            deliveryGrid.ItemsSource = VM.BindDeliveries;
            deliveryGrid.Items.Refresh();
        }

        private void DeliveryEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;

        }

        /// <summary>
        /// 编辑提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id > 0)
            {
                Delivery d = VM.GetDeliveryByIdWithOutFetch(id);
                bool isReexport = VM.IsReexport(d.Id);
                if (d != null)
                {
                    switch (d.DeliveryType)
                    {
                        case (int)DeliveryType.InternalTDBOL:
                            if (isReexport)
                            {
                                if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    var purchaseDeliveryAddView = new PurchaseDeliveryDetail(d.Id, PageMode.EditMode);
                                    RedirectTo(purchaseDeliveryAddView);
                                }
                            }
                            else
                            {
                                var purchaseDeliveryAddView = new PurchaseDeliveryDetail(d.Id, PageMode.EditMode);
                                RedirectTo(purchaseDeliveryAddView);
                            }
                            break;
                        case (int)DeliveryType.InternalTDWW:
                            if (isReexport)
                            {
                                if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    var purchaseQRAddView = new PurchaseWRDetail(d.Id, PageMode.EditMode);
                                    RedirectTo(purchaseQRAddView);
                                }
                            }
                            else
                            {
                                var purchaseQRAddView = new PurchaseWRDetail(d.Id, PageMode.EditMode);
                                RedirectTo(purchaseQRAddView);
                            }
                            break;
                        case (int)DeliveryType.ExternalTDBOL:
                            if (isReexport)
                            {
                                if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    //var importDeliveryAddView = new ImportDeliveryDetail(d.Id, PageMode.EditMode);
                                    var importDeliveryAddView = new NewImportDeliveryDetail(d.Id, PageMode.EditMode);
                                    RedirectTo(importDeliveryAddView);
                                }
                            }
                            else
                            {
                                //var importDeliveryAddView = new ImportDeliveryDetail(d.Id, PageMode.EditMode);
                                var importDeliveryAddView = new NewImportDeliveryDetail(d.Id, PageMode.EditMode);
                                RedirectTo(importDeliveryAddView);
                            }
                            break;
                        case (int)DeliveryType.ExternalTDWW:
                            if (isReexport)
                            {
                                if (MessageBox.Show(ResDelivery.ModifiedAlert, "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    //var importWRAddView = new ImportWRDetail(d.Id, PageMode.EditMode);
                                    var importWRAddView = new NewImportDeliveryDetail(d.Id, PageMode.EditMode);
                                    RedirectTo(importWRAddView);
                                }
                            }
                            else
                            {
                                //var importWRAddView = new ImportWRDetail(d.Id, PageMode.EditMode);
                                var importWRAddView = new NewImportDeliveryDetail(d.Id, PageMode.EditMode);
                                RedirectTo(importWRAddView);
                            }
                            break;
                        case (int)DeliveryType.InternalMDBOL:
                            var salesDeliveryView = new SalesDeliveryDetail(d.Id);
                            RedirectTo(salesDeliveryView);
                            break;
                        case (int)DeliveryType.InternalMDWW:
                            var salesWWView = new SalesDeliveryDetail(d.Id);
                            RedirectTo(salesWWView);
                            break;
                        case (int)DeliveryType.ExternalMDBOL:
                            var exportDeliveryView = new ExportDelivery(d.Id);
                            RedirectTo(exportDeliveryView);
                            break;
                        default:
                            var exportWRView = new ExportWRDetail(d.Id);
                            RedirectTo(exportWRView);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show(ResDelivery.DataException);
            }
        }

        /// <summary>
        /// 打印提单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryPrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id > 0)
            {
                Delivery d = VM.GetDeliveryById(id);
                if (d.DeliveryType != (int)DeliveryType.InternalMDBOL)
                {
                    MessageBox.Show(ResDelivery.PrintError);
                }
                else
                {
                    var printWarehouseOut = new PrintWarehouseOutTemplate(id, ModuleName, "发货单");
                    RedirectTo(printWarehouseOut);
                }
            }
        }
        private void DeliveryGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagerDelivery.CurPageNo - 1) * PerPage + e.Row.GetIndex() + 1;
        }

        private void DeliveryLineDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 作废提单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.Nullify, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteLineById(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
                deliveryGrid.ItemsSource = VM.BindDeliveries;
                deliveryGrid.Items.Refresh();
            }
        }

        private void ShowCirculDetailCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ShowCirculDetailExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var circulNo = e.Parameter as string;
            var win = new DeliveryListOfSameFlow(ModuleName, circulNo);
            win.Show();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.PrintSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void MDViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        //弹出发货单列表
        private void MDViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = (int)e.Parameter;
            ShowMDList(id);
        }

        private void ShowMDList(int id)
        {
            var search = new DeliveryList(ModuleName, id);
            RedirectTo(search);
        }

        private void ConvertWRCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 提单转仓单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertWRExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = (int)e.Parameter;
            string errorMsg;
            if (!VM.CanBeConvertTd2WR(id,out errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }
            ImportWRDetail frm = new ImportWRDetail(PageMode.AddMode,id);
            RedirectTo(frm);
        }
    }
}