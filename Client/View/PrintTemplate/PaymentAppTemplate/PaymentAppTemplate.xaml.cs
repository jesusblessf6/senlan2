using Client.ViewModel.PrintTemplate.PaymentAppTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.PaymentAppTemplate
{
    /// <summary>
    /// Interaction logic for PaymentAppTemplate.xaml
    /// </summary>
    public sealed partial class PaymentAppTemplate
    {

        #region Property
        public PaymentAppTemplateVM PaymentAppTemplateVM { get; set; }
        #endregion

        public PaymentAppTemplate(int id, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            PaymentAppTemplateVM = new PaymentAppTemplateVM(id);
            BindData();
        }

        public override void BindData()
        {
            paymentReport.LocalReport.ReportPath = PaymentAppTemplateVM.PathName;
            paymentReport.ProcessingMode = ProcessingMode.Local;
            paymentReport.LocalReport.DataSources.Clear();
            paymentReport.LocalReport.DataSources.Add(new ReportDataSource("Header", PaymentAppTemplateVM.HeaderList));
            paymentReport.RefreshReport();
        }
    }
}
