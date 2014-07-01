using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Payments
{
    public class PaymentRequestHomeVM : BaseVM
    {
        #region Member

        private DateTime? _endDate;
        private Dictionary<string, int> _prStatus;
        private PaymentRequestListVM _searchVM;
        private DateTime? _startDate;
        private List<BusinessPartner> _businesspartner;
        private int? _payBPId;
        private int? _paymentComplete;
        private int? _receiveBPId;
        private string _shortName;
        private string _quotaNo;
        private bool _IsOnlyCurrentUser = true;
        #endregion

        #region Properties
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


        public int? PayBPId
        {
            get { return _payBPId; }
            set
            {
                if (_payBPId != value)
                {
                    _payBPId = value;
                    Notify("PayBPId");
                }
            }
        }

        public int? ReceiveBPId
        {
            get { return _receiveBPId; }
            set
            {
                if (_receiveBPId != value)
                {
                    _receiveBPId = value;
                    Notify("ReceiveBPId");
                }
            }
        }

        public List<BusinessPartner> BusinessPartners
        {
            get { return _businesspartner; }
            set
            {
                _businesspartner = value;
                Notify("BusinessPartners");
            }
        }

        public string ShortName
        {
            get { return _shortName; }
            set
            {
                if (_shortName != value)
                {
                    _shortName = value;
                    Notify("ShortName");
                }
            }
        }

        public PaymentRequestListVM SearchVM
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

        public Dictionary<string, int> PRStatus
        {
            get { return _prStatus; }
            set
            {
                if (_prStatus != value)
                {
                    _prStatus = value;
                    Notify("PRStatus");
                }
            }
        }

        public int? PaymentComplete
        {
            get { return _paymentComplete; }
            set
            {
                if (_paymentComplete != value)
                {
                    _paymentComplete = value;
                    Notify("ReceiveBPId");
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

        public PaymentRequestHomeVM()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            LoadPayBusinessPartner();
            LoadPaymentRequestStatusr();
        }

        #endregion

        #region Method

        #region 内部客户

        public void LoadPayBusinessPartner()
        {
            using (
                var paybusinesspartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                BusinessPartners = paybusinesspartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                BusinessPartners.Insert(0, new BusinessPartner {Id = 0, ShortName = string.Empty});
            }
        }

        #endregion

        #region 付款状态

        public void LoadPaymentRequestStatusr()
        {
            _prStatus = new Dictionary<string, int>();
            _prStatus = EnumHelper.GetEnumDic<PaymentRequestStatus>(_prStatus);
        }

        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        public void LoadSearch()
        {
            SearchVM = new PaymentRequestListVM { StartDate = StartDate, EndDate = EndDate, PayBPId = PayBPId, ReceiveBPId = ReceiveBPId, QuotaNo = QuotaNo, IsOnlyCurrentUser = IsOnlyCurrentUser };
            if (PaymentComplete != null)
            {
                SearchVM.PaymentComplete = PaymentComplete;
                SearchVM.IsPaid = PaymentComplete == 1;
            }
            SearchVM.Init();
        }

        /// <summary>
        /// 本人付款申请草稿查询
        /// </summary>
        public void LoadDraftSearch()
        {
            SearchVM = new PaymentRequestListVM {IsDraft = true, IsTrueFalse = true};
            SearchVM.Init();
        }

        /// <summary>
        /// 本人付款申请草稿查询
        /// </summary>
        public void LoadApproveSearch()
        {
            SearchVM = new PaymentRequestListVM {UserId = CurrentUser.Id};
            SearchVM.Init();
        }

        #endregion
    }
}