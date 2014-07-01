using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum QuotaVATStatus
    {
        [Description("完全开票")] Complete = 1,
        [Description("部分开票")] Partial = 2,
        [Description("未开票")] NotAtAll = 3
    }
}
