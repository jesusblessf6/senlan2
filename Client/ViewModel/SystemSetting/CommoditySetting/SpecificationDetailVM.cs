using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using Client.SpecificationServiceReference;
using Client.View.SystemSetting.CommoditySetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommoditySetting
{
    public class SpecificationDetailVM : BaseVM
    {
        #region Member

        private List<Commodity> _commodities;
        private int _commodityId;
        private int _commodityTypeId;
        private List<CommodityType> _commodityTypes;
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

        #endregion

        #region Constructor

        public SpecificationDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public SpecificationDetailVM(int specificationId)
        {
            ObjectId = specificationId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commodityService.GetAll();
                _commodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            _commodityTypes = new List<CommodityType>();
            _commodityTypes.Insert(0, new CommodityType {Id = 0, Name = ""});

            if (ObjectId > 0)
            {
                using (
                    var specificationService =
                        SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
                {
                    Specification specification = specificationService.GetById(ObjectId);

                    if (specification != null)
                    {
                        Name = specification.Name;
                        Description = specification.Description;
                        CommodityId = specification.CommodityId;
                        CommodityTypeId = specification.CommodityTypeId;
                    }
                }
            }
            else
            {
                CommodityId = 0;
                CommodityTypeId = 0;
            }
        }

        protected override void Create()
        {
            var specification = new Specification
                                    {
                                        Name = Name,
                                        Description = Description,
                                        CommodityId = CommodityId,
                                        CommodityTypeId = CommodityTypeId
                                    };

            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                specificationService.AddNewSpecification(specification, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                Specification specification = specificationService.GetById(ObjectId);
                if (specification != null)
                {
                    specification.Name = Name;
                    specification.Description = Description;
                    specification.CommodityId = CommodityId;
                    specification.CommodityTypeId = CommodityTypeId;

                    specificationService.UpdateExistedSpecification(specification, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResCommoditySetting.SpecificationNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(Properties.Resources.SpecificationRequired);
            }
            if (CommodityId == 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }
            if (CommodityTypeId == 0)
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