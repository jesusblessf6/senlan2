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
    [KnownType(typeof(Brand))]
    [KnownType(typeof(BusinessPartner))]
    [KnownType(typeof(Commodity))]
    [KnownType(typeof(CommodityType))]
    [KnownType(typeof(Specification))]
    [KnownType(typeof(Warehouse))]
    public partial class Inventory: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int CommodityTypeId
        {
            get { return _commodityTypeId; }
            set
            {
                if (_commodityTypeId != value)
                {
                    ChangeTracker.RecordOriginalValue("CommodityTypeId", _commodityTypeId);
                    if (!IsDeserializing)
                    {
                        if (CommodityType != null && CommodityType.Id != value)
                        {
                            CommodityType = null;
                        }
                    }
                    _commodityTypeId = value;
                    OnPropertyChanged("CommodityTypeId");
                }
            }
        }
        private int _commodityTypeId;
    
        [DataMember]
        public int BrandId
        {
            get { return _brandId; }
            set
            {
                if (_brandId != value)
                {
                    ChangeTracker.RecordOriginalValue("BrandId", _brandId);
                    if (!IsDeserializing)
                    {
                        if (Brand != null && Brand.Id != value)
                        {
                            Brand = null;
                        }
                    }
                    _brandId = value;
                    OnPropertyChanged("BrandId");
                }
            }
        }
        private int _brandId;
    
        [DataMember]
        public Nullable<int> SpecificationId
        {
            get { return _specificationId; }
            set
            {
                if (_specificationId != value)
                {
                    ChangeTracker.RecordOriginalValue("SpecificationId", _specificationId);
                    if (!IsDeserializing)
                    {
                        if (Specification != null && Specification.Id != value)
                        {
                            Specification = null;
                        }
                    }
                    _specificationId = value;
                    OnPropertyChanged("SpecificationId");
                }
            }
        }
        private Nullable<int> _specificationId;
    
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
        public Nullable<decimal> Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        private Nullable<decimal> _quantity;
    
        [DataMember]
        public int OwnerPartyId
        {
            get { return _ownerPartyId; }
            set
            {
                if (_ownerPartyId != value)
                {
                    ChangeTracker.RecordOriginalValue("OwnerPartyId", _ownerPartyId);
                    if (!IsDeserializing)
                    {
                        if (BusinessPartner != null && BusinessPartner.Id != value)
                        {
                            BusinessPartner = null;
                        }
                    }
                    _ownerPartyId = value;
                    OnPropertyChanged("OwnerPartyId");
                }
            }
        }
        private int _ownerPartyId;
    
        [DataMember]
        public Nullable<int> WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                if (_warehouseId != value)
                {
                    ChangeTracker.RecordOriginalValue("WarehouseId", _warehouseId);
                    if (!IsDeserializing)
                    {
                        if (Warehouse != null && Warehouse.Id != value)
                        {
                            Warehouse = null;
                        }
                    }
                    _warehouseId = value;
                    OnPropertyChanged("WarehouseId");
                }
            }
        }
        private Nullable<int> _warehouseId;
    
        [DataMember]
        public string PBNo
        {
            get { return _pBNo; }
            set
            {
                if (_pBNo != value)
                {
                    _pBNo = value;
                    OnPropertyChanged("PBNo");
                }
            }
        }
        private string _pBNo;
    
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
        public bool IsWarehouseWarranty
        {
            get { return _isWarehouseWarranty; }
            set
            {
                if (_isWarehouseWarranty != value)
                {
                    _isWarehouseWarranty = value;
                    OnPropertyChanged("IsWarehouseWarranty");
                }
            }
        }
        private bool _isWarehouseWarranty;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Brand Brand
        {
            get { return _brand; }
            set
            {
                if (!ReferenceEquals(_brand, value))
                {
                    var previousValue = _brand;
                    _brand = value;
                    FixupBrand(previousValue);
                    OnNavigationPropertyChanged("Brand");
                }
            }
        }
        private Brand _brand;
    
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
        public CommodityType CommodityType
        {
            get { return _commodityType; }
            set
            {
                if (!ReferenceEquals(_commodityType, value))
                {
                    var previousValue = _commodityType;
                    _commodityType = value;
                    FixupCommodityType(previousValue);
                    OnNavigationPropertyChanged("CommodityType");
                }
            }
        }
        private CommodityType _commodityType;
    
        [DataMember]
        public Specification Specification
        {
            get { return _specification; }
            set
            {
                if (!ReferenceEquals(_specification, value))
                {
                    var previousValue = _specification;
                    _specification = value;
                    FixupSpecification(previousValue);
                    OnNavigationPropertyChanged("Specification");
                }
            }
        }
        private Specification _specification;
    
        [DataMember]
        public Warehouse Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (!ReferenceEquals(_warehouse, value))
                {
                    var previousValue = _warehouse;
                    _warehouse = value;
                    FixupWarehouse(previousValue);
                    OnNavigationPropertyChanged("Warehouse");
                }
            }
        }
        private Warehouse _warehouse;

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
            Brand = null;
            BusinessPartner = null;
            Commodity = null;
            CommodityType = null;
            Specification = null;
            Warehouse = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupBrand(Brand previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (Brand != null)
            {
                if (!Brand.Inventories.Contains(this))
                {
                    Brand.Inventories.Add(this);
                }
    
                BrandId = Brand.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Brand")
                    && (ChangeTracker.OriginalValues["Brand"] == Brand))
                {
                    ChangeTracker.OriginalValues.Remove("Brand");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Brand", previousValue);
                }
                if (Brand != null && !Brand.ChangeTracker.ChangeTrackingEnabled)
                {
                    Brand.StartTracking();
                }
            }
        }
    
        private void FixupBusinessPartner(BusinessPartner previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (BusinessPartner != null)
            {
                if (!BusinessPartner.Inventories.Contains(this))
                {
                    BusinessPartner.Inventories.Add(this);
                }
    
                OwnerPartyId = BusinessPartner.Id;
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
    
        private void FixupCommodity(Commodity previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (Commodity != null)
            {
                if (!Commodity.Inventories.Contains(this))
                {
                    Commodity.Inventories.Add(this);
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
    
        private void FixupCommodityType(CommodityType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (CommodityType != null)
            {
                if (!CommodityType.Inventories.Contains(this))
                {
                    CommodityType.Inventories.Add(this);
                }
    
                CommodityTypeId = CommodityType.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CommodityType")
                    && (ChangeTracker.OriginalValues["CommodityType"] == CommodityType))
                {
                    ChangeTracker.OriginalValues.Remove("CommodityType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CommodityType", previousValue);
                }
                if (CommodityType != null && !CommodityType.ChangeTracker.ChangeTrackingEnabled)
                {
                    CommodityType.StartTracking();
                }
            }
        }
    
        private void FixupSpecification(Specification previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (Specification != null)
            {
                if (!Specification.Inventories.Contains(this))
                {
                    Specification.Inventories.Add(this);
                }
    
                SpecificationId = Specification.Id;
            }
            else if (!skipKeys)
            {
                SpecificationId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Specification")
                    && (ChangeTracker.OriginalValues["Specification"] == Specification))
                {
                    ChangeTracker.OriginalValues.Remove("Specification");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Specification", previousValue);
                }
                if (Specification != null && !Specification.ChangeTracker.ChangeTrackingEnabled)
                {
                    Specification.StartTracking();
                }
            }
        }
    
        private void FixupWarehouse(Warehouse previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Inventories.Contains(this))
            {
                previousValue.Inventories.Remove(this);
            }
    
            if (Warehouse != null)
            {
                if (!Warehouse.Inventories.Contains(this))
                {
                    Warehouse.Inventories.Add(this);
                }
    
                WarehouseId = Warehouse.Id;
            }
            else if (!skipKeys)
            {
                WarehouseId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Warehouse")
                    && (ChangeTracker.OriginalValues["Warehouse"] == Warehouse))
                {
                    ChangeTracker.OriginalValues.Remove("Warehouse");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Warehouse", previousValue);
                }
                if (Warehouse != null && !Warehouse.ChangeTracker.ChangeTrackingEnabled)
                {
                    Warehouse.StartTracking();
                }
            }
        }

        #endregion

    }
}
