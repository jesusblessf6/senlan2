using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using Microsoft.Reporting.WinForms;

namespace Client.View.PrintTemplate.DomesticWarehouseOutTemplate
{
    /// <summary>
    /// Interaction logic for PrintInOutTemplate.xaml
    /// </summary>
    public sealed partial class PrintInOutTemplate
    {
        #region Property

        public PrintInOutTemplateVM PrintInOutTemplateVM { get; set; }

        #endregion

        public PrintInOutTemplate(int inOutID, string moduleName, string printName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            PrintInOutTemplateVM = new PrintInOutTemplateVM(inOutID, printName);
            BindData();
        }

        #region Method

        public override void BindData()
        {
            warehouseInOutReport.LocalReport.ReportPath = "PrintTemplate\\内贸出库单\\上海长然出入库单.rdlc";
            warehouseInOutReport.ProcessingMode = ProcessingMode.Local;
            warehouseInOutReport.LocalReport.DataSources.Clear();

            warehouseInOutReport.LocalReport.DataSources.Add(new ReportDataSource("Header",
                                                                                PrintInOutTemplateVM.Header));
            warehouseInOutReport.LocalReport.DataSources.Add(new ReportDataSource("Lines",
                                                                                PrintInOutTemplateVM.Lines));
            warehouseInOutReport.RefreshReport();
        }

        #endregion
    }
}
