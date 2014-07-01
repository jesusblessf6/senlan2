using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using System;

namespace Client.View.Physical.VATInvoices
{
    /// <summary>
    /// VATInvoiceHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class VATInvoiceHome
    {
        #region Property

        public VATInvoiceHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public VATInvoiceHome()
        {
            InitializeComponent();
            ModuleName = "VATInvoice";
            VM = new VATInvoiceHomeVM();
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
        private void BtnVATInvoiceRequestList(object sender, RoutedEventArgs e)
        {
            var listVM = new VATInvoiceRequestListVM();
            listVM.Init(true);
            var list = new VATInvoiceRequestList(ModuleName, listVM, PageMode.ViewMode);
            RedirectTo(list);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            VM.Load();
            var list = new VATInvoiceList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMonthUnOpenSearchClick(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startDate = dt.AddDays(-dt.Day);
            DateTime endDate = startDate.AddMonths(1);
            VM.Load(startDate,endDate);
            var list = new VATInvoiceList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUnOpenSearchClick(object sender, RoutedEventArgs e)
        {

            VM.Load(null,null);
            var list = new VATInvoiceList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            var frm = new VATInvoiceDetail((int) VATInvoiceType.Issue);
            RedirectTo(frm);
        }


        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddCollectClick(object sender, RoutedEventArgs e)
        {
            var frm = new VATInvoiceDetail((int) VATInvoiceType.Receive);
            RedirectTo(frm);
        }

        #endregion

        #region PopUpdialog

        private void BtnBusinessPartnerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int) BusinessPartnerType.Customer,
                                            (int) BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.BPId = bp.Id;
                VM.BPName = bp.ShortName;
            }
        }

        #endregion
    }
}