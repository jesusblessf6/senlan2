using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    public enum ContractType
    {
        [Description("采购")] Purchase = 1,
        [Description("销售")] Sales = 2
    }
}