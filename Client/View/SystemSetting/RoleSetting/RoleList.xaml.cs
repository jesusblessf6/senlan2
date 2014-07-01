using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.RoleSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.RoleSetting
{
    /// <summary>
    /// Interaction logic for RoleList.xaml
    /// </summary>
    public sealed partial class RoleList
    {
        #region Property

        public RoleListVM VM { get; set; }

        #endregion

        #region Member

        private readonly bool _canAdd;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;

        #endregion

        #region Constructor

        public RoleList()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";

            _canAdd = CheckPerm(PageMode.AddMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            button1.IsEnabled = _canAdd;

            VM = new RoleListVM();
            VM.Load();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            dataGrid1.ItemsSource = VM.Roles;
        }

        public override void Refresh()
        {
            VM.Load();
            dataGrid1.ItemsSource = VM.Roles;
            dataGrid1.Items.Refresh();
            base.Refresh();
        }

        #endregion

        #region Event

        private void EditRoleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void EditRoleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var roleId = (int) e.Parameter;
            var rd = new RoleDetail(roleId, PageMode.EditMode);
            rd.Show();
            e.Handled = true;
        }

        private void DeleteRoleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void DeleteRoleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 &&
                MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteRole(id);
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
            var rd = new RoleDetail(PageMode.AddMode);
            rd.Show();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void EditPermCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void EditPermExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var roleId = (int) e.Parameter;
            RedirectTo(new RolePerms(roleId, PageMode.EditMode));
            e.Handled = true;
        }

        private void ViewRoleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var roleId = (int) e.Parameter;
            var rd = new RoleDetail(roleId, PageMode.ViewMode);
            rd.Show();

            e.Handled = true;
        }

        private void ViewRoleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void ViewPermCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void ViewPermExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var roleId = (int) e.Parameter;
            RedirectTo(new RolePerms(roleId, PageMode.ViewMode));

            e.Handled = true;
        }

        #endregion
    }
}