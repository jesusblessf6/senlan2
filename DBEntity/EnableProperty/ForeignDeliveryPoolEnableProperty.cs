using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class ForeignDeliveryPoolEnableProperty
    {
        //构造函数
        public ForeignDeliveryPoolEnableProperty()
        {
            IsCommodityEnable = true;
            IsLineNewBtnEnable = true;
            IsLineDeleteBtnEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsCommodityEnable { get; set; }
        [DataMember]
        public bool IsLineNewBtnEnable { get; set; }
        [DataMember]
        public bool IsLineDeleteBtnEnable { get; set; }
    }
}
