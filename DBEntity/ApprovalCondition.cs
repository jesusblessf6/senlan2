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
    [KnownType(typeof(Currency))]
    [KnownType(typeof(Approval))]
    public partial class ApprovalCondition: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public Nullable<decimal> UpperLimit
        {
            get { return _upperLimit; }
            set
            {
                if (_upperLimit != value)
                {
                    _upperLimit = value;
                    OnPropertyChanged("UpperLimit");
                }
            }
        }
        private Nullable<decimal> _upperLimit;
    
        [DataMember]
        public int CurrencyId
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
        private int _currencyId;
    
        [DataMember]
        public int ApprovalId
        {
            get { return _approvalId; }
            set
            {
                if (_approvalId != value)
                {
                    ChangeTracker.RecordOriginalValue("ApprovalId", _approvalId);
                    if (!IsDeserializing)
                    {
                        if (Approval != null && Approval.Id != value)
                        {
                            Approval = null;
                        }
                    }
                    _approvalId = value;
                    OnPropertyChanged("ApprovalId");
                }
            }
        }
        private int _approvalId;
    
        [DataMember]
        public Nullable<decimal> LowerLimit
        {
            get { return _lowerLimit; }
            set
            {
                if (_lowerLimit != value)
                {
                    _lowerLimit = value;
                    OnPropertyChanged("LowerLimit");
                }
            }
        }
        private Nullable<decimal> _lowerLimit;

        #endregion

        #region Navigation Properties
    
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
        public Approval Approval
        {
            get { return _approval; }
            set
            {
                if (!ReferenceEquals(_approval, value))
                {
                    var previousValue = _approval;
                    _approval = value;
                    FixupApproval(previousValue);
                    OnNavigationPropertyChanged("Approval");
                }
            }
        }
        private Approval _approval;

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
            Currency = null;
            Approval = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCurrency(Currency previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ApprovalConditions.Contains(this))
            {
                previousValue.ApprovalConditions.Remove(this);
            }
    
            if (Currency != null)
            {
                if (!Currency.ApprovalConditions.Contains(this))
                {
                    Currency.ApprovalConditions.Add(this);
                }
    
                CurrencyId = Currency.Id;
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
    
        private void FixupApproval(Approval previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ApprovalConditions.Contains(this))
            {
                previousValue.ApprovalConditions.Remove(this);
            }
    
            if (Approval != null)
            {
                if (!Approval.ApprovalConditions.Contains(this))
                {
                    Approval.ApprovalConditions.Add(this);
                }
    
                ApprovalId = Approval.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Approval")
                    && (ChangeTracker.OriginalValues["Approval"] == Approval))
                {
                    ChangeTracker.OriginalValues.Remove("Approval");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Approval", previousValue);
                }
                if (Approval != null && !Approval.ChangeTracker.ChangeTrackingEnabled)
                {
                    Approval.StartTracking();
                }
            }
        }

        #endregion

    }
}
