using System;
using Client.Base.BaseClientVM;
using Client.CountryServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class CountryDetailVM : BaseVM
    {
        #region Member

        private string _chineseName;
        private string _description;
        private string _name;

        #endregion

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

        public string ChineseName
        {
            get { return _chineseName; }
            set
            {
                if (_chineseName != value)
                {
                    _chineseName = value;
                    Notify("ChineseName");
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

        #endregion

        #region Constructor

        public CountryDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public CountryDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
                {
                    Country country = countryService.GetById(ObjectId);

                    if (country != null)
                    {
                        ChineseName = country.ChineseName;
                        Description = country.Description;
                        Name = country.Name;
                    }
                }
            }
        }

        protected override void Create()
        {
            var country = new Country
                              {
                                  ChineseName = ChineseName,
                                  Description = Description,
                                  Name = Name
                              };

            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                countryService.AddNewCountry(country, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                Country country = countryService.GetById(ObjectId);
                if (country != null)
                {
                    country.ChineseName = ChineseName;
                    country.Description = Description;
                    country.Name = Name;

                    countryService.UpdateCountry(country, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.OriginCountryNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ChineseName))
            {
                throw new Exception(ResDataDictSetting.ChineseNameRequired);
            }

            return true;
        }

        #endregion
    }
}