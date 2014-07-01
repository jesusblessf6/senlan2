using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Client.ViewModel.Reports;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;
using DBEntity;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for ForwardPositionReport.xaml
    /// </summary>
    public sealed partial class ForwardPositionReport
    {
        public ForwardPositionReportVM FPVM { get; set; }

        public ForwardPositionReport()
        {
            InitializeComponent();
            ModuleName = "ForwardPositionReport";
            FPVM = new ForwardPositionReportVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = FPVM;
            zedGraphControlLine.GraphPane.Title.IsVisible = false;
            zedGraphControlLine.GraphPane.XAxis.IsVisible = false;
            zedGraphControlLine.GraphPane.YAxis.IsVisible = false;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                if (FPVM.Validate1())
                {
                    zedGraphControlLine.GraphPane.CurveList.Clear();
                    waitingBox.Show();
                    FPVM.GetLMELine(zedGraphControlLine, FPVM.SelectedCommodityID, FPVM.SelectedInternalID, FPVM.SelectedBrokerID);
                    zedGraphControlLine.AxisChange();
                    zedGraphControlLine.Invalidate();
                    zedGraphControlLine.IsShowPointValues = true;
                    dataGrid1.DataContext = FPVM.LMEList;
                    dataGrid1.Items.Refresh();
                }
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

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                if (FPVM.Validate2())
                {
                    zedGraphControlLine1.GraphPane.CurveList.Clear();
                    waitingBox.Show();
                    FPVM.GetSHFELine(zedGraphControlLine1, FPVM.SelectedCommodityID1, FPVM.SelectedInternalID1, FPVM.SelectedBrokerID1);
                    zedGraphControlLine1.AxisChange();
                    zedGraphControlLine1.Invalidate();
                    zedGraphControlLine1.IsShowPointValues = true;
                    dataGrid2.DataContext = FPVM.SHFEList;
                    dataGrid2.Items.Refresh();
                }
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

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var item = e.Row.DataContext as LMEExposureDetailLine;

            if (item != null)
            {
                if (item.Title == "-1")
                {
                    e.Row.Background = Brushes.SteelBlue;
                    e.Row.FontSize = 15;
                    e.Row.Foreground = Brushes.Orange;
                }
                else
                {
                    e.Row.Background = Brushes.White;
                    e.Row.Foreground = Brushes.Black;
                    e.Row.FontSize = 13;
                }
            }
        }
    }
}
