using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.DeliveryServiceReference;
using Client.PricingServiceReference;
using Client.QuotaServiceReference;
using Client.VATInvoiceServiceReference;
using Client.VATRateServiceReference;
using Client.View.Physical.VATInvoices;
using Client.WarehouseOutServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.VATInvoices
{
    public class VATInvoiceLineDetailVM : BaseVM
    {
        #region Member

        private List<VATInvoiceLine> _addVATInvoiceLines;
        private string _comment;
        private VATInvoiceLine _currentLine;
        private List<VATInvoiceLine> _deleteVATInvoiceLines;
        private bool _isDeleted;
        private bool _isDraft;
        private int _quotaId;
        private string _quotaNo;
        private decimal? _rateValue;
        private List<VATInvoiceLine> _showVATInvoiceLines;
        private decimal? _unOpenedQuantity;
        private List<VATInvoiceLine> _updateVATInvoiceLines;
        private decimal? _vatAmount;
        private int _vatInvoiceId;
        private decimal? _vatInvoiceQuantity;
        private decimal? _vatInvoiceRequestQuantity;
        private int? _vatInvoiceRequestLineId;
        private decimal? _vatPrice;
        private int _vatRateId;
        private List<VATRate> _vatRates;
        private int? _vatStatus;

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

        public int VATInvoiceId
        {
            get { return _vatInvoiceId; }
            set
            {
                _vatInvoiceId = value;
                Notify("VATInvoiceId");
            }
        }

        public int VATRateId
        {
            get { return _vatRateId; }
            set
            {
                _vatRateId = value;
                Notify("VATRateId");
            }
        }

        public int? VATStatus
        {
            get { return _vatStatus; }
            set
            {
                _vatStatus = value;
                Notify("VATStatus");
            }
        }

        public List<VATRate> VATRates
        {
            get { return _vatRates; }
            set
            {
                _vatRates = value;
                Notify("VATRates");
            }
        }

        public int? VATInvoiceRequestLineId
        {
            get { return _vatInvoiceRequestLineId; }
            set
            {
                _vatInvoiceRequestLineId = value;
                Notify("VATInvoiceRequestLineId");
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

        public decimal? VATInvoiceQuantity
        {
            get { return Math.Round(_vatInvoiceQuantity == null ? 0 : (decimal)_vatInvoiceQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                _vatInvoiceQuantity = value;
                Notify("VATInvoiceQuantity");
            }
        }

        public decimal? VATInvoiceRequestQuantity
        {
            get { return Math.Round(_vatInvoiceRequestQuantity == null ? 0 : (decimal)_vatInvoiceRequestQuantity, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }
            set
            {
                _vatInvoiceRequestQuantity = value;
                Notify("VATInvoiceRequestQuantity");
            }
        }



        public decimal? VATAmount
        {
            get { return Math.Round(_vatAmount == null ? 0 : (decimal)_vatAmount, RoundRules.AMOUNT, MidpointRounding.AwayFromZero); }
            set
            {
                _vatAmount = value;
                Notify("VATAmount");
            }
        }

        public decimal? VATPrice
        {
            get { return Math.Round(_vatPrice == null ? 0 : (decimal)_vatPrice, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                _vatPrice = value;
                Notify("VATPrice");
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

        public VATInvoiceLine CurrentLine
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

        public decimal? RateValue
        {
            get { return Math.Round(_rateValue == null ? 0 : (decimal)_rateValue, RoundRules.PRICE, MidpointRounding.AwayFromZero); }
            set
            {
                _rateValue = value;
                Notify("RateValue");
            }
        }

        #endregion

        #region Constructor

        public VATInvoiceLineDetailVM(int vatInvoiceType)
        {
            ObjectId = 0;
            LoadVATRate(vatInvoiceType);
            PropertyChanged += VATInvoiceLineDetailVMPropertyChanged;
        }

        public VATInvoiceLineDetailVM(int id, List<VATInvoiceLine> lines, List<VATInvoiceLine> addedLines,
                                      List<VATInvoiceLine> updatedLines, int vatInvoiceType)
        {
            ObjectId = id;
            ShowVATInvoiceLines = lines;
            AddVATInvoiceLines = addedLines;
            UpdateVATInvoiceLines = updatedLines;
            CurrentLine = GetLineFromList(id, lines);
            LoadVATRate(vatInvoiceType);
            PropertyChanged += VATInvoiceLineDetailVMPropertyChanged;
            Initialize();
        }

        #endregion

        #region Method

        /// <summary>
        /// 获取增值税率
        /// </summary>
        public void LoadVATRate(int vatInvoiceType)
        {
            using (var vatRateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                if (vatInvoiceType == (int)VATInvoiceType.Issue)
                {
                    string strInfo = string.Format("it.Type={0}", (int)VATType.Output);
                    VATRates = vatRateService.Select(strInfo, null, null);
                }
                else if (vatInvoiceType == (int)VATInvoiceType.Receive)
                {
                    string strInfo = string.Format("it.Type={0}", (int)VATType.Input);
                    VATRates = vatRateService.Select(strInfo, null, null);
                }
                if(VATRates !=  null && VATRates.Count > 0)
                {
                    VATRateId = VATRates[0].Id;
                }
            }
        }

        public void Initialize()
        {
            if (CurrentLine.Id != 0)
            {
                ObjectId = CurrentLine.Id;
            }
            
            QuotaNo = CurrentLine.Quota.QuotaNo;
            _quotaId = CurrentLine.QuotaId;
            _vatInvoiceQuantity = CurrentLine.VATInvoiceQuantity;
            VATAmount = CurrentLine.VATAmount;
            _vatPrice = CurrentLine.VATPrice;
            _vatRateId = CurrentLine.VATRateId;
            VATInvoiceId = CurrentLine.VATInvoiceId;
            UnOpenedQuantity = CurrentLine.UnOpenedQuantity;
            VATInvoiceRequestLineId = CurrentLine.VATInvoiceRequestLineId;
            if (CurrentLine.Quota.VATStatus != 1)
            {
                VATStatus = null;
            }
            else
            {
                VATStatus = (int)QuotaVATStatus.Complete;
            }
            decimal rate = RateCalculation();
            //税额= 开票金额（含税） * 税率 / (1 + 税率)
            RateValue = VATAmount * (rate / (1 + rate));
        }

        private Quota GetQuotaById(int quotaId)
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                string strInfo = string.Format("it.Id={0}", QuotaId);
                Quota selectQuota =
                    quotaService.Select(strInfo, null, new List<string> { "Deliveries", "WarehouseOuts" }).
                        FirstOrDefault();
                if (selectQuota != null)
                {
                    FilterDeleted(selectQuota.Deliveries);
                    FilterDeleted(selectQuota.WarehouseOuts);
                }
                return selectQuota;
            }
        }

        protected void VATInvoiceLineDetailVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "QuotaId")
            {
                //更改批次更新未开数量 UnOpenedQuantity 
                Quota selectQuota = GetQuotaById(QuotaId);
                UnOpenedQuantity = selectQuota.VerifiedQuantity - selectQuota.VATInvoicedQuantity;
                //using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                //{
                //    string strInfo = string.Format("it.Id={0}", QuotaId);
                //    Quota selectQuota =
                //        quotaService.Select(strInfo, null, new List<string> { "Deliveries", "WarehouseOuts" }).
                //            FirstOrDefault();
                //    if (selectQuota != null)
                //    {
                //        FilterDeleted(selectQuota.Deliveries);
                //        FilterDeleted(selectQuota.WarehouseOuts);
                        
                //        UnOpenedQuantity = selectQuota.VerifiedQuantity - selectQuota.VATInvoicedQuantity;
                //    }
                //}
                decimal amt = DefaultAmountCalculation();
                VATAmount = amt;
                decimal rate = RateCalculation();
                //税额= 开票金额（含税） * 税率 / (1 + 税率)
                RateValue = VATAmount * (rate / (1 + rate));
                using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                {
                    VATPrice = pricingService.GetAvgPricing(QuotaId);
                }
            }

            if (e.PropertyName == "VATRateId" || e.PropertyName == "VATInvoiceQuantity" || e.PropertyName == "VATPrice")
            {
                decimal amt = AmountCalculation();
                VATAmount = amt;
                decimal rate = RateCalculation();
                //税额= 开票金额（含税） * 税率 / (1 + 税率)
                RateValue = VATAmount * (rate / (1 + rate));

                if (e.PropertyName == "VATInvoiceQuantity")
                {
                    
                    if (UnOpenedQuantity.HasValue && VATInvoiceQuantity.HasValue)
                    {
                        if (VATInvoiceQuantity.Value == UnOpenedQuantity.Value)
                        {
                            VATStatus = (int)DBEntity.EnumEntity.VATStatus.Complete;
                        }
                        else
                        {
                            Quota selectQuota = GetQuotaById(QuotaId);
                            if (selectQuota.VATInvoicedQuantity + VATInvoiceQuantity > 0)
                            {
                                VATStatus = (int)DBEntity.EnumEntity.VATStatus.Partial;
                            }
                            else
                            {
                                VATStatus = (int)DBEntity.EnumEntity.VATStatus.NotAtAll;
                            }
                        }
                    }
                }
            }
        }

        public override bool Validate()
        {
            if (QuotaId <= 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            if (VATRateId <= 0)
            {
                throw new Exception(ResVATInvoice.TaxRateRequired);
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
        private VATInvoiceLine SetLineByPage()
        {
            var currentLine = new VATInvoiceLine();
            if (ObjectId == 0)
            {
                int id = GetVATId();
                currentLine.Id = id;
            }
            else
            {
                currentLine.Id = ObjectId;
            }
            currentLine.QuotaId = QuotaId;
            Quota quota;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quota = quotaService.FetchById(QuotaId, new List<string> { "Deliveries", "WarehouseOuts" });
                if (quota != null)
                {
                    FilterDeleted(quota.Deliveries);
                    FilterDeleted(quota.WarehouseOuts);
                }
            }
            currentLine.Quota = quota;
            VATRate vatRate;
            using (var vatRateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                vatRate = vatRateService.FetchById(VATRateId, null);
            }
            currentLine.VATRate = vatRate;
            currentLine.UnOpenedQuantity = UnOpenedQuantity;
            currentLine.VATInvoiceQuantity = VATInvoiceQuantity;
            currentLine.VATAmount = VATAmount;
            currentLine.VATPrice = VATPrice;
            currentLine.VATRateId = VATRateId;
            currentLine.VATInvoiceId = VATInvoiceId;
            currentLine.VATInvoiceRequestLineId = VATInvoiceRequestLineId;
            if (VATStatus == null || VATStatus <= 0)
            {
                VATStatus = (int)QuotaVATStatus.Partial;
            }
            currentLine.Quota.VATStatus = VATStatus;

            return currentLine;
        }

        private int GetVATId()
        {
            if (ShowVATInvoiceLines.Count == 0)
                return -1;
            IEnumerable<int> query = from quota in ShowVATInvoiceLines select Math.Abs(quota.Id);
            int no = query.Max();
            return -(no + 1);
        }


        /// <summary>
        /// 新增
        /// </summary>
        protected override void Create()
        {
            if (AddVATInvoiceLines == null)
            {
                AddVATInvoiceLines = new List<VATInvoiceLine>();
            }
            if (ShowVATInvoiceLines == null)
            {
                ShowVATInvoiceLines = new List<VATInvoiceLine>();
            }
            VATInvoiceLine currentLine = SetLineByPage();
            //有相同批次的明细或者已经开票完成的明细过滤
            if (ShowVATInvoiceLines.Any(item => currentLine.QuotaId == item.QuotaId))
            {
                return;
            }
            AddVATInvoiceLines.Add(currentLine);
            ShowVATInvoiceLines.Add(currentLine);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected override void Update()
        {
            VATInvoiceLine currentLine = SetLineByPage();
            //非相同批次不能被修改
            VATInvoiceLine oldLine = GetLineFromList(ObjectId, ShowVATInvoiceLines);
            if (oldLine.QuotaId != currentLine.QuotaId)
            {
                return;
            }
            if (ObjectId > 0)
            {
                //编辑已添加过的
                if (ContainsLine(ObjectId, UpdateVATInvoiceLines))
                {
                    VATInvoiceLine oldULine = GetLineFromList(ObjectId, UpdateVATInvoiceLines);
                    if (oldULine != null)
                    {
                        UpdateVATInvoiceLines.Remove(oldULine);
                    }
                }
                if (UpdateVATInvoiceLines == null)
                    UpdateVATInvoiceLines = new List<VATInvoiceLine>();
                UpdateVATInvoiceLines.Add(currentLine);
            }
            else if (ObjectId < 0)
            {
                //新增的重新编辑
                if (ContainsLine(ObjectId, AddVATInvoiceLines))
                {
                    VATInvoiceLine oldALine = GetLineFromList(ObjectId, AddVATInvoiceLines);
                    if (oldALine != null)
                    {
                        AddVATInvoiceLines.Remove(oldALine);
                    }
                }
                if (AddVATInvoiceLines == null)
                    AddVATInvoiceLines = new List<VATInvoiceLine>();
                AddVATInvoiceLines.Add(currentLine);
            }
            //维护合并的列表
            VATInvoiceLine oldLines = GetLineFromList(ObjectId, ShowVATInvoiceLines);
            if (oldLines != null)
            {
                ShowVATInvoiceLines.Remove(oldLines);
            }
            ShowVATInvoiceLines.Add(currentLine);
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
                    var parameters = new List<object> { dlv.Id };
                    Delivery delivery =
                        deliveryService.Select(strInfo, parameters, new List<string> { "DeliveryLines" }).FirstOrDefault();
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
                    var parameters = new List<object> { whs.Id };
                    WarehouseOut wareHouseOut =
                        warehouseOutService.Select(strInfo, parameters, new List<string> { "WarehouseOutLines" }).
                            FirstOrDefault();
                    if (wareHouseOut != null)
                    {
                        FilterDeleted(wareHouseOut.WarehouseOutLines);
                        foreach (WarehouseOutLine whsLine in wareHouseOut.WarehouseOutLines)
                        {
                            if (whsLine.IsVerified != null && (bool)whsLine.IsVerified)
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
        /// 已开数量(已开增值税发票数量)
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

        /// <summary>
        ///开票金额（含税）计算 
        /// </summary>
        /// <returns></returns>
        public decimal AmountCalculation()
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                //decimal amt = pricingService.GetAvgPricing(QuotaId);
                decimal amt = VATPrice ?? 0;
                return amt * (VATInvoiceQuantity == null ? 0 : (decimal)VATInvoiceQuantity);
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
                VATInvoiceQuantity = UnOpenedQuantity;
                return amt * (UnOpenedQuantity == null ? 0 : (decimal)UnOpenedQuantity);
            }
        }

        /// <summary>
        /// 税率 计算
        /// </summary>
        /// <returns></returns>
        public decimal RateCalculation()
        {
            using (var vatRateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                VATRate rate = vatRateService.GetById(VATRateId);
                if (rate != null)
                {
                    return (rate.RateValue == null ? 0 : (decimal)rate.RateValue);
                }
                return 0;
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
        private bool ContainsLine(int id, IEnumerable<VATInvoiceLine> lines)
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
        private VATInvoiceLine GetLineFromList(int id, IEnumerable<VATInvoiceLine> lines)
        {
            if (lines != null)
            {
                return lines.FirstOrDefault(line => line.Id == id);
            }
            return null;
        }

        #endregion
    }
}