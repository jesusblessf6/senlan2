using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityServiceReference;
using Client.CountryServiceReference;
using Client.View.SystemSetting.CommoditySetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommoditySetting
{
    public class BrandDetailVM : BaseVM
    {
        private List<Commodity> _commodities;
        private int _commodityId;
        private int _commodityTypeId;
        private List<CommodityType> _commodityTypes;
        private List<Country> _countries;
        private int? _countryId;
        private string _description;
        private string _name;

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
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

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
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

        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                Notify("Countries");
            }
        }

        #endregion

        #region Constructor

        public BrandDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public BrandDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                _countries = countryService.GetAll();
                _countries.Insert(0, new Country {Id = 0, ChineseName = string.Empty});
            }

            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commodityService.GetAll();
                _commodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            _commodityTypes = new List<CommodityType>();
            _commodityTypes.Insert(0, new CommodityType {Id = 0, Name = ""});

            if (ObjectId > 0)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
                {
                    Brand brand = brandService.GetById(ObjectId);

                    if (brand != null)
                    {
                        Name = brand.Name;
                        Description = brand.Description;
                        CountryId = brand.CountryId ?? 0;
                        CommodityId = brand.CommodityId;
                        CommodityTypeId = brand.CommodityTypeId;
                    }
                }
            }
            else
            {
                CountryId = 0;
                CommodityId = 0;
                CommodityTypeId = 0;
            }
        }

        protected override void Create()
        {
            var brand = new Brand
                            {
                                Name = Name,
                                Description = Description,
                                CountryId = CountryId == 0 ? null : CountryId,
                                CommodityId = CommodityId,
                                CommodityTypeId = CommodityTypeId
                            };

            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                brandService.AddNewBrand(brand, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                Brand brand = brandService.GetById(ObjectId);
                if (brand != null)
                {
                    brand.Name = Name;
                    brand.Description = Description;
                    brand.CountryId = CountryId == 0 ? null : CountryId;
                    brand.CommodityId = CommodityId;
                    brand.CommodityTypeId = CommodityTypeId;

                    brandService.UpdateExistedBrand(brand, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResCommoditySetting.BrandNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(Properties.Resources.BrandRequired);
            }
            if (CommodityId <= 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }
            if (CommodityTypeId <= 0)
            {
                throw new Exception(Properties.Resources.CommodityTypeRequired);
            }

            return true;
        }

        #endregion

        #region Event

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "CommodityId")
            {
                CommodityTypeId = -1;
                if (CommodityId == 0)
                {
                    CommodityTypes = new List<CommodityType> {new CommodityType {Id = 0, Name = ""}};
                    CommodityTypeId = 0;
                }
                else
                {
                    using (
                        var commodityService =
                            SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
                    {
                        Commodity commodity = commodityService.FetchById(CommodityId,
                                                                         new List<string> {"CommodityTypes"});
                        List<CommodityType> tmp = commodity.CommodityTypes.ToList();
                        tmp.Insert(0, new CommodityType {Id = 0, Name = ""});
                        CommodityTypes = tmp;
                        CommodityTypeId = 0;
                    }
                }
            }
        }

        #endregion
    }
}