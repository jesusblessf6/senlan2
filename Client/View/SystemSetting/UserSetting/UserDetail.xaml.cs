using Client.ViewModel.SystemSetting.UserSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.UserSetting
{
    /// <summary>
    /// Interaction logic for UserDetail.xaml
    /// </summary>
    public sealed partial class UserDetail
    {
        #region Constructor

        public UserDetail()
            : base(PageMode.ViewMode, Properties.Resources.User)
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            VM = new UserDetailVM();
            BindData();
        }

        public UserDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.User)
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            VM = new UserDetailVM();
            BindData();
        }

        public UserDetail(PageMode pageMode, int userId)
            : base(pageMode, Properties.Resources.User)
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            VM = new UserDetailVM(userId);
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