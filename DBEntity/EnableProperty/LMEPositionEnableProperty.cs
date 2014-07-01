using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class LMEPositionEnableProperty
    {
        //构造函数
        public LMEPositionEnableProperty()
        {
            IsLotQuantityEnable = true;
            IsPriceEnable = true;
            IsTradeDirectionEnable = true;
            IsCommodityEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsLotQuantityEnable { get; set; }
        [DataMember]
        public bool IsTradeDirectionEnable { get; set; }
        [DataMember]
        public bool IsPriceEnable { get; set; }
        [DataMember]
        public bool IsCommodityEnable { get; set; }
    }
}
