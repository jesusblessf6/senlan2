using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PortService" in code, svc and config file together.
    public class PortService : BaseService<Port>, IPortService
    {
        #region IRateService Members

        public Port AddNewPort(Port port, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObjs(GetObjQuery<Port>(ctx),
                                           r => r.Name == port.Name && r.CountryId == port.CountryId);
                    if (tmp.Count > 0)
                    {
                        throw new FaultException(ErrCode.PortExisted.ToString());
                    }

                    Create(GetObjSet<Port>(ctx), port);
                    ctx.SaveChanges();
                    return port;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Port UpdatePort(Port port, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var portLinks =
                        QueryForObjs(GetObjQuery<Port>(ctx),
                                     r => (r.CountryId == port.CountryId && r.Name == port.Name) && r.Id != port.Id).
                            ToList();

                    if (portLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.PortExisted.ToString());
                    }

                    var oldport = GetById(GetObjQuery<Port>(ctx), port.Id);
                    oldport.Name = port.Name;
                    oldport.CountryId = port.CountryId;
                    oldport.Description = port.Description;

                    ctx.SaveChanges();
                    return oldport;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Port> GetPortsByCountry(int countryId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<Port>(ctx), o => o.CountryId == countryId).ToList();
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