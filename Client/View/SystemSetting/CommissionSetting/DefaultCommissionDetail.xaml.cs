using System;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.CommissionSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CommissionSetting
{
    /// <summary>
    /// Interaction logic for DefaultCommissionDetail.xaml
    /// </summary>
    public sealed partial class DefaultCommissionDetail
    {
        public DefaultCommissionDetail(int commissionType, bool isDefault)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            VM = new DefaultCommissionDetailVM(commissionType, isDefault);
            BindData();
        }

        public DefaultCommissionDetail(int commissionID, int commissionType, bool isDefault)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            VM = new DefaultCommissionDetailVM(commissionID, commissionType, isDefault);
            BindData();
        }

        public DefaultCommissionDetailVM VM { get; set; }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.DataContext = VM.AllCommissionLineList;
        }

        public override void Refresh()
        {
            dataGrid1.DataContext = VM.AllCommissionLineList;
            dataGrid1.Items.Refresh();
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
                var cld = new CommissionLineDetail(id, PageMode.EditMode, VM.AllCommissionLineList,
                                                   VM.AddCommissionLineList, VM.UpdateCommissionLineList,
                                                   VM.IsDefault, VM.SelectInternalCustomerID, 0);
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
                    VM.DelCommissionLine(id);
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
            if (VM.ValidateAdd())
            {
                var cld = new CommissionLineDetail(PageMode.AddMode, VM.AllCommissionLineList,
                                                   VM.AddCommissionLineList, VM.IsDefault,
                                                   VM.SelectInternalCustomerID, 0);
                cld.ShowDialog();
                Refresh();
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
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