using System;
using System.Collections.Generic;
using System.Windows.Data;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.QuotaServiceReference;
using Client.View.Reports;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class LMEMarginReportVM : BaseVM
    {
        #region Member

        private List<Commodity> _commodities;
        private DateTime? _endDate;
        private List<BusinessPartner> _internalCustomers;
        private decimal? _marginRatio;

        private int _selectedCommodityId;
        private int _selectedInternalCustomerId;
        private DateTime? _startDate;
        private List<MarginLineClass> _pOurs;
        private List<MarginLineClass> _sOurs;
        private List<MarginLineClass> _pTheirs;
        private List<MarginLineClass> _sTheirs;

        #endregion

        #region Property
        public List<MarginLineClass> POurs 
        {
            get
            {
                return _pOurs;
            }
            set
            {
                if (value != _pOurs)
                {
                    _pOurs = value;
                    Notify("POurs");
                }
            }
        }
        public List<MarginLineClass> SOurs
        {
            get
            {
                return _sOurs;
            }
            set
            {
                if (value != _sOurs)
                {
                    _sOurs = value;
                    Notify("SOurs");
                }
            }
        }
        public List<MarginLineClass> PTheirs
        {
            get
            {
                return _pTheirs;
            }
            set
            {
                if (value != _pTheirs)
                {
                    _pTheirs = value;
                    Notify("PTheirs");
                }
            }
        }
        public List<MarginLineClass> STheirs
        {
            get
            {
                return _sTheirs;
            }
            set
            {
                if (value != _sTheirs)
                {
                    _sTheirs = value;
                    Notify("STheirs");
                }
            }
        }
        public ListCollectionView POursView { get; set; }
        public ListCollectionView PTheirsView { get; set; }
        public ListCollectionView SOursView { get; set; }
        public ListCollectionView STheirsView { get; set; }

        public int SelectedCommodityId
        {
            get { return _selectedCommodityId; }
            set
            {
                if (_selectedCommodityId != value)
                {
                    _selectedCommodityId = value;
                    Notify("SelectedCommodityId");
                }
            }
        }

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
            }
        }

        public DateTime? StartDate
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

        public DateTime? EndDate
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

        public int SelectedInternalCustomerId
        {
            get { return _selectedInternalCustomerId; }
            set
            {
                if (_selectedInternalCustomerId != value)
                {
                    _selectedInternalCustomerId = value;
                    Notify("SelectedInternalCustomerId");
                }
            }
        }

        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                _internalCustomers = value;
                Notify("InternalCustomers");
            }
        }

        public decimal? MarginRatio
        {
            get { return _marginRatio; }
            set
            {
                _marginRatio = value;
                Notify("MarginRatio");
            }
        }

        //public List<LMEMarginLineVM> POurs
        //{
        //    get { return _pOurs; }
        //    set
        //    {
        //        _pOurs = value;
        //        Notify("POurs");
        //    }
        //}

        //public List<LMEMarginLineVM> PTheirs
        //{
        //    get { return _pTheirs; }
        //    set
        //    {
        //        _pTheirs = value;
        //        Notify("PTheirs");
        //    }
        //}

        //public List<LMEMarginLineVM> SOurs
        //{
        //    get { return _sOurs; }
        //    set
        //    {
        //        _sOurs = value;
        //        Notify("SOurs");
        //    }
        //}

        //public List<LMEMarginLineVM> STheirs
        //{
        //    get { return _sTheirs; }
        //    set
        //    {
        //        _sTheirs = value;
        //        Notify("STheirs");
        //    }
        //}

        public string QueryStr { get; set; }
        public List<object> Parameters { get; set; }
        public List<LMEPosition> DuedPositions { get; set; }
        public List<LMEPosition> UnduedPositions { get; set; }

        #endregion

        #region Constructor

        public LMEMarginReportVM()
        {
            //load commodities combo
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetAll();
                _commodities.Insert(0, new Commodity());
            }

            //load brokers and internal customers
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }

            //set start date to today as default
            _endDate = DateTime.Today;
        }

        #endregion

        #region Method
        public void LoadNew()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                _pOurs = new List<MarginLineClass>();
                _sOurs = new List<MarginLineClass>();
                _pTheirs = new List<MarginLineClass>();
                _sTheirs = new List<MarginLineClass>();
                quotaService.GetPricingMarginReportData(SelectedCommodityId, SelectedInternalCustomerId, MarginRatio.Value, StartDate, EndDate, ref _pOurs, ref _sOurs, ref _pTheirs, ref _sTheirs);
            }
        }

        /// <summary>
        /// Validate the search conditions
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (SelectedCommodityId == 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }

            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            if (MarginRatio == 0 || MarginRatio == null)
            {
                throw new Exception(ResReport.MarginRatioRequired);
            }
            return true;
        }

        #region 最原始代码，暂时注释掉
        //public void Load()
        //{
        //    Validate();
        //    BuildQueryStrAndParam();

        //    //Load the initial date
        //    List<Quota> quotas;
        //    using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
        //    {
        //        quotas = quotaService.Select(QueryStr, Parameters,
        //                                     new List<string>
        //                                         {
        //                                             "Contract",
        //                                             "Contract.BusinessPartner",
        //                                             "Commodity",
        //                                             "Pricings",
        //                                             "CommercialInvoices",
        //                                             "CommercialInvoices.Currency",
        //                                             "FundFlows"
        //                                         });
        //    }
        //    FillGrid(quotas);
        //    POursView = new ListCollectionView(POurs);
        //    if (POursView.GroupDescriptions != null)
        //        POursView.GroupDescriptions.Add(new PropertyGroupDescription("BPName"));
        //    PTheirsView = new ListCollectionView(PTheirs);
        //    if (PTheirsView.GroupDescriptions != null)
        //        PTheirsView.GroupDescriptions.Add(new PropertyGroupDescription("BPName"));
        //    SOursView = new ListCollectionView(SOurs);
        //    if (SOursView.GroupDescriptions != null)
        //        SOursView.GroupDescriptions.Add(new PropertyGroupDescription("BPName"));
        //    STheirsView = new ListCollectionView(STheirs);
        //    if (STheirsView.GroupDescriptions != null)
        //        STheirsView.GroupDescriptions.Add(new PropertyGroupDescription("BPName"));
        //}

        ///// <summary>
        ///// Build Up Query string and Parameters
        ///// </summary>
        //private void BuildQueryStrAndParam()
        //{
        //    //build condition and parameters
        //    var sb = new StringBuilder();
        //    sb.AppendFormat(
        //        "it.CommodityId = @p1 and it.Contract.InternalCustomerId = @p2 and it.PricingStatus!=@p3 and it.PricingType=@p4 and (it.ApproveStatus=@p5 or it.ApproveStatus=@p6) and (it.PricingBasis=@p7 or it.PricingBasis=@p8) and (it.Contract.TradeType=@p9 or it.Contract.TradeType=@p10)");
        //    var parameters = new List<object>
        //                         {
        //                             SelectedCommodityId,
        //                             SelectedInternalCustomerId,
        //                             (int) PricingStatus.Complete,
        //                             (int) PricingType.Manual,
        //                             (int) ApproveStatus.Approved,
        //                             (int) ApproveStatus.NoApproveNeeded,
        //                             (int) PricingBasis.LME3M,
        //                             (int) PricingBasis.LMECash,
        //                             (int) TradeType.LongForeignTrade,
        //                             (int) TradeType.ShortForeignTrade
        //                         };
        //    int i = 11;
        //    if (StartDate != null)
        //    {
        //        sb.AppendFormat(" and it.ImplementedDate >= @p{0}", i++);
        //        parameters.Add(StartDate);
        //    }

        //    if (EndDate != null)
        //    {
        //        sb.AppendFormat(" and it.ImplementedDate <= @p{0}", i);
        //        parameters.Add(EndDate);
        //    }

        //    QueryStr = sb.ToString();
        //    Parameters = parameters;
        //}

        ///// <summary>
        ///// Fill the Summary Grid
        ///// </summary>
        //private void FillGrid(IEnumerable<Quota> quotas)
        //{
        //    POurs = new List<LMEMarginLineVM>();
        //    SOurs = new List<LMEMarginLineVM>();
        //    PTheirs = new List<LMEMarginLineVM>();
        //    STheirs = new List<LMEMarginLineVM>();
        //    foreach (Quota item in quotas)
        //    {
        //        FilterDeleted(item.Deliveries);
        //        FilterDeleted(item.FundFlows);
        //        FilterDeleted(item.CommercialInvoices);

        //        if (item.PricingSide == (int) PricingSide.OurSide)
        //        {
        //            if (item.Contract.ContractType == (int) ContractType.Purchase)
        //            {
        //                LMEMarginLineVM pOur = LMEMarginLineBind(item);
        //                POurs.Add(pOur);
        //            }
        //            else
        //            {
        //                LMEMarginLineVM sOur = LMEMarginLineBind(item);
        //                SOurs.Add(sOur);
        //            }
        //        }
        //        else if (item.PricingSide == (int) PricingSide.TheirSide)
        //        {
        //            if (item.Contract.ContractType == (int) ContractType.Purchase)
        //            {
        //                LMEMarginLineVM pTheir = LMEMarginLineBind(item);
        //                PTheirs.Add(pTheir);
        //            }
        //            else
        //            {
        //                LMEMarginLineVM sTheir = LMEMarginLineBind(item);
        //                STheirs.Add(sTheir);
        //            }
        //        }
        //    }
        //}

       
        ////报表Entity赋值
        //public LMEMarginLineVM LMEMarginLineBind(Quota quota)
        //{
        //    var lmeMarginLine = new LMEMarginLineVM
        //                            {
        //                                QuotaId = quota.Id,
        //                                BPartnerId = quota.Contract.BusinessPartner.Id,
        //                                BPName = Properties.Resources.BP + "：" + quota.Contract.BusinessPartner.ShortName,
        //                                QuotaNo = quota.QuotaNo,
        //                                QuotaQuantity = quota.Quantity,
        //                                PricingQuantity = quota.Pricings.Sum(p => p.PricingQuantity),
        //                                Payment =
        //                                    quota.CommercialInvoices.Where(
        //                                        t => t.InvoiceType == (int) CommercialInvoiceType.Provisional).Sum(
        //                                            p => p.Amount)
        //                            };
        //    if (quota.CommercialInvoices.Count > 0)
        //    {
        //        lmeMarginLine.PaymentStr = string.Format("{0:N}", lmeMarginLine.Payment) +
        //                                   quota.CommercialInvoices.FirstOrDefault().Currency.Name;
        //    }
        //    //含升贴水的市价
        //    lmeMarginLine.LMEPrice = LMEMarketPrice(quota) + (quota.Premium ?? 0);

        //    if (quota.PricingSide == (int) PricingSide.OurSide)
        //    {
        //        if (quota.Contract.ContractType == (int) ContractType.Purchase)
        //        {
        //            //采购我方点价
        //            lmeMarginLine.InitMargin = ProvisionalInvoiceTotal(quota)*
        //                                       ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)/
        //                                       (1 + ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01));
        //            lmeMarginLine.OurAppendMargin = GetFundFlowAmount(quota, (int) FundFlowType.Pay);
        //            lmeMarginLine.TheirReturnMargin = GetFundFlowAmount(quota, (int) FundFlowType.Receive);
        //            lmeMarginLine.ExitPrice = (ProvisionalInvoiceTotal(quota) + lmeMarginLine.OurAppendMargin -
        //                                       lmeMarginLine.TheirReturnMargin - GetPricingAmount(quota))/
        //                                      GetUnPricingQuantity(quota);
        //            lmeMarginLine.Amount = lmeMarginLine.LMEPrice*GetUnPricingQuantity(quota)*
        //                                   (1 + ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)) -
        //                                   lmeMarginLine.ExitPrice*GetUnPricingQuantity(quota);
        //            if (lmeMarginLine.Amount > 0)
        //            {
        //                lmeMarginLine.OurNeedToAppendMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //            else
        //            {
        //                lmeMarginLine.TheirNeedToReturnMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //        }
        //        else
        //        {
        //            //销售我方点价
        //            lmeMarginLine.InitMargin = ProvisionalInvoiceTotal(quota)*
        //                                       ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)/
        //                                       (1 - ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01));
        //            lmeMarginLine.OurAppendMargin = GetFundFlowAmount(quota, (int) FundFlowType.Pay);
        //            lmeMarginLine.TheirReturnMargin = GetFundFlowAmount(quota, (int) FundFlowType.Receive);
        //            lmeMarginLine.ExitPrice = (ProvisionalInvoiceTotal(quota) - lmeMarginLine.OurAppendMargin +
        //                                       lmeMarginLine.TheirReturnMargin - GetPricingAmount(quota))/
        //                                      GetUnPricingQuantity(quota);
        //            lmeMarginLine.Amount = lmeMarginLine.LMEPrice*GetUnPricingQuantity(quota)*
        //                                   (1 - ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)) -
        //                                   lmeMarginLine.ExitPrice*GetUnPricingQuantity(quota);
        //            if (lmeMarginLine.Amount > 0)
        //            {
        //                lmeMarginLine.TheirNeedToReturnMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //            else
        //            {
        //                lmeMarginLine.OurNeedToAppendMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //        }
        //    }
        //    else if (quota.PricingSide == (int) PricingSide.TheirSide)
        //    {
        //        if (quota.Contract.ContractType == (int) ContractType.Purchase)
        //        {
        //            //采购对方点价
        //            lmeMarginLine.InitMargin = ProvisionalInvoiceTotal(quota)*
        //                                       ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)/
        //                                       (1 - ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01));
        //            lmeMarginLine.TheirAppendMargin = GetFundFlowAmount(quota, (int) FundFlowType.Receive);
        //            lmeMarginLine.OurReturnMargin = GetFundFlowAmount(quota, (int) FundFlowType.Pay);
        //            lmeMarginLine.ExitPrice = GetUnPricingQuantity(quota)==0?0:(ProvisionalInvoiceTotal(quota) - lmeMarginLine.TheirAppendMargin +
        //                                       lmeMarginLine.OurReturnMargin - GetPricingAmount(quota))/
        //                                      GetUnPricingQuantity(quota);
        //            lmeMarginLine.Amount = lmeMarginLine.LMEPrice*GetUnPricingQuantity(quota)*
        //                                   (1 - ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)) -
        //                                   lmeMarginLine.ExitPrice*GetUnPricingQuantity(quota);
        //            if (lmeMarginLine.Amount > 0)
        //            {
        //                lmeMarginLine.OurNeedToReturnMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //            else
        //            {
        //                lmeMarginLine.TheirNeedToAppendMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //        }
        //        else
        //        {
        //            //销售对方点价
        //            lmeMarginLine.InitMargin = ProvisionalInvoiceTotal(quota)*
        //                                       ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)/
        //                                       (1 + ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01));
        //            lmeMarginLine.TheirAppendMargin = GetFundFlowAmount(quota, (int) FundFlowType.Receive);
        //            lmeMarginLine.OurReturnMargin = GetFundFlowAmount(quota, (int) FundFlowType.Pay);
        //            lmeMarginLine.ExitPrice = (ProvisionalInvoiceTotal(quota) + lmeMarginLine.TheirAppendMargin -
        //                                       lmeMarginLine.OurReturnMargin - GetPricingAmount(quota))/
        //                                      GetUnPricingQuantity(quota);
        //            lmeMarginLine.Amount = lmeMarginLine.LMEPrice*GetUnPricingQuantity(quota)*
        //                                   (1 + ((MarginRatio == null ? 0 : (decimal) MarginRatio)*(decimal) 0.01)) -
        //                                   lmeMarginLine.ExitPrice*GetUnPricingQuantity(quota);
        //            if (lmeMarginLine.Amount > 0)
        //            {
        //                lmeMarginLine.TheirNeedToAppendMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //            else
        //            {
        //                lmeMarginLine.OurNeedToReturnMargin =
        //                    Math.Abs(lmeMarginLine.Amount == null ? 0 : (decimal) lmeMarginLine.Amount);
        //            }
        //        }
        //    }

        //    return lmeMarginLine;
        //}

        ////LME最近市价
        //public decimal LMEMarketPrice(Quota quota)
        //{
        //    using (var marketPriceService = 
        //        SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc))
        //    {
        //        decimal amt = marketPriceService.GetLMELatestPrice(quota.Commodity);
        //        return amt;
        //    }
        //}

        //// ∑（临时发票金额 / 临时发票比率）
        //public decimal ProvisionalInvoiceTotal(Quota quota)
        //{
        //    decimal amt = 0;
        //    foreach (CommercialInvoice item in quota.CommercialInvoices)
        //    {
        //        if (item.InvoiceType == (int) CommercialInvoiceType.Provisional)
        //        {
        //            if (item.ExchangeRate.HasValue && item.ExchangeRate != 0)
        //            {
        //                amt += ((item.Amount == null ? 0 : (decimal) item.Amount)/item.ExchangeRate.Value);
        //            }
        //        }
        //    }
        //    return amt;
        //}

        ///// <summary>
        ///// 获取已追加/退还保证金 由现金科目为“现货点价保证金”的现金收付款
        ///// </summary>
        ///// <param name="quota"></param>
        ///// <param name="rorP">R收款 P付款</param>
        ///// <returns></returns>
        //public decimal GetFundFlowAmount(Quota quota, int rorP)
        //{
        //    decimal amt = 0;
        //    FinancialAccount fa;
        //    using (
        //        var financialAccountService =
        //            SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
        //    {
        //        string strInfo = string.Format("it.Name={0} and it.IsDeleted=false", "'现货点价保证金'");
        //        fa = financialAccountService.Select(strInfo, null, null).FirstOrDefault();
        //    }
        //    if (fa == null)
        //    {
        //        return 0;
        //    }
        //    foreach (FundFlow item in quota.FundFlows)
        //    {
        //        if (item.FinancialAccountId == fa.Id && item.RorP == rorP)
        //        {
        //            amt += (item.Amount == null ? 0 : (decimal) item.Amount);
        //        }
        //    }
        //    return amt;
        //}

        ////∑（已点数量 * 点价价格）
        //public decimal GetPricingAmount(Quota quota)
        //{
        //    decimal amt = 0;
        //    foreach (Pricing item in quota.Pricings)
        //    {
        //        amt += ((item.PricingQuantity == null ? 0 : (decimal) item.PricingQuantity)*
        //                (item.FinalPrice == null ? 0 : (decimal) item.FinalPrice));
        //    }
        //    return amt;
        //}

        ////未点数量
        //public decimal GetUnPricingQuantity(Quota quota)
        //{
        //    decimal qty = 0;
        //    foreach (Pricing item in quota.Pricings)
        //    {
        //        qty += (item.PricingQuantity == null ? 0 : (decimal) item.PricingQuantity);
        //    }
        //    qty = (quota.Quantity == null ? 0 : (decimal) quota.Quantity) - qty;
        //    return qty;
        //}

        #endregion

        #endregion
    }

    //报表Entity
    public class LMEMarginLineVM
    {
        public int BPartnerId { get; set; }
        public string BPName { get; set; }
        public int QuotaId { get; set; }
        public string QuotaNo { get; set; }
        public decimal? QuotaQuantity { get; set; }
        public decimal? PricingQuantity { get; set; }
        public decimal? Payment { get; set; } //已付
        public string PaymentStr { get; set; } //已付+币种
        public decimal? InitMargin { get; set; } //初始保证金
        public decimal? LMEPrice { get; set; } //lme最新价
        public decimal? ExitPrice { get; set; } //止损价
        public decimal? Amount { get; set; } //金额

        public decimal? OurAppendMargin { get; set; } //我方已追加保证金
        public decimal? OurReturnMargin { get; set; } //我方已退还保证金
        public decimal? TheirAppendMargin { get; set; } //对已方追加保证金
        public decimal? TheirReturnMargin { get; set; } //对方已退还保证金

        public decimal? OurNeedToAppendMargin { get; set; } //我方需追加保证金
        public decimal? OurNeedToReturnMargin { get; set; } //我方需退还保证金
        public decimal? TheirNeedToAppendMargin { get; set; } //对方需追加保证金
        public decimal? TheirNeedToReturnMargin { get; set; } //对方需退还保证金
    }
}