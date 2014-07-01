using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using System.Windows.Data;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Reports
{
    public class PhysicalAndFuturesReportVM : BaseVM
    {
        #region Member

        private DateTime? _startDate;
        private DateTime _endDate;
        private List<Commodity> _commodities;
        private List<BusinessPartner> _internalCustomers;
        private int _selectedCommodityId;
        private int _selectedInternalCustomerId;
        private List<PhysicalPNLClass> _domesticPhysicalPNLItemList = new List<PhysicalPNLClass>();
        private List<PhysicalPNLClass> _externalPhysicalPNLItemList = new List<PhysicalPNLClass>();
        private SHFEPositionPLReportVM _shfePositionPlReportVM;
        private LMEPositionPLReportVM _lmePositionPlReportVM;
        private readonly List<LmePNLItem> _listLme = new List<LmePNLItem>();
        private ListCollectionView _listLmeView;
        private ListCollectionView _listTDView;

        #endregion

        #region Property

        public ListCollectionView ListLmeView
        {
            get { return _listLmeView; }
            set
            {
                if (_listLmeView != value)
                {
                    _listLmeView = value;
                    Notify("ListLmeView");
                }
            }
        }

        public ListCollectionView ListTDView
        {
            get { return _listTDView; }
            set
            {
                if (_listTDView != value)
                {
                    _listTDView = value;
                    Notify("ListTDView");
                }
            }
        }

        public SHFEPositionPLReportVM SHFEPositionPLReportVM
        {
            get { return _shfePositionPlReportVM; }
            set
            {
                if (_shfePositionPlReportVM != value)
                {
                    _shfePositionPlReportVM = value;
                    Notify("SHFEPositionPLReportVM");
                }
            }
        }

        public LMEPositionPLReportVM LMEPositionPLReportVM
        {
            get { return _lmePositionPlReportVM; }
            set
            {
                if (_lmePositionPlReportVM != value)
                {
                    _lmePositionPlReportVM = value;
                    Notify("LMEPositionPLReportVM");
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

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
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

        public DateTime EndDate
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

        public int SelectedInternalCustomerId
        {
            get { return _selectedInternalCustomerId; }
            set
            {
                if (_selectedInternalCustomerId != value)
                {
                    _selectedInternalCustomerId = value;
                    Notify("SelectedInternalCustomerId");
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

        public List<PhysicalPNLClass> DomesticPhysicalPNLItemList
        {
            get { return _domesticPhysicalPNLItemList; }
            set
            {
                _domesticPhysicalPNLItemList = value;
                Notify("DomesticPhysicalPNLItemList");
            }
        }

        public List<PhysicalPNLClass> ExternalPhysicalPNLItemList
        {
            get { return _externalPhysicalPNLItemList; }
            set
            {
                _externalPhysicalPNLItemList = value;
                Notify("ExternalPhysicalPNLItemList");
            }
        }

        public List<Commodity> SelectedCommodityList { get; set; }

        #endregion

        #region Constructor

        public PhysicalAndFuturesReportVM()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetAll();
                _commodities.Insert(0, new Commodity());
            }
            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                if (_internalCustomers != null && _internalCustomers.Count > 0)
                    _selectedInternalCustomerId = _internalCustomers[0].Id;
            }
            _endDate = DateTime.Today;
        }

        #endregion

        #region Method

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            if (EndDate == null)
            {
                throw new Exception(Properties.Resources.EndDateRequired);
            }

            return true;
        }

        /// <summary>
        /// 查询金属列表
        /// </summary>
        /// <returns></returns>
        private void GetCommodityList()
        {
            if (SelectedCommodityId == 0)
                SelectedCommodityList = _commodities;
            else
            {
                SelectedCommodityList = new List<Commodity>();
                SelectedCommodityList.AddRange(_commodities.Where(c => c.Id == SelectedCommodityId).ToList());
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void Load()
        {
            Validate();
            GetCommodityList();
            LoadSHFE();
            LoadLME();
            //GetPhysicalPNLItemList();
            //GetPhysicalPNLItemListNew();
            GetPhysicalPNLData();
        }

        /// <summary>
        /// SHFE盈亏
        /// </summary>
        private void LoadSHFE()
        {
            SHFEPositionPLReportVM = new SHFEPositionPLReportVM
                                         {
                                             StartDate = StartDate,
                                             EndDate = EndDate,
                                             SelectedCommodityId = SelectedCommodityId,
                                             SelectedInternalCustomerId = SelectedInternalCustomerId
                                         };
            SHFEPositionPLReportVM.Load();
        }

        /// <summary>
        /// LME盈亏
        /// </summary>
        private void LoadLME()
        {
            _listLme.Clear();
            ListLmeView = null;
            foreach (var commodity in SelectedCommodityList)
            {
                int commodityId = commodity.Id;
                if (commodityId == 0)
                    continue;
                string commodityName = commodity.Name;
                LMEPositionPLReportVM = new LMEPositionPLReportVM
                                            {
                                                SettleDate = EndDate,
                                                SelectedCommodityId = commodityId,
                                                SelectedInternalCustomerId = SelectedInternalCustomerId
                                            };
                LMEPositionPLReportVM.Load();
                List<LmePNLItem> list = ConvertLMESummaries2LmePNLItem(LMEPositionPLReportVM.Summaries, commodityName);
                if (list != null && list.Count > 0)
                {
                    _listLme.AddRange(list);
                }
            }
            if (_listLme.Count > 0)
            {
                decimal tempDuedLockedPL = 0;
                decimal tempUnduedLockedPL = 0;
                decimal tempUnduedFloatPL = 0;
                decimal tempSumPL = 0;

                foreach (var item in _listLme)
                {
                    tempDuedLockedPL += item.DuedLockedPL;
                    tempUnduedLockedPL += item.UnduedLockedPL;
                    tempUnduedFloatPL += item.UnduedFloatPL;
                    tempSumPL += item.SumPL;

                }
                decimal sumDuedLockedPL = tempDuedLockedPL;
                decimal sumUnduedLockedPL = tempUnduedLockedPL;
                decimal sumUnduedFloatPL = tempUnduedFloatPL;
                decimal sumSumPL = tempSumPL;
               
                var sum = new LmePNLItem
                              {
                                  CommodityName = Properties.Resources.Summary,
                                  DuedLockedPL = sumDuedLockedPL,
                                  UnduedLockedPL = sumUnduedLockedPL,
                                  UnduedFloatPL = sumUnduedFloatPL,
                                  SumPL = sumSumPL
                              };
                _listLme.Add(sum);
                ListLmeView = new ListCollectionView(_listLme);
                if (ListLmeView.GroupDescriptions != null)
                    ListLmeView.GroupDescriptions.Add(new PropertyGroupDescription("CommodityName"));
            }
        }

        private List<LmePNLItem> ConvertLMESummaries2LmePNLItem(List<BrokerPLSummaryLineVM> list, string commodityName)
        {
            var lmePnlItems = new List<LmePNLItem>();

            if (list != null && list.Count > 0)
            {
                lmePnlItems.AddRange(list.Select(item => new LmePNLItem
                                                             {
                                                                 CommodityName = commodityName,
                                                                 BrokerName = item.BrokerName,
                                                                 DuedLockedPL = item.DuedLockedPL,
                                                                 UnduedLockedPL = item.UnduedLockedPL,
                                                                 UnduedFloatPL = item.UnduedFloatPL,
                                                                 SumPL = item.SumPL
                                                             }));
            }

            return lmePnlItems;
        }

        private void GetPhysicalPNLData()
        {
            _domesticPhysicalPNLItemList.Clear();
            _externalPhysicalPNLItemList.Clear();
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quotaService.GetPhysicalPNLData(StartDate, EndDate, SelectedCommodityId, SelectedInternalCustomerId, SelectedCommodityList, CurrentUser.Id, ref _domesticPhysicalPNLItemList, ref _externalPhysicalPNLItemList);
            }
        }

        #endregion
    }

    public class LmePNLItem
    {
        public string CommodityName { get; set; }
        public string BrokerName { get; set; }
        public decimal DuedLockedPL { get; set; }
        public decimal UnduedLockedPL { get; set; }
        public decimal UnduedFloatPL { get; set; }
        public decimal SumPL { get; set; }
    }

    public class TdPNLItem
    {
        /// <summary>
        /// 经纪行
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 金属
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 成交公斤
        /// </summary>
        public decimal? LotWeight { get; set; }

        /// <summary>
        /// 盈亏
        /// </summary>
        public decimal? PNL { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Commission { get; set; }

        /// <summary>
        /// 递延费
        /// </summary>
        public decimal? DelayFee { get; set; }
    }
}
