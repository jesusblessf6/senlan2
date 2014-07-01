namespace DBEntity.EnumEntity
{
    public class CurrentPriceType
    {
        public static string GetCurrentType(int pb)
        {
            string str = "";
            switch (pb)
            {
                case (int)PricingBasis.LME3M:
                    str = "USD";
                    break;
                case (int)PricingBasis.LMECash:
                    str = "USD";
                    break;
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
                    str = "CNY";
                    break;
                case (int)PricingBasis.SHX:
                    str = "CNY";
                    break;
                case (int)PricingBasis.SHY:
                    str = "CNY";
                    break;
                case (int)PricingBasis.PCJ:
                    str = "CNY";
                    break;
                case (int)PricingBasis.NC:
                    str = "CNY";
                    break;
            }
            return str;
        }
    }
}
