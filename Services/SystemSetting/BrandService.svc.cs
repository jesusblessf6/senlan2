using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BrandService" in code, svc and config file together.
    public class BrandService : BaseService<Brand>, IBrandService
    {
        /// <summary>
        /// Add Brand
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Brand AddNewBrand(Brand brand, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var brands = QueryForObjs(GetObjQuery<Brand>(ctx), o => o.Name == brand.Name && o.CommodityId == brand.CommodityId && o.CommodityTypeId==brand.CommodityTypeId);
                    if(brands.Count > 0)
                    {
                        throw new FaultException(ErrCode.BrandExisted.ToString());
                    }

                    Create(GetObjSet<Brand>(ctx), brand);
                    ctx.SaveChanges();
                    return brand;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Brand UpdateExistedBrand(Brand brand, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var brands = QueryForObjs(GetObjQuery<Brand>(ctx), o => o.Name == brand.Name && o.Id != brand.Id && o.CommodityId == brand.CommodityId && o.CommodityTypeId == brand.CommodityTypeId);
                    if (brands.Count > 0)
                    {
                        throw new FaultException(ErrCode.BrandExisted.ToString());
                    }

                    Update(GetObjSet<Brand>(ctx), brand);
                    ctx.SaveChanges();
                    return brand;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<Brand> GetBrandsWith(int commodityTypeId, int commodityId)
        {
            try
            {
                using (var ctx  = new SenLan2Entities())
                {
                    return
                        QueryForObjs(GetObjQuery<Brand>(ctx),
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