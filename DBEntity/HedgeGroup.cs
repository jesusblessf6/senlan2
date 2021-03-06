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
    [KnownType(typeof(HedgeLineLMEPosition))]
    [KnownType(typeof(HedgeLineQuota))]
    [KnownType(typeof(HedgeLineSHFEPosition))]
    [KnownType(typeof(Currency))]
    [KnownType(typeof(HedgeLineTDPosition))]
    public partial class HedgeGroup: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public Nullable<System.DateTime> HedgeDate
        {
            get { return _hedgeDate; }
            set
            {
                if (_hedgeDate != value)
                {
                    _hedgeDate = value;
                    OnPropertyChanged("HedgeDate");
                }
            }
        }
        private Nullable<System.DateTime> _hedgeDate;
    
        [DataMember]
        public int Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private int _status;
    
        [DataMember]
        public Nullable<decimal> Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    OnPropertyChanged("Rate");
                }
            }
        }
        private Nullable<decimal> _rate;
    
        [DataMember]
        public Nullable<decimal> PLAmount
        {
            get { return _pLAmount; }
            set
            {
                if (_pLAmount != value)
                {
                    _pLAmount = value;
                    OnPropertyChanged("PLAmount");
                }
            }
        }
        private Nullable<decimal> _pLAmount;
    
        [DataMember]
        public Nullable<int> PLCurrencyId
        {
            get { return _pLCurrencyId; }
            set
            {
                if (_pLCurrencyId != value)
                {
                    ChangeTracker.RecordOriginalValue("PLCurrencyId", _pLCurrencyId);
                    if (!IsDeserializing)
                    {
                        if (PLCurrency != null && PLCurrency.Id != value)
                        {
                            PLCurrency = null;
                        }
                    }
                    _pLCurrencyId = value;
                    OnPropertyChanged("PLCurrencyId");
                }
            }
        }
        private Nullable<int> _pLCurrencyId;
    
        [DataMember]
        public int ArbitrageType
        {
            get { return _arbitrageType; }
            set
            {
                if (_arbitrageType != value)
                {
                    _arbitrageType = value;
                    OnPropertyChanged("ArbitrageType");
                }
            }
        }
        private int _arbitrageType;
    
        [DataMember]
        public Nullable<decimal> PhyFixedPL
        {
            get { return _phyFixedPL; }
            set
            {
                if (_phyFixedPL != value)
                {
                    _phyFixedPL = value;
                    OnPropertyChanged("PhyFixedPL");
                }
            }
        }
        private Nullable<decimal> _phyFixedPL;
    
        [DataMember]
        public Nullable<decimal> PhyFloatPL
        {
            get { return _phyFloatPL; }
            set
            {
                if (_phyFloatPL != value)
                {
                    _phyFloatPL = value;
                    OnPropertyChanged("PhyFloatPL");
                }
            }
        }
        private Nullable<decimal> _phyFloatPL;
    
        [DataMember]
        public Nullable<decimal> SHFEFixedPL
        {
            get { return _sHFEFixedPL; }
            set
            {
                if (_sHFEFixedPL != value)
                {
                    _sHFEFixedPL = value;
                    OnPropertyChanged("SHFEFixedPL");
                }
            }
        }
        private Nullable<decimal> _sHFEFixedPL;
    
        [DataMember]
        public Nullable<decimal> SHFEFloatPL
        {
            get { return _sHFEFloatPL; }
            set
            {
                if (_sHFEFloatPL != value)
                {
                    _sHFEFloatPL = value;
                    OnPropertyChanged("SHFEFloatPL");
                }
            }
        }
        private Nullable<decimal> _sHFEFloatPL;
    
        [DataMember]
        public Nullable<decimal> LMEFixedPL
        {
            get { return _lMEFixedPL; }
            set
            {
                if (_lMEFixedPL != value)
                {
                    _lMEFixedPL = value;
                    OnPropertyChanged("LMEFixedPL");
                }
            }
        }
        private Nullable<decimal> _lMEFixedPL;
    
        [DataMember]
        public Nullable<decimal> LMEFloatPL
        {
            get { return _lMEFloatPL; }
            set
            {
                if (_lMEFloatPL != value)
                {
                    _lMEFloatPL = value;
                    OnPropertyChanged("LMEFloatPL");
                }
            }
        }
        private Nullable<decimal> _lMEFloatPL;
    
        [DataMember]
        public Nullable<decimal> StopLossSpread
        {
            get { return _stopLossSpread; }
            set
            {
                if (_stopLossSpread != value)
                {
                    _stopLossSpread = value;
                    OnPropertyChanged("StopLossSpread");
                }
            }
        }
        private Nullable<decimal> _stopLossSpread;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<HedgeLineLMEPosition> HedgeLineLMEPositions
        {
            get
            {
                if (_hedgeLineLMEPositions == null)
                {
                    _hedgeLineLMEPositions = new TrackableCollection<HedgeLineLMEPosition>();
                    _hedgeLineLMEPositions.CollectionChanged += FixupHedgeLineLMEPositions;
                }
                return _hedgeLineLMEPositions;
            }
            set
            {
                if (!ReferenceEquals(_hedgeLineLMEPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hedgeLineLMEPositions != null)
                    {
                        _hedgeLineLMEPositions.CollectionChanged -= FixupHedgeLineLMEPositions;
                    }
                    _hedgeLineLMEPositions = value;
                    if (_hedgeLineLMEPositions != null)
                    {
                        _hedgeLineLMEPositions.CollectionChanged += FixupHedgeLineLMEPositions;
                    }
                    OnNavigationPropertyChanged("HedgeLineLMEPositions");
                }
            }
        }
        private TrackableCollection<HedgeLineLMEPosition> _hedgeLineLMEPositions;
    
        [DataMember]
        public TrackableCollection<HedgeLineQuota> HedgeLineQuotas
        {
            get
            {
                if (_hedgeLineQuotas == null)
                {
                    _hedgeLineQuotas = new TrackableCollection<HedgeLineQuota>();
                    _hedgeLineQuotas.CollectionChanged += FixupHedgeLineQuotas;
                }
                return _hedgeLineQuotas;
            }
            set
            {
                if (!ReferenceEquals(_hedgeLineQuotas, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hedgeLineQuotas != null)
                    {
                        _hedgeLineQuotas.CollectionChanged -= FixupHedgeLineQuotas;
                    }
                    _hedgeLineQuotas = value;
                    if (_hedgeLineQuotas != null)
                    {
                        _hedgeLineQuotas.CollectionChanged += FixupHedgeLineQuotas;
                    }
                    OnNavigationPropertyChanged("HedgeLineQuotas");
                }
            }
        }
        private TrackableCollection<HedgeLineQuota> _hedgeLineQuotas;
    
        [DataMember]
        public TrackableCollection<HedgeLineSHFEPosition> HedgeLineSHFEPositions
        {
            get
            {
                if (_hedgeLineSHFEPositions == null)
                {
                    _hedgeLineSHFEPositions = new TrackableCollection<HedgeLineSHFEPosition>();
                    _hedgeLineSHFEPositions.CollectionChanged += FixupHedgeLineSHFEPositions;
                }
                return _hedgeLineSHFEPositions;
            }
            set
            {
                if (!ReferenceEquals(_hedgeLineSHFEPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hedgeLineSHFEPositions != null)
                    {
                        _hedgeLineSHFEPositions.CollectionChanged -= FixupHedgeLineSHFEPositions;
                    }
                    _hedgeLineSHFEPositions = value;
                    if (_hedgeLineSHFEPositions != null)
                    {
                        _hedgeLineSHFEPositions.CollectionChanged += FixupHedgeLineSHFEPositions;
                    }
                    OnNavigationPropertyChanged("HedgeLineSHFEPositions");
                }
            }
        }
        private TrackableCollection<HedgeLineSHFEPosition> _hedgeLineSHFEPositions;
    
        [DataMember]
        public Currency PLCurrency
        {
            get { return _pLCurrency; }
            set
            {
                if (!ReferenceEquals(_pLCurrency, value))
                {
                    var previousValue = _pLCurrency;
                    _pLCurrency = value;
                    FixupPLCurrency(previousValue);
                    OnNavigationPropertyChanged("PLCurrency");
                }
            }
        }
        private Currency _pLCurrency;
    
        [DataMember]
        public TrackableCollection<HedgeLineTDPosition> HedgeLineTDPositions
        {
            get
            {
                if (_hedgeLineTDPositions == null)
                {
                    _hedgeLineTDPositions = new TrackableCollection<HedgeLineTDPosition>();
                    _hedgeLineTDPositions.CollectionChanged += FixupHedgeLineTDPositions;
                }
                return _hedgeLineTDPositions;
            }
            set
            {
                if (!ReferenceEquals(_hedgeLineTDPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hedgeLineTDPositions != null)
                    {
                        _hedgeLineTDPositions.CollectionChanged -= FixupHedgeLineTDPositions;
                    }
                    _hedgeLineTDPositions = value;
                    if (_hedgeLineTDPositions != null)
                    {
                        _hedgeLineTDPositions.CollectionChanged += FixupHedgeLineTDPositions;
                    }
                    OnNavigationPropertyChanged("HedgeLineTDPositions");
                }
            }
        }
        private TrackableCollection<HedgeLineTDPosition> _hedgeLineTDPositions;

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
            HedgeLineLMEPositions.Clear();
            HedgeLineQuotas.Clear();
            HedgeLineSHFEPositions.Clear();
            PLCurrency = null;
            HedgeLineTDPositions.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupPLCurrency(Currency previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.HedgeGroups.Contains(this))
            {
                previousValue.HedgeGroups.Remove(this);
            }
    
            if (PLCurrency != null)
            {
                if (!PLCurrency.HedgeGroups.Contains(this))
                {
                    PLCurrency.HedgeGroups.Add(this);
                }
    
                PLCurrencyId = PLCurrency.Id;
            }
            else if (!skipKeys)
            {
                PLCurrencyId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PLCurrency")
                    && (ChangeTracker.OriginalValues["PLCurrency"] == PLCurrency))
                {
                    ChangeTracker.OriginalValues.Remove("PLCurrency");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PLCurrency", previousValue);
                }
                if (PLCurrency != null && !PLCurrency.ChangeTracker.ChangeTrackingEnabled)
                {
                    PLCurrency.StartTracking();
                }
            }
        }
    
        private void FixupHedgeLineLMEPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (HedgeLineLMEPosition item in e.NewItems)
                {
                    item.HedgeGroup = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("HedgeLineLMEPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HedgeLineLMEPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.HedgeGroup, this))
                    {
                        item.HedgeGroup = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HedgeLineLMEPositions", item);
                    }
                }
            }
        }
    
        private void FixupHedgeLineQuotas(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (HedgeLineQuota item in e.NewItems)
                {
                    item.HedgeGroup = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("HedgeLineQuotas", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HedgeLineQuota item in e.OldItems)
                {
                    if (ReferenceEquals(item.HedgeGroup, this))
                    {
                        item.HedgeGroup = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HedgeLineQuotas", item);
                    }
                }
            }
        }
    
        private void FixupHedgeLineSHFEPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (HedgeLineSHFEPosition item in e.NewItems)
                {
                    item.HedgeGroup = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("HedgeLineSHFEPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HedgeLineSHFEPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.HedgeGroup, this))
                    {
                        item.HedgeGroup = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HedgeLineSHFEPositions", item);
                    }
                }
            }
        }
    
        private void FixupHedgeLineTDPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (HedgeLineTDPosition item in e.NewItems)
                {
                    item.HedgeGroup = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("HedgeLineTDPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HedgeLineTDPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.HedgeGroup, this))
                    {
                        item.HedgeGroup = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HedgeLineTDPositions", item);
                    }
                }
            }
        }

        #endregion

    }
}
