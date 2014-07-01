using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for SHFEFundFlowReport.xaml
    /// </summary>
    public sealed partial class SHFEFundFlowReport
    {
        private const int RecordPerPage = 15;
        public SHFEFundFlowReportVM VM { get; set; }
        public SHFEFundFlowReport()
        {
            InitializeComponent();
            ModuleName = "SHFEFundFlowReport";
            VM=new SHFEFundFlowReportVM();
            pagingControl1.OnNewPage += pager_OnNewPage;
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGridSHFEFundFlow.ItemsSource = VM.SHFEFundFlows;
            dataGridSHFEFundFlow.Items.Refresh();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                waitingBox.Show();
                VM.To = 0;
                VM.From = RecordPerPage;
                VM.Search();
                pagingControl1.CurPageNo = 1;
                pagingControl1.Init(VM.Count, RecordPerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
        }

        private void pager_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.From = e.From;
            VM.To = e.To;
            VM.LoadSHFEFundFlow();
            dataGridSHFEFundFlow.ItemsSource = VM.SHFEFundFlows;
            dataGridSHFEFundFlow.Items.Refresh();
        }
    }
}
