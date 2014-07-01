using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.Futures.SHFE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SHFEService" in code, svc and config file together.
    public class SHFEService : BaseService<DBEntity.SHFE>, ISHFEService
    {
        #region ISHFEService Members

        public DBEntity.SHFE GetShfeByAlias(string alias)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    DBEntity.SHFE shfe = QueryForObj(GetObjQuery<DBEntity.SHFE>(ctx), o => o.Alias == alias);
                    return shfe;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<DBEntity.SHFE> GetShfeByCommodityId(int commodityId, DateTime tradeDate)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    Commodity commodity = QueryForObj(GetObjQuery<Commodity>(ctx), o => o.Id == commodityId);
                    string commodityCode = commodity.Code;
                    var shfes = new List<DBEntity.SHFE>();
                    ICollection<DBEntity.SHFE> queryShfe = QueryForObjs(GetObjQuery<DBEntity.SHFE>(ctx),
                                                                        o => o.Alias.StartsWith(commodityCode));
                    foreach (DBEntity.SHFE shfe in queryShfe)
                    {
                        string alias = shfe.Alias;
                        int month = Convert.ToInt32(alias.Substring(2));
                        int tradeMonth = tradeDate.Month;
                        int year = tradeDate.Year;
                        int nextYear = year + 1;
                        int day = tradeDate.Day;
                        string newAlias;
                        if (month < tradeMonth)
                        {
                            newAlias = commodityCode + nextYear.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0').Substring(2) +
                                       month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                        }
                        else if (month == tradeMonth)
                        {
                            if (day <= 15)
                            {
                                newAlias = commodityCode + year.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0').Substring(2) +
                                           month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            else
                            {
                                newAlias = commodityCode + nextYear.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0').Substring(2) +
                                           month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                        }
                        else
                        {
                            newAlias = commodityCode + year.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0').Substring(2) +
                                       month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                        }
                        shfe.Alias = newAlias;
                        shfes.Add(shfe);
                    }
                    return shfes;
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