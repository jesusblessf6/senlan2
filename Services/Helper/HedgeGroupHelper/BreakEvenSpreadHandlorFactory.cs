using DBEntity;
using DBEntity.EnumEntity;

namespace Services.Helper.HedgeGroupHelper
{
    public class BreakEvenSpreadHandlorFactory
    {
        public static IBreakEvenSpreadBaseHandlor GetHandlor(HedgeGroup hg)
        {
            switch (hg.ArbitrageType)
            {
                case (int)ArbitrageType.FPArbitrage:
                    return new FPHandlor();
                
                case (int)ArbitrageType.FPRevArbitrage:
                    return new FPRevHandlor();
                
                case (int)ArbitrageType.CarryArbitrage:
                    return new CarryHandlor();

                case (int)ArbitrageType.CarryRevArbitrage:
                    return new CarryRevHandlor();

                default:
                    return null;
            }
        }
    }
}