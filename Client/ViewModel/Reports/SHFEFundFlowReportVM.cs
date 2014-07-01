using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.SHFEFundFlowServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Reports
{
    public class SHFEFundFlowReportVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _brokers;
        private List<BusinessPartner> _innerCustomer;
        private int? _selectedBrokerId;
        private int? _selectedInnerCustomer;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private List<SHFEFundFlow> _shfefundFlows;
        private int _count;
        private int _from;
        private int _to;
        private string _queryStr = string.Empty;
        #endregion

        #region Property
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (_count != value)
                {
                    _count = value;
                    Notify("Count");
                }
            }
        }

        public int From
        {
            get
            {
                return _from;
            }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    Notify("From");
                }
            }
        }

        public int To
        {
            get
            {
                return _to;
            }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    Notify("To");
                }
            }
        }

        public List<SHFEFundFlow> SHFEFundFlows
        {
            get
            {
                return _shfefundFlows;
            }
            set
            {
                if (_shfefundFlows != value)
                {
                    _shfefundFlows = value;
                    Notify("SHFEFundFlows");
                }
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        /// <summary>
        /// 选择的经纪行
        /// </summary>
        public int? SelectedBrokerId
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
        public int? SelectedInnerCustomer
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

        #endregion

        #region Constructor

        public SHFEFundFlowReportVM()
        {
            LoadData();
        }

        #endregion

        #region Method

        private void LoadData()
        {
            LoadBroker();
            LoadInnerCustomer();
        }

        /// <summary>
        /// 获取经纪行
        /// </summary>
        private void LoadBroker()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _brokers = busService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        /// <summary>
        /// 获取内部客户
        /// </summary>
        private void LoadInnerCustomer()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _innerCustomer = busService.GetInternalCustomersByUser(CurrentUser.Id);
                _innerCustomer.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        public void Search()
        {
            Setparam();
            LoadSHFEFundFlowCount();
        }

        public void LoadSHFEFundFlow()
        {
            using (
                var shfeFundFlowService =
                    SvcClientManager.GetSvcClient<SHFEFundFlowServiceClient>(SvcType.SHFEFundFlowSvc))
            {
                if (_queryStr != string.Empty)
                {
                    SHFEFundFlows = shfeFundFlowService.SelectByRangeWithOrder(_queryStr, null,
                                                                                        new SortCol { ColName = "TradeDate", ByDescending = true },
                                                                                        _from, _to,
                                                                                        new List<string>
                                                                                            {
                                                                                               "SHFECapitalDetail", "SHFECapitalDetail.BusinessPartner", "SHFECapitalDetail.BusinessPartner1"
                                                                                            });
                }
                else
                {
                    SHFEFundFlows = shfeFundFlowService.SelectByRangeWithOrder("1==1", null,
                                                                                        new SortCol { ColName = "TradeDate", ByDescending = true },
                                                                                        _from, _to,
                                                                                        new List<string>
                                                                                            {
                                                                                                "SHFECapitalDetail", "SHFECapitalDetail.BusinessPartner", "SHFECapitalDetail.BusinessPartner1"
                                                                                            });
                }
            }
        }

        public void LoadSHFEFundFlowCount()
        {
            using (
               var shfeFundFlowService =
                   SvcClientManager.GetSvcClient<SHFEFundFlowServiceClient>(SvcType.SHFEFundFlowSvc))
            {
                Count = _queryStr != string.Empty
                            ? shfeFundFlowService.GetCount(_queryStr, null)
                            : shfeFundFlowService.GetAllCount();
            }
        }

        /// <summary>
        /// 设置查询参数
        /// </summary>
        private void Setparam()
        {
            List<int> idList = new List<int>();
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    idList = list.Select(c => c.Id).ToList();
                }
            }
            var sb = new StringBuilder();

            if (SelectedBrokerId.HasValue && SelectedBrokerId != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.SHFECapitalDetail.AgentId == " + SelectedBrokerId);
            }
            if (SelectedInnerCustomer.HasValue && SelectedInnerCustomer != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.SHFECapitalDetail.InternalBPId == " + SelectedInnerCustomer);
            }

            if (idList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.SHFECapitalDetail.InternalBPId ==" + idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.SHFECapitalDetail.InternalBPId ==" + idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (StartDate.HasValue)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.TradeDate >= cast('" + StartDate + "' as System.DateTime) ");
            }
            if (EndDate.HasValue)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.TradeDate <= cast('" + EndDate + "' as System.DateTime) ");
            }

            _queryStr = sb.ToString();
        }

        #endregion
    }
}
