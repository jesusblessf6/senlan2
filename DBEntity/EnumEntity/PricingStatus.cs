using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PricingStatus
    {
        [Description("点价完成")] Complete = 1,
        [Description("部分点价")] Partial = 2,
        [Description("未点价")] NotAtAll = 3
    }
}
