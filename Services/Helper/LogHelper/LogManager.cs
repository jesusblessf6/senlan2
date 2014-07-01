using System;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Utility.ErrorManagement;

namespace Services.Helper.LogHelper
{
    public class LogManager
    {
        public static void WriteLog(string tableCode, string actionCode, int objectId, int userId, int? approveStageId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    // Add new log
                    var l = new Log();

                    var doc = ctx.Documents.FirstOrDefault(o => o.TableCode == tableCode && !o.IsDeleted);
                    if (doc == null)
                    {
                        throw new FaultException<ServerErr>(new ServerErr(ErrCode.DocumentNotFound),
                            new FaultReason(ErrorMsgManager.GetErrMsg(ErrCode.DocumentNotFound)));
                    }
                    l.DocumentId = doc.Id;

                    var logAction = ctx.LogActions.FirstOrDefault(o => o.Code == actionCode && !o.IsDeleted);
                    if (logAction == null)
                    {
                        throw new FaultException<ServerErr>(new ServerErr(ErrCode.LogActionNotFound),
                            new FaultReason(ErrorMsgManager.GetErrMsg(ErrCode.LogActionNotFound)));
                    }
                    l.LogActionId = logAction.Id;

                    l.LogUserId = userId;

                    if(approveStageId != null && approveStageId > 0)
                    {
                        l.ApprovalStageId = approveStageId;
                    }

                    l.ObjectId = objectId;
                    l.LogTime = DateTime.Now;

                    ctx.Logs.AddObject(l);
                    ctx.SaveChanges();

                    // Add Log Messages
                    var lrs = ctx.LogRegistrations.Where(
                        o => o.DocumentId == doc.Id && o.LogActionId == logAction.Id && !o.IsDeleted).ToList();
                    foreach (var lr in lrs)
                    {
                        var lm = new LogMessage {LogId = l.Id, LogRegistrationId = lr.Id, UserId = lr.UserId, IsRead = false};
                        ctx.LogMessages.AddObject(lm);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
            
        }
    }
}