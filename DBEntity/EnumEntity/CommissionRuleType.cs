using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum CommissionRuleType
    {
        [Description("ByAmount")]
        Percent = 1,
        [Description("ByUnit")]
        PerUnit = 2
    }
}
