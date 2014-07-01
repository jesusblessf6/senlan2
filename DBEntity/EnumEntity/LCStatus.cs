using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum LCStatus
    {
        [Description("已开证")] Issued = 1,
        [Description("已结清")] Finished = 2
    }
}