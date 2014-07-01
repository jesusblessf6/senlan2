using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.QuotaServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class QuotaStatusChangeVM : BaseVM
    {
        #region Property

        private int _selectedDeliveryStatus;
        private int _selectedFinancialStatus;
        private List<EnumItem> _statuses;

        public List<EnumItem> Statuses
        {
            get { return _statuses; }
            set
            {
                _statuses = value;
                Notify("Statuses");
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

        #endregion

        #region Constructor

        public QuotaStatusChangeVM(int quotaId)
        {
            ObjectId = quotaId;
            Initialize();
        }

        #endregion

        #region Method

        private void Initialize()
        {
            _statuses = EnumHelper.GetEnumList<CompleteStatus>();

            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.GetById(ObjectId);

                _selectedFinancialStatus = quota.FinanceStatus
                                               ? (int) CompleteStatus.Complete
                                               : (int) CompleteStatus.NotComplete;
                _selectedDeliveryStatus = quota.DeliveryStatus
                                              ? (int) CompleteStatus.Complete
                                              : (int) CompleteStatus.NotComplete;
            }
        }

        protected override void Update()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.GetById(ObjectId);
                quota.FinanceStatus = SelectedFinancialStatus == (int) CompleteStatus.Complete;
                quota.DeliveryStatus = SelectedDeliveryStatus == (int) CompleteStatus.Complete;
                //quotaService.UpdateExisted(quota, CurrentUser.Id);
                quotaService.UpdateQuotaStatusWithVerifiedQuantityByQuotaId(quota, CurrentUser.Id);
            }
        }

        public override bool Validate()
        {
            return true;
        }

        #endregion
    }
}