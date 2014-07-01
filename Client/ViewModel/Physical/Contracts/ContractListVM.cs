using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using Client.AttachmentServiceReference;
using Client.Base.BaseClientVM;
using Client.ContractServiceReference;
using Client.DocumentServiceReference;
using Client.Helper;
using Client.Properties;
using Client.QuotaServiceReference;
using Client.View.Physical.Contracts;
using Client.ViewModel.Console.ApprovalCenter;
using Client.ViewModel.PrintTemplate.DomesticContractTemplate;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Contracts
{
    public class ContractListVM : BaseVM
    {
        #region Member

        private decimal _totalQty;
        private decimal _totalAmount;
        private bool _isSelectAll;

        #endregion

        #region Property

        public string Title { get; set; }
        public List<Quota> Quotas { get; set; }
        public ListCollectionView QuotasView { get; set; }
        public ContractSearchConditions Conditions { get; set; }
        public int QuotaTotalCount { get; set; }
        public int QuotaFrom { get; set; }
        public int QuotaTo { get; set; }
        public string QueryStr { get; set; }
        public List<object> Parameters { get; set; }

        public decimal TotalQty
        {
            get { return Math.Round(_totalQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero); }

            set
            {
                if (_totalQty != value)
                {
                    _totalQty = value;
                    Notify("TotalQty");
                }
            }
        }

        public decimal TotalAmount
        {
            get { return Math.Round(_totalAmount, RoundRules.AMOUNT, MidpointRounding.AwayFromZero); }

            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    Notify("TotalAmount");
                }
            }
        }

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

        #endregion

        #region Constructor

        public ContractListVM(ContractSearchConditions conditions)
        {
            PropertyChanged += OnPropertyChanged;
            Initialize(conditions);
            LoadQuotaCount();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelectAll")
            {
                foreach (var quota in Quotas)
                {
                    if (quota.Printable)
                    {
                        quota.IsSelected = IsSelectAll;
                    }
                }
            }
        }

        #endregion

        #region Method

        /// <summary>
        ///     Initialize the contract list VM:
        ///     1. Build QueryStr and Parameters
        ///     2. Set title
        /// </summary>
        /// <param name="conditions"></param>
        public void Initialize(ContractSearchConditions conditions)
        {
            Conditions = conditions;

            //build up the query string
            Parameters = new List<object>();
            var sb = new StringBuilder();

            //todo: ???
            sb.Append(Conditions.IsDraft
                          ? "((it.IsDraft = true and it.ApprovalId is null) or it.Contract.IsDraft = true)"
                          : "(it.ApprovalId is not null or it.IsDraft = false) and it.Contract.IsDraft <> true");

            sb.AppendFormat(" and it.Contract.ContractType = @p1");
            Parameters.Add(Conditions.ContractType);

            int i = 2;

            if (Conditions.SupplierId > 0)
            {
                sb.AppendFormat(" and it.Contract.BPId = @p{0}", i++);
                Parameters.Add(Conditions.SupplierId);
            }

            if (Conditions.TradeTypeId > 0)
            {
                sb.AppendFormat(" and it.Contract.TradeType = @p{0}", i++);
                Parameters.Add(Conditions.TradeTypeId);
            }

            if (Conditions.StartDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate >= @p{0}", i++);
                Parameters.Add(Conditions.StartDate);
            }

            if (Conditions.EndDate != null)
            {
                sb.AppendFormat(" and it.ImplementedDate <= @p{0}", i++);
                Parameters.Add(Conditions.EndDate);
            }

            if (Conditions.CommodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i++);
                Parameters.Add(Conditions.CommodityId);
            }

            if (Conditions.IsOnlyCurrentUser)
            {
                sb.AppendFormat(" and it.CreatedBy = @p{0}", i++);
                Parameters.Add(CurrentUser.Id);
            }

            if (Conditions.InternalCustomerId > 0)
            {
                sb.AppendFormat(" and it.Contract.InternalCustomerId = @p{0}", i++);
                Parameters.Add(Conditions.InternalCustomerId);
            }
            else
            {

                if (Conditions.InternalIdList.Count > 0)
                {
                    sb.AppendFormat(" and (");
                    for (int j = 0; j < Conditions.InternalIdList.Count; j++)
                    {
                        if (j == 0)
                        {
                            sb.AppendFormat("it.Contract.InternalCustomerId = @p{0}", i++);
                            Parameters.Add(Conditions.InternalIdList[j]);
                        }
                        else
                        {
                            sb.AppendFormat(" or it.Contract.InternalCustomerId = @p{0}", i++);
                            Parameters.Add(Conditions.InternalIdList[j]);
                        }
                    }
                    sb.AppendFormat(")");

                }
            }

            if (Conditions.UDFId != null && Conditions.UDFId > 0)
            {
                sb.AppendFormat(" and it.Contract.UDFId = @p{0}", i++);
                Parameters.Add(Conditions.UDFId);
            }

            if (!string.IsNullOrEmpty(Conditions.SelectExContractNo))
            {
                sb.AppendFormat(" and it.Contract.ExContractNo like @p{0}", i++);
                Parameters.Add("%" + Conditions.SelectExContractNo.Trim() + "%");
            }

            if (!string.IsNullOrEmpty(Conditions.QuotaNo))
            {
                sb.AppendFormat(" and it.QuotaNo like @p{0}", i++);
                Parameters.Add("%" + Conditions.QuotaNo.Trim() + "%");
            }

            if (Conditions.CreaterId > 0)
            {
                sb.AppendFormat(" and it.CreatedBy = @p{0}", i);
                Parameters.Add(Conditions.CreaterId);
            }

            if (conditions.IsOnlyHideRelQuotas)
            {
                sb.Append(" and it.IsAutoGenerated = False ");
            }

            QueryStr = sb.ToString();

            //Set title
            Title = Conditions.ContractType == (int)ContractType.Purchase
                        ? ResContract.PurchaseContractQuota
                        : ResContract.SalesContractQuota;
        }

        /// <summary>
        ///     Load Quota total count
        /// </summary>
        public void LoadQuotaCount()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                QuotaTotalCount = quotaService.FetchCount(QueryStr, Parameters, new List<string> { "Contract" });
            }
        }

        /// <summary>
        ///     Load Quotas for current page
        /// </summary>
        public void LoadQuotas()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var eagerLoadForFilter = new List<string>
                                    {
                                        "Contract",
                                    };
                var eagerLoadForAppending = new List<string>
                                    {
                                        "Contract.ContractUDF",
                                        "Currency",
                                        "Contract.BusinessPartner",
                                        "Contract.InternalCustomer",
                                        "Approval",
                                        "Approval.ApprovalStages",
                                        "Approval.ApprovalStages.ApprovalUser",
                                        "Warehouse",
                                        "Brand",
                                        "Commodity",
                                        "QuotaBrandRels",
                                        "QuotaBrandRels.Warehouse",
                                        "QuotaBrandRels.Brand"
                                    };
                //List<Quota> quotas = quotaService.SelectByRangeWithOrder(QueryStr, Parameters,
                //                                                         new SortCol
                //                                                             {
                //                                                                 ByDescending = true,
                //                                                                 ColName = "Contract.SignDate"
                //                                                             },
                //                                                         QuotaFrom,
                //                                                         QuotaTo,
                //                                                         eagerLoad);
                SortCol createdDateSort = new SortCol
                                        {
                                            ByDescending = false,
                                            ColName = "ImplementedDate"
                                        };
                SortCol relTransSort = new SortCol
                                        {
                                            ByDescending = false,
                                            ColName = "Created"
                                        };
                List<SortCol> sortCols = new List<SortCol>();
                sortCols.Add(relTransSort);
                sortCols.Add(createdDateSort);
                List<Quota> quotas = quotaService.SelectByRangeWithMultiOrderLazyLoad(QueryStr, Parameters,
                                                                                      sortCols, QuotaFrom, QuotaTo,
                                                                                      eagerLoadForFilter, eagerLoadForAppending);

                foreach (Quota quota in quotas)
                {
                    quota.CanBeSplit = false;
                    if (quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade && quota.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        if (quota.QuotaGroupId.HasValue && !quota.RelQuotaId.HasValue && quota.QuotaGroupId.Value == quota.Id)
                        {
                            quota.CanBeSplit = true;
                        }
                    }
                    //FilterDeleted(quota.Pricings);
                    if (quota.Approval != null)
                        FilterDeleted(quota.Approval.ApprovalStages);
                    //FilterDeleted(quota.QuotaBrandRels);

                    string passed, notPassed;
                    if (quota.PricingType == (int)PricingType.Fixed)
                    {
                        quota.Price = quota.FinalPrice ?? 0;
                        quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                    }
                    else if (quota.PricingType == (int)PricingType.Manual)
                    {
                        quota.StrPrice = Resources.Detail;
                    }
                    else if (quota.PricingType == (int)PricingType.Average)
                    {
                        //平均价点价
                        quota.Price = quota.FinalPrice ?? 0;
                        quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                    }

                    if (quota.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || quota.Approval == null ||
                        quota.Approval.ApprovalStages == null) continue;
                    FilterDeleted(quota.Approval.ApprovalStages);

                    List<ApprovalStage> stages = quota.Approval.ApprovalStages.ToList();
                    ApprovalCenterHomeVM.ParseApprovalDetailString(stages, quota.ApprovalStageIndex ?? 0, out passed,
                                                                   out notPassed);

                    if (quota.ApproveStatus == (int)ApproveStatus.Approved)
                    {
                        quota.CustomerStrField1 = passed + notPassed;
                        quota.CustomerStrField2 = string.Empty;
                    }
                    else
                    {
                        quota.CustomerStrField1 = passed;
                        quota.CustomerStrField2 = notPassed;
                    }
                    
                }

                IsSelectAll = false;
                Quotas = quotas;
                decimal totalQty;
                //TotalQty = quotaService.GetQuotaSumQty(QueryStr, Parameters, eagerLoadForFilter);
                TotalAmount = quotaService.GetQuotaSumAmount(out totalQty,QueryStr, Parameters, eagerLoadForFilter);
                TotalQty = totalQty;
                QuotasView = new ListCollectionView(quotas);
                if (QuotasView.GroupDescriptions != null)
                    QuotasView.GroupDescriptions.Add(new PropertyGroupDescription("Contract.ContractNo"));
            }
        }

        public void GetAllQuotas()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                var eagerLoadForAppending = new List<string>
                                    {
                                        "Contract",
                                        "Contract.ContractUDF",
                                        "Currency",
                                        "Contract.BusinessPartner",
                                        "Contract.InternalCustomer",
                                        "Approval",
                                        "Approval.ApprovalStages",
                                        "Approval.ApprovalStages.ApprovalUser",
                                        "Warehouse",
                                        "Brand",
                                        "Commodity",
                                        "QuotaBrandRels",
                                        "QuotaBrandRels.Warehouse",
                                        "QuotaBrandRels.Brand"
                                    };
                List<Quota> quotas = quotaService.Select(QueryStr, Parameters, eagerLoadForAppending);
                quotas = quotas.OrderBy(q => q.ImplementedDate).ThenBy(q=>q.Created).ToList();
                foreach (Quota quota in quotas)
                {
                    quota.CanBeSplit = false;
                    if (quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade && quota.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        if (quota.QuotaGroupId.HasValue && !quota.RelQuotaId.HasValue && quota.QuotaGroupId.Value == quota.Id)
                        {
                            quota.CanBeSplit = true;
                        }
                    }
                    //FilterDeleted(quota.Pricings);
                    if (quota.Approval != null)
                        FilterDeleted(quota.Approval.ApprovalStages);
                    //FilterDeleted(quota.QuotaBrandRels);

                    string passed, notPassed;
                    if (quota.PricingType == (int)PricingType.Fixed)
                    {
                        quota.Price = quota.FinalPrice ?? 0;
                        quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                    }
                    else if (quota.PricingType == (int)PricingType.Manual)
                    {
                        quota.StrPrice = Resources.Detail;
                    }
                    else if (quota.PricingType == (int)PricingType.Average)
                    {
                        //平均价点价
                        quota.Price = quota.FinalPrice ?? 0;
                        quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                    }

                    if (quota.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || quota.Approval == null ||
                        quota.Approval.ApprovalStages == null) continue;
                    FilterDeleted(quota.Approval.ApprovalStages);

                    List<ApprovalStage> stages = quota.Approval.ApprovalStages.ToList();
                    ApprovalCenterHomeVM.ParseApprovalDetailString(stages, quota.ApprovalStageIndex ?? 0, out passed,
                                                                   out notPassed);

                    if (quota.ApproveStatus == (int)ApproveStatus.Approved)
                    {
                        quota.CustomerStrField1 = passed + notPassed;
                        quota.CustomerStrField2 = string.Empty;
                    }
                    else
                    {
                        quota.CustomerStrField1 = passed;
                        quota.CustomerStrField2 = notPassed;
                    }

                }
                Quotas = quotas;
                //TotalQty = quotaService.GetQuotaSumQty(QueryStr, Parameters, eagerLoadForFilter);
                //QuotasView = new ListCollectionView(quotas);
                //if (QuotasView.GroupDescriptions != null)
                //    QuotasView.GroupDescriptions.Add(new PropertyGroupDescription("Contract.ContractNo"));
            }
        }

        /// <summary>
        ///     judge if Quota could be edited according to the approve status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool QuotaCanEditWithApproveStatus(int id)
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.GetById(id);
                //if (quota.ApproveStatus == (int)ApproveStatus.InApprove ||
                //    quota.ApproveStatus == (int)ApproveStatus.Approved)
                if(quota.ApproveStatus == (int)ApproveStatus.InApprove)
                {
                    return false;
                }

                return true;
            }
        }

        public bool QuotaCanEditWithRel(int id)
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.SelectById(new List<string> { "Contract" }, id);
                if (quota.RelQuotaId.HasValue && quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    return false;
                }

                return true;
            }
        }

        public bool QuotaCanEditWithCopyContract(int id)
        {
            return true;
        }

        /// <summary>
        ///     Remove quota by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            using (
                var contractService =
                    SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {

                contractService.RemoveQuotaById(id, CurrentUser.Id);
            }
        }

        /// <summary>
        ///     Create different page according the quota's type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Page CreatePageByQuota(int id)
        {
            Quota quota = Quotas.SingleOrDefault(o => o.Id == id);
            if (quota == null)
                return null;

            Page page = null;
            var tradeType = (TradeType)quota.Contract.TradeType;
            var contractType = (ContractType)quota.Contract.ContractType;
            string pageName = EnumHelper.GetDescriptionByCulture(contractType) +
                              EnumHelper.GetDescriptionByCulture(tradeType);

            switch (tradeType)
            {
                case TradeType.ShortForeignTrade:
                    page = new ShortContractDetail(tradeType, contractType, quota.Contract.Id,
                                                   PageMode.EditMode, pageName);
                    break;

                case TradeType.ShortDomesticTrade:
                    page = new ShortContractDetail(tradeType, contractType, quota.Contract.Id,
                                                   PageMode.EditMode, pageName);
                    break;

                case TradeType.LongForeignTrade:
                    page = new LongContractDetail(tradeType, contractType,
                                                  quota.Contract.Id, PageMode.EditMode, pageName);
                    break;

                case TradeType.LongDomesticTrade:
                    page = new LongContractDetail(tradeType, contractType,
                                                  quota.Contract.Id, PageMode.EditMode, pageName);
                    break;
            }

            return page;
        }

        /// <summary>
        ///     Judge whether the contract has attachments
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        public bool HasAttachment(int quotaId)
        {
            bool flag;
            int id;
            using (var documentService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                id = documentService.GetByTableCode("Contract").Id;
            }

            using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                )
            {
                const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2";
                var par = new List<object> { quotaId, id };
                List<Attachment> attachments = attachmentService.Query(queryStr, par);
                flag = attachments.Count > 0;
            }
            return flag;
        }

        #endregion

        public void PrintSelected()
        {
            var quotas = Quotas.Where(o => o.IsSelected);
            var toPrints = quotas.Select(o => o.ContractId).Distinct();
            foreach (var id in toPrints)
            {
                var reportVM = new PrintContractTemplateVM(id);
                var dataSources = new Dictionary<string, object> { { "Head", reportVM.HeaderList }, { "Lines", reportVM.LineList } };
                var printHelper = new PrintHelper(dataSources, reportVM.PathName, reportVM.FileName);
                printHelper.Run();
            }
        }
    }
}