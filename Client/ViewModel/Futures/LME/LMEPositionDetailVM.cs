using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommissionServiceReference;
using Client.CommodityServiceReference;
using Client.LMEPositionServiceReference;
using Client.SystemParameterServiceReference;
using Client.View.Futures.LME;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using DBEntity.EnableProperty;

namespace Client.ViewModel.Futures.LME
{
    public class LMEPositionDetailVM : ObjectBaseVM
    {
        #region Member

        private decimal? _agentCommission;
        private decimal? _agentPrice;
        private string _bPartnerName;
        private int? _brokerId;
        private List<BusinessPartner> _brokers;
        private decimal? _clientCommission;
        private decimal? _clientPrice;
        private string _comment;
        private int? _icId;
        private List<BusinessPartner> _iCs;
        private decimal? _lotAmount;
        private List<Commodity> _metals;
        private int? _positionType;
        private Dictionary<string, int> _positionTypes;
        private DateTime? _promptDate;
        private string _quotaNo;
        private int? _selectedMetal;
        private DateTime? _tradeDate;
        private int? _tradeDirection;
        private Dictionary<string, int> _tradeDirections;
        private bool _isLMEAgent;
        private LMEPositionDetailVM _pVM;
        private int? _selectedBPartnerId;
        private int? _selectedQuotaId;
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

        public DateTime? TradeDate
        {
            get { return _tradeDate; }
            set
            {
                if (_tradeDate != value)
                {
                    _tradeDate = value;
                    Notify("TradeDate");
                }
            }
        }

        public DateTime? PromptDate
        {
            get { return _promptDate; }
            set
            {
                if (_promptDate != value)
                {
                    _promptDate = value;
                    Notify("PromptDate");
                }
            }
        }

        public List<Commodity> Metals
        {
            get { return _metals; }
            set
            {
                if (_metals != value)
                {
                    _metals = value;
                    Notify("Metals");
                }
            }
        }

        public int? SelectedMetal
        {
            get { return _selectedMetal; }
            set
            {
                if (_selectedMetal != value)
                {
                    _selectedMetal = value;
                    Notify("SelectedMetal");
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

        public List<BusinessPartner> Brokers
        {
            get { return _brokers; }
            set
            {
                if (_brokers != value)
                {
                    _brokers = value;
                    Notify("Brokers");
                }
            }
        }

        public int? BrokerId
        {
            get { return _brokerId; }
            set
            {
                if (_brokerId != value)
                {
                    _brokerId = value;
                    Notify("BrokerId");
                }
            }
        }

        public int? SelectedBPartnerId
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

        public decimal? LotAmount
        {
            get { return _lotAmount; }
            set
            {
                if (_lotAmount != value)
                {
                    _lotAmount = value;
                    Notify("LotAmount");
                }
            }
        }

        public List<BusinessPartner> ICs
        {
            get { return _iCs; }
            set
            {
                if (_iCs != value)
                {
                    _iCs = value;
                    Notify("ICs");
                }
            }
        }

        public int? TradeDirection
        {
            get { return _tradeDirection; }
            set
            {
                if (_tradeDirection != value)
                {
                    _tradeDirection = value;
                    Notify("TradeDirection");
                }
            }
        }

        public int? PositionType
        {
            get { return _positionType; }
            set
            {
                if (_positionType != value)
                {
                    _positionType = value;
                    Notify("PositionType");
                }
            }
        }

        public Dictionary<string, int> TradeDirections
        {
            get { return _tradeDirections; }
            set
            {
                if (_tradeDirections != value)
                {
                    _tradeDirections = value;
                    Notify("TradeDirections");
                }
            }
        }

        public Dictionary<string, int> PositionTypes
        {
            get { return _positionTypes; }
            set
            {
                if (_positionTypes != value)
                {
                    _positionTypes = value;
                    Notify("PositionTypes");
                }
            }
        }

        public int? ICId
        {
            get { return _icId; }
            set
            {
                if (_icId != value)
                {
                    _icId = value;
                    Notify("ICId");
                }
            }
        }

        public decimal? AgentPrice
        {
            get { return _agentPrice; }
            set
            {
                if (_agentPrice != value)
                {
                    _agentPrice = value;
                    Notify("AgentPrice");
                }
            }
        }

        public decimal? ClientPrice
        {
            get { return _clientPrice; }
            set
            {
                if (_clientPrice != value)
                {
                    _clientPrice = value;
                    Notify("ClientPrice");
                }
            }
        }

        public decimal? ClientCommission
        {
            get { return _clientCommission; }
            set
            {
                if (_clientCommission != value)
                {
                    _clientCommission = value;
                    Notify("ClientCommission");
                }
            }
        }

        public decimal? AgentCommission
        {
            get { return _agentCommission; }
            set
            {
                if (_agentCommission != value)
                {
                    _agentCommission = value;
                    Notify("AgentCommission");
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

        public int? SelectedQuotaId
        {
            get { return _selectedQuotaId; }
            set
            {
                if (_selectedQuotaId != value)
                {
                    _selectedQuotaId = value;
                    Notify("SelectedQuotaId");
                }
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
                }
            }
        }

        public LMEPositionDetailVM PVM
        {
            get { return _pVM; }
            set
            {
                if (_pVM != value)
                {
                    _pVM = value;
                    Notify("PVM");
                }
            }
        }

        #endregion

        #region Constructor

        public LMEPositionDetailVM()
        {
            ObjectId = 0;
            PropertyChanged += LMEPositionDetailVMPropertyChanged;
            Initialize();
            LoadLMEPositionEnableProperty(ObjectId);
        }

        public LMEPositionDetailVM(int id)
        {
            ObjectId = id;
            PropertyChanged += LMEPositionDetailVMPropertyChanged;
            Initialize();
            LoadLMEPositionEnableProperty(ObjectId);
        }

        public bool IsLMEAgent
        {
            get { return _isLMEAgent; }
            set
            {
                if (_isLMEAgent != value)
                {
                    _isLMEAgent = value;
                    Notify("IsLMEAgent");
                }
            }
        }

        #endregion

        #region Method

        protected void LMEPositionDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc))
            {
                if (e.PropertyName == "TradeDate" || e.PropertyName == "PromptDate" || e.PropertyName == "ICId" ||
                    e.PropertyName == "SelectedMetal" || e.PropertyName == "SelectedBPartnerId" ||
                    e.PropertyName == "ClientPrice" || e.PropertyName == "LotAmount")
                {
                    ClientCommission = commissionService.GetCommissionValue(TradeDate, ICId, SelectedMetal,
                                                                            SelectedBPartnerId, ClientPrice, LotAmount,
                                                                            CurrentUser.Id);
                }
                if (e.PropertyName == "TradeDate" || e.PropertyName == "PromptDate" || e.PropertyName == "ICId" ||
                    e.PropertyName == "SelectedMetal" || e.PropertyName == "BrokerId" || e.PropertyName == "AgentPrice" ||
                    e.PropertyName == "LotAmount")
                {
                    AgentCommission = commissionService.GetCommissionValue(TradeDate, ICId, SelectedMetal, BrokerId,
                                                                           AgentPrice, LotAmount, CurrentUser.Id);
                }
                if (e.PropertyName == "TradeDate") 
                {
                    if (TradeDate.HasValue)
                    {
                        PromptDate = ((DateTime)TradeDate).AddMonths(3);
                        if (PromptDate.Value.DayOfWeek == DayOfWeek.Saturday)
                        {
                            PromptDate = PromptDate.Value.AddDays(2);
                        }
                        if (PromptDate.Value.DayOfWeek == DayOfWeek.Sunday)
                        {
                            PromptDate = PromptDate.Value.AddDays(1);
                        }
                    }
                    else 
                    {
                        PromptDate = null;
                    }
                }
            }
        }

        public void Initialize()
        {
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
            //系统参数代客理财配置
            using (var systemParameterService =
                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
            {
                SystemParameter s = systemParameterService.GetAll().FirstOrDefault();
                if (s != null)
                {
                    IsLMEAgent = s.IsLMEAgent != null && (bool) s.IsLMEAgent;
                }
                else
                {
                    IsLMEAgent = false;
                }
            }

            using (var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _iCs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                _iCs.Insert(0, new BusinessPartner());

                _brokers = businessPartnerService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner());
            }

            _positionTypes = new Dictionary<string, int>();
            _positionTypes = EnumHelper.GetEnumDic<PositionType>(_positionTypes);
            _tradeDirections = new Dictionary<string, int>();
            _tradeDirections = EnumHelper.GetEnumDic<PositionDirection>(_tradeDirections);

            GetMetals();
            SetDate();

            if (ObjectId > 0)
            {
                using (
                    var lmePositionService =
                        SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
                {
                    const string strInfo = "it.Id = @p1 ";
                    var parameters = new List<object> {ObjectId};
                    LMEPosition lmePosition =
                        lmePositionService.Select(strInfo, parameters,
                                                  new List<string>
                                                      {"Quota", "Agent", "Client", "InternalBP", "Commodity"}).
                            FirstOrDefault();
                    if (lmePosition != null)
                    {
                        _selectedQuotaId = lmePosition.QuotaId;
                        _icId = lmePosition.InternalBPId;
                        _tradeDate = lmePosition.TradeDate;
                        _bPartnerName = lmePosition.Client != null ? lmePosition.Client.ShortName : null;
                        _selectedBPartnerId = lmePosition.ClientId;
                        _selectedMetal = lmePosition.CommodityId;
                        _brokerId = lmePosition.AgentId;
                        _promptDate = lmePosition.PromptDate;
                        _quotaNo = lmePosition.Quota != null ? lmePosition.Quota.QuotaNo : null;
                        _lotAmount = lmePosition.LotAmount;
                        _tradeDirection = lmePosition.TradeDirection;
                        _positionType = lmePosition.PositionType;
                        _comment = lmePosition.Comment;
                        _agentPrice = lmePosition.AgentPrice;
                        _clientPrice = lmePosition.ClientPrice;
                        _clientCommission = lmePosition.ClientCommission;
                        _agentCommission = lmePosition.AgentCommission;
                    }
                }
            }
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _metals = metalService.GetCommoditiesByUser(CurrentUser.Id);
                _metals.Insert(0, new Commodity { Id = 0, Name = "" });
            }
        }

        public void SetDate() 
        {
            _tradeDate = DateTime.Today;
            _promptDate = DateTime.Today.AddMonths(3);
        }

        protected override void Create()
        {
            var lmePosition = new LMEPosition
                                  {
                                      QuotaId = SelectedQuotaId,
                                      InternalBPId = ICId,
                                      TradeDate = TradeDate,
                                      ClientId = SelectedBPartnerId,
                                      CommodityId = SelectedMetal,
                                      AgentId = BrokerId,
                                      PromptDate = PromptDate,
                                      LotAmount = LotAmount,
                                      TradeDirection = TradeDirection,
                                      PositionType = PositionType,
                                      Comment = Comment,
                                      AgentPrice = AgentPrice,
                                      ClientPrice = ClientPrice,
                                      ClientCommission = ClientCommission,
                                      AgentCommission = AgentCommission,
                                  };

            using (var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
            {
                lmePositionService.CreateNew(lmePosition, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
            {
                LMEPosition lmePosition = lmePositionService.GetById(ObjectId);

                if (lmePosition != null)
                {
                    lmePosition.QuotaId = SelectedQuotaId;
                    lmePosition.InternalBPId = ICId;
                    lmePosition.TradeDate = TradeDate;
                    lmePosition.ClientId = SelectedBPartnerId;
                    lmePosition.CommodityId = SelectedMetal;
                    lmePosition.AgentId = BrokerId;
                    lmePosition.PromptDate = PromptDate;
                    lmePosition.LotAmount = LotAmount;
                    lmePosition.TradeDirection = TradeDirection;
                    lmePosition.PositionType = PositionType;
                    lmePosition.Comment = Comment;
                    lmePosition.AgentPrice = AgentPrice;
                    lmePosition.ClientPrice = ClientPrice;
                    lmePosition.ClientCommission = ClientCommission;
                    lmePosition.AgentCommission = AgentCommission;
                    lmePositionService.UpdateExisted(lmePosition, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResLME.PositionNotFound);
                }
            }
        }


        public override bool Validate()
        {
            if (SelectedMetal < 0 || SelectedMetal == null)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }
            if (LotAmount < 0 || LotAmount == null)
            {
                throw new Exception(ResLME.LotNotNull);
            }

            if (TradeDate == null)
            {
                throw new Exception(Properties.Resources.TradeDateNotNull);
            }
            if (PromptDate == null)
            {
                throw new Exception(ResLME.PromptDateNotNull);
            }
            if (ICId < 0 || ICId == null)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }
            if (TradeDirection < 0 || TradeDirection == null)
            {
                throw new Exception(ResLME.TradeDirectionNotNull);
            }
            if (PositionType < 0 || PositionType == null)
            {
                throw new Exception(ResLME.TradeTypeNotNull);
            }
            if (BrokerId < 0 || BrokerId == null)
            {
                throw new Exception(Properties.Resources.BrokerRequired);
            }
            if (AgentPrice < 0 || AgentPrice == null)
            {
                throw new Exception(ResLME.BrokerPriceNotNull);
            }
            if (AgentCommission < 0 || AgentCommission == null)
            {
                throw new Exception(ResLME.BrokerCommissionNotNull);
            }
            if (TradeDate > PromptDate)
            {
                throw new Exception(ResLME.TradeDateLimitation);
            }
            
            return true;
        }

        #endregion

        #region 编辑属性

        private bool _isPriceEnable;
        private bool _isTradeDirectionEnable;
        private bool _isLotQuantityEnable;
        private bool _isCommodityEnable;

        public bool IsPriceEnable
        {
            get { return _isPriceEnable; }
            set
            {
                if (_isPriceEnable != value)
                {
                    _isPriceEnable = value;
                    Notify("IsPriceEnable");
                }
            }
        }

        public bool IsTradeDirectionEnable
        {
            get { return _isTradeDirectionEnable; }
            set
            {
                if (_isTradeDirectionEnable != value)
                {
                    _isTradeDirectionEnable = value;
                    Notify("IsTradeDirectionEnable");
                }
            }
        }

        public bool IsLotQuantityEnable
        {
            get { return _isLotQuantityEnable; }
            set
            {
                if (_isLotQuantityEnable != value)
                {
                    _isLotQuantityEnable = value;
                    Notify("IsLotQuantityEnable");
                }
            }
        }

        public bool IsCommodityEnable
        {
            get { return _isCommodityEnable; }
            set
            {
                if (_isCommodityEnable != value)
                {
                    _isCommodityEnable = value;
                    Notify("IsCommodityEnable");
                }
            }
        }

        private void LoadLMEPositionEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsLotQuantityEnable = true;
                IsPriceEnable = true;
                IsTradeDirectionEnable = true;
                IsCommodityEnable = true;
            }
            else
            {
                using (var lmePositionService =
                    SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
                {
                    LMEPositionEnableProperty lmepep = lmePositionService.SetElementsEnableProperty(id);
                    IsLotQuantityEnable = lmepep.IsLotQuantityEnable;
                    IsPriceEnable = lmepep.IsPriceEnable;
                    IsTradeDirectionEnable = lmepep.IsTradeDirectionEnable;
                    IsCommodityEnable = lmepep.IsCommodityEnable;
                }
            }
        }

        #endregion
    }
}