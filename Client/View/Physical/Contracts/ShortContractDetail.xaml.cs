using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Client.View.Attachments;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Contracts;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Client.ContractServiceReference;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    ///     Interaction logic for ContractAdd.xaml
    /// </summary>
    public sealed partial class ShortContractDetail
    {
        #region Property

        public ContractType ContractType { get; set; }
        public TradeType TradeType { get; set; }
        public bool IsEdit { get; set; }
        public bool IsSpilt { get; set; }

        #endregion

        #region Constructor

        public ShortContractDetail(TradeType tradeType, ContractType contractType, PageMode pageMode, string pageName)
            : base(pageMode, pageName)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);

            TradeType = tradeType;
            ContractType = contractType;
            VM = new ShortContractDetailVM(tradeType, contractType);
            InitPage();
            BindData();
        }

        public ShortContractDetail(TradeType tradeType, ContractType contractType, int id, PageMode pageMode,
                                   string pageName)
            : base(pageMode, pageName)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            TradeType = tradeType;
            ContractType = contractType;
            IsEdit = true;
            VM = new ShortContractDetailVM(tradeType, contractType, id);
            InitPage();
            BindData();
        }

        public ShortContractDetail(TradeType tradeType, ContractType contractType, int id, PageMode pageMode,
                                  string pageName,bool isSplit)
            : base(pageMode, pageName)
        {
            InitializeComponent();
            IsSpilt = isSplit;
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            TradeType = tradeType;
            ContractType = contractType;
            IsEdit = true;
            VM = new ShortContractDetailVM(tradeType, contractType, id, isSplit);
            InitPage();
            BindData();
        }
        #endregion

        #region Method

        #region 外贸内贸布局

        /// <summary>
        ///     布局
        /// </summary>
        public void InitPage()
        {
            if (ContractType == ContractType.Purchase)
            {
                lbSupplier.Content = Properties.Resources.Supplier;
            }
            else if (ContractType == ContractType.Sales)
            {
                lbSupplier.Content = Properties.Resources.Buyer;
            }

            switch (TradeType)
            {
                case TradeType.ShortDomesticTrade:
                    SingleContractDomesticTradePage();
                    break;
                case TradeType.ShortForeignTrade:
                    SingleContractForeignTradePage();
                    break;
            }

            if (TradeType != TradeType.ShortDomesticTrade)
            {
                label1.Visibility = Visibility.Collapsed;
                button2.Visibility = Visibility.Collapsed;
                dataGrid1.Visibility = Visibility.Collapsed;
                lbVATInvoiceDate.Visibility = Visibility.Collapsed;
                datePicker2.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        ///     内贸短单
        /// </summary>
        private void SingleContractDomesticTradePage()
        {
            lbSettlementRate.Visibility = Visibility.Collapsed;
            txtSettlementRate.Visibility = Visibility.Collapsed;
            lbShipCondition.Visibility = Visibility.Collapsed;
            tbShipCondition.Visibility = Visibility.Collapsed;
            if (ContractType == ContractType.Sales)
            {
                lbRel.Visibility = Visibility.Collapsed;
                btnRel.Visibility = Visibility.Collapsed;
                dataGrid2.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        ///     进口/转口短单
        /// </summary>
        private void SingleContractForeignTradePage()
        {
            btnWarhouse.Visibility = Visibility.Collapsed;
            lbWarehouse.Visibility = Visibility.Collapsed;
            txtWarehouse.Visibility = Visibility.Collapsed;
            lbDeliveryDate.Visibility = Visibility.Collapsed;
            dpDeliveryDate.Visibility = Visibility.Collapsed;
            lbRel.Visibility = Visibility.Collapsed;
            btnRel.Visibility = Visibility.Collapsed;
            dataGrid2.Visibility = Visibility.Collapsed;
        }


        private void ShowWareHouse()
        {
            if (TradeType == TradeType.ShortDomesticTrade)
            {
                btnWarhouse.Visibility = Visibility.Visible;
                lbWarehouse.Visibility = Visibility.Visible;
                txtWarehouse.Visibility = Visibility.Visible;
                lbDeliveryDate.Visibility = Visibility.Visible;
                dpDeliveryDate.Visibility = Visibility.Visible;
            }
        }

        private void HideWareHouse()
        {
            btnWarhouse.Visibility = Visibility.Collapsed;
            lbWarehouse.Visibility = Visibility.Collapsed;
            txtWarehouse.Visibility = Visibility.Collapsed;
            lbDeliveryDate.Visibility = Visibility.Collapsed;
            dpDeliveryDate.Visibility = Visibility.Collapsed;
            ((ShortContractDetailVM) VM).WarehouseId = null;
            ((ShortContractDetailVM) VM).DeliveryDate = null;
        }

        #endregion

        #region 根据点价类型更改页面控件的显示情况

        //todo 改成VMproperty change
        private void CbxPricingTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ShortContractDetailVM) VM).SelectPricingType == (int) PricingType.Fixed)
            {
                //固定价点价
                FixedPricing();
                cbPricingCurrency.IsEnabled = true;
                lbPrice.Content = "价格";
                if (((ShortContractDetailVM) VM).LoadFlag != 1)
                {
                    ((ShortContractDetailVM) VM).SelectPricingCurrencyId = 0;
                    ((ShortContractDetailVM) VM).LoadRate();
                }
                ((ShortContractDetailVM) VM).PricingEndDate = null;
                ((ShortContractDetailVM) VM).PricingStartDate = null;
                ((ShortContractDetailVM) VM).SelectPricingBasis = 0;
            }
            else if (((ShortContractDetailVM) VM).SelectPricingType == (int) PricingType.Manual)
            {
                //手工点价
                //if (((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || ((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
                //{
                //    lbPrice.Content = "价格";
                //}
                //else
                //{
                    lbPrice.Content = "暂定价";
                //}
                ManualPricing();
                cbPricingCurrency.IsEnabled = false;
                if (((ShortContractDetailVM) VM).LoadFlag != 1)
                {
                    ((ShortContractDetailVM) VM).SelectPricingCurrencyId = 0;
                    ((ShortContractDetailVM) VM).SettlementRate = null;
                }
            }
            else if (((ShortContractDetailVM) VM).SelectPricingType == (int) PricingType.Average)
            {
                //平均价点价
                //if (((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || ((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
                //{
                //    lbPrice.Content = "价格";
                //}
                //else
                //{
                    lbPrice.Content = "暂定价";
                //}
                AveragePricing();
                cbPricingCurrency.IsEnabled = false;
                if (((ShortContractDetailVM) VM).LoadFlag != 1)
                {
                    ((ShortContractDetailVM) VM).SelectPricingCurrencyId = 0;
                    ((ShortContractDetailVM) VM).SettlementRate = null;
                }
            }
            ((ShortContractDetailVM) VM).SetCurrencyByPricingBasis();
            ((ShortContractDetailVM) VM).LoadFlag++;
            if (TradeType == TradeType.ShortDomesticTrade)
            {
                if (IsEdit)
                {
                    IsEdit = false;
                }
                else
                {
                    ((ShortContractDetailVM) VM).UpdateBrandRelByPricingType();
                    Refresh();
                }
            }
        }

        /// <summary>
        ///     固定价点价
        /// </summary>
        private void FixedPricing()
        {
            lbPrice.Visibility = Visibility.Visible;
            txtPrice.Visibility = Visibility.Visible;

            lbPricingStartDate.Visibility = Visibility.Collapsed;
            dpPricingStartDate.Visibility = Visibility.Collapsed;

            lbPricingEndDate.Visibility = Visibility.Collapsed;
            dpPricingEndDate.Visibility = Visibility.Collapsed;

            lbPricingSide.Visibility = Visibility.Collapsed;
            rbtPricingSideTheir.Visibility = Visibility.Collapsed;
            rbtPricingSideOwn.Visibility = Visibility.Collapsed;

            lbPricingBasis.Visibility = Visibility.Collapsed;
            cbxPricingBasis.Visibility = Visibility.Collapsed;

            lbPremium.Visibility = Visibility.Collapsed;
            txtPremium.Visibility = Visibility.Collapsed;

            //if (TradeType == TradeType.ShortDomesticTrade)
            //{
            //    //内贸短单
                lbSettlementRate.Visibility = Visibility.Visible;
                txtSettlementRate.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    lbSettlementRate.Visibility = Visibility.Collapsed;
            //    txtSettlementRate.Visibility = Visibility.Collapsed;
            //}
            ShowWareHouse();
        }

        /// <summary>
        ///     手工点价
        /// </summary>
        private void ManualPricing()
        {
            dpPricingStartDate.Visibility = Visibility.Visible;
            lbPricingStartDate.Visibility = Visibility.Visible;

            dpPricingEndDate.Visibility = Visibility.Visible;
            lbPricingEndDate.Visibility = Visibility.Visible;

            rbtPricingSideTheir.Visibility = Visibility.Visible;
            lbPricingSide.Visibility = Visibility.Visible;
            rbtPricingSideOwn.Visibility = Visibility.Visible;

            //if (((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || ((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
            //{
            //    txtPrice.Visibility = Visibility.Collapsed;
            //    lbPrice.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
                txtPrice.Visibility = Visibility.Visible;
                lbPrice.Visibility = Visibility.Visible;
            //}

            cbxPricingBasis.Visibility = Visibility.Visible;
            lbPricingBasis.Visibility = Visibility.Visible;
            lbPricingBasis.Foreground = Brushes.Crimson;

            txtPremium.Visibility = Visibility.Visible;
            lbPremium.Visibility = Visibility.Visible;
            lbPremium.Foreground = Brushes.Crimson;

            //cbPricingCurrency.IsEnabled = true;
            lbSettlementRate.Visibility = Visibility.Collapsed;
            txtSettlementRate.Visibility = Visibility.Collapsed;
            //HideWareHouse();
        }

        /// <summary>
        ///     平均价点价
        /// </summary>
        private void AveragePricing()
        {
            dpPricingStartDate.Visibility = Visibility.Visible;
            lbPricingStartDate.Visibility = Visibility.Visible;

            dpPricingEndDate.Visibility = Visibility.Visible;
            lbPricingEndDate.Visibility = Visibility.Visible;

            rbtPricingSideTheir.Visibility = Visibility.Collapsed;
            rbtPricingSideOwn.Visibility = Visibility.Collapsed;
            lbPricingSide.Visibility = Visibility.Collapsed;

            //if (((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || ((ShortContractDetailVM)VM).TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
            //{
            //    txtPrice.Visibility = Visibility.Collapsed;
            //    lbPrice.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
                txtPrice.Visibility = Visibility.Visible;
                lbPrice.Visibility = Visibility.Visible;
            //}

            cbxPricingBasis.Visibility = Visibility.Visible;
            lbPricingBasis.Visibility = Visibility.Visible;
            lbPricingBasis.Foreground = Brushes.Crimson;

            txtPremium.Visibility = Visibility.Visible;
            lbPremium.Visibility = Visibility.Visible;
            lbPremium.Foreground = Brushes.Crimson;

            //cbPricingCurrency.IsEnabled = true;

            lbSettlementRate.Visibility = Visibility.Collapsed;
            txtSettlementRate.Visibility = Visibility.Collapsed;
            //HideWareHouse();
        }

        #endregion

        /// <summary>
        ///     刷新附件列表
        /// </summary>
        public override void Refresh()
        {
            dataGridAttachment.ItemsSource = ((ShortContractDetailVM) VM).Attachments;
            dataGridAttachment.Items.Refresh();
        }

        public void RefreshBrands()
        {
            dataGrid1.ItemsSource =
                ((ShortContractDetailVM) VM).AllQuotaBrandRelList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
            ((ShortContractDetailVM) VM).UpdateQty();
            if (((ShortContractDetailVM) VM).SelectPricingType == (int) PricingType.Fixed)
            {
                ((ShortContractDetailVM) VM).UpdatePrice();
            }
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource =
                ((ShortContractDetailVM) VM).AllQuotaBrandRelList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
            dataGrid2.ItemsSource = ((ShortContractDetailVM)VM).RelQuotas;
            dataGrid2.Items.Refresh();
        }

        public override bool PageValidate()
        {
            if (Validation.GetErrors(txtPremium).Count > 0)
            {
                throw new Exception(ResContract.PremiumError);
            }

            return true;
        }

        protected override void Save(object sender, RoutedEventArgs e)
        {
            if (((ShortContractDetailVM)VM).IsPopupContraryDocumentNoEmptyInfo())
            {
                MessageBoxResult result = MessageBox.Show("关联公司间交易没有填写对手盘合同号，是否要继续？", "提示",
                                                                  MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                    return;
            }
            if (ContractType == DBEntity.EnumEntity.ContractType.Sales && (TradeType == DBEntity.EnumEntity.TradeType.LongDomesticTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortDomesticTrade))
            {
                if (((ShortContractDetailVM)VM).PayBankAccountId == null || ((ShortContractDetailVM)VM).PayBankAccountId <= 0)
                {
                    MessageBoxResult dr = MessageBox.Show("未选择银行账号，确定保存吗?", "提示", MessageBoxButton.OKCancel);
                    if (dr == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
            }
            base.Save(sender, e);
        }

        /// <summary>
        ///     After saving, go to the home page
        /// </summary>
        protected override void AfterSave()
        {
            MessageBox.Show(GetSuccessMessage());
            RedirectTo(new ContractHome(ContractType));
        }

        #endregion

        #region Event

        /// <summary>
        ///     供应商弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupplierClick(object sender, RoutedEventArgs e)
        {
            string queryStr = "it.CustomerType=" + (int) BusinessPartnerType.Customer + " or it.CustomerType=" +
                              (int) BusinessPartnerType.InternalCustomer;
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                ((ShortContractDetailVM) VM).SupplierId = bp.Id;
                ((ShortContractDetailVM) VM).SupplierName = bp.ShortName;
                ((ShortContractDetailVM) VM).Description = bp.Remark;
            }
        }

        private void CbxPricingBasisSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ShortContractDetailVM) VM).SetCurrencyByPricingBasis();
        }

        /// <summary>
        ///     仓库弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWarehouseClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var warehouse = dialog.SelectedItem as Warehouse;
            if (warehouse != null)
            {
                ((ShortContractDetailVM) VM).WarehouseId = warehouse.Id;
                ((ShortContractDetailVM) VM).WarehouseName = warehouse.Name;
            }
        }

        //todo move to VM's property change
        /// <summary>
        ///     联动金属
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxCommoditySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ShortContractDetailVM) VM).LoadCommodityType();
        }

        private void CboxCommodityTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ShortContractDetailVM) VM).LoadBrandAndSpecification();
        }

        /// <summary>
        ///     附件上传
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
                ((ShortContractDetailVM) VM).AddAttachment(attachment);
                Refresh();
            }
        }

        /// <summary>
        ///     附件是否可下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDownLoadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        ///     附件是否可删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        ///     下载附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            Attachment attachment = ((ShortContractDetailVM) VM).GetAttachmentById(id,
                                                                                   ((ShortContractDetailVM) VM)
                                                                                       .Attachments);
            if (attachment != null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        ///     删除附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteFileConfirm,
                                                      Properties.Resources.DeleteAttachment, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ((ShortContractDetailVM) VM).RemoveAttachment(id);
                Refresh();
            }
        }

        private void CbPricingCurrencySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ShortContractDetailVM) VM).LoadRate();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((ShortContractDetailVM) VM).ValidateBrands())
                {
                    var pd = new MoreDetail(((ShortContractDetailVM) VM).CommodityId,
                                            ((ShortContractDetailVM) VM).CommodityTypeId,
                                            ((ShortContractDetailVM) VM).AllQuotaBrandRelList,
                                            ((ShortContractDetailVM) VM).AddQuotaBrandRelList, PageMode.AddMode,
                                            ModuleName, ((ShortContractDetailVM) VM).SelectPricingType);
                    pd.ShowDialog();
                    RefreshBrands();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void QuotaBrandRelCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void QuotaBrandRelEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            var pd = new MoreDetail(id, ((ShortContractDetailVM) VM).CommodityId,
                                    ((ShortContractDetailVM) VM).CommodityTypeId,
                                    ((ShortContractDetailVM) VM).AllQuotaBrandRelList,
                                    ((ShortContractDetailVM) VM).AddQuotaBrandRelList,
                                    ((ShortContractDetailVM) VM).UpdateQuotaBrandRelList, PageMode.EditMode, ModuleName,
                                    ((ShortContractDetailVM) VM).SelectPricingType);
            pd.ShowDialog();
            RefreshBrands();
        }

        private void QuotaBrandRelDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 &&
                MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    ((ShortContractDetailVM) VM).DeleteQuotaBrandRel(id);
                    RefreshBrands();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        #endregion

        /// <summary>
        /// 关联交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var frm = new TransactionRelation();
            frm.ShowDialog();
            if (frm.VM.Rel != null && frm.VM.SaveStatus)
            {
                ((ShortContractDetailVM)VM).AddRelQuota(frm.VM.Rel);
                dataGrid2.ItemsSource = ((ShortContractDetailVM)VM).RelQuotas;
                dataGrid2.Items.Refresh();
            }
        }

        private void RelQuotaEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ShortContractDetailVM)VM).IsRelTransactionEditBtnEnable;
            e.Handled = true;
        }

        private void RelQuotaDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ShortContractDetailVM)VM).IsRelTransactionDeleteBtnEnable;
            e.Handled = true;
        }

        private void RelQuotaDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var id = (int)e.Parameter;
                if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Reminder,
                                        MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    if (((ShortContractDetailVM)VM).RelQuotaCanBeDelete(id))
                    {
                        ((ShortContractDetailVM)VM).DeleteRelQuota(id);
                        dataGrid2.ItemsSource = ((ShortContractDetailVM)VM).RelQuotas;
                        dataGrid2.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("关联交易必须从后向前删除！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }

        }

        private void RelQuotaEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            RelQuota rel = ((ShortContractDetailVM)VM).GetRelQuotaByStage(id);
            var frm = new TransactionRelation(rel);
            frm.ShowDialog();
            if (frm.VM.Rel != null && frm.VM.SaveStatus)
            {
                rel.Price = frm.VM.Rel.Price;
                rel.BusinessParnterId = frm.VM.Rel.BusinessParnterId;
                rel.BusinessParnterName = frm.VM.Rel.BusinessParnterName;
                rel.SignDate = frm.VM.Rel.SignDate;
                rel.VATInvoiceDate = frm.VM.Rel.VATInvoiceDate;

                dataGrid2.ItemsSource = ((ShortContractDetailVM)VM).RelQuotas;
                dataGrid2.Items.Refresh();
            }
        }

        /// <summary>
        /// 币种关联收付款账号下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxPayBPSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ShortContractDetailVM)VM).LoadPayBankAccounts();
        }
        
    }
}