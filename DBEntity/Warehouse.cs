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
    [KnownType(typeof(Quota))]
    [KnownType(typeof(Delivery))]
    [KnownType(typeof(Inventory))]
    [KnownType(typeof(WarehouseOut))]
    [KnownType(typeof(WarehouseIn))]
    [KnownType(typeof(QuotaBrandRel))]
    [KnownType(typeof(Currency))]
    [KnownType(typeof(ForeignDeliveryPool))]
    [KnownType(typeof(StorageFeeRule))]
    public partial class Warehouse: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
        private string _fullName;
    
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
        private bool _isDeleted;
    
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
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        private string _address;
    
        [DataMember]
        public string ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                if (_contactPerson != value)
                {
                    _contactPerson = value;
                    OnPropertyChanged("ContactPerson");
                }
            }
        }
        private string _contactPerson;
    
        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        private string _phone;
    
        [DataMember]
        public string Fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    _fax = value;
                    OnPropertyChanged("Fax");
                }
            }
        }
        private string _fax;
    
        [DataMember]
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                if (_postCode != value)
                {
                    _postCode = value;
                    OnPropertyChanged("PostCode");
                }
            }
        }
        private string _postCode;
    
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Quota> Quotas
        {
            get
            {
                if (_quotas == null)
                {
                    _quotas = new TrackableCollection<Quota>();
                    _quotas.CollectionChanged += FixupQuotas;
                }
                return _quotas;
            }
            set
            {
                if (!ReferenceEquals(_quotas, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_quotas != null)
                    {
                        _quotas.CollectionChanged -= FixupQuotas;
                    }
                    _quotas = value;
                    if (_quotas != null)
                    {
                        _quotas.CollectionChanged += FixupQuotas;
                    }
                    OnNavigationPropertyChanged("Quotas");
                }
            }
        }
        private TrackableCollection<Quota> _quotas;
    
        [DataMember]
        public TrackableCollection<Delivery> Deliveries
        {
            get
            {
                if (_deliveries == null)
                {
                    _deliveries = new TrackableCollection<Delivery>();
                    _deliveries.CollectionChanged += FixupDeliveries;
                }
                return _deliveries;
            }
            set
            {
                if (!ReferenceEquals(_deliveries, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_deliveries != null)
                    {
                        _deliveries.CollectionChanged -= FixupDeliveries;
                    }
                    _deliveries = value;
                    if (_deliveries != null)
                    {
                        _deliveries.CollectionChanged += FixupDeliveries;
                    }
                    OnNavigationPropertyChanged("Deliveries");
                }
            }
        }
        private TrackableCollection<Delivery> _deliveries;
    
        [DataMember]
        public TrackableCollection<Inventory> Inventories
        {
            get
            {
                if (_inventories == null)
                {
                    _inventories = new TrackableCollection<Inventory>();
                    _inventories.CollectionChanged += FixupInventories;
                }
                return _inventories;
            }
            set
            {
                if (!ReferenceEquals(_inventories, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_inventories != null)
                    {
                        _inventories.CollectionChanged -= FixupInventories;
                    }
                    _inventories = value;
                    if (_inventories != null)
                    {
                        _inventories.CollectionChanged += FixupInventories;
                    }
                    OnNavigationPropertyChanged("Inventories");
                }
            }
        }
        private TrackableCollection<Inventory> _inventories;
    
        [DataMember]
        public TrackableCollection<WarehouseOut> WarehouseOuts
        {
            get
            {
                if (_warehouseOuts == null)
                {
                    _warehouseOuts = new TrackableCollection<WarehouseOut>();
                    _warehouseOuts.CollectionChanged += FixupWarehouseOuts;
                }
                return _warehouseOuts;
            }
            set
            {
                if (!ReferenceEquals(_warehouseOuts, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_warehouseOuts != null)
                    {
                        _warehouseOuts.CollectionChanged -= FixupWarehouseOuts;
                    }
                    _warehouseOuts = value;
                    if (_warehouseOuts != null)
                    {
                        _warehouseOuts.CollectionChanged += FixupWarehouseOuts;
                    }
                    OnNavigationPropertyChanged("WarehouseOuts");
                }
            }
        }
        private TrackableCollection<WarehouseOut> _warehouseOuts;
    
        [DataMember]
        public TrackableCollection<WarehouseIn> WarehouseIns
        {
            get
            {
                if (_warehouseIns == null)
                {
                    _warehouseIns = new TrackableCollection<WarehouseIn>();
                    _warehouseIns.CollectionChanged += FixupWarehouseIns;
                }
                return _warehouseIns;
            }
            set
            {
                if (!ReferenceEquals(_warehouseIns, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_warehouseIns != null)
                    {
                        _warehouseIns.CollectionChanged -= FixupWarehouseIns;
                    }
                    _warehouseIns = value;
                    if (_warehouseIns != null)
                    {
                        _warehouseIns.CollectionChanged += FixupWarehouseIns;
                    }
                    OnNavigationPropertyChanged("WarehouseIns");
                }
            }
        }
        private TrackableCollection<WarehouseIn> _warehouseIns;
    
        [DataMember]
        public TrackableCollection<QuotaBrandRel> QuotaBrandRels
        {
            get
            {
                if (_quotaBrandRels == null)
                {
                    _quotaBrandRels = new TrackableCollection<QuotaBrandRel>();
                    _quotaBrandRels.CollectionChanged += FixupQuotaBrandRels;
                }
                return _quotaBrandRels;
            }
            set
            {
                if (!ReferenceEquals(_quotaBrandRels, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_quotaBrandRels != null)
                    {
                        _quotaBrandRels.CollectionChanged -= FixupQuotaBrandRels;
                    }
                    _quotaBrandRels = value;
                    if (_quotaBrandRels != null)
                    {
                        _quotaBrandRels.CollectionChanged += FixupQuotaBrandRels;
                    }
                    OnNavigationPropertyChanged("QuotaBrandRels");
                }
            }
        }
        private TrackableCollection<QuotaBrandRel> _quotaBrandRels;
    
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
        public TrackableCollection<ForeignDeliveryPool> ForeignDeliveryPools
        {
            get
            {
                if (_foreignDeliveryPools == null)
                {
                    _foreignDeliveryPools = new TrackableCollection<ForeignDeliveryPool>();
                    _foreignDeliveryPools.CollectionChanged += FixupForeignDeliveryPools;
                }
                return _foreignDeliveryPools;
            }
            set
            {
                if (!ReferenceEquals(_foreignDeliveryPools, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_foreignDeliveryPools != null)
                    {
                        _foreignDeliveryPools.CollectionChanged -= FixupForeignDeliveryPools;
                    }
                    _foreignDeliveryPools = value;
                    if (_foreignDeliveryPools != null)
                    {
                        _foreignDeliveryPools.CollectionChanged += FixupForeignDeliveryPools;
                    }
                    OnNavigationPropertyChanged("ForeignDeliveryPools");
                }
            }
        }
        private TrackableCollection<ForeignDeliveryPool> _foreignDeliveryPools;
    
        [DataMember]
        public TrackableCollection<StorageFeeRule> StorageFeeRules
        {
            get
            {
                if (_storageFeeRules == null)
                {
                    _storageFeeRules = new TrackableCollection<StorageFeeRule>();
                    _storageFeeRules.CollectionChanged += FixupStorageFeeRules;
                }
                return _storageFeeRules;
            }
            set
            {
                if (!ReferenceEquals(_storageFeeRules, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_storageFeeRules != null)
                    {
                        _storageFeeRules.CollectionChanged -= FixupStorageFeeRules;
                    }
                    _storageFeeRules = value;
                    if (_storageFeeRules != null)
                    {
                        _storageFeeRules.CollectionChanged += FixupStorageFeeRules;
                    }
                    OnNavigationPropertyChanged("StorageFeeRules");
                }
            }
        }
        private TrackableCollection<StorageFeeRule> _storageFeeRules;

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
            Quotas.Clear();
            Deliveries.Clear();
            Inventories.Clear();
            WarehouseOuts.Clear();
            WarehouseIns.Clear();
            QuotaBrandRels.Clear();
            Currency = null;
            ForeignDeliveryPools.Clear();
            StorageFeeRules.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCurrency(Currency previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Warehouses.Contains(this))
            {
                previousValue.Warehouses.Remove(this);
            }
    
            if (Currency != null)
            {
                if (!Currency.Warehouses.Contains(this))
                {
                    Currency.Warehouses.Add(this);
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
    
        private void FixupQuotas(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Quota item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Quotas", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Quota item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Quotas", item);
                    }
                }
            }
        }
    
        private void FixupDeliveries(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Delivery item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Deliveries", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Delivery item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Deliveries", item);
                    }
                }
            }
        }
    
        private void FixupInventories(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Inventory item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Inventories", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Inventory item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Inventories", item);
                    }
                }
            }
        }
    
        private void FixupWarehouseOuts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (WarehouseOut item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("WarehouseOuts", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarehouseOut item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("WarehouseOuts", item);
                    }
                }
            }
        }
    
        private void FixupWarehouseIns(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (WarehouseIn item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("WarehouseIns", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarehouseIn item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("WarehouseIns", item);
                    }
                }
            }
        }
    
        private void FixupQuotaBrandRels(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (QuotaBrandRel item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("QuotaBrandRels", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (QuotaBrandRel item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("QuotaBrandRels", item);
                    }
                }
            }
        }
    
        private void FixupForeignDeliveryPools(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ForeignDeliveryPool item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ForeignDeliveryPools", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ForeignDeliveryPool item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ForeignDeliveryPools", item);
                    }
                }
            }
        }
    
        private void FixupStorageFeeRules(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (StorageFeeRule item in e.NewItems)
                {
                    item.Warehouse = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("StorageFeeRules", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (StorageFeeRule item in e.OldItems)
                {
                    if (ReferenceEquals(item.Warehouse, this))
                    {
                        item.Warehouse = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("StorageFeeRules", item);
                    }
                }
            }
        }

        #endregion

    }
}
