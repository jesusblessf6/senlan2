using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.LMEPositionServiceReference;
using Client.MarketPriceServiceReference;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class LMEPositionPLReportVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _brokers;
        private List<Commodity> _commodities;
        private List<BrokerPLDetailLineVM> _duedLockedDetails;
        private List<BusinessPartner> _internalCustomers;
        private int _selectedBrokerId;
        private int _selectedCommodityId;
        private int _selectedInternalCustomerId;
        private List<BrokerPLSummaryLineVM> _summaries;
        private List<BrokerPLDetailLineVM> _unduedFloatDetails;
        private List<BrokerPLDetailLineVM> _unduedLockedDetails;
        private DateTime? _settleDate;
        private decimal _ploftheday;
        private decimal _ploflastday;
        private decimal _closingPL;

        #endregion

        #region Property

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

        public List<BrokerPLSummaryLineVM> Summaries
        {
            get { return _summaries; }
            set
            {
                _summaries = value;
                Notify("Summaries");
            }
        }

        public List<BrokerPLDetailLineVM> DuedLockedDetails
        {
            get { return _duedLockedDetails; }
            set
            {
                _duedLockedDetails = value;
                Notify("DuedLockedDetails");
            }
        }

        public List<BrokerPLDetailLineVM> UnduedLockedDetails
        {
            get { return _unduedLockedDetails; }
            set
            {
                _unduedLockedDetails = value;
                Notify("UnduedLockedDetails");
            }
        }

        public List<BrokerPLDetailLineVM> UnduedFloatDetails
        {
            get { return _unduedFloatDetails; }
            set
            {
                _unduedFloatDetails = value;
                Notify("UnduedFloatDetails");
            }
        }

        public DateTime? SettleDate
        {
            get { return _settleDate; }
            set
            {
                if(_settleDate != value)
                {
                    _settleDate = value;
                    Notify("SettleDate");
                }
            }
        }

        public string QueryStrForUndued { get; set; }
        public string QueryStrForDued { get; set; }
        public List<object> Parameters { get; set; }
        public List<LMEPosition> DuedPositions { get; set; }
        public List<LMEPosition> UnduedPositions { get; set; }

        public decimal ClosingPL
        {
            get { return _closingPL; }
            set
            {
                if(_closingPL != value)
                {
                    _closingPL = value;
                    Notify("ClosingPL");
                }
            }
        }

        #endregion

        #region Constructor

        public LMEPositionPLReportVM()
        {
            //load commodities combo
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }

            //load brokers and internal customers
            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _brokers = bpService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner());

                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }

            //set start date to today as default
            _settleDate = DateTime.Today;
        }

        #endregion

        #region Method

        public void Load()
        {
            Validate();
            BuildQueryStrAndParam();

            //Load the initial date
            using (var lmeService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
            {
                DuedPositions = lmeService.GetDuedPositionSummary(QueryStrForDued, Parameters,
                                                                  new List<string> { "Agent", "Commodity" });
                UnduedPositions = lmeService.Select(QueryStrForUndued, Parameters,
                                                    new List<string> { "Agent" });
            }

            FillGrid();
        }

        public void CalculateClosingPL()
        {
            //Calculate closing pl
            _ploftheday = Summaries.Sum(o => o.DuedLockedPL + o.UnduedLockedPL);
            var vm = new LMEPositionPLReportVM
            {
                SelectedBrokerId = SelectedBrokerId,
                SelectedCommodityId = SelectedCommodityId,
                SettleDate = (SettleDate??DateTime.Today).AddDays(-1),
                SelectedInternalCustomerId = SelectedInternalCustomerId
            };
            vm.Load();
            _ploflastday = vm.Summaries.Sum(o => o.DuedLockedPL + o.UnduedLockedPL);
            ClosingPL = _ploftheday - _ploflastday;
        }

        /// <summary>
        /// Validate the search conditions
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (SelectedCommodityId == 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }

            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            if(SettleDate == null)
            {
                throw new Exception(ResReport.SettleDateRequired);
            }

            if(SettleDate > DateTime.Today)
            {
                throw new Exception(ResReport.SettleDateLimit);
            }

            return true;
        }

        /// <summary>
        /// Build Up Query string and Parameters
        /// </summary>
        private void BuildQueryStrAndParam()
        {
            //build condition and parameters
            var sbForDued = new StringBuilder();
            sbForDued.AppendFormat("it.CommodityId = @p1 and it.InternalBPId = @p2 and it.TradeDate <= @p3");
            Parameters = new List<object> { SelectedCommodityId, SelectedInternalCustomerId, SettleDate };

            int i = 4;
            if (SelectedBrokerId != 0)
            {
                sbForDued.AppendFormat(" and it.AgentId = @p{0}", i++);
                Parameters.Add(SelectedBrokerId);
            }

            var sbForUndued = new StringBuilder(sbForDued.ToString());

            sbForUndued.AppendFormat(" and it.PromptDate > @p{0}", i);
            sbForDued.AppendFormat(" and it.PromptDate <= @p{0}", i);
            Parameters.Add(SettleDate);

            QueryStrForDued = sbForDued.ToString();
            QueryStrForUndued = sbForUndued.ToString();
        }

        /// <summary>
        /// Fill the Summary Grid
        /// </summary>
        private void FillGrid()
        {
            var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc);
            Commodity comm = commodityService.GetById(SelectedCommodityId);
            int? unit = comm.LMEQtyPerHand;
            var priceService = SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc);
            decimal price = priceService.GetLMELatestPrice(comm);

            var summaries = new List<BrokerPLSummaryLineVM>();
            var duedLockedDetails = new List<BrokerPLDetailLineVM>();
            var unduedLockedDetails = new List<BrokerPLDetailLineVM>();
            var unduedFloatDetails = new List<BrokerPLDetailLineVM>();

            //Dued
            var brokerGroups = DuedPositions.GroupBy(o => o.AgentId);
            foreach (var brokerGroup in brokerGroups)
            {
                List<LMEPosition> brokerList = brokerGroup.ToList();
                LMEPosition currentBroker = brokerList.FirstOrDefault();
                if (currentBroker == null) continue;

                //汇总表中的行
                var sumLine = new BrokerPLSummaryLineVM
                                  {
                                      BrokerId = currentBroker.AgentId ?? 0,
                                      BrokerName = currentBroker.Agent.ShortName,
                                      LineType = BrokerPLDetailLineType.NormalLine
                                  };

                //明细表中Broker Header
                var detailLine = new BrokerPLDetailLineVM
                                     {
                                         BrokerName = currentBroker.Agent.ShortName,
                                         LineType = BrokerPLDetailLineType.BrokerHeader
                                     };
                duedLockedDetails.Add(detailLine);

                foreach (var lmePosition in brokerList)
                {
                    detailLine = new BrokerPLDetailLineVM
                    {
                        PromptDate = lmePosition.PromptDate == null ? string.Empty : lmePosition.PromptDate.Value.ToShortDateString(),
                        Commission = lmePosition.AgentCommission,
                        FloatPL = -lmePosition.ClientCommission - lmePosition.AgentCommission,
                        LotNumber = lmePosition.LotAmount
                    };
                    if (Math.Round(lmePosition.HedgedLotQuantity ?? 0, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) != 0)
                    {
                        detailLine.Comments = ResReport.PositionNotEven;
                        detailLine.LineType = BrokerPLDetailLineType.ErrorWarning;
                    }
                    else
                    {
                        sumLine.DuedLockedPL += detailLine.FloatPL ?? 0;
                        detailLine.LineType = BrokerPLDetailLineType.NormalLine;
                    }

                    duedLockedDetails.Add(detailLine);
                }


                //Add a broker footer 
                detailLine = new BrokerPLDetailLineVM
                                 {
                                     BrokerName = Properties.Resources.Summary,
                                     Commission = sumLine.DuedLockedPL,
                                     LineType = BrokerPLDetailLineType.BrokerFooter
                                 };
                duedLockedDetails.Add(detailLine);

                summaries.Add(sumLine);
            }

            //reform undue positions
            brokerGroups = UnduedPositions.GroupBy(o => o.AgentId);
            var unduedLockedPositions = new List<LMEPosition>();
            var unduedFloatPositions = new List<LMEPosition>();

            foreach (var brokerGroup in brokerGroups)
            {
                List<LMEPosition> brokerList = brokerGroup.ToList();
                LMEPosition currentBroker = brokerList.FirstOrDefault();
                if (currentBroker == null) continue;

                //detail
                IEnumerable<IGrouping<DateTime?, LMEPosition>> promptDateGroups = brokerList.GroupBy(o => o.PromptDate);
                foreach (var promptDateGroup in promptDateGroups)
                {
                    List<LMEPosition> promptDateList = promptDateGroup.ToList();
                    LMEPosition currentPromptDate = promptDateList.FirstOrDefault();
                    if (currentPromptDate == null) continue;

                    var exposure = (decimal) promptDateList.Sum(o => o.LotAmount*o.TradeDirectionValue);
                    if (Math.Round(exposure, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                    {
                        unduedLockedPositions.AddRange(promptDateList);
                    }
                    else
                    {
                        List<LMEPosition> longPositions =
                            promptDateList.Where(o => o.TradeDirection == (int) PositionDirection.Long).
                                OrderByDescending(o => o.TradeDate).ThenByDescending(o => o.Id).ToList();
                        List<LMEPosition> shortPositions =
                            promptDateList.Where(o => o.TradeDirection == (int) PositionDirection.Short).
                                OrderByDescending(o => o.TradeDate).ThenByDescending(o => o.Id).ToList();

                        if (exposure == 0)
                        {
                            unduedLockedPositions.AddRange(longPositions);
                            unduedLockedPositions.AddRange(shortPositions);
                        }
                        else if (exposure > 0)
                        {
                            decimal exposurecopy = exposure;
                            unduedLockedPositions.AddRange(shortPositions);

                            int i = 0;
                            while (exposurecopy > 0)
                            {
                                if (longPositions[i].LotAmount > exposurecopy)
                                {
                                    decimal assignedCommission = (longPositions[i].AgentCommission ?? 0) * exposurecopy /
                                                                 longPositions[i].LotAmount.Value;
                                    unduedFloatPositions.Add(new LMEPosition
                                                                 {
                                                                     Agent = longPositions[i].Agent,
                                                                     AgentCommission = assignedCommission,
                                                                     AgentId = longPositions[i].AgentId,
                                                                     AgentPrice = longPositions[i].AgentPrice,
                                                                     PromptDate = longPositions[i].PromptDate,
                                                                     TradeDate = longPositions[i].TradeDate,
                                                                     LotAmount = exposurecopy,
                                                                     TradeDirection = longPositions[i].TradeDirection
                                                                 });
                                    longPositions[i].LotAmount -= exposurecopy;
                                    longPositions[i].AgentCommission -= assignedCommission;
                                    exposurecopy = 0;
                                    i++;
                                }
                                else
                                {
                                    unduedFloatPositions.Add(new LMEPosition
                                                                 {
                                                                     Agent = longPositions[i].Agent,
                                                                     AgentCommission = longPositions[i].AgentCommission,
                                                                     AgentId = longPositions[i].AgentId,
                                                                     AgentPrice = longPositions[i].AgentPrice,
                                                                     PromptDate = longPositions[i].PromptDate,
                                                                     TradeDate = longPositions[i].TradeDate,
                                                                     LotAmount = longPositions[i].LotAmount,
                                                                     TradeDirection = longPositions[i].TradeDirection
                                                                 });
                                    exposurecopy -= longPositions[i].LotAmount ?? 0;
                                    longPositions.RemoveAt(i);
                                }
                            }
                            unduedLockedPositions.AddRange(longPositions);
                        }
                        else
                        {
                            decimal exposurecopy = -exposure;
                            unduedLockedPositions.AddRange(longPositions);

                            int i = 0;
                            while (exposurecopy > 0)
                            {
                                if (shortPositions[i].LotAmount > exposurecopy)
                                {
                                    decimal assignedCommission = (shortPositions[i].AgentCommission ?? 0) * exposurecopy /
                                                                 shortPositions[i].LotAmount.Value;
                                    unduedFloatPositions.Add(new LMEPosition
                                                                 {
                                                                     Agent = shortPositions[i].Agent,
                                                                     AgentCommission = assignedCommission,
                                                                     AgentId = shortPositions[i].AgentId,
                                                                     AgentPrice = shortPositions[i].AgentPrice,
                                                                     PromptDate = shortPositions[i].PromptDate,
                                                                     TradeDate = shortPositions[i].TradeDate,
                                                                     LotAmount = exposurecopy,
                                                                     TradeDirection = shortPositions[i].TradeDirection
                                                                 });
                                    shortPositions[i].LotAmount -= exposurecopy;
                                    shortPositions[i].AgentCommission -= assignedCommission;
                                    exposurecopy = 0;
                                    i++;
                                }
                                else
                                {
                                    unduedFloatPositions.Add(new LMEPosition
                                                                 {
                                                                     Agent = shortPositions[i].Agent,
                                                                     AgentCommission = shortPositions[i].AgentCommission,
                                                                     AgentId = shortPositions[i].AgentId,
                                                                     AgentPrice = shortPositions[i].AgentPrice,
                                                                     PromptDate = shortPositions[i].PromptDate,
                                                                     TradeDate = shortPositions[i].TradeDate,
                                                                     LotAmount = shortPositions[i].LotAmount,
                                                                     TradeDirection = shortPositions[i].TradeDirection
                                                                 });
                                    exposurecopy -= shortPositions[i].LotAmount ?? 0;
                                    shortPositions.RemoveAt(i);
                                }
                            }
                            unduedLockedPositions.AddRange(shortPositions);
                        }
                    }
                }
            }

            //Create line vm of undued locked
            brokerGroups = unduedLockedPositions.GroupBy(o => o.AgentId);
            foreach (var bg in brokerGroups)
            {
                List<LMEPosition> brokerList = bg.ToList();
                LMEPosition currentBroker = brokerList.FirstOrDefault();
                if (currentBroker == null) continue;

                //init the sum line
                var sumLine = new BrokerPLSummaryLineVM
                                  {
                                      BrokerId = currentBroker.AgentId ?? 0,
                                      BrokerName = currentBroker.Agent.ShortName,
                                      LineType = BrokerPLDetailLineType.NormalLine
                                  };

                //Broker Header
                unduedLockedDetails.Add(new BrokerPLDetailLineVM
                                            {
                                                BrokerName = currentBroker.Agent.ShortName,
                                                LineType = BrokerPLDetailLineType.BrokerHeader
                                            });

                var promptGroups = brokerList.GroupBy(o => o.PromptDate);
                foreach (var pg in promptGroups)
                {
                    List<LMEPosition> promptList = pg.ToList();
                    LMEPosition currentPrompt = promptList.FirstOrDefault();
                    if (currentPrompt == null) continue;

                    //Prompt Date Header
                    unduedLockedDetails.Add(new BrokerPLDetailLineVM
                                                {
                                                    PromptDate =
                                                        currentPrompt.PromptDate == null
                                                            ? string.Empty
                                                            : currentPrompt.PromptDate.Value.ToShortDateString(),
                                                    LineType = BrokerPLDetailLineType.PromptDateHeader
                                                });

                    unduedLockedDetails.AddRange(
                        promptList.Select(
                            lmePosition => new BrokerPLDetailLineVM
                                                {
                                                    TradeDate = lmePosition.TradeDate,
                                                    LotNumber = lmePosition.LotAmount,
                                                    Direction = lmePosition.TradeDirection ?? 0,
                                                    Price = lmePosition.AgentPrice,
                                                    Commission =lmePosition.AgentCommission,
                                                    LineType = BrokerPLDetailLineType.NormalLine
                                                }));

                    //Prompt Footer
                    var unduedLockedPL =
                        (decimal) (-promptList.Sum(o => o.LotAmount*o.TradeDirectionValue*unit*o.AgentPrice) -
                                   promptList.Sum(o => o.AgentCommission));
                    unduedLockedDetails.Add(new BrokerPLDetailLineVM
                                                {
                                                    PromptDate = Properties.Resources.PL,
                                                    Commission = unduedLockedPL,
                                                    LineType = BrokerPLDetailLineType.PromptDateFooter
                                                });
                    sumLine.UnduedLockedPL += unduedLockedPL;
                }

                //Add Broker Footer
                unduedLockedDetails.Add(new BrokerPLDetailLineVM
                                            {
                                                BrokerName = Properties.Resources.Summary,
                                                Commission = sumLine.UnduedLockedPL,
                                                LineType = BrokerPLDetailLineType.BrokerFooter
                                            });

                //Add the sumline
                BrokerPLSummaryLineVM tmp = summaries.FirstOrDefault(o => o.BrokerId == sumLine.BrokerId);
                if (tmp == null)
                {
                    summaries.Add(sumLine);
                }
                else
                {
                    tmp.UnduedLockedPL = sumLine.UnduedLockedPL;
                }
            }

            //Create line vm of undued float
            brokerGroups = unduedFloatPositions.GroupBy(o => o.AgentId);

            foreach (var bg in brokerGroups)
            {
                List<LMEPosition> brokerList = bg.ToList();
                LMEPosition currentBroker = brokerList.FirstOrDefault();
                if (currentBroker == null) continue;

                //init the sum line
                var sumLine = new BrokerPLSummaryLineVM
                                  {
                                      BrokerId = currentBroker.AgentId ?? 0,
                                      BrokerName = currentBroker.Agent.ShortName,
                                      LineType = BrokerPLDetailLineType.NormalLine
                                  };

                //Broker Header
                unduedFloatDetails.Add(new BrokerPLDetailLineVM
                                           {
                                               BrokerName = currentBroker.Agent.ShortName,
                                               LineType = BrokerPLDetailLineType.BrokerHeader
                                           });

                IEnumerable<IGrouping<DateTime?, LMEPosition>> promptGroups = brokerList.GroupBy(o => o.PromptDate);
                foreach (var pg in promptGroups)
                {
                    List<LMEPosition> promptList = pg.ToList();
                    LMEPosition currentPrompt = promptList.FirstOrDefault();
                    if (currentPrompt == null) continue;

                    //Prompt Date Header
                    unduedFloatDetails.Add(new BrokerPLDetailLineVM
                                               {
                                                   PromptDate =
                                                       currentPrompt.PromptDate == null
                                                           ? string.Empty
                                                           : currentPrompt.PromptDate.Value.ToShortDateString(),
                                                   LineType = BrokerPLDetailLineType.PromptDateHeader
                                               });

                    unduedFloatDetails.AddRange(
                            promptList.Select(
                                    lmePosition => new BrokerPLDetailLineVM
                                                    {
                                                        TradeDate = lmePosition.TradeDate,
                                                        LotNumber = lmePosition.LotAmount,
                                                        Direction = lmePosition.TradeDirection ?? 0,
                                                        Price = lmePosition.AgentPrice,
                                                        Commission = lmePosition.AgentCommission,
                                                        LMELastestPrice = price,
                                                        FloatPL = lmePosition.LotAmount*unit*(price - lmePosition.AgentPrice)*lmePosition.TradeDirectionValue - lmePosition.AgentCommission,
                                                        LineType = BrokerPLDetailLineType.NormalLine
                                                    }));

                    //Prompt Footer
                    var unduedFloatPL =
                        (decimal) (-promptList.Sum(o => o.LotAmount*o.TradeDirectionValue*unit*(o.AgentPrice - price)) -
                                   promptList.Sum(o => o.AgentCommission));
                    unduedFloatDetails.Add(new BrokerPLDetailLineVM
                                               {
                                                   PromptDate = Properties.Resources.PL,
                                                   FloatPL = unduedFloatPL,
                                                   LineType = BrokerPLDetailLineType.PromptDateFooter
                                               });
                    sumLine.UnduedFloatPL += unduedFloatPL;
                }

                //Add Broker Footer
                unduedFloatDetails.Add(new BrokerPLDetailLineVM
                                           {
                                               BrokerName = Properties.Resources.Summary,
                                               FloatPL = sumLine.UnduedFloatPL,
                                               LineType = BrokerPLDetailLineType.BrokerFooter
                                           });

                //Add the sumline
                BrokerPLSummaryLineVM tmp = summaries.FirstOrDefault(o => o.BrokerId == sumLine.BrokerId);
                if (tmp == null)
                {
                    summaries.Add(sumLine);
                }
                else
                {
                    tmp.UnduedFloatPL = sumLine.UnduedFloatPL;
                }
            }

            DuedLockedDetails = duedLockedDetails;
            UnduedLockedDetails = unduedLockedDetails;
            UnduedFloatDetails = unduedFloatDetails;

            foreach (BrokerPLSummaryLineVM s in summaries)
            {
                s.SumPL = s.DuedLockedPL + s.UnduedLockedPL + s.UnduedFloatPL;
            }

            Summaries = summaries;
        }

        #endregion
    }

    public class BrokerPLSummaryLineVM
    {
        public int BrokerId { get; set; }
        public string BrokerName { get; set; }
        public decimal DuedLockedPL { get; set; }
        public decimal UnduedLockedPL { get; set; }
        public decimal UnduedFloatPL { get; set; }
        public decimal SumPL { get; set; }
        public BrokerPLDetailLineType LineType { get; set; }
    }

    public class BrokerPLDetailLineVM
    {
        public string BrokerName { get; set; }
        public string PromptDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public decimal? LotNumber { get; set; }
        public int Direction { get; set; }
        public decimal? Price { get; set; }
        public decimal? Commission { get; set; }
        public decimal? LMELastestPrice { get; set; }
        public decimal? FloatPL { get; set; }
        public bool Visible { get; set; }
        public BrokerPLDetailLineType LineType { get; set; }
        public string Comments { get; set; }
    }

    public enum BrokerPLDetailLineType
    {
        BrokerHeader,
        PromptDateHeader,
        PromptDateFooter,
        BrokerFooter,
        GridFooter,
        ErrorWarning,
        NormalLine
    }
}