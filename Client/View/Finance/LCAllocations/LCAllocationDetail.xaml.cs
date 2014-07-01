using Client.View.PopUpDialog;
using Client.ViewModel.Finance.LCAllocations;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Finance.LCAllocations
{
    /// <summary>
    /// Interaction logic for LCAllocationDetail.xaml
    /// </summary>
    public sealed partial class LCAllocationDetail
    {
        #region Constructor

        public LCAllocationDetail()
            : base(PageMode.ViewMode, "信用证分配")
        {
            InitializeComponent();
            ModuleName = "LCAllocation";
            VM = new LCAllocationDetailVM();
            BindData();
        }

        public LCAllocationDetail(PageMode pageMode)
            : base(pageMode, "信用证分配")
        {
            InitializeComponent();
            ModuleName = "LCAllocation";
            VM = new LCAllocationDetailVM();
            BindData();
        }

        public LCAllocationDetail(PageMode pageMode, int id)
            : base(pageMode, "信用证分配")
        {
            InitializeComponent();
            ModuleName = "LCAllocation";
            VM = new LCAllocationDetailVM(id);
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
            string queryStr = string.Format("it.CustomerType={0} or it.CustomerType={1}",
                                            (int)BusinessPartnerType.Customer,
                                            (int)BusinessPartnerType.InternalCustomer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            ((LCAllocationDetailVM)VM).BPId = bp.Id;
            ((LCAllocationDetailVM)VM).BPName = bp.ShortName;
        }

        #endregion
    }
}
