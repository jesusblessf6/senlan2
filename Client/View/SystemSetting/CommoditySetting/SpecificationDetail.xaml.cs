using Client.ViewModel.SystemSetting.CommoditySetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CommoditySetting
{
    /// <summary>
    /// SpecificationDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class SpecificationDetail
    {
        #region Constructor

        public SpecificationDetail()
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new SpecificationDetailVM();
            BindData();
        }

        public SpecificationDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Specification)
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new SpecificationDetailVM();
            BindData();
        }

        public SpecificationDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.Specification)
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new SpecificationDetailVM(id);
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