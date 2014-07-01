using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DBEntity.EnumEntity;
using PriceDBEntity;
using System.Text;

namespace DBEntity
{
    partial class Quota : IApprovable
    {
        private decimal _price;
        private int _promptMonth;
        private int _promptYear;

        private decimal? _settlementRate;
        private string _totalBrands;
        private string _totalWarehouseName;
        private string _AutoQuotaNo;
        private string _ContractInfo;

        [DataMember]
        public string AutoQuotaNo
        {
            get { return _AutoQuotaNo; }
            set
            {
                if (_AutoQuotaNo != value)
                {
                    _AutoQuotaNo = value;
                    OnPropertyChanged("AutoQuotaNo");
                }
            }
        }

        [DataMember]
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        [DataMember]
        public decimal? SettlementRate
        {
            get { return _settlementRate; }
            set
            {
                if (_settlementRate != value)
                {
                    _settlementRate = value;
                    OnPropertyChanged("SettlementRate");
                }
            }
        }

        public decimal PricedQuantity { get; set; }
        public decimal? AveragePrice { get; set; }
        public string StrPrice { get; set; }
        public string CustomerStrField1 { get; set; }
        public string CustomerStrField2 { get; set; }
        public CurrentPrice QuotaCurrentPrice { get; set; }
        //public string ContractInfo { get; set; }
        public decimal AvailableQuantityForHedge { get; set; }
        public decimal ActualQuantity { get; set; }
        public decimal InvoicedQuantity { get; set; }

        [DataMember]
        public string ContractInfo
        {
            get
            {
                if (Contract != null && Contract.BusinessPartner != null && Contract.InternalCustomer != null)
                {
                    _ContractInfo = "业务伙伴:" + Contract.BusinessPartner.ShortName + " 签署方：" + Contract.InternalCustomer.ShortName + " 品牌:" + TotalBrands + " 数量：" + (Quantity ?? 0).ToString(RoundRules.STR_QUANTITY) + " 单价：" + (FinalPrice ?? 0).ToString(RoundRules.STR_PRICE);
                }
                return _ContractInfo;
            }
            set { _ContractInfo = value; }
        }

        [DataMember]
        public string TotalBrands
        {
            get
            {
                if (QuotaBrandRels != null && QuotaBrandRels.Count > 0)
                {
                    string temp = string.Empty;
                    var brandsName = new List<string>();
                    foreach (QuotaBrandRel quotaBrandRel in QuotaBrandRels)
                    {
                        if (quotaBrandRel.Brand != null && quotaBrandRel.IsDeleted == false)
                        {
                            if (brandsName.Contains(quotaBrandRel.Brand.Name))
                                continue;
                            brandsName.Add(quotaBrandRel.Brand.Name);
                        }
                    }
                    if (brandsName.Count > 0)
                    {
                        brandsName.ForEach(o => temp += "/" + o);
                    }

                    if (!string.IsNullOrEmpty(temp) && temp.Length > 0)
                    {
                        _totalBrands = temp.Substring(1, temp.Length - 1);
                    }
                    return _totalBrands;
                }

                if (Brand != null)
                    return Brand.Name;

                return string.Empty;
            }
            set { _totalBrands = value; }
        }

        public int PromptYear
        {
            get
            {
                int month = PromptMonth;
                if (month > 0)
                {
                    DateTime time = ImplementedDate.Value.Date; //签署日期

                    if (time.Month < month)
                    {
                        _promptYear = time.Year;
                    }
                    else if (time.Month == month)
                    {
                        var cDay = new DateTime(time.Year, time.Month, 16); //当月的合同的到期日
                        if (time.DayOfWeek == DayOfWeek.Saturday)
                        {
                            time = time.AddDays(2);
                        }
                        else if (time.DayOfWeek == DayOfWeek.Sunday)
                        {
                            //周日
                            time = time.AddDays(1);
                        }

                        int day = time.Day;

                        if (cDay.DayOfWeek == DayOfWeek.Saturday)
                        {
                            //是周六
                            cDay = cDay.AddDays(2);
                        }
                        else if (cDay.DayOfWeek == DayOfWeek.Sunday)
                        {
                            //周日
                            cDay = cDay.AddDays(1);
                        }

                        if (cDay.Day <= day)
                        {
                            //过了到期日
                            _promptYear = time.Year + 1;
                        }
                        else
                        {
                            _promptYear = time.Year;
                        }
                    }
                    else
                    {
                        _promptYear = time.Year + 1;
                    }
                }
                else
                    _promptYear = 0;

                return _promptYear;
            }
        }

        public int PromptMonth
        {
            get
            {
                switch (PricingBasis.Value)
                {
                    case (int)EnumEntity.PricingBasis.SHFE01:
                        _promptMonth = 1;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE02:
                        _promptMonth = 2;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE03:
                        _promptMonth = 3;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE04:
                        _promptMonth = 4;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE05:
                        _promptMonth = 5;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE06:
                        _promptMonth = 6;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE07:
                        _promptMonth = 7;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE08:
                        _promptMonth = 8;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE09:
                        _promptMonth = 9;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE10:
                        _promptMonth = 10;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE11:
                        _promptMonth = 11;
                        break;
                    case (int)EnumEntity.PricingBasis.SHFE12:
                        _promptMonth = 12;
                        break;
                    default:
                        _promptMonth = 0;
                        break;
                }
                return _promptMonth;
            }
        }

        //仓库名称,多品牌
        public string TotalWarehouseName
        {
            get
            {
                if (QuotaBrandRels != null && QuotaBrandRels.Count > 0)
                {
                    string temp = string.Empty;
                    var warehouseName = new List<string>();
                    foreach (QuotaBrandRel quotaBrandRel in QuotaBrandRels)
                    {
                        if (quotaBrandRel.Warehouse != null && quotaBrandRel.IsDeleted == false)
                        {
                            if (warehouseName.Contains(quotaBrandRel.Warehouse.Name))
                                continue;
                            warehouseName.Add(quotaBrandRel.Warehouse.Name);
                        }
                    }
                    if (warehouseName.Count > 0)
                    {
                        warehouseName.ForEach(o => temp += "/" + o);
                    }

                    if (!string.IsNullOrEmpty(temp) && temp.Length > 0)
                    {
                        _totalWarehouseName = temp.Substring(1, temp.Length - 1);
                    }
                    return _totalWarehouseName;
                }

                if (Warehouse != null)
                    return Warehouse.Name;

                return string.Empty;
            }
            set { _totalWarehouseName = value; }
        }

        [DataMember]
        public decimal? TotalRequestAmount
        {
            get
            {
                if (PaymentRequests != null && PaymentRequests.Count > 0)
                {
                    foreach (PaymentRequest payment in PaymentRequests)
                    {
                        if (payment.IsDeleted)
                            continue;

                        if (payment.PaymentUsage != null && payment.PaymentUsage.FinancialAccount != null && payment.PaymentUsage.FinancialAccount.Name == "货款")
                        {
                            _totalRequestAmount += payment.RequestAmount;
                        }
                    }
                }
                return _totalRequestAmount ?? (_totalRequestAmount = 0);
            }
            set { _totalRequestAmount = value; }
        }
        private decimal? _totalRequestAmount;

        [DataMember]
        public decimal AmountForApproval { get; set; }

        [DataMember]
        public int CurrencyIdForApproval { get; set; }

        private bool _approvalCanEdit = true;
        public bool ApprovalCanEdit
        {
            get
            {
                _approvalCanEdit = true;
                if (Contract != null && Contract.ContractType == (int)ContractType.Purchase && Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    if (RelQuotaId != null)
                    {
                        _approvalCanEdit = false;
                    }
                }

                return _approvalCanEdit;
            }
            set
            {
                _approvalCanEdit = value;
            }
        }

        public int VituralRelQuotaId
        {
            get
            {
                if (RelQuotaId.HasValue)
                    return RelQuotaId.Value;
                else
                {
                    return Id;
                }
            }
        }

        public bool AutoGenGeneratedCanEdit
        {
            get
            {
                //if (Contract.TradeType == (int)TradeType.LongForeignTrade || Contract.TradeType == (int)TradeType.ShortForeignTrade)
                //{
                //    return !IsAutoGenerated;
                //}
                //else if (Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                //{
                //    return !RelQuotaId.HasValue;
                //}
                //return true;

                return !IsAutoGenerated;
            }
        }

        //public string IsPrintControlsVisible
        //{
        //    get
        //    {
        //        if (Contract.TradeType == (int) TradeType.ShortForeignTrade ||
        //            Contract.TradeType == (int) TradeType.LongForeignTrade)
        //            return "Hidden";

        //        return "Visible";
        //    }
        //}

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        private bool _isSelected;

        public bool Printable
        {
            get
            {
                return (ApproveStatus == (int)EnumEntity.ApproveStatus.NoApproveNeeded ||
                        ApproveStatus == (int)EnumEntity.ApproveStatus.Approved);
            }
        }

        public decimal QuotaAmount
        {
            get
            {
                return (FinalPrice ?? 0) * VerifiedQuantity;
            }
        }

        private bool _canSplit;

        public bool CanBeSplit
        {
            get { return _canSplit; }
            set
            {
                if (_canSplit != value)
                {
                    _canSplit = value;
                    OnPropertyChanged("CanBeSplit");
                }
            }
        }

        private bool _isMoreBrands;

        [DataMember]
        public bool IsMoreBrands
        {
            set { _isMoreBrands = value; }
            get
            {
                if (QuotaBrandRels != null && QuotaBrandRels.Count > 0)
                {
                    _isMoreBrands = true;
                }
                else
                {
                    _isMoreBrands = false;
                }
                return _isMoreBrands;
            }
        }

        private bool _isNotMoreBrands;

        [DataMember]
        public bool IsNotMoreBrands
        {
            set { _isNotMoreBrands = value; }
            get
            {
                if (QuotaBrandRels != null && QuotaBrandRels.Count > 0)
                {
                    _isNotMoreBrands = false;
                }
                else
                {
                    _isNotMoreBrands = true;
                }
                return _isNotMoreBrands;
            }
        }

        private string _moreBrandDetail;

        public string MoreBrandDetail
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (QuotaBrandRels != null && QuotaBrandRels.Count > 0)
                {
                    foreach (var quotaBrand in QuotaBrandRels)
                    {
                        string warehouseName = "";
                        if (quotaBrand.Warehouse != null)
                        {
                            warehouseName = quotaBrand.Warehouse.Name;
                        }
                        sb.Append("品牌:" + quotaBrand.Brand.Name + " 数量:" + quotaBrand.Quantity + " 价格:" + quotaBrand.Price + " 仓库:" + warehouseName + "  ");
                    }
                }
                else
                {
                    sb.Append(Quantity);
                }
                _moreBrandDetail = sb.ToString();
                return _moreBrandDetail;
            }
            set { _moreBrandDetail = value; }
        }
    }
}
