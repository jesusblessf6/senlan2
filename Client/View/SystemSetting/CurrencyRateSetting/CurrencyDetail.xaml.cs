using Client.ViewModel.SystemSetting.CurrencyRateSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CurrencyRateSetting
{
    /// <summary>
    /// Interaction logic for CurrencyDetail.xaml
    /// </summary>
    public sealed partial class CurrencyDetail
    {
        #region Constructor

        public CurrencyDetail()
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";
            VM = new CurrencyDetailVM();
            BindData();
        }

        public CurrencyDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.Currency)
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";
            VM = new CurrencyDetailVM();
            BindData();
        }

        public CurrencyDetail(int bankId, PageMode pageMode)
            : base(pageMode, Properties.Resources.Currency)
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";
            VM = new CurrencyDetailVM(bankId);

            if (bankId > 0)
            {
                cbIsSystem.IsEnabled = false;
            }

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