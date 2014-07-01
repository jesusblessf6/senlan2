using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.Properties;
using Client.QuotaServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Contracts
{
    public class QuotaDetailViewVM : BaseVM
    {
        #region Member

        private List<CommercialInvoice> _commercialInvoiceList;
        private List<Delivery> _deliveryList;
        private string _deliveryTypeValue;
        private List<FundFlow> _fundFlowList;
        private List<LetterOfCredit> _letterOfCreditList;
        private List<PaymentRequest> _paymentRequestList;
        private List<Quota> _quotaList;
        private List<VATInvoiceLine> _vatInvoiceLineList;
        private List<VATInvoice> _vatInvoiceList;
        private List<WarehouseIn> _warehouseInList;
        private bool _warehouseInVisible;
        private List<WarehouseOut> _warehouseOutList;
        private bool _warehouseOutVisible;
        private string _warehouseTypeValue;

        #region 合计

        private string _totalGrossWeight;
        private string _totalNetWeight;
        private string _totalOpenQty;
        private string _totalVerQty;
        private string _totalWarehouseQty;

        #endregion

        #endregion

        #region Property

        public List<FundFlow> FundFlowList
        {
            get { return _fundFlowList; }
            set
            {
                if (_fundFlowList != value)
                {
                    _fundFlowList = value;
                    Notify("FundFlowList");
                }
            }
        }

        public string TotalOpenQty
        {
            get { return _totalOpenQty; }
            set
            {
                if (_totalOpenQty != value)
                {
                    _totalOpenQty = value;
                    Notify("TotalOpenQty");
                }
            }
        }

        public string TotalWarehouseQty
        {
            get { return _totalWarehouseQty; }
            set
            {
                if (_totalWarehouseQty != value)
                {
                    _totalWarehouseQty = value;
                    Notify("TotalWarehouseQty");
                }
            }
        }

        public string TotalVerQty
        {
            get { return _totalVerQty; }
            set
            {
                if (_totalVerQty != value)
                {
                    _totalVerQty = value;
                    Notify("TotalVerQty");
                }
            }
        }

        public string TotalGrossWeight
        {
            get { return _totalGrossWeight; }
            set
            {
                if (_totalGrossWeight != value)
                {
                    _totalGrossWeight = value;
                    Notify("TotalGrossWeight");
                }
            }
        }

        public string TotalNetWeight
        {
            get { return _totalNetWeight; }
            set
            {
                if (_totalNetWeight != value)
                {
                    _totalNetWeight = value;
                    Notify("TotalNetWeight");
                }
            }
        }

        public List<VATInvoiceLine> VATInvoiceLineList
        {
            get { return _vatInvoiceLineList; }
            set
            {
                if (_vatInvoiceLineList != value)
                {
                    _vatInvoiceLineList = value;
                    Notify("VATInvoiceLineList");
                }
            }
        }

        public bool WarehouseOutVisible
        {
            get { return _warehouseOutVisible; }
            set
            {
                if (_warehouseOutVisible != value)
                {
                    _warehouseOutVisible = value;
                    Notify("WarehouseOutVisible");
                }
            }
        }

        public bool WarehouseInVisible
        {
            get { return _warehouseInVisible; }
            set
            {
                if (_warehouseInVisible != value)
                {
                    _warehouseInVisible = value;
                    Notify("WarehouseInVisible");
                }
            }
        }

        public string WarehouseTypeValue
        {
            get { return _warehouseTypeValue; }
            set
            {
                if (_warehouseTypeValue != value)
                {
                    _warehouseTypeValue = value;
                    Notify("WarehouseTypeValue");
                }
            }
        }

        public string DeliveryTypeValue
        {
            get { return _deliveryTypeValue; }
            set
            {
                if (_deliveryTypeValue != value)
                {
                    _deliveryTypeValue = value;
                    Notify("DeliveryTypeValue");
                }
            }
        }

        public List<Quota> QuotaList
        {
            get { return _quotaList; }
            set
            {
                if (_quotaList != value)
                {
                    _quotaList = value;
                    Notify("QuotaList");
                }
            }
        }

        public List<Delivery> DeliveryList
        {
            get { return _deliveryList; }
            set
            {
                if (_deliveryList != value)
                {
                    _deliveryList = value;
                    Notify("DeliveryList");
                }
            }
        }

        public List<WarehouseIn> WarehouseInList
        {
            get { return _warehouseInList; }
            set
            {
                if (_warehouseInList != value)
                {
                    _warehouseInList = value;
                    Notify("WarehouseInList");
                }
            }
        }

        public List<WarehouseOut> WarehouseOutList
        {
            get { return _warehouseOutList; }
            set
            {
                if (_warehouseOutList != value)
                {
                    _warehouseOutList = value;
                    Notify("WarehouseOutList");
                }
            }
        }

        public List<CommercialInvoice> CommercialInvoiceList
        {
            get { return _commercialInvoiceList; }
            set
            {
                if (_commercialInvoiceList != value)
                {
                    _commercialInvoiceList = value;
                    Notify("CommercialInvoiceList");
                }
            }
        }

        public List<PaymentRequest> PaymentRequestList
        {
            get { return _paymentRequestList; }
            set
            {
                if (_paymentRequestList != value)
                {
                    _paymentRequestList = value;
                    Notify("PaymentRequestList");
                }
            }
        }

        public List<LetterOfCredit> LetterOfCreditList
        {
            get { return _letterOfCreditList; }
            set
            {
                if (_letterOfCreditList != value)
                {
                    _letterOfCreditList = value;
                    Notify("LetterOfCreditList");
                }
            }
        }

        public List<VATInvoice> VATInvoiceList
        {
            get { return _vatInvoiceList; }
            set
            {
                if (_vatInvoiceList != value)
                {
                    _vatInvoiceList = value;
                    Notify("VATInvoiceList");
                }
            }
        }

        #endregion

        public QuotaDetailViewVM(int id)
        {
            ObjectId = id;
            GetData();
            GetTotalQty();
        }

        #region Method

        public void GetData()
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                const string str = "it.id = @p1";
                var parameters = new List<object> { ObjectId };
                QuotaList = quotaService.Select(str, parameters, new List<string>
                                                                     {
                                                                         "Contract",
                                                                         "Contract.ContractUDF",
                                                                         "Currency",
                                                                         "Contract.BusinessPartner",
                                                                         "Contract.InternalCustomer",
                                                                         "Approval",
                                                                         "Pricings",
                                                                         "Approval.ApprovalStages",
                                                                         "Approval.ApprovalStages.ApprovalUser",
                                                                         "Warehouse",
                                                                         "Brand",
                                                                         "Commodity",
                                                                         "QuotaBrandRels",
                                                                         "QuotaBrandRels.Brand",
                                                                         "WarehouseOuts",
                                                                         "WarehouseOuts.WarehouseOutLines",
                                                                         "Deliveries.DeliveryLines.WarehouseInLines",
                                                                         "Deliveries.DeliveryLines.CommodityType",
                                                                         "Deliveries.DeliveryLines.Specification",
                                                                         "Deliveries.DeliveryLines.Brand",
                                                                         "Deliveries.DeliveryLines",
                                                                         "Deliveries.DeliveryLines.WarehouseInLines.WarehouseIn",
                                                                         "Deliveries",
                                                                         "Deliveries.Warehouse",
                                                                         "CommercialInvoices",
                                                                         "CommercialInvoices.Currency",
                                                                         "VATInvoiceLines",
                                                                         "VATInvoiceLines.VATInvoice",
                                                                         "LetterOfCredits",
                                                                         "LetterOfCredits.Bank",
                                                                         "LetterOfCredits.Bank1",
                                                                         "VATInvoiceLines.VATInvoice.BusinessPartner",
                                                                         "VATInvoiceLines.VATInvoice.BusinessPartner1",
                                                                         "VATInvoiceLines.VATInvoiceRequestLine",
                                                                         "VATInvoiceLines.Quota",
                                                                         "FundFlows",
                                                                         "FundFlows.BusinessPartner",
                                                                         "FundFlows.InternalCustomer",
                                                                         "FundFlows.Currency",
                                                                         "FundFlows.FinancialAccount"
                                                                     });
                if (QuotaList.Count > 0)
                {
                    Quota quota = QuotaList[0];
                    FilterDeleted(quota.Deliveries);
                    //FilterDeleted(quota.Deliveries.);
                    if (quota.Contract.ContractType == (int)ContractType.Purchase) //采购批次 提单对应入库
                    {
                        DeliveryTypeValue = "提货单";
                        WarehouseTypeValue = "入库";
                        WarehouseInVisible = true;
                        WarehouseOutVisible = false;
                        if (quota.Deliveries.Count > 0)
                        {
                            DeliveryList = quota.Deliveries.Where(c => c.IsDeleted == false && (c.WarrantId == null || (c.WarrantId.HasValue && c.DeliveryType == (int)DeliveryType.ExternalTDWW))).ToList();
                            var inLines = new List<WarehouseInLine>();
                            foreach (Delivery delivery in DeliveryList)
                            {
                                foreach (DeliveryLine deliveryLine in delivery.DeliveryLines)
                                {
                                    inLines.AddRange(
                                        deliveryLine.WarehouseInLines.Where(c => c.IsDeleted == false).ToList());
                                }
                            }

                            var inList = inLines.Select(inLine => inLine.WarehouseIn).ToList();
                            WarehouseInList = inList.Distinct().ToList();
                        }
                    }
                    else
                    {
                        DeliveryTypeValue = "发货单";
                        WarehouseTypeValue = "出库";
                        WarehouseInVisible = false;
                        WarehouseOutVisible = true;
                        if (quota.Deliveries.Count > 0)
                        {
                            DeliveryList = new List<Delivery>();
                            List<Delivery> deliveryList = quota.Deliveries.Where(c => c.IsDeleted == false).ToList();
                            foreach (Delivery delivery in deliveryList)
                            {
                                FilterDeleted(delivery.DeliveryLines);
                                DeliveryList.Add(delivery);
                            }
                        }
                        WarehouseOutList = quota.WarehouseOuts.Where(c => c.IsDeleted == false).ToList();
                    }
                    FundFlowList = quota.FundFlows.Where(c => c.IsDeleted == false).ToList();
                    CommercialInvoiceList = quota.CommercialInvoices.Where(c => c.IsDeleted == false).ToList();
                    LetterOfCreditList = quota.LetterOfCredits.Where(c => c.IsDeleted == false).ToList();

                    VATInvoiceLineList = quota.VATInvoiceLines.Where(c => c.IsDeleted == false).ToList();
                    if (quota.PricingType == (int)PricingType.Fixed)
                    {
                        Pricing firstOrDefault = quota.Pricings.FirstOrDefault();
                        if (firstOrDefault != null)
                        {
                            quota.Price = firstOrDefault.FinalPrice ?? 0;
                            quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                        }
                    }
                    else if (quota.PricingType == (int)PricingType.Manual)
                    {
                        quota.StrPrice = Resources.Detail;
                    }
                    else if (quota.PricingType == (int)PricingType.Average)
                    {
                        //平均价点价
                        Pricing firstOrDefault = quota.Pricings.FirstOrDefault();
                        if (firstOrDefault != null)
                        {
                            quota.Price = firstOrDefault.FinalPrice ?? 0;
                            quota.StrPrice = quota.Price.ToString(RoundRules.STR_PRICE);
                        }
                    }
                }
            }
        }

        public void GetTotalQty()
        {
            decimal totalGrossWeight = 0;
            decimal totalNetWeight = 0;
            decimal totalVerQty = 0;
            decimal totalWarehouseQty = 0;
            decimal totalVaTinvoiceQty = 0;
            if (DeliveryList != null && DeliveryList.Count > 0)
            {
                foreach (Delivery delivery in DeliveryList)
                {
                    foreach (DeliveryLine line in delivery.DeliveryLines)
                    {
                        if (line.GrossWeight.HasValue)
                        {
                            totalGrossWeight += line.GrossWeight.Value;
                        }
                        if (line.NetWeight.HasValue)
                        {
                            totalNetWeight += line.NetWeight.Value;
                        }
                        if (line.VerifiedWeight.HasValue)
                        {
                            totalVerQty += line.VerifiedWeight.Value;
                        }
                    }
                }
            }

            if (WarehouseInList != null && WarehouseInList.Count > 0)
            {
                totalWarehouseQty =
                    WarehouseInList.Sum(
                        c =>
                        c.WarehouseInLines.Where(a => a.IsDeleted == false && a.VerifiedQuantity.HasValue)
                         .Sum(o => o.VerifiedQuantity.Value));
            }

            if (WarehouseOutList != null && WarehouseOutList.Count > 0)
            {
                totalWarehouseQty =
                    WarehouseOutList.Sum(
                        c =>
                        c.WarehouseOutLines.Where(a => a.IsDeleted == false && a.VerifiedQuantity.HasValue)
                         .Sum(o => o.VerifiedQuantity.Value));
            }

            if (VATInvoiceLineList != null && VATInvoiceLineList.Count > 0)
            {
                totalVaTinvoiceQty =
                    VATInvoiceLineList.Where(a => a.IsDeleted == false && a.VATInvoiceQuantity.HasValue)
                                      .Sum(o => o.VATInvoiceQuantity.Value);
            }

            TotalGrossWeight = string.Format("{0:#,##0.0000}", totalGrossWeight);
            TotalNetWeight = string.Format("{0:#,##0.0000}", totalNetWeight);
            TotalVerQty = string.Format("{0:#,##0.0000}", totalVerQty);
            TotalWarehouseQty = string.Format("{0:#,##0.0000}", totalWarehouseQty);
            TotalOpenQty = string.Format("{0:#,##0.0000}", totalVaTinvoiceQty);
        }

        #endregion
    }
}