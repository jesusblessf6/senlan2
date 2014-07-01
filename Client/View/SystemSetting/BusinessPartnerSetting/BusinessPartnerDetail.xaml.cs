using System.Windows.Controls;
using Client.ViewModel.SystemSetting.BusinessPartnerSetting;
using DBEntity.EnumEntity;
using Utility.Controls;

namespace Client.View.SystemSetting.BusinessPartnerSetting
{
    /// <summary>
    /// Interaction logic for BusinessPartnerDetail.xaml
    /// </summary>
    public sealed partial class BusinessPartnerDetail
    {
        private const int BankPerPage = 5;

        #region Constructor

        public BusinessPartnerDetail(): 
            base(PageMode.ViewMode, Properties.Resources.BP)
        {
            InitializeComponent();
            ModuleName = "BusinessPartnerSetting";
            VM = new BusinessPartnerDetailVM();
            pgBankList.OnNewPage += pgBankList_OnNewPage;
            pgBankList.Init(((BusinessPartnerDetailVM)VM).BankTotalCount, BankPerPage);
            BindData();
        }

        public BusinessPartnerDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.BP)
        {
            InitializeComponent();
            ModuleName = "BusinessPartnerSetting";
            VM = new BusinessPartnerDetailVM();
            pgBankList.OnNewPage += pgBankList_OnNewPage;
            pgBankList.Init(((BusinessPartnerDetailVM)VM).BankTotalCount, BankPerPage);
            BindData();
        }

        public BusinessPartnerDetail(int id, PageMode pageMode)
            : base(pageMode, Properties.Resources.BP)
        {
            InitializeComponent();
            ModuleName = "BusinessPartnerSetting";
            VM = new BusinessPartnerDetailVM(id);
            pgBankList.OnNewPage += pgBankList_OnNewPage;
            pgBankList.Init(((BusinessPartnerDetailVM)VM).BankTotalCount, BankPerPage);
            BindData();
        }

        #endregion

        #region Method

        private void pgBankList_OnNewPage(object sender, PagingEventArgs e)
        {
            ((BusinessPartnerDetailVM)VM).BankForm = e.From;
            ((BusinessPartnerDetailVM)VM).BankTo = e.To;
            ((BusinessPartnerDetailVM)VM).SetBankAccounts(VM.ObjectId);
            dataGridBanks.ItemsSource = ((BusinessPartnerDetailVM)VM).BankAccounts;
            dataGridBanks.Items.Refresh();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pgBankList.CurPageNo - 1) * BankPerPage + e.Row.GetIndex() + 1;
        }

        #endregion
    }
}