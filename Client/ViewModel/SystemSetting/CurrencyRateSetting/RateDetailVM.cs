using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.RateServiceReference;
using Client.View.SystemSetting.CurrencyRateSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CurrencyRateSetting
{
    public class RateDetailVM : BaseVM
    {
        #region Members

        private List<Currency> _currencies;
        private decimal? _currencyRate;
        private string _description;
        private int _foreignCurrencyId;

        #endregion

        #region Property

        public decimal? CurrencyRate
        {
            get { return _currencyRate; }
            set
            {
                if (_currencyRate != value)
                {
                    _currencyRate = value;
                    Notify("CurrencyRate");
                }
            }
        }

        public int ForeignCurrencyId
        {
            get { return _foreignCurrencyId; }
            set
            {
                if (_foreignCurrencyId != value)
                {
                    _foreignCurrencyId = value;
                    Notify("ForeignCurrencyId");
                }
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

        #endregion

        #region Constructor

        public RateDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public RateDetailVM(int rateId)
        {
            ObjectId = rateId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var crrencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currencies = crrencyService.GetAll();
                Currencies.Insert(0, new Currency {Id = 0, Name = string.Empty});
            }

            if (ObjectId > 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    Rate rate = rateService.FetchById(ObjectId, new List<string> {"Currency"});

                    ForeignCurrencyId = rate.Currency.Id;
                    CurrencyRate = rate.RateValue;
                    Description = rate.Description;
                }
            }
        }

        protected override void Create()
        {
            var rate = new Rate
                           {
                               RateValue = CurrencyRate,
                               ForeignCurrencyId = ForeignCurrencyId,
                               Description = Description
                           };

            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
            {
                rateService.AddNewRate(rate, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
            {
                Rate rate = rateService.GetById(ObjectId);

                if (rate != null)
                {
                    rate.RateValue = CurrencyRate;
                    rate.Description = Description;
                    rate.ForeignCurrencyId = ForeignCurrencyId;

                    rateService.UpdateRate(rate, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResCurrencyRateSetting.ExchangeRateNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (CurrencyRate == null)
            {
                throw new Exception(Properties.Resources.ExchangeRateNotNull);
            }
            if (CurrencyRate <= 0)
            {
                throw new Exception(ResCurrencyRateSetting.ExchangeRatePositive);
            }

            if (ForeignCurrencyId == 0)
            {
                throw new Exception(Properties.Resources.CurrencyNotNull);
            }

            return true;
        }

        #endregion
    }
}