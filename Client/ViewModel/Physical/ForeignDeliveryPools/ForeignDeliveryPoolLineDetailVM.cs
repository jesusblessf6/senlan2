using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityTypeServiceReference;
using Client.CountryServiceReference;
using Client.SpecificationServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.ForeignDeliveryPools
{
    public class ForeignDeliveryPoolLineDetailVM : ObjectBaseVM
    {
        #region Members & Properties

        public ForeignDeliveryPoolDetailVM ParentVM { get; set; }

        private List<CommodityType> _commodityTypes;
        public List<CommodityType> CommodityTypes
        {
            get { return _commodityTypes; }
            set
            {
                _commodityTypes = value;
                Notify("CommodityTypes");
            }
        }

        private int _selectedCommodityTypeId;
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

        private List<Brand> _brands;
        public List<Brand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                Notify("Brands");
            }
        }

        private int _selectedBrandId;
        public int SelectedBrandId
        {
            get { return _selectedBrandId; }
            set
            {
                if (_selectedBrandId != value)
                {
                    _selectedBrandId = value;
                    Notify("SelectedBrandId");
                }
            }
        }

        private List<Specification> _specifications;
        public List<Specification> Specifications
        {
            get { return _specifications; }
            set
            {
                _specifications = value;
                Notify("Specifications");
            }
        }

        private int _selectedSpecificationId;
        public int SelectedSpecificationId
        {
            get { return _selectedSpecificationId; }
            set
            {
                if (_selectedSpecificationId != value)
                {
                    _selectedSpecificationId = value;
                    Notify("SelectedSpecificationId");
                }
            }
        }

        private string _pbNo;
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

        private decimal? _netWeight;
        public decimal? NetWeight
        {
            get { return _netWeight; }
            set
            {
                if (_netWeight != value)
                {
                    _netWeight = value;
                    Notify("NetWeight");
                }
            }
        }

        private decimal? _grossWeight;
        public decimal? GrossWeight
        {
            get { return _grossWeight; }
            set
            {
                if (_grossWeight != value)
                {
                    _grossWeight = value;
                    Notify("GrossWeight");
                }
            }
        }

        private List<Country> _countries;
        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                Notify("Countries");
            }
        }

        private int _selectedCountryId;
        public int SelectedCountryId
        {
            get { return _selectedCountryId; }
            set
            {
                if (_selectedCountryId != value)
                {
                    _selectedCountryId = value;
                    Notify("SelectedCountryId");
                }
            }
        }

        private decimal? _packingQuantity;
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

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    Notify("Comments");
                }
            }
        }

        #region Members & Properties related to the items' atttibutes

        public string VisibilityForWR
        {
            get
            {
                if (ParentVM.DeliveryTypeId == (int)DeliveryType.ExternalTDBOL)
                {
                    return "Collapsed";
                }

                if (ParentVM.DeliveryTypeId == (int)DeliveryType.ExternalTDWW)
                {
                    return "Visible";
                }

                return "Collapsed";
            }
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Add new line
        /// </summary>
        /// <param name="parentVM"></param>
        public ForeignDeliveryPoolLineDetailVM(ForeignDeliveryPoolDetailVM parentVM)
        {
            ParentVM = parentVM;
            Initialize();
        }

        /// <summary>
        /// Edit/View Line
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentVM"></param>
        public ForeignDeliveryPoolLineDetailVM(int id, ForeignDeliveryPoolDetailVM parentVM)
        {
            ParentVM = parentVM;
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        protected override void Create()
        {
            var line = new ForeignDeliveryPoolLine
                           {
                               CommodityTypeId = ConvertZeroToNull(SelectedCommodityTypeId),
                               BrandId = ConvertZeroToNull(SelectedBrandId),
                               SpecificationId = ConvertZeroToNull(SelectedSpecificationId),
                               PBNo = PBNo,
                               NetWeight = NetWeight,
                               GrossWeight = GrossWeight,
                               OriginCountryId = ConvertZeroToNull(SelectedCountryId),
                               PackingQuantity = PackingQuantity,
                               Comment = Comments,
                               Id = -(ParentVM.Details.Count + 1),
                           };

            line.CommodityType = SelectedCommodityTypeId > 0
                                     ? _commodityTypes.Single(o => o.Id == _selectedCommodityTypeId)
                                     : null;
            line.Brand = SelectedBrandId > 0 ? _brands.Single(o => o.Id == _selectedBrandId) : null;
            line.Specification = SelectedSpecificationId > 0
                                     ? _specifications.Single(o => o.Id == _selectedSpecificationId)
                                     : null;
            line.OriginCountry = SelectedCountryId > 0 ? _countries.Single(o => o.Id == _selectedCountryId) : null;

            ParentVM.Details.Add(line);
            ParentVM.NewAddedLines.Add(line);
            ParentVM.IsCommodityEnable = false;
        }

        protected override void Update()
        {
            var line = ParentVM.Details.Single(o => o.Id == ObjectId);

            line.CommodityTypeId = ConvertZeroToNull(SelectedCommodityTypeId);
            line.CommodityType = SelectedCommodityTypeId > 0 ? _commodityTypes.Single(o => o.Id == _selectedCommodityTypeId) : null;
            line.BrandId = ConvertZeroToNull(SelectedBrandId);
            line.Brand = SelectedBrandId > 0 ? _brands.Single(o => o.Id == _selectedBrandId) : null;
            line.SpecificationId = ConvertZeroToNull(SelectedSpecificationId);
            line.Specification = SelectedSpecificationId > 0 ? _specifications.Single(o => o.Id == _selectedSpecificationId) : null;
            line.PBNo = PBNo;
            line.NetWeight = NetWeight;
            line.GrossWeight = GrossWeight;
            line.OriginCountryId = ConvertZeroToNull(SelectedCountryId);
            line.OriginCountry = SelectedCountryId > 0 ? _countries.Single(o => o.Id == _selectedCountryId) : null;
            line.PackingQuantity = PackingQuantity;
            line.Comment = Comments;

            if (ObjectId > 0 && ParentVM.ModifiedLines.All(o => o.Id != ObjectId))
            {
                //if the line is existed line and 
                //not in the modified lines list, 
                //then add it into the list
                ParentVM.ModifiedLines.Add(line);
            }
        }

        public override bool Validate()
        {
            if (PackingQuantity < 0)
            {
                throw new Exception("捆数必须为正整数");
            }

            if (SelectedCommodityTypeId == 0)
            {
                throw new Exception("请选择金属类型");
            }

            return true;
        }

        private void Initialize()
        {
            using (var commTypeService = SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                _commodityTypes = commTypeService.GetCommodityTypesByCommodity(ParentVM.SelectedCommodityId);
                _commodityTypes.Insert(0, new CommodityType());
            }

            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                _countries = countryService.GetAll();
                _countries.Insert(0, new Country());
            }

            _brands = new List<Brand> { new Brand() };
            _specifications = new List<Specification> { new Specification() };

            if (ObjectId != 0)
            {
                var detail = ParentVM.Details.Single(o => o.Id == ObjectId);
                _selectedCommodityTypeId = detail.CommodityTypeId ?? 0;

                if (_selectedCommodityTypeId > 0)
                {
                    using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                    {
                        _brands = brandService.GetBrandsWith(_selectedCommodityTypeId, ParentVM.SelectedCommodityId).OrderBy(o => o.Name).ToList();
                        _brands.Insert(0, new Brand());
                        _selectedBrandId = detail.BrandId ?? 0;
                    }

                    using (var specService = SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                    {
                        _specifications = specService.GetSpecificationsWith(ParentVM.SelectedCommodityId,
                                                                            _selectedCommodityTypeId);
                        _specifications.Insert(0, new Specification());
                        _selectedSpecificationId = detail.SpecificationId ?? 0;
                    }
                }

                _pbNo = detail.PBNo;
                _netWeight = detail.NetWeight;
                _grossWeight = detail.GrossWeight;
                _selectedCountryId = detail.OriginCountryId ?? 0;
                _packingQuantity = detail.PackingQuantity;
                _comments = detail.Comment;
            }

            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Event

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedCommodityTypeId":
                    using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                    {
                        var brands = brandService.GetBrandsWith(_selectedCommodityTypeId, ParentVM.SelectedCommodityId).OrderBy(o => o.Name).ToList();
                        brands.Insert(0, new Brand());
                        Brands = brands;
                        SelectedBrandId = -1;
                        SelectedBrandId = 0;
                    }

                    using (var specService = SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                    {
                        var specs = specService.GetSpecificationsWith(ParentVM.SelectedCommodityId,
                                                                      _selectedCommodityTypeId);
                        specs.Insert(0, new Specification());
                        Specifications = specs;
                        SelectedSpecificationId = -1;
                        SelectedSpecificationId = 0;
                    }
                    break;

                case "SelectedBrandId":
                    if (SelectedBrandId != 0)
                    {
                        using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                        {
                            Brand brand = brandService.GetById(SelectedBrandId);
                            if (brand != null)
                            {
                                if (brand.CountryId.HasValue)
                                {
                                    using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
                                    {
                                        Country country = countryService.GetById(brand.CountryId.Value);
                                        _countries.Clear();
                                        if (country != null)
                                        {
                                            _countries.Add(country);
                                        }
                                        _countries.Insert(0, new Country());
                                        Countries = _countries;
                                        SelectedCountryId = country == null ? 0 :country.Id;
                                    }

                                    break;
                                }
                            }
                        }
                    }
                    using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
                    {
                        _countries = countryService.GetAll();
                        _countries.Insert(0, new Country());
                        Countries = _countries;
                        SelectedCountryId = -1;
                        SelectedCountryId = 0;
                    }
                    
                    break;
            }
        }

        #endregion
    }
}
