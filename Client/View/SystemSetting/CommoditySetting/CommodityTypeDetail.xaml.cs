using Client.ViewModel.SystemSetting.CommoditySetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CommoditySetting
{
    /// <summary>
    /// CommodityTypeDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class CommodityTypeDetail
    {
        #region Constructor

        public CommodityTypeDetail()
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new CommodityTypeDetailVM();
            BindData();
        }

        public CommodityTypeDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.CommodityType)
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new CommodityTypeDetailVM();
            BindData();
        }

        public CommodityTypeDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.CommodityType)
        {
            InitializeComponent();
            if (id > 0 && pageMode == PageMode.EditMode) 
            {
                comboBox1.IsEnabled = false;
            }
            ModuleName = "CommoditySetting";
            VM = new CommodityTypeDetailVM(id);
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