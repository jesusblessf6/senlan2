using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IFinancialAccountService”。
    [ServiceContract]
    public interface IFinancialAccountService : IService<FinancialAccount>
    {
        [OperationContract]
        FinancialAccount AddNewFinancialAccount(FinancialAccount financialAccount, int userId);

        [OperationContract]
        FinancialAccount UpdateFinancialAccount(FinancialAccount financialAccount, int userId);
    }
}
