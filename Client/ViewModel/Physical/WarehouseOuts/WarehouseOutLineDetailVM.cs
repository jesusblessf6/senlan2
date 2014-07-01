using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityServiceReference;
using Client.CommodityTypeServiceReference;
using Client.QuotaServiceReference;
using Client.SpecificationServiceReference;
using Client.WarehouseInLineServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using Client.WarehouseOutLineServiceReference;
using DBEntity.EnableProperty;
using System.ComponentModel;

namespace Client.ViewModel.Physical.WarehouseOuts
{
    public class WarehouseOutLineDetailVM : BaseVM
    {
        #region Member

        private List<WarehouseOutLine> _addWarehouseOutLines;
        private int _brandId;
        private List<Brand> _brands;
        private string _comment;
        private int _commodityId;
        private string _commodityName;
        private int _commodityTypeId;
        private List<CommodityType> _commodityTypes;
        private int _internalCustomerID;
        private bool _isPBClear;
        private bool _isVerified;
        private string _pbNo;
        private decimal? _packingQuantity;
        private decimal? _quantity;
        private int _specificationId;
        private List<Specification> _specifications;
        private List<WarehouseOutLine> _updateWarehouseOutLines;
        private decimal? _verifiedQuantity;

        private int _warehouseId;
        private WarehouseInLine _warehouseInLine;
        private int _warehouseInLineId;
        private List<WarehouseInLine> _warehouseInLines;
        private int? _warehouseOutLineId;
        private List<WarehouseOutLine> _warehouseOutLines;

        #region 提货人列表维护

        private List<WarehouseOutDeliveryPerson> _addDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _allDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _deleteDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _updateDeliveryPersonList;

        #endregion

        #endregion

        #region Property

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

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                if (_warehouseId != value)
                {
                    _warehouseId = value;
                    Notify("WarehouseId");
                }
            }
        }

        public int InternalCustomerID
        {
            get { return _internalCustomerID; }
            set
            {
                if (_internalCustomerID != value)
                {
                    _internalCustomerID = value;
                    Notify("InternalCustomerID");
                }
            }
        }

        public List<WarehouseOutLine> UpdateWarehouseOutLines
        {
            get { return _updateWarehouseOutLines; }
            set
            {
                if (_updateWarehouseOutLines != value)
                {
                    _updateWarehouseOutLines = value;
                    Notify("UpdateWarehouseOutLines");
                }
            }
        }

        public List<WarehouseOutLine> AddWarehouseOutLines
        {
            get { return _addWarehouseOutLines; }
            set
            {
                if (_addWarehouseOutLines != value)
                {
                    _addWarehouseOutLines = value;
                    Notify("AddWarehouseOutLines");
                }
            }
        }

        public bool IsPBClear
        {
            get { return _isPBClear; }
            set
            {
                if (_isPBClear != value)
                {
                    _isPBClear = value;
                    Notify("IsPBClear");
                }
            }
        }

        public List<WarehouseInLine> WarehouseInLines
        {
            get { return _warehouseInLines; }
            set
            {
                if (_warehouseInLines != value)
                {
                    _warehouseInLines = value;
                    Notify("WarehouseInLines");
                }
            }
        }

        public WarehouseInLine WarehouseInLine
        {
            get { return _warehouseInLine; }
            set
            {
                if (_warehouseInLine != value)
                {
                    _warehouseInLine = value;
                    Notify("WarehouseInLine");
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

        public decimal? VerifiedQuantity
        {
            get { return _verifiedQuantity; }
            set
            {
                if (_verifiedQuantity != value)
                {
                    _verifiedQuantity = value;
                    Notify("VerifiedQuantity");
                }
            }
        }

        public decimal? Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    Notify("Quantity");
                }
            }
        }

        public decimal? PackingQuantity
        {
            get { return _packingQuantity; }
            set
            {
                if (_packingQuantity != value)
                {
                    _packingQuantity = value;
                    Notify("PackingQuantity");
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

        public int? WarehouseOutLineId
        {
            get { return _warehouseOutLineId; }
            set
            {
                if (_warehouseOutLineId != value)
                {
                    if (_warehouseOutLineId != value)
                    {
                        _warehouseOutLineId = value;
                        Notify("WarehouseOutLineId");
                    }
                }
            }
        }

        public List<WarehouseOutLine> WarehouseOutLines
        {
            get { return _warehouseOutLines; }
            set
            {
                if (_warehouseOutLines != value)
                {
                    _warehouseOutLines = value;
                    Notify("WarehouseOutLines");
                }
            }
        }

        public int BrandId
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

        public int SpecificationId
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

        public int CommodityTypeId
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

        public int CommodityId
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

        public string CommodityName
        {
            get { return _commodityName; }
            set
            {
                if (_commodityName != value)
                {
                    _commodityName = value;
                    Notify("CommodityName");
                }
            }
        }

        public int WarehouseInLineId
        {
            get { return _warehouseInLineId; }
            set
            {
                if (_warehouseInLineId != value)
                {
                    _warehouseInLineId = value;
                    Notify("WarehouseInLineId");
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

        #endregion

        #region Constructor

        public WarehouseOutLineDetailVM(int quotaId, List<WarehouseOutLine> lines, List<WarehouseInLine> inLines,
                                  List<WarehouseOutLine> addLines, int internalCustomerID, int warehouseId)
        {
            ObjectId = 0;
            AllDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            AddDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            PropertyChanged += OnPropertyChanged;
            InternalCustomerID = internalCustomerID;
            WarehouseId = warehouseId;
            WarehouseOutLines = lines;
            WarehouseInLines = inLines;
            AddWarehouseOutLines = addLines;
            LoadAddMessage(quotaId);
            Load();
            LoadWarehouseOutLineEnableProperty(ObjectId);
        }

        public WarehouseOutLineDetailVM(int commodityId, int warehouseOutLineId, List<WarehouseOutLine> lines,
                                  List<WarehouseOutLine> addLines, List<WarehouseOutLine> updateLines,
                                  List<WarehouseInLine> inLines, int internalCustomerID, int warehouseId)
        {
            ObjectId = warehouseOutLineId;
            AllDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            AddDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            UpdateDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            DeleteDeliveryPersonList = new List<WarehouseOutDeliveryPerson>();
            PropertyChanged += OnPropertyChanged;
            InternalCustomerID = internalCustomerID;
            WarehouseId = warehouseId;
            WarehouseOutLines = lines;
            CommodityId = commodityId;
            AddWarehouseOutLines = addLines;
            UpdateWarehouseOutLines = updateLines;
            WarehouseInLines = inLines;
            LoadWarehouseOutLine();
            Load();
            LoadWarehouseOutLineEnableProperty(ObjectId);
        }

        public void Load()
        {
            LoadCommodity(CommodityId);
            LoadCommodityType();
            LoadBrandAndSpecification();
        }

        #endregion

        #region Method
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Quantity")
            {
                SetVerQty();
            }
            if (e.PropertyName == "CommodityTypeId")
            {
                LoadBrandAndSpecification();
            }
        }

        public void LoadAddMessage(int quotaId)
        {
            if (quotaId > 0)
            {
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    Quota quota = quotaService.GetById(quotaId);
                    if (quota != null)
                    {
                        CommodityId = quota.CommodityId ?? 0;
                        CommodityTypeId = quota.CommodityTypeId ?? 0;
                        SpecificationId = quota.SpecificationId ?? 0;
                        BrandId = quota.BrandId ?? 0;
                    }
                }
            }
        }

        public void LoadWarehouseOutLine()
        {
            if (ObjectId != 0)
            {
                List<WarehouseOutLine> outLines = WarehouseOutLines.Where(c => c.Id == ObjectId).ToList();
                if (outLines.Count > 0)
                {
                    WarehouseOutLine outLine = outLines[0];
                    WarehouseInLine = outLine.WarehouseInLine;
                    CommodityTypeId = outLine.CommodityTypeId;
                    BrandId = outLine.BrandId;
                    SpecificationId = outLine.SpecificationId;
                    _quantity = outLine.Quantity;
                    VerifiedQuantity = outLine.VerifiedQuantity;
                    IsVerified = Convert.ToBoolean(outLine.IsVerified);
                    Comment = outLine.Comment;
                    PackingQuantity = outLine.PackingQuantity;
                    IsPBClear = outLine.WarehouseInLine.IsPBCleared ?? false;
                    AllDeliveryPersonList =
                        outLine.WarehouseOutDeliveryPersons.Where(c => c.IsDeleted == false).ToList();
                }
            }
        }

        public void GetOnlyQty(int warehouseInLineID)
        {
            //decimal? result = 0;
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> { warehouseInLineID };
                List<WarehouseInLine> warehouseInLines = warehouseInLineService.Select(str, parameters,
                                                                                       new List<string> { "WarehouseOutLines" });
                if (warehouseInLines.Count > 0)
                {
                    WarehouseInLine warehouseInLine = warehouseInLines[0];
                    FilterDeleted(warehouseInLine.WarehouseOutLines);
                    decimal? qty = 0;
                    decimal? verifiedQty = 0;
                    foreach (WarehouseOutLine outLine in warehouseInLine.WarehouseOutLines)
                    {
                        if (!outLine.IsDeleted)
                        {
                            decimal verified = outLine.VerifiedQuantity == null
                                                     ? 0
                                                     : (decimal)outLine.VerifiedQuantity;
                            decimal quantity = outLine.Quantity == null ? 0 : outLine.Quantity.Value;
                            qty += quantity;
                            verifiedQty += verified;
                        }
                    }

                    //result = warehouseInLine.VerifiedQuantity - qty;
                    Quantity = warehouseInLine.Quantity - qty;
                    VerifiedQuantity = warehouseInLine.VerifiedQuantity - verifiedQty;
                }
            }
        }

        public void LoadCommodity(int commodityId)
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commodity commodity = commodityService.GetById(commodityId);
                CommodityId = commodity.Id;
                CommodityName = commodity.Name;
            }
        }

        public void LoadCommodityType()
        {
            if (CommodityId != 0)
            {
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    const string str = "it.CommodityId = @p1";
                    var parameters = new List<object> { CommodityId };
                    CommodityTypes = commodityTypeService.Query(str, parameters);
                    if (CommodityTypes.Count > 0)
                    {
                        if (CommodityTypeId <= 0)
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

        public void LoadBrandAndSpecification()
        {
            LoadBrand();
            LoadSpecification();
        }

        private void LoadBrand()
        {
            if (CommodityId != 0 && CommodityTypeId != 0)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { CommodityId, CommodityTypeId };
                    Brands = brandService.Query(str, parameters).OrderBy(b => b.Name).ToList();
                    if (Brands.Count > 0)
                    {
                        if (BrandId <= 0)
                        {
                            BrandId = Brands[0].Id;
                        }
                        else
                        {
                            if (!Brands.Select(c => c.Id).Contains(BrandId))
                            {
                                BrandId = Brands[0].Id;
                            }
                        }
                    }
                }
            }
            else
            {
                Brands = new List<Brand>();
            }
        }

        private void LoadSpecification()
        {
            if (CommodityId != 0 && CommodityTypeId != 0)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { CommodityId, CommodityTypeId };
                    Specifications = specificationService.Query(str, parameters).OrderBy(s => s.Name).ToList();
                    if (Specifications.Count > 0)
                    {
                        if (SpecificationId <= 0)
                        {
                            SpecificationId = Specifications[0].Id;
                        }
                        else
                        {
                            if (!Specifications.Select(c => c.Id).Contains(SpecificationId))
                            {
                                SpecificationId = Specifications[0].Id;
                            }
                        }
                    }
                }
            }
            else
            {
                Brands = new List<Brand>();
            }
        }

        protected override void Create()
        {
            var line = new WarehouseOutLine();
            if (WarehouseOutLines.Count <= 0)
            {
                line.Id = -1;
            }
            else
            {
                var lineIdList = WarehouseOutLines.Select(lineId => Math.Abs(lineId.Id)).ToList();
                int maxID = lineIdList.Max();
                line.Id = -(maxID + 1);
            }

            line.IsVerified = IsVerified;
            line.PackingQuantity = PackingQuantity;
            line.Quantity = Quantity;
            line.VerifiedQuantity = VerifiedQuantity;
            line.WarehouseInLineId = WarehouseInLineId;
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> { WarehouseInLineId };
                List<WarehouseInLine> inLines = warehouseInLineService.Select(str, parameters,
                                                                              new List<string>
                                                                                  {
                                                                                      "DeliveryLine",
                                                                                      "DeliveryLine.Delivery.Quota.Commodity"
                                                                                  });
                if (inLines.Count > 0)
                {
                    WarehouseInLine inLine = inLines[0];
                    line.WarehouseInLine = inLine;
                }
            }
            line.Comment = Comment;
            line.CommodityTypeId = CommodityTypeId;
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                CommodityType commodityType = commodityTypeService.GetById(CommodityTypeId);
                line.CommodityType = commodityType;
            }

            line.BrandId = BrandId;
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                Brand brand = brandService.GetById(BrandId);
                line.Brand = brand;
            }

            line.SpecificationId = SpecificationId;
            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                Specification specification = specificationService.GetById(SpecificationId);
                line.Specification = specification;
            }

            //提货人信息
            line.WarehouseOutDeliveryPersons.Clear();
            foreach (WarehouseOutDeliveryPerson deliveryPerson in AllDeliveryPersonList)
            {
                line.WarehouseOutDeliveryPersons.Add(deliveryPerson);
            }

            #region 把新增的出库行对应的入库行更改清卡状态后的数据存到list里面

            var newWarehouseInLine = new WarehouseInLine();
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                const string str = "it.Id = @p1";
                var parameter = new List<object> { WarehouseInLineId };
                List<WarehouseInLine> inLines = warehouseInLineService.Select(str, parameter,
                                                                              new List<string>
                                                                                  {
                                                                                      "DeliveryLine.Delivery.Quota.Contract",
                                                                                      "DeliveryLine.Delivery.Quota",
                                                                                      "WarehouseIn",
                                                                                      "DeliveryLine.Delivery",
                                                                                      "DeliveryLine"
                                                                                  });
                if (inLines.Count > 0)
                {
                    newWarehouseInLine = inLines[0];
                    newWarehouseInLine.IsPBCleared = IsPBClear;
                }
            }
            if (WarehouseInLines.Count > 0)
            {
                List<WarehouseInLine> warehouseInLines = WarehouseInLines.Where(c => c.Id == WarehouseInLineId).ToList();
                if (warehouseInLines.Count > 0)
                {
                    WarehouseInLine warehouseInLine = warehouseInLines[0];
                    WarehouseInLines.Remove(warehouseInLine);
                }
            }
            WarehouseInLines.Add(newWarehouseInLine);

            #endregion

            if (ValidateAllLine(WarehouseOutLines, line))
            {
                WarehouseOutLines.Add(line);
                AddWarehouseOutLines.Add(line);
            }
        }

        protected override void Update()
        {
            var outLine = new WarehouseOutLine();
            List<WarehouseOutLine> lines = WarehouseOutLines.Where(c => c.Id == ObjectId).ToList();
            if (lines.Count > 0)
            {
                WarehouseOutLine line = lines[0];
                outLine.Id = line.Id;
                outLine.WarehouseOutId = line.WarehouseOutId;
                outLine.IsVerified = IsVerified;
                outLine.PackingQuantity = PackingQuantity;
                outLine.Quantity = Quantity;
                outLine.VerifiedQuantity = VerifiedQuantity;
                outLine.WarehouseInLineId = WarehouseInLine.Id;
                using (
                    var warehouseInLineService =
                        SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
                {
                    const string str = "it.Id = @p1";
                    var parameters = new List<object> { WarehouseInLine.Id };
                    List<WarehouseInLine> inLines = warehouseInLineService.Select(str, parameters,
                                                                                  new List<string>
                                                                                      {
                                                                                          "DeliveryLine",
                                                                                          "DeliveryLine.Delivery.Quota.Commodity"
                                                                                      });
                    if (inLines.Count > 0)
                    {
                        WarehouseInLine inLine = inLines[0];
                        outLine.WarehouseInLine = inLine;
                    }
                }
                outLine.Comment = Comment;
                outLine.CommodityTypeId = CommodityTypeId;
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    CommodityType commodityType = commodityTypeService.GetById(CommodityTypeId);
                    outLine.CommodityType = commodityType;
                }

                outLine.BrandId = BrandId;
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    Brand brand = brandService.GetById(BrandId);
                    outLine.Brand = brand;
                }

                outLine.SpecificationId = SpecificationId;
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    Specification specification = specificationService.GetById(SpecificationId);
                    outLine.Specification = specification;
                }
                //提货人信息
                outLine.WarehouseOutDeliveryPersons.Clear();
                foreach (WarehouseOutDeliveryPerson deliveryPerson in AllDeliveryPersonList)
                {
                    outLine.WarehouseOutDeliveryPersons.Add(deliveryPerson);
                }

                if (ValidateAllLine(WarehouseOutLines, outLine))
                {

                    #region 更改对应入库单的清卡状态

                    if (line.Id > 0)
                    {
                        using (
                            var warehouseInLineService =
                                SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
                        {
                            var inLine = new WarehouseInLine();
                            const string str = "it.Id = @p1";
                            var parameter = new List<object> { line.WarehouseInLineId };
                            List<WarehouseInLine> inLines = warehouseInLineService.Select(str, parameter,
                                                                                          new List<string>
                                                                                          {
                                                                                              "DeliveryLine.Delivery.Quota.Contract",
                                                                                              "DeliveryLine.Delivery.Quota",
                                                                                              "WarehouseIn",
                                                                                              "DeliveryLine.Delivery",
                                                                                              "DeliveryLine"
                                                                                          });
                            if (inLines.Count > 0)
                            {
                                inLine = inLines[0];
                                inLine.IsPBCleared = IsPBClear;
                            }
                            if (line.WarehouseInLineId == WarehouseInLine.Id)
                            {
                                WarehouseInLines.Add(inLine);
                            }
                            else
                            {
                                const string strQuery = "it.Id = @p1";
                                var parameter1 = new List<object> { WarehouseInLine.Id };
                                List<WarehouseInLine> newLines = warehouseInLineService.Select(strQuery, parameter1,
                                                                                               new List<string>
                                                                                               {
                                                                                                   "DeliveryLine.Delivery.Quota.Contract",
                                                                                                   "DeliveryLine.Delivery.Quota",
                                                                                                   "WarehouseIn",
                                                                                                   "DeliveryLine.Delivery",
                                                                                                   "DeliveryLine"
                                                                                               });
                                if (newLines.Count > 0)
                                {
                                    WarehouseInLine newLine = newLines[0];
                                    newLine.IsPBCleared = IsPBClear;
                                    WarehouseInLines.Add(newLine);
                                }
                                inLine.IsPBCleared = false;
                                WarehouseInLines.Add(inLine);
                            }
                        }
                    }
                    else
                    {
                        List<WarehouseInLine> oldInLines =
                            WarehouseInLines.Where(c => c.Id == line.WarehouseInLineId).ToList();
                        if (oldInLines.Count > 0)
                        {
                            WarehouseInLine oldInLine = oldInLines[0];
                            WarehouseInLines.Remove(oldInLine);
                        }
                        if (WarehouseInLines.Count > 0)
                        {
                            List<WarehouseInLine> inLines = WarehouseInLines.Where(c => c.Id == WarehouseInLine.Id).ToList();
                            if (inLines.Count > 0)
                            {
                                WarehouseInLine inLine = inLines[0];
                                WarehouseInLines.Remove(inLine);
                            }
                        }
                        using (
                            var warehouseInLineService =
                                SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
                        {
                            const string strQuery = "it.Id = @p1";
                            var parameter1 = new List<object> { WarehouseInLine.Id };
                            List<WarehouseInLine> newLines = warehouseInLineService.Select(strQuery, parameter1,
                                                                                           new List<string>
                                                                                           {
                                                                                               "DeliveryLine.Delivery.Quota.Contract",
                                                                                               "DeliveryLine.Delivery.Quota",
                                                                                               "WarehouseIn",
                                                                                               "DeliveryLine.Delivery",
                                                                                               "DeliveryLine"
                                                                                           });
                            if (newLines.Count > 0)
                            {
                                WarehouseInLine newLine = newLines[0];
                                newLine.IsPBCleared = IsPBClear;
                                WarehouseInLines.Add(newLine);
                            }
                        }
                    }

                    #endregion

                    WarehouseOutLines.Remove(line);
                    WarehouseOutLines.Add(outLine);
                    if (line.Id < 0)
                    {
                        if (AddWarehouseOutLines.Count > 0)
                        {
                            List<WarehouseOutLine> addOutLines = AddWarehouseOutLines.Where(c => c.Id == line.Id).ToList();
                            if (addOutLines.Count > 0)
                            {
                                WarehouseOutLine addOutLine = addOutLines[0];
                                AddWarehouseOutLines.Remove(addOutLine);
                                AddWarehouseOutLines.Add(outLine);
                            }
                        }
                    }
                    else
                    {
                        if (UpdateWarehouseOutLines.Count > 0)
                        {
                            List<WarehouseOutLine> updateOutLines =
                                UpdateWarehouseOutLines.Where(c => c.Id == line.Id).ToList();
                            if (updateOutLines.Count > 0)
                            {
                                WarehouseOutLine updateOutLine = updateOutLines[0];
                                UpdateWarehouseOutLines.Remove(updateOutLine);
                            }
                        }
                        UpdateWarehouseOutLines.Add(outLine);
                    }
                }
            }
        }

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
                                                        WarehouseOutLineId = deliveryPerson.WarehouseOutLineId,
                                                        Tel = deliveryPerson.Tel
                                                    };
                        AllDeliveryPersonList.Add(newDeliveryPerson);
                    }
                    else
                    {
                        AddDeliveryPersonList.Remove(deliveryPerson);
                    }
                }
            }
        }

        public override bool Validate()
        {
            if(!Quantity.HasValue)
            {
                throw new Exception("数量不能为空");
            }

            if(!VerifiedQuantity.HasValue)
            {
                throw new Exception("实际数量不能为空");
            }

            if (WarehouseInLine == null)
            {
                throw new Exception(Properties.Resources.PBNoRequired);
            }

            if (CommodityTypeId == 0)
            {
                throw new Exception(Properties.Resources.CommodityTypeRequired);
            }

            if (BrandId == 0)
            {
                throw new Exception(Properties.Resources.BrandRequired);
            }

            if (SpecificationId == 0)
            {
                throw new Exception(Properties.Resources.SpecificationRequired);
            }

            return true;
        }

        private bool ValidateAllLine(List<WarehouseOutLine> lines, WarehouseOutLine line)
        {
            if (lines.Count > 0)
            {
                var listID = new List<int>();
                foreach (WarehouseOutLine outLine in WarehouseOutLines)
                {
                    if (outLine.Id != line.Id)
                    {
                        listID.Add(outLine.WarehouseInLineId);
                    }
                }
                if (listID.Contains(line.WarehouseInLineId))
                {
                    throw new Exception("一个出库项下的多个出库行不能对应相同的入库行！");
                }
            }

            return true;
        }

        public void SetVerQty()
        {
            VerifiedQuantity = Quantity;
        }

        #endregion

        #region 编辑属性

        private bool _isQuantityEnable;
        private bool _isVerifiedQuantityEnable;
        private bool _isClearPBNoEnable;

        public bool IsQuantityEnable
        {
            get { return _isQuantityEnable; }
            set
            {
                if (_isQuantityEnable != value)
                {
                    _isQuantityEnable = value;
                    Notify("IsQuantityEnable");
                }
            }
        }

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

        public bool IsClearPBNoEnable
        {
            get { return _isClearPBNoEnable; }
            set
            {
                if (_isClearPBNoEnable != value)
                {
                    _isClearPBNoEnable = value;
                    Notify("IsClearPBNoEnable");
                }
            }
        }

        private void LoadWarehouseOutLineEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsQuantityEnable = true;
                IsVerifiedQuantityEnable = true;
                IsClearPBNoEnable = true;
            }
            else
            {
                using (var warehouseOutLineService =
                    SvcClientManager.GetSvcClient<WarehouseOutLineServiceClient>(SvcType.WarehouseOutLineSvc))
                {
                    WarehouseOutLineEnableProperty wolep = warehouseOutLineService.SetElementsEnableProperty(id);
                    IsQuantityEnable = wolep.IsQuantityEnable;
                    IsVerifiedQuantityEnable = wolep.IsVerifiedQuantityEnable;
                    IsClearPBNoEnable = wolep.IsClearPBNoEnable;
                }
            }
        }

        #endregion
    }
}