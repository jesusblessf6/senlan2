using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Helper.FuturePositionHelper;

namespace Services.Helper.HedgeGroupHelper
{
    public class FPHandlor : IBreakEvenSpreadBaseHandlor
    {
        /// <summary>
        /// 计算期现正套的保本基差的方法是：
        /// （已点价批次以及期货头寸的总盈亏+未点价采购批次的升贴水×数量-未点价销售批次的升贴水×数量）/现货批次的敞口数量
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="ctx"></param>
        public void Handle(HedgeGroup hg, SenLan2Entities ctx)
        {
            hg.StopLossSpread = null;

            //LME PnL
            var lmeLines =
                ctx.HedgeLineLMEPositions.Include("LMEPosition").Include("LMEPosition.Commodity")
                   .Where(o => o.HedgeGroupId == hg.Id && !o.IsDeleted)
                   .ToList();
            decimal lmePnL = LMEPositionHelper.CalcPositionPnL(lmeLines)*(hg.Rate ?? 1) -
                             lmeLines.Sum(o => o.AssignedCommission) * (hg.Rate ?? 1);

            //SHFE PnL
            var shfeLines =
                ctx.HedgeLineSHFEPositions.Include("SHFEPosition").Include("SHFEPosition.Commodity")
                   .Where(o => o.HedgeGroupId == hg.Id && !o.IsDeleted)
                   .ToList();
            decimal shfePnL = SHFEPositionHelper.CalcPositionPnL(shfeLines) - shfeLines.Sum(o => o.AssignedCommission);

            decimal totalPnL = -(lmePnL + shfePnL); //用于算基差，所以要加负号

            //Quota PnL
            var quotaLines =
                ctx.HedgeLineQuotas.Include("Quota")
                   .Include("Quota.Contract")
                   .Include("Quota.Pricings")
                   .Include("Quota.Currency")
                   .Where(o => o.HedgeGroupId == hg.Id && !o.IsDeleted).ToList()
                   .Select(o => o.Quota).ToList();
            var exposure = -quotaLines.Sum(o => o.Quantity*o.Contract.ContractTypeValue) ?? 0;

            if (exposure != 0)
            {
                foreach (var q in quotaLines)
                {
                    decimal rate = 1;
                    if (q.Currency.Code != "CNY")
                        rate = hg.Rate ?? 1;

                    if (q.PricingStatus == (int)PricingStatus.Complete)
                    {
                        totalPnL -= (q.FinalPrice * q.Quantity * q.Contract.ContractTypeValue ?? 0) * rate;
                    }
                    else
                    {
                        var pricings = q.Pricings.Where(o => !o.IsDeleted).ToList();
                        var unpricedQty = (decimal)(q.Quantity - pricings.Sum(o => o.PricingQuantity));
                        totalPnL -= (decimal)pricings.Sum(o => o.PricingQuantity * o.FinalPrice) * q.Contract.ContractTypeValue * rate;
                        totalPnL -= (unpricedQty * q.Premium * q.Contract.ContractTypeValue * rate) ?? 0;
                    }
                }

                hg.StopLossSpread = totalPnL / exposure;
            }
        }
    }
}