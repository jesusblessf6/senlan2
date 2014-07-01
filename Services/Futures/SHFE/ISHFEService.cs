using System;
using System.Collections.Generic;
using System.ServiceModel;
using Services.Base;

namespace Services.Futures.SHFE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISHFEService" in both code and config file together.
    [ServiceContract]
    public interface ISHFEService:IService<DBEntity.SHFE>
    {
        [OperationContract]
        DBEntity.SHFE GetShfeByAlias(string alias);

        [OperationContract]
        List<DBEntity.SHFE> GetShfeByCommodityId(int commodityId,DateTime tradeDate);
    }
}
