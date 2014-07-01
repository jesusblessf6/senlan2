using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentMeanService" in both code and config file together.
    [ServiceContract]
    public interface IPaymentMeanService : IService<PaymentMean>
    {
        [OperationContract]
        PaymentMean AddNewPaymentMean(PaymentMean pm, int userId);

        [OperationContract]
        PaymentMean UpdatePaymentMean(PaymentMean pm, int userId);

    }
}