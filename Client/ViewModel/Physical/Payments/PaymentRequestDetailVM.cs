using System;
using System.Collections.Generic;
using System.Linq;
using Client.BankAccountServiceReference;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CurrencyServiceReference;
using Client.DeliveryServiceReference;
using Client.FundFlowServiceReference;
using Client.LetterOfCreditServiceReference;
using Client.PaymentMeanServiceReference;
using Client.PaymentRequestServiceReference;
using Client.PaymentUsageServiceReference;
using Client.View.Physical.Payments;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;


namespace Client.ViewModel.Physical.Payments
{
    public class PaymentRequestDetailVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _businesspartner;
        private string _comment;
        private int _currencyId;
        private List<Currency> _currencys;
        private List<Delivery> _deldeliverys;
        private Delivery _delivery;
        private int? _deliveryId;
        private int _deliverylineCount;
        private int _deliverylineFrom;
        private int _deliverylineTo;
        private List<Delivery> _deliverys;
        private int? _oldpaymentMeanId;
        private int? _oldpaymentUsageId;
        private decimal _paidAmount;
        private int? _payBPId;
        private int? _payBankAccountId;
        private List<BankAccount> _paybankaccounts;
        private int? _paymentMeanId;
        private int? _paymentUsageId;
        private List<PaymentMean> _paymentmeans;
        private List<PaymentUsage> _paymentusages;
        private int? _prapproveStatus;
        private int? _quotaId;
        private string _quotaNo;
        private int? _receiveBPId;
        private int? _receiveBankAccountId;
        private List<BankAccount> _receivebankaccounts;
        private decimal? _requestAmount;
        private DateTime? _requestDate;
        private string _shortName;
        private int? _tradeTypeId;
        private List<int> _idList;
        private bool _isPaymentRequestFinished = true;
        private List<Bank> _IBanks;
        private int? _SelectedBankValue;
        private int? _invoiceId;
        private string _invoiceNo;
        #endregion

        #region Property
        public int? SelectedBankValue
        {
            get { return _SelectedBankValue; }
            set
            {
                if (_SelectedBankValue != value)
                {
                    _SelectedBankValue = value;
                    Notify("SelectedBankValue");
                }
            }
        }

        public List<Bank> IBanks
        {
            get { return _IBanks; }
            set
            {
                _IBanks = value;
                Notify("IBanks");
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

        public int DeliveryLineCount
        {
            get { return _deliverylineCount; }
            set
            {
                if (_deliverylineCount != value)
                {
                    _deliverylineCount = value;
                    Notify("DeliveryLineCount");
                }
            }
        }

        public int DeliveryLineTo
        {
            get { return _deliverylineTo; }
            set
            {
                if (_deliverylineTo != value)
                {
                    _deliverylineTo = value;
                    Notify("DeliveryLineTo");
                }
            }
        }

        public int DeliveryLineFrom
        {
            get { return _deliverylineFrom; }
            set
            {
                if (_deliverylineFrom != value)
                {
                    _deliverylineFrom = value;
                    Notify("DeliveryLineFrom");
                }
            }
        }

        public int? QuotaId
        {
            get { return _quotaId; }
            set
            {
                if (_quotaId != value)
                {
                    _quotaId = value;
                    Notify("QuotaId");
                }
            }
        }

        public DateTime? RequestDate
        {
            get { return _requestDate; }
            set
            {
                if (_requestDate != value)
                {
                    _requestDate = value;
                    Notify("RequestDate");
                }
            }
        }

        public decimal? RequestAmount
        {
            get { return _requestAmount; }
            set
            {
                if (_requestAmount != value)
                {
                    _requestAmount = value;
                    Notify("RequestAmount");
                }
            }
        }

        public decimal PaidAmount
        {
            get { return _paidAmount; }
            set
            {
                if (_paidAmount != value)
                {
                    _paidAmount = value;
                    Notify("PaidAmount");
                }
            }
        }

        public int CurrencyId
        {
            get { return _currencyId; }
            set
            {
                if (_currencyId != value)
                {
                    _currencyId = value;
                    Notify("CurrencyId");
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

        public int? PayBankAccountId
        {
            get { return _payBankAccountId; }
            set
            {
                if (_payBankAccountId != value)
                {
                    _payBankAccountId = value;
                    Notify("PayBankAccountId");
                }
            }
        }

        public int? ReceiveBankAccountId
        {
            get { return _receiveBankAccountId; }
            set
            {
                if (_receiveBankAccountId != value)
                {
                    _receiveBankAccountId = value;
                    Notify("ReceiveBankAccountId");
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

        public int? OldPaymentMeanId
        {
            get { return _oldpaymentMeanId; }
            set
            {
                if (_oldpaymentMeanId != value)
                {
                    _oldpaymentMeanId = value;
                    Notify("OldPaymentMeanId");
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

        public int? OldPaymentUsageId
        {
            get { return _oldpaymentUsageId; }
            set
            {
                if (_oldpaymentUsageId != value)
                {
                    _oldpaymentUsageId = value;
                    Notify("OldPaymentUsageId");
                }
            }
        }

        public int? PRApproveStatus
        {
            get { return _prapproveStatus; }
            set
            {
                if (_prapproveStatus != value)
                {
                    _prapproveStatus = value;
                    Notify("PRApproveStatus");
                }
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
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
            get
            {
                return _paybankaccounts;
            }
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

        public List<Delivery> Deliverys
        {
            get { return _deliverys; }
            set
            {
                _deliverys = value;
                Notify("Deliverys");
            }
        }

        public Delivery Delivery
        {
            get { return _delivery; }
            set
            {
                _delivery = value;
                Notify("Delivery");
            }
        }

        public List<Delivery> DelDeliverys
        {
            get { return _deldeliverys; }
            set
            {
                _deldeliverys = value;
                Notify("DelDeliverys");
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

        public int? DeliveryId
        {
            get { return _deliveryId; }
            set
            {
                if (_deliveryId != value)
                {
                    _deliveryId = value;
                    Notify("DeliveryId");
                }
            }
        }

        public int? TradeTypeId
        {
            get { return _tradeTypeId; }
            set
            {
                if (_tradeTypeId != value)
                {
                    _tradeTypeId = value;
                    Notify("TradeTypeId");
                }
            }
        }

        public bool IsPaymentRequestFinished
        {
            get { return _isPaymentRequestFinished; }
            set
            {
                if (_isPaymentRequestFinished != value)
                {
                    _isPaymentRequestFinished = value;
                    Notify("IsPaymentRequestFinished");
                }
            }
        }

        public int? InvoiceId
        {
            get { return _invoiceId; }
            set
            {
                if (_invoiceId != value)
                {
                    _invoiceId = value;
                    Notify("InvoiceId");
                }
            }
        }

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                if (_invoiceNo != value)
                {
                    _invoiceNo = value;
                    Notify("InvoiceNo");
                }
            }
        }
        #endregion

        #region Constructor

        public PaymentRequestDetailVM()
        {
            ObjectId = 0;
            Initialize();
            LoadDocumentEnableProperty(ObjectId);
        }

        public PaymentRequestDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
            LoadDocumentEnableProperty(ObjectId);
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
            //币种类型
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currencys = currencyService.GetAll();
                Currencys.Insert(0, new Currency { Id = 0, Name = string.Empty });
            }
            //付款方
            using (
                var paybusinesspartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                BusinessPartners = paybusinesspartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                BusinessPartners.Insert(0, new BusinessPartner { Id = 0, ShortName = string.Empty });
            }

            //付款方式
            using (
                var receivepaymentmeanService =
                    SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc))
            {
                PaymentMeans = receivepaymentmeanService.GetAll();
                PaymentMeans.Insert(0, new PaymentMean { Id = 0, Name = string.Empty });
            }

            //付款用途
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                PaymentUsages = paymentusageService.GetAll();
                List<PaymentUsage> defaultUsageList = PaymentUsages.Where(c => c.IsDefault && !c.IsDeleted).ToList();
                if(defaultUsageList != null && defaultUsageList.Count > 0)
                {
                    PaymentUsage defaultUsage = defaultUsageList.FirstOrDefault();
                    PaymentUsageId = defaultUsage.Id;
                    PaymentMeanId = defaultUsage.DefaultPaymentMeanId;
                }
                PaymentUsages.Insert(0, new PaymentUsage { Id = 0, Name = string.Empty });
            }
            RequestDate = DateTime.Today;
            if (ObjectId > 0)
            {
                using (
                    var paymentrequestService =
                        SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
                {
                    PaymentRequest paymentRequest = paymentrequestService.SelectById(new List<string>
                                                                                     {
                                                                                         "PaymentMean",
                                                                                         "Currency",
                                                                                         "PaymentUsage",
                                                                                         "PayBusinessPartner",
                                                                                         "ReceiveBusinessPartner",
                                                                                         "PayBankAccount",
                                                                                         "ReceiveBankAccount",
                                                                                         "Quota",
                                                                                         "Quota.Contract",
                                                                                         "FundFlows",
                                                                                         "LetterOfCredits",
                                                                                         "CommercialInvoice"
                                                                                     }, ObjectId);
                    if (paymentRequest != null)
                    {
                        QuotaId = paymentRequest.Quota == null ? 0 : Convert.ToInt32(paymentRequest.Quota.Id);
                        QuotaNo = paymentRequest.Quota == null ? "" : paymentRequest.Quota.QuotaNo;
                        TradeTypeId = paymentRequest.Quota == null
                                          ? 0
                                          : Convert.ToInt32(paymentRequest.Quota.Contract.TradeType);
                        RequestDate = paymentRequest.RequestDate;
                        RequestAmount = Convert.ToDecimal(paymentRequest.RequestAmount);
                        CurrencyId = paymentRequest.Currency == null ? 0 : paymentRequest.Currency.Id;
                        PayBPId = paymentRequest.PayBPId;
                        ShortName = paymentRequest.ReceiveBusinessPartner.ShortName;
                        ReceiveBPId = paymentRequest.ReceiveBPId;
                        PayBankAccountId = paymentRequest.PayBankAccountId;
                        ReceiveBankAccountId = paymentRequest.ReceiveBankAccountId;
                        PaymentMeanId = paymentRequest.PaymentMeanId;
                        OldPaymentMeanId = paymentRequest.PaymentMeanId;
                        PaymentUsageId = paymentRequest.PaymentUsageId;
                        OldPaymentUsageId = paymentRequest.PaymentUsageId;
                        PRApproveStatus = paymentRequest.ApproveStatus;
                        Comment = paymentRequest.Comment;
                        SelectedBankValue = paymentRequest.IntermediaryBankId;
                        IsPaymentRequestFinished = paymentRequest.Quota == null ? false : (paymentRequest.Quota.IsPaymentRequestFinished ?? false);

                        if (paymentRequest.CommercialInvoice != null)
                        {
                            InvoiceId = paymentRequest.CommercialInvoice.Id;
                            InvoiceNo = paymentRequest.CommercialInvoice.InvoiceNo;
                        }
                        FilterDeleted(paymentRequest.FundFlows);
                        FilterDeleted(paymentRequest.LetterOfCredits);
                        if (paymentRequest.PaymentMean.IsForFundFlow)
                        {
                            PaidAmount += (decimal)paymentRequest.FundFlows.Sum(o => o.Amount);
                        }
                        else
                        {
                            PaidAmount += (decimal)paymentRequest.LetterOfCredits.Sum(o => o.PresentAmount);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择付款用途得付款方式
        /// </summary>
        public void LoadPaymentMeans()
        {
            //付款方式
            PaymentUsage paymentusage;
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                paymentusage = paymentusageService.GetById(PaymentUsageId == null ? 0 : Convert.ToInt32(PaymentUsageId));
            }
            if (OldPaymentUsageId != PaymentUsageId)
            {
                if (paymentusage != null)
                {
                    using (
                        var paymentmeanService =
                            SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc))
                    {
                        int pmid = paymentusage.DefaultPaymentMeanId == null
                                       ? 0
                                       : Convert.ToInt32(paymentusage.DefaultPaymentMeanId);
                        PaymentMean paymentmean = paymentmeanService.GetById(pmid);
                        PaymentMeanId = paymentmean == null ? 0 : paymentmean.Id;
                    }
                }
            }
            else
            {
                PaymentMeanId = OldPaymentMeanId;
            }
        }

        /// <summary>
        /// 选择币种获得付款账号
        /// </summary>
        public void LoadPayBankAccounts()
        {
            if (PayBPId != null && PayBPId != 0)
            {
                using (
                    var bankaccountTypeService =
                        SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
                {
                    BankAccount defaultBankAccount = bankaccountTypeService.GetDefaultBankAccountByBusinessPartnerId(CurrentUser.Id, PayBPId.Value, CurrencyId);

                    PayBankAccounts = bankaccountTypeService.GetBankAccountsByPaymentMean(CurrencyId,
                                                                                          Convert.ToInt32(PayBPId));
                    PayBankAccounts.Insert(0, new BankAccount { Id = 0, Description = "" });

                    if (defaultBankAccount != null)
                    {
                        bool flag = false;
                        foreach (var payBankAccount in PayBankAccounts)
                        {
                            if (payBankAccount.Id == defaultBankAccount.Id)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            PayBankAccounts.Insert(1, defaultBankAccount);
                        }
                        if (ObjectId <= 0)
                        {
                            PayBankAccountId = defaultBankAccount.Id;
                        }

                    }
                }
            }
            else
            {
                PayBankAccounts = new List<BankAccount>();
            }
        }

        /// <summary>
        /// 选择币种获得收款账号
        /// </summary>
        public void LoadReceiveBankAccounts()
        {
            if (ReceiveBPId != null && ReceiveBPId != 0)
            {
                using (
                    var bankaccountTypeService =
                        SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
                {
                    BankAccount defaultBankAccount = bankaccountTypeService.GetDefaultBankAccountByBusinessPartnerId(CurrentUser.Id, ReceiveBPId.Value, CurrencyId);
                    ReceiveBankAccounts = bankaccountTypeService.GetBankAccountsByPaymentMean(CurrencyId,
                                                                                              Convert.ToInt32(
                                                                                                  ReceiveBPId));
                    ReceiveBankAccounts.Insert(0, new BankAccount { Id = 0, Description = "" });

                    if (defaultBankAccount != null)
                    {
                        bool flag = false;
                        foreach (var receiveBankAccount in ReceiveBankAccounts)
                        {
                            if (receiveBankAccount.Id == defaultBankAccount.Id)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            ReceiveBankAccounts.Insert(1, defaultBankAccount);
                        }
                        if (ObjectId <= 0)
                        {
                            ReceiveBankAccountId = defaultBankAccount.Id;
                        }

                    }
                }
                LoadIntermediaryBank();
            }
            else
            {
                ReceiveBankAccounts = new List<BankAccount>();
            }
        }

        public void LoadIntermediaryBank()
        {
            if (ReceiveBPId != null && ReceiveBPId != 0)
            {
                List<Bank> banks = new List<Bank>();
                if (ReceiveBankAccounts != null && ReceiveBankAccounts.Count > 0)
                {
                    foreach (BankAccount account in ReceiveBankAccounts)
                    {
                        if (account.Bank != null)
                        {
                            banks.Add(account.Bank);
                        }
                    }
                }
                IBanks = banks.Distinct().ToList();
                IBanks.Insert(0, new Bank { Id = 0, Name = "" });
            }
            else
            {
                IBanks = new List<Bank>();
            }
        }
        /// <summary>
        /// 提单行列表
        /// </summary>
        public void LoadDeliveryLines()
        {
            Deliverys = new List<Delivery>();
        }

        /// <summary>
        /// 提单行列表
        /// </summary>
        public void LoadDelDeliveryLines()
        {
            DelDeliverys = new List<Delivery>();
        }

        /// <summary>
        /// 提单行列表
        /// </summary>
        public void LoadDeliveryLinesEdit()
        {
            if (ObjectId != 0)
            {
                using (
                    var deliveryService =
                        SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
                {
                    const string queryStr = "it.PaymentRequestId=@p1";
                    var parameters = new List<object> { ObjectId };

                    var includes = new List<string> { "DeliveryLines", "Quota.CommodityType", "DeliveryLines.Brand" };
                    Deliverys = deliveryService.SelectByRangeWithOrder(queryStr, parameters,
                                                                               new SortCol { ByDescending = true, ColName = "Id" },
                                                                               DeliveryLineFrom, DeliveryLineTo,
                                                                               includes);
                    foreach (var d in Deliverys)
                    {
                        FilterDeleted(d.DeliveryLines);
                    }
                }
            }
            else
            {
                Deliverys = new List<Delivery>();
            }
        }

        public void LoadDeliveryLineCount()
        {
            if (ObjectId != 0)
            {
                using (
                    var deliveryService =
                        SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
                {
                    const string queryStr = "it.PaymentRequestId=@p1";
                    var parameters = new List<object> { ObjectId };

                    var includes = new List<string> { "DeliveryLines", "Quota.CommodityType", "DeliveryLines.Brand" };
                    Deliverys = deliveryService.Select(queryStr, parameters, includes);
                    foreach (var d in Deliverys)
                    {
                        FilterDeleted(d.DeliveryLines);
                    }
                }
            }
            _deliverylineCount = Deliverys.Count();
        }

        /// <summary>
        /// 删除列提单表
        /// </summary>
        public void RemoveDeliverys(int deliveryId)
        {
            if (QuotaId != null && QuotaId != 0)
            {
                Delivery = Deliverys.SingleOrDefault(o => o.Id == deliveryId);
            }
            else
            {
                Delivery = new Delivery();
            }
        }

        /// <summary>
        /// 删除列提单表
        /// </summary>
        public int? SelectDeliveryLine()
        {
            int? id = 0;
            if (QuotaId != null && QuotaId != 0)
            {
                using (
                    var paymentrequestService =
                        SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
                {
                    PaymentRequest pr = paymentrequestService.GetById(ObjectId);
                    id = pr == null ? 0 : pr.QuotaId ?? 0;
                }
            }
            return id;
        }

        /// <summary>
        /// 已付金额
        /// </summary>
        /// <returns></returns>
        //public decimal GetPaidAmount()
        //{
        //    decimal result = 0;
        //    if (ObjectId > 0)
        //    {
        //        const string condition = "it.PaymentRequestId = @p1";
        //        var parameters = new List<object> { ObjectId };
        //        using (var ffService = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc))
        //        {
        //            result += ffService.SelectSum(condition, parameters, null, "it.Amount");
        //        }

        //        using (var lcService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
        //        {
        //            result += lcService.SelectSum(condition, parameters, null, "it.PresentAmount");
        //        }
        //    }
        //    return result;
        //}

        public void GetQuotaDetail(Quota quota)
        { 
            if(quota != null)
            {
                decimal? requestedAmount = 0;
                using ( var paymentrequestService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
                {
                    requestedAmount = paymentrequestService.GetPaymentRequestAmountSumByQuota(quota.Id, CurrentUser.Id);
                }
                if (quota.PricingType == (int)PricingType.Average)
                {
                    if (quota.PricingStatus == (int)PricingStatus.Complete)
                    {
                        RequestAmount = quota.Equality - requestedAmount;
                    }
                    else
                    {
                        RequestAmount = 0;
                    }
                }
                else
                {
                    RequestAmount = quota.Equality - requestedAmount;
                }
                //if (quota.PricingStatus == (int)PricingStatus.Complete)
                //{
                //    RequestAmount = quota.Equality - requestedAmount;
                //}
                //else
                //{
                //    RequestAmount = 0;
                //}

                if (quota.PricingCurrencyId.HasValue)
                {
                    CurrencyId = quota.PricingCurrencyId.Value;
                }
            }
        }

        public void GetInvoiceDetail(CommercialInvoice invoice)
        {
            if (invoice != null)
            {
                using (var paymentrequestService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
                {

                    RequestAmount = paymentrequestService.GetPaymentRequestAmountSumByInvoice(invoice.Id, CurrentUser.Id);
                }

                if (invoice.CurrencyId.HasValue)
                {
                    CurrencyId = invoice.CurrencyId.Value;
                }
                InvoiceId = invoice.Id;
                InvoiceNo = invoice.InvoiceNo;
                decimal paidAmount = 0M;
                //PaidAmount = invoice.PaymentRequestAmount;
                FilterDeleted(invoice.PaymentRequests);
                foreach (var paymentRequest in invoice.PaymentRequests)
                {
                    FilterDeleted(paymentRequest.FundFlows);
                    FilterDeleted(paymentRequest.LetterOfCredits);
                    if (paymentRequest.PaymentMean.IsForFundFlow)
                    {
                        paidAmount += (decimal)paymentRequest.FundFlows.Sum(o => o.Amount);
                    }
                    else
                    {
                        paidAmount += (decimal)paymentRequest.LetterOfCredits.Sum(o => o.PresentAmount);
                    }
                }
                PaidAmount = paidAmount;
            }
        }

        protected override void Create()
        {
            if (ReceiveBankAccountId.HasValue && ReceiveBankAccountId.Value == 0)
            {
                ReceiveBankAccountId = null;
            }
            if (SelectedBankValue.HasValue && SelectedBankValue.Value == 0)
            {
                SelectedBankValue = null;
            }
            var paymentRequest = new PaymentRequest
                                     {
                                         QuotaId = QuotaId,
                                         RequestDate = RequestDate,
                                         RequestAmount = RequestAmount,
                                         CurrencyId = CurrencyId,
                                         PayBPId = PayBPId == null ? 0 : Convert.ToInt32(PayBPId),
                                         ReceiveBPId = ReceiveBPId == null ? 0 : Convert.ToInt32(ReceiveBPId),
                                         PayBankAccountId = PayBankAccountId == 0 ? null : PayBankAccountId,
                                         ReceiveBankAccountId = ReceiveBankAccountId,
                                         PaymentMeanId = PaymentMeanId,
                                         PaymentUsageId = PaymentUsageId,
                                         IntermediaryBankId = SelectedBankValue,
                                         InvoiceId = InvoiceId,
                                         Comment = Comment,
                                     };

            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                paymentrequestService.CreatePaymentRequestDeliveryLine(paymentRequest, CurrentUser.Id, Deliverys, IsPaymentRequestFinished);
            }
        }

        protected override void Update()
        {
            if (ReceiveBankAccountId.HasValue && ReceiveBankAccountId.Value == 0)
            {
                ReceiveBankAccountId = null;
            }
            if (SelectedBankValue.HasValue && SelectedBankValue.Value == 0)
            {
                SelectedBankValue = null;
            }
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                PaymentRequest paymentRequest = paymentrequestService.GetById(ObjectId);
                if (paymentRequest != null)
                {
                    paymentRequest.QuotaId = QuotaId == 0 ? null : QuotaId;
                    paymentRequest.RequestDate = RequestDate;
                    paymentRequest.RequestAmount = RequestAmount;
                    paymentRequest.CurrencyId = CurrencyId;
                    paymentRequest.PayBPId = PayBPId == null ? 0 : Convert.ToInt32(PayBPId);
                    paymentRequest.ReceiveBPId = ReceiveBPId == null ? 0 : Convert.ToInt32(ReceiveBPId);
                    paymentRequest.PayBankAccountId = PayBankAccountId == 0 ? null : PayBankAccountId;
                    paymentRequest.ReceiveBankAccountId = ReceiveBankAccountId;
                    paymentRequest.PaymentMeanId = PaymentMeanId;
                    paymentRequest.PaymentUsageId = PaymentUsageId;
                    paymentRequest.Comment = Comment;
                    paymentRequest.IntermediaryBankId = SelectedBankValue;
                    paymentRequest.InvoiceId = InvoiceId;
                    paymentrequestService.UpdatePaymentRequestDeliveryLine(paymentRequest, CurrentUser.Id, Deliverys,
                                                                           DelDeliverys, IsPaymentRequestFinished);
                }
                else
                {
                    throw new Exception(ResPayment.PaymentRequestNotFound);
                }
            }
        }

        public bool IsExisted()
        {
            return false;
        }


        public override bool Validate()
        {
            if (!RequestDate.HasValue)
            {
                throw new Exception(ResPayment.ApplyDateRequired);
            }
            if (RequestAmount == null)
            {
                throw new Exception(ResPayment.AppliedAmountRequired);
            }

            if (Equals(CurrencyId, 0))
            {
                throw new Exception(ResPayment.PaymentCurrencyRequired);
            }

            if (!PayBPId.HasValue || Equals(PayBPId, 0))
            {
                throw new Exception(Properties.Resources.PaymentBPNotNull);
            }

            if (string.IsNullOrWhiteSpace(ShortName))
            {
                throw new Exception(ResPayment.ReceiptBPRequired);
            }

            //if (!ReceiveBankAccountId.HasValue || Equals(ReceiveBankAccountId, 0))
            //{
            //    throw new Exception(ResPayment.ReceiptAccountRequired);
            //}

            if (!PaymentMeanId.HasValue || Equals(PaymentMeanId, 0))
            {
                throw new Exception(Properties.Resources.PaymentMeanRequired);
            }

            if (!PaymentUsageId.HasValue || Equals(PaymentUsageId, 0))
            {
                throw new Exception(ResPayment.PaymentUsageRequired);
            }

            using (
                var paymentmeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMean paymentmean =
                    paymentmeanService.GetById(PaymentMeanId == null ? 0 : Convert.ToInt32(PaymentMeanId));
                BankAccount payBankAccount;
                BankAccount receiveBankAccount = null;

                using (
                    var bankaccountService =
                        SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc))
                {
                    payBankAccount =bankaccountService.GetById(PayBankAccountId == null ? 0 : Convert.ToInt32(PayBankAccountId));
                    if (ReceiveBankAccountId.HasValue && ReceiveBankAccountId.Value != 0)
                    {
                        receiveBankAccount = bankaccountService.GetById(ReceiveBankAccountId == null
                                                           ? 0
                                                           : Convert.ToInt32(ReceiveBankAccountId));
                    }
                }

                if (paymentmean.Name == "LC" || paymentmean.Name == "L/C")
                {
                    if (TradeTypeId == (int) TradeType.LongDomesticTrade ||
                        TradeTypeId == (int) TradeType.ShortDomesticTrade)
                    {
                        throw new Exception(ResPayment.NotForDomesticQuota);
                    }

                    if (PayBankAccountId != null && PayBankAccountId != 0)
                    {
                        if (payBankAccount.Usage != (int)BankAccountType.LCBalance)
                        {
                            throw new Exception(ResPayment.PaymentAccountError);
                        }
                    }

                    if (receiveBankAccount != null)
                    {
                        if (receiveBankAccount.Usage != (int)BankAccountType.LCBalance)
                        {
                            throw new Exception(ResPayment.ReceiptAccountError);
                        }
                    }
                }
                else if (paymentmean.Name == "DP" || paymentmean.Name == "TT" || paymentmean.Name == "D/P" ||
                         paymentmean.Name == "T/T")
                {
                    if (PayBankAccountId != null && PayBankAccountId!=0)
                    {
                        if (payBankAccount.Usage != (int)BankAccountType.Asset)
                        {
                            throw new Exception(ResPayment.PaymentAccountError2);
                        }
                    }

                    if (receiveBankAccount != null)
                    {
                        if (receiveBankAccount.Usage != (int)BankAccountType.Asset)
                        {
                            throw new Exception(ResPayment.ReceiptAccountError2);
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region 编辑属性

        private bool _isQuotaBtnEnable;
        private bool _isCIBtnEnable;
        private bool _isRequestAmountEnable;
        private bool _isCurrencyEnable;
        private bool _isBPPayEnable;
        private bool _isAccountPayEnable;
        private bool _isBPReceiveEnable;
        private bool _isAccountReceiveEnable;
        private bool _isPaymentUsageEnable;
        private bool _isPaymentMeanEnable;
        private bool _isTransferBankEnable;

        public bool IsQuotaBtnEnable
        {
            get { return _isQuotaBtnEnable; }
            set
            {
                if (_isQuotaBtnEnable != value)
                {
                    _isQuotaBtnEnable = value;
                    Notify("IsQuotaBtnEnable");
                }
            }
        }

        public bool IsCIBtnEnable
        {
            get { return _isCIBtnEnable; }
            set
            {
                if (_isCIBtnEnable != value)
                {
                    _isCIBtnEnable = value;
                    Notify("IsCIBtnEnable");
                }
            }
        }

        public bool IsRequestAmountEnable
        {
            get { return _isRequestAmountEnable; }
            set
            {
                if (_isRequestAmountEnable != value)
                {
                    _isRequestAmountEnable = value;
                    Notify("IsRequestAmountEnable");
                }
            }
        }

        public bool IsCurrencyEnable
        {
            get { return _isCurrencyEnable; }
            set
            {
                if (_isCurrencyEnable != value)
                {
                    _isCurrencyEnable = value;
                    Notify("IsCurrencyEnable");
                }
            }
        }

        public bool IsBPPayEnable
        {
            get { return _isBPPayEnable; }
            set
            {
                if (_isBPPayEnable != value)
                {
                    _isBPPayEnable = value;
                    Notify("IsBPPayEnable");
                }
            }
        }

        public bool IsAccountPayEnable
        {
            get { return _isAccountPayEnable; }
            set
            {
                if (_isAccountPayEnable != value)
                {
                    _isAccountPayEnable = value;
                    Notify("IsAccountPayEnable");
                }
            }
        }

        public bool IsBPReceiveEnable
        {
            get { return _isBPReceiveEnable; }
            set
            {
                if (_isBPReceiveEnable != value)
                {
                    _isBPReceiveEnable = value;
                    Notify("IsBPReceiveEnable");
                }
            }
        }

        public bool IsAccountReceiveEnable
        {
            get { return _isAccountReceiveEnable; }
            set
            {
                if (_isAccountReceiveEnable != value)
                {
                    _isAccountReceiveEnable = value;
                    Notify("IsAccountReceiveEnable");
                }
            }
        }

        public bool IsPaymentUsageEnable
        {
            get { return _isPaymentUsageEnable; }
            set
            {
                if (_isPaymentUsageEnable != value)
                {
                    _isPaymentUsageEnable = value;
                    Notify("IsPaymentUsageEnable");
                }
            }
        }

        public bool IsPaymentMeanEnable
        {
            get { return _isPaymentMeanEnable; }
            set
            {
                if (_isPaymentMeanEnable != value)
                {
                    _isPaymentMeanEnable = value;
                    Notify("IsPaymentMeanEnable");
                }
            }
        }

        public bool IsTransferBankEnable
        {
            get { return _isTransferBankEnable; }
            set
            {
                if (_isTransferBankEnable != value)
                {
                    _isTransferBankEnable = value;
                    Notify("IsTransferBankEnable");
                }
            }
        }

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsQuotaBtnEnable = true;
                IsCIBtnEnable = true;
                IsRequestAmountEnable = true;
                IsCurrencyEnable = true;
                IsBPPayEnable = true;
                IsAccountPayEnable = true;
                IsBPReceiveEnable = true;
                IsAccountReceiveEnable = true;
                IsPaymentUsageEnable = true;
                IsPaymentMeanEnable = true;
                IsTransferBankEnable = true;
            }
            else
            {
                using (var pyService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
                {
                    DBEntity.EnableProperty.PaymentRequestEnableProperty prep = pyService.SetElementsEnableProperty(id);
                    IsQuotaBtnEnable = prep.IsQuotaBtnEnable;
                    IsCIBtnEnable = prep.IsCIBtnEnable;
                    IsRequestAmountEnable = prep.IsRequestAmountEnable;
                    IsCurrencyEnable = prep.IsCurrencyEnable;
                    IsBPPayEnable = prep.IsBPPayEnable;
                    IsAccountPayEnable = prep.IsAccountPayEnable;
                    IsBPReceiveEnable = prep.IsBPReceiveEnable;
                    IsAccountReceiveEnable = prep.IsAccountReceiveEnable;
                    IsPaymentUsageEnable = prep.IsPaymentUsageEnable;
                    IsPaymentMeanEnable = prep.IsPaymentMeanEnable;
                    IsTransferBankEnable = prep.IsTransferBankEnable;
                }
            }
        }
        #endregion
    }
}