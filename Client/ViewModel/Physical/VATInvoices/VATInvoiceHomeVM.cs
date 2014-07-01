using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceHomeVM : BaseVM
    {
        #region Member

        private int? _bpId;
        private string _bpName;
        private int? _internalBPId;
        private List<BusinessPartner> _internalBPs;
        private VATInvoiceListVM _listVM;
        private List<Commodity> _metals;
        private int? _selectedMetal;
        private Dictionary<string, int> _vatStatus;
        private int? _vatStatusId;
        private DateTime? _implementedStartDate;
        private DateTime? _implementedEndDate;
        private Dictionary<string, int> _vatInvoiceTypes;
        private int? _vatInvoiceTypeId;
        private bool _containCurrentUser = true;

        #endregion

        #region Property

        public DateTime? ImplementedStartDate
        {
            get { return _implementedStartDate; }
            set
            {
                if (_implementedStartDate != value)
                {
                    _implementedStartDate = value;
                    Notify("ImplementedStartDate");
                }
            }
        }

        public DateTime? ImplementedEndDate
        {
            get { return _implementedEndDate; }
            set
            {
                if (_implementedEndDate != value)
                {
                    _implementedEndDate = value;
                    Notify("ImplementedEndDate");
                }
            }
        }

        public int? BPId
        {
            get { return _bpId; }
            set
            {
                if (_bpId != value)
                {
                    _bpId = value;
                    Notify("BPId");
                }
            }
        }

        public int? InternalBPId
        {
            get { return _internalBPId; }
            set
            {
                if (_internalBPId != value)
                {
                    _internalBPId = value;
                    Notify("InternalBPId");
                }
            }
        }

        public List<BusinessPartner> InternalBPs
        {
            get { return _internalBPs; }
            set
            {
                if (_internalBPs != value)
                {
                    _internalBPs = value;
                    Notify("InternalBPs");
                }
            }
        }

        public List<Commodity> Metals
        {
            get { return _metals; }
            set
            {
                if (_metals != value)
                {
                    _metals = value;
                    Notify("Metals");
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

        public string BPName
        {
            get { return _bpName; }
            set
            {
                if (_bpName != value)
                {
                    _bpName = value;
                    Notify("BPName");
                }
            }
        }

        public int? VATStatusId
        {
            get { return _vatStatusId; }
            set
            {
                if (_vatStatusId != value)
                {
                    _vatStatusId = value;
                    Notify("VATStatusId");
                }
            }
        }

        public Dictionary<string, int> VATStatus
        {
            get { return _vatStatus; }
            set
            {
                if (_vatStatus != value)
                {
                    _vatStatus = value;
                    Notify("VATStatus");
                }
            }
        }

        public VATInvoiceListVM ListVM
        {
            get { return _listVM; }
            set
            {
                if (_listVM != value)
                {
                    _listVM = value;
                    Notify("ListVM");
                }
            }
        }

        public Dictionary<string, int> VATInvoiceTypes
        {
            get { return _vatInvoiceTypes; }
            set
            {
                if (_vatInvoiceTypes != value)
                {
                    _vatInvoiceTypes = value;
                    Notify("VATInvoiceTypes");
                }
            }
        }

        public int? VATInvoiceTypeId
        {
            get { return _vatInvoiceTypeId; }
            set
            {
                if (_vatInvoiceTypeId != value)
                {
                    _vatInvoiceTypeId = value;
                    Notify("VATInvoiceTypeId");
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

        #region Constructor

        public VATInvoiceHomeVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public void Initialize()
        {
            GetVATInvoiceTypes();
            GetOpenCollectInvoiceTypes();
            GetMetals();
            GetInternalCustomer();
        }

        #endregion

        #region Method

        public void Load()
        {
            ListVM = new VATInvoiceListVM
                         {
                             BPId = BPId,
                             InternalBPId = InternalBPId,
                             SelectedMetal = SelectedMetal,
                             VATStatusId = VATStatusId,
                             ImplementedStartDate=ImplementedStartDate,
                             ImplementedEndDate=ImplementedEndDate,
                             VATInvoiceTypeId = VATInvoiceTypeId,
                             ContainCurrentUser = ContainCurrentUser
                         };
            ListVM.Init();
        }

        public void Load(DateTime? startDate, DateTime? endDate)
        {
            ListVM = new VATInvoiceListVM { InvoicedStartDate = startDate, InvoicedEndDate = endDate, VATStatusId = (int)QuotaVATStatus.Partial, ContainCurrentUser = ContainCurrentUser };
            // IsUnOpenInvoice大于0标识为未开发票
            ListVM.Init();
        }

        public void GetVATInvoiceTypes()
        {
            VATStatus = new Dictionary<string, int> {{"", 0}};
            VATStatus = EnumHelper.GetEnumDic<QuotaVATStatus>(VATStatus);
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                const bool param = false;
                const string strInfo = "it.IsDeleted = @p1 ";
                var parameters = new List<object> {param};
                Metals = metalService.Select(strInfo, parameters, null);
                Metals.Insert(0, new Commodity {Id = 0, Name = ""});
            }
        }

        public void GetInternalCustomer()
        {
            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalBPs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalBPs.Insert(0, new BusinessPartner {Id = 0, ShortName = ""});
            }
        }
        /// <summary>
        /// 开票/收票 类型
        /// </summary>
        public void GetOpenCollectInvoiceTypes()
        {
            VATInvoiceTypes = new Dictionary<string, int> { { "", 0 } };
            VATInvoiceTypes = EnumHelper.GetEnumDic<VATInvoiceType>(VATInvoiceTypes);
        }
        

        #endregion
    }
}