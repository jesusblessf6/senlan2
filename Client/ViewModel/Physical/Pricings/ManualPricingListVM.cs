using System.Collections.Generic;
using System.Globalization;
using Client.Base.BaseClientVM;
using Client.PricingServiceReference;
using Client.UnpricingServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.QuotaServiceReference;
using System.Linq;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Physical.Pricings
{
    public class ManualPricingListVM : BaseVM
    {
        #region Property

        private List<Quota> _quotas;
        private string _condition;
        private List<object> _parameters;
        private bool _containCurrentUser;

        #endregion

        #region Property

        public List<Quota> Quotas
        {
            get { return _quotas; }
            set
            {
                _quotas = value;
                Notify("Quotas");
            }
        }

        public int PricingStatusId { get; set; }

        public int QuotaId { get; set; }

        public string QuotaNo { get; set; }

        public int BusinessPartnerId { get; set; }

        public int PricingSideId { get; set; }

        public int QuotaCount { get; set; }

        public int QuotaFrom { get; set; }

        public int QuotaTo { get; set; }

        public bool ContainCurrentUser
        {
            get { return _containCurrentUser; }
            set
            {
                if (_containCurrentUser != value)
                {
                    _containCurrentUser = value;
                    Notify("ContainCurrentUser");
                }
            }
        }
        #endregion

        #region Constructor

        public ManualPricingListVM(ManualPricingSearchConditions cons)
        {
            PricingStatusId = cons.PricingStatusId;
            QuotaId = cons.QuotaId;
            QuotaNo = cons.QuotaNo;
            BusinessPartnerId = cons.BusinessPartnerId;
            PricingSideId = cons.PricingSideId;
            ContainCurrentUser = cons.ContainCurrentUser;
            Init();
            LoadCount();
        }

        #endregion

        #region Method

        public void Init()
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

            _condition = "it.PricingType = @p1";
            _parameters = new List<object>{(int) PricingType.Manual};

            int i = 2;
            if (PricingStatusId > 0)
            {
                _condition += " and it.PricingStatus = @p" + i.ToString(CultureInfo.InvariantCulture);
                _parameters.Add(PricingStatusId);
                i++;
            }

            if (idList.Count > 0)
            {
                _condition += " and (";
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        _condition += "it.Contract.InternalCustomerId = @p" + i.ToString(CultureInfo.InvariantCulture);
                        _parameters.Add(idList[j]);
                        i++;
                    }
                    else
                    {
                        _condition += " or it.Contract.InternalCustomerId = @p" + i.ToString(CultureInfo.InvariantCulture);
                        _parameters.Add(idList[j]);
                        i++;
                    }
                }
                _condition += ")";
            }
            
            if (ContainCurrentUser)
            {
                _condition += " and it.CreatedBy = @p" + i.ToString(CultureInfo.InvariantCulture);
                _parameters.Add(CurrentUser.Id);
                i++;
            }

            //if (QuotaId > 0)
            //{
            //    _condition += " and it.Id = @p" + i.ToString(CultureInfo.InvariantCulture);
            //    _parameters.Add(QuotaId);
            //    i++;
            //}
            if(!string.IsNullOrEmpty(QuotaNo))
            {
                _condition += " and it.QuotaNo Like \'%" + QuotaNo + "%\'";
                _parameters.Add(QuotaNo);
                i++;
            }

            if (BusinessPartnerId > 0)
            {
                _condition += " and it.Contract.BPId = @p" + i.ToString(CultureInfo.InvariantCulture);
                _parameters.Add(BusinessPartnerId);
                i++;
            }

            if (PricingSideId > 0)
            {
                _condition += " and it.PricingSide = @p" + i.ToString(CultureInfo.InvariantCulture);
                _parameters.Add(PricingSideId);
            }
        }

        public void LoadCount()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                QuotaCount = quotaService.GetCount(_condition, _parameters);
            }
        }

        public void Load()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var quotas = quotaService.SelectByRangeWithOrder(_condition, _parameters, new SortCol{ByDescending = true, ColName = "Id"}, QuotaFrom, QuotaTo,
                                    new List<string> { "Pricings", "Unpricings", "Pricings.Currency", "Contract" });

                foreach(var q in quotas)
                {
                    FilterDeleted(q.Pricings);
                    FilterDeleted(q.Unpricings);
                    q.PricedQuantity = quotaService.GetPricedQuantity(q.Id);

                    FilterDeleted(q.Pricings);
                    FilterDeleted(q.Unpricings);
                }

                Quotas = quotas;
            }
        }

        public void DeletePricing(int id)
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                pricingService.RemoveById(id, CurrentUser.Id);
                var ps = pricingService.Query("it.RelPricingId = " + id, null);
                foreach (var pricing in ps)
                {
                    pricingService.RemoveById(pricing.Id, CurrentUser.Id);
                }
            }
        }

        public void DeleteUnpricing(int id)
        {
            using(var unpricingService = SvcClientManager.GetSvcClient<UnpricingServiceClient>(SvcType.UnpricingSvc))
            {
                unpricingService.RemoveById(id, CurrentUser.Id);
                var ups = unpricingService.Query("it.RelUnpricingId = " + id, null);
                foreach (var up in ups)
                {
                    unpricingService.RemoveById(up.Id, CurrentUser.Id);
                }
            }
        }

        public bool IsUnpricingEditable(int id)
        {
            var unpricings = Quotas.SelectMany(o => o.Unpricings).ToList();
            var up = unpricings.FirstOrDefault(o => o.Id == id);
            if(up == null || up.UnpricingId == null || up.UnpricingId == 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
