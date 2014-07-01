using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// PaymentMeanDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentMeanDetail
    {
        #region Constructor

        public PaymentMeanDetail()
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new PaymentMeanDetailVM();
            BindData();
        }

        public PaymentMeanDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.PaymentMean)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new PaymentMeanDetailVM();
            BindData();
        }

        public PaymentMeanDetail(int paymentmenanId, PageMode pageMode)
            : base(pageMode, Properties.Resources.PaymentMean)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new PaymentMeanDetailVM(paymentmenanId);
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