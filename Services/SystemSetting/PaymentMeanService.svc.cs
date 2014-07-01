using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Data;
using System.Linq;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaymentMeanService" in code, svc and config file together.
    public class PaymentMeanService : BaseService<PaymentMean>, IPaymentMeanService
    {
        #region IRateService Members

        public PaymentMean AddNewPaymentMean(PaymentMean paymentmean, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObj(GetObjQuery<PaymentMean>(ctx), r => r.Name == paymentmean.Name);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.PaymentMeanExisted.ToString());
                    }

                    Create(GetObjSet<PaymentMean>(ctx), paymentmean);
                    ctx.SaveChanges();
                    return paymentmean;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public PaymentMean UpdatePaymentMean(PaymentMean paymentmean, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var paymentmeanLinks =
                        QueryForObjs(GetObjQuery<PaymentMean>(ctx),
                                     r => r.Name == paymentmean.Name && r.Id != paymentmean.Id).ToList();

                    if (paymentmeanLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.PaymentMeanExisted.ToString());
                    }

                    PaymentMean oldpaymentmean = GetById(GetObjQuery<PaymentMean>(ctx), paymentmean.Id);
                    oldpaymentmean.Name = paymentmean.Name;
                    oldpaymentmean.Description = paymentmean.Description;
                    oldpaymentmean.IsForFundFlow = paymentmean.IsForFundFlow;

                    ctx.SaveChanges();
                    return oldpaymentmean;
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