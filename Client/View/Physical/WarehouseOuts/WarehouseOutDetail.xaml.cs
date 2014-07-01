using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseOuts;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.WarehouseOuts
{
    /// <summary>
    /// Interaction logic for WarehouseOutDetail.xaml
    /// </summary>
    public sealed partial class WarehouseOutDetail
    {
        #region Property

        public Quota Quota { get; set; }
        public Warehouse Warehouse { get; set; }
        public WarehouseOutDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public WarehouseOutDetail()
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            VM = new WarehouseOutDetailVM();
            BindData();
        }

        public WarehouseOutDetail(int id)
        {
            InitializeComponent();
            ModuleName = "WarehouseOutHome";
            VM = new WarehouseOutDetailVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            VM.SetQty(VM.WarehouseOutLines);
            dataGrid1.DataContext = VM.Lines;
            dataGrid1.Items.Refresh();
        }

        public override void Refresh()
        {
            VM.SetQty(VM.WarehouseOutLines);
            dataGrid1.DataContext = VM.Lines;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            string queryStr = "it.Contract.ContractType = @p1 and it.DeliveryStatus = false and (it.Contract.TradeType = @p2 or it.Contract.TradeType = @p3) and (it.ApproveStatus = @p4 or it.ApproveStatus = @p5)";
            if (VM.IdList != null && VM.IdList.Count > 0)
            {
                queryStr += " and (";
                for (int j = 0; j < VM.IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format("it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Contract.InternalCustomerId = {0}", VM.IdList[j]);
                    }
                }
                queryStr += ")";
            }
            var parameters = new List<object>
                                 {
                                     (int) ContractType.Sales,
                                     (int) TradeType.ShortDomesticTrade,
                                     (int) TradeType.LongDomesticTrade,
                                     (int) ApproveStatus.Approved,
                                     (int) ApproveStatus.NoApproveNeeded
                                 };
            var list = new List<string> {"Specification","Contract.BusinessPartner","Contract.InternalCustomer","QuotaBrandRels",};
            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, parameters, null,null,0,0,false,list);
            dialog.ShowDialog();
            Quota = dialog.SelectedItem as Quota;
            if (Quota != null)
            {
                VM.QuotaId = Quota.Id;
                VM.QuotaNo = Quota.QuotaNo;
                VM.BPId = Quota.Contract.BPId ?? 0;
                VM.CommodityId = Quota.CommodityId ?? 0;
                VM.CommodityName = Quota.Commodity.Name;
                VM.InternalCustomerID = Quota.Contract.InternalCustomerId ?? 0;
                VM.BusinessPartnerId = Quota.Contract.BusinessPartner.Id;
                VM.BusinessPartnerName = Quota.Contract.BusinessPartner.ShortName;
                if (Quota.Warehouse != null)
                {
                    VM.WarehouseId = Quota.Warehouse.Id;
                    VM.WarehouseName = Quota.Warehouse.Name;
                }
                else 
                {
                    VM.WarehouseId = 0;
                    VM.WarehouseName = null;
                }
                VM.ContractInfo = Quota.ContractInfo;
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            Warehouse = dialog.SelectedItem as Warehouse;
            if (Warehouse != null)
            {
                VM.WarehouseId = Warehouse.Id;
                VM.WarehouseName = Warehouse.Name;
            }
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VM.ValidateAdd())
                {
                    var wd = new WarehouseOutLineDetail(VM.QuotaId, PageMode.AddMode, VM.WarehouseOutLines,
                                                        VM.WarehouseInLines, VM.AddWarehouseOutLines,
                                                        VM.InternalCustomerID, VM.WarehouseId);
                    wd.ShowDialog();
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void WarehouseOutLineCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            e.CanExecute = id != 0;
            e.Handled = true;
        }

        private void WarehouseOutLineEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0)
            {
                var wd = new WarehouseOutLineDetail(VM.CommodityId, id, PageMode.EditMode, VM.WarehouseOutLines,
                                                    VM.AddWarehouseOutLines, VM.UpdateWarehouseOutLines,
                                                    VM.WarehouseInLines, VM.InternalCustomerID, VM.WarehouseId);
                wd.ShowDialog();
                Refresh();
            }
        }

        private void WarehouseOutLineDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DelWarehouseOutLine(id);
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

        private void Button6Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                var wh = new WarehouseOutHome();
                RedirectTo(wh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            var wh = new WarehouseOutHome();
            RedirectTo(wh);
        }

        #endregion

        private void Button7Click(object sender, RoutedEventArgs e)
        {
            string queryStr = "it.CustomerType=" + (int)BusinessPartnerType.Customer + " or it.CustomerType=" + (int)BusinessPartnerType.InternalCustomer;
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                VM.BusinessPartnerName = bp.ShortName;
                VM.BusinessPartnerId = bp.Id;
            }
        }
    }
}