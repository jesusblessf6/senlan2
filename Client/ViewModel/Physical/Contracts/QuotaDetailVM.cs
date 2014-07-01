using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityServiceReference;
using Client.CommodityTypeServiceReference;
using Client.CurrencyServiceReference;
using Client.PricingServiceReference;
using Client.QuotaServiceReference;
using Client.RateServiceReference;
using Client.SpecificationServiceReference;
using Client.View.Physical.Contracts;
using Client.WarehouseServiceReference;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.PaymentMeanServiceReference;
using Client.BusinessPartnerServiceReference;
using System.ComponentModel;

namespace Client.ViewModel.Physical.Contracts
{
    public class QuotaDetailVM : BaseVM
    {
        #region Member

        private List<Quota> _addedQuotas;
        private int? _approveStatus;
        private int? _brandId;
        private List<Brand> _brands;
        private int? _commodityId;
        private int? _commodityTypeId;
        private List<CommodityType> _commodityTypes;
        private List<Commodity> _commoditys;
        private List<Currency> _currencies;
        private Quota _currentQuota;
        private DateTime? _deliveryDate;
        private int _deliveryStatus;
        private int _financeStatus;
        private int _id;
        private DateTime? _implementedDate;
        private bool _loadState;
        private decimal? _premium = 0;
        private decimal? _price;
        private Dictionary<string, int> _pricingBasises;
        private DateTime? _pricingEndDate;
        private int? _pricingSide;
        private bool _pricingSideOwn;
        private bool _pricingSideTheir;
        private DateTime? _pricingStartDate;
        private Dictionary<string, int> _pricingTypes;
        private decimal? _quantity;
        private string _quotaNo;
        private string _exQuotaNo;
        private List<Quota> _quotas;
        private int _selectPricingBasis;
        private int _selectPricingCurrencyId;
        private int _selectPricingType = 1;
        private int? _settlementCurrencyId;
        private decimal? _settlementRate;
        private int? _specificationId;
        private List<Specification> _specifications;
        private Dictionary<string, int> _statusTypes;
        private List<Quota> _updatedQuotas;
        private int? _warehouseId;
        private string _warehouseName;
        private string _shipTerm;
        private Dictionary<string, int> _paymentMean;
        private int? _selectPaymentMeanId;
        private string _vATInvoiceStr;
        private DateTime? _vATInvoiceDate;
        private string _IsAutoNoVisible;
        private string _AutoQuotaNo;
        private int? _BpId;

        #endregion

        #region Property
        public string AutoQuotaNo
        {
            get { return _AutoQuotaNo; }
            set { 
                if(_AutoQuotaNo != value)
                {
                    _AutoQuotaNo = value;
                    Notify("AutoQuotaNo");
                }
            }
        }

        public string IsAutoNoVisible
        {
            get { return _IsAutoNoVisible; }
            set
            {
                if (_IsAutoNoVisible != value)
                {
                    _IsAutoNoVisible = value;
                    Notify("IsAutoNoVisible");
                }
            }
        }

        public List<Quota> Quotas
        {
            get { return _quotas; }
            set
            {
                if (_quotas != value)
                {
                    _quotas = value;
                    Notify("Quotas");
                }
            }
        }

        public List<Quota> AddedQuotas
        {
            get { return _addedQuotas; }
            set
            {
                if (_addedQuotas != value)
                {
                    _addedQuotas = value;
                    Notify("AddedQuotas");
                }
            }
        }

        public List<Quota> UpdatedQuotas
        {
            get { return _updatedQuotas; }
            set
            {
                if (_updatedQuotas != value)
                {
                    _updatedQuotas = value;
                    Notify("UpdatedQuotas");
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

        public TradeType TradeType { get; set; }

        public ContractType ContractType { get; set; }

        public decimal? Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify("Price");
                }
            }
        }

        public string ExQuotaNo
        {
            get { return _exQuotaNo; }
            set
            {
                if (_exQuotaNo != value)
                {
                    _exQuotaNo = value;
                    Notify("ExQuotaNo");
                }
            }
        }

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                if (_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public DateTime? ImplementedDate
        {
            get { return _implementedDate; }
            set
            {
                if (_implementedDate != value)
                {
                    _implementedDate = value;
                    Notify("ImplementedDate");
                }
            }
        }

        public decimal? Quantity
        {
            get
            {
                if (_quantity != null)
                    return Math.Round((decimal)_quantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);

                return null;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    Notify("Quantity");
                }
            }
        }

        public int? ApproveStatus
        {
            get { return _approveStatus; }
            set
            {
                if (_approveStatus != value)
                {
                    _approveStatus = value;
                    Notify("ApproveStatus");
                }
            }
        }

        public int FinanceStatus
        {
            get { return _financeStatus; }
            set
            {
                if (_financeStatus != value)
                {
                    _financeStatus = value;
                    Notify("FinanceStatus");
                }
            }
        }

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

        public List<Commodity> Commoditys
        {
            get { return _commoditys; }
            set
            {
                if (_commoditys != value)
                {
                    _commoditys = value;
                    Notify("Commoditys");
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

        public int SelectPricingType
        {
            get { return _selectPricingType; }
            set
            {
                if (_selectPricingType != value)
                {
                    _selectPricingType = value;
                    Notify("SelectPricingType");
                }
            }
        }

        public Dictionary<string, int> PricingTypes
        {
            get { return _pricingTypes; }
            set
            {
                if (_pricingTypes != value)
                {
                    _pricingTypes = value;
                    Notify("PricingTypes");
                }
            }
        }

        public int SelectPricingBasis
        {
            get { return _selectPricingBasis; }
            set
            {
                if (_selectPricingBasis != value)
                {
                    _selectPricingBasis = value;
                    Notify("SelectPricingBasis");
                }
            }
        }

        public Dictionary<string, int> PricingBasises
        {
            get { return _pricingBasises; }
            set
            {
                if (_pricingBasises != value)
                {
                    _pricingBasises = value;
                    Notify("PricingBasises");
                }
            }
        }

        public DateTime? PricingStartDate
        {
            get { return _pricingStartDate; }
            set
            {
                if (_pricingStartDate != value)
                {
                    _pricingStartDate = value;
                    Notify("PricingStartDate");
                }
            }
        }

        public DateTime? PricingEndDate
        {
            get { return _pricingEndDate; }
            set
            {
                if (_pricingEndDate != value)
                {
                    _pricingEndDate = value;
                    Notify("PricingEndDate");
                }
            }
        }

        public bool PricingSideTheir
        {
            get { return _pricingSideTheir; }
            set
            {
                if (_pricingSideTheir != value)
                {
                    _pricingSideTheir = value;
                    Notify("PricingSideTheir");
                }
            }
        }

        public bool PricingSideOwn
        {
            get { return _pricingSideOwn; }
            set
            {
                if (_pricingSideOwn != value)
                {
                    _pricingSideOwn = value;
                    Notify("PricingSideOwn");
                }
            }
        }

        /// <summary>
        /// 升贴水
        /// </summary>
        public decimal? Premium
        {
            get
            {
                return _premium;
            }
            set
            {
                if (_premium != value)
                {
                    _premium = value;
                    Notify("Premium");
                }
            }
        }

        public DateTime? DeliveryDate
        {
            get { return _deliveryDate; }
            set
            {
                if (_deliveryDate != value)
                {
                    _deliveryDate = value;
                    Notify("DeliveryDate");
                }
            }
        }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public int? WarehouseId
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

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set
            {
                if (_warehouseName != value)
                {
                    _warehouseName = value;
                    Notify("WarehouseName");
                }
            }
        }

        public Quota CurrentQuota
        {
            get { return _currentQuota; }
            set
            {
                if (_currentQuota != value)
                {
                    _currentQuota = value;
                    Notify("CurrentQuota");
                }
            }
        }

        /// <summary>
        /// 选择的结算币种
        /// </summary>
        public int? SettlementCurrencyId
        {
            get { return _settlementCurrencyId; }
            set
            {
                if (_settlementCurrencyId != value)
                {
                    _settlementCurrencyId = value;
                    Notify("SettlementCurrencyId");
                }
            }
        }

        public decimal? SettlementRate
        {
            get
            {
                if (_settlementRate != null)
                {
                    return Math.Round((decimal)_settlementRate, RoundRules.RATE, MidpointRounding.AwayFromZero);
                }

                return null;
            }
            set
            {
                if (_settlementRate != value)
                {
                    _settlementRate = value;
                    Notify("SettlementRate");
                }
            }
        }

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

        public int? PricingSide
        {
            get { return _pricingSide; }
            set
            {
                if (_pricingSide != value)
                {
                    _pricingSide = value;
                    Notify("PricingSide");
                }
            }
        }

        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                if (_currencies != value)
                {
                    _currencies = value;
                    Notify("Currencies");
                }
            }
        }

        public int SelectPricingCurrencyId
        {
            get { return _selectPricingCurrencyId; }
            set
            {
                if (_selectPricingCurrencyId != value)
                {
                    _selectPricingCurrencyId = value;
                    Notify("SelectPricingCurrencyId");
                }
            }
        }

        public string ShipTerm
        {
            get { return _shipTerm; }
            set
            {
                if (_shipTerm != value)
                {
                    _shipTerm = value;
                    Notify("ShipTerm");
                }
            }
        }

        public Dictionary<string, int> PaymentMean
        {
            get { return _paymentMean; }
            set
            {
                if (_paymentMean != value)
                {
                    _paymentMean = value;
                    Notify("PaymentMean");
                }
            }
        }

        public int? SelectPaymentMeanId
        {
            get { return _selectPaymentMeanId; }
            set
            {
                if (_selectPaymentMeanId != value)
                {
                    _selectPaymentMeanId = value;
                    Notify("SelectPaymentMeanId");
                }
            }
        }

        public string VATInvoiceStr
        {
            get { return _vATInvoiceStr; }
            set
            {
                if (_vATInvoiceStr != value)
                {
                    _vATInvoiceStr = value;
                    Notify("VATInvoiceDate");
                }
            }
        }

        public DateTime? VATInvoiceDate
        {
            get { return _vATInvoiceDate; }
            set
            {
                if (_vATInvoiceDate != value)
                {
                    _vATInvoiceDate = value;
                    Notify("VATInvoiceDate");
                }
            }
        }
        #endregion

        #region Constructor

        public QuotaDetailVM(TradeType tradeType, ContractType contractType, int? bpId)
        {
            ObjectId = 0;
            TradeType = tradeType;
            _BpId = bpId;
            LoadComboxValue();
            LoadPricingSideByEdit();
            LoadDocumentLineEnableProperty(ObjectId);

            if (tradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade || tradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade)
            {
                IsAutoNoVisible = "Visible";
            }
            else
            {
                if (tradeType == TradeType.LongDomesticTrade)
                {
                    if (contractType == ContractType.Purchase)
                    {
                        VATInvoiceStr = "预收票日期";
                    }
                    else
                    {
                        VATInvoiceStr = "预开票日期";
                    }
                    _vATInvoiceDate = DateTime.Today;
                }
                IsAutoNoVisible = "Collapsed";
            }
            PropertyChanged += OnPropertyChanged;
        }

        public QuotaDetailVM(TradeType tradeType, DateTime time, ContractType contractType, int? bpId)
        {
            ObjectId = 0;
            TradeType = tradeType;
            ImplementedDate = time;
            _BpId = bpId;
            LoadComboxValue();
            LoadPricingSideByEdit();
            LoadDocumentLineEnableProperty(ObjectId);
            if (tradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade || tradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade)
            {
                IsAutoNoVisible = "Visible";
            }
            else
            {
                if (tradeType == TradeType.LongDomesticTrade)
                {
                    if (contractType == ContractType.Purchase)
                    {
                        VATInvoiceStr = "预收票日期";
                    }
                    else
                    {
                        VATInvoiceStr = "预开票日期";
                    }
                    _vATInvoiceDate = DateTime.Today;
                }
                IsAutoNoVisible = "Collapsed";
            }
            PropertyChanged += OnPropertyChanged;
        }

        public QuotaDetailVM(int id, TradeType tradeType, List<Quota> quotas, List<Quota> addedQuotas,
                             List<Quota> updatedQuotas, ContractType contractType, int? bpId)
        {
            ObjectId = id;
            _BpId = bpId;
            Quotas = quotas;
            AddedQuotas = addedQuotas;
            UpdatedQuotas = updatedQuotas;
            CurrentQuota = GetQuotaFromList(id, Quotas);
            TradeType = tradeType;
            LoadComboxValue();
            LoadQuota();
            LoadPricingSideByEdit();
            LoadDocumentLineEnableProperty(ObjectId);
            if (tradeType == DBEntity.EnumEntity.TradeType.ShortForeignTrade || tradeType == DBEntity.EnumEntity.TradeType.LongForeignTrade)
            {
                IsAutoNoVisible = "Visible";
            }
            else
            {
                if (tradeType == TradeType.LongDomesticTrade)
                {
                    if (contractType == ContractType.Purchase)
                    {
                        VATInvoiceStr = "预收票日期";
                    }
                    else
                    {
                        VATInvoiceStr = "预开票日期";
                    }
                }
                IsAutoNoVisible = "Collapsed";
            }
            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Method

        #region 页面数据准备

        private void LoadQuota()
        {
            if (CurrentQuota.Id != 0)
            {
                _loadState = true;
                ObjectId = CurrentQuota.Id;
            }
            Id = CurrentQuota.Id;
            QuotaNo = CurrentQuota.QuotaNo;
            ExQuotaNo = CurrentQuota.ExQuotaNo;
            ImplementedDate = CurrentQuota.ImplementedDate;
            Quantity = CurrentQuota.Quantity;
            ApproveStatus = CurrentQuota.ApproveStatus;
            AutoQuotaNo = CurrentQuota.AutoQuotaNo;
            Price = CurrentQuota.Price;
            SettlementRate = CurrentQuota.SettlementRate;
            FinanceStatus = CurrentQuota.FinanceStatus ? 1 : 0;
            DeliveryStatus = CurrentQuota.DeliveryStatus ? 1 : 0;
            CommodityId = CurrentQuota.CommodityId;
            CommodityTypeId = CurrentQuota.CommodityTypeId;
            BrandId = CurrentQuota.BrandId;
            SpecificationId = CurrentQuota.SpecificationId;
            SelectPricingType = CurrentQuota.PricingType;
            SelectPricingBasis = CurrentQuota.PricingBasis ?? 0;
            PricingStartDate = CurrentQuota.PricingStartDate;
            PricingEndDate = CurrentQuota.PricingEndDate;
            Premium = CurrentQuota.Premium;
            _selectPricingCurrencyId = CurrentQuota.PricingCurrencyId ?? 0;
            if(CurrentQuota.RelQuotaId.HasValue)
            {
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    Quota relQuota = quotaService.GetById(CurrentQuota.RelQuotaId.Value);
                    AutoQuotaNo = relQuota.QuotaNo;
                }
            }
            //SettlementRate = CurrentQuota.SettlementRate;
            if (TradeType == TradeType.LongDomesticTrade)
            {
                VATInvoiceDate = CurrentQuota.VATInvoiceDate;
            }
            if (CurrentQuota.PricingType == (int)PricingType.Fixed)
            {
                Pricing firstOrDefault = CurrentQuota.Pricings.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    Price = firstOrDefault.FinalPrice;
                    //获取固定点价的汇率
                    //if (TradeType == TradeType.ShortDomesticTrade)
                    //{
                    //汇率
                    SettlementRate = firstOrDefault.ExchangeRate;
                    //}
                }
            }
            else
            {
                Price = CurrentQuota.TempPrice;
            }
            //else if (CurrentQuota.PricingType == (int)PricingType.Manual)
            //{
            //    Price = CurrentQuota.Price;
            //}
            WarehouseId = CurrentQuota.WarehouseId;
            //Price = CurrentQuota.Price;
            ShipTerm = CurrentQuota.ShipTerm;
            PricingSide = CurrentQuota.PricingSide;

            if (WarehouseId.HasValue)
                GetWarehouseNameById((int)WarehouseId);
            else
                WarehouseName = string.Empty;
            DeliveryDate = CurrentQuota.DeliveryDate;
            SelectPaymentMeanId = CurrentQuota.PaymentMeanId ?? 0;
        }

        private void GetWarehouseNameById(int id)
        {
            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                Warehouse warehouse = warehouseService.GetById(id);
                WarehouseName = warehouse != null ? warehouse.Name : string.Empty;
            }
        }

        private void LoadComboxValue()
        {
            LoadStatus();
            LoadCommodity();
            LoadPricingType();
            LoadPricingBasis();
            LoadCurrency();
            SetPaymentMean();
        }

        private void LoadStatus()
        {
            StatusTypes = new Dictionary<string, int>();
            StatusTypes = EnumHelper.GetEnumDic<StatusType>(StatusTypes);
        }

        private void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commoditys = commodityService.GetCommoditiesByUser(CurrentUser.Id);
            }
            _commoditys.Insert(0, new Commodity { Id = 0, Name = "" });
        }

        private Commodity GetCommodityById(int id)
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                return commodityService.GetById(id);
            }
        }

        public void LoadCommodityType()
        {
            if (CommodityId != null && CommodityId != 0)
            {
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    const string str = "it.CommodityId = @p1";
                    var parameters = new List<object> { CommodityId };
                    CommodityTypes = commodityTypeService.Query(str, parameters);
                    if (ObjectId != 0 && _loadState)
                        return;
                    if (CommodityTypes.Count > 0)
                    {
                        CommodityTypeId = CommodityTypes[0].Id;
                    }
                    else
                    {
                        CommodityTypeId = null;
                        BrandId = null;
                        SpecificationId = null;
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

        private CommodityType GetCommodityTypeById(int id)
        {
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                return commodityTypeService.GetById(id);
            }
        }

        public void LoadBrandAndSpecification()
        {
            LoadBrand();
            LoadSpecification();
        }

        private void LoadBrand()
        {
            if (CommodityId != 0 && CommodityTypeId != null)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { CommodityId, CommodityTypeId };
                    List<Brand> brands = brandService.Query(str, parameters).OrderBy(b => b.Name).ToList();
                    brands.Insert(0, new Brand());
                    if (ObjectId != 0 && _loadState && BrandId != null)
                    {
                        Brands = brands;
                        return;
                    }
                    if (brands.Count > 0)
                    {
                        BrandId = brands[0].Id;
                    }
                    else
                    {
                        BrandId = null;
                    }
                    Brands = brands;
                }
            }
            else
            {
                Brands = new List<Brand>();
            }
        }

        private Brand GetBrandById(int id)
        {
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                return brandService.GetById(id);
            }
        }

        private void LoadSpecification()
        {
            if (CommodityId != 0 && CommodityTypeId != null)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    const string str = "it.CommodityId = @p1 and it.CommodityTypeId = @p2";
                    var parameters = new List<object> { CommodityId, CommodityTypeId };
                    List<Specification> tempSpecifications = specificationService.Query(str, parameters).OrderBy(s => s.Name).ToList();
                    tempSpecifications.Insert(0, new Specification());
                    if (ObjectId != 0 && _loadState && SpecificationId != null)
                    {
                        Specifications = tempSpecifications;
                        _loadState = false;
                        return;
                    }
                    if (tempSpecifications.Count > 0)
                    {
                        SpecificationId = tempSpecifications[0].Id;
                    }
                    else
                    {
                        SpecificationId = null;
                    }
                    Specifications = tempSpecifications;
                }
            }
            else
            {
                Specifications = new List<Specification>();
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

        private void LoadPricingType()
        {
            PricingTypes = new Dictionary<string, int>();
            PricingTypes = EnumHelper.GetEnumDic<PricingType>(PricingTypes);
        }

        private void LoadPricingBasis()
        {
            PricingBasises = new Dictionary<string, int> { { "", 0 } };
            PricingBasises = EnumHelper.GetEnumDic<PricingBasis>(PricingBasises);
        }

        public void LoadPricingSide()
        {
            PricingSideTheir = false;
            PricingSideOwn = true;
        }

        public void LoadPricingSideByEdit()
        {
            if (!PricingSide.HasValue)
            {
                LoadPricingSide();
            }
            else
            {
                switch ((int)PricingSide)
                {
                    case 1:
                        PricingSideTheir = true;
                        PricingSideOwn = false;
                        break;
                    case 2:
                        PricingSideTheir = false;
                        PricingSideOwn = true;
                        break;
                }
            }
        }

        private void LoadCurrency()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                List<Currency> currencies = currencyService.GetAll();
                currencies.Insert(0, new Currency { Id = 0, Name = "" });
                Currencies = currencies;
            }
        }

        /// <summary>
        /// 根据币种返回兑换的汇率
        /// </summary>
        public void LoadRate(int currencyFrom, int currencyTo)
        {
            if (currencyFrom != 0 && currencyTo != 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    decimal? rate = rateService.GetExchangeRate(currencyFrom, currencyTo, CurrentUser.Id);
                    SettlementRate = rate.HasValue ? rate : null;
                }
            }
            else
            {
                SettlementRate = null;
            }
        }

        public void LoadRate()
        {
            
            //if (TradeType == TradeType.LongDomesticTrade)
            //{
            //内贸长单
            if (SelectPricingCurrencyId != 0)
            {
                int cnyCurrencyId = GetCNY();
                LoadRate(cnyCurrencyId, SelectPricingCurrencyId);
            }
            else
            {
                SettlementRate = null;
            }
            //}
        }

        #endregion

        public override bool Validate()
        {
            if (!ImplementedDate.HasValue)
            {
                throw new Exception(ResContract.ImplementedDateNotNull);
            }
            if (CommodityId == 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }
            if (CommodityTypeId == 0)
            {
                throw new Exception(Properties.Resources.CommodityTypeRequired);
            }
            if (SelectPricingType == 0)
            {
                throw new Exception(ResContract.PricingTypeNotNull);
            }
            if (!Quantity.HasValue)
            {
                throw new Exception(ResContract.QuantityNotNull);
            }
            if (SelectPricingCurrencyId == 0)
            {
                throw new Exception(ResContract.PricingCurrencyNotNull);
            }
            if (SelectPricingType == (int)PricingType.Average)
            {
                if (SelectPricingBasis == 0 || SelectPricingBasis == 0)
                {
                    throw new Exception(ResContract.PricingRefNotNull);
                }
                if (!PricingStartDate.HasValue)
                {
                    throw new Exception(ResContract.PricingStartDateNotNull);
                }
                if (!PricingEndDate.HasValue)
                {
                    throw new Exception(ResContract.PricingEndDateNotNull);
                }
                if (PricingStartDate.Value > PricingEndDate.Value)
                {
                    throw new Exception("点价开始日期不能大于点价结束日期");
                }
            }
            else if (SelectPricingType == (int)PricingType.Manual)
            {
                if (TradeType == DBEntity.EnumEntity.TradeType.LongDomesticTrade || TradeType == DBEntity.EnumEntity.TradeType.ShortDomesticTrade)
                {
                    if (!Price.HasValue)
                    {
                        throw new Exception(Properties.Resources.PriceNotNull);
                    }
                }
                if (SelectPricingBasis == 0 || SelectPricingBasis == 0)
                {
                    throw new Exception(ResContract.PricingRefNotNull);
                }
                if (!PricingStartDate.HasValue)
                {
                    throw new Exception(ResContract.PricingStartDateNotNull);
                }
                if (!PricingEndDate.HasValue)
                {
                    throw new Exception(ResContract.PricingEndDateNotNull);
                }
                if (PricingStartDate.Value > PricingEndDate.Value)
                {
                    throw new Exception("点价开始日期不能大于点价结束日期");
                }
                if (!Premium.HasValue)
                {
                    throw new Exception(ResContract.PremiumNotNull);
                }
            }
            else if (SelectPricingType == (int)PricingType.Fixed)
            {
                //固定价点价
                if (!Price.HasValue)
                {
                    throw new Exception(Properties.Resources.PriceNotNull);
                }
                //if (TradeType == TradeType.LongDomesticTrade)
                //{
                if (!SettlementRate.HasValue)
                {
                    throw new Exception(Properties.Resources.ExchangeRateNotNull);
                }
                //}
            }
            return true;
        }

        /// <summary>
        /// 从页面数据生成批次对象，供保存用
        /// </summary>
        /// <returns></returns>
        private Quota SetQuotaByPage()
        {
            if (SelectPaymentMeanId.HasValue && SelectPaymentMeanId.Value == 0)
            {
                SelectPaymentMeanId = null;
            }
            GetPricingSide();
            var currentQuota = new Quota();
            if (ObjectId == 0)
            {
                int id = GetQuotaId();
                currentQuota.Id = id;
            }
            else
            {
                currentQuota.Id = ObjectId;
            }

            currentQuota.QuotaNo = QuotaNo;
            currentQuota.AutoQuotaNo = AutoQuotaNo;//对手批次号
            currentQuota.ExQuotaNo = ExQuotaNo;
            currentQuota.ImplementedDate = ImplementedDate;
            currentQuota.Quantity = Quantity;
            currentQuota.ApproveStatus = ApproveStatus;
            currentQuota.FinanceStatus = FinanceStatus == 1;
            currentQuota.DeliveryStatus = DeliveryStatus == 1;
            currentQuota.CommodityId = CommodityId ?? 0;
            currentQuota.Commodity = GetCommodityById((int)currentQuota.CommodityId);
            currentQuota.CommodityTypeId = CommodityTypeId ?? 0;
            currentQuota.CommodityType = GetCommodityTypeById((int)currentQuota.CommodityTypeId);
            currentQuota.BrandId = BrandId ?? 0;
            currentQuota.Brand = GetBrandById((int)currentQuota.BrandId);
            currentQuota.SpecificationId = SpecificationId ?? 0;
            currentQuota.Specification = GetSpecificationById((int)currentQuota.SpecificationId);
            currentQuota.PricingType = SelectPricingType;
            currentQuota.PricingStartDate = PricingStartDate;
            currentQuota.PricingEndDate = PricingEndDate;
            currentQuota.Price = Price ?? 0;
            if (PricingSide != null) currentQuota.PricingSide = (int)PricingSide;
            currentQuota.Premium = Premium;
            currentQuota.WarehouseId = WarehouseId;
            currentQuota.DeliveryDate = DeliveryDate;
            currentQuota.StrPrice = Price == null ? "" : Price.Value.ToString(RoundRules.STR_PRICE);
            currentQuota.IsDraft = IsSaveAsDraft;
            currentQuota.PricingCurrencyId = SelectPricingCurrencyId;
            currentQuota.SettlementRate = null;
            currentQuota.ShipTerm = ShipTerm;
            currentQuota.PaymentMeanId = SelectPaymentMeanId;
            if (SelectPricingType == (int)PricingType.Fixed)
            {
                //固定价点价
                //if (TradeType == TradeType.LongDomesticTrade)
                //{
                //内贸长单(取CNY,设置汇率)
                currentQuota.SettlementRate = SettlementRate;
                //}
                currentQuota.PricingBasis = null;
            }
            else
            {
                //if (SelectPricingType == (int)PricingType.Manual)
                //{
                //    //手工点价
                //    currentQuota.TempPrice = Price ?? 0;
                //    currentQuota.Price = 0;
                //}
                currentQuota.PricingBasis = SelectPricingBasis;
            }
            currentQuota.VATInvoiceDate = VATInvoiceDate;
            return currentQuota;
        }

        private int GetCNY()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currency currency = currencyService.GetCurrencyByCode("CNY");
                if (currency != null)
                {
                    return currency.Id;
                }

                throw new Exception(ResContract.CNYNotFound);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void Create()
        {
            if (AddedQuotas == null)
            {
                AddedQuotas = new List<Quota>();
            }
            if (Quotas == null)
            {
                Quotas = new List<Quota>();
            }
            Quota currentQuota = SetQuotaByPage();
            AddedQuotas.Add(currentQuota);
            Quotas.Add(currentQuota);
            Quotas = Quotas.OrderByDescending(c => c.Id).ToList();
        }

        private int GetQuotaId()
        {
            if (Quotas.Count == 0)
                return -1;
            IEnumerable<int> query = from quota in Quotas select Math.Abs(quota.Id);
            int no = query.Max();
            return -(no + 1);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected override void Update()
        {
            Quota currentQuota = SetQuotaByPage();

            if (ObjectId > 0)
            {
                //编辑已添加过的
                if (ContainsQuota(ObjectId, UpdatedQuotas))
                {
                    Quota oldUQuota = GetQuotaFromList(ObjectId, UpdatedQuotas);
                    if (oldUQuota != null)
                    {
                        UpdatedQuotas.Remove(oldUQuota);
                    }
                }
                if (UpdatedQuotas == null)
                    UpdatedQuotas = new List<Quota>();
                UpdatedQuotas.Add(currentQuota);
            }
            else if (ObjectId < 0)
            {
                //新增的重新编辑
                if (ContainsQuota(ObjectId, AddedQuotas))
                {
                    Quota oldAQuota = GetQuotaFromList(ObjectId, AddedQuotas);
                    if (oldAQuota != null)
                    {
                        AddedQuotas.Remove(oldAQuota);
                    }
                    if (AddedQuotas == null)
                        AddedQuotas = new List<Quota>();
                    AddedQuotas.Add(currentQuota);
                }
            }
            //维护合并的列表
            Quota oldQuotas = GetQuotaFromList(ObjectId, Quotas);
            if (oldQuotas != null)
            {
                Quotas.Remove(oldQuotas);
            }
            Quotas.Add(currentQuota);
            Quotas = Quotas.OrderByDescending(c => c.Id).ToList();
        }

        /// <summary>
        /// 判断点价方
        /// </summary>
        private void GetPricingSide()
        {
            if (PricingSideTheir)
            {
                PricingSide = (int)DBEntity.EnumEntity.PricingSide.TheirSide;
            }
            else if (PricingSideOwn)
            {
                PricingSide = (int)DBEntity.EnumEntity.PricingSide.OurSide;
            }
        }

        #endregion

        #region 加载编辑状态下的控件enable属性

        //成员变量
        private bool _isCommodityEnable;
        private bool _isPremiumEnable;
        private bool _isPriceEnable;
        private bool _isPricingBasisEnable;
        private bool _isPricingEndDateEnable;
        private bool _isPricingStartDateEnable;
        private bool _isPricingTypeEnable;
        private bool _isQuantityEnable;
        private bool _isSaveAsDraftEnable;
        private bool _isImplDateEnable;

        //属性
        public bool IsPriceEnable
        {
            get { return _isPriceEnable; }
            set
            {
                if (_isPriceEnable != value)
                {
                    _isPriceEnable = value;
                    Notify("IsPriceEnable");
                }
            }
        }

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

        public bool IsPricingBasisEnable
        {
            get { return _isPricingBasisEnable; }
            set
            {
                if (_isPricingBasisEnable != value)
                {
                    _isPricingBasisEnable = value;
                    Notify("IsPricingBasisEnable");
                }
            }
        }

        public bool IsPricingStartDateEnable
        {
            get { return _isPricingStartDateEnable; }
            set
            {
                if (_isPricingStartDateEnable != value)
                {
                    _isPricingStartDateEnable = value;
                    Notify("IsPricingStartDateEnable");
                }
            }
        }

        public bool IsPricingEndDateEnable
        {
            get { return _isPricingEndDateEnable; }
            set
            {
                if (_isPricingEndDateEnable != value)
                {
                    _isPricingEndDateEnable = value;
                    Notify("IsPricingEndDateEnable");
                }
            }
        }

        public bool IsCommodityEnable
        {
            get { return _isCommodityEnable; }
            set
            {
                if (_isCommodityEnable != value)
                {
                    _isCommodityEnable = value;
                    Notify("IsCommodityEnable");
                }
            }
        }

        public bool IsPremiumEnable
        {
            get { return _isPremiumEnable; }
            set
            {
                if (_isPremiumEnable != value)
                {
                    _isPremiumEnable = value;
                    Notify("IsPremiumEnable");
                }
            }
        }

        public bool IsPricingTypeEnable
        {
            get { return _isPricingTypeEnable; }
            set
            {
                if (_isPricingTypeEnable != value)
                {
                    _isPricingTypeEnable = value;
                    Notify("IsPricingTypeEnable");
                }
            }
        }

        public bool IsSaveAsDraftEnable
        {
            get { return _isSaveAsDraftEnable; }
            set
            {
                if (_isSaveAsDraftEnable != value)
                {
                    _isSaveAsDraftEnable = value;
                    Notify("IsSaveAsDraftEnable");
                }
            }
        }

        public bool IsImplDateEnable
        {
            get { return _isImplDateEnable; }
            set
            {
                if (_isImplDateEnable != value)
                {
                    _isImplDateEnable = value;
                    Notify("IsImplDateEnable");
                }
            }
        }

        private void LoadDocumentLineEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsPriceEnable = true;
                IsQuantityEnable = true;
                IsPricingBasisEnable = true;
                IsPricingStartDateEnable = true;
                IsPricingEndDateEnable = true;
                IsCommodityEnable = true;
                IsPremiumEnable = true;
                IsPricingTypeEnable = true;
                IsSaveAsDraftEnable = true;
                IsImplDateEnable = true;
            }
            else
            {
                IsSaveAsDraftEnable = false;

                using (var quotaService =
                    SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    QuotaEnableProperty qep = quotaService.SetElementsEnableProperty(id);
                    IsCommodityEnable = qep.IsCommodityEnable;
                    IsPremiumEnable = qep.IsPremiumEnable;
                    IsPriceEnable = qep.IsPriceEnable;
                    IsPricingBasisEnable = qep.IsPricingBasisEnable;
                    IsPricingEndDateEnable = qep.IsPricingEndDateEnable;
                    IsPricingStartDateEnable = qep.IsPricingStartDateEnable;
                    IsQuantityEnable = qep.IsQuantityEnable;
                    IsPricingTypeEnable = qep.IsPricingTypeEnable;
                    IsImplDateEnable = qep.IsImplDateEnable;
                }
            }
        }

        #endregion

        #region 维护列表

        /// <summary>
        /// 判断列表是否包含指定批次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quotas"></param>
        /// <returns></returns>
        private bool ContainsQuota(int id, IEnumerable<Quota> quotas)
        {
            if (quotas != null)
            {
                return quotas.Any(quota => quota.Id == id);
            }
            return false;
        }

        /// <summary>
        /// 根据列表和id返回批次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quotas"></param>
        /// <returns></returns>
        private Quota GetQuotaFromList(int id, IEnumerable<Quota> quotas)
        {
            if (quotas != null)
            {
                return quotas.FirstOrDefault(quota => quota.Id == id);
            }
            return null;
        }

        #endregion

        #region 根据点价基准获取价格币种

        public void SetCurrencyByPricingBasis()
        {
            if (SelectPricingBasis != 0 && SelectPricingType != (int)PricingType.Fixed)
            {
                using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                {
                    var pb = (PricingBasis)SelectPricingBasis;
                    SelectPricingCurrencyId = pricingService.GetCurrencyByPricingBasis(pb).Id;
                }
            }
        }

        #endregion

        private void SetPaymentMean()
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMean = new Dictionary<string, int> { { "", 0 } };
                List<PaymentMean> paymentmeans = paymentMeanService.GetAll();
                foreach (PaymentMean paymentmean in paymentmeans)
                {
                    PaymentMean.Add(paymentmean.Name, paymentmean.Id);
                }
            }
        }

        /// <summary>
        /// 如果是关联交易，没有填写对手盘批次号给出提示
        /// </summary>
        /// <returns></returns>
        public bool IsPopupContraryDocumentNoEmptyInfo()
        {
            if (TradeType == TradeType.LongDomesticTrade || TradeType == TradeType.ShortDomesticTrade)
                return false;
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                BusinessPartner bp = busService.SelectById(null, _BpId ?? 0);
                if (bp != null && bp.CustomerType == (int)BusinessPartnerType.InternalCustomer)
                {
                    if (string.IsNullOrEmpty(AutoQuotaNo))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectPricingCurrencyId":
                    LoadRate();
                    break;
                default:
                    break;
            }
        }
    }
}