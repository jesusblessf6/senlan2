using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum BusinessPartnerType
    {
        [Description("客户")]
        Customer = 1,
        [Description("经纪行")]
        Broker = 2,
        [Description("内部客户")]
        InternalCustomer = 3
    }
}