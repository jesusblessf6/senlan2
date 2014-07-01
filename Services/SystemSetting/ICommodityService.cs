using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommodityService" in both code and config file together.
    [ServiceContract]
    public interface ICommodityService : IService<Commodity>
    {
        [OperationContract]
        List<Commodity> GetCommoditiesByUser(int userId);
        [OperationContract]
        Commodity GetCommoditiyByCode(string code);
    }
}