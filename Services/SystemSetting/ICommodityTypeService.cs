using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICommodityTypeService”。
    [ServiceContract]
    public interface ICommodityTypeService : IService<CommodityType>
    {
        [OperationContract]
        CommodityType AddNewCommodityType(CommodityType ct, int userId);

        [OperationContract]
        CommodityType UpdateExistedCommodityType(CommodityType ct, int userId);

        [OperationContract]
        List<CommodityType> GetCommodityTypesByCommodity(int commodityId);
    }
}