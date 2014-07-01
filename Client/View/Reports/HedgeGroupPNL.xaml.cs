using System.Windows;
using System.Windows.Controls;
using Client.ViewModel.Reports;
using Utility.Controls;
using Utility.ErrorManagement;
using System;
using Infralution.Localization.Wpf;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for HedgeGroupPNL.xaml
    /// </summary>
    public sealed partial class HedgeGroupPNL
    {
        #region Property

        public HedgeGroupPNLVM VM { get; set; }
        private const int RecPerPage = 15;

        #endregion

        #region Constructor

        public HedgeGroupPNL()
        {
            InitializeComponent();
            ModuleName = "HedgeGroupFloatPNLReport";
            VM = new HedgeGroupPNLVM();
            pagingControl1.OnNewPage += OnOnNewPage;
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

        private void Query(object sender, RoutedEventArgs e)
        {
             var waitingBox = new WaitingBox.WaitingBox();
             try
             {
                 waitingBox.Show();
                 VM.BuildQuery();
                 VM.LoadCount();
                 pagingControl1.CurPageNo = 1;
                 pagingControl1.Init(VM.RecCount, RecPerPage);
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

        private void OnOnNewPage(object sender, PagingEventArgs e)
        {
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                waitingBox.Show();
                VM.From = e.From;
                VM.To = e.To;
                VM.Load();
                BindData();
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

        private void OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * RecPerPage + e.Row.GetIndex() + 1;
        }

        #endregion   
    }
}
