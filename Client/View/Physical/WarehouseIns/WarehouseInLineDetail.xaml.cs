using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Client.View.PopUpDialog;
using Client.ViewModel.Physical.WarehouseIns;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.WarehouseIns
{
    /// <summary>
    ///     Interaction logic for WarehouseInLineDetail.xaml
    /// </summary>
    public sealed partial class WarehouseInLineDetail
    {
        #region Property

        public DeliveryLine DeliveryLine { get; set; }
        public DeliveryTypeWarehouseIn DeliveryTypeWarehouseIn { get; set; }
        public WarehouseInLineDetailVM WVM { get; set; }

        #endregion

        #region Constructor

        public WarehouseInLineDetail(DeliveryTypeWarehouseIn d, PageMode pageMode, List<WarehouseInLine> lines,
                                     List<WarehouseInLine> addLines, int commodityId)
            : base(pageMode, ResWarehouseIn.WarehouseInLine)
        {
            InitializeComponent();
            ModuleName = "WarehouseInHome";
            DeliveryTypeWarehouseIn = d;
            WVM = new WarehouseInLineDetailVM(d, lines, addLines, commodityId);
            BindData();
        }

        public WarehouseInLineDetail(DeliveryTypeWarehouseIn d, int warehouseInlineId, PageMode pageMode,
                                     List<WarehouseInLine> lines, List<WarehouseInLine> addLines,
                                     List<WarehouseInLine> updateLines, int commodityId)
            : base(pageMode, ResWarehouseIn.WarehouseInLine)
        {
            InitializeComponent();
            ModuleName = "WarehouseInHome";
            WVM = new WarehouseInLineDetailVM(d, warehouseInlineId, lines, addLines, updateLines, commodityId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = WVM;
        }

        #endregion

        #region Event

        //todo: Re-write later
        private void Button4Click(object sender, RoutedEventArgs e)
        {
            string queryStr;
            if (WVM.DeliveryTypeWarehouseIn == DeliveryTypeWarehouseIn.InternalWarehouseIn)
            {
                queryStr =
                    "it.DeliveryStatus = false and (it.Delivery.DeliveryType = @p1 or it.Delivery.DeliveryType = @p2) and (it.Delivery.ApproveStatus = @p5 or it.Delivery.ApproveStatus = @p6) and it.Delivery.Quota.Commodity.Id = @p7";
            }
            else
            {
                queryStr =
                    "it.DeliveryStatus = false and it.Delivery.IsCustomed = true and (it.Delivery.DeliveryType = @p3 or it.Delivery.DeliveryType = @p4) and (it.Delivery.WarrantId is null or (it.Delivery.WarrantId is not null and it.Delivery.DeliveryType =" + (int)DeliveryType.ExternalTDWW + ")) and (it.Delivery.ApproveStatus = @p5 or it.Delivery.ApproveStatus = @p6) and it.Delivery.Quota.Commodity.Id = @p7";
            }

            if (WVM.IdList != null && WVM.IdList.Count > 0)
            {
                queryStr += string.Format(" and (");
                for (int j = 0; j < WVM.IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format(" it.Delivery.Quota.Contract.InternalCustomerId = {0} ", WVM.IdList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Delivery.Quota.Contract.InternalCustomerId = {0}", WVM.IdList[j]);
                    }
                }
                queryStr += string.Format(" )");
            }

            var parameters = new List<object>
                                 {
                                     (int) DeliveryType.InternalTDBOL,
                                     (int) DeliveryType.InternalTDWW,
                                     (int) DeliveryType.ExternalTDBOL,
                                     (int) DeliveryType.ExternalTDWW,
                                     (int) ApproveStatus.Approved,
                                     (int) ApproveStatus.NoApproveNeeded,
                                     WVM.SelectedCommodityId
                                 };

            //var list = new List<string>
            //               {
            //                   "Delivery",
            //                   "Delivery.Quota.Commodity",
            //                   "Delivery.Quota.CommodityType",
            //                   "Brand",
            //                   "Specification",
            //                   "WarehouseInLines",
            //                   "SalesDeliveryLines"
            //               };
            //PopDialog dialog = PopDialogCreater.CreateDialog("DeliveryLine", queryStr, parameters, list);
            PopDialog dialog = PopDialogCreater.CreateDialog("DeliveryLine", queryStr, parameters);
            dialog.ShowDialog();
            DeliveryLine = dialog.SelectedItem as DeliveryLine;
            if (DeliveryLine != null)
            {
                WVM.SelectedCommodityName = DeliveryLine.Delivery.Quota.Commodity.Name;
                //WVM.SelectedCommodityId = DeliveryLine.Delivery.Quota.Commodity.Id;
                WVM.DeliveryNo = DeliveryLine.Delivery.DeliveryNo;
                WVM.DeliveryLineId = DeliveryLine.Id;
                WVM.DeliveryLine = DeliveryLine;
                WVM.IsVerified = DeliveryLine.IsVerified;
                WVM.SelectedCommodityTypeId = DeliveryLine.CommodityTypeId == null
                                                  ? 0
                                                  : (int)DeliveryLine.CommodityTypeId;
                WVM.BrandId = DeliveryLine.BrandId == null ? 0 : (int)DeliveryLine.BrandId;
                WVM.SpecificationId = DeliveryLine.SpecificationId == null ? 0 : (int)DeliveryLine.SpecificationId;
                WVM.LoadCommodityType();
                comboBox1.SelectedValue = WVM.SelectedCommodityTypeId;
                comboBox2.SelectedValue = WVM.BrandId;
                comboBox3.SelectedValue = WVM.SpecificationId;
                if (WVM.DeliveryTypeWarehouseIn == DeliveryTypeWarehouseIn.InternalWarehouseIn)
                {
                    WVM.Quantity = DeliveryLine.OnlyQty ?? 0;
                }
                else if (WVM.DeliveryTypeWarehouseIn == DeliveryTypeWarehouseIn.ExternalWarehouseIn)
                {
                    WVM.Quantity = DeliveryLine.OnlyGrossWeight ?? 0;
                }
                WVM.VerifiedQuantity = DeliveryLine.OnlyVerfiedQty ?? 0;
                WVM.PackingQuantity = DeliveryLine.OnlyPackingQuantity ?? 0;
                //WVM.GetTDOnlyQty(DeliveryLine.Id);
            }
        }


        private void BtSave(object sender, RoutedEventArgs e)
        {
            try
            {
                WVM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}