using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// LMEMarginReport.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LMEMarginReport
    {
        #region Property

        public LMEMarginReportVM VM { get; set; }

        #endregion

        #region Constructor

        public LMEMarginReport()
        {
            InitializeComponent();
            ModuleName = "LMEMarginReport";
            VM = new LMEMarginReportVM();
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
                VM.LoadNew();
                pOurGrid.ItemsSource = VM.POurs;
                pTheirGrid.ItemsSource = VM.PTheirs;
                sOurGrid.ItemsSource = VM.SOurs;
                sTheirGrid.ItemsSource = VM.STheirs;

                pOurGrid.Items.Refresh();
                pTheirGrid.Items.Refresh();
                sOurGrid.Items.Refresh();
                sTheirGrid.Items.Refresh();
                
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