using Client.ViewModel.SystemSetting.RoleSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.RoleSetting
{
    /// <summary>
    /// Interaction logic for RoleDetail.xaml
    /// </summary>
    public sealed partial class RoleDetail
    {
        #region Constructor

        public RoleDetail(PageMode pageMode) : base(pageMode, Properties.Resources.Role)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";
            VM = new RoleDetailVM();

            BindData();
        }

        public RoleDetail()
            : base(PageMode.ViewMode, Properties.Resources.Role)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";
            VM = new RoleDetailVM();

            BindData();
        }

        public RoleDetail(int roleId)
            : base(PageMode.ViewMode, Properties.Resources.Role)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";
            VM = new RoleDetailVM(roleId);

            BindData();
        }

        public RoleDetail(int roleId, PageMode pageMode)
            : base(pageMode, Properties.Resources.Role)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";
            VM = new RoleDetailVM(roleId);

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