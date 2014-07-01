using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum IsVerified
    {
        //[Description("")] SelectEmpty = 3,
        [Description("未确认")] False = 1,
        [Description("已确认")] True = 2
    }
}