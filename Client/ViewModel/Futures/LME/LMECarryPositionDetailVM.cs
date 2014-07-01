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
    public class LMECarryPositionDetailVM : ObjectBaseVM
    {
        #region Member

        private decimal? _agentCommission;
        private decimal? _agentCommission2;
        private decimal? _agentPrice;
        private decimal? _agentPrice2;
        private string _bPartnerName;
        private string _bPartnerName2;
        private int? _brokerId;
        private int? _brokerId2;
        private List<BusinessPartner> _brokers;
        private int? _carryPositionId;
        private int? _carryPositionId2;
        private decimal? _clientCommission;
        private decimal? _clientCommission2;
        private decimal? _clientPrice;
        private decimal? _clientPrice2;
        private string _comment;
        private int? _icId;
        private List<BusinessPartner> _iCs;
        private decimal? _lotAmount;
        private List<Commodity> _metals;
        private int? _positionType;
        private int? _positionType2;
        private Dictionary<string, int> _positionTypes;
        private DateTime? _promptDate;
        private DateTime? _promptDate2;
        private string _quotaNo;
        private int? _selectedMetal;
        private DateTime? _tradeDate;

        private int? _tradeDirection;
        private int? _tradeDirection2;
        private Dictionary<string, int> _tradeDirections;

        private bool _isLMEAgent;
        private LMEPositionDetailVM _pVM;
        private int? _selectedBPartnerId;
        private int? _selectedBPartnerId2;
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

        public string BPartnerName2
        {
            get { return _bPartnerName2; }
            set
            {
                if (_bPartnerName2 != value)
                {
                    _bPartnerName2 = value;
                    Notify("BPartnerName2");
                }
            }
        }

        public int? SelectedBPartnerId2
        {
            get { return _selectedBPartnerId2; }
            set
            {
                if (_selectedBPartnerId2 != value)
                {
                    _selectedBPartnerId2 = value;
                    Notify("SelectedBPartnerId2");
                }
            }
        }

        public int? TradeDirection2
        {
            get { return _tradeDirection2; }
            set
            {
                if (_tradeDirection2 != value)
                {
                    _tradeDirection2 = value;
                    Notify("TradeDirection2");
                }
            }
        }

        public int? PositionType2
        {
            get { return _positionType2; }
            set
            {
                if (_positionType2 != value)
                {
                    _positionType2 = value;
                    Notify("PositionType2");
                }
            }
        }

        public DateTime? PromptDate2
        {
            get { return _promptDate2; }
            set
            {
                if (_promptDate2 != value)
                {
                    _promptDate2 = value;
                    Notify("PromptDate2");
                }
            }
        }

        public int? BrokerId2
        {
            get { return _brokerId2; }
            set
            {
                if (_brokerId2 != value)
                {
                    _brokerId2 = value;
                    Notify("BrokerId2");
                }
            }
        }

        public decimal? AgentPrice2
        {
            get { return _agentPrice2; }
            set
            {
                if (_agentPrice2 != value)
                {
                    _agentPrice2 = value;
                    Notify("AgentPrice2");
                }
            }
        }

        public decimal? ClientPrice2
        {
            get { return _clientPrice2; }
            set
            {
                if (_clientPrice2 != value)
                {
                    _clientPrice2 = value;
                    Notify("ClientPrice2");
                }
            }
        }

        public decimal? ClientCommission2
        {
            get { return _clientCommission2; }
            set
            {
                if (_clientCommission2 != value)
                {
                    _clientCommission2 = value;
                    Notify("ClientCommission2");
                }
            }
        }

        public decimal? AgentCommission2
        {
            get { return _agentCommission2; }
            set
            {
                if (_agentCommission2 != value)
                {
                    _agentCommission2 = value;
                    Notify("AgentCommission2");
                }
            }
        }

        public int? CarryPositionId
        {
            get { return _carryPositionId; }
            set
            {
                if (_carryPositionId != value)
                {
                    _carryPositionId = value;
                    Notify("CarryPositionId");
                }
            }
        }

        public int? CarryPositionId2
        {
            get { return _carryPositionId2; }
            set
            {
                if (_carryPositionId2 != value)
                {
                    _carryPositionId2 = value;
                    Notify("CarryPositionId2");
                }
            }
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

        #region Constructor

        public LMECarryPositionDetailVM()
        {
            ObjectId = 0;
            PropertyChanged += LMECarryPositionDetailVMPropertyChanged;
            Initialize();
            LoadLMEPositionEnableProperty(ObjectId);
        }

        public LMECarryPositionDetailVM(int id)
        {
            ObjectId = id;
            PropertyChanged += LMECarryPositionDetailVMPropertyChanged;
            Initialize();
            LoadLMEPositionEnableProperty(ObjectId);
        }

        #endregion

        #region Method

        protected void LMECarryPositionDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var position1 = new LMEPosition
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

            var position2 = new LMEPosition
            {
                QuotaId = SelectedQuotaId,
                InternalBPId = ICId,
                TradeDate = TradeDate,
                ClientId = SelectedBPartnerId,
                CommodityId = SelectedMetal,
                AgentId = BrokerId,
                PromptDate = PromptDate2,
                LotAmount = LotAmount,
                TradeDirection = TradeDirection2,
                PositionType = PositionType2,
                Comment = Comment,
                AgentPrice = AgentPrice2,
                ClientPrice = ClientPrice2,
                ClientCommission = ClientCommission2,
                AgentCommission = AgentCommission2,
            };

            if (e.PropertyName == "BPartnerName")
            {
                BPartnerName2 = BPartnerName;
            }
            if (e.PropertyName == "TradeDirection")
            {
                if (TradeDirection != null || TradeDirection > 0)
                {
                    if (TradeDirection == (int) PositionDirection.Long)
                    {
                        TradeDirection2 = (int) PositionDirection.Short;
                    }
                    else if (TradeDirection == (int) PositionDirection.Short)
                    {
                        TradeDirection2 = (int) PositionDirection.Long;
                    }
                }
            }
            if (e.PropertyName == "PositionType")
            {
                if (PositionType != null || PositionType > 0)
                {
                    PositionType2 = PositionType;
                }
            }

            decimal? commissionValue1 = 0;
            decimal? commissionValue2 = 0;
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                if (e.PropertyName == "TradeDate" || e.PropertyName == "PromptDate" || e.PropertyName == "PromptDate2" || e.PropertyName == "ICId" ||
                    e.PropertyName == "SelectedMetal" || e.PropertyName == "SelectedBPartnerId" ||
                    e.PropertyName == "ClientPrice" || e.PropertyName == "LotAmount" || e.PropertyName == "ClientPrice2")
                {
                    commissionService.GetCarryCommissionValue(position1, position2, SelectedBPartnerId, ClientPrice, ClientPrice2, ref commissionValue1, ref commissionValue2, CurrentUser.Id);
                    ClientCommission = commissionValue1;
                    ClientCommission2 = commissionValue2;
                }
                if (e.PropertyName == "TradeDate" || e.PropertyName == "PromptDate" || e.PropertyName == "PromptDate2" || e.PropertyName == "ICId" ||
                    e.PropertyName == "SelectedMetal" || e.PropertyName == "BrokerId" || e.PropertyName == "AgentPrice" || e.PropertyName == "AgentPrice2" ||
                    e.PropertyName == "LotAmount")
                {
                    commissionService.GetCarryCommissionValue(position1, position2, BrokerId, AgentPrice, AgentPrice2, ref commissionValue1, ref commissionValue2, CurrentUser.Id);
                    AgentCommission = commissionValue1;
                    AgentCommission2 = commissionValue2;
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
            using (
                var systemParameterService =
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

            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _iCs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                _iCs.Insert(0, new BusinessPartner {Id = 0, ShortName = ""});

                _brokers =
                    businessPartnerService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner {Id = 0, Name = ""});
            }
            _positionTypes = new Dictionary<string, int>();
            _positionTypes = EnumHelper.GetEnumDic<PositionType>(_positionTypes);
            _tradeDirections = new Dictionary<string, int>();
            _tradeDirections = EnumHelper.GetEnumDic<PositionDirection>(_tradeDirections);
            GetMetals();
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
                        SelectedQuotaId = lmePosition.QuotaId;
                        ICId = lmePosition.InternalBPId;
                        TradeDate = lmePosition.TradeDate;
                        BPartnerName = lmePosition.Client != null ? lmePosition.Client.ShortName : null;
                        SelectedBPartnerId = lmePosition.ClientId;
                        SelectedMetal = lmePosition.CommodityId;
                        BrokerId = lmePosition.AgentId;
                        PromptDate = lmePosition.PromptDate;
                        QuotaNo = lmePosition.Quota != null ? lmePosition.Quota.QuotaNo : null;
                        LotAmount = lmePosition.LotAmount;
                        TradeDirection = lmePosition.TradeDirection;
                        PositionType = lmePosition.PositionType;
                        Comment = lmePosition.Comment;
                        AgentPrice = lmePosition.AgentPrice;
                        ClientPrice = lmePosition.ClientPrice;
                        ClientCommission = lmePosition.ClientCommission;
                        AgentCommission = lmePosition.AgentCommission;

                        LMEPosition lmePosition2 = lmePositionService.Select("it.Id=" + (lmePosition.CarryPositionId ??0), null,
                                                                             new List<string>
                                                                                 {"Quota", "Agent", "Client", "InternalBP", "Commodity"}).
                            FirstOrDefault();
                        if (lmePosition2 != null)
                        {
                            PromptDate2 = lmePosition2.PromptDate;
                            TradeDirection2 = lmePosition2.TradeDirection;
                            PositionType2 = lmePosition2.PositionType;
                            AgentPrice2 = lmePosition2.AgentPrice;
                            SelectedBPartnerId2 = lmePosition2.ClientId;
                            BPartnerName2 = lmePosition2.Client != null ? lmePosition2.Client.ShortName : "";
                            BrokerId2 = lmePosition2.AgentId;
                            ClientPrice2 = lmePosition2.ClientPrice;
                            ClientCommission2 = lmePosition2.ClientCommission;
                            AgentCommission2 = lmePosition2.AgentCommission;
                        }
                    }
                }
            }
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Metals = metalService.GetCommoditiesByUser(CurrentUser.Id);
                Metals.Insert(0, new Commodity {Id = 0, Name = ""});
            }
        }

        protected override void Create()
        {
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
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
                var lmePosition2 = new LMEPosition
                                       {
                                           QuotaId = SelectedQuotaId,
                                           InternalBPId = ICId,
                                           TradeDate = TradeDate,
                                           ClientId = SelectedBPartnerId,
                                           CommodityId = SelectedMetal,
                                           AgentId = BrokerId,
                                           PromptDate = PromptDate2,
                                           LotAmount = LotAmount,
                                           TradeDirection = TradeDirection2,
                                           PositionType = PositionType2,
                                           Comment = Comment,
                                           AgentPrice = AgentPrice2,
                                           ClientPrice = ClientPrice2,
                                           ClientCommission = ClientCommission2,
                                           AgentCommission = AgentCommission2,
                                       };


                lmePositionService.CreateNewCarryLMEPosition(lmePosition, lmePosition2, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
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

                    LMEPosition lmePosition2 = lmePositionService.Select("it.Id=" + (lmePosition.CarryPositionId??0), null,
                                                                         new List<string>
                                                                             {"Quota", "Agent", "Client", "InternalBP", "Commodity"}).
                        FirstOrDefault();
                    if (lmePosition2 != null)
                    {
                        lmePosition2.QuotaId = SelectedQuotaId;
                        lmePosition2.InternalBPId = ICId;
                        lmePosition2.TradeDate = TradeDate;
                        lmePosition2.ClientId = SelectedBPartnerId;
                        lmePosition2.CommodityId = SelectedMetal;
                        lmePosition2.AgentId = BrokerId;
                        lmePosition2.PromptDate = PromptDate2;
                        lmePosition2.LotAmount = LotAmount;
                        lmePosition2.TradeDirection = TradeDirection2;
                        lmePosition2.PositionType = PositionType2;
                        lmePosition2.Comment = Comment;
                        lmePosition2.AgentPrice = AgentPrice2;
                        lmePosition2.ClientPrice = ClientPrice2;
                        lmePosition2.ClientCommission = ClientCommission2;
                        lmePosition2.AgentCommission = AgentCommission2;
                    }
                    lmePositionService.UpdateCarryLMEPosition(lmePosition, lmePosition2, CurrentUser.Id);
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
            if (PromptDate == null || PromptDate2 == null)
            {
                throw new Exception(ResLME.PromptDateNotNull);
            }
            if (TradeDirection < 0 || TradeDirection == null)
            {
                throw new Exception(ResLME.TradeDirectionNotNull);
            }
            if (PositionType < 0 || PositionType == null)
            {
                throw new Exception(ResLME.TradeTypeNotNull);
            }
            if (ICId < 0 || ICId == null)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }
            if (BrokerId < 0 || BrokerId == null || BrokerId2 < 0 || BrokerId2 == null)
            {
                throw new Exception(Properties.Resources.BrokerRequired);
            }
            if (AgentPrice < 0 || AgentPrice == null || AgentPrice2 < 0 || AgentPrice2 == null)
            {
                throw new Exception(ResLME.BrokerPriceNotNull);
            }
            if (AgentCommission < 0 || AgentCommission == null || AgentCommission2 < 0 || AgentCommission2 == null)
            {
                throw new Exception(ResLME.BrokerCommissionNotNull);
            }
            if (TradeDate > PromptDate || TradeDate > PromptDate2)
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