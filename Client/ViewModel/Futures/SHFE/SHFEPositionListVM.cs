using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.SHFEPositionServiceReference;
using Client.View.Futures.SHFE;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.SHFE
{
    public class SHFEPositionListVM : BaseVM
    {
        #region Member

        private readonly List<Object> _parameters = new List<object>();
        private int _positionCount;
        private List<SHFEPosition> _positions;
        private string _queryStr = string.Empty;

        #endregion

        #region Property

        public int? BrokerId { get; set; }
        public int? InnerCustomerId { get; set; }
        public int? CommodityId { get; set; }
        public DateTime? StartTradeDate { get; set; }
        public DateTime? EndTradeDate { get; set; }
        public DateTime? StartPromptDate { get; set; }
        public DateTime? EndPromptDate { get; set; }

        public List<SHFEPosition> Positions
        {
            get { return _positions; }
            set
            {
                if (_positions != value)
                {
                    _positions = value;
                    Notify("Positions");
                }
            }
        }

        public int PageFrom { get; set; }
        public int PageTo { get; set; }

        public int PositionCount
        {
            get { return _positionCount; }
            set
            {
                if (_positionCount != value)
                {
                    _positionCount = value;
                    Notify("PositionCount");
                }
            }
        }

        #endregion

        public SHFEPositionListVM()
        {
        }

        public SHFEPositionListVM(int? brokerId, int? innerCustomerId, int? commodityId, DateTime? startTradeDate,
                                  DateTime? endTradeDate, DateTime? startPromptDate, DateTime? endPromptDate)
        {
            BrokerId = brokerId;
            InnerCustomerId = innerCustomerId;
            CommodityId = commodityId;
            StartTradeDate = startTradeDate;
            EndTradeDate = endTradeDate;
            StartPromptDate = startPromptDate;
            EndPromptDate = endPromptDate;
            LoadPositionCount();
        }

        private void BuildParamter()
        {
            int num = 1;
            var sb = new StringBuilder();
            if (BrokerId.HasValue && BrokerId != 0)
            {
                //经纪行
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.SHFECapitalDetail.AgentId=@p{0} ", num++));
                _parameters.Add(BrokerId.Value);
            }
            if (InnerCustomerId.HasValue && InnerCustomerId != 0)
            {
                //内部客户
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.SHFECapitalDetail.InternalBPId=@p{0} ", num++));
                _parameters.Add(InnerCustomerId.Value);
            }
            else
            {
                List<BusinessPartner> innerCustomers = GetFilterInnerCustomer();
                if (innerCustomers.Count > 0)
                {
                    sb.Append(sb.Length > 0 ? " and (" : "(");
                    foreach (BusinessPartner innerCustomer in innerCustomers)
                    {
                        sb.Append(string.Format(" it.SHFECapitalDetail.InternalBPId=@p{0} or", num++));
                        _parameters.Add(innerCustomer.Id);
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(")");
                }
                else
                {
                    throw new Exception(ResSHFE.NoInternalCustomerFound);
                }
            }
            if (CommodityId.HasValue && CommodityId != 0)
            {
                //金属
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.CommodityId=@p{0} ", num++));
                _parameters.Add(CommodityId.Value);
            }
            else
            {
                List<Commodity> commodities = GetFilterCommodity();
                if (commodities.Count > 0)
                {
                    sb.Append(sb.Length > 0 ? " and (" : "(");
                    foreach (Commodity commodity in commodities)
                    {
                        sb.Append(string.Format(" it.CommodityId=@p{0} or", num++));
                        _parameters.Add(commodity.Id);
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(")");
                }
                else
                {
                    throw new Exception(ResSHFE.NoCommodityFound);
                }
            }
            if (StartTradeDate.HasValue)
            {
                //交易开始日期
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.SHFECapitalDetail.TradeDate>=@p{0} ", num++));
                _parameters.Add(StartTradeDate.Value);
            }
            if (EndTradeDate.HasValue)
            {
                //交易截止日期
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.SHFECapitalDetail.TradeDate<=@p{0} ", num++));
                _parameters.Add(EndTradeDate.Value);
            }
            if (StartPromptDate.HasValue)
            {
                //到期开始日期
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.PromptDate>=@p{0} ", num++));
                _parameters.Add(StartPromptDate.Value);
            }
            if (EndPromptDate.HasValue)
            {
                //到期截止日期
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(string.Format(" it.PromptDate<=@p{0} ", num));
                _parameters.Add(EndPromptDate.Value);
            }
            _queryStr = sb.ToString();
        }

        private List<Commodity> GetFilterCommodity()
        {
            List<Commodity> commodities;
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                commodities = commodityService.GetCommoditiesByUser(CurrentUser.Id);
            }
            return commodities;
        }

        private List<BusinessPartner> GetFilterInnerCustomer()
        {
            List<BusinessPartner> innerCustomers;
            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                innerCustomers = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
            }
            return innerCustomers;
        }

        private void LoadPositionCount()
        {
            BuildParamter();
            using (
                var positionService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                if (!string.IsNullOrWhiteSpace(_queryStr))
                {
                    //有查询条件
                    PositionCount =
                        positionService.Select(_queryStr, _parameters,
                                               new List<string>
                                                   {
                                                       "SHFE",
                                                       "SHFECapitalDetail",
                                                       "SHFECapitalDetail.BusinessPartner",
                                                       "SHFECapitalDetail.BusinessPartner1",
                                                       "Commodity"
                                                   }).Count;
                }
            }
        }

        public void LoadPosition()
        {
            using (
                var positionService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                if (!string.IsNullOrWhiteSpace(_queryStr))
                {
                    //有查询条件
                    Positions = positionService.SelectByRangeWithOrder(_queryStr, _parameters,
                                                                       new SortCol {ColName = "Id", ByDescending = true},
                                                                       PageFrom, PageTo,
                                                                       new List<string>
                                                                           {
                                                                               "SHFE",
                                                                               "SHFECapitalDetail",
                                                                               "SHFECapitalDetail.BusinessPartner",
                                                                               "SHFECapitalDetail.BusinessPartner1",
                                                                               "Commodity"
                                                                           });
                }
            }
        }
    }
}