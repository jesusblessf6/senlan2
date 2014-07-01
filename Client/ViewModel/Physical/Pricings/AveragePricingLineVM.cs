using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.MarketPriceServiceReference;
using Client.RateServiceReference;
//using Client.UnpricingServiceReference;
using Client.View.Physical.Pricings;
using DBEntity;
using DBEntity.EnumEntity;
using PriceDBEntity;
using Utility.ServiceManagement;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Physical.Pricings
{
    public class AveragePricingLineVM : BaseVM
    {
        #region Member

        private decimal? _averagePricing = 0; //均价
        public List<AveragePricingLineList> AveragePricingLines; //数据集合
        public List<AveragePricingLineList> AveragePricingLines2; //分页所用数据集合
        private decimal? _sumPricing = 0; //总价格
        private int _averagePricingLineCount; //记录总数
        private Commodity _commodity;
        private List<Currency> _currencys;

        private decimal? _eRate;
        private DateTime? _endDate;
        private decimal? _finalPrice; //最终价格
        private string _getcurrencyName; //点价基准币种名称
        private decimal? _premium; //升贴水价格
        private int? _pricingBasisId;
        private int? _pricingCurrencyId;
        private DateTime? _pricingDate;

        private int _pricingLineForm;
        private int _pricingLineTo;
        private int _pricingLineTotleCount;
        private int _settlementCurrencyId;
        private string _settlementcurrencyName; //批次结算币种名称
        private DateTime? _startDate;

        private int _tradeTypeId;

        private List<DateRangePriceClass> _prices;

        #endregion

        #region Property

        public decimal? FinalPrice
        {
            get { return _finalPrice; }
            set
            {
                if (_finalPrice != value)
                {
                    _finalPrice = value;
                    Notify("FinalPrice");
                }
            }
        }

        public decimal? Premium
        {
            get { return _premium; }
            set
            {
                if (_premium != value)
                {
                    _premium = value;
                    Notify("Premium");
                }
            }
        }

        public List<Currency> Currencys
        {
            get { return _currencys; }
            set
            {
                _currencys = value;
                Notify("Currencys");
            }
        }

        public int? PricingCurrencyId
        {
            get { return _pricingCurrencyId; }
            set
            {
                _pricingCurrencyId = value;
                Notify("PricingCurrencyId");
            }
        }

        public int SettlementCurrencyId
        {
            get { return _settlementCurrencyId; }
            set
            {
                _settlementCurrencyId = value;
                Notify("SettlementCurrencyId");
            }
        }

        public DateTime? PricingDate
        {
            get { return _pricingDate; }
            set
            {
                if (_pricingDate != value)
                {
                    _pricingDate = value;
                    Notify("PricingDate");
                }
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

        private Commodity Commodity
        {
            get { return _commodity; }
            set
            {
                if (_commodity != value)
                {
                    _commodity = value;
                    Notify("Commodity");
                }
            }
        }

        public int? PricingBasisId
        {
            get { return _pricingBasisId; }
            set
            {
                _pricingBasisId = value;
                Notify("PricingBasisId");
            }
        }

        public string GetCurrencyName
        {
            get { return _getcurrencyName; }
            set
            {
                if (_getcurrencyName != value)
                {
                    _getcurrencyName = value;
                    Notify("GetCurrencyName");
                }
            }
        }

        public string SettlementcurrencyName
        {
            get { return _settlementcurrencyName; }
            set
            {
                if (_settlementcurrencyName != value)
                {
                    _settlementcurrencyName = value;
                    Notify("SettlementcurrencyName");
                }
            }
        }

        public decimal? ERate
        {
            get { return _eRate; }
            set
            {
                if (_eRate != value)
                {
                    _eRate = value;
                    Notify("ERate");
                }
            }
        }

        public int AveragePricingLineCount
        {
            get { return _averagePricingLineCount; }
            set
            {
                if (_averagePricingLineCount != value)
                {
                    _averagePricingLineCount = value;
                    Notify("AveragePricingLineCount");
                }
            }
        }

        public int PricinglineTotleCount
        {
            get { return _pricingLineTotleCount; }
            set
            {
                if (_pricingLineTotleCount != value)
                {
                    _pricingLineTotleCount = value;
                    Notify("PricinglineTotleCount");
                }
            }
        }

        public int PricingLineForm
        {
            get { return _pricingLineForm; }
            set
            {
                if (_pricingLineForm != value)
                {
                    _pricingLineForm = value;
                    Notify("PricingLineForm");
                }
            }
        }

        public int PricingLineTo
        {
            get { return _pricingLineTo; }
            set
            {
                if (_pricingLineTo != value)
                {
                    _pricingLineTo = value;
                    Notify("PricingLineTo");
                }
            }
        }


        public int TradeTypeId
        {
            get { return _tradeTypeId; }
            set
            {
                if (_tradeTypeId != value)
                {
                    _tradeTypeId = value;
                    Notify("TradeTypeId");
                }
            }
        }

        #endregion

        #region Constructor

        public AveragePricingLineVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public AveragePricingLineVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            _prices = new List<DateRangePriceClass>();
            if (ObjectId > 0)
            {
                Quota quota;
                using (
                var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    quota = quotaService.FetchById(ObjectId,
                                                                new List<string>
                                                                    {
                                                                        "Commodity",
                                                                        "Currency",
                                                                        "Contract",
                                                                        "Pricings"
                                                                    });
                    FilterDeleted(quota.Pricings);
                    if (quota != null)
                    {
                        Premium = quota.Premium;
                        //TODO::价格币种修改
                        Commodity = quota.Commodity;
                        PricingBasisId = quota.PricingBasis;//点价基准
                        StartDate = quota.PricingStartDate; //点价开始日期
                        EndDate = quota.PricingEndDate;     //点价结束日期
                        if (quota.PricingStatus == (int)PricingStatus.Complete)//如果点价完成
                        {
                            Premium = quota.Pricings[0].Premium;        //升贴水
                            FinalPrice = quota.Pricings[0].FinalPrice;  //最终价格
                            ERate = quota.Pricings[0].ExchangeRate;     //利率
                            PricingDate = quota.Pricings[0].PricingDate;//日期
                        }
                        TradeTypeId = quota.Contract.TradeType;
                    }
                }

                #region 列表明细

                using (var marketPriceService = SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc))
                {
                    if (Convert.ToInt32(PricingBasis.LME3M) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<LME_OfficialPrice> officialPrice = marketPriceService.GetLME3MSettlementPriceOfficialPrice(Commodity, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
                        officialPrice.ForEach(o=>_prices.Add(new DateRangePriceClass {Date=o.TradeDate,Price=o.Month3Sell}));
                        
                        if (officialPrice != null)
                        {
                            //币种名称
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.LME3M)), quota);
                        }
                        LME3MOfficialPriceList(officialPrice);
                        //平均价、最终价格、集合
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.LME3M), _sumPricing);
                    }
                    else if (Convert.ToInt32(PricingBasis.LMECash) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<LME_OfficialPrice> officialPrice =marketPriceService.GetLMECashSettlementPriceOfficialPrice(Commodity, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
                        officialPrice.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.TradeDate, Price = o.CashSell }));
                        if (officialPrice != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.LMECash)), quota);
                        }
                        LMECashOfficialPriceList(officialPrice);
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.LMECash), _sumPricing);
                    }
                    else if (Convert.ToInt32(PricingBasis.SGESettlement) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        //这个上海黄金交易所的目前不知道从那里取值。
                    }
                    else if (Convert.ToInt32(PricingBasis.SHFE01) <= PricingBasisId && (Convert.ToInt32(PricingBasis.SHFE12) >= PricingBasisId))
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        int year = quota.PromptYear;
                        int month = quota.PromptMonth;
                        List<SHFE_MonthlySettlePrice> monthlySettlePrice =marketPriceService.GetSHFEMonthlySettlementPrice(Commodity, Convert.ToDateTime(StartDate),Convert.ToDateTime(EndDate),year,month);
                        monthlySettlePrice.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.TradeDate, Price = o.SettlePrice }));
                        if (monthlySettlePrice != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(PricingBasisId.Value), quota);
                        }
                        SHFEMonthlySettlePriceList(monthlySettlePrice, PricingBasisId.Value);
                        AverageLine(quota, AveragePricingLines, PricingBasisId.Value, _sumPricing);
                    }
                    else if (Convert.ToInt32(PricingBasis.SHX) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<SMM_SMMWebPrice> shmetPricelist = marketPriceService.GetSHMETWebPrice(Commodity,Convert.ToDateTime(StartDate),Convert.ToDateTime(EndDate));
                        shmetPricelist.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.UpdateTime, Price = o.AveragePrice }));
                        if (shmetPricelist != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.SHX)), quota);
                        }
                        SHXSMMWebPriceList(shmetPricelist);
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.SHX), _sumPricing);
                    }
                    else if (Convert.ToInt32(PricingBasis.SHY) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<SMM_SMMWebPrice> smmPricelist = marketPriceService.GetSMMWebPrice(Commodity,Convert.ToDateTime(StartDate),Convert.ToDateTime(EndDate));
                        smmPricelist.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.UpdateTime, Price = o.AveragePrice }));
                        if (smmPricelist != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.SHY)), quota);
                        }
                        SHYSMMWebPriceList(smmPricelist, GetCurrencyName);
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.SHY), _sumPricing);
                    }
                    else if(Convert.ToInt32(PricingBasis.PCJ) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<SMM_SMMWebPrice> smmPriceList = marketPriceService.GetPCJWebPrice(Commodity, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
                        smmPriceList.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.UpdateTime, Price = o.AveragePrice }));
                        if(smmPriceList != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.PCJ)), quota);
                        }
                        PCJWebPriceList(smmPriceList, GetCurrencyName);
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.PCJ), _sumPricing);
                    }
                    else if(Convert.ToInt32(PricingBasis.NC) == PricingBasisId)
                    {
                        AveragePricingLines = new List<AveragePricingLineList>();
                        List<SMM_SMMWebPrice> smmPriceList = marketPriceService.GetNCWebPrice(Commodity, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
                        smmPriceList.ForEach(o => _prices.Add(new DateRangePriceClass { Date = o.UpdateTime, Price = o.AveragePrice }));
                        if (smmPriceList != null)
                        {
                            GetCurrencyName = CurrencyName(CurrentPriceType.GetCurrentType(Convert.ToInt32(PricingBasis.NC)), quota);
                        }
                        NCWebPriceList(smmPriceList, GetCurrencyName);
                        AverageLine(quota, AveragePricingLines, Convert.ToInt32(PricingBasis.NC), _sumPricing);
                    }
                }

                #endregion
            }
        }


        #region LME3MPrice、LMECASHPrice、SHFE当月结算价、上海金属网、上海有色网

        /// <summary>
        /// LME3MPrice：得到LME3MPrice的集合、计算总价格
        /// </summary>
        /// <param name="officialPrice"></param>
        private void LME3MOfficialPriceList(IEnumerable<LME_OfficialPrice> officialPrice)
        {
            foreach (LME_OfficialPrice lme3M in officialPrice)
            {
                //计算总价格
                _sumPricing += lme3M.Month3Sell == null ? 0 : Convert.ToDecimal(lme3M.Month3Sell);
                var apll = new AveragePricingLineList
                {
                    StartDate = Convert.ToDateTime(lme3M.TradeDate).ToString("yyyy-MM-dd"),
                    Pricing = lme3M.Month3Sell,
                    Currency = GetCurrencyName,
                    PricingBasisId = Convert.ToInt32(PricingBasis.LME3M)
                };
                AveragePricingLines.Add(apll);
            }
        }

        /// <summary>
        /// LMECASHPrice：得到LMECASHPrice的集合、计算总价格
        /// </summary>
        /// <param name="officialPrice"></param>
        private void LMECashOfficialPriceList(IEnumerable<LME_OfficialPrice> officialPrice)
        {
            foreach (LME_OfficialPrice lmeCash in officialPrice)
            {
                //计算总价格
                _sumPricing += lmeCash.CashSell == null ? 0 : Convert.ToDecimal(lmeCash.CashSell);
                var apll = new AveragePricingLineList
                {
                    StartDate = Convert.ToDateTime(lmeCash.TradeDate).ToString("yyyy-MM-dd"),
                    Pricing = lmeCash.CashSell,
                    Currency = GetCurrencyName,
                    PricingBasisId = Convert.ToInt32(PricingBasis.LMECash)
                };
                AveragePricingLines.Add(apll);
            }
        }

        /// <summary>
        /// SHFE当月结算价：得到当月结算价的集合、计算总价格
        /// </summary>
        /// <param name="monthlySettlePrice"></param>
        /// <param name="pb"></param>
        private void SHFEMonthlySettlePriceList(IEnumerable<SHFE_MonthlySettlePrice> monthlySettlePrice,int pb)
        {
            foreach (SHFE_MonthlySettlePrice shfeSettlement in monthlySettlePrice)
            {
                //计算总价格
                _sumPricing += shfeSettlement.SettlePrice == null ? 0 : Convert.ToDecimal(shfeSettlement.SettlePrice);
                
                var apll = new AveragePricingLineList
                {
                    StartDate =
                        Convert.ToDateTime(shfeSettlement.TradeDate).ToString("yyyy-MM-dd"),
                    Pricing = shfeSettlement.SettlePrice,
                    Currency = GetCurrencyName,
                    PricingBasisId = pb
                };
                AveragePricingLines.Add(apll);
            }
        }


        /// <summary>
        /// 上海金属网：得到上海金属网的集合、计算总价格
        /// </summary>
        /// <param name="shmetPricelist"></param>
        private void SHXSMMWebPriceList(IEnumerable<SMM_SMMWebPrice> shmetPricelist)
        {
            foreach (SMM_SMMWebPrice shmetPrice in shmetPricelist)
            {
                //计算总价格
                _sumPricing += shmetPrice.AveragePrice == null ? 0 : Convert.ToDecimal(shmetPrice.AveragePrice);
                var apll = new AveragePricingLineList
                               {
                                   StartDate = Convert.ToDateTime(shmetPrice.UpdateTime).ToString("yyyy-MM-dd"),
                                   Pricing = shmetPrice.AveragePrice,
                                   Currency = GetCurrencyName,
                                   PricingBasisId = Convert.ToInt32(PricingBasis.SHX)
                               };
                AveragePricingLines.Add(apll);
            }
        }

        /// <summary>
        /// 上海有色网：得到上海有色网的集合、计算总价格
        /// </summary>
        /// <param name="smmPricelist"></param>
        /// <param name="currencyName">币种</param>
        private void SHYSMMWebPriceList(IEnumerable<SMM_SMMWebPrice> smmPricelist, string currencyName)
        {
            foreach (SMM_SMMWebPrice smmPrice in smmPricelist)
            {
                //计算总价格
                _sumPricing += smmPrice.AveragePrice == null ? 0 : Convert.ToDecimal(smmPrice.AveragePrice);
                var apll = new AveragePricingLineList
                {
                    StartDate = Convert.ToDateTime(smmPrice.UpdateTime).ToString("yyyy-MM-dd"),
                    Pricing = smmPrice.AveragePrice,
                    Currency = currencyName,
                    PricingBasisId = Convert.ToInt32(PricingBasis.SHY)
                };
                AveragePricingLines.Add(apll);
            }
        }

        private void PCJWebPriceList(IEnumerable<SMM_SMMWebPrice> smmPricelist, string currencyName)
        {
            foreach (SMM_SMMWebPrice smmPrice in smmPricelist)
            {
                //计算总价格
                _sumPricing += smmPrice.AveragePrice == null ? 0 : Convert.ToDecimal(smmPrice.AveragePrice);
                var apll = new AveragePricingLineList
                {
                    StartDate = Convert.ToDateTime(smmPrice.UpdateTime).ToString("yyyy-MM-dd"),
                    Pricing = smmPrice.AveragePrice,
                    Currency = currencyName,
                    PricingBasisId = Convert.ToInt32(PricingBasis.PCJ)
                };
                AveragePricingLines.Add(apll);
            }
        }

        private void NCWebPriceList(IEnumerable<SMM_SMMWebPrice> smmPricelist, string currencyName)
        {
            foreach (SMM_SMMWebPrice smmPrice in smmPricelist)
            {
                //计算总价格
                _sumPricing += smmPrice.AveragePrice == null ? 0 : Convert.ToDecimal(smmPrice.AveragePrice);
                var apll = new AveragePricingLineList
                {
                    StartDate = Convert.ToDateTime(smmPrice.UpdateTime).ToString("yyyy-MM-dd"),
                    Pricing = smmPrice.AveragePrice,
                    Currency = currencyName,
                    PricingBasisId = Convert.ToInt32(PricingBasis.NC)
                };
                AveragePricingLines.Add(apll);
            }
        }

        #endregion

        #region 返回币种名称、计算平均价、计算最终价格、分页集合

        /// <summary>
        /// 返回币种名称
        /// </summary>
        /// <param name="code">币种代码</param>
        /// <param name="quota"> </param>
        /// <returns></returns>
        private string CurrencyName(string code, Quota quota)
        {
            string str = ""; //点价币种
            Currency currency; //点价币种对象
            Currency currency2; //结算币种对象
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                currency = currencyService.GetCurrencyByCode(code);
                currency2 = currencyService.GetCurrencyByCode("CNY");
            }

            if (currency != null)
            {
                str = currency.Name; //点价币种
                PricingCurrencyId = currency.Id;
                if (quota.PricingStatus != (int)PricingStatus.Complete)
                {
                    using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                    {
                        //TODO::价格币种修改
                        ERate = rateService.GetExchangeRate(currency2.Id,
                                                            Convert.ToInt32(quota.PricingCurrencyId),
                                                            CurrentUser.Id);
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 求平均价、最终价格、分页集合
        /// </summary>
        /// <param name="quota"> </param>
        /// <param name="averagePricingLines">平均价点价明细集合</param>
        /// <param name="pricingBasisId">点价基准</param>
        /// <param name="sumPricing">总价格</param>
        protected void AverageLine(Quota quota, List<AveragePricingLineList> averagePricingLines, int pricingBasisId, decimal? sumPricing)
        {
            //总记录
            AveragePricingLineCount = averagePricingLines.Count();
            if (AveragePricingLineCount != 0)
            {
                //平均价
                _averagePricing = AveragePricings(averagePricingLines, sumPricing);
                //最终价格
                FinalPrice = FinalPrices(_averagePricing, Premium, quota);
                //集合
                LoadAveragePricingLine(averagePricingLines);
            }
            else
            {
                MessageBox.Show(ResPricing.PricingNotFound);
            }
        }

        /// <summary>
        /// 集合
        /// </summary>
        /// <param name="averagePricingLines"></param>
        private void LoadAveragePricingLine(IEnumerable<AveragePricingLineList> averagePricingLines)
        {
            //分页所用集合
            if (AveragePricingLines2 != null)
            {
                AveragePricingLines2.Clear();
            }
            AveragePricingLines2 = averagePricingLines.Skip(PricingLineForm).Take(PricingLineTo).ToList();
        }

        /// <summary>
        /// 计算平均价
        /// </summary>
        /// <param name="averagePricingLines">平均价点价明细集合</param>
        /// <param name="sumPricing">总价格</param>
        /// <returns></returns>
        private decimal? AveragePricings(IEnumerable<AveragePricingLineList> averagePricingLines, decimal? sumPricing)
        {
            //过滤价格为零的记录
            List<AveragePricingLineList> lines = averagePricingLines.Where(o => o.Pricing != null && o.Pricing != 0).ToList();
            decimal? averagePricing = Math.Round(Convert.ToDecimal((sumPricing??0) / lines.Count()), RoundRules.PRICE, MidpointRounding.AwayFromZero);
            return averagePricing;
        }

        /// <summary>
        /// 计算最终价格
        /// </summary>
        /// <param name="averagePricing">平均价</param>
        /// <param name="premium">升贴水</param>
        /// <param name="quota"></param>
        /// <returns></returns>
        private decimal? FinalPrices(decimal? averagePricing, decimal? premium, Quota quota)
        {
            _sumPricing = averagePricing + premium;
            if (quota.PricingStatus != (int)PricingStatus.Complete)
            {
                _finalPrice = Math.Round(Convert.ToDecimal(_sumPricing), RoundRules.PRICE, MidpointRounding.AwayFromZero);
            }
            else
            {
                _finalPrice = Math.Round(Convert.ToDecimal(_finalPrice), RoundRules.PRICE, MidpointRounding.AwayFromZero);
            }
            return _finalPrice;
        }

        #endregion

        /// <summary>
        /// 分页的时候用到
        /// </summary>
        public void LoadAveragePricingLine()
        {
            if (AveragePricingLines2 != null)
            {
                AveragePricingLines2.Clear();
            }
            AveragePricingLines2 = AveragePricingLines.Skip(PricingLineForm - 1).Take(PricingLineTo).ToList(); //获取分页集合
            //创建一条新数据
            var apll2 = new AveragePricingLineList
                            {
                                StartDate = Properties.Resources.AveragePrice,
                                Pricing = Convert.ToDouble(_averagePricing),
                                Currency = GetCurrencyName,
                                PricingBasisId = PricingBasisId
                            };
            AveragePricingLines2.Add(apll2); //插入到分页集合中
        }

        protected override void Create()
        {
        }

        protected override void Update()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.FetchById(ObjectId, new List<string> { "Unpricings", "Pricings" });
                var pricing = new Pricing();
                if (quota != null)
                {
                    if (quota.PricingStatus != (int)PricingStatus.Complete)
                    {
                        FilterDeleted(quota.Unpricings);
                        Unpricing unpricing = quota.Unpricings.FirstOrDefault();

                        if (unpricing != null)
                        {
                            pricing.QuotaId = quota.Id;
                            pricing.PricingQuantity = unpricing.UnpricingQuantity;
                            pricing.StartPricingDate = quota.PricingStartDate;//.StartPricingDate;
                            pricing.EndPricingDate = quota.PricingEndDate;//.EndPricingDate;
                            pricing.DeferFee = unpricing.DeferFee;
                            pricing.UnpricingId = unpricing.Id;
                            pricing.Premium = Premium;
                            pricing.FinalPrice = FinalPrice;
                            pricing.PricingBasis = PricingBasisId;
                            pricing.CurrencyId = PricingCurrencyId;
                            pricing.ExchangeRate = ERate;
                            pricing.PricingDate = PricingDate;

                            quotaService.CompleteUnpricingtoPricing(unpricing.Id, pricing, unpricing.QuotaId, CurrentUser.Id);
                        }
                    }
                    else
                    {
                        FilterDeleted(quota.Pricings);
                        pricing = quota.Pricings.FirstOrDefault();
                        if (pricing != null)
                        {
                            pricing.FinalPrice = FinalPrice;
                            pricing.ExchangeRate = ERate;
                            pricing.PricingDate = PricingDate;
                            quotaService.UpdatePricing(pricing, CurrentUser.Id);
                        }
                    }
                }

                if (quota.RelQuotaId != null && quota.IsAutoGenerated)
                {
                    Quota quota2 = quotaService.FetchById(quota.RelQuotaId.Value, new List<string> { "Unpricings", "Pricings" });
                    var pricing2 = new Pricing();
                    if (quota2 != null)
                    {
                        if (quota2.PricingStatus != (int)PricingStatus.Complete)
                        {
                            FilterDeleted(quota2.Unpricings);
                            Unpricing unpricing = quota2.Unpricings.FirstOrDefault();

                            if (unpricing != null)
                            {
                                pricing2.QuotaId = quota2.Id;
                                pricing2.PricingQuantity = unpricing.UnpricingQuantity;
                                pricing2.StartPricingDate = quota2.PricingStartDate;//.StartPricingDate;
                                pricing2.EndPricingDate = quota2.PricingEndDate;//.EndPricingDate;
                                pricing2.DeferFee = unpricing.DeferFee;
                                pricing2.UnpricingId = unpricing.Id;
                                pricing2.Premium = Premium;
                                pricing2.FinalPrice = FinalPrice;
                                pricing2.PricingBasis = PricingBasisId;
                                pricing2.CurrencyId = PricingCurrencyId;
                                pricing2.ExchangeRate = ERate;
                                pricing2.PricingDate = PricingDate;

                                quotaService.CompleteUnpricingtoPricing(unpricing.Id, pricing2, unpricing.QuotaId, CurrentUser.Id);
                            }
                        }
                        else
                        {
                            FilterDeleted(quota2.Pricings);
                            pricing2 = quota2.Pricings.FirstOrDefault();
                            if (pricing2 != null)
                            {
                                pricing2.FinalPrice = FinalPrice;
                                pricing2.ExchangeRate = ERate;
                                pricing2.PricingDate = PricingDate;
                                quotaService.UpdatePricing(pricing2, CurrentUser.Id);
                            }
                        }
                    }
                }
                
            }
        }

        public override bool Validate()
        {
            return true;
        }

        /// <summary>
        /// 判断是否到点价结束日期
        /// </summary>
        /// <returns></returns>
        public bool Verification()
        {
            #region 必填控件验证
            if (!ERate.HasValue)
            {
                throw new Exception(Properties.Resources.ExchangeRateNotNull);
            }
            if (!PricingDate.HasValue)
            {
                throw new Exception(ResPricing.PricingDateNotNull);
            }
            #endregion
            if (ObjectId != 0)
            {
                using (
                    var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    Quota up = quotaService.FetchById(ObjectId, null);
                    DateTime? endTime = up.PricingEndDate;
                    DateTime max = _prices.Max(o => o.Date).Value;
                    if (endTime > max)
                    {
                        return false;
                    }
                    
                    return true;
                }
            }
            return false;
        }

        #endregion
    }

    public class AveragePricingLineList
    {
        public double? Pricing { get; set; } //价格
        public string Currency { get; set; } //币种
        public int? PricingBasisId { get; set; } //点价基准类型
        public string StartDate { get; set; } //日期
    }

    public class DateRangePriceClass
    {
        public DateTime? Date { get; set; }
        public double? Price { get; set; }
    }
}