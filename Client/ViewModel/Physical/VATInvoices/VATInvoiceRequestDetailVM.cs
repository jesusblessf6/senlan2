using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.QuotaServiceReference;
using Client.VATInvoicedRequestLineServiceReference;
using Client.VATInvoicedRequestServiceReference;
using Client.View.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.View.PopUpDialog;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceRequestDetailVM : BaseVM
    {
        #region Member

        private List<VATInvoiceRequestLine> _addVATInvoiceRequestLines;
        private Dictionary<string, int> _approveStatus;
        private int? _approveStatusID;
        private int _bpId;
        private string _bpName;
        private string _comment;
        private List<VATInvoiceRequestLine> _deleteVATInvoiceRequestLines;
        private VATInvoiceRequestLineDetailVM _detailVM;
        private int _internalBPId;
        private List<BusinessPartner> _internalBPs;
        private int _listFrom;
        private int _listTo;
        private int _listTotleCount;
        private VATInvoiceRequestListVM _listVM;
        private List<Commodity> _metals;
        private decimal? _quantity;
        private string _quotaNo;
        private DateTime? _requestDate = DateTime.Today;
        private int? _selectedMetal;
        private List<VATInvoiceRequestLine> _showVATInvoiceRequestLines;
        private decimal? _unOpenedQuantity;
        private List<VATInvoiceRequestLine> _updateVATInvoiceRequestLines;
        private TrackableCollection<VATInvoiceRequestLine> _vatInvoiceRequestLines;
        private List<Quota> _QuotaList = new List<Quota>();
        #endregion

        #region Property
        public List<Quota> QuotaList
        {
            get { return _QuotaList; }
            set { 
                if(_QuotaList != value)
                {
                    _QuotaList = value;
                    Notify("QuotaList");
                }
            }
        }

        public List<VATInvoiceRequestLine> AddVATInvoiceRequestLines
        {
            get { return _addVATInvoiceRequestLines; }
            set
            {
                if (_addVATInvoiceRequestLines != value)
                {
                    _addVATInvoiceRequestLines = value;
                    Notify("AddVATInvoiceRequestLines");
                }
            }
        }

        public List<VATInvoiceRequestLine> UpdateVATInvoiceRequestLines
        {
            get { return _updateVATInvoiceRequestLines; }
            set
            {
                if (_updateVATInvoiceRequestLines != value)
                {
                    _updateVATInvoiceRequestLines = value;
                    Notify("UpdateVATInvoiceRequestLines");
                }
            }
        }

        public List<VATInvoiceRequestLine> DeleteVATInvoiceRequestLines
        {
            get { return _deleteVATInvoiceRequestLines; }
            set
            {
                if (_deleteVATInvoiceRequestLines != value)
                {
                    _deleteVATInvoiceRequestLines = value;
                    Notify("DeleteVATInvoiceRequestLines");
                }
            }
        }

        public List<VATInvoiceRequestLine> ShowVATInvoiceRequestLines
        {
            get { return _showVATInvoiceRequestLines; }
            set
            {
                if (_showVATInvoiceRequestLines != value)
                {
                    _showVATInvoiceRequestLines = value;
                    Notify("ShowVATInvoiceRequestLines");
                }
            }
        }

        public int BPId
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

        public int InternalBPId
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

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
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

        public DateTime? RequestDate
        {
            get { return _requestDate; }
            set
            {
                if (_requestDate != value)
                {
                    _requestDate = value;
                    Notify("RequestDate");
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

        public TrackableCollection<VATInvoiceRequestLine> VATInvoiceRequestLines
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

        public decimal? Quantity
        {
            get { return Math.Round(_quantity == null ? 0 : (decimal)_quantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    Notify("Quantity");
                }
            }
        }

        public decimal? UnOpenedQuantity
        {
            get { return Math.Round(_unOpenedQuantity == null ? 0 : (decimal)_unOpenedQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                if (_unOpenedQuantity != value)
                {
                    _unOpenedQuantity = value;
                    Notify("UnOpenedQuantity");
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

        #endregion

        #region Constructor

        public VATInvoiceRequestDetailVM()
        {
            ObjectId = 0;
            QuotaList = new List<Quota>();
            Initialize();
        }

        public VATInvoiceRequestDetailVM(int id)
        {
            ObjectId = id;
            QuotaList = new List<Quota>();
            if (DetailVM == null)
                DetailVM = new VATInvoiceRequestLineDetailVM();
            Initialize();
        }

        #endregion

        #region Method

        /// <summary>
        /// 自动生成新增的行Id
        /// </summary>
        /// <returns></returns>
        private int GetLineId()
        {
            if (ShowVATInvoiceRequestLines.Count == 0)
                return 1;
            IEnumerable<int> query = from lines in ShowVATInvoiceRequestLines select Math.Abs(lines.Id);
            int id = query.Max();
            return id + 1;
        }

        /// <summary>
        /// 根据Id查找批次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VATInvoiceRequestLine GetVATInvoiceRequestLineByID(int id)
        {
            IEnumerable<VATInvoiceRequestLine> query = from line in ShowVATInvoiceRequestLines
                                                       where line.Id == id
                                                       select line;
            List<VATInvoiceRequestLine> q = query.ToList();
            if (q.Count > 0)
            {
                return q[0];
            }
            return null;
        }

        public VATInvoiceRequestLine GetLineById(int id, List<VATInvoiceRequestLine> lines)
        {
            if (lines != null)
            {
                return lines.FirstOrDefault(t => t.Id == id);
            }

            return null;
        }

        public void GetInternalCustomer()
        {
            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalBPs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalBPs.Insert(0, new BusinessPartner { Id = 0, ShortName = "" });
            }
        }

        public void Initialize()
        {
            ShowVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
            GetInternalCustomer();
            if (ObjectId > 0)
            {
                using (
                    var vatInvoiceRequestService =
                        SvcClientManager.GetSvcClient<VATInvoiceRequestServiceClient>(SvcType.VATInvoiceRequestSvc))
                {
                    string strInfo = string.Format("it.Id={0}", ObjectId);
                    VATInvoiceRequest vatr =
                        vatInvoiceRequestService.Select(strInfo, null,
                                                        new List<string>
                                                            {
                                                                "VATInvoiceRequestLines.Quota",
                                                                "VATInvoiceRequestLines.Quota.Deliveries",
                                                                "VATInvoiceRequestLines.Quota.WarehouseOuts",
                                                                "BusinessPartner",
                                                                "InternalCustomer",
                                                                "VATInvoiceRequestLines"
                                                            }).FirstOrDefault();
                    if (vatr != null)
                    {
                        FilterDeleted(vatr.VATInvoiceRequestLines);
                        BPId = vatr.BPId;
                        InternalBPId = vatr.InternalBPId;
                        RequestDate = vatr.RequestDate;
                        Comment = vatr.Comment;
                        BPName = vatr.BusinessPartner.ShortName;
                        ShowVATInvoiceRequestLines = vatr.VATInvoiceRequestLines.Where(c => !c.IsDeleted).ToList();
                    }
                }
            }
        }

        protected override void Create()
        {
            using (
                var vatInvoiceRequestService =
                    SvcClientManager.GetSvcClient<VATInvoiceRequestServiceClient>(SvcType.VATInvoiceRequestSvc))
            {
                var invoiceRequest = new VATInvoiceRequest
                                         {
                                             BPId = BPId,
                                             InternalBPId = InternalBPId,
                                             Comment = Comment,
                                             RequestDate = RequestDate,
                                             IsDeleted = false,
                                             IsDraft = false,
                                         };
                vatInvoiceRequestService.CreateDocument(CurrentUser.Id, invoiceRequest, AddVATInvoiceRequestLines, QuotaList);
            }
        }

        protected override void Update()
        {
            using (
                var vatInvoiceRequestService =
                    SvcClientManager.GetSvcClient<VATInvoiceRequestServiceClient>(SvcType.VATInvoiceRequestSvc))
            {
                var vtr = new VATInvoiceRequest
                              {
                                  Id = ObjectId,
                                  BPId = BPId,
                                  InternalBPId = InternalBPId,
                                  Comment = Comment,
                                  RequestDate = RequestDate,
                              };
                vatInvoiceRequestService.UpdateDocument(CurrentUser.Id, vtr, AddVATInvoiceRequestLines,
                                                        UpdateVATInvoiceRequestLines, DeleteVATInvoiceRequestLines, QuotaList);
            }
        }

        public bool IsExisted()
        {
            return false;
        }


        public override bool Validate()
        {
            if (BPId <= 0)
            {
                throw new Exception(ResVATInvoice.BuyerIsRequired);
            }
            if (InternalBPId <= 0)
            {
                throw new Exception(ResVATInvoice.InvoiceBPRequired);
            }
            if (ShowVATInvoiceRequestLines == null || ShowVATInvoiceRequestLines.Count == 0)
            {
                throw new Exception(ResVATInvoice.DetailRequired);
            }

            var idlist = ShowVATInvoiceRequestLines.Select(o => o.QuotaId).Distinct().ToList();
            var slist = idlist.Select(id => " it.Id = " + id + " ").ToList();
            var qstr = string.Join(" or ", slist);
            List<Quota> quotas = null;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quotas = quotaService.Select(qstr, null, new List<string> { "Deliveries" });
            }
            foreach(Quota q in quotas)
            {
                FilterDeleted(q.Deliveries);
                foreach (Delivery del in q.Deliveries)
                {
                    if (del.IsVerified == false)
                    {
                        if (del.DeliveryType == (int)DeliveryType.InternalTDBOL || del.DeliveryType == (int)DeliveryType.InternalTDWW)
                        {
                            throw new Exception("合同" + q.QuotaNo + "对应的提单" + del.DeliveryNo + "，实数没有确认！");
                        }
                        else
                        {
                            throw new Exception("合同" + q.QuotaNo + "对应的发货单" + del.DeliveryNo + "，实数没有确认！");
                        }
                    }
                }
            }
            return true;
        }

        public bool CreateQuotaValidate()
        {
            if (BPId <= 0)
            {
                throw new Exception(ResVATInvoice.BuyerIsRequired);
            }
            if (InternalBPId <= 0)
            {
                throw new Exception(ResVATInvoice.InvoiceBPRequired);
            }
            return true;
        }

        public bool CanLineEdit(int id)
        {
            using ( var lineService = SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc) )
            {
                VATInvoiceRequestLine line = lineService.GetById(id);
                if (line != null && (line.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.InApprove ||
                    line.ApproveStatus == (int)DBEntity.EnumEntity.ApproveStatus.Approved))
                {
                    return false;
                }

                return true;
            }
        }

        public bool CanLineDelete(int id)
        {
            using (var lineService = SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
            {
                VATInvoiceRequestLine line = lineService.GetById(id);

                if (line.VATStatus == (int)VATStatus.Complete || line.VATStatus == (int)VATStatus.Partial)
                {
                    return false;
                }

                return true;
            }
        }

        #endregion

        #region 维护列表

        /// <summary>
        /// 新增批次
        /// </summary>
        /// <param name="line"> </param>
        public void AddLine(VATInvoiceRequestLine line)
        {
            if (ShowVATInvoiceRequestLines == null)
                ShowVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
            int no = GetLineId();
            line.Id = -no;
            ShowVATInvoiceRequestLines.Add(line);
            if (AddVATInvoiceRequestLines == null)
            {
                AddVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
            }
            AddVATInvoiceRequestLines.Add(line);
        }

        /// <summary>
        /// 修改批次
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLine(int id)
        {
            VATInvoiceRequestLine line = GetLineById(id, ShowVATInvoiceRequestLines);
            if (line != null)
            {
                VATInvoiceRequestLine addLine = GetLineById(id, AddVATInvoiceRequestLines);
                if (addLine == null)
                {
                    if (UpdateVATInvoiceRequestLines == null)
                    {
                        UpdateVATInvoiceRequestLines = new List<VATInvoiceRequestLine> { line };
                    }
                }
            }
        }

        /// <summary>
        /// 删除批次
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLine(int id)
        {
            VATInvoiceRequestLine line = GetLineById(id, ShowVATInvoiceRequestLines);
            if (line != null)
            {
                ShowVATInvoiceRequestLines.Remove(line);
                VATInvoiceRequestLine addLine = GetLineById(id, AddVATInvoiceRequestLines);
                if (addLine != null)
                {
                    AddVATInvoiceRequestLines.Remove(addLine);
                }
                else
                {
                    VATInvoiceRequestLine updateLine = GetLineById(id, UpdateVATInvoiceRequestLines);
                    if (updateLine != null)
                    {
                        UpdateVATInvoiceRequestLines.Remove(updateLine);
                    }
                    if (DeleteVATInvoiceRequestLines == null)
                    {
                        DeleteVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
                    }
                    DeleteVATInvoiceRequestLines.Add(line);
                }
            }
        }

        #endregion

        #region 批次弹出框
        public void GetInvoiceRequestDetailsByQuotas()
        {
            string queryStr =
               string.Format(
                   "(it.ApproveStatus= {0} or it.ApproveStatus= {1}) and it.Contract.ContractType={2} and it.FinanceStatus=false and it.DeliveryStatus=true and it.PricingStatus={3} and (it.VATStatus!={4}) and (it.Contract.TradeType={5} or it.Contract.TradeType={6}) and it.Contract.BPId={7} and it.Contract.InternalCustomerId={8} and (it.IsVatRequestFinished = false or it.IsVatRequestFinished is null)",
                   (int)DBEntity.EnumEntity.ApproveStatus.Approved, (int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded, (int)ContractType.Sales,
                   (int)PricingStatus.Complete, (int)QuotaVATStatus.Complete, (int)TradeType.LongDomesticTrade,
                   (int)TradeType.ShortDomesticTrade, BPId, InternalBPId);
            PopDialog dialog = PopDialogCreater.CreateDialog("QuotaForVATInvoice", queryStr, null,null,null,0,0,true);
            dialog.ShowDialog();
            var list = dialog.SelectedItemList;
            if (list != null)
            {
                //获取选择的批次列表
                List<Quota> quotas = new List<Quota>();
                foreach (var item in list)
                {
                    Quota quota = item as Quota;
                    if (quota != null && !quotas.Contains(quota))
                    {
                        quotas.Add(quota);
                    }
                }

                if (quotas.Count > 0)
                {
                    var quotaList = quotas.Select(o => o.Id).ToList();

                    if (AddVATInvoiceRequestLines == null)
                    {
                        AddVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
                    }

                    int vatId = GetVATId();
                    using (var vatInvoiceRequestDetailService = SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc))
                    {
                        List<VATInvoiceRequestLine> lines = vatInvoiceRequestDetailService.GetVATInvoiceRequestLinesByQuotaList(CurrentUser.Id, quotaList, vatId);
                        //QuotaList = new List<Quota>();
                        if (lines.Count > 0)
                        {
                            foreach (var line in lines)
                            {
                                if (ShowVATInvoiceRequestLines.Any(item => line.QuotaId == item.QuotaId))
                                {
                                    continue;
                                }
                                ShowVATInvoiceRequestLines.Add(line);
                                
                                AddVATInvoiceRequestLines.Add(line);
                                QuotaList.Add(line.Quota);
                            }
                        }

                    }

                }
            }

        }

        public int GetVATId()
        {
            if (ShowVATInvoiceRequestLines.Count == 0)
                return -1;
            IEnumerable<int> query = from quota in ShowVATInvoiceRequestLines select Math.Abs(quota.Id);
            int no = query.Max();
            return -(no + 1);
        }
        #endregion
    }
}