using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.LME
{
    public class LMEPositionHomeVM : BaseVM
    {
        #region Member

        private string _bPartnerName;
        private int? _brokerId;
        private List<BusinessPartner> _brokers;
        private DateTime? _endPromptDate;
        private DateTime? _endTradeDate;
        private int? _icId;
        private List<BusinessPartner> _iCs;
        private LMEPositionListVM _listVM;
        private List<Commodity> _metals;
        private int? _selectedMetal;
        private DateTime? _startPromptDate;
        private DateTime? _startTradeDate;
        private LMEPositionHomeVM _vm;
        private int? _selectedBPartnerId;

        #endregion

        #region Property

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

        public LMEPositionListVM ListVM
        {
            get { return _listVM; }
            set
            {
                if (_listVM != value)
                {
                    _listVM = value;
                    Notify("ListVM");
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


        public LMEPositionHomeVM VM
        {
            get { return _vm; }
            set
            {
                if (_vm != value)
                {
                    _vm = value;
                    Notify("VM");
                }
            }
        }

        #endregion

        #region Constructor

        public LMEPositionHomeVM()
        {
            ObjectId = 0;
            Initialize();
        }

        #endregion

        public void Initialize()
        {
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

            GetMetals();
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Metals = metalService.GetCommoditiesByUser(CurrentUser.Id);
                Metals.Insert(0, new Commodity {Id = 0, Name = ""});
            }
        }

        public void Load()
        {
            ListVM = new LMEPositionListVM
                         {
                             ICId = ICId,
                             SelectedBPartnerId = SelectedBPartnerId,
                             BrokerId = BrokerId,
                             SelectedMetal = SelectedMetal,
                             StartTradeDate = StartTradeDate,
                             EndTradeDate = EndTradeDate,
                             StartPromptDate = StartPromptDate,
                             EndPromptDate = EndPromptDate
                         };
            ListVM.Init();
        }
    }
}