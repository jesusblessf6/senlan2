using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BrandServiceReference;
using Client.CommodityServiceReference;
using Client.CommodityTypeServiceReference;
using Client.SpecificationServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommoditySetting
{
    public class CommodityHomeVM : BaseVM
    {
        #region Member

        private List<Commodity> _searchCommodities;
        private int? _searchCommodityId;
        private int? _searchCommodityTypeId;
        private List<CommodityType> _searchCommodityTypes;
        private int _brandCount;
        private int _brandFrom;
        private int _brandTo;
        private List<Brand> _brands;
        private List<Commodity> _commodities;

        private int _commodityCount;
        private int _commodityFrom;
        private int _commodityTo;

        private int _commodityTypeCount;
        private int _commodityTypeFrom;
        private int _commodityTypeTo;
        private List<CommodityType> _commodityTypes;

        private int _specificationCount;
        private int _specificationFrom;
        private int _specificationTo;
        private List<Specification> _specifications;
        private string _BrandName;
        #endregion

        #region Property
        public string BrandName
        {
            get { return _BrandName; }
            set { 
                if(_BrandName != value)
                {
                    _BrandName = value;
                    Notify("BrandName");
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

        public List<Commodity> SearchCommodities
        {
            get { return _searchCommodities; }
            set
            {
                _searchCommodities = value;
                Notify("SearchCommodities");
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

        public List<CommodityType> SearchCommodityTypes
        {
            get { return _searchCommodityTypes; }
            set
            {
                _searchCommodityTypes = value;
                Notify("SearchCommodityTypes");
            }
        }

        public int? SearchCommodityId
        {
            get { return _searchCommodityId; }
            set
            {
                _searchCommodityId = value;
                Notify("SearchCommodityId");
            }
        }

        public int? SearchCommodityTypeId
        {
            get { return _searchCommodityTypeId; }
            set
            {
                _searchCommodityTypeId = value;
                Notify("SearchCommodityTypeId");
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

        public List<Brand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                Notify("Brands");
            }
        }

        public int CommodityCount
        {
            get { return _commodityCount; }
            set
            {
                if (_commodityCount != value)
                {
                    _commodityCount = value;
                    Notify("CommodityCount");
                }
            }
        }

        public int CommodityTypeCount
        {
            get { return _commodityTypeCount; }
            set
            {
                if (_commodityTypeCount != value)
                {
                    _commodityTypeCount = value;
                    Notify("CommodityTypeCount");
                }
            }
        }

        public int BrandCount
        {
            get { return _brandCount; }
            set
            {
                if (_brandCount != value)
                {
                    _brandCount = value;
                    Notify("BrandCount");
                }
            }
        }

        public int SpecificationCount
        {
            get { return _specificationCount; }
            set
            {
                if (_specificationCount != value)
                {
                    _specificationCount = value;
                    Notify("SpecificationCount");
                }
            }
        }

        public int CommodityFrom
        {
            get { return _commodityFrom; }
            set
            {
                if (_commodityFrom != value)
                {
                    _commodityFrom = value;
                    Notify("CommodityFrom");
                }
            }
        }

        public int CommodityTypeFrom
        {
            get { return _commodityTypeFrom; }
            set
            {
                if (_commodityTypeFrom != value)
                {
                    _commodityTypeFrom = value;
                    Notify("CommodityTypeFrom");
                }
            }
        }

        public int BrandFrom
        {
            get { return _brandFrom; }
            set
            {
                if (_brandFrom != value)
                {
                    _brandFrom = value;
                    Notify("BrandFrom");
                }
            }
        }

        public int SpecificationFrom
        {
            get { return _specificationFrom; }
            set
            {
                if (_specificationFrom != value)
                {
                    _specificationFrom = value;
                    Notify("SpecificationFrom");
                }
            }
        }

        public int CommodityTo
        {
            get { return _commodityTo; }
            set
            {
                if (_commodityTo != value)
                {
                    _commodityTo = value;
                    Notify("CommodityTo");
                }
            }
        }

        public int CommodityTypeTo
        {
            get { return _commodityTypeTo; }
            set
            {
                if (_commodityTypeTo != value)
                {
                    _commodityTypeTo = value;
                    Notify("CommodityTypeTo");
                }
            }
        }

        public int BrandTo
        {
            get { return _brandTo; }
            set
            {
                if (_brandTo != value)
                {
                    _brandTo = value;
                    Notify("BrandTo");
                }
            }
        }

        public int SpecificationTo
        {
            get { return _specificationTo; }
            set
            {
                if (_specificationTo != value)
                {
                    _specificationTo = value;
                    Notify("SpecificationTo");
                }
            }
        }

        #endregion

        #region Constructor

        public CommodityHomeVM()
        {
            _commodities = new List<Commodity>();
            LoadCommodityCount();

            _commodityTypes = new List<CommodityType>();
            LoadCommodityTypeCount();

            _brands = new List<Brand>();
            LoadBrandCount();

            _specifications = new List<Specification>();
            LoadSpecificationCount();

            PropertyChanged += CommodityHomeVMPropertyChanged;
        }

        #endregion

        #region Method

        protected void CommodityHomeVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchCommodityId")
            {
                if (SearchCommodityId > 0)
                {
                    using (
                        var commodityTypeService =
                            SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
                    {
                        string strInfo = "it.IsDeleted = false and it.CommodityId=" + SearchCommodityId;
                        SearchCommodityTypes = commodityTypeService.Select(strInfo, null, null);
                        SearchCommodityTypes.Insert(0, new CommodityType {Id = 0, Name = ""});
                    }
                }
            }
        }

        public void LoadCommodityCount()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodityCount = commodityService.GetAllCount();
            }
        }

        public void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commodityService.GetByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                    CommodityFrom, CommodityTo);
            }
        }


        public void LoadCommodityTypeCount()
        {
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams2(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    _commodityTypeCount = commodityTypeService.GetAllCount();
                }
                else
                {
                    _commodityTypeCount = commodityTypeService.Select(queryStr, parameters,
                                                                                 new List<string> { "Commodity" }).Count;
                }
            }
        }

        public void LoadCommodityType()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                const string strInfo = "it.IsDeleted = false";
                SearchCommodities = commodityService.Select(strInfo, null, null);
                SearchCommodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams2(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    CommodityTypes =
                        commodityTypeService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                   CommodityTypeFrom, CommodityTypeTo,
                                                                   new List<string> {"Commodity"});
                }
                else
                {
                    CommodityTypes = commodityTypeService.SelectByRangeWithOrder(queryStr, parameters,
                                                                                 new SortCol
                                                                                     {
                                                                                         ByDescending = true,
                                                                                         ColName = "Id"
                                                                                     }, BrandFrom,
                                                                                 BrandTo,
                                                                                 new List<string> {"Commodity"});
                }
            }
        }

        public void LoadBrandCount()
        {
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    _brandCount = brandService.GetAllCount();
                }
                else
                {
                    _brandCount = brandService.Select(queryStr, parameters,
                                                                 new List<string> { "Commodity", "CommodityType", "Country" }).Count;
                }
            }
        }

        public void LoadBrand()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                const string strInfo = "it.IsDeleted = false";
                SearchCommodities = commodityService.Select(strInfo, null, null);
                SearchCommodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                const string strInfo = "it.IsDeleted = false";
                SearchCommodityTypes = commodityTypeService.Select(strInfo, null, null);
                SearchCommodityTypes.Insert(0, new CommodityType {Id = 0, Name = ""});
            }

            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    Brands = brandService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                BrandFrom,
                                                                BrandTo,
                                                                new List<string>
                                                                    {"Commodity", "CommodityType", "Country"});
                }
                else
                {
                    Brands = brandService.SelectByRangeWithOrder(queryStr, parameters,
                                                                 new SortCol {ByDescending = true, ColName = "Id"},
                                                                 BrandFrom, BrandTo,
                                                                 new List<string>
                                                                     {"Commodity", "CommodityType", "Country"});
                }
            }
        }

        public void LoadSpecificationCount()
        {
            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    _specificationCount = specificationService.GetAllCount();
                }
                else
                {
                    _specificationCount = specificationService.Select(queryStr, parameters,
                                                                                 new List<string> { "Commodity", "CommodityType" }).Count;
                }
            }
        }

        public void LoadSpecification()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                const string strInfo = "it.IsDeleted = false";
                SearchCommodities = commodityService.Select(strInfo, null, null);
                SearchCommodities.Insert(0, new Commodity {Id = 0, Name = ""});
            }

            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                const string strInfo = "it.IsDeleted = false";
                SearchCommodityTypes = commodityTypeService.Select(strInfo, null, null);
                SearchCommodityTypes.Insert(0, new CommodityType {Id = 0, Name = ""});
            }

            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                if (queryStr == string.Empty)
                {
                    Specifications =
                        specificationService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                   SpecificationFrom, SpecificationTo,
                                                                   new List<string> {"Commodity", "CommodityType"});
                }
                else
                {
                    Specifications = specificationService.SelectByRangeWithOrder(queryStr, parameters,
                                                                                 new SortCol
                                                                                     {
                                                                                         ByDescending = true,
                                                                                         ColName = "Id"
                                                                                     }, BrandFrom,
                                                                                 BrandTo,
                                                                                 new List<string>
                                                                                     {"Commodity", "CommodityType"});
                }
            }
        }


        public void DeleteCommodityType(int id)
        {
            using (
                var commodityTypeService =
                    SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                commodityTypeService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void DeleteBrand(int id)
        {
            using (var brandService = SvcClientManager.GetSvcClient<BrandServiceClient>(SvcType.BrandSvc))
            {
                brandService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void DeleteSpecification(int id)
        {
            using (
                var specificationService =
                    SvcClientManager.GetSvcClient<SpecificationServiceClient>(SvcType.SpecificationSvc))
            {
                specificationService.RemoveById(id, CurrentUser.Id);
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;

            if (SearchCommodityId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Commodity.Id = @p{0} ", num++);
                parameters.Add(SearchCommodityId);
            }
            if (SearchCommodityTypeId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityType.Id = @p{0} ", num);
                parameters.Add(SearchCommodityTypeId);
            }
            if(!string.IsNullOrEmpty(BrandName))
            {
                if(sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Name  Like \'%" + BrandName + "%\'");
                parameters.Add(BrandName);
            }

            queryStr = sb.ToString();
        }

        private void BuildQueryStrAndParams2(out string queryStr, out List<object> parameters)
        {
            parameters = new List<object>();
            var sb = new StringBuilder();
            const int num = 1;

            if (SearchCommodityId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Commodity.Id = @p{0} ", num);
                parameters.Add(SearchCommodityId);
            }

            queryStr = sb.ToString();
        }

        #endregion
    }
}