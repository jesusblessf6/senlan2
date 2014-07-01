using System;
using System.Collections.Generic;
using System.Linq;
using DBEntity;
using PriceDBEntity;
using DBEntity.EnumEntity;

namespace Services.Helper.MarketPrice
{
    public class MarketPriceManager
    {
        #region  拆借利率

        /// <summary>
        /// 获取所有Lme拆借利率种类
        /// </summary>
        public static Dictionary<int, string> GetSelectLmeCommodity()
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                var dict = new Dictionary<int, string>();
                try
                {
                    foreach (var commodity in ctx.LME_Commodity.Where(t => t.Name.Contains("年") || t.Name.Contains("月")))
                    {
                        dict.Add(commodity.LME_CommodityID,commodity.Name);
                    }
                }
                catch
                {
                    dict = null;
                }
                return dict;
            }
        }

        /// <summary>
        /// 拆借利率价格
        /// </summary>
        /// <param name="id">拆借利率Id</param>
        /// <returns></returns>
        public static decimal GetSelectLMELastedPrice(int id)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    var lmeLastedPrice = ctx.LME_LastedPrice.FirstOrDefault(p => p.LME_CommodityID == id);
                    return Convert.ToDecimal(lmeLastedPrice.LastedPrice);
                }
                catch
                {
                    return 0;
                }
            }
        }

        #endregion

        #region LME价格

        /// <summary>
        /// 获得LME3月官方结算价
        /// </summary>
        /// <param name="comm">金属类型</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        public static decimal GetLME3MSettlementPrice(Commodity comm, DateTime tradeDate)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    LME_OfficialPrice lmeOfficialPrice = null;
                    DateTime date = tradeDate;
                    while (lmeOfficialPrice == null)
                    {
                        lmeOfficialPrice = ctx.LME_OfficialPrice.FirstOrDefault(p => p.LME_CommodityID == comm.Id && p.TradeDate == date.Date);
                        date = date.AddDays(-1);
                    }
                    return Convert.ToDecimal(lmeOfficialPrice.Month3Sell);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获得LME现货官方结算价
        /// </summary>
        /// <param name="comm">金属品种</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        public static decimal GetLMECashSettlementPrice(Commodity comm, DateTime tradeDate)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    LME_OfficialPrice lmeOfficialPrice = null;
                    DateTime date = tradeDate;
                    while (lmeOfficialPrice == null)
                    {
                        lmeOfficialPrice = ctx.LME_OfficialPrice.FirstOrDefault(p => p.LME_CommodityID == comm.Id && p.TradeDate == date.Date);
                        date = date.AddDays(-1);
                    }
                    return Convert.ToDecimal(lmeOfficialPrice.CashSell);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获得LME三个月内每天到期的价格
        /// </summary>
        public static decimal GetLMEDailySettlementPrice(Commodity comm, DateTime tradeDate, DateTime prompDate)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    var firstOrDefault = ctx.LME_EvaDay.FirstOrDefault(p => p.LME_CommodityID == comm.Id && p.TradeDate == tradeDate.Date && p.PromptDate == prompDate.Date);
                    if (firstOrDefault != null)
                        return Convert.ToDecimal(firstOrDefault.Price);

                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获得LME最新价格
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static decimal GetLMELatestPrice(Commodity comm)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    var firstOrDefault = ctx.LME_LastedPrice.FirstOrDefault(p => p.LME_CommodityID == comm.Id);
                    if (firstOrDefault != null)
                        return Convert.ToDecimal(firstOrDefault.LastedPrice);

                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public static List<decimal> GetLME3MSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end)
        {
            var prices = new List<decimal>();
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    List<LME_OfficialPrice> officials = ctx.LME_OfficialPrice.Where(p => p.LME_CommodityID == comm.Id &&
                                                                                         p.TradeDate >= start.Date &&
                                                                                         p.TradeDate <= end.Date).
                                                                                OrderBy(p => p.TradeDate).ToList();
                    prices.AddRange(officials.Select(official => Convert.ToDecimal(official.Month3Sell)));
                    return prices;
                }
                catch (Exception)
                {
                    prices.Clear();
                    return prices;
                }
            }
        }

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public static List<decimal> GetLMECashSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end)
        {
            var prices = new List<decimal>();
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    List<LME_OfficialPrice> officials = ctx.LME_OfficialPrice.Where(p => p.LME_CommodityID == comm.Id &&
                                                                                         p.TradeDate >= start.Date &&
                                                                                         p.TradeDate <= end.Date).
                                                                                OrderBy(p => p.TradeDate).ToList();
                    prices.AddRange(officials.Select(official => Convert.ToDecimal(official.CashSell)));
                    return prices;
                }
                catch (Exception)
                {
                    prices.Clear();
                    return prices;
                }
            }
        }

        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public static List<LME_OfficialPrice> GetLME3MSettlementPriceOfficialPrice(Commodity comm, DateTime start, DateTime end)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                var officials = new List<LME_OfficialPrice>();
                try
                {
                    officials = ctx.LME_OfficialPrice.Include("LME_Commodity").Where(p => p.LME_CommodityID == comm.Id &&
                                                                                         p.TradeDate >= start.Date &&
                                                                                         p.TradeDate <= end.Date).
                                                                                OrderBy(p => p.TradeDate).ToList();
                    return officials;
                }
                catch (Exception)
                {
                    officials.Clear();
                    return officials;
                }
            }
        }

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public static List<LME_OfficialPrice> GetLMECashSettlementPriceOfficialPrice(Commodity comm, DateTime start, DateTime end)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                var officials = new List<LME_OfficialPrice>();
                try
                {
                    officials = ctx.LME_OfficialPrice.Include("LME_Commodity").Where(p => p.LME_CommodityID == comm.Id &&
                                                                                         p.TradeDate >= start.Date &&
                                                                                         p.TradeDate <= end.Date).
                                                                                OrderBy(p => p.TradeDate).ToList();
                    return officials;
                }
                catch (Exception)
                {
                    officials.Clear();
                    return officials;
                }
            }
        }
        #endregion

        #region SHFE价格

        /// <summary>
        /// 获得指定合约品种的最新价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        public static decimal GetSHFELatestPrice(Commodity comm, int promptMonth)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    int commId = GetSHFECommodityIDByCommdityAndPromptMonth(comm, promptMonth);
                    if (commId == -1)
                        return -1;
                    var shfeLastedPrice = ctx.SHFE_LastedPrice.Where(p => p.SHFE_Commodity.SHFE_CommodityID == commId).
                                                                    OrderByDescending(p => p.UpdateTime).FirstOrDefault();
                    if (shfeLastedPrice != null)
                        return Convert.ToDecimal(shfeLastedPrice.LastedPrice);

                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获得指定合约品种在指定日期的官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="tradeDate"></param>
        /// <param name="promptYear"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        public static decimal GetSHFESettlementPrice(Commodity comm, DateTime tradeDate, int promptYear, int promptMonth)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    int commId = GetSHFECommodityIDByCommdityAndPromptMonth(comm, promptMonth);
                    if (commId == -1)
                        return -1;
                    SHFE_MonthlySettlePrice shfeMonthlySettlePrice = null;
                    DateTime  date = tradeDate;
                    while(shfeMonthlySettlePrice == null)
                    {
                        shfeMonthlySettlePrice  = ctx.SHFE_MonthlySettlePrice.FirstOrDefault(p => p.SHFE_Commodity.SHFE_CommodityID == commId && p.TradeDate == tradeDate.Date &&
                                                                                            p.PromptMonth == promptMonth && p.PromptYear == promptYear);
                        date = date.AddDays(-1);
                    }
                    return Convert.ToDecimal(shfeMonthlySettlePrice.SettlePrice);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获得SHFE指定交易日期内的指定合约的结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"> </param>
        /// <param name="promptYear"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        public static List<SHFE_MonthlySettlePrice> GetSHFEMonthlySettlementPrice(Commodity comm, DateTime start, DateTime end,
                                                                                    int promptYear, int promptMonth)
        {
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    int commId = GetSHFECommodityIDByCommdityAndPromptMonth(comm, promptMonth);
                    if (commId == -1)
                        return null;
                    List<SHFE_MonthlySettlePrice> shfeMonthlySettlePrice = ctx.SHFE_MonthlySettlePrice.Include("SHFE_Commodity").Where(p => p.SHFE_Commodity.SHFE_CommodityID == commId &&
                                                                                                                                            p.TradeDate >= start.Date && p.TradeDate <= end.Date &&
                                                                                                                                            p.PromptMonth == promptMonth && p.PromptYear == promptYear).OrderBy(p => p.TradeDate).ToList();

                    return shfeMonthlySettlePrice;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        #endregion

        #region 现货价
        /// <summary>
        /// 获取指定日的上海有色网现货价格
        /// </summary>
        /// <returns></returns>
        public static decimal GetSMMPrice(Commodity comm, DateTime tradeDate)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.SHY);
            if (code == string.Empty)
                return -1;
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    var smmPrice = ctx.SMM_SMMWebPrice.FirstOrDefault(p => p.UpdateTime == tradeDate.Date && p.Name == code);
                    if (smmPrice != null && smmPrice.AveragePrice != null)
                        return Convert.ToDecimal(smmPrice.AveragePrice);
                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// 获得指定日的上海金属网现货价格
        /// </summary>
        /// <returns></returns>
        public static decimal GetSHMETPrice(Commodity comm, DateTime tradeDate)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.SHX);
            if (code == string.Empty)
                return -1;
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    var smmPrice = ctx.SMM_SMMWebPrice.FirstOrDefault(p => p.UpdateTime == tradeDate.Date && p.Name == code);
                    if (smmPrice != null && smmPrice.AveragePrice != null)
                        return Convert.ToDecimal(smmPrice.AveragePrice);
                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获取指定日的上海有色网现货价格对象集合
        /// </summary>
        /// <returns></returns>
        public static List<SMM_SMMWebPrice> GetSMMWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.SHY);
            if (code == string.Empty)
                return null;
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    List<SMM_SMMWebPrice> smmPrice = ctx.SMM_SMMWebPrice.Include("SMM_Commodity").Where(p => p.UpdateTime >= start && p.UpdateTime <= end && p.Name == code).OrderBy(p => p.UpdateTime).ToList();
                    return smmPrice;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获得指定日的上海金属网现货价格对象集合
        /// </summary>
        /// <returns></returns>
        public static List<SMM_SMMWebPrice> GetSHMETWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.SHX);
            if (code == string.Empty)
                return null;
            using (var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    List<SMM_SMMWebPrice> smmPrice = ctx.SMM_SMMWebPrice.Include("SMM_Commodity").Where(p => p.UpdateTime >= start && p.UpdateTime <= end && p.Name == code).OrderBy(p => p.UpdateTime).ToList();
                    return smmPrice;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取长江现货价格对象集合
        /// </summary>
        /// <returns></returns>
        public static List<SMM_SMMWebPrice> GetPCJWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.PCJ);
            if(code == string.Empty)
            {
                return null;
            }
            using(var ctx = new SenLanMarketPriceEntities())
            {
                try {
                    List<SMM_SMMWebPrice> smmPrice = ctx.SMM_SMMWebPrice.Include("SMM_Commodity").Where(p => p.UpdateTime >= start && p.UpdateTime <= end && p.Name == code).OrderBy(p => p.UpdateTime).ToList();
                    return smmPrice;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 南储现货价格对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<SMM_SMMWebPrice> GetNCWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            string code = MappingSenLanCommodity2PysicalCommodity(comm, PricingBasis.NC);
            if(code == string.Empty)
            {
                return null;
            }
            using(var ctx = new SenLanMarketPriceEntities())
            {
                try
                {
                    List<SMM_SMMWebPrice> smmPrice = ctx.SMM_SMMWebPrice.Include("SMM_Commodity").Where(p => p.UpdateTime >= start && p.UpdateTime <= end && p.Name == code).OrderBy(p => p.UpdateTime).ToList();
                    return smmPrice;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获取最新的金属网现货价格
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static decimal GetLatestSHMETPrice(Commodity comm)
        {
            DateTime date = DateTime.Today.Date;
            decimal price = -1;
            while (price == -1)
            {
                if (date.CompareTo(DateTime.MinValue) > 0)
                {
                    price = GetSHMETPrice(comm, date);
                    date = date.AddDays(-1);
                }
                else
                {
                    price = 0;
                }
                //if (date.ToString() != "0001-1-1 0:00:00")//用来判断金属没有价格时，日期为0001-1-1时在减掉一天报错的问题
                //{
                //    price = GetSHMETPrice(comm, date);
                //    date = date.AddDays(-1);
                //}
                //else
                //{
                //    price = 0;
                //}
            }
            return price;
        }
        
        /// <summary>
        /// 获取最新的有色网现货价格
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static decimal GetLatestSMMPrice(Commodity comm)
        {
            DateTime date = DateTime.Today.Date;
            decimal price = -1;
            while (price == -1)
            {
                //if (date.ToString() != "0001-1-1 0:00:00")//用来判断金属没有价格时，日期为0001-1-1时在减掉一天报错的问题
                if (date.CompareTo(DateTime.MinValue) > 0)
                {
                    price = GetSMMPrice(comm, date);
                    date = date.AddDays(-1);
                }
                else
                {
                    price = 0;
                }
            }
            return price;
        }

        /// <summary>
        /// 映射金属类型（铜铝铅锌）到现货金属类型
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public static string MappingSenLanCommodity2PysicalCommodity(Commodity comm, PricingBasis market)
        {
            //金属网
            if (market == PricingBasis.SHX)
            {
                switch (comm.Code)
                {
                    case "CU":
                        return "SHXCU0";
                    case "AL":
                        return "SHXAL0";
                    case "PB":
                        return "SHXPL0";
                    case "ZN":
                        return "SHXZN0";
                    case "TI":
                        return "SHXPN0";
                    case "NI":
                        return "SHXNI0";
                }
            }
            else if (market == PricingBasis.SHY) //有色网
            {
                switch (comm.Code)
                {
                    case "CU":
                        return "SHYCU0";
                    case "AL":
                        return "SHYAL0";
                    case "PB":
                        return "SHYPL0";
                    case "ZN":
                        return "SHYZN0";
                    case "TI":
                        return "SHYPI0";
                    case "NI":
                        return "SHXNI0";
                }
            }
            else if(market == PricingBasis.PCJ)//长江现货
            {
               switch(comm.Code)
               {
                   case "CU":
                       return "PCJCU0";
                   case "AL":
                       return "PCJAL0";
                   case "PB":
                       return "PCJPLM";
                   case "ZN":
                       return "PCJZN0";
                   case "TI":
                       return "PCJPIN";
                   case "NI":
                       return "PCJNI1";
               }
            }
            else if(market == PricingBasis.NC)//南储
            {
                switch(comm.Code)
                {
                    case "CU":
                        return "NCCU11";
                    case "AL":
                        return "NCAL00";
                    case "CO":
                        return "NCCO11";
                    case "PB":
                        return "NCPLM1";
                    case "ZN":
                        return "NCXZN0";
                    case "TI":
                        return "NCPIN1";
                    case "NI":
                        return "NCNI11";
                }
            }

            return string.Empty;
        }
        #endregion

        /// <summary>
        /// 根据点价基准获取最新价格，-1代表没有获得价格,目前仅用作合同批次审批的估价
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="comm"> </param>
        /// <returns></returns>
        public static CurrentPrice GetCurrentPrice(int pb, Commodity comm)
        {
            var cp = new CurrentPrice();
            switch (pb)
            {
                case (int)PricingBasis.LME3M:
                    cp.Currency = "USD";
                    cp.Price = GetLME3MSettlementPrice(comm, DateTime.Today);
                    break;
                case (int)PricingBasis.LMECash:
                    cp.Currency = "USD";
                    cp.Price = GetLMECashSettlementPrice(comm, DateTime.Today);
                    break;
                case (int)PricingBasis.SHFE01:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 1);
                    break;
                case (int)PricingBasis.SHFE02:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 2);
                    break;
                case (int)PricingBasis.SHFE03:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 3);
                    break;
                case (int)PricingBasis.SHFE04:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 4);
                    break;
                case (int)PricingBasis.SHFE05:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 5);
                    break;
                case (int)PricingBasis.SHFE06:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 6);
                    break;
                case (int)PricingBasis.SHFE07:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 7);
                    break;
                case (int)PricingBasis.SHFE08:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 8);
                    break;
                case (int)PricingBasis.SHFE09:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 9);
                    break;
                case (int)PricingBasis.SHFE10:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 10);
                    break;
                case (int)PricingBasis.SHFE11:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 11);
                    break;
                case (int)PricingBasis.SHFE12:
                    cp.Currency = "CNY";
                    cp.Price = GetSHFELatestPrice(comm, 12);
                    break;
                case (int)PricingBasis.SHX:
                    cp.Currency = "CNY";
                    cp.Price = GetLatestSHMETPrice(comm);
                    break;
                case (int)PricingBasis.SHY:
                    cp.Currency = "CNY";
                    cp.Price = GetLatestSMMPrice(comm);
                    break;
            }
            return cp;
        }

        public static int GetSHFECommodityIDByCommdityAndPromptMonth(Commodity comm, int promptMonth)
        {
             using (var ctx = new SenLanMarketPriceEntities())
             {
                try
                {
                    string pzCode = GetSHFEPZCodeByCommodityAndPromptMonth(comm, promptMonth);
                    return ctx.SHFE_Commodity.FirstOrDefault(c => c.Code == pzCode).SHFE_CommodityID;
                }
                catch (Exception)
                {
                    return -1;
                }
             }
        }

        private static string MappingDateToCode(int promptMonth)
        {
            switch (promptMonth)
            {
                case 1:
                    return "F";
                case 2:
                    return "G";
                case 3:
                    return "H";
                case 4:
                    return "J";
                case 5:
                    return "K";
                case 6:
                    return "M";
                case 7:
                    return "N";
                case 8:
                    return "Q";
                case 9:
                    return "U";
                case 10:
                    return "V";
                case 11:
                    return "X";
                case 12:
                    return "Z";
                default:
                    return String.Empty;
            }
        }

        private static string GetSHFEPZCodeByCommodityAndPromptMonth(Commodity comm, int promptMonth)
        {
            string pzCode = "SF";
            pzCode += comm.Code;
            pzCode += MappingDateToCode(promptMonth);
            pzCode += "5";
            return pzCode;
        }
    }
}