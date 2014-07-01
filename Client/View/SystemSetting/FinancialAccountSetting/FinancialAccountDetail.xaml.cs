using System.Windows;
using Client.View.PopUpDialog;
using DBEntity;
using Client.ViewModel.SystemSetting.FinancialAccountSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.FinancialAccountSetting
{
    /// <summary>
    /// FinancialAccountDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class FinancialAccountDetail
    {
        #region Property

        public FinancialAccount FinancialAccount { get; set; }

        #endregion

        #region Constructor

        public FinancialAccountDetail()
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            VM = new FinancialAccountDetailVM();
            BindData();
        }

        public FinancialAccountDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.FinancialAccount)
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            VM = new FinancialAccountDetailVM();
            BindData();
        }

        public FinancialAccountDetail(int moduleId, PageMode pageMode)
            : base(pageMode, Properties.Resources.FinancialAccount)
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            VM = new FinancialAccountDetailVM(moduleId);
            BindData();
        }

        public FinancialAccountDetail(int moduleId)
            : base(PageMode.ViewMode, Properties.Resources.FinancialAccount)
        {
            InitializeComponent();
            ModuleName = "FinancialAccountSetting";
            VM = new FinancialAccountDetailVM(moduleId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region PopUpdialog
        private void BtnParentClick(object sender, RoutedEventArgs e)
        {
            var dialog = new TreeViewDialog(true);
            dialog.ShowDialog();
            FinancialAccount = dialog.SelectedItems as FinancialAccount;
            if (FinancialAccount != null)
            {
                ((FinancialAccountDetailVM)VM).ParentId = FinancialAccount.Id;
                ((FinancialAccountDetailVM)VM).ParentName = FinancialAccount.Name;
            }
        }

        #endregion

    }
}
