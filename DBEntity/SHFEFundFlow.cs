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
    [KnownType(typeof(SHFECapitalDetail))]
    public partial class SHFEFundFlow: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int SHFECapitalDetailsId
        {
            get { return _sHFECapitalDetailsId; }
            set
            {
                if (_sHFECapitalDetailsId != value)
                {
                    ChangeTracker.RecordOriginalValue("SHFECapitalDetailsId", _sHFECapitalDetailsId);
                    if (!IsDeserializing)
                    {
                        if (SHFECapitalDetail != null && SHFECapitalDetail.Id != value)
                        {
                            SHFECapitalDetail = null;
                        }
                    }
                    _sHFECapitalDetailsId = value;
                    OnPropertyChanged("SHFECapitalDetailsId");
                }
            }
        }
        private int _sHFECapitalDetailsId;
    
        [DataMember]
        public Nullable<System.DateTime> TradeDate
        {
            get { return _tradeDate; }
            set
            {
                if (_tradeDate != value)
                {
                    _tradeDate = value;
                    OnPropertyChanged("TradeDate");
                }
            }
        }
        private Nullable<System.DateTime> _tradeDate;
    
        [DataMember]
        public decimal AmountIn
        {
            get { return _amountIn; }
            set
            {
                if (_amountIn != value)
                {
                    _amountIn = value;
                    OnPropertyChanged("AmountIn");
                }
            }
        }
        private decimal _amountIn;
    
        [DataMember]
        public decimal AmountOut
        {
            get { return _amountOut; }
            set
            {
                if (_amountOut != value)
                {
                    _amountOut = value;
                    OnPropertyChanged("AmountOut");
                }
            }
        }
        private decimal _amountOut;
    
        [DataMember]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        private string _type;
    
        [DataMember]
        public string Abstract
        {
            get { return _abstract; }
            set
            {
                if (_abstract != value)
                {
                    _abstract = value;
                    OnPropertyChanged("Abstract");
                }
            }
        }
        private string _abstract;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public SHFECapitalDetail SHFECapitalDetail
        {
            get { return _sHFECapitalDetail; }
            set
            {
                if (!ReferenceEquals(_sHFECapitalDetail, value))
                {
                    var previousValue = _sHFECapitalDetail;
                    _sHFECapitalDetail = value;
                    FixupSHFECapitalDetail(previousValue);
                    OnNavigationPropertyChanged("SHFECapitalDetail");
                }
            }
        }
        private SHFECapitalDetail _sHFECapitalDetail;

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
            SHFECapitalDetail = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupSHFECapitalDetail(SHFECapitalDetail previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SHFEFundFlows.Contains(this))
            {
                previousValue.SHFEFundFlows.Remove(this);
            }
    
            if (SHFECapitalDetail != null)
            {
                if (!SHFECapitalDetail.SHFEFundFlows.Contains(this))
                {
                    SHFECapitalDetail.SHFEFundFlows.Add(this);
                }
    
                SHFECapitalDetailsId = SHFECapitalDetail.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SHFECapitalDetail")
                    && (ChangeTracker.OriginalValues["SHFECapitalDetail"] == SHFECapitalDetail))
                {
                    ChangeTracker.OriginalValues.Remove("SHFECapitalDetail");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SHFECapitalDetail", previousValue);
                }
                if (SHFECapitalDetail != null && !SHFECapitalDetail.ChangeTracker.ChangeTrackingEnabled)
                {
                    SHFECapitalDetail.StartTracking();
                }
            }
        }

        #endregion

    }
}
