using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum CommercialInvoiceType
    {
        [Description("临时发票")] Provisional = 1,
        [Description("最终发票")] Final = 2,
        [Description("商业发票")] FinalCommercial = 3
    }
}