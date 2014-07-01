using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.WarehouseServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.SystemSetting.WarehouseSetting
{
    public class WarehouseSettingVM : BaseVM
    {
        #region Member

        private int _warehouseCount;
        private int _warehouseFrom;
        private int _warehouseTo;
        private List<Warehouse> _warehouses;
        private string _ShortName;
        #endregion

        #region Property
        public string ShortName
        {
            get { return _ShortName; }
            set { 
                if(_ShortName != value)
                {
                    _ShortName = value;
                    Notify("ShortName");
                }
            }
        }

        public List<Warehouse> Warehouses
        {
            get { return _warehouses; }
            set
            {
                _warehouses = value;
                Notify("Warehouses");
            }
        }

        public int WarehouseCount
        {
            get { return _warehouseCount; }
            set
            {
                if (_warehouseCount != value)
                {
                    _warehouseCount = value;
                    Notify("WarehouseCount");
                }
            }
        }

        public int WarehouseTo
        {
            get { return _warehouseTo; }
            set
            {
                if (_warehouseTo != value)
                {
                    _warehouseTo = value;
                    Notify("WarehouseTo");
                }
            }
        }

        public int WarehouseFrom
        {
            get { return _warehouseFrom; }
            set
            {
                if (_warehouseFrom != value)
                {
                    _warehouseFrom = value;
                    Notify("WarehouseFrom");
                }
            }
        }

        #endregion

        #region Method

        public void LoadWarehouseCount()
        {
            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                if (!string.IsNullOrEmpty(ShortName))
                {
                    LoadWarehouse();
                    _warehouseCount = _warehouses.Count();
                }
                else
                {
                    _warehouseCount = warehouseService.GetAllCount();
                }
            }
        }

        public void LoadWarehouse()
        {
            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                _warehouses = warehouseService.GetByRangeWithOrder(new SortCol { ByDescending = true, ColName = "Id" },
                                                                       WarehouseFrom, WarehouseTo);
                if (!string.IsNullOrEmpty(ShortName))
                {
                    if(_warehouses != null && _warehouses.Count > 0)
                    {
                        _warehouses = _warehouses.Where(c => c.Name.ToUpper().Contains(ShortName.ToUpper())).ToList();
                    }
                }
            }
        }

        public void DeleteWarehouse(int id)
        {
            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                warehouseService.RemoveById(id,CurrentUser.Id);
            }
        }

        #endregion

        #region Constructor

        public WarehouseSettingVM()
        {
            _warehouses = new List<Warehouse>();
            LoadWarehouseCount();
        }

        //public void GetWarehouseByShortName()
        //{
        //    if (!string.IsNullOrEmpty(ShortName))
        //    {
        //        LoadWarehouse();
        //        if (_warehouses != null && _warehouses.Count > 0)
        //        {
        //            _warehouses = _warehouses.Where(c => c.Name.Contains(ShortName)).ToList();
        //            WarehouseCount = _warehouses.Count;
        //        }
        //    }
        //}
        #endregion
    }
}