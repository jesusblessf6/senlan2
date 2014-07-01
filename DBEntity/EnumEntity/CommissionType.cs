using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum CommissionType
    {
        [Description("客户佣金")] ClientCommission = 1,
        [Description("经纪行佣金")] AgentCommission = 2
    }
}