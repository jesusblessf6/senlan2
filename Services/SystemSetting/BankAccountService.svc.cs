using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Transactions;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankAccountService" in code, svc and config file together.
    public class BankAccountService : BaseService<BankAccount>, IBankAccountService
    {
        #region IBankAccountService Members

        public override void RemoveById(int id, int userId)
        {
              try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        BankAccount bankAccount = QueryForObj(GetObjQuery<BankAccount>(ctx), o => o.Id == id);
                        bankAccount.IsDeleted = true;
                        Update(GetObjSet<BankAccount>(ctx), bankAccount);
                        ctx.SaveChanges();
                    }
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
        }

        /// <summary>
        /// 付款方项下和付款币种相同的资金类银行账户集合，Description为 账户银行名 – 账户名
        /// </summary>
        /// <returns></returns>
        public List<BankAccount> GetBankAccountsByCurrencyIdAndCustomerId(int currencyId, int customerId,
                                                                          BankAccountType bankAccountType)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var baType = (int) bankAccountType;
                    List<BankAccount> bankAct =
                        QueryForObjs(
                            GetObjQuery<BankAccount>(ctx, new Collection<string> {"Currency", "Bank", "BusinessPartner"}),
                            t => t.CurrencyId == currencyId && t.BusinessPartnerId == customerId && t.Usage == baType).
                            ToList();

                    foreach (BankAccount item in bankAct)
                    {
                        item.Description = (item.Bank == null ? "" : item.Bank.Name) + "-" +
                                           (item.AccountCode);
                    }

                    return bankAct;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<BankAccount> GetBankAccountsByPaymentMean(int? currencyId, int customerId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<BankAccount> bankAct = new List<BankAccount>();
                    if (currencyId != null)
                    {
                        bankAct = QueryForObjs(
                                 GetObjQuery<BankAccount>(ctx, new Collection<string> { "Currency", "Bank", "BusinessPartner" }),
                                 t => t.CurrencyId == currencyId && t.BusinessPartnerId == customerId).
                                 ToList();
                    }
                    else
                    {
                     bankAct = QueryForObjs(
                            GetObjQuery<BankAccount>(ctx, new Collection<string> {"Bank", "BusinessPartner" }),
                            t => t.BusinessPartnerId == customerId).
                            ToList();
                    }

                    //foreach (BankAccount item in bankAct)
                    //{
                    //    item.Description = (item.Bank == null ? "" : item.Bank.Name) + "-" +
                    //                       (item.AccountCode);
                    //}

                    foreach (BankAccount item in bankAct)
                    {
                        item.Description = (item.Bank == null ? "" : item.Bank.Name) + "-" +
                            (item.AccountCode) + (string.IsNullOrEmpty(item.Description) == true ? "" : ("-" + item.Description));
                    }

                    return bankAct;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="account"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BankAccount UpdateExistedAccount(BankAccount account, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    //if (account.IsDefault.Value)
                    //{
                    //    BankAccount defaultBankAccount = QueryForObj(GetObjQuery<BankAccount>(ctx), o => o.BusinessPartnerId == account.BusinessPartnerId && o.IsDefault == true);
                    //    if (defaultBankAccount != null)
                    //    {
                    //        defaultBankAccount.IsDefault = false;
                    //        Update(GetObjSet<BankAccount>(ctx), defaultBankAccount);
                    //    }
                    //}
                    //if(QueryForObjs(GetObjQuery<FundFlow>(ctx), o => o.BankAccountId == account.Id).Count > 0 ||
                    //    QueryForObjs(GetObjQuery<PaymentRequest>(ctx), o => o.PayBankAccountId == account.Id || 
                    //                                                    o.ReceiveBankAccountId == account.Id).Count > 0)
                    //{
                    //    throw new FaultException(ErrCode.BankAccountUsed.ToString());
                    //}

                    if (QueryForObjs(GetObjQuery<BankAccount>(ctx), o => o.BankId == account.BankId && o.AccountCode == account.AccountCode && o.Id != account.Id).Count > 0)
                    {
                        throw new FaultException(ErrCode.BankAccountExisted.ToString());
                    }

                    Update(GetObjSet<BankAccount>(ctx), account);
                    ctx.SaveChanges();
                    return account;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BankAccount AddNewAccount(BankAccount account, int userId)
        {
            try
            {
                using(var ctx = new SenLan2Entities(userId))
                {
                    if (account.IsDefault.Value)
                    {
                        BankAccount defaultBankAccount = QueryForObj(GetObjQuery<BankAccount>(ctx), o => o.BusinessPartnerId == account.BusinessPartnerId && o.IsDefault == true);
                        if (defaultBankAccount != null)
                        {
                            defaultBankAccount.IsDefault = false;
                            Update(GetObjSet<BankAccount>(ctx), defaultBankAccount);
                        }
                    }
                    if(QueryForObjs(GetObjQuery<BankAccount>(ctx), o => o.BankId == account.BankId &&
                        o.AccountCode == account.AccountCode &&
                        o.CurrencyId == account.CurrencyId).Count > 0)
                    {
                        throw new FaultException<ServerErr>(new ServerErr(ErrCode.BankAccountExisted),
                                                    new FaultReason(
                                                        ErrorMsgManager.GetErrMsg(ErrCode.BankAccountExisted)));
                    }

                    Create(GetObjSet<BankAccount>(ctx), account);
                    ctx.SaveChanges();
                    return account;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public BankAccount GetDefaultBankAccountByBusinessPartnerId(int userId, int businessPartnerId,int? currencyId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                BankAccount defaultBankAccount = new BankAccount();
                if (currencyId != null)
                {
                    defaultBankAccount = QueryForObj(GetObjQuery<BankAccount>(ctx, new List<string>() { "Bank" }), o => (o.IsDefault ?? false) && o.BusinessPartnerId == businessPartnerId && o.CurrencyId == currencyId);
                }
                else
                {
                    defaultBankAccount = QueryForObj(GetObjQuery<BankAccount>(ctx, new List<string>() { "Bank" }), o => (o.IsDefault ?? false) && o.BusinessPartnerId == businessPartnerId);
                }
                 
                if (defaultBankAccount != null)
                {
                    defaultBankAccount.Description = (defaultBankAccount.Bank == null ? "" : defaultBankAccount.Bank.Name) + "-" + (defaultBankAccount.AccountCode);
                }
                return defaultBankAccount;
            }
        }
        #endregion
    }
}