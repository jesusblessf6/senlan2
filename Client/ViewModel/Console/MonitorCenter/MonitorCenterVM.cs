using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.QuotaServiceReference;
using Utility.ServiceManagement;
using DBEntity;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Console.MonitorCenter
{
    public class MonitorCenterVM : BaseVM
    {
        #region Member

        private List<PricingMonitorLineVM> _pricingLines;

        #endregion

        #region Property

        public List<PricingMonitorLineVM> PricingLines
        {
            get { return _pricingLines; }
            set 
            { 
                _pricingLines = value;
                Notify("PricingLines");
            }
        }

        #endregion

        #region Constructor

        public MonitorCenterVM()
        {
            _pricingLines = new List<PricingMonitorLineVM>();
        }

        #endregion

        #region Method

        public void LoadPircingMonitor()
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

            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var quotas = quotaService.GetQuotasApproachingPricingEnd();
                var finalQuotas = new List<Quota>();
                foreach (int id in idList)
                {
                    var quotaList = quotas.Where(c => c.Contract.InternalCustomerId == id).ToList();
                    finalQuotas.AddRange(quotaList);
                }
                foreach (var quota in finalQuotas)
                {
                    var pricedQty = quota.Pricings.Where(o => !o.IsDeleted && !o.IsDraft).Sum(o => o.PricingQuantity);
                    var line = new PricingMonitorLineVM
                        {
                            QuotaNo = quota.QuotaNo,
                            BPName = quota.Contract.BusinessPartner.ShortName,
                            QuotaQuantity = quota.Quantity ?? 0,
                            UnpricedQuantity = (quota.Quantity ?? 0) - ((decimal)pricedQty),
                            PricingTypeId = quota.PricingType,
                            StartDate = quota.PricingStartDate,
                            EndDate = quota.PricingEndDate,
                            InternalCustomerName = quota.Contract.InternalCustomer.ShortName,
                            DaysRemain = ((quota.PricingEndDate ?? SqlDateTime.MaxValue.Value) - DateTime.Today).Days
                        };
                    _pricingLines.Add(line);
                }

                _pricingLines = _pricingLines.OrderBy(o => o.DaysRemain).ToList();
            }
        }

        #endregion
    }
}
