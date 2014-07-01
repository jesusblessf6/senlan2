using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Finance.LetterOfCredits;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Finance.LetterOfCredits
{
    /// <summary>
    /// LetterOfCreditHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LetterOfCreditHome
    {
        #region Property

        public LetterOfCreditHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public LetterOfCreditHome()
        {
            InitializeComponent();
            ModuleName = "LetterOfCreditSetting";
            VM = new LetterOfCreditHomeVM();
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

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            VM.Reset();
        }
        

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            VM.Load();
            var list = new LetterOfCreditList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateLCClick(object sender, RoutedEventArgs e)
        {
            var frm = new IssueLCDetail();
            RedirectTo(frm);
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreatePtClick(object sender, RoutedEventArgs e)
        {
            var frm = new PresentationDetail();
            RedirectTo(frm);
        }


        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentMonthDomesticClick(object sender, RoutedEventArgs e)
        {
            VM.LoadByDate();
            var list = new LetterOfCreditList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int) BusinessPartnerType.Customer,
                                            (int) BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.BeneficiaryId = bp.Id;
            VM.BeneficiaryName = bp.ShortName;
        }

        private void BtnInternalCustomerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int) BusinessPartnerType.Customer,
                                            (int) BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.ApplicantId = bp.Id;
            VM.ApplicantName = bp.ShortName;
        }

        #endregion
    }
}