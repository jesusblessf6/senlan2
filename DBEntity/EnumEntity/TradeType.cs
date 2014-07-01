using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum TradeType
    {
        [Description("内贸短单")] ShortDomesticTrade = 1,
        [Description("进口转口短单")] ShortForeignTrade = 2,
        [Description("内贸长单")] LongDomesticTrade = 3,
        [Description("进口转口长单")]
        LongForeignTrade = 4
    }
}