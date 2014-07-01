using Services.Base;
using DBEntity;
using DBEntity.EnableProperty;
using Utility.ErrorManagement;
using System.Data;
using System.ServiceModel;
using System.Collections.Generic;
using DBEntity.EnumEntity;
using System.Linq;

namespace Services.Physical.Deliveries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeliveryLineService" in code, svc and config file together.
    public class DeliveryLineService : BaseService<DeliveryLine>, IDeliveryLineService
    {
        public DeliveryLineEnableProperty SetElementsEnableProperty(int id)
        {
            var dlep = new DeliveryLineEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //如果有入库，则不能修改净重，确认数量
                    if (QueryForObjs(GetObjQuery<WarehouseInLine>(ctx), wil => wil.DeliveryLineId == id).Count > 0)
                    {
                        dlep.IsNetWeightEnable = true;
                        //允许修改实际数量
                        //dlep.IsVerifiedQuantityEnable = false;
                        dlep.IsBrandEnable = false;
                        dlep.IsCommodityTypeEnable = false;
                        dlep.IsSpecificationEnable = false;
                        return dlep;
                    }

                    //对应批次参加保值，且保值已经结算不可以修改
                    DeliveryLine dll = QueryForObj(GetObjQuery<DeliveryLine>(ctx, new List<string> { "Delivery" }), d => d.Id == id);
                    HedgeLineQuota hlq = QueryForObjs(GetObjQuery<HedgeLineQuota>(ctx, new List<string> { "HedgeGroup" }), q => q.QuotaId == dll.Delivery.QuotaId).FirstOrDefault();
                    if (hlq != null && hlq.HedgeGroup.Status == (int)HedgeGroupStatus.Settled)
                    {
                        dlep.IsNetWeightEnable = false;
                        dlep.IsVerifiedQuantityEnable = false;
                        dlep.IsBrandEnable = false;
                        dlep.IsCommodityTypeEnable = false;
                        dlep.IsSpecificationEnable = false;
                        return dlep;
                    }
                }
                return dlep;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
