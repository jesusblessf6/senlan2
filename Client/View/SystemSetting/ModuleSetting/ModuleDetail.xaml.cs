using System.Windows;
using Client.ViewModel.SystemSetting.ModuleSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.ModuleSetting
{
    /// <summary>
    /// Interaction logic for ModuleDetail.xaml
    /// </summary>
    public sealed partial class ModuleDetail
    {
        #region Constructor

        public ModuleDetail()
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModuleDetailVM();
            BindData();
        }

        public ModuleDetail(PageMode pageMode)
            : base(pageMode, "模块")
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModuleDetailVM();
            BindData();
        }

        public ModuleDetail(int moduleId, PageMode pageMode)
            : base(pageMode, "模块")
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModuleDetailVM(moduleId);
            BindData();
        }

        public ModuleDetail(int moduleId)
            : base(PageMode.ViewMode, "模块")
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModuleDetailVM(moduleId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        protected override void BaseWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (PageMode == PageMode.EditMode)
            {
                textBox5.IsEnabled = false;
            }
            base.BaseWindowLoaded(sender, e);
        }

        #endregion
    }
}