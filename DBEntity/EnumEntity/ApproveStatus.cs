using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum ApproveStatus
    {
        [Description("不需要审批")] NoApproveNeeded = 1,
        [Description("审批未开始")] ApproveNotStart = 2,
        [Description("审批进行中")] InApprove = 3,
        [Description("审批已通过")] Approved = 4,
        [Description("审批被拒绝")] ApproveRefused = 5
    }
}