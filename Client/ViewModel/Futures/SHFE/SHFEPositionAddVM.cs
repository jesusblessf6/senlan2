using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.SHFEPositionServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.SHFE
{
    public class SHFEPositionAddVM : ObjectBaseVM
    {
        #region Member

        private string _alias;
        private List<BusinessPartner> _brokers;
        private string _comment;
        private decimal? _commission;
        private List<Commodity> _commodities;
        private int _direction;
        private List<BusinessPartner> _innerCustomer;
        private decimal? _lotQuantity;
        private int _openClose;
        private decimal? _pnl;
        private List<EnumItem> _positionDirections;
        private List<EnumItem> _positionOpenClose;
        private List<EnumItem> _positionTypes;
        private decimal? _price;
        private int _selectShfeId;
        private int _selectedBrokerId;
        private int _selectedCommodityId;
        private int _selectedInnerCustomer;
        private List<DBEntity.SHFE> _shfes;
        private DateTime? _tradeDate;
        private int _type;

        #endregion

        #region Property

        /// <summary>
        /// 选择的经纪行
        /// </summary>
        public int SelectedBrokerId
        {
            get { return _selectedBrokerId; }
            set
            {
                if (_selectedBrokerId != value)
                {
                    _selectedBrokerId = value;
                    Notify("SelectedBrokerId");
                }
            }
        }

        /// <summary>
        /// 选择的内部客户
        /// </summary>
        public int SelectedInnerCustomer
        {
            get { return _selectedInnerCustomer; }
            set
            {
                if (_selectedInnerCustomer != value)
                {
                    _selectedInnerCustomer = value;
                    Notify("SelectedInnerCustomer");
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

        public List<BusinessPartner> InnerCustomer
        {
            get { return _innerCustomer; }
            set
            {
                if (_innerCustomer != value)
                {
                    _innerCustomer = value;
                    Notify("InnerCustomer");
                }
            }
        }

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                if (_commodities != value)
                {
                    _commodities = value;
                    Notify("Commodities");
                }
            }
        }

        public int SelectedCommodityId
        {
            get { return _selectedCommodityId; }
            set
            {
                if (_selectedCommodityId != value)
                {
                    _selectedCommodityId = value;
                    Notify("SelectedCommodityId");
                }
            }
        }

        /// <summary>
        /// 手数
        /// </summary>
        public decimal? LotQuantity
        {
            get { return _lotQuantity; }
            set
            {
                if (_lotQuantity != value)
                {
                    _lotQuantity = value;
                    Notify("LotQuantity");
                }
            }
        }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify("Price");
                }
            }
        }

        /// <summary>
        /// 交易方向集合
        /// </summary>
        public List<EnumItem> PositionDirections
        {
            get { return _positionDirections; }
            set
            {
                if (_positionDirections != value)
                {
                    _positionDirections = value;
                    Notify("PositionDirections");
                }
            }
        }

        public int Direction
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    Notify("Direction");
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

        public List<DBEntity.SHFE> SHFEs
        {
            get { return _shfes; }
            set
            {
                if (_shfes != value)
                {
                    _shfes = value;
                    Notify("SHFEs");
                }
            }
        }

        public int SelectShfeId
        {
            get { return _selectShfeId; }
            set
            {
                if (_selectShfeId != value)
                {
                    _selectShfeId = value;
                    Notify("SelectShfeId");
                }
            }
        }

        public List<EnumItem> PositionOpenClose
        {
            get { return _positionOpenClose; }
            set
            {
                if (_positionOpenClose != value)
                {
                    _positionOpenClose = value;
                    Notify("PositionOpenClose");
                }
            }
        }

        public int OpenClose
        {
            get { return _openClose; }
            set
            {
                if (_openClose != value)
                {
                    _openClose = value;
                    Notify("OpenClose");
                }
            }
        }

        public List<EnumItem> PositionTypes
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

        public int Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    Notify("Type");
                }
            }
        }

        public decimal? Commission
        {
            get { return _commission; }
            set
            {
                if (_commission != value)
                {
                    _commission = value;
                    Notify("Commission");
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

        public decimal? PNL
        {
            get { return _pnl; }
            set
            {
                if (_pnl != value)
                {
                    _pnl = value;
                    Notify("PNL");
                }
            }
        }

        public string Alias
        {
            get { return _alias; }
            set
            {
                if (_alias != value)
                {
                    _alias = value;
                    Notify("Alias");
                }
            }
        }

        #endregion

        #region Constructor

        public SHFEPositionAddVM()
        {
            LoadData();
        }

        public SHFEPositionAddVM(int id)
        {
            LoadData();
            LoadSHFEPostion(id);
        }

        #endregion

        #region Method

        private void LoadData()
        {
            LoadBroker();
            LoadInnerCustomer();
            LoadCommodity();
            LoadDirections();
            LoadPostionOpenClose();
            LoadPositionTypes();
        }

        /// <summary>
        /// 获取经纪行
        /// </summary>
        private void LoadBroker()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                _brokers = busService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner {Id = 0, Name = string.Empty});
            }
        }

        /// <summary>
        /// 获取内部客户
        /// </summary>
        private void LoadInnerCustomer()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                _innerCustomer = busService.GetInternalCustomersByUser(CurrentUser.Id);
                _innerCustomer.Insert(0, new BusinessPartner {Id = 0, Name = string.Empty});
            }
        }

        /// <summary>
        /// 获得金属
        /// </summary>
        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
            }
            _commodities.Insert(0, new Commodity {Id = 0, Name = string.Empty});
        }

        private void LoadDirections()
        {
            _positionDirections = EnumHelper.GetEnumList<PositionDirection>();
            _positionDirections.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
        }

        private void LoadPostionOpenClose()
        {
            _positionOpenClose = EnumHelper.GetEnumList<PositionOpenClose>();
            _positionOpenClose.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
        }

        private void LoadPositionTypes()
        {
            _positionTypes = EnumHelper.GetEnumList<PositionType>();
            _positionTypes.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
        }

        private void LoadSHFEPostion(int id)
        {
            using (
                var shfePositionService =
                    SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                SHFEPosition position = shfePositionService.GetSHFEPositionById(id);
                SelectedBrokerId = position.SHFECapitalDetail.AgentId.HasValue
                                       ? position.SHFECapitalDetail.AgentId.Value
                                       : 0;
                SelectedInnerCustomer = position.SHFECapitalDetail.InternalBPId.HasValue
                                            ? position.SHFECapitalDetail.InternalBPId.Value
                                            : 0;
                SelectedCommodityId = position.CommodityId.HasValue ? position.CommodityId.Value : 0;
                LotQuantity = position.LotQuantity;
                Price = position.Price;
                Direction = position.PositionDirection.HasValue ? position.PositionDirection.Value : 0;
                TradeDate = position.SHFECapitalDetail.TradeDate;
                //LoadSHFEs();
                OpenClose = position.OpenClose.HasValue ? position.OpenClose.Value : 0;
                Type = position.PositionType.HasValue ? position.PositionType.Value : 0;
                Commission = position.Commission;
                PNL = position.PNL;
                Comment = position.Comment;
                Alias = position.Alias;
                if (position.SHFEId != null) SelectShfeId = position.SHFEId.Value;
            }
        }

        #endregion
    }
}