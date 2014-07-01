using Client.ViewModel.SystemSetting.ModuleSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.ModuleSetting
{
    /// <summary>
    /// Interaction logic for CategoryDetail.xaml
    /// </summary>
    public sealed partial class CategoryDetail
    {
        #region Constructor

        public CategoryDetail(PageMode pageMode)
            : base(pageMode, "模块分类")
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new CategoryDetailVM();
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