using System.Collections.Generic;
using System.Windows;
using Client.CommercialInvoiceServiceReference;
using Client.Converters;
using Client.DeliveryLineServiceReference;
using Client.DeliveryServiceReference;
using Client.LetterOfCreditServiceReference;
using Client.UnpricingServiceReference;
using Client.UserServiceReference;
using Client.WarehouseInLineServiceReference;
using Client.WarehouseServiceReference;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.BankServiceReference;
using Client.BusinessPartnerServiceReference;
using Utility.Misc;

namespace Client.View.PopUpDialog
{
    public class PopDialogCreater
    {
        #region Member

        private static readonly Dictionary<string, PopDialogInfo> DocPopMap;

        #endregion

        #region Method

        public static PopDialog CreateDialog(string documentType)
        {
            var info = DocPopMap[documentType];
            if (null == info)
                return null;

            return new PopDialog(info.Title, info.Columns, info.Conditions,
                info.SvcClientType, info.ServiceType, info.InnerQueryStr, null, info.EagerLoadListForFilter, 0, 0, false, info.EagerLoadListForAppend, info.SortCols) { WindowStartupLocation = WindowStartupLocation.CenterScreen };
        }

        public static PopDialog CreateDialog(string documentType, string queryStr, List<object> parameters, List<string> forFilter = null, string title = null, int filterId = 0, int contentId = 0, bool selectedMode = false, List<string> forAppend = null, List<SortCol> sortCols = null)
        {
            var info = DocPopMap[documentType];
            if (null == info)
                return null;
            if (info.EagerLoadListForFilter == null)
                info.EagerLoadListForFilter = new List<string>();
            if (info.EagerLoadListForAppend == null)
                info.EagerLoadListForAppend = new List<string>();
            if (info.SortCols == null)
                info.SortCols = new List<SortCol>();
            if (forFilter != null)
            {
                foreach (var item in forFilter)
                {
                    if (!info.EagerLoadListForFilter.Contains(item))
                    {
                        info.EagerLoadListForFilter.Insert(0, item);
                    }
                }
            }

            if (forAppend != null)
            {
                foreach (var item in forAppend)
                {
                    if (!info.EagerLoadListForAppend.Contains(item))
                    {
                        info.EagerLoadListForAppend.Insert(0, item);
                    }
                }
            }
            if (sortCols != null)
            {
                info.SortCols = sortCols;
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                info.Title = title;
            }

            string fullQueryStr;
            if (!string.IsNullOrWhiteSpace(queryStr) && !string.IsNullOrWhiteSpace(info.InnerQueryStr))
            {
                fullQueryStr = "(" + queryStr + ") and (" + info.InnerQueryStr + ")";
            }
            else
            {
                fullQueryStr = queryStr + info.InnerQueryStr;
            }

            return new PopDialog(info.Title, info.Columns, info.Conditions,
                info.SvcClientType, info.ServiceType, fullQueryStr, parameters, info.EagerLoadListForFilter, filterId, contentId, selectedMode, info.EagerLoadListForAppend, info.SortCols) { WindowStartupLocation = WindowStartupLocation.CenterScreen };
        }

        #endregion

        #region Constructor

        //Condition no more than 2
        static PopDialogCreater()
        {
            DocPopMap = new Dictionary<string, PopDialogInfo>
                            {
                                {"Bank", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>{new ColumnInfo {Header = Properties.Resources.BankName, Path = "Name"},
                                                                                        new ColumnInfo {Header = "SWIFT", Path = "Code"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Address, Path = "Address"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Comments, Path = "Description"}},
                                                        Title = ResPopDialog.SelectBank,
                                                        Conditions = new Dictionary<string, string> {{Properties.Resources.BankName, "Name"}},
                                                        SvcClientType = typeof(BankServiceClient),
                                                        ServiceType = SvcType.BankSvc,
                                                        InnerQueryStr = "it.IsDeleted = false",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "Created",ByDescending = true}}
                                                    }
                                },
                                {"BusinessPartner", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>{new ColumnInfo {Header = SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting.BPShortName, Path = "ShortName"},
                                                                                        new ColumnInfo {Header = SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting.BPCode, Path = "Code"},
                                                                                        new ColumnInfo {Header = SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting.BPFullName, Path = "Name"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Comments, Path = "Remark"}},
                                                        Title = ResPopDialog.SelectBP,
                                                        Conditions = new Dictionary<string, string> {{ResPopDialog.BPName, "ShortName"}},
                                                        SvcClientType = typeof(BusinessPartnerServiceClient),
                                                        ServiceType = SvcType.BusinessPartnerSvc,
                                                        InnerQueryStr = "it.IsDeleted = false and (it.ApproveStatus = " + (int)ApproveStatus.Approved + " or it.ApproveStatus = " + (int)ApproveStatus.NoApproveNeeded + ")",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "Created",ByDescending = true}}
                                                    }
                                },
                                {"Quota", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>{new ColumnInfo {Header = Properties.Resources.QuotaNo, Path = "QuotaNo"},
                                                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Contract.BusinessPartner.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.SignSide, Path = "Contract.InternalCustomer.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "Commodity.Name"},
                                                                                        new ColumnInfo {Header = Properties.Resources.CommodityType, Path = "CommodityType.Name"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "TotalBrands"},
                                                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.ShortName, Path = "TotalWarehouseName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Quantity, Path = "Quantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                        new ColumnInfo {Header = Properties.Resources.ActualQuantity, Path = "VerifiedQuantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                        new ColumnInfo {Header = "单价", Path = "FinalPrice", StringFormat = RoundRules.STR_PRICE},
                                                                                        new ColumnInfo {Header = "金额", Path = "QuotaAmount", StringFormat = RoundRules.STR_AMOUNT},
                                                                                        new ColumnInfo {Header = "币种", Path = "Currency.Name"},
                                                                                        //new ColumnInfo {Header = "流转信息", Path = "RelQuotaStr"}
                                                        },
                                                        
                                                        Title = Properties.Resources.SelectQuota,
                                                        Conditions = new Dictionary<string,string>{{Properties.Resources.QuotaNo, "QuotaNo"}, {Properties.Resources.BP, "Contract.BusinessPartner.ShortName"}},
                                                        SvcClientType = typeof(QuotaServiceReference.QuotaServiceClient),
                                                        ServiceType = SvcType.QuotaSvc,
                                                        EagerLoadListForFilter = new List<string>{"Contract"},
                                                        EagerLoadListForAppend = new List<string>{"Commodity", "Brand", "Contract.BusinessPartner", "Contract.InternalCustomer", "Warehouse", "Currency"},
                                                        InnerQueryStr = "it.IsDraft = false",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "Created",ByDescending = true}}
                                                    }
                                },
                                {"Warehouse", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.ShortName, Path = "Name"},
                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.FullName, Path = "FullName"},
                                                        new ColumnInfo {Header = Properties.Resources.Address, Path = "Address"},
                                                        new ColumnInfo {Header = Properties.Resources.ContactPerson, Path = "ContactPerson"},
                                                        new ColumnInfo {Header = Properties.Resources.Tel, Path = "Phone"}
                                                    },
                                                    Title = ResPopDialog.SelectWarehouse,
                                                    Conditions = new Dictionary<string,string>{{ResPopDialog.WarehouseName, "Name"}},
                                                    SvcClientType = typeof(WarehouseServiceClient),
                                                    ServiceType = SvcType.WarehouseSvc,
                                                    InnerQueryStr = "it.IsDeleted = false",
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "Name",ByDescending = false}}
                                                }
                                },
                                {"Unpricing", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.QuotaNo, Path = "Quota.QuotaNo"},
                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "Quota.Commodity.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "Quota.Brand.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Quota.Contract.BusinessPartner.ShortName"},
                                                        new ColumnInfo {Header = Properties.Resources.SignSide, Path = "Quota.Contract.InternalCustomer.ShortName"},
														new ColumnInfo {Header = Properties.Resources.QuotaQuantity, Path = "Quota.Quantity", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.UnpricingQuantity, Path = "UnpricingQuantity", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.PricingStartDate, Path = "StartPricingDate", StringFormat = "yyyy-MM-dd"},
                                                        new ColumnInfo {Header = Properties.Resources.PricingEndDate, Path = "EndPricingDate", StringFormat = "yyyy-MM-dd"},
                                                        new ColumnInfo {Header = ResPopDialog.DeferFeeOccurred, Path = "DeferFee", StringFormat = RoundRules.STR_AMOUNT},
                                                        //new ColumnInfo {Header = "流转信息", Path = "Quota.RelQuotaStr"},                                                 
                                                    },
                                                    Title = ResPopDialog.SelectUnpricedQuota,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.QuotaNo, "Quota.QuotaNo"}, {Properties.Resources.BP, "Quota.Contract.BusinessPartner.ShortName"}},
                                                    SvcClientType = typeof(UnpricingServiceClient),
                                                    ServiceType = SvcType.UnpricingSvc,
                                                    EagerLoadListForFilter = new List<string>{"Quota", "Quota.Contract"},
                                                    EagerLoadListForAppend = new List<string>{"Quota.Commodity", "Quota.Brand", "Quota.Contract.BusinessPartner", "Quota.Contract.InternalCustomer"},
                                                    InnerQueryStr = "(it.Quota.ApproveStatus = " + (int)ApproveStatus.Approved + " or it.Quota.ApproveStatus = " + (int)ApproveStatus.NoApproveNeeded + ") and it.IsAutoGenerated = false",
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "Quota.ImplementedDate",ByDescending = true}}
                                                }
                                },
                                {"LetterOfCredit", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.LoCNo, Path = "LCNo"},
                                                        new ColumnInfo {Header = Properties.Resources.LoCAmount, Path = "IssueAmount",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = Properties.Resources.LCPresentAmount, Path = "PresentAmount",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = Properties.Resources.LoCCurrency, Path = "Currency.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.LCInterest, Path = "Interest", StringFormat = RoundRules.STR_AMOUNT}
                                                    },
                                                    Title = ResPopDialog.SelectLoC,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.LoCNo, "LCNo"}},
                                                    SvcClientType = typeof(LetterOfCreditServiceClient),
                                                    ServiceType = SvcType.LetterOfCreditSvc,
                                                    EagerLoadListForAppend = new List<string>{"Currency","LCCIRels"},
                                                    InnerQueryStr = "it.IsDeleted = false",
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "IssueDate",ByDescending = true}}
                                                }
                                },
                                {"TDelivery", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.QuotaNo, Path = "Quota.QuotaNo"},
                                                        new ColumnInfo {Header = Properties.Resources.BLNo, Path = "DeliveryNo"},
                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Quota.Contract.BusinessPartner.ShortName"},
                                                        new ColumnInfo {Header = Properties.Resources.IssuingDate, Path = "IssueDate", StringFormat = "yyyy-MM-dd"},
                                                        new ColumnInfo {Header = Properties.Resources.NetWeight, Path = "TotalNetWeight", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.GrossWeight, Path = "TotalGrossWeight", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.ActualQuantity, Path = "TotalQuantity", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "DeliveryLines/CommodityType.Commodity.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.CommodityType, Path = "DeliveryLines/CommodityType.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "TotalBrands"},
                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.ShortName, Path = "Warehouse.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.BLType, Path = "DeliveryType", Converter = new DeliveryTypeConverter()},
                                                        new ColumnInfo {Header = "价格", Path = "Quota.FinalPrice", StringFormat = RoundRules.STR_PRICE},
                                                        //new ColumnInfo {Header = "流转信息", Path = "Quota.RelQuotaStr"}
                                                    },
                                                    Title = ResPopDialog.SelectDelivery,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.BLNo, "DeliveryNo"},{"批次号","Quota.QuotaNo"}},
                                                    SvcClientType = typeof(DeliveryServiceClient),
                                                    ServiceType = SvcType.DeliverySvc,
                                                    EagerLoadListForFilter = new List<string>{"Quota", "Quota.Contract"},
                                                    EagerLoadListForAppend = new List<string>{"DeliveryLines.CommodityType","DeliveryLines.CommodityType.Commodity","DeliveryLines.Brand", "Quota.Contract.BusinessPartner","DeliveryLines.SalesDeliveryLines","DeliveryLines.WarehouseInLines", "DeliveryLines","Warehouse"},
                                                    InnerQueryStr = "it.IsDraft = false",
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "IssueDate",ByDescending = true}}
                                                }
                                },
                                {"Delivery", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.BLNo, Path = "DeliveryNo"},
                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Quota.Contract.BusinessPartner.ShortName"},
                                                        new ColumnInfo {Header = Properties.Resources.IssuingDate, Path = "IssueDate",StringFormat = "yyyy-MM-dd"},
                                                        new ColumnInfo {Header = Properties.Resources.NetWeight, Path = "TotalNetWeight",StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.GrossWeight, Path = "TotalGrossWeight",StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.Quantity, Path = "TotalQuantity",StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "DeliveryLines/CommodityType.Commodity.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "TotalBrands"},
                                                        new ColumnInfo {Header = Properties.Resources.BLType, Path = "DeliveryType", Converter = new DeliveryTypeConverter()}
                                                    },
                                                    Title = ResPopDialog.SelectDelivery,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.BLNo, "DeliveryNo"}},
                                                    SvcClientType = typeof(DeliveryServiceClient),
                                                    ServiceType = SvcType.DeliverySvc,
                                                    EagerLoadListForAppend = new List<string>{"DeliveryLines.CommodityType","DeliveryLines.CommodityType.Commodity","DeliveryLines.Brand","Quota", "Quota.Contract", "Quota.Contract.BusinessPartner", "DeliveryLines","Quota.Brand"},
                                                    InnerQueryStr = "it.IsDraft = false",
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "IssueDate",ByDescending = true}}
                                                }
                                },
                                {"DeliveryLine", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.BLNo, Path = "Delivery.DeliveryNo"},
                                                        new ColumnInfo {Header = Properties.Resources.IssuingDate, Path = "Delivery.IssueDate",StringFormat = "yyyy-MM-dd"},
                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "CommodityType.Name"},
                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "Brand.Name"},
                                                        new ColumnInfo {Header = "剩余数量", Path = "OnlyQty", StringFormat = RoundRules.STR_QUANTITY},
                                                        //new ColumnInfo {Header = Properties.Resources.GrossWeight, Path = "GrossWeight", StringFormat = RoundRules.STR_QUANTITY}, 目前仅用在入库处，不需要显示毛重
                                                        new ColumnInfo {Header = "剩余实际数量", Path = "OnlyVerfiedQty", StringFormat = RoundRules.STR_QUANTITY},
                                                        new ColumnInfo {Header = "剩余捆数", Path = "OnlyPackingQuantity", StringFormat = RoundRules.STR_QUANTITY}
                                                    },
                                                    Title = ResPopDialog.SelectDeliveryLine,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.BLNo, "Delivery.DeliveryNo"}},
                                                    SvcClientType = typeof(DeliveryLineServiceClient),
                                                    ServiceType = SvcType.DeliveryLineSvc,
                                                    InnerQueryStr = "it.IsDeleted = false",
                                                    EagerLoadListForFilter = new List<string>{"Delivery","Delivery.Quota","Delivery.Quota.Commodity","Delivery.Quota.Contract"},
                                                    EagerLoadListForAppend = new List<string>{"Delivery.Quota.CommodityType","Brand","Specification","WarehouseInLines","SalesDeliveryLines"}
                                                }
                                },
                                {"ProvisionalInvoice", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.ProvisionalInvoiceNo, Path = "InvoiceNo"},
                                                        new ColumnInfo {Header = "结算金额", Path = "Amount",StringFormat = RoundRules.STR_AMOUNT},
                                                         new ColumnInfo {Header = "利息", Path = "TotleInterest",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = Properties.Resources.Currency, Path = "Currency.Name"}
                                                    },
                                                    Title = ResPopDialog.SelectProvisionalInvoice,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.ProvisionalInvoiceNo, "InvoiceNo"}},
                                                    SvcClientType = typeof(CommercialInvoiceServiceClient),
                                                    ServiceType = SvcType.CommercialInvoiceSvc,
                                                    EagerLoadListForAppend = new List<string>{"Quota","Currency","Deliveries","Deliveries.DeliveryLines","LCCIRels","LCCIRels.LetterOfCredit"},
                                                    InnerQueryStr = "it.InvoiceType = " + (int) CommercialInvoiceType.Provisional,
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "InvoicedDate",ByDescending = true}}
                                                }
                                },
                                {"User", new PopDialogInfo
                                                 {
                                                    Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = Properties.Resources.Name, Path = "Name"},
                                                        new ColumnInfo {Header = Properties.Resources.LoginName, Path = "LoginName"},
                                                        new ColumnInfo {Header = Properties.Resources.Comments, Path = "Description"}
                                                    },
                                                    Title = ResPopDialog.SelectUser,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.Name, "Name"}},
                                                    SvcClientType = typeof(UserServiceClient),
                                                    InnerQueryStr = "it.IsDeleted = false",
                                                    ServiceType = SvcType.UserSvc
                                                 }  
                                },
                                {"WarehouseInLine", new PopDialogInfo
                                                {
                                                    Columns = new List<ColumnInfo>
                                                                    {
                                                                        new ColumnInfo {Header = Properties.Resources.CardNo, Path = "PBNo"},
                                                                        new ColumnInfo {Header = Properties.Resources.Quantity, Path = "Quantity",StringFormat = RoundRules.STR_QUANTITY},
                                                                        new ColumnInfo {Header = Properties.Resources.ActualQuantity, Path = "VerifiedQuantity",StringFormat = RoundRules.STR_QUANTITY},
                                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "DeliveryLine.Delivery.Quota.Commodity.Name"},
                                                                        new ColumnInfo {Header = Properties.Resources.CommodityType, Path = "CommodityType.Name"},
                                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "Brand.Name"},
                                                                        new ColumnInfo {Header = Properties.Resources.Specification, Path = "Specification.Name"},
                                                                        new ColumnInfo {Header = Properties.Resources.Bundle, Path = "PackingQuantity",StringFormat = RoundRules.STR_QUANTITY},
                                                                        new ColumnInfo {Header = "剩余捆数", Path = "OnlyPackingQty",StringFormat = RoundRules.STR_QUANTITY},
                                                                        new ColumnInfo {Header = Properties.Resources.QuantityRemain, Path = "OnlyQuantity",StringFormat = RoundRules.STR_QUANTITY}
                                                                    },
                                                    Title = ResPopDialog.SelectWarehouseInLine,
                                                    Conditions = new Dictionary<string,string>{{Properties.Resources.CardNo, "PBNo"}},
                                                    SvcClientType = typeof(WarehouseInLineServiceClient),
                                                    InnerQueryStr = "it.IsDeleted = false",
                                                    ServiceType = SvcType.WarehouseInLineSvc,
                                                    EagerLoadListForFilter = new List<string>{"DeliveryLine.Delivery.Quota","DeliveryLine.Delivery.Quota.Contract","WarehouseIn"},
                                                    EagerLoadListForAppend = new List<string>{"DeliveryLine.Delivery.Quota.Commodity","CommodityType","Brand","Specification","WarehouseOutLines"}
                                                }

                                },
                                 {"QuotaForPayment", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>{new ColumnInfo {Header = Properties.Resources.QuotaNo, Path = "QuotaNo"},
                                                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Contract.BusinessPartner.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.SignSide, Path = "Contract.InternalCustomer.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "Commodity.Name"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "TotalBrands"},
                                                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.ShortName, Path = "TotalWarehouseName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Quantity, Path = "Quantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                        new ColumnInfo {Header = Properties.Resources.ActualQuantity, Path = "VerifiedQuantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                         new ColumnInfo {Header = "已申请金额", Path = "TotalRequestAmount" , StringFormat = RoundRules.STR_AMOUNT}
                                                        },
                                                        
                                                        Title = Properties.Resources.SelectQuota,
                                                        Conditions = new Dictionary<string,string>{{Properties.Resources.QuotaNo, "QuotaNo"}, {Properties.Resources.BP, "Contract.BusinessPartner.ShortName"}},
                                                        SvcClientType = typeof(QuotaServiceReference.QuotaServiceClient),
                                                        ServiceType = SvcType.QuotaSvc,
                                                        EagerLoadListForFilter = new List<string>{"Contract"},
                                                        EagerLoadListForAppend = new List<string>{ "Commodity", "Brand", "Contract.BusinessPartner", "Contract.InternalCustomer", "Warehouse"},
                                                        InnerQueryStr = "it.IsDraft = false",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "Created",ByDescending = true}}
                                                    }
                                },
                                {"DeliveryPerson", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>
                                                                      {
                                                                          new ColumnInfo{Header = "名称", Path = "Name"},
                                                                          new ColumnInfo{Header = "车号", Path = "VehicleNo"},
                                                                          new ColumnInfo{Header = "身份证", Path = "IdNo"},
                                                                          new ColumnInfo{Header = "备注", Path = "Comments"}
                                                                      },
                                                        Title = "选择提货人",
                                                        Conditions = new Dictionary<string, string>{{"名称", "Name"}},
                                                        SvcClientType = typeof(DeliveryPersonServiceReference.DeliveryPersonServiceClient),
                                                        ServiceType = SvcType.DeliveryPersonSvc,
                                                        InnerQueryStr = "it.IsDeleted = false",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "Name",ByDescending = false}}
                                                    }},
                                {"ForeignDeliveryPool", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>
                                                                      {
                                                                          new ColumnInfo{Header = "标识号", Path = "MarkNo"},
                                                                          new ColumnInfo{Header = "提单号", Path = "DeliveryNo"},
                                                                          new ColumnInfo{Header = "类型", Path = "DeliveryType", Converter = new DeliveryTypeConverter()},
                                                                          new ColumnInfo{Header = "开具日期", Path = "IssueDate", StringFormat = "yyyy-MM-dd"},
                                                                          new ColumnInfo{Header = "金属", Path = "Commodity.Name"},
                                                                          new ColumnInfo{Header = "净重", Path = "TotalNetWeight", StringFormat = RoundRules.STR_QUANTITY},
                                                                          new ColumnInfo{Header = "毛重", Path = "TotalGrossWeight", StringFormat = RoundRules.STR_QUANTITY},
                                                                          new ColumnInfo{Header = "捆数", Path = "TotalPackingQuantity", StringFormat = RoundRules.STR_INTEGER}
                                                                      },
                                                        Title = "提单池",
                                                        Conditions = new Dictionary<string, string>{{"提单号", "DeliveryNo"}, {"标识号", "MarkNo"}},
                                                        SvcClientType = typeof(ForeignDeliveryPoolServiceReference.ForeignDeliveryPoolServiceClient),
                                                        ServiceType = SvcType.ForeignDeliveryPoolSvc,
                                                        InnerQueryStr = "it.IsDeleted = false",
                                                        EagerLoadListForAppend = new List<string>{"Commodity", "Shipper", "ShippingParty", "NotifyParty", "ForeignDeliveryPoolLines", 
                                                            "ForeignDeliveryPoolLines.CommodityType", "ForeignDeliveryPoolLines.Specification", 
                                                            "ForeignDeliveryPoolLines.OriginCountry", "ForeignDeliveryPoolLines.Brand", "WarehouseProvider", "Warehouse"},
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "IssueDate",ByDescending = true}}
                                                    }
                                },
                                 {"QuotaForVATInvoice", new PopDialogInfo
                                                    {
                                                        Columns = new List<ColumnInfo>{new ColumnInfo {Header = Properties.Resources.QuotaNo, Path = "QuotaNo"},
                                                                                        new ColumnInfo {Header = Properties.Resources.BP, Path = "Contract.BusinessPartner.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.SignSide, Path = "Contract.InternalCustomer.ShortName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Commodity, Path = "Commodity.Name"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Brand, Path = "TotalBrands"},
                                                                                        new ColumnInfo {Header = SystemSetting.WarehouseSetting.ResWarehouseSetting.ShortName, Path = "TotalWarehouseName"},
                                                                                        new ColumnInfo {Header = Properties.Resources.Quantity, Path = "Quantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                        new ColumnInfo {Header = Properties.Resources.ActualQuantity, Path = "VerifiedQuantity", StringFormat = RoundRules.STR_QUANTITY},
                                                                                        new ColumnInfo {Header = "单价", Path = "FinalPrice", StringFormat = RoundRules.STR_PRICE},
                                                                                        new ColumnInfo {Header = "金额", Path = "QuotaAmount", StringFormat = RoundRules.STR_AMOUNT},
                                                                                        new ColumnInfo {Header = "币种", Path = "Currency.Name"},
                                                                                        new ColumnInfo {Header = "开/收票日期", Path = "VATInvoiceDate", StringFormat = "yyyy-MM-dd"},
                                                                                        //new ColumnInfo {Header = "流转信息", Path = "RelQuotaStr"}
                                                        },
                                                        
                                                        Title = Properties.Resources.SelectQuota,
                                                        Conditions = new Dictionary<string,string>{{Properties.Resources.QuotaNo, "QuotaNo"}, {Properties.Resources.BP, "Contract.BusinessPartner.ShortName"}},
                                                        SvcClientType = typeof(QuotaServiceReference.QuotaServiceClient),
                                                        ServiceType = SvcType.QuotaSvc,
                                                        EagerLoadListForFilter = new List<string>{"Contract"},
                                                        EagerLoadListForAppend = new List<string>{"Commodity", "Brand", "Contract.BusinessPartner", "Contract.InternalCustomer", "QuotaBrandRels", "QuotaBrandRels.Brand","QuotaBrandRels.Warehouse","Warehouse","Currency"},
                                                        InnerQueryStr = "it.IsDraft = false",
                                                        SortCols = new List<SortCol>{new SortCol{ColName = "VATInvoiceDate",ByDescending = true}}
                                                    }
                                },
                                {"Invoice", new PopDialogInfo
                                                {
                                                        Columns = new List<ColumnInfo>{
                                                        new ColumnInfo {Header = "发票号", Path = "InvoiceNo"},
                                                        new ColumnInfo {Header = "结算金额", Path = "Amount",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = "应付", Path = "ARAPAmount",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = "利息", Path = "TotleInterest",StringFormat = RoundRules.STR_AMOUNT},
                                                        new ColumnInfo {Header = Properties.Resources.Currency, Path = "Currency.Name"},
                                                        new ColumnInfo{Header = "已申请金额",Path = "PaymentRequestAmount",StringFormat = RoundRules.STR_AMOUNT}
                                                    },
                                                    Title = ResPopDialog.SelectProvisionalInvoice,
                                                    Conditions = new Dictionary<string,string>{{"发票号", "InvoiceNo"}},
                                                    SvcClientType = typeof(CommercialInvoiceServiceClient),
                                                    ServiceType = SvcType.CommercialInvoiceSvc,
                                                    EagerLoadListForAppend = new List<string>{"Quota","Currency","Deliveries","Deliveries.DeliveryLines","LCCIRels","LCCIRels.LetterOfCredit","PaymentRequests","PaymentRequests.FundFlows","PaymentRequests.LetterOfCredits","PaymentRequests.PaymentMean","ProvisionalInvoices"},
                                                    InnerQueryStr = "(it.InvoiceType = " + (int) CommercialInvoiceType.Provisional + " and it.FinalInvoiceId is null) or it.InvoiceType = " + (int)CommercialInvoiceType.Final + " or it.InvoiceType = " + (int)CommercialInvoiceType.FinalCommercial,
                                                    SortCols = new List<SortCol>{new SortCol{ColName = "InvoicedDate",ByDescending = true}}
                                                }
                                }
                            };
        }

        #endregion
    }
}
