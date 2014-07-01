using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum BankAccountType
    {
        [Description("资金类")] Asset = 1,
        [Description("信用证余额类")] LCBalance = 2
    }
}