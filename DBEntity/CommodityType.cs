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
    [KnownType(typeof(Commodity))]
    [KnownType(typeof(Specification))]
    [KnownType(typeof(Brand))]
    [KnownType(typeof(Quota))]
    [KnownType(typeof(Inventory))]
    [KnownType(typeof(WarehouseInLine))]
    [KnownType(typeof(WarehouseOutLine))]
    [KnownType(typeof(DeliveryLine))]
    [KnownType(typeof(ForeignDeliveryPoolLine))]
    public partial class CommodityType: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        private bool _isDeleted;
    
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
        public int CommodityId
        {
            get { return _commodityId; }
            set
            {
                if (_commodityId != value)
                {
                    ChangeTracker.RecordOriginalValue("CommodityId", _commodityId);
                    if (!IsDeserializing)
                    {
                        if (Commodity != null && Commodity.Id != value)
                        {
                            Commodity = null;
                        }
                    }
                    _commodityId = value;
                    OnPropertyChanged("CommodityId");
                }
            }
        }
        private int _commodityId;
    
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
        public bool IsSystem
        {
            get { return _isSystem; }
            set
            {
                if (_isSystem != value)
                {
                    _isSystem = value;
                    OnPropertyChanged("IsSystem");
                }
            }
        }
        private bool _isSystem;
    
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
        public string EnglishName
        {
            get { return _englishName; }
            set
            {
                if (_englishName != value)
                {
                    _englishName = value;
                    OnPropertyChanged("EnglishName");
                }
            }
        }
        private string _englishName;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Commodity Commodity
        {
            get { return _commodity; }
            set
            {
                if (!ReferenceEquals(_commodity, value))
                {
                    var previousValue = _commodity;
                    _commodity = value;
                    FixupCommodity(previousValue);
                    OnNavigationPropertyChanged("Commodity");
                }
            }
        }
        private Commodity _commodity;
    
        [DataMember]
        public TrackableCollection<Specification> Specifications
        {
            get
            {
                if (_specifications == null)
                {
                    _specifications = new TrackableCollection<Specification>();
                    _specifications.CollectionChanged += FixupSpecifications;
                }
                return _specifications;
            }
            set
            {
                if (!ReferenceEquals(_specifications, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_specifications != null)
                    {
                        _specifications.CollectionChanged -= FixupSpecifications;
                    }
                    _specifications = value;
                    if (_specifications != null)
                    {
                        _specifications.CollectionChanged += FixupSpecifications;
                    }
                    OnNavigationPropertyChanged("Specifications");
                }
            }
        }
        private TrackableCollection<Specification> _specifications;
    
        [DataMember]
        public TrackableCollection<Brand> Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new TrackableCollection<Brand>();
                    _brands.CollectionChanged += FixupBrands;
                }
                return _brands;
            }
            set
            {
                if (!ReferenceEquals(_brands, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_brands != null)
                    {
                        _brands.CollectionChanged -= FixupBrands;
                    }
                    _brands = value;
                    if (_brands != null)
                    {
                        _brands.CollectionChanged += FixupBrands;
                    }
                    OnNavigationPropertyChanged("Brands");
                }
            }
        }
        private TrackableCollection<Brand> _brands;
    
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
        public TrackableCollection<WarehouseInLine> WarehouseInLines
        {
            get
            {
                if (_warehouseInLines == null)
                {
                    _warehouseInLines = new TrackableCollection<WarehouseInLine>();
                    _warehouseInLines.CollectionChanged += FixupWarehouseInLines;
                }
                return _warehouseInLines;
            }
            set
            {
                if (!ReferenceEquals(_warehouseInLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_warehouseInLines != null)
                    {
                        _warehouseInLines.CollectionChanged -= FixupWarehouseInLines;
                    }
                    _warehouseInLines = value;
                    if (_warehouseInLines != null)
                    {
                        _warehouseInLines.CollectionChanged += FixupWarehouseInLines;
                    }
                    OnNavigationPropertyChanged("WarehouseInLines");
                }
            }
        }
        private TrackableCollection<WarehouseInLine> _warehouseInLines;
    
        [DataMember]
        public TrackableCollection<WarehouseOutLine> WarehouseOutLines
        {
            get
            {
                if (_warehouseOutLines == null)
                {
                    _warehouseOutLines = new TrackableCollection<WarehouseOutLine>();
                    _warehouseOutLines.CollectionChanged += FixupWarehouseOutLines;
                }
                return _warehouseOutLines;
            }
            set
            {
                if (!ReferenceEquals(_warehouseOutLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_warehouseOutLines != null)
                    {
                        _warehouseOutLines.CollectionChanged -= FixupWarehouseOutLines;
                    }
                    _warehouseOutLines = value;
                    if (_warehouseOutLines != null)
                    {
                        _warehouseOutLines.CollectionChanged += FixupWarehouseOutLines;
                    }
                    OnNavigationPropertyChanged("WarehouseOutLines");
                }
            }
        }
        private TrackableCollection<WarehouseOutLine> _warehouseOutLines;
    
        [DataMember]
        public TrackableCollection<DeliveryLine> DeliveryLines
        {
            get
            {
                if (_deliveryLines == null)
                {
                    _deliveryLines = new TrackableCollection<DeliveryLine>();
                    _deliveryLines.CollectionChanged += FixupDeliveryLines;
                }
                return _deliveryLines;
            }
            set
            {
                if (!ReferenceEquals(_deliveryLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_deliveryLines != null)
                    {
                        _deliveryLines.CollectionChanged -= FixupDeliveryLines;
                    }
                    _deliveryLines = value;
                    if (_deliveryLines != null)
                    {
                        _deliveryLines.CollectionChanged += FixupDeliveryLines;
                    }
                    OnNavigationPropertyChanged("DeliveryLines");
                }
            }
        }
        private TrackableCollection<DeliveryLine> _deliveryLines;
    
        [DataMember]
        public TrackableCollection<ForeignDeliveryPoolLine> ForeignDeliveryPoolLines
        {
            get
            {
                if (_foreignDeliveryPoolLines == null)
                {
                    _foreignDeliveryPoolLines = new TrackableCollection<ForeignDeliveryPoolLine>();
                    _foreignDeliveryPoolLines.CollectionChanged += FixupForeignDeliveryPoolLines;
                }
                return _foreignDeliveryPoolLines;
            }
            set
            {
                if (!ReferenceEquals(_foreignDeliveryPoolLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_foreignDeliveryPoolLines != null)
                    {
                        _foreignDeliveryPoolLines.CollectionChanged -= FixupForeignDeliveryPoolLines;
                    }
                    _foreignDeliveryPoolLines = value;
                    if (_foreignDeliveryPoolLines != null)
                    {
                        _foreignDeliveryPoolLines.CollectionChanged += FixupForeignDeliveryPoolLines;
                    }
                    OnNavigationPropertyChanged("ForeignDeliveryPoolLines");
                }
            }
        }
        private TrackableCollection<ForeignDeliveryPoolLine> _foreignDeliveryPoolLines;

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
            Commodity = null;
            Specifications.Clear();
            Brands.Clear();
            Quotas.Clear();
            Inventories.Clear();
            WarehouseInLines.Clear();
            WarehouseOutLines.Clear();
            DeliveryLines.Clear();
            ForeignDeliveryPoolLines.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCommodity(Commodity previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CommodityTypes.Contains(this))
            {
                previousValue.CommodityTypes.Remove(this);
            }
    
            if (Commodity != null)
            {
                if (!Commodity.CommodityTypes.Contains(this))
                {
                    Commodity.CommodityTypes.Add(this);
                }
    
                CommodityId = Commodity.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Commodity")
                    && (ChangeTracker.OriginalValues["Commodity"] == Commodity))
                {
                    ChangeTracker.OriginalValues.Remove("Commodity");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Commodity", previousValue);
                }
                if (Commodity != null && !Commodity.ChangeTracker.ChangeTrackingEnabled)
                {
                    Commodity.StartTracking();
                }
            }
        }
    
        private void FixupSpecifications(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Specification item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Specifications", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Specification item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Specifications", item);
                    }
                }
            }
        }
    
        private void FixupBrands(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Brand item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Brands", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Brand item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Brands", item);
                    }
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
                    item.CommodityType = this;
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
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Quotas", item);
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
                    item.CommodityType = this;
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
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Inventories", item);
                    }
                }
            }
        }
    
        private void FixupWarehouseInLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (WarehouseInLine item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("WarehouseInLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarehouseInLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("WarehouseInLines", item);
                    }
                }
            }
        }
    
        private void FixupWarehouseOutLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (WarehouseOutLine item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("WarehouseOutLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarehouseOutLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("WarehouseOutLines", item);
                    }
                }
            }
        }
    
        private void FixupDeliveryLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DeliveryLine item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("DeliveryLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DeliveryLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("DeliveryLines", item);
                    }
                }
            }
        }
    
        private void FixupForeignDeliveryPoolLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ForeignDeliveryPoolLine item in e.NewItems)
                {
                    item.CommodityType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ForeignDeliveryPoolLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ForeignDeliveryPoolLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.CommodityType, this))
                    {
                        item.CommodityType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ForeignDeliveryPoolLines", item);
                    }
                }
            }
        }

        #endregion

    }
}
