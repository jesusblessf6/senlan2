using System;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.View.SystemSetting.CurrencyRateSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CurrencyRateSetting
{
    public class CurrencyDetailVM : BaseVM
    {
        #region Member

        private string _code;
        private string _description;
        private bool _isSystem;
        private string _name;

        #endregion

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    Notify("Code");
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

        public bool IsSystem
        {
            get { return _isSystem; }
            set
            {
                if (_isSystem != value)
                {
                    _isSystem = value;
                    Notify("IsSystem");
                }
            }
        }

        #endregion

        #region Constructor

        public CurrencyDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public CurrencyDetailVM(int currencyId)
        {
            ObjectId = currencyId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    Currency currency = currencyService.GetById(ObjectId);

                    if (currency != null)
                    {
                        Name = currency.Name;
                        Code = currency.Code;
                        Description = currency.Description;
                        IsSystem = currency.IsSystem;
                    }
                }
            }
        }

        protected override void Create()
        {
            var currency = new Currency
                               {
                                   Name = Name,
                                   Code = Code,
                                   Description = Description,
                                   IsSystem = IsSystem
                               };

            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                currencyService.AddNewCurrency(currency, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currency currency = currencyService.GetById(ObjectId);
                if (currency != null)
                {
                    currency.Name = Name;
                    currency.Code = Code;
                    currency.Description = Description;
                    currency.IsSystem = IsSystem;

                    currencyService.UpdateCurrency(currency, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResCurrencyRateSetting.CurrencyNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResCurrencyRateSetting.CurrencyNameRequired);
            }

            if (string.IsNullOrWhiteSpace(Code))
            {
                throw new Exception(ResCurrencyRateSetting.CurrencyCodeRequired);
            }

            return true;
        }

        #endregion
    }
}