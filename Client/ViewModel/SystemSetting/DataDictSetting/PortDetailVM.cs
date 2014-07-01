using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CountryServiceReference;
using Client.PortServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class PortDetailVM : BaseVM
    {
        #region Members

        private List<Country> _countries;
        private int _countryId;
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

        public int CountryId
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

        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                Notify("Countries");
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

        public PortDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public PortDetailVM(int countryId)
        {
            ObjectId = countryId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                _countries = countryService.GetAll().OrderBy(c => c.ChineseName).ToList();
                _countries.Insert(0, new Country {Id = 0, ChineseName = string.Empty});
            }

            if (ObjectId > 0)
            {
                using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                {
                    Port port = portService.FetchById(ObjectId, new List<string> {"Country"});

                    _countryId = port.Country.Id;
                    _name = port.Name;
                    _description = port.Description;
                }
            }
        }

        protected override void Create()
        {
            var port = new Port
                           {
                               Name = Name,
                               CountryId = CountryId,
                               Description = Description
                           };

            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                portService.AddNewPort(port, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                Port port = portService.GetById(ObjectId);

                if (port != null)
                {
                    port.Name = Name;
                    port.Description = Description;
                    port.CountryId = CountryId;

                    portService.UpdatePort(port, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.PortNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResDataDictSetting.PortNameRequired);
            }
            //if (CountryId == 0)
            //{
            //    throw new Exception(ResDataDictSetting.OriginRequired);
            //}

            return true;
        }

        #endregion
    }
}