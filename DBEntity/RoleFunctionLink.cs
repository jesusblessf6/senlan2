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
    [KnownType(typeof(Function))]
    [KnownType(typeof(Role))]
    public partial class RoleFunctionLink: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int RoleId
        {
            get { return _roleId; }
            set
            {
                if (_roleId != value)
                {
                    ChangeTracker.RecordOriginalValue("RoleId", _roleId);
                    if (!IsDeserializing)
                    {
                        if (Role != null && Role.Id != value)
                        {
                            Role = null;
                        }
                    }
                    _roleId = value;
                    OnPropertyChanged("RoleId");
                }
            }
        }
        private int _roleId;
    
        [DataMember]
        public int FunctionId
        {
            get { return _functionId; }
            set
            {
                if (_functionId != value)
                {
                    ChangeTracker.RecordOriginalValue("FunctionId", _functionId);
                    if (!IsDeserializing)
                    {
                        if (Function != null && Function.Id != value)
                        {
                            Function = null;
                        }
                    }
                    _functionId = value;
                    OnPropertyChanged("FunctionId");
                }
            }
        }
        private int _functionId;
    
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
        public Function Function
        {
            get { return _function; }
            set
            {
                if (!ReferenceEquals(_function, value))
                {
                    var previousValue = _function;
                    _function = value;
                    FixupFunction(previousValue);
                    OnNavigationPropertyChanged("Function");
                }
            }
        }
        private Function _function;
    
        [DataMember]
        public Role Role
        {
            get { return _role; }
            set
            {
                if (!ReferenceEquals(_role, value))
                {
                    var previousValue = _role;
                    _role = value;
                    FixupRole(previousValue);
                    OnNavigationPropertyChanged("Role");
                }
            }
        }
        private Role _role;

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
            Function = null;
            Role = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupFunction(Function previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RoleFunctionLinks.Contains(this))
            {
                previousValue.RoleFunctionLinks.Remove(this);
            }
    
            if (Function != null)
            {
                if (!Function.RoleFunctionLinks.Contains(this))
                {
                    Function.RoleFunctionLinks.Add(this);
                }
    
                FunctionId = Function.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Function")
                    && (ChangeTracker.OriginalValues["Function"] == Function))
                {
                    ChangeTracker.OriginalValues.Remove("Function");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Function", previousValue);
                }
                if (Function != null && !Function.ChangeTracker.ChangeTrackingEnabled)
                {
                    Function.StartTracking();
                }
            }
        }
    
        private void FixupRole(Role previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RoleFunctionLinks.Contains(this))
            {
                previousValue.RoleFunctionLinks.Remove(this);
            }
    
            if (Role != null)
            {
                if (!Role.RoleFunctionLinks.Contains(this))
                {
                    Role.RoleFunctionLinks.Add(this);
                }
    
                RoleId = Role.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Role")
                    && (ChangeTracker.OriginalValues["Role"] == Role))
                {
                    ChangeTracker.OriginalValues.Remove("Role");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Role", previousValue);
                }
                if (Role != null && !Role.ChangeTracker.ChangeTrackingEnabled)
                {
                    Role.StartTracking();
                }
            }
        }

        #endregion

    }
}
