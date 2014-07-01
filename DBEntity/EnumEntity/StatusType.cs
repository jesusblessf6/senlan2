using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum StatusType
    {
        [Description("未结清")] NotCompleted = 0,
        [Description("结清")] Completed = 1
    }
}