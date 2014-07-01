using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class QuotaEnableProperty
    {
        //构造函数
        public QuotaEnableProperty()
        {
            IsPriceEnable = true;
            IsQuantityEnable = true;
            IsPricingBasisEnable = true;
            IsPricingTypeEnable = true;
            IsPricingStartDateEnable = true;
            IsPricingEndDateEnable = true;
            IsCommodityEnable = true;
            IsPremiumEnable = true;
            IsImplDateEnable = true;
        }
        //属性成员
        [DataMember]
        public bool IsQuantityEnable { get; set; }
        [DataMember]
        public bool IsPriceEnable { get; set; }
        [DataMember]
        public bool IsPricingBasisEnable { get; set; }
        [DataMember]
        public bool IsPricingStartDateEnable { get; set; }
        [DataMember]
        public bool IsPricingEndDateEnable { get; set; }
        [DataMember]
        public bool IsCommodityEnable { get; set; }
        [DataMember]
        public bool IsPremiumEnable { get; set; }
        [DataMember]
        public bool IsPricingTypeEnable { get; set; }
        [DataMember]
        public bool IsImplDateEnable { get; set; }
    }
}
