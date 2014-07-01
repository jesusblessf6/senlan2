using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.Finance.FundFlows;
using Client.View.Finance.LetterOfCredits;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Payments;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.Payments
{
    /// <summary>
    /// PaymentWorkbench.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentWorkbench
    {
        #region Member

        private const int PaymentWorkbenchPerPage = 15;
        private bool _queried = false;

        #endregion

        #region Property

        public PaymentWorkbenchVM VM { get; set; }

        #endregion

        public PaymentWorkbench()
        {
            InitializeComponent();
            ModuleName = "PaymentWorkbench";
            VM = new PaymentWorkbenchVM();
            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            rootGrid.DataContext = VM;
        }

        #region Method

        public override void BindData()
        {
            VM.LoadPaymentWorkbendchCount();
            pagingControl1.Init(VM.PaymentWorkbendchTotleCount, PaymentWorkbenchPerPage);
        }

        #endregion

        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PaymentWorkbendchForm = e.From;
            VM.PaymentWorkbendchTo = e.To;
            VM.LoadPaymentWorkbendch();
            dataGrid1.ItemsSource = VM.PaymentRequests;
            dataGrid1.Items.Refresh();
        }

        /// <summary>
        /// 收款客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var businessPartner = dialog.SelectedItem as BusinessPartner;
            if (businessPartner != null)
            {
                VM.ReceiveBPId = businessPartner.Id;
                VM.ShortName = businessPartner.ShortName;
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                waitingBox.Show();
                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
            _queried = true;
        }

        private void PaymentCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PaymentExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            VM.PaymentRequestId = id;
            //if (VM.LoadPaymentMean().Name == "LC" || VM.LoadPaymentMean().Name == "L/C")
            //{
            //    VM.SelectLC();
            //    var lcfrm = new LetterOfCreditDetail(VM.LCVM, PageMode.AddMode);
            //    RedirectTo(lcfrm);
            //}
            //else if (VM.LoadPaymentMean().Name == "TT" || VM.LoadPaymentMean().Name == "T/T" ||
            //         VM.LoadPaymentMean().Name == "DP" || VM.LoadPaymentMean().Name == "D/P")
            //{
            //    VM.SelectPayment();
            //    var pfrm = new PaymentDetail(VM.PVM, PageMode.AddMode);
            //    RedirectTo(pfrm);
            //}
                if (VM.LoadPaymentMean().IsForFundFlow)//如果标识为现金收付 跳转到现金收付页面
                {
                    VM.SelectPayment();
                    var pfrm = new PaymentDetail(VM.PVM, PageMode.AddMode);
                    RedirectTo(pfrm);
                }
                else
                {
                    VM.SelectLC();
                    var lcfrm = new IssueLCDetail(VM.LCVM, PageMode.AddMode);
                    RedirectTo(lcfrm);
                }
            e.Handled = true;
        }

        private void PaymentConsummationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PaymentConsummationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                if (VM.ValidateAmount(id))
                {
                    if (MessageBox.Show(ResPayment.PaymentConfirm, ResPayment.PaymentComplete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        try
                        {
                            VM.PaymentRequestId = id;
                            VM.ObjectId = id;
                            VM.Save();
							VM.LoadPaymentWorkbendchCount();
							pagingControl1.Init(VM.PaymentWorkbendchTotleCount, PaymentWorkbenchPerPage);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                            return;
                        }
                   }
                }
            }
            e.Handled = true;
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * PaymentWorkbenchPerPage + e.Row.GetIndex() + 1;
        }

        private void RootGridIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_queried && (bool) e.OldValue == false && (bool) e.NewValue)
            {
                VM.LoadPaymentWorkbendchCount();
                pagingControl1.Init(VM.PaymentWorkbendchTotleCount, PaymentWorkbenchPerPage);
            }
        }
    }
}
