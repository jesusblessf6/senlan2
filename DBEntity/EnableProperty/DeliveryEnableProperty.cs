using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class DeliveryEnableProperty
    {
        public DeliveryEnableProperty()
        {
            IsQuotaEnable = true;
            IsTDEnable = true;
            IsWarehouseEnable = true;
            IsPoolNoBtnEnable = true;
        }
        [DataMember]
        public bool IsQuotaEnable { get; set; }
        [DataMember]
        public bool IsTDEnable { get; set; }
        [DataMember]
        public bool IsWarehouseEnable { get; set; }
        [DataMember]
        public bool IsPoolNoBtnEnable { get; set; }
    }
}
