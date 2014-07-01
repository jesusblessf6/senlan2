using System.ServiceModel;
using Services.Base;
using DBEntity;
using DBEntity.EnableProperty;
using System.Data;
using Utility.ErrorManagement;
using System.Collections.Generic;
using DBEntity.EnumEntity;
using System.Linq;

namespace Services.Physical.WarehouseIns
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarehouseInLineService" in code, svc and config file together.
    public class WarehouseInLineService : BaseService<WarehouseInLine>, IWarehouseInLineService
    {
        public WarehouseInLineEnableProperty SetElementsEnableProperty(int id)
        {
            var wilep = new WarehouseInLineEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //任何情况下提单都不可以编辑
                    wilep.IsDeliveryLineEnable = false;
                    WarehouseInLine wil = QueryForObj(GetObjQuery<WarehouseInLine>(ctx, new List<string> { "DeliveryLine", "DeliveryLine.Delivery" }), d => d.Id == id);
                    //如果存在出库不允许修改
                    if (QueryForObjs(GetObjQuery<WarehouseOutLine>(ctx), wol => wol.WarehouseInLineId == id).Count > 0)
                    {
                        wilep.IsBrandEnable = false;
                        wilep.IsCommodityTypeEnable = false;
                        wilep.IsPBNoEnable = false;
                        wilep.IsQuantityEnable = false;
                        //允许修改实际数量
                        //wilep.IsVerifiedQuantityEnable = false;
                        //wilep.IsDeliveryLineEnable = false;
                        //清卡后不可以修改实际数量
                        if(wil.IsPBCleared == true)
                        {
                            wilep.IsVerifiedQuantityEnable = false;
                        }
                        wilep.IsSpecificationEnable = false;
                    }

                    //对应批次参与分组保值，且分组保值已经结算
                    HedgeLineQuota hlq = QueryForObjs(GetObjQuery<HedgeLineQuota>(ctx, new List<string> { "HedgeGroup" }), q => q.QuotaId == wil.DeliveryLine.Delivery.QuotaId).FirstOrDefault();
                    if (hlq != null && hlq.HedgeGroup.Status == (int)HedgeGroupStatus.Settled)
                    {
                        wilep.IsBrandEnable = false;
                        wilep.IsCommodityTypeEnable = false;
                        wilep.IsPBNoEnable = false;
                        wilep.IsQuantityEnable = false;
                        wilep.IsVerifiedQuantityEnable = false;
                        wilep.IsDeliveryLineEnable = false;
                        wilep.IsSpecificationEnable = false;
                    }

                    return wilep;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
