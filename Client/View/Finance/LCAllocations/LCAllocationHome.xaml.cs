using Client.View.PopUpDialog;
using Client.ViewModel.Finance.LCAllocations;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Finance.LCAllocations
{
    /// <summary>
    /// Interaction logic for LCAllocationHomer.xaml
    /// </summary>
    public sealed partial class LCAllocationHome
    {
        public new LCAllocationHomeVM VM { get; set; }
        #region Constructor

        public LCAllocationHome()
        {
            InitializeComponent();
            VM = new LCAllocationHomeVM();
            ModuleName = "LCAllocation";
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

        private void Button1Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RedirectTo(new LCAllocationDetail(PageMode.AddMode));
        }

        private void Button5Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RedirectTo(new LCAllocationList(VM.GetQueryElements(LCAllocationHomeVM.QueryType.Free)));
        }

        private void Button6Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.Reset();
        }

        private void Button4Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int)BusinessPartnerType.Customer,
                                            (int)BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.BPId = bp.Id;
            VM.BPName = bp.ShortName;
        }

        private void Button2Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RedirectTo(new LCAllocationList(VM.GetQueryElements(LCAllocationHomeVM.QueryType.CurrentMonth)));
        }

        private void Button3Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RedirectTo(new LCAllocationList(VM.GetQueryElements(LCAllocationHomeVM.QueryType.CurrentYear)));
        }

        #endregion
    }
}
