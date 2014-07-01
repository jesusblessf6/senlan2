using DBEntity.EnumEntity;

namespace DBEntity
{
    partial class LMEPosition
    {
        public int TradeDirectionValue
        {
            get
            {
                if (!TradeDirection.HasValue)
                {
                    return 0;
                }

                if (TradeDirection == (int)PositionDirection.Long)
                {
                    return 1;
                }

                return -1;
            }
        }

        public decimal AvailableLotForHedge { get; set; }
    }
}
