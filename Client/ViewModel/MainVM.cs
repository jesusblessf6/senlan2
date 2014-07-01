using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Client.Base.BaseClientVM;
using Client.LogMessageServiceReference;
using Client.RoleServiceReference;
using Client.View;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel
{
    public class MainVM : BaseVM
    {
        #region Member

        private List<Category> _categories;
        private List<ModulePermPair> _modulePermPairs;
        private int _unreadLogCount;
        private bool _logNumberChanged;

        #endregion

        #region Property


        public Main Main { get; set; }

        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public List<ModulePermPair> ModulePermPairs
        {
            get { return _modulePermPairs; }
            set { _modulePermPairs = value; }
        }

        public int UnreadLogCount
        {
            get { return _unreadLogCount; }
            set
            {
                if(_unreadLogCount != value)
                {
                    if (value > _unreadLogCount)
                    {
                        LogNumberChanged = true;
                        LogNumberChanged = false;
                    }
                    _unreadLogCount = value;
                    Notify("UnreadLogCount");
                }
            }
        }

        public bool LogNumberChanged
        {
            get { return _logNumberChanged; }
            set
            {
                if(_logNumberChanged != value)
                {
                    _logNumberChanged = value;
                    Notify("LogNumberChanged");
                }
            }
        }

        #endregion

        #region Constructor

        public MainVM()
        {
            _categories = new List<Category>();
            _modulePermPairs = new List<ModulePermPair>();
            LoadPerms();
        }

        private void LoadPerms()
        {
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                List<Function> functions = roleService.GetPermsByRole(CurrentUser.RoleId ?? 0);
                _categories = functions.Select(o => o.Module.Category).Distinct().ToList();
                foreach (Function f in functions)
                {
                    _modulePermPairs.Add(new ModulePermPair {ModuleId = f.ModuleId, Mode = f.PageMode});
                }

                Application.Current.Properties["ModulePermPairs"] = _modulePermPairs;
            }
        }

        #endregion

        #region Method

        public static int GetUnreadLogCount(int userId)
        {
            using (var logMessageService = SvcClientManager.GetSvcClient<LogMessageServiceClient>(SvcType.LogMessageSvc))
            {
                return logMessageService.GetUnreadLogCountByUser(userId);
            }
        }

        #endregion
    }

    public class ModulePermPair
    {
        public int ModuleId { get; set; }
        public string Mode { get; set; }
    }
}