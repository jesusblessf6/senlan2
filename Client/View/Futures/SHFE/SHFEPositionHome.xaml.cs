using System.Windows;
using Client.ViewModel.Futures.SHFE;
using DBEntity.EnumEntity;

namespace Client.View.Futures.SHFE
{
    /// <summary>
    /// Interaction logic for SHFEPositionHome.xaml
    /// </summary>
    public sealed partial class SHFEPositionHome
    {
        #region Property

        public SHFEPositionHomeVM VM { get; set; }

        #endregion

        public SHFEPositionHome()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "SHFEPositionSetting";
            VM = new SHFEPositionHomeVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        /// <summary>
        /// 境内头寸导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var dialog= new SHFEPositionImport();
            dialog.ShowDialog();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            var list=new SHFEPositionList(VM.SelectedBrokerId,VM.SelectedInnerCustomer,VM.SelectedCommodityId,VM.StartTradeDate,VM.EndTradeDate,VM.StartPromptDate,VM.EndPromptDate);
            RedirectTo(list);
        }
    }
}
