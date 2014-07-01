using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.ApprovalSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.ApprovalSetting
{
    /// <summary>
    /// Interaction logic for ApprovalList.xaml
    /// </summary>
    public partial class ApprovalList
    {
        #region Property

        private const int ApprovalPerPage = 10;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;
        public ApprovalListVM VM { get; set; }

        #endregion

        #region Constructor

        public ApprovalList()
        {
            InitializeComponent();
            VM = new ApprovalListVM();
            ModuleName = "ApprovalSetting";
            button1.IsEnabled = CheckPerm(PageMode.AddMode);

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(VM.ApprovalCount, ApprovalPerPage);
        }

        #endregion

        #region Event

        /// <summary>
        /// new page event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pagingEventArgs"></param>
        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs pagingEventArgs)
        {
            VM.ApprovalFrom = pagingEventArgs.From;
            VM.ApprovalTo = pagingEventArgs.To;
            VM.Load();
            dataGrid1.ItemsSource = VM.Approvals;
            dataGrid1.Items.Refresh();
        }

        /// <summary>
        /// whether able to view approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        /// <summary>
        /// view approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            var av = new ApprovalDetail(PageMode.ViewMode, id);
            av.Show();
            e.Handled = true;
        }

        /// <summary>
        /// whether able to edit approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        /// <summary>
        /// edit approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;

            if (!VM.CanEdit(id))
            {
                MessageBox.Show(ResApprovalSetting.UsedApprovalLimit);
                return;
            }

            var av = new ApprovalDetail(PageMode.EditMode, id);
            av.Show();
            e.Handled = true;
        }

        /// <summary>
        /// whether able to delete approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        /// <summary>
        /// delete approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            if (!VM.CanDelete(id))
            {
                MessageBox.Show(ResApprovalSetting.UsingApprovalLimit);
                return;
            }

            if (id > 0 && MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.Nullify, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteApproval(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
            }

            e.Handled = true;
        }

        /// <summary>
        /// add new approval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var ad = new ApprovalDetail(PageMode.AddMode);
            ad.Show();
        }

        /// <summary>
        /// set the line no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1)*ApprovalPerPage + e.Row.GetIndex() + 1;
        }

        #endregion

        #region Method

        /// <summary>
        /// Bind Data
        /// </summary>
        public override void BindData()
        {
        }

        /// <summary>
        /// Refresh page
        /// </summary>
        public override void Refresh()
        {
            VM.LoadCount();
            pagingControl1.Init(VM.ApprovalCount, ApprovalPerPage);
        }

        #endregion
    }
}