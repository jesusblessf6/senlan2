using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CountryServiceReference;
using Client.DeliveryPersonServiceReference;
using Client.PaymentMeanServiceReference;
using Client.PaymentUsageServiceReference;
using Client.PortServiceReference;
using Client.VATRateServiceReference;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class DataDictHomeVM : BaseVM
    {
        #region Member

        private List<Country> _countries;

        private int _countryCount;
        private int _countryFrom;
        private int _countryTo;

        private int _paymentmeanCount;
        private int _paymentmeanFrom;
        private int _paymentmeanTo;
        private List<PaymentMean> _paymentmeans;

        private int _paymentusageCount;
        private int _paymentusageFrom;
        private int _paymentusageTo;
        private List<PaymentUsage> _paymentusages;
        private int _portCount;
        private int _portFrom;
        private int _portTo;
        private List<Port> _ports;
        private int _vatrateCount;
        private int _vatrateFrom;
        private int _vatrateTo;
        private List<VATRate> _vatrates;

        private int _udfCount;
        private int _udfFrom;
        private int _udfTo;
        private List<ContractUDF> _udfs;

        private int _deliveryPersonCount;
        private int _deliveryPersonFrom;
        private int _deliveryPersonTo;
        private List<DeliveryPerson> _deliveryPersons; 
        #endregion

        #region Property

        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                Notify("Countries");
            }
        }

        public List<Port> Ports
        {
            get { return _ports; }
            set
            {
                _ports = value;
                Notify("Ports");
            }
        }

        public List<PaymentMean> PaymentMeans
        {
            get { return _paymentmeans; }
            set
            {
                _paymentmeans = value;
                Notify("PaymentMeans");
            }
        }

        public List<VATRate> VATRates
        {
            get { return _vatrates; }
            set
            {
                _vatrates = value;
                Notify("VATRates");
            }
        }

        public List<PaymentUsage> PaymentUsages
        {
            get { return _paymentusages; }
            set
            {
                _paymentusages = value;
                Notify("PaymentUsages");
            }
        }

        public List<ContractUDF> Udfs
        {
            get { return _udfs; }
            set
            {
                _udfs = value;
                Notify("Udfs");
            }
        }

        public int CountryCount
        {
            get { return _countryCount; }
            set
            {
                if (_countryCount != value)
                {
                    _countryCount = value;
                    Notify("CountryCount");
                }
            }
        }

        public int CountryTo
        {
            get { return _countryTo; }
            set
            {
                if (_countryTo != value)
                {
                    _countryTo = value;
                    Notify("CountryTo");
                }
            }
        }

        public int CountryFrom
        {
            get { return _countryFrom; }
            set
            {
                if (_countryFrom != value)
                {
                    _countryFrom = value;
                    Notify("CountryFrom");
                }
            }
        }

        public int PortCount
        {
            get { return _portCount; }
            set
            {
                if (_portCount != value)
                {
                    _portCount = value;
                    Notify("PortCount");
                }
            }
        }

        public int PortTo
        {
            get { return _portTo; }
            set
            {
                if (_portTo != value)
                {
                    _portTo = value;
                    Notify("PortTo");
                }
            }
        }

        public int PortFrom
        {
            get { return _portFrom; }
            set
            {
                if (_portFrom != value)
                {
                    _portFrom = value;
                    Notify("PortFrom");
                }
            }
        }

        public int PaymentMeanCount
        {
            get { return _paymentmeanCount; }
            set
            {
                if (_paymentmeanCount != value)
                {
                    _paymentmeanCount = value;
                    Notify("PaymentMeanCount");
                }
            }
        }

        public int PaymentMeanTo
        {
            get { return _paymentmeanTo; }
            set
            {
                if (_paymentmeanTo != value)
                {
                    _paymentmeanTo = value;
                    Notify("PaymentMeanTo");
                }
            }
        }

        public int PaymentMeanFrom
        {
            get { return _paymentmeanFrom; }
            set
            {
                if (_paymentmeanFrom != value)
                {
                    _paymentmeanFrom = value;
                    Notify("PaymentMeanFrom");
                }
            }
        }

        public int VATRateCount
        {
            get { return _vatrateCount; }
            set
            {
                if (_vatrateCount != value)
                {
                    _vatrateCount = value;
                    Notify("VATRateCount");
                }
            }
        }

        public int VATRateTo
        {
            get { return _vatrateTo; }
            set
            {
                if (_vatrateTo != value)
                {
                    _vatrateTo = value;
                    Notify("VATRateTo");
                }
            }
        }

        public int VATRateFrom
        {
            get { return _vatrateFrom; }
            set
            {
                if (_vatrateFrom != value)
                {
                    _vatrateFrom = value;
                    Notify("VATRateFrom");
                }
            }
        }

        public int PaymentUsageCount
        {
            get { return _paymentusageCount; }
            set
            {
                if (_paymentusageCount != value)
                {
                    _paymentusageCount = value;
                    Notify("PaymentUsageCount");
                }
            }
        }

        public int PaymentUsageTo
        {
            get { return _paymentusageTo; }
            set
            {
                if (_paymentusageTo != value)
                {
                    _paymentusageTo = value;
                    Notify("PaymentUsageTo");
                }
            }
        }

        public int PaymentUsageFrom
        {
            get { return _paymentusageFrom; }
            set
            {
                if (_paymentusageFrom != value)
                {
                    _paymentusageFrom = value;
                    Notify("PaymentUsageFrom");
                }
            }
        }

        public int UdfCount
        {
            get { return _udfCount; }
            set
            {
                if (_udfCount != value)
                {
                    _udfCount = value;
                    Notify("UdfCount");
                }
            }
        }

        public int UdfTo
        {
            get { return _udfTo; }
            set
            {
                if (_udfTo != value)
                {
                    _udfTo = value;
                    Notify("UdfTo");
                }
            }
        }

        public int UdfFrom
        {
            get { return _udfFrom; }
            set
            {
                if (_udfFrom != value)
                {
                    _udfFrom = value;
                    Notify("UdfFrom");
                }
            }
        }

        public int DeliveryPersonCount
        {
            get { return _deliveryPersonCount; }
            set
            {
                if (_deliveryPersonCount != value)
                {
                    _deliveryPersonCount = value;
                    Notify("DeliveryPersonCount");
                }
            }
        }

        public int DeliveryPersonFrom
        {
            get { return _deliveryPersonFrom; }
            set
            {
                if (_deliveryPersonFrom != value)
                {
                    _deliveryPersonFrom = value;
                    Notify("DeliveryPersonFrom");
                }
            }
        }

        public int DeliveryPersonTo
        {
            get { return _deliveryPersonTo; }
            set
            {
                if (_deliveryPersonTo != value)
                {
                    _deliveryPersonTo = value;
                    Notify("DeliveryPersonTo");
                }
            }
        }

        public List<DeliveryPerson> DeliveryPersons
        {
            get { return _deliveryPersons; }
            set
            {
                _deliveryPersons = value;
                Notify("DeliveryPersons");
            }
        }

        #endregion

        #region Constructor

        public DataDictHomeVM()
        {
            _countries = new List<Country>();
            LoadCountryCount();
            _ports = new List<Port>();
            LoadPortCount();
            _paymentmeans = new List<PaymentMean>();
            LoadPaymentMeanCount();
            _vatrates = new List<VATRate>();
            LoadVATRateCount();
            _paymentusages = new List<PaymentUsage>();
            LoadPaymentUsageCount();
            _udfs = new List<ContractUDF>();
            LoadContractUDFCount();
            _deliveryPersons = new List<DeliveryPerson>();
            LoadDeliveryPersonCount();
        }

        #endregion

        #region Method

        #region 原产地

        public void LoadCountry()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                Countries = countryService.GetByRangeWithOrder(new SortCol { ByDescending = false, ColName = "ChineseName" },
                                                               CountryFrom, CountryTo);
            }
        }

        public void LoadCountryCount()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                _countryCount = countryService.GetAllCount();
            }
        }

        public void DeleteCountry(int id)
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                countryService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 港口

        public void LoadPort()
        {
            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                Ports = portService.FetchByRangeWithOrder(new SortCol { ByDescending = false, ColName = "Name" }, PortFrom,
                                                          PortTo, new List<string> {"Country"});
            }
        }

        public void LoadPortCount()
        {
            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                _portCount = portService.GetAllCount();
            }
        }

        public void DeletePort(int id)
        {
            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                portService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 付款方式

        public void LoadPaymentMean()
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMeans = paymentMeanService.GetByRangeWithOrder(
                    new SortCol {ByDescending = true, ColName = "Id"}, PaymentMeanFrom, PaymentMeanTo);
            }
        }

        public void LoadPaymentMeanCount()
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                _paymentmeanCount = paymentMeanService.GetAllCount();
            }
        }

        public void DeletePaymentMean(int id)
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                paymentMeanService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 税率

        public void LoadVATRate()
        {
            using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                List<VATRate> vatRateList =
                    vatrateService.GetByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"}, VATRateFrom,
                                                       VATRateTo);
                if (VATRates != null)
                {
                    VATRates.Clear();
                }
                else
                {
                    VATRates = new List<VATRate>();
                }

                foreach (VATRate vr in vatRateList)
                {
                    vr.RateValue = vr.RateValue*100; //转会税率成百分比
                    VATRates.Add(vr);
                }
            }
        }

        public void LoadVATRateCount()
        {
            using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                _vatrateCount = vatrateService.GetAllCount();
            }
        }

        public void DeleteVATRate(int id)
        {
            using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                vatrateService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 付款用途

        public void LoadPaymentUsage()
        {
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                PaymentUsages =
                    paymentusageService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                              PaymentUsageFrom, PaymentUsageTo,
                                                              new List<string> {"PaymentMean", "FinancialAccount"});
            }
        }

        public void LoadPaymentUsageCount()
        {
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                _paymentusageCount = paymentusageService.GetAllCount();
            }
        }

        public void DeletePaymentUsage(int id)
        {
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                paymentusageService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 自定义类型

        public void LoadContractUDF()
        {
            using (
                var contractUDFService =
                    SvcClientManager.GetSvcClient<ContractUDFServiceReference.ContractUDFServiceClient>(SvcType.ContractUDFSvc))
            {
                _udfs = contractUDFService.GetByRangeWithOrder(new SortCol { ByDescending = true, ColName = "Id" },
                                                               UdfFrom, UdfTo);
            }
        }

        public void LoadContractUDFCount()
        {
            using (
               var contractUDFService =
                    SvcClientManager.GetSvcClient<ContractUDFServiceReference.ContractUDFServiceClient>(SvcType.ContractUDFSvc))
            {
                _udfCount = contractUDFService.GetAllCount();
            }
        }

        public void DeleteContractUDF(int id)
        {
            using (
               var contractUDFService =
                    SvcClientManager.GetSvcClient<ContractUDFServiceReference.ContractUDFServiceClient>(SvcType.ContractUDFSvc))
            {
                contractUDFService.RemoveById(id, CurrentUser.Id);
            }
        }

        #endregion

        #region 提货人
        public void LoadDeliveryPersonCount()
        {
            using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
            {
                _deliveryPersonCount = dpService.GetAllCount();
            }
        }

        public void LoadDeliveryPersons()
        {
            using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
            {
                _deliveryPersons = dpService.GetByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                 _deliveryPersonFrom, _deliveryPersonTo);
            }
        }

        public void DeleteDeliveryPerson(int id)
        {
            using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
            {
                dpService.RemoveById(id, CurrentUser.Id);
            }
        }
        #endregion

        #endregion
    }
}