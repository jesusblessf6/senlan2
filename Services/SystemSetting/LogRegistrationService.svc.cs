using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Linq;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogRegistrationService" in code, svc and config file together.
    public class LogRegistrationService : BaseService<LogRegistration>, ILogRegistrationService
    {
        /// <summary>
        /// Get the Log Registration info by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<LogRegistration> GetRegsByUser(int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<LogRegistration>(ctx, new List<string> {"Document", "LogAction"}),
                                 o => o.UserId == userId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Update the user's log registration
        /// </summary>
        /// <param name="regs"></param>
        /// <param name="userId"></param>
        public void UpdateUserRegistration(List<LogRegistration> regs, int userId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        var lrs = QueryForObjs(GetObjQuery<LogRegistration>(ctx), o => o.UserId == userId);
                        foreach (var logRegistration in lrs)
                        {
                            Delete(GetObjSet<LogRegistration>(ctx), logRegistration);
                        }
                        ctx.SaveChanges();

                        foreach (var lr in regs)
                        {
                            var l = lr;
                            var reg = new LogRegistration();

                            var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == l.Document.TableCode);
                            reg.DocumentId = doc.Id;

                            var action = QueryForObj(GetObjQuery<LogAction>(ctx), o => o.Code == l.LogAction.Code);
                            reg.LogActionId = action.Id;

                            reg.UserId = userId;
                            Create(GetObjSet<LogRegistration>(ctx), reg);
                        }
                        ctx.SaveChanges();

                        ts.Complete();
                    }
                }
                
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

    }
}
