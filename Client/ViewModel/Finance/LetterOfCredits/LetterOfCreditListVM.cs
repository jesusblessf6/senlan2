using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.LetterOfCreditServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using Utility.Misc;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Finance.LetterOfCredits
{
    public class LetterOfCreditListVM : BaseVM
    {
        #region Member
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime? _start2Date;
        private DateTime? _end2Date;
        private int _applicantId;
        private string _applicantName;
        private int _beneficiaryId;
        private string _beneficiaryName;
        private List<LetterOfCredit> _letterOfCredits; 
        private int _listTotleCount;
        private int _listFrom;
        private int _listTo;
        private string _queryStr;
        private List<object> _parameters;
        private int _lcPorS;
        private bool _containCurrentUser;
        private string _QuotaNo;
        #endregion

        #region Property
        public string QuotaNo
        {
            get { return _QuotaNo; }
            set { 
                if(_QuotaNo != value)
                {
                    _QuotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public int LCPorS
        {
            get { return _lcPorS; }
            set { 
                if(_lcPorS != value)
                {
                    _lcPorS = value;
                    Notify("LCPorS");
                }
            }
        }

        public DateTime? EndDate
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
        public DateTime? End2Date
        {
            get { return _end2Date; }
            set
            {
                if (_end2Date != value)
                {
                    _end2Date = value;
                    Notify("End2Date");
                }
            }
        }
        public DateTime? Start2Date
        {
            get { return _start2Date; }
            set
            {
                if (_start2Date != value)
                {
                    _start2Date = value;
                    Notify("Start2Date");
                }
            }
        }
        public int ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (_applicantId != value)
                {
                    _applicantId = value;
                    Notify("ApplicantId");
                }
            }
        }
        public string ApplicantName
        {
            get { return _applicantName; }
            set
            {
                if (_applicantName != value)
                {
                    _applicantName = value;
                    Notify("ApplicantName");
                }
            }
        }
        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                if (_beneficiaryId != value)
                {
                    _beneficiaryId = value;
                    Notify("BeneficiaryId");
                }
            }
        }
        public string BeneficiaryName
        {
            get { return _beneficiaryName; }
            set
            {
                if (_beneficiaryName != value)
                {
                    _beneficiaryName = value;
                    Notify("BeneficiaryName");
                }
            }
        }
        public List<LetterOfCredit> LetterOfCredits
        {
            get { return _letterOfCredits; }
            set
            {
                if (_letterOfCredits != value)
                {
                    _letterOfCredits = value;
                    Notify("LetterOfCredits");
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

        public bool ContainCurrentUser
        {
            get { return _containCurrentUser; }
            set
            {
                if (_containCurrentUser != value)
                {
                    _containCurrentUser = value;
                    Notify("ContainCurrentUser");
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
            LoadListCount();
        }

        public void LoadListCount()
        {
            using (var letterOfCreditService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _listTotleCount = queryStr == string.Empty ? letterOfCreditService.GetAllCount() : letterOfCreditService.GetCount(queryStr, parameters);
            }
        }

        public void LoadList()
        {
            using (var letterOfCreditService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    LetterOfCredits = letterOfCreditService.FetchByRangeWithOrder(new SortCol { ByDescending = true, ColName = "Id" }, ListFrom,
                                                          ListTo, new List<string> { "Quota", "BusinessPartner", "BusinessPartner1", "Currency", "Deliveries","Bank","Bank1" }).Where(t => !t.IsDeleted).ToList();
                }
                else
                {
                    LetterOfCredits = letterOfCreditService.SelectByRangeWithOrder(queryStr, parameters, new SortCol { ByDescending = true, ColName = "Id" }, ListFrom, ListTo,
                                                           new List<string> { "Quota", "BusinessPartner", "BusinessPartner1", "Currency", "Deliveries", "Bank", "Bank1" }).Where(t => !t.IsDeleted).ToList();
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
                        sb.Append("(");
                        sb.AppendFormat("it.PorS = 1 and (it.ApplicantId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.ApplicantId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")) or ");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.Append("(");
                        sb.AppendFormat("it.PorS = 2 and (it.BeneficiaryId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.BeneficiaryId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")))");

            }

            if (ApplicantId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.ApplicantId = @p{0} ", num++);
                parameters.Add(ApplicantId);
            }
            if (BeneficiaryId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.BeneficiaryId = @p{0} ", num++);
                parameters.Add(BeneficiaryId);
            }

            if (ContainCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            if(LCPorS != 0)
            {
                if(sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PorS = @p{0}", num++);
                parameters.Add(LCPorS);
            }
         
            if(!string.IsNullOrEmpty(QuotaNo))
            {
                if(sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.QuotaNo like '%" + QuotaNo.Trim() + "%'");
            }

            if (StartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IssueDate >= @p{0} ", num++);
                parameters.Add(StartDate.Value);
            }
            
            if (EndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IssueDate <= @p{0} ", num);
                parameters.Add(EndDate.Value.AddDays(1).AddMinutes(-1));
            }

            queryStr = sb.ToString();
        }



        public LetterOfCredit GetLetterOfCreditById(int id)
        {
            LetterOfCredit lc;
            using (var letterOfCreditService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                lc = letterOfCreditService.GetById(id);
            }
            return lc;
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            using (var lcService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                lcService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}
