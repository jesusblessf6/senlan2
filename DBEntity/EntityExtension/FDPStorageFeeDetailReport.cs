using System;
using System.Runtime.Serialization;

namespace DBEntity
{
    [DataContract]
    public class FDPStorageFeeDetailReport
    {
        //仓单号
        [DataMember]
        public string DeliveryNo { get; set; }

        // 净重
        [DataMember]
        public string NetWeight { get; set; }

        //毛重
        [DataMember]
        public string GrossWeight { get; set; }

        //捆数
        [DataMember]
        public string Bundle { get; set; }

        //仓库
        [DataMember]
        public string WarehouseName { get; set; }

        //起始日期
        [DataMember]
        public DateTime? StartDate { get; set; }

        //结束日期
        [DataMember]
        public DateTime? EndDate { get; set; }

        //仓租
        [DataMember]
        public string StorageFee { get; set; }

        //货权转移费
        [DataMember]
        public string TransferFee { get; set; }

        //仓单费
        [DataMember]
        public string WarrantFee { get; set; }

        //总计
        [DataMember]
        public string TotalFee { get; set; }

        //币种
        [DataMember]
        public string CurrencyName { get; set; }

        //备注
        [DataMember]
        public string Comment { get; set; }
    }
}
