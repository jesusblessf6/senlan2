using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityTypeServiceReference;
using Client.CountryServiceReference;
using Client.DeliveryLineServiceReference;
using Client.SpecificationServiceReference;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Deliveries
{
    public class DeliveryLineVM : BaseVM
    {
        #region Member

        private List<DeliveryLine> _addedDeliveryLines = new List<DeliveryLine>();
        private int? _brandId; //品牌
        private List<Brand> _brands;
        private string _comment;
        private Commodity _commodity;
        private int? _commodityId;
        private int? _commodityTypeId;
        private List<CommodityType> _commodityTypes;
        private List<Country> _countries;
        private Country _country;
        private int? _countryId; //原产地
        private DeliveryLine _currentDeliveryLine;
        private List<DeliveryLine> _deliveryLines = new List<DeliveryLine>();

        private int _deliveryStatus; //货运状态
        private decimal? _grossWeight; //毛重
        private int _id;
        private bool _isVerified; //实际数量是否确认
        private int? _lcId;
        private decimal? _netWeight; //净重
        private string _pbNo;
        private decimal? _packingQuantity; //捆数
        private int? _paymentRequestId;
        private int? _specificationId; //规格
        private List<Specification> _specifications;
        private Dictionary<string, int> _statusTypes;

        private List<DeliveryLine> _updatedDeliveryLines = new List<DeliveryLine>();
        private decimal? _verifiedWeight; //实际重量
        private bool _startStatus;
        private bool? _dlvLineIsVerified;

        private decimal? _tempUnitPrice;//暂定价


        #region 提货人列表维护

        private List<WarehouseOutDeliveryPerson> _addDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _allDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _deleteDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _updateDeliveryPersonList;

        #endregion

        private int _oldID;
        private int? _fDPLineId;
        #endregion

        #region Property
        public decimal? TempUnitPrice
        {
            get { return _tempUnitPrice; }
            set {
                if (_tempUnitPrice != value)
                {
                    _tempUnitPrice = value;
                    Notify("TempUnitPrice");
                }
            }
        }

        public int OldID
        {
            get { return _oldID; }
            set { 
                if(_oldID != value)
                {
                    _oldID = value;
                    Notify("OldID");
                }
            }
        }

        public DeliveryType DeliveryType { get; set; }

        public List<WarehouseOutDeliveryPerson> AllDeliveryPersonList
        {
            get { return _allDeliveryPersonList; }
            set
            {
                if (_allDeliveryPersonList != value)
                {
                    _allDeliveryPersonList = value;
                    Notify("AllDeliveryPersonList");
                }
            }
        }

        public List<WarehouseOutDeliveryPerson> DeleteDeliveryPersonList
        {
            get { return _deleteDeliveryPersonList; }
            set
            {
                if (_deleteDeliveryPersonList != value)
                {
                    _deleteDeliveryPersonList = value;
                    Notify("DeleteDeliveryPersonList");
                }
            }
        }

        public List<WarehouseOutDeliveryPerson> UpdateDeliveryPersonList
        {
            get { return _updateDeliveryPersonList; }
            set
            {
                if (_updateDeliveryPersonList != value)
                {
                    _updateDeliveryPersonList = value;
                    Notify("UpdateDeliveryPersonList");
                }
            }
        }

        public List<WarehouseOutDeliveryPerson> AddDeliveryPersonList
        {
            get { return _addDeliveryPersonList; }
            set
            {
                if (_addDeliveryPersonList != value)
                {
                    _addDeliveryPersonList = value;
                    Notify("AddDeliveryPersonList");
                }
            }
        }

        /// <summary>
        /// 提单行
        /// </summary>
        public bool? DlvLineIsVerified
        {
            get { return _dlvLineIsVerified; }
            set
            {
                if (_dlvLineIsVerified != value)
                {
                    _dlvLineIsVerified = value;
                    Notify("DlvLineIsVerified");
                }
            }
        }

        /// <summary>
        /// 提单行
        /// </summary>
        public List<DeliveryLine> DeliveryLines
        {
            get { return _deliveryLines; }
            set
            {
                if (_deliveryLines != value)
                {
                    _deliveryLines = value;
                    Notify("DeliveryLines");
                }
            }
        }

        /// <summary>
        /// 新增的提单行列表
        /// </summary>
        public List<DeliveryLine> AddedDeliveryLines
        {
            get { return _addedDeliveryLines; }
            set
            {
                if (_addedDeliveryLines != value)
                {
                    _addedDeliveryLines = value;
                    Notify("AddedDeliveryLines");
                }
            }
        }

        /// <summary>
        /// 编辑的提单行列表
        /// </summary>
        public List<DeliveryLine> UpdatedDeliveryLines
        {
            get { return _updatedDeliveryLines; }
            set
            {
                if (_updatedDeliveryLines != value)
                {
                    _updatedDeliveryLines = value;
                    Notify("UpdatedDeliveryLines");
                }
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public Dictionary<string, int> StatusTypes
        {
            get { return _statusTypes; }
            set
            {
                if (_statusTypes != value)
                {
                    _statusTypes = value;
                    Notify("StatusTypes");
                }
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    Notify("Id");
                }
            }
        }

        public int? LCId
        {
            get { return _lcId; }
            set
            {
                if (_lcId != value)
                {
                    _lcId = value;
                    Notify("LCId");
                }
            }
        }

        public int? PaymentRequestId
        {
            get { return _paymentRequestId; }
            set
            {
                if (_paymentRequestId != value)
                {
                    _paymentRequestId = value;
                    Notify("PaymentRequestId");
                }
            }
        }

        public DeliveryLine CurrentDeliveryLine
        {
            get { return _currentDeliveryLine; }
            set
            {
                if (_currentDeliveryLine != value)
                {
                    _currentDeliveryLine = value;
                    Notify("CurrentDeliveryLine");
                }
            }
        }

        public string PBNo
        {
            get { return _pbNo; }
            set
            {
                if (_pbNo != value)
                {
                    _pbNo = value;
                    Notify("PBNo");
                }
            }
        }

        public decimal? NetWeight
        {
            get
            {
                if(_netWeight!=null)
                {
                    return Math.Round((decimal)_netWeight, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                }
                
                return null;
            }
            set
            {
                if (_netWeight != value)
                {
                    _netWeight = value;
                    Notify("NetWeight");
                }
            }
        }

        public decimal? VerifiedWeight
        {
            get
            {
                if(_verifiedWeight!=null)
                {
                    return Math.Round((decimal)_verifiedWeight, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                }

                return null;
            }
            set
            {
                if (_verifiedWeight != value)
                {
                    _verifiedWeight = value;
                    Notify("VerifiedWeight");
                }
            }
        }

        public decimal? GrossWeight
        {
            get
            {
                if(_grossWeight!=null)
                {
                    return Math.Round((decimal)_grossWeight, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                }
                
                return null;
            }
            set
            {
                if (_grossWeight != value)
                {
                    _grossWeight = value;
                    Notify("GrossWeight");
                }
            }
        }

        public decimal? PackingQuantity
        {
            get
            {
                if (_packingQuantity.HasValue)
                {
                    return Math.Round((decimal)_packingQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                }
                
                return _packingQuantity;
            }
            set
            {
                if (_packingQuantity != value)
                {
                    _packingQuantity = value;
                    Notify("PackingQuantity");
                }
            }
        }

        public int? CountryId
        {
            get { return _countryId; }
            set
            {
                if (_countryId != value)
                {
                    _countryId = value;
                    Notify("CountryId");
                }
            }
        }

        public Commodity Commodity
        {
            get { return _commodity; }
            set
            {
                if (_commodity != value)
                {
                    _commodity = value;
                    Notify("CommodityId");
                }
            }
        }

        public int? CommodityId
        {
            get { return _commodityId; }
            set
            {
                if (_commodityId != value)
                {
                    _commodityId = value;
                    Notify("CommodityId");
                }
            }
        }

        public int? CommodityTypeId
        {
            get { return _commodityTypeId; }
            set
            {
                if (_commodityTypeId != value)
                {
                    _commodityTypeId = value;
                    Notify("CommodityTypeId");
                }
            }
        }

        public int? BrandId
        {
            get { return _brandId; }
            set
            {
                if (_brandId != value)
                {
                    _brandId = value;
                    Notify("BrandId");
                }
            }
        }

        public int? SpecificationId
        {
            get { return _specificationId; }
            set
            {
                if (_specificationId != value)
                {
                    _specificationId = value;
                    Notify("SpecificationId");
                }
            }
        }

        public Country Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    Notify("Country");
                }
            }
        }

        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                if (_countries != value)
                {
                    _countries = value;
                    Notify("Countries");
                }
            }
        }

        public List<Brand> Brands
        {
            get { return _brands; }
            set
            {
                if (_brands != value)
                {
                    _brands = value;
                    Notify("Brands");
                }
            }
        }

        public List<Specification> Specifications
        {
            get { return _specifications; }
            set
            {
                if (_specifications != value)
                {
                    _specifications = value;
                    Notify("Specifications");
                }
            }
        }

        public List<CommodityType> CommodityTypes
        {
            get { return _commodityTypes; }
            set
            {
                if (_commodityTypes != value)
                {
                    _commodityTypes = value;
                    Notify("CommodityTypes");
                }
            }
        }

        public bool IsVerified
        {
            get { return _isVerified; }
            set
            {
                if (_isVerified != value)
                {
                    _isVerified = value;
                    Notify("IsVerified");
                }
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
                }
            }
        }

        /// <summary>
        /// 货运状态
        /// </summary>
        public int DeliveryStatus
        {
            get { return _deliveryStatus; }
            set
            {
                if (_deliveryStatus != value)
                {
                    _deliveryStatus = value;
                    Notify("DeliveryStatus");
                }
            }
        }

        #endregion

        #region Constructor

        public DeliveryLineVM(DeliveryLine deliveryLine, Commodity commodity)
        {
            AllDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            AddDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            UpdateDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            DeleteDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();

            Id = deliveryLine.Id;
            CurrentDeliveryLine = deliveryLine;
            Commodity = commodity;
            CommodityId = commodity.Id;
            PBNo = deliveryLine.PBNo;
            NetWeight = deliveryLine.NetWeight;
            GrossWeight = deliveryLine.GrossWeight;
            VerifiedWeight = deliveryLine.VerifiedWeight;
            CountryId = deliveryLine.CountryId;
            Country = deliveryLine.Country;
            BrandId = deliveryLine.BrandId;
            PackingQuantity = deliveryLine.PackingQuantity;
            IsVerified = deliveryLine.IsVerified;
            DlvLineIsVerified = deliveryLine.IsVerified;
            Comment = deliveryLine.Comment;
            DeliveryStatus = deliveryLine.DeliveryStatus?1:0;
            _fDPLineId = deliveryLine.FDPLineId;

            _startStatus = true;
            LoadCommodityType();
            LoadBrandAndSpecification();
            LoadCountry();
            LoadStatus();
            LoadDocumentLineEnableProperty(Id);
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BrandId")
            {
                Country country = GetCountryByBrandId(Convert.ToInt32(BrandId ?? 0));
                if (country != null)
                {
                    CountryId = country.Id;
                }
                else
                {
                    CountryId = null;
                }
            }
            if (e.PropertyName == "NetWeight")
            {
                if (DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW ||
                    DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
                {
                    GrossWeight = NetWeight;
                }
                else
                {
                    VerifiedWeight = NetWeight;
                }
            }
        }

        public DeliveryLineVM(Commodity commodity, CommodityType commodityType, Brand brand, Specification specification,
                              List<DeliveryLine> deliveryLines, List<DeliveryLine> addDeliveryLines,DeliveryType deliveryType,decimal? qty)
        {
            ObjectId = 0;
            DeliveryType = deliveryType;
            AllDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            AddDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            DeliveryLines = deliveryLines;
            AddedDeliveryLines = addDeliveryLines;
            Commodity = commodity;
            CommodityId = commodity.Id;
            CommodityTypeId = commodityType.Id;
            _brandId = brand == null ? 0 : brand.Id;

            SpecificationId = specification == null ? 0 : specification.Id;

            _startStatus = true;
            LoadCommodityType();

            LoadCountry();
            LoadStatus();
            LoadDocumentLineEnableProperty(ObjectId);

            if (deliveryLines == null || deliveryLines.Count == 0)
            { 
                //第一次新增
                if (deliveryType == DeliveryType.ExternalTDBOL || deliveryType == DeliveryType.ExternalTDWW)
                {
                    NetWeight = qty;
                    GrossWeight = qty;
                }
                else if (deliveryType == DeliveryType.InternalTDBOL || deliveryType == DeliveryType.InternalTDWW)
                {
                    NetWeight = qty;
                    VerifiedWeight = qty;
                }
            }
            PropertyChanged += OnPropertyChanged;
        }

        public DeliveryLineVM(int id, Commodity commodity, List<DeliveryLine> deliveryLines,
                              List<DeliveryLine> addDeliveryLines, List<DeliveryLine> updateDeliveryLines,DeliveryType deliveryType)
        {
            ObjectId = id;
            OldID = id;
            DeliveryType = deliveryType;
            DeliveryLines = deliveryLines;
            //SetID(id);
            AllDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            AddDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            UpdateDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            DeleteDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();

            AddedDeliveryLines = addDeliveryLines;
            UpdatedDeliveryLines = updateDeliveryLines;
            Commodity = commodity;
            CommodityId = commodity.Id;
            
            _startStatus = true;
            LoadCommodityType();
            LoadCountry();
            LoadDeliveryLine(GetDeliveryLineFromList(id, deliveryLines));

            LoadStatus();
            LoadDocumentLineEnableProperty(ObjectId);
            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Method

        public void SetID(int objectID)
        {
            using (var deliveryLineService = SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {objectID};
                List<DeliveryLine> lines = deliveryLineService.Select(str, parameters, new List<string> { "Delivery"});
                if(lines.Count > 0)
                {
                    DeliveryLine line = lines[0];
                    if (line.Delivery.DeliveryType != (int)DeliveryType)
                    {
                        ObjectId = 0;
                    }
                }
            }
        }

        private void LoadDeliveryLine(DeliveryLine deliveryLine)
        {
            Id = deliveryLine.Id;
            CurrentDeliveryLine = deliveryLine;
            PBNo = deliveryLine.PBNo;
            NetWeight = deliveryLine.NetWeight;
            GrossWeight = deliveryLine.GrossWeight;
            VerifiedWeight = deliveryLine.VerifiedWeight;
            Country = deliveryLine.Country;
            CountryId = deliveryLine.CountryId;
            BrandId = deliveryLine.BrandId;
            CommodityTypeId = deliveryLine.CommodityTypeId;
            SpecificationId = deliveryLine.SpecificationId;
            PackingQuantity = deliveryLine.PackingQuantity;
            IsVerified = deliveryLine.IsVerified;
            DlvLineIsVerified = deliveryLine.IsVerified;
            Comment = deliveryLine.Comment;
            DeliveryStatus = deliveryLine.DeliveryStatus?1:0;
            _fDPLineId = deliveryLine.FDPLineId;
            AllDeliveryPersonList =
                        deliveryLine.WarehouseOutDeliveryPersons.Where(c => c.IsDeleted == false).ToList();
            if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW 
                || DeliveryType == DeliveryType.InternalTDBOL || DeliveryType == DeliveryType.InternalTDWW)
            { 
                //内贸，有暂定价
                TempUnitPrice = deliveryLine.TempUnitPrice;
            }
        }

        /// <summary>
        /// 加载金属品牌和规格
        /// </summary>
        public void LoadBrandAndSpecification()
        {
            LoadBrand();
            LoadSpecification();
        }

        /// <summary>
        /// 金属类型
        /// </summary>
        public void LoadCommodityType()
        {
            if (CommodityId != null && CommodityId != 0)
            {
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    const string str = "it.CommodityId = @p1";
                    var parameters = new List<object> {CommodityId};
                    CommodityTypes = commodityTypeService.Query(str, parameters);
                    if (!_startStatus)
                    {
                        if (CommodityTypes.Count > 0)
                        {
                            CommodityTypeId = CommodityTypes[0].Id;
                        }
                    }
                }
            }
            else
            {
                CommodityTypes = new List<CommodityType>();
                Brands = new List<Brand>();
                Specifications = new List<Specification>();
            }
        }

        /// <summary>
        /// 金属品牌
        /// </summary>
        private void LoadBrand()
        {
            if (CommodityId != 0 && CommodityTypeId != null)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> {CommodityId, CommodityTypeId};
                    List<Brand> brands = brandService.Query(str, parameters).OrderBy(b => b.Name).ToList();
                    brands.Insert(0, new Brand {Id = 0, Name = ""});
                    if (!_startStatus)
                    {
                        if (brands.Count > 0)
                        {
                            BrandId = brands[0].Id;
                        }
                        else
                        {
                            BrandId = null;
                        }
                    }
                    Brands = brands;
                }
            }
            else
            {
                Brands = new List<Brand>();
            }
        }

        /// <summary>
        /// 金属规格
        /// </summary>
        private void LoadSpecification()
        {
            if (CommodityId != 0 && CommodityTypeId != null)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> {CommodityId, CommodityTypeId};
                    List<Specification> specifications = specificationService.Query(str, parameters).OrderBy(s => s.Name).ToList();
                    specifications.Insert(0, new Specification {Id = 0, Name = ""});
                    if (!_startStatus)
                    {
                        if (specifications.Count > 0)
                        {
                            SpecificationId = specifications[0].Id;
                        }
                        else
                        {
                            SpecificationId = null;
                        }
                    }
                    Specifications = specifications;
                }
            }
            else
            {
                Brands = new List<Brand>();
            }
            _startStatus = false;
        }

        /// <summary>
        /// 加载原产地
        /// </summary>
        public void LoadCountry()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                Countries = countryService.GetAll();
                Countries.Insert(0, new Country());
            }
        }

        /// <summary>
        /// 加载货运状态
        /// </summary>
        private void LoadStatus()
        {
            StatusTypes = new Dictionary<string, int>();
            StatusTypes = EnumHelper.GetEnumDic<StatusType>(StatusTypes);
        }

        public override bool Validate()
        {
            return true;
        }

        protected override void Create()
        {
            if (DeliveryLines == null)
            {
                DeliveryLines = new List<DeliveryLine>();
            }
            if (AddedDeliveryLines == null)
            {
                AddedDeliveryLines = new List<DeliveryLine>();
            }
            DeliveryLine line = SaveObject();
            DeliveryLines.Add(line);
            AddedDeliveryLines.Add(line);
            if(OldID != ObjectId)
            {
                DeliveryLine oldline = DeliveryLines.Where(c => c.Id == OldID).ToList()[0];
                DeliveryLines.Remove(oldline);
                AddedDeliveryLines.Remove(oldline);
            }
        }

        protected override void Update()
        {
            DeliveryLine line = SaveObject();
            DeliveryLine oldLine = GetDeliveryLineFromList(ObjectId, AddedDeliveryLines);
            if (oldLine != null)
            {
                //新增的
                AddedDeliveryLines.Remove(oldLine);
                AddedDeliveryLines.Add(line);
            }
            else
            {
                //编辑的
                oldLine = GetDeliveryLineFromList(ObjectId, UpdatedDeliveryLines);
                if (oldLine != null)
                {
                    UpdatedDeliveryLines.Remove(oldLine);
                }
                UpdatedDeliveryLines.Add(line);
            }
            oldLine = GetDeliveryLineFromList(ObjectId, DeliveryLines);
            DeliveryLines.Remove(oldLine);
            DeliveryLines.Add(line);
        }

        private DeliveryLine GetDeliveryLineFromList(int id, IEnumerable<DeliveryLine> deliveryLines)
        {
            if (deliveryLines != null)
            {
                return deliveryLines.FirstOrDefault(line => line.Id == id);
            }

            return null;
        }

        private DeliveryLine SaveObject()
        {
            var deliveryLine = new DeliveryLine
                                   {
                                       Id = ObjectId == 0 ? GetDeliveryLineId() : Id,
                                       BrandId = BrandId,
                                       CommodityTypeId = CommodityTypeId,
                                       SpecificationId = SpecificationId,
                                       CountryId = CountryId,
                                       GrossWeight = (GrossWeight ?? 0),
                                       NetWeight = (NetWeight ?? 0),
                                       VerifiedWeight = (VerifiedWeight ?? 0),
                                       IsVerified = IsVerified,
                                       DlvLineIsVerified=IsVerified,
                                       PackingQuantity = (PackingQuantity ?? 0),
                                       PBNo = PBNo,
                                       Comment = Comment,
                                       DeliveryStatus = (DeliveryStatus==1),
                                       FDPLineId = _fDPLineId,
                                       Country = CountryId == null ? null : GetCountryById((int) CountryId)
                                   };
            if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW
                || DeliveryType == DeliveryType.InternalTDBOL || DeliveryType == DeliveryType.InternalTDWW)
            {
                //内贸，有暂定价
                deliveryLine.TempUnitPrice = TempUnitPrice;
            }

            if (BrandId.HasValue)
                deliveryLine.Brand = GetBrandById((int) BrandId);
            if (CommodityTypeId.HasValue)
                deliveryLine.CommodityType = GetCommodityTypeById((int) CommodityTypeId);
            if (SpecificationId.HasValue)
                deliveryLine.Specification = GetSpecificationById((int) SpecificationId);
            deliveryLine.CommodityType.Commodity = Commodity;
            if (CountryId.HasValue)
            {
                deliveryLine.Country = GetCountryById(CountryId.Value);
            }
            //提货人信息
            deliveryLine.WarehouseOutDeliveryPersons.Clear();
            foreach (WarehouseOutDeliveryPerson deliveryPerson in AllDeliveryPersonList)
            {
                deliveryLine.WarehouseOutDeliveryPersons.Add(deliveryPerson);
            }

            return deliveryLine;
        }

        private Country GetCountryById(int id)
        {
            Country country;
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                country = countryService.GetById(id);
            }
            return country;
        }

        private int GetDeliveryLineId()
        {
            if (DeliveryLines.Count == 0)
                return -1;
            int max = 0;
            foreach (var line in DeliveryLines)
            {
                if(line.Id == -Int32.MaxValue)
                {
                    continue;
                }
                int id = line.Id;
                if (id < 0)
                    id = -id;
                if (id > max)
                    max = id;
            }
            return -(max+1);
            //IEnumerable<int> query = from deliveryLine in DeliveryLines select Math.Abs(deliveryLine.Id);
            //int no = query.Max();
            //return -(no + 1);
        }

        private Brand GetBrandById(int id)
        {
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                return brandService.GetById(id);
            }
        }

        public Country GetCountryByBrandId(int id)
        {
            Brand brand = GetBrandById(id);
            if (brand == null)
            {
                return null;
            }
            return GetCountryById(Convert.ToInt32(brand.CountryId ?? 0));
        }


        private CommodityType GetCommodityTypeById(int id)
        {
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                return commodityTypeService.GetById(id);
            }
        }

        private Specification GetSpecificationById(int id)
        {
            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                return specificationService.GetById(id);
            }
        }

        #endregion

        #region 提单行编辑逻辑

        private bool _isNetWeightEnable;
        private bool _isVerifiedQuantityEnable;
        private bool _isSpecificationEnable;
        private bool _isBrandEnable;
        private bool _isCommodityTypeEnable;

        public bool IsVerifiedQuantityEnable
        {
            get { return _isVerifiedQuantityEnable; }
            set
            {
                if (_isVerifiedQuantityEnable != value)
                {
                    _isVerifiedQuantityEnable = value;
                    Notify("IsVerifiedQuantityEnable");
                }
            }
        }

        public bool IsNetWeightEnable
        {
            get { return _isNetWeightEnable; }
            set
            {
                if (_isNetWeightEnable != value)
                {
                    _isNetWeightEnable = value;
                    Notify("IsNetWeightEnable");
                }
            }
        }

        public bool IsSpecificationEnable
        {
            get { return _isSpecificationEnable; }
            set
            {
                if (_isSpecificationEnable != value)
                {
                    _isSpecificationEnable = value;
                    Notify("IsSpecificationEnable");
                }
            }
        }

        public bool IsBrandEnable
        {
            get { return _isBrandEnable; }
            set
            {
                if (_isBrandEnable != value)
                {
                    _isBrandEnable = value;
                    Notify("IsBrandEnable");
                }
            }
        }

        public bool IsCommodityTypeEnable
        {
            get { return _isCommodityTypeEnable; }
            set
            {
                if (_isCommodityTypeEnable != value)
                {
                    _isCommodityTypeEnable = value;
                    Notify("IsCommodityTypeEnable");
                }
            }
        }

        private void LoadDocumentLineEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsNetWeightEnable = true;
                IsVerifiedQuantityEnable = true;
                IsBrandEnable = true;
                IsSpecificationEnable = true;
                IsCommodityTypeEnable = true;
            }
            else
            {
                using (var deliveryLineService =
                    SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
                {
                    DeliveryLineEnableProperty dlep = deliveryLineService.SetElementsEnableProperty(id);
                    IsNetWeightEnable = dlep.IsNetWeightEnable;
                    IsVerifiedQuantityEnable = dlep.IsVerifiedQuantityEnable;
                    IsSpecificationEnable = dlep.IsSpecificationEnable;
                    IsBrandEnable = dlep.IsBrandEnable;
                    IsCommodityTypeEnable = dlep.IsCommodityTypeEnable;
                }
            }
        }

        #endregion

        #region 删除提货人
        public void DelDeliveryPerson(int deliveryPersonID)
        {
            if (AllDeliveryPersonList.Count > 0)
            {
                List<WarehouseOutDeliveryPerson> list =
                    AllDeliveryPersonList.Where(c => c.Id == deliveryPersonID).ToList();

                if (list.Count > 0)
                {
                    WarehouseOutDeliveryPerson deliveryPerson = list[0];
                    AllDeliveryPersonList.Remove(deliveryPerson);
                    if (deliveryPersonID > 0)
                    {
                        var newDeliveryPerson = new WarehouseOutDeliveryPerson
                        {
                            Id = deliveryPerson.Id,
                            Name = deliveryPerson.Name,
                            IdentityCard = deliveryPerson.IdentityCard,
                            IsDeleted = true,
                            VehicleNo = deliveryPerson.VehicleNo,
                            DeliveryQuantity = deliveryPerson.DeliveryQuantity,
                            WarehouseOutLineId = deliveryPerson.WarehouseOutLineId
                        };
                        AllDeliveryPersonList.Add(newDeliveryPerson);
                        UpdateDeliveryPersonList.Add(newDeliveryPerson);
                    }
                    else
                    {
                        AddDeliveryPersonList.Remove(deliveryPerson);
                    }
                }
            }
        }
        #endregion
    }
}
