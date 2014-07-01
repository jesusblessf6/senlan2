using System;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Futures.HedgeGroups;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Futures.HedgeGroups
{
    /// <summary>
    /// Interaction logic for HedgeGroupDetail.xaml
    /// </summary>
    public sealed partial class HedgeGroupDetail
    {
        #region Property

        private const int RecPerPage = 5;
        
        #endregion

        #region Constructor

        public HedgeGroupDetail(PageMode pageMode)
            :base(pageMode, Properties.Resources.HedgeGroup)
        {
            InitializeComponent();
            ModuleName = "HedgeGroup";
            VM = new HedgeGroupDetailVM();
            BindData();

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(0, RecPerPage);
            pagingControl2.OnNewPage += PagingControl2OnOnNewPage;
            pagingControl2.Init(0, RecPerPage);
            pagingControl22.OnNewPage += PagingControl22OnOnNewPage;
            pagingControl22.Init(0, RecPerPage);
        }

        public HedgeGroupDetail(PageMode pageMode, int id)
            : base(pageMode, Properties.Resources.HedgeGroup)
        {
            InitializeComponent();
            ModuleName = "HedgeGroup";
            VM = new HedgeGroupDetailVM(id);
            BindData();

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(0, RecPerPage);
            pagingControl2.OnNewPage += PagingControl2OnOnNewPage;
            pagingControl2.Init(0, RecPerPage);
            pagingControl22.OnNewPage += PagingControl22OnOnNewPage;
            pagingControl22.Init(0, RecPerPage);
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
        /// Reset quota conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).ResetQuotaConditions();
        }

        /// <summary>
        /// Reset LME Position conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).ResetLMEPositionConditions();
        }

        /// <summary>
        /// Reset SHFE Positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button27Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).ResetSHFEPositionConditions();
        }

        /// <summary>
        /// Query for Quotas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).LoadQuotaCount();
            pagingControl1.Init(((HedgeGroupDetailVM)VM).QuotaCount, RecPerPage);
        }

        /// <summary>
        /// Query for LME positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM) VM).LoadLMEPositionCount();
            pagingControl2.Init(((HedgeGroupDetailVM)VM).LMEPositionCount, RecPerPage);
        }

        /// <summary>
        /// Query for SHFE positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button26Click(object sender, RoutedEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).LoadSHFEPositionCount();
            pagingControl22.Init(((HedgeGroupDetailVM)VM).SHFEPositionCount, RecPerPage);
        }

        /// <summary>
        /// new page handler for quotas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        {
            ((HedgeGroupDetailVM) VM).QuotaFrom = e.From;
            ((HedgeGroupDetailVM) VM).QuotaTo = e.To;
            ((HedgeGroupDetailVM) VM).LoadQuotas();
            dataGrid4.ItemsSource = ((HedgeGroupDetailVM) VM).Quotas;
            dataGrid4.Items.Refresh();
        }

        /// <summary>
        /// new page handler for LME positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> </param>
        private void PagingControl2OnOnNewPage(object sender, PagingEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).LMEPositionFrom = e.From;
            ((HedgeGroupDetailVM)VM).LMEPositionTo = e.To;
            ((HedgeGroupDetailVM)VM).LoadLMEPositions();
            dataGrid5.ItemsSource = ((HedgeGroupDetailVM)VM).LMEPositions;
            dataGrid5.Items.Refresh();
        }

        /// <summary>
        /// new page handler for SHFE positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagingControl22OnOnNewPage(object sender, PagingEventArgs e)
        {
            ((HedgeGroupDetailVM)VM).SHFEPositionFrom = e.From;
            ((HedgeGroupDetailVM)VM).SHFEPositionTo = e.To;
            ((HedgeGroupDetailVM)VM).LoadSHFEPositions();
            dataGrid25.ItemsSource = ((HedgeGroupDetailVM)VM).SHFEPositions;
            dataGrid25.Items.Refresh();
        }

        /// <summary>
        /// When expand the expander, collapse the other two
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander1Expanded(object sender, RoutedEventArgs e)
        {
            expander2.IsExpanded = false;
            expander3.IsExpanded = false;
        }

        /// <summary>
        /// When expand the expander, collapse the other two
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander2Expanded(object sender, RoutedEventArgs e)
        {
            expander1.IsExpanded = false;
            expander3.IsExpanded = false;
        }

        /// <summary>
        /// When expand the expander, collapse the other two
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander3Expanded(object sender, RoutedEventArgs e)
        {
            expander1.IsExpanded = false;
            expander2.IsExpanded = false;
        }

        /// <summary>
        /// Popup window of business partner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var pop = PopDialogCreater.CreateDialog("BusinessPartner");
            pop.ShowDialog();
            var bp = (BusinessPartner)pop.SelectedItem;
            if(bp != null)
            {
                ((HedgeGroupDetailVM) VM).QuotaBPId = bp.Id;
                ((HedgeGroupDetailVM) VM).QuotaBPName = bp.ShortName;
            }
        }

        protected override void SetItemStatusByPageMode()
        {
            if(PageMode == PageMode.ViewMode)
            {
                textBox1.IsEnabled = false;
                datePicker1.IsEnabled = false;
                currencyTextBox1.IsEnabled = false;
                leftGrid.IsEnabled = false;
                rightGrid.Visibility = Visibility.Collapsed;
                comboBox9.IsEnabled = false;
            }
            else
            {
                button8.Visibility = Visibility.Collapsed;
                label19.Visibility = Visibility.Collapsed; 
                label20.Visibility = Visibility.Collapsed;
                label25.Visibility = Visibility.Collapsed;
                label26.Visibility = Visibility.Collapsed;
                label28.Visibility = Visibility.Collapsed;
                label29.Visibility = Visibility.Collapsed;
                label30.Visibility = Visibility.Collapsed;
                label31.Visibility = Visibility.Collapsed;
            }
        }

        private void Button8Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((HedgeGroupDetailVM)VM).CalculatePL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        #region Command
        private void RemoveAddedQuotaCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void RemoveAddedLMEPositionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void RemoveAddedSHFEPositionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AddQuotaCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AddLMEPositionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void AddSHFEPositionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void RemoveAddedQuotaExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var quotaId = (int)e.Parameter;
                ((HedgeGroupDetailVM)VM).RemoveAddedQuota(quotaId);
                dataGrid1.ItemsSource = ((HedgeGroupDetailVM)VM).AddedQuotas;
                dataGrid1.Items.Refresh();
                dataGrid4.Items.Refresh();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void RemoveAddedLMEPositionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var lmePositionId = (int)e.Parameter;
                ((HedgeGroupDetailVM)VM).RemoveAddedLMEPosition(lmePositionId);
                dataGrid2.ItemsSource = ((HedgeGroupDetailVM)VM).AddedLMEPositions;
                dataGrid2.Items.Refresh();
                dataGrid5.Items.Refresh();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void RemoveAddedSHFEPositionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var shfePositionId = (int)e.Parameter;
                ((HedgeGroupDetailVM)VM).RemoveAddedSHFEPosition(shfePositionId);
                dataGrid3.ItemsSource = ((HedgeGroupDetailVM)VM).AddedSHFEPositions;
                dataGrid3.Items.Refresh();
                dataGrid25.Items.Refresh();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void AddQuotaExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var quotaId = (int)e.Parameter;
                ((HedgeGroupDetailVM)VM).AddQuota(quotaId);
                dataGrid1.ItemsSource = ((HedgeGroupDetailVM)VM).AddedQuotas;
                dataGrid1.Items.Refresh();
                dataGrid4.ItemsSource = null;
                dataGrid4.ItemsSource = ((HedgeGroupDetailVM)VM).Quotas;
                dataGrid4.Items.Refresh();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void AddLMEPositionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var lmePositionId = (int)e.Parameter;
                var w = new AssignedQuantityWindow(((HedgeGroupDetailVM)VM).GetAvailableLotNumberByLMEId(lmePositionId));
                w.ShowDialog();
                decimal qty = w.AssignedQuantity;

                if(qty > 0)
                {
                    ((HedgeGroupDetailVM)VM).AddLMEPosition(lmePositionId, qty);
                    dataGrid2.ItemsSource = ((HedgeGroupDetailVM)VM).AddedLMEPositions;
                    dataGrid2.Items.Refresh();
                    dataGrid5.Items.Refresh();
                }
                
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void AddSHFEPositionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var shfePositionId = (int)e.Parameter;
                var w = new AssignedQuantityWindow(((HedgeGroupDetailVM)VM).GetAvailableLotNumberBySHFEId(shfePositionId));
                w.ShowDialog();
                decimal qty = w.AssignedQuantity;
                if(qty > 0)
                {
                    ((HedgeGroupDetailVM)VM).AddSHFEPosition(shfePositionId, qty);
                    dataGrid3.ItemsSource = ((HedgeGroupDetailVM)VM).AddedSHFEPositions;
                    dataGrid3.Items.Refresh();
                    dataGrid25.Items.Refresh();
                }
                
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
        #endregion
        #endregion
    }
}
