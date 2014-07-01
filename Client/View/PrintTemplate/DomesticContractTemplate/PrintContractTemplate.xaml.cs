using System.Windows;
using Client.ViewModel.PrintTemplate.DomesticContractTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.DomesticContractTemplate
{
    /// <summary>
    /// Interaction logic for PrintContractTemplate.xaml
    /// </summary>
    public sealed partial class PrintContractTemplate
    {
        #region Property

        public PrintContractTemplateVM VM { get; set; }

        #endregion

        #region Constructor

        public PrintContractTemplate(int contractID, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new PrintContractTemplateVM(contractID);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            contractReport.LocalReport.ReportPath = VM.PathName;
            contractReport.ProcessingMode = ProcessingMode.Local;
            contractReport.LocalReport.DataSources.Clear();
            //contractReport.ShowToolBar = false;

            contractReport.LocalReport.DataSources.Add(new ReportDataSource("Head", VM.HeaderList));
            contractReport.LocalReport.DataSources.Add(new ReportDataSource("Lines", VM.LineList));
            contractReport.RefreshReport();
        }

        #endregion

        #region Event

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
        }

        #endregion

    }
}
