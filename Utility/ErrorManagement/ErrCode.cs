namespace Utility.ErrorManagement
{
    public enum ErrCode
    {
        NoErr = 0,
        UnkownErr,
        OptimisticConcurrencyErr,
        ServerErr,
        EndpointNotFound,
        FetchUnreadTransErr,
        TimeoutErr,
        LoginFailErr,
        ObjectNotFound,
        LoginNameExisted,
        CurrencyExisted,
        RateExisted,
        CountryExisted,
        UdfExisted,
        DeleteFKErr,
        DeleteErr,
        PortExisted,
        PaymentMeanExisted,
        VATRateExisted,
        PaymentUsageExisted,
        StringOverflow,
        RoleNameExisted,
        ApprovalConditionCollapsed,
        ApprovalNameExisted,
        FinancialAccountAddFKErr,
        FinancialAccountUpdateFKErr,
        FinancialAccountExisted,
        FinancialAccountUpdate2FKErr,
        PaymentUsagePAExisted,
        BankNameExisted,
        BankAccountUsed,
        BankAccountExisted,
        CommodityTypeExisted,
        BrandExisted,
        SpecificationExisted,
        WarehouseExisted,

        //关联单据错误码 - 开始
        //批次相关
        QuotaDeliveryConnected,
        QuotaWarehouseOutConnected,
        QuotaPaymentRequestConnected,
        QuotaCommercialInvoiceConnected,
        QuotaFundFlowConnected,
        QuotaVATInvoiceConnected,
        QuotaVATInvoiceRequestConnected,
        QuotaLetterOfCreditConnected,
        QuotaPricingConnected,
        QuotaHedgedNotAbleToDeleteModify,
        //付款申请相关
        PaymentRequestLCConnected,
        PaymentRequestFundFlowConnected,
        //提单相关
        DeliveryWarehouseInConnected,
        DeliveryCommercialInvoiceConnected,
        DeliveryPaymentRequestConnected,
        DeliveryDeliveryConnected,
        DeliveryLCConnected,
        //入库相关
        WarehouseInWarehouseOutConnected,
        //点价相关
        PricingVATInvoiceConnected,
        PricingUnpricingConnected,
        UnpricingUnpricingConnected,
        ExceedPricingDateRange,
        SaleDeliveryConnected,
        //关联单据错误码 - 结束

        QuotaNotExisted,
        NotInApproval,
        ApprovalStageNotFound,
        UnpricingQuantityNotEnough,
        UnpricingNotFound,
        FinalInvoiceIdExisted,
        OldPasswordErr,
        PaymentRequestNotFound,
        DocumentNotFound,
        LogActionNotFound,
        //增值税发票相关
        VATInvoiceRequestLineConnected,

        PricingCurrencyNotMatch,
        CurrencyNotFound,
        LMEPositionNotFound,
        SHFEPositionNotFound,
        HedgeGroupNotFound,
        HedgeGroupLineQuotaNotFound,
        HedgeGroupLineLMEPositionNotFound,
        HedgeGroupLineSHFEPositionNotFound,
        HedgeGroupSettledNotForModify,
        LMEPositionHedged,

        //会计科目
        FinancialAccountFundFlowConnected,
        FinancialAccountPaymentUsageConnected,

        //信用证
        LCCommercialInvoiceConnected,

        //提单行没有暂定价
        DeliveryLineNotHasTempUnitPrice,

        //是自动生成的单据
        DeleteRelQuotaConnected,
        EditRelQuotaConnected,

        DuplicatedDeliveryPersonInfo,
        NotDuringApproval,
        ForeignDeliveryPoolNotFound,

        DuplicatedDeliveryNo,
        InvoiceHasPayMentRequest
    }
}
