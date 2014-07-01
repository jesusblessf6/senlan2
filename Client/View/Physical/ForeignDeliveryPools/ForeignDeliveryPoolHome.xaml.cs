using System.Windows;
using Client.ViewModel.Physical.ForeignDeliveryPools;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.View.Physical.ForeignDeliveryPools
{
    /// <summary>
    /// Interaction logic for ForeignDeliveryPoolHome.xaml
    /// </summary>
    public sealed partial class ForeignDeliveryPoolHome
    {
        #region Constructor

        public ForeignDeliveryPoolHome()
        {
            InitializeComponent();
            ModuleName = "ForeignDeliveryPool";
            VM = new ForeignDeliveryPoolHomeVM();
            BindData();
        }

        #endregion

        #region Method

        

        #endregion

        #region Event

        private void BtnCurrentMonthForeignClick(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(ForeignDeliveryPoolHomeVM.ForeignDeliveryPoolQueryType.CurrentMonth);
            var p = new ForeignDeliveryPoolList(cons);
            RedirectTo(p);
        }

        public override void Query(object sender, RoutedEventArgs e)
        {
            var cons = VM.GetQueryElements(ForeignDeliveryPoolHomeVM.ForeignDeliveryPoolQueryType.Free);
            var p = new ForeignDeliveryPoolList(cons);
            RedirectTo(p);
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var p = new ForeignDeliveryPoolDetail(PageMode.AddMode, EnumHelper.GetEnumItem<DeliveryType>((int)DeliveryType.ExternalTDBOL));
            RedirectTo(p);
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var p = new ForeignDeliveryPoolDetail(PageMode.AddMode, EnumHelper.GetEnumItem<DeliveryType>((int)DeliveryType.ExternalTDWW));
            RedirectTo(p);
        }

        #endregion
    }
}
