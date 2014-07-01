using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.View.Physical.WarehouseIns;
using DBEntity.EnumEntity;
using Utility.Misc;
using DBEntity;
using Utility.ServiceManagement;
using Client.CommodityServiceReference;

namespace Client.ViewModel.Physical.WarehouseIns
{
    public class WarehouseInHomeVM : BaseVM
    {
        #region Member

        private string _comment;
        private int _deliveryId;
        private DateTime? _endDate;
        private bool _isVerified;
        private string _pbNo;
        private decimal _quantity;
        private WarehouseInListVM _searchVM;
        private DateTime? _startDate;
        private int _supplierId;
        private string _supplierName;
        private decimal _verifiedQuantity;
        private List<EnumItem> _verifiedStatus;
        private int _selectedVerifiedStatus;
        private int _warehouseId;
        private DateTime _warehouseInDate;
        private string _warehouseName;
        private List<Commodity> _commodityList;
        private int _commodityId;
        private bool _containCurrentUser = true;

        #endregion

        #region Property
        public int CommodityId
        {
            get { return _commodityId; }
            set { 
                if(_commodityId != value)
                {
                    _commodityId = value;
                    Notify("CommodityId");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set { 
                if(_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
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

        public bool IsVerified
        {
            get { return _isVerified; }
            set
            {
                if (_isVerified != value)
                {
                    _isVerified = value;
                    Notify("IsVerified");
                }
            }
        }

        public List<EnumItem> VerifiedStatus
        {
            get { return _verifiedStatus; }
            set
            {
                _verifiedStatus = value;
                Notify("StatusTypes");
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

        public WarehouseInListVM SearchVM
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

        public string WarehouseName
        {
            get { return _warehouseName; }
            set
            {
                _warehouseName = value;
                Notify("WarehouseName");
            }
        }

        public string PBNo
        {
            get { return _pbNo; }
            set
            {
                _pbNo = value;
                Notify("PBNo");
            }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                Notify("Quantity");
            }
        }

        public decimal VerifiedQuantity
        {
            get { return _verifiedQuantity; }
            set
            {
                _verifiedQuantity = value;
                Notify("VerifiedQuantity");
            }
        }

        public int DeliveryId
        {
            get { return _deliveryId; }
            set
            {
                _deliveryId = value;
                Notify("DeliveryId");
            }
        }

        public DateTime WarehouseInDate
        {
            get { return _warehouseInDate; }
            set
            {
                _warehouseInDate = value;
                Notify("WarehouseInDate");
            }
        }

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                _warehouseId = value;
                Notify("WarehouseId");
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                Notify("Comment");
            }
        }

        public bool ContainCurrentUser
        {
            get { return _containCurrentUser; }
            set
            {
                if (_containCurrentUser != value)
                {
                    _containCurrentUser = value;
                    Notify("ContainCurrentUser");
                }
            }
        }

        public int SelectedVerifiedStatus
        {
            get { return _selectedVerifiedStatus; }
            set
            {
                if (_selectedVerifiedStatus != value)
                {
                    _selectedVerifiedStatus = value;
                    Notify("SelectedVerifiedStatus");
                }
            }
        }
        #endregion

        #region Constructor

        public WarehouseInHomeVM()
        {
            LoadStatus();
            LoadCommodity();

            EndDate = DateTime.Today;
            StartDate = DateTime.Today.AddMonths(-1);
        }

        #endregion

        #region Method

        private void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetCommoditiesByUser(CurrentUser.Id);
            }
            CommodityList.Insert(0, new Commodity { Id = 0, Name = "" });
            CommodityId = 0;
        }

        private void LoadStatus()
        {
            VerifiedStatus = EnumHelper.GetEnumList<IsVerified>();
            VerifiedStatus.Insert(0, new EnumItem());
        }

        public void LoadSearch(string selectValue, WarehouseInSearchType type)
        {
            SearchVM = new WarehouseInListVM
                           {
                               Title = ResWarehouseIn.WarehouseInQuery,
                               WarehouseInDate = WarehouseInDate,
                               SupplierId = SupplierId,
                               WarehouseId = WarehouseId,
                               IsVerified = SelectedVerifiedStatus,
                               CommodityId = CommodityId,
                               ContainCurrentUser = ContainCurrentUser
                           };
            switch (type)
            {
                case WarehouseInSearchType.DefaultSearch:
                    SearchVM.StartDate = StartDate;
                    SearchVM.EndDate = EndDate;
                    break;
                case WarehouseInSearchType.CurrentMonth:
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    EndDate = StartDate.Value.AddMonths(1).AddDays(-1);
                    SearchVM.StartDate = StartDate;
                    SearchVM.EndDate = EndDate;
                    break;
                case WarehouseInSearchType.CurrentYear:
                    StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    EndDate = DateTime.Now.AddYears(1).AddDays(-1);
                    SearchVM.StartDate = StartDate;
                    SearchVM.EndDate = EndDate;
                    break;
                case WarehouseInSearchType.LastMonth:
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    EndDate = StartDate.Value.AddMonths(1).AddDays(-1);
                    SearchVM.StartDate = StartDate;
                    SearchVM.EndDate = EndDate;
                    break;
                case WarehouseInSearchType.LastYear:
                    StartDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
                    EndDate = StartDate.Value.AddYears(1).AddDays(-1);
                    SearchVM.StartDate = StartDate;
                    SearchVM.EndDate = EndDate;
                    break;
            }
            SearchVM.Init();
        }

        #endregion
    }

    #region 快速查询

    public enum WarehouseInSearchType
    {
        CurrentMonth,
        LastMonth,
        LastYear,
        CurrentYear,
        DefaultSearch
    }

    #endregion
}