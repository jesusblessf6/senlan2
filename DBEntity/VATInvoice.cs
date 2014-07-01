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
    [KnownType(typeof(BusinessPartner))]
    [KnownType(typeof(VATInvoiceRequest))]
    [KnownType(typeof(VATInvoiceLine))]
    public partial class VATInvoice: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int VATInvoiceType
        {
            get { return _vATInvoiceType; }
            set
            {
                if (_vATInvoiceType != value)
                {
                    _vATInvoiceType = value;
                    OnPropertyChanged("VATInvoiceType");
                }
            }
        }
        private int _vATInvoiceType;
    
        [DataMember]
        public int BPId
        {
            get { return _bPId; }
            set
            {
                if (_bPId != value)
                {
                    ChangeTracker.RecordOriginalValue("BPId", _bPId);
                    if (!IsDeserializing)
                    {
                        if (BusinessPartner != null && BusinessPartner.Id != value)
                        {
                            BusinessPartner = null;
                        }
                    }
                    _bPId = value;
                    OnPropertyChanged("BPId");
                }
            }
        }
        private int _bPId;
    
        [DataMember]
        public int InternalBPId
        {
            get { return _internalBPId; }
            set
            {
                if (_internalBPId != value)
                {
                    ChangeTracker.RecordOriginalValue("InternalBPId", _internalBPId);
                    if (!IsDeserializing)
                    {
                        if (BusinessPartner1 != null && BusinessPartner1.Id != value)
                        {
                            BusinessPartner1 = null;
                        }
                    }
                    _internalBPId = value;
                    OnPropertyChanged("InternalBPId");
                }
            }
        }
        private int _internalBPId;
    
        [DataMember]
        public Nullable<System.DateTime> InvoicedDate
        {
            get { return _invoicedDate; }
            set
            {
                if (_invoicedDate != value)
                {
                    _invoicedDate = value;
                    OnPropertyChanged("InvoicedDate");
                }
            }
        }
        private Nullable<System.DateTime> _invoicedDate;
    
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
        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                if (_invoiceNo != value)
                {
                    _invoiceNo = value;
                    OnPropertyChanged("InvoiceNo");
                }
            }
        }
        private string _invoiceNo;
    
        [DataMember]
        public Nullable<int> VATInvoiceRequestId
        {
            get { return _vATInvoiceRequestId; }
            set
            {
                if (_vATInvoiceRequestId != value)
                {
                    ChangeTracker.RecordOriginalValue("VATInvoiceRequestId", _vATInvoiceRequestId);
                    if (!IsDeserializing)
                    {
                        if (VATInvoiceRequest != null && VATInvoiceRequest.Id != value)
                        {
                            VATInvoiceRequest = null;
                        }
                    }
                    _vATInvoiceRequestId = value;
                    OnPropertyChanged("VATInvoiceRequestId");
                }
            }
        }
        private Nullable<int> _vATInvoiceRequestId;

        #endregion

        #region Navigation Properties
    
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
        public BusinessPartner BusinessPartner1
        {
            get { return _businessPartner1; }
            set
            {
                if (!ReferenceEquals(_businessPartner1, value))
                {
                    var previousValue = _businessPartner1;
                    _businessPartner1 = value;
                    FixupBusinessPartner1(previousValue);
                    OnNavigationPropertyChanged("BusinessPartner1");
                }
            }
        }
        private BusinessPartner _businessPartner1;
    
        [DataMember]
        public VATInvoiceRequest VATInvoiceRequest
        {
            get { return _vATInvoiceRequest; }
            set
            {
                if (!ReferenceEquals(_vATInvoiceRequest, value))
                {
                    var previousValue = _vATInvoiceRequest;
                    _vATInvoiceRequest = value;
                    FixupVATInvoiceRequest(previousValue);
                    OnNavigationPropertyChanged("VATInvoiceRequest");
                }
            }
        }
        private VATInvoiceRequest _vATInvoiceRequest;
    
        [DataMember]
        public TrackableCollection<VATInvoiceLine> VATInvoiceLines
        {
            get
            {
                if (_vATInvoiceLines == null)
                {
                    _vATInvoiceLines = new TrackableCollection<VATInvoiceLine>();
                    _vATInvoiceLines.CollectionChanged += FixupVATInvoiceLines;
                }
                return _vATInvoiceLines;
            }
            set
            {
                if (!ReferenceEquals(_vATInvoiceLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_vATInvoiceLines != null)
                    {
                        _vATInvoiceLines.CollectionChanged -= FixupVATInvoiceLines;
                    }
                    _vATInvoiceLines = value;
                    if (_vATInvoiceLines != null)
                    {
                        _vATInvoiceLines.CollectionChanged += FixupVATInvoiceLines;
                    }
                    OnNavigationPropertyChanged("VATInvoiceLines");
                }
            }
        }
        private TrackableCollection<VATInvoiceLine> _vATInvoiceLines;

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
            BusinessPartner = null;
            BusinessPartner1 = null;
            VATInvoiceRequest = null;
            VATInvoiceLines.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupBusinessPartner(BusinessPartner previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoices.Contains(this))
            {
                previousValue.VATInvoices.Remove(this);
            }
    
            if (BusinessPartner != null)
            {
                if (!BusinessPartner.VATInvoices.Contains(this))
                {
                    BusinessPartner.VATInvoices.Add(this);
                }
    
                BPId = BusinessPartner.Id;
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
    
        private void FixupBusinessPartner1(BusinessPartner previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoices1.Contains(this))
            {
                previousValue.VATInvoices1.Remove(this);
            }
    
            if (BusinessPartner1 != null)
            {
                if (!BusinessPartner1.VATInvoices1.Contains(this))
                {
                    BusinessPartner1.VATInvoices1.Add(this);
                }
    
                InternalBPId = BusinessPartner1.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BusinessPartner1")
                    && (ChangeTracker.OriginalValues["BusinessPartner1"] == BusinessPartner1))
                {
                    ChangeTracker.OriginalValues.Remove("BusinessPartner1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BusinessPartner1", previousValue);
                }
                if (BusinessPartner1 != null && !BusinessPartner1.ChangeTracker.ChangeTrackingEnabled)
                {
                    BusinessPartner1.StartTracking();
                }
            }
        }
    
        private void FixupVATInvoiceRequest(VATInvoiceRequest previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.VATInvoices.Contains(this))
            {
                previousValue.VATInvoices.Remove(this);
            }
    
            if (VATInvoiceRequest != null)
            {
                if (!VATInvoiceRequest.VATInvoices.Contains(this))
                {
                    VATInvoiceRequest.VATInvoices.Add(this);
                }
    
                VATInvoiceRequestId = VATInvoiceRequest.Id;
            }
            else if (!skipKeys)
            {
                VATInvoiceRequestId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("VATInvoiceRequest")
                    && (ChangeTracker.OriginalValues["VATInvoiceRequest"] == VATInvoiceRequest))
                {
                    ChangeTracker.OriginalValues.Remove("VATInvoiceRequest");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("VATInvoiceRequest", previousValue);
                }
                if (VATInvoiceRequest != null && !VATInvoiceRequest.ChangeTracker.ChangeTrackingEnabled)
                {
                    VATInvoiceRequest.StartTracking();
                }
            }
        }
    
        private void FixupVATInvoiceLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (VATInvoiceLine item in e.NewItems)
                {
                    item.VATInvoice = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("VATInvoiceLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (VATInvoiceLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.VATInvoice, this))
                    {
                        item.VATInvoice = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("VATInvoiceLines", item);
                    }
                }
            }
        }

        #endregion

    }
}
