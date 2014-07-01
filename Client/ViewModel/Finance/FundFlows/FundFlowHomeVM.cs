using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.QueryManagement;
using Utility.ServiceManagement;
using System.Linq;
using Client.PaymentMeanServiceReference;
using Utility.Misc;

namespace Client.ViewModel.Finance.FundFlows
{
    public class FundFlowHomeVM : HomeBaseVM
    {
        #region search type enum

        public enum FundFlowSearchType
        {
            Free,
            CurrentMonthPmt,
            CurrentMontRecpt,
            CurrentYearPmt,
            CurrentYearRecpt
        }

        #endregion

        #region Member

        private string _bPartnerName;
        private DateTime? _endDate;
        private string _financialAccountName;
        private int _icId;
        private List<BusinessPartner> _internalCustomers;
        private DateTime? _startDate;
        private int _selectedBPartnerId;
        private int _selectedFinancialAccountId;
        private bool _containCurrentUser = true;
        private int _paymentMeanId;
        private List<PaymentMean> _paymentMeans;
        private List<EnumItem> _fundFlowTypes;
        private int _selectFundFlowType;
        private string _QuotaNo;

        #endregion

        #region Property
        public string QuotaNo
        {
            get { return _QuotaNo;}
            set { 
                if(_QuotaNo != value)
                {
                    _QuotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public int SelectFundFlowType
        {
            get { return _selectFundFlowType; }
            set
            {
                if (_selectFundFlowType != value)
                {
                    _selectFundFlowType = value;
                    Notify("SelectFundFlowType");
                }
            }
        }

        public List<EnumItem> FundFlowTypes
        {
            get { return _fundFlowTypes; }
            set
            {
                _fundFlowTypes = value;
                Notify("FundFlowTypes");              
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

        public int ICId
        {
            get { return _icId; }
            set
            {
                if (_icId != value)
                {
                    _icId = value;
                    Notify("ICId");
                }
            }
        }

        public int SelectedFinancialAccountId
        {
            get { return _selectedFinancialAccountId; }
            set
            {
                if (_selectedFinancialAccountId != value)
                {
                    _selectedFinancialAccountId = value;
                    Notify("SelectedFinancialAccountId");
                }
            }
        }


        public string FinancialAccountName
        {
            get { return _financialAccountName; }
            set
            {
                if (_financialAccountName != value)
                {
                    _financialAccountName = value;
                    Notify("FinancialAccountName");
                }
            }
        }


        public int SelectedBPartnerId
        {
            get { return _selectedBPartnerId; }
            set
            {
                if (_selectedBPartnerId != value)
                {
                    _selectedBPartnerId = value;
                    Notify("SelectedBPartnerId");
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

        public List<PaymentMean> PaymentMeans
        {
            get { return _paymentMeans; }
            set
            {
                _paymentMeans = value;
                Notify("PaymentMeans");
            }
        }

        public int PaymentMeanId
        {
            get { return _paymentMeanId; }
            set
            {
                if (_paymentMeanId != value)
                {
                    _paymentMeanId = value;
                    Notify("PaymentMeanId");
                }
            }
        }
        #endregion

        #region Constructor

        public FundFlowHomeVM()
        {
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }

            //付款方式
            using (var receivepaymentmeanService =
                    SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc))
            {
                _paymentMeans = receivepaymentmeanService.GetAll();
                _paymentMeans.Insert(0, new PaymentMean());
            }

            _fundFlowTypes = EnumHelper.GetEnumList<FundFlowType>();

            _startDate = DateTime.Today;
            _endDate = DateTime.Today;
        }

        public override void Reset()
        {
            SelectedBPartnerId = 0;
            BPartnerName = string.Empty;
            SelectedFinancialAccountId = 0;
            FinancialAccountName = string.Empty;
            StartDate = null;
            EndDate = null;
            ICId = 0;
            PaymentMeanId = 0;
        }

        public override List<QueryElement> GetQueryElements(object queryType = null)
        {
            var type = queryType == null ? FundFlowSearchType.Free : (FundFlowSearchType)queryType;
            var elements = new List<QueryElement>();
            
            DateTime tmpDate;

            switch (type)
            {
                case FundFlowSearchType.CurrentMontRecpt:
                    elements.Add(new QueryElement { FieldName = "RorP", Operator = Operator.Equal, Value = (int)FundFlowType.Receive });
                    tmpDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.GreaterEqualThan, Value = tmpDate });
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.LessEqualThan, Value = tmpDate.AddMonths(1).AddDays(-1) });
                    break;

                case FundFlowSearchType.CurrentMonthPmt:
                    elements.Add(new QueryElement { FieldName = "RorP", Operator = Operator.Equal, Value = (int)FundFlowType.Pay });
                    tmpDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.GreaterEqualThan, Value = tmpDate });
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.LessEqualThan, Value = tmpDate.AddMonths(1).AddDays(-1) });
                    break;

                case FundFlowSearchType.CurrentYearPmt:
                    elements.Add(new QueryElement { FieldName = "RorP", Operator = Operator.Equal, Value = (int)FundFlowType.Pay });
                    tmpDate = new DateTime(DateTime.Today.Year, 1, 1);
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.GreaterEqualThan, Value = tmpDate });
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.LessEqualThan, Value = tmpDate.AddYears(1).AddDays(-1) });
                    break;

                case FundFlowSearchType.CurrentYearRecpt:
                    elements.Add(new QueryElement { FieldName = "RorP", Operator = Operator.Equal, Value = (int)FundFlowType.Receive });
                    tmpDate = new DateTime(DateTime.Today.Year, 1, 1);
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.GreaterEqualThan, Value = tmpDate });
                    elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.LessEqualThan, Value = tmpDate.AddYears(1).AddDays(-1) });
                    break;

                case FundFlowSearchType.Free:
                    var idList = new List<int>();
                    using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
                    {
                        List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                        if (list.Count > 0)
                        {
                            idList = list.Select(c => c.Id).ToList();
                        }
                    }
                    if (ICId > 0)
                    {
                        elements.Add(new QueryElement { FieldName = "InternalBPId", Operator = Operator.Equal, Value = ICId });
                    }
                    else
                    {
                        if (idList.Count > 0)
                        {
                            for (int j = 0; j < idList.Count; j++)
                            {
                                if (j == 0 && j == idList.Count - 1)
                                {
                                    elements.Add(new QueryElement { FieldName = "InternalBPId", Operator = Operator.Equal, Value = idList[j]});
                                }
                                else if(j == 0)
                                {
                                    elements.Add(new QueryElement { FieldName = "InternalBPId", Operator = Operator.Equal, Value = idList[j], WithLeftBracket = true });
                                }
                                else if (j == idList.Count - 1)
                                {
                                    elements.Add(new QueryElement { FieldName = "InternalBPId", Operator = Operator.Equal, Value = idList[j], RelationToLeft = Relation.Or, WithRightBracket = true });
                                }
                                else
                                {
                                    elements.Add(new QueryElement { FieldName = "InternalBPId", Operator = Operator.Equal, Value = idList[j], RelationToLeft = Relation.Or });
                                }
                            }
                        }
                    }
                    if (SelectedBPartnerId > 0)
                    {
                        elements.Add(new QueryElement { FieldName = "BPId", Operator = Operator.Equal, Value = SelectedBPartnerId });
                    }
                    if (SelectedFinancialAccountId > 0)
                    {
                        elements.Add(new QueryElement { FieldName = "FinancialAccountId", Operator = Operator.Equal, Value = SelectedFinancialAccountId });
                    }
                    if (StartDate != null)
                    {
                        elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.GreaterEqualThan, Value = StartDate });
                    }
                    if (EndDate != null)
                    {
                        elements.Add(new QueryElement { FieldName = "TradeDate", Operator = Operator.LessEqualThan, Value = EndDate });
                    }
                    if (PaymentMeanId > 0)
                    {
                        elements.Add(new QueryElement { FieldName = "PaymentMeanId", Operator = Operator.Equal, Value = PaymentMeanId });
                    }
                    if (SelectFundFlowType > 0)
                    {
                        elements.Add(new QueryElement { FieldName = "RorP", Operator = Operator.Equal, Value = SelectFundFlowType });
                    }
                    if(!string.IsNullOrEmpty(QuotaNo))
                    {
                        elements.Add(new QueryElement { FieldName = "Quota.QuotaNo", Operator = Operator.Like, Value = QuotaNo });
                    }
                    if (ContainCurrentUser)
                        elements.Add(new QueryElement { FieldName = "CreatedBy", Operator = Operator.Equal, Value = CurrentUser.Id });
                    break;
            }

            return elements;
        }

        #endregion
    }
}