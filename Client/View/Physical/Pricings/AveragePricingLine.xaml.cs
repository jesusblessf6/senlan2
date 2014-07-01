using System;
using System.Windows;
using System.Windows.Controls;
using Client.ViewModel.Physical.Pricings;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// AveragePricingLine.xaml 的交互逻辑
    /// </summary>
    public sealed partial class AveragePricingLine
    {
        #region Members

        private const int AverageLinePerPage = 10;
        
        #endregion

        #region Property

        public AveragePricingLineVM APLVM { get; set; }

        #endregion

        #region Constructor

        public AveragePricingLine()
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            APLVM = new AveragePricingLineVM();
            BindData();
        }

        public AveragePricingLine(PageMode pageMode)
            : base(pageMode, ResPricing.AveragePricingDetail)
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            APLVM = new AveragePricingLineVM();
            BindData();
        }

        public AveragePricingLine(int moduleId, PageMode pageMode)
            : base(pageMode, ResPricing.AveragePricingDetail)
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            APLVM = new AveragePricingLineVM(moduleId);
            pagingControl1.OnNewPage += pagerAveragePricing_OnNewPage;
            pagingControl1.Init(APLVM.AveragePricingLineCount, AverageLinePerPage);

            BindData();
        }

        public AveragePricingLine(int moduleId)
            : base(PageMode.ViewMode, ResPricing.AveragePricingDetail)
        {
            InitializeComponent();
            ModuleName = "AveragePricing";
            APLVM = new AveragePricingLineVM(moduleId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = APLVM;
            if (APLVM.TradeTypeId == (int) TradeType.LongForeignTrade ||
                APLVM.TradeTypeId == (int) TradeType.ShortForeignTrade)
            {
                txtRate.Visibility = Visibility.Collapsed;
                labRateName.Visibility = Visibility.Collapsed;
            }
        }

        private void pagerAveragePricing_OnNewPage(object sender, PagingEventArgs e)
        {
            APLVM.PricingLineForm = e.From;
            APLVM.PricingLineTo = AverageLinePerPage; 
            APLVM.LoadAveragePricingLine();
            dataGrid1.ItemsSource = APLVM.AveragePricingLines2;
            dataGrid1.Items.Refresh();
        }

        protected override void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!APLVM.Verification())
                {
                    if (MessageBox.Show(ResPricing.PricingNotCompleteConfirm, ResPricing.ConfirmPriced, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        APLVM.Save();
                        MessageBox.Show(Properties.Resources.SaveSuccessfully);
                        var apsc = new AveragePricingSearchConditions();
                        RedirectTo(new AveragePricingList(apsc));

                        Close();
                    }
                }
                else
                {
                    APLVM.Save();
                    MessageBox.Show(Properties.Resources.SaveSuccessfully);
                    var apsc = new AveragePricingSearchConditions();
                    RedirectTo(new AveragePricingList(apsc));

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * AverageLinePerPage + e.Row.GetIndex() + 1;
        }

        #endregion
    }
}