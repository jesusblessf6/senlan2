using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum DeliveryTypeWarehouseIn
    {
        [Description("内贸提单或者仓单入库")] InternalWarehouseIn = 1,
        [Description("外贸提单或者仓单入库")] ExternalWarehouseIn = 2
    }
}