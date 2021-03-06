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
    [KnownType(typeof(Module))]
    [KnownType(typeof(RoleFunctionLink))]
    public partial class Function: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int ModuleId
        {
            get { return _moduleId; }
            set
            {
                if (_moduleId != value)
                {
                    ChangeTracker.RecordOriginalValue("ModuleId", _moduleId);
                    if (!IsDeserializing)
                    {
                        if (Module != null && Module.Id != value)
                        {
                            Module = null;
                        }
                    }
                    _moduleId = value;
                    OnPropertyChanged("ModuleId");
                }
            }
        }
        private int _moduleId;
    
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
        public string PageMode
        {
            get { return _pageMode; }
            set
            {
                if (_pageMode != value)
                {
                    _pageMode = value;
                    OnPropertyChanged("PageMode");
                }
            }
        }
        private string _pageMode;
    
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Module Module
        {
            get { return _module; }
            set
            {
                if (!ReferenceEquals(_module, value))
                {
                    var previousValue = _module;
                    _module = value;
                    FixupModule(previousValue);
                    OnNavigationPropertyChanged("Module");
                }
            }
        }
        private Module _module;
    
        [DataMember]
        public TrackableCollection<RoleFunctionLink> RoleFunctionLinks
        {
            get
            {
                if (_roleFunctionLinks == null)
                {
                    _roleFunctionLinks = new TrackableCollection<RoleFunctionLink>();
                    _roleFunctionLinks.CollectionChanged += FixupRoleFunctionLinks;
                }
                return _roleFunctionLinks;
            }
            set
            {
                if (!ReferenceEquals(_roleFunctionLinks, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_roleFunctionLinks != null)
                    {
                        _roleFunctionLinks.CollectionChanged -= FixupRoleFunctionLinks;
                    }
                    _roleFunctionLinks = value;
                    if (_roleFunctionLinks != null)
                    {
                        _roleFunctionLinks.CollectionChanged += FixupRoleFunctionLinks;
                    }
                    OnNavigationPropertyChanged("RoleFunctionLinks");
                }
            }
        }
        private TrackableCollection<RoleFunctionLink> _roleFunctionLinks;

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
            Module = null;
            RoleFunctionLinks.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupModule(Module previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Functions.Contains(this))
            {
                previousValue.Functions.Remove(this);
            }
    
            if (Module != null)
            {
                if (!Module.Functions.Contains(this))
                {
                    Module.Functions.Add(this);
                }
    
                ModuleId = Module.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Module")
                    && (ChangeTracker.OriginalValues["Module"] == Module))
                {
                    ChangeTracker.OriginalValues.Remove("Module");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Module", previousValue);
                }
                if (Module != null && !Module.ChangeTracker.ChangeTrackingEnabled)
                {
                    Module.StartTracking();
                }
            }
        }
    
        private void FixupRoleFunctionLinks(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (RoleFunctionLink item in e.NewItems)
                {
                    item.Function = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("RoleFunctionLinks", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RoleFunctionLink item in e.OldItems)
                {
                    if (ReferenceEquals(item.Function, this))
                    {
                        item.Function = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("RoleFunctionLinks", item);
                    }
                }
            }
        }

        #endregion

    }
}
