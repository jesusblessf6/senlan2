﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.View.Reports {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResReport {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResReport() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Client.View.Reports.ResReport", typeof(ResReport).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 Amount Remain 的本地化字符串。
        /// </summary>
        public static string AmountRemain {
            get {
                return ResourceManager.GetString("AmountRemain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Average Pull Price 的本地化字符串。
        /// </summary>
        public static string AveragePullPrice {
            get {
                return ResourceManager.GetString("AveragePullPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Average Push Price 的本地化字符串。
        /// </summary>
        public static string AveragePushPrice {
            get {
                return ResourceManager.GetString("AveragePushPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Broker Name 的本地化字符串。
        /// </summary>
        public static string BrokerName {
            get {
                return ResourceManager.GetString("BrokerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 1. Domestic Receivable/Payable = Ʃ(Priced Price × Priced Qty)；Foreign Receivable/Payable = ƩFinal Invoice Amount + ƩProvisional Invoice Amount(Not Adjusted Invoice)；Convert according to the settlement currency. 的本地化字符串。
        /// </summary>
        public static string Calculation1 {
            get {
                return ResourceManager.GetString("Calculation1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 2. Physical Gross Profit = Sales Receivable - Ʃ(Corresponding Purchase Payable)；Convert according to the settlement currency. 的本地化字符串。
        /// </summary>
        public static string Calculation2 {
            get {
                return ResourceManager.GetString("Calculation2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Change Status 的本地化字符串。
        /// </summary>
        public static string ChangeStatus {
            get {
                return ResourceManager.GetString("ChangeStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Closing PnL of Settle Date 的本地化字符串。
        /// </summary>
        public static string ClosingPnLOfSettleDate {
            get {
                return ResourceManager.GetString("ClosingPnLOfSettleDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Customer Name 的本地化字符串。
        /// </summary>
        public static string CustomerName {
            get {
                return ResourceManager.GetString("CustomerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Date Range should not be more than 3 months! 的本地化字符串。
        /// </summary>
        public static string DateRangeLimit {
            get {
                return ResourceManager.GetString("DateRangeLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Document No. 的本地化字符串。
        /// </summary>
        public static string DocumentNo {
            get {
                return ResourceManager.GetString("DocumentNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Domestic Hedge Ratio 的本地化字符串。
        /// </summary>
        public static string DomesticHedgeRatio {
            get {
                return ResourceManager.GetString("DomesticHedgeRatio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Domestic Hedge Ratio is Required! 的本地化字符串。
        /// </summary>
        public static string DomesticHedgeRatioRequired {
            get {
                return ResourceManager.GetString("DomesticHedgeRatioRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Squared Fixed PnL 的本地化字符串。
        /// </summary>
        public static string DuedLockedPnL {
            get {
                return ResourceManager.GetString("DuedLockedPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Exposure 的本地化字符串。
        /// </summary>
        public static string Exposure {
            get {
                return ResourceManager.GetString("Exposure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Exposure Trend 的本地化字符串。
        /// </summary>
        public static string ExposureTrend {
            get {
                return ResourceManager.GetString("ExposureTrend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Float PnL 的本地化字符串。
        /// </summary>
        public static string FloatPnL {
            get {
                return ResourceManager.GetString("FloatPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Foreign BL/WR Flow Report 的本地化字符串。
        /// </summary>
        public static string ForeignBLWRFlowReport {
            get {
                return ResourceManager.GetString("ForeignBLWRFlowReport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Inform Bank:  的本地化字符串。
        /// </summary>
        public static string InformBank {
            get {
                return ResourceManager.GetString("InformBank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Initial Pricing Margin 的本地化字符串。
        /// </summary>
        public static string InitPricingMargin {
            get {
                return ResourceManager.GetString("InitPricingMargin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Inventory 的本地化字符串。
        /// </summary>
        public static string Inventory {
            get {
                return ResourceManager.GetString("Inventory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Invoiced Qty 的本地化字符串。
        /// </summary>
        public static string InvoicedQty {
            get {
                return ResourceManager.GetString("InvoicedQty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Latest Price 的本地化字符串。
        /// </summary>
        public static string LatestPrice {
            get {
                return ResourceManager.GetString("LatestPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Latest Price (incl. Premium) 的本地化字符串。
        /// </summary>
        public static string LatestPriceWithPremium {
            get {
                return ResourceManager.GetString("LatestPriceWithPremium", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Latest Settlement Price 的本地化字符串。
        /// </summary>
        public static string LatestSettlementPrice {
            get {
                return ResourceManager.GetString("LatestSettlementPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Ledger 的本地化字符串。
        /// </summary>
        public static string Ledger {
            get {
                return ResourceManager.GetString("Ledger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 LME Latest Price 的本地化字符串。
        /// </summary>
        public static string LMELatestPrice {
            get {
                return ResourceManager.GetString("LMELatestPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 LME Long 的本地化字符串。
        /// </summary>
        public static string LMELong {
            get {
                return ResourceManager.GetString("LMELong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 LME Position PnL Report 的本地化字符串。
        /// </summary>
        public static string LMEPositionPL {
            get {
                return ResourceManager.GetString("LMEPositionPL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 LME Short 的本地化字符串。
        /// </summary>
        public static string LMEShort {
            get {
                return ResourceManager.GetString("LMEShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 LoC Info 的本地化字符串。
        /// </summary>
        public static string LoCInfo {
            get {
                return ResourceManager.GetString("LoCInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Margin Ratio 的本地化字符串。
        /// </summary>
        public static string MarginRatio {
            get {
                return ResourceManager.GetString("MarginRatio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Margin Ratio is Required! 的本地化字符串。
        /// </summary>
        public static string MarginRatioRequired {
            get {
                return ResourceManager.GetString("MarginRatioRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Not Priced 的本地化字符串。
        /// </summary>
        public static string NotPriced {
            get {
                return ResourceManager.GetString("NotPriced", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Open/Collect 的本地化字符串。
        /// </summary>
        public static string OpenCollect {
            get {
                return ResourceManager.GetString("OpenCollect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Please select invoice type, Open or Collect! 的本地化字符串。
        /// </summary>
        public static string OpenCollectRequired {
            get {
                return ResourceManager.GetString("OpenCollectRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Opposite Added Margin 的本地化字符串。
        /// </summary>
        public static string OppoCalledMargin {
            get {
                return ResourceManager.GetString("OppoCalledMargin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Opposite Additional Margin to Call 的本地化字符串。
        /// </summary>
        public static string OppoMarginToAdd {
            get {
                return ResourceManager.GetString("OppoMarginToAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Opposite Margin to Return 的本地化字符串。
        /// </summary>
        public static string OppositeMarginToReturn {
            get {
                return ResourceManager.GetString("OppositeMarginToReturn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Opposite Returned Margin 的本地化字符串。
        /// </summary>
        public static string OppositeReturnedMargin {
            get {
                return ResourceManager.GetString("OppositeReturnedMargin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Our Added Margin 的本地化字符串。
        /// </summary>
        public static string OurAdditionalMargin {
            get {
                return ResourceManager.GetString("OurAdditionalMargin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Our Additional Margin to Call 的本地化字符串。
        /// </summary>
        public static string OurMarginToAdd {
            get {
                return ResourceManager.GetString("OurMarginToAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Our Margin to Return 的本地化字符串。
        /// </summary>
        public static string OurMarginToReturn {
            get {
                return ResourceManager.GetString("OurMarginToReturn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Our Returned Margin 的本地化字符串。
        /// </summary>
        public static string OurReturnedMargin {
            get {
                return ResourceManager.GetString("OurReturnedMargin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Paid 的本地化字符串。
        /// </summary>
        public static string Paid {
            get {
                return ResourceManager.GetString("Paid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Partially Priced 的本地化字符串。
        /// </summary>
        public static string PartialPriced {
            get {
                return ResourceManager.GetString("PartialPriced", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical Domestic Trade PnL 的本地化字符串。
        /// </summary>
        public static string PhysicalDomesticTradePnL {
            get {
                return ResourceManager.GetString("PhysicalDomesticTradePnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical Foreign Trade PnL 的本地化字符串。
        /// </summary>
        public static string PhysicalForeignTradePnL {
            get {
                return ResourceManager.GetString("PhysicalForeignTradePnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical/Futures PnL Report 的本地化字符串。
        /// </summary>
        public static string PhysicalFuturesPnL {
            get {
                return ResourceManager.GetString("PhysicalFuturesPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical Gross Profit 的本地化字符串。
        /// </summary>
        public static string PhysicalGrossProfit {
            get {
                return ResourceManager.GetString("PhysicalGrossProfit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical Purchase 的本地化字符串。
        /// </summary>
        public static string PhysicalPurchase {
            get {
                return ResourceManager.GetString("PhysicalPurchase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Physical Sales 的本地化字符串。
        /// </summary>
        public static string PhysicalSales {
            get {
                return ResourceManager.GetString("PhysicalSales", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Position Detail 的本地化字符串。
        /// </summary>
        public static string PositionDetail {
            get {
                return ResourceManager.GetString("PositionDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Position Not Even! 的本地化字符串。
        /// </summary>
        public static string PositionNotEven {
            get {
                return ResourceManager.GetString("PositionNotEven", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Position PnL 的本地化字符串。
        /// </summary>
        public static string PositionPL {
            get {
                return ResourceManager.GetString("PositionPL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Risk of Pricing Margin 的本地化字符串。
        /// </summary>
        public static string PricingMarginRisk {
            get {
                return ResourceManager.GetString("PricingMarginRisk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Average Purchase Price 的本地化字符串。
        /// </summary>
        public static string PruchaseAveragePrice {
            get {
                return ResourceManager.GetString("PruchaseAveragePrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Pull Position 的本地化字符串。
        /// </summary>
        public static string PullPosition {
            get {
                return ResourceManager.GetString("PullPosition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Purchase Date 的本地化字符串。
        /// </summary>
        public static string PurchaseDate {
            get {
                return ResourceManager.GetString("PurchaseDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Purchase - Priced by Opposite 的本地化字符串。
        /// </summary>
        public static string PurchaseOppoPricing {
            get {
                return ResourceManager.GetString("PurchaseOppoPricing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Purchase - Priced by Us 的本地化字符串。
        /// </summary>
        public static string PurchaseOurSidePricing {
            get {
                return ResourceManager.GetString("PurchaseOurSidePricing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Purchase Quota No. 的本地化字符串。
        /// </summary>
        public static string PurchaseQuotaNo {
            get {
                return ResourceManager.GetString("PurchaseQuotaNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Push Position 的本地化字符串。
        /// </summary>
        public static string PushPosition {
            get {
                return ResourceManager.GetString("PushPosition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Quota Status 的本地化字符串。
        /// </summary>
        public static string QuotaStatus {
            get {
                return ResourceManager.GetString("QuotaStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Quota Status Modification 的本地化字符串。
        /// </summary>
        public static string QuotaStatusChange {
            get {
                return ResourceManager.GetString("QuotaStatusChange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Receivable And Payable 的本地化字符串。
        /// </summary>
        public static string ReceivableAndPayable {
            get {
                return ResourceManager.GetString("ReceivableAndPayable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Received 的本地化字符串。
        /// </summary>
        public static string Received {
            get {
                return ResourceManager.GetString("Received", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Average Sales Price 的本地化字符串。
        /// </summary>
        public static string SalesAveragePrice {
            get {
                return ResourceManager.GetString("SalesAveragePrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Sales Date 的本地化字符串。
        /// </summary>
        public static string SalesDate {
            get {
                return ResourceManager.GetString("SalesDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Sales - Priced by Opposite 的本地化字符串。
        /// </summary>
        public static string SalesOppoPricing {
            get {
                return ResourceManager.GetString("SalesOppoPricing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Sales - Priced by Us 的本地化字符串。
        /// </summary>
        public static string SalesOurPricing {
            get {
                return ResourceManager.GetString("SalesOurPricing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Sales PnL 的本地化字符串。
        /// </summary>
        public static string SalesPnL {
            get {
                return ResourceManager.GetString("SalesPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Sales Quota No. 的本地化字符串。
        /// </summary>
        public static string SalesQuotaNo {
            get {
                return ResourceManager.GetString("SalesQuotaNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Settlement Date should not be later than today! 的本地化字符串。
        /// </summary>
        public static string SettleDateLimit {
            get {
                return ResourceManager.GetString("SettleDateLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Settlement Date is Required! 的本地化字符串。
        /// </summary>
        public static string SettleDateRequired {
            get {
                return ResourceManager.GetString("SettleDateRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Settlement Date 的本地化字符串。
        /// </summary>
        public static string SettlementDate {
            get {
                return ResourceManager.GetString("SettlementDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SHFE Long 的本地化字符串。
        /// </summary>
        public static string SHFELong {
            get {
                return ResourceManager.GetString("SHFELong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SHFE Position PnL 的本地化字符串。
        /// </summary>
        public static string SHFEPnL {
            get {
                return ResourceManager.GetString("SHFEPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SHFE Short 的本地化字符串。
        /// </summary>
        public static string SHFEShort {
            get {
                return ResourceManager.GetString("SHFEShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Stop-Loss Price 的本地化字符串。
        /// </summary>
        public static string StopLossPrice {
            get {
                return ResourceManager.GetString("StopLossPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Summary By Broker 的本地化字符串。
        /// </summary>
        public static string SumByBroker {
            get {
                return ResourceManager.GetString("SumByBroker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Trade Type is Required! 的本地化字符串。
        /// </summary>
        public static string TradeTypeRequired {
            get {
                return ResourceManager.GetString("TradeTypeRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unsquared Float PnL 的本地化字符串。
        /// </summary>
        public static string UnduedFloatPnL {
            get {
                return ResourceManager.GetString("UnduedFloatPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unsquared Fixed PnL 的本地化字符串。
        /// </summary>
        public static string UnduedLockedPnL {
            get {
                return ResourceManager.GetString("UnduedLockedPnL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 VAT Invoice Detail 的本地化字符串。
        /// </summary>
        public static string VATInvoiceDetail {
            get {
                return ResourceManager.GetString("VATInvoiceDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 VAT Invoiced Qty 的本地化字符串。
        /// </summary>
        public static string VATInvoicedQty {
            get {
                return ResourceManager.GetString("VATInvoicedQty", resourceCulture);
            }
        }
    }
}
