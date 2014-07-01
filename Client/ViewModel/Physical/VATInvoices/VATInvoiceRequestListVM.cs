using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.VATInvoicedRequestLineServiceReference;
using Client.VATInvoicedRequestServiceReference;
using Client.ViewModel.Console.ApprovalCenter;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.ComponentModel;
using Client.VATInvoiceServiceReference;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceRequestListVM : BaseVM
    {
        #region Member

        private Dictionary<string, int> _approveStatus;
        private int? _approveStatusID;
        private int? _bpId;
        private string _bpName;
        private VATInvoiceRequestLineDetailVM _detailVM;
        private int? _internalBPId;
        private List<BusinessPartner> _internalBPs;
        private int _listFrom;
        private int _listTo;
        private int _listTotleCount;
        private VATInvoiceRequestListVM _listVM;
        private DateTime? _requestEndDate;
        private DateTime? _requestStartDate;
        private int? _selectedMetal;
        private List<VATInvoiceRequestLine> _vatInvoiceRequestLines;
        private List<VATInvoiceRequest> _vatInvoiceRequests;
        private int? _createdBy;
        private bool _isOnlyCurrentUser;
        private decimal? _totalQuantity;
        private decimal? _totalAmount;
        private List<VATInvoiceRequestLine> _vatInvoiceRequestLinesAll;
        private decimal? _VerifiedQuantity;
        private bool _SelectAll;
        private List<VATInvoiceBatchClass> batchs = new List<VATInvoiceBatchClass>();
        private List<VATInvoiceRequestLine> _SelectedList;
        private bool _isNeedApproved;
        #endregion

        #region Property
        public bool IsNeedApproved
        {
            get { return _isNeedApproved; }
            set
            {
                if (_isNeedApproved != value)
                {
                    _isNeedApproved = value;
                    Notify("IsNeedApproved");
                }
            }
        }

        public List<VATInvoiceRequestLine> SelectedList
        {
            get { return _SelectedList; }
            set { 
                if(_SelectedList != value)
                {
                    _SelectedList = value;
                    Notify("SelectedList");
                }
            }
        }

        public decimal? VerifiedQuantity
        {
            get { return _VerifiedQuantity; }
            set
            {
                if (_VerifiedQuantity != value)
                {
                    _VerifiedQuantity = value;
                    Notify("VerifiedQuantity");
                }
            }
        }

        public List<VATInvoiceRequestLine> VATInvoiceRequestLinesAll
        {
            get { return _vatInvoiceRequestLinesAll; }
            set
            {
                if (_vatInvoiceRequestLinesAll != value)
                {
                    _vatInvoiceRequestLinesAll = value;
                    Notify("VATInvoiceRequestLinesAll");
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

        public int? CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    _createdBy = value;
                    Notify("CreatedBy");
                }
            }
        }

        public int? BPId
        {
            get { return _bpId; }
            set
            {
                if (_bpId != value)
                {
                    _bpId = value;
                    Notify("BPId");
                }
            }
        }

        public int? InternalBPId
        {
            get { return _internalBPId; }
            set
            {
                if (_internalBPId != value)
                {
                    _internalBPId = value;
                    Notify("InternalBPId");
                }
            }
        }

        public List<BusinessPartner> InternalBPs
        {
            get { return _internalBPs; }
            set
            {
                if (_internalBPs != value)
                {
                    _internalBPs = value;
                    Notify("InternalBPs");
                }
            }
        }

        public int? SelectedMetal
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

        public string BPName
        {
            get { return _bpName; }
            set
            {
                if (_bpName != value)
                {
                    _bpName = value;
                    Notify("BPName");
                }
            }
        }

        public int? ApproveStatusID
        {
            get { return _approveStatusID; }
            set
            {
                if (_approveStatusID != value)
                {
                    _approveStatusID = value;
                    Notify("ApproveStatusID");
                }
            }
        }

        public Dictionary<string, int> ApproveStatus
        {
            get { return _approveStatus; }
            set
            {
                if (_approveStatus != value)
                {
                    _approveStatus = value;
                    Notify("ApproveStatus");
                }
            }
        }

        public DateTime? RequestStartDate
        {
            get { return _requestStartDate; }
            set
            {
                if (_requestStartDate != value)
                {
                    _requestStartDate = value;
                    Notify("RequestStartDate");
                }
            }
        }

        public DateTime? RequestEndDate
        {
            get { return _requestEndDate; }
            set
            {
                if (_requestEndDate != value)
                {
                    _requestEndDate = value;
                    Notify("RequestEndDate");
                }
            }
        }

        public VATInvoiceRequestListVM ListVM
        {
            get { return _listVM; }
            set
            {
                if (_listVM != value)
                {
                    _listVM = value;
                    Notify("ListVM");
                }
            }
        }

        public VATInvoiceRequestLineDetailVM DetailVM
        {
            get { return _detailVM; }
            set
            {
                if (_detailVM != value)
                {
                    _detailVM = value;
                    Notify("DetailVM");
                }
            }
        }

        public List<VATInvoiceRequest> VATInvoiceRequests
        {
            get { return _vatInvoiceRequests; }
            set
            {
                if (_vatInvoiceRequests != value)
                {
                    _vatInvoiceRequests = value;
                    Notify("VATInvoiceRequests");
                }
            }
        }

        public List<VATInvoiceRequestLine> VATInvoiceRequestLines
        {
            get { return _vatInvoiceRequestLines; }
            set
            {
                if (_vatInvoiceRequestLines != value)
                {
                    _vatInvoiceRequestLines = value;
                    Notify("VATInvoiceRequestLines");
                }
            }
        }

        public int ListTotleCount
        {
            get { return _listTotleCount; }
            set
            {
                if (_listTotleCount != value)
                {
                    _listTotleCount = value;
                    Notify("ListTotleCount");
                }
            }
        }

        public int ListFrom
        {
            get { return _listFrom; }
            set
            {
                if (_listFrom != value)
                {
                    _listFrom = value;
                    Notify("ListFrom");
                }
            }
        }

        public int ListTo
        {
            get { return _listTo; }
            set
            {
                if (_listTo != value)
                {
                    _listTo = value;
                    Notify("ListTo");
                }
            }
        }

        public decimal? TotalQuantity
        {
            get { return Math.Round((decimal)_totalQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                if (value != null && _totalQuantity != value)
                {
                    _totalQuantity = value;
                    Notify("TotalQuantity");
                }
            }
        }

        public decimal? TotalAmount
        {
            get { return Math.Round((decimal)_totalAmount, RoundRules.AMOUNT, MidpointRounding.AwayFromZero); }
            set
            {
                if (value != null && _totalAmount != value)
                {
                    _totalAmount = value;
                    Notify("TotalAmount");
                }
            }
        }

        public bool SelectAll
        {
            get { return _SelectAll; }
            set
            {
                if (_SelectAll != value)
                {
                    _SelectAll = value;
                    Notify("SelectAll");
                }
            }
        }
        #endregion

        #region Method
        public VATInvoiceRequestListVM()
        {
            PropertyChanged += OnPropertyChanged;
            GetInternalCustomer();
        }

        /// <summary>
        /// 审核通过的开票申请
        /// </summary>
        public void Load()
        {
            ListVM = new VATInvoiceRequestListVM
                         {
                             BPId = BPId,
                             InternalBPId = InternalBPId,
                             RequestStartDate = RequestStartDate,
                             RequestEndDate = RequestEndDate,
                         };
            LoadList(true);
        }

        public void Init(bool isNeedApproved)
        {
            IsNeedApproved = isNeedApproved;
            LoadListCount(IsNeedApproved);
        }

        public void LoadListCount(bool isNeedApproved)
        {
            using (var vatInvoicedRequestLineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                string queryStr;
                List<object> parameters;

                if (isNeedApproved)
                {
                    BuildQueryStrAndParams2(out queryStr, out parameters);
                    _listTotleCount = queryStr == string.Empty
                                    ? vatInvoicedRequestLineService.GetCount("it.ApproveStatus = " + (int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded + " or it.ApproveStatus = " + (int)DBEntity.EnumEntity.ApproveStatus.Approved + " and it.VATStatus != " + (int)VATStatus.Complete + " and it.Quota.VATStatus != " + (int)QuotaVATStatus.Complete, null)
                                    : vatInvoicedRequestLineService.GetCount(queryStr, parameters);
                }
                else
                {
                    BuildQueryStrAndParams(out queryStr, out parameters);
                    _listTotleCount = queryStr == string.Empty
                                         ? vatInvoicedRequestLineService.GetAllCount()
                                         : vatInvoicedRequestLineService.GetCount(queryStr, parameters);
                }

                TotalQuantity = string.IsNullOrWhiteSpace(queryStr)
                                    ? vatInvoicedRequestLineService.SelectSum("1=1", null, null, "it.RequestQuantity")
                                    : vatInvoicedRequestLineService.SelectSum(queryStr, parameters, null,
                                                                              "it.RequestQuantity");
                TotalAmount = string.IsNullOrWhiteSpace(queryStr)
                                  ? vatInvoicedRequestLineService.SelectSum("1=1", null, null, "it.RequestAmount")
                                  : vatInvoicedRequestLineService.SelectSum(queryStr, parameters, null,
                                                                            "it.RequestAmount");
            }
        }

        public void LoadList(bool isNeedApproved)
        {
            using (var vatInvoicedRequestLineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                string queryStr;
                List<object> parameters;
                if (isNeedApproved)
                {
                    BuildQueryStrAndParams2(out queryStr, out parameters);
                }
                else
                {
                    BuildQueryStrAndParams(out queryStr, out parameters);
                }

                if (queryStr == string.Empty)
                {
                    queryStr = "1=1";
                }

              
                VATInvoiceRequestLines = vatInvoicedRequestLineService.SelectByRangeWithMultiOrderLazyLoad(
                                                                                    queryStr, parameters,
                                                                                    new List<SortCol>
                                                                                    {
                                                                                        new SortCol { ByDescending = true, ColName = "VATInvoiceRequest.Created" }
                                                                                    },
                                                                                    ListFrom, ListTo,
                                                                                    new List<string>
                                                                                    {
                                                                                        "VATInvoiceRequest",
                                                                                        "Quota",
                                                                                    },
                                                                                    new List<string>
                                                                                    {      
                                                                                        "Quota.Commodity",
                                                                                        "Quota.CommodityType",
                                                                                        "Quota.Brand",
                                                                                        "VATInvoiceRequest.BusinessPartner",
                                                                                        "VATInvoiceRequest.InternalCustomer",
                                                                                        "Approval",
                                                                                        "Approval.ApprovalStages",
                                                                                        "Approval.ApprovalStages.ApprovalUser"
                                                                                    }).ToList();

                foreach (VATInvoiceRequestLine item in VATInvoiceRequestLines)
                {
                    if (item.Approval != null)
                    {
                        FilterDeleted(item.Approval.ApprovalStages);

                        string passed, notPassed;
                        List<ApprovalStage> stages = item.Approval.ApprovalStages.ToList();
                        ApprovalCenterHomeVM.ParseApprovalDetailString(stages, item.ApprovalStageIndex ?? 0, out passed,
                                                                       out notPassed);
                        if (item.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.Approved)
                        {
                            item.CustomerStrField1 = passed + notPassed;
                            item.CustomerStrField2 = string.Empty;
                        }
                        else
                        {
                            item.CustomerStrField1 = passed;
                            item.CustomerStrField2 = notPassed;
                        }
                    }
                }
                SelectAll = false;
            }
        }

        public void LoadVATInvoiceRequestLinesAll()
        {
            using (var vatInvoicedRequestLineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                string queryStr;
                List<object> parameters;
                if (IsNeedApproved)
                {
                    BuildQueryStrAndParams2(out queryStr, out parameters);
                }
                else
                {
                    BuildQueryStrAndParams(out queryStr, out parameters);
                }

                VATInvoiceRequestLinesAll = vatInvoicedRequestLineService.Select(queryStr, parameters, new List<string>
                                                                             {
                                                                                 "VATInvoiceRequest",
                                                                                 "VATInvoiceRequest.BusinessPartner",
                                                                                 "VATInvoiceRequest.InternalCustomer",
                                                                                 "Quota",
                                                                                 "Quota.Commodity",
                                                                                 "Quota.Brand",
                                                                                 "Quota.CommodityType",
                                                                             }).OrderByDescending(t => t.VATInvoiceRequest.Created).ToList();
            }
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
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
            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
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
                        sb.AppendFormat("it.VATInvoiceRequest.InternalCustomer.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.VATInvoiceRequest.InternalCustomer.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (IsOnlyCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            if (BPId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.BPId = @p{0} ", num++);
                parameters.Add(BPId);
            }
            if (InternalBPId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.InternalBPId = @p{0} ", num++);
                parameters.Add(InternalBPId);
            }

            if (SelectedMetal > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.CommodityId = @p{0} ", num++);
                parameters.Add(SelectedMetal);
            }

            if (RequestStartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.RequestDate >= @p{0} ", num++);
                parameters.Add(RequestStartDate);
            }
            if (RequestEndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.RequestDate <= @p{0} ", num++);
                parameters.Add(RequestEndDate);
            }
            if (VerifiedQuantity.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.VerifiedQuantity = @p{0}", num++);
                parameters.Add(VerifiedQuantity);
            }

            if (CreatedBy > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.CreatedBy = @p{0} ", num++);
                parameters.Add(CreatedBy);
            }

            if (ApproveStatusID > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.ApproveStatus = @p{0} ", num);
                parameters.Add(ApproveStatusID);
            }


            queryStr = sb.ToString();
        }

        private void BuildQueryStrAndParams2(out string queryStr, out List<object> parameters)
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
            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
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
                        sb.AppendFormat("it.VATInvoiceRequest.InternalCustomer.Id= @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.VATInvoiceRequest.InternalCustomer.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (BPId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.BPId = @p{0} ", num++);
                parameters.Add(BPId);
            }
            if (InternalBPId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.InternalBPId = @p{0} ", num++);
                parameters.Add(InternalBPId);
            }
            if (RequestStartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.RequestDate >= @p{0} ", num++);
                parameters.Add(RequestStartDate);
            }
            if (RequestEndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoiceRequest.RequestDate <= @p{0} ", num++);
                parameters.Add(RequestEndDate);
            }
            if (sb.Length != 0)
            {
                sb.Append(" and ");
            }
            sb.AppendFormat("(it.ApproveStatus = @p{0} ", num++);
            parameters.Add((int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded);
            sb.AppendFormat("or it.ApproveStatus = @p{0} )", num++);
            parameters.Add((int)DBEntity.EnumEntity.ApproveStatus.Approved);
            sb.AppendFormat("and it.Quota.VATStatus != @p{0} ", num++);
            parameters.Add((int)QuotaVATStatus.Complete);
            sb.AppendFormat("and it.VATStatus != @p{0} ", num);
            parameters.Add((int)VATStatus.Complete);
            queryStr = sb.ToString();
        }


        public VATInvoiceRequest GetItByLineId(int id)
        {
            using (
                var lineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc)
                )
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> { id };
                VATInvoiceRequestLine line =
                    lineService.Select(str, parameters, new List<string> { "VATInvoiceRequest" }).FirstOrDefault();
                if (line != null)
                    return line.VATInvoiceRequest;
            }
            return null;
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            using (var vatInvoiceRequestLineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                vatInvoiceRequestLineService.RemoveById(id, CurrentUser.Id);
            }
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        public void RemoveInvoiceRequest(int id)
        {
            using (var vatInvoiceRequestService =
                    SvcClientManager.GetSvcClient<VATInvoiceRequestServiceClient>(SvcType.VATInvoiceRequestSvc))
            {
                vatInvoiceRequestService.RemoveById(id, CurrentUser.Id);
            }
        }

        public bool CanLineEditWithApproveStatus(int id)
        {
            using (var lineService =
                    SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                VATInvoiceRequestLine line = lineService.GetById(id);
                if (line != null &&
                    (line.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.InApprove ||
                     line.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.Approved))
                {
                    return false;
                }

                return true;
            }
        }

        public void GetInternalCustomer()
        {
            using (var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalBPs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalBPs.Insert(0, new BusinessPartner());
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectAll")
            {
                foreach (var invoice in VATInvoiceRequestLines)
                {
                    if (invoice.InvoiceSelectedEnable)
                    {
                        invoice.IsSelected = SelectAll;
                    }
                }
            }
        }

        /// <summary>
        /// 批量开票
        /// </summary>
        public void BatchInvoiceOperation()
        {
            SelectedList = new List<VATInvoiceRequestLine>();
            if (VATInvoiceRequestLines != null && VATInvoiceRequestLines.Count > 0)
            {
                SelectedList = VATInvoiceRequestLines.Where(o => o.IsSelected).ToList();
                if (SelectedList.Count > 0)
                {
                    using (var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc))
                    {
                        var batchInvoices = vatInvoiceService.GetBatchInvoiceByLines(CurrentUser.Id, SelectedList);
                        vatInvoiceService.CreateDocumentByVATInvoiceBatch(CurrentUser.Id, batchInvoices);
                    }
                }
            }
        }

        #endregion
    }


}