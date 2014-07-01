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
using Client.AttachmentServiceReference;
using Client.DocumentServiceReference;
using DBEntity.EnableProperty;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class ProvisionalCommercialInvoiceVM : ObjectBaseVM
    {
        #region Member

        private List<Delivery> _addDelivery;
        private List<LetterOfCredit> _addLetterOfCredit;
        private List<Currency> _currencies;
        private string _currency;
        private List<Delivery> _deleteDelivery;
        private List<LetterOfCredit> _deleteLetterOfCredit;
        private List<Delivery> _deliveries;
        private string _deliveryTerm;
        private decimal _grossWeight;
        private decimal _interest;
        private string _invoiceNo;
        private DateTime? _invoicedDate = DateTime.Now.Date;
        private List<LetterOfCredit> _letterOfCredits;
        private decimal? _money;
        private decimal _netWeights;
        private Dictionary<string, int> _paymentMean;
        private decimal? _price;
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
        private int _loadCount = 1;
        private List<int> _idList;

        private List<Attachment> _addAttachments;
        private List<Attachment> _deleteAttachments;
        private List<Attachment> _attachments;

        private decimal? ratio = 100;

        private List<LCCIRel> _lcciRels;
        private List<LCCIRel> _addRels;
        private List<LCCIRel> _deleteRels;
        private bool _IsCIFinished = true;
        private string _IsFinishedVisible;

        #endregion

        #region Property
        public string IsFinishedVisible
        {
            get { return _IsFinishedVisible; }
            set
            {
                if (_IsFinishedVisible != value)
                {
                    _IsFinishedVisible = value;
                    Notify("IsFinishedVisible");
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


        public ContractType ContractType { get; set; }

        public int LoadCount { get; set; }

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
                if (_settlementRate != null)
                {
                    _settlementRate = Math.Round(_settlementRate.Value, RoundRules.RATE, MidpointRounding.AwayFromZero);
                }
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

        public List<LetterOfCredit> AddLetterOfCredit
        {
            get { return _addLetterOfCredit; }
            set
            {
                if (_addLetterOfCredit != value)
                {
                    _addLetterOfCredit = value;
                    Notify("AddLetterOfCredit");
                }
            }
        }

        public List<LetterOfCredit> DeleteLetterOfCredit
        {
            get { return _deleteLetterOfCredit; }
            set
            {
                if (_deleteLetterOfCredit != value)
                {
                    _deleteLetterOfCredit = value;
                    Notify("DeleteLetterOfCredit");
                }
            }
        }

        public List<LetterOfCredit> LetterOfCredits
        {
            get { return _letterOfCredits; }
            set
            {
                if (_letterOfCredits != value)
                {
                    _letterOfCredits = value;
                    Notify("LetterOfCredits");
                }
            }
        }

        public List<Delivery> AddDelivery
        {
            get { return _addDelivery; }
            set
            {
                if (_addDelivery != value)
                {
                    _addDelivery = value;
                    Notify("AddDelivery");
                }
            }
        }

        public List<Delivery> DeleteDelivery
        {
            get { return _deleteDelivery; }
            set
            {
                if (_deleteDelivery != value)
                {
                    _deleteDelivery = value;
                    Notify("DeleteDelivery");
                }
            }
        }

        public List<Delivery> Deliveries
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

        public decimal NetWeights
        {
            get
            {
                return _netWeights;
            }
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
                if (_money != null)
                {
                    _money = Math.Round(_money.Value, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
                }
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

        public decimal? Price
        {
            get
            {
                if (_price != null)
                {
                    if (IsFinalCommercialInv)
                    {
                        _price = Math.Round(_price.Value, RoundRules.RATE, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        _price = Math.Round(_price.Value, RoundRules.PRICE, MidpointRounding.AwayFromZero);
                    }
                }
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

        public decimal? Ratio
        {
            get { return ratio; }
            set
            {
                if (ratio != value)
                {
                    ratio = value;
                    Notify("Ratio");
                }
            }
        }

        public List<LCCIRel> LCCIRels
        {
            get { return _lcciRels; }
            set
            {
                if (_lcciRels != value)
                {
                    _lcciRels = value;
                    Notify("LCCIRels");
                }
            }
        }

        public List<LCCIRel> AddRels
        {
            get { return _addRels; }
            set
            {
                if (_addRels != value)
                {
                    _addRels = value;
                    Notify("AddRels");
                }
            }
        }

        public List<LCCIRel> DeleteRels
        {
            get { return _deleteRels; }
            set
            {
                if (_deleteRels != value)
                {
                    _deleteRels = value;
                    Notify("DeleteRels");
                }
            }
        }

        public bool IsFinalCommercialInv { get; set; }

        #endregion

        #region Construct

        public ProvisionalCommercialInvoiceVM(ContractType contractType, bool isFinalCommercialInv = false)
        {
            ChangeQuota = false;
            LoadCount = 1;
            const int id = 0;
            IsFinalCommercialInv = isFinalCommercialInv;
            IsVisible = contractType == ContractType.Purchase ? "Collapsed" : "Visible";
            LoadCurrency();
            GetInternalIDList();
            SetPaymentMean();
            LoadProvisionalCommercialInvoiceEnableProperty(id);
        }

        public ProvisionalCommercialInvoiceVM(int id, ContractType contractType, bool isFinalCommercialInv = false)
        {
            ChangeQuota = false;
            LoadCount = 0;
            IsFinalCommercialInv = isFinalCommercialInv;
            IsVisible = contractType == ContractType.Purchase ? "Collapsed" : "Visible";
            ObjectId = id;
            _loadCount = 0;
            LoadCurrency();
            GetInternalIDList();
            SetPaymentMean();
            LoadInvoice();
            GetBankAccount(QuotaId);
            LoadAttachments();
            LoadProvisionalCommercialInvoiceEnableProperty(ObjectId);
        }

        #endregion

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
                        var account = new BankAccountClass();
                        if (!bankAccount.IsDeleted)
                        {
                            account.Id = bankAccount.Id;
                            account.AccountCode = bankAccount.Bank.Name + "-" + bankAccount.AccountCode;
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
                QuotaId = invoice.QuotaId;
                InvoiceNo = invoice.InvoiceNo;
                InvoicedDate = invoice.InvoicedDate;
                DeliveryTerm = invoice.DeliveryTerm;
                SelectPaymentMeanId = invoice.PaymentMeanId;
                SelectedBankAccountID = invoice.BankAccountId;
                Money = invoice.Amount;
                Price = invoice.Price;
                Remark = invoice.Comment;
                Ratio = invoice.Ratio ?? 100;
                QuotaNo = quota.QuotaNo;
                _currency = quota.Currency.Name;
                _IsCIFinished = quota.IsCIFinished ?? false;
                if (quota.PricingCurrencyId != null) QuotaCurrencyId = quota.PricingCurrencyId.Value;
                SupplierName = contract.BusinessPartner.ShortName;
                if (invoice.ExchangeRate.HasValue)
                {
                    SettlementRate = invoice.ExchangeRate.Value;
                }
                if (invoice.CurrencyId.HasValue)
                {
                    SelectCurrencyId = invoice.CurrencyId.Value;
                }
                LoadDeliveries(invoice.Id);
                LCCIRels = invoice.LCCIRels.ToList();
                SetWeights();
                SetInterest();
            }
        }

        public void AppendLetterOfCredit(LCCIRel rel)
        {
            if (LCCIRels == null)
            {
                LCCIRels = new List<LCCIRel>();
            }
            if (AddRels == null)
            {
                AddRels = new List<LCCIRel>();
            }
            int maxId = 1;
            if (LCCIRels.Count > 0)
            {
                maxId = LCCIRels.Max(o => o.Id);
                maxId++;
            }
            rel.Id = maxId;
            LCCIRels.Add(rel);
            AddRels.Add(rel);
            SetInterest();
        }

        public void RemoveLetterOfCredit(int id)
        {
            LCCIRel rel = GetLCCIRelById(id);
            LCCIRels.Remove(rel);
            if (LCCIRels.Count == 0)
            {
                LCCIRels = null;
            }
            if (AddRels != null)
            {
                if (ContainsLCCIRel(rel, AddRels))
                {
                    AddRels.Remove(rel);
                    if (AddRels.Count == 0)
                    {
                        AddRels = null;
                    }
                }
                else
                {
                    if (DeleteRels == null)
                    {
                        DeleteRels = new List<LCCIRel> { rel };
                    }
                    else
                    {
                        DeleteRels.Add(rel);
                    }
                }
            }
            else
            {
                if (DeleteRels == null)
                {
                    DeleteRels = new List<LCCIRel> { rel };
                }
                else
                {
                    DeleteRels.Add(rel);
                }
            }
            SetInterest();
        }

        private bool ContainsLCCIRel(LCCIRel rel, IEnumerable<LCCIRel> Rels)
        {
            return Rels.Any(o => o.Id == rel.Id);
        }

        public void AppendDeliveries(Delivery delivery)
        {
            if (Deliveries == null)
            {
                Deliveries = new List<Delivery>();
            }
            if (AddDelivery == null)
            {
                AddDelivery = new List<Delivery>();
            }
            if (!ContainsDelivery(delivery, Deliveries))
            {
                Deliveries.Add(delivery);
                AddDelivery.Add(delivery);
            }
            SetWeights();
        }

        private Delivery GetDeliveryById(int id)
        {
            if (Deliveries != null)
            {
                return Deliveries.SingleOrDefault(o => o.Id == id);
            }

            return null;
        }

        private LCCIRel GetLCCIRelById(int id)
        {
            if (LCCIRels != null)
            {
                return LCCIRels.SingleOrDefault(o => o.Id == id);
            }

            return null;
        }

        public void RemoveDeliveries(int id)
        {
            Delivery delivery = GetDeliveryById(id);
            Deliveries.Remove(delivery);
            if (Deliveries.Count == 0)
            {
                Deliveries = null;
            }
            if (AddDelivery != null)
            {
                if (ContainsDelivery(delivery, AddDelivery))
                {
                    AddDelivery.Remove(delivery);
                    if (AddDelivery.Count == 0)
                    {
                        AddDelivery = null;
                    }
                }
                else
                {
                    if (DeleteDelivery == null)
                    {
                        DeleteDelivery = new List<Delivery> { delivery };
                    }
                }
            }
            else
            {
                if (DeleteDelivery == null)
                {
                    DeleteDelivery = new List<Delivery> { delivery };
                }
            }
            SetWeights();
        }

        private bool ContainsDelivery(Delivery delivery, IEnumerable<Delivery> deliveries)
        {
            return deliveries.Any(line => line.Id == delivery.Id);
        }

        public void SetWeights()
        {
            decimal nWeight, gWeight;
            CalcNetWeights(out nWeight, out gWeight);
            NetWeights = nWeight;
            GrossWeight = gWeight;
            SetMoney();
        }

        private void CalcNetWeights(out decimal nWights, out decimal gWeight)
        {
            nWights = 0;
            gWeight = 0;
            if (Deliveries != null)
            {
                foreach (Delivery delivery in Deliveries)
                {
                    if (delivery.TotalNetWeight.HasValue)
                    {
                        nWights += delivery.TotalNetWeight.Value;
                    }
                    if (delivery.TotalGrossWeight.HasValue)
                    {
                        gWeight += delivery.TotalGrossWeight.Value;
                    }
                }
            }
        }

        public void SetInterest()
        {
            Interest = CalcInterest();
            SetMoney();
        }

        private decimal CalcInterest()
        {
            decimal interest = 0;
            if (LCCIRels != null)
            {
                foreach (var rel in LCCIRels)
                {
                    //按分配金额计算信用证利息
                    decimal presentAmount = rel.LetterOfCredit.PresentAmount ?? 0;
                    decimal allocationAmount = rel.AllocationAmount ?? 0;
                    decimal lcInterest = rel.LetterOfCredit.Interest ?? 0;
                    if (allocationAmount != 0 && presentAmount != 0 && lcInterest != 0)
                    {
                        interest += lcInterest * allocationAmount / presentAmount;
                    }
                }
            }
            return Math.Round(interest, RoundRules.AMOUNT, MidpointRounding.AwayFromZero);
        }

        public void SetPrice()
        {
            if (Money.HasValue && Money != 0 && _netWeights != 0 && SettlementRate != null && SettlementRate != 0)
            {
                if (SettlementRate != null && SettlementRate != 0)
                {
                    if(IsFinalCommercialInv)
                    {
                        Price = Math.Round(Money.Value / (decimal)SettlementRate / _netWeights / (Ratio ?? 100) * 100, RoundRules.RATE, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        Price = Math.Round(Money.Value / (decimal)SettlementRate / _netWeights / (Ratio ?? 100) * 100, RoundRules.PRICE, MidpointRounding.AwayFromZero);
                    }
                    return;
                }
            }

            Price = 0;
        }

        /// <summary>
        /// 根据单价计算金额
        /// </summary>
        public void SetMoney()
        {
            if (Price.HasValue && Price != 0 && NetWeights != 0 && SettlementRate != null && SettlementRate != 0)
            {
                Money = Math.Round((Price * SettlementRate) ?? 0, RoundRules.AMOUNT, MidpointRounding.AwayFromZero) * NetWeights * (Ratio ?? 100) / 100;
                if (IsFinalCommercialInv == true)
                {
                    Money += Interest;
                }
            }
            else
            {
                Money = 0;
            }
        }

        public void ChangeNetWeight()
        {
            SetMoney();
        }

        protected override void Create()
        {
            var commercialInvoice = new CommercialInvoice
                                        {
                                            QuotaId = QuotaId,
                                            InvoiceNo = InvoiceNo,
                                            InvoicedDate = InvoicedDate,
                                            DeliveryTerm = DeliveryTerm,
                                            PaymentMeanId = SelectPaymentMeanId == 0 ? null : SelectPaymentMeanId,
                                            Amount = Money,
                                            CurrencyId = SelectCurrencyId,
                                            ExchangeRate = SettlementRate,
                                            Price = Price,
                                            Comment = _remark,
                                            BankAccountId = SelectedBankAccountID <= 0 ? null : SelectedBankAccountID,
                                            InvoiceType = IsFinalCommercialInv ? (int)CommercialInvoiceType.FinalCommercial : (int)CommercialInvoiceType.Provisional,
                                            Ratio = Ratio
                                        };
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                commercialInvoiceService.CreateCommercialInvoice(CurrentUser.Id, commercialInvoice, AddRels,
                                                                 AddDelivery, AddAttachments, IsCIFinished);
            }
        }

        protected override void Update()
        {
            var commercialInvoice = new CommercialInvoice
                                        {
                                            Id = ObjectId,
                                            QuotaId = QuotaId,
                                            InvoiceNo = InvoiceNo,
                                            InvoicedDate = InvoicedDate,
                                            DeliveryTerm = DeliveryTerm,
                                            PaymentMeanId = SelectPaymentMeanId == 0 ? null : SelectPaymentMeanId,
                                            Amount = Money,
                                            CurrencyId = SelectCurrencyId,
                                            ExchangeRate = SettlementRate,
                                            Price = Price,
                                            Comment = _remark,
                                            BankAccountId = SelectedBankAccountID <= 0 ? null : SelectedBankAccountID,
                                            InvoiceType = IsFinalCommercialInv ? (int)CommercialInvoiceType.FinalCommercial : (int)CommercialInvoiceType.Provisional,
                                            Ratio = Ratio
                                        };
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                commercialInvoiceService.UpdateCommercialInvoice(CurrentUser.Id, commercialInvoice, AddRels,
                                                                 DeleteRels, AddDelivery,
                                                                 DeleteDelivery, AddAttachments, DeleteAttachments, ChangeQuota, IsCIFinished);
            }
        }

        public override bool Validate()
        {
            if (!QuotaId.HasValue || QuotaId.Value == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            if (_deliveries == null || _deliveries.Count == 0)
            {
                if (ContractType == ContractType.Purchase)
                {
                    throw new Exception(ResCommercialInvoice.BLNotNull);
                }

                throw new Exception(ResCommercialInvoice.DeliveryFormNotNull);
            }
            if (SelectCurrencyId == 0)
            {
                throw new Exception(Properties.Resources.CurrencyNotNull);
            }

            if (Price == null || Price == 0)
            {
                throw new Exception(Properties.Resources.PriceNotNull);
            }
            if (!SettlementRate.HasValue || SettlementRate == 0)
            {
                throw new Exception("汇率不能为空或0!");
            }
            //验证关联的信用证上的开证币种和临时发票
            bool flag = false;
            if (LCCIRels != null && LCCIRels.Count > 0)
            {
                if (LCCIRels.Any(o => o.LetterOfCredit.CurrencyId != SelectCurrencyId))
                {
                    flag = true;
                }
            }

            //if (_letterOfCredits != null && _letterOfCredits.Count > 0)
            //{
            //    if (_letterOfCredits.Any(letterOfCredit => letterOfCredit.CurrencyId != SelectCurrencyId))
            //    {
            //        flag = true;
            //    }
            //}
            if (flag)
            {
                throw new Exception(ResCommercialInvoice.CurrencyInconsistentError3);
            }
            //if (ObjectId == 0)
            //    CheckInvoiceNo();
            return true;
        }

        private void CheckInvoiceNo()
        {
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                string str = "it.InvoiceNo = @p1 and it.InvoiceType=" + (int)CommercialInvoiceType.Provisional;
                var param = new List<object> { InvoiceNo };
                List<CommercialInvoice> commercialInvoices = commercialInvoiceService.Query(str, param);
                if (commercialInvoices.Count > 0)
                {
                    throw new Exception(ResCommercialInvoice.InvoiceNoExisted);
                }
            }
        }


        public CommercialInvoice GetInvoiceById(int id)
        {
            CommercialInvoice invoice;
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                invoice = invoiceService.SelectById(new List<string>() { "LCCIRels", "LCCIRels.LetterOfCredit", "LCCIRels.LetterOfCredit.Currency" }, id);
                FilterDeleted(invoice.LCCIRels);
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

        private Contract GetContractById(int id)
        {
            Contract contract;
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                contract = contractService.FetchById(id, new List<string> { "BusinessPartner" });
            }
            return contract;
        }

        private void LoadDeliveries(int id)
        {
            List<Delivery> deliveries;
            using (
                var invoiceService = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                string str = "it.CommercialInvoiceId=" + id;

                deliveries = invoiceService.GetDeliveryByInvoiceId(CurrentUser.Id, id);
            }
            Deliveries = deliveries;
        }

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
            if (_loadCount++ > 0)
            {
                if (SelectCurrencyId != 0)
                {
                    LoadRate(SelectCurrencyId, QuotaCurrencyId);
                }
            }
        }

        #endregion

        #region 维护附件列表

        /// <summary>
        /// 加载附件
        /// </summary>
        public void LoadAttachments()
        {
            //int id = GetDocumentId("ProvisionalInvoice");
            const int documentType = (int)DocumentType.ProvisionalInvoice;
            if (ObjectId <= 0)
            {
                Attachments.Clear();
            }
            else
            {
                using (
                    var attachmentService =
                        SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
                {
                    const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2";
                    var parameters = new List<object> { ObjectId, documentType };
                    _attachments = attachmentService.Query(queryStr, parameters);
                    ChangeAttachmentName(_attachments);
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
            int did = GetDocumentId("ProvisionalInvoice");
            if (Attachments == null)
                Attachments = new List<Attachment>();
            if (AddAttachments == null)
                AddAttachments = new List<Attachment>();
            attachment.DocumentId = did;
            int id = -GetMaxNum();
            attachment.Id = id;
            _attachments.Add(attachment);
            ChangeAttachmentName(_attachments);
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

        private void ChangeAttachmentName(IEnumerable<Attachment> attachments)
        {
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    string name = attachment.FileName;
                    string fileName = GetFileName(name);
                    string fex = GetFex(fileName);
                    int index = fileName.LastIndexOf("_", StringComparison.Ordinal);
                    string realFileName = fileName.Substring(0, index);
                    attachment.Name = realFileName + "." + fex;
                }
            }
        }

        /// <summary>  
        /// 获取文件名称  
        /// </summary>  
        /// <param name="path">路径</param>  
        /// <returns></returns>  
        public static string GetFileName(String path)
        {
            if (path.Contains("\\"))
            {
                string[] arr = path.Split('\\');
                return arr[arr.Length - 1];
            }
            else
            {
                string[] arr = path.Split('/');
                return arr[arr.Length - 1];
            }
        }

        /// <summary>  
        /// 获取文件后缀名  
        /// </summary>  
        /// <param name="filename">文件名</param>  
        /// <returns></returns>  
        public static String GetFex(string filename)
        {
            return filename.Substring(filename.LastIndexOf(".", StringComparison.Ordinal) + 1);
        }

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
        #endregion

        #region 临时商业发票控件可编辑逻辑

        private bool _isQuotaEnable;
        private bool _isPaymentMeansEnable;
        private bool _isLCAddEnable;
        private bool _isDeliveryAddEnable;
        private bool _isPriceEnable;
        private bool _isAmountEnable;
        private bool _isSettlementCurrencyEnable;
        private bool _isExchangeRateEnable;
        private bool _isIncludeInterestEnable;
        private bool _isLCDeleteEnable;
        private bool _isDeliveryDeleteEnable;

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

        public bool IsPaymentMeansEnable
        {
            get { return _isPaymentMeansEnable; }
            set
            {
                if (_isPaymentMeansEnable != value)
                {
                    _isPaymentMeansEnable = value;
                    Notify("IsPaymentMeansEnable");
                }
            }
        }

        public bool IsLCAddEnable
        {
            get { return _isLCAddEnable; }
            set
            {
                if (_isLCAddEnable != value)
                {
                    _isLCAddEnable = value;
                    Notify("IsLCAddEnable");
                }
            }
        }

        public bool IsDeliveryAddEnable
        {
            get { return _isDeliveryAddEnable; }
            set
            {
                if (_isDeliveryAddEnable != value)
                {
                    _isDeliveryAddEnable = value;
                    Notify("IsDeliveryAddEnable");
                }
            }
        }

        public bool IsPriceEnable
        {
            get { return _isPriceEnable; }
            set
            {
                if (_isPriceEnable != value)
                {
                    _isPriceEnable = value;
                    Notify("IsPriceEnable");
                }
            }
        }

        public bool IsAmountEnable
        {
            get { return _isAmountEnable; }
            set
            {
                if (_isAmountEnable != value)
                {
                    _isAmountEnable = value;
                    Notify("IsAmountEnable");
                }
            }
        }

        public bool IsSettlementCurrencyEnable
        {
            get { return _isSettlementCurrencyEnable; }
            set
            {
                if (_isSettlementCurrencyEnable != value)
                {
                    _isSettlementCurrencyEnable = value;
                    Notify("IsSettlementCurrencyEnable");
                }
            }
        }

        public bool IsExchangeRateEnable
        {
            get { return _isExchangeRateEnable; }
            set
            {
                if (_isExchangeRateEnable != value)
                {
                    _isExchangeRateEnable = value;
                    Notify("IsExchangeRateEnable");
                }
            }
        }

        public bool IsIncludeInterestEnable
        {
            get { return _isIncludeInterestEnable; }
            set
            {
                if (_isIncludeInterestEnable != value)
                {
                    _isIncludeInterestEnable = value;
                    Notify("IsIncludeInterestEnable");
                }
            }
        }

        public bool IsLCDeleteEnable
        {
            get { return _isLCDeleteEnable; }
            set
            {
                if (_isLCDeleteEnable != value)
                {
                    _isLCDeleteEnable = value;
                    Notify("IsLCDeleteEnable");
                }
            }
        }


        public bool IsDeliveryDeleteEnable
        {
            get { return _isDeliveryDeleteEnable; }
            set
            {
                if (_isDeliveryDeleteEnable != value)
                {
                    _isDeliveryDeleteEnable = value;
                    Notify("IsDeliveryDeleteEnable");
                }
            }
        }

        /// <summary>
        /// 加载临时发票的控件编辑属性
        /// </summary>
        /// <param name="id"></param>
        private void LoadProvisionalCommercialInvoiceEnableProperty(int id)
        {
            if (IsFinalCommercialInv)
            {
                IsFinishedVisible = "Visible";
            }
            else
            {
                IsFinishedVisible = "Collapsed";
            }
            if (id <= 0)
            {
                IsAmountEnable = true;
                IsDeliveryAddEnable = true;
                IsExchangeRateEnable = true;
                IsIncludeInterestEnable = true;
                IsLCAddEnable = true;
                IsPaymentMeansEnable = true;
                IsPriceEnable = true;
                IsQuotaEnable = true;
                IsSettlementCurrencyEnable = true;
                IsLCDeleteEnable = true;
                IsDeliveryDeleteEnable = true;
            }
            else
            {
                using (var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
                {
                    PCommercialInvoiceEnableProperty pciep = commercialInvoiceService.SetElementsEnableProperty(id);
                    IsAmountEnable = pciep.IsAmountEnable;
                    IsDeliveryAddEnable = pciep.IsDeliveryAddEnable;
                    IsExchangeRateEnable = pciep.IsExchangeRateEnable;
                    IsIncludeInterestEnable = pciep.IsIncludeInterestEnable;
                    IsLCAddEnable = pciep.IsLCAddEnable;
                    IsPaymentMeansEnable = pciep.IsPaymentMeansEnable;
                    IsPriceEnable = pciep.IsPriceEnable;
                    IsQuotaEnable = pciep.IsQuotaEnable;
                    IsSettlementCurrencyEnable = pciep.IsSettlementCurrencyEnable;
                    IsLCDeleteEnable = pciep.IsLCAddEnable;
                    IsDeliveryDeleteEnable = pciep.IsDeliveryAddEnable;
                }
            }
        }

        #endregion

        public void GetDeliveryByQuota(int quotaId)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                string query = "it.CommercialInvoiceId is null and it.IsDraft = false and (it.WarrantId is null or (it.WarrantId is not null and it.DeliveryType == " + (int)DeliveryType.ExternalTDBOL + ")) and it.QuotaId =" + quotaId;
                List<string> eagerLoadList = new List<string> { "DeliveryLines.CommodityType", "DeliveryLines.CommodityType.Commodity", "DeliveryLines.Brand", "Quota", "Quota.Contract", "Quota.Contract.BusinessPartner", "DeliveryLines", "Quota.Brand" };
                List<Delivery> list = deliveryService.Select(query, null, eagerLoadList);
                if (list.Count > 0)
                {
                    foreach (var d in list)
                    {
                        AppendDeliveries(d);
                    }
                }
            }
        }

    }
    public class BankAccountClass
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
    }
}