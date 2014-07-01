using Client.ViewModel.PrintTemplate.PricingConfirmationTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.PricingConfirmationTemplate
{
    /// <summary>
    /// Interaction logic for PricingConfirmationTemplate.xaml
    /// </summary>
    public sealed partial class PricingConfirmationTemplate
    {
        #region Property
        public PricingConfirmationVM PricingConfirmationVM { get; set; }
        #endregion

        public PricingConfirmationTemplate(int id, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            PricingConfirmationVM = new PricingConfirmationVM(id);
            BindData();
        }

        public override void BindData()
        {
            pricingReport.LocalReport.ReportPath = PricingConfirmationVM.PathName;
            pricingReport.ProcessingMode = ProcessingMode.Local;
            pricingReport.LocalReport.DataSources.Clear();
            pricingReport.LocalReport.DataSources.Add(new ReportDataSource("Head", PricingConfirmationVM.HeaderList));
            pricingReport.RefreshReport();
        }
    }
}
