using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum DocumentType
    {
        [Description("仓库")]
        Warehouse = 1,
        [Description("增值税率")]
        VATRate = 2,
        [Description("合同")]
        Contract = 3,
        [Description("批次")]
        Quota = 4,
        [Description("提货单/发货单")]
        Delivery = 5,
        [Description("入库")]
        WarehouseIn = 6,
        [Description("出库")]
        WarehouseOut = 7,
        [Description("移库")]
        WarehouseTransfer = 8,
        [Description("付款申请")]
        PaymentRequest = 9,
        [Description("增值税发票明细")]
        VATInvoiceRequestLine = 10,
        [Description("信用证")]
        LetterOfCredit = 11,
        [Description("临时发票")]
        ProvisionalInvoice = 12,
        [Description("最终发票")]
        FinalInvoice = 13,
        [Description("外贸提单池")]
        ForeignDeliveryPool = 14,
        [Description("客户/经纪行")]
        BusinessPartner = 15
    }
}
