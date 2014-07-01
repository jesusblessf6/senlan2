using Client.ViewModel.Physical.Pricings;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for PricingList.xaml
    /// </summary>
    public sealed partial class PricingList
    {
        #region Property

        public PricingListVM VM { get; set; }

        #endregion

        #region Constructor

        public PricingList(int id)
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new PricingListVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}
