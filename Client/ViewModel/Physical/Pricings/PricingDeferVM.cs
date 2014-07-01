using System;
using System.Collections.Generic;
using System.ComponentModel;
using Client.Base.BaseClientVM;
using Client.QuotaServiceReference;
using Client.UnpricingServiceReference;
using Client.View.Physical.Pricings;
using DBEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.Linq;

namespace Client.ViewModel.Physical.Pricings
{
    public class PricingDeferVM : BaseVM
    {
        #region Constructor

        public PricingDeferVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public PricingDeferVM(int unpricingId)
        {
            ObjectId = unpricingId;
            Initialize();
        }

        #endregion

        #region Member

        private int _parentUnpricingId;
        private int _quotaId;
        private string _quotaNo;
        private decimal? _unpricingQuantity;
        private DateTime? _endDate;
        private decimal? _deferQuantity;
        private decimal? _newDeferFee;
        private string _description;
        private DateTime? _deferDate;
        private decimal _oldDeferQty;
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

        public int ParentUnpricingId
        {
            get { return _parentUnpricingId; }
            set
            {
                if (_parentUnpricingId != value)
                {
                    _parentUnpricingId = value;
                    Notify("ParentUnpricingId");
                }
            }
        }

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

        public decimal? UnpricingQuantity
        {
            get { return _unpricingQuantity; }
            set
            {
                if (_unpricingQuantity != value)
                {
                    _unpricingQuantity = value;
                    Notify("UnpricingQuantity");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if(_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public decimal? DeferQuantity
        {
            get { return _deferQuantity; }
            set
            {
                if(_deferQuantity != value)
                {
                    _deferQuantity = value;
                    Notify("DeferQuantity");
                }
            }
        }

        public decimal? NewDeferFee
        {
            get { return _newDeferFee; }
            set
            {
                if(_newDeferFee != value)
                {
                    _newDeferFee = value;
                    Notify("NewDeferFee");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        public DateTime? DeferDate
        {
            get { return _deferDate; }
            set
            {
                if(_deferDate != value)
                {
                    _deferDate = value;
                    Notify("DeferDate");
                }
            }
        }

        #endregion

        #region Method

        protected override void Create()
        {
            var unpricing = new Unpricing
                                {
                                    QuotaId = QuotaId,
                                    UnpricingQuantity = DeferQuantity,
                                    DeferDate = DeferDate,
                                    DeferFee = NewDeferFee,
                                    EndPricingDate = EndDate,
                                    Description = Description,
                                    UnpricingId = ParentUnpricingId
                                };

            var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc);
            var parent = unpricingService.SelectById(new List<string>{"RelatedUnpricings"}, ParentUnpricingId);
            unpricing.DeferFee += parent == null ? 0 : parent.DeferFee;
            var newUn = unpricingService.DeferPricing(unpricing, CurrentUser.Id);

            if (parent.RelatedUnpricings != null)
            {
                foreach (var un in parent.RelatedUnpricings)
                {
                    unpricing.QuotaId = un.QuotaId;
                    unpricing.UnpricingId = un.Id;
                    unpricing.RelUnpricingId = newUn.Id;
                    unpricing.IsAutoGenerated = true;
                    unpricingService.DeferPricing(unpricing, CurrentUser.Id);
                }
            }
        }

        protected override void Update()
        {
            using (var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
            {
                var un = unpricingService.SelectById(new List<string>{"RelatedUnpricings"}, ObjectId);
                var parent = unpricingService.GetById(un.UnpricingId ?? 0);

                un.UnpricingQuantity = DeferQuantity;
                un.DeferDate = DeferDate;
                un.DeferFee = NewDeferFee + (parent.DeferFee ?? 0);
                un.EndPricingDate = EndDate;
                un.Description = Description;

                unpricingService.UpdateExisted(un, CurrentUser.Id);

                if (un.RelatedUnpricings != null)
                {
                    foreach (var tu in un.RelatedUnpricings)
                    {
                        tu.UnpricingQuantity = DeferQuantity;
                        tu.DeferDate = DeferDate;
                        tu.DeferFee = NewDeferFee + (parent.DeferFee ?? 0);
                        tu.EndPricingDate = EndDate;
                        tu.Description = Description;

                        unpricingService.UpdateExisted(tu, CurrentUser.Id);
                    }
                }
            }
        }

        public override bool Validate()
        {
            if(ParentUnpricingId == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }

            if(EndDate == null)
            {
                throw new Exception(ResPricing.DeferredPromptDateRequired);
            }

            if(DeferQuantity == null)
            {
                throw new Exception(ResPricing.DeferQtyRequired);
            }

            if(DeferQuantity - _oldDeferQty > UnpricingQuantity)
            {
                throw new Exception(ResPricing.DeferQtyError2);
            }

            return true;
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        public void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }


            if(ObjectId > 0)
            {
                using (var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
                {
                    var un = unpricingService.GetById(ObjectId);
                    ParentUnpricingId = un.UnpricingId ?? 0;
                    DeferQuantity = un.UnpricingQuantity;
                    _oldDeferQty = un.UnpricingQuantity ?? 0;
                    DeferDate = un.DeferDate;

                    var parent = unpricingService.GetById(un.UnpricingId ?? 0);
                    var parentDeferFee = parent == null ? 0 : parent.DeferFee;
                    NewDeferFee = (un.DeferFee ?? 0) - (parentDeferFee ?? 0);

                    QuotaId = un.QuotaId;

                    EndDate = un.EndPricingDate;
                    Description = un.Description;
                }
            }
            else
            {
                DeferDate = DateTime.Today;
                _oldDeferQty = 0;
            }
        }

        #endregion

        #region Event

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ParentUnpricingId")
            {
                if(ParentUnpricingId > 0)
                {
                    using (var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
                    {
                        var unpricing = unpricingService.FetchById(ParentUnpricingId, new List<string>{"Quota"});
                        if(unpricing == null || unpricing.Quota == null)
                        {
                            throw new Exception(ResPricing.QuotaNotFound);
                        }

                        QuotaId = unpricing.QuotaId;
                        QuotaNo = unpricing.Quota.QuotaNo;
                        UnpricingQuantity = unpricing.UnpricingQuantity;
                    }
                }
            }
        }

        #endregion
    }
}
