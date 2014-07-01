//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;


namespace DBEntity
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Bank))]
    [KnownType(typeof(BusinessPartner))]
    [KnownType(typeof(Currency))]
    [KnownType(typeof(FundFlow))]
    [KnownType(typeof(PaymentRequest))]
    [KnownType(typeof(CommercialInvoice))]
    [KnownType(typeof(Contract))]
    public partial class BankAccount: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public int BankId
        {
            get { return _bankId; }
            set
            {
                if (_bankId != value)
                {
                    ChangeTracker.RecordOriginalValue("BankId", _bankId);
                    if (!IsDeserializing)
                    {
                        if (Bank != null && Bank.Id != value)
                        {
                            Bank = null;
                        }
                    }
                    _bankId = value;
                    OnPropertyChanged("BankId");
                }
            }
        }
        private int _bankId;
    
        [DataMember]
        public byte[] Ver
        {
            get { return _ver; }
            set
            {
                if (_ver != value)
                {
                    _ver = value;
                    OnPropertyChanged("Ver");
                }
            }
        }
        private byte[] _ver;
    
        [DataMember]
        public string AccountCode
        {
            get { return _accountCode; }
            set
            {
                if (_accountCode != value)
                {
                    _accountCode = value;
                    OnPropertyChanged("AccountCode");
                }
            }
        }
        private string _accountCode;
    
        [DataMember]
        public Nullable<int> Usage
        {
            get { return _usage; }
            set
            {
                if (_usage != value)
                {
                    _usage = value;
                    OnPropertyChanged("Usage");
                }
            }
        }
        private Nullable<int> _usage;
    
        [DataMember]
        public Nullable<System.DateTime> Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    OnPropertyChanged("Created");
                }
            }
        }
        private Nullable<System.DateTime> _created;
    
        [DataMember]
        public Nullable<System.DateTime> Updated
        {
            get { return _updated; }
            set
            {
                if (_updated != value)
                {
                    _updated = value;
                    OnPropertyChanged("Updated");
                }
            }
        }
        private Nullable<System.DateTime> _updated;
    
        [DataMember]
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    OnPropertyChanged("IsDeleted");
                }
            }
        }
        private bool _isDeleted = false;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<int> BusinessPartnerId
        {
            get { return _businessPartnerId; }
            set
            {
                if (_businessPartnerId != value)
                {
                    ChangeTracker.RecordOriginalValue("BusinessPartnerId", _businessPartnerId);
                    if (!IsDeserializing)
                    {
                        if (BusinessPartner != null && BusinessPartner.Id != value)
                        {
                            BusinessPartner = null;
                        }
                    }
                    _businessPartnerId = value;
                    OnPropertyChanged("BusinessPartnerId");
                }
            }
        }
        private Nullable<int> _businessPartnerId;
    
        [DataMember]
        public Nullable<int> CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    _createdBy = value;
                    OnPropertyChanged("CreatedBy");
                }
            }
        }
        private Nullable<int> _createdBy;
    
        [DataMember]
        public Nullable<int> UpdatedBy
        {
            get { return _updatedBy; }
            set
            {
                if (_updatedBy != value)
                {
                    _updatedBy = value;
                    OnPropertyChanged("UpdatedBy");
                }
            }
        }
        private Nullable<int> _updatedBy;
    
        [DataMember]
        public Nullable<int> CurrencyId
        {
            get { return _currencyId; }
            set
            {
                if (_currencyId != value)
                {
                    ChangeTracker.RecordOriginalValue("CurrencyId", _currencyId);
                    if (!IsDeserializing)
                    {
                        if (Currency != null && Currency.Id != value)
                        {
                            Currency = null;
                        }
                    }
                    _currencyId = value;
                    OnPropertyChanged("CurrencyId");
                }
            }
        }
        private Nullable<int> _currencyId;
    
        [DataMember]
        public Nullable<bool> IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    OnPropertyChanged("IsDefault");
                }
            }
        }
        private Nullable<bool> _isDefault;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Bank Bank
        {
            get { return _bank; }
            set
            {
                if (!ReferenceEquals(_bank, value))
                {
                    var previousValue = _bank;
                    _bank = value;
                    FixupBank(previousValue);
                    OnNavigationPropertyChanged("Bank");
                }
            }
        }
        private Bank _bank;
    
        [DataMember]
        public BusinessPartner BusinessPartner
        {
            get { return _businessPartner; }
            set
            {
                if (!ReferenceEquals(_businessPartner, value))
                {
                    var previousValue = _businessPartner;
                    _businessPartner = value;
                    FixupBusinessPartner(previousValue);
                    OnNavigationPropertyChanged("BusinessPartner");
                }
            }
        }
        private BusinessPartner _businessPartner;
    
        [DataMember]
        public Currency Currency
        {
            get { return _currency; }
            set
            {
                if (!ReferenceEquals(_currency, value))
                {
                    var previousValue = _currency;
                    _currency = value;
                    FixupCurrency(previousValue);
                    OnNavigationPropertyChanged("Currency");
                }
            }
        }
        private Currency _currency;
    
        [DataMember]
        public TrackableCollection<FundFlow> FundFlows
        {
            get
            {
                if (_fundFlows == null)
                {
                    _fundFlows = new TrackableCollection<FundFlow>();
                    _fundFlows.CollectionChanged += FixupFundFlows;
                }
                return _fundFlows;
            }
            set
            {
                if (!ReferenceEquals(_fundFlows, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fundFlows != null)
                    {
                        _fundFlows.CollectionChanged -= FixupFundFlows;
                    }
                    _fundFlows = value;
                    if (_fundFlows != null)
                    {
                        _fundFlows.CollectionChanged += FixupFundFlows;
                    }
                    OnNavigationPropertyChanged("FundFlows");
                }
            }
        }
        private TrackableCollection<FundFlow> _fundFlows;
    
        [DataMember]
        public TrackableCollection<PaymentRequest> PayPaymentRequests
        {
            get
            {
                if (_payPaymentRequests == null)
                {
                    _payPaymentRequests = new TrackableCollection<PaymentRequest>();
                    _payPaymentRequests.CollectionChanged += FixupPayPaymentRequests;
                }
                return _payPaymentRequests;
            }
            set
            {
                if (!ReferenceEquals(_payPaymentRequests, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_payPaymentRequests != null)
                    {
                        _payPaymentRequests.CollectionChanged -= FixupPayPaymentRequests;
                    }
                    _payPaymentRequests = value;
                    if (_payPaymentRequests != null)
                    {
                        _payPaymentRequests.CollectionChanged += FixupPayPaymentRequests;
                    }
                    OnNavigationPropertyChanged("PayPaymentRequests");
                }
            }
        }
        private TrackableCollection<PaymentRequest> _payPaymentRequests;
    
        [DataMember]
        public TrackableCollection<PaymentRequest> ReceivePaymentRequests
        {
            get
            {
                if (_receivePaymentRequests == null)
                {
                    _receivePaymentRequests = new TrackableCollection<PaymentRequest>();
                    _receivePaymentRequests.CollectionChanged += FixupReceivePaymentRequests;
                }
                return _receivePaymentRequests;
            }
            set
            {
                if (!ReferenceEquals(_receivePaymentRequests, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_receivePaymentRequests != null)
                    {
                        _receivePaymentRequests.CollectionChanged -= FixupReceivePaymentRequests;
                    }
                    _receivePaymentRequests = value;
                    if (_receivePaymentRequests != null)
                    {
                        _receivePaymentRequests.CollectionChanged += FixupReceivePaymentRequests;
                    }
                    OnNavigationPropertyChanged("ReceivePaymentRequests");
                }
            }
        }
        private TrackableCollection<PaymentRequest> _receivePaymentRequests;
    
        [DataMember]
        public TrackableCollection<CommercialInvoice> CommercialInvoices
        {
            get
            {
                if (_commercialInvoices == null)
                {
                    _commercialInvoices = new TrackableCollection<CommercialInvoice>();
                    _commercialInvoices.CollectionChanged += FixupCommercialInvoices;
                }
                return _commercialInvoices;
            }
            set
            {
                if (!ReferenceEquals(_commercialInvoices, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_commercialInvoices != null)
                    {
                        _commercialInvoices.CollectionChanged -= FixupCommercialInvoices;
                    }
                    _commercialInvoices = value;
                    if (_commercialInvoices != null)
                    {
                        _commercialInvoices.CollectionChanged += FixupCommercialInvoices;
                    }
                    OnNavigationPropertyChanged("CommercialInvoices");
                }
            }
        }
        private TrackableCollection<CommercialInvoice> _commercialInvoices;
    
        [DataMember]
        public TrackableCollection<Contract> Contracts
        {
            get
            {
                if (_contracts == null)
                {
                    _contracts = new TrackableCollection<Contract>();
                    _contracts.CollectionChanged += FixupContracts;
                }
                return _contracts;
            }
            set
            {
                if (!ReferenceEquals(_contracts, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_contracts != null)
                    {
                        _contracts.CollectionChanged -= FixupContracts;
                    }
                    _contracts = value;
                    if (_contracts != null)
                    {
                        _contracts.CollectionChanged += FixupContracts;
                    }
                    OnNavigationPropertyChanged("Contracts");
                }
            }
        }
        private TrackableCollection<Contract> _contracts;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    	static ICollection<string> eagerLoadProperties = new List<string>() { };
    	public ICollection<string> EagerLoadProperties
    	{
    		get { return eagerLoadProperties; }
    	}
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Bank = null;
            BusinessPartner = null;
            Currency = null;
            FundFlows.Clear();
            PayPaymentRequests.Clear();
            ReceivePaymentRequests.Clear();
            CommercialInvoices.Clear();
            Contracts.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupBank(Bank previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankAccounts.Contains(this))
            {
                previousValue.BankAccounts.Remove(this);
            }
    
            if (Bank != null)
            {
                if (!Bank.BankAccounts.Contains(this))
                {
                    Bank.BankAccounts.Add(this);
                }
    
                BankId = Bank.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Bank")
                    && (ChangeTracker.OriginalValues["Bank"] == Bank))
                {
                    ChangeTracker.OriginalValues.Remove("Bank");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Bank", previousValue);
                }
                if (Bank != null && !Bank.ChangeTracker.ChangeTrackingEnabled)
                {
                    Bank.StartTracking();
                }
            }
        }
    
        private void FixupBusinessPartner(BusinessPartner previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankAccounts.Contains(this))
            {
                previousValue.BankAccounts.Remove(this);
            }
    
            if (BusinessPartner != null)
            {
                if (!BusinessPartner.BankAccounts.Contains(this))
                {
                    BusinessPartner.BankAccounts.Add(this);
                }
    
                BusinessPartnerId = BusinessPartner.Id;
            }
            else if (!skipKeys)
            {
                BusinessPartnerId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BusinessPartner")
                    && (ChangeTracker.OriginalValues["BusinessPartner"] == BusinessPartner))
                {
                    ChangeTracker.OriginalValues.Remove("BusinessPartner");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BusinessPartner", previousValue);
                }
                if (BusinessPartner != null && !BusinessPartner.ChangeTracker.ChangeTrackingEnabled)
                {
                    BusinessPartner.StartTracking();
                }
            }
        }
    
        private void FixupCurrency(Currency previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankAccounts.Contains(this))
            {
                previousValue.BankAccounts.Remove(this);
            }
    
            if (Currency != null)
            {
                if (!Currency.BankAccounts.Contains(this))
                {
                    Currency.BankAccounts.Add(this);
                }
    
                CurrencyId = Currency.Id;
            }
            else if (!skipKeys)
            {
                CurrencyId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Currency")
                    && (ChangeTracker.OriginalValues["Currency"] == Currency))
                {
                    ChangeTracker.OriginalValues.Remove("Currency");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Currency", previousValue);
                }
                if (Currency != null && !Currency.ChangeTracker.ChangeTrackingEnabled)
                {
                    Currency.StartTracking();
                }
            }
        }
    
        private void FixupFundFlows(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FundFlow item in e.NewItems)
                {
                    item.BankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FundFlows", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FundFlow item in e.OldItems)
                {
                    if (ReferenceEquals(item.BankAccount, this))
                    {
                        item.BankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FundFlows", item);
                    }
                }
            }
        }
    
        private void FixupPayPaymentRequests(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (PaymentRequest item in e.NewItems)
                {
                    item.PayBankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("PayPaymentRequests", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PaymentRequest item in e.OldItems)
                {
                    if (ReferenceEquals(item.PayBankAccount, this))
                    {
                        item.PayBankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("PayPaymentRequests", item);
                    }
                }
            }
        }
    
        private void FixupReceivePaymentRequests(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (PaymentRequest item in e.NewItems)
                {
                    item.ReceiveBankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ReceivePaymentRequests", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PaymentRequest item in e.OldItems)
                {
                    if (ReferenceEquals(item.ReceiveBankAccount, this))
                    {
                        item.ReceiveBankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ReceivePaymentRequests", item);
                    }
                }
            }
        }
    
        private void FixupCommercialInvoices(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CommercialInvoice item in e.NewItems)
                {
                    item.BankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CommercialInvoices", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CommercialInvoice item in e.OldItems)
                {
                    if (ReferenceEquals(item.BankAccount, this))
                    {
                        item.BankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CommercialInvoices", item);
                    }
                }
            }
        }
    
        private void FixupContracts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Contract item in e.NewItems)
                {
                    item.BankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Contracts", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Contract item in e.OldItems)
                {
                    if (ReferenceEquals(item.BankAccount, this))
                    {
                        item.BankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Contracts", item);
                    }
                }
            }
        }

        #endregion

    }
}
