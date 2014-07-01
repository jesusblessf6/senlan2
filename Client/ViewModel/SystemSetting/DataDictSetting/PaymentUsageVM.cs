using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.PaymentMeanServiceReference;
using Client.PaymentUsageServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using Utility.ServiceManagement;
using System.Linq;
using System.Windows;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class PaymentUsageVM : BaseVM
    {
        #region Members

        private int? _defaultPaymentMeanId;
        private string _description;
        private int? _financialAccountId;
        private string _financialAccountName;
        private string _name;
        private List<PaymentMean> _paymentmeans;
        private bool _IsDefault;

        #endregion

        #region Property
        public bool IsDefault
        {
            get { return _IsDefault; }
            set { 
                if(_IsDefault != value)
                {
                    _IsDefault = value;
                    Notify("IsDefault");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public int? FinancialAccountId
        {
            get { return _financialAccountId; }
            set
            {
                if (_financialAccountId != value)
                {
                    _financialAccountId = value;
                    Notify("FinancialAccountId");
                }
            }
        }

        public int? DefaultPaymentMeanId
        {
            get { return _defaultPaymentMeanId; }
            set
            {
                if (_defaultPaymentMeanId != value)
                {
                    _defaultPaymentMeanId = value;
                    Notify("DefaultPaymentMeanId");
                }
            }
        }

        public string FinancialAccountName
        {
            get { return _financialAccountName; }
            set
            {
                if (_financialAccountName != value)
                {
                    _financialAccountName = value;
                    Notify("FinancialAccountName");
                }
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

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        #endregion

        #region Constructor

        public PaymentUsageVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public PaymentUsageVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            using (
                var paymentmeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMeans = paymentmeanService.GetAll();
                PaymentMeans.Insert(0, new PaymentMean {Id = 0, Name = string.Empty});
            }

            if (ObjectId > 0)
            {
                using (
                    var paymentusageService =
                        SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
                {
                    PaymentUsage paymentusage = paymentusageService.FetchById(ObjectId,
                                                                              new List<string>
                                                                                  {"PaymentMean", "FinancialAccount"});

                    Name = paymentusage.Name;
                    DefaultPaymentMeanId = paymentusage.PaymentMean == null ? 0 : paymentusage.PaymentMean.Id;
                    FinancialAccountId = paymentusage.FinancialAccountId;
                    FinancialAccountName = paymentusage.FinancialAccount == null
                                               ? ""
                                               : paymentusage.FinancialAccount.Name;
                    Description = paymentusage.Description;
                    IsDefault = paymentusage.IsDefault;
                }
            }
        }

        protected override void Create()
        {
            var paymentusage = new PaymentUsage
                                   {
                                       Name = Name,
                                       DefaultPaymentMeanId = DefaultPaymentMeanId,
                                       FinancialAccountId = FinancialAccountId,
                                       Description = Description,
                                       IsDefault = IsDefault
                                   };

            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                paymentusageService.AddNewPaymentUsage(paymentusage, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
            {
                PaymentUsage paymentusage = paymentusageService.GetById(ObjectId);

                if (paymentusage != null)
                {
                    paymentusage.Name = Name;
                    paymentusage.DefaultPaymentMeanId = DefaultPaymentMeanId == 0 ? null : DefaultPaymentMeanId;
                    paymentusage.FinancialAccountId = FinancialAccountId;
                    paymentusage.Description = Description;
                    paymentusage.IsDefault = IsDefault;

                    paymentusageService.UpdatePaymentUsage(paymentusage, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.PaymentUsageNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResDataDictSetting.PaymentUsageNameRequired);
            }
            
            if(IsDefault)
            {
                using (
                var paymentusageService =
                    SvcClientManager.GetSvcClient<PaymentUsageServiceClient>(SvcType.PaymentUsageSvc))
                {
                    List<PaymentUsage> paymentUsages = paymentusageService.GetAll();
                    if(paymentUsages != null && paymentUsages.Count > 0)
                    {
                        List<PaymentUsage> defaultUsageList = paymentUsages.Where(c => c.IsDefault).ToList();
                        if(defaultUsageList != null && defaultUsageList.Count > 0)
                        {
                            PaymentUsage defaultUsage = defaultUsageList.FirstOrDefault();
                            if (defaultUsage.Id != ObjectId)
                            {
                                if (MessageBox.Show("系统中已经存在默认的付款用途，是否继续？", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    defaultUsage.IsDefault = false;
                                    paymentusageService.UpdatePaymentUsage(defaultUsage, CurrentUser.Id);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        #endregion
    }
}