using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.ViewModel.Physical.Deliveries;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    /// NewImportDeliveryEdit.xaml 的交互逻辑
    /// </summary>
    public sealed partial class NewImportDeliveryEdit
    {
        public NewImportDeliveryEditVM NVM { get; set; }

        public NewImportDeliveryEdit(int PID, List<DeliveryLine> addLineList, List<Delivery> deliveryList, PageMode pageMode)
            : base(pageMode, "编辑")
        {
            InitializeComponent();
            ModuleName = "PurchaseDelivery";
            NVM = new NewImportDeliveryEditVM(PID, addLineList, deliveryList);
            BindData();
        }

        public override void BindData()
        {
            grid.DataContext = NVM;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                NVM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
    }
}
