using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.RateServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CurrencyRateSetting
{
    public class CurrencyRateHomeVM : BaseVM
    {
        #region Member

        private List<Currency> _currencies;
        private List<Rate> _rates;

        #endregion

        #region Property

        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                Notify("Currencies");
            }
        }

        public List<Rate> Rates
        {
            get { return _rates; }
            set
            {
                _rates = value;
                Notify("Rates");
            }
        }

        #endregion

        #region Constructor

        public CurrencyRateHomeVM()
        {
            _currencies = new List<Currency>();
            LoadCurrency();
            _rates = new List<Rate>();
            LoadRate();
        }

        #endregion

        #region Method

        public void LoadCurrency()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currencies = currencyService.GetAll();
            }
        }

        public void LoadRate()
        {
            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
            {
                Rates = rateService.FetchAll(new List<string> {"Currency"});
            }
        }

        public void DeleteCurrency(int id)
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                currencyService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void DeleteRate(int id)
        {
            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
            {
                rateService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}