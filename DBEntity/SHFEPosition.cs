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
    [KnownType(typeof(Commodity))]
    [KnownType(typeof(SHFE))]
    [KnownType(typeof(SHFECapitalDetail))]
    [KnownType(typeof(HedgeLineSHFEPosition))]
    public partial class SHFEPosition: IObjectWithChangeTracker, INotifyPropertyChanged, IEntity
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
        public Nullable<decimal> LotQuantity
        {
            get { return _lotQuantity; }
            set
            {
                if (_lotQuantity != value)
                {
                    _lotQuantity = value;
                    OnPropertyChanged("LotQuantity");
                }
            }
        }
        private Nullable<decimal> _lotQuantity;
    
        [DataMember]
        public Nullable<decimal> Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        private Nullable<decimal> _price;
    
        [DataMember]
        public Nullable<int> CommodityId
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
        private Nullable<int> _commodityId;
    
        [DataMember]
        public Nullable<int> SHFEId
        {
            get { return _sHFEId; }
            set
            {
                if (_sHFEId != value)
                {
                    ChangeTracker.RecordOriginalValue("SHFEId", _sHFEId);
                    if (!IsDeserializing)
                    {
                        if (SHFE != null && SHFE.Id != value)
                        {
                            SHFE = null;
                        }
                    }
                    _sHFEId = value;
                    OnPropertyChanged("SHFEId");
                }
            }
        }
        private Nullable<int> _sHFEId;
    
        [DataMember]
        public Nullable<int> OpenClose
        {
            get { return _openClose; }
            set
            {
                if (_openClose != value)
                {
                    _openClose = value;
                    OnPropertyChanged("OpenClose");
                }
            }
        }
        private Nullable<int> _openClose;
    
        [DataMember]
        public Nullable<int> PositionDirection
        {
            get { return _positionDirection; }
            set
            {
                if (_positionDirection != value)
                {
                    _positionDirection = value;
                    OnPropertyChanged("PositionDirection");
                }
            }
        }
        private Nullable<int> _positionDirection;
    
        [DataMember]
        public Nullable<int> PositionType
        {
            get { return _positionType; }
            set
            {
                if (_positionType != value)
                {
                    _positionType = value;
                    OnPropertyChanged("PositionType");
                }
            }
        }
        private Nullable<int> _positionType;
    
        [DataMember]
        public Nullable<decimal> Commission
        {
            get { return _commission; }
            set
            {
                if (_commission != value)
                {
                    _commission = value;
                    OnPropertyChanged("Commission");
                }
            }
        }
        private Nullable<decimal> _commission;
    
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
        public Nullable<int> SHFECapitalDetailsId
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
        private Nullable<int> _sHFECapitalDetailsId;
    
        [DataMember]
        public Nullable<System.DateTime> PromptDate
        {
            get { return _promptDate; }
            set
            {
                if (_promptDate != value)
                {
                    _promptDate = value;
                    OnPropertyChanged("PromptDate");
                }
            }
        }
        private Nullable<System.DateTime> _promptDate;
    
        [DataMember]
        public Nullable<decimal> HedgedLotQuantity
        {
            get { return _hedgedLotQuantity; }
            set
            {
                if (_hedgedLotQuantity != value)
                {
                    _hedgedLotQuantity = value;
                    OnPropertyChanged("HedgedLotQuantity");
                }
            }
        }
        private Nullable<decimal> _hedgedLotQuantity = 0m;
    
        [DataMember]
        public Nullable<decimal> PNL
        {
            get { return _pNL; }
            set
            {
                if (_pNL != value)
                {
                    _pNL = value;
                    OnPropertyChanged("PNL");
                }
            }
        }
        private Nullable<decimal> _pNL;
    
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

        #endregion

        #region Navigation Properties
    
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
    
        [DataMember]
        public SHFE SHFE
        {
            get { return _sHFE; }
            set
            {
                if (!ReferenceEquals(_sHFE, value))
                {
                    var previousValue = _sHFE;
                    _sHFE = value;
                    FixupSHFE(previousValue);
                    OnNavigationPropertyChanged("SHFE");
                }
            }
        }
        private SHFE _sHFE;
    
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
            Commodity = null;
            SHFE = null;
            SHFECapitalDetail = null;
            HedgeLineSHFEPositions.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCommodity(Commodity previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SHFEPositions.Contains(this))
            {
                previousValue.SHFEPositions.Remove(this);
            }
    
            if (Commodity != null)
            {
                if (!Commodity.SHFEPositions.Contains(this))
                {
                    Commodity.SHFEPositions.Add(this);
                }
    
                CommodityId = Commodity.Id;
            }
            else if (!skipKeys)
            {
                CommodityId = null;
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
    
        private void FixupSHFE(SHFE previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SHFEPositions.Contains(this))
            {
                previousValue.SHFEPositions.Remove(this);
            }
    
            if (SHFE != null)
            {
                if (!SHFE.SHFEPositions.Contains(this))
                {
                    SHFE.SHFEPositions.Add(this);
                }
    
                SHFEId = SHFE.Id;
            }
            else if (!skipKeys)
            {
                SHFEId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SHFE")
                    && (ChangeTracker.OriginalValues["SHFE"] == SHFE))
                {
                    ChangeTracker.OriginalValues.Remove("SHFE");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SHFE", previousValue);
                }
                if (SHFE != null && !SHFE.ChangeTracker.ChangeTrackingEnabled)
                {
                    SHFE.StartTracking();
                }
            }
        }
    
        private void FixupSHFECapitalDetail(SHFECapitalDetail previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SHFEPositions.Contains(this))
            {
                previousValue.SHFEPositions.Remove(this);
            }
    
            if (SHFECapitalDetail != null)
            {
                if (!SHFECapitalDetail.SHFEPositions.Contains(this))
                {
                    SHFECapitalDetail.SHFEPositions.Add(this);
                }
    
                SHFECapitalDetailsId = SHFECapitalDetail.Id;
            }
            else if (!skipKeys)
            {
                SHFECapitalDetailsId = null;
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
                    item.SHFEPosition = this;
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
                    if (ReferenceEquals(item.SHFEPosition, this))
                    {
                        item.SHFEPosition = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HedgeLineSHFEPositions", item);
                    }
                }
            }
        }

        #endregion

    }
}