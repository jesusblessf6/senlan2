using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;

namespace Services.Physical.WarehouseOuts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarehouseOutLineService" in code, svc and config file together.
    public class WarehouseOutLineService : BaseService<WarehouseOutLine>, IWarehouseOutLineService
    {
        public WarehouseOutLineEnableProperty SetElementsEnableProperty(int id)
        {
            var wolep = new WarehouseOutLineEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //如果该出库行对应的批次参与分组保值，且分组已经结算，该出库行不可以修改
                    WarehouseOutLine wol = QueryForObj(GetObjQuery<WarehouseOutLine>(ctx, new List<string>{"WarehouseOut"}), l => l.Id == id);
                    HedgeLineQuota hlq = QueryForObjs(GetObjQuery<HedgeLineQuota>(ctx, new List<string> { "HedgeGroup" }), q => q.QuotaId == wol.WarehouseOut.QuotaId).FirstOrDefault();
                    if (hlq != null && hlq.HedgeGroup.Status == (int)HedgeGroupStatus.Settled)
                    {
                        wolep.IsVerifiedQuantityEnable = false;
                        wolep.IsQuantityEnable = false;
                        wolep.IsClearPBNoEnable = false;
                        return wolep;
                    }
                    return wolep;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}