using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.CommissionLineServiceReference;
using Client.CommissionServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.SystemSetting.CommissionSetting
{
    public class CommissionSearchVM : BaseVM
    {
        #region Member

        private int _bPartnerID;
        private int _commissionCount;
        private int _commissionFrom;
        private List<CommissionLine> _commissionLineList;
        private List<Commission> _commissionList;
        private int _commissionTo;
        private int _commissionTypeValue;
        private int _commodityID;
        private int _internalCustomerID;
        private List<object> _parameters;
        private string _queryStr;

        #endregion

        #region Porperty

        public int CommissionFrom
        {
            get { return _commissionFrom; }
            set
            {
                if (_commissionFrom != value)
                {
                    _commissionFrom = value;
                    Notify("CommissionFrom");
                }
            }
        }

        public int CommissionTo
        {
            get { return _commissionTo; }
            set
            {
                if (_commissionTo != value)
                {
                    _commissionTo = value;
                    Notify("CommissionTo");
                }
            }
        }

        public List<CommissionLine> CommissionLineList
        {
            get { return _commissionLineList; }
            set
            {
                if (_commissionLineList != value)
                {
                    _commissionLineList = value;
                    Notify("CommissionLineList");
                }
            }
        }

        public List<Commission> CommissionList
        {
            get { return _commissionList; }
            set
            {
                if (_commissionList != value)
                {
                    _commissionList = value;
                    Notify("CommissionList");
                }
            }
        }

        public int CommissionCount
        {
            get { return _commissionCount; }
            set
            {
                if (_commissionCount != value)
                {
                    _commissionCount = value;
                    Notify("CommissionCount");
                }
            }
        }

        public int CommodityID
        {
            get { return _commodityID; }
            set
            {
                if (_commodityID != value)
                {
                    _commodityID = value;
                    Notify("CommodityID");
                }
            }
        }

        public int BPartnerID
        {
            get { return _bPartnerID; }
            set
            {
                if (_bPartnerID != value)
                {
                    _bPartnerID = value;
                    Notify("BPartnerID");
                }
            }
        }

        public int InternalCustomerID
        {
            get { return _internalCustomerID; }
            set
            {
                if (_internalCustomerID != value)
                {
                    _internalCustomerID = value;
                    Notify("InternalCustomerID");
                }
            }
        }

        public int CommissionTypeValue
        {
            get { return _commissionTypeValue; }
            set
            {
                if (_commissionTypeValue != value)
                {
                    _commissionTypeValue = value;
                    Notify("CommissionTpeValue");
                }
            }
        }

        #endregion

        #region Method

        public void Init()
        {
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void InitPage()
        {
            LoadCommissionCount();
            LoadCommissionList();
        }

        public void LoadCommissionCount()
        {
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    CommissionCount = commissionService.GetAllCount();
                }
                else
                {
                    CommissionList = new List<Commission>();

                    using (
                        var commissionLineService =
                            SvcClientManager.GetSvcClient<CommissionLineServiceClient>(SvcType.CommissionLineSvc))
                    {
                        CommissionLineList = commissionLineService.Select(queryStr, parameters,
                                                                          new List<string>
                                                                              {
                                                                                  "Commission",
                                                                                  "Commodity",
                                                                                  "Commission.BusinessPartner",
                                                                                  "Commission.InternalBP"
                                                                              });
                    }
                    if (CommissionLineList.Count > 0)
                    {
                        foreach (CommissionLine line in CommissionLineList)
                        {
                            CommissionList.Add(line.Commission);
                        }
                    }
                    CommissionList = CommissionList.Distinct().ToList();
                    CommissionCount = CommissionList.Count;
                }
            }
        }

        public void LoadCommissionList()
        {
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    CommissionList = commissionService.SelectByRangeWithOrder("1=1", null,
                                                                              new SortCol
                                                                                  {ByDescending = true, ColName = "Id"},
                                                                              CommissionFrom, CommissionTo,
                                                                              new List<string>
                                                                                  {
                                                                                      "CommissionLines",
                                                                                      "CommissionLines.Commodity",
                                                                                      "BusinessPartner",
                                                                                      "InternalBP"
                                                                                  });
                }
                else
                {
                    CommissionList = new List<Commission>();
                    using (
                        var commissionLineService =
                            SvcClientManager.GetSvcClient<CommissionLineServiceClient>(SvcType.CommissionLineSvc))
                    {
                        CommissionLineList = commissionLineService.Select(queryStr, parameters,
                                                                          new List<string>
                                                                              {
                                                                                  "Commission",
                                                                                  "Commodity",
                                                                                  "Commission.BusinessPartner",
                                                                                  "Commission.InternalBP"
                                                                              });
                    }
                    if (CommissionLineList.Count > 0)
                    {
                        foreach (CommissionLine line in CommissionLineList)
                        {
                            CommissionList.Add(line.Commission);
                        }
                    }
                    CommissionList = CommissionList.Distinct().ToList();
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
            if (CommissionTypeValue != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Commission.CommissionType = @p{0} ", num++);
                parameters.Add(CommissionTypeValue);
            }

            if (CommodityID != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0}", num++);
                parameters.Add(CommodityID);
            }

            if (InternalCustomerID != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Commission.InternalBPId = @p{0}", num++);
                parameters.Add(InternalCustomerID);
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
                        sb.AppendFormat("it.Commission.InternalBPId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Commission.InternalBPId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (BPartnerID != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Commission.BPId = @p{0}", num);
                parameters.Add(BPartnerID);
            }

            queryStr = sb.ToString();
        }

        public Commission GetCommissionIdByLineID(int lineID)
        {
            var commission = new Commission();
            const string str = "it.Id = @p1";
            var parameters = new List<object> {lineID};
            using (
                var commissionLineService =
                    SvcClientManager.GetSvcClient<CommissionLineServiceClient>(SvcType.CommissionLineSvc))
            {
                List<CommissionLine> lines = commissionLineService.Select(str, parameters,
                                                                          new List<string> {"Commission"});
                if (lines.Count > 0)
                {
                    CommissionLine line = lines[0];
                    commission = line.Commission;
                }
            }
            return commission;
        }

        public void DelCommissionLine(int lineID)
        {
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                commissionService.RemoveById(lineID, CurrentUser.Id);
            }
        }

        #endregion
    }
}