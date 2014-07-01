using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.QuotaServiceReference;
using Client.View.PopUpDialog;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using System;
using Client.FundFlowServiceReference;
using System.ComponentModel;
using Client.ViewModel.PrintTemplate.APARTemplate;
using Client.Helper;

namespace Client.ViewModel.Reports
{
    public class APARReportVM : BaseVM
    {
        #region Member

        private int? _bpId;
        private string _bpName;
        private int _innerCustomerId;
        private List<BusinessPartner> _innerCustomers;
        private int _metalId;
        private List<Commodity> _metals;
        private List<TempClass> _tempClasses;

        private DateTime? _endDate = DateTime.Today;
        private DateTime? _startDate = DateTime.Today.AddMonths(-1);

        private List<ARAPClass> _listAraps;

        private string _quotaNo;
        private List<ARAPClassForPrint> _finalList;
        private bool _isSelectAll;

        #endregion

        #region Property
        public bool IsSelectAll
        {
            get { return _isSelectAll; }
            set
            {
                if (_isSelectAll != value)
                {
                    _isSelectAll = value;
                    Notify("IsSelectAll");
                }
            }
        }

        public List<ARAPClassForPrint> FinalList
        {
            get { return _finalList; }
            set
            {
                if (_finalList != value)
                {
                    _finalList = value;
                    Notify("FinalList");
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

        public List<ARAPClass> ListAraps
        {
            get { return _listAraps; }
            set
            {
                if (_listAraps != value)
                {
                    _listAraps = value;
                    Notify("ListAraps");
                }
            }
        }

        public ListCollectionView APARView { get; set; }

        public List<TempClass> TempClasses
        {
            get { return _tempClasses; }
            set
            {
                if (_tempClasses != value)
                {
                    _tempClasses = value;
                    Notify("TempClasses");
                }
            }
        }

        /// <summary>
        /// 客户Id
        /// </summary>
        public int? BpId
        {
            get { return _bpId; }
            set
            {
                if (_bpId != value)
                {
                    _bpId = value;
                    Notify("BpId");
                }
            }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string BpName
        {
            get { return _bpName; }
            set
            {
                if (_bpName != value)
                {
                    _bpName = value;
                    Notify("BpName");
                }
            }
        }

        /// <summary>
        /// 内部客户Id
        /// </summary>
        public int InnerCustomerId
        {
            get { return _innerCustomerId; }
            set
            {
                if (_innerCustomerId != value)
                {
                    _innerCustomerId = value;
                    Notify("InnerCustomerId");
                }
            }
        }

        /// <summary>
        /// 金属Id
        /// </summary>
        public int MetalId
        {
            get { return _metalId; }
            set
            {
                if (_metalId != value)
                {
                    _metalId = value;
                    Notify("MetalId");
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

        public List<BusinessPartner> InnerCustomers
        {
            get { return _innerCustomers; }
            set
            {
                if (_innerCustomers != value)
                {
                    _innerCustomers = value;
                    Notify("InnerCustomers");
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

        #endregion

        #region Contruct

        public APARReportVM()
        {
            FinalList = new List<ARAPClassForPrint>();
            LoadCommodity();
            LoadInternalCustomers();
            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Method
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelectAll")
            {
                foreach (var pr in FinalList)
                {
                    if (pr.Title == "-1")
                    {
                        pr.IsPrintSelected = IsSelectAll;
                    }
                }
            }
        }

        /// <summary>
        /// Get the Commodities for the Combo Box
        /// </summary>
        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _metals = commService.GetCommoditiesByUser(CurrentUser.Id);
            }
            _metals.Insert(0, new Commodity { Id = 0, Name = string.Empty });
        }

        /// <summary>
        /// Get the Internal Customer for the Combo Box
        /// </summary>
        private void LoadInternalCustomers()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                _innerCustomers = busService.GetInternalCustomersByUser(CurrentUser.Id);
                _innerCustomers.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        public void ShowCustomerDialog()
        {
            string queryStr = "it.CustomerType = " + (int)BusinessPartnerType.Customer + " or it.CustomerType = " +
                              (int)BusinessPartnerType.InternalCustomer;
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                BpId = bp.Id;
                BpName = bp.ShortName;
            }
        }

        public void Search()
        {
            APARView = null;
            NewCreateData();
        }

        private void NewCreateData()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                List<ARAPClass> listAraps = quotaService.GetARAPReportData(BpId ?? 0, InnerCustomerId, MetalId, StartDate, EndDate, QuotaNo, CurrentUser.Id);
                if (listAraps.Count == 0)
                {
                    //ListAraps = null;
                    FinalList = null;
                }
                else
                {
                    //ListAraps = listAraps;
                    FinalList = new List<ARAPClassForPrint>();
                    foreach (ARAPClass arap in listAraps)
                    {
                        ARAPClassForPrint print = new ARAPClassForPrint();
                        print.Title = arap.Title;
                        print.BusinessPartnerName = arap.BusinessPartnerName;
                        print.InnerCustomerName = arap.InnerCustomerName;
                        print.QuotaNoStr = arap.QuotaNo;
                        print.CommodityName = arap.CommodityName;
                        print.BrandName = arap.BrandName;
                        print.VerQty = arap.VerQty;
                        print.NPrice = arap.Price;
                        print.PricingCurrency = arap.PricingCurrency;
                        print.BReceived = arap.BReceived;
                        print.BPaid = arap.BPaid;
                        print.SReceived = arap.SReceived;
                        print.SPaid = arap.SPaid;
                        print.AmountRemain = arap.AmountRemain;
                        print.AmountRemainCNY = arap.AmountRemainCNY;
                        print.SettleCurrency = arap.SettleCurrency;
                        print.InternalCustomerId = arap.InternalCustomerId;
                        print.CustomerId = arap.CustomerId;
                        print.Date = arap.Date;
                        print.VatInvoiceQty = arap.VatInvoiceQty;
                        print.VatInvoiceAmount = arap.VatInvoiceAmount;
                        print.VatInvoiceAmountRemain = arap.VatInvoiceAmountRemain;
                        print.BeforeAmount = arap.BeforeAmount;
                        print.EndDate = EndDate;
                        FinalList.Add(print);
                    }
                }
            }
        }

        public void PrintSelected()
        {
            List<ARAPClassForPrint> toPrints = FinalList.Where(o => o.IsPrintSelected).ToList();
            foreach (ARAPClassForPrint pr in toPrints)
            {
                var reportVM = new APARTemplateVM(pr);
                var dataSources = new Dictionary<string, object> { { "Header", reportVM.HeaderList } };
                var printHelper = new PrintHelper(dataSources, @"PrintTemplate\对账单模板\应收应付对账单.rdlc");
                printHelper.Run();
            }
        }

        #endregion
    }

    public class TempClass
    {
        public string Title { get; set; }

        public string InnerName { get; set; }

        public string BpName { get; set; }

        public string CommodityName { get; set; }

        public string BrandName { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyName1 { get; set; }

        public string QuotaNo { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? Yings { get; set; }

        public decimal? Yingf { get; set; }

        public decimal? Yis { get; set; }

        public decimal? Yif { get; set; }

        public decimal? Ye { get; set; }

        public decimal Sts { get; set; }

        public string TradeType { get; set; }
    }

    public class ARAPClassForPrint : Quota
    {

        /// <summary>
        /// 分组名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 业务伙伴名称
        /// </summary>
        public string BusinessPartnerName { get; set; }

        /// <summary>
        /// 内部客户名称
        /// </summary>
        public string InnerCustomerName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string QuotaNoStr { get; set; }

        /// <summary>
        /// 金属品种
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 金属品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal? VerQty { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? NPrice { get; set; }

        /// <summary>
        /// 点价币种
        /// </summary>
        public string PricingCurrency { get; set; }

        /// <summary>
        /// 应收
        /// </summary>
        public decimal? BReceived { get; set; }

        /// <summary>
        /// 应付
        /// </summary>
        public decimal? BPaid { get; set; }

        /// <summary>
        /// 已收
        /// </summary>
        public decimal? SReceived { get; set; }

        /// <summary>
        /// 已付
        /// </summary>
        public decimal? SPaid { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? AmountRemain { get; set; }

        /// <summary>
        /// 余额(人民币)
        /// </summary>
        public decimal? AmountRemainCNY { get; set; }

        /// <summary>
        /// 结算币种
        /// </summary>
        public string SettleCurrency { get; set; }

        public int? InternalCustomerId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? Date { get; set; }

        public decimal? VatInvoiceQty { get; set; }

        public decimal? VatInvoiceAmount { get; set; }

        public decimal? VatInvoiceAmountRemain { get; set; }

        /// <summary>
        /// 期初余额
        /// </summary>
        public decimal? BeforeAmount { get; set; }

        /// <summary>
        /// 复选框是否被选中
        /// </summary>
        public bool IsPrintSelected
        {
            get
            {
                return _IsPrintSelected;
            }
            set
            {
                if (_IsPrintSelected != value)
                {
                    _IsPrintSelected = value;
                    OnPropertyChanged("IsPrintSelected");
                }
            }
        }
        private bool _IsPrintSelected;

        public string IsVisible
        {
            get
            {
                if (Title == "-1")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public DateTime? EndDate { get; set; }//查询截止日期

    }
}
