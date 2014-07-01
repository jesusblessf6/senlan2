using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.LogMessageServiceReference;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Console.LogMessages
{
    public sealed class LogMessageListVM : ListBaseVM
    {
        #region Constructor

        public LogMessageListVM(List<QueryElement> cons) : base(cons)
        {
            InitService();
            RegisterIncludes();
        }

        #endregion

        #region Method

        /// <summary>
        /// Mark the message as read
        /// </summary>
        /// <param name="id"></param>
        public void MarkAsRead(int id)
        {
            using (var logMessageService = SvcClientManager.GetSvcClient<LogMessageServiceClient>(SvcType.LogMessageSvc))
            {
                logMessageService.MarkAsRead(id, CurrentUser.Id);
            }
        }

        public override void InitService()
        {
            SvcClient = SvcClientManager.GetSvcClient<LogMessageServiceClient>(SvcType.LogMessageSvc);
        }

        public override void RegisterIncludes()
        {
            Includes = new List<string>();
        }

        public override void LoadList()
        {
            using (var logMessageService = SvcClientManager.GetSvcClient<LogMessageServiceClient>(SvcType.LogMessageSvc))
            {
                Entities = logMessageService.GetUnreadLogsByUserWithRange(CurrentUser.Id, From, To);
            }
        }

        public override void GetRecCount()
        {
            using (var logMessageService = SvcClientManager.GetSvcClient<LogMessageServiceClient>(SvcType.LogMessageSvc))
            {
                TotalCount = logMessageService.GetUnreadLogCountByUser(CurrentUser.Id);
            }
        }

        #endregion
    }
}
