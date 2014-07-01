using System;
using System.Collections.Generic;
using DBEntity;
using PriceDBEntity;
using Services.Helper.MarketPrice;

namespace Services.MarketPrice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MarketPriceService”。
    public class MarketPriceService : IMarketPriceService
    {
        #region 拆借利率种类

        public Dictionary<int, string> GetSelectLmeCommodity()
        {
            return MarketPriceManager.GetSelectLmeCommodity();
        }

        public decimal GetSelectLMELastedPrice(int id)
        {
            return MarketPriceManager.GetSelectLMELastedPrice(id);
        }

        #endregion

        //public Helper.MarketPrice.MarketPriceManager MarketPriceManager = new Services.Helper.MarketPrice.MarketPriceManager();

        #region IMarketPriceService Members

        /// <summary>
        /// 获得LME3月官方结算价
        /// </summary>
        /// <param name="comm">金属类型</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        public decimal GetLME3MSettlementPrice(Commodity comm, DateTime tradeDate)
        {
            return MarketPriceManager.GetLME3MSettlementPrice(comm, tradeDate);
        }

        /// <summary>
        /// 获得LME现货官方结算价
        /// </summary>
        /// <param name="comm">金属品种</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        public decimal GetLMECashSettlementPrice(Commodity comm, DateTime tradeDate)
        {
            return MarketPriceManager.GetLMECashSettlementPrice(comm, tradeDate);
        }

        /// <summary>
        /// 获得LME三个月内每天到期的价格
        /// </summary>
        public decimal GetLMEDailySettlementPrice(Commodity comm, DateTime tradeDate, DateTime prompDate)
        {
            return MarketPriceManager.GetLMEDailySettlementPrice(comm, tradeDate, prompDate);
        }

        /// <summary>
        /// 获得LME最新价格
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public decimal GetLMELatestPrice(Commodity comm)
        {
            return MarketPriceManager.GetLMELatestPrice(comm);
        }

        /// <summary>
        /// 获得指定合约品种的最新价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        public decimal GetSHFELatestPrice(Commodity comm, int promptMonth)
        {
            return MarketPriceManager.GetSHFELatestPrice(comm, promptMonth);
        }

        /// <summary>
        /// 获得指定合约品种在指定日期的官方结算价
        /// </summary>
        /// <param name="comm"> </param>
        /// <param name="tradeDate"></param>
        /// <param name="promptYear"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        public decimal GetSHFESettlementPrice(Commodity comm, DateTime tradeDate, int promptYear, int promptMonth)
        {
            return MarketPriceManager.GetSHFESettlementPrice(comm, tradeDate, promptYear, promptMonth);
        }

        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public List<decimal> GetLME3MSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end)
        {
            return MarketPriceManager.GetLME3MSettlementPriceDate2Date(comm, start, end);
        }

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public List<decimal> GetLMECashSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end)
        {
            return MarketPriceManager.GetLMECashSettlementPriceDate2Date(comm, start, end);
        }

        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public List<LME_OfficialPrice> GetLME3MSettlementPriceOfficialPrice(Commodity comm, DateTime start, DateTime end)
        {
            var lme3MList = new List<LME_OfficialPrice>();
            List<LME_OfficialPrice> officials = MarketPriceManager.GetLME3MSettlementPriceOfficialPrice(comm, start, end);
            foreach (LME_OfficialPrice lme3M in officials)
            {
                lme3M.LME_Commodity = null;
                lme3M.LME_CommodityReference = null;
                lme3MList.Add(lme3M);
            }
            return lme3MList;
        }

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>发生异常返回集合是数量为0的空集合</returns>
        public List<LME_OfficialPrice> GetLMECashSettlementPriceOfficialPrice(Commodity comm, DateTime start,
                                                                              DateTime end)
        {
            var lmeCashList = new List<LME_OfficialPrice>();
            List<LME_OfficialPrice> officials = MarketPriceManager.GetLMECashSettlementPriceOfficialPrice(comm, start,
                                                                                                          end);
            foreach (LME_OfficialPrice lmeCash in officials)
            {
                lmeCash.LME_Commodity = null;
                lmeCash.LME_CommodityReference = null;
                lmeCashList.Add(lmeCash);
            }
            return lmeCashList;
        }

        /// <summary>
        /// 获得SHFE当月结算价对象集合
        /// </summary>
        /// <returns></returns>
        public List<SHFE_MonthlySettlePrice> GetSHFEMonthlySettlementPrice(Commodity comm, DateTime start, DateTime end, int promptYear, int promptMonth)
        {
            var shfeMonthlyList = new List<SHFE_MonthlySettlePrice>();
            List<SHFE_MonthlySettlePrice> shfeMonthlys = MarketPriceManager.GetSHFEMonthlySettlementPrice(comm, start, end, promptYear, promptMonth);
            foreach (SHFE_MonthlySettlePrice shfe in shfeMonthlys)
            {
                shfe.SHFE_Commodity = null;
                shfe.SHFE_CommodityReference = null;
                shfeMonthlyList.Add(shfe);
            }
            return shfeMonthlyList;
        }

        #endregion

        #region 现货价

        /// <summary>
        /// 获取指定日的上海有色网现货价格
        /// </summary>
        /// <returns></returns>
        public decimal GetSMMPrice(Commodity comm, DateTime tradeDate)
        {
            return MarketPriceManager.GetSMMPrice(comm, tradeDate);
        }

        /// <summary>
        /// 获得指定日的上海金属网现货价格
        /// </summary>
        /// <returns></returns>
        public decimal GetSHMETPrice(Commodity comm, DateTime tradeDate)
        {
            return MarketPriceManager.GetSHMETPrice(comm, tradeDate);
        }

        /// <summary>
        /// 获取指定日的上海有色网现货价格
        /// </summary>
        /// <returns></returns>
        public List<SMM_SMMWebPrice> GetSMMWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            var smmWebPriceList = new List<SMM_SMMWebPrice>();
            List<SMM_SMMWebPrice> smmWebPrice = MarketPriceManager.GetSMMWebPrice(comm, start, end);
            foreach (SMM_SMMWebPrice smmWeb in smmWebPrice)
            {
                smmWeb.SMM_Commodity = null;
                smmWeb.SMM_CommodityReference = null;
                smmWebPriceList.Add(smmWeb);
            }
            return smmWebPriceList;
        }

        /// <summary>
        /// 获得指定日的上海金属网现货价格
        /// </summary>
        /// <returns></returns>
        public List<SMM_SMMWebPrice> GetSHMETWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            var shmetWebPriceList = new List<SMM_SMMWebPrice>();
            List<SMM_SMMWebPrice> shmetWebPrice = MarketPriceManager.GetSHMETWebPrice(comm, start, end);
            foreach (SMM_SMMWebPrice shmetWeb in shmetWebPrice)
            {
                shmetWeb.SMM_Commodity = null;
                shmetWeb.SMM_CommodityReference = null;
                shmetWebPriceList.Add(shmetWeb);
            }
            return shmetWebPriceList;
        }

        /// <summary>
        /// 获得指定日的长江现货价格
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<SMM_SMMWebPrice> GetPCJWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            var pcjWebPriceList = new List<SMM_SMMWebPrice>();
            List<SMM_SMMWebPrice> pcjWebPrice = MarketPriceManager.GetPCJWebPrice(comm, start, end);
            if (pcjWebPrice != null && pcjWebPrice.Count > 0)
            {
                foreach (SMM_SMMWebPrice pcjWeb in pcjWebPrice)
                {
                    pcjWeb.SMM_Commodity = null;
                    pcjWeb.SMM_CommodityReference = null;
                    pcjWebPriceList.Add(pcjWeb);
                }
            }
            return pcjWebPriceList;
        }

        public List<SMM_SMMWebPrice> GetNCWebPrice(Commodity comm, DateTime start, DateTime end)
        {
            var ncWebPriceList = new List<SMM_SMMWebPrice>();
            List<SMM_SMMWebPrice> ncWebPrice = MarketPriceManager.GetNCWebPrice(comm, start, end);
            if (ncWebPrice != null && ncWebPrice.Count > 0)
            {
                foreach (SMM_SMMWebPrice ncWeb in ncWebPrice)
                {
                    ncWeb.SMM_Commodity = null;
                    ncWeb.SMM_CommodityReference = null;
                    ncWebPriceList.Add(ncWeb);
                }
            }
            return ncWebPriceList;
        }
        #endregion

        #region General

        public CurrentPrice GetCurrenctPrice(int pricingBasis, Commodity comm)
        {
            return MarketPriceManager.GetCurrentPrice(pricingBasis, comm);
        }

        #endregion
    }
}