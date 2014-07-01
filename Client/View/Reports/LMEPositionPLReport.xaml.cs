using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for LMEPositionPLReport.xaml
    /// </summary>
    public sealed partial class LMEPositionPLReport
    {
        #region Property

        public LMEPositionPLReportVM VM { get; set; }

        #endregion

        #region Constructor

        public LMEPositionPLReport()
        {
            InitializeComponent();
            ModuleName = "LMEPositionPLReport";
            VM = new LMEPositionPLReportVM();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                VM.Validate();
                
                waitingBox.Show();

                VM.Load();
                VM.CalculateClosingPL();

                dataGrid1.ItemsSource = VM.Summaries;
                duedLockedGrid.ItemsSource = VM.DuedLockedDetails;
                unduedLockedGrid.ItemsSource = VM.UnduedLockedDetails;
                unduedFloatGrid.ItemsSource = VM.UnduedFloatDetails;
                dataGrid1.Items.Refresh();
                duedLockedGrid.Items.Refresh();
                unduedLockedGrid.Items.Refresh();
                unduedFloatGrid.Items.Refresh();

                
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

        #endregion
    }
}