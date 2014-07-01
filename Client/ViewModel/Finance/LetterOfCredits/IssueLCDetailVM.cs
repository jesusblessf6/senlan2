using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.AttachmentServiceReference;
using Client.BankServiceReference;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CurrencyServiceReference;
using Client.LetterOfCreditServiceReference;
using Client.MarketPriceServiceReference;
using Client.View.Finance.LetterOfCredits;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.View.Physical.CommercialInvoices;
using DBEntity.EnableProperty;

namespace Client.ViewModel.Finance.LetterOfCredits
{
    public class IssueLCDetailVM : ObjectBaseVM
    {
        #region Member

        private DateTime? _acceptanceExpiryDate;
        private DateTime? _actualAcceptanceDate;
        private int? _advisingBankId;
        private decimal? _amount;
        private int _applicantId;
        private List<BusinessPartner> _applicants;
        private List<Bank> _banks;
        private int _beneficiaryId;
        private string _beneficiaryName;
        private string _comment;
        private int? _commercialInvoiceId;
        private string _commercialInvoiceName;
        private List<Currency> _currencies;
        private int _currencyId;
        private string _currencyName;
        private TrackableCollection<Delivery> _deliveries;
        private decimal? _float;
        private int? _iborType;
        private decimal? _iborValue;
        private decimal? _interest;

        private int? _issueBankId;
        private DateTime? _issueDate;
        private decimal? _issueQuantity;
        private int? _lcDays;
        private DateTime? _lcExpiryDate;
        private string _lcNo;
        private Dictionary<string, int> _lcStatus;
        private int _lcStatusId;
        private int _lcType;
        private Dictionary<string, int> _lcTypes;
        private DateTime? _latestShippmentDate;
        private int _porS;
        private decimal? _presentAmount;
        private DateTime? _presentDate;
        private Dictionary<string, int> _promptBasis;
        private int? _promptBasisId;
        private string _quotaNo;
        private TrackableCollection<CommercialInvoice> _showCommercialInvoiceLines;

        private List<Attachment> _addAttachments;
        private List<Attachment> _attachments;
        private List<Attachment> _deleteAttachments;

        private Dictionary<int, string> _lendingRates;
        private int? _paymentRequestId;
        private int? _selectedQuotaId;
        private List<int> _idList;

        private Dictionary<string, int> _statusTypes;
        private int _financeStatus;
        private bool _isPresentAmountCanEdit;
        private bool _IsLCFinished = false;
        #endregion

        #region Property
        public bool IsLCFinished
        {
            get { return _IsLCFinished; }
            set {
                if (_IsLCFinished != value)
                {
                    _IsLCFinished = value;
                    Notify("IsLCFinished");
                }
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

        public string LCNo
        {
            get { return _lcNo; }
            set
            {
                if (_lcNo != value)
                {
                    _lcNo = value;
                    Notify("LCNo");
                }
            }
        }

        public int LCType
        {
            get { return _lcType; }
            set
            {
                if (_lcType != value)
                {
                    _lcType = value;
                    Notify("LCType");
                }
            }
        }

        public int LCStatusId
        {
            get { return _lcStatusId; }
            set
            {
                if (_lcStatusId != value)
                {
                    _lcStatusId = value;
                    Notify("LCStatusId");
                }
            }
        }

        public int ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (_applicantId != value)
                {
                    _applicantId = value;
                    Notify("ApplicantId");
                }
            }
        }

        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                if (_beneficiaryId != value)
                {
                    _beneficiaryId = value;
                    Notify("BeneficiaryId");
                }
            }
        }

        public string BeneficiaryName
        {
            get { return _beneficiaryName; }
            set
            {
                if (_beneficiaryName != value)
                {
                    _beneficiaryName = value;
                    Notify("BeneficiaryName");
                }
            }
        }

        public int? LCDays
        {
            get { return _lcDays; }
            set
            {
                if (_lcDays != value)
                {
                    _lcDays = value;
                    Notify("LCDays");
                }
            }
        }

        public int? PromptBasisId
        {
            get { return _promptBasisId; }
            set
            {
                if (_promptBasisId != value)
                {
                    _promptBasisId = value;
                    Notify("PromptBasis");
                }
            }
        }

        public int? AdvisingBankId
        {
            get { return _advisingBankId; }
            set
            {
                if (_advisingBankId != value)
                {
                    _advisingBankId = value;
                    Notify("AdvisingBankId");
                }
            }
        }

        public int? IssueBankId
        {
            get { return _issueBankId; }
            set
            {
                if (_issueBankId != value)
                {
                    _issueBankId = value;
                    Notify("IssueBankId");
                }
            }
        }

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

        public decimal? IssueQuantity
        {
            get { return Math.Round(_issueQuantity == null ? 0 : (decimal)_issueQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                if (_issueQuantity != value)
                {
                    _issueQuantity = value;
                    Notify("IssueQuantity");
                }
            }
        }

        public DateTime? AcceptanceExpiryDate
        {
            get { return _acceptanceExpiryDate; }
            set
            {
                if (_acceptanceExpiryDate != value)
                {
                    _acceptanceExpiryDate = value;
                    Notify("AcceptanceExpiryDate");
                }
            }
        }

        public DateTime? LCExpiryDate
        {
            get { return _lcExpiryDate; }
            set
            {
                if (_lcExpiryDate != value)
                {
                    _lcExpiryDate = value;
                    Notify("LCExpiryDate");
                }
            }
        }

        public DateTime? LatestShippmentDate
        {
            get { return _latestShippmentDate; }
            set
            {
                if (_latestShippmentDate != value)
                {
                    _latestShippmentDate = value;
                    Notify("LatestShippmentDate");
                }
            }
        }

        public DateTime? ActualAcceptanceDate
        {
            get { return _actualAcceptanceDate; }
            set
            {
                if (_actualAcceptanceDate != value)
                {
                    _actualAcceptanceDate = value;
                    Notify("ActualAcceptanceDate");
                }
            }
        }

        public decimal? PresentAmount
        {
            get { return Math.Round(_presentAmount == null ? 0 : (decimal)_presentAmount, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                if (_presentAmount != value)
                {
                    _presentAmount = value;
                    Notify("PresentAmount");
                }
            }
        }

        public DateTime? PresentDate
        {
            get { return _presentDate; }
            set
            {
                if (_presentDate != value)
                {
                    _presentDate = value;
                    Notify("PresentDate");
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

        public int? IBORType
        {
            get { return _iborType; }
            set
            {
                if (_iborType != value)
                {
                    _iborType = value;
                    Notify("IBORType");
                }
            }
        }

        public string CommercialInvoiceName
        {
            get { return _commercialInvoiceName; }
            set
            {
                if (_commercialInvoiceName != value)
                {
                    _commercialInvoiceName = value;
                    Notify("CommercialInvoiceName");
                }
            }
        }

        public int? CommercialInvoiceId
        {
            get { return _commercialInvoiceId; }
            set
            {
                if (_commercialInvoiceId != value)
                {
                    _commercialInvoiceId = value;
                    Notify("CommercialInvoiceId");
                }
            }
        }

        public decimal? IBORValue
        {
            get { return Math.Round(_iborValue == null ? 0 : (decimal)_iborValue, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero); }
            set
            {
                if (_iborValue != value)
                {
                    _iborValue = value;
                    Notify("IBORValue");
                }
            }
        }

        public decimal? Float
        {
            get { return Math.Round(_float == null ? 0 : (decimal)_float, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero); }
            set
            {
                if (_float != value)
                {
                    _float = value;
                    Notify("Float");
                }
            }
        }

        public decimal? Interest
        {
            get { return Math.Round(_interest == null ? 0 : (decimal)_interest, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                if (_interest != value)
                {
                    _interest = value;
                    Notify("Interest");
                }
            }
        }

        public int PorS
        {
            get { return _porS; }
            set
            {
                if (_porS != value)
                {
                    _porS = value;
                    Notify("PorS");
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

        public int? SelectedQuotaId
        {
            get { return _selectedQuotaId; }
            set
            {
                if (_selectedQuotaId != value)
                {
                    _selectedQuotaId = value;
                    Notify("SelectedQuotaId");
                }
            }
        }

        public decimal? Amount
        {
            get { return Math.Round(_amount == null ? 0 : (decimal)_amount, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    Notify("Amount");
                }
            }
        }

        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                if (_currencies != value)
                {
                    _currencies = value;
                    Notify("Currencies");
                }
            }
        }

        public string CurrencyName
        {
            get { return _currencyName; }
            set
            {
                if (_currencyName != value)
                {
                    _currencyName = value;
                    Notify("CurrencyName");
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

        public List<BusinessPartner> Applicants
        {
            get { return _applicants; }
            set
            {
                if (_applicants != value)
                {
                    _applicants = value;
                    Notify("Applicants");
                }
            }
        }

        public Dictionary<string, int> LCStatus
        {
            get { return _lcStatus; }
            set
            {
                if (_lcStatus != value)
                {
                    _lcStatus = value;
                    Notify("LCStatus");
                }
            }
        }

        public Dictionary<string, int> PromptBasis
        {
            get { return _promptBasis; }
            set
            {
                if (_promptBasis != value)
                {
                    _promptBasis = value;
                    Notify("PromptBasis");
                }
            }
        }

        public Dictionary<string, int> LCTypes
        {
            get { return _lcTypes; }
            set
            {
                if (_lcTypes != value)
                {
                    _lcTypes = value;
                    Notify("LCTypes");
                }
            }
        }

        public List<Bank> Banks
        {
            get { return _banks; }
            set
            {
                if (_banks != value)
                {
                    _banks = value;
                    Notify("Banks");
                }
            }
        }

        public TrackableCollection<Delivery> Deliveries
        {
            get { return _deliveries; }
            set
            {
                if (_deliveries != value)
                {
                    _deliveries = value;
                    Notify("Deliveries");
                }
            }
        }

        public TrackableCollection<CommercialInvoice> ShowCommercialInvoiceLines
        {
            get { return _showCommercialInvoiceLines; }
            set
            {
                if (_showCommercialInvoiceLines != value)
                {
                    _showCommercialInvoiceLines = value;
                    Notify("ShowCommercialInvoiceLines");
                }
            }
        }

        public int? PaymentRequestId
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

        public List<Attachment> AddAttachments
        {
            get { return _addAttachments; }
            set
            {
                if (_addAttachments != value)
                {
                    _addAttachments = value;
                    Notify("AddAttachments");
                }
            }
        }

        public List<Attachment> DeleteAttachments
        {
            get { return _deleteAttachments; }
            set
            {
                if (_deleteAttachments != value)
                {
                    _deleteAttachments = value;
                    Notify("DeleteAttachments");
                }
            }
        }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                if (_attachments != value)
                {
                    _attachments = value;
                    Notify("Attachments");
                }
            }
        }

        public Dictionary<int, string> LendingRates
        {
            get { return _lendingRates; }
            set
            {
                if (_lendingRates != value)
                {
                    _lendingRates = value;
                    Notify("LendingRates");
                }
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public Dictionary<string, int> StatusTypes
        {
            get { return _statusTypes; }
            set
            {
                if (_statusTypes != value)
                {
                    _statusTypes = value;
                    Notify("StatusTypes");
                }
            }
        }

        public int FinanceStatus
        {
            get { return _financeStatus; }
            set
            {
                if (_financeStatus != value)
                {
                    _financeStatus = value;
                    Notify("FinanceStatus");
                }
            }
        }

        public bool IsPresentAmountCanEdit
        {
            get { return _isPresentAmountCanEdit; }
            set
            {
                if (_isPresentAmountCanEdit != value)
                {
                    _isPresentAmountCanEdit = value;
                    Notify("IsPresentAmountCanEdit");
                }
            }
        }
        #endregion

        #region Constructor

        public IssueLCDetailVM()
        {
            ObjectId = 0;
            Initialize();
            LoadDocumentEnableProperty(ObjectId);
        }

        public IssueLCDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
            LoadDocumentEnableProperty(ObjectId);
        }

        #endregion

        #region Method

        protected void LetterOfCreditDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LCType")
            {
                if (LCType == (int) DBEntity.EnumEntity.LCType.LCSight)
                {
                    LCDays = 0;
                    Interest = 0;
                }
            }

            if (e.PropertyName == "IBORType")
            {
                if (IBORType!=null)
                {
                    IBORValue = GetSelectLMELastedPrice(Convert.ToInt32(IBORType));
                }
            }

            if (e.PropertyName == "PresentAmount" || e.PropertyName == "Float" || e.PropertyName == "IBORValue" ||
                e.PropertyName == "LCDays" || e.PropertyName == "IssueDate" || e.PropertyName == "PresentDate" ||
                e.PropertyName == "PromptBasis")
            {
                if (PromptBasisId == null)
                {
                    return;
                }
                Interest = LCRateCalculation((LCPromptBasis) PromptBasisId, PresentAmount, Deliveries, Float,
                                             IBORValue, LCDays, IssueDate);
            }
        }

        public void BindCboList()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                _currencies = currencyService.GetAll();
                _currencies.Insert(0, new Currency());
            }

            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                _banks = bankService.GetAll().OrderBy(o => o.Name).ToList();
                _banks.Insert(0, new Bank { Id = 0, Name = "" });
            }

            using (var marketPriceService = SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc))
            {
                _lendingRates = marketPriceService.GetSelectLmeCommodity();
                if (_lendingRates == null)
                {
                    var dict = new Dictionary<int, string>();
                    _lendingRates = dict;
                }
                _lendingRates.Add(0, "");
            }

            _lcStatus = new Dictionary<string, int>();
            _lcStatus = EnumHelper.GetEnumDic<LCStatus>(_lcStatus);

            _promptBasis = new Dictionary<string, int>();
            _promptBasis = EnumHelper.GetEnumDic<LCPromptBasis>(_promptBasis);

            _lcTypes = new Dictionary<string, int>();
            _lcTypes = EnumHelper.GetEnumDic<LCType>(_lcTypes);

            LoadStatus();
        }

        /// <summary>
        /// 加载财务状态
        /// </summary>
        private void LoadStatus()
        {
            _statusTypes = new Dictionary<string, int>();
            _statusTypes = EnumHelper.GetEnumDic<StatusType>(StatusTypes);
        }

        public void Initialize()
        {
            _isPresentAmountCanEdit = true;
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    _idList = list.Select(c => c.Id).ToList();
                }

                _applicants = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                _applicants.Insert(0, new BusinessPartner ());
            }

            _deliveries = new TrackableCollection<Delivery>();
            _showCommercialInvoiceLines = new TrackableCollection<CommercialInvoice>();
            BindCboList();

            if (ObjectId > 0)
            {
                LoadAttachments();
                using (
                    var letterOfCreditService =
                        SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
                {
                    const string strInfo = "it.Id = @p1 ";
                    var parameters = new List<object> {ObjectId};
                    LetterOfCredit letterOfCredit =
                        letterOfCreditService.Select(strInfo, parameters,
                                                     new List<string>
                                                         {
                                                             "Quota",
                                                             "Quota.Currency",
                                                             "BusinessPartner",
                                                             "BusinessPartner1",
                                                             "Currency",
                                                             "Deliveries",
                                                              "LCCIRels.CommercialInvoice"
                                                         }).FirstOrDefault();
                    if (letterOfCredit != null)
                    {
                        _amount = letterOfCredit.IssueAmount;
                        _lcNo = letterOfCredit.LCNo;
                        _lcType = letterOfCredit.LCType;
                        _lcStatusId = letterOfCredit.LCStatus;
                        _applicantId = letterOfCredit.ApplicantId;
                        _beneficiaryId = letterOfCredit.BeneficiaryId;
                        _beneficiaryName = letterOfCredit.BusinessPartner1.ShortName;
                        _currencyName = letterOfCredit.Currency.Name;
                        _currencyId = letterOfCredit.CurrencyId;
                        _lcDays = letterOfCredit.LCDays;
                        _promptBasisId = letterOfCredit.PromptBasis;
                        _advisingBankId = letterOfCredit.AdvisingBankId;
                        _issueBankId = letterOfCredit.IssueBankId;
                        _issueDate = letterOfCredit.IssueDate;
                        _issueQuantity = letterOfCredit.IssueQuantity;
                        _acceptanceExpiryDate = letterOfCredit.AcceptanceExpiryDate;
                        _lcExpiryDate = letterOfCredit.LCExpiryDate;
                        _latestShippmentDate = letterOfCredit.LatestShippmentDate;
                        _actualAcceptanceDate = letterOfCredit.ActualAcceptanceDate;
                        _presentAmount = letterOfCredit.PresentAmount;
                        _presentDate = letterOfCredit.PresentDate;
                        _comment = letterOfCredit.Comment;
                        _iborType = letterOfCredit.IBORType;
                        _financeStatus = letterOfCredit.FinancialStatus ? 1 : 0;
                        _iborValue = letterOfCredit.IBORValue;
                        _float = letterOfCredit.Float;
                        _interest = letterOfCredit.Interest;
                        _quotaNo = letterOfCredit.Quota == null ? "" : letterOfCredit.Quota.QuotaNo;
                        _selectedQuotaId = letterOfCredit.QuotaId;
                        _deliveries = letterOfCredit.Deliveries;
                        _paymentRequestId = letterOfCredit.PaymentRequestId;
                        if (letterOfCredit.Quota != null)
                        {
                            _IsLCFinished = letterOfCredit.Quota.IsFundflowFinished ?? true;
                        }
                        FilterDeleted(letterOfCredit.LCCIRels);

                        if (letterOfCredit.LCCIRels != null && letterOfCredit.LCCIRels.Count > 0)
                        {
                            _isPresentAmountCanEdit = false;
                            _showCommercialInvoiceLines.Clear();
                            foreach (var rel in letterOfCredit.LCCIRels)
                            {
                                _showCommercialInvoiceLines.Add(rel.CommercialInvoice);
                            }
                        }
                    }
                }
            }
            else
            {
                LCStatusId = (int)DBEntity.EnumEntity.LCStatus.Issued;
            }

            PropertyChanged += LetterOfCreditDetailVMPropertyChanged;
        }

        protected override void Create()
        {
            var letterOfCredit = new LetterOfCredit
                                     {
                                         PorS = (int) LCPorS.LCPurchase,
                                         IssueAmount = Amount,
                                         LCNo = LCNo,
                                         LCType = LCType,
                                         LCStatus = LCStatusId,
                                         ApplicantId = ApplicantId,
                                         BeneficiaryId = BeneficiaryId,
                                         CurrencyId = CurrencyId,
                                         LCDays = LCDays,
                                         PromptBasis = PromptBasisId,
                                         //AdvisingBankId = AdvisingBankId,
                                         IssueBankId = IssueBankId,
                                         IssueDate = IssueDate,
                                         IssueQuantity = IssueQuantity,
                                         AcceptanceExpiryDate = AcceptanceExpiryDate,
                                         LCExpiryDate = LCExpiryDate,
                                         LatestShippmentDate = LatestShippmentDate,
                                         ActualAcceptanceDate = ActualAcceptanceDate,
                                         PresentAmount = PresentAmount,
                                         PresentDate = PresentDate,
                                         Comment = Comment,
                                         IBORType = IBORType,
                                         FinancialStatus = FinanceStatus == 1,
                                         IBORValue = IBORValue,
                                         Float = Float,
                                         Interest = Interest,
                                         QuotaId = SelectedQuotaId,
                                         PaymentRequestId = PaymentRequestId,
                                     };
            if (AdvisingBankId.HasValue && AdvisingBankId.Value != 0)
            {
                letterOfCredit.AdvisingBankId = AdvisingBankId;
            }
            else
            {
                letterOfCredit.AdvisingBankId = null;
            }

            using (
                var letterOfCreditService =
                    SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                //IsExisted();
                letterOfCreditService.CreateNewLetterOfCredit(letterOfCredit, CurrentUser.Id,
                                                              Deliveries.ToList(), AddAttachments, IsLCFinished);
            }
        }

        protected override void Update()
        {
            using (
                var letterOfCreditService =
                    SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                const string strInfo = "it.Id = @p1 ";
                var parameters = new List<object> {ObjectId};
                LetterOfCredit letterOfCredit =
                    letterOfCreditService.Select(strInfo, parameters,
                                                 new List<string>
                                                     {
                                                         "Quota",
                                                         "BusinessPartner",
                                                         "BusinessPartner1",
                                                         "Currency",
                                                         "Deliveries"
                                                     }).FirstOrDefault();
                if (letterOfCredit != null)
                {
                    letterOfCredit.IssueAmount = Amount;
                    letterOfCredit.LCNo = LCNo;
                    letterOfCredit.LCType = LCType;
                    letterOfCredit.LCStatus = LCStatusId;
                    letterOfCredit.ApplicantId = ApplicantId;
                    letterOfCredit.BeneficiaryId = BeneficiaryId;
                    letterOfCredit.CurrencyId = CurrencyId;
                    letterOfCredit.LCDays = LCDays;
                    letterOfCredit.PromptBasis = PromptBasisId;
                    //letterOfCredit.AdvisingBankId = AdvisingBankId;
                    if (AdvisingBankId.HasValue && AdvisingBankId.Value != 0)
                    {
                        letterOfCredit.AdvisingBankId = AdvisingBankId;
                    }
                    else
                    {
                        letterOfCredit.AdvisingBankId = null;
                    }
                    letterOfCredit.IssueBankId = IssueBankId;
                    letterOfCredit.IssueDate = IssueDate;
                    letterOfCredit.IssueQuantity = IssueQuantity;
                    letterOfCredit.AcceptanceExpiryDate = AcceptanceExpiryDate;
                    letterOfCredit.LCExpiryDate = LCExpiryDate;
                    letterOfCredit.LatestShippmentDate = LatestShippmentDate;
                    letterOfCredit.ActualAcceptanceDate = ActualAcceptanceDate;
                    letterOfCredit.PresentAmount = PresentAmount;
                    letterOfCredit.PresentDate = PresentDate;
                    letterOfCredit.Comment = Comment;
                    letterOfCredit.IBORType = IBORType;
                    letterOfCredit.FinancialStatus = FinanceStatus == 1;
                    letterOfCredit.IBORValue = IBORValue;
                    letterOfCredit.Float = Float;
                    letterOfCredit.Interest = Interest;
                    letterOfCredit.QuotaId = SelectedQuotaId;
                    letterOfCreditService.UpdateExistedLetterOfCredit(letterOfCredit, CurrentUser.Id,
                                                                      Deliveries.ToList(),
                                                                      AddAttachments, DeleteAttachments, IsLCFinished);
                }
                else
                {
                    throw new Exception(ResLetterOfCredit.LoCNotFound);
                }
            }
        }

        public bool IsExisted()
        {
            using (
                var letterOfCreditService =
                    SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                const string strInfo = "it.LCNo = @p1 ";
                var parameters = new List<object> {LCNo};
                LetterOfCredit letterOfCredit = letterOfCreditService.Select(strInfo, parameters, null).FirstOrDefault();
                if (letterOfCredit == null)
                {
                    return false;
                }
            }
            throw new Exception(ResLetterOfCredit.LoCExisted);
        }


        public override bool Validate()
        {
            if (string.IsNullOrEmpty(LCNo))
            {
                throw new Exception(ResLetterOfCredit.LoCNoNotNull);
            }
            if (LCType <= 0)
            {
                throw new Exception(ResLetterOfCredit.LoCTypeNotNull);
            }
            if (LCStatusId <= 0)
            {
                throw new Exception(ResLetterOfCredit.LoCStatusNotNull);
            }
            if (ApplicantId <= 0)
            {
                throw new Exception(ResLetterOfCredit.ApplyBPNotNull);
            }
            if (BeneficiaryId <= 0)
            {
                throw new Exception(ResLetterOfCredit.BenbifitBPNotNull);
            }
            if (CurrencyId <= 0)
            {
                throw new Exception(ResLetterOfCredit.LoCCurrencyNotNull);
            }
            if (CommercialInvoiceCurrencyValidate()) 
            {
                throw new Exception(ResCommercialInvoice.CurrencyInconsistentError3);
            }

            return true;
        }


        /// <summary>
        /// 信用证利息计算
        /// </summary>
        /// <param name="rcPromptBasis">到期的基准</param>
        /// <param name="rcPresentAmount">交单金额</param>
        /// <param name="rcDeliveries">信用证提单集合</param>
        /// <param name="rcFloat">信用证利息的浮点</param>
        /// <param name="rcIBORValue">拆借利率的利率值</param>
        /// <param name="rcDays">远期证的天数</param>
        /// <param name="rcIssueDate">开证日期</param>
        /// <returns></returns>
        public decimal LCRateCalculation(LCPromptBasis rcPromptBasis, decimal? rcPresentAmount,
                                         TrackableCollection<Delivery> rcDeliveries, decimal? rcFloat,
                                         decimal? rcIBORValue, int? rcDays, DateTime? rcIssueDate)
        {
            try
            {
                if (rcPresentAmount == null)
                {
                    return 0;
                }
                rcFloat = (rcFloat ?? 0);
                rcIBORValue = (rcIBORValue ?? 0);
                rcDays = (rcDays ?? 0);
                
                decimal rate = (decimal) rcPresentAmount*
                                   ((decimal) rcFloat*(decimal) 0.01 + (decimal) rcIBORValue*(decimal) 0.01)*(int) rcDays/360;
                return rate;
            }
            catch (Exception e)
            {
                throw new Exception(ResLetterOfCredit.InterestError + e.Message);
            }
        }

        /// <summary>
        /// 拆借利率
        /// </summary>
        /// <param name="id">拆借利率ID</param>
        /// <returns></returns>
        public decimal GetSelectLMELastedPrice(int id)
        {
            try
            {
                using (
                    var marketPriceService =
                        SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc))
                {
                    return marketPriceService.GetSelectLMELastedPrice(id);
                }
            }
            catch
            {
                throw new Exception(ResLetterOfCredit.LIBORError);
            }
        }

        public bool CommercialInvoiceCurrencyValidate() 
        {
            if (CommercialInvoiceId != null && CommercialInvoiceId >0 && CurrencyId > 0) 
            {
                using (
                    var commercialInvoiceService =
                        SvcClientManager.GetSvcClient<CommercialInvoiceServiceReference.CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
                {
                      CommercialInvoice invoice=commercialInvoiceService.GetById((int)CommercialInvoiceId);
                      if (invoice.CurrencyId != CurrencyId) 
                      {
                          return true;
                      }
                }
            }
            return false;
        }
        #endregion

        #region 维护附件列表

        /// <summary>
        /// 根据id获取附件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atts"> </param>
        /// <returns></returns>
        public Attachment GetAttachmentById(int id, List<Attachment> atts)
        {
            if (atts != null)
            {
                return atts.FirstOrDefault(attachment => attachment.Id == id);
            }

            return null;
        }

        /// <summary>
        /// 加载附件
        /// </summary>
        public void LoadAttachments()
        {
            if (ObjectId <= 0)
            {
                _attachments.Clear();
            }
            else
            {
                using (
                    var attachmentService =
                        SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
                {
                    const int documentType = (int)DocumentType.LetterOfCredit;
                    const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2 ";
                    var parameters = new List<object> {ObjectId, documentType};
                    _attachments = attachmentService.Query(queryStr, parameters);
                    if (_attachments.Count > 0)
                    {
                        _attachments = attachmentService.ChangeAttachmentName(Attachments);
                    }
                }
            }
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="attachment"></param>
        public void AddAttachment(Attachment attachment)
        {
            if (Attachments == null)
                Attachments = new List<Attachment>();
            if (AddAttachments == null)
                AddAttachments = new List<Attachment>();
            attachment.DocumentId = 3;
            int id = -GetMaxNum();
            attachment.Id = id;
            _attachments.Add(attachment);
            using (
                  var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                  )
            {
                if (Attachments.Count > 0)
                {
                    Attachments = attachmentService.ChangeAttachmentName(_attachments);
                }
            }
            AddAttachments.Add(attachment);
        }

        private int GetMaxNum()
        {
            if (Attachments != null && Attachments.Count > 0)
            {
                IEnumerable<int> query = from attachment in Attachments select Math.Abs(attachment.Id);
                int num = query.Max() + 1;
                return num;
            }

            return 1;
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="deleteId"></param>
        public void RemoveAttachment(int deleteId)
        {
            Attachment attachment = GetAttachmentById(deleteId, Attachments);
            if (attachment != null)
            {
                Attachments.Remove(attachment);
                if (Attachments.Count == 0)
                    Attachments = null;
            }

            Attachment addattachment = GetAttachmentById(deleteId, AddAttachments);
            {
                if (addattachment != null)
                {
                    //如果是新增的附件
                    AddAttachments.Remove(addattachment);
                    if (AddAttachments.Count == 0)
                        AddAttachments = null;
                }
                else
                {
                    //增加到删除列表里
                    if (DeleteAttachments == null)
                    {
                        DeleteAttachments = new List<Attachment>();
                    }
                    DeleteAttachments.Add(attachment);
                }
            }
        }

        #endregion

#region 编辑属性
        private bool _isBPEnable;
        private bool _isInternalCustomerEnable;
        private bool _isQuotaEnable;

        public bool IsBPEnable
        {
            get { return _isBPEnable; }
            set
            {
                if (_isBPEnable != value)
                {
                    _isBPEnable = value;
                    Notify("IsBPEnable");
                }
            }
        }

        public bool IsInternalCustomerEnable
        {
            get { return _isInternalCustomerEnable; }
            set
            {
                if (_isInternalCustomerEnable != value)
                {
                    _isInternalCustomerEnable = value;
                    Notify("IsInternalCustomerEnable");
                }
            }
        }

        public bool IsQuotaEnable
        {
            get { return _isQuotaEnable; }
            set
            {
                if (_isQuotaEnable != value)
                {
                    _isQuotaEnable = value;
                    Notify("IsQuotaEnable");
                }
            }
        }

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsBPEnable = true;
                IsInternalCustomerEnable = true;
                IsQuotaEnable = true;
            }
            else
            {
                using (var lcService = SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
                {
                    LCEnableProperty lcep = lcService.SetElementsEnableProperty(id);
                    IsBPEnable = lcep.IsBPEnable;
                    IsInternalCustomerEnable = lcep.IsInternalCustomerEnable;
                    IsQuotaEnable = lcep.IsQuotaEnable;
                }
            }
        }
#endregion
    }
}