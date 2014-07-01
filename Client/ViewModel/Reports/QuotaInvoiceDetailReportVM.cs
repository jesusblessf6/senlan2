using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.QuotaServiceReference;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Reports
{
    public class QuotaInvoiceDetailReportVM : BaseVM
    {
        #region Property

        private int _bpId;
        private string _bpName;
        private List<Commodity> _commodities;
        private int _commodityId;
        private DateTime? _endDate;
        private int _internalCustomerId;
        private List<BusinessPartner> _internalCustomers;
        private List<object> _parameters;
        private string _queryStr;
        private List<Quota> _quotas;
        private DateTime? _startDate = DateTime.Today.AddMonths(-1);
        private int _vatInvoiceTypeId;
        private List<EnumItem> _vatInvoiceTypes;
        private int _selectedVATStatus;
        private Dictionary<string, int> _vatStatus;
        private string _verQtyCount;
        private string _amount;

        public int SelectedVATStatus
        {
            get { return _selectedVATStatus; }
            set
            {
                if (_selectedVATStatus != value)
                {
                    _selectedVATStatus = value;
                    Notify("SelectedVATStatus");
                }
            }
        }

        public Dictionary<string, int> VATStatus
        {
            get { return _vatStatus; }
            set
            {
                if (_vatStatus != value)
                {
                    _vatStatus = value;
                    Notify("VATStatus");
                }
            }
        }

        //public int From { get; set; }
        //public int To { get; set; }
        //public int Count { get; set; }
        public ListCollectionView QuotasView { get; set; }


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

        public int InternalCustomerId
        {
            get { return _internalCustomerId; }
            set
            {
                if (_internalCustomerId != value)
                {
                    _internalCustomerId = value;
                    Notify("InternalCustomerId");
                }
            }
        }

        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                _internalCustomers = value;
                Notify("InternalCustomers");
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

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
            }
        }

        public int VATInvoiceTypeId
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

        public List<EnumItem> VATInvoiceTypes
        {
            get { return _vatInvoiceTypes; }
            set
            {
                _vatInvoiceTypes = value;
                Notify("VATInvoiceTypes");
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

        public List<Quota> Quotas
        {
            get { return _quotas; }
            set
            {
                _quotas = value;
                Notify("Quotas");
            }
        }

        public string VerQtyCount
        {
            get { return _verQtyCount; }
            set
            {
                _verQtyCount = value;
                Notify("VerQtyCount");
            }
        }

        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                Notify("Amount");
            }
        }
        #endregion

        #region Contructor

        public QuotaInvoiceDetailReportVM()
        {
            Initialize();
        }

        #endregion

        #region Method

        /// <summary>
        /// Init the search conditions
        /// </summary>
        private void Initialize()
        {
            _bpId = 0;
            _bpName = string.Empty;

            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }
            _internalCustomerId = 0;

            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }
            _commodityId = 0;

            _vatInvoiceTypes = EnumHelper.GetEnumList<VATInvoiceType>();
            _vatInvoiceTypes.Insert(0, new EnumItem());
            _vatInvoiceTypeId = 0;

            //_startDate = null;
            //_endDate = null;

            LoadVATStatus();
        }

        /// <summary>
        /// Reset search conditions
        /// </summary>
        public void Reset()
        {
            BPId = 0;
            BPName = string.Empty;
            InternalCustomerId = 0;
            CommodityId = 0;
            VATInvoiceTypeId = 0;
            StartDate = null;
            EndDate = null;
        }

        /// <summary>
        /// Query for the quotas according to the conditions
        /// </summary>
        public void Load()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                //List<Quota> quotas = quotaService.SelectByRangeWithOrder(_queryStr, _parameters,
                //                                                         new SortCol
                //                                                             {ByDescending = false, ColName = "Id"},
                //                                                         From, To,
                //                                                         new List<string>
                //                                                             {
                //                                                                 "Contract",
                //                                                                 "Commodity",
                //                                                                 "Brand",
                //                                                                 "Pricings",
                //                                                                 "VATInvoiceLines",
                //                                                                 "Contract.BusinessPartner"
                //                                                             });

                BuildQueryStrAndParams();

                List<SortCol> sortCols = new List<SortCol> { 
                                                    new SortCol { ByDescending = false, ColName = "Contract.BusinessPartner.ShortName" },
                                                    new SortCol { ByDescending = false, ColName = "Id" }
                                                    };

                List<Quota> quotas = quotaService.SelectWithMultiOrder(_queryStr, _parameters,
                                            sortCols,
                                            new List<string>
                                                {
                                                    "Contract",
                                                    "Commodity",
                                                    "Brand",
                                                    "Pricings",
                                                    "VATInvoiceLines",
                                                    "Contract.BusinessPartner"
                                                });
                decimal? verQtyCount = quotas.Sum(o => o.VerifiedQuantity);
                decimal? amount = quotas.Sum(o => o.VerifiedQuantity * o.FinalPrice);
                VerQtyCount = (verQtyCount ?? 0M).ToString(RoundRules.STR_QUANTITY);
                Amount = (amount ?? 0M).ToString(RoundRules.STR_AMOUNT);
                QuotasView = new ListCollectionView(quotas);
                if (QuotasView.GroupDescriptions != null)
                {
                    QuotasView.GroupDescriptions.Add(new PropertyGroupDescription("Contract.BusinessPartner.ShortName"));
                }
            }
        }

        /// <summary>
        /// Get the record count of quotas according to the conditions
        /// </summary>
        //public void LoadCount()
        //{
        //    Validate();
        //    BuildQueryStrAndParams();
        //    using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
        //    {
        //        Count = quotaService.FetchCount(_queryStr, _parameters, new List<string> {"Contract"});
        //    }
        //}

        /// <summary>
        /// Validate the search conditions
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            //Validate
            if (InternalCustomerId == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            if (VATInvoiceTypeId == 0)
            {
                throw new Exception(ResReport.OpenCollectRequired);
            }

            return true;
        }

        /// <summary>
        /// Build up the query string and parameters
        /// </summary>
        private void BuildQueryStrAndParams()
        {
            //Build Query String and Parameters
            var parameters = new List<object>();
            var sb = new StringBuilder();

            sb.Append("it.Contract.InternalCustomerId = @p1");
            parameters.Add(InternalCustomerId);

            sb.Append(" and it.Contract.ContractType = @p2");
            if (VATInvoiceTypeId == (int) VATInvoiceType.Receive)
            {
                parameters.Add((int) ContractType.Purchase);
            }
            else
            {
                parameters.Add((int) ContractType.Sales);
            }

            sb.Append(" and it.PricingStatus = @p3");
            parameters.Add((int) PricingStatus.Complete);

            sb.Append(" and (it.ApproveStatus = @p4 or it.ApproveStatus = @p5)");
            parameters.Add((int) ApproveStatus.Approved);
            parameters.Add((int) ApproveStatus.NoApproveNeeded);

            //sb.Append(" and it.DeliveryStatus = @p6");
            //parameters.Add(true);

            sb.Append(" and (it.Contract.TradeType = @p6 or it.Contract.TradeType = @p7)");
            parameters.Add((int) TradeType.ShortDomesticTrade);
            parameters.Add((int) TradeType.LongDomesticTrade);

            int i = 8;
            if (BPId > 0)
            {
                sb.AppendFormat(" and it.Contract.BPId = @p{0}", i++);
                parameters.Add(BPId);
            }

            if (CommodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i++);
                parameters.Add(CommodityId);
            }

            if (StartDate != null)
            {
                sb.AppendFormat(" and it.VATInvoiceDate >= @p{0}", i++);
                parameters.Add(StartDate);
            }

            if (EndDate != null)
            {
                sb.AppendFormat(" and it.VATInvoiceDate <= @p{0}", i++);
                parameters.Add(EndDate);
            }

            if (SelectedVATStatus != 0)
            {
                sb.AppendFormat(" and it.VATStatus = @p{0}", i++);
                parameters.Add(SelectedVATStatus);
            }

            _queryStr = sb.ToString();
            _parameters = parameters;
        }

        private void LoadVATStatus()
        { 
            VATStatus = new Dictionary<string, int>();
            VATStatus.Add("", 0);
            VATStatus = EnumHelper.GetEnumDic<QuotaVATStatus>(VATStatus);
        }
        #endregion


    }
}