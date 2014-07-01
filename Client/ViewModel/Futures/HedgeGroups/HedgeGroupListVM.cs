using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.HedgeGroupServiceReference;
using Client.View.Futures.HedgeGroups;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.Linq;
using System.Text;

namespace Client.ViewModel.Futures.HedgeGroups
{
    public class HedgeGroupListVM : BaseVM
    {
        #region Member

        private List<HedgeGroup> _hedgeGroups; 
        
        #endregion

        #region Property

        public HedgeGroupConditions Conditions { get; set; }
        public string QueryStr { get; set; }
        public List<object> Parameters { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Count { get; set; }

        public List<HedgeGroup> HedgeGroups
        {
            get { return _hedgeGroups; }
            set
            {
                _hedgeGroups = value;
                Notify("HedgeGroups");
            }
        }

        #endregion

        #region Constructor

        public HedgeGroupListVM(HedgeGroupConditions conditions)
        {
            Conditions = conditions;
            BuildQueryStrAndParam();
        }

        #endregion

        #region Method

        /// <summary>
        /// Build the query string and parameters
        /// </summary>
        private void BuildQueryStrAndParam()
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
            var clauses = new List<string>();
            Parameters = new List<object>();

            int i = 1;
            if (idList != null && idList.Count > 0)
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
                        sb.AppendFormat("it.PayBusinessPartner.Id= @p{0}", i++);
                        Parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.PayBusinessPartner.Id = @p{0}", i++);
                        Parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if(Conditions.StartDate != null)
            {
                clauses.Add(string.Format("it.HedgeDate >= @p{0}", i++));
                Parameters.Add(Conditions.StartDate);
            }

            if(Conditions.EndDate != null)
            {
                clauses.Add(string.Format("it.HedgeDate <= @p{0}", i));
                Parameters.Add(Conditions.EndDate);
            }

            if (Conditions.HedgeNme != null)
            {
                clauses.Add(string.Format("it.Name like '%"+Conditions.HedgeNme.Trim() +"%' ", i));
            }

            QueryStr = string.Join(" and ", clauses);
        }

        /// <summary>
        /// Load the count of all the hedge group
        /// </summary>
        public void LoadCount()
        {
            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                Count = string.IsNullOrWhiteSpace(QueryStr) ? hgService.GetAllCount() : hgService.GetCount(QueryStr, Parameters);   
            }
        }

        /// <summary>
        /// Load the hedge groups for current page
        /// </summary>
        public void Load()
        {
            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                if(string.IsNullOrWhiteSpace(QueryStr))
                {
                    HedgeGroups = hgService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "HedgeDate"}, From,
                                                                To, new List<string>{"PLCurrency"});
                }
                else
                {
                    HedgeGroups = hgService.SelectByRangeWithOrder(QueryStr, Parameters,
                                                 new SortCol { ByDescending = true, ColName = "HedgeDate" }, From, To, new List<string> { "PLCurrency" });
                }
            }
        }

        /// <summary>
        /// Delete the hedge group (no content)
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                var hg = hgService.FetchById(id, new List<string> { "HedgeLineQuotas", "HedgeLineLMEPositions", "HedgeLineSHFEPositions" });
                if(hg.HedgeLineLMEPositions.Count > 0 || hg.HedgeLineQuotas.Count > 0 || hg.HedgeLineSHFEPositions.Count >0)
                {
                    throw new Exception(ResHedgeGroup.DeleteError);
                }

                hgService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }

    public class HedgeGroupConditions
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HedgeNme { get; set; }
    }

    public enum HedgeGroupSearchType
    {
        Free,
        CurrentMonth,
        LastMonth,
        CurrentYear,
        LastYear
    }
}
