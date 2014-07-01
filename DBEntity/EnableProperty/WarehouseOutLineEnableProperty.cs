using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class WarehouseOutLineEnableProperty
    {
        //构造函数
        public WarehouseOutLineEnableProperty()
        {
            IsQuantityEnable = true;
            IsVerifiedQuantityEnable = true;
            IsClearPBNoEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsQuantityEnable { get; set; }
        [DataMember]
        public bool IsVerifiedQuantityEnable { get; set; }
        [DataMember]
        public bool IsClearPBNoEnable { get; set; }
    }
}
