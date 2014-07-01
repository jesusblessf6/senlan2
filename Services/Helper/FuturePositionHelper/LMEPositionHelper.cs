using System.Collections.Generic;
using System.Linq;
using DBEntity;

namespace Services.Helper.FuturePositionHelper
{
    public class LMEPositionHelper
    {
        /// <summary>
        /// Only for the even positions
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static decimal CalcPositionPnL(List<HedgeLineLMEPosition> positions)
        {
            decimal result = 0;

            if (positions != null)
            {
                var ps = positions.Where(o => !o.IsDeleted).ToList();
                result -= (decimal) ps.Sum(o => o.LMEPosition.AgentPrice*o.AssignedLotAmount*o.LMEPosition.TradeDirectionValue*o.LMEPosition.Commodity.LMEQtyPerHand);
            }

            return result;
        }
    }
}