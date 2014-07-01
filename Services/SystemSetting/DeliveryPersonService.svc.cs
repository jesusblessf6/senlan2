using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeliveryPersonService" in code, svc and config file together.
    public class DeliveryPersonService : BaseService<DeliveryPerson>, IDeliveryPersonService
    {
        public override DeliveryPerson CreateNew(DeliveryPerson obj, int userId)
        {
            using (var ctx = new SenLan2Entities())
            {
                var t = QueryForObjs(GetObjQuery<DeliveryPerson>(ctx), o => o.IdNo == obj.IdNo);
                if (t.Count > 0)
                {
                    throw new FaultException(ErrCode.DuplicatedDeliveryPersonInfo.ToString());
                }
            }

            return base.CreateNew(obj, userId);
        }

        public override void UpdateExisted(DeliveryPerson obj, int userId)
        {
            using (var ctx = new SenLan2Entities())
            {
                var t = QueryForObjs(GetObjQuery<DeliveryPerson>(ctx), o => o.IdNo == obj.IdNo && o.Id != obj.Id);
                if (t.Count > 0)
                {
                    throw new FaultException(ErrCode.DuplicatedDeliveryPersonInfo.ToString());
                }
            }

            base.UpdateExisted(obj, userId);
        }
    }
}
