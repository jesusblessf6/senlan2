using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Client.ViewModel.Finance.LCAllocations;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using Utility.QueryManagement;

namespace Client.View.Finance.LCAllocations
{
    /// <summary>
    /// Interaction logic for LCAllocationList.xaml
    /// </summary>
    public sealed partial class LCAllocationList
    {
        #region Member;

        private const int RecPerPage = 50;
        private readonly bool _canEdit;
        private readonly bool _canDelete;

        public LCAllocationListVM VM { get; set; }

        #endregion

        #region Constructor

        public LCAllocationList()
        {
            InitializeComponent();
            ModuleName = "LCAllocation";
            VM = new LCAllocationListVM(new List<QueryElement>());
            ((LCAllocationListVM)VM).LoadCount();

            rootGrid.DataContext = VM;

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(((LCAllocationListVM)VM).Count, RecPerPage);
        }

        public LCAllocationList(List<QueryElement> clauses)
        {
            InitializeComponent();
            ModuleName = "LCAllocation";

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);

            VM = new LCAllocationListVM(clauses);
            ((LCAllocationListVM)VM).LoadCount();

            rootGrid.DataContext = VM;

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(((LCAllocationListVM)VM).Count, RecPerPage);
        }

        #endregion

        #region Method

        public override void Refresh()
        {
            ((LCAllocationListVM)VM).LoadCount();
            pagingControl1.Init(((LCAllocationListVM)VM).Count, RecPerPage);
        }

        #endregion

        #region Event

        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        {
            ((LCAllocationListVM)VM).From = e.From;
            ((LCAllocationListVM)VM).To = e.To;
            ((LCAllocationListVM)VM).Load();
            dataGrid1.ItemsSource = ((LCAllocationListVM)VM).LCAllocations;
            dataGrid1.Items.Refresh();
        }

        private void DataGrid1_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = RecPerPage * (pagingControl1.CurPageNo - 1) + e.Row.GetIndex() + 1;
            if (((LCAllocation)e.Row.Item).IsCanceled)
            {
                e.Row.Foreground = Brushes.LavenderBlush;
            }
        }

        private void EditLCAllocationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void EditLCAllocationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            RedirectTo(new LCAllocationDetail(PageMode.EditMode, id));

            e.Handled = true;
        }

        private void DeleteLCAllocationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DeleteLCAllocationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;

            try
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    ((LCAllocationListVM)VM).RemoveById(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }

            e.Handled = true;
        }

        private void CancelLCAllocationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void CancelLCAllocationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            ((LCAllocationListVM)VM).CancelById(id);
            Refresh();
            e.Handled = true;
        }
        #endregion
    }
}
