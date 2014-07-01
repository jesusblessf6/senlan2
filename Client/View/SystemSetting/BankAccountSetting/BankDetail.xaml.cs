using Client.ViewModel.SystemSetting.BankAccountSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.BankAccountSetting
{
    /// <summary>
    /// Interaction logic for BankDetail.xaml
    /// </summary>
    public sealed partial class BankDetail
    {
        #region Constructor

        public BankDetail()
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankDetailVM();
            BindData();
        }

        public BankDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Bank)
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankDetailVM();
            BindData();
        }

        public BankDetail(int bankId, PageMode pageMode)
            : base(pageMode, Properties.Resources.Bank)
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankDetailVM(bankId);
            BindData();
        }

        #endregion

        #region Method

        /// <summary>
        /// Bind Data
        /// </summary>
        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}