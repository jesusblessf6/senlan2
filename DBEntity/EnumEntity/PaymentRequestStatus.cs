using System.ComponentModel;
namespace DBEntity.EnumEntity
{
    public enum PaymentRequestStatus
    {
        [Description("付款完成")] PaymentComplete = 1,
        [Description("付款未完成")] PaymentInComplete = 2
    }
}
