using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryService" in code, svc and config file together.
    public class CountryService : BaseService<Country>, ICountryService
    {
        #region ICountryService Members

        public Country AddNewCountry(Country country, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Country tmp = QueryForObj(GetObjQuery<Country>(ctx),
                                              o => o.ChineseName == country.ChineseName);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.CountryExisted.ToString());
                    }

                    Create(GetObjSet<Country>(ctx), country);
                    ctx.SaveChanges();
                    return country;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Country UpdateCountry(Country country, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Country> countryLinks =
                        QueryForObjs(GetObjQuery<Country>(ctx),
                                     o =>
                                     o.ChineseName == country.ChineseName &&
                                     o.Id != country.Id).ToList();

                    if (countryLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.CountryExisted.ToString());
                    }

                    Country oldcountry = GetById(GetObjQuery<Country>(ctx), country.Id);
                    oldcountry.ChineseName = country.ChineseName;
                    oldcountry.Description = country.Description;
                    oldcountry.Name = country.Name;

                    ctx.SaveChanges();
                    return oldcountry;
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