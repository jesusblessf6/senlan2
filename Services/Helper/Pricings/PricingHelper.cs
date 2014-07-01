using DBEntity;
using System.Linq;
using DBEntity.EnumEntity;

namespace Services.Helper.Pricings
{
    public class PricingHelper
    {
        public static IPricingHandler GetPricingHandler(Quota quota, SenLan2Entities ctx)
        {
            switch (quota.PricingType)
            {
                case (int)PricingType.Fixed:
                    return new FixPricingHandler(quota, ctx);

                case (int)PricingType.Manual:
                    return new ManualPricingHandler(quota, ctx);
                
                case (int)PricingType.Average:
                    return new AveragePricingHandler(quota,ctx);

                default:
                    return null;
            }
        }

        public static Currency GetCurrencyByPricingBasis(PricingBasis pb)
        {
            using (var ctx = new SenLan2Entities())
            {
                switch ((int)pb)
                {
                    case (int)PricingBasis.LME3M:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "USD");
                    case (int)PricingBasis.LMECash:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "USD");
                    case (int)PricingBasis.SGESettlement:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    case (int)PricingBasis.SHFE01:
                    case (int)PricingBasis.SHFE02:
                    case (int)PricingBasis.SHFE03:
                    case (int)PricingBasis.SHFE04:
                    case (int)PricingBasis.SHFE05:
                    case (int)PricingBasis.SHFE06:
                    case (int)PricingBasis.SHFE07:
                    case (int)PricingBasis.SHFE08:
                    case (int)PricingBasis.SHFE09:
                    case (int)PricingBasis.SHFE10:
                    case (int)PricingBasis.SHFE11:
                    case (int)PricingBasis.SHFE12:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    case (int)PricingBasis.SHX:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    case (int)PricingBasis.SHY:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    case (int)PricingBasis.PCJ:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    case (int)PricingBasis.NC:
                        return ctx.Currencies.FirstOrDefault(c => c.Code == "CNY");
                    default:
                        return null;
                }
            }
        }
    }
}