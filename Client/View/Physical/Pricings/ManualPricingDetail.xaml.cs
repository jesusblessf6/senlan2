using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Pricings;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for ManualPricingDetail.xaml
    /// </summary>
    public sealed partial class ManualPricingDetail
    {
        #region Constructor

        public ManualPricingDetail(PageMode pageMode, int pricingId)
            : base(pageMode, Properties.Resources.Pricing)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new ManualPricingDetailVM(pricingId);

            if(pricingId > 0)
            {
                textBox1.IsEnabled = false;
                button1.IsEnabled = false;
                textBox2.IsEnabled = false;
                currencyTextBox1.IsEnabled = false;
                txPricedQuantity.IsEnabled = false;
                currencyTextBox4.IsEnabled = false;
                currencyTextBox5.IsEnabled = false;
                currencyTextBox6.IsEnabled = false;
                cbPricingCurrency.IsEnabled = false;
            }

            BindData();
        }

        public ManualPricingDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Pricing)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new ManualPricingDetailVM();
            BindData();
        }

        public ManualPricingDetail()
            : base(PageMode.ViewMode, Properties.Resources.Pricing)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new ManualPricingDetailVM();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            string condition = "it.Quota.PricingType = @p1 and it.UnpricingQuantity > 0 and (it.Quota.PricingStatus = @p2 or it.Quota.PricingStatus = @p3)";
            if (((ManualPricingDetailVM)VM).IdList != null && ((ManualPricingDetailVM)VM).IdList.Count > 0)
            {
                condition += string.Format(" and (");
                for (int j = 0; j < ((ManualPricingDetailVM)VM).IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        condition += string.Format(" it.Quota.Contract.InternalCustomerId = {0} ", ((ManualPricingDetailVM)VM).IdList[j]);
                    }
                    else
                    {
                        condition += string.Format(" or it.Quota.Contract.InternalCustomerId = {0}", ((ManualPricingDetailVM)VM).IdList[j]);
                    }
                }
                condition += string.Format(" )");
            }
            var parameters = new List<object> { (int)PricingType.Manual, (int)PricingStatus.NotAtAll, (int)PricingStatus.Partial };
            var dialog = PopDialogCreater.CreateDialog("Unpricing", condition, parameters);
            dialog.ShowDialog();
            var u = dialog.SelectedItem as Unpricing;
            if (u != null)
            {
                ((ManualPricingDetailVM) VM).UnpricingId = u.Id;
                ((ManualPricingDetailVM)VM).QuotaId = u.QuotaId;
            }
        }

        #endregion

        #region Method

        public override bool PageValidate()
        {
            if (Validation.GetErrors(txPricingQuantity).Count > 0)
            {
                throw new Exception(ResPricing.PricingQtyWrong);
            }

            if (Validation.GetErrors(currencyTextBox2).Count > 0)
            {
                throw new Exception(ResPricing.ReferencePricingWrong);
            }

            if (Validation.GetErrors(currencyTextBox6).Count > 0)
            {
                throw new Exception(ResPricing.FinalPricingWrong);
            }

            if (Validation.GetErrors(currencyTextBox3).Count > 0)
            {
                throw new Exception(ResPricing.SwitchFeeWrong);
            }

            if (Validation.GetErrors(currencyTextBox4).Count > 0)
            {
                throw new Exception(ResPricing.DeferFeeWrong);
            }

            if (Validation.GetErrors(currencyTextBox7).Count > 0)
            {
                throw new Exception(ResPricing.ExchangeRateWrong);
            }

            return true;
        }

        #endregion
    }
}
