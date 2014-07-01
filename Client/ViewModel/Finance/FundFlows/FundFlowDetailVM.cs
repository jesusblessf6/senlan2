using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.BankAccountServiceReference;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CurrencyServiceReference;
using Client.FundFlowServiceReference;
using Client.Properties;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.View.Finance.FundFlows;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.PaymentMeanServiceReference;
using DBEntity.EnableProperty;
using Client.FinancialAccountServiceReference;
using System.Text.RegularExpressions;

namespace Client.ViewModel.Finance.FundFlows
{
    public class FundFlowDetailVM : ObjectBaseVM
    {
        #region Member

        private decimal? _amount;
        private string _bPartnerName;
        private List<BankAccount> _bankAccounts;
        private List<Currency> _currencies;
        private string _description;
        private string _financialAccountName;
        private List<BusinessPartner> _internalCustomers;
        private int? _icId;
        private int? _paymentRequestId;
        private string _quotaNo;
        private decimal? _rate;
        private int? _selectedBPartnerId;
        private int? _selectedBankAccountId;
        private int? _selectedFinancialAccountId;
        private int? _selectedPaymentCurrencyId;
        private int? _selectedQuotaId;
        private int _settlementCurrencyId;
        private string _settlementCurrencyName;
        private DateTime? _tradeDate;
        private int? _rOrP;
        private List<int> _idList;
        private int? _paymentMeanId;
        private List<PaymentMean> _paymentmeans;
        private bool _IsFundflowFinished = true;

        #endregion

        #region Property
        public bool IsFundflowFinished
        {
            get { return _IsFundflowFinished; }
            set { 
                if(_IsFundflowFinished != value)
                {
                    _IsFundflowFinished = value;
                    Notify("IsFundflowFinished");
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

        public int? ROrP
        {
            get { return _rOrP; }
            set
            {
                if (_rOrP != value)
                {
                    _rOrP = value;
                    Notify("ROrP");
                }
            }
        }

        public DateTime? TradeDate
        {
            get { return _tradeDate; }
            set
            {
                if (_tradeDate != value)
                {
                    _tradeDate = value;
                    Notify("TradeDate");
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

        public int? SelectedBPartnerId
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

        public int SettlementCurrencyId
        {
            get { return _settlementCurrencyId; }
            set
            {
                if (_settlementCurrencyId != value)
                {
                    _settlementCurrencyId = value;
                    Notify("SettlementCurrencyId");
                }
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

        public int? ICId
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
            get { return Math.Round(_amount == null ? 0 : (decimal)_amount, RoundRules.AMOUNT, MidpointRounding.AwayFromZero); }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    Notify("Amount");
                }
            }
        }

        public decimal? Rate
        {
            get { return Math.Round(_rate == null ? 0 : (decimal)_rate, RoundRules.RATE, MidpointRounding.AwayFromZero); }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    Notify("Rate");
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

        public string SettlementCurrencyName
        {
            get { return _settlementCurrencyName; }
            set
            {
                if (_settlementCurrencyName != value)
                {
                    _settlementCurrencyName = value;
                    Notify("SettlementCurrencyName");
                }
            }
        }

        public int? SelectedPaymentCurrencyId
        {
            get { return _selectedPaymentCurrencyId; }
            set
            {
                if (_selectedPaymentCurrencyId != value)
                {
                    _selectedPaymentCurrencyId = value;
                    Notify("SelectedPaymentCurrencyId");
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

        public int? SelectedFinancialAccountId
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

        public List<BankAccount> BankAccounts
        {
            get { return _bankAccounts; }
            set
            {
                if (_bankAccounts != value)
                {
                    _bankAccounts = value;
                    Notify("BankAccounts");
                }
            }
        }

        public int? SelectedBankAccountId
        {
            get { return _selectedBankAccountId; }
            set
            {
                if (_selectedBankAccountId != value)
                {
                    _selectedBankAccountId = value;
                    Notify("SelectedBankAccountId");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
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

        public List<PaymentMean> PaymentMeans
        {
            get { return _paymentmeans; }
            set
            {
                _paymentmeans = value;
                Notify("PaymentMeans");
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

        public FundFlowDetailVM(int? rOrP)
        {
            ObjectId = 0;
            ROrP = rOrP;
            Initialize();
            PropertyChanged += PaymentDetailVMPropertyChanged;
            SetSettlementCurrencyByQuotaId(SelectedQuotaId);
            LoadDocumentEnableProperty(ObjectId);
        }

        public FundFlowDetailVM(int id, int? rOrP)
        {
            ObjectId = id;
            ROrP = rOrP;
            Initialize();
            PropertyChanged += PaymentDetailVMPropertyChanged;
            SetSettlementCurrencyByQuotaId(SelectedQuotaId);
            LoadDocumentEnableProperty(ObjectId);
        }

        #endregion

        #region Method

        protected void PaymentDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SettlementCurrencyId" || e.PropertyName == "SelectedPaymentCurrencyId")
            {
                if (SettlementCurrencyId == SelectedPaymentCurrencyId)
                {
                    Rate = 1;
                }
                else
                {
                    using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                    {
                        Rate = rateService.GetExchangeRate(SettlementCurrencyId,
                                                           SelectedPaymentCurrencyId == null
                                                               ? 0
                                                               : (int) SelectedPaymentCurrencyId, CurrentUser.Id);
                    }
                }
            }

            if (e.PropertyName == "ICId" || e.PropertyName == "SelectedPaymentCurrencyId")
            {
                BindBankAccount();
            }

            if (e.PropertyName == "SelectedBPartnerId")
            {
                SelectedQuotaId = null;
                QuotaNo = null;
                SetSettlementCurrencyByQuotaId(SelectedQuotaId);//重新选择会清空批次 结算币种要重新赋值
            }
        }

        public void SetSettlementCurrencyByQuotaId(int? quotaId)
        {
            Currency cry;
            if (quotaId == null)
            {
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    cry = currencyService.GetCurrencyByCode("CNY");
                }
            }
            else
            {
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    cry = quotaService.GetSettlementCurrencyByQuotaId((int)quotaId);
                }
            }
            SettlementCurrencyName = cry == null ? "" : cry.Name;
            SettlementCurrencyId = cry == null ? 0 : cry.Id;
        }

        public void BindBankAccount()
        {
            using (
                var bankAccountService = SvcClientManager.GetSvcClient<BankAccountServiceClient>(SvcType.BankAccountSvc)
                )
            {
                int currencyId = _selectedPaymentCurrencyId == null ? 0 : Convert.ToInt32(SelectedPaymentCurrencyId);
                int customerId = _icId == null ? 0 : Convert.ToInt32(ICId);
                List<BankAccount> accounts = bankAccountService.GetBankAccountsByCurrencyIdAndCustomerId(currencyId,
                                                                                                         customerId,
                                                                                                         BankAccountType
                                                                                                             .Asset);
                accounts.Insert(0, new BankAccount {Id = 0, Description = ""});
                BankAccounts = accounts;
                if (_selectedBankAccountId == null)
                {
                    #region 切换内部客户 重新绑定默认银行账户
                    if (accounts.Count > 0)
                    {
                        List<BankAccount> defaultAccountList = accounts.Where(c => c.IsDefault != null && c.IsDefault.Value).ToList();
                        if (defaultAccountList.Count > 0)
                        {
                            BankAccount account = defaultAccountList[0];
                            SelectedBankAccountId = account.Id;
                        }
                    }
                }
                #endregion
            }
        }

        public void Initialize()
        {
            TradeDate = DateTime.Now.Date;

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }

            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner {Id = 0, ShortName = ""});
            }

            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                _currencies = currencyService.GetAll();
                _currencies.Insert(0, new Currency {Id = 0, Name = ""});
                if (ROrP == (int)FundFlowType.Receive)
                {
                    Currency currency = currencyService.GetCurrencyByCode("CNY");
                    if (currency != null)
                    {
                        SelectedPaymentCurrencyId = currency.Id;
                    }
                }
            }

            //付款方式
            using (
                var receivepaymentmeanService =
                    SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc))
            {
                PaymentMeans = receivepaymentmeanService.GetAll();
                PaymentMeans.Insert(0, new PaymentMean { Id = 0, Name = string.Empty });
            }
            if (ROrP == (int)FundFlowType.Receive)
            {
                using (
                    var financialaccountService =
                        SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
                {
                    const string condition = "it.Name = @p1";
                    var parameters = new List<object> { "货款" };
                    List<FinancialAccount> accountList = financialaccountService.Select(condition, parameters, null);
                    if (accountList != null && accountList.Count > 0)
                    {
                        FinancialAccount account = accountList[0];
                        SelectedFinancialAccountId = account.Id;
                        FinancialAccountName = account.Name;
                    }
                }
            }

            if (ObjectId > 0)
            {
                using (var fundFlowService = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc))
                {
                    const string strInfo = "it.Id = @p1 ";
                    var parameters = new List<object> {ObjectId};
                    FundFlow fundFlow =
                        fundFlowService.Select(strInfo, parameters,
                                               new List<string>
                                                   {
                                                       "Quota",
                                                       "Quota.Currency",
                                                       "BusinessPartner",
                                                       "InternalCustomer",
                                                       "Currency",
                                                       "FinancialAccount"
                                                   }).FirstOrDefault();
                    if (fundFlow != null)
                    {
                        _selectedBankAccountId = fundFlow.BankAccountId;
                        _selectedFinancialAccountId = fundFlow.FinancialAccountId;
                        _rate = fundFlow.Rate;
                        _selectedPaymentCurrencyId = fundFlow.CurrencyId;
                        _selectedQuotaId = fundFlow.QuotaId;
                        _icId = fundFlow.InternalBPId;
                        _selectedBPartnerId = fundFlow.BPId;
                        _tradeDate = fundFlow.TradeDate;
                        _amount = fundFlow.Amount;
                        SetSettlementCurrencyByQuotaId(fundFlow.QuotaId);
                        _description = fundFlow.Description;
                        _paymentRequestId = fundFlow.PaymentRequestId;
                        _bPartnerName = fundFlow.BusinessPartner.ShortName;
                        _financialAccountName = fundFlow.FinancialAccount.Name;
                        _quotaNo = fundFlow.Quota == null ? "" : fundFlow.Quota.QuotaNo;
                        _paymentMeanId = fundFlow.PaymentMeanId;
                        if (fundFlow.Quota != null)
                        {
                            _IsFundflowFinished = fundFlow.Quota.IsFundflowFinished ?? true;
                        }
                        BindBankAccount();
                    }
                }
            }
        }

        protected override void Create()
        {
            var fundFlow = new FundFlow
                               {
                                   RorP = (int) ROrP,
                                   BankAccountId =
                                       SelectedBankAccountId == null ? 0 : Int32.Parse(SelectedBankAccountId.ToString()),
                                   FinancialAccountId =
                                       SelectedFinancialAccountId == null
                                           ? 0
                                           : Int32.Parse(SelectedFinancialAccountId.ToString()),
                                   Rate = Rate == null ? 0 : decimal.Parse(Rate.ToString()),
                                   CurrencyId =
                                       SelectedPaymentCurrencyId == null
                                           ? 0
                                           : Int32.Parse(SelectedPaymentCurrencyId.ToString()),
                                   QuotaId = SelectedQuotaId,
                                   InternalBPId = ICId == null ? 0 : Int32.Parse(ICId.ToString()),
                                   BPId = SelectedBPartnerId == null ? 0 : Int32.Parse(SelectedBPartnerId.ToString()),
                                   TradeDate = TradeDate,
                                   Amount = Amount,
                                   Description = Description,
                                   PaymentRequestId = PaymentRequestId,
                                   PaymentMeanId = PaymentMeanId == 0 ? null : PaymentMeanId
                               };
            //fundFlow.Quota.IsFundflowFinished = IsFundflowFinished;

            using (var fundFlowService = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc))
            {
                fundFlowService.AddNewFundFlow(IsFundflowFinished, fundFlow, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var fundFlowService = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc))
            {
                FundFlow fundFlow = fundFlowService.GetById(ObjectId);
                if (fundFlow != null)
                {
                    fundFlow.RorP = (int) ROrP;
                    fundFlow.BankAccountId = SelectedBankAccountId == null
                                                 ? 0
                                                 : Int32.Parse(SelectedBankAccountId.ToString());
                    fundFlow.FinancialAccountId = SelectedFinancialAccountId == null
                                                      ? 0
                                                      : Int32.Parse(SelectedFinancialAccountId.ToString());
                    fundFlow.Rate = Rate == null ? 0 : decimal.Parse(Rate.ToString());
                    fundFlow.CurrencyId = SelectedPaymentCurrencyId == null
                                              ? 0
                                              : Int32.Parse(SelectedPaymentCurrencyId.ToString());
                    fundFlow.QuotaId = SelectedQuotaId;
                    fundFlow.InternalBPId = ICId == null ? 0 : Int32.Parse(ICId.ToString());
                    fundFlow.BPId = SelectedBPartnerId == null ? 0 : Int32.Parse(SelectedBPartnerId.ToString());
                    fundFlow.TradeDate = TradeDate;
                    fundFlow.Amount = Amount;
                    fundFlow.Description = Description;
                    fundFlow.PaymentMeanId = PaymentMeanId;
                    //fundFlow.Quota.IsFundflowFinished = IsFundflowFinished;
                    fundFlowService.UpdateFundFlow(IsFundflowFinished,fundFlow, CurrentUser.Id);
                }
            }
        }


        public override bool Validate()
        {
            if ((ROrP ?? 0) == (int)FundFlowType.Pay)
            {

                if (SelectedBPartnerId == null || SelectedBPartnerId <= 0)
                {
                    throw new Exception(ResFundFlow.ReceiptBPNotNull);
                }
                if (TradeDate == null)
                {
                    throw new Exception(ResFundFlow.PaymentDateNotNull);
                }
                if (Amount == null)
                {
                    throw new Exception(ResFundFlow.PaymentAmountNotNull);
                }
                if (ICId == null || ICId <= 0)
                {
                    throw new Exception(Resources.PaymentBPNotNull);
                }
                if (SelectedPaymentCurrencyId <= 0)
                {
                    throw new Exception(ResFundFlow.PaymentCurrencyNotNull);
                }
                if (SelectedFinancialAccountId == null || SelectedFinancialAccountId <= 0)
                {
                    throw new Exception(ResFundFlow.FinancialAccountNotNull);
                }
                if (SelectedBankAccountId == null || SelectedBankAccountId <= 0)
                {
                    throw new Exception(ResFundFlow.PaymentAccountNotNull);
                }
            }
            else
            {
                if (SelectedBPartnerId == null || SelectedBPartnerId <= 0)
                {
                    throw new Exception(Resources.PaymentBPNotNull);
                }
                if (ICId == null || ICId <= 0)
                {
                    throw new Exception(ResFundFlow.ReceiptBPNotNull);
                }
                if (TradeDate == null)
                {
                    throw new Exception(ResFundFlow.ReceiptDateNotNull);
                }
                if (Amount == null)
                {
                    throw new Exception(ResFundFlow.ReceiptAmountNotNull);
                }
                if (SelectedPaymentCurrencyId <= 0)
                {
                    throw new Exception(ResFundFlow.ReceiptCurrencyNotNull);
                }
                if (SelectedFinancialAccountId == null || SelectedFinancialAccountId <= 0)
                {
                    throw new Exception(ResFundFlow.FinancialAccountNotNull);
                }
                if (SelectedBankAccountId == null || SelectedBankAccountId <= 0)
                {
                    throw new Exception(ResFundFlow.ReceiptAccountNotNull);
                }
            }
            return true;
        }

        /// <summary>
        /// 仅当 存在货款及子节点 并没有选择批次的情况下 需要弹出验证提示
        /// </summary>
        /// <returns></returns>
        public bool CheckFinancialAccount() 
        {
            if(SelectedFinancialAccountId!=null && SelectedFinancialAccountId>0)
            {
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    List<int> idList = quotaService.GetFinancialAccount(CurrentUser.Id);
                    if (idList.Contains((int)SelectedFinancialAccountId)) 
                    {
                        if (SelectedQuotaId == null || SelectedQuotaId <= 0) 
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region 编辑属性
        private bool _isBPEnable;
        private bool _isInternalCustomerEnable;

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

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsBPEnable = true;
                IsInternalCustomerEnable = true;
            }
            else
            {
                using (var ffService = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc))
                {
                    FundFlowEnableProperty ffep = ffService.SetElementsEnableProperty(id);
                    IsBPEnable = ffep.IsBPEnable;
                    IsInternalCustomerEnable = ffep.IsInternalCustomerEnable;
                }
            }
        }

        #endregion
    }
}