using System;
using System.Windows;
using Client.ViewModel.Reports;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;

namespace Client.View.Reports
{
    /// <summary>
    /// Interaction logic for BusinessPartnerContractOrder.xaml
    /// </summary>
    public sealed partial class BusinessPartnerContractOrder
    {
        public BusinessPartnerContractOrderVM VM { get; set; }

        public BusinessPartnerContractOrder()
        {
            InitializeComponent();
            ModuleName = "BusinessPartnerContractOrder";
            VM = new BusinessPartnerContractOrderVM();
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            VM.ContractTypeId = Convert.ToInt32(comboBox2.SelectedValue);
            var waitingBox = new WaitingBox.WaitingBox();
            try
            {
                if (VM.Validate())
                {
                    waitingBox.Show();
                    VM.GetData();
                    dataGrid1.DataContext = VM.ContractOrderList;
                    dataGrid1.Items.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            finally
            {
                waitingBox.Close();
            }
        }
    }
}
