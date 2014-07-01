using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.QuotaServiceReference;
using Client.VATInvoiceServiceReference;
using Client.View.Physical.VATInvoices;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceDetailVM : BaseVM
    {
        #region Member

        private List<VATInvoiceLine> _addVATInvoiceLines;
        private Dictionary<string, int> _approveStatus;
        private int? _approveStatusID;
        private int _bpId;
        private string _bpName;
        private string _comment;
        private List<VATInvoiceLine> _deleteVATInvoiceLines;
        private VATInvoiceLineDetailVM _detailVM;
        private int _internalBPId;
        private List<BusinessPartner> _internalBPs;
        private string _invoiceNo;
        private DateTime? _invoicedDate = DateTime.Today;
        private int _listFrom;
        private int _listTo;
        private int _listTotleCount;
        private VATInvoiceListVM _listVM;
        private List<Commodity> _metals;
        private decimal? _quantity;
        private string _quotaNo;
        private int? _selectedMetal;
        private List<VATInvoiceLine> _showVATInvoiceLines;
        private decimal? _unOpenedQuantity;
        private List<VATInvoiceLine> _updateVATInvoiceLines;
        private TrackableCollection<VATInvoiceLine> _vatInvoiceLines;
        private int? _vatInvoiceRequestId;
        private int _vatInvoiceType;

        #endregion

        #region Property

        public List<VATInvoiceLine> AddVATInvoiceLines
        {
            get { return _addVATInvoiceLines; }
            set
            {
                if (_addVATInvoiceLines != value)
                {
                    _addVATInvoiceLines = value;
                    Notify("AddVATInvoiceLines");
                }
            }
        }

        public List<VATInvoiceLine> UpdateVATInvoiceLines
        {
            get { return _updateVATInvoiceLines; }
            set
            {
                if (_updateVATInvoiceLines != value)
                {
                    _updateVATInvoiceLines = value;
                    Notify("UpdateVATInvoiceLines");
                }
            }
        }

        public List<VATInvoiceLine> DeleteVATInvoiceLines
        {
            get { return _deleteVATInvoiceLines; }
            set
            {
                if (_deleteVATInvoiceLines != value)
                {
                    _deleteVATInvoiceLines = value;
                    Notify("DeleteVATInvoiceLines");
                }
            }
        }

        public List<VATInvoiceLine> ShowVATInvoiceLines
        {
            get { return _showVATInvoiceLines; }
            set
            {
                if (_showVATInvoiceLines != value)
                {
                    _showVATInvoiceLines = value;
                    Notify("ShowVATInvoiceLines");
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

        public DateTime? InvoicedDate
        {
            get { return _invoicedDate; }
            set
            {
                if (_invoicedDate != value)
                {
                    _invoicedDate = value;
                    Notify("InvoicedDate");
                }
            }
        }

        public int VATInvoiceType
        {
            get { return _vatInvoiceType; }
            set
            {
                if (_vatInvoiceType != value)
                {
                    _vatInvoiceType = value;
                    Notify("VATInvoiceType");
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

        public TrackableCollection<VATInvoiceLine> VATInvoiceLines
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

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                if (_invoiceNo != value)
                {
                    _invoiceNo = value;
                    Notify("InvoiceNo");
                }
            }
        }

        public int? VATInvoiceRequestId
        {
            get { return _vatInvoiceRequestId; }
            set
            {
                if (_vatInvoiceRequestId != value)
                {
                    _vatInvoiceRequestId = value;
                    Notify("VATInvoiceRequestId");
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

        public VATInvoiceDetailVM(int vatInvoiceType, PageMode pageMode)
        {
            VATInvoiceType = vatInvoiceType;
            ObjectId = 0;
            Initialize();
        }

        public VATInvoiceDetailVM(int id)
        {
            ObjectId = id;
            if (DetailVM == null)
                DetailVM = new VATInvoiceLineDetailVM(VATInvoiceType);
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
            if (ShowVATInvoiceLines.Count == 0)
                return 1;
            IEnumerable<int> query = from lines in ShowVATInvoiceLines select Math.Abs(lines.Id);
            int id = query.Max();
            return id + 1;
        }

        /// <summary>
        /// 根据Id查找批次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VATInvoiceLine GetVATInvoiceLineByID(int id)
        {
            IEnumerable<VATInvoiceLine> query = from line in ShowVATInvoiceLines where line.Id == id select line;
            List<VATInvoiceLine> q = query.ToList();
            if (q.Count > 0)
            {
                return q[0];
            }
            return null;
        }

        /// <summary>
        /// 根据明细ID查找header
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public VATInvoiceLine GetLineById(int id, List<VATInvoiceLine> lines)
        {
            if (lines != null)
            {
                return lines.FirstOrDefault(t => t.Id == id);
            }

            return null;
        }

        /// <summary>
        /// 获取内部客户
        /// </summary>
        public void GetInternalCustomer()
        {
            using (
                var businessPartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalBPs = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalBPs.Insert(0, new BusinessPartner {Id = 0, ShortName = ""});
            }
        }

        public void Initialize()
        {
            //VATInvoiceLines = new TrackableCollection<VATInvoiceLine>();
            ShowVATInvoiceLines = new List<VATInvoiceLine>();
            GetInternalCustomer();
            if (ObjectId > 0)
            {
                using (
                    var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc)
                    )
                {
                    string strInfo = string.Format("it.Id={0}", ObjectId);
                    VATInvoice vatr =
                        vatInvoiceService.Select(strInfo, null,
                                                 new List<string>
                                                     {
                                                         "VATInvoiceLines.VATRate",
                                                         "VATInvoiceLines.Quota",
                                                         "VATInvoiceLines.Quota.Deliveries",
                                                         "VATInvoiceLines.Quota.WarehouseOuts",
                                                         "BusinessPartner",
                                                         "BusinessPartner1",
                                                         "VATInvoiceLines",
                                                         "VATInvoiceRequest",
                                                         "VATInvoiceLines.VATInvoiceRequestLine"
                                                     }).FirstOrDefault();
                    if (vatr != null)
                    {
                        FilterDeleted(vatr.VATInvoiceLines);

                        BPId = vatr.BPId;
                        InternalBPId = vatr.InternalBPId;
                        InvoicedDate = vatr.InvoicedDate;
                        Comment = vatr.Comment;
                        BPName = vatr.BusinessPartner.ShortName;
                        InvoiceNo = vatr.InvoiceNo;
                        VATInvoiceType = vatr.VATInvoiceType;
                        VATInvoiceRequestId = vatr.VATInvoiceRequestId;
                       
                        ShowVATInvoiceLines = vatr.VATInvoiceLines.Where(c => !c.IsDeleted).ToList();
                    }
                }
            }
        }

        protected override void Create()
        {
            using (var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc)
                )
            {
                var vatInvoice = new VATInvoice
                                     {
                                         BPId = BPId,
                                         InternalBPId = InternalBPId,
                                         Comment = Comment,
                                         InvoicedDate = InvoicedDate,
                                         InvoiceNo = InvoiceNo,
                                         VATInvoiceType = VATInvoiceType,
                                         IsDeleted = false,
                                         IsDraft = false,
                                         VATInvoiceRequestId=VATInvoiceRequestId
                                     };
                foreach (VATInvoiceLine itemLine in AddVATInvoiceLines)
                {
                    if (itemLine.QuotaId <= 0)
                    {
                        throw new Exception(ResVATInvoice.QuotaOfInvoiceLineRequired);
                    }
                    if (itemLine.VATRateId <= 0)
                    {
                        throw new Exception(ResVATInvoice.TaxRateOfInvoiceLineRequired);
                    }
                }
                vatInvoiceService.CreateDocument(CurrentUser.Id, vatInvoice, AddVATInvoiceLines);
            }
        }

        protected override void Update()
        {
            using (var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc)
                )
            {
                var vtr = new VATInvoice
                              {
                                  Id = ObjectId,
                                  BPId = BPId,
                                  InternalBPId = InternalBPId,
                                  Comment = Comment,
                                  InvoicedDate = InvoicedDate,
                                  InvoiceNo = InvoiceNo,
                                  VATInvoiceType = VATInvoiceType,
                                  VATInvoiceRequestId = VATInvoiceRequestId
                              };
                vatInvoiceService.UpdateDocument(CurrentUser.Id, vtr, AddVATInvoiceLines, UpdateVATInvoiceLines,
                                                 DeleteVATInvoiceLines);
            }
        }

        public bool IsExisted()
        {
            return false;
        }


        public override bool Validate()
        {
            if (VATInvoiceType == (int)DBEntity.EnumEntity.VATInvoiceType.Issue)
            {
                if (BPId <= 0)
                {
                    throw new Exception(ResVATInvoice.BuyerIsRequired);
                }
                if (InternalBPId <= 0)
                {
                    throw new Exception(ResVATInvoice.InvoiceBPRequired);
                }
                if (ShowVATInvoiceLines == null || ShowVATInvoiceLines.Count == 0)
                {
                    throw new Exception(ResVATInvoice.DetailRequired);
                }
            }
            else if (VATInvoiceType == (int)DBEntity.EnumEntity.VATInvoiceType.Receive) 
            {
                if (BPId <= 0)
                {
                    throw new Exception("供应商不能为空！");
                }
                if (InternalBPId <= 0)
                {
                    throw new Exception("收票方不能为空！");
                }
                if (ShowVATInvoiceLines == null || ShowVATInvoiceLines.Count == 0)
                {
                    throw new Exception(ResVATInvoice.DetailRequired);
                }
            }
            //合同对应提单全部确定实数才可以开收票
            var idlist = ShowVATInvoiceLines.Select(o => o.QuotaId).Distinct().ToList();
            var slist = idlist.Select(id => " it.Id = " + id + " ").ToList();
            var qstr = string.Join(" or ", slist);
            List<Quota> quotas = null;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quotas = quotaService.Select(qstr, null, new List<string> { "Deliveries" });
            }
            foreach (Quota q in quotas)
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
            if (VATInvoiceType == (int)DBEntity.EnumEntity.VATInvoiceType.Issue)
            {
                if (BPId <= 0)
                {
                    throw new Exception(ResVATInvoice.BuyerIsRequired);
                }
                if (InternalBPId <= 0)
                {
                    throw new Exception(ResVATInvoice.InvoiceBPRequired);
                }
            }
            else if (VATInvoiceType == (int)DBEntity.EnumEntity.VATInvoiceType.Receive)
            {
                if (BPId <= 0)
                {
                    throw new Exception("供应商不能为空！");
                }
                if (InternalBPId <= 0)
                {
                    throw new Exception("收票方不能为空！");
                }
            }
            return true;
        }


        //存在的增值税申请 赋值增值税发票
        public void BindVATInvoiceVM(VATInvoiceRequest vatInvoiceRequset)
        {
            if (vatInvoiceRequset != null)
            {
                BPId = vatInvoiceRequset.BPId;
                InternalBPId = vatInvoiceRequset.InternalBPId;
                VATInvoiceRequestId = vatInvoiceRequset.Id;
                BusinessPartner bp;
                using (
                    var businessPartnerService =
                        SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
                {
                    bp = businessPartnerService.GetById(BPId);
                }
                if (bp != null)
                {
                    BPName = bp.ShortName;
                }

                VATRate vatRate;
                using (
                    var vatRateService =
                        SvcClientManager.GetSvcClient<VATRateServiceReference.VATRateServiceClient>(SvcType.VATRateSvc))
                {
                    //it.Type=2 为销项税
                    vatRate = vatRateService.Select("it.IsDeleted=false and it.Type=2 order by it.Created", null, null).FirstOrDefault();
                }


                var vatInvoiceLines = new List<VATInvoiceLine>();
                foreach (VATInvoiceRequestLine item in vatInvoiceRequset.VATInvoiceRequestLines)
                {
                    var line = new VATInvoiceLine();
                    int id = GetLineId();
                    line.Id = -id;
                    line.QuotaId = item.QuotaId;
                    line.VATInvoiceQuantity = item.RequestQuantity - item.VATInvoicedQuantity;
                    line.UnOpenedQuantity = item.RequestQuantity - item.VATInvoicedQuantity;
                    line.VATAmount = item.RequestAmount;
                    line.VATPrice = item.RequestPrice;
                    line.VATInvoiceRequestLineId = item.Id;
                    if (vatRate != null)
                    {
                        line.VATRateId = vatRate.Id;
                        line.VATRate = vatRate;
                    }
                    if (DetailVM == null)
                    {
                        DetailVM = new VATInvoiceLineDetailVM(VATInvoiceType);
                    }

                    using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                    {
                        Quota qt = quotaService.GetById(item.QuotaId);
                        if (qt != null)
                        {
                            line.Quota = qt;
                            line.Quota.VATStatus = qt.VATStatus;
                        }
                    }
                    vatInvoiceLines.Add(line);
                    if (ShowVATInvoiceLines == null)
                    {
                        ShowVATInvoiceLines = new List<VATInvoiceLine>();
                    }
                    ShowVATInvoiceLines.Add(line);
                    if (AddVATInvoiceLines == null)
                    {
                        AddVATInvoiceLines = new List<VATInvoiceLine>();
                    }
                    AddVATInvoiceLines.Add(line);
                }
            }
        }

        #endregion

        #region 维护列表

        /// <summary>
        /// 新增批次
        /// </summary>
        /// <param name="line"> </param>
        public void AddLine(VATInvoiceLine line)
        {
            if (ShowVATInvoiceLines == null)
                ShowVATInvoiceLines = new List<VATInvoiceLine>();
            int no = GetLineId();
            line.Id = -no;
            ShowVATInvoiceLines.Add(line);
            if (AddVATInvoiceLines == null)
            {
                AddVATInvoiceLines = new List<VATInvoiceLine>();
            }
            AddVATInvoiceLines.Add(line);
        }

        /// <summary>
        /// 修改批次
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLine(int id)
        {
            VATInvoiceLine line = GetLineById(id, ShowVATInvoiceLines);
            if (line != null)
            {
                VATInvoiceLine addLine = GetLineById(id, AddVATInvoiceLines);
                if (addLine == null)
                {
                    if (UpdateVATInvoiceLines == null)
                    {
                        UpdateVATInvoiceLines = new List<VATInvoiceLine> {line};
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
            VATInvoiceLine line = GetLineById(id, ShowVATInvoiceLines);
            if (line != null)
            {
                ShowVATInvoiceLines.Remove(line);
                VATInvoiceLine addLine = GetLineById(id, AddVATInvoiceLines);
                if (addLine != null)
                {
                    AddVATInvoiceLines.Remove(addLine);
                }
                else
                {
                    VATInvoiceLine updateLine = GetLineById(id, UpdateVATInvoiceLines);
                    if (updateLine != null)
                    {
                        UpdateVATInvoiceLines.Remove(updateLine);
                    }
                    if (DeleteVATInvoiceLines == null)
                    {
                        DeleteVATInvoiceLines = new List<VATInvoiceLine>();
                    }
                    DeleteVATInvoiceLines.Add(line);
                }
            }
        }

        #endregion
    }
}