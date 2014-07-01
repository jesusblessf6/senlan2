using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.CurrencyServiceReference;
using Client.FinancialAccountServiceReference;
using Client.PaymentRequestServiceReference;
using Client.PaymentUsageServiceReference;
using Client.View.Physical.Payments;
using Client.ViewModel.Console.ApprovalCenter;
using Client.ViewModel.Finance.FundFlows;
using Client.ViewModel.Finance.LetterOfCredits;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BankAccountServiceReference;
using System.Windows.Forms;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Physical.Payments
{
    public class PaymentWorkbenchVM : BaseVM
    {
        #region Menber

        private DateTime? _endDate;
        private DateTime? _startDate;
        private List<BusinessPartner> _businesspartner;
        private int? _commodityId;
        private List<Commodity> _commoditys;
        private List<Currency> _currencys;
        private IssueLCDetailVM _lcVM;
        private FundFlowDetailVM _pVM;
        private int? _payBPId;
        private List<BankAccount> _paybankaccounts;
        private int _paymentRequestId;
        private List<PaymentRequest> _paymentRequests;
        private int? _paymentUsageId;
        private int _paymentWorkbendchForm;
        private int _paymentWorkbendchTo;
        private int _paymentWorkbendchTotleCount;
        private List<PaymentMean> _paymentmeans;
        private List<PaymentUsage> _paymentusages;
        private int? _receiveBPId;
        private List<BankAccount> _receivebankaccounts;
        private string _shortName;
        private decimal _fwAmount;
        private decimal _lcAmount;
        private List<object> _parameters;
        private string _queryStr;
        private int? _paymentMeanId;
        private string _quotaNo;

        #endregion

        #region Property

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

        public int? PaymentUsageId
        {
            get { return _paymentUsageId; }
            set
            {
                if (_paymentUsageId != value)
                {
                    _paymentUsageId = value;
                    Notify("PaymentUsageId");
                }
            }
        }

        public int? CommodityId
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

        public List<Currency> Currencys
        {
            get { return _currencys; }
            set
            {
                _currencys = value;
                Notify("Currencys");
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

        public List<BankAccount> PayBankAccounts
        {
            get { return _paybankaccounts; }
            set
            {
                _paybankaccounts = value;
                Notify("PayBankAccounts");
            }
        }

        public List<BankAccount> ReceiveBankAccounts
        {
            get { return _receivebankaccounts; }
            set
            {
                _receivebankaccounts = value;
                Notify("ReceiveBankAccounts");
            }
        }

        public List<PaymentMean> PaymentMeans
        {
            get { return _paymentmeans; }
            set
            {
                _paymentmeans = value;
                Notify("PaymentMeans");
            }
        }

        public List<PaymentUsage> PaymentUsages
        {
            get { return _paymentusages; }
            set
            {
                _paymentusages = value;
                Notify("PaymentMeans");
            }
        }

        public List<Commodity> Commoditys
        {
            get { return _commoditys; }
            set
            {
                _commoditys = value;
                Notify("Commoditys");
            }
        }

        public int PaymentWorkbendchTotleCount
        {
            get { return _paymentWorkbendchTotleCount; }
            set
            {
                if (_paymentWorkbendchTotleCount != value)
                {
                    _paymentWorkbendchTotleCount = value;
                    Notify("PaymentWorkbendchTotleCount");
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

        public int PaymentWorkbendchForm
        {
            get { return _paymentWorkbendchForm; }
            set
            {
                if (_paymentWorkbendchForm != value)
                {
                    _paymentWorkbendchForm = value;
                    Notify("PaymentWorkbendchForm");
                }
            }
        }

        public int PaymentWorkbendchTo
        {
            get { return _paymentWorkbendchTo; }
            set
            {
                if (_paymentWorkbendchTo != value)
                {
                    _paymentWorkbendchTo = value;
                    Notify("PaymentWorkbendchTo");
                }
            }
        }

        public int PaymentRequestId
        {
            get { return _paymentRequestId; }
            set
            {
                if (_paymentRequestId != value)
                {
                    _paymentRequestId = value;
                    Notify("PaymentRequestId");
                }
            }
        }

        public FundFlowDetailVM PVM
        {
            get { return _pVM; }
            set
            {
                if (_pVM != value)
                {
                    _pVM = value;
                    Notify("PVM");
                }
            }
        }

        public IssueLCDetailVM LCVM
        {
            get { return _lcVM; }
            set
            {
                if (_lcVM != value)
                {
                    _lcVM = value;
                    Notify("LCVM");
                }
            }
        }

        public int? PaymentMeanId
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

        public PaymentWorkbenchVM()
        {
            LoadPayBusinessPartner();
            LoadPaymentUsages();
            LoadCommoditys();
        }

        #endregion

        #region Method

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

        public void LoadPaymentUsages()
        {
            using (
                var paymentusagesService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                PaymentUsages = paymentusagesService.GetAll();
                PaymentUsages.Insert(0, new PaymentUsage {Id = 0, Name = string.Empty});
            }
        }

        public void LoadCommoditys()
        {
            using (var commoditysService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commoditys = commoditysService.GetAll();
                Commoditys.Insert(0, new Commodity {Id = 0, Name = string.Empty});
            }
        }

        public void Init()
        {
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            List<int> idList = new List<int>();
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
            sb.Append("it.IsPaid=false and (it.ApproveStatus==" + Convert.ToInt32(ApproveStatus.Approved) + " or it.ApproveStatus==" + Convert.ToInt32(ApproveStatus.NoApproveNeeded) + ")");

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
            if (PaymentUsageId != 0 && PaymentUsageId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PaymentUsageId = @p{0} ", num++);
                parameters.Add(PaymentUsageId);
            }
            if (CommodityId != 0 && CommodityId != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.CommodityId = @p{0} ", num++);
                parameters.Add(CommodityId);
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
                parameters.Add(EndDate.Value.AddDays(1).AddMinutes(-1));
            }
            if (!string.IsNullOrWhiteSpace(QuotaNo))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.QuotaNo Like @p{0} ", num);
                parameters.Add("%" + QuotaNo.Trim() + "%");
            }
            queryStr = sb.ToString();
        }

        private void InitPage()
        {
            LoadPaymentWorkbendchCount();
        }

        public void LoadPaymentWorkbendchCount()
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _paymentWorkbendchTotleCount = queryStr == string.Empty ? paymentrequestService.GetAllCount() : paymentrequestService.GetCount(queryStr, parameters);
            }
        }

        public void LoadPaymentWorkbendch()
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                var includes = new List<string>
                                   {
                                       "Quota",
                                       "Quota.Commodity",
                                       "Currency",
                                       "PayBusinessPartner",
                                       "ReceiveBusinessPartner",
                                       "PaymentMean",
                                       "PaymentUsage",
                                       "User",
                                       "FundFlows",
                                       "LetterOfCredits",
                                       "Approval",
                                       "Approval.ApprovalStages",
                                       "Approval.ApprovalStages.ApprovalUser",
                                       "ReceiveBankAccount",
                                       "PayBankAccount",
                                       "ReceiveBankAccount.Bank",
                                       "PayBankAccount.Bank"
                                   }; 
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    PaymentRequests =
                        paymentrequestService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                    PaymentWorkbendchForm,
                                                                    PaymentWorkbendchTo, includes);
                }
                else
                {
                    PaymentRequests = paymentrequestService.SelectByRangeWithOrder(queryStr, parameters,
                                                                                   new SortCol
                                                                                       {
                                                                                           ByDescending = true,
                                                                                           ColName = "Id"
                                                                                       },
                                                                                   PaymentWorkbendchForm,
                                                                                   PaymentWorkbendchTo, includes);
                }

                foreach (var pay in PaymentRequests)
                {
                    FilterDeleted(pay.FundFlows);
                    FilterDeleted(pay.LetterOfCredits);
                    #region 计算已付金额
                    decimal result = 0;
                    //if (pay.PaymentMean.Name == "LC" || pay.PaymentMean.Name == "L/C")
                    //{
                    //    result = pay.LetterOfCredits.Aggregate(result, (current, lc) => current + (lc.PresentAmount ?? 0));
                    //}
                    //else if (pay.PaymentMean.Name == "TT" || pay.PaymentMean.Name == "T/T" ||
                    //         pay.PaymentMean.Name == "DP" || pay.PaymentMean.Name == "D/P")
                    //{
                    //    result = pay.FundFlows.Aggregate(result, (current, ff) => current + (ff.Amount ?? 0));
                    //}

                    if (pay.PaymentMean.IsForFundFlow)
                    {
                        result = pay.FundFlows.Aggregate(result, (current, ff) => current + (ff.Amount ?? 0));
                    }
                    else
                    {
                        result = pay.LetterOfCredits.Aggregate(result, (current, lc) => current + (lc.PresentAmount ?? 0));
                    }
                    pay.PaidAmount = result;
                    #endregion

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

                PaymentRequests =
                    PaymentRequests.OrderByDescending(o => o.ReceiveBusinessPartner.ShortName).ThenByDescending(
                        b => b.PayBusinessPartner.ShortName).ThenByDescending(c => c.RequestDate).ToList();
            }
        }

        public bool ValidateAmount(int id)
        {
            List<PaymentRequest> requestList = PaymentRequests.Where(c => c.Id == id).ToList();
            if(requestList != null && requestList.Count > 0)
            {
                PaymentRequest request = requestList[0];
                if (request.RequestAmount != request.PaidAmount)
                {
                    MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("申请金额和已付金额不相等确认标识为付款完成吗？", "系统提示", messButton);
                    if(dr == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public PaymentMean LoadPaymentMean()
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                var includes = new List<string> {"PaymentMean"};
                PaymentRequest pm = paymentrequestService.FetchById(PaymentRequestId, includes);
                if (pm.PaymentMean != null)
                {
                    return pm.PaymentMean;
                }
            }
            return null;
        }

        public void SelectPayment()
        {
            PVM = new FundFlowDetailVM((int)FundFlowType.Pay);
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                var includes = new List<string>
                                   {
                                       "Quota",
                                       "Currency",
                                       "PayBusinessPartner",
                                       "ReceiveBusinessPartner",
                                       "PaymentMean",
                                       "PaymentUsage",
                                       "User",
                                       "FundFlows"
                                   };
                const string str = "it.Id=@p1";
                var parameters = new List<object> {PaymentRequestId};

                PaymentRequest pm = paymentrequestService.Select(str, parameters, includes)[0];
                FilterDeleted(pm.FundFlows);
                if (pm.PaymentMean != null)
                {
                    _fwAmount = 0;
                    foreach (FundFlow fw in pm.FundFlows)
                    {
                        _fwAmount += fw.Amount == null ? 0 : Convert.ToDecimal(fw.Amount);
                    }
                    PVM.SelectedBPartnerId = pm.ReceiveBusinessPartner.Id;
                    PVM.BPartnerName = pm.ReceiveBusinessPartner.ShortName;
                    PVM.ICId = pm.PayBPId;
                    PVM.QuotaNo = pm.Quota == null ? "" : pm.Quota.QuotaNo;
                    PVM.SelectedQuotaId = pm.QuotaId;
                    PVM.SelectedPaymentCurrencyId = pm.CurrencyId;
                    PVM.SelectedBankAccountId = pm.PayBankAccountId;
                    PVM.Amount = pm.RequestAmount - _fwAmount;
                    PVM.PaymentRequestId = PaymentRequestId;
                    PVM.PaymentMeanId = pm.PaymentMeanId;
                    PVM.IsFundflowFinished = pm.Quota == null ? true : pm.Quota.IsPaymentRequestFinished ?? false;//点击付款把批次付款状态带过去
                    PVM.Description = pm.Comment;
                    using (
                        var financialaccountService =
                            SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
                    {
                        FinancialAccount fa =
                            financialaccountService.GetById(pm.PaymentUsage.FinancialAccountId == null
                                                                ? 0
                                                                : Convert.ToInt32(pm.PaymentUsage.FinancialAccountId));
                        if (fa != null)
                        {
                            PVM.FinancialAccountName = fa.Name; 
                            PVM.SelectedFinancialAccountId = pm.PaymentUsage.FinancialAccountId;
                        }
                    }

                    if (pm.Quota != null)
                    {
                        if (pm.Quota.QuotaNo != null || pm.Quota.QuotaNo != "")
                        {
                            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                            {
                                Currency cry = quotaService.GetSettlementCurrencyByQuotaId(pm.Quota.Id);
                                PVM.SettlementCurrencyName =
                                    cry.Name;
                                PVM.SettlementCurrencyId = cry.Id;
                            }

                            //using (
                            //    var currencyService =
                            //        SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                            //{
                            //    //TODO::价格币种修改

                            //    PVM.SettlementCurrencyName =
                            //        currencyService.GetById(pm.Quota.PricingCurrencyId ?? 0).Name;
                            //    PVM.SettlementCurrencyId = pm.Quota.PricingCurrencyId ?? 0;
                            //}
                        }
                    }

                    if (pm.CurrencyId != null && pm.CurrencyId > 0 && pm.PayBankAccountId == null)
                    {
                        using (var bankAccountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
                        {
                            List<BankAccount> accounts = bankAccountService.GetBankAccountsByCurrencyIdAndCustomerId(pm.CurrencyId.Value,pm.PayBPId,BankAccountType.Asset);
                            if(accounts.Count > 0)
                            {
                                List<BankAccount> accountList = accounts.Where(c => c.IsDefault != null && c.IsDefault.Value).ToList();
                                if(accountList.Count > 0)
                                {
                                    BankAccount defaultAccount = accountList[0];
                                    PVM.SelectedBankAccountId = defaultAccount.Id;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void SelectLC()
        {
            LCVM = new IssueLCDetailVM();
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                var includes = new List<string>
                                   {
                                       "Quota",
                                       "Currency",
                                       "PayBusinessPartner",
                                       "ReceiveBusinessPartner",
                                       "PaymentMean",
                                       "PaymentUsage",
                                       "User",
                                       "PayBankAccount",
                                       "ReceiveBankAccount",
                                       "LetterOfCredits"
                                   };
                PaymentRequest pm = paymentrequestService.FetchById(PaymentRequestId, includes);
                FilterDeleted(pm.LetterOfCredits);
                if (pm.PaymentMean != null)
                {
                    _lcAmount = 0;
                    foreach (LetterOfCredit lc in pm.LetterOfCredits)
                    {
                        _lcAmount += lc.PresentAmount == null ? 0 : Convert.ToDecimal(lc.PresentAmount);
                    }

                    LCVM.BeneficiaryId = pm.ReceiveBusinessPartner.Id;
                    LCVM.BeneficiaryName = pm.ReceiveBusinessPartner.ShortName;
                    LCVM.ApplicantId = pm.PayBPId;
                    LCVM.QuotaNo = pm.Quota == null ? "" : pm.Quota.QuotaNo;
                    LCVM.SelectedQuotaId = pm.QuotaId;
                    LCVM.CurrencyId = Convert.ToInt32(pm.CurrencyId);
                    if(pm.ReceiveBankAccount !=null)
                        LCVM.AdvisingBankId = pm.ReceiveBankAccount.BankId;
                    LCVM.IssueBankId = pm.PayBankAccount != null ? (int?)pm.PayBankAccount.BankId : null;
                    LCVM.PresentAmount = pm.RequestAmount - _lcAmount;
                    LCVM.PaymentRequestId = PaymentRequestId;
                    LCVM.IsLCFinished = pm.Quota == null ? true : pm.Quota.IsPaymentRequestFinished.Value;//点击付款把批次付款状态带过去
                }
            }
        }

        protected override void Update()
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                PaymentRequest paymentRequest = paymentrequestService.GetById(PaymentRequestId);
                if (paymentRequest != null)
                {
                    paymentRequest.IsPaid = true;
                    paymentrequestService.UpdatePaymentRequestIsPaid(paymentRequest, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResPayment.PaymentRequestNotFound);
                }
            }
        }

        public override bool Validate()
        {
            return true;
        }

        #endregion
    }
}