using System;
using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using PriceDBEntity;

namespace Services.MarketPrice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMarketPriceService”。
    [ServiceContract]
    public interface IMarketPriceService
    {
        #region 拆借利率种类

        [OperationContract]
        Dictionary<int, string> GetSelectLmeCommodity();

        [OperationContract]
        decimal GetSelectLMELastedPrice(int id);

        #endregion

        #region LME价格
        /// <summary>
        /// 获得LME3月官方结算价
        /// </summary>
        /// <param name="comm">金属品种</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        [OperationContract]
        decimal GetLME3MSettlementPrice(Commodity comm, DateTime tradeDate);

        /// <summary>
        /// 获得LME现货官方结算价
        /// </summary>
        /// <param name="comm">金属品种</param>
        /// <param name="tradeDate">交易日期</param>
        /// <returns>-1标示没有取到价格</returns>
        [OperationContract]
        decimal GetLMECashSettlementPrice(Commodity comm, DateTime tradeDate);

        /// <summary>
        /// 获得LME三个月内每天到期的价格
        /// </summary>
        [OperationContract]
        decimal GetLMEDailySettlementPrice(Commodity comm, DateTime tradeDate, DateTime prompDate);


        /// <summary>
        /// 获得LME最新价格
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetLMELatestPrice(Commodity comm);

        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [OperationContract]
        List<decimal> GetLME3MSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end);

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [OperationContract]
        List<decimal> GetLMECashSettlementPriceDate2Date(Commodity comm, DateTime start, DateTime end);

        /// <summary>
        /// 获得在起始日期内的LME3月官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [OperationContract]
        List<LME_OfficialPrice> GetLME3MSettlementPriceOfficialPrice(Commodity comm, DateTime start, DateTime end);

        /// <summary>
        /// 获得在起始日期内的LME现货官方结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [OperationContract]
        List<LME_OfficialPrice> GetLMECashSettlementPriceOfficialPrice(Commodity comm, DateTime start, DateTime end);


        #endregion

        #region SHFE价格

        /// <summary>
        /// 获得指定合约品种的最新价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetSHFELatestPrice(Commodity comm, int promptMonth);

        /// <summary>
        /// 获得指定合约品种在指定日期的官方结算价
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="tradeDate"></param>
        /// <param name="promptYear"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetSHFESettlementPrice(Commodity comm, DateTime tradeDate, int promptYear, int promptMonth);

        /// <summary>
        /// 获得SHFE当月结算价对象集合
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"> </param>
        /// <param name="end"> </param>
        /// <param name="promptYear"></param>
        /// <param name="promptMonth"></param>
        /// <returns></returns>
        [OperationContract]
        List<SHFE_MonthlySettlePrice> GetSHFEMonthlySettlementPrice(Commodity comm, DateTime start, DateTime end, int promptYear, int promptMonth);
        #endregion

        #region 现货价
        /// <summary>
        /// 获取指定日的上海有色网现货价格
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        decimal GetSMMPrice(Commodity comm, DateTime tradeDate);
        /// <summary>
        /// 获得指定日的上海金属网现货价格
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        decimal GetSHMETPrice(Commodity comm, DateTime tradeDate);
        /// <summary>
        /// 获取指定日的上海有色网现货价格
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<SMM_SMMWebPrice> GetSMMWebPrice(Commodity comm, DateTime start, DateTime end);
        /// <summary>
        /// 获得指定日的上海金属网现货价格
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<SMM_SMMWebPrice> GetSHMETWebPrice(Commodity comm, DateTime start, DateTime end);
        /// <summary>
        /// 获得指定日的长江金属现货价格
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [OperationContract]
        List<SMM_SMMWebPrice> GetPCJWebPrice(Commodity comm, DateTime start, DateTime end);
       /// <summary>
       /// 获得指定日的南储金属现货价格
       /// </summary>
       /// <param name="comm"></param>
       /// <param name="start"></param>
       /// <param name="end"></param>
       /// <returns></returns>
       [OperationContract]
        List<SMM_SMMWebPrice> GetNCWebPrice(Commodity comm, DateTime start, DateTime end);
        #endregion

        #region General

        [OperationContract]
        CurrentPrice GetCurrenctPrice(int pricingBasis, Commodity comm);

        #endregion
    }
}
