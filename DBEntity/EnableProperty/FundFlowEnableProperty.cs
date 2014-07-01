using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class FundFlowEnableProperty
    {
        //构造函数
        public FundFlowEnableProperty()
        {
            IsBPEnable = true;
            IsInternalCustomerEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsBPEnable { get; set; }
        [DataMember]
        public bool IsInternalCustomerEnable { get; set; }
    }
}

