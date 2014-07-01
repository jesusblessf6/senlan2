using DBEntity.EnumEntity;

namespace DBEntity
{
    partial class SHFEPosition
    {
        public int TradeDirectionValue
        {
            get
            {
                if (!PositionDirection.HasValue)
                {
                    return 0;
                }

                if (PositionDirection == (int)EnumEntity.PositionDirection.Long)
                {
                    return 1;
                }

                return -1;
            }
        }

        public int OpenCloseValue
        {
            get
            {
                if (!OpenClose.HasValue)
                {
                    return 0;
                }

                if (OpenClose == (int)PositionOpenClose.Open)
                {
                    return 1;
                }

                return -1;
            }
        }

        public decimal AvailableLotForHedge { get; set; }
    }
}
