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
using Microsoft.Reporting.WinForms;
using Client.ViewModel.PrintTemplate.ContractPrint;
using Client.Base;

namespace Client.View.PrintTemplate.ContractPrint
{
    /// <summary>
    /// Interaction logic for PrintContractTemplate.xaml
    /// </summary>
    public partial class PrintContractTemplate : BasePage
    {

        private PrintContractTemplateVM _PrintContractTemplateVM;

        public PrintContractTemplateVM PrintContractTemplateVM
        {
            get { return _PrintContractTemplateVM; }
            set { _PrintContractTemplateVM = value; }
        }


        public PrintContractTemplate(int contractID, string moduleName)
        {
            InitializeComponent();
            ModuleName = moduleName;
            PrintContractTemplateVM = new PrintContractTemplateVM(contractID);
            BindData();
        }


        public override void BindData()
        {
            contractReport.LocalReport.ReportPath = @"PrintTemplate\内贸合同模板\ContractReport.rdlc";
            contractReport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            contractReport.LocalReport.DataSources.Clear();

            contractReport.LocalReport.DataSources.Add(new ReportDataSource("Head", PrintContractTemplateVM.HeaderList));
            contractReport.LocalReport.DataSources.Add(new ReportDataSource("Lines", PrintContractTemplateVM.LineList));
            contractReport.RefreshReport();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //contractReport.LocalReport.ReportPath = @"ContractPrint\ContractReport.rdlc";
            //contractReport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //contractReport.LocalReport.DataSources.Clear();

            //contractReport.LocalReport.DataSources.Add(new ReportDataSource("Head", PrintContractTemplateVM.HeaderList));
            //contractReport.LocalReport.DataSources.Add(new ReportDataSource("Lines", PrintContractTemplateVM.LineList));
            //contractReport.RefreshReport();
        }

    }
}
