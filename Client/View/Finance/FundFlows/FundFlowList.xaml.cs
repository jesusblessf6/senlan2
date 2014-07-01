using System.Collections.Generic;
using System.Windows.Input;
using Client.ViewModel.Finance.FundFlows;
using Utility.QueryManagement;

namespace Client.View.Finance.FundFlows
{
    /// <summary>
    ///     FundFlowList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class FundFlowList
    {
        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        public override int RecPerPage
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region Constructor

        public FundFlowList(List<QueryElement> cons)
            : base("FundFlowSetting")
        {
            InitializeComponent();
            VM = new FundFlowListVM(cons);
        }

        #endregion

        #region Event

        protected override void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            RedirectTo(((FundFlowListVM)VM).GetDetailPage(id));
        }

        #endregion
    }
}