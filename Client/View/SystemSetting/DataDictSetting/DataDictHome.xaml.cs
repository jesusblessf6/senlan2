using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// Interaction logic for DataDictHome.xaml
    /// </summary>
    public sealed partial class DataDictHome
    {
        #region Property

        public DataDictHomeVM VM { get; set; }

        #endregion

        #region Member

        private const int DataDictPerPage = 10;
        private readonly bool _canAdd;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;

        #endregion

        #region Constructor

        public DataDictHome()
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new DataDictHomeVM();
            _canAdd = CheckPerm(PageMode.AddMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            #region 原产地

            button1.IsEnabled = _canAdd;
            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl1.Init(VM.CountryCount, DataDictPerPage);

            #endregion

            #region 港口

            button2.IsEnabled = _canAdd;
            portpagingControl.OnNewPage += portpagingControl_OnNewPage;
            portpagingControl.Init(VM.PortCount, DataDictPerPage);

            #endregion

            #region 付款方式

            btPaymentMean.IsEnabled = _canAdd;
            paymentmeanpagingControl.OnNewPage += paymentmeanpagingControl_OnNewPage;
            paymentmeanpagingControl.Init(VM.PaymentMeanCount, DataDictPerPage);

            #endregion

            #region 税率

            btVATRate.IsEnabled = _canAdd;
            vatratepagingControl.OnNewPage += vatratepagingControl_OnNewPage;
            vatratepagingControl.Init(VM.VATRateCount, DataDictPerPage);

            #endregion

            #region 付款用途

            btPaymentUsage.IsEnabled = _canAdd;
            paymentusagepagingControl.OnNewPage += paymentusagepagingControl_OnNewPage;
            paymentusagepagingControl.Init(VM.PaymentUsageCount, DataDictPerPage);

            #endregion

            #region 自定义类型
            btUDF.IsEnabled = _canAdd;
            udfPagingControl.OnNewPage += UdfPagingControl_OnNewPage;
            udfPagingControl.Init(VM.UdfCount, DataDictPerPage);

            #endregion

            #region 提货人

            btAddDP.IsEnabled = _canAdd;
            dpListPager.OnNewPage += DPListPagerOnOnNewPage;
            dpListPager.Init(VM.DeliveryPersonCount, DataDictPerPage);

            #endregion
        }

        #endregion

        #region Event

        #region 原产地Event

        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.CountryFrom = e.From;
            VM.CountryTo = e.To;
            VM.LoadCountry();
            dataGrid1.ItemsSource = VM.Countries;
            dataGrid1.Items.Refresh();
        }

        private void CountryEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void CountryEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var currencyId = (int) e.Parameter;
            var cd = new CountryDetail(currencyId, PageMode.EditMode);
            cd.Show();
            e.Handled = true;
        }

        private void CountryDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void CountryDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteCountry(id);
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

        private void CountryViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void CountryViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var currencyId = (int) e.Parameter;
            var cd = new CountryDetail(currencyId, PageMode.ViewMode);
            cd.Show();
            e.Handled = true;
        }

        private void BtCountryClick(object sender, RoutedEventArgs e)
        {
            var cd = new CountryDetail(PageMode.AddMode);
            cd.Show();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region 港口Event

        private void portpagingControl_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PortFrom = e.From;
            VM.PortTo = e.To;
            VM.LoadPort();
            portDataGrid.ItemsSource = VM.Ports;
            portDataGrid.Items.Refresh();
        }

        private void PortEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PortEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var portId = (int) e.Parameter;
            var pd = new PortDetail(PageMode.EditMode, portId);
            pd.Show();
            e.Handled = true;
        }

        private void PortDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PortDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeletePort(id);
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

        private void PortViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void PortViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var portId = (int) e.Parameter;
            var pd = new PortDetail(PageMode.ViewMode, portId);
            pd.Show();
            e.Handled = true;
        }

        private void BtPortClick(object sender, RoutedEventArgs e)
        {
            var pd = new PortDetail(PageMode.AddMode);
            pd.Show();
        }

        private void DataGridPortLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (portpagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region 付款方式Event

        private void paymentmeanpagingControl_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PaymentMeanFrom = e.From;
            VM.PaymentMeanTo = e.To;
            VM.LoadPaymentMean();
            paymentMeanDataGrid.ItemsSource = VM.PaymentMeans;
            paymentMeanDataGrid.Items.Refresh();
        }

        private void PaymentMeanEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PaymentMeanEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var paymentmeanId = (int) e.Parameter;
            var pm = new PaymentMeanDetail(paymentmeanId, PageMode.EditMode);
            pm.Show();
            e.Handled = true;
        }

        private void PaymentMeanDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PaymentMeanDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeletePaymentMean(id);
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

        private void PaymentMeanViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void PaymentMeanViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var paymentmeanId = (int) e.Parameter;
            var pm = new PaymentMeanDetail(paymentmeanId, PageMode.ViewMode);
            pm.Show();
            e.Handled = true;
        }

        private void BtPaymentMeanClick(object sender, RoutedEventArgs e)
        {
            var pm = new PaymentMeanDetail(PageMode.AddMode);
            pm.Show();
        }

        private void DataGridPaymentMeanLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (paymentmeanpagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region 税率Event

        private void vatratepagingControl_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.VATRateFrom = e.From;
            VM.VATRateTo = e.To;
            VM.LoadVATRate();
            vatRateDataGrid.ItemsSource = VM.VATRates;
            vatRateDataGrid.Items.Refresh();
        }

        private void VATRateEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void VATRateEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var vatrateId = (int) e.Parameter;
            var pm = new VATRateDetail(PageMode.EditMode, vatrateId);
            pm.Show();
            e.Handled = true;
        }

        private void VATRateDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void VATRateDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteVATRate(id);
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

        private void VATRateViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void VATRateViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var vatrateId = (int) e.Parameter;
            var pm = new VATRateDetail(PageMode.ViewMode, vatrateId);
            pm.Show();
            e.Handled = true;
        }

        private void BtVATRateClick(object sender, RoutedEventArgs e)
        {
            var pm = new VATRateDetail(PageMode.AddMode);
            pm.Show();
        }

        private void DataGridVATRateLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (vatratepagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region 付款用途Event

        private void paymentusagepagingControl_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PaymentUsageFrom = e.From;
            VM.PaymentUsageTo = e.To;
            VM.LoadPaymentUsage();
            paymentUsageDataGrid.ItemsSource = VM.PaymentUsages;
            paymentUsageDataGrid.Items.Refresh();
        }

        private void PaymentUsageEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PaymentUsageEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var paymentusageId = (int) e.Parameter;
            var pu = new PaymentUsageDetail(PageMode.EditMode, paymentusageId);
            pu.Show();
            e.Handled = true;
        }

        private void PaymentUsageDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PaymentUsageDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeletePaymentUsage(id);
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

        private void PaymentUsageViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void PaymentUsageViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var paymentusageId = (int) e.Parameter;
            var pu = new PaymentUsageDetail(PageMode.ViewMode, paymentusageId);
            pu.Show();
            e.Handled = true;
        }

        private void BtPaymentUsageClick(object sender, RoutedEventArgs e)
        {
            var pu = new PaymentUsageDetail(PageMode.AddMode);
            pu.Show();
        }

        private void DataGridPaymentUsageLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (paymentusagepagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region 付款用途Event

        private void UdfPagingControl_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.UdfFrom = e.From;
            VM.UdfTo = e.To;
            VM.LoadContractUDF();
            udfDataGrid.ItemsSource = VM.Udfs;
            udfDataGrid.Items.Refresh();
        }

        private void UdfEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void UdfEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var pu = new ContractUDFDetail(PageMode.EditMode, id);
            pu.Show();
            e.Handled = true;
        }

        private void UdfDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void UdfDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteContractUDF(id);
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

        private void UdfViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void UdfViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var pu = new ContractUDFDetail(PageMode.ViewMode, id);
            pu.Show();
            e.Handled = true;
        }

        private void BtUDFClick(object sender, RoutedEventArgs e)
        {
            var pu = new ContractUDFDetail(PageMode.AddMode);
            pu.Show();
        }

        private void DataGridUdfLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (udfPagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        #endregion


        private void TabControl1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0 && e.AddedItems.Count > 0)
            {
                Refresh();
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        #region 提货人
        private void DeliveryPersonLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (udfPagingControl.CurPageNo - 1) * DataDictPerPage + e.Row.GetIndex() + 1;
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var w = new DeliveryPersonDetail(PageMode.AddMode);
            w.Show();
            e.Handled = true;
        }

        private void DPEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void DPEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var w = new DeliveryPersonDetail(PageMode.EditMode, id);
            w.Show();
            e.Handled = true;
        }

        private void DPDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DPDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteDeliveryPerson(id);
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

        private void DPViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void DPViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var w = new DeliveryPersonDetail(PageMode.ViewMode, id);
            w.Show();
            e.Handled = true;
        }

        private void DPListPagerOnOnNewPage(object sender, PagingEventArgs e)
        {
            VM.DeliveryPersonFrom = e.From;
            VM.DeliveryPersonTo = e.To;
            VM.LoadDeliveryPersons();
            dgDPList.ItemsSource = VM.DeliveryPersons;
            dgDPList.Items.Refresh();
        }
        #endregion

        #endregion

        #region Method

        public override void BindData()
        {
        }

        public override void Refresh()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                VM.LoadCountryCount();
                pagingControl1.Init(VM.CountryCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                VM.LoadPortCount();
                portpagingControl.Init(VM.PortCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                VM.LoadPaymentMeanCount();
                paymentmeanpagingControl.Init(VM.PaymentMeanCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                VM.LoadVATRateCount();
                vatratepagingControl.Init(VM.VATRateCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                VM.LoadPaymentUsageCount();
                paymentusagepagingControl.Init(VM.PaymentUsageCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                VM.LoadDeliveryPersonCount();
                dpListPager.Init(VM.DeliveryPersonCount, DataDictPerPage);
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                VM.LoadContractUDFCount();
                udfPagingControl.Init(VM.UdfCount, DataDictPerPage);
            }
        }

        #endregion

        
    }
}