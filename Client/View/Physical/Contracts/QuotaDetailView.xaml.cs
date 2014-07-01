using System;
using System.Windows;
using System.Windows.Input;
using Client.View.Physical.Pricings;
using Client.ViewModel.Physical.Contracts;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    ///     Interaction logic for QuotaDetailView.xaml
    /// </summary>
    public sealed partial class QuotaDetailView
    {
        public QuotaDetailView(int id, ContractType contractType, PageMode pageMode)
            : base(pageMode, Properties.Resources.Quota)
        {
            InitializeComponent();
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);
            QDVM = new QuotaDetailViewVM(id);
            BindData();
        }

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = QDVM;
            dataGridQuotas.DataContext = QDVM.QuotaList;
            dataGridQuotas.Items.Refresh();
            deliveryGrid.DataContext = QDVM.DeliveryList;
            deliveryGrid.Items.Refresh();
            warehouseInGrid.DataContext = QDVM.WarehouseInList;
            warehouseInGrid.Items.Refresh();
            warehouseOutGrid.DataContext = QDVM.WarehouseOutList;
            warehouseOutGrid.Items.Refresh();
            dataGrid1.DataContext = QDVM.CommercialInvoiceList;
            dataGrid1.Items.Refresh();
            listGrid.DataContext = QDVM.LetterOfCreditList;
            listGrid.Items.Refresh();
            foundFlowListGrid.DataContext = QDVM.FundFlowList;
            foundFlowListGrid.Items.Refresh();
            vatListGrid.DataContext = QDVM.VATInvoiceLineList;
            vatListGrid.Items.Refresh();
            if (QDVM.WarehouseInVisible)
            {
                warehouseInGrid.Visibility = Visibility.Visible;
                warehouseOutGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                warehouseInGrid.Visibility = Visibility.Collapsed;
                warehouseOutGrid.Visibility = Visibility.Visible;
            }
        }

        #endregion

        public QuotaDetailViewVM QDVM { get; set; }

        /// <summary>
        ///     Can view pricings?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PricingViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        ///     View Pricings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PricingViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var pl = new PricingList(id);
            pl.ShowDialog();
            e.Handled = true;
        }

        private void ObjectBaseWindowClosed(object sender, EventArgs e)
        {
            Close();
        }

        private void ObjectBaseWindowLoaded(object sender, RoutedEventArgs e)
        {
            Title = "批次关联明细信息";
        }
    }
}