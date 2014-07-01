using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“FinancialAccountService”。
    public class FinancialAccountService : BaseService<FinancialAccount>, IFinancialAccountService
    {
        #region IFinancialAccountService Members

        public FinancialAccount AddNewFinancialAccount(FinancialAccount financialaccount, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    FinancialAccount tmp = QueryForObj(GetObjQuery<FinancialAccount>(ctx),
                                                       o => o.Name == financialaccount.Name);

                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.FinancialAccountExisted.ToString());
                    }
                    List<PaymentUsage> paymentusageList =
                        QueryForObjs(GetObjQuery<PaymentUsage>(ctx),
                                     o => o.FinancialAccountId == financialaccount.ParentId).ToList();
                    if (paymentusageList.Count > 0)
                    {
                        throw new FaultException(ErrCode.FinancialAccountAddFKErr.ToString());
                    }
                    Create(GetObjSet<FinancialAccount>(ctx), financialaccount);
                    ctx.SaveChanges();
                    return financialaccount;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public FinancialAccount UpdateFinancialAccount(FinancialAccount financialaccount, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<FinancialAccount> financialaccountLinks =
                        QueryForObjs(GetObjQuery<FinancialAccount>(ctx),
                                     o => o.Name == financialaccount.Name && o.Id != financialaccount.Id).ToList();

                    if (financialaccountLinks.Count < 1)
                    {
                        FinancialAccount oldfinancialaccount = GetById(GetObjQuery<FinancialAccount>(ctx),
                                                                       financialaccount.Id);
                        List<FinancialAccount> faList =
                            QueryForObjs(GetObjQuery<FinancialAccount>(ctx), o => o.ParentId == oldfinancialaccount.Id).
                                ToList();
                        List<PaymentUsage> paymentusageList =
                            QueryForObjs(GetObjQuery<PaymentUsage>(ctx),
                                         o => o.FinancialAccountId == financialaccount.ParentId).ToList();
                        if (paymentusageList.Count > 0)
                        {
                            throw new FaultException(ErrCode.FinancialAccountUpdateFKErr.ToString());
                        }
                        if (faList.Count == 0)
                        {
                            oldfinancialaccount.Name = financialaccount.Name;
                            oldfinancialaccount.ParentId = financialaccount.ParentId;
                            oldfinancialaccount.AccountLevel = financialaccount.AccountLevel;
                            oldfinancialaccount.Description = financialaccount.Description;
                            oldfinancialaccount.IsIncludedInAPAR = financialaccount.IsIncludedInAPAR;
                        }
                        else
                        {
                            if (oldfinancialaccount.ParentId != financialaccount.ParentId)
                            {
                                throw new FaultException(ErrCode.FinancialAccountUpdate2FKErr.ToString());
                            }
                            oldfinancialaccount.Name = financialaccount.Name;
                            oldfinancialaccount.AccountLevel = financialaccount.AccountLevel;
                            oldfinancialaccount.Description = financialaccount.Description;
                            oldfinancialaccount.IsIncludedInAPAR = financialaccount.IsIncludedInAPAR;
                        }
                        ctx.SaveChanges();

                        return oldfinancialaccount;
                    }
                    throw new FaultException(ErrCode.FinancialAccountExisted.ToString());
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public override void RemoveById(int id, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    //有现金流关联，不能删除
                    if (QueryForObjs(GetObjQuery<FundFlow>(ctx), ff => ff.FinancialAccountId == id).Count > 0)
                    {
                        throw new FaultException(ErrCode.FinancialAccountFundFlowConnected.ToString());
                    }
                    //有付款用途关联，不能删除
                    if (QueryForObjs(GetObjQuery<PaymentUsage>(ctx), pu => pu.FinancialAccountId == id).Count > 0)
                    {
                        throw new FaultException(ErrCode.FinancialAccountPaymentUsageConnected.ToString());
                    }
                    FinancialAccount fa = QueryForObj(GetObjQuery<FinancialAccount>(ctx), p => p.Id == id);
                    fa.IsDeleted = true;
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
            //base.RemoveById(id, userId);
        }

        #endregion
    }
}
