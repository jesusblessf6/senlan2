using System.Collections.Generic;
using System.Linq;
using DBEntity;

namespace Services.Helper.FuturePositionHelper
{
    public class SHFEPositionHelper
    {
        /// <summary>
        /// Only for the even positions
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static decimal CalcPositionPnL(List<HedgeLineSHFEPosition> positions)
        {
            decimal result = 0;

            if (positions != null)
            {
                var ps = positions.Where(o => !o.IsDeleted).ToList();
                result -= (decimal)ps.Sum(o => o.SHFEPosition.Price*o.AssignedLotAmount*o.SHFEPosition.TradeDirectionValue * o.SHFEPosition.Commodity.SHFEQtyPerHand);
            }

            return result;
        }
    }
}