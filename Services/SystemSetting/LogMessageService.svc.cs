using System.Collections.Generic;
using System.Linq;
using DBEntity;
using Services.Base;
using Utility.Misc;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogMessageService" in code, svc and config file together.
    public class LogMessageService : BaseService<LogMessage>, ILogMessageService
    {
        /// <summary>
        /// Get the count of the unread log message of given user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetUnreadLogCountByUser(int userId)
        {
            const string condition = "it.IsRead = false and it.UserId = @p1";
            var p = new List<object>{userId};
            return GetCount(condition, p);
        }

        /// <summary>
        /// Get unread log message by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<LogMessage> GetUnreadLogsByUser(int userId)
        {
            using (var ctx = new SenLan2Entities())
            {
                return
                    QueryForObjs(GetObjQuery<LogMessage>(ctx, new List<string>{"Log", "Log.Document", "Log.LogAction", "Log.User"}), o => o.UserId == userId && !o.IsRead).OrderByDescending(
                        o => o.Created).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public void MarkAsRead(int id, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var logMessage = GetById(GetObjQuery<LogMessage>(ctx), id);
                logMessage.IsRead = true;
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Get unread log message in range
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<LogMessage> GetUnreadLogsByUserWithRange(int userId, int from, int to)
        {
            const string condition = "it.UserId = @p1 and it.IsRead = false";
            var p = new List<object>{userId};

            return SelectByRangeWithOrder(condition, p, new SortCol {ByDescending = true, ColName = "Created"}, from, to,
                                   new List<string> {"Log", "Log.Document", "Log.LogAction", "Log.User"}).ToList();
        }
    }
}