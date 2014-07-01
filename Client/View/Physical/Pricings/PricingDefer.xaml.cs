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
    /// Interaction logic for PricingDefer.xaml
    /// </summary>
    public sealed partial class PricingDefer
    {
        #region Constructor

        public PricingDefer(PageMode pageMode)
            : base(pageMode, ResPricing.PricingDefer)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new PricingDeferVM();
            BindData();
        }

        public PricingDefer()
            : base(PageMode.ViewMode, ResPricing.PricingDefer)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new PricingDeferVM();
            BindData();
        }

        public PricingDefer(PageMode pageMode, int unpricingId)
            : base(pageMode, ResPricing.PricingDefer)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new PricingDeferVM(unpricingId);

            if(unpricingId > 0)
            {
                button1.IsEnabled = false;
            }

            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        public override bool PageValidate()
        {
            if(Validation.GetErrors(currencyTextBox2).Count > 0)
            {
                throw new Exception(ResPricing.DeferQtyError);
            }

            if(Validation.GetErrors(currencyTextBox3).Count > 0)
            {
                throw new Exception(ResPricing.DeferFeeError);
            }

            return true;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            string condition = "it.Quota.PricingType = @p1 and it.UnpricingQuantity > 0 and (it.Quota.PricingStatus = @p2 or it.Quota.PricingStatus = @p3)";
            if (((PricingDeferVM)VM).IdList != null && ((PricingDeferVM)VM).IdList.Count > 0)
            {
                condition += string.Format(" and (");
                for (int j = 0; j < ((PricingDeferVM)VM).IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        condition += string.Format(" it.Quota.Contract.InternalCustomerId = {0} ", ((PricingDeferVM)VM).IdList[j]);
                    }
                    else
                    {
                        condition += string.Format(" or it.Quota.Contract.InternalCustomerId = {0}", ((PricingDeferVM)VM).IdList[j]);
                    }
                }
                condition += string.Format(" )");
            }
            var parameters = new List<object>{(int)PricingType.Manual, (int) PricingStatus.NotAtAll, (int) PricingStatus.Partial};
            var dialog = PopDialogCreater.CreateDialog("Unpricing", condition, parameters);
            dialog.ShowDialog();
            var unpricing = dialog.SelectedItem as Unpricing;
            if (unpricing != null) 
                ((PricingDeferVM)VM).ParentUnpricingId = unpricing.Id;
        }

        #endregion
    }
}
