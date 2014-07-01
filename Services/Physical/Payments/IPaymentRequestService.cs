using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;

namespace Services.Physical.Payments
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPaymentRequestService”。
    [ServiceContract]
    public interface IPaymentRequestService : IService<PaymentRequest>
    {
        //[OperationContract]
        //void AddNewPaymentRequest(PaymentRequest paymentRequest, int userId);

        [OperationContract]
        void UpdateExistedPaymentRequest(PaymentRequest paymentRequest, int userId);

        [OperationContract]
        void CreatePaymentRequestDeliveryLine(PaymentRequest paymentRequest, int userId, List<Delivery> deliveries, bool IsPaymentRequestFinished);

        [OperationContract]
        void UpdatePaymentRequestDeliveryLine(PaymentRequest paymentRequest, int userId, List<Delivery> newDeliveries, List<Delivery> oldDeliveries, bool IsPaymentRequestFinished);

        /// <summary>
        /// 此接口只用于付款工作台的付款完成操作。只修改IsPaid字段
        /// 用之前的接口会将审批状态修改成 审批未开始 状态。
        /// </summary>
        /// <param name="paymentrequest"></param>
        /// <param name="userId"></param>
        [OperationContract]
        void UpdatePaymentRequestIsPaid(PaymentRequest paymentrequest, int userId);

        [OperationContract]
        decimal GetPaymentRequestAmountSumByQuota(int quotaId, int userId);

        [OperationContract]
        decimal GetPaymentRequestAmountSumByInvoice(int invoiceId, int userId);

        [OperationContract]
        PaymentRequestEnableProperty SetElementsEnableProperty(int id);
    }
}
