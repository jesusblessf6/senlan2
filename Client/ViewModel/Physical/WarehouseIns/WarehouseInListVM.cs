using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.Helper;
using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using Client.WarehouseInLineServiceReference;
using Client.WarehouseInServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using Utility.Misc;

namespace Client.ViewModel.Physical.WarehouseIns
{
    public class WarehouseInListVM : BaseVM
    {
        #region Member

        private DateTime? _endDate;
        private int _isVerified;
        private DateTime? _startDate;
        private int _supplierId;
        private string _title;
        private int _warehouseId;
        private DateTime? _warehouseInDate;
        private int _warehouseInLineAllCount;
        private int _warehouseInLineFrom;
        private List<WarehouseInLine> _warehouseInLineList;
        private int _warehouseInLineTo;
        private List<WarehouseIn> _warehouseInList;
        private List<object> _parameters;
        private string _queryStr;
        private int _commodityId;
        private bool _containCurrentUser;
        private bool _isSelectAll;
        private int _WarehouseInAllCount;
        private int _WarehouseInFrom;
        private int _WarehouseInTo;

        #endregion

        #region Property
        public int WarehouseInTo
        {
            get { return _WarehouseInTo; }
            set { 
                if(_WarehouseInTo != value)
                {
                    _WarehouseInTo = value;
                    Notify("WarehouseInTo");
                }
            }
        }

        public int WarehouseInFrom
        {
            get { return _WarehouseInFrom; }
            set
            {
                if (_WarehouseInFrom != value)
                {
                    _WarehouseInFrom = value;
                    Notify("WarehouseInFrom");
                }
            }
        }

        public int WarehouseInAllCount
        {
            get { return _WarehouseInAllCount; }
            set { 
                if(_WarehouseInAllCount != value)
                {
                    _WarehouseInAllCount = value;
                    Notify("WarehouseInAllCount");
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

        public int IsVerified
        {
            get { return _isVerified; }
            set
            {
                if (_isVerified != value)
                {
                    _isVerified = value;
                    Notify("_IsVerified");
                }
            }
        }

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                if (_warehouseId != value)
                {
                    _warehouseId = value;
                    Notify("WarehouseId");
                }
            }
        }

        public int WarehouseInLineFrom
        {
            get { return _warehouseInLineFrom; }
            set
            {
                if (_warehouseInLineFrom != value)
                {
                    _warehouseInLineFrom = value;
                    Notify("WarehouseInLineFrom");
                }
            }
        }

        public int WarehouseInLineTo
        {
            get { return _warehouseInLineTo; }
            set
            {
                if (_warehouseInLineTo != value)
                {
                    _warehouseInLineTo = value;
                    Notify("WarehouseInLineTo");
                }
            }
        }

        public int WarehouseInLineAllCount
        {
            get { return _warehouseInLineAllCount; }
            set
            {
                if (_warehouseInLineAllCount != value)
                {
                    _warehouseInLineAllCount = value;
                    Notify("WarehouseInLineAllCount");
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    Notify("Title");
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

        public DateTime? WarehouseInDate
        {
            get { return _warehouseInDate; }
            set
            {
                if (_warehouseInDate != value)
                {
                    _warehouseInDate = value;
                    Notify("WarehouseInDate");
                }
            }
        }

        public List<WarehouseInLine> WarehouseInLineList
        {
            get { return _warehouseInLineList; }
            set
            {
                if (_warehouseInLineList != value)
                {
                    _warehouseInLineList = value;
                    Notify("WarehouseInLineList");
                }
            }
        }

        public List<WarehouseIn> WarehouseInList
        {
            get { return _warehouseInList; }
            set
            {
                if (_warehouseInList != value)
                {
                    _warehouseInList = value;
                    Notify("WarehouseInList");
                }
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

        #region Method

        public void Init()
        {
            PropertyChanged += OnPropertyChanged;
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelectAll")
            {
                foreach (var wi in WarehouseInList)
                {
                    if (wi.Printable)
                    {
                        wi.IsSelected = IsSelectAll;
                    }
                }
            }
        }

        private void InitPage()
        {
            LoadWarehouseInCount();
        }

        public void LoadWarehouseInCount()
        {
            using (var warehouseInService = SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                WarehouseInAllCount = queryStr == string.Empty ? warehouseInService.GetAllCount() : warehouseInService.GetCount(queryStr, parameters);
            }
        }

        public void LoadWarehouseInList()
        {
            using (var warehouseInService = SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);

                if (queryStr == string.Empty)
                {
                    queryStr = "1=1";
                    parameters = null;
                };

                WarehouseInList = warehouseInService.SelectByRangeWithMultiOrderLazyLoad(queryStr, parameters, new List<SortCol> { new SortCol { ByDescending = true, ColName = "WarehouseInDate" } }, WarehouseInFrom, WarehouseInTo,
                                                                                                            new List<string>
                                                                                                                    {
                                                                                                                        "Warehouse",
                                                                                                                        "Commodity"
                                                                                                                    },
                                                                                                        new List<string>
                                                                                                                    {
                                                                                                                       "WarehouseInLines",
                                                                                                                        "Warehouse",
                                                                                                                        "WarehouseInLines.Brand",
                                                                                                                        "WarehouseInLines.DeliveryLine.Delivery",
                                                                                                                        "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract.InternalCustomer",
                                                                                                                        "WarehouseInLines.DeliveryLine.Delivery.Quota.Commodity",
                                                                                                                        "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract.BusinessPartner"
                                                                                                                    });
                foreach (WarehouseIn warehouseIn in WarehouseInList)
                {
                    FilterDeleted(warehouseIn.WarehouseInLines);
                }
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            //var idList = new List<int>();
            //using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            //{
            //    List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
            //    if (list.Count > 0)
            //    {
            //        idList = list.Select(c => c.Id).ToList();
            //    }
            //}

            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
            //if (idList.Count > 0)
            //{
            //    if (sb.Length != 0)
            //    {
            //        sb.Append(" and ");
            //    }
            //    sb.Append("(");
            //    for (int j = 0; j < idList.Count; j++)
            //    {
            //        if (j == 0)
            //        {
            //            sb.AppendFormat("it.DeliveryLine.Delivery.Quota.Contract.InternalCustomerId = @p{0}", num++);
            //            parameters.Add(idList[j]);
            //        }
            //        else
            //        {
            //            sb.AppendFormat(" or it.DeliveryLine.Delivery.Quota.Contract.InternalCustomerId = @p{0}", num++);
            //            parameters.Add(idList[j]);
            //        }
            //    }
            //    sb.Append(")");
            //}

            if (ContainCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            //if (SupplierId != 0)
            //{
            //    if (sb.Length != 0)
            //    {
            //        sb.Append(" and ");
            //    }
            //    sb.AppendFormat("it.DeliveryLine.Delivery.Quota.Contract.BusinessPartner.Id = @p{0} ", num++);
            //    parameters.Add(SupplierId);
            //}

            if(CommodityId != 0)
            {
                if(sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0}", num++);
                parameters.Add(CommodityId);
            }

            if (WarehouseId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.WarehouseId = @p{0} ", num++);
                parameters.Add(WarehouseId);
            }

            if (IsVerified > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IsVerified = @p{0}", num++);
                parameters.Add(IsVerified == (int)DBEntity.EnumEntity.IsVerified.True);
            }

            if (StartDate != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.WarehouseInDate >= @p{0}", num++);
                parameters.Add(StartDate);
            }

            if (EndDate != null)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.WarehouseInDate <= @p{0}", num++);
                parameters.Add(EndDate);
            }

            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }

            sb.AppendFormat("it.IsDeleted = @p{0}", num);
            parameters.Add(false);
            queryStr = sb.ToString();
        }

        public WarehouseInLine GetWarehouseInLineById(int id)
        {
            const string str = "it.Id = @p1";
            var parameter = new List<object> {id};
            var warehouseInLine = new WarehouseInLine();
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                List<WarehouseInLine> lines = warehouseInLineService.Select(str, parameter,
                                                                            new List<string> {"WarehouseIn"});
                if (lines.Count > 0)
                {
                    warehouseInLine = lines[0];
                }
                return warehouseInLine;
            }
        }

        public void DelWarehouseInLine(int id)
        {
            using (
                var warehouseInService =
                    SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                warehouseInService.RemoveById(id, CurrentUser.Id);
            }
        }

        public int GetWarehouseIdByWarehouseInLineID(int id)
        {
            const string str = "it.Id = @p1";
            var parameter = new List<object>();
            int warehouseID = 0;
            parameter.Add(id);
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                List<WarehouseInLine> lines = warehouseInLineService.Select(str, parameter,
                                                                            new List<string> {"WarehouseIn"});
                if (lines.Count > 0)
                {
                    WarehouseInLine inLine = lines[0];
                    warehouseID = inLine.WarehouseInId;
                }
            }
            return warehouseID;
        }

        public void PrintSelectedWarehouseIn()
        {
            var toPrints = WarehouseInList.Where(o => o.IsSelected);
            foreach (var wo in toPrints)
            {
                var reportVM = new PrintInOutTemplateVM(wo.Id, "打印入库单");
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.Header }, { "Lines", reportVM.Lines } };
                var printHelper = new PrintHelper(dataSources, "PrintTemplate\\内贸出库单\\上海长然出入库单.rdlc", null,  true);
                printHelper.Run();
            }
        }

        #endregion
    }
}