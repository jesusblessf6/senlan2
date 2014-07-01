using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.FinancialAccountServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.FinancialAccountSetting
{
    public class FinancialAccountHomeVM : BaseVM
    {
        #region Members

        private int _financialAccountCount;
        private int _financialAccountFrom;
        private int _financialAccountTo;
        private List<FinancialAccount> _financialAccounts4;
        private bool _isRoot;
        private string _selectedFinancialAccountName;

        #endregion

        #region Property

        public List<FinancialAccount> FinancialAccounts3 { get; set; }

        public List<FinancialAccount> FinancialAccounts4
        {
            get { return _financialAccounts4; }
            set
            {
                _financialAccounts4 = value;
                Notify("FinancialAccounts4");
            }
        }

        public int FinancialAccountCount
        {
            get { return _financialAccountCount; }
            set
            {
                if (_financialAccountCount != value)
                {
                    _financialAccountCount = value;
                    Notify("FinancialAccountCount");
                }
            }
        }

        public int FinancialAccountFrom
        {
            get { return _financialAccountFrom; }
            set
            {
                if (_financialAccountFrom != value)
                {
                    _financialAccountFrom = value;
                    Notify("FinancialAccountFrom");
                }
            }
        }

        public int FinancialAccountTo
        {
            get { return _financialAccountTo; }
            set
            {
                if (_financialAccountTo != value)
                {
                    _financialAccountTo = value;
                    Notify("FinancialAccountTo");
                }
            }
        }

        public FinancialAccount FinancialAccount { get; set; }

        public string SelectedFinancialAccountName
        {
            get { return _selectedFinancialAccountName; }
            set
            {
                if (value != _selectedFinancialAccountName)
                {
                    _selectedFinancialAccountName = value;
                    Notify("SelectedFinancialAccountName");
                }
            }
        }

        public bool IsRoot
        {
            get { return _isRoot; }
            set
            {
                if (_isRoot != value)
                {
                    _isRoot = value;
                    Notify("IsRoot");
                }
            }
        }

        #endregion

        #region Constructor

        public FinancialAccountHomeVM()
        {
            LoadFinancialAccountCount();
        }

        #endregion

        #region Method

        public void Load()
        {
            LoadFinancialAccountTree();
            LoadSelectedFinancialAccountName();
        }

        public void LoadFinancialAccountTree()
        {
            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                var includes = new List<string> {"Children"};
                List<FinancialAccount> financialaccounts = financialaccountService.FetchAll(includes);
                FinancialAccounts3 = financialaccounts.Where(o => o.ParentId == null).ToList();
                foreach (FinancialAccount fa in FinancialAccounts3)
                {
                    FilterDeleted(fa.Children);
                }
            }
        }

        public void LoadSelectedFinancialAccountName()
        {
            SelectedFinancialAccountName = FinancialAccount == null ? "" : FinancialAccount.Name;
        }

        public void LoadFinancialAccountDetails()
        {
            const string condition = "it.ParentId = @p1";
            var parameters = new List<object> {FinancialAccount == null ? 0 : FinancialAccount.Id};
            var includes2 = new List<string> {"Children"};
            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                List<FinancialAccount> financialaccountCount = financialaccountService.Select(condition, parameters,
                                                                                              includes2);
                List<FinancialAccount> financialaccounts =
                    financialaccountService.SelectByRangeWithOrder(condition,
                                                                   parameters,
                                                                   new SortCol {ByDescending = true, ColName = "Id"},
                                                                   FinancialAccountFrom,
                                                                   FinancialAccountTo,
                                                                   includes2);
                FinancialAccounts4 = financialaccounts;
                _financialAccountCount = financialaccountCount.Count();
            }
        }

        public void LoadFinancialAccountCount()
        {
            const string condition = "it.ParentId = @p1";
            var parameters = new List<object> {FinancialAccount == null ? 0 : FinancialAccount.Id};
            var includes2 = new List<string> {"Children"};
            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                List<FinancialAccount> financialaccountCount = financialaccountService.Select(condition, parameters,
                                                                                              includes2);

                _financialAccountCount = financialaccountCount.Count();
            }
        }

        public void DeleteFinancialAccount(int id)
        {
            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                financialaccountService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}