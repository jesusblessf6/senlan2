using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Pricings;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for PricingHome.xaml
    /// </summary>
    public sealed partial class PricingHome
    {
        #region Property

        public PricingHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public PricingHome()
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new PricingHomeVM();
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

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("Quota", "it.PricingType=@p1", new List<object>{(int)PricingType.Manual});
            dialog.ShowDialog();
            var quota = dialog.SelectedItem as Quota;
            if (quota != null)
            {
                VM.QuotaId = quota.Id;
                VM.QuotaNo = quota.QuotaNo;
            }
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.BPId = bp.Id;
                VM.BPName = bp.ShortName;
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
			try
			{
				var pd = new ManualPricingDetail(PageMode.AddMode);
				pd.Show();
			}
            catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            var cons = VM.BuildConditions();
            var pl = new ManualPricingList(cons);
            RedirectTo(pl);
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
			try
			{
				var pd = new PricingDefer(PageMode.AddMode);
				pd.Show();
			}
            catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }

        private void PartialPricingListCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PartialPricingListExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var cons = new ManualPricingSearchConditions {PricingStatusId = (int) PricingStatus.Partial};
            var mp = new ManualPricingList(cons);
            RedirectTo(mp);
            e.Handled = true;
        }

        private void CompletedPricingListCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

        private void CompletedPricingListExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var cons = new ManualPricingSearchConditions { PricingStatusId = (int)PricingStatus.Complete };
            var mp = new ManualPricingList(cons);
            RedirectTo(mp);
            e.Handled = true;
        }

        private void Button6Click(object sender, RoutedEventArgs e)
        {
            VM.Clear();
        }

        private void UnpricedPricingListCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void UnpricedPricingListExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var cons = new ManualPricingSearchConditions { PricingStatusId = (int)PricingStatus.NotAtAll };
            var mp = new ManualPricingList(cons);
            RedirectTo(mp);
            e.Handled = true;
        }

        #endregion

        
    }
}
