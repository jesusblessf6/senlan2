using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Client.Base.BaseClientVM;
using Client.DeliveryServiceReference;
using Client.Helper;
using Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.Linq;

namespace Client.ViewModel.Physical.Deliveries
{
    public class DeliveryListVM : BaseVM
    {
        #region Member

        private List<Delivery> _deliveries;
        private int _deliveryFrom;
        private int _deliveryTo;
        private int _deliveryTotleCount;
        private DateTime? _endDate;
        private int _selectedMetal;
        private int _selectedTradeType;
        private DateTime? _startDate;
        private int _supplierId;
        private string _title;
        private List<object> _parameters;
        private string _queryStr;
        private bool? _dlvIsVerified;
        private string _blNo;
        private bool _isOnlyCurrentUser;
        private int _warehouseId;
        private bool _isSelectAll;
        private int? _selectedBrand;
        private string _quotaNo;
        private string _totalVerifiedQty;

        #endregion

        #region Property
        public int TdId { get; set; }
        public string TotalVerifiedQty
        {
            get { return _totalVerifiedQty; }
            set
            {
                if (_totalVerifiedQty != value)
                {
                    _totalVerifiedQty = value;
                    Notify("TotalVerifiedQty");
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

        public bool IsOnlyCurrentUser
        {
            get { return _isOnlyCurrentUser; }
            set
            {
                if (_isOnlyCurrentUser != value)
                {
                    _isOnlyCurrentUser = value;
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

        public bool? DlvIsVerified
        {
            get { return _dlvIsVerified; }
            set
            {
                if (_dlvIsVerified != value)
                {
                    _dlvIsVerified = value;
                    Notify("DlvIsVerified");
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

        public List<Delivery> BindDeliveries
        {
            get { return _deliveries; }
            set
            {
                if (_deliveries != value)
                {
                    _deliveries = value;
                    Notify("Deliveries");
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

        public int DeliveryTotleCount
        {
            get { return _deliveryTotleCount; }
            set
            {
                if (_deliveryTotleCount != value)
                {
                    _deliveryTotleCount = value;
                    Notify("ContractTotleCount");
                }
            }
        }

        public int DeliveryFrom
        {
            get { return _deliveryFrom; }
            set
            {
                if (_deliveryFrom != value)
                {
                    _deliveryFrom = value;
                    Notify("DeliveryFrom");
                }
            }
        }

        public int DeliveryTo
        {
            get { return _deliveryTo; }
            set
            {
                if (_deliveryTo != value)
                {
                    _deliveryTo = value;
                    Notify("DeliveryTo");
                }
            }
        }

        public ContractType ContractType { get; set; }

        public string IsPrintControlsVisible
        {
            get
            {
                if (ContractType == ContractType.Purchase)
                    return "Hidden";

                return "Visible";
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

        public DeliveryListVM() { }
        public DeliveryListVM(int tdId)
        {
            TdId = tdId;
            LoadMDsByTDId(tdId);
        }

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
                foreach (var delivery in BindDeliveries)
                {
                    if (delivery.Printable)
                    {
                        delivery.IsSelected = IsSelectAll;
                    }
                }
            }
        }


        private void InitPage()
        {
            LoadDeliveryCount();
        }

        private void InitPageQuick()
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                _deliveryTotleCount = _queryStr == string.Empty ? deliveryService.GetAllCount() : deliveryService.GetCount(_queryStr, _parameters);
            }
        }

        public void LoadDeliveryCount()
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _deliveryTotleCount = queryStr == string.Empty ? deliveryService.GetAllCount() : deliveryService.GetCount(queryStr, parameters);
            }
        }

        public void LoadDelivery()
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                List<Delivery> dList;
                List<Delivery> allList;
                if (_queryStr == string.Empty)
                {
                    _queryStr = "1=1";
                    _parameters = null;
                };
                dList = deliveryService.SelectByRangeWithMultiOrderLazyLoad(_queryStr, _parameters,
                                                                                new List<SortCol> { new SortCol { ByDescending = true, ColName = "IssueDate" } },
                                                                                DeliveryFrom, DeliveryTo,
                                                                                new List<string>
                                                                                {
                                                                                    "Quota.Contract.BusinessPartner",
                                                                                    "Quota.Commodity",
                                                                                    "Quota.Contract.InternalCustomer",
                                                                                },
                                                                                new List<string>
                                                                                {
                                                                                    "Warehouse",
                                                                                    "DeliveryLines",
                                                                                    "DeliveryLines.CommodityType",
                                                                                    "DeliveryLines.Specification",
                                                                                    "DeliveryLines.Brand",
                                                                                    "DeliveryLines.PurchaseDeliveryLine.Delivery",
                                                                                    "ConvertedTd"
                                                                                });
                //合计数量取所有数据的值
                allList = deliveryService.Select(_queryStr, _parameters, new List<string>
                                                                                {
                                                                                    "DeliveryLines",
                                                                                    "DeliveryLines.CommodityType",
                                                                                    "DeliveryLines.Brand"
                                                                                });
                foreach (Delivery delivery in allList)
                {
                    FilterDeleted(delivery.DeliveryLines);
                }

                foreach (Delivery delivery in dList)
                {
                    FilterDeleted(delivery.DeliveryLines);
                }
                BindDeliveries = dList;
                SetTotalVerifiedQty(allList);
            }
        }

        private void SetTotalVerifiedQty(List<Delivery> allList)
        {
            decimal? total = 0;
            List<Delivery> dDeliveryList = allList.Where(c => c.DeliveryType == (int)DeliveryType.InternalTDBOL || c.DeliveryType == (int)DeliveryType.InternalTDWW || c.DeliveryType == (int)DeliveryType.InternalMDBOL || c.DeliveryType == (int)DeliveryType.InternalMDWW).ToList();
            List<Delivery> fDeliveryList = allList.Where(c => c.DeliveryType == (int)DeliveryType.ExternalTDBOL || c.DeliveryType == (int)DeliveryType.ExternalTDWW || c.DeliveryType == (int)DeliveryType.ExternalMDBOL || c.DeliveryType == (int)DeliveryType.ExternalMDWW).ToList();
            if (dDeliveryList.Count > 0)//内贸统计实际数量
            {
                total += dDeliveryList.Sum(c => c.DeliveryLines.Sum(o => o.VerifiedWeight));
            }
            if (fDeliveryList.Count > 0)//外贸统计净重
            {
                total += fDeliveryList.Sum(c => c.DeliveryLines.Sum(o => o.NetWeight));
            }
            TotalVerifiedQty = string.Format("{0:#,##0.0000}", total ?? 0);

            IsSelectAll = false;
        }

        public Delivery GetDeliveryByIdWithOutFetch(int id)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                Delivery delivery = deliveryService.GetById(id);
                return delivery;
            }
        }

        /// <summary>
        /// 根据id查找delivery
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Delivery GetDeliveryById(int id)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> { id };
                Delivery del = deliveryService.Select(str, parameters, new List<string>{
                                                                                            "Quota",
                                                                                            "Warehouse",
                                                                                            "WarehouseProvider",
                                                                                            "Shipper",
                                                                                            "ShippingParty",
                                                                                            "NotifyParty",
                                                                                            "Quota.Commodity",
                                                                                            "LoadingPort",
                                                                                            "LoadingPlace",
                                                                                            "DischargePort",
                                                                                            "DischargePlace",
                                                                                            "DeliveryLines",
                                                                                            "DeliveryLines.Brand",
                                                                                            "DeliveryLines.CommodityType",
                                                                                            "DeliveryLines.Specification",
                                                                                            "DeliveryLines.WarehouseOutDeliveryPersons"
                                                                                        }).FirstOrDefault();
                if (del != null)
                {
                    FilterDeleted(del.DeliveryLines);
                    return del;
                }
                return null;
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
        {
            List<int> idList = GetInternalIDList();
            parameters = new List<object>();
            var sb = new StringBuilder(" (it.WarrantId is null or (it.WarrantId is not null and it.DeliveryType =" + (int)DeliveryType.ExternalTDWW + ")) ");
            int num = 1;

            if (IsOnlyCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            if (!string.IsNullOrWhiteSpace(QuotaNo))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("it.Quota.QuotaNo Like \'%" + QuotaNo + "%\'");
            }

            if (idList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.Quota.Contract.InternalCustomerId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Quota.Contract.InternalCustomerId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (SelectedTradeType != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.Contract.TradeType = @p{0} ", num++);
                parameters.Add(SelectedTradeType);
            }
            if (SupplierId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.Contract.BPId = @p{0} ", num++);
                parameters.Add(SupplierId);
            }

            if (WarehouseId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Warehouse.Id = @p{0}", num++);
                parameters.Add(WarehouseId);
            }

            if (StartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IssueDate >= @p{0} ", num++);
                parameters.Add(StartDate.Value);
            }
            if (EndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IssueDate <= @p{0} ", num++);
                parameters.Add(EndDate.Value.AddDays(1).AddMinutes(-1));
            }
            if (DlvIsVerified.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.IsVerified == @p{0} ", num++);
                parameters.Add(DlvIsVerified);
            }
            if (SelectedMetal != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.CommodityId == @p{0} ", num++);
                parameters.Add(SelectedMetal);
            }
            if (!string.IsNullOrWhiteSpace(BLNo))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.DeliveryNo like '%" + BLNo.Trim() + "%' ", num);
            }

            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }
            if (ContractType == ContractType.Purchase)
            {
                sb.AppendFormat("(it.DeliveryType == " + (int)DeliveryType.InternalTDBOL + " or it.DeliveryType == " +
                                (int)DeliveryType.InternalTDWW + " or it.DeliveryType == " +
                                (int)DeliveryType.ExternalTDBOL + " or it.DeliveryType == " +
                                (int)DeliveryType.ExternalTDWW + ")");
            }
            else if (ContractType == ContractType.Sales)
            {
                sb.AppendFormat("(it.DeliveryType == " + (int)DeliveryType.InternalMDBOL + " or it.DeliveryType == " +
                                (int)DeliveryType.InternalMDWW + " or it.DeliveryType == " +
                                (int)DeliveryType.ExternalMDBOL + " or it.DeliveryType == " +
                                (int)DeliveryType.ExternalMDWW + ")");
            }

            if (SelectedBrand != null && SelectedBrand != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.BrandId Like @p{0}", num);
                parameters.Add("%" + SelectedBrand.Value + "%");
            }

            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }

            sb.Append("it.RelDeliveryId is null");

            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }

            sb.Append("((it.Quota.IsAutoGenerated == True and (it.Quota.Contract.TradeType =" + (int)TradeType.ShortForeignTrade + " or it.Quota.Contract.TradeType =" + (int)TradeType.LongForeignTrade + ")) or it.Quota.IsAutoGenerated == False)");

            queryStr = sb.ToString();
        }

        public void InitQuickSearch(bool flag)
        {
            if (flag)
            {
                BuildParamCurrentMonthInternal();
            }
            else
            {
                BuildParamCurrentMonthExternal();
            }
            InitPageQuick();
        }

        private void BuildParamCurrentMonthInternal()
        {
            List<int> idList = GetInternalIDList();
            //本月内贸提单
            _queryStr = string.Empty;
            _parameters = new List<object>();
            var sb = new StringBuilder();
            if (ContractType == ContractType.Purchase)
            {
                //采购
                sb.Append(" (it.DeliveryType ==" + (int)DeliveryType.InternalTDBOL + " or it.DeliveryType ==" +
                          (int)DeliveryType.InternalTDWW + ") ");
            }
            else
            {
                //销售
                sb.Append(" (it.DeliveryType ==" + (int)DeliveryType.InternalMDBOL + " or it.DeliveryType ==" +
                          (int)DeliveryType.InternalMDWW + ") ");
            }

            if (idList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.Quota.Contract.InternalCustomerId ==" + idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Quota.Contract.InternalCustomerId == " + idList[j]);
                    }
                }
                sb.Append(")");
            }

            DateTime now = DateTime.Now;
            DateTime startTime = Convert.ToDateTime(now.ToString("yyyy-MM-01"));
            DateTime endTime = startTime.AddMonths(1);
            sb.Append(" and it.IssueDate < @p1 ");
            sb.Append(" and it.IssueDate >= @p2 ");
            _parameters.Add(endTime);
            _parameters.Add(startTime);
            sb.Append(" and it.Quota.IsAutoGenerated == False ");
            _queryStr = sb.ToString();
        }

        private void BuildParamCurrentMonthExternal()
        {
            List<int> idList = GetInternalIDList();
            //本月外贸提单
            _queryStr = string.Empty;
            _parameters = new List<object>();
            var sb = new StringBuilder();
            if (ContractType == ContractType.Purchase)
            {
                //采购
                sb.AppendFormat("(it.DeliveryType ==" + (int)DeliveryType.ExternalTDBOL + " or it.DeliveryType ==" +
                                (int)DeliveryType.ExternalTDWW + ")");
            }
            else
            {
                //销售
                sb.AppendFormat("(it.DeliveryType ==" + (int)DeliveryType.ExternalMDBOL + " or it.DeliveryType ==" +
                                (int)DeliveryType.ExternalMDWW + ")");
            }
            if (idList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.Quota.Contract.InternalCustomerId ==" + idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Quota.Contract.InternalCustomerId == " + idList[j]);
                    }
                }
                sb.Append(")");
            }
            DateTime now = DateTime.Now;
            DateTime startTime = Convert.ToDateTime(now.ToString("yyyy-MM-01"));
            DateTime endTime = startTime.AddMonths(1);
            sb.Append(" and it.IssueDate < @p1 ");
            sb.Append(" and it.IssueDate >= @p2 ");
            _parameters.Add(endTime);
            _parameters.Add(startTime);
            //sb.Append(" and ((it.Quota.IsAutoGenerated == False and (it.Quota.Contract.TradeType =" + (int)TradeType.ShortForeignTrade + " or it.Quota.Contract.TradeType =" + (int)TradeType.LongForeignTrade + ")) or it.Quota.IsAutoGenerated == True)");
            _queryStr = sb.ToString();
        }

        public void DeleteLineById(int id)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                deliveryService.RemoveById(id, CurrentUser.Id);
                if (TdId != 0)
                {
                    LoadMDsByTDId(TdId);
                }
                else
                {
                    InitPage();
                    LoadDelivery();
                }
            }
        }

        public bool IsReexport(int id)
        {
            using (var dService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                return dService.IsReexport(id, CurrentUser.Id);
            }
        }

        public List<int> GetInternalIDList()
        {
            var idList = new List<int>();
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    idList = list.Select(c => c.Id).ToList();
                }
            }

            return idList;
        }

        public void PrintSelected()
        {
            var toPrints = BindDeliveries.Where(o => o.IsSelected);
            foreach (var delivery in toPrints)
            {
                var reportVM = new PrintWarehouseOutTemplateVM("发货单", delivery.Id);
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.HeaderList }, { "Lines", reportVM.LineList } };
                var printHelper = new PrintHelper(dataSources, reportVM.PathName, null, true);
                printHelper.Run();
            }
        }

        #endregion

        #region 点击提单的单据号
        public void LoadMDsByTDId(int tdId)
        {
            using (var dService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                List<Delivery> mds = new List<Delivery>();
                Delivery td = dService.SelectById(new List<string> { 
                    "DeliveryLines", 
                    "DeliveryLines.SalesDeliveryLines",
                    "DeliveryLines.SalesDeliveryLines.Delivery",
                    "DeliveryLines.SalesDeliveryLines.Delivery.Quota",
                    "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Contract",
                    "DeliveryLines.SalesDeliveryLines.Delivery.Warehouse",
                    "DeliveryLines.SalesDeliveryLines.Delivery.WarehouseProvider",
                    "DeliveryLines.SalesDeliveryLines.Delivery.Shipper",
                    "DeliveryLines.SalesDeliveryLines.Delivery.ShippingParty",
                    "DeliveryLines.SalesDeliveryLines.Delivery.NotifyParty",
                    "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Commodity",
                    "DeliveryLines.SalesDeliveryLines.Delivery.LoadingPort",
                    "DeliveryLines.SalesDeliveryLines.Delivery.LoadingPlace",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DischargePort",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DischargePlace",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines.Brand",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines.CommodityType",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines.Specification",
                    "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines.WarehouseOutDeliveryPersons"
                },
                    tdId);
                FilterDeleted(td.DeliveryLines);
                foreach (var tdLine in td.DeliveryLines)
                {
                    FilterDeleted(tdLine.SalesDeliveryLines);
                    foreach (var mdLine in tdLine.SalesDeliveryLines)
                    {
                        if (!mds.Contains(mdLine.Delivery))
                        {
                            FilterDeleted(mdLine.Delivery.DeliveryLines);
                            mds.Add(mdLine.Delivery);
                        }
                    }
                }
                BindDeliveries = mds;
                SetTotalVerifiedQty(mds);
            }
        }
        #endregion

        #region 提单转仓单
        public bool CanBeConvertTd2WR(int tdId, out string errorMsg)
        {
            bool _canConvert = true;
            errorMsg = string.Empty;
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                Delivery delivery = deliveryService.SelectById(new List<string> { "DeliveryLines", "DeliveryLines.WarehouseInLines", "DeliveryLines.SalesDeliveryLines" }, tdId);
                FilterDeleted(delivery.DeliveryLines);
                foreach (var line in delivery.DeliveryLines)
                {
                    FilterDeleted(line.WarehouseInLines);
                    if (line.WarehouseInLines.Count > 0)
                    {
                        errorMsg = "提单已有入库，不能转仓单！";
                        break;
                    }
                    FilterDeleted(line.SalesDeliveryLines);
                    if (line.SalesDeliveryLines.Count > 0)
                    {
                        errorMsg = "提单已销售，不能转仓单！";
                        break;
                    }
                }
                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    _canConvert = false;
                }
            }

            return _canConvert;
        }
        #endregion
    }
}