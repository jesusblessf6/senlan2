using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.CurrencyServiceReference;
using Client.LCAllocationServiceReference;
using Client.UserServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Finance.LCAllocations
{
    public class LCAllocationDetailVM : ObjectBaseVM
    {
        #region Members & Properties

        private string _bpName;
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

        private int _bpId;
        public int BPId
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

        private List<BusinessPartner> _internalCustomers;
        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set 
            { 
                _internalCustomers = value;
                Notify("InternalCustomers");
            }
        }

        private int _selectedInternalCustomerId;
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

        private DateTime? _enquireDate;
        public DateTime? EnquireDate
        {
            get { return _enquireDate; }
            set
            {
                if (_enquireDate != value)
                {
                    _enquireDate = value;
                    Notify("EnquireDate");
                }
            }
        }

        private List<Commodity> _commodities;
        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
            }
        }

        private int _selectedCommodityId;
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

        private string _issueBankName;
        public string IssueBankName
        {
            get { return _issueBankName; }
            set
            {
                if (_issueBankName != value)
                {
                    _issueBankName = value;
                    Notify("IssueBankName");
                }
            }
        }

        private string _acceptingBankName;
        public string AcceptingBankName
        {
            get { return _acceptingBankName; }
            set
            {
                if (_acceptingBankName != value)
                {
                    _acceptingBankName = value;
                    Notify("AcceptingBankName");
                }
            }
        }

        private List<Currency> _currencies;
        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                Notify("Currencies");
            }
        }

        private int _selectedCurrencyId;
        public int SelectedCurrencyId
        {
            get { return _selectedCurrencyId; }
            set
            {
                if (_selectedCurrencyId != value)
                {
                    _selectedCurrencyId = value;
                    Notify("SelectedCurrencyId");
                }
            }
        }

        private int? _days;
        public int? Days
        {
            get { return _days;}
            set
            {
                if (_days != value)
                {
                    _days = value;
                    Notify("Days");
                }
            }
        }

        private decimal? _quantity;
        public decimal? Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    Notify("Quantity");
                }
            }
        }

        private decimal? _amount;
        public decimal? Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    Notify("Amount");
                }
            }
        }

        private string _quotation;
        public string Quotation
        {
            get { return _quotation; }
            set
            {
                if (_quotation != value)
                {
                    _quotation = value;
                    Notify("Quotation");
                }
            }
        }

        private DateTime? _issueDate;
        public DateTime? IssueDate
        {
            get { return _issueDate; }
            set
            {
                if (_issueDate != value)
                {
                    _issueDate = value;
                    Notify("IssueDate");
                }
            }
        }

        private DateTime? _discountDate;
        public DateTime? DiscountDate
        {
            get { return _discountDate; }
            set
            {
                if (_discountDate != value)
                {
                    _discountDate = value;
                    Notify("DiscountDate");
                }
            }
        }

        private string _actualDiscounting;
        public string ActualDiscounting
        {
            get { return _actualDiscounting; }
            set
            {
                if (_actualDiscounting != value)
                {
                    _actualDiscounting = value;
                    Notify("ActualDiscounting");
                }
            }
        }

        private List<User> _responsors;
        public List<User> Responsors
        {
            get { return _responsors; }
            set
            {
                _responsors = value;
                Notify("Responsors");
            }
        }

        private int _selectedResponsorId;
        public int SelectedResponsorId
        {
            get { return _selectedResponsorId; }
            set
            {
                if (_selectedResponsorId != value)
                {
                    _selectedResponsorId = value;
                    Notify("SelectedResponsorId");
                }
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    Notify("Comments");
                }
            }
        }

        private bool _isCanceled;
        public bool IsCanceled
        {
            get { return _isCanceled; }
            set
            {
                if (_isCanceled != value)
                {
                    _isCanceled = value;
                    Notify("IsCanceled");
                }
            }
        }
        
        #endregion

        #region Constructor

        public LCAllocationDetailVM()
        {
            Initialize();
        }

        public LCAllocationDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        private void Initialize()
        {
            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }

            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }

            using (var currService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                _currencies = currService.GetAll();
                _currencies.Insert(0, new Currency());
            }

            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                _responsors = userService.GetAll();
                _responsors.Insert(0, new User());
            }

            if (ObjectId > 0)
            {
                using (
                    var lcallocatioService =
                        SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
                {
                    var lca = lcallocatioService.FetchById(ObjectId, new List<string> {"BusinessPartner"});
                    _bpId = lca.BusinessPartnerId;
                    _bpName = lca.BusinessPartner.ShortName;
                    _selectedInternalCustomerId = lca.InternalCustomerId;
                    _enquireDate = lca.EnquireDate;
                    _selectedCommodityId = lca.CommodityId ?? 0;
                    _issueBankName = lca.IssueBankName;
                    _acceptingBankName = lca.AcceptingBankName;
                    _selectedCurrencyId = lca.CurrencyId ?? 0;
                    _days = lca.Days;
                    _quantity = lca.Quantity;
                    _amount = lca.Amount;
                    _quotation = lca.Quotation;
                    _issueDate = lca.IssueDate;
                    _discountDate = lca.DiscountDate;
                    _actualDiscounting = lca.ActualDiscounting;
                    _selectedResponsorId = lca.ResponsorId ?? 0;
                    _comments = lca.Comments;
                    _isCanceled = lca.IsCanceled;
                }
            }
            else
            {
                _enquireDate = DateTime.Today;
                _isCanceled = false;
            }
        }

        protected override void Create()
        {
            var lca = new LCAllocation
                          {
                              BusinessPartnerId = BPId,
                              InternalCustomerId = SelectedInternalCustomerId,
                              EnquireDate = EnquireDate,
                              CommodityId = ZeroToNull(SelectedCommodityId),
                              IssueBankName = IssueBankName,
                              AcceptingBankName = AcceptingBankName,
                              CurrencyId = ZeroToNull(SelectedCurrencyId),
                              Days = Days,
                              Quantity = Quantity,
                              Amount = Amount,
                              Quotation = Quotation,
                              IssueDate = IssueDate,
                              DiscountDate = DiscountDate,
                              ActualDiscounting = ActualDiscounting,
                              ResponsorId = ZeroToNull(SelectedResponsorId),
                              Comments = Comments,
                              IsCanceled = IsCanceled
                          };

            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                lcaService.CreateNew(lca, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                var lca = lcaService.GetById(ObjectId);
                lca.BusinessPartnerId = BPId;
                lca.InternalCustomerId = SelectedInternalCustomerId;
                lca.EnquireDate = EnquireDate;
                lca.CommodityId = ZeroToNull(SelectedCommodityId);
                lca.IssueBankName = IssueBankName;
                lca.AcceptingBankName = AcceptingBankName;
                lca.CurrencyId = ZeroToNull(SelectedCurrencyId);
                lca.Days = Days;
                lca.Quantity = Quantity;
                lca.Amount = Amount;
                lca.Quotation = Quotation;
                lca.IssueDate = IssueDate;
                lca.DiscountDate = DiscountDate;
                lca.ActualDiscounting = ActualDiscounting;
                lca.ResponsorId = ZeroToNull(SelectedResponsorId);
                lca.Comments = Comments;
                lca.IsCanceled = IsCanceled;

                lcaService.UpdateExisted(lca, CurrentUser.Id);
            }
        }

        public override bool Validate()
        {
            if (BPId == 0)
            {
                throw new Exception("请选择客户！");
            }

            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception("请选择内部客户！");
            }
            return true;
        }

        private int? ZeroToNull(int? v)
        {
            return v == 0 ? null : v;
        }

        #endregion
    }
}

