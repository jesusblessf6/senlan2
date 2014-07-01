using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.InventoryServiceReference;
using Client.View.Physical.InventoryReport;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.InventoryReport
{
    public class InventoryReportHomeVM : BaseVM
    {
        #region Member

        private List<Commodity> _commodityList;
        private DataTable _dt;
        private List<DeliveryLine> _externalTDList;
        private List<BusinessPartner> _internalCustomerList;
        private List<DeliveryLine> _internalTDList;
        private int? _selectedCommodityID;
        private int _selectedCustomerID;

        #endregion

        #region Property

        public DataTable DT
        {
            get { return _dt; }
            set
            {
                if (_dt != value)
                {
                    _dt = value;
                    Notify("DT");
                }
            }
        }

        public List<DeliveryLine> ExternalTDList
        {
            get { return _externalTDList; }
            set
            {
                if (_externalTDList != value)
                {
                    _externalTDList = value;
                    Notify("ExternalTDList");
                }
            }
        }

        public List<DeliveryLine> InternalTDList
        {
            get { return _internalTDList; }
            set
            {
                if (_internalTDList != value)
                {
                    _internalTDList = value;
                    Notify("InternalTDList");
                }
            }
        }

        public int SelectedCustomerID
        {
            get { return _selectedCustomerID; }
            set
            {
                if (_selectedCustomerID != value)
                {
                    _selectedCustomerID = value;
                    Notify("SelectedCustomerID");
                }
            }
        }

        public int? SelectedCommodityID
        {
            get { return _selectedCommodityID; }
            set
            {
                if (_selectedCommodityID != value)
                {
                    _selectedCommodityID = value;
                    Notify("SelectedCommodityID");
                }
            }
        }

        public List<BusinessPartner> InternalCustomerList
        {
            get { return _internalCustomerList; }
            set
            {
                if (_internalCustomerList != value)
                {
                    _internalCustomerList = value;
                    Notify("InternalCustomerList");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                if (_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        #endregion

        #region Constructor

        public InventoryReportHomeVM()
        {
            CommodityList = new List<Commodity>();
            InternalCustomerList = new List<BusinessPartner>();

            LoadCommodityList();
            LoadCustomerList();
        }

        public void Init()
        {
            InternalTDList = new List<DeliveryLine>();
            ExternalTDList = new List<DeliveryLine>();
            DT = new DataTable();
            DT = GetTable();
            GetInternalTDByParameter();
            GetExternalTDListByParameter();
        }

        #endregion

        #region Method

        public void LoadCommodityList()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetCommoditiesByUser(CurrentUser.Id);
                CommodityList.Insert(0, new Commodity { Id = 0, Name = "" });
                if (CommodityList.Count > 0)
                {
                    SelectedCommodityID = CommodityList[0].Id;
                }
            }
        }

        public void LoadCustomerList()
        {
            using (
                var customerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = customerService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalCustomerList.Insert(0, new BusinessPartner { Id = 0, ShortName = "" });
                if (InternalCustomerList.Count > 0)
                {
                    SelectedCustomerID = 0;
                }
            }
        }

        public List<Inventory> GetInventoryByParameter()
        {
            using (var inventoryService = SvcClientManager.GetSvcClient<InventoryServiceClient>(SvcType.InventorySvc))
            {
                const string str = "it.CommodityId = @p1 and it.OwnerPartyId = @p2";
                var parameter = new List<object> { SelectedCommodityID, SelectedCustomerID };
                List<Inventory> inventoryList = inventoryService.Select(str, parameter,
                                                                        new List<string> { "Warehouse", "BusinessPartner", "Brand" });
                return inventoryList;
            }
        }

        public DataTable GetTable()
        {
            List<Inventory> list = GetInventoryByParameter();
            var dt = new DataTable();
            var warehouseIDList = new List<int>();
            var brandList = list.Select(inventory => inventory.Brand).ToList();
            brandList = brandList.Distinct().ToList();
            dt.Columns.Add(ResInventoryReport.WarehouseBrand);
            foreach (Brand brand in brandList)
            {
                dt.Columns.Add(brand.Name);
            }
            if (list.Count > 0)
            {
                foreach (Inventory inventory in list)
                {
                    int id = inventory.WarehouseId == null ? 0 : (int)inventory.WarehouseId;
                    if (!warehouseIDList.Contains(id))
                    {
                        DataRow dr = dt.NewRow();
                        warehouseIDList.Add(id);
                        dr[ResInventoryReport.WarehouseBrand] = inventory.Warehouse.Name;
                        bool isVisible = false;
                        foreach (Brand brand in brandList)
                        {
                            Brand brand1 = brand;
                            List<Inventory> listByID =
                                list.Where(c => c.WarehouseId == id && c.BrandId == brand1.Id).ToList();
                            if (listByID.Count > 0)
                            {
                                decimal totalQty = listByID.Sum(c => c.Quantity == null ? 0 : (decimal)c.Quantity);
                                if (totalQty != 0)
                                {
                                    isVisible = true;
                                }
                                dr[brand1.Name] = totalQty;
                            }
                        }
                        if (isVisible)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                double isResult = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[j][i].ToString()))
                    {
                        if (Math.Abs(Convert.ToDouble(dt.Rows[j][i].ToString()) - 0) > Double.Epsilon)
                        {
                            isResult = 1;
                        }
                    }
                }
                if (Math.Abs(isResult - 0) < double.Epsilon)
                {
                    dt.Columns.Remove(dt.Columns[i]);
                    i = i - 1;
                }
            }

            DT = dt;
            return DT;
        }

        /// <summary>
        /// 内贸提单/仓单
        /// </summary>
        public void GetInternalTDByParameter()
        {
            using (var inventoryService = SvcClientManager.GetSvcClient<InventoryServiceClient>(SvcType.InventorySvc))
            {
                InternalTDList = inventoryService.GetInternalTDList(SelectedCommodityID, SelectedCustomerID,
                                                                    CurrentUser.Id);
                if(InternalTDList != null && InternalTDList.Count > 0)
                {
                    decimal totalOnlyQty = InternalTDList.Sum(c => c.OnlyQty ?? 0);
                    decimal totalOnlyVerifiedQty = InternalTDList.Sum(c => c.OnlyVerfiedQty ?? 0);
                    var totalLine = new DeliveryLine
                    {
                        Id = 0,
                        OnlyQty = totalOnlyQty,
                        OnlyVerfiedQty = totalOnlyVerifiedQty
                    };
                    InternalTDList.Add(totalLine);
                }
            }
        }

        public void GetExternalTDListByParameter()
        {
            using (var inventoryService = SvcClientManager.GetSvcClient<InventoryServiceClient>(SvcType.InventorySvc))
            {
                ExternalTDList = inventoryService.GetExternalTDList(SelectedCommodityID, SelectedCustomerID,
                                                                    CurrentUser.Id);
                if(ExternalTDList != null && ExternalTDList.Count > 0)
                {
                    decimal totalOnlyQty = ExternalTDList.Sum(c => c.OnlyQty ?? 0);
                    decimal totalOnlyGrossWeight = ExternalTDList.Sum(c => c.OnlyGrossWeight ?? 0);
                    var totalLine = new DeliveryLine { 
                        Id = 0,
                        OnlyQty = totalOnlyQty,
                        OnlyGrossWeight = totalOnlyGrossWeight
                    };
                    ExternalTDList.Add(totalLine);
                }
            }
        }

        public override bool Validate()
        {
            if (SelectedCommodityID <= 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }

            if (SelectedCustomerID <= 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }
            return true;
        }

        #endregion
    }
}