using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class CommercialInvoiceHomeVM : BaseVM
    {
        #region Member

        private Dictionary<string, int> _innerCustomers;
        private int _cTypeId;
        private int _commerTypeId;
        private Dictionary<string, int> _commoditys;
        private DateTime? _endDate;
        private int _interCusId;
        private Dictionary<string, int> _invoiceTypes;
        private int? _sId;
        private string _sName;
        private CommercialInvoiceListVM _searchVM;
        private DateTime? _startDate;
        private bool _IsOnlyCurrentUser = true;
        private string _QuotaNo;

        #endregion

        #region Property
        public string QuotaNo
        { 
            get{return _QuotaNo;}
            set { 
                if(_QuotaNo != value)
                {
                    _QuotaNo = value;
                    Notify("QuotaNo");
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

        public Dictionary<string, int> InvoiceTypes
        {
            get { return _invoiceTypes; }
            set
            {
                if (_invoiceTypes != value)
                {
                    _invoiceTypes = value;
                    Notify("InvoiceTypes");
                }
            }
        }

        public Dictionary<string, int> Commoditys
        {
            get { return _commoditys; }
            set
            {
                if (_commoditys != value)
                {
                    _commoditys = value;
                    Notify("Commoditys");
                }
            }
        }

        public ContractType ContractType { get; set; }

        public CommercialInvoiceListVM SearchVM
        {
            get { return _searchVM; }
            set
            {
                if (_searchVM != value)
                {
                    _searchVM = value;
                    Notify("SearchVM");
                }
            }
        }

        public int? SId
        {
            set
            {
                if (_sId != value)
                {
                    _sId = value;
                    Notify("SId");
                }
            }
            get { return _sId; }
        }

        public string SName
        {
            get { return _sName; }
            set
            {
                if (_sName != value)
                {
                    _sName = value;
                    Notify("SName");
                }
            }
        }

        public int CTypeId
        {
            set
            {
                if (_cTypeId != value)
                {
                    _cTypeId = value;
                    Notify("CTypeId");
                }
            }
            get { return _cTypeId; }
        }

        public int InterCusId
        {
            set
            {
                if (_interCusId != value)
                {
                    _interCusId = value;
                    Notify("InterCusId");
                }
            }
            get { return _interCusId; }
        }

        public int CommerTypeId
        {
            set
            {
                if (_commerTypeId != value)
                {
                    _commerTypeId = value;
                    Notify("CommerTypeId");
                }
            }
            get { return _commerTypeId; }
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

        public Dictionary<string, int> InnerCustomers
        {
            get { return _innerCustomers; }
            set
            {
                if (_innerCustomers != value)
                {
                    _innerCustomers = value;
                    Notify("InnerCustomers");
                }
            }
        }

        #endregion

        #region Method

        public CommercialInvoiceHomeVM()
        {
            LoadInnerCustomer();
            LoadCommoditys();
            LoadInvoiceTypes();
            _endDate = DateTime.Today;
            _startDate = DateTime.Today.AddMonths(-1);
        }

        public void SearchData()
        {
            SearchVM = new CommercialInvoiceListVM(SId, CTypeId, InterCusId, CommerTypeId, ContractType, StartDate,
                                                     EndDate, IsOnlyCurrentUser, QuotaNo);
        }

        public void SearchDataByDate(int? type, ContractType contractType, DateTime? startDate, DateTime? endDate)
        {
            _searchVM = new CommercialInvoiceListVM(null, null, null, type, contractType, startDate, endDate, IsOnlyCurrentUser, QuotaNo);
        }

        private void LoadInnerCustomer()
        {
            InnerCustomers = new Dictionary<string, int> {{"", 0}};
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                busService.GetInternalCustomersByUser(CurrentUser.Id).ForEach(o => InnerCustomers.Add(o.ShortName, o.Id));
            }
        }

        private void LoadCommoditys()
        {
            Commoditys = new Dictionary<string, int> {{"", 0}};
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                commodityService.GetAll().ForEach(o => Commoditys.Add(o.Name, o.Id));
            }
        }

        private void LoadInvoiceTypes()
        {
            InvoiceTypes = new Dictionary<string, int> {{"", 0}};
            InvoiceTypes = EnumHelper.GetEnumDic<CommercialInvoiceType>(InvoiceTypes);
        }

        #endregion
    }
}