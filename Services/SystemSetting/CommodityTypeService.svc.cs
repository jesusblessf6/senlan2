using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CommodityTypeService”。
    public class CommodityTypeService : BaseService<CommodityType>, ICommodityTypeService
    {
        /// <summary>
        /// Add new Commodity Type
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public CommodityType AddNewCommodityType(CommodityType ct, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var cts = QueryForObjs(GetObjQuery<CommodityType>(ctx), o => o.Name == ct.Name || o.EnglishName==ct.EnglishName);
                    if(cts.Count > 0)
                    {
                        throw new FaultException(ErrCode.CommodityTypeExisted.ToString());
                    }

                    Create(GetObjSet<CommodityType>(ctx), ct);
                    ctx.SaveChanges();
                    return ct;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Update the Commodity Type
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CommodityType UpdateExistedCommodityType(CommodityType ct, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var cts = QueryForObjs(GetObjQuery<CommodityType>(ctx), o => o.Name == ct.Name && o.EnglishName ==ct.EnglishName && o.Id != ct.Id);
                    if(cts.Count > 0)
                    {
                        throw new FaultException(ErrCode.CommodityTypeExisted.ToString());
                    }

                    Update(GetObjSet<CommodityType>(ctx), ct);
                    ctx.SaveChanges();
                    return ct;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Get Commodity types by commodity id
        /// </summary>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public List<CommodityType> GetCommodityTypesByCommodity(int commodityId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<CommodityType>(ctx), o => o.CommodityId == commodityId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}