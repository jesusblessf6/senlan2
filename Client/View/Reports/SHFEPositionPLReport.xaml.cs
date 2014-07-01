using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// SHFEPositionPLReport.xaml 的交互逻辑
    /// </summary>
    public sealed partial class SHFEPositionPLReport
    {
        #region Property

        public SHFEPositionPLReportVM VM { get; set; }

        #endregion

        #region Constructor

        public SHFEPositionPLReport()
        {
            InitializeComponent();
            ModuleName = "SHFEPositionPLReport";
            VM = new SHFEPositionPLReportVM();
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
            try
            {
                VM.Validate();
                var waitingBox = new WaitingBox.WaitingBox();
                waitingBox.Show();
                VM.Load(); 
                grid1.ItemsSource = VM.ShfePositionPNLView;
                grid2.ItemsSource = VM.SHFEHoldingPositionPNLView;
                grid1.Items.Refresh();
                grid2.Items.Refresh();
                waitingBox.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        #endregion
    }
}
