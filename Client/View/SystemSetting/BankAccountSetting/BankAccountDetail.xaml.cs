using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.SystemSetting.BankAccountSetting;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.BankAccountSetting
{
    /// <summary>
    /// Interaction logic for BankAccountDetail.xaml
    /// </summary>
    public sealed partial class BankAccountDetail
    {
        #region Constructor

        public BankAccountDetail()
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankAccountDetailVM();
            BindData();
        }

        public BankAccountDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.BankAccount)
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankAccountDetailVM();
            BindData();
        }

        public BankAccountDetail(PageMode pageMode, int accountId)
            : base(pageMode, Properties.Resources.BankAccount)
        {
            InitializeComponent();
            ModuleName = "BankAccountSetting";
            VM = new BankAccountDetailVM(accountId);
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

        #region 弹出框

        /// <summary>
        /// Pop window of bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchBankClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Bank");
            dialog.ShowDialog();
            var bank = dialog.SelectedItem as Bank;
            if (bank == null) return;
            ((BankAccountDetailVM) VM).SelectedBankId = bank.Id;
            ((BankAccountDetailVM) VM).BankName = bank.Name;
        }

        /// <summary>
        /// pop window of BP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            ((BankAccountDetailVM) VM).SelectedBPartnerId = bp.Id;
            ((BankAccountDetailVM) VM).BPartnerName = bp.ShortName;
        }

        #endregion
    }
}