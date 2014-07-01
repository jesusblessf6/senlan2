using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class RelTransactionEnableProperty
    {
        //构造函数
        public RelTransactionEnableProperty()
        {
            IsPriceEnable = true;
            IsDateEnable = true;
            IsRelBPEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsPriceEnable { get; set; }
        [DataMember]
        public bool IsDateEnable { get; set; }
        [DataMember]
        public bool IsRelBPEnable { get; set; }
    }
}