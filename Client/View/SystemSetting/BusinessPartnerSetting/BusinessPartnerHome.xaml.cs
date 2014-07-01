using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.BusinessPartnerSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.BusinessPartnerSetting
{
    /// <summary>
    /// Interaction logic for BusinessPartnerHome.xaml
    /// todo: remove the search state/ searchbuttonclicked, 
    /// add query string and parameters to VM. 
    /// only when the button click, the two will update.
    /// </summary>
    public sealed partial class BusinessPartnerHome
    {
        #region Member

        private const int BusinessPartnerPerPage = 10;
        private readonly bool _canDelete;
        private readonly bool _canEdit;
        private readonly bool _canView;
        private bool _searchBtnClicked;

        #endregion

        #region Property

        public BusinessPartnerHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public BusinessPartnerHome()
        {
            InitializeComponent();
            ModuleName = "BusinessPartnerSetting";
            VM = new BusinessPartnerHomeVM();

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            pgPartners.OnNewPage += pgPartners_OnNewPage;
            pgPartners.Init(VM.PartnerTotalCount, BusinessPartnerPerPage);
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
            bool state = GetSearchState();
            VM.SearchState = state;
            VM.LoadPartnerCount();
            pgPartners.Init(VM.PartnerTotalCount, BusinessPartnerPerPage);
        }

        public bool GetSearchState()
        {
            if ((txtName.Text.Trim() == string.Empty && comboBoxType.SelectedIndex == 0) || !_searchBtnClicked)
            {
                _searchBtnClicked = false;
                return false;
            }

            return true;
        }

        #endregion

        #region Event

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            var businessPartnerDetail = new BusinessPartnerDetail(PageMode.AddMode);
            businessPartnerDetail.Show();
        }

        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            _searchBtnClicked = txtName.Text.Trim() != string.Empty || comboBoxType.SelectedIndex != 0;
            VM.SearchPartners(_searchBtnClicked);
            pgPartners.Init(VM.PartnerTotalCount, BusinessPartnerPerPage);
        }

        private void DataGridPartnerLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pgPartners.CurPageNo - 1)*BusinessPartnerPerPage + e.Row.GetIndex() + 1;
        }

        private void pgPartners_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.PartnerForm = e.From;
            VM.PartnerTo = e.To;
            bool state = GetSearchState();
            VM.LoadPartners(state);
            dataGridPartner.ItemsSource = VM.Partners;
            dataGridPartner.Items.Refresh();
        }

        private void PartnerEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                var editForm = new BusinessPartnerDetail(id, PageMode.EditMode);
                editForm.Show();
            }
        }

        private void PartnerDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.Remove(id);
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

        private void PartnerEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PartnerDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PartnerViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void PartnerViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                var editForm = new BusinessPartnerDetail(id, PageMode.ViewMode);
                editForm.Show();
            }
            e.Handled = true;
        }

        #endregion
    }
}