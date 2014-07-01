using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.SystemSetting.CommissionSetting;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.CommissionSetting
{
    /// <summary>
    /// Interaction logic for CommissionHome.xaml
    /// </summary>
    public sealed partial class CommissionHome
    {
        #region Property

        public CommissionHomeVM VM { get; set; }
        public BusinessPartner BusinessPartner { get; set; }

        #endregion

        public CommissionHome()
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            VM = new CommissionHomeVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            string str = null;
            if ((int) comboBox1.SelectedValue == (int) CommissionType.AgentCommission)
            {
                str = "it.CustomerType = 2";
            }
            else if (VM.SelectInternalCustomerID == (int) CommissionType.ClientCommission)
            {
                str = "it.CustomerType = 1";
            }

            var dialog = PopDialogCreater.CreateDialog("BusinessPartner", str, null);
            dialog.ShowDialog();
            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                VM.CustomerID = BusinessPartner.Id;
                VM.CustomerName = BusinessPartner.ShortName;
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            //客户佣金设置
            const int commissionType = (int) CommissionType.ClientCommission;
            var cd = new CommissionDetail(commissionType, false);
            RedirectTo(cd);
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            //经济行佣金设置
            const int commissionType = (int) CommissionType.AgentCommission;
            var cd = new CommissionDetail(commissionType, false);
            RedirectTo(cd);
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            //客户佣金默认
            const int commissionType = (int) CommissionType.ClientCommission;
            var dc = new DefaultCommissionDetail(commissionType, true);
            RedirectTo(dc);
        }

        private void Button6Click(object sender, RoutedEventArgs e)
        {
            VM.LoadSearch();
            var cs = new CommissionSearch(VM.SearchVM);
            RedirectTo(cs);
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            //经济行佣金默认
            const int commissionType = (int) CommissionType.AgentCommission;
            var dc = new DefaultCommissionDetail(commissionType, true);
            RedirectTo(dc);
        }
    }
}