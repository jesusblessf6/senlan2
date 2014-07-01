using System;
using System.Collections.Generic;
using System.ServiceModel;
using Services.Base;
using DBEntity;
using DBEntity.EnableProperty;

namespace Services.Futures.LME
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ILMEPositionService”。
    [ServiceContract]
    public interface ILMEPositionService : IService<LMEPosition>
    {
        [OperationContract]
        void CreateNewCarryLMEPosition(LMEPosition lp,LMEPosition lp2, int userId);

        [OperationContract]
        void UpdateCarryLMEPosition(LMEPosition lp, LMEPosition lp2, int userId);

        [OperationContract]
        void DeleteLMEPosition(int id, int userId);

        [OperationContract]
        void DeleteCarryLMEPosition(int id, int userId);

        [OperationContract]
        decimal GetQtyByParameters(int positionDirection, int commodityID, int internalCustomerID, DateTime? date, string type, int userId);

        [OperationContract]
        List<LMEPosition> GetDuedPositionSummary(string queryStr, List<object> parameters, List<string> includes);

        [OperationContract]
        LMEPositionEnableProperty SetElementsEnableProperty(int id);

        [OperationContract]
        List<LMEExposureDetailLine> GetLMEExposureLines(int commodityId, int internalCustomerId, int brokerId);
    }
}
