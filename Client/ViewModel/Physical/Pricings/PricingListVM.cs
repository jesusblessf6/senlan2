using System.Collections.Generic;
using Client.Base.BaseClientVM;
using DBEntity;
using Client.PricingServiceReference;
using Utility.ServiceManagement;
using DBEntity.EnumEntity;
using System;

namespace Client.ViewModel.Physical.Pricings
{
    public class PricingListVM : BaseVM
    {
        #region Member
        private decimal? _avgPricing;
        private List<Pricing> _pricings;

        #endregion

        #region Property

        public List<Pricing> Pricings
        {
            get { return _pricings; }
            set
            {
                _pricings = value;
                Notify("Pricings");
            }
        }
        public decimal? AVGPricing
        {
            get { return Math.Round(_avgPricing == null ? 0 : (decimal)_avgPricing, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                _avgPricing = value;
                Notify("AVGPricing");
            }
        }


        #endregion

        #region Constructor

        public PricingListVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Constructor

        public void Initialize()
        {
            if(ObjectId > 0)
            {
                using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                {
                    Pricings = pricingService.GetPricingByQuotaId(ObjectId);
                    AVGPricing = pricingService.GetAvgPricing(ObjectId);
                }
            }
        }

        #endregion
    }
}
