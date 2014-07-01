using Client.ViewModel.Reports;
using DBEntity.EnumEntity;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for QuotaStatusChange.xaml
    /// </summary>
    public sealed partial class QuotaStatusChange
    {
        #region Constructor

        public QuotaStatusChange(int quotaId)
            : base(PageMode.EditMode, ResReport.QuotaStatus)
        {
            InitializeComponent();
            ModuleName = "QuotaStatusChange";
            VM = new QuotaStatusChangeVM(quotaId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}
