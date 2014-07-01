using System;
using System.Data;
using System.Windows;
using Client.ViewModel.Reports;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for ExposureChart.xaml
    /// </summary>
    public sealed partial class ExposureChart
    {
        public ExposureChart()
        {
            InitializeComponent();
            ModuleName = "ExposureChart";
            ECVM = new ExposureChartVM();
            BindData();
        }

        public ExposureChartVM ECVM { get; set; }

        public override void BindData()
        {
            rootGrid.DataContext = ECVM;
            zedGraphControlLine.GraphPane.Title.IsVisible = false;
            zedGraphControlLine.GraphPane.XAxis.IsVisible = false;
            zedGraphControlLine.GraphPane.YAxis.IsVisible = false;
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                if (ECVM.Validate())
                {
                    zedGraphControlLine.GraphPane.CurveList.Clear();

                    
                    waitingBox.Show();

                    //ECVM.GetLine(zedGraphControlLine, ECVM.StartDate, ECVM.EndDate, ECVM.CommodityID,
                    //       ECVM.InternalCustomerID2, ECVM.ProportionValue);

                    ECVM.GetLineNew(zedGraphControlLine, ECVM.StartDate, ECVM.EndDate, ECVM.CommodityID,
                           ECVM.InternalCustomerID2, ECVM.ProportionValue);

                    zedGraphControlLine.AxisChange();
                    zedGraphControlLine.Invalidate();
                    dataGrid2.ItemsSource = ECVM.DT.AsDataView();
                    
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
    }
}