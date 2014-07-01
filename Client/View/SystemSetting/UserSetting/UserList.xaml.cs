using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.UserSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.UserSetting
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public sealed partial class UserList
    {
        #region Property

        public UserListVM VM { get; set; }

        #endregion

        #region Member

        private const int UserPerPage = 10;
        private readonly bool _canAdd;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;

        #endregion

        #region Constructor

        public UserList()
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            _canAdd = CheckPerm(PageMode.AddMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            button1.IsEnabled = _canAdd;

            VM = new UserListVM();

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(VM.UserCount, UserPerPage);
        }

        #endregion

        #region Event

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void EditUserCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void EditUserExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var userId = (int) e.Parameter;
            var ud = new UserDetail(PageMode.EditMode, userId);
            ud.Show();
            e.Handled = true;
        }

        private void ViewUserCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void ViewUserExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var userId = (int) e.Parameter;
            var ud = new UserDetail(PageMode.ViewMode, userId);
            ud.Show();
            e.Handled = true;
        }

        private void DeleteUserCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DeleteUserExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteUser(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var ud = new UserDetail(PageMode.AddMode);
            ud.Show();
        }

        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs pagingEventArgs)
        {
            VM.UserFrom = pagingEventArgs.From;
            VM.UserTo = pagingEventArgs.To;
            VM.Load();
            dataGrid1.ItemsSource = VM.Users;
            dataGrid1.Items.Refresh();
        }

        private void LinkCommodityCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void LinkCommodityExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var lc = new LinkCommodity(PageMode.ViewMode, id);
            RedirectTo(lc);
            e.Handled = true;
        }

        private void LinkICCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void LinkICExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var ic = new LinkIC(PageMode.ViewMode, id);
            RedirectTo(ic);
            e.Handled = true;
        }

        #endregion

        #region Method

        public override void BindData()
        {
            dataGrid1.ItemsSource = VM.Users;
        }

        public override void Refresh()
        {
            VM.LoadCount();
            pagingControl1.Init(VM.UserCount, UserPerPage);
        }

        #endregion
    }
}