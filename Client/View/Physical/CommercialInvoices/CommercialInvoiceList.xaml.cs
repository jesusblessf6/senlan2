using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Client.View.Physical.Contracts;
using Client.View.PrintTemplate.DocumentsTemplate;
using Client.View.PrintTemplate.FinalInvoiceTemplate;
using Client.View.PrintTemplate.ProvisionalInvoiceTemplate;
using Client.ViewModel.Physical.CommercialInvoices;
using Client.ViewModel.PrintTemplate.DocumentsTemplate;
using Client.ViewModel.PrintTemplate.FinalInvoiceTemplate;
using Client.ViewModel.PrintTemplate.ProvisionalInvoiceTemplate;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Microsoft.Reporting.WinForms;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    ///     Interaction logic for CommercialInvoiceList.xaml
    /// </summary>
    public sealed partial class CommercialInvoiceList
    {
        private const int RecordPerPage = 20;

        public CommercialInvoiceList(string moduleName, CommercialInvoiceListVM vm, ContractType contractType)
        {
            InitializeComponent();
            ContractType = contractType;
            if (ContractType == ContractType.Sales)
            {
                dataGrid1.Columns[2].Header = Properties.Resources.Buyer;
                lbTitle.Content = ResCommercialInvoice.SalesCommercialInvoiceList;
            }
            else if (ContractType == ContractType.Purchase)
            {
                dataGrid1.Columns[2].Header = Properties.Resources.Supplier;
                lbTitle.Content = ResCommercialInvoice.PurchaseCommercialInvoiceList;
            }
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagingControl1.OnNewPage += pager_OnNewPage;
            pagingControl1.Init(VM.Count, RecordPerPage);
            BindData();
        }

        public CommercialInvoiceListVM VM { get; set; }
        public ContractType ContractType { get; set; }

        public override void BindData()
        {
            dataGrid1.ItemsSource = VM.CommercialInvoice;
            dataGrid1.Items.Refresh();
        }

        private void pager_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.From = e.From;
            VM.To = e.To;
            VM.LoadCommercialInvoice();
            dataGrid1.ItemsSource = VM.CommercialInvoice;
            dataGrid1.Items.Refresh();
        }

        private void InvoiceCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void InvoiceEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //编辑
            var id = (int)e.Parameter;
            CommercialInvoice invoice = VM.GetInvoiceById(id);
            if (invoice != null)
            {
                if (invoice.InvoiceType == (int)CommercialInvoiceType.Provisional)
                {
                    //临时发票
                    RedirectTo(new ProvisionalCommercialInvoice(ContractType, id));
                }
                else if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
                {
                    //最终发票
                    RedirectTo(new FinalCommercialInvoice(ContractType, id));
                }
                else if (invoice.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                {
                    RedirectTo(new ProvisionalCommercialInvoice(ContractType, id, true));
                }
            }
        }

        private void InvoiceDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.Nullify,
                                MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                return;
            //删除
            try
            {
                var id = (int)e.Parameter;
                VM.RemoveInvoiceById(id);
                MessageBox.Show(Properties.Resources.DeleteSucessfully);
                VM.LoadComCount();
                VM.LoadCommercialInvoice();
                dataGrid1.ItemsSource = VM.CommercialInvoice;
                dataGrid1.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void InvoicePrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            CommercialInvoice invoice = VM.GetInvoiceById(id);
            if (invoice != null)
            {
                PrintCommercialInvoice printCommercialInvoice = new PrintCommercialInvoice(PageMode.EditMode, ModuleName, id, invoice.InvoiceType);
                printCommercialInvoice.ShowDialog();
            }
            //string dirPath = "ReportOutput";
            //if (!Directory.Exists(dirPath))
            //{
            //    Directory.CreateDirectory(dirPath);
            //}

            //if (invoice != null)
            //{
            //    if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
            //    {
            //        var rptVM = new FinalInvoiceTemplateVM(id);
            //        var localReport = new LocalReport { ReportPath = rptVM.PathName };
            //        localReport.DataSources.Add(new ReportDataSource("Head", rptVM.HeaderList));
            //        localReport.DataSources.Add(new ReportDataSource("Lines", rptVM.LCPropertyList));
            //        var output = localReport.Render("EXCEL");
            //        string fileName = "FinalInvoice" + id + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            //        var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
            //        fs.Write(output, 0, output.Length);
            //        fs.Flush();
            //        fs.Close();

            //        Process.Start(dirPath + "\\" + fileName);
            //    }
            //    else if (invoice.InvoiceType == (int)CommercialInvoiceType.Provisional || invoice.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
            //    {
            //        var rptVM = new ProvisionalInvoiceTemplateVM(id);
            //        var localReport = new LocalReport { ReportPath = rptVM.PathName };
            //        localReport.DataSources.Add(new ReportDataSource("Head", rptVM.HeaderList));
            //        var output = localReport.Render("EXCEL");
            //        string fileName = "ProvisionalInvoice" + id + "-" + DateTime.Now.ToString("yyyyMMddhhmmss")  +".xls";
            //        var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
            //        fs.Write(output, 0, output.Length);
            //        fs.Flush();
            //        fs.Close();

            //        Process.Start(dirPath + "\\" + fileName);
            //    }
            //}
        }

        private void PrintDocumentExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            CommercialInvoice invoice = VM.GetInvoiceById(id);
            if (invoice != null)
            {
                //var documents = new PrintDocumentsTemplate(id, ModuleName);
                //RedirectTo(documents);
                string dirPath = "ReportOutput";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                var rptVM = new DocumentsTemplateVM(id);
                var localReport = new LocalReport { ReportPath = @"PrintTemplate\交单单据模板\交单单据报表.rdlc" };
                localReport.DataSources.Add(new ReportDataSource("Header", rptVM.HeaderList));
                var output = localReport.Render("EXCEL");
                string fileName = "InvoiceDocument" + id +"-" +DateTime.Now.ToString("yyyyMMddhhmmss")+ ".xls";
                var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
                fs.Write(output, 0, output.Length);
                fs.Flush();
                fs.Close();

                Process.Start(dirPath + "\\" + fileName);
            }
        }

        /// <summary>
        ///     Can view attachment?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        ///     View attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (!VM.HasAttachment(id))
            {
                MessageBox.Show(Properties.Resources.NoAttachment);
                return;
            }
            string code = VM.GetDocumentCode(id);
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show(Properties.Resources.NoAttachment);
                return;
            }
            var frm = new AttachmentList(id, code);
            frm.ShowDialog();
        }
    }
}