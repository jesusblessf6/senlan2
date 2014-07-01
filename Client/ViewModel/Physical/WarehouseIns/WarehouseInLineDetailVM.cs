using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityTypeServiceReference;
using Client.ContractServiceReference;
using Client.DeliveryLineServiceReference;
using Client.SpecificationServiceReference;
using Client.View.Physical.WarehouseIns;
using Client.WarehouseInLineServiceReference;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.ComponentModel;

namespace Client.ViewModel.Physical.WarehouseIns
{
    public class WarehouseInLineDetailVM : BaseVM
    {
        #region Member

        private int _brandId;
        private string _comment;
        private Commodity _commodity;
        private DeliveryLine _deliveryLine;
        private int _deliveryLineId;
        private string _deliveryNo;
        private DeliveryTypeWarehouseIn _deliveryTypeWarehouseIn;
        private bool _isVerified;
        private List<WarehouseInLine> _lines;
        private string _pbNo;
        private decimal? _packingQuantity;
        private decimal _quantity;
        private int _specificationId;
        private decimal _verifiedQuantity;
        private int _warehouseId;
        private WarehouseIn _warehouseIn;

        private DateTime? _warehouseInDate;
        private int _warehouseInId;
        private string _warehouseInLineComment;
        private int _warehouseInLineId;
        private List<WarehouseInLine> _warehouseInLines;
        private string _warehouseName;
        private List<Brand> _brands;
        private List<CommodityType> _commodityTypes;
        private int _selectedCommodityId;
        private string _selectedCommodityName;
        private int _selectedCommodityTypeId;
        private List<Specification> _specifications;
        public decimal TotalPackingQty = 0;
        public decimal TotalQty = 0;
        public decimal TotalVerQty = 0;
        private List<int> _idList;
        #region 入库行列表维护

        private List<WarehouseInLine> _addWarehouseInLines;
        private List<WarehouseInLine> _allWarehouseInLines;
        private List<WarehouseInLine> _deleteWarehouseInLines;
        private List<WarehouseInLine> _updateWarehouseInLines;

        #endregion

        #endregion

        #region Property
        public List<int> IdList
        {
            get { return _idList; }
            set
            {
                if (_idList != value)
                {
                    _idList = value;
                    Notify("IdList");
                }
            }
        }

        public List<WarehouseInLine> AllWarehouseInLines
        {
            get { return _allWarehouseInLines; }
            set
            {
                if (_allWarehouseInLines != value)
                {
                    _allWarehouseInLines = value;
                    Notify("AllWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> DeleteWarehouseInLines
        {
            get { return _deleteWarehouseInLines; }
            set
            {
                if (_deleteWarehouseInLines != value)
                {
                    _deleteWarehouseInLines = value;
                    Notify("DeleteWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> UpdateWarehouseInLines
        {
            get { return _updateWarehouseInLines; }
            set
            {
                if (_updateWarehouseInLines != value)
                {
                    _updateWarehouseInLines = value;
                    Notify("UpdateWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> AddWarehouseInLines
        {
            get { return _addWarehouseInLines; }
            set
            {
                if (_addWarehouseInLines != value)
                {
                    _addWarehouseInLines = value;
                    Notify("AddWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> Lines
        {
            get { return _lines; }
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    Notify("Lines");
                }
            }
        }

        public DeliveryLine DeliveryLine
        {
            get { return _deliveryLine; }
            set
            {
                if (_deliveryLine != value)
                {
                    _deliveryLine = value;
                    Notify("DeliveryLine");
                }
            }
        }

        public string DeliveryNo
        {
            get { return _deliveryNo; }
            set
            {
                if (_deliveryNo != value)
                {
                    _deliveryNo = value;
                    Notify("DeliveryNo");
                }
            }
        }

        public string SelectedCommodityName
        {
            get { return _selectedCommodityName; }
            set
            {
                if (_selectedCommodityName != value)
                {
                    _selectedCommodityName = value;
                    Notify("SelectedCommodityName");
                }
            }
        }

        public WarehouseIn WarehouseIn
        {
            get { return _warehouseIn; }
            set
            {
                if (_warehouseIn != value)
                {
                    _warehouseIn = value;
                    Notify("WarehouseIn");
                }
            }
        }

        public int WarehouseInId
        {
            get { return _warehouseInId; }
            set
            {
                if (_warehouseInId != value)
                {
                    _warehouseInId = value;
                    Notify("WarehouseInId");
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
                    Notify("Commodity");
                }
            }
        }

        public DeliveryTypeWarehouseIn DeliveryTypeWarehouseIn
        {
            get { return _deliveryTypeWarehouseIn; }
            set
            {
                if (_deliveryTypeWarehouseIn != value)
                {
                    _deliveryTypeWarehouseIn = value;
                    Notify("DeliveryTypeWarehouseIn");
                }
            }
        }

        public int SelectedCommodityId
        {
            get { return _selectedCommodityId; }
            set
            {
                if (_selectedCommodityId != value)
                {
                    _selectedCommodityId = value;
                    Notify("SelectedCommodityId");
                }
            }
        }


        public int SelectedCommodityTypeId
        {
            get { return _selectedCommodityTypeId; }
            set
            {
                if (_selectedCommodityTypeId != value)
                {
                    _selectedCommodityTypeId = value;
                    Notify("SelectedCommodityTypeId");
                }
            }
        }


        public List<CommodityType> CommodityTypes
        {
            get { return _commodityTypes; }
            set
            {
                _commodityTypes = value;
                Notify("CommodityTypes");
            }
        }

        public List<Brand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                Notify("Brands");
            }
        }

        public List<Specification> Specifications
        {
            get { return _specifications; }
            set
            {
                _specifications = value;
                Notify("Specifications");
            }
        }

        public decimal? PackingQuantity
        {
            get { return _packingQuantity; }
            set
            {
                _packingQuantity = value;
                Notify("PackingQuantity");
            }
        }

        public int SpecificationId
        {
            get { return _specificationId; }
            set
            {
                _specificationId = value;
                Notify("SpecificationId");
            }
        }

        public int BrandId
        {
            get { return _brandId; }
            set
            {
                _brandId = value;
                Notify("BrandId");
            }
        }

        public bool IsVerified
        {
            get { return _isVerified; }
            set
            {
                _isVerified = value;
                Notify("IsVerified");
            }
        }

        public string PBNo
        {
            get { return _pbNo; }
            set
            {
                _pbNo = value;
                Notify("PBNo");
            }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                Notify("Quantity");
            }
        }

        public decimal VerifiedQuantity
        {
            get { return _verifiedQuantity; }
            set
            {
                _verifiedQuantity = value;
                Notify("VerifiedQuantity");
            }
        }

        public int DeliveryLineId
        {
            get { return _deliveryLineId; }
            set
            {
                _deliveryLineId = value;
                Notify("DeliveryId");
            }
        }

        public DateTime? WarehouseInDate
        {
            get { return _warehouseInDate; }
            set
            {
                _warehouseInDate = value;
                Notify("WarehouseInDate");
            }
        }

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                _warehouseId = value;
                Notify("WarehouseId");
            }
        }

        public string WarehouseName
        {
            get { return _warehouseName; }
            set
            {
                _warehouseName = value;
                Notify("WarehouseName");
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                Notify("Comment");
            }
        }

        public string WarehouseInLineComment
        {
            get { return _warehouseInLineComment; }
            set
            {
                _warehouseInLineComment = value;
                Notify("WarehouseInLineComment");
            }
        }

        public List<WarehouseInLine> WarehouseInLines
        {
            get { return _warehouseInLines; }
            set
            {
                _warehouseInLines = value;
                Notify("WarehosueInLines");
            }
        }

        public int WarehouseInLineId
        {
            get { return _warehouseInLineId; }
            set
            {
                _warehouseInLineId = value;
                Notify("WarehouseInLineId");
            }
        }

        #endregion

        public WarehouseInLineDetailVM(DeliveryTypeWarehouseIn deliveryTypeWarehouseIn, List<WarehouseInLine> lines,
                                 List<WarehouseInLine> addLines, int commodityId)
        {
            ObjectId = 0;
            AllWarehouseInLines = lines;
            AddWarehouseInLines = addLines;
            DeliveryTypeWarehouseIn = deliveryTypeWarehouseIn;
            SelectedCommodityId = commodityId;
            PropertyChanged += OnPropertyChanged;
            LoadWarehouseInLine();
            GetIDList();
            LoadDocumentLineEnableProperty(ObjectId);
        }

        public WarehouseInLineDetailVM(DeliveryTypeWarehouseIn deliveryTypeWarehouseIn, int warehouseInLineId,
                                 List<WarehouseInLine> lines, List<WarehouseInLine> addLines,
                                 List<WarehouseInLine> updateLines, int commodityId)
        {
            DeliveryTypeWarehouseIn = deliveryTypeWarehouseIn;
            AllWarehouseInLines = lines;
            AddWarehouseInLines = addLines;
            ObjectId = warehouseInLineId;
            UpdateWarehouseInLines = updateLines;
            SelectedCommodityId = commodityId;
            PropertyChanged += OnPropertyChanged;
            LoadWarehouseInLine();
            LoadCommodityType();
            GetIDList();
            LoadDocumentLineEnableProperty(ObjectId);
        }

        #region Method
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Quantity")
            {
                SetVerifiedQtyByQty();
            }
            if (e.PropertyName == "SelectedCommodityTypeId")
            {
                LoadBrandAndSpecification();
            }
        }

        #region 加载当前用户关联内部客户
        public void GetIDList()
        {
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
        }
        #endregion

        #region 加载金属 品牌 规格

        public void LoadBrandAndSpecification()
        {
            LoadBrand();
            LoadSpecification();
        }

        public void LoadCommodityType()
        {
            if (SelectedCommodityId != 0)
            {
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    const string str = "it.CommodityId = @p1";
                    var parameters = new List<object> { SelectedCommodityId };
                    CommodityTypes = commodityTypeService.Query(str, parameters);
                    if (CommodityTypes.Count > 0)
                    {
                        if (SelectedCommodityTypeId <= 0)
                        {
                            SelectedCommodityTypeId = CommodityTypes[0].Id;
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

        private void LoadBrand()
        {
            if (SelectedCommodityId != 0 && SelectedCommodityTypeId != 0)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { SelectedCommodityId, SelectedCommodityTypeId };
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
            if (SelectedCommodityId != 0 && SelectedCommodityTypeId != 0)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { SelectedCommodityId, SelectedCommodityTypeId };
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

        #endregion

        #region 加载入库行

        public void LoadWarehouseInLine()
        {
            if (ObjectId > 0)
            {
                List<WarehouseInLine> warehouseInLines = AllWarehouseInLines.Where(c => c.Id == ObjectId).ToList();
                if (warehouseInLines.Count > 0) //保存之后的编辑 ID>0的
                {
                    WarehouseInLine warehouseInLine = warehouseInLines[0];
                    if (warehouseInLine != null)
                    {
                        DeliveryLineId = warehouseInLine.DeliveryLineId;
                        PBNo = warehouseInLine.PBNo;
                        _quantity = Convert.ToDecimal(warehouseInLine.Quantity);
                        VerifiedQuantity = Convert.ToDecimal(warehouseInLine.VerifiedQuantity);
                        IsVerified = warehouseInLine.IsVerified != null && warehouseInLine.IsVerified.Value;
                        SelectedCommodityId = warehouseInLine.DeliveryLine.Delivery.Quota.Commodity.Id;
                        SelectedCommodityTypeId = Convert.ToInt32(warehouseInLine.CommodityTypeId);
                        DeliveryLine = warehouseInLine.DeliveryLine;
                        BrandId = Convert.ToInt32(warehouseInLine.BrandId);
                        SpecificationId = Convert.ToInt32(warehouseInLine.SpecificationId);
                        PackingQuantity = warehouseInLine.PackingQuantity;
                        WarehouseInLineComment = warehouseInLine.Comment;
                    }
                }
            }
            else
            {
                if (AllWarehouseInLines.Count > 0) //未保存之前的编辑 数据存在list里面 ID可能小于0
                {
                    List<WarehouseInLine> lines = AllWarehouseInLines.Where(c => c.Id == ObjectId).ToList();
                    if (lines.Count > 0)
                    {
                        WarehouseInLine warehouseInLine = lines[0];
                        if (warehouseInLine != null)
                        {
                            DeliveryLineId = warehouseInLine.DeliveryLineId;
                            PBNo = warehouseInLine.PBNo;
                            Quantity = Convert.ToDecimal(warehouseInLine.Quantity);
                            VerifiedQuantity = Convert.ToDecimal(warehouseInLine.VerifiedQuantity);
                            IsVerified = warehouseInLine.IsVerified != null && warehouseInLine.IsVerified.Value;
                            SelectedCommodityId = warehouseInLine.DeliveryLine.Delivery.Quota.Commodity.Id;
                            SelectedCommodityTypeId = Convert.ToInt32(warehouseInLine.CommodityTypeId);
                            BrandId = Convert.ToInt32(warehouseInLine.BrandId);
                            DeliveryLine = warehouseInLine.DeliveryLine;
                            SpecificationId = Convert.ToInt32(warehouseInLine.SpecificationId);
                            PackingQuantity = Convert.ToDecimal(warehouseInLine.PackingQuantity);
                            WarehouseInLineComment = warehouseInLine.Comment;
                        }
                    }
                }
                else //新增
                {
                    //SelectedCommodityId = 0;
                    SelectedCommodityTypeId = 0;
                }
            }
        }

        #endregion

        public void GetTDOnlyQty(int tdID)
        {
            decimal? onlyVerifiedQty = 0;
            decimal? onlyQty = 0;
            decimal? onlyPackingQty = 0;
            using (
                var deliveryLineService =
                    SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> { tdID };
                List<DeliveryLine> deliveryLineList = deliveryLineService.Select(str, parameters,
                                                                                 new List<string> { "Delivery", "WarehouseInLines" });
                if (deliveryLineList.Count > 0)
                {
                    DeliveryLine deliveryLine = deliveryLineList[0];
                    FilterDeleted(deliveryLine.WarehouseInLines);
                    decimal? verifiedQty = 0;
                    decimal? qty = 0;
                    decimal? packingQty = 0;
                    foreach (WarehouseInLine warehouseInLine in deliveryLine.WarehouseInLines)
                    {
                        if (!warehouseInLine.IsDeleted)
                        {
                            verifiedQty += warehouseInLine.VerifiedQuantity ?? 0;
                            qty += warehouseInLine.Quantity;
                            packingQty += warehouseInLine.PackingQuantity;
                        }
                    }
                    if (DeliveryTypeWarehouseIn == DeliveryTypeWarehouseIn.InternalWarehouseIn)
                    {
                        onlyVerifiedQty = deliveryLine.VerifiedWeight - verifiedQty;
                    }
                    else if (DeliveryTypeWarehouseIn == DeliveryTypeWarehouseIn.ExternalWarehouseIn)
                    {
                        onlyVerifiedQty = deliveryLine.GrossWeight - verifiedQty;
                    }
                    onlyQty = deliveryLine.NetWeight - qty;
                    onlyPackingQty = deliveryLine.PackingQuantity - packingQty;
                }
            }

            Quantity = (onlyQty == null ? 0 : (decimal)onlyQty);
            VerifiedQuantity = (onlyQty == null ? 0 : (decimal)onlyVerifiedQty);
            PackingQuantity = (onlyPackingQty == null ? 0 : onlyPackingQty.Value);
        }

        public void SetVerifiedQtyByQty()
        {
            VerifiedQuantity = Quantity;
        }

        #region 入库行属性Enable

        private bool _isBrandEnable;
        private bool _isCommodityTypeEnable;
        private bool _isDeliveryLineEnable;
        private bool _isPBNoEnable;
        private bool _isQuantityEnable;
        private bool _isSpecificationEnable;
        private bool _isVerifiedQuantityEnable;

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

        public bool IsPBNoEnable
        {
            get { return _isPBNoEnable; }
            set
            {
                if (_isPBNoEnable != value)
                {
                    _isPBNoEnable = value;
                    Notify("IsPBNoEnable");
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

        public bool IsDeliveryLineEnable
        {
            get { return _isDeliveryLineEnable; }
            set
            {
                if (_isDeliveryLineEnable != value)
                {
                    _isDeliveryLineEnable = value;
                    Notify("IsDeliveryLineEnable");
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

        private void LoadDocumentLineEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsBrandEnable = true;
                IsCommodityTypeEnable = true;
                IsPBNoEnable = true;
                IsQuantityEnable = true;
                IsVerifiedQuantityEnable = true;
                IsDeliveryLineEnable = true;
                IsSpecificationEnable = true;
            }
            else
            {
                using (var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
                {
                    WarehouseInLineEnableProperty wilep = warehouseInLineService.SetElementsEnableProperty(id);
                    IsBrandEnable = wilep.IsBrandEnable;
                    IsCommodityTypeEnable = wilep.IsCommodityTypeEnable;
                    IsPBNoEnable = wilep.IsPBNoEnable;
                    IsQuantityEnable = wilep.IsQuantityEnable;
                    IsVerifiedQuantityEnable = wilep.IsVerifiedQuantityEnable;
                    IsDeliveryLineEnable = wilep.IsDeliveryLineEnable;
                    IsSpecificationEnable = wilep.IsSpecificationEnable;
                }
            }
        }

        #endregion

        #region 验证

        public override bool Validate()
        {
            if (DeliveryLine == null)
            {
                throw new Exception(ResWarehouseIn.BLWRRequired);
            }

            if (string.IsNullOrEmpty(PBNo))
            {
                throw new Exception(Properties.Resources.PBNoRequired);
            }

            if (SelectedCommodityTypeId == 0)
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

        #endregion

        #region 增删改List

        protected override void Create()
        {
            var warehouseInLine = new WarehouseInLine();
            if (AllWarehouseInLines.Count <= 0)
            {
                warehouseInLine.Id = -1;
            }
            else
            {
                var lineIdList = AllWarehouseInLines.Select(line => Math.Abs(line.Id)).ToList();

                int maxID = lineIdList.Max();

                warehouseInLine.Id = -(maxID + 1);
            }
            warehouseInLine.DeliveryLineId = DeliveryLineId;
            warehouseInLine.PBNo = PBNo;
            warehouseInLine.IsPBCleared = false; //新增清卡状态默认为false
            warehouseInLine.Quantity = Quantity;
            warehouseInLine.VerifiedQuantity = VerifiedQuantity;
            warehouseInLine.IsVerified = IsVerified;
            warehouseInLine.DeliveryLine = DeliveryLine;
            warehouseInLine.CommodityTypeId = SelectedCommodityTypeId;
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                Contract contract = contractService.GetById(DeliveryLine.Delivery.Quota.ContractId);
                warehouseInLine.DeliveryLine.Delivery.Quota.Contract = contract;
            }
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                CommodityType commodityType = commodityTypeService.GetById(SelectedCommodityTypeId);
                warehouseInLine.CommodityType = commodityType;
            }
            warehouseInLine.BrandId = BrandId;
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                Brand brand = brandService.GetById(BrandId);
                warehouseInLine.Brand = brand;
            }
            warehouseInLine.SpecificationId = SpecificationId;
            warehouseInLine.PackingQuantity = PackingQuantity;
            warehouseInLine.Comment = WarehouseInLineComment;
            AllWarehouseInLines.Add(warehouseInLine);
            #region 新建对象去掉外键关联 防止数据溢出
            var addLine = new WarehouseInLine
                              {
                                  Id = warehouseInLine.Id,
                                  DeliveryLineId = warehouseInLine.DeliveryLineId,
                                  PBNo = warehouseInLine.PBNo,
                                  IsPBCleared = warehouseInLine.IsPBCleared,
                                  Quantity = warehouseInLine.Quantity,
                                  PackingQuantity = warehouseInLine.PackingQuantity,
                                  VerifiedQuantity = warehouseInLine.VerifiedQuantity,
                                  IsVerified = warehouseInLine.IsVerified,
                                  CommodityTypeId = warehouseInLine.CommodityTypeId,
                                  BrandId = warehouseInLine.BrandId,
                                  SpecificationId = warehouseInLine.SpecificationId,
                                  Comment = warehouseInLine.Comment
                              };
            #endregion
            AddWarehouseInLines.Add(addLine);
        }

        protected override void Update()
        {
            var warehouseInLine = new WarehouseInLine();
            if (AllWarehouseInLines.Count > 0)
            {
                List<WarehouseInLine> lines = AllWarehouseInLines.Where(c => c.Id == ObjectId).ToList();
                if (lines.Count > 0)
                {
                    WarehouseInLine line = lines[0];
                    warehouseInLine.Id = line.Id;
                    warehouseInLine.WarehouseInId = line.WarehouseInId;
                    warehouseInLine.DeliveryLineId = DeliveryLineId;
                    warehouseInLine.IsPBCleared = line.IsPBCleared;
                    warehouseInLine.PBNo = PBNo;
                    warehouseInLine.Quantity = Quantity;
                    warehouseInLine.VerifiedQuantity = VerifiedQuantity;
                    warehouseInLine.IsVerified = IsVerified;
                    warehouseInLine.DeliveryLine = DeliveryLine;
                    warehouseInLine.CommodityTypeId = SelectedCommodityTypeId;
                    using (
                        var contractService =
                            SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
                    {
                        Contract contract = contractService.GetById(DeliveryLine.Delivery.Quota.ContractId);
                        warehouseInLine.DeliveryLine.Delivery.Quota.Contract = contract;
                    }
                    using (
                        var commodityTypeService =
                            SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                    {
                        CommodityType commodityType = commodityTypeService.GetById(SelectedCommodityTypeId);
                        warehouseInLine.CommodityType = commodityType;
                    }
                    warehouseInLine.BrandId = BrandId;
                    using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                    {
                        Brand brand = brandService.GetById(BrandId);
                        warehouseInLine.Brand = brand;
                    }
                    warehouseInLine.SpecificationId = SpecificationId;
                    warehouseInLine.PackingQuantity = PackingQuantity;
                    warehouseInLine.Comment = WarehouseInLineComment;
                    AllWarehouseInLines.Remove(line);
                    AllWarehouseInLines.Add(warehouseInLine);
                    if (line.Id < 0)
                    {
                        if (AddWarehouseInLines.Count > 0)
                        {
                            WarehouseInLine addLine = AddWarehouseInLines.Where(c => c.Id == line.Id).ToList()[0];
                            AddWarehouseInLines.Remove(addLine);
                            #region 新建对象去掉外键关联 防止数据溢出
                            var newAddLine = new WarehouseInLine
                                                 {
                                                     Id = warehouseInLine.Id,
                                                     DeliveryLineId = warehouseInLine.DeliveryLineId,
                                                     PBNo = warehouseInLine.PBNo,
                                                     IsPBCleared = warehouseInLine.IsPBCleared,
                                                     Quantity = warehouseInLine.Quantity,
                                                     PackingQuantity = warehouseInLine.PackingQuantity,
                                                     VerifiedQuantity = warehouseInLine.VerifiedQuantity,
                                                     IsVerified = warehouseInLine.IsVerified,
                                                     CommodityTypeId = warehouseInLine.CommodityTypeId,
                                                     BrandId = warehouseInLine.BrandId,
                                                     SpecificationId = warehouseInLine.SpecificationId,
                                                     Comment = warehouseInLine.Comment,
                                                     WarehouseInId = warehouseInLine.WarehouseInId
                                                 };
                            #endregion
                            AddWarehouseInLines.Add(newAddLine);
                        }
                    }
                    else
                    {
                        if (UpdateWarehouseInLines.Count > 0)
                        {
                            List<WarehouseInLine> updateLines =
                                UpdateWarehouseInLines.Where(c => c.Id == line.Id).ToList();
                            if (updateLines.Count > 0)
                            {
                                WarehouseInLine updateLine = updateLines[0];
                                UpdateWarehouseInLines.Remove(updateLine);
                            }
                        }
                        #region 新建对象去掉外键关联 防止数据溢出
                        var newUpdateLine = new WarehouseInLine
                                                {
                                                    Id = warehouseInLine.Id,
                                                    DeliveryLineId = warehouseInLine.DeliveryLineId,
                                                    PBNo = warehouseInLine.PBNo,
                                                    IsPBCleared = warehouseInLine.IsPBCleared,
                                                    Quantity = warehouseInLine.Quantity,
                                                    PackingQuantity = warehouseInLine.PackingQuantity,
                                                    VerifiedQuantity = warehouseInLine.VerifiedQuantity,
                                                    IsVerified = warehouseInLine.IsVerified,
                                                    CommodityTypeId = warehouseInLine.CommodityTypeId,
                                                    BrandId = warehouseInLine.BrandId,
                                                    SpecificationId = warehouseInLine.SpecificationId,
                                                    Comment = warehouseInLine.Comment,
                                                    WarehouseInId = warehouseInLine.WarehouseInId
                                                };
                        #endregion
                        UpdateWarehouseInLines.Add(newUpdateLine);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}