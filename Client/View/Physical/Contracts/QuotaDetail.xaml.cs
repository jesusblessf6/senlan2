using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Contracts;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for ContractQuotaAdd.xaml
    /// </summary>
    public sealed partial class QuotaDetail
    {
        #region Property

        public ContractType ContractType { get; set; }
        public TradeType TradeType { get; set; }

        #endregion

        #region Constructor

        public QuotaDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tradeType"></param>
        /// <param name="contractType"></param>
        /// <param name="pageMode"></param>
        /// <param name="contractDetailVM"> </param>
        public QuotaDetail(int id, TradeType tradeType, ContractType contractType, PageMode pageMode, LongContractDetailVM contractDetailVM)
            : base(pageMode, Properties.Resources.Quota)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            TradeType = tradeType;
            ContractType = contractType;
            InitPage();
            VM = new QuotaDetailVM(id, tradeType, contractDetailVM.Quotas, contractDetailVM.AddQuotas, contractDetailVM.UpdateQuotas, contractType, contractDetailVM.SupplierId);
            BindData();
        }

        /// <summary>
        /// 新增用
        /// </summary>
        /// <param name="tradeType"></param>
        /// <param name="contractType"></param>
        /// <param name="pageMode"></param>
        /// <param name="contractDetailVM"> </param>
        public QuotaDetail(TradeType tradeType, ContractType contractType, PageMode pageMode, LongContractDetailVM contractDetailVM)
            : base(pageMode, Properties.Resources.Quota)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            TradeType = tradeType;
            ContractType = contractType;
            InitPage();
            VM = contractDetailVM.SignDate == null
                     ? new QuotaDetailVM(tradeType, contractType, contractDetailVM.SupplierId)
                     : new QuotaDetailVM(tradeType, contractDetailVM.SignDate.Value, contractType, contractDetailVM.SupplierId);
            
            ((QuotaDetailVM)VM).AddedQuotas = contractDetailVM.AddQuotas;
            ((QuotaDetailVM)VM).Quotas = contractDetailVM.Quotas;
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void InitPage()
        {
            if (TradeType == TradeType.LongDomesticTrade)
            {
                //内贸长单
                if (ContractType == ContractType.Purchase)
                {
                    lbTitle.Content = ResContract.DomesticPurchaseQuota;
                }
                else if (ContractType == ContractType.Sales)
                {
                    lbTitle.Content = ResContract.DomesticSalesQuota;
                }
                lbWarehouse.Visibility = Visibility.Visible;
                txtWarehouse.Visibility = Visibility.Visible;
                btnWarehouse.Visibility = Visibility.Visible;
                lbDeliveryDate.Visibility = Visibility.Visible;
                dpDeliveryDate.Visibility = Visibility.Visible;
                lbShipCondition.Visibility = Visibility.Collapsed;
                tbShipCondition.Visibility = Visibility.Collapsed;
            }
            else if (TradeType == TradeType.LongForeignTrade)
            {
                //外贸长单
                if (ContractType == ContractType.Purchase)
                {
                    lbTitle.Content = ResContract.ForeignPurchaseQuota;
                }
                else if (ContractType == ContractType.Sales)
                {
                    lbTitle.Content = ResContract.ForeignSalesQuota;
                }
                lbWarehouse.Visibility = Visibility.Collapsed;
                txtWarehouse.Visibility = Visibility.Collapsed;
                btnWarehouse.Visibility = Visibility.Collapsed;
                lbDeliveryDate.Visibility = Visibility.Collapsed;
                dpDeliveryDate.Visibility = Visibility.Collapsed;
                lbVATInvoiceDate.Visibility = Visibility.Collapsed;
                datePicker2.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowWareHouse()
        {
            if (TradeType == TradeType.LongDomesticTrade)
            {
                btnWarehouse.Visibility = Visibility.Visible;
                lbWarehouse.Visibility = Visibility.Visible;
                txtWarehouse.Visibility = Visibility.Visible;
                lbDeliveryDate.Visibility = Visibility.Visible;
                dpDeliveryDate.Visibility = Visibility.Visible;
            }
        }

        private void HideWareHouse()
        {
            btnWarehouse.Visibility = Visibility.Collapsed;
            lbWarehouse.Visibility = Visibility.Collapsed;
            txtWarehouse.Visibility = Visibility.Collapsed;
            lbDeliveryDate.Visibility = Visibility.Collapsed;
            dpDeliveryDate.Visibility = Visibility.Collapsed;
            ((QuotaDetailVM)VM).WarehouseId = null;
            ((QuotaDetailVM)VM).DeliveryDate = null;
        }

        /// <summary>
        /// 固定价点价
        /// </summary>
        private void FixedPricing()
        {
            lbPrice.Foreground = Brushes.Crimson;
            lbPrice.Visibility = Visibility.Visible;
            txtPrice.Visibility = Visibility.Visible;
            dpPricingStartDate.Visibility = Visibility.Collapsed;
            dpPricingEndDate.Visibility = Visibility.Collapsed;
            rbtPricingSideTheir.Visibility = Visibility.Collapsed;
            rbtPricingSideOwn.Visibility = Visibility.Collapsed;
            if (TradeType == TradeType.LongDomesticTrade)
            {
                //内贸长单
                txtWarehouse.Visibility = Visibility.Visible;
                btnWarehouse.Visibility = Visibility.Visible;
                lbWarehouse.Visibility = Visibility.Visible;

                dpDeliveryDate.Visibility = Visibility.Visible;
                lbDeliveryDate.Visibility = Visibility.Visible;
                lbSettlementRate.Visibility = Visibility.Visible;
                txtSettlementRate.Visibility = Visibility.Visible;
            }
            else
            {
                //外贸长单
                lbSettlementRate.Visibility = Visibility.Visible;
                txtSettlementRate.Visibility = Visibility.Visible;
            }
            cbxPricingBasis.Visibility = Visibility.Collapsed;
            txtPremium.Visibility = Visibility.Collapsed;

            lbPricingStartDate.Visibility = Visibility.Collapsed;
            lbPricingEndDate.Visibility = Visibility.Collapsed;
            lbPricingSide.Visibility = Visibility.Collapsed;
            lbPricingBasis.Visibility = Visibility.Collapsed;
            lbPremium.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 手工点价
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
            //if (TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
            //{
            //    txtPrice.Visibility = Visibility.Collapsed;
            //    lbPrice.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
                txtPrice.Visibility = Visibility.Visible;
                lbPrice.Visibility = Visibility.Visible;
            //}
            lbPrice.Foreground = Brushes.Crimson;
            cbxPricingBasis.Visibility = Visibility.Visible;
            lbPricingBasis.Visibility = Visibility.Visible;
            txtPremium.Visibility = Visibility.Visible;
            lbPremium.Visibility = Visibility.Visible;
            lbPremium.Foreground = Brushes.Black;
            lbSettlementRate.Visibility = Visibility.Collapsed;
            txtSettlementRate.Visibility = Visibility.Collapsed;
            if (TradeType == TradeType.LongDomesticTrade)
            {
                //内贸长单
                //txtWarehouse.Visibility = Visibility.Collapsed;
                //btnWarehouse.Visibility = Visibility.Collapsed;
                //lbWarehouse.Visibility = Visibility.Collapsed;

                dpDeliveryDate.Visibility = Visibility.Collapsed;
                lbDeliveryDate.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 平均价点价
        /// </summary>
        private void AveragePricing()
        {
            dpPricingStartDate.Visibility = Visibility.Visible;
            dpPricingEndDate.Visibility = Visibility.Visible;
            rbtPricingSideTheir.Visibility = Visibility.Collapsed;
            rbtPricingSideOwn.Visibility = Visibility.Collapsed;

            lbPricingStartDate.Visibility = Visibility.Visible;
            lbPricingEndDate.Visibility = Visibility.Visible;
            lbPricingSide.Visibility = Visibility.Collapsed;

            //if (TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
            //{
            //    txtPrice.Visibility = Visibility.Collapsed;
            //    lbPrice.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
                txtPrice.Visibility = Visibility.Visible;
                lbPrice.Visibility = Visibility.Visible;
            //}
            //txtPrice.Visibility = Visibility.Visible;
            cbxPricingBasis.Visibility = Visibility.Visible;
            txtPremium.Visibility = Visibility.Visible;

            lbPrice.Foreground = Brushes.Crimson;
            //lbPrice.Visibility = Visibility.Visible;
            lbPricingBasis.Visibility = Visibility.Visible;
            lbPremium.Visibility = Visibility.Visible;
            lbPremium.Foreground = Brushes.Crimson;
            lbSettlementRate.Visibility = Visibility.Collapsed;
            txtSettlementRate.Visibility = Visibility.Collapsed;
            if (TradeType == TradeType.LongDomesticTrade)
            {
                //内贸长单
                //txtWarehouse.Visibility = Visibility.Collapsed;
                //btnWarehouse.Visibility = Visibility.Collapsed;
                //lbWarehouse.Visibility = Visibility.Collapsed;

                dpDeliveryDate.Visibility = Visibility.Collapsed;
                lbDeliveryDate.Visibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Event

        //private void CbPricingCurrencySelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ((QuotaDetailVM) VM).LoadRate();
        //}

        private void CbCommoditySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((QuotaDetailVM) VM).LoadCommodityType();
        }

        private void CbCmmodityTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((QuotaDetailVM) VM).LoadBrandAndSpecification();
        }

        private void CbPricingTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((QuotaDetailVM)VM).SelectPricingType == (int)PricingType.Fixed)
            {
                //固定价点价
                lbPrice.Content = "价格";
                FixedPricing();
                lbPricingStartDate.Foreground = Brushes.Black;
                lbPricingEndDate.Foreground = Brushes.Black;
                cbxPricingCurrency.IsEnabled = true;
                ShowWareHouse();
            }
            else if (((QuotaDetailVM)VM).SelectPricingType == (int)PricingType.Manual)
            {
                //手工点价
                //if (TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
                //{
                //    lbPrice.Content = "价格";
                //}
                //else
                //{
                    lbPrice.Content = "暂定价";
                //}
                ManualPricing();
                lbPricingStartDate.Foreground = Brushes.Crimson;
                lbPricingEndDate.Foreground = Brushes.Crimson;
                lbPremium.Foreground = Brushes.Crimson;
                cbxPricingCurrency.IsEnabled = false;
                ((QuotaDetailVM)VM).SelectPricingCurrencyId = 0;
                ((QuotaDetailVM)VM).SettlementRate = null;
                //HideWareHouse();
            }
            else if (((QuotaDetailVM)VM).SelectPricingType == (int)PricingType.Average)
            {
                //平均价点价
                //if (TradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade)
                //{
                //    lbPrice.Content = "价格";
                //}
                //else
                //{
                    lbPrice.Content = "暂定价";
                //}
                AveragePricing();
                //lbPricingBasis.Foreground = Brushes.Crimson;
                lbPricingStartDate.Foreground = Brushes.Crimson;
                lbPricingEndDate.Foreground = Brushes.Crimson;
                lbPremium.Foreground = Brushes.Crimson;
                cbxPricingCurrency.IsEnabled = false;
                ((QuotaDetailVM)VM).SelectPricingCurrencyId = 0;
                ((QuotaDetailVM)VM).SettlementRate = null;
               //HideWareHouse();
            }
            ((QuotaDetailVM)VM).SetCurrencyByPricingBasis();
        }

        private void BtnWarhouseClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var warehouse = dialog.SelectedItem as Warehouse;
            if (warehouse != null)
            {
                ((QuotaDetailVM)VM).WarehouseId = warehouse.Id;
                ((QuotaDetailVM)VM).WarehouseName = warehouse.Name;
            }
        }

        public override bool PageValidate()
        {
            if (Validation.GetErrors(txtPrice).Count > 0)
            {
                throw new Exception(ResContract.PriceError);
            }
            return true;
        }

        private void CbxPricingBasisSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((QuotaDetailVM)VM).SetCurrencyByPricingBasis();
        }

        private void BtCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void Save(object sender, RoutedEventArgs e)
        {
            if (((QuotaDetailVM)VM).IsPopupContraryDocumentNoEmptyInfo())
            {
                MessageBoxResult result = MessageBox.Show("关联公司间交易没有填写对手盘批次号，是否要继续？", "提示",
                                                                  MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                    return;
            }
            base.Save(sender, e);
        }

        #endregion
    }
}