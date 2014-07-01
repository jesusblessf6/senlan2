using System;
using System.Data;
using System.Windows;
using Client.ViewModel.Console.DashBoardChart;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Console.DashBoard
{
    /// <summary>
    /// Interaction logic for DashBoardChart.xaml
    /// </summary>
    public sealed partial class DashBoardChart
    {
        #region Property

        public DashBoardChartVM VM { get; set; }

        #endregion

        #region Constructor

        public DashBoardChart()
        {
            InitializeComponent();
            ModuleName = "DashboardChart";
            VM = new DashBoardChartVM();
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
                zedGraphControl.GraphPane.CurveList.Clear();
                waitingBox.Show();
                VM.SortedOverlayBar(zedGraphControl);
                zedGraphControl.AxisChange();
                zedGraphControl.Invalidate();
                dataGrid1.Visibility = Visibility.Visible;
                dataGrid1.ItemsSource = VM.GetInventoryTable().AsDataView();
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

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                if (VM.SearchValidate())
                {
                    zedGraphControlBar.GraphPane.CurveList.Clear();
                    waitingBox.Show();
                    VM.GetAmountNew(zedGraphControlBar, VM.StartDate, VM.EndDate, VM.InternalCustomerID3);
                    zedGraphControlBar.AxisChange();
                    zedGraphControlBar.Invalidate();
                    dataGrid3.Visibility = Visibility.Visible;
                    dataGrid3.ItemsSource = VM.DT.AsDataView();
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

        #endregion
    }
}