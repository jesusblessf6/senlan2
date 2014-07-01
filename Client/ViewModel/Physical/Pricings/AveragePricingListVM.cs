using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.QuotaServiceReference;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Physical.Pricings
{
    public class AveragePricingListVM : BaseVM
    {
        #region Member

        private int _quotaFrom;
        //private int _unpricingId;
        private int _quotaTo;
        private int _quotasTotleCount;
        private List<object> _parameters;
        private string _queryStr;

        private List<Quota> _quotas;
        private bool _containCurrentUser;

        #endregion

        #region Properties

        public AveragePricingSearchConditions APSC { get; set; }

        public List<Quota> Quotas
        {
            get { return _quotas; }
            set
            {
                if (_quotas != value)
                {
                    _quotas = value;
                    Notify("Quotas");
                }
            }
        }

        //public int UnPricingId
        //{
        //    get { return _unpricingId; }
        //    set
        //    {
        //        if (_unpricingId != value)
        //        {
        //            _unpricingId = value;
        //            Notify("UnPricingId");
        //        }
        //    }
        //}

        public int QuotasTotleCount
        {
            get { return _quotasTotleCount; }
            set
            {
                if (_quotasTotleCount != value)
                {
                    _quotasTotleCount = value;
                    Notify("QuotasTotleCount");
                }
            }
        }

        public int QuotaFrom
        {
            get { return _quotaFrom; }
            set
            {
                if (_quotaFrom != value)
                {
                    _quotaFrom = value;
                    Notify("QuotaFrom");
                }
            }
        }

        public int QuotaTo
        {
            get { return _quotaTo; }
            set
            {
                if (_quotaTo != value)
                {
                    _quotaTo = value;
                    Notify("QuotaTo");
                }
            }
        }

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

        public AveragePricingListVM(AveragePricingSearchConditions c)
        {
            APSC = c;
            Init();
        }

        #endregion

        #region Method

        public void Init()
        {
            BuildQueryStrAndParams(out _queryStr, out _parameters);
            InitPage();
        }

        private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
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

            parameters = new List<object>();
            var sb = new StringBuilder();
            int num = 1;
            sb.Append("(it.ApproveStatus=" + Convert.ToInt32(ApproveStatus.NoApproveNeeded) +
                        " or it.ApproveStatus=" + Convert.ToInt32(ApproveStatus.Approved) +
                        ") and it.PricingType=" + Convert.ToInt32(PricingType.Average) + "");

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
                        sb.AppendFormat("it.Contract.InternalCustomerId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                    else
                    {
                        sb.AppendFormat(" or it.Contract.InternalCustomerId = @p{0}", num++);
                        parameters.Add(idList[j]);
                    }
                }
                sb.Append(")");
            }

            if (APSC.ContainCurrentUser)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CreatedBy = @p{0} ", num++);
                parameters.Add(CurrentUser.Id);
            }

            if (APSC.Status)
            {
                if (APSC.PricingStatusId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.PricingStatus <> @p{0} ", num++);
                    parameters.Add(APSC.PricingStatusId);
                }
            }
            else if (APSC.Status == false)
            {
                if (APSC.PricingStatusId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.PricingStatus = @p{0} ", num++);
                    parameters.Add(APSC.PricingStatusId);
                }
            }
            if (APSC.BusinessPartnerId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.BPId = @p{0} ", num++);
                parameters.Add(APSC.BusinessPartnerId);
            }
            if (APSC.InternalCustomerId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.Contract.InternalCustomerId = @p{0} ", num++);
                parameters.Add(APSC.InternalCustomerId);
            }
            if (APSC.CommodityId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.CommodityId = @p{0} ", num++);
                parameters.Add(APSC.CommodityId);
            }
            if (APSC.PricingBasisId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PricingBasis = @p{0} ", num++);
                parameters.Add(APSC.PricingBasisId);
            }
            if (APSC.StartDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PricingStartDate >= @p{0} ", num++);
                parameters.Add(APSC.StartDate.Value);
            }
            if (APSC.EndDate.HasValue)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.AppendFormat("it.PricingEndDate <= @p{0} ", num);
                parameters.Add(APSC.EndDate.Value.AddDays(1).AddMinutes(-1));
            }
            queryStr = sb.ToString();
        }

        private void InitPage()
        {
            LoadQuotasCount();
        }

        public void LoadQuotasCount()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);
                _quotasTotleCount = quotaService.GetCount(queryStr, parameters);
            }
        }

        public void LoadQuotas()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                string queryStr;
                List<object> parameters;
                BuildQueryStrAndParams(out queryStr, out parameters);

                Quotas = quotaService.SelectByRangeWithOrder(queryStr, parameters,
                                                    new SortCol { ByDescending = true, ColName = "Id" },
                                                    QuotaFrom, QuotaTo,
                                                    new List<string>
                                                                            {
                                                                                "Commodity",
                                                                                "Contract",
                                                                                "Contract.BusinessPartner",
                                                                                "Contract.InternalCustomer",
                                                                                "Pricings"
                                                                            });


                #region 计算最终价格
                foreach (Quota upr in Quotas)
                {
                    TrackableCollection<Pricing> pricings = upr.Pricings;
                    decimal result = pricings.Sum(pr => pr.FinalPrice ?? 0);
                    upr.FinalPrice = result;
                }
                #endregion
            }
        }

        #endregion
    }
}