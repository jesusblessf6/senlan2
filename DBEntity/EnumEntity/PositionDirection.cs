using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PositionDirection
    {
        [Description("买入")] Long = 1,
        [Description("卖出")] Short = 2
    }
}