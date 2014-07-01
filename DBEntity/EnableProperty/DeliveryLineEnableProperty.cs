using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class DeliveryLineEnableProperty
    {
        public DeliveryLineEnableProperty()
        {
            IsNetWeightEnable = true;
            IsVerifiedQuantityEnable = true;
            IsCommodityTypeEnable = true;
            IsBrandEnable = true;
            IsSpecificationEnable = true;
        }
        [DataMember]
        public bool IsNetWeightEnable { get; set; }
        [DataMember]
        public bool IsVerifiedQuantityEnable { get; set; }
        [DataMember]
        public bool IsCommodityTypeEnable { get; set; }
        [DataMember]
        public bool IsBrandEnable { get; set; }
        [DataMember]
        public bool IsSpecificationEnable { get; set; }
    }
}