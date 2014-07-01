using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum FundFlowType
    {
        [Description("收款")] Receive = 1,
        [Description("付款")] Pay = 2
    }
}