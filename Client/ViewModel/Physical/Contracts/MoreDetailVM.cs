using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using DBEntity;
using Client.SpecificationServiceReference;
using Utility.ServiceManagement;
using Client.BrandServiceReference;
using Client.WarehouseServiceReference;

namespace Client.ViewModel.Physical.Contracts
{
    public class MoreDetailVM : BaseVM
    {
        #region Member
        private int? _brandId;
        private int? _specificationId;
        private decimal? _price;
        private decimal? _quantity;
        private int? _warehouseId;
        private string _warehouseName;
        private List<QuotaBrandRel> _allQuotaBrandRelList;
        private List<QuotaBrandRel> _addQuotaBrandRelList;
        private List<QuotaBrandRel> _updateQuotaBrandRelList;

        private List<Brand> _brands;
        private int? _commodityId;
        private int? _commodityTypeId;
        private List<Specification> _specifications;

        private int _pricingType;
        #endregion

        #region Property
        public int PricingType
        {
            get { return _pricingType; }
            set { 
                if(_pricingType != value)
                {
                    _pricingType = value;
                    Notify("PricingType");
                }
            }
        }

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

        public List<QuotaBrandRel> UpdateQuotaBrandRelList
        {
            get { return _updateQuotaBrandRelList; }
            set
            {
                if (_updateQuotaBrandRelList != value)
                {
                    _updateQuotaBrandRelList = value;
                    Notify("UpdateQuotaBrandRelList");
                }
            }
        }

        public List<QuotaBrandRel> AddQuotaBrandRelList
        {
            get { return _addQuotaBrandRelList; }
            set
            {
                if (_addQuotaBrandRelList != value)
                {
                    _addQuotaBrandRelList = value;
                    Notify("AddQuotaBrandRelList");
                }
            }
        }

        public List<QuotaBrandRel> AllQuotaBrandRelList
        {
            get { return _allQuotaBrandRelList; }
            set
            {
                if (_allQuotaBrandRelList != value)
                {
                    _allQuotaBrandRelList = value;
                    Notify("AllQuotaBrandRelList");
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
        #endregion

        #region Contrustor
        public MoreDetailVM(int? commodityID, int? commodityTypeID, List<QuotaBrandRel> allList, List<QuotaBrandRel> addList, int pricingType)
        {
            ObjectId = 0;
            AllQuotaBrandRelList = allList;
            AddQuotaBrandRelList = addList;
            CommodityId = commodityID;
            CommodityTypeId = commodityTypeID;
            BrandId = 0;
            SpecificationId = 0;
            PricingType = pricingType;
            LoadBrand();
            LoadSpecification();
        }

        public MoreDetailVM(int quotaBrandRelID, int? commodityID, int? commodityTypeID, List<QuotaBrandRel> allList, List<QuotaBrandRel> addList, List<QuotaBrandRel> updateList, int pricingType)
        {
            ObjectId = quotaBrandRelID;
            AllQuotaBrandRelList = allList;
            AddQuotaBrandRelList = addList;
            UpdateQuotaBrandRelList = updateList;
            CommodityId = commodityID;
            CommodityTypeId = commodityTypeID;
            PricingType = pricingType;
            LoadQuotaBrandRel();
            LoadBrand();
            LoadSpecification();
        }
        #endregion

        #region Method
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
                            if (!Brands.Select(c => c.Id).Contains(BrandId.Value))
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
                            if (!Specifications.Select(c => c.Id).Contains(SpecificationId.Value))
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

        private void LoadQuotaBrandRel()
        {
            if (ObjectId != 0)
            {
                List<QuotaBrandRel> list = AllQuotaBrandRelList.Where(c => c.Id == ObjectId).ToList();
                if (list.Count > 0)
                {
                    QuotaBrandRel quotaBrandRel = list[0];
                    BrandId = quotaBrandRel.BrandId;
                    SpecificationId = quotaBrandRel.SpecificationId;
                    Price = quotaBrandRel.Price;
                    Quantity = quotaBrandRel.Quantity;
                    WarehouseId = quotaBrandRel.WarehouseId;
                    WarehouseName = quotaBrandRel.Warehouse == null ? "" : quotaBrandRel.Warehouse.Name;
                }
            }
        }

        protected override void Create()
        {
            var quotaBrandRel = new QuotaBrandRel();
            if (AllQuotaBrandRelList.Count <= 0)
            {
                quotaBrandRel.Id = -1;
            }
            else
            {
                var lineIdList = AllQuotaBrandRelList.Select(lineId => Math.Abs(lineId.Id)).ToList();
                int maxID = lineIdList.Max();
                quotaBrandRel.Id = -(maxID + 1);
            }
            quotaBrandRel.BrandId = BrandId;
            quotaBrandRel.SpecificationId = SpecificationId;
            quotaBrandRel.Price = Price;
            quotaBrandRel.Quantity = Quantity;
            quotaBrandRel.WarehouseId = WarehouseId;
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                Brand brand = brandService.GetById(BrandId.Value);
                quotaBrandRel.Brand = brand;
            }

            if (SpecificationId.HasValue)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    Specification specification = specificationService.GetById(SpecificationId.Value);
                    quotaBrandRel.Specification = specification;
                }
            }

            if (WarehouseId.HasValue)
            {
                using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                {
                    Warehouse warehouse = warehouseService.GetById(WarehouseId.Value);
                    quotaBrandRel.Warehouse = warehouse;
                }
            }

            AddQuotaBrandRelList.Add(quotaBrandRel);
            AllQuotaBrandRelList.Add(quotaBrandRel);
        }

        protected override void Update()
        {
            var quotaBrandRel = new QuotaBrandRel();
            List<QuotaBrandRel> list = AllQuotaBrandRelList.Where(c => c.Id == ObjectId).ToList();
            if (list.Count > 0)
            {
                QuotaBrandRel quotaBrandRelOld = list[0];
                quotaBrandRel.Id = quotaBrandRelOld.Id;
                quotaBrandRel.BrandId = BrandId;
                quotaBrandRel.SpecificationId = SpecificationId;
                quotaBrandRel.Price = Price;
                quotaBrandRel.Quantity = Quantity;
                quotaBrandRel.WarehouseId = WarehouseId;
                quotaBrandRel.QuotaId = quotaBrandRelOld.QuotaId;
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    Brand brand = brandService.GetById(BrandId.Value);
                    quotaBrandRel.Brand = brand;
                }

                if (SpecificationId.HasValue)
                {
                    using (
                        var specificationService =
                            SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                    {
                        Specification specification = specificationService.GetById(SpecificationId.Value);
                        quotaBrandRel.Specification = specification;
                    }
                }

                if (WarehouseId.HasValue)
                {
                    using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                    {
                        Warehouse warehouse = warehouseService.GetById(WarehouseId.Value);
                        quotaBrandRel.Warehouse = warehouse;
                    }
                }

                AllQuotaBrandRelList.Remove(quotaBrandRelOld);
                AllQuotaBrandRelList.Add(quotaBrandRel);

                if (quotaBrandRelOld.Id < 0)
                {
                    if (AddQuotaBrandRelList.Count > 0)
                    {
                        List<QuotaBrandRel> brandRelList = AddQuotaBrandRelList.Where(c => c.Id == quotaBrandRelOld.Id).ToList();
                        if (brandRelList.Count > 0)
                        {
                            QuotaBrandRel brandRel = brandRelList[0];
                            AddQuotaBrandRelList.Remove(brandRel);
                            AddQuotaBrandRelList.Add(quotaBrandRel);
                        }
                    }
                }
                else
                {
                    if (UpdateQuotaBrandRelList.Count > 0)
                    {
                        List<QuotaBrandRel> updateBrandRelList = UpdateQuotaBrandRelList.Where(c => c.Id == quotaBrandRelOld.Id).ToList();
                        if (updateBrandRelList.Count > 0)
                        {
                            QuotaBrandRel updateBrandRel = updateBrandRelList[0];
                            UpdateQuotaBrandRelList.Remove(updateBrandRel);
                            UpdateQuotaBrandRelList.Add(quotaBrandRel);
                        }
                    }
                }
            }
        }

        public override bool Validate()
        {
            if (!BrandId.HasValue || BrandId <= 0)
            {
                throw new Exception(Properties.Resources.BrandRequired);
            }

            if (!Quantity.HasValue)
            {
                throw new Exception(View.Physical.Contracts.ResContract.QuantityNotNull);
            }

            if (PricingType == (int)DBEntity.EnumEntity.PricingType.Fixed)
            {
                if(!Price.HasValue)
                {
                    throw new Exception(Properties.Resources.PriceNotNull);
                }
            }
            return true;
        }
        #endregion
    }
}
