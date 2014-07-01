using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum CompleteStatus
    {
        [Description("未完成")] NotComplete = 1,
        [Description("完成")] Complete = 2
    }
}
