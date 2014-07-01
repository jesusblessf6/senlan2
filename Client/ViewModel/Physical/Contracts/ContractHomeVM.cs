using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Physical.Contracts
{
    public class ContractHomeVM : BaseVM
    {
        #region Member
        private List<int> _idList;
        private ContractType _contractType;
        private int _supplierId;
        private string _supplierName;
        private List<EnumItem> _tradeTypes;
        private int _selectedTradeType;
        private DateTime? _startDate=DateTime.Today;
        private DateTime? _endDate=DateTime.Today;
        private List<Commodity> _commodities;
        private int _selectedCommodityId;
        private List<BusinessPartner> _internalCustomers;
        private int _selectedInternalCustomerId;
        private List<ContractUDF> _udfs;
        private int? _selectedUsdId;
        private string _selectExContractNo;
        private bool _IsOnlyCurrentUser = true;
        private bool _IsOnlyHideRelQuotas = false;
        private string _quotaNo;
        #endregion

        #region Property
        public bool IsOnlyHideRelQuotas
        {
            get { return _IsOnlyHideRelQuotas; }
            set
            {
                if (_IsOnlyHideRelQuotas != value)
                {
                    _IsOnlyHideRelQuotas = value;
                    Notify("IsOnlyHideRelQuotas");
                }
            }
        }
        public bool IsOnlyCurrentUser
        {
            get { return _IsOnlyCurrentUser; }
            set
            {
                if (_IsOnlyCurrentUser != value)
                {
                    _IsOnlyCurrentUser = value;
                    Notify("IsOnlyCurrentUser");
                }
            }
        }

        public List<int> IdList
        {
            get { return _idList; }
            set
            {
                if (_idList != value)
                {
                    _idList = value;
                    Notify("IdList");
                }
            }
        }

        public List<EnumItem> TradeTypes
        {
            get { return _tradeTypes; }
            set
            {
                if (_tradeTypes != value)
                {
                    _tradeTypes = value;
                    Notify("TradeTypes");
                }
            }
        }

        public int SelectedTradeType
        {
            get { return _selectedTradeType; }
            set
            {
                if (_selectedTradeType != value)
                {
                    _selectedTradeType = value;
                    Notify("SelectedTradeType");
                }
            }
        }
        public List<ContractUDF> Udfs
        {
            get { return _udfs; }
            set
            {
                if (_udfs != value)
                {
                    _udfs = value;
                    Notify("Udfs");
                }
            }
        }

        public int? SelectedUsdId
        {
            get { return _selectedUsdId; }
            set
            {
                if (_selectedUsdId != value)
                {
                    _selectedUsdId = value;
                    Notify("SelectedUsdId");
                }
            }
        }


        /// <summary>`
        /// 供应商ID
        /// </summary>
        public int SupplierId
        {
            get { return _supplierId; }
            set
            {
                if (_supplierId != value)
                {
                    _supplierId = value;
                    Notify("SupplierId");
                }
            }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    Notify("SupplierName");
                }
            }
        }

        public string SelectExContractNo
        {
            get { return _selectExContractNo; }
            set
            {
                if (_selectExContractNo != value)
                {
                    _selectExContractNo = value;
                    Notify("SelectExContractNo");
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

        public ContractType ContractType
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

        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                if (_internalCustomers != value)
                {
                    _internalCustomers = value;
                    Notify("InternalCustomers");
                }
            }
        }

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                if (_commodities != value)
                {
                    _commodities = value;
                    Notify("Commodities");
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

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                if (_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }
        #endregion

        #region Constructor

        public ContractHomeVM(ContractType contractType)
        {
            ContractType = contractType;
            GetIDList();
            GetTradeTypes();
            LoadCommodity();
            LoadInternalCustomers();
            LoadUdf();
        }

        #endregion

        #region Method
        public void GetIDList()
        {
            IdList = new List<int>();
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
        }

        /// <summary>
        /// Get the Trade Types for the Combo Box
        /// </summary>
        public void GetTradeTypes()
        {
            _tradeTypes = EnumHelper.GetEnumList<TradeType>();
            _tradeTypes.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
        }

        private void LoadUdf()
        {
            using (
              var contractUDFService =
                   SvcClientManager.GetSvcClient<ContractUDFServiceReference.ContractUDFServiceClient>(SvcType.ContractUDFSvc))
            {
                _udfs = contractUDFService.GetAll();
                _udfs.Insert(0, new ContractUDF { Id = 0, Name = string.Empty });
            }
        }

        /// <summary>
        /// Get the Commodities for the Combo Box
        /// </summary>
        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity { Id = 0, Name = string.Empty });
            }
        }

        /// <summary>
        /// Get the Internal Customer for the Combo Box
        /// </summary>
        private void LoadInternalCustomers()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = busService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner{Id = 0, Name = string.Empty});
            }
        }

        /// <summary>
        /// Clear the search conditions
        /// </summary>
        public void Reset()
        {
            SelectedTradeType = 0;
            SupplierId = 0;
            SupplierName = string.Empty;
            StartDate = null;
            EndDate = null;
            SelectedCommodityId = 0;
            SelectedInternalCustomerId = 0;
            SelectedUsdId = 0;
            SelectExContractNo = string.Empty;
            QuotaNo = string.Empty;
        }

        /// <summary>
        /// Build up the search conditions
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal ContractSearchConditions BuildConditions(ContractSearchType type)
        {
            var conditions = new ContractSearchConditions {ContractType = (int) ContractType};

            switch(type)
            {
                case ContractSearchType.Free:
                    {
                        conditions.SupplierId = SupplierId;
                        conditions.TradeTypeId = SelectedTradeType;
                        conditions.StartDate = StartDate;
                        conditions.EndDate = EndDate;
                        conditions.CommodityId = SelectedCommodityId;
                        conditions.InternalCustomerId = SelectedInternalCustomerId;
                        conditions.UDFId = SelectedUsdId;
                        conditions.IsDraft = false;
                        conditions.SelectExContractNo =SelectExContractNo;
                        conditions.InternalIdList = IdList;
                        conditions.IsOnlyCurrentUser = IsOnlyCurrentUser;
                        conditions.IsOnlyHideRelQuotas = IsOnlyHideRelQuotas;
                        conditions.QuotaNo = QuotaNo;
                        break;
                    }

                case ContractSearchType.CurrentMonth:
                    {
                        var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        var endDate = startDate.AddMonths(1).AddDays(-1);
                        conditions.StartDate = startDate;
                        conditions.EndDate = endDate;
                        conditions.InternalIdList = IdList;
                        break;
                    }

                case ContractSearchType.LastMonth:
                    {
                        var startDate = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).AddMonths(-1);
                        var endDate = startDate.AddMonths(1).AddDays(-1);
                        conditions.StartDate = startDate;
                        conditions.EndDate = endDate;
                        conditions.InternalIdList = IdList;
                        break;
                    }

                case ContractSearchType.LastYear:
                    {
                        var startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                        var endDate = startDate.AddYears(1).AddDays(-1);
                        conditions.StartDate = startDate;
                        conditions.EndDate = endDate;
                        conditions.InternalIdList = IdList;
                        break;
                    }
                    
                case ContractSearchType.CurrentYear:
                    {
                        var startDate = new DateTime(DateTime.Today.Year, 1, 1);
                        var endDate = startDate.AddYears(1).AddDays(-1);
                        conditions.StartDate = startDate;
                        conditions.EndDate = endDate;
                        conditions.InternalIdList = IdList;
                        break;
                    }

                case ContractSearchType.Draft:
                    {
                        conditions.IsDraft = true;
                        conditions.CreaterId = CurrentUser.Id;
                        conditions.InternalIdList = IdList;
                        break;
                    }
            }

            return conditions;
        }

        public static string GetModuleNameByContractType(ContractType contractType)
        {
            if(contractType == ContractType.Sales)
            {
                return "SalesContract";
            }
            
            if(contractType == ContractType.Purchase)
            {
                return "PurchaseContract";
            }

            return "";
        }

        #endregion
    }

    /// <summary>
    /// the conditions will be sent to the contract list page
    /// </summary>
    public class ContractSearchConditions
    {
        public int SupplierId { get; set; }
        public int TradeTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CommodityId { get; set; }
        public int InternalCustomerId { get; set; }
        public bool IsDraft { get; set; }
        public int ContractType { get; set; }
        public int CreaterId { get; set; }
        public int? UDFId { get; set; }
        public string SelectExContractNo { get; set; }
        public List<int> InternalIdList { get; set; }
        public bool IsOnlyCurrentUser { get; set; }
        public bool IsOnlyHideRelQuotas { get; set; }
        public string QuotaNo { get; set; }
    }

    /// <summary>
    /// Search Type
    /// </summary>
    internal enum ContractSearchType
    {
        Free,
        LastMonth,
        CurrentMonth,
        LastYear,
        CurrentYear,
        Draft
    }
}