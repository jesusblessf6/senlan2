using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PositionOpenClose
    {
        [Description("开仓")] Open = 1,
        [Description("平仓")] Close = 2
    }
}
