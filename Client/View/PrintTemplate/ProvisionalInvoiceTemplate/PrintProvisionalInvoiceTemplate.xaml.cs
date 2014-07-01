using Client.ViewModel.PrintTemplate.ProvisionalInvoiceTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.ProvisionalInvoiceTemplate
{
    /// <summary>
    /// Interaction logic for PrintProvisionalInvoiceTemplate.xaml
    /// </summary>
    public sealed partial class PrintProvisionalInvoiceTemplate
    {
        #region Property
        public ProvisionalInvoiceTemplateVM ProvisionalInvoiceTemplateVM { get; set; }
        #endregion

        public PrintProvisionalInvoiceTemplate(int id, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            ProvisionalInvoiceTemplateVM = new ProvisionalInvoiceTemplateVM(id);
            BindData();
        }

        public override void BindData()
        {
            invoiceReport.LocalReport.ReportPath = ProvisionalInvoiceTemplateVM.PathName;
            invoiceReport.ProcessingMode = ProcessingMode.Local;
            invoiceReport.LocalReport.DataSources.Clear();
           
            invoiceReport.LocalReport.DataSources.Add(new ReportDataSource("Head",
                               ProvisionalInvoiceTemplateVM.HeaderList));
            
            invoiceReport.RefreshReport();
        }
    }
}
