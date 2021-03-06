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
    [KnownType(typeof(Commission))]
    [KnownType(typeof(Commodity))]
    public partial class CommissionLine: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public bool IsDraft
        {
            get { return _isDraft; }
            set
            {
                if (_isDraft != value)
                {
                    _isDraft = value;
                    OnPropertyChanged("IsDraft");
                }
            }
        }
        private bool _isDraft;
    
        [DataMember]
        public int CommissionId
        {
            get { return _commissionId; }
            set
            {
                if (_commissionId != value)
                {
                    ChangeTracker.RecordOriginalValue("CommissionId", _commissionId);
                    if (!IsDeserializing)
                    {
                        if (Commission != null && Commission.Id != value)
                        {
                            Commission = null;
                        }
                    }
                    _commissionId = value;
                    OnPropertyChanged("CommissionId");
                }
            }
        }
        private int _commissionId;
    
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
        public int RuleType
        {
            get { return _ruleType; }
            set
            {
                if (_ruleType != value)
                {
                    _ruleType = value;
                    OnPropertyChanged("RuleType");
                }
            }
        }
        private int _ruleType;
    
        [DataMember]
        public Nullable<decimal> RuleValue
        {
            get { return _ruleValue; }
            set
            {
                if (_ruleValue != value)
                {
                    _ruleValue = value;
                    OnPropertyChanged("RuleValue");
                }
            }
        }
        private Nullable<decimal> _ruleValue;
    
        [DataMember]
        public Nullable<System.DateTime> StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private Nullable<System.DateTime> _startDate;
    
        [DataMember]
        public Nullable<System.DateTime> EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
        private Nullable<System.DateTime> _endDate;
    
        [DataMember]
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        private string _comment;
    
        [DataMember]
        public Nullable<int> RuleType2
        {
            get { return _ruleType2; }
            set
            {
                if (_ruleType2 != value)
                {
                    _ruleType2 = value;
                    OnPropertyChanged("RuleType2");
                }
            }
        }
        private Nullable<int> _ruleType2;
    
        [DataMember]
        public Nullable<decimal> RuleValue2
        {
            get { return _ruleValue2; }
            set
            {
                if (_ruleValue2 != value)
                {
                    _ruleValue2 = value;
                    OnPropertyChanged("RuleValue2");
                }
            }
        }
        private Nullable<decimal> _ruleValue2;
    
        [DataMember]
        public Nullable<int> CarryDaysLimit
        {
            get { return _carryDaysLimit; }
            set
            {
                if (_carryDaysLimit != value)
                {
                    _carryDaysLimit = value;
                    OnPropertyChanged("CarryDaysLimit");
                }
            }
        }
        private Nullable<int> _carryDaysLimit;
    
        [DataMember]
        public Nullable<bool> InLimitIsOneLeg
        {
            get { return _inLimitIsOneLeg; }
            set
            {
                if (_inLimitIsOneLeg != value)
                {
                    _inLimitIsOneLeg = value;
                    OnPropertyChanged("InLimitIsOneLeg");
                }
            }
        }
        private Nullable<bool> _inLimitIsOneLeg;
    
        [DataMember]
        public Nullable<bool> OutLimieIsOneLeg
        {
            get { return _outLimieIsOneLeg; }
            set
            {
                if (_outLimieIsOneLeg != value)
                {
                    _outLimieIsOneLeg = value;
                    OnPropertyChanged("OutLimieIsOneLeg");
                }
            }
        }
        private Nullable<bool> _outLimieIsOneLeg;
    
        [DataMember]
        public Nullable<int> InLimitRuleType1
        {
            get { return _inLimitRuleType1; }
            set
            {
                if (_inLimitRuleType1 != value)
                {
                    _inLimitRuleType1 = value;
                    OnPropertyChanged("InLimitRuleType1");
                }
            }
        }
        private Nullable<int> _inLimitRuleType1;
    
        [DataMember]
        public Nullable<decimal> InLimitRuleValue1
        {
            get { return _inLimitRuleValue1; }
            set
            {
                if (_inLimitRuleValue1 != value)
                {
                    _inLimitRuleValue1 = value;
                    OnPropertyChanged("InLimitRuleValue1");
                }
            }
        }
        private Nullable<decimal> _inLimitRuleValue1;
    
        [DataMember]
        public Nullable<int> InLimitRuleType2
        {
            get { return _inLimitRuleType2; }
            set
            {
                if (_inLimitRuleType2 != value)
                {
                    _inLimitRuleType2 = value;
                    OnPropertyChanged("InLimitRuleType2");
                }
            }
        }
        private Nullable<int> _inLimitRuleType2;
    
        [DataMember]
        public Nullable<decimal> InLimitRuleValue2
        {
            get { return _inLimitRuleValue2; }
            set
            {
                if (_inLimitRuleValue2 != value)
                {
                    _inLimitRuleValue2 = value;
                    OnPropertyChanged("InLimitRuleValue2");
                }
            }
        }
        private Nullable<decimal> _inLimitRuleValue2;
    
        [DataMember]
        public Nullable<int> OutLimitRuleType1
        {
            get { return _outLimitRuleType1; }
            set
            {
                if (_outLimitRuleType1 != value)
                {
                    _outLimitRuleType1 = value;
                    OnPropertyChanged("OutLimitRuleType1");
                }
            }
        }
        private Nullable<int> _outLimitRuleType1;
    
        [DataMember]
        public Nullable<decimal> OutLimitRuleValue1
        {
            get { return _outLimitRuleValue1; }
            set
            {
                if (_outLimitRuleValue1 != value)
                {
                    _outLimitRuleValue1 = value;
                    OnPropertyChanged("OutLimitRuleValue1");
                }
            }
        }
        private Nullable<decimal> _outLimitRuleValue1;
    
        [DataMember]
        public Nullable<int> OutLimitRuleType2
        {
            get { return _outLimitRuleType2; }
            set
            {
                if (_outLimitRuleType2 != value)
                {
                    _outLimitRuleType2 = value;
                    OnPropertyChanged("OutLimitRuleType2");
                }
            }
        }
        private Nullable<int> _outLimitRuleType2;
    
        [DataMember]
        public Nullable<decimal> OutLimitRuleValue2
        {
            get { return _outLimitRuleValue2; }
            set
            {
                if (_outLimitRuleValue2 != value)
                {
                    _outLimitRuleValue2 = value;
                    OnPropertyChanged("OutLimitRuleValue2");
                }
            }
        }
        private Nullable<decimal> _outLimitRuleValue2;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Commission Commission
        {
            get { return _commission; }
            set
            {
                if (!ReferenceEquals(_commission, value))
                {
                    var previousValue = _commission;
                    _commission = value;
                    FixupCommission(previousValue);
                    OnNavigationPropertyChanged("Commission");
                }
            }
        }
        private Commission _commission;
    
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
            Commission = null;
            Commodity = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCommission(Commission previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CommissionLines.Contains(this))
            {
                previousValue.CommissionLines.Remove(this);
            }
    
            if (Commission != null)
            {
                if (!Commission.CommissionLines.Contains(this))
                {
                    Commission.CommissionLines.Add(this);
                }
    
                CommissionId = Commission.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Commission")
                    && (ChangeTracker.OriginalValues["Commission"] == Commission))
                {
                    ChangeTracker.OriginalValues.Remove("Commission");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Commission", previousValue);
                }
                if (Commission != null && !Commission.ChangeTracker.ChangeTrackingEnabled)
                {
                    Commission.StartTracking();
                }
            }
        }
    
        private void FixupCommodity(Commodity previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CommissionLines.Contains(this))
            {
                previousValue.CommissionLines.Remove(this);
            }
    
            if (Commodity != null)
            {
                if (!Commodity.CommissionLines.Contains(this))
                {
                    Commodity.CommissionLines.Add(this);
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

        #endregion

    }
}
