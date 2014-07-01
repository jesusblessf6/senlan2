using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RateService" in code, svc and config file together.
    public class RateService : BaseService<Rate>, IRateService
    {
        #region IRateService Members

        /// <summary>
        /// 获取 settleCurr 兑 curr 汇率
        /// </summary>
        /// <param name="settleCurr">兑换币种</param>
        /// <param name="curr">币种</param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public decimal? GetExchangeRate(int settleCurr, int curr, int userId)  //todo remove the userid parameter
        {
            if (settleCurr == curr)
                return 1;

            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (settleCurr <= 0 || curr <= 0)
                    {
                        return 0;
                    }
                    Rate tmpA = QueryForObj(GetObjQuery<Rate>(ctx), r => r.ForeignCurrencyId == settleCurr);
                    Rate tmpB = QueryForObj(GetObjQuery<Rate>(ctx), r => r.ForeignCurrencyId == curr);
                    if (tmpA == null || tmpB == null || tmpA.RateValue == 0)
                    {
                        return 0;
                    }
                    return tmpB.RateValue / tmpA.RateValue;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Rate AddNewRate(Rate rate, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Rate tmp = QueryForObj(GetObjQuery<Rate>(ctx), r => r.ForeignCurrencyId == rate.ForeignCurrencyId);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.RateExisted.ToString());
                    }

                    Create(GetObjSet<Rate>(ctx), rate);
                    ctx.SaveChanges();
                    return rate;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Rate UpdateRate(Rate rate, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var rateLinks =
                        QueryForObjs(GetObjQuery<Rate>(ctx),
                                     r => r.ForeignCurrencyId == rate.ForeignCurrencyId && r.Id != rate.Id).ToList();

                    if (rateLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.RateExisted.ToString());
                    }

                    var oldrate = GetById(GetObjQuery<Rate>(ctx), rate.Id);
                    oldrate.RateValue = rate.RateValue;
                    oldrate.ForeignCurrencyId = rate.ForeignCurrencyId;
                    oldrate.Description = rate.Description;

                    ctx.SaveChanges();
                    return oldrate;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Get the rate of currency to the base currency
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <param name="baseCurrencyCode"></param>
        /// <returns></returns>
        public decimal? GetExchangeRateByCode(string currencyCode, string baseCurrencyCode)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var curr = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Code == currencyCode);
                    if(curr == null)
                    {
                        throw new FaultException(ErrCode.CurrencyNotFound.ToString());
                    }

                    var baseCurr = QueryForObj(GetObjQuery<Currency>(ctx), o => o.Code == baseCurrencyCode);
                    if(baseCurr == null)
                    {
                        throw new FaultException(ErrCode.CurrencyNotFound.ToString());
                    }

                    var rate = QueryForObj(GetObjQuery<Rate>(ctx), o => o.ForeignCurrencyId == curr.Id);
                    var baseRate = QueryForObj(GetObjQuery<Rate>(ctx), o => o.ForeignCurrencyId == baseCurr.Id);
                    if(rate == null || baseRate == null)
                    {
                        return null;
                    }

                    return rate.RateValue/baseRate.RateValue;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion
    }
}