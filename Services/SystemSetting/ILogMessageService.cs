using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogMessageService" in both code and config file together.
    [ServiceContract]
    public interface ILogMessageService : IService<LogMessage>
    {
        [OperationContract]
        int GetUnreadLogCountByUser(int userId);

        [OperationContract]
        List<LogMessage> GetUnreadLogsByUser(int userId);

        [OperationContract]
        void MarkAsRead(int id, int userId);

        [OperationContract]
        List<LogMessage> GetUnreadLogsByUserWithRange(int userId, int from, int to);
    }
}
