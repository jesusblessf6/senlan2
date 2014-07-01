using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Data;
using Utility.ErrorManagement;
using System.Linq;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VATRateService" in code, svc and config file together.
    public class VATRateService : BaseService<VATRate>, IVATRateService
    {
        #region IRateService Members

        public VATRate AddNewVATRate(VATRate vatRate, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObj(GetObjQuery<VATRate>(ctx),
                                              r => r.Code == vatRate.Code && r.Type == vatRate.Type);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.VATRateExisted.ToString());
                    }

                    Create(GetObjSet<VATRate>(ctx), vatRate);
                    ctx.SaveChanges();
                    return vatRate;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public VATRate UpdateVATRate(VATRate vatRate, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var vatRateLinks =
                        QueryForObjs(GetObjQuery<VATRate>(ctx),
                                     r => r.Code == vatRate.Code && r.Id != vatRate.Id).ToList();

                    if(vatRateLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.VATRateExisted.ToString());
                    }

                    var oldVATRate = GetById(GetObjQuery<VATRate>(ctx), vatRate.Id);
                    oldVATRate.Code = vatRate.Code;
                    oldVATRate.Type = vatRate.Type;
                    oldVATRate.RateValue = vatRate.RateValue;
                    oldVATRate.Description = vatRate.Description;

                    ctx.SaveChanges();
                    return oldVATRate;
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