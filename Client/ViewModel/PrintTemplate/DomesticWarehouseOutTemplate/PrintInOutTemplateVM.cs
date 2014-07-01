using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Utility.ServiceManagement;
using Client.WarehouseOutServiceReference;
using DBEntity;
using Client.QuotaServiceReference;
using Client.WarehouseInServiceReference;
using System.Globalization;

namespace Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate
{
    public class PrintInOutTemplateVM : BaseVM
    {
        #region Member
        private List<InOutHeader> _Header;
        private List<InOutLines> _Lines;
        #endregion

        #region Property
        public List<InOutLines> Lines
        {
            get { return _Lines; }
            set { 
                if(_Lines != value)
                {
                    _Lines = value;
                    Notify("Lines");
                }
            }
        }

        public List<InOutHeader> Header
        {
            get { return _Header; }
            set { 
                if(_Header != value)
                {
                    _Header = value;
                    Notify("Header");
                }
            }
        }
        #endregion

        #region Contuctor
        public PrintInOutTemplateVM(int inOutID, string typeName)
        {
            Header = new List<InOutHeader>();
            Lines = new List<InOutLines>();
            if(typeName == "打印入库单")
            {
                GetInValue(inOutID);
            }
            else if(typeName == "打印出库单")
            {
                GetOutValue(inOutID);
            }
        }

        public void GetInValue(int inID)
        {
            using (
               var warehouseInService =
                   SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> { inID };

                List<WarehouseIn> list = warehouseInService.Select(str, parameters, new List<string> { 
                                                                                    "WarehouseInLines",
                                                                                    "WarehouseInLines.DeliveryLine.Delivery.Quota",
                                                                                    "WarehouseInLines.DeliveryLine.Delivery.Quota.Commodity",
                                                                                    "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract",
                                                                                    "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract.BusinessPartner",
                                                                                    "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract.InternalCustomer",
                                                                                    "Warehouse",
                                                                                    "WarehouseInLines.Brand",
                                                                                    "WarehouseInLines.Specification"
                                                                                                      });
                if(list != null && list.Count > 0)
                {
                    WarehouseIn warehouseIn = list[0];
                    FilterDeleted(warehouseIn.WarehouseInLines);
                    var header = new InOutHeader { 
                    InternalName = warehouseIn.WarehouseInLines[0].DeliveryLine.Delivery.Quota.Contract.InternalCustomer.Name,
                    ReportTitle = "采 购 入 库 单",
                    ContractNo = warehouseIn.WarehouseInLines[0].DeliveryLine.Delivery.Quota.Contract.ContractNo,
                    WarehouseName = warehouseIn.Warehouse.Name,
                    InOutDate = warehouseIn.WarehouseInDate == null ? "" : warehouseIn.WarehouseInDate.Value.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo),
                    BPartnerName = warehouseIn.WarehouseInLines[0].DeliveryLine.Delivery.Quota.Contract.BusinessPartner.Name,
                    Comment = warehouseIn.Comment,
                    CurrentUserName = CurrentUser.Name,
                    CurrentDate = DateTime.Now.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo)
                    };
                    decimal? totalQty = 0;
                    decimal? totalAmount = 0;
                    if(warehouseIn.WarehouseInLines != null && warehouseIn.WarehouseInLines.Count > 0)
                    {
                        int i = 1;
                        foreach(WarehouseInLine inLine in warehouseIn.WarehouseInLines)
                        {
                            if(!inLine.IsDeleted)
                            {
                                decimal? qty = 0;
                                decimal? price = 0;
                                decimal? amount = 0;
                                var line = new InOutLines();
                                line.No = i;
                                line.BrandName = inLine.Brand.Name;
                                line.SpecificationName = inLine.Specification.Name;
                                line.Unit = inLine.DeliveryLine.Delivery.Quota.Commodity.SHFEUnit;
                                qty = inLine.VerifiedQuantity;
                                line.Qty = string.Format("{0:#,##0.0000}", qty);
                                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                                {
                                    price = quotaService.GetPriceByQuotaPricing(inLine.DeliveryLine.Delivery.Quota.Id, CurrentUser.Id);
                                    line.Price = string.Format("{0:#,##0.00}", price);
                                }
                                amount = qty * price;
                                line.Amount = string.Format("{0:#,##0.00}", amount);
                                line.QuotaNo = inLine.DeliveryLine.Delivery.Quota.QuotaNo;
                                line.LineComment = inLine.Comment;
                                totalAmount += amount;
                                totalQty += qty;
                                i++;
                                Lines.Add(line);
                            }
                        }
                    }
                    header.TotalQty = string.Format("{0:#,##0.0000}", totalQty);
                    header.TotalAmount = string.Format("{0:#,##0.00}", totalAmount);
                    Header.Add(header);
                }
            }
        }

        public void GetOutValue(int outID)
        {
            using (
               var warehouseOutService =
                   SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> { outID };

                List<WarehouseOut> list = warehouseOutService.Select(str, parameters,
                                                                     new List<string>
                                                                         {
                                                                             "WarehouseOutLines",
                                                                             "Quota",
                                                                             "Quota.Commodity",
                                                                             "Quota.Contract",
                                                                             "Quota.Contract.BusinessPartner",
                                                                             "Quota.Contract.InternalCustomer",
                                                                             "Warehouse",
                                                                             "WarehouseOutLines.Brand",
                                                                             "WarehouseOutLines.Specification",
                                                                             "BusinessPartner"
                                                                         });

                if (list.Count > 0)
                {
                    WarehouseOut warehouseOut = list[0];
                    FilterDeleted(warehouseOut.WarehouseOutLines);
                    var header = new InOutHeader
                    {
                        InternalName = warehouseOut.Quota.Contract.InternalCustomer.Name,
                        BPartnerName = warehouseOut.Quota.Contract.BusinessPartner.Name,
                        ReportTitle = "销 售 出 库 单",
                        ContractNo = warehouseOut.Quota.Contract.ContractNo,
                        WarehouseName = warehouseOut.Warehouse.Name,
                        InOutDate = warehouseOut.WarehouseOutDate == null ? "" : warehouseOut.WarehouseOutDate.Value.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo),
                        Comment = warehouseOut.Comment,
                        CurrentUserName = CurrentUser.Name,
                        CurrentDate = DateTime.Now.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo)
                    };

                    decimal? totalQty = 0;
                    decimal? totalAmount = 0 ;
                    if(warehouseOut.WarehouseOutLines != null && warehouseOut.WarehouseOutLines.Count > 0)
                    {
                        int i = 1;
                        foreach(WarehouseOutLine outLine in warehouseOut.WarehouseOutLines)
                        {
                            if(!outLine.IsDeleted)
                            {
                                decimal? qty = 0;
                                decimal? price = 0;
                                decimal? amount = 0;
                                var line = new InOutLines();
                                line.No = i;
                                line.BrandName = outLine.Brand.Name;
                                line.SpecificationName = outLine.Specification.Name;
                                line.Unit = warehouseOut.Quota.Commodity.SHFEUnit;
                                qty = outLine.VerifiedQuantity;
                                line.Qty = string.Format("{0:#,##0.0000}",qty);
                                using(var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                                {
                                    price = quotaService.GetPriceByQuotaPricing(warehouseOut.Quota.Id, CurrentUser.Id);
                                    line.Price = string.Format("{0:#,##0.00}", price);
                                }
                                amount = qty * price;
                                line.Amount =string.Format("{0:#,##0.00}", amount);
                                line.QuotaNo = warehouseOut.Quota.QuotaNo;
                                line.LineComment = outLine.Comment;
                                totalAmount += amount;
                                totalQty += qty;
                                i++;

                                Lines.Add(line);
                            }
                        }
                    }
                    header.TotalQty = string.Format("{0:#,##0.0000}", totalQty);
                    header.TotalAmount = string.Format("{0:#,##0.00}", totalAmount);
                    Header.Add(header);
                }
            }
        }
        #endregion
    }

    public class InOutHeader
    {
        public string InternalName { get; set; }
        public string ReportTitle { get; set; }
        public string ContractNo { get; set; }
        public string WarehouseName { get; set; }
        public string InOutDate { get; set; }
        public string BPartnerName { get; set; }
        public string Comment { get; set; }
        public string CurrentUserName { get; set; }
        public string CurrentDate { get; set; }
        public string TotalQty { get; set; }
        public string TotalAmount { get; set; }
    }

    public class InOutLines
    {
        public int No { get; set; }
        public string BrandName { get; set; }
        public string SpecificationName { get; set; }
        public string Unit { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string QuotaNo { get; set; }
        public string LineComment { get; set; }
    }
}
