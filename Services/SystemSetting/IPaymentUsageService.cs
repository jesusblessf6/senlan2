using System.ServiceModel;
using Services.Base;
using DBEntity;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPaymentUsageService”。
    [ServiceContract]
    public interface IPaymentUsageService : IService<PaymentUsage>
    {
        //[OperationContract]
        //void DoWork();
        [OperationContract]
        PaymentUsage AddNewPaymentUsage(PaymentUsage paymentusage, int userId);

        [OperationContract]
        PaymentUsage UpdatePaymentUsage(PaymentUsage paymentusage, int userId);

    }
}
