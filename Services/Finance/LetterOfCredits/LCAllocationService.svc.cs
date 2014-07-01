using System.Collections.Generic;
using DBEntity;
using Services.Base;

namespace Services.Finance.LetterOfCredits
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LCAllocationService" in code, svc and config file together.
    public class LCAllocationService : BaseService<LCAllocation>, ILCAllocationService
    {
        public decimal GetQuantitySum(string predicate, List<object> parameters)
        {
            return SelectSum<LCAllocation>(predicate, parameters, null, o => o.Quantity);
        }

        public decimal GetAmountSum(string predicate, List<object> parameters, List<string> eagerProperties)
        {
            return SelectSum<LCAllocation>(predicate, parameters, eagerProperties, o => o.Amount);
        }
    }
}
