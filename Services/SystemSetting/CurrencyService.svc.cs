using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CurrencyService" in code, svc and config file together.
    public class CurrencyService : BaseService<Currency>, ICurrencyService
    {
        #region ICurrencyService Members

        public Currency AddNewCurrency(Currency currency,int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Currency tmp = QueryForObj(GetObjQuery<Currency>(ctx),
                                               o => o.Name == currency.Name || o.Code == currency.Code);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.CurrencyExisted.ToString());
                    }

                    Create(GetObjSet<Currency>(ctx), currency);
                    ctx.SaveChanges();
                    return currency;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Currency UpdateCurrency(Currency currency, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Currency> currencyLinks =
                        QueryForObjs(GetObjQuery<Currency>(ctx),
                                     o => (o.Name == currency.Name || o.Code == currency.Code) && o.Id != currency.Id).
                            ToList();

                    if (currencyLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.CurrencyExisted.ToString());
                    }

                    var oldcurrency = GetById(GetObjQuery<Currency>(ctx), currency.Id);
                    oldcurrency.Name = currency.Name;
                    oldcurrency.Code = currency.Code;
                    oldcurrency.Description = currency.Description;

                    ctx.SaveChanges();
                    return oldcurrency;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Currency GetCurrencyByCode(string code)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<Currency>(ctx), o => o.Code == code).FirstOrDefault();
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