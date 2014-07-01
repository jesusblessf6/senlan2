using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.SHFE
{
    public class SHFEPositionHomeVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _brokers;
        private List<Commodity> _commodities;
        private DateTime? _endPromptDate;
        private DateTime? _endTradeDate;
        private List<BusinessPartner> _innerCustomer;
        private int _selectedBrokerId;
        private int _selectedCommodityId;
        private int _selectedInnerCustomer;
        private DateTime? _startPromptDate;
        private DateTime? _startTradeDate;

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

        public DateTime? StartTradeDate
        {
            get { return _startTradeDate; }
            set
            {
                if (_startTradeDate != value)
                {
                    _startTradeDate = value;
                    Notify("StartTradeDate");
                }
            }
        }

        public DateTime? EndTradeDate
        {
            get { return _endTradeDate; }
            set
            {
                if (_endTradeDate != value)
                {
                    _endTradeDate = value;
                    Notify("EndTradeDate");
                }
            }
        }

        public DateTime? StartPromptDate
        {
            get { return _startPromptDate; }
            set
            {
                if (_startPromptDate != value)
                {
                    _startPromptDate = value;
                    Notify("StartPromptDate");
                }
            }
        }

        public DateTime? EndPromptDate
        {
            get { return _endPromptDate; }
            set
            {
                if (_endPromptDate != value)
                {
                    _endPromptDate = value;
                    Notify("EndPromptDate");
                }
            }
        }

        #endregion

        #region Constructor

        public SHFEPositionHomeVM()
        {
            LoadData();
        }

        #endregion

        #region Method

        private void LoadData()
        {
            LoadBroker();
            LoadInnerCustomer();
            LoadCommodity();
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

        #endregion
    }
}