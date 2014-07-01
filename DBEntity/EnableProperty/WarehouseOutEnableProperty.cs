using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class WarehouseOutEnableProperty
    {
        public WarehouseOutEnableProperty()
        {
            IsWarehouseEnable = true;
            IsQuotaEnable = true;
        }

        [DataMember]
        public bool IsWarehouseEnable { get; set; }
        [DataMember]
        public bool IsQuotaEnable { get; set; }
    }
}
