using System.Windows.Controls;
using Client.ViewModel.Console.MonitorCenter;

namespace Client.View.Console.MonitorCenter
{
    /// <summary>
    /// Interaction logic for MonitorCenter.xaml
    /// </summary>
    public sealed partial class MonitorCenter
    {
        #region Property

        public MonitorCenterVM VM { get; set; }
        
        #endregion

        #region Constructor

        public MonitorCenter()
        {
            InitializeComponent();
            ModuleName = "MonitorCenter";
            VM = new MonitorCenterVM();
            VM.LoadPircingMonitor();
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

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        #endregion
    }
}
