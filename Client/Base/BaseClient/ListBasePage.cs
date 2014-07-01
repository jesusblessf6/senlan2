using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.Base.BaseClientVM;
using Utility.Controls;
using DBEntity.EnumEntity;

namespace Client.Base.BaseClient
{
    /// <summary>
    /// Base Class of List Page
    /// </summary>
    public class ListBasePage : BasePage
    {
        #region Property

        public ListBaseVM VM { get; set; }
        public virtual int RecPerPage
        {
            get { return 10; }
        }

        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }
        public DataGrid EntityList { get; set; }
        public PagingControl Pager { get; set; }

        public virtual bool IsLazy
        {
            get { return false; }
        }

        #endregion

        #region Constrcutor

        protected ListBasePage(string moduleName)
        {
            ModuleName = moduleName;
            CanEdit = CheckPerm(PageMode.EditMode);
            CanDelete = CheckPerm(PageMode.DeleteMode);
            CanView = CheckPerm(PageMode.ViewMode);

            Loaded += OnLoaded;
        }

        protected ListBasePage()
        {
            ModuleName = "";
            CanEdit = true;
            CanDelete = true;
            CanView = true;

            Loaded += OnLoaded;
        }

        #endregion

        #region Event

        protected virtual void OnNewPage(object sender, PagingEventArgs e)
        {
            VM.From = e.From;
            VM.To = e.To;

            if (IsLazy)
            {
                VM.LoadListLazy();
            }
            else
            {
                VM.LoadList();
            }
            

            if (EntityList != null)
            {
                EntityList.ItemsSource = VM.Entities;
                EntityList.Items.Refresh();
            }
        }

        protected virtual void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            VM.GetRecCount();
            EntityList = (DataGrid)FindName("entityList");
            Pager = (PagingControl)FindName("pager");

            if (Pager != null)
            {
                Pager.OnNewPage += OnNewPage;
                Pager.Init(VM.TotalCount, RecPerPage);
            }
        }

        protected virtual void OnLoadRowIndex(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (Pager.CurPageNo - 1) * RecPerPage + e.Row.GetIndex() + 1;
        }

        protected virtual void ListDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanDelete;
            e.Handled = true;
        }

        protected virtual void ListEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanEdit;
            e.Handled = true;
        }

        protected virtual void ListViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanView;
            e.Handled = true;
        }

        protected virtual void ListDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            try
            {
                if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Reminder,
                                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    VM.Remove(id);
                    MessageBox.Show(Properties.Resources.OperationSucceed);
                    Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.OperationFailed);
            }
        }

        protected virtual void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        protected virtual void ListViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        #endregion

        #region Method

        public override void Refresh()
        {
            VM.GetRecCount();
            Pager.Init(VM.TotalCount, RecPerPage);
        }

        #endregion
    }
}
