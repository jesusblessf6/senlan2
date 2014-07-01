using Client.ViewModel.Futures.SHFE;
using DBEntity.EnumEntity;

namespace Client.View.Futures.SHFE
{
    /// <summary>
    /// Interaction logic for SHFEPositionDetail.xaml
    /// </summary>
    public sealed partial class SHFEPositionDetail
    {
        public SHFEPositionAddVM VM { get; set; }
        public SHFEPositionDetail()
        {
            InitializeComponent();
            ModuleName = "SHFEPositionSetting";
        }

        public SHFEPositionDetail(int id,PageMode pageMode): base(pageMode)
        {
            InitializeComponent();
            ModuleName = "SHFEPositionSetting";
            VM=new SHFEPositionAddVM(id);
            BindData();
            if (pageMode == PageMode.ViewMode)
            {
                IsEnabled = false;
            }
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }
    }
}
