using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity;
using DBEntity.EnumEntity;
using System;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// PaymentUsageDetail.xaml 的交互逻辑
    /// </summary>
    public sealed partial class PaymentUsageDetail
    {
        #region Constructor

        public PaymentUsageDetail()
            : base(PageMode.ViewMode, Properties.Resources.PaymentUsage)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PaymentUsageVM();
            BindData();
        }

        public PaymentUsageDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.PaymentUsage)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PaymentUsageVM();
            BindData();
        }

        public PaymentUsageDetail(PageMode pageMode, int paymentusageId)
            : base(pageMode, Properties.Resources.PaymentUsage)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new PaymentUsageVM(paymentusageId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region PopUpdialog

        private void BtnFinancialAccountClick(object sender, RoutedEventArgs e)
        {
            var dialog = new TreeViewDialog();
            dialog.ShowDialog();
            var fa = dialog.SelectedItems as FinancialAccount;
            if (fa != null)
            {
                ((PaymentUsageVM)VM).FinancialAccountId = fa.Id;
                ((PaymentUsageVM)VM).FinancialAccountName = fa.Name;
            }
        }

        #endregion

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((PaymentUsageVM)VM).Validate())
                {
                    VM.Save();
                    MessageBox.Show(Properties.Resources.SaveSuccessfully);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
    }
}