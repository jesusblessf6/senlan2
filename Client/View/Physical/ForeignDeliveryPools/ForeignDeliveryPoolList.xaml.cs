using System.Collections.Generic;
using System.Windows.Input;
using Client.ViewModel.Physical.ForeignDeliveryPools;
using DBEntity.EnumEntity;
using Utility.QueryManagement;

namespace Client.View.Physical.ForeignDeliveryPools
{
    /// <summary>
    /// Interaction logic for ForeignDeliveryPoolList.xaml
    /// </summary>
    public sealed partial class ForeignDeliveryPoolList
    {
        #region Properties

        public override int RecPerPage
        {
            get
            {
                return 5;
            }
        }

        #endregion

        #region Constructor

        public ForeignDeliveryPoolList(List<QueryElement> cons)
            :base("ForeignDeliveryPool")
        {
            InitializeComponent();
            VM = new ForeignDeliveryListVM(cons);
        }

        #endregion

        #region Event

        protected override void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var deliveryType = ((ForeignDeliveryListVM) VM).GetDeliveryType(id);
            var p = new ForeignDeliveryPoolDetail(PageMode.EditMode, deliveryType, id);
            RedirectTo(p);
        }

        #endregion
    }
}
