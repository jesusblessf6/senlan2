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
    [KnownType(typeof(SHFEPosition))]
    [KnownType(typeof(SHFEHoldingPosition))]
    [KnownType(typeof(TDHoldingPosition))]
    [KnownType(typeof(TDPosition))]
    public partial class SHFE: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged("Code");
                }
            }
        }
        private string _code;
    
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
        public string Alias
        {
            get { return _alias; }
            set
            {
                if (_alias != value)
                {
                    _alias = value;
                    OnPropertyChanged("Alias");
                }
            }
        }
        private string _alias;
    
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<SHFEPosition> SHFEPositions
        {
            get
            {
                if (_sHFEPositions == null)
                {
                    _sHFEPositions = new TrackableCollection<SHFEPosition>();
                    _sHFEPositions.CollectionChanged += FixupSHFEPositions;
                }
                return _sHFEPositions;
            }
            set
            {
                if (!ReferenceEquals(_sHFEPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_sHFEPositions != null)
                    {
                        _sHFEPositions.CollectionChanged -= FixupSHFEPositions;
                    }
                    _sHFEPositions = value;
                    if (_sHFEPositions != null)
                    {
                        _sHFEPositions.CollectionChanged += FixupSHFEPositions;
                    }
                    OnNavigationPropertyChanged("SHFEPositions");
                }
            }
        }
        private TrackableCollection<SHFEPosition> _sHFEPositions;
    
        [DataMember]
        public TrackableCollection<SHFEHoldingPosition> SHFEHoldingPositions
        {
            get
            {
                if (_sHFEHoldingPositions == null)
                {
                    _sHFEHoldingPositions = new TrackableCollection<SHFEHoldingPosition>();
                    _sHFEHoldingPositions.CollectionChanged += FixupSHFEHoldingPositions;
                }
                return _sHFEHoldingPositions;
            }
            set
            {
                if (!ReferenceEquals(_sHFEHoldingPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_sHFEHoldingPositions != null)
                    {
                        _sHFEHoldingPositions.CollectionChanged -= FixupSHFEHoldingPositions;
                    }
                    _sHFEHoldingPositions = value;
                    if (_sHFEHoldingPositions != null)
                    {
                        _sHFEHoldingPositions.CollectionChanged += FixupSHFEHoldingPositions;
                    }
                    OnNavigationPropertyChanged("SHFEHoldingPositions");
                }
            }
        }
        private TrackableCollection<SHFEHoldingPosition> _sHFEHoldingPositions;
    
        [DataMember]
        public TrackableCollection<TDHoldingPosition> TDHoldingPositions
        {
            get
            {
                if (_tDHoldingPositions == null)
                {
                    _tDHoldingPositions = new TrackableCollection<TDHoldingPosition>();
                    _tDHoldingPositions.CollectionChanged += FixupTDHoldingPositions;
                }
                return _tDHoldingPositions;
            }
            set
            {
                if (!ReferenceEquals(_tDHoldingPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_tDHoldingPositions != null)
                    {
                        _tDHoldingPositions.CollectionChanged -= FixupTDHoldingPositions;
                    }
                    _tDHoldingPositions = value;
                    if (_tDHoldingPositions != null)
                    {
                        _tDHoldingPositions.CollectionChanged += FixupTDHoldingPositions;
                    }
                    OnNavigationPropertyChanged("TDHoldingPositions");
                }
            }
        }
        private TrackableCollection<TDHoldingPosition> _tDHoldingPositions;
    
        [DataMember]
        public TrackableCollection<TDPosition> TDPositions
        {
            get
            {
                if (_tDPositions == null)
                {
                    _tDPositions = new TrackableCollection<TDPosition>();
                    _tDPositions.CollectionChanged += FixupTDPositions;
                }
                return _tDPositions;
            }
            set
            {
                if (!ReferenceEquals(_tDPositions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_tDPositions != null)
                    {
                        _tDPositions.CollectionChanged -= FixupTDPositions;
                    }
                    _tDPositions = value;
                    if (_tDPositions != null)
                    {
                        _tDPositions.CollectionChanged += FixupTDPositions;
                    }
                    OnNavigationPropertyChanged("TDPositions");
                }
            }
        }
        private TrackableCollection<TDPosition> _tDPositions;

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
            SHFEPositions.Clear();
            SHFEHoldingPositions.Clear();
            TDHoldingPositions.Clear();
            TDPositions.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupSHFEPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (SHFEPosition item in e.NewItems)
                {
                    item.SHFE = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("SHFEPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SHFEPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.SHFE, this))
                    {
                        item.SHFE = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("SHFEPositions", item);
                    }
                }
            }
        }
    
        private void FixupSHFEHoldingPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (SHFEHoldingPosition item in e.NewItems)
                {
                    item.SHFE = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("SHFEHoldingPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SHFEHoldingPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.SHFE, this))
                    {
                        item.SHFE = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("SHFEHoldingPositions", item);
                    }
                }
            }
        }
    
        private void FixupTDHoldingPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (TDHoldingPosition item in e.NewItems)
                {
                    item.SHFE = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("TDHoldingPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TDHoldingPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.SHFE, this))
                    {
                        item.SHFE = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("TDHoldingPositions", item);
                    }
                }
            }
        }
    
        private void FixupTDPositions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (TDPosition item in e.NewItems)
                {
                    item.SHFE = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("TDPositions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TDPosition item in e.OldItems)
                {
                    if (ReferenceEquals(item.SHFE, this))
                    {
                        item.SHFE = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("TDPositions", item);
                    }
                }
            }
        }

        #endregion

    }
}
