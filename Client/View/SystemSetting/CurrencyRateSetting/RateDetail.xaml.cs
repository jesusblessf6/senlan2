using System;
using System.Windows.Controls;
using Client.ViewModel.SystemSetting.CurrencyRateSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CurrencyRateSetting
{
    /// <summary>
    /// Interaction logic for RateDetail.xaml
    /// </summary>
    public sealed partial class RateDetail
    {
        #region Constructor

        public RateDetail()
            : base(PageMode.ViewMode, Properties.Resources.ExchangeRate)
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";

            VM = new RateDetailVM();
            BindData();
        }

        public RateDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.ExchangeRate)
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";

            VM = new RateDetailVM();
            BindData();
        }

        public RateDetail(PageMode pageMode, int rateId)
            : base(pageMode, Properties.Resources.ExchangeRate)
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";

            VM = new RateDetailVM(rateId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        public override bool PageValidate()
        {
            if (Validation.GetErrors(textBox1).Count > 0)
            {
                throw new Exception(ResCurrencyRateSetting.ExchangeRateInputWrong);
            }

            return true;
        }

        #endregion
    }
}