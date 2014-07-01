using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using Client.View.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;
using Client.CommodityTypeServiceReference;

namespace Client.ViewModel.Physical.Deliveries
{
    public class DeliveryHomeVM : BaseVM
    {
        #region Member

        private DateTime? _endDate = DateTime.Today;
        private List<Commodity> _metals;
        private DeliveryListVM _searchVM;
        private int _selectedMetal;
        private int _selectedTradeType;
        private DateTime? _startDate = DateTime.Today;
        private int _supplierId;
        private string _supplierName;
        private Dictionary<string, int> _tradeTypes;
        private List<EnumItem> _dlvIsVerifieds;
        private int _selectedIsVerified;
        private string _blNo;
        private bool _IsOnlyCurrentUser = true;
        private int _WarehouseId;
        private string _WarehouseName;
        private List<Brand> _brands;
        private int? _selectedBrand;
        private string _quotaNo;
        private List<CommodityType> _CommodityTypes;
        private int _SelectedCommodityId;
        #endregion

        #region Property
        public int SelectedCommodityTypeId
        {
            get { return _SelectedCommodityId; }
            set
            {
                if(_SelectedCommodityId != value)
                {
                    _SelectedCommodityId = value;
                    Notify("SelectedCommodityTypeId");
                }
            }
        }

        public List<CommodityType> CommodityTypes
        {
            get { return _CommodityTypes; }
            set { 
                if(_CommodityTypes != value)
                {
                    _CommodityTypes = value;
                    Notify("CommodityTypes");
                }
            }
        }

        public string WarehouseName
        {
            get { return _WarehouseName; }
            set
            {
                if (_WarehouseName != value)
                {
                    _WarehouseName = value;
                    Notify("WarehouseName");
                }
            }
        }

        public int WarehouseId
        {
            get { return _WarehouseId; }
            set
            {
                if (_WarehouseId != value)
                {
                    _WarehouseId = value;
                    Notify("WarehouseId");
                }
            }
        }

        public bool IsOnlyCurrentUser
        {
            get { return _IsOnlyCurrentUser; }
            set
            {
                if (_IsOnlyCurrentUser != value)
                {
                    _IsOnlyCurrentUser = value;
                    Notify("IsOnlyCurrentUser");
                }
            }
        }

        public string BLNo
        {
            get { return _blNo; }
            set
            {
                if (_blNo != value)
                {
                    _blNo = value;
                    Notify("BLNo");
                }
            }
        }

        public int SelectedIsVerified
        {
            get { return _selectedIsVerified; }
            set
            {
                if (_selectedIsVerified != value)
                {
                    _selectedIsVerified = value;
                    Notify("SelectedIsVerified");
                }
            }
        }

        public List<EnumItem> DlvIsVerifieds
        {
            get { return _dlvIsVerifieds; }
            set
            {
                _dlvIsVerifieds = value;
                Notify("DlvIsVerifieds");
            }
        }

        public Dictionary<string, int> TradeTypes
        {
            get { return _tradeTypes; }
            set
            {
                if (_tradeTypes != value)
                {
                    _tradeTypes = value;
                    Notify("TradeTypes");
                }
            }
        }

        public int SelectedTradeType
        {
            get { return _selectedTradeType; }
            set
            {
                if (_selectedTradeType != value)
                {
                    _selectedTradeType = value;
                    Notify("SelectedTradeType");
                }
            }
        }

        public List<Commodity> Metals
        {
            get { return _metals; }
            set
            {
                if (_metals != value)
                {
                    _metals = value;
                    Notify("Metals");
                }
            }
        }

        public int SelectedMetal
        {
            get { return _selectedMetal; }
            set
            {
                if (_selectedMetal != value)
                {
                    _selectedMetal = value;
                    Notify("SelectedMetal");
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

        public int? SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                if (_selectedBrand != value)
                {
                    _selectedBrand = value;
                    Notify("SelectedBrand");
                }
            }
        }

        /// <summary>`
        /// 供应商ID
        /// </summary>
        public int SupplierId
        {
            get { return _supplierId; }
            set
            {
                if (_supplierId != value)
                {
                    _supplierId = value;
                    Notify("SupplierId");
                }
            }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    Notify("SupplierName");
                }
            }
        }


        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public DeliveryListVM SearchVM
        {
            get { return _searchVM; }
            set
            {
                if (_searchVM != value)
                {
                    _searchVM = value;
                    Notify("SearchVM");
                }
            }
        }

        public ContractType ContractType { get; set; }

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

        #endregion

        #region Constructor

        public DeliveryHomeVM()
        {
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
            GetTradeTypes();
            GetDlvIsVerifieds();
            //GetMetals();
            GetCommodityTypes();
        }

        public DeliveryHomeVM(ContractType contractType)
        {
            ContractType = contractType;
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
            GetTradeTypes();
            GetDlvIsVerifieds();
            //GetMetals();
            GetCommodityTypes();
        }

        #endregion

        #region Method

        public void LoadSearch()
        {
            SearchVM = new DeliveryListVM();
            if (ContractType == ContractType.Purchase)
                SearchVM.Title = ResDelivery.PurchaseBLQuery;
            else if (ContractType == ContractType.Sales)
                SearchVM.Title = ResDelivery.SalesBLQuery;
            SearchVM.SelectedTradeType = SelectedTradeType;
            SearchVM.SelectedMetal = SelectedMetal;
            SearchVM.StartDate = StartDate;
            SearchVM.EndDate = EndDate;
            SearchVM.SupplierId = SupplierId;
            SearchVM.ContractType = ContractType;
            SearchVM.IsOnlyCurrentUser = IsOnlyCurrentUser;
            SearchVM.WarehouseId = WarehouseId;
            SearchVM.QuotaNo = QuotaNo;

            SearchVM.BLNo = BLNo;
            switch (SelectedIsVerified)
            {
                case 0:
                    SearchVM.DlvIsVerified = null;
                    break;
                case (int)IsVerified.True:
                    SearchVM.DlvIsVerified = true;
                    break;
                case (int)IsVerified.False:
                    SearchVM.DlvIsVerified = false;
                    break;
            }
            SearchVM.SelectedBrand = SelectedBrand;
            SearchVM.Init();
        }

        public void LoadSearchQuick(bool flag)
        {
            SearchVM = new DeliveryListVM();
            if (ContractType == ContractType.Purchase)
                SearchVM.Title = ResDelivery.PurchaseBLQuery;
            else if (ContractType == ContractType.Sales)
                SearchVM.Title = ResDelivery.SalesBLQuery;
            SearchVM.ContractType = ContractType;
            SearchVM.InitQuickSearch(flag);
        }

        public void GetTradeTypes()
        {
            TradeTypes = new Dictionary<string, int> { { "", 0 } };
            TradeTypes = EnumHelper.GetEnumDic<TradeType>(TradeTypes);
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Metals = metalService.GetCommoditiesByUser(CurrentUser.Id);
                Metals.Insert(0, new Commodity { Id = 0, Name = "" });
            }
        }

        public void GetDlvIsVerifieds()
        {
            DlvIsVerifieds = EnumHelper.GetEnumList<IsVerified>();
            DlvIsVerifieds.Insert(0, new EnumItem());
            SelectedIsVerified = 0;
        }

        public void LoadSalesDelCurrentMonthSearch()
        {
            SearchVM = new DeliveryListVM
                           {
                               Title = ResDelivery.SalesBLQuery,
                               ContractType = ContractType.Sales,
                               StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                           };

            SearchVM.EndDate = SearchVM.StartDate.Value.AddMonths(1).AddDays(-1);
            SearchVM.Init();
        }

        public void LoadSalesDelLastMonthSearch()
        {
            SearchVM = new DeliveryListVM
                           {
                               Title = ResDelivery.SalesBLQuery,
                               ContractType = ContractType.Sales,
                               StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1)
                           };

            SearchVM.EndDate = SearchVM.StartDate.Value.AddMonths(1).AddDays(-1);
            SearchVM.Init();
        }

        public void LoadSalesDelCurrentYearSearch()
        {
            SearchVM = new DeliveryListVM
                           {
                               Title = ResDelivery.SalesBLQuery,
                               ContractType = ContractType.Sales,
                               StartDate = new DateTime(DateTime.Today.Year, 1, 1)
                           };

            SearchVM.EndDate = SearchVM.StartDate.Value.AddYears(1).AddDays(-1);
            SearchVM.Init();
        }

        public void GetCommodityTypes()
        {
            using (var commodityTypeService = SvcClientManager.GetSvcClient<CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            {
                CommodityTypes = commodityTypeService.GetAll();
                CommodityTypes.Insert(0, new CommodityType { Id = 0, Name = "" });
            }
        }

        public void GetBrands()
        {

            if(SelectedCommodityTypeId != 0)
            {
                using (var brandService = SvcClientManager.GetSvcClient<BrandServiceReference.BrandServiceClient>(SvcType.BrandSvc))
                {
                    var brands = brandService.Query("it.CommodityTypeId = " + SelectedCommodityTypeId, null).OrderBy(o => o.Name).ToList();
                    brands.Insert(0, new Brand());
                    Brands = brands;
                }
            }
            else
            {
                Brands = new List<Brand> { new Brand() };
            }
            //if (SelectedMetal != 0)
            //{
            //    List<CommodityType> commodityTypes;
            //    using (
            //        var commodityTypeService =
            //            SvcClientManager.GetSvcClient<CommodityTypeServiceReference.CommodityTypeServiceClient>(SvcType.CommodityTypeSvc))
            //    {
            //        commodityTypes = commodityTypeService.Query("it.CommodityId = " + SelectedMetal, null);
            //    }
            //    if (commodityTypes.Count > 0)
            //    {
            //        using (var brandService = SvcClientManager.GetSvcClient<BrandServiceReference.BrandServiceClient>(SvcType.BrandSvc))
            //        {
            //            string query = "it.CommodityId = " + SelectedMetal + " and (";
            //            foreach (var commodityType in commodityTypes)
            //            {
            //                query += " it.CommodityTypeId = " + commodityType.Id + " or";
            //            }
            //            query = query.Remove(query.Length - 2);
            //            query += " )";

            //            //Brands = brandService.Query(query, null);
            //            //if(Brands != null && Brands.Count > 0)
            //            //{
            //            //    Brands = Brands.OrderBy(c => c.Name).ToList();
            //            //}
            //            //Brands.Insert(0, new Brand { Id = 0});
            //            var brands = brandService.Query(query, null).OrderBy(o => o.Name).ToList();
            //            brands.Insert(0, new Brand());
            //            Brands = brands;
            //        }
            //    }
            //    else
            //    {
            //        Brands = new List<Brand> {new Brand()};
            //    }
            //}
            //else
            //{
            //    Brands = new List<Brand>{new Brand()};
            //}
        }

        #endregion
    }
}