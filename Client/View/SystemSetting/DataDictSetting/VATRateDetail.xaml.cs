using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// VATRateDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATRateDetail
    {
        #region Constructor

        public VATRateDetail()
            : base(PageMode.ViewMode, ResDataDictSetting.VAT)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new VATRateDetailVM();
            BindData();
        }

        public VATRateDetail(PageMode pageMode)
            : base(pageMode, ResDataDictSetting.VAT)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new VATRateDetailVM();
            BindData();
        }

        public VATRateDetail(PageMode pageMode, int vatrateId)
            : base(pageMode, ResDataDictSetting.VAT)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new VATRateDetailVM(vatrateId);
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