using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum HedgeGroupStatus
    {
        [Description("未结算")] NotSettled = 1,
        [Description("已结算")] Settled = 2
    }
}
