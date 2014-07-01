using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.Helper;
using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using Client.WarehouseOutLineServiceReference;
using Client.WarehouseOutServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.WarehouseOuts
{
    public sealed class WarehouseOutListVM : ListBaseVM
    {
        #region Member

        private bool _isSelectAll;

        #endregion

        #region Property

        public bool IsSelectAll
        {
            get { return _isSelectAll; }
            set
            {
                if (_isSelectAll != value)
                {
                    _isSelectAll = value;
                    Notify("IsSelectAll");
                }
            }
        }

        

        #endregion

        #region Constructor

        public WarehouseOutListVM(List<QueryElement> cons)
            : base(cons)
        {
            InitService();
            RegisterIncludes();
            RegisterExtraIncludes();
            SortCols = new List<SortCol>{new SortCol{ByDescending = true, ColName = "WarehouseOutDate"}};
            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Method

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelectAll")
            {
                foreach (var entity in Entities)
                {
                    var delivery = (WarehouseOut) entity;
                    if (delivery.Printable)
                    {
                        delivery.IsSelected = IsSelectAll;
                    }
                }
            }
        }

        public override void InitService()
        {
            SvcClient = SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc);
        }

        public override void RegisterIncludes()
        {
            Includes = new List<string>
                           {
                               "Quota",
                               "Quota.Contract"
                           };
        }

        public void DelWarehouseOutLine(int warehouseLineId)
        {
            using (
                var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                warehouseOutService.RemoveById(warehouseLineId, CurrentUser.Id);
            }
        }

        public int GetWarehouseOutIdByLineID(int id)
        {
            using (var woLineService = SvcClientManager.GetSvcClient<WarehouseOutLineServiceClient>(SvcType.WarehouseOutLineSvc))
            {
                var line = woLineService.GetById(id);
                return line.WarehouseOutId;
            }
        }

        public void PrintSelected()
        {
            var toPrints = Entities.Cast<WarehouseOut>().Where(o => o.IsSelected);
            foreach (var wo in toPrints)
            {
                var reportVM = new PrintWarehouseOutTemplateVM("出库", wo.Id);
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.HeaderList }, { "Lines", reportVM.LineList } };
                var printHelper = new PrintHelper(dataSources, reportVM.PathName, null, true);
                printHelper.Run();
            }
        }

        public void PrintSelectedWarehouseOut()
        {
            var toPrints = Entities.Cast<WarehouseOut>().Where(o => o.IsSelected);
            foreach (var wo in toPrints)
            {
                var reportVM = new PrintInOutTemplateVM(wo.Id, "打印出库单");
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.Header }, { "Lines", reportVM.Lines } };
                var printHelper = new PrintHelper(dataSources, "PrintTemplate\\内贸出库单\\上海长然出入库单.rdlc", null, true);
                printHelper.Run();
            }
        }

        public override void RegisterExtraIncludes()
        {
            ExtraIncludes = new List<string>
                                {
                                    "Quota.Contract.BusinessPartner",
                                    "Quota.Contract.InternalCustomer",
                                    "Warehouse",
                                    "Quota.Commodity",
                                    "WarehouseOutLines.CommodityType",
                                    "WarehouseOutLines.Brand", 
                                    "WarehouseOutLines",  
                                    "WarehouseOutLines.WarehouseInLine",
                                };
        }

        public override void FilterEntities()
        {
            foreach (var entity in Entities)
            {
                FilterDeleted(((WarehouseOut)entity).WarehouseOutLines);
            }
        }

        public override void Resort()
        {
            Entities = Entities.Cast<WarehouseOut>().OrderByDescending(o => o.WarehouseOutDate);
        }

        #endregion
    }
}