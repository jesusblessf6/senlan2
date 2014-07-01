using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum PrintTemplateType
    {
        [Description("内贸合同模板")] DomesticContractTemplate = 1,
        [Description("外贸合同模板")] InternationalContractTemplate = 2,
        [Description("付款申请单模板")] PaymentRequestTemplate = 3,
        [Description("内贸出库单")] DomesticWarehouseOutTemplate = 4,
        [Description("临时商业发票")] ProvisionalInvoiceTemplate = 5,
        [Description("最终商业发票")] FinalInvoiceTemplate = 6,
        [Description("点价确认单模板")] PricingConfirmationTemplate = 7,

    }
}
