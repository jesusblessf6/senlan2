using DBEntity;
using Services.Base;
using System.Data;
using System.ServiceModel;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankService" in code, svc and config file together.
    public class BankService : BaseService<Bank>, IBankService
    {
        /// <summary>
        /// Add new Bank. At the same time validate the name.
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Bank AddNewBank(Bank bank, int userId)
        {
            try
            {
                using(var ctx = new SenLan2Entities(userId))
                {
                    if(QueryForObjs(GetObjQuery<Bank>(ctx), o => o.Name == bank.Name).Count > 0)
                    {
                        throw new FaultException(ErrCode.BankNameExisted.ToString());
                    }

                    Create(GetObjSet<Bank>(ctx), bank);
                    ctx.SaveChanges();
                    return bank;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Update the Bank. Validate the name.
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Bank UpdateExistedBank(Bank bank, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    if (QueryForObjs(GetObjQuery<Bank>(ctx), o => o.Name == bank.Name && o.Id != bank.Id).Count > 0)
                    {
                        throw new FaultException(ErrCode.BankNameExisted.ToString());
                    }

                    Update(GetObjSet<Bank>(ctx), bank);
                    ctx.SaveChanges();
                    return bank;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}