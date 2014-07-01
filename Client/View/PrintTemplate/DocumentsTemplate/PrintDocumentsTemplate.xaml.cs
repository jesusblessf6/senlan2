using Client.ViewModel.PrintTemplate.DocumentsTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.DocumentsTemplate
{
    /// <summary>
    /// Interaction logic for PrintDocumentsTemplate.xaml
    /// </summary>
    public sealed partial class PrintDocumentsTemplate
    {
        #region Property

        public DocumentsTemplateVM VM { get; set; }

        #endregion

        public PrintDocumentsTemplate(int invoiceID, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new DocumentsTemplateVM(invoiceID);
            BindData();
        }

        public override void BindData()
        {
            documentOriginReport.LocalReport.ReportPath = @"PrintTemplate\交单单据模板\交单单据报表.rdlc";
            documentOriginReport.ProcessingMode = ProcessingMode.Local;
            documentOriginReport.LocalReport.DataSources.Clear();
            
            documentOriginReport.LocalReport.DataSources.Add(new ReportDataSource("Header", VM.HeaderList));
            documentOriginReport.RefreshReport();
        }
    }
}
