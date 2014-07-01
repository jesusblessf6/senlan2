using Client.ViewModel.Reports;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// Interaction logic for DeliveryListOfSameFlow.xaml
    /// </summary>
    public sealed partial class DeliveryListOfSameFlow
    {
        #region Property

        public ExternalDeliveryCirculReportVM VM { get; set; }

        #endregion

        #region Constructor

        public DeliveryListOfSameFlow(string moduleName, string circulNo)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new ExternalDeliveryCirculReportVM {CirculNo = circulNo};
            VM.Load();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            dataGrid1.DataContext = VM.CirculView;
        }

        #endregion
    }
}
