using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Futures.LME;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Futures.LME
{
    /// <summary>
    /// LMEPositionHome.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LMEPositionHome
    {
        #region Property

        public LMEPositionHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public LMEPositionHome()
        {
            InitializeComponent();
            ModuleName = "LMEPositionSetting";
            VM = new LMEPositionHomeVM();
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
            VM.Load();
            var list = new LMEPositionList(ModuleName, VM.ListVM);
            RedirectTo(list);
        }

        private void BtnCreatePositionClick(object sender, RoutedEventArgs e)
        {
            var frm = new LMEPositionDetail();
            RedirectTo(frm);
        }

        private void BtnCreateCarryPositionClick(object sender, RoutedEventArgs e)
        {
            var frm = new LMECarryPositionDetail();
            RedirectTo(frm);
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0}", (int) BusinessPartnerType.Customer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.SelectedBPartnerId = bp.Id;
            VM.BPartnerName = bp.ShortName;
        }

        #endregion
    }
}