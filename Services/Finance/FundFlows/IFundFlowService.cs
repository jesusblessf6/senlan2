using System.ServiceModel;
using DBEntity;
using Services.Base;
using System;
using System.Collections.Generic;
using DBEntity.EnableProperty;

namespace Services.Finance.FundFlows
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IFundFlowService”。
    [ServiceContract]
    public interface IFundFlowService : IService<FundFlow>
    {
        [OperationContract]
        FundFlow UpdateFundFlow(bool isFundflowFinished,FundFlow fundFlow, int userId);

        [OperationContract]
        FundFlow AddNewFundFlow(bool isFundflowFinished,FundFlow fundFlow, int userId);

        [OperationContract]
        List<FundFlow> GetListByParameter(int? internalCustomerId, int? customerId, DateTime? startDate, DateTime? endDate, int userId);

        [OperationContract]
        FundFlowEnableProperty SetElementsEnableProperty(int id);
    }
}
