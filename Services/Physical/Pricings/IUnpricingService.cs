using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.Physical.Pricings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnpricingService" in both code and config file together.
    [ServiceContract]
    public interface IUnpricingService : IService<Unpricing>
    {
        [OperationContract]
        List<Unpricing> GetUnpricingsByQuotaId(int quotaId);

        [OperationContract]
        Unpricing DeferPricing(Unpricing unpricing, int userId);
    }
}
