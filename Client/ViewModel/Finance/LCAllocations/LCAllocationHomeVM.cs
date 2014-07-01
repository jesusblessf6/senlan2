using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using DBEntity;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Finance.LCAllocations
{
    public class LCAllocationHomeVM : BaseVM
    {
        #region Others

        public enum QueryType
        {
            Free,
            CurrentMonth,
            CurrentYear
        }

        #endregion

        #region Members & Properties

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

        private DateTime? _enquireStartDate;
        public DateTime? EnquireStartDate
        {
            get { return _enquireStartDate; }
            set
            {
                if (_enquireStartDate != value)
                {
                    _enquireStartDate = value;
                    Notify("EnquireStartDate");
                }
            }
        }

        private DateTime? _enquireEndDate;
        public DateTime? EnquireEndDate
        {
            get { return _enquireEndDate; }
            set
            {
                if (_enquireEndDate != value)
                {
                    _enquireEndDate = value;
                    Notify("EnquireEndDate");
                }
            }
        }

        private DateTime? _discountStartDate;
        public DateTime? DiscountStartDate
        {
            get { return _discountStartDate; }
            set
            {
                if (_discountStartDate != value)
                {
                    _discountStartDate = value;
                    Notify("DiscountStartDate");
                }
            }
        }

        private DateTime? _discountEndDate;
        public  DateTime? DiscountEndDate
        {
            get { return _discountEndDate; }
            set
            {
                if (_discountEndDate != value)
                {
                    _discountEndDate = value;
                    Notify("DiscountEndDate");
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



        private bool _onlyForCurrentUser;
        public bool OnlyForCurrentUser
        {
            get { return _onlyForCurrentUser; }
            set
            {
                if (_onlyForCurrentUser != value)
                {
                    _onlyForCurrentUser = value;
                    Notify("OnlyForCurrentUser");
                }
            }
        }

        #endregion

        #region Constructor

        public LCAllocationHomeVM()
        {
            _onlyForCurrentUser = true;

            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }
        }

        #endregion

        #region Method

        public List<QueryElement> GetQueryElements(QueryType type)
        {
            var elements = new List<QueryElement>();
            switch (type)
            {
                case(QueryType.CurrentMonth):
                    {
                        var tmpStartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        var tmpEndDate = tmpStartDate.AddMonths(1).AddDays(-1);
                        elements.Add(new QueryElement { FieldName = "EnquireDate", Operator = Operator.GreaterEqualThan, Value = tmpStartDate });
                        elements.Add(new QueryElement { FieldName = "EnquireDate", Operator = Operator.LessEqualThan, Value = tmpEndDate });
                    }
                    break;

                case(QueryType.CurrentYear):
                    {
                        var tmpStartDate = new DateTime(DateTime.Today.Year, 1, 1);
                        var tmpEndDate = tmpStartDate.AddYears(1).AddDays(-1);
                        elements.Add(new QueryElement{FieldName = "EnquireDate", Operator = Operator.GreaterEqualThan, Value = tmpStartDate});
                        elements.Add(new QueryElement{FieldName = "EnquireDate", Operator = Operator.LessEqualThan, Value = tmpEndDate});
                    }
                    break;

                case(QueryType.Free):
                    {
                        if (BPId > 0)
                        {
                            elements.Add(new QueryElement{FieldName = "BusinessPartnerId", Operator = Operator.Equal, Value = BPId});
                        }

                        if (SelectedInternalCustomerId > 0)
                        {
                            elements.Add(new QueryElement{FieldName = "InternalCustomerId", Operator = Operator.Equal, Value = SelectedInternalCustomerId});
                        }

                        if (EnquireStartDate != null)
                        {
                            elements.Add(new QueryElement{FieldName = "EnquireDate", Operator = Operator.GreaterEqualThan, Value = EnquireStartDate});
                        }

                        if (EnquireEndDate != null)
                        {
                            elements.Add(new QueryElement{FieldName = "EnquireDate", Operator = Operator.LessEqualThan, Value = EnquireEndDate});
                        }

                        if (DiscountStartDate != null)
                        {
                            elements.Add(new QueryElement{FieldName = "DiscountDate", Operator = Operator.GreaterEqualThan, Value = DiscountStartDate});
                        }

                        if (DiscountEndDate != null)
                        {
                            elements.Add(new QueryElement { FieldName = "DiscountDate", Operator = Operator.LessEqualThan, Value = DiscountEndDate});
                        }

                        if (!string.IsNullOrWhiteSpace(IssueBankName))
                        {
                            elements.Add(new QueryElement{FieldName = "IssueBankName", Operator = Operator.Like, Value = "%"+IssueBankName + "%"});
                        }

                        if (!string.IsNullOrWhiteSpace(AcceptingBankName))
                        {
                            elements.Add(new QueryElement{FieldName = "AcceptingBankName", Operator = Operator.Like, Value = "%" + AcceptingBankName + "%"});
                        }

                        if (OnlyForCurrentUser)
                        {
                            elements.Add(new QueryElement
                                             {
                                                 FieldName = "CreatedBy",
                                                 Operator = Operator.Equal,
                                                 Value = CurrentUser.Id
                                             });
                        }
                        
                        for (int i = 0; i < InternalCustomers.Count; i++)
                        {
                            var e = new QueryElement
                                        {
                                            FieldName = "InternalCustomerId", Operator = Operator.Equal, Value = InternalCustomers[i].Id
                                        };
                            if (i == 0)
                            {
                                e.RelationToLeft = Relation.And;
                                e.WithLeftBracket = true;
                            }
                            else
                            {
                                e.RelationToLeft = Relation.Or;
                                if (i == InternalCustomers.Count - 1)
                                {
                                    e.WithRightBracket = true;
                                }
                            }

                            elements.Add(e);
                        }
                    }
                    break;
            }
            return elements;
        }

        public void Reset()
        {
            BPId = 0;
            BPName = string.Empty;
            SelectedInternalCustomerId = 0;
            EnquireStartDate = null;
            EnquireEndDate = null;
            DiscountStartDate = null;
            DiscountEndDate = null;
            IssueBankName = string.Empty;
            AcceptingBankName = string.Empty;
            OnlyForCurrentUser = true;
        }

        #endregion
    }
}
