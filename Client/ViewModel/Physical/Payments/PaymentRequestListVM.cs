using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.Helper;
using Client.PaymentRequestServiceReference;
using Client.ViewModel.Console.ApprovalCenter;
using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using Client.ViewModel.PrintTemplate.PaymentAppTemplate;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Physical.Payments
{
    public class PaymentRequestListVM : BaseVM
    {
        #region Member

        private DateTime? _endDate;
        private bool _isDraft;
        private bool _isPaid;
        private bool _isTrueFalse;
        private List<object> _parameters;
        private int? _payBPId;
        private int? _paymentComplete;
        private int _paymentRequestForm;
        private int _paymentRequestTo;
        private int _paymentRequestTotleCount;
        private List<PaymentRequest> _paymentRequests;
        private string _queryStr;
        private int? _receiveBPId;
        private PaymentRequestListVM _searchVM;
        private DateTime? _startDate;
        private int? _userId;
        private string _quotaNo;
        private bool _isOnlyCurrentUser;
        private bool _isSelectAll;

        #endregion

        #region Property
        public int CheckedPaymentId { get; set; }
        public bool IsOnlyCurrentUser
        {
            get { return _isOnlyCurrentUser; }
            set
            {
                if (_isOnlyCurrentUser != value)
                {
                    _isOnlyCurrentUser = value;
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

        public int PaymentRequestTotleCount
        {
            get { return _paymentRequestTotleCount; }
            set
            {
                if (_paymentRequestTotleCount != value)
                {
                    _paymentRequestTotleCount = value;
                    Notify("PaymentRequestTotleCount");
                }
            }
        }

        public List<PaymentRequest> PaymentRequests
        {
            get { return _paymentRequests; }
            set
            {
                if (_paymentRequests != value)
                {
                    _paymentRequests = value;
                    Notify("PaymentRequests");
                }
            }
        }

        public int PaymentRequestForm
        {
            get { return _paymentRequestForm; }
            set
            {
                if (_paymentRequestForm != value)
                {
                    _paymentRequestForm = value;
                    Notify("PaymentRequestForm");
                }
            }
        }

        public int PaymentRequestTo
        {
            get { return _paymentRequestTo; }
            set
            {
                if (_paymentRequestTo != value)
                {
                    _paymentRequestTo = value;
                    Notify("PaymentRequestTo");
                }
            }
        }

        public bool IsDraft
        {
            get { return _isDraft; }
            set
            {
                if (_isDraft != value)
                {
                    _isDraft = value;
                    Notify("IsDraft");
                }
            }
        }

        public bool IsTrueFalse
        {
            get { return _isTrueFalse; }
            set
            {
                if (_isTrueFalse != value)
                {
                    _isTrueFalse = value;
                    Notify("IsTrueFalse");
                }
            }
        }

        public bool IsPaid
        {
            get { return _isPaid; }
            set
            {
                if (_isPaid != value)
                {
                    _isPaid = value;
                    Notify("IsPaid");
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
                    Notify("PaymentComplete");
                }
            }
        }

        public int? UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    Notify("UserId");
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

        public bool IsSelectAll
        {
            get { return _isSelectAll; }
            set
            {
                if (_isSelectAll != value)
                {
                    _isSelectAll = value;
                    Notify("IsSelectAll");
                }
            }
        }
        #endregion

        #region Method

        public void Init()
        {
            PropertyChanged += OnPropertyChanged;
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelectAll")
            {
                foreach (var pr in PaymentRequests)
                {
                    if (pr.Printable)
                    {
                        pr.IsSelected = IsSelectAll;
                        if (IsSelectAll && pr.QuotaId.HasValue)
                        {
                            int contractId = pr.Quota.ContractId;
                            List<PaymentRequest> list = PaymentRequests.Where(o => o.IsSelected && o.Quota != null && o.Quota.ContractId == contractId && o.Printable).ToList();
                            if (list.Count > 1)
                            {
                                pr.Printable = false;
                            }
                        }
                        else
                        {
                            pr.Printable = true;
                        }
                    }
                    else if (!IsSelectAll)
                    {
                        pr.IsSelected = IsSelectAll;
                        pr.Printable = (pr.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded ||
                                                    pr.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.Approved);
                    }
                }
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            var idList = new List<int>();
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
            if (idList.Count > 0)
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
                        sb.AppendFormat("it.PayBusinessPartner.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.PayBusinessPartner.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (IsOnlyCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            if (UserId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(UserId);
            }
            if (UserId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.ApproveStatus = @p{0} ", num++);
                parameters.Add((int)ApproveStatus.ApproveNotStart);
            }
            if (PayBPId != 0 && PayBPId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PayBPId = @p{0} ", num++);
                parameters.Add(PayBPId);
            }
            if (ReceiveBPId != 0 && ReceiveBPId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.ReceiveBPId = @p{0} ", num++);
                parameters.Add(ReceiveBPId);
            }
            if (StartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.RequestDate >= @p{0} ", num++);
                parameters.Add(StartDate.Value);
            }
            if (EndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.RequestDate <= @p{0} ", num++);
                parameters.Add(EndDate.Value);
            }
            if (PaymentComplete != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IsPaid = @p{0} ", num++);
                parameters.Add(IsPaid);
            }

            if (IsTrueFalse)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy =@p{0} ", num++);
                parameters.Add(CurrentUser.Id);
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IsDraft = @p{0} ", num);
                parameters.Add(IsDraft);
            }

            if (!string.IsNullOrEmpty(QuotaNo))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.QuotaNo like '%" + QuotaNo.Trim() + "%'");
            }

            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }
            sb.Append("it.IsDeleted=false ");

            queryStr = sb.ToString();
        }

        private void InitPage()
        {
            LoadPaymentRequestCount();
        }

        public void LoadPaymentRequestCount()
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                _paymentRequestTotleCount = _queryStr == string.Empty ? paymentrequestService.GetAllCount() : paymentrequestService.GetCount(_queryStr, _parameters);
            }
        }

        public void LoadPaymentRequest()
        {
            using (var paymentrequestService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                if (_queryStr == string.Empty)
                {
                    _queryStr = "1=1";
                }

                PaymentRequests = paymentrequestService.SelectByRangeWithMultiOrderLazyLoad(_queryStr, _parameters,
                                                                                            new List<SortCol> { new SortCol { ByDescending = true, ColName = "RequestDate" } },
                                                                                            PaymentRequestForm, PaymentRequestTo,
                                                                                            new List<string>
                                                                                            {
                                                                                                "PayBusinessPartner",
                                                                                                "ReceiveBusinessPartner",
                                                                                            },
                                                                                            new List<string>
                                                                                            {
                                                                                                "Currency",
                                                                                                "PaymentMean",
                                                                                                "PaymentUsage",
                                                                                                "User",
                                                                                                "Approval",
                                                                                                "Approval.ApprovalStages",
                                                                                                "Approval.ApprovalStages.ApprovalUser",
                                                                                                "FundFlows",
                                                                                                "LetterOfCredits",
                                                                                                "Quota",
                                                                                                "Quota.Contract"
                                                                                            });

                foreach (PaymentRequest pay in PaymentRequests)
                {
                    FilterDeleted(pay.FundFlows);
                    FilterDeleted(pay.LetterOfCredits);

                    decimal result = 0;
                    if (pay.PaymentMean.IsForFundFlow)
                    {
                        result = pay.FundFlows.Aggregate(result, (current, ff) => current + (ff.Amount ?? 0));
                    }
                    else
                    {
                        result = pay.LetterOfCredits.Aggregate(result, (current, lc) => current + (lc.PresentAmount ?? 0));
                    }

                    pay.PaidAmount = result;

                    if (pay.Approval != null)
                    {
                        FilterDeleted(pay.Approval.ApprovalStages);
                        string passed, notPassed;
                        List<ApprovalStage> stages = pay.Approval.ApprovalStages.ToList();
                        ApprovalCenterHomeVM.ParseApprovalDetailString(stages, pay.ApprovalStageIndex ?? 0, out passed,
                                                                       out notPassed);
                        if (pay.ApproveStatus == (int)ApproveStatus.Approved)
                        {
                            pay.CustomerStrField1 = passed + notPassed;
                            pay.CustomerStrField2 = string.Empty;
                        }
                        else
                        {
                            pay.CustomerStrField1 = passed;
                            pay.CustomerStrField2 = notPassed;
                        }
                    }
                }
                IsSelectAll = false;
            }
        }

        public void DeletePaymentRequest(int id)
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                paymentrequestService.RemoveById(id, CurrentUser.Id);
            }
        }

        public bool CanPREditWithApproveStatus(int id)
        {
            using (var prService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc)
                )
            {
                PaymentRequest pr = prService.GetById(id);
                //if (pr.ApproveStatus == (int) ApproveStatus.InApprove ||
                //    pr.ApproveStatus == (int) ApproveStatus.Approved)
                if (pr.ApproveStatus == (int)ApproveStatus.InApprove)
                {
                    return false;
                }
                return true;
            }
        }

        #endregion

        public void PrintSelected()
        {
            var toPrints = PaymentRequests.Where(o => o.IsSelected && o.Printable);
            List<PaymentRequest> list = PaymentRequests.Where(o => o.IsSelected && o.Printable).ToList();
            foreach (var pr in toPrints)
            {
                var reportVM = new PaymentAppTemplateVM(pr.Id);
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.HeaderList } };
                var printHelper = new PrintHelper(dataSources, reportVM.PathName);
                printHelper.Run();
            }
        }

        public void SetPrintCheckBoxSelected(int paymentId, bool selected = true)
        {
            //if (CheckedPaymentId == 0)
            //{
            //    CheckedPaymentId = paymentId;
            //}
            //if (CheckedPaymentId != paymentId)
            //    return;
            PaymentRequest paymentRequest = PaymentRequests.Where(o => o.Id == paymentId).FirstOrDefault();
            if (paymentRequest.QuotaId.HasValue && paymentRequest.Quota.Contract.TradeType == (int)TradeType.LongDomesticTrade)
            {
                List<PaymentRequest> list = PaymentRequests.Where(o =>o.QuotaId.HasValue && o.Quota.ContractId == paymentRequest.Quota.ContractId 
     && (o.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded || o.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.Approved)).ToList();
                foreach (var pr in list)
                {
                    pr.IsSelected = selected;
                    if (selected && pr.Id != paymentId)
                    {
                        pr.Printable = !selected;
                    }
                    else
                    {
                        pr.Printable = true;
                    }
                }
            }

            //CheckedPaymentId = 0;
        }
    }
}