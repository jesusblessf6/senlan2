using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Payments;
using DBEntity;

namespace Client.View.Physical.Payments
{
    /// <summary>
    /// PaymentRequestHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentRequestHome
    {
        #region Property

        public PaymentRequestHomeVM VM { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Constructor

        public PaymentRequestHome()
        {
            InitializeComponent();
            ModuleName = "PaymentRequest";
            VM = new PaymentRequestHomeVM();
            BindData();
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
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch();
            var search = new PaymentRequestList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        /// <summary>
        /// 本人付款申请草稿查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDraftSearchClick(object sender, RoutedEventArgs e)
        {
            VM.LoadDraftSearch();
            var search = new PaymentRequestList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        /// <summary>
        /// 本人未审批付款申请查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApproveSearchClick(object sender, RoutedEventArgs e)
        {
            VM.LoadApproveSearch();
            var search = new PaymentRequestList(ModuleName, VM.SearchVM);
            RedirectTo(search);
        }

        /// <summary>
        /// 新增付款申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPaymentRequestAddClick(object sender, RoutedEventArgs e)
        {
            var frm = new PaymentRequestDetail();
            RedirectTo(frm);
        }

        #endregion

        #region PopUpdialog

        /// <summary>
        /// 收款客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                VM.ReceiveBPId = BusinessPartner.Id;
                VM.ShortName = BusinessPartner.ShortName;
            }
        }

        #endregion
    }
}