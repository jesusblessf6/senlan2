using System.Runtime.Serialization;

namespace DBEntity.EnableProperty
{
    [DataContract(IsReference = true)]
    public class PaymentRequestEnableProperty
    {
        //构造函数
        public PaymentRequestEnableProperty()
        {
            IsQuotaBtnEnable = true;
            IsCIBtnEnable = true;
            IsRequestAmountEnable = true;
            IsCurrencyEnable = true;
            IsBPPayEnable = true;
            IsAccountPayEnable = true;
            IsBPReceiveEnable = true;
            IsAccountReceiveEnable = true;
            IsPaymentUsageEnable = true;
            IsPaymentMeanEnable = true;
            IsTransferBankEnable = true;
        }
        //数据成员
        [DataMember]
        public bool IsQuotaBtnEnable { get; set; }
        [DataMember]
        public bool IsCIBtnEnable { get; set; }
        [DataMember]
        public bool IsRequestAmountEnable { get; set; }
        [DataMember]
        public bool IsCurrencyEnable { get; set; }
        [DataMember]
        public bool IsBPPayEnable { get; set; }
        [DataMember]
        public bool IsAccountPayEnable { get; set; }
        [DataMember]
        public bool IsBPReceiveEnable { get; set; }
        [DataMember]
        public bool IsAccountReceiveEnable { get; set; }
        [DataMember]
        public bool IsPaymentUsageEnable { get; set; }
        [DataMember]
        public bool IsPaymentMeanEnable { get; set; }
        [DataMember]
        public bool IsTransferBankEnable { get; set; }
    }
}
