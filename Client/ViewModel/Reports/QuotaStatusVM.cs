using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.QuotaServiceReference;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Reports
{
    public class QuotaStatusVM : BaseVM
    {
        #region Property

        private int _businessPartnerId;
        private string _businessPartnerName;
        private List<EnumItem> _businessTypes;
        private List<EnumItem> _deliveryStatuses;
        private DateTime? _endDate;
        private List<EnumItem> _financialStatuses;
        private List<BusinessPartner> _internalCustomers;
        private List<object> _parameters;
        private string _queryStr;
        private int _quotaId;

        private string _quotaNo;
        private List<QuotaStatusChangeLineVM> _results;
        private int _selectedBusinessType;
        private int _selectedDeliveryStatus;
        private int _selectedFinancialStatus;
        private int _selectedInternalCustomerId;
        private List<int> _idList;

        private DateTime? _startDate;

        public List<int> IdList
        {
            get { return _idList; }
            set
            {
                if (_idList != value)
                {
                    _idList = value;
                    Notify("IdList");
                }
            }
        }

        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                if (_quotaId != value)
                {
                    _quotaId = value;
                    Notify("QuotaId");
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

        public int BusinessPartnerId
        {
            get { return _businessPartnerId; }
            set
            {
                if (_businessPartnerId != value)
                {
                    _businessPartnerId = value;
                    Notify("BusinessPartnerId");
                }
            }
        }

        public string BusinessPartnerName
        {
            get { return _businessPartnerName; }
            set
            {
                if (_businessPartnerName != value)
                {
                    _businessPartnerName = value;
                    Notify("BusinessPartnerName");
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

        public int SelectedInternalCustomerId
        {
            get { return _selectedInternalCustomerId; }
            set
            {
                if (_selectedInternalCustomerId != value)
                {
                    _selectedInternalCustomerId = value;
                    Notify("SelectedInternalCustomerId");
                }
            }
        }

        public List<EnumItem> FinancialStatuses
        {
            get { return _financialStatuses; }
            set
            {
                _financialStatuses = value;
                Notify("FinancialStatuses");
            }
        }

        public int SelectedFinancialStatus
        {
            get { return _selectedFinancialStatus; }
            set
            {
                if (_selectedFinancialStatus != value)
                {
                    _selectedFinancialStatus = value;
                    Notify("SelectedFinancialStatus");
                }
            }
        }

        public List<EnumItem> DeliveryStatuses
        {
            get { return _deliveryStatuses; }
            set
            {
                if (_deliveryStatuses != value)
                {
                    _deliveryStatuses = value;
                    Notify("DeliveryStatuses");
                }
            }
        }

        public int SelectedDeliveryStatus
        {
            get { return _selectedDeliveryStatus; }
            set
            {
                if (_selectedDeliveryStatus != value)
                {
                    _selectedDeliveryStatus = value;
                    Notify("SelectedDeliveryStatus");
                }
            }
        }

        public List<EnumItem> BusinessTypes
        {
            get { return _businessTypes; }
            set
            {
                _businessTypes = value;
                Notify("BusinessTypes");
            }
        }

        public int SelectedBusinessType
        {
            get { return _selectedBusinessType; }
            set
            {
                if (_selectedBusinessType != value)
                {
                    _selectedBusinessType = value;
                    Notify("SelectedBusinessType");
                }
            }
        }

        public List<QuotaStatusChangeLineVM> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                Notify("Results");
            }
        }

        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        #endregion

        #region Constructor

        public QuotaStatusVM()
        {
            _startDate = DateTime.Today.AddMonths(-1);
            _endDate = DateTime.Today;

            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> ics = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                ics.Insert(0, new BusinessPartner());
                _internalCustomers = ics;
            }

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }

            _financialStatuses = EnumHelper.GetEnumList<CompleteStatus>();
            _financialStatuses.Insert(0, new EnumItem());

            _deliveryStatuses = EnumHelper.GetEnumList<CompleteStatus>();
            _deliveryStatuses.Insert(0, new EnumItem());

            _businessTypes = EnumHelper.GetEnumList<DomesticForeign>();
            _businessTypes.Insert(0, new EnumItem());

            _quotaId = 0;
            _businessPartnerId = 0;
        }

        #endregion

        #region Method

        public void Reset()
        {
            QuotaId = 0;
            QuotaNo = null;
            BusinessPartnerName = null;
            BusinessPartnerId = 0;
            StartDate = DateTime.Today.AddMonths(-1);
            EndDate = DateTime.Today;
            SelectedBusinessType = 0;
            SelectedDeliveryStatus = 0;
            SelectedFinancialStatus = 0;
            SelectedInternalCustomerId = 0;
        }

        public void LoadCount()
        {
            BuildQueryStrAndParam();

            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Count = quotaService.FetchCount(_queryStr, _parameters, new List<string> { "Contract" });
            }
        }

        public override bool Validate()
        {
            if (SelectedBusinessType == 0)
            {
                throw new Exception(ResReport.TradeTypeRequired);
            }

            return true;
        }

        private void BuildQueryStrAndParam()
        {
            var sb = new StringBuilder();
            _parameters = new List<object>();

            sb.Append("(it.Contract.TradeType = @p1 or it.Contract.TradeType = @p2) and (it.ApproveStatus = " + (int)ApproveStatus.Approved + " or it.ApproveStatus = " + (int)ApproveStatus.NoApproveNeeded + ")");
            if (SelectedBusinessType == (int)DomesticForeign.Domestic)
            {
                _parameters.Add((int)TradeType.LongDomesticTrade);
                _parameters.Add((int)TradeType.ShortDomesticTrade);
            }
            else if (SelectedBusinessType == (int)DomesticForeign.Foreign)
            {
                _parameters.Add((int)TradeType.LongForeignTrade);
                _parameters.Add((int)TradeType.ShortForeignTrade);
            }

            int i = 3;
            if (QuotaId > 0)
            {
                sb.AppendFormat(" and it.Id = @p{0}", i++);
                _parameters.Add(QuotaId);
            }

            if (StartDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate >= @p{0}", i++);
                _parameters.Add(StartDate);
            }

            if (EndDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate <= @p{0}", i++);
                _parameters.Add(EndDate);
            }

            if (BusinessPartnerId > 0)
            {
                sb.AppendFormat(" and it.Contract.BPId = @p{0}", i++);
                _parameters.Add(BusinessPartnerId);
            }

            if (SelectedInternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.Contract.InternalCustomerId = @p{0}", i++);
                _parameters.Add(SelectedInternalCustomerId);
            }

            if (IdList != null && IdList.Count > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < IdList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.AppendFormat("it.Contract.InternalCustomerId = @p{0}", i++);
                        _parameters.Add(IdList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Contract.InternalCustomerId = @p{0}", i++);
                        _parameters.Add(IdList[j]);
                    }
                }
                sb.Append(")");
            }

            if (SelectedFinancialStatus > 0)
            {
                sb.AppendFormat(" and it.FinanceStatus = @p{0}", i++);
                _parameters.Add(SelectedFinancialStatus == (int)CompleteStatus.Complete);
            }

            if (SelectedDeliveryStatus > 0)
            {
                sb.AppendFormat(" and it.DeliveryStatus = @p{0}", i);
                _parameters.Add(SelectedDeliveryStatus == (int)CompleteStatus.Complete);
            }

            sb.Append(" and it.IsAutoGenerated = false");

            _queryStr = sb.ToString();
        }

        public void Load()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                List<Quota> quotas = quotaService.SelectByRangeWithOrder(_queryStr, _parameters,
                                                                         new SortCol
                                                                             {ByDescending = true, ColName = "Id"}, From,
                                                                         To,
                                                                         new List<string>
                                                                             {
                                                                                 "Contract",
                                                                                 "CommercialInvoices",
                                                                                 "CommercialInvoices.Currency",
                                                                                 "Contract.InternalCustomer",
                                                                                 "Contract.BusinessPartner",
                                                                                 "QuotaBrandRels",
                                                                                 "QuotaBrandRels.Brand",
                                                                                 "Contract.BusinessPartner",
                                                                                 "Brand",
                                                                                 "Commodity",
                                                                                 "Currency"
                                                                             });
                Results = new List<QuotaStatusChangeLineVM>();
                foreach (Quota quota in quotas)
                {
                    var line = new QuotaStatusChangeLineVM
                                   {
                                       ActualQuantity = quota.VerifiedQuantity,
                                       BrandName = quota.Brand == null ? string.Empty : quota.Brand.Name,
                                       BusinessPartnerName = quota.Contract.BusinessPartner.ShortName,
                                       CommodityName = quota.Commodity.Name,
                                       CurrencyName = quota.Currency.Name,
                                       DeliveryStatusId = quota.DeliveryStatus
                                                              ? (int) CompleteStatus.Complete
                                                              : (int) CompleteStatus.NotComplete,
                                       FinancialStatusId = quota.FinanceStatus
                                                               ? (int) CompleteStatus.Complete
                                                               : (int) CompleteStatus.NotComplete,
                                       ImplementedDate = quota.ImplementedDate
                                   };

                    decimal? receivable, payable, received, paid, remain, price;
                    int currencyId;
                    decimal vatqty;
                    string tmp1, tmp2;
                    quotaService.GetAparReportDataByQuota(out price, out payable, out receivable, out paid,
                                                            out received, out remain, out tmp1, out tmp2,out currencyId, out vatqty,
                                                            quota, CurrentUser.Id);

                    line.PaidAmount = paid;
                    line.PayableAmount = payable;
                    line.Price = price;
                    line.QuotaId = quota.Id;
                    line.QuotaNo = quota.QuotaNo;
                    line.ReceivableAmount = receivable;
                    line.ReceivedAmount = received;
                    line.RemainAmount = remain;
                    line.VATQuantity = vatqty;
                    line.VATStatus = quota.VATStatus ?? 0;

                    Results.Add(line);
                }
            }
        }

        #endregion
    }

    public class QuotaStatusChangeLineVM
    {
        public string QuotaNo { get; set; }
        public DateTime? ImplementedDate { get; set; }
        public string BusinessPartnerName { get; set; }
        public string CommodityName { get; set; }
        public string BrandName { get; set; }
        public decimal ActualQuantity { get; set; }
        public decimal? Price { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ReceivableAmount { get; set; }
        public decimal? PayableAmount { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainAmount { get; set; }
        public decimal VATQuantity { get; set; }
        public int FinancialStatusId { get; set; }
        public int DeliveryStatusId { get; set; }
        public int QuotaId { get; set; }
        public int VATStatus { get; set; }
    }
}