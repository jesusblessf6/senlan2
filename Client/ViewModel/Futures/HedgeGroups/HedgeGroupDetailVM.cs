using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.ContractUDFServiceReference;
using Client.HedgeGroupServiceReference;
using Client.LMEPositionServiceReference;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.SHFEPositionServiceReference;
using Client.View.Futures.HedgeGroups;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Futures.HedgeGroups
{
    public class HedgeGroupDetailVM : ObjectBaseVM
    {
        #region Member

        #region Header
        private string _hedgeGroupName;
        private DateTime? _hedgeGroupDate;
        private decimal? _rate;
        private List<EnumItem> _arbitrageTypes;
        private int _selectedArbitrageTypeId;
        #endregion

        #region Added Quotas and Positions
        private List<HedgeLineQuota> _addedQuotas;
        private string _quotaPLStr;
        private string _quotaFixedPLStr;
        private decimal _quotaFixedPL;
        private string _quotaFloatPLStr;
        private decimal _quotaFloatPL;
        private List<HedgeLineLMEPosition> _addedLMEPositions;
        private string _lmePLStr;
        private string _lmeFixedPLStr;
        private decimal _lmeFixedPL;
        private string _lmeFloatPLStr;
        private decimal _lmeFloatPL;
        private List<HedgeLineSHFEPosition> _addedSHFEPositions;
        private string _shfePLStr;
        private string _shfeFixedPLStr;
        private decimal _shfeFixedPL;
        private string _shfeFloatPLStr;
        private decimal _shfeFloatPL;
        private decimal? _totalPL;
        private string _totalPLStr;
        #endregion

        #region Quotas
        private int _quotaBPId;
        private string _quotaBPName;
        private int _quotaInternalCustomerId;
        private DateTime? _quotaStartDate;
        private DateTime? _quotaEndDate;
        private int _quotaCommodityId;
        private List<Quota> _quotas;
        private List<ContractUDF> _udfTypes;
        private int _selectedUDFTypeId;
        #endregion

        #region LMEPosition
        private int _lmePositionInternalCustomerId;
        private int _lmePositionCommodityId;
        private int _lmePositionDirectionId;
        private int _lmePositionBrokerId;
        private DateTime? _lmePositionStartDate;
        private DateTime? _lmePositionEndDate;
        private List<LMEPosition> _lmePositions;
        private int _lmePositionTypeId;
        #endregion

        #region SHFEPosition
        private int _shfePositionInternalCustomerId;
        private int _shfePositionCommodityId;
        private int _shfePositionDirectionId;
        private int _shfePositionBrokerId;
        private DateTime? _shfePositionStartDate;
        private DateTime? _shfePositionEndDate;
        private List<SHFEPosition> _shfePositions;
        private int _shfePositionTypeId;
        #endregion

        #region Common Conditions
        private List<BusinessPartner> _internalCustomers;
        private List<Commodity> _commodities;
        private List<EnumItem> _directions;
        private List<BusinessPartner> _brokers;
        private List<EnumItem> _positionTypes;
        #endregion

        #region Average Price

        private decimal? _quotaBuyAvg;
        private decimal? _quotaSellAvg;
        private decimal? _lmeBuyAvg;
        private decimal? _lmeSellAvg;
        private decimal? _shfeSellOpenAvg;
        private decimal? _shfeSellCloseAvg;
        private decimal? _shfeBuyOpenAvg;
        private decimal? _shfeBuyCloseAvg;

        #endregion
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
        #region Header
        public string HedgeGroupName
        {
            get { return _hedgeGroupName; }
            set
            {
                if (_hedgeGroupName != value)
                {
                    _hedgeGroupName = value;
                    Notify("HedgeGroupName");
                }
            }
        }

        public DateTime? HedgeGroupDate
        {
            get { return _hedgeGroupDate; }
            set
            {
                if (_hedgeGroupDate != value)
                {
                    _hedgeGroupDate = value;
                    Notify("HedgeGroupDate");
                }
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

        public List<EnumItem> ArbitrageTypes
        {
            get { return _arbitrageTypes; }
            set
            {
                _arbitrageTypes = value;
                Notify("ArbitrageTypes");
            }
        }

        public int SelectedArbitrageTypeId
        {
            get { return _selectedArbitrageTypeId; }
            set
            {
                if (_selectedArbitrageTypeId != value)
                {
                    _selectedArbitrageTypeId = value;
                    Notify("SelectedArbitrageTypeId");
                }
            }
        }

        public IPLCalculationMethod Calculator { get; set; }
        #endregion

        #region Added Quotas and Positions
        public List<HedgeLineQuota> AddedQuotas
        {
            get { return _addedQuotas; }
            set
            {
                _addedQuotas = value;
                Notify("AddedQuotas");
            }
        }

        public string QuotaPLStr
        {
            get { return _quotaPLStr; }
            set
            {
                if (_quotaPLStr != value)
                {
                    _quotaPLStr = value;
                    Notify("QuotaPLStr");
                }
            }
        }

        public List<HedgeLineLMEPosition> AddedLMEPositions
        {
            get { return _addedLMEPositions; }
            set
            {
                _addedLMEPositions = value;
                Notify("AddedLMEPositions");
            }
        }

        public string LMEPLStr
        {
            get { return _lmePLStr; }
            set
            {
                if (_lmePLStr != value)
                {
                    _lmePLStr = value;
                    Notify("LMEPLStr");
                }
            }
        }

        public List<HedgeLineSHFEPosition> AddedSHFEPositions
        {
            get { return _addedSHFEPositions; }
            set
            {
                _addedSHFEPositions = value;
                Notify("AddedSHFEPositions");
            }
        }

        public string SHFEPLStr
        {
            get { return _shfePLStr; }
            set
            {
                if (_shfePLStr != value)
                {
                    _shfePLStr = value;
                    Notify("SHFEPLStr");
                }
            }
        }



        public string TotalPLStr
        {
            get { return _totalPLStr; }
            set
            {
                if (_totalPLStr != value)
                {
                    _totalPLStr = value;
                    Notify("TotalPLStr");
                }
            }
        }

        public string QuotaFixedPLStr
        {
            get { return _quotaFixedPLStr; }
            set
            {
                if (_quotaFixedPLStr != value)
                {
                    _quotaFixedPLStr = value;
                    Notify("QuotaFixedPLStr");
                }
            }
        }

        public decimal QuotaFixedPL
        {
            get { return _quotaFixedPL; }
            set
            {
                if (_quotaFixedPL != value)
                {
                    _quotaFixedPL = value;
                    Notify("QuotaFixedPL");
                }
            }
        }

        public string QuotaFloatPLStr
        {
            get { return _quotaFloatPLStr; }
            set
            {
                if (_quotaFloatPLStr != value)
                {
                    _quotaFloatPLStr = value;
                    Notify("QuotaFloatPLStr");
                }
            }
        }

        public decimal QuotaFloatPL
        {
            get { return _quotaFloatPL; }
            set
            {
                if (_quotaFloatPL != value)
                {
                    _quotaFloatPL = value;
                    Notify("QuotaFloatPL");
                }
            }
        }

        public string LMEFloatPLStr
        {
            get { return _lmeFloatPLStr; }
            set
            {
                if (_lmeFloatPLStr != value)
                {
                    _lmeFloatPLStr = value;
                    Notify("LMEFloatPLStr");
                }
            }
        }

        public decimal LMEFloatPL
        {
            get { return _lmeFloatPL; }
            set
            {
                if (_lmeFloatPL != value)
                {
                    _lmeFloatPL = value;
                    Notify("LMEFloatPL");
                }
            }
        }

        public string LMEFixedPLStr
        {
            get { return _lmeFixedPLStr; }
            set
            {
                if (_lmeFixedPLStr != value)
                {
                    _lmeFixedPLStr = value;
                    Notify("LMEFixedPLStr");
                }
            }
        }

        public decimal LMEFixedPL
        {
            get { return _lmeFixedPL; }
            set
            {
                if (_lmeFixedPL != value)
                {
                    _lmeFixedPL = value;
                    Notify("LMEFixedPL");
                }
            }
        }

        public string SHFEFixedPLStr
        {
            get { return _shfeFixedPLStr; }
            set
            {
                if (_shfeFixedPLStr != value)
                {
                    _shfeFixedPLStr = value;
                    Notify("SHFEFixedPLStr");
                }
            }
        }

        public decimal SHFEFixedPL
        {
            get { return _shfeFixedPL; }
            set
            {
                if (_shfeFixedPL != value)
                {
                    _shfeFixedPL = value;
                    Notify("SHFEFixedPL");
                }
            }
        }

        public string SHFEFloatPLStr
        {
            get { return _shfeFloatPLStr; }
            set
            {
                if (_shfeFloatPLStr != value)
                {
                    _shfeFloatPLStr = value;
                    Notify("SHFEFloatPLStr");
                }
            }
        }

        public decimal SHFEFloatPL
        {
            get { return _shfeFloatPL; }
            set
            {
                if (_shfeFloatPL != value)
                {
                    _shfeFloatPL = value;
                    Notify("SHFEFloatPLStr");
                }
            }
        }

        public int UserId { get; set; }

        #endregion

        #region Quotas
        public int QuotaFrom { get; set; }
        public int QuotaTo { get; set; }
        public int QuotaCount { get; set; }
        public List<HedgeLineQuota> NewQuotas { get; set; } // 新增的批次
        public List<HedgeLineQuota> DeletedQuotas { get; set; } //移除的批次

        public int QuotaBPId
        {
            get { return _quotaBPId; }
            set
            {
                if (_quotaBPId != value)
                {
                    _quotaBPId = value;
                    Notify("QuotaBPId");
                }
            }
        }

        public string QuotaBPName
        {
            get { return _quotaBPName; }
            set
            {
                if (_quotaBPName != value)
                {
                    _quotaBPName = value;
                    Notify("QuotaBPName");
                }
            }
        }

        public int QuotaInternalCustomerId
        {
            get { return _quotaInternalCustomerId; }
            set
            {
                if (_quotaInternalCustomerId != value)
                {
                    _quotaInternalCustomerId = value;
                    Notify("QuotaInternalCustomerId");
                }
            }
        }

        public DateTime? QuotaStartDate
        {
            get { return _quotaStartDate; }
            set
            {
                if (_quotaStartDate != value)
                {
                    _quotaStartDate = value;
                    Notify("QuotaStartDate");
                }
            }
        }

        public DateTime? QuotaEndDate
        {
            get { return _quotaEndDate; }
            set
            {
                if (_quotaEndDate != value)
                {
                    _quotaEndDate = value;
                    Notify("QuotaEndDate");
                }
            }
        }

        public int QuotaCommodityId
        {
            get { return _quotaCommodityId; }
            set
            {
                if (_quotaCommodityId != value)
                {
                    _quotaCommodityId = value;
                    Notify("QuotaCommodityId");
                }
            }
        }

        public List<Quota> Quotas
        {
            get { return _quotas; }
            set
            {
                _quotas = value;
                Notify("Quotas");
            }
        }

        public List<ContractUDF> UDFTypes
        {
            get { return _udfTypes; }
            set
            {
                _udfTypes = value;
                Notify("UDFTypes");
            }
        }

        public int SelectedUDFTypeId
        {
            get { return _selectedUDFTypeId; }
            set
            {
                if (_selectedUDFTypeId != value)
                {
                    _selectedUDFTypeId = value;
                    Notify("SelectedUDFTypeId");
                }
            }
        }

        #endregion

        #region LMEPositions
        public int LMEPositionFrom { get; set; }
        public int LMEPositionTo { get; set; }
        public int LMEPositionCount { get; set; }
        public List<HedgeLineLMEPosition> NewLMEPositions { get; set; }  //新增的LME头寸
        public List<HedgeLineLMEPosition> DeletedLMEPositions { get; set; }  //删除的LME头寸

        public int LMEPositionInternalCustomerId
        {
            get { return _lmePositionInternalCustomerId; }
            set
            {
                if (_lmePositionInternalCustomerId != value)
                {
                    _lmePositionInternalCustomerId = value;
                    Notify("LMEPositionInternalCustomerId");
                }
            }
        }

        public int LMEPositionCommodityId
        {
            get { return _lmePositionCommodityId; }
            set
            {
                if (_lmePositionCommodityId != value)
                {
                    _lmePositionCommodityId = value;
                    Notify("LMEPositionCommodityId");
                }
            }
        }

        public int LMEPositionDirectionId
        {
            get { return _lmePositionDirectionId; }
            set
            {
                if (_lmePositionDirectionId != value)
                {
                    _lmePositionDirectionId = value;
                    Notify("LMEPositionDirectionId");
                }
            }
        }

        public int LMEPositionBrokerId
        {
            get { return _lmePositionBrokerId; }
            set
            {
                if (_lmePositionBrokerId != value)
                {
                    _lmePositionBrokerId = value;
                    Notify("LMEPositionBrokerId");
                }
            }
        }

        public DateTime? LMEPositionStartDate
        {
            get { return _lmePositionStartDate; }
            set
            {
                if (_lmePositionStartDate != value)
                {
                    _lmePositionStartDate = value;
                    Notify("LMEPositionStartDate");
                }

            }
        }

        public DateTime? LMEPositionEndDate
        {
            get { return _lmePositionEndDate; }
            set
            {
                if (_lmePositionEndDate != value)
                {
                    _lmePositionEndDate = value;
                    Notify("LMEPositionEndDate");
                }
            }
        }

        public List<LMEPosition> LMEPositions
        {
            get { return _lmePositions; }
            set
            {
                _lmePositions = value;
                Notify("LMEPositions");
            }
        }

        public int LMEPositionTypeId
        {
            get { return _lmePositionTypeId; }
            set
            {
                if (_lmePositionTypeId != value)
                {
                    _lmePositionTypeId = value;
                    Notify("LMEPositionTypeId");
                }
            }
        }
        #endregion

        #region SHFEPosition
        public int SHFEPositionFrom { get; set; }
        public int SHFEPositionTo { get; set; }
        public int SHFEPositionCount { get; set; }
        public List<HedgeLineSHFEPosition> NewSHFEPositions { get; set; }  //新增的SHFE头寸
        public List<HedgeLineSHFEPosition> DeletedSHFEPositions { get; set; }  //移除的SHFE头寸

        public int SHFEPositionInternalCustomerId
        {
            get { return _shfePositionInternalCustomerId; }
            set
            {
                if (_shfePositionInternalCustomerId != value)
                {
                    _shfePositionInternalCustomerId = value;
                    Notify("SHFEPositionInternalCustomerId");
                }
            }
        }

        public int SHFEPositionCommodityId
        {
            get { return _shfePositionCommodityId; }
            set
            {
                if (_shfePositionCommodityId != value)
                {
                    _shfePositionCommodityId = value;
                    Notify("SHFEPositionCommodityId");
                }
            }
        }

        public int SHFEPositionDirectionId
        {
            get { return _shfePositionDirectionId; }
            set
            {
                if (_shfePositionDirectionId != value)
                {
                    _shfePositionDirectionId = value;
                    Notify("SHFEPositionDirectionId");
                }
            }
        }

        public int SHFEPositionBrokerId
        {
            get { return _shfePositionBrokerId; }
            set
            {
                if (_shfePositionBrokerId != value)
                {
                    _shfePositionBrokerId = value;
                    Notify("SHFEPositionBrokerId");
                }
            }
        }

        public DateTime? SHFEPositionStartDate
        {
            get { return _shfePositionStartDate; }
            set
            {
                if (_shfePositionStartDate != value)
                {
                    _shfePositionStartDate = value;
                    Notify("SHFEPositionStartDate");
                }
            }
        }

        public DateTime? SHFEPositionEndDate
        {
            get { return _shfePositionEndDate; }
            set
            {
                if (_shfePositionEndDate != value)
                {
                    _shfePositionEndDate = value;
                    Notify("SHFEPositionEndDate");
                }
            }
        }

        public List<SHFEPosition> SHFEPositions
        {
            get { return _shfePositions; }
            set
            {
                _shfePositions = value;
                Notify("SHFEPositions");
            }
        }

        public int SHFEPositionTypeId
        {
            get { return _shfePositionTypeId; }
            set
            {
                if (_shfePositionTypeId != value)
                {
                    _shfePositionTypeId = value;
                    Notify("SHFEPositionTypeId");
                }
            }
        }
        #endregion

        #region Common Conditions
        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                _internalCustomers = value;
                Notify("InternalCustomers");
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

        public List<EnumItem> Directions
        {
            get { return _directions; }
            set
            {
                _directions = value;
                Notify("Directions");
            }
        }

        public List<BusinessPartner> Brokers
        {
            get { return _brokers; }
            set
            {
                _brokers = value;
                Notify("Brokers");
            }
        }

        public List<EnumItem> PositionTypes
        {
            get { return _positionTypes; }
            set
            {
                _positionTypes = value;
                Notify("PositionTypes");
            }
        }

        #endregion

        #region Average Price

        public decimal? QuotaBuyAvg
        {
            get { return _quotaBuyAvg; }
            set
            {
                if (_quotaBuyAvg != value)
                {
                    _quotaBuyAvg = value;
                    Notify("QuotaBuyAvg");
                }
            }
        }

        public decimal? QuotaSellAvg
        {
            get { return _quotaSellAvg; }
            set
            {
                if (_quotaSellAvg != value)
                {
                    _quotaSellAvg = value;
                    Notify("QuotaSellAvg");
                }
            }
        }

        public decimal? LMEBuyAvg
        {
            get { return _lmeBuyAvg; }
            set
            {
                if (_lmeBuyAvg != value)
                {
                    _lmeBuyAvg = value;
                    Notify("LMEBuyAvg");
                }
            }
        }

        public decimal? LMESellAvg
        {
            get { return _lmeSellAvg; }
            set
            {
                if (_lmeSellAvg != value)
                {
                    _lmeSellAvg = value;
                    Notify("LMESellAvg");
                }
            }
        }

        public decimal? SHFESellOpenAvg
        {
            get { return _shfeSellOpenAvg; }
            set
            {
                if (_shfeSellOpenAvg != value)
                {
                    _shfeSellOpenAvg = value;
                    Notify("SHFESellOpenAvg");
                }
            }
        }

        public decimal? SHFESellCloseAvg
        {
            get { return _shfeSellCloseAvg; }
            set
            {
                if (_shfeSellCloseAvg != value)
                {
                    _shfeSellCloseAvg = value;
                    Notify("SHFESellCloseAvg");
                }
            }
        }

        public decimal? SHFEBuyOpenAvg
        {
            get { return _shfeBuyOpenAvg; }
            set
            {
                if (_shfeBuyOpenAvg != value)
                {
                    _shfeBuyOpenAvg = value;
                    Notify("SHFEBuyOpenAvg");
                }
            }
        }

        public decimal? SHFEBuyCloseAvg
        {
            get { return _shfeBuyCloseAvg; }
            set
            {
                if (_shfeBuyCloseAvg != value)
                {
                    _shfeBuyCloseAvg = value;
                    Notify("SHFEBuyCloseAvg");
                }
            }
        }

        #endregion

        #region Currencies

        public string TotalPLCurrency { get; set; }
        public string QuotaPLCurrency { get; set; }
        public string LMEPLCurrency { get; set; }
        public string SHFEPLCurrency { get; set; }

        #endregion

        #endregion

        #region Constructor

        public HedgeGroupDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public HedgeGroupDetailVM(int id)
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
            //Calculator = new Method4ChinaCopper();
            Calculator = new GeneralCalculationMethod();
            //init internal customers and brokers
            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());

                _brokers = bpService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner());
            }

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }

            //init Commodities
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }

            //init directions
            _directions = EnumHelper.GetEnumList<PositionDirection>();
            _directions.Insert(0, new EnumItem());

            //init position types
            _positionTypes = EnumHelper.GetEnumList<PositionType>();
            _positionTypes.Insert(0, new EnumItem());

            //init UDFTypes
            using (var udfService = SvcClientManager.GetSvcClient<ContractUDFServiceClient>(SvcType.ContractUDFSvc))
            {
                _udfTypes = udfService.GetAll();
                _udfTypes.Insert(0, new ContractUDF());
            }

            //Init ArbitrageTypes
            _arbitrageTypes = EnumHelper.GetEnumList<ArbitrageType>();
            _selectedArbitrageTypeId = (int)ArbitrageType.Common;

            NewQuotas = new List<HedgeLineQuota>();
            DeletedQuotas = new List<HedgeLineQuota>();
            NewLMEPositions = new List<HedgeLineLMEPosition>();
            DeletedLMEPositions = new List<HedgeLineLMEPosition>();
            NewSHFEPositions = new List<HedgeLineSHFEPosition>();
            DeletedSHFEPositions = new List<HedgeLineSHFEPosition>();
            Quotas = new List<Quota>();
            LMEPositions = new List<LMEPosition>();
            SHFEPositions = new List<SHFEPosition>();
            AddedQuotas = new List<HedgeLineQuota>();
            AddedLMEPositions = new List<HedgeLineLMEPosition>();
            AddedSHFEPositions = new List<HedgeLineSHFEPosition>();

            if (ObjectId > 0)
            {
                using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
                {
                    var hg = hgService.FetchById(ObjectId, new List<string> { "PLCurrency" });
                    _hedgeGroupName = hg.Name;
                    _hedgeGroupDate = hg.HedgeDate;

                    _rate = hg.Rate;
                    _selectedArbitrageTypeId = hg.ArbitrageType;



                    _addedQuotas = hgService.GetQuotasInHedgeGroup(ObjectId,
                                                                   new List<string>
                                                                       {
                                                                           "Quota",
                                                                           "Quota.Contract",
                                                                           "Quota.Commodity",
                                                                           "Quota.Contract.BusinessPartner",
                                                                           "Quota.Pricings",
                                                                           "Quota.Pricings.Currency",
                                                                           "Quota.Currency"
                                                                       });
                    foreach (var quota in _addedQuotas)
                    {
                        EntityUtil.FilterDeletedEntity(quota.Quota.Pricings);
                        quota.Quota.PricedQuantity = (decimal)quota.Quota.Pricings.Sum(o => o.PricingQuantity);

                        if (quota.Quota.PricedQuantity == 0)
                        {
                            quota.Quota.AveragePrice = null;
                        }
                        else
                        {
                            quota.Quota.AveragePrice = quota.Quota.Pricings.Sum(o => o.PricingQuantity * o.FinalPrice) /
                                                       quota.Quota.PricedQuantity;
                        }

                        quota.Quota.ActualQuantity = quota.Quota.VerifiedQuantity;
                    }

                    _addedLMEPositions = hgService.GetLMEsInHedgeGroup(ObjectId,
                                                                       new List<string>
                                                                           {
                                                                               "LMEPosition",
                                                                               "LMEPosition.Commodity",
                                                                               "LMEPosition.Agent"
                                                                           });
                    _addedSHFEPositions = hgService.GetSHFEsInHedgeGroup(ObjectId,
                                                                         new List<string>
                                                                             {
                                                                                 "SHFEPosition",
                                                                                 "SHFEPosition.SHFECapitalDetail",
                                                                                 "SHFEPosition.Commodity",
                                                                                 "SHFEPosition.SHFE"
                                                                             });
                    SetCurrencies();
                    if (hg.Status == (int)HedgeGroupStatus.Settled)
                    {
                        _totalPL = hg.PLAmount;
                        QuotaFixedPLStr = hg.PhyFixedPL.HasValue ? hg.PhyFixedPL.Value.ToString("N2") + " CNY" : "";
                        SHFEPLStr = hg.SHFEFixedPL.HasValue ? hg.SHFEFixedPL.Value.ToString("N2") + " " + SHFEPLCurrency : "";
                        LMEPLStr = hg.LMEFixedPL.HasValue ? hg.LMEFixedPL.Value.ToString("N2") + " " + LMEPLCurrency : "";
                        _totalPLStr = (_totalPL ?? 0).ToString("N2") + " " + "CNY";
                    }
                }
            }
            else
            {
                _hedgeGroupDate = DateTime.Today;
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    _rate = rateService.GetExchangeRateByCode("USD", "CNY");
                }
            }
        }

        /// <summary>
        /// Reset the search conditions of quota
        /// </summary>
        public void ResetQuotaConditions()
        {
            QuotaBPId = 0;
            QuotaBPName = string.Empty;
            QuotaInternalCustomerId = 0;
            QuotaStartDate = null;
            QuotaEndDate = null;
            QuotaCommodityId = 0;
            SelectedUDFTypeId = 0;
        }

        /// <summary>
        /// Reset the search conditions of LME position
        /// </summary>
        public void ResetLMEPositionConditions()
        {
            LMEPositionCommodityId = 0;
            LMEPositionInternalCustomerId = 0;
            LMEPositionStartDate = null;
            LMEPositionEndDate = null;
            LMEPositionDirectionId = 0;
            LMEPositionBrokerId = 0;
            LMEPositionTypeId = 0;
        }

        /// <summary>
        /// Reset the search conditions of SHFE position
        /// </summary>
        public void ResetSHFEPositionConditions()
        {
            SHFEPositionCommodityId = 0;
            SHFEPositionInternalCustomerId = 0;
            SHFEPositionStartDate = null;
            SHFEPositionEndDate = null;
            SHFEPositionDirectionId = 0;
            SHFEPositionBrokerId = 0;
            SHFEPositionTypeId = 0;
        }

        /// <summary>
        /// Override the create function in basevm
        /// </summary>
        protected override void Create()
        {
            CheckSaveLogic();
            var hg = new HedgeGroup { Name = HedgeGroupName, HedgeDate = HedgeGroupDate, Rate = Rate, Status = (int)HedgeGroupStatus.NotSettled, ArbitrageType = SelectedArbitrageTypeId };
            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                hgService.CreateHedgeGroup(hg, AddedQuotas, AddedLMEPositions, AddedSHFEPositions, CurrentUser.Id);
            }
        }

        /// <summary>
        /// Override the validate function in basevm
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(HedgeGroupName))
            {
                throw new Exception(ResHedgeGroup.HedgeNameNotNull);
            }

            if (Rate == null)
            {
                throw new Exception(ResHedgeGroup.RateRequired);
            }

            return true;
        }

        /// <summary>
        /// Override the update function in basevm
        /// </summary>
        protected override void Update()
        {
            CheckSaveLogic();
            var hg = new HedgeGroup { Id = ObjectId, Name = HedgeGroupName, HedgeDate = HedgeGroupDate, Rate = Rate, Status = (int)HedgeGroupStatus.NotSettled, PLAmount = null, PLCurrencyId = null, ArbitrageType = SelectedArbitrageTypeId };

            List<int> newLmeIds = NewLMEPositions.Select(o => o.LMEPositionId).ToList();
            var updatedLmes = AddedLMEPositions.Where(o => !newLmeIds.Contains(o.LMEPositionId)).ToList();

            List<int> newShfeIds = NewSHFEPositions.Select(o => o.SHFEPositionId).ToList();
            var updatedShfes = AddedSHFEPositions.Where(o => !newShfeIds.Contains(o.SHFEPositionId)).ToList();

            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                hgService.UpdateHedgeGroup(hg, NewQuotas, DeletedQuotas, updatedLmes, NewLMEPositions,
                                           DeletedLMEPositions, updatedShfes, NewSHFEPositions, DeletedSHFEPositions,
                                           CurrentUser.Id);
            }
        }

        /// <summary>
        /// Get the count of the quotas
        /// </summary>
        public void LoadQuotaCount()
        {
            string condition;
            List<object> parameters;
            BuildQuotaCondition(out condition, out parameters);
            var includes = new List<string> { "Contract" };

            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                QuotaCount = quotaService.FetchCount(condition, parameters, includes);
            }
        }

        /// <summary>
        /// Get the count of the LME positions
        /// </summary>
        public void LoadLMEPositionCount()
        {
            string condition;
            List<object> parameters;
            BuildLMEPositionCondition(out condition, out parameters);

            using (var lmeService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
            {
                LMEPositionCount = lmeService.GetCount(condition, parameters);
            }
        }

        /// <summary>
        /// Get the count of the SHFE positions
        /// </summary>
        public void LoadSHFEPositionCount()
        {
            string condition;
            List<object> parameters;
            BuildSHFEPositionCondition(out condition, out parameters);
            var includes = new List<string> { "SHFECapitalDetail" };

            using (var shfeService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                SHFEPositionCount = shfeService.FetchCount(condition, parameters, includes);
            }
        }

        /// <summary>
        /// Load the quotas of current page
        /// </summary>
        public void LoadQuotas()
        {
            Quotas.Clear();
            if (QuotaCount > 0)
            {
                string condition;
                List<object> parameters;
                BuildQuotaCondition(out condition, out parameters);
                var includes = new List<string> { "Contract", "Contract.BusinessPartner", "Commodity", "Pricings", "Currency", "Contract.ContractUDF" };

                var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc);
                List<Quota> quotas = quotaService.SelectByRangeWithOrder(condition, parameters, new SortCol { ByDescending = false, ColName = "Id" }, QuotaFrom, QuotaTo, includes);

                foreach (var quota in quotas)
                {
                    FilterDeleted(quota.Pricings);
                    quota.PricedQuantity = (decimal)quota.Pricings.Sum(o => o.PricingQuantity);
                    if (quota.PricedQuantity == 0)
                    {
                        quota.AveragePrice = null;
                    }
                    else
                    {
                        quota.AveragePrice = quota.Pricings.Sum(o => o.PricingQuantity * o.FinalPrice) /
                                             quota.PricedQuantity;
                    }

                    quota.AvailableQuantityForHedge = quota.Quantity ?? 0;
                    //quota.ActualQuantity = quotaService.GetVerifiedQuantity(quota.Id, CurrentUser.Id);
                    quota.ActualQuantity = quota.VerifiedQuantity;

                    var q = NewQuotas.FirstOrDefault(o => o.QuotaId == quota.Id);
                    if (q != null)
                    {
                        quota.AvailableQuantityForHedge = 0;
                    }
                }

                Quotas = quotas;
            }
        }

        /// <summary>
        /// Load the LME Positions of current page
        /// </summary>
        public void LoadLMEPositions()
        {
            LMEPositions.Clear();
            if (LMEPositionCount > 0)
            {
                string condition;
                List<object> parameters;
                BuildLMEPositionCondition(out condition, out parameters);
                var includes = new List<string> { "Agent", "Commodity" };

                using (var lmeService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
                {
                    LMEPositions = lmeService.SelectByRangeWithOrder(condition, parameters, new SortCol { ByDescending = false, ColName = "Id" }, LMEPositionFrom, LMEPositionTo, includes);
                    foreach (var p in LMEPositions)
                    {
                        if (p.HedgedLotQuantity == null)
                        {
                            p.AvailableLotForHedge = p.LotAmount ?? 0;
                        }
                        else
                        {
                            p.AvailableLotForHedge = (p.LotAmount ?? 0) - (decimal)p.HedgedLotQuantity;
                        }

                        var tmpP = NewLMEPositions.FirstOrDefault(o => o.LMEPositionId == p.Id);
                        if (tmpP != null)
                        {
                            p.AvailableLotForHedge -= tmpP.AssignedLotAmount;
                        }

                        tmpP = DeletedLMEPositions.FirstOrDefault(o => o.LMEPositionId == p.Id);
                        if (tmpP != null)
                        {
                            p.AvailableLotForHedge += tmpP.AssignedLotAmount;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Load the SHFE Positions of current page
        /// </summary>
        public void LoadSHFEPositions()
        {
            SHFEPositions.Clear();
            if (SHFEPositionCount > 0)
            {
                string condition;
                List<object> parameters;
                BuildSHFEPositionCondition(out condition, out parameters);
                var includes = new List<string> { "SHFECapitalDetail", "Commodity", "SHFECapitalDetail.BusinessPartner" };

                using (var shfeService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
                {
                    SHFEPositions = shfeService.SelectByRangeWithOrder(condition, parameters, new SortCol { ByDescending = false, ColName = "Id" }, SHFEPositionFrom, SHFEPositionTo, includes);
                    foreach (var p in SHFEPositions)
                    {
                        if (p.HedgedLotQuantity == null)
                        {
                            p.AvailableLotForHedge = p.LotQuantity ?? 0;
                        }
                        else
                        {
                            p.AvailableLotForHedge = (p.LotQuantity ?? 0) - (decimal)p.HedgedLotQuantity;
                        }

                        var tmpP = NewSHFEPositions.FirstOrDefault(o => o.SHFEPositionId == p.Id);
                        if (tmpP != null)
                        {
                            p.AvailableLotForHedge -= tmpP.AssignedLotAmount;
                        }

                        tmpP = DeletedSHFEPositions.FirstOrDefault(o => o.SHFEPositionId == p.Id);
                        if (tmpP != null)
                        {
                            p.AvailableLotForHedge += tmpP.AssignedLotAmount;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Build up the condition of quota
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="parameters"></param>
        private void BuildQuotaCondition(out string condition, out List<object> parameters)
        {
            parameters = new List<object>();

            var sb = new StringBuilder("it.IsHedged = false");
            int i = 1;
            if (QuotaBPId > 0)
            {
                sb.AppendFormat(" and it.Contract.BPId = @p{0}", i++);
                parameters.Add(QuotaBPId);
            }

            if (IdList != null && IdList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.Contract.InternalCustomerId= @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Contract.InternalCustomerId = @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                }
                sb.Append(")");
            }

            if (QuotaInternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.Contract.InternalCustomerId = @p{0}", i++);
                parameters.Add(QuotaInternalCustomerId);
            }

            if (QuotaStartDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate >= @p{0}", i++);
                parameters.Add(QuotaStartDate);
            }

            if (QuotaEndDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate <= @p{0}", i++);
                parameters.Add(QuotaEndDate);
            }

            if (QuotaCommodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i++);
                parameters.Add(QuotaCommodityId);
            }

            if (SelectedUDFTypeId > 0)
            {
                sb.AppendFormat(" and it.Contract.UDFId = @p{0}", i);
                parameters.Add(SelectedUDFTypeId);
            }

            condition = sb.ToString();
        }

        /// <summary>
        /// Build up the condition of LME Position
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="parameters"></param>
        private void BuildLMEPositionCondition(out string condition, out List<object> parameters)
        {
            var sb = new StringBuilder("(it.HedgedLotQuantity is null or (it.HedgedLotQuantity is not null and it.LotAmount > it.HedgedLotQuantity))");
            parameters = new List<object>();

            int i = 1;
            if (LMEPositionCommodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i++);
                parameters.Add(LMEPositionCommodityId);
            }

            if (LMEPositionInternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.InternalBPId = @p{0}", i++);
                parameters.Add(LMEPositionInternalCustomerId);
            }

            if (IdList != null && IdList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.InternalBPId = @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.InternalBPId = @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                }
                sb.Append(")");
            }

            if (LMEPositionStartDate != null)
            {
                sb.AppendFormat(" and it.PromptDate >= @p{0}", i++);
                parameters.Add(LMEPositionStartDate);
            }

            if (LMEPositionEndDate != null)
            {
                sb.AppendFormat(" and it.PromptDate <= @p{0}", i++);
                parameters.Add(LMEPositionEndDate);
            }

            if (LMEPositionDirectionId > 0)
            {
                sb.AppendFormat(" and it.TradeDirection = @p{0}", i++);
                parameters.Add(LMEPositionDirectionId);
            }

            if (LMEPositionBrokerId > 0)
            {
                sb.AppendFormat(" and it.AgentId = @p{0}", i++);
                parameters.Add(LMEPositionBrokerId);
            }

            if (LMEPositionTypeId > 0)
            {
                sb.AppendFormat(" and it.PositionType = @p{0}", i);
                parameters.Add(LMEPositionTypeId);
            }

            condition = sb.ToString();
        }

        /// <summary>
        /// Build up the condition of SHFE Position
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="parameters"></param>
        private void BuildSHFEPositionCondition(out string condition, out List<object> parameters)
        {
            var sb = new StringBuilder("(it.HedgedLotQuantity is null or (it.HedgedLotQuantity is not null and it.LotQuantity > it.HedgedLotQuantity))");
            parameters = new List<object>();
            int i = 1;

            if (SHFEPositionCommodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i++);
                parameters.Add(SHFEPositionCommodityId);
            }

            if (SHFEPositionInternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.SHFECapitalDetail.InternalBPId = @p{0}", i++);
                parameters.Add(SHFEPositionInternalCustomerId);
            }

            if (IdList != null && IdList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.SHFECapitalDetail.InternalBPId = @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.SHFECapitalDetail.InternalBPId = @p{0}", i++);
                        parameters.Add(IdList[j]);
                    }
                }
                sb.Append(")");
            }

            if (SHFEPositionStartDate != null)
            {
                sb.AppendFormat(" and it.SHFECapitalDetail.TradeDate >= @p{0}", i++);
                parameters.Add(SHFEPositionStartDate);
            }

            if (SHFEPositionEndDate != null)
            {
                sb.AppendFormat(" and it.SHFECapitalDetail.TradeDate <= @p{0}", i++);
                parameters.Add(SHFEPositionEndDate);
            }

            if (SHFEPositionDirectionId > 0)
            {
                sb.AppendFormat(" and it.PositionDirection = @p{0}", i++);
                parameters.Add(SHFEPositionDirectionId);
            }

            if (SHFEPositionBrokerId > 0)
            {
                sb.AppendFormat(" and it.SHFECapitalDetail.AgentId = @p{0}", i++);
                parameters.Add(SHFEPositionBrokerId);
            }

            if (SHFEPositionTypeId > 0)
            {
                sb.AppendFormat(" and it.PositionType = @p{0}", i);
                parameters.Add(SHFEPositionTypeId);
            }

            condition = sb.ToString();
        }

        /// <summary>
        /// remove quota by id from the added quotas 
        /// </summary>
        /// <param name="quotaId">quota id</param>
        public void RemoveAddedQuota(int quotaId)
        {
            var line = AddedQuotas.Find(o => o.QuotaId == quotaId);
            if (NewQuotas.RemoveAll(o => o.QuotaId == quotaId) <= 0)
            {
                DeletedQuotas.Add(line);
            }
            AddedQuotas.Remove(line);

            var quota = Quotas.SingleOrDefault(o => o.Id == quotaId);
            if (quota != null)
            {
                quota.AvailableQuantityForHedge = quota.Quantity ?? 0;
            }
        }

        /// <summary>
        /// Add quota from right to left
        /// </summary>
        /// <param name="quotaId"></param>
        public void AddQuota(int quotaId)
        {
            Quota quotaLine = _quotas.Find(o => o.Id == quotaId);
            quotaLine.AvailableQuantityForHedge = 0;

            var addedQuotaLine = DeletedQuotas.FirstOrDefault(o => o.QuotaId == quotaId);
            if (addedQuotaLine != null)
            {
                AddedQuotas.Add(addedQuotaLine);
                DeletedQuotas.Remove(addedQuotaLine);
            }
            else
            {
                var hedgeLine = new HedgeLineQuota
                {
                    HedgeGroupId = ObjectId,
                    QuotaId = quotaId,
                    Quota = quotaLine,
                    AssignedQuantity = quotaLine.Quantity ?? 0
                };
                AddedQuotas.Add(hedgeLine);
                NewQuotas.Add(hedgeLine);
            }
        }

        /// <summary>
        /// remove LME Position by id from the added positions 
        /// </summary>
        /// <param name="lmePositionId"></param>
        public void RemoveAddedLMEPosition(int lmePositionId)
        {
            var line = AddedLMEPositions.Find(o => o.LMEPositionId == lmePositionId);
            if (NewLMEPositions.RemoveAll(o => o.LMEPositionId == lmePositionId) <= 0)
            {
                DeletedLMEPositions.Add(line);
            }
            AddedLMEPositions.Remove(line);

            var lme = LMEPositions.SingleOrDefault(o => o.Id == lmePositionId);
            if (lme != null)
            {
                lme.AvailableLotForHedge += line.AssignedLotAmount;
            }
        }

        /// <summary>
        /// Add lme position to the hedge group, with given assigned quantity
        /// </summary>
        /// <param name="lmePositionId"></param>
        /// <param name="qty"></param>
        public void AddLMEPosition(int lmePositionId, decimal qty)
        {
            var p = LMEPositions.SingleOrDefault(o => o.Id == lmePositionId);
            if (p != null)
            {
                if (p.AvailableLotForHedge < qty)
                {
                    throw new Exception(ResHedgeGroup.NotEnough);
                }
                p.AvailableLotForHedge -= qty;
                var assignedCommission = Math.Round((decimal)(p.AgentCommission / p.LotAmount * qty), RoundRules.AMOUNT, MidpointRounding.AwayFromZero);

                // in deleted ones
                var tmp = DeletedLMEPositions.FirstOrDefault(o => o.LMEPositionId == lmePositionId);
                if (tmp != null)
                {
                    DeletedLMEPositions.Remove(tmp);
                    tmp.AssignedLotAmount = qty;
                    tmp.AssignedCommission = assignedCommission;
                    AddedLMEPositions.Add(tmp);
                    AddedLMEPositions = AddedLMEPositions.OrderBy(o => o.LMEPosition.TradeDate).ToList();
                    return;
                }

                // in new ones
                tmp = NewLMEPositions.FirstOrDefault(o => o.LMEPositionId == lmePositionId);
                if (tmp != null)
                {
                    tmp.AssignedLotAmount += qty;
                    tmp.AssignedCommission += assignedCommission;
                    return;
                }

                // new added
                var newLine = new HedgeLineLMEPosition
                {
                    LMEPosition = p,
                    LMEPositionId = p.Id,
                    AssignedLotAmount = qty,
                    HedgeGroupId = ObjectId,
                    AssignedCommission = assignedCommission
                };
                AddedLMEPositions.Add(newLine);
                AddedLMEPositions = AddedLMEPositions.OrderBy(o => o.LMEPosition.TradeDate).ToList();
                NewLMEPositions.Add(newLine);
            }
        }

        /// <summary>
        /// remove SHFE Position by id from the added positions 
        /// </summary>
        /// <param name="shfePositionId"></param>
        public void RemoveAddedSHFEPosition(int shfePositionId)
        {
            var line = AddedSHFEPositions.Find(o => o.SHFEPositionId == shfePositionId);
            if (NewSHFEPositions.RemoveAll(o => o.SHFEPositionId == shfePositionId) <= 0)
            {
                DeletedSHFEPositions.Add(line);
            }
            AddedSHFEPositions.Remove(line);

            var shfe = SHFEPositions.SingleOrDefault(o => o.Id == shfePositionId);
            if (shfe != null)
            {
                shfe.AvailableLotForHedge += line.AssignedLotAmount;
            }
        }

        /// <summary>
        /// Add shfe position to the hedge group, with given assigned quantity
        /// </summary>
        /// <param name="shfePositionId"></param>
        /// <param name="qty"></param>
        public void AddSHFEPosition(int shfePositionId, decimal qty)
        {
            var p = SHFEPositions.SingleOrDefault(o => o.Id == shfePositionId);
            if (p != null)
            {
                if (p.AvailableLotForHedge < qty)
                {
                    throw new Exception(ResHedgeGroup.NotEnough);
                }
                p.AvailableLotForHedge -= qty;
                var assignedCommission = Math.Round((decimal)(p.Commission / p.LotQuantity * qty), RoundRules.AMOUNT, MidpointRounding.AwayFromZero);

                // in deleted ones
                var tmp = DeletedSHFEPositions.FirstOrDefault(o => o.SHFEPositionId == shfePositionId);
                if (tmp != null)
                {
                    DeletedSHFEPositions.Remove(tmp);
                    tmp.AssignedLotAmount = qty;
                    tmp.AssignedCommission = assignedCommission;
                    AddedSHFEPositions.Add(tmp);
                    AddedSHFEPositions =
                        AddedSHFEPositions.OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ToList();
                    return;
                }

                // in new ones
                tmp = NewSHFEPositions.FirstOrDefault(o => o.SHFEPositionId == shfePositionId);
                if (tmp != null)
                {
                    tmp.AssignedLotAmount += qty;
                    tmp.AssignedCommission += assignedCommission;
                    return;
                }

                // new added
                var newLine = new HedgeLineSHFEPosition
                {
                    SHFEPosition = p,
                    SHFEPositionId = p.Id,
                    AssignedLotAmount = qty,
                    HedgeGroupId = ObjectId,
                    AssignedCommission = assignedCommission
                };
                AddedSHFEPositions.Add(newLine);
                AddedSHFEPositions = AddedSHFEPositions.OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ToList();
                NewSHFEPositions.Add(newLine);
            }
        }

        /// <summary>
        /// Calculate the PL 
        /// </summary>
        public void CalculatePL()
        {
            SetCurrencies();
            UserId = CurrentUser.Id;
            Calculator.Calculate(this);
        }

        /// <summary>
        /// Set the currency for PL and average price
        /// </summary>
        private void SetCurrencies()
        {
            //Quota Currency
            if (AddedQuotas.SelectMany(o => o.Quota.Pricings).Select(o => o.Currency).Any(o => o.Code == "CNY"))
            {
                QuotaPLCurrency = "CNY";
            }
            else
            {
                QuotaPLCurrency = "USD";
            }

            LMEPLCurrency = "USD";
            SHFEPLCurrency = "CNY";

            //total pl currency
            if (QuotaPLCurrency == "USD" && AddedSHFEPositions.Count == 0)
            {
                TotalPLCurrency = "USD";
            }
            else
            {
                TotalPLCurrency = "CNY";
            }
        }

        /// <summary>
        /// Calculate the average price
        /// </summary>
        internal void CalculateAvgPrice()
        {
            //Get Rate
            decimal rate;
            if (Rate == null || Rate == 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    rate = rateService.GetExchangeRateByCode("USD", "CNY") ?? 0;
                }
            }
            else
            {
                rate = (decimal)Rate;
            }

            var buyQuotas =
                AddedQuotas.Where(o => o.Quota.Contract.ContractType == (int)ContractType.Purchase).ToList();
            var sellQuotas = AddedQuotas.Where(o => o.Quota.Contract.ContractType == (int)ContractType.Sales).ToList();

            if (QuotaPLCurrency == "USD")
            {
                QuotaBuyAvg = buyQuotas.Count == 0
                              ? null
                              : buyQuotas.Sum(o => o.Quota.AveragePrice * o.Quota.ActualQuantity) /
                                buyQuotas.Sum(o => o.Quota.ActualQuantity);
                QuotaSellAvg = sellQuotas.Count == 0
                                   ? null
                                   : sellQuotas.Sum(o => o.Quota.AveragePrice * o.Quota.ActualQuantity) /
                                     sellQuotas.Sum(o => o.Quota.ActualQuantity);
            }
            else
            {

                var quotaBuyQtySum = buyQuotas.Sum(o => o.Quota.ActualQuantity);
                if (Math.Round(quotaBuyQtySum, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                {
                    QuotaBuyAvg = null;
                }
                else
                {
                    decimal? quotaBuyAmountSum = 0;
                    foreach (var hedgeLineQuota in buyQuotas)
                    {
                        if (hedgeLineQuota.Quota.Currency.Code == "USD")
                        {
                            quotaBuyAmountSum += hedgeLineQuota.Quota.AveragePrice * hedgeLineQuota.Quota.ActualQuantity * rate;
                        }
                        else
                        {
                            quotaBuyAmountSum += hedgeLineQuota.Quota.AveragePrice * hedgeLineQuota.Quota.ActualQuantity;
                        }
                    }
                    QuotaBuyAvg = quotaBuyAmountSum / quotaBuyQtySum;
                }

                var quotaSellQtySum = sellQuotas.Sum(o => o.Quota.ActualQuantity);
                if (Math.Round(quotaSellQtySum, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                {
                    QuotaSellAvg = null;
                }
                else
                {
                    decimal? quotaSellAmountSum = 0;
                    foreach (var hedgeLineQuota in sellQuotas)
                    {
                        if (hedgeLineQuota.Quota.Currency.Code == "USD")
                        {
                            quotaSellAmountSum += hedgeLineQuota.Quota.AveragePrice * hedgeLineQuota.Quota.ActualQuantity * rate;
                        }
                        else
                        {
                            quotaSellAmountSum += hedgeLineQuota.Quota.AveragePrice * hedgeLineQuota.Quota.ActualQuantity;
                        }
                    }
                    QuotaSellAvg = quotaSellAmountSum / quotaSellQtySum;
                }
            }

            var buyLmes = AddedLMEPositions.Where(o => o.LMEPosition.TradeDirection == (int)PositionDirection.Long).ToList();
            var sellLmes = AddedLMEPositions.Where(o => o.LMEPosition.TradeDirection == (int)PositionDirection.Short).ToList();

            LMEBuyAvg = buyLmes.Count == 0
                            ? null
                            : buyLmes.Sum(o => o.LMEPosition.AgentPrice * o.AssignedLotAmount) /
                              buyLmes.Sum(o => o.AssignedLotAmount);
            LMESellAvg = sellLmes.Count == 0
                             ? null
                             : sellLmes.Sum(o => o.LMEPosition.AgentPrice * o.AssignedLotAmount) /
                               sellLmes.Sum(o => o.AssignedLotAmount);

            var buyOpenShfes =
                AddedSHFEPositions.Where(
                    o =>
                    o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                    o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).ToList();
            SHFEBuyOpenAvg = buyOpenShfes.Count == 0
                                 ? null
                                 : buyOpenShfes.Sum(o => o.SHFEPosition.Price * o.AssignedLotAmount) /
                                   buyOpenShfes.Sum(o => o.AssignedLotAmount);

            var buyCloseShfes =
                AddedSHFEPositions.Where(
                    o =>
                    o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                    o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).ToList();
            SHFEBuyCloseAvg = buyCloseShfes.Count == 0
                                  ? null
                                  : buyCloseShfes.Sum(o => o.SHFEPosition.Price * o.AssignedLotAmount) /
                                    buyCloseShfes.Sum(o => o.AssignedLotAmount);

            var sellOpenShfes =
                AddedSHFEPositions.Where(
                    o =>
                    o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                    o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).ToList();
            SHFESellOpenAvg = sellOpenShfes.Count == 0
                                  ? null
                                  : sellOpenShfes.Sum(o => o.SHFEPosition.Price * o.AssignedLotAmount) /
                                    sellOpenShfes.Sum(o => o.AssignedLotAmount);

            var sellCloseShfes =
                AddedSHFEPositions.Where(
                    o =>
                    o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                    o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).ToList();
            SHFESellCloseAvg = sellCloseShfes.Count == 0
                                   ? null
                                   : sellCloseShfes.Sum(o => o.SHFEPosition.Price * o.AssignedLotAmount) /
                                     sellCloseShfes.Sum(o => o.AssignedLotAmount);
        }

        public decimal GetAvailableLotNumberByLMEId(int id)
        {
            var lme = LMEPositions.SingleOrDefault(o => o.Id == id);
            if (lme != null)
            {
                return lme.AvailableLotForHedge;
            }

            return 0;
        }

        public decimal GetAvailableLotNumberBySHFEId(int id)
        {
            var shfe = SHFEPositions.SingleOrDefault(o => o.Id == id);
            if (shfe != null)
            {
                return shfe.AvailableLotForHedge;
            }

            return 0;
        }

        /// <summary>
        /// 验证保存逻辑
        /// </summary>
        /// <returns></returns>
        private void CheckSaveLogic()
        {
            switch (SelectedArbitrageTypeId)
            {
                case (int)ArbitrageType.FPArbitrage:
                //期现正套
                case (int)ArbitrageType.FPRevArbitrage:
                    //期现反套
                    CheckFPArbitrage();
                    break;
                case (int)ArbitrageType.CarryArbitrage:
                //跨期正套
                case (int)ArbitrageType.CarryRevArbitrage:
                    //跨期反套
                    CheckCarryArbitrage();
                    break;
                case (int)ArbitrageType.MarketArbitrage:
                //跨市正套
                case (int)ArbitrageType.MarketRevArbitrage:
                    //跨市反套
                    CheckMarketArbitrage();
                    break;
            }
        }

        #region 验证期现正套反套保存逻辑
        private void CheckFPArbitrage()
        {
            //没有头寸或者只能有内盘或者外盘头寸
            if (AddedQuotas.Count == 0)
            {
                throw new Exception("期现保值必须有现货");
            }
            if (AddedLMEPositions.Count == 0 && AddedSHFEPositions.Count == 0)
            {
                throw new Exception("期现保值必须有期货");
            }
            if (AddedLMEPositions.Count > 0 && AddedSHFEPositions.Count > 0)
            {
                throw new Exception("期现保值必须只有内盘或外盘头寸");
            }

            int quotaCommodityCount = AddedQuotas.Select(o => o.Quota.CommodityId).Distinct().Count();
            if (quotaCommodityCount > 1)
            {
                throw new Exception("期现保值现货的金属必须一样");
            }

            int lmeCommodityCount = AddedLMEPositions.Select(o => o.LMEPosition.CommodityId).Distinct().Count();
            if (lmeCommodityCount > 1)
            {
                throw new Exception("期现保值期货的金属必须一样");
            }

            int shfeCommodityCount = AddedSHFEPositions.Select(o => o.SHFEPosition.CommodityId).Distinct().Count();
            if (shfeCommodityCount > 1)
            {
                throw new Exception("期现保值期货的金属必须一样");
            }

            List<PhyLotAmount> list = GetPhyLotAmount();

            List<SHFELotAmount> shfes = GetSHFELotAmount();
            List<LMELotAmount> lmes = GetLMELotAmount();

            int phyCommodityId = AddedQuotas[0].Quota.CommodityId.Value;


            if (AddedLMEPositions.Count > 0)
            {
                if (lmes.Count > 0)
                {
                    LMELotAmount lme = lmes[0];
                    if (lme.CommodityId != phyCommodityId)
                    {
                        throw new Exception("期现货的金属不同");
                    }
                }

            }

            if (AddedSHFEPositions.Count > 0)
            {
                if (shfes.Count > 0)
                {
                    //if (shfes.Count > 1)
                    //{
                    //    throw new Exception("内盘头寸有多个合约不平");
                    //}
                    SHFELotAmount shfe = shfes[0];
                    if (shfe.CommodityId != phyCommodityId)
                    {
                        throw new Exception("期现货的金属不同");
                    }
                    if (shfe.LotAmountLong < 0 || shfe.LotAmountShort < 0)
                    {
                        throw new Exception("期货内盘没有开仓的净持仓");
                    }
                }

            }

            if (list.Count > 0)
            {
                List<int> contractTypes = AddedQuotas.Select(o => o.Quota.Contract.ContractType).Distinct().ToList();
                if (contractTypes.Count == 1)
                {
                    //只有采购或销售
                    if (shfes.Count == 0 && lmes.Count == 0)
                    {
                        throw new Exception("期货必须要有净持仓");
                    }
                    if (shfes.Count > 0)
                    {
                        if (shfes.Count > 1)
                        {
                            throw new Exception("期货只能有一个合约有净持仓");
                        }
                        if (contractTypes[0] == (int)ContractType.Purchase)
                        {
                            //采购
                            if (shfes[0].LotAmountShort <= 0)
                            {
                                throw new Exception("内盘必须要有卖出开仓的净持仓");
                            }
                        }
                        else
                        {
                            //销售
                            if (shfes[0].LotAmountLong <= 0)
                            {
                                throw new Exception("内盘必须要有买入开仓的净持仓");
                            }
                        }

                    }
                    if (lmes.Count > 0)
                    {
                        if (lmes.Count > 1)
                        {
                            throw new Exception("期货只能有一个到期日有净持仓");
                        }
                        if (lmes[0].LotAmount * (list[0].LotAmountPurchase - list[0].LotAmountSales) > 0)
                        {
                            throw new Exception("期现保值现货的净持仓和外盘的净持仓的方向不能相同");
                        }
                    }

                }
                else
                {
                    //现货采购销售数量不等
                    //因为没有跨品牌，所以只有一种金属
                    if (shfes.Count > 0)
                    {
                        bool flag= shfes.Any(o => o.LotAmountLong > 0 || o.LotAmountShort > 0);

                        if (!flag)
                        {
                            throw new Exception("内盘没有开仓的净持仓");
                        }

                        if (AddedQuotas.Any(o => o.Quota.Contract.ContractType == (int)ContractType.Purchase))
                        { 
                            //现货有采购,期货要有卖出的开仓来保值
                            if (!AddedSHFEPositions.Any(o => o.SHFEPosition.PositionDirection==(int)PositionDirection.Short 
                                && o.SHFEPosition.OpenClose==(int)PositionOpenClose.Open))
                            {
                                throw new Exception("期现保值现货的交易和内盘的净持仓的方向不能相同");
                            }
                        }

                        if (AddedQuotas.Any(o => o.Quota.Contract.ContractType == (int)ContractType.Sales))
                        {
                            //现货有销售,期货要有买入的开仓来保值
                            if (!AddedSHFEPositions.Any(o => o.SHFEPosition.PositionDirection == (int)PositionDirection.Long
                                && o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open))
                            {
                                throw new Exception("期现保值现货的交易和内盘的净持仓的方向不能相同");
                            }
                        }
                    }
                    if (lmes.Count > 0)
                    {
                        LMELotAmount lme = lmes[0];
                        if (lme.CommodityId != phyCommodityId)
                        {
                            throw new Exception("期现货的金属不同");
                        }
                        //if (lme.LotAmount * (phyLotAmount.LotAmountPurchase - phyLotAmount.LotAmountSales) > 0)
                        //{
                        //    throw new Exception("期现保值现货的净持仓和外盘的净持仓的方向不能相同");
                        //}

                        if (AddedQuotas.Any(o => o.Quota.Contract.ContractType == (int)ContractType.Purchase))
                        {
                            //现货有采购,期货要有卖出来保值
                            if (AddedLMEPositions.All(o => o.LMEPosition.TradeDirection != (int)PositionDirection.Short))
                            {
                                throw new Exception("期现保值现货的交易和外盘的净持仓的方向不能相同");
                            }
                        }

                        if (AddedQuotas.Any(o => o.Quota.Contract.ContractType == (int)ContractType.Sales))
                        {
                            //现货有销售,期货要有买入来保值
                            if (AddedLMEPositions.All(o => o.LMEPosition.TradeDirection != (int)PositionDirection.Long))
                            {
                                throw new Exception("期现保值现货的交易和外盘的净持仓的方向不能相同");
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region 验证跨期正套反套保存逻辑

        private void CheckCarryArbitrage()
        {
            //1.	不能包含现货合同
            //2.	仅有内盘头寸或者外盘头寸
            //3.	针对内盘,没有不平的合约或者仅有两个期货合约可以有净持仓,并且净持仓的数量相等方向相反
            //4.	针对外盘,没有不平的到期日头寸或者仅有两个到期日的头寸可以有净持仓,并且净持仓的数量相等方向相反
            //5.    到期日必须有不同的情况

            //不能包含现货合同
            if (AddedQuotas.Count > 0)
            {
                throw new Exception("跨期保值不能包含现货合同");
            }

            //仅有内盘头寸或者外盘头寸
            if (AddedLMEPositions.Count > 0 && AddedSHFEPositions.Count > 0)
            {
                throw new Exception("跨期保值必须仅有内盘头寸或者外盘头寸");
            }
            if (AddedLMEPositions.Count == 0 && AddedSHFEPositions.Count == 0)
            {
                throw new Exception("跨期保值必须有内盘头寸或者外盘头寸");
            }
            //针对内盘,没有不平的合约或者仅有两个期货合约可以有净持仓,并且净持仓的数量相等方向相反
            if (AddedSHFEPositions.Count > 0)
            {
                int count = AddedSHFEPositions.Select(o => o.SHFEPosition.SHFEId).Distinct().Count();
                if (count == 1)
                {
                    throw new Exception("跨期保值必须有多个不同的合约");
                }
                int shortCount = AddedSHFEPositions.Count(o => o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open && o.SHFEPosition.PositionDirection == (int)PositionDirection.Short);
                int longCount = AddedSHFEPositions.Count(o => o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open && o.SHFEPosition.PositionDirection == (int)PositionDirection.Long);

                if (shortCount == 0 || longCount == 0)
                {
                    throw new Exception("跨期保值开仓方向不能相同");
                }

                if (!CheckSHFEPosition())
                {
                    throw new Exception("跨期保值内盘必须没有不平的合约或者仅有两个期货合约可以有净持仓,并且净持仓的数量相等方向相反");
                }
            }

            //针对外盘,没有不平的到期日头寸或者仅有两个到期日的头寸可以有净持仓,并且净持仓的数量相等方向相反
            if (AddedLMEPositions.Count > 0)
            {
                int count = AddedLMEPositions.Select(o => o.LMEPosition.PromptDate).Distinct().Count();
                if (count == 1)
                {
                    throw new Exception("跨期保值必须有多个不同的到期日");
                }
                if (!CheckLMEPosition())
                {
                    throw new Exception("跨期保值外盘必须没有不平的到期日头寸或者仅有两个到期日的头寸可以有净持仓,并且净持仓的数量相等方向相反");
                }
            }
        }
        #endregion

        #region 验证跨市正套反套保存逻辑
        private void CheckMarketArbitrage()
        {
            //1.	不能包含现货合同
            //2.	必须既有内盘头寸又有外盘头寸
            //3.	针对内盘，仅有一个期货合约可以有净持仓;针对外盘,仅有一个到期日头寸可以有净持仓
            //4.	或者内外盘同时都没有净持仓
            //5.	如果头寸不平，内盘净持仓和外盘净持仓的方向相反,不要求数量相同

            //不能包含现货
            if (AddedQuotas.Count > 0)
            {
                throw new Exception("跨市保值不能包含现货合同");
            }

            //必须既有内盘头寸又有外盘头寸
            if (AddedLMEPositions.Count == 0 || AddedSHFEPositions.Count == 0)
            {
                throw new Exception("跨市保值必须既有内盘头寸又有外盘头寸");
            }

            List<int> lmeCommodities = AddedLMEPositions.Select(o => o.LMEPosition.CommodityId.Value).Distinct().ToList();
            int lmeCommodityCount = lmeCommodities.Count();
            if (lmeCommodityCount > 1)
            {
                throw new Exception("跨市保值不能跨金属");
            }

            List<int> shfeCommodities = AddedSHFEPositions.Select(o => o.SHFEPosition.CommodityId.Value).Distinct().ToList();
            int shfeCommodityCount = shfeCommodities.Count();
            if (shfeCommodityCount > 1)
            {
                throw new Exception("跨市保值不能跨金属");
            }

            if (shfeCommodities[0] != lmeCommodities[0])
            {
                throw new Exception("跨市保值不能跨金属");
            }

            List<SHFELotAmount> holdSHFE = GetSHFELotAmount();
            List<LMELotAmount> holdLME = GetLMELotAmount();
            if (holdSHFE.Count == 0 && holdLME.Count == 0)
            {
                //内外盘同时都没有净持仓
                return;
            }
            if (holdSHFE.Count == 1 && holdLME.Count == 1)
            {
                //针对内盘，仅有一个期货合约可以有净持仓;针对外盘,仅有一个到期日头寸可以有净持仓
                SHFELotAmount shfe = holdSHFE[0];
                LMELotAmount lme = holdLME[0];

                if (shfe.CommodityId != lme.CommodityId)
                {
                    throw new Exception("金属不同");
                }

                if (shfe.LotAmountShort < 0 || shfe.LotAmountLong < 0)
                {
                    throw new Exception("内盘没有开仓的净持仓");
                }
                if (shfe.LotAmountShort > 0)
                {
                    //卖出不平
                    if (shfe.LotAmountShort * lme.LotAmount < 0)
                    {
                        throw new Exception("跨市保值内盘净持仓和外盘净持仓的方向必须相反");
                    }
                }

                if (shfe.LotAmountLong > 0)
                {
                    //买入不平
                    if (shfe.LotAmountLong * lme.LotAmount > 0)
                    {
                        throw new Exception("跨市保值内盘净持仓和外盘净持仓的方向必须相反");
                    }
                }
            }
            else
            {
                throw new Exception("跨市保值针对内盘，仅有一个期货合约可以有净持仓;针对外盘,仅有一个到期日头寸可以有净持仓");
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns>返回true是平掉了</returns>
        private bool CheckSHFEPosition()
        {
            bool result = true;
            int commodityCount = AddedSHFEPositions.Select(o => o.SHFEPosition.CommodityId).Distinct().Count();
            if (commodityCount > 1)
            {
                throw new Exception("不能跨金属");
            }
            var shfeGroupByComms = AddedSHFEPositions.GroupBy(o => o.SHFEPosition.CommodityId);
            foreach (var shfeGroupByComm in shfeGroupByComms)
            {
                var shfeListByComm = shfeGroupByComm.ToList();

                var shfeGroupBySHFEs = shfeListByComm.GroupBy(o => o.SHFEPosition.SHFEId);
                foreach (var shfeGroupBySHFE in shfeGroupBySHFEs)
                {
                    var shfeListBySHFE = shfeGroupBySHFE.ToList();
                    var openLongSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                    var closeLongSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                    var openShortSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                    var closeShortSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                    if (Math.Round(openLongSum - closeShortSum, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) != 0 || Math.Round(openShortSum - closeLongSum) != 0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (!result)
            {
                List<SHFELotAmount> shfeHoldLotAmounts = GetSHFELotAmount();
                var shfeGroupByCommodityId = shfeHoldLotAmounts.GroupBy(o => o.CommodityId);
                foreach (var shfeGroupByComm in shfeGroupByCommodityId)
                {
                    var shfeListByComm = shfeGroupByComm.ToList();
                    if (shfeListByComm.Count == 2)
                    {
                        //只有2个合约
                        SHFELotAmount shfeLotAmount1 = shfeListByComm[0];
                        SHFELotAmount shfeLotAmount2 = shfeListByComm[1];
                        decimal lotAmountLong = shfeLotAmount1.LotAmountLong - shfeLotAmount2.LotAmountShort;
                        decimal lotAmountShort = shfeLotAmount1.LotAmountShort - shfeLotAmount2.LotAmountLong;

                        if (lotAmountLong == 0 && lotAmountShort == 0)
                        {
                            //数量相等，方向相反
                            result = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>返回true是平掉了</returns>
        private bool CheckLMEPosition()
        {
            bool result = false;
            int commodityCount = AddedLMEPositions.Select(o => o.LMEPosition.CommodityId).Distinct().Count();
            if (commodityCount > 1)
            {
                throw new Exception("不能跨金属");
            }
            List<LMELotAmount> lmeHoldLotAmounts = GetLMELotAmount();
            if (lmeHoldLotAmounts.Count == 0)
            {
                //没有净持仓
                result = true;
            }
            else
            {
                //有净持仓，需判断是否平掉
                var lmeGroupByComms = lmeHoldLotAmounts.GroupBy(o => o.CommodityId);
                foreach (var lmeGroupByComm in lmeGroupByComms)
                {
                    var lmeListByComm = lmeGroupByComm.ToList();
                    if (lmeListByComm.Count == 2)
                    {
                        //只有2个到期日
                        decimal lotAmount = lmeListByComm.Sum(o => o.LotAmount);
                        if (lotAmount == 0)
                        {
                            //数量相等，方向相反
                            result = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }
        #region 计算内盘的净持仓

        private List<SHFELotAmount> GetSHFELotAmount()
        {
            var shfeLotAmounts = new List<SHFELotAmount>();

            if (AddedSHFEPositions.Count > 0)
            {
                var shfeGroupByComms = AddedSHFEPositions.GroupBy(o => o.SHFEPosition.CommodityId);
                foreach (var shfeGroupByComm in shfeGroupByComms)
                {
                    var shfeListByComm = shfeGroupByComm.ToList();
                    var shfeListByComm1 = shfeListByComm.FirstOrDefault();
                    if (shfeListByComm1 == null)
                        continue;
                    int commodityId = shfeListByComm1.SHFEPosition.CommodityId.Value;

                    var shfeGroupBySHFEs = shfeListByComm.GroupBy(o => o.SHFEPosition.SHFEId);
                    foreach (var shfeGroupBySHFE in shfeGroupBySHFEs)
                    {
                        var shfeListBySHFE = shfeGroupBySHFE.ToList();
                        var shfeListBySHFE1 = shfeListBySHFE.FirstOrDefault();
                        if (shfeListBySHFE1 == null)
                            continue;
                        int shfeId = shfeListBySHFE1.SHFEPosition.SHFEId.Value;
                        DateTime day = shfeListBySHFE1.SHFEPosition.PromptDate.Value;
                        var longSumOpen =
                            shfeListBySHFE.Where(
                                o =>
                                o.SHFEPosition.PositionDirection == (int)PositionDirection.Long
                                && o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                        var longSumClose =
                            shfeListBySHFE.Where(
                                o =>
                                o.SHFEPosition.PositionDirection == (int)PositionDirection.Long
                                && o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                        var shortSumOpen =
                            shfeListBySHFE.Where(
                                o =>
                                o.SHFEPosition.PositionDirection == (int)PositionDirection.Short
                                && o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                        var shortSumClose =
                            shfeListBySHFE.Where(
                                o =>
                                o.SHFEPosition.PositionDirection == (int)PositionDirection.Short
                                && o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                        if (longSumOpen == 0 && shortSumOpen == 0)
                        {
                            throw new Exception("净持仓应为开仓");
                        }
                        decimal lotAmountLong = longSumOpen - shortSumClose;
                        decimal lotAmountShort = shortSumOpen - longSumClose;
                        if (lotAmountLong < 0 || lotAmountShort < 0)
                        {
                            throw new Exception("净持仓不能为平仓");
                        }
                        if (lotAmountLong != 0 || lotAmountShort != 0)
                        {
                            var shfeLotAmount = new SHFELotAmount
                                                    {
                                                        SHFEId = shfeId,
                                                        LotAmountLong = lotAmountLong,
                                                        LotAmountShort = lotAmountShort,
                                                        CommodityId = commodityId,
                                                        PromptDate = day
                                                    };
                            shfeLotAmounts.Add(shfeLotAmount);
                        }
                    }
                }
            }
            return shfeLotAmounts;
        }
        #endregion

        #region 计算外盘的净持仓
        private List<LMELotAmount> GetLMELotAmount()
        {
            var lmeLotAmounts = new List<LMELotAmount>();
            if (AddedLMEPositions.Count > 0)
            {
                var lmeGroupByComms = AddedLMEPositions.GroupBy(o => o.LMEPosition.CommodityId);
                foreach (var lmeGroupByComm in lmeGroupByComms)
                {
                    var lmeListByComm = lmeGroupByComm.ToList();
                    HedgeLineLMEPosition hedgeLineLMEPosition = lmeListByComm.FirstOrDefault();
                    if (hedgeLineLMEPosition == null)
                        continue;
                    int commodityId = hedgeLineLMEPosition.LMEPosition.CommodityId.Value;

                    var lmeGroupByPrompts = lmeListByComm.GroupBy(o => o.LMEPosition.PromptDate);
                    foreach (var lmeGroupByPrompt in lmeGroupByPrompts)
                    {
                        var lmeListByPrompt = lmeGroupByPrompt.ToList();
                        var lmeListByPrompt1 = lmeListByPrompt.FirstOrDefault();
                        if (lmeListByPrompt1 == null)
                            continue;
                        DateTime day = lmeListByPrompt1.LMEPosition.PromptDate.Value;
                        decimal lotAmount = lmeListByPrompt.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue);
                        if (lotAmount != 0)
                        {
                            var lmeLotAmount = new LMELotAmount
                                                   {
                                                       PromptDate = day,
                                                       LotAmount = lotAmount,
                                                       CommodityId = commodityId
                                                   };
                            lmeLotAmounts.Add(lmeLotAmount);
                        }
                    }
                }
            }
            return lmeLotAmounts;
        }
        #endregion

        #region 计算现货的净持仓
        private List<PhyLotAmount> GetPhyLotAmount()
        {
            var phyLotAmounts = new List<PhyLotAmount>();

            if (AddedQuotas.Count > 0)
            {
                var phyGroupByComms = AddedQuotas.GroupBy(o => o.Quota.CommodityId);
                foreach (var phyGroupByComm in phyGroupByComms)
                {
                    var phyListByComm = phyGroupByComm.ToList();
                    HedgeLineQuota hedgeLineQuota = phyListByComm.FirstOrDefault();
                    if (hedgeLineQuota == null)
                        continue;
                    int commodityId = hedgeLineQuota.Quota.CommodityId.Value;
                    decimal purchaseQty = AddedQuotas.Where(o => o.Quota.Contract.ContractType == (int)ContractType.Purchase).Sum(o => o.Quota.Quantity ?? 0);
                    decimal salesQty = AddedQuotas.Where(o => o.Quota.Contract.ContractType == (int)ContractType.Sales).Sum(o => o.Quota.Quantity ?? 0);
                    if (purchaseQty != salesQty)
                    {
                        var phyLotAmount = new PhyLotAmount
                                               {
                                                   CommodityId = commodityId,
                                                   LotAmountPurchase = purchaseQty,
                                                   LotAmountSales = salesQty
                                               };
                        phyLotAmounts.Add(phyLotAmount);
                    }
                }
            }

            return phyLotAmounts;
        }
        #endregion
        #endregion
    }

    public class SHFELotAmount
    {
        public int SHFEId { get; set; }
        public int CommodityId { get; set; }
        public decimal LotAmountLong { get; set; }
        public decimal LotAmountShort { get; set; }
        public DateTime PromptDate { get; set; }
    }

    public class LMELotAmount
    {
        public DateTime PromptDate { get; set; }
        public int CommodityId { get; set; }
        public decimal LotAmount { get; set; }
    }

    public class PhyLotAmount
    {
        public int CommodityId { get; set; }
        public decimal LotAmountSales { get; set; }
        public decimal LotAmountPurchase { get; set; }
    }
}

