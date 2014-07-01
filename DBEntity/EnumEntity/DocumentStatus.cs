using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum DocumentStatus
    {
        [Description("草稿")] Draft = 1,
        [Description("正式")] Normal = 2,
        [Description("删除")] Deleted = 3
    }
}
