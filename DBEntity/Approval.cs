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
    [KnownType(typeof(Document))]
    [KnownType(typeof(ApprovalStage))]
    [KnownType(typeof(ApprovalCondition))]
    [KnownType(typeof(Quota))]
    [KnownType(typeof(Delivery))]
    [KnownType(typeof(PaymentRequest))]
    [KnownType(typeof(VATInvoiceRequestLine))]
    [KnownType(typeof(BusinessPartner))]
    public partial class Approval: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public int DocumentId
        {
            get { return _documentId; }
            set
            {
                if (_documentId != value)
                {
                    ChangeTracker.RecordOriginalValue("DocumentId", _documentId);
                    if (!IsDeserializing)
                    {
                        if (Document != null && Document.Id != value)
                        {
                            Document = null;
                        }
                    }
                    _documentId = value;
                    OnPropertyChanged("DocumentId");
                }
            }
        }
        private int _documentId;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    OnPropertyChanged("IsDefault");
                }
            }
        }
        private bool _isDefault;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Document Document
        {
            get { return _document; }
            set
            {
                if (!ReferenceEquals(_document, value))
                {
                    var previousValue = _document;
                    _document = value;
                    FixupDocument(previousValue);
                    OnNavigationPropertyChanged("Document");
                }
            }
        }
        private Document _document;
    
        [DataMember]
        public TrackableCollection<ApprovalStage> ApprovalStages
        {
            get
            {
                if (_approvalStages == null)
                {
                    _approvalStages = new TrackableCollection<ApprovalStage>();
                    _approvalStages.CollectionChanged += FixupApprovalStages;
                }
                return _approvalStages;
            }
            set
            {
                if (!ReferenceEquals(_approvalStages, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_approvalStages != null)
                    {
                        _approvalStages.CollectionChanged -= FixupApprovalStages;
                    }
                    _approvalStages = value;
                    if (_approvalStages != null)
                    {
                        _approvalStages.CollectionChanged += FixupApprovalStages;
                    }
                    OnNavigationPropertyChanged("ApprovalStages");
                }
            }
        }
        private TrackableCollection<ApprovalStage> _approvalStages;
    
        [DataMember]
        public TrackableCollection<ApprovalCondition> ApprovalConditions
        {
            get
            {
                if (_approvalConditions == null)
                {
                    _approvalConditions = new TrackableCollection<ApprovalCondition>();
                    _approvalConditions.CollectionChanged += FixupApprovalConditions;
                }
                return _approvalConditions;
            }
            set
            {
                if (!ReferenceEquals(_approvalConditions, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_approvalConditions != null)
                    {
                        _approvalConditions.CollectionChanged -= FixupApprovalConditions;
                    }
                    _approvalConditions = value;
                    if (_approvalConditions != null)
                    {
                        _approvalConditions.CollectionChanged += FixupApprovalConditions;
                    }
                    OnNavigationPropertyChanged("ApprovalConditions");
                }
            }
        }
        private TrackableCollection<ApprovalCondition> _approvalConditions;
    
        [DataMember]
        public TrackableCollection<Quota> Quotas
        {
            get
            {
                if (_quotas == null)
                {
                    _quotas = new TrackableCollection<Quota>();
                    _quotas.CollectionChanged += FixupQuotas;
                }
                return _quotas;
            }
            set
            {
                if (!ReferenceEquals(_quotas, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_quotas != null)
                    {
                        _quotas.CollectionChanged -= FixupQuotas;
                    }
                    _quotas = value;
                    if (_quotas != null)
                    {
                        _quotas.CollectionChanged += FixupQuotas;
                    }
                    OnNavigationPropertyChanged("Quotas");
                }
            }
        }
        private TrackableCollection<Quota> _quotas;
    
        [DataMember]
        public TrackableCollection<Delivery> Deliveries
        {
            get
            {
                if (_deliveries == null)
                {
                    _deliveries = new TrackableCollection<Delivery>();
                    _deliveries.CollectionChanged += FixupDeliveries;
                }
                return _deliveries;
            }
            set
            {
                if (!ReferenceEquals(_deliveries, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_deliveries != null)
                    {
                        _deliveries.CollectionChanged -= FixupDeliveries;
                    }
                    _deliveries = value;
                    if (_deliveries != null)
                    {
                        _deliveries.CollectionChanged += FixupDeliveries;
                    }
                    OnNavigationPropertyChanged("Deliveries");
                }
            }
        }
        private TrackableCollection<Delivery> _deliveries;
    
        [DataMember]
        public TrackableCollection<PaymentRequest> PaymentRequests
        {
            get
            {
                if (_paymentRequests == null)
                {
                    _paymentRequests = new TrackableCollection<PaymentRequest>();
                    _paymentRequests.CollectionChanged += FixupPaymentRequests;
                }
                return _paymentRequests;
            }
            set
            {
                if (!ReferenceEquals(_paymentRequests, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_paymentRequests != null)
                    {
                        _paymentRequests.CollectionChanged -= FixupPaymentRequests;
                    }
                    _paymentRequests = value;
                    if (_paymentRequests != null)
                    {
                        _paymentRequests.CollectionChanged += FixupPaymentRequests;
                    }
                    OnNavigationPropertyChanged("PaymentRequests");
                }
            }
        }
        private TrackableCollection<PaymentRequest> _paymentRequests;
    
        [DataMember]
        public TrackableCollection<VATInvoiceRequestLine> VATInvoiceRequestLines
        {
            get
            {
                if (_vATInvoiceRequestLines == null)
                {
                    _vATInvoiceRequestLines = new TrackableCollection<VATInvoiceRequestLine>();
                    _vATInvoiceRequestLines.CollectionChanged += FixupVATInvoiceRequestLines;
                }
                return _vATInvoiceRequestLines;
            }
            set
            {
                if (!ReferenceEquals(_vATInvoiceRequestLines, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_vATInvoiceRequestLines != null)
                    {
                        _vATInvoiceRequestLines.CollectionChanged -= FixupVATInvoiceRequestLines;
                    }
                    _vATInvoiceRequestLines = value;
                    if (_vATInvoiceRequestLines != null)
                    {
                        _vATInvoiceRequestLines.CollectionChanged += FixupVATInvoiceRequestLines;
                    }
                    OnNavigationPropertyChanged("VATInvoiceRequestLines");
                }
            }
        }
        private TrackableCollection<VATInvoiceRequestLine> _vATInvoiceRequestLines;
    
        [DataMember]
        public TrackableCollection<BusinessPartner> BusinessPartners
        {
            get
            {
                if (_businessPartners == null)
                {
                    _businessPartners = new TrackableCollection<BusinessPartner>();
                    _businessPartners.CollectionChanged += FixupBusinessPartners;
                }
                return _businessPartners;
            }
            set
            {
                if (!ReferenceEquals(_businessPartners, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_businessPartners != null)
                    {
                        _businessPartners.CollectionChanged -= FixupBusinessPartners;
                    }
                    _businessPartners = value;
                    if (_businessPartners != null)
                    {
                        _businessPartners.CollectionChanged += FixupBusinessPartners;
                    }
                    OnNavigationPropertyChanged("BusinessPartners");
                }
            }
        }
        private TrackableCollection<BusinessPartner> _businessPartners;

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
            Document = null;
            ApprovalStages.Clear();
            ApprovalConditions.Clear();
            Quotas.Clear();
            Deliveries.Clear();
            PaymentRequests.Clear();
            VATInvoiceRequestLines.Clear();
            BusinessPartners.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupDocument(Document previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Approvals.Contains(this))
            {
                previousValue.Approvals.Remove(this);
            }
    
            if (Document != null)
            {
                if (!Document.Approvals.Contains(this))
                {
                    Document.Approvals.Add(this);
                }
    
                DocumentId = Document.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Document")
                    && (ChangeTracker.OriginalValues["Document"] == Document))
                {
                    ChangeTracker.OriginalValues.Remove("Document");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Document", previousValue);
                }
                if (Document != null && !Document.ChangeTracker.ChangeTrackingEnabled)
                {
                    Document.StartTracking();
                }
            }
        }
    
        private void FixupApprovalStages(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ApprovalStage item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ApprovalStages", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ApprovalStage item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ApprovalStages", item);
                    }
                }
            }
        }
    
        private void FixupApprovalConditions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ApprovalCondition item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ApprovalConditions", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ApprovalCondition item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ApprovalConditions", item);
                    }
                }
            }
        }
    
        private void FixupQuotas(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Quota item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Quotas", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Quota item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Quotas", item);
                    }
                }
            }
        }
    
        private void FixupDeliveries(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Delivery item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Deliveries", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Delivery item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Deliveries", item);
                    }
                }
            }
        }
    
        private void FixupPaymentRequests(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (PaymentRequest item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("PaymentRequests", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PaymentRequest item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("PaymentRequests", item);
                    }
                }
            }
        }
    
        private void FixupVATInvoiceRequestLines(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (VATInvoiceRequestLine item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("VATInvoiceRequestLines", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (VATInvoiceRequestLine item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("VATInvoiceRequestLines", item);
                    }
                }
            }
        }
    
        private void FixupBusinessPartners(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (BusinessPartner item in e.NewItems)
                {
                    item.Approval = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("BusinessPartners", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (BusinessPartner item in e.OldItems)
                {
                    if (ReferenceEquals(item.Approval, this))
                    {
                        item.Approval = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("BusinessPartners", item);
                    }
                }
            }
        }

        #endregion

    }
}
