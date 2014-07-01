using System;
using System.Collections.Generic;
using System.ComponentModel;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.PricingServiceReference;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.UnpricingServiceReference;
using Client.View.Physical.Pricings;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.Linq;

namespace Client.ViewModel.Physical.Pricings
{
    public class ManualPricingDetailVM : BaseVM
    {
        #region Member

        private int _quotaId;
        private string _quotaNo;
        private int _unpricingId;
        private string _pricingStatus;
        private decimal? _quotaQuantity;
        private decimal? _pricedQuantity;
        private decimal? _pricingQuantity;
        private DateTime? _pricingDate;
        private int _pricingBasisId;
        private List<EnumItem> _pricingBasises; 
        private decimal? _basicPrice;
        private decimal? _adjustQPFee;
        private decimal? _deferFee;
        private decimal? _premium;
        private decimal? _finalPrice;
        private string _currencyCode;
        private decimal? _rate;
        private string _descripion;
        private int _selectedCurrencyId;
        private List<Currency> _currencies;
        private DateTime? _priceDate;
        private bool _isPricingComplete;
        private List<int> _idList;

        #endregion

        #region Property
        public List<int> IdList
        {
            get { return _idList; }
            set
            {
                if (_idList != value)
                {
                    _idList = value;
                    Notify("IdList");
                }
            }
        }

        public bool IsPricingComplete
        {
            get { return _isPricingComplete; }
            set
            {
                if (_isPricingComplete != value)
                {
                    _isPricingComplete = value;
                    Notify("IsPricingComplete");
                }
            }
        }

        public DateTime? PriceDate
        {
            get { return _priceDate; }
            set { 
                if(_priceDate != value)
                {
                    _priceDate = value;
                    Notify("PriceDate");
                }
            }
        }

        public int SettlementCurrencyId { get; set; }

        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                if (_quotaId != value)
                {
                    _quotaId = value;
                    Notify("QuotaId");
                }
            }
        }

        public int UnpricingId
        {
            get { return _unpricingId; }
            set
            {
                if(_unpricingId != value)
                {
                    _unpricingId = value;
                    Notify("UnpricingId");
                }
            }
        }

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                if (_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public string PricingStatus
        {
            get { return _pricingStatus; }
            set
            {
                if (_pricingStatus != value)
                {
                    _pricingStatus = value;
                    Notify("PricingStatus");
                }
            }
        }

        public decimal? QuotaQuantity
        {
            get { return _quotaQuantity; }
            set
            {
                if (_quotaQuantity != value)
                {
                    _quotaQuantity = value;
                    Notify("QuotaQuantity");
                }
            }
        }

        public decimal? PricedQuantity
        {
            get { return _pricedQuantity; }
            set
            {
                if (_pricedQuantity != value)
                {
                    _pricedQuantity = value;
                    Notify("PricedQuantity");
                }
            }
        }

        public decimal? PricingQuantity
        {
            get { return _pricingQuantity; }
            set
            {
                if (_pricingQuantity != value)
                {
                    _pricingQuantity = value;
                    Notify("PricingQuantity");
                }
            }
        }

        public DateTime? PricingDate
        {
            get { return _pricingDate; }
            set
            {
                if (_pricingDate != value)
                {
                    _pricingDate = value;
                    Notify("PricingDate");
                }
            }
        }

        public int PricingBasisId
        {
            get { return _pricingBasisId; }
            set
            {
                if (_pricingBasisId != value)
                {
                    _pricingBasisId = value;
                    Notify("PricingBasisId");
                }
            }
        }

        public decimal? BasicPrice
        {
            get { return _basicPrice; }
            set
            {
                if (_basicPrice != value)
                {
                    _basicPrice = value;
                    Notify("BasicPrice");
                }
            }
        }

        public decimal? AdjustQpFee
        {
            get { return _adjustQPFee; }
            set
            {
                if (_adjustQPFee != value)
                {
                    _adjustQPFee = value;
                    Notify("AdjustQpFee");
                }
            }
        }

        public decimal? DeferFee
        {
            get { return _deferFee; }
            set
            {
                if (_deferFee != value)
                {
                    _deferFee = value;
                    Notify("DeferFee");
                }
            }
        }

        public decimal? Premium
        {
            get { return _premium; }
            set
            {
                if (_premium != value)
                {
                    _premium = value;
                    Notify("Premium");
                }
            }
        }

        public decimal? FinalPrice
        {
            get { return _finalPrice; }
            set
            {
                if (_finalPrice != value)
                {
                    _finalPrice = value;
                    Notify("FinalPrice");
                }
            }
        }

        public int SelectedCurrencyId
        {
            get { return _selectedCurrencyId; }
            set
            {
                if(_selectedCurrencyId != value)
                {
                    _selectedCurrencyId = value;
                    Notify("SelectedCurrencyId");
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

        public decimal? Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    Notify("Rate");
                }
            }
        }

        public string Descripion
        {
            get { return _descripion; }
            set
            {
                if (_descripion != value)
                {
                    _descripion = value;
                    Notify("Descripion");
                }
            }
        }

        public List<EnumItem> PricingBasises
        {
            get { return _pricingBasises; }
            set
            {
                _pricingBasises = value;
                Notify("PricingBasises");
            }
        }

        public string CurrencyCode
        {
            get { return _currencyCode; }
            set
            {
                if(_currencyCode != value)
                {
                    _currencyCode = value;
                    Notify("CurrencyCode");
                }
            }
        }

        #endregion

        #region Constructor

        public ManualPricingDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public ManualPricingDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        /// <summary>
        /// Initialize the VM
        /// </summary>
        private void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            //Pricing Basises
            var basises = EnumHelper.GetEnumList<PricingBasis>();
            basises.Insert(0, new EnumItem{Id = 0, Name = string.Empty});
            _pricingBasises = basises;

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }

            //currencies
            using (var curService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                var currencies = curService.GetAll();
                currencies.Insert(0, new Currency{Id = 0, Name = string.Empty});
                _currencies = currencies;
                _selectedCurrencyId = 0;
            }

            if (ObjectId > 0)
            {
                var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc);
                Pricing pricing = pricingService.FetchById(ObjectId, new List<string> {"Quota"});

                if (pricing != null)
                {
                    _quotaId = pricing.QuotaId;

                    LoadQuotaRelatedInfo();

                    _pricingQuantity = pricing.PricingQuantity;
                    _pricingDate = pricing.PricingDate;
                    _basicPrice = pricing.BasicPrice;
                    _adjustQPFee = pricing.AdjustQPFee;
                    _deferFee = pricing.DeferFee;
                    _finalPrice = pricing.FinalPrice;
                    _descripion = pricing.Description;
                    _pricingBasisId = pricing.PricingBasis ?? 0;
                    _premium = pricing.Premium;
                    _selectedCurrencyId = pricing.CurrencyId ?? 0;
                    _rate = pricing.ExchangeRate;
                    _priceDate = pricing.PriceDate;


                    using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                    {
                        var currency = currencyService.GetById(SelectedCurrencyId);
                        if (currency != null) _currencyCode = currency.Code;
                    }

                    return;
                }
            }

            _pricingDate = DateTime.Today;
        }

        /// <summary>
        /// Create the pricing
        /// </summary>
        protected override void Create()
        {
            var p = new Pricing
                        {
                            AdjustQPFee = AdjustQpFee,
                            BasicPrice = BasicPrice,
                            DeferFee = DeferFee,
                            PricingDate = PricingDate,
                            PricingQuantity = PricingQuantity,
                            QuotaId = QuotaId,
                            UnpricingId = UnpricingId,
                            FinalPrice = FinalPrice,
                            PricingBasis = PricingBasisId,
                            CurrencyId =  SelectedCurrencyId,
                            Premium = Premium,
                            PriceDate = PriceDate,
                            ExchangeRate = Rate
                        };

            var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc);
            var returnedPricing = pricingService.AddNewManualPricing(p, CurrentUser.Id, IsPricingComplete);
            
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var q = quotaService.GetById(QuotaId);
                if (q.RelQuotaId != null)
                {
                    p.QuotaId = q.RelQuotaId.Value;
                    p.RelPricingId = returnedPricing.Id;
                    p.IsAutoGenerated = true;

                    using (var upService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
                    {
                        //var tu = upService.GetById(UnpricingId);
                        var tu = upService.Query("it.RelUnpricingId = " + UnpricingId, null).FirstOrDefault();
                        if (tu != null && tu.RelUnpricingId != null)
                        {
                            p.UnpricingId = tu.Id;
                            pricingService.AddNewManualPricing(p, CurrentUser.Id, IsPricingComplete);
                        }
                    }
                }                
            }
        }   

        /// <summary>
        /// Update Pricing
        /// </summary>
        protected override void Update()
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                var pricing = pricingService.SelectById(new List<string>{"RelatedPricings"}, ObjectId);
                pricing.AdjustQPFee = AdjustQpFee;
                pricing.BasicPrice = BasicPrice;
                pricing.PricingDate = PricingDate;
                pricing.PricingQuantity = PricingQuantity;
                pricing.PricingBasis = PricingBasisId;
                pricing.FinalPrice = FinalPrice;
                pricing.Description = Descripion;
                pricing.Premium = Premium;
                pricing.ExchangeRate = Rate;
                pricing.PriceDate = PriceDate;
                pricing.CurrencyId = SelectedCurrencyId;

                pricingService.UpdateManualPricing(pricing, CurrentUser.Id, IsPricingComplete);

                if (pricing.RelatedPricings != null && pricing.RelatedPricings.Count > 0)
                {
                    foreach ( var p in pricing.RelatedPricings)
                    {
                        p.AdjustQPFee = AdjustQpFee;
                        p.BasicPrice = BasicPrice;
                        p.PricingDate = PricingDate;
                        p.PricingQuantity = PricingQuantity;
                        p.PricingBasis = PricingBasisId;
                        p.FinalPrice = FinalPrice;
                        p.Description = Descripion;
                        p.Premium = Premium;
                        p.ExchangeRate = Rate;
                        p.PriceDate = PriceDate;
                        p.CurrencyId = SelectedCurrencyId;
                        pricingService.UpdateManualPricing(p, CurrentUser.Id, IsPricingComplete);
                    }
                }
            }

        }

        /// <summary>
        /// According to the quotaId, load the quota related info
        /// </summary>
        protected void LoadQuotaRelatedInfo()
        {
            if (QuotaId > 0)
            {
                var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc);
                var quota = quotaService.FetchById(QuotaId, new List<string> {"Contract"});

                if (quota == null)
                {
                    throw new Exception(ResPricing.QuotaNotFound);
                }

                if (quota.PricingStatus.HasValue)
                {
                    if (quota.PricingStatus.Value == (int)DBEntity.EnumEntity.PricingStatus.Complete)
                    {
                        IsPricingComplete = true;
                    }
                    else
                    {
                        IsPricingComplete = false;
                    }
                }

                QuotaNo = quota.QuotaNo;
                PricingStatus = quota.PricingStatus == null
                                    ? string.Empty
                                    : EnumHelper.GetDesByValue<PricingStatus>(quota.PricingStatus.Value);
                QuotaQuantity = quota.Quantity;
                PricedQuantity = quotaService.GetPricedQuantity(QuotaId);
                PricingBasisId = quota.PricingBasis ?? 0;
                Premium = quota.Premium;

                //if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade || quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                //{
                //    IsRateVisible = true;
                //}
                //else
                //{
                //    IsRateVisible = false;
                //}
            }
        }

        public override bool Validate()
        {
            if(QuotaId == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }

            if(PricingQuantity == null)
            {
                throw new Exception(ResPricing.PricingQtyRequired);
            }

            if(PricingDate == null)
            {
                throw new Exception(ResPricing.PricingDateRequired);
            }

            if(PricingBasisId == 0)
            {
                throw new Exception(ResPricing.PricingReferenceRequired);
            }

            if(BasicPrice == null)
            {
                throw new Exception(ResPricing.ReferencePriceRequired);
            }

            if(FinalPrice == null)
            {
                throw new Exception(ResPricing.FinalPriceRequired);
            }            

            return true;
        }

        public void LoadUnpricingInfo()
        {
            if(UnpricingId > 0)
            {
                using(var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
                {
                    var un = unpricingService.GetById(UnpricingId);
                    DeferFee = un.DeferFee;
                }
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Calculate automatically when property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "QuotaId")
            {
                LoadQuotaRelatedInfo();
            }
            else if(e.PropertyName == "UnpricingId")
            {
                LoadUnpricingInfo();
            }
            else if (e.PropertyName == "Premium" || e.PropertyName == "BasicPrice" || e.PropertyName == "AdjustQpFee" || e.PropertyName == "DeferFee")
            {
                FinalPrice = (BasicPrice ?? 0) + (Premium ?? 0) + (AdjustQpFee ?? 0) + (DeferFee ?? 0);
            }
            else if(e.PropertyName == "PricingBasisId")
            {
                if(PricingBasisId == (int) PricingBasis.LME3M || PricingBasisId == (int) PricingBasis.LMECash)
                {
                    using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                    {
                        var currency = currencyService.GetCurrencyByCode("USD");
                        SelectedCurrencyId = currency.Id;
                        CurrencyCode = currency.Name;
                    }
                }
                else if(PricingBasisId == (int) PricingBasis.SGESettlement || 
                    PricingBasisId == (int) PricingBasis.SHX || 
                    PricingBasisId == (int) PricingBasis.SHY ||
                    PricingBasisId == (int) PricingBasis.SHFE01 ||
                    PricingBasisId == (int) PricingBasis.SHFE02 ||
                    PricingBasisId == (int) PricingBasis.SHFE03 ||
                    PricingBasisId == (int) PricingBasis.SHFE04 ||
                    PricingBasisId == (int) PricingBasis.SHFE05 ||
                    PricingBasisId == (int) PricingBasis.SHFE06 ||
                    PricingBasisId == (int) PricingBasis.SHFE07 ||
                    PricingBasisId == (int) PricingBasis.SHFE08 ||
                    PricingBasisId == (int) PricingBasis.SHFE09 ||
                    PricingBasisId == (int) PricingBasis.SHFE10 ||
                    PricingBasisId == (int) PricingBasis.SHFE11 ||
                    PricingBasisId == (int) PricingBasis.SHFE12 ||
                    PricingBasisId == (int) PricingBasis.PCJ ||
                    PricingBasisId == (int) PricingBasis.NC)
                {
                    using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                    {
                        var currency = currencyService.GetCurrencyByCode("CNY");
                        SelectedCurrencyId = currency.Id;
                        CurrencyCode = currency.Name;
                    }
                }
            }
            else if(e.PropertyName == "SelectedCurrencyId")
            {
                int rmbId;
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    rmbId = currencyService.GetCurrencyByCode("CNY").Id;
                }
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    Rate = rateService.GetExchangeRate(rmbId, SelectedCurrencyId, CurrentUser.Id);
                }
            }
        }

        #endregion
    }
}
