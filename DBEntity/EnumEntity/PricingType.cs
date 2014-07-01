using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PricingType
    {
        [Description("固定价点价")] Fixed = 1,
        [Description("手工点价")] Manual = 2,
        [Description("平均价点价")] Average = 3
    }
}