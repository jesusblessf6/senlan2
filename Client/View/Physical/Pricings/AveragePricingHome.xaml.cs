using System;
using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Pricings;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for AveragePricingHome.xaml
    /// </summary>
    public sealed partial class AveragePricingHome
    {
        #region Property

        public AveragePricingHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public AveragePricingHome()
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            VM = new AveragePricingHomeVM();
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

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            const string condition = "it.CustomerType = @p1 or it.CustomerType = @p2";
            var parameters = new List<object>
                                 {(int) BusinessPartnerType.Customer, (int) BusinessPartnerType.InternalCustomer};
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", condition, parameters);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.BusinessPartnerId = bp.Id;
                VM.BusinessPartnerName = bp.ShortName;
            }
        }

        private void Button6Click(object sender, RoutedEventArgs e)
        {
            var search = new AveragePricingList(VM.BuildCondition());
            RedirectTo(search);
        }

        private void BtCompleteClick(object sender, RoutedEventArgs e)
        {
            var search =
                new AveragePricingList(VM.CompleteNotAtAllBuildCondition(Convert.ToInt32(PricingStatus.Complete)));
            RedirectTo(search);
        }

        private void BtNotAtAllClick(object sender, RoutedEventArgs e)
        {
            var search =
                new AveragePricingList(VM.CompleteNotAtAllBuildCondition(Convert.ToInt32(PricingStatus.NotAtAll)));
            RedirectTo(search);
        }

        private void BtThisMonthClick(object sender, RoutedEventArgs e)
        {
            var search = new AveragePricingList(VM.ThisMonthBuildCondition());
            RedirectTo(search);
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            VM.Clear();
        }

        #endregion
    }
}