using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum VATType
    {
        [Description("进项税")] Input = 1,
        [Description("销项税")] Output = 2
    }
}