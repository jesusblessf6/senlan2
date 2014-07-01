using DBEntity.EnumEntity;
using Client.ViewModel.SystemSetting.DataDictSetting;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// Interaction logic for DeliveryPersonDetail.xaml
    /// </summary>
    public sealed partial class DeliveryPersonDetail
    {
        #region Constructor

        public DeliveryPersonDetail() : base(PageMode.ViewMode, "提货人")
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new DeliveryPersonDetailVM();
            BindData();
        }

        public DeliveryPersonDetail(PageMode pageMode) : base(pageMode, "提货人")
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new DeliveryPersonDetailVM();
            BindData();
        }

        public DeliveryPersonDetail(PageMode pageMode, int id) : base(pageMode, "提货人")
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new DeliveryPersonDetailVM(id);
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
