using System.Collections.Generic;
using Client.BankAccountServiceReference;
using Client.BankServiceReference;
using Client.Base.BaseClientVM;
using DBEntity;
using Utility.ServiceManagement;
using Utility.Misc;
using System.Text;

namespace Client.ViewModel.SystemSetting.BankAccountSetting
{
    public class BankAccountSettingVM : BaseVM
    {
        #region Member

        private int _accountCount;
        private int _accountFrom;
        private int _accountTo;
        private List<BankAccount> _bankAccounts;
        private int _bankCount;
        private int _bankFrom;
        private int _bankTo;
        private List<Bank> _banks;
        private string _searchName;
        private string _searchCustomerName;
        private int? _searchCustomerId;
        private string _searchBankAccountName;
        private bool _searchState;
        #endregion

        #region Property
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                if (_searchName != value)
                {
                    _searchName = value;
                    Notify("SearchName");
                }
            }
        }

        public string SearchCustomerName
        {
            get { return _searchCustomerName; }
            set
            {
                if (_searchCustomerName != value)
                {
                    _searchCustomerName = value;
                    Notify("SearchCustomerName");
                }
            }
        }

        public int? SearchCustomerId
        {
            get { return _searchCustomerId; }
            set
            {
                if (_searchCustomerId != value)
                {
                    _searchCustomerId = value;
                    Notify("SearchCustomerId");
                }
            }
        }

        public string SearchBankAccountName
        {
            get { return _searchBankAccountName; }
            set
            {
                if (_searchBankAccountName != value)
                {
                    _searchBankAccountName = value;
                    Notify("SearchBankAccountName");
                }
            }
        }

        public bool SearchState
        {
            get { return _searchState; }
            set
            {
                if (_searchState != value)
                {
                    _searchState = value;
                    Notify("SearchState");
                }
            }
        }

        public List<Bank> Banks
        {
            get { return _banks; }
            set
            {
                _banks = value;
                Notify("Banks");
            }
        }

        public List<BankAccount> BankAccounts
        {
            get { return _bankAccounts; }
            set
            {
                _bankAccounts = value;
                Notify("BankAccounts");
            }
        }

        public int BankCount
        {
            get { return _bankCount; }
            set
            {
                if (_bankCount != value)
                {
                    _bankCount = value;
                    Notify("BankCount");
                }
            }
        }

        public int BankFrom
        {
            get { return _bankFrom; }
            set
            {
                if (_bankFrom != value)
                {
                    _bankFrom = value;
                    Notify("BankFrom");
                }
            }
        }

        public int BankTo
        {
            get { return _bankTo; }
            set
            {
                if (_bankTo != value)
                {
                    _bankTo = value;
                    Notify("BankTo");
                }
            }
        }

        public int AccountCount
        {
            get { return _accountCount; }
            set
            {
                if (_accountCount != value)
                {
                    _accountCount = value;
                    Notify("AccountCount");
                }
            }
        }

        public int AccountFrom
        {
            get { return _accountFrom; }
            set
            {
                if (_accountFrom != value)
                {
                    _accountFrom = value;
                    Notify("AccountFrom");
                }
            }
        }

        public int AccountTo
        {
            get { return _accountTo; }
            set
            {
                if (_accountTo != value)
                {
                    _accountTo = value;
                    Notify("AccountTo");
                }
            }
        }

        #endregion

        #region Constructor

        public BankAccountSettingVM()
        {
            _bankAccounts = new List<BankAccount>();
            _banks = new List<Bank>();

            LoadCount();
        }

        #endregion

        #region Method

        public void LoadCount()
        {
            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                BankCount = bankService.GetAllCount();
            }

            using (var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
            {
                AccountCount = accountService.GetAllCount();
            }
        }

        public void LoadBank()
        {
            SearchBanks(true);
        }

        public void LoadBankAccount()
        {
            SearchBankAccounts(true);
        }

        public void DeleteBank(int id)
        {
            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                bankService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void DeleteAccount(int id)
        {
            using (var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
            {
                accountService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void SearchBanks(bool state)
        {
            SearchState = state;
            string queryStr;
            List<object> parameters;
            BuildQueryStrAndParams(out queryStr, out parameters);
            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                if (queryStr != "")
                {
                    BankCount = bankService.GetCount(queryStr, parameters);
                    Banks = bankService.QueryByRange(queryStr, parameters, BankFrom, BankTo);
                }
                else
                {
                    BankCount = bankService.GetAllCount();
                    Banks = bankService.GetByRangeWithOrder(new SortCol { ByDescending = true, ColName = "Id" }, BankFrom,
                                                          BankTo);
                }
            }
        }

        public void SearchBankAccounts(bool state) 
        {
            SearchState = state;
            string queryStr;
            List<object> parameters;
            BuildQueryStrAndParamsBankAccount(out queryStr, out parameters);
            using (var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
            {
                if (queryStr != "")
                {
                    AccountCount = accountService.GetCount(queryStr, parameters);
                    BankAccounts = accountService.SelectByRange(queryStr, parameters, AccountFrom, AccountTo,new List<string> { "Bank", "Currency", "BusinessPartner" });
                }
                else
                {
                    AccountCount = accountService.GetAllCount();
                    BankAccounts = accountService.FetchByRange(AccountFrom,
                                                          AccountTo, new List<string> { "Bank", "Currency", "BusinessPartner" });
                }
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            queryStr = string.Empty;
            parameters = new List<object>();
            if (!SearchState)
                return;
            var sb = new StringBuilder();
            const int num = 1;
            if (!string.IsNullOrEmpty(SearchName))
            {
                sb.AppendFormat("it.Name like @p{0} ", num);
                parameters.Add("%" + SearchName.Trim() + "%");
            }
            queryStr = sb.ToString();
        }

        private void BuildQueryStrAndParamsBankAccount(out string queryStr, out List<object> parameters)
        {
            queryStr = string.Empty;
            parameters = new List<object>();
            if (!SearchState)
                return;
            var sb = new StringBuilder();
            int num = 1;
            if (!string.IsNullOrEmpty(SearchBankAccountName))
            {
                sb.AppendFormat("it.Bank.Name like @p{0} ", num++);
                parameters.Add("%" + SearchBankAccountName.Trim() + "%");
            }
            if (SearchCustomerId>0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.BusinessPartner.id= @p{0} ", num);
                parameters.Add(SearchCustomerId);
            }
            queryStr = sb.ToString();
        }

        

        #endregion
    }
}