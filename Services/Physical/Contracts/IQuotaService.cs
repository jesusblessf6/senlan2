using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;
using System;

namespace Services.Physical.Contracts
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IQuotaService”。
    [ServiceContract]
    public interface IQuotaService : IService<Quota>
    {
        [OperationContract]
        decimal GetExchangeRate(int? settleCurr, int curr, int userId);
        [OperationContract]
        decimal GetPricedQuantity(int quotaId);

        [OperationContract]
        QuotaEnableProperty SetElementsEnableProperty(int id);

        [OperationContract]
        List<Quota> GetQuotasApproachingPricingEnd();

        [OperationContract]
        List<Quota> GetPurchaseAmount(DateTime? startDate, DateTime? endDate, int internalCustomerID);

        [OperationContract]
        IEnumerable<int> GetFinancialAccount(int userId);
        /// <summary>
        /// 根据批次Id获取该批次的实际数量
        /// </summary>
        /// <param name="quotaId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetVerifiedQuantity(int quotaId, int userId);

        [OperationContract]
        decimal GetPriceByQuotaPricing(int quotaId, int userId);

        [OperationContract]
        decimal GetAmountByQuotaId(int quotaId, int userId);

        [OperationContract]
        decimal GetPayAmountByQuotaId(int quotaId, int userId);

        [OperationContract]
        decimal GetReceivableAmountByQuotaId(int quotaId, int userId);

        [OperationContract]
        string GetCurrencyByPricing(int quotaId);

        /// <summary>
        /// 根据批次ID查询结算币种，外贸批次结算币种 = 商业发票的结算币种
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        [OperationContract]
        Currency GetSettlementCurrencyByQuotaId(int quotaId);

        [OperationContract]
        decimal GetPriceByQuotaPricingWithRate(int quotaId, int userId);

        [OperationContract]
        decimal GetAparReportDataByQuota(Quota quota, int userId, out decimal? price,
                                               out decimal? yingf, out decimal? yings, out decimal? yif,
                                               out decimal? yis, out decimal? ye, out string pricingCurrencyName,
                                               out string currencyName,out int currencyId, out decimal yik);

        //[OperationContract]
        //decimal GetQuotaAmount(int quotaId, ref Dictionary<string, decimal> commodityDictionary, ref decimal qtyCount, int userId, bool containsUnPricing = false, bool containsRate = false);

        [OperationContract]
        decimal GetQuotaAmount(Quota quota, ref Dictionary<string, decimal> commodityDictionary, ref decimal qtyCount, ref decimal avgPrice, int userId, bool containsUnPricing = false, bool containsRate = false, bool convertCurrency = true);

        [OperationContract]
        List<Quota> GetAllQuotaListByDateAndCommodity(DateTime? startDate, DateTime endDate, int? commodityId,
                                                      int internalCustomerID);

        [OperationContract]
        decimal GetQuotaSumQty(string str, List<object> param, List<string> eagorLoad);

        [OperationContract]
        decimal GetAvgPrice(List<QuotaBrandRel> list);

        [OperationContract]
        List<ARAPClass> GetARAPReportData(int bPId, int innerCustomerId, int commodityId, DateTime? startDate, DateTime? endDate,string quotaNo, int userId);

        [OperationContract]
        List<LedgerClass> GetLedgerData(DateTime startTime, DateTime endTime, int commodityId, int internalCustomersId,
                                        int bpId, int purchaseCustomerId, int userId);

        [OperationContract]
        void UpdateQuotaStatusWithVerifiedQuantityByQuotaId(Quota quota, int userId);

        [OperationContract]
        decimal GetQuotaAmountsByQuota(List<Quota> quotas, int userId);

        [OperationContract]
        void GetPricingMarginReportData(int commodityId, int internalCustomerId, decimal rate, DateTime? startDate, DateTime? endDate, ref List<MarginLineClass> pOursList, ref List<MarginLineClass> sOursList, ref List<MarginLineClass> pTheirsList, ref List<MarginLineClass> sTheirsList);

        [OperationContract]
        void GetPhysicalPNLData(DateTime? startTime, DateTime endTime, int commodityId,
                                                              int internalCustomersId,
                                                              List<Commodity> selectedCommodityList, int userid, ref List<PhysicalPNLClass> innerList, ref List<PhysicalPNLClass> outList);

        [OperationContract]
        void CompleteUnpricingtoPricing(int unpricingId, Pricing pricing, int quotaId, int userId);

        [OperationContract]
        void UpdatePricing(Pricing pricing, int userId);

        [OperationContract]
        List<DashBoardClass> GetDashBoard(DateTime? startDate, DateTime? endDate, int internalCustomerID, int userId,
            ref List<Currency> currencyList, ref List<Commodity> commodityList, ref List<DashBoardTotalClass> totals);

        [OperationContract]
        List<BPartnerContractOrder> GetContractOrderList(string queryStr, List<object> parameters, int userId);

        [OperationContract]
        decimal GetQuotaSumAmount(string str, List<object> param, List<string> eagorLoad, out decimal sumQty);
    }

    [DataContract]
    public class ARAPClass
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 业务伙伴名称
        /// </summary>
        [DataMember]
        public string BusinessPartnerName { get; set; }

        /// <summary>
        /// 内部客户名称
        /// </summary>
        [DataMember]
        public string InnerCustomerName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [DataMember]
        public string QuotaNo { get; set; }

        /// <summary>
        /// 金属品种
        /// </summary>
        [DataMember]
        public string CommodityName { get; set; }

        /// <summary>
        /// 金属品牌
        /// </summary>
        [DataMember]
        public string BrandName { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        [DataMember]
        public decimal? VerQty { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [DataMember]
        public decimal? Price { get; set; }

        /// <summary>
        /// 点价币种
        /// </summary>
        [DataMember]
        public string PricingCurrency { get; set; }

        /// <summary>
        /// 应收
        /// </summary>
        [DataMember]
        public decimal? BReceived { get; set; }

        /// <summary>
        /// 应付
        /// </summary>
        [DataMember]
        public decimal? BPaid { get; set; }

        /// <summary>
        /// 已收
        /// </summary>
        [DataMember]
        public decimal? SReceived { get; set; }

        /// <summary>
        /// 已付
        /// </summary>
        [DataMember]
        public decimal? SPaid { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        [DataMember]
        public decimal? AmountRemain { get; set; }

        /// <summary>
        /// 余额(人民币)
        /// </summary>
        [DataMember]
        public decimal? AmountRemainCNY { get; set; }

        /// <summary>
        /// 结算币种
        /// </summary>
        [DataMember]
        public string SettleCurrency { get; set; }

        [DataMember]
        public int? InternalCustomerId { get; set; }

        [DataMember]
        public int? CustomerId { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public decimal? VatInvoiceQty { get; set; }

        [DataMember]
        public decimal? VatInvoiceAmount { get; set; }

        [DataMember]
        public decimal? VatInvoiceAmountRemain { get; set; }

        /// <summary>
        /// 期初余额
        /// </summary>
        [DataMember]
        public decimal? BeforeAmount { get; set; }
    }

    [DataContract]
    public class LedgerClass
    {
        [DataMember]
        public string PQuotaNo { get; set; }    //采购批次号(采购)

        [DataMember]
        public DateTime? PQuotaDate { get; set; }//采购日期(采购)

        [DataMember]
        public string PQuotaSupplier { get; set; }    //供应商(采购)

        [DataMember]
        public string MetalName { get; set; }    //金属品种(采购)

        [DataMember]
        public string PBrandName { get; set; }    //金属品牌(采购)

        [DataMember]
        public decimal? PQty { get; set; }      //批次数量(采购)

        [DataMember]
        public decimal? PVerifiedQty { get; set; }      //实际数量(采购)

        [DataMember]
        public decimal? PSalesQty { get; set; }      //销售数量(采购)

        [DataMember]
        public string PPrice { get; set; }      //价格(采购)

        [DataMember]
        public string PCurrency { get; set; }   //币种(采购)

        [DataMember]
        public decimal? PPay { get; set; }      //应付(采购)

        [DataMember]
        public decimal? PPaid { get; set; }      //已付金额(采购)

        [DataMember]
        public decimal? PReceived { get; set; }      //已收(采购)

        [DataMember]
        public decimal? PSettle { get; set; }      //结算(采购)

        [DataMember]
        public string PSettleCurrency { get; set; }   //结算币种(采购)

        [DataMember]
        public string SQuotaNo { get; set; }    //销售批次(销售)

        [DataMember]
        public DateTime? SQuotaDate { get; set; }//采购日期(销售)

        [DataMember]
        public string SQuotaBuyer { get; set; }    //采购商(销售)

        [DataMember]
        public string SBrandName { get; set; }    //金属品牌(销售)

        [DataMember]
        public decimal? SQty { get; set; }      //批次数量(销售)

        [DataMember]
        public decimal? SVerifiedQty { get; set; }      //实际数量(销售)

        [DataMember]
        public string SPrice { get; set; }      //价格(销售)

        [DataMember]
        public string SCurrency { get; set; }   //币种(销售)

        [DataMember]
        public decimal? SReceive { get; set; }      //应收(销售)

        [DataMember]
        public decimal? SReceived { get; set; }      //已收(销售)

        [DataMember]
        public decimal? SPaid { get; set; }      //已付金额(销售)

        [DataMember]
        public decimal? SSettle { get; set; }      //结算(销售)

        [DataMember]
        public string SSettleCurrency { get; set; }   //结算币种(销售)

        [DataMember]
        public decimal? Profit { get; set; }        //现货毛利
    }

    [DataContract]
    public class PhysicalPNLClass
    {
        [DataMember]
        public string CommodityName { get; set; }

        [DataMember]
        public decimal? BuySumQty { get; set; }

        [DataMember]
        public decimal? BuyAvgPrice { get; set; }

        [DataMember]
        public decimal? SellSumQty { get; set; }

        [DataMember]
        public decimal? SellAvgPrice { get; set; }

        [DataMember]
        public decimal? SellPNL { get; set; }

        [DataMember]
        public decimal? InventorySumQty { get; set; }

        [DataMember]
        public decimal? LatestPrice { get; set; }

        [DataMember]
        public decimal? FloatPNL { get; set; }

        [DataMember]
        public decimal? TotalPNL { get; set; }
    }

    [DataContract]
    public class MarginLineClass
    {
        [DataMember]
        public int BPartnerId { get; set; }
        [DataMember]
        public string BPName { get; set; }
        [DataMember]
        public int QuotaId { get; set; }
        [DataMember]
        public string QuotaNo { get; set; }
        [DataMember]
        public decimal? QuotaQuantity { get; set; }
        [DataMember]
        public decimal? PricingQuantity { get; set; }
        [DataMember]
        public decimal? Payment { get; set; } //已付
        [DataMember]
        public string PaymentStr { get; set; } //已付+币种
        [DataMember]
        public decimal? InitMargin { get; set; } //初始保证金
        [DataMember]
        public decimal? LastPrice { get; set; } //最新价
        [DataMember]
        public decimal? ExitPrice { get; set; } //止损价
        [DataMember]
        public decimal? Amount { get; set; } //金额
        [DataMember]
        public decimal? OurAppendMargin { get; set; } //我方已追加保证金
        [DataMember]
        public decimal? OurReturnMargin { get; set; } //我方已退还保证金
        [DataMember]
        public decimal? TheirAppendMargin { get; set; } //对已方追加保证金
        [DataMember]
        public decimal? TheirReturnMargin { get; set; } //对方已退还保证金
        [DataMember]
        public decimal? OurNeedToAppendMargin { get; set; } //我方需追加保证金
        [DataMember]
        public decimal? OurNeedToReturnMargin { get; set; } //我方需退还保证金
        [DataMember]
        public decimal? TheirNeedToAppendMargin { get; set; } //对方需追加保证金
        [DataMember]
        public decimal? TheirNeedToReturnMargin { get; set; } //对方需退还保证金
    }

    [DataContract]
    public class DashBoardChartClass
    {
        [DataMember]
        public int CommodityId { get; set; }
        [DataMember]
        public string CommodityName { get; set; }
        [DataMember]
        public int CurrencyId { get; set; }
        [DataMember]
        public string CurrencyName { get; set; }
        [DataMember]
        public decimal AmountPurchase { get; set; }
        [DataMember]
        public decimal AmountSale { get; set; }
        [DataMember]
        public decimal QuantityP { get; set; }
        [DataMember]
        public decimal QuantityS { get; set; }
    }

    [DataContract]
    public class DashBoardClass
    {
        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public int CurrencyId { get; set; }

        [DataMember]
        public string CommodityName { get; set; }

        [DataMember]
        public int CommodityId { get; set; }

        [DataMember]
        public decimal PurchaseAmount { get; set; }

        [DataMember]
        public decimal SaleAmount { get; set; }
    }

    [DataContract]
    public class DashBoardTotalClass
    {
        [DataMember]
        public string CommodityName { get; set; }

        [DataMember]
        public int CommodityId { get; set; }

        [DataMember]
        public decimal PurchaseQty { get; set; }

        [DataMember]
        public decimal SaleQty { get; set; }
    }

    [DataContract]
    public class BPartnerContractOrder
    {
        [DataMember]
        public string BusinessParnterName { get; set; }

        [DataMember]
        public decimal? Qty { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }

        [DataMember]
        public decimal? AvgPrice { get; set; }
    }
}
