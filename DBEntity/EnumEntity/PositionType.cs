using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PositionType
    {
        [Description("保值")] Hedge = 1,
        [Description("套利")] Arbitrage = 2,
        [Description("投机")] Speculation = 3
    }
}
