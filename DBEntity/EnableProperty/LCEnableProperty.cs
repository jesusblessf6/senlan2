using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class LCEnableProperty
    {
        //构造函数
        public LCEnableProperty()
        {
            IsBPEnable = true;
            IsInternalCustomerEnable = true;
            IsQuotaEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsBPEnable { get; set; }
        [DataMember]
        public bool IsInternalCustomerEnable { get; set; }
        [DataMember]
        public bool IsQuotaEnable { get; set; }
    }
}