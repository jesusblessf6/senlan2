using System;
using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    ///     Interaction logic for DeliveryPersonMsg.xaml
    /// </summary>
    public sealed partial class DeliveryPersonMsg
    {
        #region Property

        public DeliveryPersonMsgVM DPVM { get; set; }

        #endregion

        public DeliveryPersonMsg(List<WarehouseOutDeliveryPerson> allDeliveryPerson,
                                 List<WarehouseOutDeliveryPerson> addDeliveryPerson, PageMode pageMode,
                                 string moduleName)
            : base(pageMode, "新增提货人信息")
        {
            InitializeComponent();
            ModuleName = moduleName;
            DPVM = new DeliveryPersonMsgVM(allDeliveryPerson, addDeliveryPerson);
            BindData();
        }

        public DeliveryPersonMsg(int deliveryPersonID, List<WarehouseOutDeliveryPerson> allDeliveryPerson,
                                 List<WarehouseOutDeliveryPerson> addDeliveryPerson,
                                 List<WarehouseOutDeliveryPerson> updateDeliveryPerson, PageMode pageMode,
                                 string moduleName)
            : base(pageMode, "编辑提货人信息")
        {
            InitializeComponent();
            ModuleName = moduleName;
            DPVM = new DeliveryPersonMsgVM(deliveryPersonID, allDeliveryPerson, addDeliveryPerson,
                                           updateDeliveryPerson);
            BindData();
        }

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = DPVM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DPVM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("DeliveryPerson");
            dialog.ShowDialog();
            var dp = dialog.SelectedItem as DeliveryPerson;
            if (dp == null) return;

            DPVM.Name = dp.Name;
            DPVM.IdentityCard = dp.IdNo;
            DPVM.VehicleNo = dp.VehicleNo;
            DPVM.Tel = dp.Tel;
        }

        #endregion
    }
}