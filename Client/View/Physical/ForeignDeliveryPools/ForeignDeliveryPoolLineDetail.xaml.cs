using Client.ViewModel.Physical.ForeignDeliveryPools;
using DBEntity.EnumEntity;

namespace Client.View.Physical.ForeignDeliveryPools
{
    /// <summary>
    /// Interaction logic for ForeignDeliveryPoolLineDetail.xaml
    /// </summary>
    public sealed partial class ForeignDeliveryPoolLineDetail
    {
        #region Constructor

        /// <summary>
        /// only for Add
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="parentVM"></param>
        public ForeignDeliveryPoolLineDetail(string objName, ForeignDeliveryPoolDetailVM parentVM)
            : base(PageMode.AddMode, objName)
        {
            InitializeComponent();
            VM = new ForeignDeliveryPoolLineDetailVM(parentVM);
            ModuleName = "ForeignDeliveryPool";
            BindData();
        }

        /// <summary>
        /// only for Edit
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="id"></param>
        /// <param name="parentVM"></param>
        /// <param name="pageMode"></param>
        public ForeignDeliveryPoolLineDetail(string objName, int id, ForeignDeliveryPoolDetailVM parentVM, PageMode pageMode)
            : base(pageMode, objName)
        {
            InitializeComponent();
            VM = new ForeignDeliveryPoolLineDetailVM(id, parentVM);
            ModuleName = "ForeignDeliveryPool";
            BindData();
        }

        #endregion

        #region Method

        protected override void AfterSave()
        {
            Close();
        }

        #endregion
    }
}
