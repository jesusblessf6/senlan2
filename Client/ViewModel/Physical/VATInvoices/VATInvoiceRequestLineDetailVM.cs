using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.DeliveryServiceReference;
using Client.PricingServiceReference;
using Client.QuotaServiceReference;
using Client.VATInvoiceServiceReference;
using Client.VATInvoicedRequestLineServiceReference;
using Client.WarehouseOutServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceRequestLineDetailVM : BaseVM
    {
        #region Member

        private List<VATInvoiceRequestLine> _addVATInvoiceRequestLines;
        private string _comment;
        private VATInvoiceRequestLine _currentLine;
        private List<VATInvoiceRequestLine> _deleteVATInvoiceRequestLines;
        private bool _isDeleted;
        private bool _isDraft;
        private int _quotaId;
        private string _quotaNo;
        private decimal? _requestAmount;
        private decimal? _requestPrice;
        private decimal? _requestQuantity;
        private decimal? _vatInvoicedQuantity;
        private List<VATInvoiceRequestLine> _showVATInvoiceRequestLines;
        private decimal? _unOpenedQuantity;
        private List<VATInvoiceRequestLine> _updateVATInvoiceRequestLines;
        private int _vatInvoiceRequestId;
        private List<Quota> _QuotaList;
        private bool? _IsVatRequestFinished = true;
        #endregion

        #region Property
        public bool? IsVatRequestFinished
        {
            get { return _IsVatRequestFinished; }
            set {
                if (_IsVatRequestFinished != value)
                {
                    _IsVatRequestFinished = value;
                    Notify("IsVatRequestFinished");
                }
            }
        }

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

        public List<VATInvoiceRequestLine> ShowVATInvoiceRequestLines
        {
            get { return _showVATInvoiceRequestLines; }
            set
            {
                if (_showVATInvoiceRequestLines != value)
                {
                    _showVATInvoiceRequestLines = value;
                    Notify("_ShowVATInvoiceRequestLines");
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

        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                _quotaId = value;
                Notify("QuotaId");
            }
        }

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                _quotaNo = value;
                Notify("QuotaNo");
            }
        }

        public int VATInvoiceRequestId
        {
            get { return _vatInvoiceRequestId; }
            set
            {
                _vatInvoiceRequestId = value;
                Notify("VATInvoiceRequestId");
            }
        }



        public decimal? VATInvoicedQuantity
        {
            get { return Math.Round(_vatInvoicedQuantity == null ? 0 : (decimal)_vatInvoicedQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                _vatInvoicedQuantity = value;
                Notify("VATInvoicedQuantity");
            }
        }

        public decimal? RequestQuantity
        {
            get { return Math.Round(_requestQuantity == null ? 0 : (decimal)_requestQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                _requestQuantity = value;
                Notify("RequestQuantity");
            }
        }

        public decimal? UnOpenedQuantity
        {
            get { return Math.Round(_unOpenedQuantity == null ? 0 : (decimal)_unOpenedQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                _unOpenedQuantity = value;
                Notify("UnOpenedQuantity");
            }
        }

        public decimal? RequestAmount
        {
            get { return Math.Round(_requestAmount == null ? 0 : (decimal)_requestAmount, RoundRules.AMOUNT, MidpointRounding.AwayFromZero); }
            set
            {
                _requestAmount = value;
                Notify("RequestAmount");
            }
        }

        public decimal? RequestPrice
        {
            get { return Math.Round(_requestPrice == null ? 0 : (decimal)_requestPrice, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                _requestPrice = value;
                Notify("RequestPrice");
            }
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                Notify("IsDeleted");
            }
        }

        public bool IsDraft
        {
            get { return _isDraft; }
            set
            {
                _isDraft = value;
                Notify("IsDraft");
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

        public VATInvoiceRequestLine CurrentLine
        {
            get { return _currentLine; }
            set
            {
                if (_currentLine != value)
                {
                    _currentLine = value;
                    Notify("CurrentLine");
                }
            }
        }

        #endregion

        #region Constructor

        public VATInvoiceRequestLineDetailVM()
        {
            ObjectId = 0;
            PropertyChanged += VATInvoiceLineDetailVMPropertyChanged;
        }

        public VATInvoiceRequestLineDetailVM(int id, List<VATInvoiceRequestLine> lines,
                                             List<VATInvoiceRequestLine> addedLines,
                                             List<VATInvoiceRequestLine> updatedLines, List<Quota> quotaList)
        {
            ObjectId = id;
            ShowVATInvoiceRequestLines = lines;
            AddVATInvoiceRequestLines = addedLines;
            UpdateVATInvoiceRequestLines = updatedLines;
            QuotaList = quotaList;
            CurrentLine = GetLineFromList(id, lines);
            PropertyChanged += VATInvoiceLineDetailVMPropertyChanged;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (CurrentLine.Id != 0)
            {
                ObjectId = CurrentLine.Id;
            }
            _quotaId = CurrentLine.QuotaId;
            QuotaNo = CurrentLine.Quota.QuotaNo;
            IsVatRequestFinished = CurrentLine.Quota.IsVatRequestFinished ?? false;
            _requestQuantity = CurrentLine.RequestQuantity;
            VATInvoicedQuantity = CurrentLine.VATInvoicedQuantity;
            RequestAmount = CurrentLine.RequestAmount;
            _requestPrice = CurrentLine.RequestPrice;
            UnOpenedQuantity = CurrentLine.UnOpenedQuantity;
            VATInvoiceRequestId = CurrentLine.VATInvoiceRequestId;
            Comment = CurrentLine.Comment;
        }

        protected void VATInvoiceLineDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "QuotaId")
            {
                //更改批次更新未开数量 UnOpenedQuantity 
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    string strInfo = string.Format("it.Id={0}", QuotaId);
                    Quota selectQuota =
                        quotaService.Select(strInfo, null, new List<string> {"Deliveries", "WarehouseOuts"}).
                            FirstOrDefault();
                    if (selectQuota != null)
                    {
                        FilterDeleted(selectQuota.Deliveries);
                        FilterDeleted(selectQuota.WarehouseOuts);
                        UnOpenedQuantity = selectQuota.VerifiedQuantity-(selectQuota.VATInvoicedQuantity ?? 0);
                    }
                    decimal amt = DefaultAmountCalculation();
                    RequestAmount = amt;
                    using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                    {
                        RequestPrice = pricingService.GetAvgPricing(QuotaId);
                    }
                }
            }
            if (e.PropertyName == "RequestQuantity" || e.PropertyName == "RequestPrice")
            {
                decimal amt = AmountCalculation();
                RequestAmount = amt;
            }
        }

        public override bool Validate()
        {
            if (QuotaId <= 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var q = quotaService.SelectById(new List<string> { "Deliveries" }, QuotaId);
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

        /// <summary>
        /// 从页面数据生成批次对象，供保存用
        /// </summary>
        /// <returns></returns>
        private VATInvoiceRequestLine SetLineByPage()
        {
            var currentLine = new VATInvoiceRequestLine();
            if (ObjectId == 0)
            {
                int id = GetVATId();
                currentLine.Id = id;
                currentLine.ApproveStatus = 0;
            }
            else
            {
                currentLine.Id = ObjectId;
                using (
                    var lineService =
                        SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(
                            SvcType.VATInvoiceRequestLineSvc))
                {
                    VATInvoiceRequestLine line = lineService.GetById(ObjectId);
                    if (line != null)
                    {
                        currentLine.ApproveStatus = line.ApproveStatus;
                    }
                }
            }
            currentLine.QuotaId = QuotaId;
            Quota quota;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quota = quotaService.FetchById(QuotaId, new List<string> {"Deliveries", "WarehouseOuts"});
                if (quota != null)
                {
                    FilterDeleted(quota.Deliveries);
                    FilterDeleted(quota.WarehouseOuts);
                    quota.IsVatRequestFinished = IsVatRequestFinished;
                }
            }

            if (QuotaList.Count > 0)
            {
                List<Quota> quotaList = QuotaList.Where(c => c.Id == QuotaId).ToList();
                if (quotaList.Count > 0)
                {
                    Quota oldQuota = quotaList[0];
                    QuotaList.Remove(oldQuota);
                }
            }
            QuotaList.Add(quota);

            currentLine.Quota = quota;
            currentLine.RequestQuantity = RequestQuantity;
            currentLine.RequestAmount = RequestAmount;
            currentLine.RequestPrice = RequestPrice;
            currentLine.Comment = Comment;
            currentLine.UnOpenedQuantity = UnOpenedQuantity;
            currentLine.VATInvoiceRequestId = VATInvoiceRequestId;
            return currentLine;
        }

        public int GetVATId()
        {
            if (ShowVATInvoiceRequestLines.Count == 0)
                return -1;
            IEnumerable<int> query = from quota in ShowVATInvoiceRequestLines select Math.Abs(quota.Id);
            int no = query.Max();
            return -(no + 1);
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void Create()
        {
            if (AddVATInvoiceRequestLines == null)
            {
                AddVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
            }
            if (ShowVATInvoiceRequestLines == null)
            {
                ShowVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
            }
            if(QuotaList == null)
            {
                QuotaList = new List<Quota>();
            }
            VATInvoiceRequestLine currentLine = SetLineByPage();
            //有相同批次的明细或者已经开票完成的明细过滤
            if (ShowVATInvoiceRequestLines.Any(item => currentLine.QuotaId == item.QuotaId))
            {
                return;
            }
            AddVATInvoiceRequestLines.Add(currentLine);
            ShowVATInvoiceRequestLines.Add(currentLine);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected override void Update()
        {
            if(QuotaList == null)
            {
                QuotaList = new List<Quota>();
            }
            VATInvoiceRequestLine currentLine = SetLineByPage();
            //非相同批次不能被修改
            VATInvoiceRequestLine oldLine = GetLineFromList(ObjectId, ShowVATInvoiceRequestLines);
            if (oldLine.QuotaId != currentLine.QuotaId)
            {
                return;
            }
            if (ObjectId > 0)
            {
                //编辑已添加过的
                if (ContainsLine(ObjectId, UpdateVATInvoiceRequestLines))
                {
                    VATInvoiceRequestLine oldULine = GetLineFromList(ObjectId, UpdateVATInvoiceRequestLines);
                    if (oldULine != null)
                    {
                        UpdateVATInvoiceRequestLines.Remove(oldULine);
                    }
                }
                if (UpdateVATInvoiceRequestLines == null)
                    UpdateVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
                UpdateVATInvoiceRequestLines.Add(currentLine);
            }
            else if (ObjectId < 0)
            {
                //新增的重新编辑
                if (ContainsLine(ObjectId, AddVATInvoiceRequestLines))
                {
                    VATInvoiceRequestLine oldALine = GetLineFromList(ObjectId, AddVATInvoiceRequestLines);
                    if (oldALine != null)
                    {
                        AddVATInvoiceRequestLines.Remove(oldALine);
                    }
                }
                if (AddVATInvoiceRequestLines == null)
                    AddVATInvoiceRequestLines = new List<VATInvoiceRequestLine>();
                AddVATInvoiceRequestLines.Add(currentLine);
            }
            //维护合并的列表
            VATInvoiceRequestLine oldLines = GetLineFromList(ObjectId, ShowVATInvoiceRequestLines);
            if (oldLines != null)
            {
                ShowVATInvoiceRequestLines.Remove(oldLines);
            }
            ShowVATInvoiceRequestLines.Add(currentLine);

        }

        /// <summary>
        /// 批次项下的转手的发货单确认数量
        /// </summary>
        /// <param name="deliverys"></param>
        /// <returns></returns>
        public decimal DeliveryQty(TrackableCollection<Delivery> deliverys)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                decimal dlvQty = 0;
                foreach (Delivery dlv in deliverys)
                {
                    const string strInfo = "it.Id = @p1 ";
                    var parameters = new List<object> {dlv.Id};
                    Delivery delivery =
                        deliveryService.Select(strInfo, parameters, new List<string> {"DeliveryLines"}).FirstOrDefault();
                    if (delivery != null)
                    {
                        FilterDeleted(delivery.DeliveryLines);
                        foreach (DeliveryLine dlvLine in delivery.DeliveryLines)
                        {
                            if (dlvLine.IsVerified)
                            {
                                dlvQty += (dlvLine.VerifiedWeight == null
                                               ? 0
                                               : Convert.ToDecimal(dlvLine.VerifiedWeight));
                            }
                        }
                    }
                }
                return dlvQty;
            }
        }

        /// <summary>
        /// 批次对应的出库的确认数量
        /// </summary>
        /// <param name="warehouseOuts"></param>
        /// <returns></returns>
        public decimal WarehouseOutQty(TrackableCollection<WarehouseOut> warehouseOuts)
        {
            using (
                var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                decimal outQty = 0;
                foreach (WarehouseOut whs in warehouseOuts)
                {
                    const string strInfo = "it.Id = @p1 ";
                    var parameters = new List<object> {whs.Id};
                    WarehouseOut wareHouseOut =
                        warehouseOutService.Select(strInfo, parameters, new List<string> {"WarehouseOutLines"}).
                            FirstOrDefault();
                    if (wareHouseOut != null)
                    {
                       FilterDeleted(wareHouseOut.WarehouseOutLines);
                        foreach (WarehouseOutLine whsLine in wareHouseOut.WarehouseOutLines)
                        {
                            if (whsLine.IsVerified != null && (bool) whsLine.IsVerified)
                            {
                                outQty += (whsLine.VerifiedQuantity == null
                                               ? 0
                                               : Convert.ToDecimal(whsLine.VerifiedQuantity));
                            }
                        }
                    }
                }
                return outQty;
            }
        }

        /// <summary>
        /// 已开数量(已开增值税发票批次数量)
        /// </summary>
        /// <param name="quotaId"> </param>
        /// <returns></returns>
        public decimal OpenQty(int quotaId)
        {
            using (var vatInvoiceService = SvcClientManager.GetSvcClient<VATInvoiceServiceClient>(SvcType.VATInvoiceSvc)
                )
            {
                decimal openQty = vatInvoiceService.OpenQty(quotaId, CurrentUser.Id);
                return openQty;
            }
        }

        #endregion

        #region 维护列表

        /// <summary>
        /// 判断列表是否包含指定批次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lines"> </param>
        /// <returns></returns>
        private bool ContainsLine(int id, IEnumerable<VATInvoiceRequestLine> lines)
        {
            if (lines != null)
            {
                return lines.Any(line => line.Id == id);
            }
            return false;
        }

        /// <summary>
        /// 根据列表和id返回批次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lines"> </param>
        /// <returns></returns>
        private VATInvoiceRequestLine GetLineFromList(int id, IEnumerable<VATInvoiceRequestLine> lines)
        {
            if (lines != null)
            {
                return lines.FirstOrDefault(line => line.Id == id);
            }
            return null;
        }

        /// <summary>
        ///申请金额计算
        /// </summary>
        /// <returns></returns>
        public decimal AmountCalculation()
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                decimal amt = RequestPrice ?? 0;
                return amt*(RequestQuantity == null ? 0 : (decimal) RequestQuantity);
            }
        }

        /// <summary>
        /// 默认情况下申请数量为未开数量
        /// </summary>
        /// <returns></returns>
        public decimal DefaultAmountCalculation()
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                decimal amt = pricingService.GetAvgPricing(QuotaId);
                RequestQuantity = UnOpenedQuantity;
                return amt*(UnOpenedQuantity == null ? 0 : (decimal) UnOpenedQuantity);
            }
        }

        #endregion
    }
}