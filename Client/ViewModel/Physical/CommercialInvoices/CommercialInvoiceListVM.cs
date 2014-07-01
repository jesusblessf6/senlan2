using System;
using System.Collections.Generic;
using System.Text;
using Client.Base.BaseClientVM;
using Client.CommercialInvoiceServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.DocumentServiceReference;
using Client.AttachmentServiceReference;
using System.Linq;
using Client.BusinessPartnerServiceReference;
using Utility.Misc;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class CommercialInvoiceListVM : BaseVM
    {
        #region Member

        private List<object> _parameters = null;
        private int? _cTypeId;
        private int? _commerTypeId;
        private List<CommercialInvoice> _commercialInvoice;
        private ContractType _contractType;
        private int _count;
        private DateTime? _endDate;
        private int _from;
        private int? _interCusId;
        private string _queryStr;
        private int? _sId;
        private DateTime? _startDate;
        private int _to;
        private bool _isOnlyCurrentUser;
        private string _QuotaNo;
        #endregion

        #region Property
        public string QuotaNo
        {
            get { return _QuotaNo; }
            set { 
                if(_QuotaNo != value)
                {
                    _QuotaNo = value;
                    Notify("QuotaNo");
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

        public ContractType ContractType
        {
            get { return _contractType; }
            set
            {
                if (_contractType != value)
                {
                    _contractType = value;
                    Notify("ContractType");
                }
            }
        }

        public List<CommercialInvoice> CommercialInvoice
        {
            get { return _commercialInvoice; }
            set
            {
                if (_commercialInvoice != value)
                {
                    _commercialInvoice = value;
                    Notify("CommercialInvoice");
                }
            }
        }

        public int? SId
        {
            set
            {
                if (_sId != value)
                {
                    _sId = value;
                    Notify("SId");
                }
            }
            get { return _sId; }
        }

        public int? CTypeId
        {
            set
            {
                if (_cTypeId != value)
                {
                    _cTypeId = value;
                    Notify("CTypeId");
                }
            }
            get { return _cTypeId; }
        }

        public int? InterCusId
        {
            set
            {
                if (_interCusId != value)
                {
                    _interCusId = value;
                    Notify("InterCusId");
                }
            }
            get { return _interCusId; }
        }

        public int? CommerTypeId
        {
            set
            {
                if (_commerTypeId != value)
                {
                    _commerTypeId = value;
                    Notify("CommerTypeId");
                }
            }
            get { return _commerTypeId; }
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

        public int Count
        {
            get { return _count; }
            set
            {
                if (_count != value)
                {
                    _count = value;
                    Notify("Count");
                }
            }
        }

        public int From
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    Notify("From");
                }
            }
        }

        public int To
        {
            get { return _to; }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    Notify("To");
                }
            }
        }

        #endregion

        public CommercialInvoiceListVM()
        {
        }

        public CommercialInvoiceListVM(int? sId, int? cTypeId, int? interCusId, int? commerTypeId,
                                         ContractType contractType, DateTime? startDate, DateTime? endDate, bool isOnlyCurrentUser, string quotaNo)
        {
            SId = sId;
            CTypeId = cTypeId;
            InterCusId = interCusId;
            CommerTypeId = commerTypeId;
            ContractType = contractType;
            StartDate = startDate;
            EndDate = endDate;
            IsOnlyCurrentUser = isOnlyCurrentUser;
            QuotaNo = quotaNo;
            Setparam();
            LoadComCount();
        }

        #region Method

        /// <summary>
        /// 根据条件取分页用发票数据
        /// </summary>
        public void LoadCommercialInvoice()
        {
            using (var commercialInvoiceService = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                if (_queryStr == string.Empty)
                {
                    _queryStr = "1==1";
                    _parameters = null;
                };


                CommercialInvoice = commercialInvoiceService.SelectByRangeWithMultiOrderLazyLoad(_queryStr, _parameters,
                                                        new List<SortCol> { new SortCol { ByDescending = true, ColName = "InvoicedDate" } }, _from, _to,
                                                        new List<string>
                                                        {
                                                            "Quota.Contract.BusinessPartner",
                                                            "Quota.Contract.InternalCustomer",
                                                            "Quota.Commodity"
                                                        },
                                                        new List<string>
                                                        {
                                                            "FinalInvoice",
                                                            "Currency",
                                                            "Deliveries",
                                                            "Deliveries.DeliveryLines",
                                                            "ProvisionalInvoices",
                                                            "ProvisionalInvoices.Deliveries",
                                                            "ProvisionalInvoices.Deliveries.DeliveryLines",
                                                            "BaseInvoice",
                                                            "BaseInvoice.Deliveries",
                                                            "BaseInvoice.Deliveries.DeliveryLines"
                                                        });
            }
        }

        /// <summary>
        /// 根据条件获取查询的总发票数
        /// </summary>
        public void LoadComCount()
        {
            using (
                var commercialInvoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                Count = _queryStr != string.Empty
                            ? commercialInvoiceService.GetCount(_queryStr, _parameters)
                            : commercialInvoiceService.GetAllCount();
            }
        }

        /// <summary>
        /// 设置查询参数
        /// </summary>
        private void Setparam()
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

            var sb = new StringBuilder();
            if (SId.HasValue)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.Quota.Contract.BPId == " + SId);
            }
            if (CTypeId.HasValue && CTypeId != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.Quota.CommodityId == " + CTypeId);
            }

            if (IsOnlyCurrentUser)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.CreatedBy == " + CurrentUser.Id);
            }

            if (InterCusId.HasValue && InterCusId != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.Quota.Contract.InternalCustomerId == " + InterCusId);
            }
            else if (idList.Count > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("(");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        sb.Append("it.Quota.Contract.InternalCustomerId ==" + idList[j]);
                    }
                    else
                    {
                        sb.Append(" or it.Quota.Contract.InternalCustomerId == " + idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (CommerTypeId.HasValue && CommerTypeId != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.InvoiceType == " + CommerTypeId);
            }
            if (StartDate.HasValue)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.InvoicedDate >= cast('" + StartDate + "' as System.DateTime) ");
            }
            if (EndDate.HasValue)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" it.InvoicedDate <= cast('" + EndDate + "' as System.DateTime) ");
            }
            if(!string.IsNullOrEmpty(QuotaNo))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("it.Quota.QuotaNo Like \'%" + QuotaNo + "%\'");
            }

            if (sb.Length > 0)
            {
                sb.Append(" and ");
            }
            sb.Append(" it.Quota.Contract.ContractType == " + (int)ContractType);
            _queryStr = sb.ToString();
        }

        /// <summary>
        /// 跟据id获取发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommercialInvoice GetInvoiceById(int id)
        {
            CommercialInvoice invoice;
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                invoice = invoiceService.GetById(id);
            }
            return invoice;
        }

        /// <summary>
        /// 根据id删除发票
        /// </summary>
        /// <param name="id"></param>
        public void RemoveInvoiceById(int id)
        {
            using (
                var invoiceService =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                invoiceService.RemoveInvoice(id, CurrentUser.Id);
            }
        }

        /// <summary>
        /// Judge whether the contract has attachments
        /// </summary>
        /// <param name="selectId"> </param>
        /// <returns></returns>
        public bool HasAttachment(int selectId)
        {
            bool flag;
            int id;
            string documentCode = GetDocumentCode(selectId);

            using (var documentService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                id = documentService.GetByTableCode(documentCode).Id;
            }

            using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
            {
                const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2";
                var par = new List<object> { selectId, id };
                List<Attachment> attachments = attachmentService.Query(queryStr, par);
                flag = attachments.Count > 0;
            }
            return flag;
        }

        /// <summary>
        /// Judge whether the contract has attachments
        /// </summary>
        /// <param name="selectId"> </param>
        /// <returns></returns>
        public string GetDocumentCode(int selectId)
        {
            string documentCode = "";
            using (
                   var invoiceService =
                       SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                CommercialInvoice invoice = invoiceService.GetById(selectId);
                if (invoice != null)
                {
                    if (invoice.InvoiceType == (int)CommercialInvoiceType.Provisional || invoice.InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        documentCode = "ProvisionalInvoice";
                    }
                    else if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
                    {
                        documentCode = "FinalInvoice";
                    }
                }
            }
            return documentCode;
        }

        #endregion
    }
}