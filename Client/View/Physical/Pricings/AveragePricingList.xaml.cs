using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Physical.Pricings;
using DBEntity.EnumEntity;
using Utility.Controls;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for AveragePricingList.xaml
    /// </summary>
    public sealed partial class AveragePricingList
    {
        #region Properties

        private const int AveragePricingPerPage = 10;
        public AveragePricingListVM VM { get; set; }

        #endregion

        #region Constructor

        public AveragePricingList(AveragePricingSearchConditions c)
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            VM = new AveragePricingListVM(c);
            pagingControl1.OnNewPage += pagerAveragePricing_OnNewPage;
            pagingControl1.Init(VM.QuotasTotleCount, AveragePricingPerPage);

            BindData();
        }

        public AveragePricingList()
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            VM = new AveragePricingListVM(null);
            pagingControl1.OnNewPage += pagerAveragePricing_OnNewPage;
            pagingControl1.Init(VM.QuotasTotleCount, AveragePricingPerPage);

            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void pagerAveragePricing_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.QuotaFrom = e.From;
            VM.QuotaTo = e.To;
            VM.LoadQuotas();
            dataGrid1.ItemsSource = VM.Quotas;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void UnPricingExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int moduleId = e.Parameter is int ? (int) e.Parameter : 0;
            var md = new AveragePricingLine(moduleId, PageMode.EditMode);
            md.Show();
            e.Handled = true;
        }

        private void UnPricingCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * AveragePricingPerPage + e.Row.GetIndex() + 1;
        }

        #endregion
    }
}