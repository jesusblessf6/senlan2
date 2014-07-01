using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.ApprovalSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.ApprovalSetting
{
    /// <summary>
    /// Interaction logic for ApprovalDetail.xaml
    /// </summary>
    public sealed partial class ApprovalDetail
    {
        #region Constructor

        public ApprovalDetail() :
            base(PageMode.ViewMode, Properties.Resources.Approval)
        {
            InitializeComponent();
            ModuleName = "ApprovalSetting";
            VM = new ApprovalDetailVM();
            BindData();
        }

        public ApprovalDetail(PageMode pageMode) :
            base(pageMode, Properties.Resources.Approval)
        {
            InitializeComponent();
            ModuleName = "ApprovalSetting";
            VM = new ApprovalDetailVM();
            BindData();
        }

        public ApprovalDetail(PageMode pageMode, int approvalId) :
            base(pageMode, Properties.Resources.Approval)
        {
            InitializeComponent();
            ModuleName = "ApprovalSetting";
            VM = new ApprovalDetailVM(approvalId);

            if (approvalId > 0)
            {
                comboBox1.IsEnabled = false;
            }

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

        /// <summary>
        /// Refresh the datagrids
        /// </summary>
        public override void Refresh()
        {
            dataGrid1.Items.Refresh();
            dataGrid2.Items.Refresh();
        }

        #endregion

        #region Event

        /// <summary>
        /// Add Approval Stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var asd = new ApprovalStageDetail(((ApprovalDetailVM) VM).Stages);
            asd.Show();
            asd.Owner = this;
            asd.Owner.IsEnabled = false;
        }

        /// <summary>
        /// When the page is enable again, refresh it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalDetailIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((bool)e.OldValue == false && (bool)e.NewValue)
            {
                Refresh();
            }
        }

        /// <summary>
        /// whether able to delete stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StageDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// Delete approval stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StageDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            ((ApprovalDetailVM) VM).RemoveStage(id);
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = ((ApprovalDetailVM) VM).Stages;
            dataGrid1.Items.Refresh();
            e.Handled = true;
        }

        /// <summary>
        /// Add approval condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var acd = new ApprovalConditionDetail(((ApprovalDetailVM) VM).Conditions);
            acd.Show();
            acd.Owner = this;
            acd.Owner.IsEnabled = false;
        }

        /// <summary>
        /// set the line number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid2LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// whether able to delete approval condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConditionDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// delete approval condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConditionDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            ((ApprovalDetailVM) VM).RemoveCondition(id);
            dataGrid2.ItemsSource = null;
            dataGrid2.ItemsSource = ((ApprovalDetailVM) VM).Conditions;
            dataGrid2.Items.Refresh();
            e.Handled = true;
        }

        #endregion
    }
}