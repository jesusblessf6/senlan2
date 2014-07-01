using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CommercialInvoiceServiceReference;
using Client.ContractServiceReference;
using Client.CurrencyServiceReference;
using Client.DeliveryServiceReference;
using Client.LetterOfCreditServiceReference;
using Client.PaymentMeanServiceReference;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.View.Physical.CommercialInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.PricingServiceReference;
using Client.DocumentServiceReference;
using Client.AttachmentServiceReference;
using Client.BusinessPartnerServiceReference;
using System.ComponentModel;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class FinalCommercialInvoiceVM : ObjectBaseVM
    {
        #region Member

        private List<CommercialInvoice> _addInvoice;
        private decimal _amount;
        private decimal _balance;
        private decimal _pricingCurrencyBalance;
        private List<Currency> _currencies;
        private string _currency;
        private List<CommercialInvoice> _deleteInvoice;
        private string _deliveryTerm;
        private decimal _grossWeight;
        private decimal _interest;
        private string _invoiceNo;
        private DateTime? _invoicedDate = DateTime.Now.Date;
        private List<CommercialInvoice> _invoices;
        private decimal? _money;
        private decimal _netWeights;
        private Dictionary<string, int> _paymentMean;
        private decimal _price;
        private int _quotaCurrencyId;
        private int? _quotaId;
        private string _quotaNo;
        private string _remark;
        private int _selectCurrencyId;
        private int? _selectPaymentMeanId;
        private decimal? _settlementRate;
        private string _supplierName;
        private List<BankAccountClass> _bankAccountList;
        private int? _selectedBankAccountID;
        private string _isVisible;
        private readonly ContractType _contractType;
        private string _lbName = Properties.Resources.Receivable + "/" + Properties.Resources.Payable;

        private List<Attachment> _addAttachments;
        private List<Attachment> _attachments;
        private List<Attachment> _deleteAttachments;
        private List<int> _idList;
        private bool _IsCIFinished = true;
        private int _clearBalanceCurrencyId;
        private decimal? _clearBalanceRate;

        #endregion

        #region Property
        public int ClearBalanceCurrencyId
        {
            get { return _clearBalanceCurrencyId; }
            set
            {
                if (_clearBalanceCurrencyId != value)
                {
                    _clearBalanceCurrencyId = value;
                    Notify("ClearBalanceCurrencyId");
                }
            }
        }

        public decimal? ClearBalanceRate
        {
            get { return _clearBalanceRate; }
            set
            {
                if (_clearBalanceRate != value)
                {
                    _clearBalanceRate = value;
                    Notify("ClearBalanceRate");
                }
            }
        }

        public bool IsCIFinished
        {
            get { return _IsCIFinished; }
            set
            {
                if (_IsCIFinished != value)
                {
                    _IsCIFinished = value;
                    Notify("IsCIFinished");
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

        public bool ChangeQuota { get; set; }

        public string LbName
        {
            get { return _lbName; }
            set
            {
                if (_lbName != value)
                {
                    _lbName = value;
                    Notify("LbName");
                }
            }
        }

        public string IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    Notify("IsVisible");
                }
            }
        }

        public int? SelectedBankAccountID
        {
            get { return _selectedBankAccountID; }
            set
            {
                if (_selectedBankAccountID != value)
                {
                    _selectedBankAccountID = value;
                    Notify("SelectedBankAccountID");
                }
            }
        }

        public List<BankAccountClass> BankAccountList
        {
            get { return _bankAccountList; }
            set
            {
                if (_bankAccountList != value)
                {
                    _bankAccountList = value;
                    Notify("BankAccountList");
                }
            }
        }

        public int QuotaCurrencyId
        {
            get { return _quotaCurrencyId; }
            set
            {
                if (_quotaCurrencyId != value)
                {
                    _quotaCurrencyId = value;
                    Notify("QuotaCurrencyId");
                }
            }
        }

        public decimal? SettlementRate
        {
            get
            {
                return _settlementRate;
            }
            set
            {
                if (_settlementRate != value)
                {
                    _settlementRate = value;
                    Notify("SettlementRate");
                }
            }
        }

        public int SelectCurrencyId
        {
            get { return _selectCurrencyId; }
            set
            {
                if (_selectCurrencyId != value)
                {
                    _selectCurrencyId = value;
                    Notify("SelectCurrencyId");
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

        public DateTime? InvoicedDate
        {
            get { return _invoicedDate; }
            set
            {
                if (_invoicedDate != value)
                {
                    _invoicedDate = value;
                    Notify("InvoicedDate");
                }
            }
        }

        public int? QuotaId
        {
            set
            {
                if (_quotaId != value)
                {
                    _quotaId = value;
                    Notify("QuotaId");
                }
            }
            get { return _quotaId; }
        }

        public string QuotaNo
        {
            set
            {
                if (_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
            get { return _quotaNo; }
        }

        public string SupplierName
        {
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    Notify("SupplierName");
                }
            }
            get { return _supplierName; }
        }

        public string DeliveryTerm
        {
            set
            {
                if (_deliveryTerm != value)
                {
                    _deliveryTerm = value;
                    Notify("DeliveryTerm");
                }
            }
            get { return _deliveryTerm; }
        }

        public int? SelectPaymentMeanId
        {
            get { return _selectPaymentMeanId; }
            set
            {
                if (_selectPaymentMeanId != value)
                {
                    _selectPaymentMeanId = value;
                    Notify("SelectPaymentMeanId");
                }
            }
        }

        public Dictionary<string, int> PaymentMean
        {
            get { return _paymentMean; }
            set
            {
                if (_paymentMean != value)
                {
                    _paymentMean = value;
                    Notify("PaymentMean");
                }
            }
        }

        public List<CommercialInvoice> AddInvoice
        {
            get { return _addInvoice; }
            set
            {
                if (_addInvoice != value)
                {
                    _addInvoice = value;
                    Notify("AddInvoice");
                }
            }
        }

        public List<CommercialInvoice> DeleteInvoice
        {
            get { return _deleteInvoice; }
            set
            {
                if (_deleteInvoice != value)
                {
                    _deleteInvoice = value;
                    Notify("DeleteInvoice");
                }
            }
        }

        public List<CommercialInvoice> Invoices
        {
            get { return _invoices; }
            set
            {
                if (_invoices != value)
                {
                    _invoices = value;
                    Notify("Invoices");
                }
            }
        }

        public decimal NetWeights
        {
            get { return _netWeights; }
            set
            {
                if (_netWeights != value)
                {
                    _netWeights = value;
                    Notify("NetWeights");
                }
            }
        }

        public decimal GrossWeight
        {
            get { return _grossWeight; }
            set
            {
                if (_grossWeight != value)
                {
                    _grossWeight = value;
                    Notify("GrossWeight");
                }
            }
        }

        public decimal? Money
        {
            get
            {
                //if (_money != null)
                //{
                //    _money = Math.Round(_money.Value, RoundRules.AMOUNT);
                //}
                return _money;
            }
            set
            {
                if (_money != value)
                {
                    _money = value;
                    Notify("Money");
                }
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                    Notify("Currency");
                }
            }
        }

        public decimal Interest
        {
            get { return _interest; }
            set
            {
                if (_interest != value)
                {
                    _interest = value;
                    Notify("Interest");
                }
            }
        }

        public decimal Price
        {
            get
            {
                _price = Math.Round(_price, RoundRules.RATE, MidpointRounding.AwayFromZero);
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify("Price");
                }
            }
        }

        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    Notify("Remark");
                }
            }
        }

        public decimal Amouts
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    Notify("Amounts");
                }
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    Notify("Balance");
                }
            }
        }

        public decimal PricingCurrencyBalance
        {
            get { return _pricingCurrencyBalance; }
            set
            {
                if (_pricingCurrencyBalance != value)
                {
                    _pricingCurrencyBalance = value;
                    Notify("PricingCurrencyBalance");
                }
            }
        }

        /// <summary>
        /// 新增附件列表
        /// </summary>
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

        /// <summary>
        /// 删除附件列表
        /// </summary>
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

        #endregion

        public FinalCommercialInvoiceVM(ContractType contractType)
        {
            IsVisible = contractType == ContractType.Purchase ? "Hidden" : "Visible";
            LoadCurrency();
            GetInternalIDList();
            SetPaymentMean();
            _contractType = contractType;
            PropertyChanged += OnPropertyChanged;
        }

        public FinalCommercialInvoiceVM(int id, ContractType contractType)
        {
            IsVisible = contractType == ContractType.Purchase ? "Hidden" : "Visible";
            ObjectId = id;
            LoadCurrency();
            SetPaymentMean();
            LoadInvoice();
            GetInternalIDList();
            GetBankAccount(QuotaId);
            _contractType = contractType;
            PropertyChanged += OnPropertyChanged;
        }

        #region Method
        public void GetInternalIDList()
        {
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
        }

        public void GetBankAccount(int? quotaId)
        {
            var list = new List<BankAccountClass> { new BankAccountClass { AccountCode = "", Id = 0 } };
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> { quotaId };
                List<Quota> quotaList = quotaService.Select(str, parameters, new List<string> { "Contract.InternalCustomer.BankAccounts.Bank", "Contract.InternalCustomer.BankAccounts", "Contract.InternalCustomer" });
                if (quotaList.Count > 0)
                {
                    Quota quota = quotaList[0];
                    foreach (BankAccount bankAccount in quota.Contract.InternalCustomer.BankAccounts)
                    {
                        if (!bankAccount.IsDeleted)
                        {
                            var account = new BankAccountClass
                                              {
                                                  Id = bankAccount.Id,
                                                  AccountCode = bankAccount.Bank.Name + "-" + bankAccount.AccountCode
                                              };
                            list.Add(account);
                        }
                    }
                }
                BankAccountList = list;
                if (BankAccountList.Count > 0)
                {
                    if (ObjectId <= 0)
                    {
                        SelectedBankAccountID = BankAccountList[0].Id;
                    }
                }
            }
        }

        private void SetPaymentMean()
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMean = new Dictionary<string, int> { { "", 0 } };
                List<PaymentMean> paymentmeans = paymentMeanService.GetAll();
                foreach (PaymentMean paymentmean in paymentmeans)
                {
                    PaymentMean.Add(paymentmean.Name, paymentmean.Id);
                }
            }
        }

        private void LoadInvoice()
        {
            CommercialInvoice invoice = GetInvoiceById(ObjectId);
            if (invoice != null)
            {
                Quota quota = GetQuotaById(invoice.QuotaId ?? 0);
                Contract contract = GetContractById(quota.ContractId);
                _quotaId = invoice.QuotaId;
                if (quota.PricingCurrencyId != null) _quotaCurrencyId = quota.PricingCurrencyId.Value;
                _invoiceNo = invoice.InvoiceNo;
                _invoicedDate = invoice.InvoicedDate;
                _deliveryTerm = invoice.DeliveryTerm;
                _selectPaymentMeanId = invoice.PaymentMeanId;
                if (invoice.CurrencyId != null) _selectCurrencyId = (int)invoice.CurrencyId;
                _settlementRate = invoice.ExchangeRate;
                _money = invoice.Amount;
                if (invoice.Price != null)
                    _price = (decimal)invoice.Price;
                _remark = invoice.Comment;
                _quotaNo = quota.QuotaNo;
                _currency = quota.Currency.Name;
                _IsCIFinished = quota.IsCIFinished ?? false;
                _supplierName = contract.BusinessPartner.ShortName;

                _selectedBankAccountID = invoice.BankAccountId == null ? 0 : invoice.BankAccountId.Value;
                using (
                    var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                    )
                {
                    string queryStr = "it.DocumentId= 13 and it.RecordId= " + invoice.Id;
                    var parameters = new List<object> { ObjectId };
                    Attachments = attachmentService.Query(queryStr, parameters);
                    if (Attachments.Count > 0)
                    {
                        Attachments = attachmentService.ChangeAttachmentName(Attachments);
                    }
                }
                LoadProvisionalInvoice();
                _clearBalanceRate = invoice.ClearBalanceRate;
                _clearBalanceCurrencyId = invoice.ClearBalanceCurrencyId ?? 0;
                SetClearBalance();
            }
        }

        /// <summary>
        /// 初始化临时发票列表
        /// </summary>
        private void LoadProvisionalInvoice()
        {
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                Invoices = invoiceService.Select("it.FinalInvoiceId==" + ObjectId, null,
                                                 new List<string> { "Quota", "Quota.Currency", "Currency", "LCCIRels", "LCCIRels.LetterOfCredit" });
                Calc(false);
            }
        }

        /// <summary>
        /// 根据发票ID获取发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommercialInvoice GetInvoiceById(int id)
        {
            CommercialInvoice invoice;
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                invoice = invoiceService.GetById(id);
            }
            return invoice;
        }

        private Quota GetQuotaById(int id)
        {
            Quota quota;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quota = quotaService.FetchById(id, new List<string> { "Contract", "Currency" });
            }
            return quota;
        }

        /// <summary>
        /// 根据合同ID获取合同
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Contract GetContractById(int id)
        {
            Contract contract;
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                contract = contractService.FetchById(id, new List<string> { "BusinessPartner" });
            }
            return contract;
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void Create()
        {

            var commercialInvoice = new CommercialInvoice
                                        {
                                            QuotaId = QuotaId,
                                            InvoiceNo = InvoiceNo,
                                            InvoicedDate = InvoicedDate,
                                            DeliveryTerm = DeliveryTerm,
                                            PaymentMeanId = SelectPaymentMeanId,
                                            ExchangeRate = SettlementRate,
                                            CurrencyId = SelectCurrencyId,
                                            Amount = Money,
                                            Price = Price,
                                            Comment = _remark,
                                            BankAccountId = SelectedBankAccountID <= 0 ? null : SelectedBankAccountID,
                                            InvoiceType = (int)CommercialInvoiceType.Final
                                        };
            if (ClearBalanceCurrencyId != 0)
            {
                commercialInvoice.ClearBalanceCurrencyId = ClearBalanceCurrencyId;
            }
            else
            {
                commercialInvoice.ClearBalanceCurrencyId = null;
            }
            if (ClearBalanceRate != 0)
            {
                commercialInvoice.ClearBalanceRate = ClearBalanceRate;
            }
            else
            {
                commercialInvoice.ClearBalanceRate = null;
            }
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                commercialInvoiceService.CreateFinalCommercialInvoice(CurrentUser.Id, commercialInvoice, AddInvoice, AddAttachments, IsCIFinished);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        protected override void Update()
        {
            var commercialInvoice = new CommercialInvoice
                                        {
                                            Id = ObjectId,
                                            QuotaId = QuotaId,
                                            InvoiceNo = InvoiceNo,
                                            InvoicedDate = InvoicedDate,
                                            DeliveryTerm = DeliveryTerm,
                                            PaymentMeanId = SelectPaymentMeanId,
                                            ExchangeRate = SettlementRate,
                                            CurrencyId = SelectCurrencyId,
                                            Amount = Money,
                                            Price = Price,
                                            Comment = _remark,
                                            BankAccountId = SelectedBankAccountID <= 0 ? null : SelectedBankAccountID,
                                            InvoiceType = (int)CommercialInvoiceType.Final
                                        };
            if (ClearBalanceCurrencyId != 0)
            {
                commercialInvoice.ClearBalanceCurrencyId = ClearBalanceCurrencyId;
            }
            else
            {
                commercialInvoice.ClearBalanceCurrencyId = null;
            }
            if (ClearBalanceRate != 0)
            {
                commercialInvoice.ClearBalanceRate = ClearBalanceRate;
            }
            else
            {
                commercialInvoice.ClearBalanceRate = null;
            }
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                commercialInvoiceService.UpdateFinalCommercialInvoice(CurrentUser.Id, commercialInvoice, AddInvoice,
                                                                      DeleteInvoice, AddAttachments, DeleteAttachments, ChangeQuota, IsCIFinished);
            }
        }

        /// <summary>
        /// 页面数据验证
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (!QuotaId.HasValue || QuotaId.Value == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            if (_invoices == null || _invoices.Count == 0)
            {
                throw new Exception(ResCommercialInvoice.ProvisionalInvoiceNotNull);
            }
            if (SelectCurrencyId == 0)
            {
                throw new Exception(Properties.Resources.CurrencyNotNull);
            }
            int currencyCount = Invoices.Select(o => o.CurrencyId).Distinct().Count();
            if (currencyCount > 1)
            {
                throw new Exception(ResCommercialInvoice.CurrencyInconsistentError);
            }
            if (!SettlementRate.HasValue || SettlementRate == 0)
            {
                throw new Exception("汇率不能为空或0");
            }
            //验证关联的信用证上的开证币种和临时发票
            bool flag = false;
            if (Invoices != null && Invoices.Count > 0)
            {
                if (Invoices.Any(invoice => invoice.CurrencyId != SelectCurrencyId))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                throw new Exception(ResCommercialInvoice.CurrencyInconsistentError2);
            }
            //if (ObjectId == 0)
            //    CheckInvoiceNo();
            return true;
        }

        /// <summary>
        /// 增加临时发票
        /// </summary>
        /// <param name="invoice"></param>
        public void AppendInvoice(CommercialInvoice invoice)
        {
            if (Invoices == null)
            {
                Invoices = new List<CommercialInvoice>();
            }
            if (AddInvoice == null)
            {
                AddInvoice = new List<CommercialInvoice>();
            }
            if (!ContainsInvoice(invoice, Invoices))
            {
                Invoices.Add(invoice);
                AddInvoice.Add(invoice);
            }
            Calc();
        }

        /// <summary>
        /// 删除临时发票
        /// </summary>
        /// <param name="id"></param>
        public void Removeinvoice(int id)
        {
            CommercialInvoice invoice = GetCommercialInvoiceById(id);
            Invoices.Remove(invoice);
            if (Invoices.Count == 0)
            {
                Invoices = null;
            }
            if (AddInvoice != null)
            {
                if (ContainsInvoice(invoice, AddInvoice))
                {
                    AddInvoice.Remove(invoice);
                    if (AddInvoice.Count == 0)
                    {
                        AddInvoice = null;
                    }
                }
                else
                {
                    if (DeleteInvoice == null)
                    {
                        DeleteInvoice = new List<CommercialInvoice> { invoice };
                    }
                }
            }
            else
            {
                if (DeleteInvoice == null)
                {
                    DeleteInvoice = new List<CommercialInvoice> { invoice };
                }
            }
            Calc();
        }

        /// <summary>
        /// 在发票列表中获取发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private CommercialInvoice GetCommercialInvoiceById(int id)
        {
            if (Invoices != null)
            {
                return Invoices.SingleOrDefault(o => o.Id == id);
            }

            return null;
        }

        /// <summary>
        /// 列表是否包含该发票
        /// </summary>
        /// <param name="commercialInvoice"></param>
        /// <param name="commercialInvoices"></param>
        /// <returns></returns>
        private bool ContainsInvoice(CommercialInvoice commercialInvoice, IEnumerable<CommercialInvoice> commercialInvoices)
        {
            return commercialInvoices.Any(invoice => invoice.Id == commercialInvoice.Id);
        }

        ///// <summary>
        ///// 计算金额
        ///// </summary>
        //private void CalcContruct()
        //{
        //    decimal interest = 0M;
        //    decimal netWeights = 0M;
        //    decimal grossWeights = 0M;
        //    decimal ammounts = 0M;
        //    if (Invoices != null)
        //    {
        //        foreach (CommercialInvoice invoice in Invoices)
        //        {
        //            int id = invoice.Id;
        //            interest += invoice.TotleInterest;
        //            decimal nWeight, gWeight;
        //            GetWeights(id, out nWeight, out gWeight);
        //            netWeights += nWeight;
        //            grossWeights += gWeight;
        //            if (invoice.Amount.HasValue)
        //            {
        //                ammounts += (decimal) invoice.Amount;
        //            }
        //        }
        //    }
        //    Interest = interest;
        //    NetWeights = netWeights;
        //    GrossWeight = grossWeights;
        //    Ammouts = ammounts;
        //    SetMoney();
        //}

        /// <summary>
        /// 计算金额
        /// </summary>
        private void Calc(bool isAdded = true)
        {
            decimal interest = 0M;
            decimal netWeights = 0M;
            decimal grossWeights = 0M;
            decimal amounts = 0M;
            if (Invoices != null)
            {
                foreach (CommercialInvoice invoice in Invoices)
                {
                    int id = invoice.Id;
                    interest += invoice.TotleInterest;
                    decimal nWeight, gWeight;
                    GetWeights(id, out nWeight, out gWeight);
                    netWeights += nWeight;
                    grossWeights += gWeight;
                    if (invoice.Amount.HasValue)
                    {
                        amounts += (decimal)invoice.Amount;
                    }
                }
            }
            Interest = interest;
            NetWeights = netWeights;
            GrossWeight = grossWeights;
            Amouts = amounts;

            SetMoney(isAdded);
        }

        /// <summary>
        /// 计算信用证利息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private decimal GetInterest(int id)
        {
            decimal interests = 0.0M;
            using (var invoiceService = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                CommercialInvoice invoice = invoiceService.SelectById(new List<string>() { "LCCIRels", "LCCIRels.LetterOfCredit" }, id);
                FilterDeleted(invoice.LCCIRels);
                foreach (var rel in invoice.LCCIRels)
                {
                    LetterOfCredit credit = rel.LetterOfCredit;
                    decimal presentAmount = credit.PresentAmount ?? 0;
                    decimal allocationAmount = rel.AllocationAmount ?? 0;
                    decimal interest = credit.Interest ?? 0;
                    if (presentAmount != 0 && allocationAmount != 0 && interest != 0)
                    {
                        interests += interest * allocationAmount / presentAmount;
                    }
                }
            }
            return interests;
        }

        /// <summary>
        /// 计算毛重净重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="netWeights"></param>
        /// <param name="grossWeights"></param>
        private void GetWeights(int id, out decimal netWeights, out decimal grossWeights)
        {
            netWeights = 0;
            grossWeights = 0;
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                CommercialInvoice invoice = invoiceService.SelectById(new List<string> {"Deliveries", "Deliveries.DeliveryLines",
                                                                                   "ProvisionalInvoices", "BaseInvoice", "BaseInvoice.Deliveries" }, id);

                netWeights = invoice.NetWeights;
                grossWeights = invoice.GrossWeights;

                //List<Delivery> deliveries = deliveryService.Select("it.CommercialInvoiceId=" + id, null,
                //                                                               new List<string> { "DeliveryLines", "BaseCommercialInvoiceId", "Deliveries",
                //                                                                   "ProvisionalInvoices", "BaseInvoice", "BaseInvoice.Deliveries" });

                //foreach (var delivery in deliveries)
                //{
                //    FilterDeleted(delivery.DeliveryLines);
                //    foreach (DeliveryLine line in delivery.DeliveryLines)
                //    {
                //        netWeights += (line.NetWeight ?? 0);
                //        grossWeights += (line.GrossWeight ?? 0);
                //    }
                //}
            }
        }

        /// <summary>
        /// 设置应收应付
        /// </summary>
        /// <param name="isAdded">true 新增  false 编辑加载</param>
        public void SetMoney(bool isAdded = true)
        {
            if (isAdded)
            {
                if (SettlementRate == null)
                {
                    Money = 0;
                    Balance = 0;
                    LbName = Properties.Resources.Payable + " / " + Properties.Resources.Receivable;
                    return;
                }
                Money = Math.Round(Price * (SettlementRate ?? 0) * NetWeights + Interest, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
            }

            if (_contractType == ContractType.Purchase)
            {
                //采购
                Balance = (Money ?? 0) - Amouts;
                LbName = Balance >= 0 ? Properties.Resources.Payable : Properties.Resources.Receivable;
            }
            else
            {
                //销售
                Balance = (Money ?? 0) - Amouts;
                LbName = Balance >= 0 ? Properties.Resources.Receivable : Properties.Resources.Payable;
            }
            Balance = Math.Round(Math.Abs(Balance), RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
            //if (SettlementRate != null && SettlementRate != 0)
            //{
            //    PricingCurrencyBalance = Math.Round(Balance / (decimal)SettlementRate, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
            //}
        }

        ///// <summary>
        ///// 设置应收应付
        ///// </summary>
        //public void SetMoneyContruct()
        //{
        //    if (_contractType == ContractType.Purchase)
        //    {
        //        //采购
        //        Balance = (Money ?? 0) - Ammouts;
        //        LbName = Balance >= 0 ? Properties.Resources.Payable : Properties.Resources.Receivable;
        //    }
        //    else
        //    {
        //        //销售
        //        Balance = (Money ?? 0) - Ammouts;
        //        LbName = Balance >= 0 ? Properties.Resources.Receivable : Properties.Resources.Payable;
        //    }
        //    Balance = Math.Round(Math.Abs(Balance), RoundRules.AMOUNT);
        //}

        private void LoadCurrency()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                List<Currency> currencies = currencyService.GetAll();
                currencies.Insert(0, new Currency { Id = 0, Name = "" });
                Currencies = currencies;
            }
        }

        /// <summary>
        /// 根据币种返回兑换的汇率
        /// </summary>
        public void LoadRate(int currencyFrom, int currencyTo)
        {
            if (currencyFrom != 0 && currencyTo != 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    decimal? rate = rateService.GetExchangeRate(currencyFrom, currencyTo, CurrentUser.Id);
                    SettlementRate = rate.HasValue ? rate : null;
                }
            }
            else
            {
                SettlementRate = null;
            }
        }

        public void LoadRate()
        {
            if (SelectCurrencyId != 0)
            {
                LoadRate(SelectCurrencyId, QuotaCurrencyId);
            }
            else
            {
                SettlementRate = null;
            }
        }

        private void CheckInvoiceNo()
        {
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                string str = "it.InvoiceNo = @p1 and it.InvoiceType=" + (int)CommercialInvoiceType.Final;
                var param = new List<object> { InvoiceNo };
                List<CommercialInvoice> commercialInvoices = commercialInvoiceService.Query(str, param);
                if (commercialInvoices.Count > 0)
                {
                    throw new Exception(ResCommercialInvoice.InvoiceNoExisted);
                }
            }
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

        /// <summary>
        /// 根据id获取附件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atts"> </param>
        /// <returns></returns>
        public Attachment GetAttachmentById(int id, List<Attachment> atts)
        {
            if (atts == null)
                return null;
            return atts.FirstOrDefault(attachment => attachment.Id == id);
        }

        /// <summary>
        /// 加载附件列表
        /// </summary>
        public void LoadAttachments()
        {
            //点编辑的时候
            if (ObjectId != 0)
            {
                //int id = GetDocumentId("FinalInvoice");
                const int documentType = (int)DocumentType.FinalInvoice;
                using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
                {
                    const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2";
                    var parameters = new List<object> { ObjectId, documentType };
                    _attachments = attachmentService.Query(queryStr, parameters);
                    if (Attachments.Count > 0)
                    {
                        Attachments = attachmentService.ChangeAttachmentName(_attachments);
                    }
                }
            }
        }

        private int GetDocumentId(string code)
        {
            int id;
            using (var documentService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                id = documentService.GetByTableCode(code).Id;
            }
            return id;
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="attachment"></param>
        public void AddAttachment(Attachment attachment)
        {
            int did = GetDocumentId("FinalInvoice");
            if (Attachments == null)
                Attachments = new List<Attachment>();
            if (AddAttachments == null)
                AddAttachments = new List<Attachment>();
            attachment.DocumentId = did;
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

        /// <summary>
        /// 给新增的附件一个id值，方便删除操作定位
        /// </summary>
        /// <returns></returns>
        private int GetMaxNum()
        {
            if (Attachments.Count == 0)
                return 1;
            IEnumerable<int> query = from attachment in Attachments select Math.Abs(attachment.Id);
            int num = query.Max() + 1;
            return num;
        }

        public void LoadInvoice(int quotaId)
        {
            using (var invoiceService = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                string query = "it.FinalInvoiceId is null and it.InvoiceType = " + (int)CommercialInvoiceType.Provisional + " and it.QuotaId =" + quotaId;
                List<string> eagerLoadList = new List<string> { "Quota", "Currency", "Deliveries", "Deliveries.DeliveryLines", "LCCIRels", "LCCIRels.LetterOfCredit" };
                List<CommercialInvoice> list = invoiceService.Select(query, null, eagerLoadList);
                if (list.Count > 0)
                {
                    foreach (var c in list)
                    {
                        AppendInvoice(c);
                    }
                }
            }
        }

        private void SetClearBalanceRate()
        {
            if (ClearBalanceCurrencyId != 0 && SelectCurrencyId != 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    decimal? rate = rateService.GetExchangeRate(ClearBalanceCurrencyId, SelectCurrencyId, CurrentUser.Id);
                    ClearBalanceRate = rate.HasValue ? rate : null;
                }
            }
            else
            {
                ClearBalanceRate = null;
            }
        }

        private void SetClearBalance()
        {
            if (ClearBalanceCurrencyId != 0 && ClearBalanceRate.HasValue && ClearBalanceRate.Value > 0)
            {
                Currency currency;
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    currency = currencyService.GetById(SelectCurrencyId);
                }
                if(currency != null)
                {
                    if (currency.Code == "CNY")
                    {
                        PricingCurrencyBalance = Balance / ClearBalanceRate.Value;
                    }
                    else if(currency.Code == "USD")
                    {
                        PricingCurrencyBalance = Balance * ClearBalanceRate.Value;
                    }
                }
            }
            else
            {
                PricingCurrencyBalance = 0;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SettlementRate":
                case "Price":
                    SetMoney();
                    SetClearBalance();
                    break;
                case "SelectCurrencyId":
                    LoadRate();
                    SetMoney();
                    //SetClearBalanceRate();
                    break;
                case "ClearBalanceCurrencyId"://二次结算币种
                    //SetClearBalanceRate();
                    break;
                case "ClearBalanceRate"://二次结算汇率
                    SetClearBalance();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}