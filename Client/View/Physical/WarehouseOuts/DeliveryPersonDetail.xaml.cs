using System;
using System.Collections.Generic;
using System.Windows;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseOuts;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.WarehouseOuts
{
    /// <summary>
    /// Interaction logic for DeliveryPersonDetail.xaml
    /// </summary>
    public sealed partial class DeliveryPersonDetail
    {
        #region Constructor

        public DeliveryPersonDetail(List<WarehouseOutDeliveryPerson> allDeliveryPerson,
                                    List<WarehouseOutDeliveryPerson> addDeliveryPerson, PageMode pageMode)
            : base(pageMode, ResWarehouseOut.DeliveryPersonInfo)
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            PDVM = new DeliveryPersonDetailVM(allDeliveryPerson, addDeliveryPerson);
            BindData();
        }

        public DeliveryPersonDetail(int deliveryPersonID, List<WarehouseOutDeliveryPerson> allDeliveryPerson,
                                    List<WarehouseOutDeliveryPerson> addDeliveryPerson,
                                    List<WarehouseOutDeliveryPerson> updateDeliveryPerson, PageMode pageMode)
            : base(pageMode, ResWarehouseOut.DeliveryPersonInfo)
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            PDVM = new DeliveryPersonDetailVM(deliveryPersonID, allDeliveryPerson, addDeliveryPerson,
                                              updateDeliveryPerson);
            BindData();
        }

        #endregion

        #region Property

        public DeliveryPersonDetailVM PDVM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = PDVM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PDVM.Save();
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
            if(dp == null)
                return;

            PDVM.Name = dp.Name;
            PDVM.IdentityCard = dp.IdNo;
            PDVM.VehicleNo = dp.VehicleNo;
            PDVM.Tel = dp.Tel;
        }

        #endregion
    }
}