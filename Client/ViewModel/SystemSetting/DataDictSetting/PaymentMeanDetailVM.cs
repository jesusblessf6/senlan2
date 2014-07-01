using System;
using Client.Base.BaseClientVM;
using Client.PaymentMeanServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class PaymentMeanDetailVM : BaseVM
    {
        #region Member

        private string _description;
        private string _name;
        private bool _isForFundFlow = false;

        #endregion

        #region Property
        public bool IsForFundFlow
        {
            get { return _isForFundFlow; }
            set { 
                if(_isForFundFlow != value)
                {
                    _isForFundFlow = value;
                    Notify("IsForFundFlow");
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

        public PaymentMeanDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public PaymentMeanDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (
                    var paymentMeanService =
                        SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc))
                {
                    PaymentMean paymentmean = paymentMeanService.GetById(ObjectId);

                    if (paymentmean != null)
                    {
                        Name = paymentmean.Name;
                        Description = paymentmean.Description;
                        IsForFundFlow = paymentmean.IsForFundFlow;
                    }
                }
            }
        }

        protected override void Create()
        {
            var paymentmean = new PaymentMean
                                  {
                                      Name = Name,
                                      Description = Description,
                                      IsForFundFlow = IsForFundFlow
                                  };

            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                paymentMeanService.AddNewPaymentMean(paymentmean, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var paymentMeanService = SvcClientManager.GetSvcClient<PaymentMeanServiceClient>(SvcType.PaymentMeanSvc)
                )
            {
                PaymentMean paymentmean = paymentMeanService.GetById(ObjectId);
                if (paymentmean != null)
                {
                    paymentmean.Name = Name;
                    paymentmean.Description = Description;
                    paymentmean.IsForFundFlow = IsForFundFlow;
                    paymentMeanService.UpdatePaymentMean(paymentmean, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.PaymentMeanNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(Properties.Resources.PaymentMeanRequired);
            }

            return true;
        }

        #endregion
    }
}