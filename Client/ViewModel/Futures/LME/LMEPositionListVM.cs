using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.LMEPositionServiceReference;
using Client.SystemParameterServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Futures.LME
{
    public class LMEPositionListVM : BaseVM
    {
        #region Member

        private int? _brokerId;
        private DateTime? _endPromptDate;
        private DateTime? _endTradeDate;
        private int? _icId;
        private List<LMEPosition> _lmePositions;
        private int _listFrom;
        private int _listTo;
        private int _listTotleCount;
        private int? _selectedMetal;
        private DateTime? _startPromptDate;
        private DateTime? _startTradeDate;
        private bool _isLMEAgent;
        private int? _selectedBPartnerId;
        private List<object> _parameters;
        private string _queryStr;

        #endregion

        #region Property

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


        public int ListTotleCount
        {
            get { return _listTotleCount; }
            set
            {
                if (_listTotleCount != value)
                {
                    _listTotleCount = value;
                    Notify("ListTotleCount");
                }
            }
        }

        public int ListFrom
        {
            get { return _listFrom; }
            set
            {
                if (_listFrom != value)
                {
                    _listFrom = value;
                    Notify("ListFrom");
                }
            }
        }

        public int ListTo
        {
            get { return _listTo; }
            set
            {
                if (_listTo != value)
                {
                    _listTo = value;
                    Notify("ListTo");
                }
            }
        }

        public List<LMEPosition> LMEPositions
        {
            get { return _lmePositions; }
            set
            {
                if (_lmePositions != value)
                {
                    _lmePositions = value;
                    Notify("LMEPositions");
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

        #endregion

        #region Method

        public void Init()
        {
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void InitPage()
        {
            LoadListCount();
        }

        public void LoadListCount()
        {
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _listTotleCount = queryStr == string.Empty ? lmePositionService.GetAllCount() : lmePositionService.GetCount(queryStr, parameters);
            }
        }

        public void LoadList()
        {
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
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    LMEPositions =
                        lmePositionService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                 ListFrom,
                                                                 ListTo,
                                                                 new List<string>
                                                                     {
                                                                         "Quota",
                                                                         "Agent",
                                                                         "Client",
                                                                         "InternalBP",
                                                                         "Commodity"
                                                                     }).Where(t => !t.IsDeleted).ToList();
                }
                else
                {
                    LMEPositions =
                        lmePositionService.SelectByRangeWithOrder(queryStr, parameters,
                                                                  new SortCol {ByDescending = true, ColName = "Id"},
                                                                  ListFrom, ListTo,
                                                                  new List<string>
                                                                      {
                                                                          "Quota",
                                                                          "Agent",
                                                                          "Client",
                                                                          "InternalBP",
                                                                          "Commodity"
                                                                      }).Where(t => !t.IsDeleted).ToList();
                }
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
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
            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;

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
                        sb.AppendFormat("it.InternalBPId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.InternalBPId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (SelectedBPartnerId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.ClientId = @p{0} ", num++);
                parameters.Add(SelectedBPartnerId);
            }
            if (BrokerId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.AgentId = @p{0} ", num++);
                parameters.Add(BrokerId);
            }
            if (ICId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.InternalBPId = @p{0} ", num++);
                parameters.Add(ICId);
            }

            if (SelectedMetal > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0} ", num++);
                parameters.Add(SelectedMetal);
            }

            if (StartTradeDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.TradeDate >= @p{0} ", num++);
                parameters.Add(StartTradeDate.Value);
            }
            if (EndTradeDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.TradeDate <= @p{0} ", num++);
                parameters.Add(EndTradeDate.Value.AddDays(1).AddMinutes(-1));
            }

            if (StartPromptDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PromptDate >= @p{0} ", num++);
                parameters.Add(StartPromptDate.Value);
            }
            if (EndPromptDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PromptDate <= @p{0} ", num);
                parameters.Add(EndPromptDate.Value.AddDays(1).AddMinutes(-1));
            }

            queryStr = sb.ToString();
        }

        public LMEPosition GetLMEPositionById(int id)
        {
            LMEPosition lmePosition;
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
            {
                lmePosition = lmePositionService.GetById(id);
            }
            return lmePosition;
        }

        public void Remove(int id)
        {
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
            {
                lmePositionService.DeleteLMEPosition(id, CurrentUser.Id);
            }
        }

        public void RemoveCarryPosition(int id)
        {
            using (
                var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc)
                )
            {
                lmePositionService.DeleteCarryLMEPosition(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}