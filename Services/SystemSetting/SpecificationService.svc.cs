using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SpecificationService" in code, svc and config file together.
    public class SpecificationService : BaseService<Specification>, ISpecificationService
    {
        /// <summary>
        /// Add new Specification
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Specification AddNewSpecification(Specification specification, int userId)
        {
            try
            {
                using(var ctx = new SenLan2Entities(userId))
                {
                    var ss = QueryForObjs(GetObjQuery<Specification>(ctx), o => o.Name == specification.Name && o.CommodityId == specification.CommodityId);
                    if(ss.Count > 0)
                    {
                        throw new FaultException(ErrCode.SpecificationExisted.ToString());
                    }

                    Create(GetObjSet<Specification>(ctx), specification);
                    ctx.SaveChanges();
                    return specification;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Update Specification
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Specification UpdateExistedSpecification(Specification specification, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var ss = QueryForObjs(GetObjQuery<Specification>(ctx),
                                 o => o.Name == specification.Name && o.Id != specification.Id && o.CommodityId == specification.CommodityId);

                    if(ss.Count > 0)
                    {
                        throw new FaultException(ErrCode.SpecificationExisted.ToString());
                    }

                    Update(GetObjSet<Specification>(ctx), specification);
                    ctx.SaveChanges();
                    return specification;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Specification> GetSpecificationsWith(int commodityId, int commodityTypeId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return
                        QueryForObjs(GetObjQuery<Specification>(ctx),
                                     o => o.CommodityTypeId == commodityTypeId && o.CommodityId == commodityId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}