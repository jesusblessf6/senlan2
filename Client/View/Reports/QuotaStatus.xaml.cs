using System;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for QuotaStatus.xaml
    /// </summary>
    public sealed partial class QuotaStatus
    {
        #region Property

        public QuotaStatusVM VM { get; set; }
        public const int RecPerPage = 20;
        private readonly bool _canEdit;
        
        #endregion

        #region Contructor

        public QuotaStatus()
        {
            InitializeComponent();
            ModuleName = "QuotaStatusChange";
            VM = new QuotaStatusVM();
            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            _canEdit = CheckPerm(PageMode.EditMode);
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
            VM.LoadCount();
            pagingControl1.Init(VM.Count, RecPerPage);
        }

        #endregion

        #region Event

        private void ChangeStatusCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void ChangeStatusExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var quotaId = (int) e.Parameter;
            var qs = new QuotaStatusChange(quotaId);
            qs.Show();
        }

        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        {
            VM.From = e.From;
            VM.To = e.To;
            VM.Load();
            dataGrid1.ItemsSource = VM.Results;
            dataGrid1.Items.Refresh();
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Validate();
                pagingControl1.CurPageNo = 1;
                var waitingBox = new WaitingBox.WaitingBox();
                waitingBox.Show();
                VM.LoadCount();
                pagingControl1.Init(VM.Count, RecPerPage);
                waitingBox.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            VM.Reset();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Empty;

            if (VM.IdList != null && VM.IdList.Count > 0)
            {
                if (!string.IsNullOrEmpty(queryStr))
                {
                    queryStr += " and ";
                }

                queryStr += string.Format("(");
                for (int j = 0; j < VM.IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format(" it.Contract.InternalCustomerId = {0} ", VM.IdList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                }
                queryStr += string.Format(" )");
            }
            var dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null);
            dialog.ShowDialog();
            var selectedItem = (Quota) dialog.SelectedItem;
            if(selectedItem != null)
            {
                VM.QuotaId = selectedItem.Id;
                VM.QuotaNo = selectedItem.QuotaNo;
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var selectedItem = (BusinessPartner)dialog.SelectedItem;
            if (selectedItem != null)
            {
                VM.BusinessPartnerId = selectedItem.Id;
                VM.BusinessPartnerName = selectedItem.ShortName;
            }
        }

        #endregion
    }
}
