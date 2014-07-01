using Client.ViewModel.PrintTemplate.FinalInvoiceTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.FinalInvoiceTemplate
{
    /// <summary>
    /// Interaction logic for PrintFinalInvoiceTemplate.xaml
    /// </summary>
    public sealed partial class PrintFinalInvoiceTemplate
    {
        #region Property
        public FinalInvoiceTemplateVM FinalInvoiceTemplateVM { get; set; }
        #endregion

        public PrintFinalInvoiceTemplate(int id, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            FinalInvoiceTemplateVM = new FinalInvoiceTemplateVM(id);
            BindData();
        }

        public override void BindData()
        {
            finalInvoiceReport.LocalReport.ReportPath = FinalInvoiceTemplateVM.PathName;
            finalInvoiceReport.ProcessingMode = ProcessingMode.Local;
            finalInvoiceReport.LocalReport.DataSources.Clear();
            
            finalInvoiceReport.LocalReport.DataSources.Add(new ReportDataSource("Head",
                                                  FinalInvoiceTemplateVM.HeaderList));
            finalInvoiceReport.LocalReport.DataSources.Add(new ReportDataSource("Lines",
                                                 FinalInvoiceTemplateVM.LCPropertyList));
            finalInvoiceReport.RefreshReport();
        }
    }
}
