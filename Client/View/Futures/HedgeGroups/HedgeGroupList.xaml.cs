using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Futures.HedgeGroups;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Futures.HedgeGroups
{
    /// <summary>
    /// Interaction logic for HedgeGroupList.xaml
    /// </summary>
    public sealed partial class HedgeGroupList
    {
        #region Property

        public HedgeGroupListVM VM { get; set; }
        private const int RecPerPage = 20;

        #endregion

        #region Constructor

        public HedgeGroupList(HedgeGroupConditions condition)
            :base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "HedgeGroup";
            VM = new HedgeGroupListVM(condition);
            VM.LoadCount();

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(VM.Count, RecPerPage);

            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        public override void Refresh()
        {
            pagingControl1.Init(VM.Count, RecPerPage);
        }

        #endregion

        #region Event

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo-1)*RecPerPage + e.Row.GetIndex() + 1;
        }

        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        {
            VM.From = e.From;
            VM.To = e.To;
            VM.Load();
            dataGrid1.ItemsSource = VM.HedgeGroups;
            dataGrid1.Items.Refresh();
        }

        private void HedgeGroupLinkCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void HedgeGroupLinkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            RedirectTo(new HedgeGroupDetail(PageMode.ViewMode, id));
            e.Handled = true;
        }

        private void HedgeGroupEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void HedgeGroupEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            RedirectTo(new HedgeGroupDetail(PageMode.EditMode, id));
            e.Handled = true;
        }

        private void HedgeGroupDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void HedgeGroupDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            try
            {
                if(MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    VM.DeleteById(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        #endregion

        
    }
}
