using System.ComponentModel;

namespace DBEntity.EnumEntity
{
    //由于信用证项下的批次不是必填项，使用该标识位来区分采购还是销售项下的信用证
    public enum LCPorS
    {
        [Description("采购项下信用证")] LCPurchase = 1,
        [Description("销售项下信用证")] LCSales = 2
    }
}