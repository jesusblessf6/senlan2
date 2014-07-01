using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PurchaseContractType
    {
        [Description("内贸长单")] MuchContractDomesticTrade = 1,
        [Description("内贸短单")] SingleContractDomesticTrade = 2,
        [Description("进口/转口长单")] MuchContractForeignTrade = 3,
        [Description("进口/转口短单")] SingleContractForeignTrade = 4,
    }
}