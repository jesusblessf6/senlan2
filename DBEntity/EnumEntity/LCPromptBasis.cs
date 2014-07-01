using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum LCPromptBasis
    {
        [Description("IssueDate")]
        LCIssueDate = 1,
        [Description("BLDate")]
        LCBLDate = 2,
        [Description("Sight")] LCSight = 3
    }
}