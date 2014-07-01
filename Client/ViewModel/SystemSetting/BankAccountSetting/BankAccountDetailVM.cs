using System;
using System.Collections.Generic;
using Client.BankAccountServiceReference;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.View.SystemSetting.BankAccountSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.SystemSetting.BankAccountSetting
{
    public class BankAccountDetailVM : BaseVM
    {
        #region Member

        private string _accountCode;
        private string _bPartnerName;
        private string _bankName;
        private List<Bank> _banks;
        private List<Currency> _currencies;
        private string _description;
        private int _selectedBPartnerId;
        private int _selectedBankId;
        private int _selectedCurrencyId;
        private int _selectedUsageId;
        private List<EnumItem> _usages;
        private bool _isDefault;

        #endregion

        #region Property

        public List<EnumItem> Usages
        {
            get { return _usages; }
            set
            {
                if (_usages != value)
                {
                    _usages = value;
                    Notify("Usages");
                }
            }
        }

        public int SelectedBankId
        {
            get { return _selectedBankId; }
            set
            {
                if (_selectedBankId != value)
                {
                    _selectedBankId = value;
                    Notify("SelectedBankId");
                }
            }
        }

        public int SelectedBPartnerId
        {
            get { return _selectedBPartnerId; }
            set
            {
                if (_selectedBPartnerId != value)
                {
                    _selectedBPartnerId = value;
                    Notify("SelectedBPartnerId");
                }
            }
        }

        public int SelectedUsageId
        {
            get { return _selectedUsageId; }
            set
            {
                if (_selectedUsageId != value)
                {
                    _selectedUsageId = value;
                    Notify("SelectedUsageId");
                }
            }
        }

        public int SelectedCurrencyId
        {
            get { return _selectedCurrencyId; }
            set
            {
                if (_selectedCurrencyId != value)
                {
                    _selectedCurrencyId = value;
                    Notify("SelectedCurrencyId");
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

        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                Notify("Currencies");
            }
        }

        public string AccountCode
        {
            get { return _accountCode; }
            set
            {
                if (_accountCode != value)
                {
                    _accountCode = value;
                    Notify("AccountCode");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (_bankName != value)
                {
                    _bankName = value;
                    Notify("BankName");
                }
            }
        }

        public string BPartnerName
        {
            get { return _bPartnerName; }
            set
            {
                if (_bPartnerName != value)
                {
                    _bPartnerName = value;
                    Notify("BPartnerName");
                }
            }
        }

        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    Notify("IsDefault");
                }
            }
        }

        #endregion

        #region Constructor

        public BankAccountDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public BankAccountDetailVM(int accountId)
        {
            ObjectId = accountId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                _currencies = currencyService.GetAll();
                _currencies.Insert(0, new Currency {Id = 0, Name = ""});
            }

            _usages = EnumHelper.GetEnumList<BankAccountType>();
            _usages.Insert(0, new EnumItem {Id = 0, Name = ""});

            if (ObjectId > 0)
            {
                using (
                    var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc)
                    )
                {
                    BankAccount account = accountService.FetchById(ObjectId,
                                                                   new List<string> {"Bank", "BusinessPartner"});

                    _selectedBankId = account.BankId;
                    _bankName = account.Bank.Name;
                    _bPartnerName = account.BusinessPartner == null ? "" : account.BusinessPartner.ShortName;
                    _selectedBPartnerId = account.BusinessPartnerId ?? 0;
                    _accountCode = account.AccountCode;
                    _selectedUsageId = account.Usage ?? 0;
                    _selectedCurrencyId = account.CurrencyId ?? 0;
                    _description = account.Description;
                    _isDefault = account.IsDefault ?? false;
                }
            }
            else
            {
                _selectedBankId = 0;
                _bankName = string.Empty;
                _bPartnerName = string.Empty;
                _selectedBPartnerId = 0;
                _accountCode = string.Empty;
                _selectedUsageId = 0;
                _selectedCurrencyId = 0;
                _description = string.Empty;
            }
        }

        public override bool Validate()
        {
            if (SelectedBankId == 0)
            {
                throw new Exception(ResBankAccountSetting.BankRequired);
            }

            if (string.IsNullOrWhiteSpace(AccountCode))
            {
                throw new Exception(ResBankAccountSetting.BankAccountRequired);
            }

            if (SelectedCurrencyId == 0)
            {
                throw new Exception(Properties.Resources.CurrencyNotNull);
            }

            if (SelectedUsageId <= 0)
            {
                throw new Exception(ResBankAccountSetting.AccountUsageRequired);
            }

            if (SelectedBPartnerId <= 0)
            {
                throw new Exception(ResBankAccountSetting.BPRequired);
            }

            if (IsDefault)
            {
                using (
                var bankAccountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc)
                )
                {
                    int currencyId = SelectedCurrencyId;
                    int customerId = SelectedBPartnerId;
                    List<BankAccount> accounts = bankAccountService.GetBankAccountsByCurrencyIdAndCustomerId(currencyId,
                                                                                                             customerId,
                                                                                                             BankAccountType
                                                                                                                 .Asset);
                    if (accounts.Count > 0)
                    {
                        List<BankAccount> defaultAccountList = accounts.Where(c => c.IsDefault != null && c.IsDefault.Value).ToList();
                        if (defaultAccountList.Count > 0)
                        {
                            if (defaultAccountList.Select(c => c.Id).Contains(ObjectId))
                            {
                                if (defaultAccountList.Count > 1)
                                {
                                    throw new Exception("一个客户在同一个币种下只能有一个默认银行账户");
                                }
                            }
                            else
                            {
                                throw new Exception("一个客户在同一个币种下只能有一个默认银行账户");
                            }
                        }
                    }
                }
            }
            return true;
        }

        protected override void Create()
        {
            var account = new BankAccount
                              {
                                  BankId = SelectedBankId,
                                  AccountCode = AccountCode,
                                  Usage = SelectedUsageId,
                                  Description = Description,
                                  BusinessPartnerId = SelectedBPartnerId,
                                  CurrencyId = SelectedCurrencyId,
                                  IsDefault = IsDefault
                              };

            using (var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
            {
                accountService.AddNewAccount(account, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var accountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
            {
                BankAccount account = accountService.GetById(ObjectId);
                if (account != null)
                {
                    account.BankId = SelectedBankId;
                    account.BusinessPartnerId = SelectedBPartnerId;
                    account.CurrencyId = SelectedCurrencyId;
                    account.AccountCode = AccountCode;
                    account.Usage = SelectedUsageId;
                    account.Description = Description;
                    account.IsDefault = IsDefault;
                }

                accountService.UpdateExistedAccount(account, CurrentUser.Id);
            }
        }

        #endregion
    }
}