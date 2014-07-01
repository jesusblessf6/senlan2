using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class WarehouseInLineEnableProperty
    {
        public WarehouseInLineEnableProperty()
        {
            IsBrandEnable = true;
            IsCommodityTypeEnable = true;
            IsPBNoEnable = true;
            IsQuantityEnable = true;
            IsVerifiedQuantityEnable = true;
            IsDeliveryLineEnable = true;
            IsSpecificationEnable = true;
        }
        [DataMember]
        public bool IsQuantityEnable { get; set; }
        [DataMember]
        public bool IsCommodityTypeEnable { get; set; }
        [DataMember]
        public bool IsBrandEnable { get; set; }
        [DataMember]
        public bool IsPBNoEnable { get; set; }
        [DataMember]
        public bool IsVerifiedQuantityEnable { get; set; }
        [DataMember]
        public bool IsDeliveryLineEnable { get; set; }
        [DataMember]
        public bool IsSpecificationEnable { get; set; }

    }
}
