using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// PortDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PortDetail
    {
        #region Constructor

        public PortDetail()
            : base(PageMode.ViewMode, ResDataDictSetting.Port)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PortDetailVM();
            BindData();
        }

        public PortDetail(PageMode pageMode)
            : base(pageMode, ResDataDictSetting.Port)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PortDetailVM();
            BindData();
        }

        public PortDetail(PageMode pageMode, int portId)
            : base(pageMode, ResDataDictSetting.Port)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PortDetailVM(portId);
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