using System;
using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;

namespace Services.Helper.HedgeGroupHelper
{
    public class CarryHandlor : IBreakEvenSpreadBaseHandlor
    {
        /// <summary>
        /// 将已平头寸的浮动盈亏摊到未平的头寸上
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="ctx"></param>
        public void Handle(HedgeGroup hg, SenLan2Entities ctx)
        {
            hg.StopLossSpread = null;

            var lmeLines =
                ctx.HedgeLineLMEPositions.Include("LMEPosition").Include("LMEPosition.Commodity")
                   .Where(o => o.HedgeGroupId == hg.Id && !o.IsDeleted)
                   .ToList();

            var shfeLines =
                ctx.HedgeLineSHFEPositions.Include("SHFEPosition").Include("SHFEPosition.Commodity")
                   .Where(o => o.HedgeGroupId == hg.Id && !o.IsDeleted)
                   .ToList();

            if (lmeLines.Count > 0)
            {
                var groups = lmeLines.GroupBy(o => o.LMEPosition.PromptDate);
                decimal exposure = 0;
                foreach (var @group in groups)
                {
                    var list = @group.ToList();
                    var tmp = Math.Round((decimal)list.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue * o.LMEPosition.Commodity.LMEQtyPerHand), RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                    if (tmp != 0)
                    {
                        exposure = Math.Abs(tmp);
                        break;
                    }
                }

                if (exposure != 0)
                {
                    var pnl =
                        - lmeLines.Sum(o => o.AssignedLotAmount*o.LMEPosition.AgentPrice*o.LMEPosition.TradeDirectionValue*o.LMEPosition.Commodity.LMEQtyPerHand) - lmeLines.Sum(o => o.AssignedCommission);
                    hg.StopLossSpread = -pnl/exposure;
                }
            }
            else if (shfeLines.Count > 0)
            {
                var groups = shfeLines.GroupBy(o => o.SHFEPosition.PromptDate);
                decimal exposure = 0;
                foreach (var @group in groups)
                {
                    var list = @group.ToList();

                    var tmp =
                        Math.Round(
                            (decimal)list.Sum(
                                o =>
                                o.AssignedLotAmount * o.SHFEPosition.OpenCloseValue * o.SHFEPosition.Commodity.SHFEQtyPerHand), RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                    if (tmp != 0)
                    {
                        exposure = Math.Abs(tmp);
                        break;
                    }
                }

                if (exposure != 0)
                {
                    var pnl =
                        -shfeLines.Sum(
                            o =>
                            o.AssignedLotAmount * o.SHFEPosition.Price * o.SHFEPosition.TradeDirectionValue * o.SHFEPosition.Commodity.SHFEQtyPerHand) - shfeLines.Sum(o => o.AssignedCommission);
                    hg.StopLossSpread = -pnl / exposure;
                }
            }
        }
    }
}