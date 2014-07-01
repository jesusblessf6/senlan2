using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Utility.Misc;
using DBEntity.EnumEntity;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Reports
{
    public class BusinessPartnerContractOrderVM : BaseVM
    {
        #region Member

        private List<BPartnerContractOrder> _contractOrderList;
        private string _bPartnerName;
        private int _bPartnerID;
        private string _commodityName;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private List<BusinessPartner> _internalCustomerList;
        private List<Commodity> _commodityList;
        private Dictionary<string, int> _contractType;
        private int _selectedInternalCustomerId;
        private int _commodityId;
        private int _contractTypeId;

        #endregion

        #region Property

        public int ContractTypeId
        {
            get { return _contractTypeId; }
            set
            {
                if (_contractTypeId != value)
                {
                    _contractTypeId = value;
                    Notify("ContractType");
                }
            }
        }

        /// <summary>
        /// 金属id
        /// </summary>
        public int CommodityId
        {
            get { return _commodityId; }
            set
            {
                if (_commodityId != value)
                {
                    _commodityId = value;
                    Notify("CommodityId");
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

        public Dictionary<string, int> ContractType
        {
            get { return _contractType; }
            set
            {
                if (_contractType != value)
                {
                    _contractType = value;
                    Notify("ContractType");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                if (_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        public List<BusinessPartner> InternalCustomerList
        {
            get { return _internalCustomerList; }
            set
            {
                if (_internalCustomerList != value)
                {
                    _internalCustomerList = value;
                    Notify("InternalCustomerList");
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

        public string CommodityName
        {
            get { return _commodityName; }
            set
            {
                if (_commodityName != value)
                {
                    _commodityName = value;
                    Notify("CommodityName");
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

        public List<BPartnerContractOrder> ContractOrderList
        {
            get { return _contractOrderList; }
            set
            {
                if (_contractOrderList != value)
                {
                    _contractOrderList = value;
                    Notify("ContractOrderList");
                }
            }
        }

        #endregion

        #region Contruct

        public BusinessPartnerContractOrderVM()
        {
            StartDate = DateTime.Now.AddMonths(1 - DateTime.Now.Month).AddDays(1 - DateTime.Now.Day);
            EndDate = DateTime.Now;
            LoadCommodity();
            LoadContractType();
            LoadInternalCustomer();
        }

        #endregion

        #region Method

        public void LoadInternalCustomer()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                InternalCustomerList = busService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalCustomerList.Insert(0, new BusinessPartner {Id = 0, Name = string.Empty});
            }
        }

        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commService.GetCommoditiesByUser(CurrentUser.Id);
            }
            CommodityList.Insert(0, new Commodity {Id = 0, Name = string.Empty});
        }

        private void LoadContractType()
        {
            ContractType = new Dictionary<string, int>();
            ContractType = EnumHelper.GetEnumDic<ContractType>(ContractType);
        }

        public void GetData()
        {
            ContractOrderList = new List<BPartnerContractOrder>();
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                ContractOrderList = quotaService.GetContractOrderList(queryStr, parameters, CurrentUser.Id);
            }
        }

        public override bool Validate()
        {
            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception("内部客户不能为空");
            }

            if (CommodityId == 0)
            {
                throw new Exception("金属不能为空");
            }

            if (!StartDate.HasValue)
            {
                throw new Exception("请选择起始日期");
            }

            if (!EndDate.HasValue)
            {
                throw new Exception("请选择截止日期");
            }

            if (StartDate.Value > EndDate.Value)
            {
                throw new Exception("起始日期不能大于截止日期");
            }

            if (ContractTypeId == 0)
            {
                throw new Exception("请选择业务类型");
            }
            return true;
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
            if (SelectedInternalCustomerId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.InternalCustomerId = @p{0} ", num++);
                parameters.Add(SelectedInternalCustomerId);
            }

            if (CommodityId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0} ", num++);
                parameters.Add(CommodityId);
            }

            if (StartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.SignDate >= @p{0} ", num++);
                parameters.Add(StartDate);
            }

            if (EndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.SignDate <= @p{0} ", num++);
                parameters.Add(EndDate);
            }

            if (ContractTypeId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.ContractType = @p{0} ", num);
                parameters.Add(ContractTypeId);
            }

            queryStr = sb.ToString();
        }

        #endregion
    }
}
