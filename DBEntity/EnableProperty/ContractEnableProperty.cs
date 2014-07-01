using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class ContractEnableProperty
    {
        //构造函数
        public ContractEnableProperty()
        {
            IsSignBPEnable = true;
            IsBPEnable = true;
            //短单合同的签署日期在均价点价后不能修改
            IsSignDateEnable = true;
            // 关联交易
            IsRelTransactionNewBtnEnable = true;
            IsRelTransactionEditBtnEnable = true;
            IsRelTransactionDeleteBtnEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsSignBPEnable { get; set; }
        [DataMember]
        public bool IsBPEnable { get; set; }
        [DataMember]
        public bool IsSignDateEnable { get; set; }
        [DataMember]
        public bool IsRelTransactionNewBtnEnable { get; set; }
        [DataMember]
        public bool IsRelTransactionEditBtnEnable { get; set; }
        [DataMember]
        public bool IsRelTransactionDeleteBtnEnable { get; set; }
    }
}
