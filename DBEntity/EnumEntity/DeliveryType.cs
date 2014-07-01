using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum DeliveryType
    {
        [Description("内贸提单")] InternalTDBOL = 1,
        [Description("内贸仓单")] InternalTDWW = 2,
        [Description("外贸提单")] ExternalTDBOL = 3,
        [Description("外贸仓单")] ExternalTDWW = 4,
        [Description("内贸发货单提单")]
        InternalMDBOL = 5,
        [Description("内贸发货单仓单")]
        InternalMDWW = 6,
        [Description("外贸发货单提单")]
        ExternalMDBOL = 7,
        [Description("外贸发货单仓单")]
        ExternalMDWW = 8
    }
}