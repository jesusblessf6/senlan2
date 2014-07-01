using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.SHFEPositionServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class SHFEPositionPLReportVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _brokers;
        private List<Commodity> _commodities;
        private DateTime _endDate;
        private List<BusinessPartner> _internalCustomers;
        private List<SHFEHoldingPositionPNL> _shfeHoldingPositionPNLList;
        private ListCollectionView _shfeHoldingPositionPNLView;
        private int _selectedBrokerId;
        private int _selectedCommodityId;
        private int _selectedInternalCustomerId;
        private List<SHFEPositionPNL> _shfePositionPNLList;
        private ListCollectionView _shfePositionPNLView;
        private DateTime? _startDate;

        #endregion

        #region Property

        public List<SHFEPositionPNL> SHFEPositionPNLList
        {
            get { return _shfePositionPNLList; }
            set
            {
                _shfePositionPNLList = value;
                Notify("SHFEPositionPNLList");
            }
        }

        public ListCollectionView ShfePositionPNLView
        {
            get { return _shfePositionPNLView; }
            set
            {
                _shfePositionPNLView = value;
                Notify("ShfePositionPNLView");
            }
        }

        public List<SHFEHoldingPositionPNL> SHFEHoldingPositionPNLList
        {
            get { return _shfeHoldingPositionPNLList; }
            set
            {
                _shfeHoldingPositionPNLList = value;
                Notify("SHFEHoldingPositionPNLList");
            }
        }

        public ListCollectionView SHFEHoldingPositionPNLView
        {
            get { return _shfeHoldingPositionPNLView; }
            set
            {
                _shfeHoldingPositionPNLView = value;
                Notify("SHFEHoldingPositionPNLView");
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

        public List<BusinessPartner> Brokers
        {
            get { return _brokers; }
            set
            {
                _brokers = value;
                Notify("Brokers");
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

        public List<SHFECapitalDetail> SHFECapitalDetailList { get; set; }

        #endregion

        #region Constructor

        public SHFEPositionPLReportVM()
        {
            //load commodities combo
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetAll();
                _commodities.Insert(0, new Commodity());
            }

            //load brokers and internal customers
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _brokers = bpService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner());

                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
            }

            //set end date to today as default
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
            if (EndDate == null)
            {
                throw new Exception(Properties.Resources.EndDateRequired);
            }

            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            return true;
        }

        public void Load()
        {
            Validate();
            GetSHFECapitalDetailList();
            FillGrid();
        }

        /// <summary>
        /// 查询SHFE资金状况列表
        /// </summary>
        /// <returns></returns>
        public void GetSHFECapitalDetailList()
        {
            using (var shfeService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                SHFECapitalDetailList = shfeService.GetSHFECapitalDetailList(SelectedBrokerId,
                                                                             SelectedInternalCustomerId, StartDate,
                                                                             EndDate);
            }
        }

        /// <summary>
        /// 显示表格数据
        /// </summary>
        private void FillGrid()
        {
            SHFEPositionPNLList = new List<SHFEPositionPNL>();
            SHFEHoldingPositionPNLList = new List<SHFEHoldingPositionPNL>();
            if (SHFECapitalDetailList != null && SHFECapitalDetailList.Count > 0)
            {
                List<Commodity> commodityList = GetCommodityList();
                IEnumerable<IGrouping<int?, SHFECapitalDetail>> groups = SHFECapitalDetailList.GroupBy(h => h.AgentId);
                foreach (var group in groups.ToList())
                {
                    decimal sumClosePNL = 0; //平仓盈亏小计
                    decimal sumFloatPNL = 0; //浮动盈亏小计
                    decimal sumCommission = 0; //佣金小计
                    decimal sumPNL = 0; //总盈亏小计
                    decimal sumBuyHolding = 0; //买持仓小计
                    decimal sumSellHolding = 0; //卖持仓小计
                    decimal sumPNLHolding = 0; //持仓浮动盈亏小计

                    #region 盈亏统计

                    List<SHFECapitalDetail> cList = group.ToList();
                    DateTime? maxTradeDate = cList.Max(i => i.TradeDate);
                    string brokerName = cList[0].BusinessPartner.ShortName;

                    foreach (Commodity c in commodityList)
                    {
                        var clocal = c;
                        var sPNL = new SHFEPositionPNL {BrokerName = brokerName, CommodityName = c.Name};
                        decimal closePNL = 0;
                        decimal floatPNL = 0;
                        decimal commission = 0;

                        foreach (SHFECapitalDetail sh in cList)
                        {
                            List<SHFEPosition> pList =
                                sh.SHFEPositions.Where(
                                    h => h.CommodityId == clocal.Id && h.IsDeleted == false && h.IsDraft == false).ToList();
                            closePNL += pList.Sum(i => i.PNL == null ? 0 : (decimal) i.PNL);
                            commission += pList.Sum(i => i.Commission == null ? 0 : (decimal) i.Commission);
                            if (sh.TradeDate == maxTradeDate)
                                floatPNL +=
                                    sh.SHFEHoldingPositions.Where(
                                        h => h.CommodityId == clocal.Id && h.IsDeleted == false && h.IsDraft == false).Sum(
                                            i => i.PNL == null ? 0 : (decimal) i.PNL);
                        }

                        sPNL.ClosePNL = closePNL; //平仓盈亏
                        sPNL.FloatPNL = floatPNL; //浮动盈亏
                        sPNL.Commission = commission; //佣金
                        sPNL.PNL = closePNL + floatPNL - commission; //总盈亏
                        SHFEPositionPNLList.Add(sPNL);

                        sumClosePNL += closePNL;
                        sumFloatPNL += floatPNL;
                        sumCommission += commission;
                        sumPNL += sPNL.PNL;
                    }

                    //小计
                    var footSHFE = new SHFEPositionPNL
                                       {
                                           BrokerName = brokerName,
                                           CommodityName = Properties.Resources.Summary,
                                           ClosePNL = sumClosePNL,
                                           FloatPNL = sumFloatPNL,
                                           Commission = sumCommission,
                                           PNL = sumPNL
                                       };
                    SHFEPositionPNLList.Add(footSHFE);

                    #endregion

                    #region 持仓统计

                    List<SHFECapitalDetail> hList =
                        cList.Where(h => h.TradeDate == maxTradeDate && h.IsDeleted == false && h.IsDraft == false).
                            ToList();
                    SHFECapitalDetail maxSHFECapitalDetail = hList[0];
                    List<SHFEHoldingPosition> holdingList = SelectedCommodityId == 0
                                                                ? maxSHFECapitalDetail.SHFEHoldingPositions.ToList()
                                                                : maxSHFECapitalDetail.SHFEHoldingPositions.Where(
                                                                    h => h.CommodityId == SelectedCommodityId).
                                                                      ToList();
                    foreach (SHFEHoldingPosition sh in holdingList)
                    {
                        var sp = new SHFEHoldingPositionPNL
                                     {
                                         BrokerName = brokerName,
                                         Alias = sh.Alias,
                                         TradeDirection =
                                             sh.PositionDirection == (int) PositionDirection.Long ? Properties.Resources.Long : Properties.Resources.Short,
                                         BuyQty = sh.PositionDirection == (int) PositionDirection.Long ? sh.LotQuantity : 0,
                                         BuyPrice = sh.PositionDirection == (int) PositionDirection.Long ? sh.Price : 0,
                                         SellQty =
                                             sh.PositionDirection == (int) PositionDirection.Long ? 0 : sh.LotQuantity,
                                         SellPrice = sh.PositionDirection == (int) PositionDirection.Long ? 0 : sh.Price,
                                         SettlementPrice = sh.TodaySettlementPrice,
                                         PNL = sh.PNL
                                     };
                        SHFEHoldingPositionPNLList.Add(sp);

                        sumBuyHolding += sp.BuyQty ?? 0;
                        sumSellHolding += sp.SellQty ?? 0;
                        sumPNLHolding += sp.PNL ?? 0;
                    }

                    //小计
                    var footHolding = new SHFEHoldingPositionPNL
                                          {
                                              BrokerName = brokerName,
                                              Alias = Properties.Resources.Summary,
                                              BuyQty = sumBuyHolding,
                                              SellQty = sumSellHolding,
                                              PNL = sumPNLHolding
                                          };
                    SHFEHoldingPositionPNLList.Add(footHolding);

                    #endregion
                }
            }
            ShfePositionPNLView = new ListCollectionView(SHFEPositionPNLList);
            if (ShfePositionPNLView.GroupDescriptions != null)
                ShfePositionPNLView.GroupDescriptions.Add(new PropertyGroupDescription("BrokerName"));
            SHFEHoldingPositionPNLView = new ListCollectionView(SHFEHoldingPositionPNLList);
            if (SHFEHoldingPositionPNLView.GroupDescriptions != null)
                SHFEHoldingPositionPNLView.GroupDescriptions.Add(new PropertyGroupDescription("BrokerName"));
        }

        /// <summary>
        /// 查询金属列表
        /// </summary>
        /// <returns></returns>
        private List<Commodity> GetCommodityList()
        {
            var commodityList = new List<Commodity>();
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                if (SelectedCommodityId == 0)
                    commodityList = commodityService.GetAll();
                else
                {
                    Commodity comm = commodityService.GetById(SelectedCommodityId);
                    commodityList.Add(comm);
                }
            }
            return commodityList;
        }

        #endregion
    }

    public class SHFEPositionPNL
    {
        public string BrokerName { get; set; }
        public string CommodityName { get; set; }
        public decimal ClosePNL { get; set; }
        public decimal FloatPNL { get; set; }
        public decimal Commission { get; set; }
        public decimal PNL { get; set; }
    }

    public class SHFEHoldingPositionPNL
    {
        public string BrokerName { get; set; }
        public string Alias { get; set; }
        public string TradeDirection { get; set; }
        public decimal? BuyQty { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? SellQty { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? SettlementPrice { get; set; }
        public decimal? PNL { get; set; }
    }
}