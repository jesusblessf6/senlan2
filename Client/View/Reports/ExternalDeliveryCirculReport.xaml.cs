using System;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for ExternalDeliveryCirculReport.xaml
    /// </summary>
    public sealed partial class ExternalDeliveryCirculReport
     {
        #region Property

        public ExternalDeliveryCirculReportVM VM { get; set; }

        #endregion

        #region Constructor

        public ExternalDeliveryCirculReport()
        {
            InitializeComponent();
            ModuleName = "BLCirculReport";
            VM = new ExternalDeliveryCirculReportVM();
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
                dataGrid1.ItemsSource = VM.CirculView;
                dataGrid1.Items.Refresh();
                
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

        #region PopUpdialog

        /// <summary>
        /// 客户弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            VM.ShowCustomerDialog();
        }

        #endregion
    }
}
