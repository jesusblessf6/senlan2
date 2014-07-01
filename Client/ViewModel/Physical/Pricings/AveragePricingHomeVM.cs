using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Pricings
{
    public class AveragePricingHomeVM : BaseVM
    {
        #region Member

        private AveragePricingListVM _searchVM;
        private int _businessPartnerId;
        private string _businessPartnerName;
        private List<Commodity> _commodities;
        private int _commodityId;
        private DateTime? _endDate;
        private int _internalCustomerId;
        private List<BusinessPartner> _internalCustomers;
        private int _pricingBasisId;
        private List<EnumItem> _pricingBasises;
        private int _pricingStatusId;
        private DateTime? _startDate;
        private bool _status;
        private bool _containCurrentUser = true;

        #endregion

        #region Property

        public int BusinessPartnerId
        {
            get { return _businessPartnerId; }
            set
            {
                if (_businessPartnerId != value)
                {
                    _businessPartnerId = value;
                    Notify("BusinessPartnerId");
                }
            }
        }

        public string BusinessPartnerName
        {
            get { return _businessPartnerName; }
            set
            {
                if (_businessPartnerName != value)
                {
                    _businessPartnerName = value;
                    Notify("BusinessPartnerName");
                }
            }
        }

        public int InternalCustomerId
        {
            get { return _internalCustomerId; }
            set
            {
                if (_internalCustomerId != value)
                {
                    _internalCustomerId = value;
                    Notify("InternalCustomerId");
                }
            }
        }

        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                _internalCustomers = value;
                Notify("InternalCustomers");
            }
        }

        public int CommodityId
        {
            get { return _commodityId; }
            set
            {
                if (_commodityId != value)
                {
                    _commodityId = value;
                    Notify("CommodityId");
                }
            }
        }

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
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

        public List<EnumItem> PricingBasises
        {
            get { return _pricingBasises; }
            set
            {
                _pricingBasises = value;
                Notify("PricingBasises");
            }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public AveragePricingListVM SearchVM
        {
            get { return _searchVM; }
            set
            {
                if (_searchVM != value)
                {
                    _searchVM = value;
                    Notify("SearchVM");
                }
            }
        }

        public int PricingStatusId
        {
            get { return _pricingStatusId; }
            set
            {
                if (_pricingStatusId != value)
                {
                    _pricingStatusId = value;
                    Notify("PricingStatusId");
                }
            }
        }

        public bool Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    Notify("Status");
                }
            }
        }

        public bool ContainCurrentUser
        {
            get { return _containCurrentUser; }
            set
            {
                if (_containCurrentUser != value)
                {
                    _containCurrentUser = value;
                    Notify("ContainCurrentUser");
                }
            }
        }

        #endregion

        #region Constructor

        public AveragePricingHomeVM()
        {
            //Internal Customers
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                //const string str = "it.CustomerType=@p1";
                //var parameters = new List<object> {Convert.ToInt32(BusinessPartnerType.InternalCustomer)};

                //List<BusinessPartner> ics = bpService.Select(str, parameters, null);
                List<BusinessPartner> ics = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                ics.Insert(0, new BusinessPartner {Id = 0, ShortName = string.Empty});
                _internalCustomers = ics;
                _internalCustomerId = 0;
            }

            //Commodity
            using (var comService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                List<Commodity> coms = comService.GetAll();
                coms.Insert(0, new Commodity {Id = 0, Name = string.Empty});
                _commodities = coms;
                _commodityId = 0;
            }

            //Pricing Basis
            List<EnumItem> basises = EnumHelper.GetEnumList<PricingBasis>();
            basises.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
            _pricingBasises = basises;
            _pricingBasisId = 0;
        }

        #endregion

        #region Method

        protected void LoadSearch(AveragePricingSearchConditions c)
        {
            SearchVM = new AveragePricingListVM(c);
            SearchVM.Init();
        }

        /// <summary>
        /// 重置搜索条件
        /// </summary>
        public void Clear()
        {
            BusinessPartnerId = 0;
            BusinessPartnerName = "";
            InternalCustomerId = 0;
            CommodityId = 0;
            PricingBasisId = 0;
            StartDate = null;
            EndDate = null;
        }

        public AveragePricingSearchConditions BuildCondition()
        {
            var c = new AveragePricingSearchConditions
                        {
                            BusinessPartnerId = BusinessPartnerId,
                            InternalCustomerId = InternalCustomerId,
                            CommodityId = CommodityId,
                            PricingBasisId = PricingBasisId,
                            StartDate = StartDate,
                            EndDate = EndDate,
                            PricingStatusId = Convert.ToInt32(PricingStatus.Partial),
                            Status = true,
                            ContainCurrentUser = ContainCurrentUser
                        };
            return c;
        }

        public AveragePricingSearchConditions CompleteNotAtAllBuildCondition(int pricingStatusId)
        {
            var c = new AveragePricingSearchConditions
                        {
                            BusinessPartnerId = 0,
                            InternalCustomerId = 0,
                            CommodityId = 0,
                            PricingBasisId = 0,
                            StartDate = null,
                            EndDate = null,
                            PricingStatusId = pricingStatusId,
                            Status = false
                        };
            return c;
        }

        public AveragePricingSearchConditions ThisMonthBuildCondition()
        {
            var c = new AveragePricingSearchConditions
                        {
                            BusinessPartnerId = 0,
                            InternalCustomerId = 0,
                            CommodityId = 0,
                            PricingBasisId = 0,
                            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), //当月的第一天
                            EndDate = null,
                            PricingStatusId = Convert.ToInt32(PricingStatus.Partial),
                            Status = true
                        };
            return c;
        }

        #endregion
    }

    public class AveragePricingSearchConditions
    {
        public int BusinessPartnerId { get; set; }
        public int InternalCustomerId { get; set; }
        public int CommodityId { get; set; }
        public int PricingBasisId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PricingStatusId { get; set; }
        public bool Status { get; set; }
        public bool ContainCurrentUser { get; set; }
    }
}