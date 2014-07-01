using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum ArbitrageType
    {
        [Description("普通")] Common = 1,
        [Description("期现正套")] FPArbitrage = 2,
        [Description("期现反套")] FPRevArbitrage = 3,
        [Description("跨期正套")] CarryArbitrage = 4,
        [Description("跨期反套")] CarryRevArbitrage = 5,
        [Description("跨市正套")] MarketArbitrage = 6,
        [Description("跨市反套")] MarketRevArbitrage = 7
    }
}
