using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class PCommercialInvoiceEnableProperty
    {
        //构造函数
        public PCommercialInvoiceEnableProperty()
        {
            IsQuotaEnable = true;
            IsPaymentMeansEnable = true;
            IsLCAddEnable = true;
            IsDeliveryAddEnable = true;
            IsPriceEnable = true;
            IsAmountEnable = true;
            IsSettlementCurrencyEnable = true;
            IsExchangeRateEnable = true;
            IsIncludeInterestEnable = true;
            IsLCDeleteEnable = true;
            IsDeliveryDeleteEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsQuotaEnable { get; set; }
        [DataMember]
        public bool IsPaymentMeansEnable { get; set; }
        [DataMember]
        public bool IsLCAddEnable { get; set; }
        [DataMember]
        public bool IsDeliveryAddEnable { get; set; }
        [DataMember]
        public bool IsPriceEnable { get; set; }
        [DataMember]
        public bool IsAmountEnable { get; set; }
        [DataMember]
        public bool IsSettlementCurrencyEnable { get; set; }
        [DataMember]
        public bool IsExchangeRateEnable { get; set; }
        [DataMember]
        public bool IsIncludeInterestEnable { get; set; }
        [DataMember]
        public bool IsLCDeleteEnable { get; set; }
        [DataMember]
        public bool IsDeliveryDeleteEnable { get; set; }
    }
}
