using System;
using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Futures.LME;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Futures.LME
{
    /// <summary>
    /// LMEPositionDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LMEPositionDetail
    {
        #region Property

        public LMEPositionDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public LMEPositionDetail()
        {
            InitializeComponent();
            ModuleName = "LMEPositionSetting";
            VM = new LMEPositionDetailVM();
            BindData();
        }

        public LMEPositionDetail(PageMode pageMode)
            :base(pageMode)
        {
            InitializeComponent();
            ModuleName = "LMEPositionSetting";
            VM = new LMEPositionDetailVM();
            BindData();
        }

        public LMEPositionDetail(int id, PageMode pageMode)
            :base(pageMode)
        {
            InitializeComponent();
            ModuleName = "LMEPositionSetting";
            VM = new LMEPositionDetailVM(id);
            BindData();
        }

        public LMEPositionDetail(LMEPositionDetailVM vm)
        {
            InitializeComponent();
            ModuleName = "LMEPositionSetting";
            if (vm == null)
                return;
            VM = vm;
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            ControlShow();
        }

        public void ControlShow()
        {
            if (VM.IsLMEAgent)
            {
                lbClient.Visibility = Visibility.Visible;
                lbClientCommission.Visibility = Visibility.Visible;
                lbClientPrice.Visibility = Visibility.Visible;
                txtClient.Visibility = Visibility.Visible;
                txtClientCommission.Visibility = Visibility.Visible;
                txtClientPrice.Visibility = Visibility.Visible;
                btnClient.Visibility = Visibility.Visible;
            }
            else
            {
                lbClient.Visibility = Visibility.Collapsed;
                lbClientCommission.Visibility = Visibility.Collapsed;
                lbClientPrice.Visibility = Visibility.Collapsed;
                txtClient.Visibility = Visibility.Collapsed;
                txtClientCommission.Visibility = Visibility.Collapsed;
                txtClientPrice.Visibility = Visibility.Collapsed;
                btnClient.Visibility = Visibility.Collapsed;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new LMEPositionHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            RedirectTo(new LMEPositionHome());
        }

        #endregion

        #region PopUpdialog

        private void BtnCustomerClick(object sender, RoutedEventArgs e)
        {
            string queryStr = string.Format("it.CustomerType={0}", (int) BusinessPartnerType.Customer);
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp == null) return;
            VM.SelectedBPartnerId = bp.Id;
            VM.BPartnerName = bp.ShortName;
        }

        private void BtnQoutaClick(object sender, RoutedEventArgs e)
        {
            string queryStr =
                string.Format(
                    "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and (it.Contract.TradeType={2} or it.Contract.TradeType={3})",
                    (int) ApproveStatus.Approved, (int) ApproveStatus.NoApproveNeeded, (int) TradeType.ShortForeignTrade,
                    (int) TradeType.LongForeignTrade);
            if (VM.IdList != null && VM.IdList.Count > 0)
            {
                queryStr += string.Format(" and (");
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
            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as Quota;
            if (bp == null) return;
            VM.SelectedQuotaId = bp.Id;
            VM.QuotaNo = bp.QuotaNo;
        }

        #endregion
    }
}