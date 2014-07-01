using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Physical.Payments;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using Client.View.PrintTemplate.PaymentAppTemplate;

namespace Client.View.Physical.Payments
{
    /// <summary>
    /// PaymentRequestList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentRequestList
    {
        #region Member

        private const int PaymentRequestPerPage = 15;
        private readonly bool _canDelete;
        private readonly bool _canEdit;

        #endregion

        #region Property

        public PaymentRequestListVM VM { get; set; }

        #endregion

        #region Constructor

        public PaymentRequestList(string moduleName, PaymentRequestListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);

            VM = vm;
            pagingControl1.OnNewPage += pagerPaymentRequest_OnNewPage;
            pagingControl1.Init(VM.PaymentRequestTotleCount, PaymentRequestPerPage);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            contractGrid.ItemsSource = VM.PaymentRequests;
            cbSelectAll.DataContext = VM;
        }

        #endregion

        #region Event

        private void pagerPaymentRequest_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PaymentRequestForm = e.From;
            VM.PaymentRequestTo = e.To;
            VM.LoadPaymentRequest();
            //contractGrid.ItemsSource = null;
            contractGrid.ItemsSource = VM.PaymentRequests;
            contractGrid.Items.Refresh();
        }

        private void PaymentRequestEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PaymentRequestDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PaymentRequestPrintCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PaymentRequestPrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if(id > 0)
            {
                var paymentPrint = new PaymentAppTemplate(id, ModuleName);
                RedirectTo(paymentPrint);
            }

        }
        private void PaymentRequestEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;

            if (!VM.CanPREditWithApproveStatus(id))
            {
                MessageBox.Show(ResPayment.ApprovalError);
                return;
            }

            var prd = new PaymentRequestDetail(id, PageMode.EditMode);
            RedirectTo(prd);
        }

        private void PaymentRequestDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;

            if (!VM.CanPREditWithApproveStatus(id))
            {
                MessageBox.Show(ResPayment.ApprovalError2);
                return;
            }

            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeletePaymentRequest(id);
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
            VM.LoadPaymentRequestCount();
            pagingControl1.OnNewPage += pagerPaymentRequest_OnNewPage;
            pagingControl1.Init(VM.PaymentRequestTotleCount, PaymentRequestPerPage);
            BindData();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * PaymentRequestPerPage + e.Row.GetIndex() + 1;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.PrintSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            int paymentId = Convert.ToInt32(c.Tag);
            VM.SetPrintCheckBoxSelected(paymentId,c.IsChecked ?? false);
        }
    }
}