using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.DeliveryServiceReference;
using Client.Properties;
using Client.View.PopUpDialog;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class ExternalDeliveryCirculReportVM : BaseVM
    {
        #region Member

        private int _bpId;
        private string _bpName;
        private string _circulNo;
        private List<Commodity> _commodities;
        private List<ExternalDeliveryCirculReportLineVM> _eDCRLines;
        private DateTime? _endDate;
        private List<BusinessPartner> _internalCustomers;
        private decimal? _marginRatio;

        private int _selectedInternalCustomerId;
        private DateTime? _startDate;

        #endregion

        #region Property

        public ListCollectionView CirculView { get; set; }

        public string CirculNo
        {
            get { return _circulNo; }
            set
            {
                _circulNo = value;
                Notify("CirculNo");
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

        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
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

        public List<BusinessPartner> InternalCustomers
        {
            get { return _internalCustomers; }
            set
            {
                _internalCustomers = value;
                Notify("InternalCustomers");
            }
        }

        public decimal? MarginRatio
        {
            get { return _marginRatio; }
            set
            {
                _marginRatio = value;
                Notify("MarginRatio");
            }
        }

        public List<ExternalDeliveryCirculReportLineVM> EDCRlines
        {
            get { return _eDCRLines; }
            set
            {
                _eDCRLines = value;
                Notify("EDCRlines");
            }
        }


        public string QueryStr { get; set; }
        public List<object> Parameters { get; set; }

        #endregion

        #region Constructor

        public ExternalDeliveryCirculReportVM()
        {
            //load brokers and internal customers
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                _internalCustomers = bpService.GetInternalCustomersByUser(CurrentUser.Id);
                _internalCustomers.Insert(0, new BusinessPartner());
            }

            //set start date to today as default
            _endDate = DateTime.Today;
        }

        #endregion

        #region Method

        /// <summary>
        /// 显示客户弹出框
        /// </summary>
        public void ShowCustomerDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var customer = dialog.SelectedItem as BusinessPartner;
            if (customer != null)
            {
                BPId = customer.Id;
                BPName = customer.ShortName;
            }
        }

        public void Load()
        {
            Validate();
            BuildQueryStrAndParam();
            if (EDCRlines == null)
            {
                EDCRlines = new List<ExternalDeliveryCirculReportLineVM>();
            }
            //Load the initial date
            List<Delivery> deliverys;
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                deliverys = deliveryService.Select(QueryStr, Parameters,
                                                   new List<string>
                                                       {
                                                           "Quota",
                                                           "Quota.Contract",
                                                           "Quota.Contract.BusinessPartner",
                                                           "Quota.Contract.InternalCustomer",
                                                           "Quota.Commodity",
                                                           "DeliveryLines",
                                                           "DeliveryLines.Brand",
                                                           "LetterOfCredit",
                                                           "LetterOfCredit.Bank",
                                                           "Quota.Brand",
                                                       });
            }
            if (deliverys.Count > 0)
            {
                foreach (var delivery in deliverys)
                {
                    FilterDeleted(delivery.DeliveryLines);
                }
            }
            FillGrid(deliverys);
            EDCRlines = EDCRlines.OrderBy(o => o.CirculNo).ThenBy(o => o.DeliveryNo).ToList();
            CirculView = new ListCollectionView(EDCRlines);
            if (CirculView.GroupDescriptions != null)
                CirculView.GroupDescriptions.Add(new PropertyGroupDescription("CirculNo"));
        }

        /// <summary>
        /// Validate the search conditions
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return true;
        }

        /// <summary>
        /// Build Up Query string and Parameters
        /// </summary>
        private void BuildQueryStrAndParam()
        {
            List<int> idList = new List<int>();
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    idList = list.Select(c => c.Id).ToList();
                }
            }

            //build condition and parameters
            var sb = new StringBuilder();
            sb.AppendFormat(
                "(it.DeliveryType=@p1 or it.DeliveryType=@p2) and it.IsDeleted=false");
            var parameters = new List<object>
                                 {
                                     (int) DeliveryType.ExternalTDBOL,
                                     (int) DeliveryType.ExternalTDWW,
                                 };
            int i = 3;
            if (SelectedInternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.Quota.Contract.InternalCustomerId  = @p{0}", i++);
                parameters.Add(SelectedInternalCustomerId);
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
                        sb.AppendFormat("it.Quota.Contract.InternalCustomerId = @p{0}", i++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Quota.Contract.InternalCustomerId = @p{0}", i++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (StartDate != null)
            {
                sb.AppendFormat(" and it.IssueDate >= @p{0}", i++);
                parameters.Add(StartDate);
            }
            if (!string.IsNullOrEmpty(CirculNo == null ? CirculNo : CirculNo.Trim()))
            {
                sb.AppendFormat(" and it.CirculNo Like @p{0}", i++);
                parameters.Add("%" + CirculNo.Trim() + "%");
            }
            if (BPId > 0)
            {
                sb.AppendFormat(" and it.Quota.Contract.BPId == @p{0}", i++);
                parameters.Add(BPId);
            }

            if (EndDate != null)
            {
                sb.AppendFormat(" and it.IssueDate <= @p{0}", i);
                parameters.Add(EndDate);
            }

            QueryStr = sb.ToString();
            Parameters = parameters;
        }

        /// <summary>
        /// Fill the Summary Grid
        /// </summary>
        private void FillGrid(IEnumerable<Delivery> deliverys)
        {
            EDCRlines.Clear();
            foreach (Delivery item in deliverys)
            {
                ExternalDeliveryCirculReportLineVM edcrLine = ExternalDeliveryCirculReportLineBind(item);
                if(edcrLine!=null)
                    EDCRlines.Add(edcrLine);
            }
        }

        //报表Entity赋值
        public ExternalDeliveryCirculReportLineVM ExternalDeliveryCirculReportLineBind(Delivery delivery)
        {
            if (delivery != null)
            {
                //根据ID找MD
                Delivery mDelivery = null;
                Delivery td;
                using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
                {
                    QueryStr = string.Format("it.Id={0}", delivery.Id);
                    Parameters = null;
                    td = deliveryService.Select(QueryStr, Parameters,
                                                       new List<string>
                                                           {
                                                               "DeliveryLines",
                                                               "DeliveryLines.SalesDeliveryLines",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Contract",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Contract.BusinessPartner",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Contract.InternalCustomer",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Commodity",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.DeliveryLines",
                                                               "DeliveryLines.SalesDeliveryLines.Delivery.Quota.Brand"
                                                           }).FirstOrDefault();
                    FilterDeleted(td.DeliveryLines);

                    foreach (var dline in td.DeliveryLines)
                    {
                        FilterDeleted(dline.SalesDeliveryLines);
                        if (dline.SalesDeliveryLines.Count > 0)
                        {
                            mDelivery = dline.SalesDeliveryLines.FirstOrDefault().Delivery;
                            break;
                        }
                    }
                    if (mDelivery == null || mDelivery.Id < 0)
                    {

                        return null;
                    }

                    FilterDeleted(mDelivery.DeliveryLines);
                }
                var line = new ExternalDeliveryCirculReportLineVM
                               {
                                   CirculNo = delivery.CirculNo, //流水号
                                   CommodityName = delivery.Quota.Commodity.Name, //金属
                                   NetWeight = delivery.TotalNetWeight, //净重
                                   GrossWeight = delivery.TotalGrossWeight, //毛重
                                   SellBPName = delivery.Quota.Contract.BusinessPartner.ShortName,
                                   BuyBPName = mDelivery.Quota.Contract.BusinessPartner.ShortName,
                                   BuyDate = delivery.Quota.ImplementedDate,
                                   SellDate = mDelivery.Quota.ImplementedDate,
                                   DeliveryNo = delivery.DeliveryNo,
                                   DeliveryId = delivery.Id,
                                   DeliveryType =
                                       (delivery.DeliveryType == 0
                                            ? string.Empty
                                            : EnumHelper.GetDesByValue<DeliveryType>(delivery.DeliveryType))
                               };
                foreach (var item in delivery.DeliveryLines.GroupBy(t => t.Brand))
                {
                    line.BrandName += item.FirstOrDefault().Brand == null ? "" : item.FirstOrDefault().Brand.Name + "；";
                }
                if (delivery.LetterOfCredit != null)
                {
                    line.LCMsg += Resources.LoCNo + ":" + delivery.LetterOfCredit.LCNo + "，" + Resources.IssuingDate + ":" +
                                          string.Format("{0:yyyy/MM/dd}", delivery.LetterOfCredit.IssueDate) +
                                          "，" + ResReport.InformBank +
                                          (delivery.LetterOfCredit.Bank == null
                                               ? ""
                                               : delivery.LetterOfCredit.Bank.Name) + "；";
                }
                return line;
            }
            return null;
        }

        #endregion
    }

    //报表Entity
    public class ExternalDeliveryCirculReportLineVM
    {
        public string CirculNo { get; set; } //流水号
        public DateTime? BuyDate { get; set; } //采购日期
        public DateTime? SellDate { get; set; } //销售日期
        public string BuyBPName { get; set; } //采购方
        public string SellBPName { get; set; } //销售方
        public string CommodityName { get; set; } //金属
        public string BrandName { get; set; } //品牌
        public decimal? NetWeight { get; set; } //净重
        public decimal? GrossWeight { get; set; } //毛重
        public string DeliveryNo { get; set; } //单据号(提单号)
        public string DeliveryType { get; set; } //单据类型（提单类型）
        public string LCMsg { get; set; } //信用证信息
        public int DeliveryId { get; set; }
    }
}