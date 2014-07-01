using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.Finance.LetterOfCredits
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILCAllocationService" in both code and config file together.
    [ServiceContract]
    public interface ILCAllocationService : IService<LCAllocation>
    {
        [OperationContract]
        decimal GetQuantitySum(string predicate, List<object> parameters);

        [OperationContract]
        decimal GetAmountSum(string predicate, List<object> parameters, List<string> eagerProperties);
    }
}
