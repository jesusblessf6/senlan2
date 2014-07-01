using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceRequestHomeVM : BaseVM
    {
        #region Member

        private Dictionary<string, int> _approveStatus;
        private int? _approveStatusID;
        private int? _bpId;
        private string _bpName;
        private int? _internalBPId;
        private List<BusinessPartner> _internalBPs;
        private VATInvoiceRequestListVM _listVM;
        private List<Commodity> _metals;
        private int? _selectedMetal;
        private bool _IsOnlyCurrentUser = true;
        private DateTime? _StartDate;
        private DateTime? _EndDate;
        private decimal? _VerifiedQuantity;
        #endregion

        #region Property
        public decimal? VerifiedQuantity
        {
            get { return _VerifiedQuantity; }
            set {
                if (_VerifiedQuantity != value)
                {
                    _VerifiedQuantity = value;
                    Notify("VerifiedQuantity");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { 
                if(_EndDate != value)
                {
                    _EndDate = value;
                    Notify("EndDate");
                }
            }
        }

        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { 
                if(_StartDate != value)
                {
                    _StartDate = value;
                    Notify("StartDate");
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

        public int? ApproveStatusID
        {
            get { return _approveStatusID; }
            set
            {
                if (_approveStatusID != value)
                {
                    _approveStatusID = value;
                    Notify("ApproveStatusID");
                }
            }
        }

        public Dictionary<string, int> ApproveStatus
        {
            get { return _approveStatus; }
            set
            {
                if (_approveStatus != value)
                {
                    _approveStatus = value;
                    Notify("ApproveStatus");
                }
            }
        }

        public VATInvoiceRequestListVM ListVM
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

        #endregion

        #region Constructor

        public VATInvoiceRequestHomeVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public void Initialize()
        {
            GetApproveStatus();
            GetMetals();
            GetInternalCustomer();
        }

        #endregion

        #region Method

        public void Load()
        {
            ListVM = new VATInvoiceRequestListVM
                         {
                             BPId = BPId,
                             InternalBPId = InternalBPId,
                             SelectedMetal = SelectedMetal,
                             ApproveStatusID = ApproveStatusID,
                             IsOnlyCurrentUser = IsOnlyCurrentUser,
                             RequestStartDate = StartDate,
                             RequestEndDate = EndDate,
                             VerifiedQuantity = VerifiedQuantity
                         };
            ListVM.Init(false);
        }

        public void Load(DateTime? startDate, DateTime? endDate, int? createdBy)
        {
            ListVM = new VATInvoiceRequestListVM
            {
                RequestStartDate=startDate,
                RequestEndDate=endDate,
                CreatedBy=createdBy
            };
            ListVM.Init(false);
        }

        public void GetApproveStatus()
        {
            ApproveStatus = new Dictionary<string, int> {{"", 0}};
            ApproveStatus = EnumHelper.GetEnumDic<ApproveStatus>(ApproveStatus);
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

        #endregion
    }
}