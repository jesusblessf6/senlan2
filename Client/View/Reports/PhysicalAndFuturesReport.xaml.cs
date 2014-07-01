using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// PhysicalAndFuturesReport.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PhysicalAndFuturesReport
    {
        #region Property

        public PhysicalAndFuturesReportVM VM { get; set; }

        #endregion

        #region Constructor

        public PhysicalAndFuturesReport()
        {
            InitializeComponent();
            ModuleName = "PhysicalAndFuturesReport";
            VM = new PhysicalAndFuturesReportVM();
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
                dataGridSHFE.ItemsSource = VM.SHFEPositionPLReportVM.ShfePositionPNLView;
                dataGridSHFE.Items.Refresh();
                dataGridLME.ItemsSource = VM.ListLmeView;
                dataGridLME.Items.Refresh();
                //现货内贸
                dataGridPhysicalDomestic.ItemsSource = VM.DomesticPhysicalPNLItemList;
                dataGridPhysicalDomestic.Items.Refresh();
                //现货外贸
                dataGridPhysicalExternal.ItemsSource = VM.ExternalPhysicalPNLItemList;
                dataGridPhysicalExternal.Items.Refresh();
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
