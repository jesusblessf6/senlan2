using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PricingSide
    {
        [Description("对方")] TheirSide = 1,
        [Description("我方")] OurSide = 2
    }
}
