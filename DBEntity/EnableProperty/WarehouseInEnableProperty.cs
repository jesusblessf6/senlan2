using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class WarehouseInEnableProperty
    {
        public WarehouseInEnableProperty()
        {
            IsWarehouseEnable = true;
        }

        [DataMember]
        public bool IsWarehouseEnable { get; set; }
    }
}
