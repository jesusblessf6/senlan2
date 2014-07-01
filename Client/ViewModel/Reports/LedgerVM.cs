using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.DeliveryServiceReference;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.View.PopUpDialog;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class LedgerVM : BaseVM
    {
        #region Member

        private BusinessPartner _customer;
        private int _customerId;
        private string _customerName;
        private BusinessPartner _purchaseCustomer;
        private int _purchaseCustomerId;
        private string _purchaseCustomerName;
        private DateTime _endDate = DateTime.Today;
        private List<BusinessPartner> _internalCustomers;
        private DataTable _ledgerGrid;
        private List<Commodity> _metals;
        private int _selectedInternalCustomersId;
        private int _selectedMetalId;
        private DateTime _startDate = DateTime.Today.AddMonths(-1);

        #endregion

        #region Property
        public List<LedgerClass> Ledgers { get; set; }
        public List<Commodity> Metals
        {
            get { return _metals; }
            set
            {
                if (_metals != value)
                {
                    _metals = value;
                    Notify("Metals");
                }
            }
        }

        public int SelectedMetalId
        {
            get { return _selectedMetalId; }
            set
            {
                if (_selectedMetalId != value)
                {
                    _selectedMetalId = value;
                    Notify("SelectedMetalId");
                }
            }
        }

        public int SelectedInternalCustomersId
        {
            get { return _selectedInternalCustomersId; }
            set
            {
                if (_selectedInternalCustomersId != value)
                {
                    _selectedInternalCustomersId = value;
                    Notify("SelectedInternalCustomersId");
                }
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    _customerId = value;
                    Notify("CustomerId");
                }
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    Notify("CustomerName");
                }
            }
        }

        public BusinessPartner Customer
        {
            get { return _customer; }
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    Notify("Customer");
                }
            }
        }
        public int PurchaseCustomerId
        {
            get { return _purchaseCustomerId; }
            set
            {
                if (_purchaseCustomerId != value)
                {
                    _purchaseCustomerId = value;
                    Notify("PurchaseCustomerId");
                }
            }
        }

        public string PurchaseCustomerName
        {
            get { return _purchaseCustomerName; }
            set
            {
                if (_purchaseCustomerName != value)
                {
                    _purchaseCustomerName = value;
                    Notify("PurchaseCustomerName");
                }
            }
        }

        public BusinessPartner PurchaseCustomer
        {
            get { return _purchaseCustomer; }
            set
            {
                if (_purchaseCustomer != value)
                {
                    _purchaseCustomer = value;
                    Notify("PurchaseCustomer");
                }
            }
        }
        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                if (_internalCustomers != value)
                {
                    _internalCustomers = value;
                    Notify("InternalCustomers");
                }
            }
        }

        public DataTable LedgerGrid
        {
            get { return _ledgerGrid; }
            set
            {
                if (_ledgerGrid != value)
                {
                    _ledgerGrid = value;
                    Notify("LedgerGrid");
                }
            }
        }

        #endregion

        #region Constructor

        public LedgerVM()
        {
            GetMetals();
            GetInternalCustomer();
        }

        #endregion

        #region Method

        /// <summary>
        /// 金属列表
        /// </summary>
        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Metals = metalService.GetCommoditiesByUser(CurrentUser.Id);
                Metals.Insert(0, new Commodity { Id = 0, Name = "" });
                if (Metals != null && Metals.Count > 0)
                    SelectedMetalId = Metals[0].Id;
            }
        }

        /// <summary>
        /// 内部客户列表
        /// </summary>
        public void GetInternalCustomer()
        {
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                if (InternalCustomers != null && InternalCustomers.Count > 0)
                    SelectedInternalCustomersId = InternalCustomers[0].Id;
            }
        }

        /// <summary>
        /// 显示销售客户弹出框
        /// </summary>
        public void ShowCustomerDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            Customer = dialog.SelectedItem as BusinessPartner;
            if (Customer != null)
            {
                CustomerId = Customer.Id;
                CustomerName = Customer.ShortName;
            }
        }

        /// <summary>
        /// 显示采购客户弹出框
        /// </summary>
        public void ShowPurchaseCustomerDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            PurchaseCustomer = dialog.SelectedItem as BusinessPartner;
            if (PurchaseCustomer != null)
            {
                PurchaseCustomerId = PurchaseCustomer.Id;
                PurchaseCustomerName = PurchaseCustomer.ShortName;
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (SelectedMetalId <= 0)
                throw new Exception(Properties.Resources.CommodityNotNull);
            if (SelectedInternalCustomersId <= 0)
                throw new Exception(Properties.Resources.SignSideRequired);
            if (StartDate == null || EndDate == null)
                throw new Exception(Properties.Resources.StartDateRequired);
            return true;
        }

        #endregion

        #region Ledger
        public void ShowLedgerGridNew()
        {
            Ledgers = null;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Ledgers = quotaService.GetLedgerData(StartDate, EndDate, SelectedMetalId, SelectedInternalCustomersId, CustomerId, PurchaseCustomerId,
                                          CurrentUser.Id);
            }
        }
        /// <summary>
        /// 显示台帐
        /// </summary>
        //public void ShowLedgerGrid()
        //{
        //    var dt = new DataTable();

        //    #region 初始化列名

        //    dt.Columns.Add("pQuotaNo");
        //    dt.Columns.Add("pQuotaDate");
        //    dt.Columns.Add("pQuotaSupplier");
        //    dt.Columns.Add("metalName");
        //    dt.Columns.Add("pBrandName");
        //    dt.Columns.Add("pQty");
        //    dt.Columns.Add("pVerifiedQty");
        //    dt.Columns.Add("pSalesQty");
        //    dt.Columns.Add("pPrice");
        //    dt.Columns.Add("pCurrency");
        //    dt.Columns.Add("pPay");
        //    dt.Columns.Add("pPaid");
        //    dt.Columns.Add("pReceived");
        //    dt.Columns.Add("pSettle");
        //    dt.Columns.Add("pSettleCurrency");

        //    dt.Columns.Add("sQuotaNo");
        //    dt.Columns.Add("sQuotaDate");
        //    dt.Columns.Add("sQuotaBuyer");
        //    dt.Columns.Add("sBrandName");
        //    dt.Columns.Add("sQty");
        //    dt.Columns.Add("sVerifiedQty");
        //    dt.Columns.Add("sPrice");
        //    dt.Columns.Add("sCurrency");
        //    dt.Columns.Add("sReceive");
        //    dt.Columns.Add("sReceived");
        //    dt.Columns.Add("sPaid");
        //    dt.Columns.Add("sSettle");
        //    dt.Columns.Add("sSettleCurrency");
        //    dt.Columns.Add("profit");

        //    bool emptyFlag = false;
        //    #endregion

        //    if (Validate())
        //    {
        //        IEnumerable<Quota> salesQuotaList = GetSalesQuotas();
        //        var businessParterService =
        //            SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc);
        //        using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
        //        {
        //            foreach (Quota sQuota in salesQuotaList)
        //            {
        //                Currency sCurrency = quotaService.GetSettlementCurrencyByQuotaId(sQuota.Id); //销售批次的结算币种
        //                decimal pSumAmount = 0; //采购应付金额汇总（采购价格 × 对应的销售数量），用于计算利润
        //                List<PQuotaItem> pQuotaItems = GetPurchaseQuotasBySalesQuota(sQuota);
        //                if (pQuotaItems != null && pQuotaItems.Count > 0)
        //                {
        //                    bool currencyFlag = true; //标志所有采购批次的结算币种是否全部都有值，如果有结算币种没有值，那么就不计算利润
        //                    for (int i = 0; i < pQuotaItems.Count; i++)
        //                    {
        //                        #region 采购部分

        //                        Quota q = pQuotaItems[i].PQuota;
        //                        Currency pCurrency = quotaService.GetSettlementCurrencyByQuotaId(q.Id); //采购批次的结算币种
        //                        if (pCurrency == null)
        //                            currencyFlag = false;

        //                        DataRow dr = dt.NewRow();
        //                        dr["pQuotaNo"] = q.QuotaNo;
        //                        if (q.ImplementedDate != null)
        //                        {
        //                            var time = (DateTime)q.ImplementedDate;
        //                            dr["pQuotaDate"] = time.Year + "-" + time.Month + "-" + time.Day;
        //                        }
        //                        BusinessPartner supplier = businessParterService.GetById((int)q.Contract.BPId);
        //                        dr["pQuotaSupplier"] = supplier.ShortName;
        //                        dr["metalName"] = q.Commodity.Name;
        //                        if (q.Brand != null)
        //                            dr["pBrandName"] = q.Brand.Name;
        //                        else
        //                            dr["pBrandName"] = "";
        //                        dr["pQty"] = string.Format("{0:#,##0.####}", q.Quantity);
        //                        decimal pVerifiedQty = q.VerifiedQuantity;
        //                        dr["pVerifiedQty"] = string.Format("{0:#,##0.####}", pVerifiedQty);
        //                        dr["pSalesQty"] = string.Format("{0:#,##0.####}", pQuotaItems[i].DividedQty);
        //                        decimal pPaid = quotaService.GetPayAmountByQuotaId(q.Id, CurrentUser.Id); //已付
        //                        dr["pPaid"] = string.Format("{0:#,##0.##}", pPaid);
        //                        decimal pReceived = quotaService.GetReceivableAmountByQuotaId(q.Id, CurrentUser.Id);//已收
        //                        dr["pReceived"] = string.Format("{0:#,##0.##}", pReceived);

        //                        if (q.PricingStatus == (int)PricingStatus.Complete)
        //                        {
        //                            decimal pPrice = quotaService.GetPriceByQuotaPricing(q.Id, CurrentUser.Id);
        //                            dr["pPrice"] = string.Format("{0:#,##0.##}", pPrice);
        //                            decimal pPay;
        //                            if (q.Contract.TradeType == (int)TradeType.LongForeignTrade ||
        //                                q.Contract.TradeType == (int)TradeType.ShortForeignTrade)
        //                                pPay = quotaService.GetAmountByQuotaId(q.Id, CurrentUser.Id);
        //                            else
        //                            {
        //                                decimal pPriceWithRate = quotaService.GetPriceByQuotaPricingWithRate(q.Id,
        //                                                                                                     CurrentUser
        //                                                                                                         .Id);
        //                                pPay = pPriceWithRate * pVerifiedQty;
        //                            }
        //                            dr["pPay"] = string.Format("{0:#,##0.##}", pPay);
        //                            dr["pSettle"] = string.Format("{0:#,##0.##}", pPay - pPaid + pReceived);
        //                            if (currencyFlag && sCurrency != null &&
        //                                pCurrency.Id == sCurrency.Id)
        //                                pSumAmount += pVerifiedQty == 0
        //                                                  ? 0
        //                                                  : (pPay * pQuotaItems[i].DividedQty / pVerifiedQty); //采购金额汇总，用于计算利润
        //                            else if (currencyFlag && sCurrency != null &&
        //                                     pCurrency.Id != sCurrency.Id)
        //                            {
        //                                decimal rate = GetRateByTwoCurrency(sCurrency.Id, pCurrency.Id,
        //                                                                    CurrentUser.Id);
        //                                pSumAmount += pVerifiedQty == 0
        //                                                  ? 0
        //                                                  : (pPay * pQuotaItems[i].DividedQty / pVerifiedQty * rate);
        //                            }
        //                        }
        //                        else if (q.PricingStatus == (int)PricingStatus.Complete)
        //                            dr["pPrice"] = ResReport.PartialPriced;
        //                        else
        //                            dr["pPrice"] = ResReport.NotPriced;

        //                        dr["pCurrency"] = q.Currency.Name;
        //                        if (q.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
        //                            q.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
        //                            dr["pSettleCurrency"] = Properties.Resources.CNY; //结算币种
        //                        else
        //                        {
        //                            if (pCurrency != null)
        //                                dr["pSettleCurrency"] = pCurrency.Name;
        //                            else
        //                                dr["pSettleCurrency"] = "";
        //                        }

        //                        #endregion

        //                        #region 销售部分

        //                        if (i == pQuotaItems.Count - 1)
        //                        {
        //                            dr["sQuotaNo"] = sQuota.QuotaNo;
        //                            if (sQuota.ImplementedDate != null)
        //                            {
        //                                var time = (DateTime)sQuota.ImplementedDate;
        //                                dr["sQuotaDate"] = time.Year + "-" + time.Month + "-" + time.Day;
        //                            }
        //                            BusinessPartner buyer = businessParterService.GetById((int)sQuota.Contract.BPId);
        //                            dr["sQuotaBuyer"] = buyer.ShortName;
        //                            if (sQuota.Brand != null)
        //                                dr["sBrandName"] = sQuota.Brand.Name;
        //                            else
        //                                dr["sBrandName"] = "";
        //                            dr["sQty"] = string.Format("{0:#,##0.####}", sQuota.Quantity);

        //                            decimal sVerifiedQty = sQuota.VerifiedQuantity;
        //                            dr["sVerifiedQty"] = string.Format("{0:#,##0.####}", sVerifiedQty);
        //                            decimal sReceived = quotaService.GetReceivableAmountByQuotaId(sQuota.Id,
        //                                                                                          CurrentUser.Id); //已收
        //                            dr["sReceived"] = string.Format("{0:#,##0.##}", sReceived);
        //                            decimal sPaid = quotaService.GetPayAmountByQuotaId(sQuota.Id, CurrentUser.Id); //已付
        //                            dr["sPaid"] = string.Format("{0:#,##0.##}", sPaid);

        //                            decimal sReceive = 0;
        //                            if (sQuota.PricingStatus == (int)PricingStatus.Complete)
        //                            {
        //                                decimal sPrice = quotaService.GetPriceByQuotaPricing(sQuota.Id, CurrentUser.Id);
        //                                dr["sPrice"] = string.Format("{0:#,##0.##}", sPrice);
        //                                if (sQuota.Contract.TradeType == (int)TradeType.LongForeignTrade ||
        //                                    sQuota.Contract.TradeType == (int)TradeType.ShortForeignTrade)
        //                                    sReceive = quotaService.GetAmountByQuotaId(sQuota.Id, CurrentUser.Id);
        //                                else
        //                                {
        //                                    decimal sPriceWithRate =
        //                                        quotaService.GetPriceByQuotaPricingWithRate(sQuota.Id, CurrentUser.Id);
        //                                    sReceive = sPriceWithRate * sVerifiedQty;
        //                                }
        //                                dr["sReceive"] = string.Format("{0:#,##0.##}", sReceive);
        //                                dr["sSettle"] = string.Format("{0:#,##0.##}", sReceive - sReceived + sPaid);
        //                            }
        //                            else if (q.PricingStatus == (int)PricingStatus.Complete)
        //                                dr["sPrice"] = ResReport.PartialPriced;
        //                            else
        //                                dr["sPrice"] = ResReport.NotPriced;

        //                            dr["sCurrency"] = sQuota.Currency.Name;
        //                            if (sQuota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
        //                                sQuota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
        //                                dr["sSettleCurrency"] = Properties.Resources.CNY; //结算币种
        //                            else
        //                            {
        //                                if (sCurrency != null)
        //                                    dr["sSettleCurrency"] = sCurrency.Name;
        //                                else
        //                                    dr["sSettleCurrency"] = "";
        //                            }
        //                            if (currencyFlag && sReceive != 0 && pSumAmount != 0)
        //                                dr["profit"] = string.Format("{0:#,##0.##}", sReceive - pSumAmount);//现货利润 = 应收 - 应付
        //                        }

        //                        #endregion

        //                        dt.Rows.Add(dr);
        //                        emptyFlag = true;
        //                    }
        //                }
        //                if (emptyFlag)
        //                {
        //                    DataRow emptyRow = dt.NewRow();
        //                    dt.Rows.Add(emptyRow);
        //                    emptyFlag = false;
        //                }

        //            }
        //        }
        //    }
        //    LedgerGrid = dt;
        //}

        /// <summary>
        /// 查询销售批次
        /// </summary>
        /// <returns></returns>
        //private IEnumerable<Quota> GetSalesQuotas()
        //{
        //    using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
        //    {
        //        //销售批次、不需要审批或审批完成、不是草稿、金属、内部客户、起始履约日期、业务伙伴（可选）
        //        string condition =
        //            "it.Contract.ContractType = @p1 and (it.ApproveStatus = @p2 or it.ApproveStatus = @p3) and it.IsDraft = @p4 and it.CommodityId = @p5 and it.Contract.InternalCustomerId = @p6 and it.ImplementedDate >= @p7 and it.ImplementedDate <= @p8 ";
        //        var parameters = new List<object>
        //                             {
        //                                 (int) ContractType.Sales,
        //                                 (int) ApproveStatus.NoApproveNeeded,
        //                                 (int) ApproveStatus.Approved,
        //                                 false,
        //                                 SelectedMetalId,
        //                                 SelectedInternalCustomersId,
        //                                 StartDate,
        //                                 EndDate
        //                             };
        //        if (Customer != null && CustomerId > 0)
        //        {
        //            condition += "and it.Contract.BPId = @p9 ";
        //            parameters.Add(CustomerId);
        //        }
        //        var includes = new List<string>
        //                           {
        //                               "Contract",
        //                               "Contract.BusinessPartner",
        //                               "Commodity",
        //                               "Brand",
        //                               "Currency", 
        //                               "Deliveries",
        //                               "Deliveries.Delivery2",
        //                               "Deliveries.Delivery2.Quota",
        //                               "Deliveries.Delivery2.Quota.Currency",
        //                               "Deliveries.Delivery2.Quota.Contract",
        //                               "WarehouseOuts",
        //                               "WarehouseOuts.WarehouseOutLines",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine.DeliveryLine",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine.DeliveryLine.Delivery",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine.DeliveryLine.Delivery.Quota",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine.DeliveryLine.Delivery.Quota.Currency",
        //                               "WarehouseOuts.WarehouseOutLines.WarehouseInLine.DeliveryLine.Delivery.Quota.Contract"
        //                           };
        //        List<Quota> salesQuotas = quotaService.Select(condition, parameters, includes);
        //        return salesQuotas;
        //    }
        //}

        /// <summary>
        /// 根据销售批次查找对应的所有采购批次
        /// </summary>
        /// <param name="salesQuota"></param>
        /// <returns></returns>
        //private List<PQuotaItem> GetPurchaseQuotasBySalesQuota(Quota salesQuota)
        //{
        //    //如果销售批次以提单转手的方式销售，则通过发货单查找提单，然后通过提单查找采购批次，
        //    //即：销售批次--发货单--提单--采购批次
        //    //如果销售批次以出库的方式销售，则通过出库查找对应的入库，再通过入库查找提单，最后通过提单查找采购批次，
        //    //即：销售批次--出库--出库行--入库行--提单行--提单--采购批次

        //    var pQuotaItemList = new List<PQuotaItem>();
        //    if (salesQuota.Deliveries != null && salesQuota.Deliveries.Count > 0)
        //    {
        //        List<Delivery> dList = salesQuota.Deliveries.Where(c => c.IsDeleted == false).ToList();
        //        using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
        //        {
        //            foreach (Delivery d in dList)
        //            {
        //                var pi = new PQuotaItem { PQuota = d.Delivery2.Quota };
        //                decimal dividedQuantity = deliveryService.GetSaleDeliveryQuantityById(d.Id, CurrentUser.Id);
        //                pi.DividedQty = dividedQuantity;
        //                pQuotaItemList.Add(pi);
        //            }
        //        }
        //    }
        //    if (salesQuota.WarehouseOuts != null && salesQuota.WarehouseOuts.Count > 0)
        //    {
        //        List<WarehouseOut> warehouseOuts = salesQuota.WarehouseOuts.Where(o => o.IsDeleted == false).ToList();
        //        foreach (WarehouseOut wo in warehouseOuts)
        //        {
        //            List<WarehouseOutLine> oList = wo.WarehouseOutLines.Where(c => c.IsDeleted == false).ToList();
        //            foreach (WarehouseOutLine wol in oList)
        //            {
        //                var pi = new PQuotaItem
        //                             {
        //                                 PQuota = wol.WarehouseInLine.DeliveryLine.Delivery.Quota,
        //                                 DividedQty = wol.VerifiedQuantity ?? 0
        //                             };
        //                pQuotaItemList.Add(pi);
        //            }
        //        }
        //    }
        //    pQuotaItemList =
        //        pQuotaItemList.GroupBy(c => c.PQuota).Select(
        //            g => new PQuotaItem { PQuota = g.Key, DividedQty = g.Sum(h => h.DividedQty) }).ToList();
        //    return pQuotaItemList;
        //}

        /// <summary>
        /// 计算两个币种之间的汇率
        /// </summary>
        /// <param name="settleCurr"></param>
        /// <param name="curr"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private decimal GetRateByTwoCurrency(int settleCurr, int curr, int userId)
        {
            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
            {
                decimal? rate = rateService.GetExchangeRate(settleCurr, curr, userId);

                if (rate != null)
                    return rate.Value;

                return 1;
            }
        }

        #endregion

        #region Struct

        public struct PQuotaItem
        {
            /// <summary>
            /// 拆分后的数量，即此采购批次销售给某一销售批次的数量
            /// </summary>
            public decimal DividedQty;

            /// <summary>
            /// 采购批次
            /// </summary>
            public Quota PQuota;
        }

        #endregion
    }
}