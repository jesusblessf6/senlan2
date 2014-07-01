using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.Physical.Pricings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UnpricingService" in code, svc and config file together.
    public class UnpricingService : BaseService<Unpricing>, IUnpricingService
    {
        /// <summary>
        /// Get unpricing by quota id
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public List<Unpricing> GetUnpricingsByQuotaId(int quotaId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<Unpricing>(ctx), o => o.QuotaId == quotaId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 删除延期点价的记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Unpricing up = QueryForObj(GetObjQuery<Unpricing>(ctx, new List<string>{"ParentUnpricing"}), u => u.Id == id);

                    //1. 如果已经从自身进行过点价，则不能删除
                    ICollection<Pricing> ps = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.UnpricingId == up.Id);
                    if(ps.Count > 0)
                    {
                        throw new FaultException(ErrCode.PricingUnpricingConnected.ToString());
                    }

                    //2. 如果已经被再次延期也不能删除
                    ICollection<Unpricing> ups = QueryForObjs(GetObjQuery<Unpricing>(ctx), o => o.UnpricingId == up.Id);
                    if (ups.Count > 0)
                    {
                        throw new FaultException(ErrCode.UnpricingUnpricingConnected.ToString());
                    }

                    //3. 删除当前延期点价
                    up.IsDeleted = true;

                    //4. 将该延期的数量换到原来的延期上
                    up.ParentUnpricing.UnpricingQuantity += up.UnpricingQuantity;

                    //5. 保存
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 编辑延期点价
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="userId"></param>
        public override void UpdateExisted(Unpricing obj, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Unpricing up = QueryForObj(GetObjQuery<Unpricing>(ctx, new List<string> { "ParentUnpricing" }), u => u.Id == obj.Id);

                    //1. 如果已经从自身进行过点价，则不能编辑
                    ICollection<Pricing> ps = QueryForObjs(GetObjQuery<Pricing>(ctx), o => o.UnpricingId == up.Id);
                    if (ps.Count > 0)
                    {
                        throw new FaultException(ErrCode.PricingUnpricingConnected.ToString());
                    }

                    //2. 如果已经被再次延期也不能编辑
                    ICollection<Unpricing> ups = QueryForObjs(GetObjQuery<Unpricing>(ctx), o => o.UnpricingId == up.Id);
                    if (ups.Count > 0)
                    {
                        throw new FaultException(ErrCode.UnpricingUnpricingConnected.ToString());
                    }

                    //3. 将编辑的数量还给上个延期的记录
                    var diff = ((obj.UnpricingQuantity ?? 0) - (up.UnpricingQuantity ?? 0));
                    up.ParentUnpricing.UnpricingQuantity -= diff;

                    //4. 保存当天的延期
                    up.DeferDate = obj.DeferDate;
                    up.DeferFee = obj.DeferFee;
                    up.Description = obj.Description;
                    up.EndPricingDate = obj.EndPricingDate;
                    up.QuotaId = obj.QuotaId;
                    up.StartPricingDate = obj.StartPricingDate;
                    up.UnpricingId = obj.UnpricingId;
                    up.UnpricingQuantity = obj.UnpricingQuantity;
                    up.Updated = System.DateTime.Now;
                    up.UpdatedBy = userId;
                    up.Created = obj.Created;
                    up.CreatedBy = obj.CreatedBy;

                    //5. 保存
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }


        /// <summary>
        /// Defer Pricing
        /// </summary>
        /// <param name="unpricing"></param>
        /// <param name="userId"></param>
        public Unpricing DeferPricing(Unpricing unpricing, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var up = GetById(GetObjQuery<Unpricing>(ctx), unpricing.UnpricingId ?? 0);

                    if (up == null)
                    {
                        throw new FaultException(ErrCode.QuotaNotExisted.ToString());
                    }

                    if (unpricing.UnpricingQuantity > up.UnpricingQuantity)
                    {
                        throw new FaultException(ErrCode.UnpricingQuantityNotEnough.ToString());
                    }

                    var newUp = new Unpricing
                    {
                        QuotaId = unpricing.QuotaId,
                        UnpricingQuantity = unpricing.UnpricingQuantity,
                        StartPricingDate = up.StartPricingDate,
                        EndPricingDate = unpricing.EndPricingDate,
                        DeferFee = unpricing.DeferFee,
                        DeferDate = unpricing.DeferDate,
                        UnpricingId = unpricing.UnpricingId,
                        RelUnpricingId =  unpricing.RelUnpricingId,
                        IsAutoGenerated = unpricing.IsAutoGenerated
                    };
                    Create(GetObjSet<Unpricing>(ctx), newUp);

                    up.UnpricingQuantity -= unpricing.UnpricingQuantity;

                    var quota = GetById(GetObjQuery<Quota>(ctx), unpricing.QuotaId);
                    quota.PricingEndDate = unpricing.EndPricingDate;

                    ctx.SaveChanges();
                    return newUp;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
