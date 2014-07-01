using Client.ViewModel.SystemSetting.CommoditySetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CommoditySetting
{
    /// <summary>
    /// BrandDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class BrandDetail
    {
        #region Constructor

        public BrandDetail()
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new BrandDetailVM();
            BindData();
        }

        public BrandDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Brand)
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new BrandDetailVM();
            BindData();
        }

        public BrandDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.Brand)
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new BrandDetailVM(id);
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