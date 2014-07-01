using System.Collections.ObjectModel;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommodityService" in code, svc and config file together.
    public class CommodityService : BaseService<Commodity>, ICommodityService
    {
        public List<Commodity> GetCommoditiesByUser(int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var x = QueryForObjs(GetObjQuery<UserCommodityLink>(ctx, new Collection<string> { "Commodity" }), o => o.UserId == userId).ToList();
                    return x.Select(o => o.Commodity).OrderBy(o => o.Name).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Commodity GetCommoditiyByCode(string code)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var commodity = QueryForObj(GetObjQuery<Commodity>(ctx), o => o.Code == code);
                    return commodity;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}