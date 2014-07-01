using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.VATInvoiceLineServiceReference;
using Client.VATInvoiceServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using DBEntity.EnumEntity;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceListVM : BaseVM
    {
        #region Member

        private Dictionary<string, int> _approveStatus;
        private int? _approveStatusID;
        private int? _bpId;
        private string _bpName;
        private VATInvoiceLineDetailVM _detailVM;
        private int? _internalBPId;
        private DateTime? _invoicedEndDate;
        private DateTime? _invoicedStartDate;
        private int _listFrom;
        private int _listTo;
        private int _listTotleCount;
        private VATInvoiceListVM _listVM;
        private int? _selectedMetal;
        private List<VATInvoiceLine> _vatInvoiceLines;
        private List<VATInvoice> _vatInvoices;
        private int? _vatStatusId;
        private DateTime? _implementedStartDate;
        private DateTime? _implementedEndDate;
        private int? _vatInvoiceTypeId;
        private bool _containCurrentUser;
        private decimal? _totalQuantity;
        private decimal? _totalAmount;
        private List<VATInvoiceLine> _AllLines;
        #endregion

        #region Property
        public List<VATInvoiceLine> AllLines
        {
            get { return _AllLines; }
            set { 
                if(_AllLines != value)
                {
                    _AllLines = value;
                    Notify("AllLines");
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

        public int? VATStatusId
        {
            get { return _vatStatusId; }
            set
            {
                if (_vatStatusId != value)
                {
                    _vatStatusId = value;
                    Notify("VATStatusId");
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

        public VATInvoiceListVM ListVM
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

        public VATInvoiceLineDetailVM DetailVM
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

        public List<VATInvoice> VATInvoices
        {
            get { return _vatInvoices; }
            set
            {
                if (_vatInvoices != value)
                {
                    _vatInvoices = value;
                    Notify("VATInvoices");
                }
            }
        }

        public List<VATInvoiceLine> VATInvoiceLines
        {
            get { return _vatInvoiceLines; }
            set
            {
                if (_vatInvoiceLines != value)
                {
                    _vatInvoiceLines = value;
                    Notify("VATInvoiceLines");
                }
            }
        }

        public DateTime? InvoicedStartDate
        {
            get { return _invoicedStartDate; }
            set
            {
                if (_invoicedStartDate != value)
                {
                    _invoicedStartDate = value;
                    Notify("InvoicedStartDate");
                }
            }
        }

        public DateTime? InvoicedEndDate
        {
            get { return _invoicedEndDate; }
            set
            {
                if (_invoicedEndDate != value)
                {
                    _invoicedEndDate = value;
                    Notify("InvoicedEndDate");
                }
            }
        }

        public DateTime? ImplementedStartDate
        {
            get { return _implementedStartDate; }
            set
            {
                if (_implementedStartDate != value)
                {
                    _implementedStartDate = value;
                    Notify("ImplementedStartDate");
                }
            }
        }

        public DateTime? ImplementedEndDate
        {
            get { return _implementedEndDate; }
            set
            {
                if (_implementedEndDate != value)
                {
                    _implementedEndDate = value;
                    Notify("ImplementedEndDate");
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

        public int? VATInvoiceTypeId
        {
            get { return _vatInvoiceTypeId; }
            set
            {
                if (_vatInvoiceTypeId != value)
                {
                    _vatInvoiceTypeId = value;
                    Notify("VATInvoiceTypeId");
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

        public decimal? TotalQuantity
        {
            get { return Math.Round((decimal)_totalQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                if (_totalQuantity != value)
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
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    Notify("TotalAmount");
                }
            }
        }
        #endregion

        #region Method

        public void Init()
        {
            InitPage();
        }

        private void InitPage()
        {
            LoadListCount();
        }

        public void LoadListCount()
        {
            using (
                var vatInvoicedLineService =
                    SvcClientManager.GetSvcClient<VATInvoiceLineServiceClient>(SvcType.VATInvoiceLineSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _listTotleCount = queryStr == string.Empty ? vatInvoicedLineService.GetAllCount() : vatInvoicedLineService.GetCount(queryStr, parameters);

                TotalQuantity = queryStr == string.Empty
                                    ? vatInvoicedLineService.SelectSum("1=1", null, null, "it.VATInvoiceQuantity")
                                    : vatInvoicedLineService.SelectSum(queryStr, parameters, null,
                                                                       "it.VATInvoiceQuantity");
                TotalAmount = queryStr == string.Empty
                                    ? vatInvoicedLineService.SelectSum("1=1", null, null, "it.VATAmount")
                                    : vatInvoicedLineService.SelectSum(queryStr, parameters, null,
                                                                       "it.VATAmount");
            }
        }

        public void LoadList()
        {
            using (
                var vatInvoicedLineService =
                    SvcClientManager.GetSvcClient<VATInvoiceLineServiceClient>(SvcType.VATInvoiceLineSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                var includesForFilter = new List<string>
                                            {
                                                "VATInvoice",
                                                "VATInvoice.BusinessPartner",
                                                "VATInvoice.BusinessPartner1",
                                            };

                var includesForLoad = new List<string>
                                            {
                                                "VATInvoiceRequestLine",
                                                "VATInvoiceRequestLine.VATInvoiceRequest",
                                                "Quota",
                                                "Quota.Deliveries",
                                                "Quota.WarehouseOuts"
                                            };

                if (queryStr == string.Empty)
                {
                    queryStr = "1=1";
                }

                VATInvoiceLines = vatInvoicedLineService.SelectByRangeWithMultiOrderLazyLoad(queryStr, parameters,
                                                                                new List<SortCol> { new SortCol { ByDescending = true, ColName = "VATInvoice.InvoicedDate" } },
                                                                                ListFrom, ListTo, includesForFilter, includesForLoad);

            }
        }

        public void LoadListAll()
        {
            using (
               var vatInvoicedLineService =
                   SvcClientManager.GetSvcClient<VATInvoiceLineServiceClient>(SvcType.VATInvoiceLineSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                var includes = new List<string>
                                            {
                                                "VATInvoice",
                                                "VATInvoice.BusinessPartner",
                                                "VATInvoice.BusinessPartner1",
                                                "VATInvoiceRequestLine",
                                                "VATInvoiceRequestLine.VATInvoiceRequest",
                                                "Quota",
                                                "Quota.Deliveries",
                                                "Quota.WarehouseOuts"
                                            };

                if (queryStr == string.Empty)
                {
                    queryStr = "1=1";
                }
                AllLines = vatInvoicedLineService.Select(queryStr, parameters, includes);

                AllLines = AllLines.OrderByDescending(c => c.VATInvoice.InvoicedDate).ToList();
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
                        sb.AppendFormat("it.VATInvoice.BusinessPartner1.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.VATInvoice.BusinessPartner1.Id = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (ContainCurrentUser)
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
                sb.AppendFormat("it.VATInvoice.BPId = @p{0} ", num++);
                parameters.Add(BPId);
            }
            if (InternalBPId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.InternalBPId = @p{0} ", num++);
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

            if (SelectedMetal > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.CommodityId = @p{0} ", num++);
                parameters.Add(SelectedMetal);
            }

            if (VATStatusId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Quota.VATStatus = @p{0} ", num++);
                parameters.Add(VATStatusId);
            }

            if (InvoicedStartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.InvoicedDate >= @p{0} ", num++);
                parameters.Add(InvoicedStartDate);
            }

            if (InvoicedEndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.InvoicedDate <= @p{0} ", num++);
                parameters.Add(InvoicedEndDate);
            }

            if (ImplementedStartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.InvoicedDate >= @p{0} ", num++);
                parameters.Add(ImplementedStartDate);
            }

            if (ImplementedEndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.InvoicedDate <= @p{0} ", num++);
                parameters.Add(ImplementedEndDate);
            }

            if (VATInvoiceTypeId > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.VATInvoice.VATInvoiceType = @p{0} ", num);
                parameters.Add(VATInvoiceTypeId);
            }

            queryStr = sb.ToString();
        }

        public VATInvoice GetItByLineId(int id)
        {
            using (var vatInvoiceLineService =
                    SvcClientManager.GetSvcClient<VATInvoiceLineServiceClient>(SvcType.VATInvoiceLineSvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> {id};
                VATInvoiceLine line =
                    vatInvoiceLineService.Select(str, parameters, new List<string> {"VATInvoice"}).FirstOrDefault();
                if (line != null)
                    return line.VATInvoice;
            }
            return null;
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVATInvoice(int id)
        {
            using (var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc))
            {
                vatInvoiceService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}