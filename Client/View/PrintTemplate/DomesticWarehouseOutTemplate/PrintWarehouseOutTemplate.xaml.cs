using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.DomesticWarehouseOutTemplate
{
    /// <summary>
    /// Interaction logic for PrintWarehouseOutTemplate.xaml
    /// </summary>
    public sealed partial class PrintWarehouseOutTemplate
    {
        #region Constructor

        public PrintWarehouseOutTemplate(int warehouseOutID, string moduleName, string printName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            PrintWarehouseOutTemplateVM = new PrintWarehouseOutTemplateVM(printName,warehouseOutID);
            BindData();
        }

        #endregion

        #region Property

        public PrintWarehouseOutTemplateVM PrintWarehouseOutTemplateVM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            warehouseOutReport.LocalReport.ReportPath = PrintWarehouseOutTemplateVM.PathName;
            warehouseOutReport.ProcessingMode = ProcessingMode.Local;
            warehouseOutReport.LocalReport.DataSources.Clear();

            warehouseOutReport.LocalReport.DataSources.Add(new ReportDataSource("Header",
                                                                                PrintWarehouseOutTemplateVM.HeaderList));
            warehouseOutReport.LocalReport.DataSources.Add(new ReportDataSource("Lines",
                                                                                PrintWarehouseOutTemplateVM.LineList));
            warehouseOutReport.RefreshReport();
        }

        #endregion
    }
}