using Client.ViewModel.Physical.ForeignDeliveryPools;
using DBEntity.EnumEntity;

namespace Client.View.Physical.ForeignDeliveryPools
{
    /// <summary>
    /// Interaction logic for StorageFeeDateDetail.xaml
    /// </summary>
    public sealed partial class StorageFeeDateDetail
    {
        #region Constructor

        //Edit and View mode
        public StorageFeeDateDetail(ForeignDeliveryPoolDetailVM parentVM, int id, PageMode pageMode)
            : base(pageMode, "仓租日期明细")
        {
            InitializeComponent();
            ModuleName = "ForeignDeliveryPool";
            VM = new StorageFeeDateDetailVM(parentVM, id);
            BindData();
        }

        //Add mode
        public StorageFeeDateDetail(ForeignDeliveryPoolDetailVM parentVM)
            : base(PageMode.AddMode, "仓租日期明细")
        {
            InitializeComponent();
            ModuleName = "ForeignDeliveryPool";
            VM = new StorageFeeDateDetailVM(parentVM);
            BindData();
        }

        #endregion
    }
}
