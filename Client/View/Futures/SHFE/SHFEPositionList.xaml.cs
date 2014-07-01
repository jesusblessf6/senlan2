using System;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Futures.SHFE;
using DBEntity.EnumEntity;
using Utility.Controls;

namespace Client.View.Futures.SHFE
{
    /// <summary>
    /// Interaction logic for SHFEPositionList.xaml
    /// </summary>
    public sealed partial class SHFEPositionList
    {
        #region Property

        public SHFEPositionListVM VM { get; set; }
        private const int PositionPerPage = 20;

        #endregion
        public SHFEPositionList(int? brokerId, int? innerCustomerId, int? commodityId, DateTime? startTradeDate, DateTime? endTradeDate, DateTime? startPromptDate, DateTime? endPromptDate)
        {
            InitializeComponent();
            ModuleName = "SHFEPositionSetting";
            VM = new SHFEPositionListVM(brokerId, innerCustomerId, commodityId, startTradeDate, endTradeDate,
                                        startPromptDate, endPromptDate);
            pager.OnNewPage += pagerContract_OnNewPage;
            pager.Init(VM.PositionCount, PositionPerPage);
            BindData();
        }

        public SHFEPositionList()
        {
            InitializeComponent();
            ModuleName = "SHFEPositionSetting";
            VM=new SHFEPositionListVM();
        }

        public override void BindData()
        {
            dataGridPosition.ItemsSource = VM.Positions;
            dataGridPosition.Items.Refresh();
        }

        private void pagerContract_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PageFrom = e.From;
            VM.PageTo = e.To;
            VM.LoadPosition();
            dataGridPosition.ItemsSource = VM.Positions;
            dataGridPosition.Items.Refresh();
        }

        private void DataGridPositionLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pager.CurPageNo - 1) * PositionPerPage + e.Row.GetIndex() + 1;
        }

        private void PositionViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PositionViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            if(id>0)
            {
                RedirectTo(new SHFEPositionDetail(id,PageMode.ViewMode));
            }
        }
    }
}
