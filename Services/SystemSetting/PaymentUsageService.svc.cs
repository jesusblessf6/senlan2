using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Data;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PaymentUsageService”。
    public class PaymentUsageService : BaseService<PaymentUsage>, IPaymentUsageService
    {
        #region IRateService Members

        public PaymentUsage AddNewPaymentUsage(PaymentUsage paymentusage, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObj(GetObjQuery<PaymentUsage>(ctx), r => r.Name == paymentusage.Name);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.PaymentUsageExisted.ToString());
                    }

                    //匹配的账户必须是末级科目
                    var financialaccountLinks =
                        QueryForObjs(GetObjQuery<FinancialAccount>(ctx),
                                     r => r.ParentId == paymentusage.FinancialAccountId).ToList();
                    if (financialaccountLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.PaymentUsagePAExisted.ToString());
                    }

                    Create(GetObjSet<PaymentUsage>(ctx), paymentusage);
                    ctx.SaveChanges();
                    return paymentusage;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public PaymentUsage UpdatePaymentUsage(PaymentUsage paymentusage, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var financialaccountLinks =
                        QueryForObjs(GetObjQuery<FinancialAccount>(ctx),
                                     r => r.ParentId == paymentusage.FinancialAccountId).ToList();
                    if (financialaccountLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.PaymentUsagePAExisted.ToString());
                    }

                    var paymentusageLinks =
                        QueryForObjs(GetObjQuery<PaymentUsage>(ctx),
                                     r => r.Name == paymentusage.Name && r.Id != paymentusage.Id).ToList();

                    if (paymentusageLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.PaymentUsageExisted.ToString());
                    }

                    var oldPaymentUsage = GetById(GetObjQuery<PaymentUsage>(ctx), paymentusage.Id);
                    oldPaymentUsage.Name = paymentusage.Name;
                    oldPaymentUsage.DefaultPaymentMeanId = paymentusage.DefaultPaymentMeanId;
                    oldPaymentUsage.FinancialAccountId = paymentusage.FinancialAccountId;
                    oldPaymentUsage.Description = paymentusage.Description;
                    oldPaymentUsage.IsDefault = paymentusage.IsDefault;

                    ctx.SaveChanges();
                    return oldPaymentUsage;
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
