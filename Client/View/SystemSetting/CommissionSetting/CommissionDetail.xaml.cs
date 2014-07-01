using System;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.SystemSetting.CommissionSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CommissionSetting
{
    /// <summary>
    /// Interaction logic for CommissionDetail.xaml
    /// </summary>
    public sealed partial class CommissionDetail
    {
        public CommissionDetail(int commissionType, bool isDefault)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            CDVM = new CommissionDetailVM(commissionType, isDefault);
            BindData();
        }

        public CommissionDetail(int commissionType, int commissionId, bool isDefault)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            CDVM = new CommissionDetailVM(commissionType, commissionId, isDefault);
            BindData();
        }

        public CommissionDetailVM CDVM { get; set; }

        public BusinessPartner BusinessPartner { get; set; }

        public override void BindData()
        {
            rootGrid.DataContext = CDVM;
            dataGrid1.DataContext = CDVM.AllCommissionLineList;
        }


        private void CommissionLineCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != 0;
            e.Handled = true;
        }

        private void CommissionLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                var cld = new CommissionLineDetail(id, PageMode.EditMode, CDVM.AllCommissionLineList,
                                                   CDVM.AddCommissionLineList, CDVM.UpdateCommissionLineList,
                                                   CDVM.IsDefault, CDVM.SelectInternalCustomerID, CDVM.CustomerID);
                cld.ShowDialog();
                Refresh();
            }
        }

        private void CommissionLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    CDVM.DelCommissionLine(id);
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

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            string str = null;
            if (CDVM.CommissionTypeValue == (int) CommissionType.AgentCommission)
            {
                str = "it.CustomerType = 2";
            }
            else if (CDVM.CommissionTypeValue == (int) CommissionType.ClientCommission)
            {
                str = "it.CustomerType = 1";
            }

            var dialog = PopDialogCreater.CreateDialog("BusinessPartner", str, null);
            dialog.ShowDialog();
            BusinessPartner = dialog.SelectedItem as BusinessPartner;
            if (BusinessPartner != null)
            {
                CDVM.CustomerID = BusinessPartner.Id;
                CDVM.CustomerName = BusinessPartner.ShortName;
            }
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CDVM.ValidateAdd())
                {
                    var cld = new CommissionLineDetail(PageMode.AddMode, CDVM.AllCommissionLineList,
                                                       CDVM.AddCommissionLineList, CDVM.IsDefault,
                                                       CDVM.SelectInternalCustomerID, CDVM.CustomerID);
                    cld.ShowDialog();
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        public override void Refresh()
        {
            dataGrid1.DataContext = CDVM.AllCommissionLineList;
            dataGrid1.Items.Refresh();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CDVM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                var ch = new CommissionHome();
                RedirectTo(ch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var ch = new CommissionHome();
            RedirectTo(ch);
        }
    }
}