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
    [KnownType(typeof(VATInvoice))]
    [KnownType(typeof(VATRate))]
    [KnownType(typeof(VATInvoiceRequestLine))]
    public partial class VATInvoiceLine: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int VATInvoiceId
        {
            get { return _vATInvoiceId; }
            set
            {
                if (_vATInvoiceId != value)
                {
                    ChangeTracker.RecordOriginalValue("VATInvoiceId", _vATInvoiceId);
                    if (!IsDeserializing)
                    {
                        if (VATInvoice != null && VATInvoice.Id != value)
                        {
                            VATInvoice = null;
                        }
                    }
                    _vATInvoiceId = value;
                    OnPropertyChanged("VATInvoiceId");
                }
            }
        }
        private int _vATInvoiceId;
    
        [DataMember]
        public Nullable<decimal> VATInvoiceQuantity
        {
            get { return _vATInvoiceQuantity; }
            set
            {
                if (_vATInvoiceQuantity != value)
                {
                    _vATInvoiceQuantity = value;
                    OnPropertyChanged("VATInvoiceQuantity");
                }
            }
        }
        private Nullable<decimal> _vATInvoiceQuantity;
    
        [DataMember]
        public int VATRateId
        {
            get { return _vATRateId; }
            set
            {
                if (_vATRateId != value)
                {
                    ChangeTracker.RecordOriginalValue("VATRateId", _vATRateId);
                    if (!IsDeserializing)
                    {
                        if (VATRate != null && VATRate.Id != value)
                        {
                            VATRate = null;
                        }
                    }
                    _vATRateId = value;
                    OnPropertyChanged("VATRateId");
                }
            }
        }
        private int _vATRateId;
    
        [DataMember]
        public Nullable<int> VATInvoiceRequestLineId
        {
            get { return _vATInvoiceRequestLineId; }
            set
            {
                if (_vATInvoiceRequestLineId != value)
                {
                    ChangeTracker.RecordOriginalValue("VATInvoiceRequestLineId", _vATInvoiceRequestLineId);
                    if (!IsDeserializing)
                    {
                        if (VATInvoiceRequestLine != null && VATInvoiceRequestLine.Id != value)
                        {
                            VATInvoiceRequestLine = null;
                        }
                    }
                    _vATInvoiceRequestLineId = value;
                    OnPropertyChanged("VATInvoiceRequestLineId");
                }
            }
        }
        private Nullable<int> _vATInvoiceRequestLineId;
    
        [DataMember]
        public Nullable<decimal> VATAmount
        {
            get { return _vATAmount; }
            set
            {
                if (_vATAmount != value)
                {
                    _vATAmount = value;
                    OnPropertyChanged("VATAmount");
                }
            }
        }
        private Nullable<decimal> _vATAmount;
    
        [DataMember]
        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                if (_quotaId != value)
                {
                    ChangeTracker.RecordOriginalValue("QuotaId", _quotaId);
                    if (!IsDeserializing)
                    {
                        if (Quota != null && Quota.Id != value)
                        {
                            Quota = null;
                        }
                    }
                    _quotaId = value;
                    OnPropertyChanged("QuotaId");
                }
            }
        }
        private int _quotaId;
    
        [DataMember]
        public Nullable<decimal> VATPrice
        {
            get { return _vATPrice; }
            set
            {
                if (_vATPrice != value)
                {
                    _vATPrice = value;
                    OnPropertyChanged("VATPrice");
                }
            }
        }
        private Nullable<decimal> _vATPrice;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Quota Quota
        {
            get { return _quota; }
            set
            {
                if (!ReferenceEquals(_quota, value))
                {
                    var previousValue = _quota;
                    _quota = value;
                    FixupQuota(previousValue);
                    OnNavigationPropertyChanged("Quota");
                }
            }
        }
        private Quota _quota;
    
        [DataMember]
        public VATInvoice VATInvoice
        {
            get { return _vATInvoice; }
            set
            {
                if (!ReferenceEquals(_vATInvoice, value))
                {
                    var previousValue = _vATInvoice;
                    _vATInvoice = value;
                    FixupVATInvoice(previousValue);
                    OnNavigationPropertyChanged("VATInvoice");
                }
            }
        }
        private VATInvoice _vATInvoice;
    
        [DataMember]
        public VATRate VATRate
        {
            get { return _vATRate; }
            set
            {
                if (!ReferenceEquals(_vATRate, value))
                {
                    var previousValue = _vATRate;
                    _vATRate = value;
                    FixupVATRate(previousValue);
                    OnNavigationPropertyChanged("VATRate");
                }
            }
        }
        private VATRate _vATRate;
    
        [DataMember]
        public VATInvoiceRequestLine VATInvoiceRequestLine
        {
            get { return _vATInvoiceRequestLine; }
            set
            {
                if (!ReferenceEquals(_vATInvoiceRequestLine, value))
                {
                    var previousValue = _vATInvoiceRequestLine;
                    _vATInvoiceRequestLine = value;
                    FixupVATInvoiceRequestLine(previousValue);
                    OnNavigationPropertyChanged("VATInvoiceRequestLine");
                }
            }
        }
        private VATInvoiceRequestLine _vATInvoiceRequestLine;

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
            Quota = null;
            VATInvoice = null;
            VATRate = null;
            VATInvoiceRequestLine = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupQuota(Quota previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoiceLines.Contains(this))
            {
                previousValue.VATInvoiceLines.Remove(this);
            }
    
            if (Quota != null)
            {
                if (!Quota.VATInvoiceLines.Contains(this))
                {
                    Quota.VATInvoiceLines.Add(this);
                }
    
                QuotaId = Quota.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Quota")
                    && (ChangeTracker.OriginalValues["Quota"] == Quota))
                {
                    ChangeTracker.OriginalValues.Remove("Quota");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Quota", previousValue);
                }
                if (Quota != null && !Quota.ChangeTracker.ChangeTrackingEnabled)
                {
                    Quota.StartTracking();
                }
            }
        }
    
        private void FixupVATInvoice(VATInvoice previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoiceLines.Contains(this))
            {
                previousValue.VATInvoiceLines.Remove(this);
            }
    
            if (VATInvoice != null)
            {
                if (!VATInvoice.VATInvoiceLines.Contains(this))
                {
                    VATInvoice.VATInvoiceLines.Add(this);
                }
    
                VATInvoiceId = VATInvoice.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("VATInvoice")
                    && (ChangeTracker.OriginalValues["VATInvoice"] == VATInvoice))
                {
                    ChangeTracker.OriginalValues.Remove("VATInvoice");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("VATInvoice", previousValue);
                }
                if (VATInvoice != null && !VATInvoice.ChangeTracker.ChangeTrackingEnabled)
                {
                    VATInvoice.StartTracking();
                }
            }
        }
    
        private void FixupVATRate(VATRate previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoiceLines.Contains(this))
            {
                previousValue.VATInvoiceLines.Remove(this);
            }
    
            if (VATRate != null)
            {
                if (!VATRate.VATInvoiceLines.Contains(this))
                {
                    VATRate.VATInvoiceLines.Add(this);
                }
    
                VATRateId = VATRate.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("VATRate")
                    && (ChangeTracker.OriginalValues["VATRate"] == VATRate))
                {
                    ChangeTracker.OriginalValues.Remove("VATRate");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("VATRate", previousValue);
                }
                if (VATRate != null && !VATRate.ChangeTracker.ChangeTrackingEnabled)
                {
                    VATRate.StartTracking();
                }
            }
        }
    
        private void FixupVATInvoiceRequestLine(VATInvoiceRequestLine previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoiceLines.Contains(this))
            {
                previousValue.VATInvoiceLines.Remove(this);
            }
    
            if (VATInvoiceRequestLine != null)
            {
                if (!VATInvoiceRequestLine.VATInvoiceLines.Contains(this))
                {
                    VATInvoiceRequestLine.VATInvoiceLines.Add(this);
                }
    
                VATInvoiceRequestLineId = VATInvoiceRequestLine.Id;
            }
            else if (!skipKeys)
            {
                VATInvoiceRequestLineId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("VATInvoiceRequestLine")
                    && (ChangeTracker.OriginalValues["VATInvoiceRequestLine"] == VATInvoiceRequestLine))
                {
                    ChangeTracker.OriginalValues.Remove("VATInvoiceRequestLine");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("VATInvoiceRequestLine", previousValue);
                }
                if (VATInvoiceRequestLine != null && !VATInvoiceRequestLine.ChangeTracker.ChangeTrackingEnabled)
                {
                    VATInvoiceRequestLine.StartTracking();
                }
            }
        }

        #endregion

    }
}
