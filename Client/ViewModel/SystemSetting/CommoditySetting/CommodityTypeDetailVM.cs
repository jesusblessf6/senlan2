using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using Client.CommodityTypeServiceReference;
using Client.View.SystemSetting.CommoditySetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommoditySetting
{
    public class CommodityTypeDetailVM : BaseVM
    {
        #region Member

        private List<Commodity> _commodities;
        private int _commodityId;
        private string _description;
        private string _englishName;
        private bool _isDeleted;
        private string _name;
        private int _selectedCommodityId;

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

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    Notify("IsDeleted");
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

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set { _commodities = value; }
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

        public string EnglishName
        {
            get { return _englishName; }
            set
            {
                if (_englishName != value)
                {
                    _englishName = value;
                    Notify("EnglishName");
                }
            }
        }

        #endregion

        #region Constructor

        public CommodityTypeDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public CommodityTypeDetailVM(int bankId)
        {
            ObjectId = bankId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commodityService.GetAll();
                _commodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            if (ObjectId > 0)
            {
                using (
                    var commodityTypeService =
                        SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                {
                    CommodityType commodityType = commodityTypeService.GetById(ObjectId);

                    if (commodityType != null)
                    {
                        Name = commodityType.Name;
                        Description = commodityType.Description;
                        SelectedCommodityId = commodityType.CommodityId;
                        EnglishName = commodityType.EnglishName;
                    }
                }
            }
            else
            {
                SelectedCommodityId = 0;
            }
        }

        protected override void Create()
        {
            var commodityType = new CommodityType
                                    {
                                        Name = Name,
                                        CommodityId = SelectedCommodityId,
                                        Description = Description,
                                        EnglishName = EnglishName,
                                        IsSystem = false
                                    };

            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                commodityTypeService.AddNewCommodityType(commodityType, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                CommodityType commodityType = commodityTypeService.GetById(ObjectId);
                if (commodityType != null)
                {
                    commodityType.Name = Name;
                    commodityType.CommodityId = SelectedCommodityId;
                    commodityType.Description = Description;
                    commodityType.EnglishName = EnglishName;

                    commodityTypeService.UpdateExistedCommodityType(commodityType, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResCommoditySetting.CommodityTypeNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(Properties.Resources.CommodityTypeRequired);
            }
            if (string.IsNullOrWhiteSpace(EnglishName))
            {
                throw new Exception(ResCommoditySetting.EnglishNameRequired);
            }
            if (SelectedCommodityId <= 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }

            return true;
        }

        #endregion
    }
}