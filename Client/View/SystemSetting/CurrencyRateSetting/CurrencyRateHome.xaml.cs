using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.CurrencyRateSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CurrencyRateSetting
{
    /// <summary>
    /// Interaction logic for CurrencyRateHome.xaml
    /// </summary>
    public sealed partial class CurrencyRateHome
    {
        #region Property

        public CurrencyRateHomeVM VM { get; set; }

        #endregion

        #region Member

        private readonly bool _canAdd;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;

        #endregion

        #region Constructor

        public CurrencyRateHome()
        {
            InitializeComponent();
            ModuleName = "CurrencyRateSetting";

            _canAdd = CheckPerm(PageMode.AddMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            button1.IsEnabled = _canAdd;
            btRate.IsEnabled = _canAdd;

            VM = new CurrencyRateHomeVM();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        public override void Refresh()
        {
            VM.LoadCurrency();
            dataGrid1.ItemsSource = VM.Currencies;
            dataGrid1.Items.Refresh();

            VM.LoadRate();
            ratedataGrid.ItemsSource = VM.Rates;
            ratedataGrid.Items.Refresh();
        }

        #endregion

        #region Event

        #region 货币

        private void CurrencyEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void CurrencyEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var currencyId = (int) e.Parameter;
            var cd = new CurrencyDetail(currencyId, PageMode.EditMode);
            cd.Show();
            e.Handled = true;
        }

        private void CurrencyDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void CurrencyDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteCurrency(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        private void CurrencyViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void CurrencyViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var currencyId = (int) e.Parameter;
            var cd = new CurrencyDetail(currencyId, PageMode.ViewMode);
            cd.Show();
            e.Handled = true;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var cd = new CurrencyDetail(PageMode.AddMode);
            cd.Show();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        #endregion

        #region 汇率

        private void RateEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void RateEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var rateId = (int) e.Parameter;
            var cd = new RateDetail(PageMode.EditMode, rateId);
            cd.Show();
            e.Handled = true;
        }

        private void RateDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void RateDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteRate(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        private void RateViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void RateViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var rateId = (int) e.Parameter;
            var cd = new RateDetail(PageMode.ViewMode, rateId);
            cd.Show();
            e.Handled = true;
        }

        private void BtRateClick(object sender, RoutedEventArgs e)
        {
            var cd = new RateDetail(PageMode.AddMode);
            cd.Show();
        }

        private void RatedataGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        #endregion

        #endregion
    }
}