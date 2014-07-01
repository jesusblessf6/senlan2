using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    //todo: 将点价基准改成数据库表，因为点价基准中海油币种信息
    public enum PricingBasis
    {
        [Description("LME3MPrice")]
        LME3M = 1,
        [Description("LMECASHPrice")]
        LMECash = 2,
        [Description("上海有色网")] SHY = 3,
        [Description("上海金属网")] SHX = 4,
        [Description("SGE当月结算价")] SGESettlement= 5,
        [Description("SHFE01")] SHFE01 = 6,
        [Description("SHFE02")] SHFE02 = 7,
        [Description("SHFE03")] SHFE03 = 8,
        [Description("SHFE04")]
        SHFE04 = 9,
        [Description("SHFE05")]
        SHFE05 = 10,
        [Description("SHFE06")]
        SHFE06 = 11,
        [Description("SHFE07")]
        SHFE07 = 12,
        [Description("SHFE08")]
        SHFE08 = 13,
        [Description("SHFE09")]
        SHFE09 = 14,
        [Description("SHFE10")]
        SHFE10 = 15,
        [Description("SHFE11")]
        SHFE11 = 16,
        [Description("SHFE12")]
        SHFE12 = 17,
        [Description("长江")]
        PCJ = 18,
        [Description("南储")]
        NC = 19
    }
}