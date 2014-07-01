using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum VATInvoiceType
    {
        [Description("开票")] Issue=1,
        [Description("收票")] Receive = 2
    }
}
