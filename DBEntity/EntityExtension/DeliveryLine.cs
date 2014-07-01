using System.Linq;
using System.Runtime.Serialization;
using DBEntity.EnumEntity;

namespace DBEntity
{
    partial class DeliveryLine
    {
        private decimal? _onlyQty;//剩余数量
        private decimal? _onlyVerfiedQty;//剩余实际数量
        private decimal? _onlyGrossWeight;//剩余毛重
        private decimal? _onlyPackingQuantity;//剩余捆数（发货单用）
        [DataMember]
        public int DeliveryPID { get; set; }
        [DataMember]
        public decimal? OnlyQty
        {
            get
            {
                if (Delivery != null)
                {   
                    decimal? totalQty = 0;
                    if (WarehouseInLines != null && WarehouseInLines.Count > 0)
                    {
                        totalQty += WarehouseInLines.Where(c => c.IsDeleted == false).Sum(o => o.Quantity);
                    }
                    if (SalesDeliveryLines != null && SalesDeliveryLines.Count > 0)//对应的发货单列表
                    {
                        totalQty += SalesDeliveryLines.Where(c => c.IsDeleted == false).Sum(o => o.NetWeight);
                    }
                    _onlyQty = NetWeight - totalQty;
                    
                }
                return _onlyQty;
            }

            set { _onlyQty = value; }
        }

        [DataMember]
        public decimal? OnlyGrossWeight
        {
            get
            {
                if (Delivery != null)
                {
                    decimal? totalQty = 0;
                    if (WarehouseInLines != null && WarehouseInLines.Count > 0)
                    {
                        totalQty += WarehouseInLines.Where(c => c.IsDeleted == false).Sum(o => o.VerifiedQuantity);
                    }
                    if (SalesDeliveryLines != null && SalesDeliveryLines.Count > 0)//对应的发货单列表
                    {
                        totalQty += SalesDeliveryLines.Where(c => c.IsDeleted == false).Sum(o => o.GrossWeight);
                    }
                    _onlyGrossWeight = GrossWeight - totalQty;
                }
                return _onlyGrossWeight;
            }

            set { _onlyGrossWeight = value; }
        }

        [DataMember]
        public decimal? OnlyVerfiedQty
        {
            get
            {
                if (Delivery != null)
                {
                        decimal? totalQty = 0;
                        if (WarehouseInLines != null && WarehouseInLines.Count > 0)
                        {
                            totalQty += WarehouseInLines.Where(c => c.IsDeleted == false).Sum(o => o.VerifiedQuantity);
                        }
                        if (SalesDeliveryLines != null && SalesDeliveryLines.Count > 0)//对应的发货单列表
                        {
                            totalQty += SalesDeliveryLines.Where(c => c.IsDeleted == false).Sum(o => o.VerifiedWeight);
                        }

                        if (Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || Delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                        {
                            _onlyVerfiedQty = VerifiedWeight - totalQty;
                        }
                        else if (Delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                        {
                            _onlyVerfiedQty = NetWeight - totalQty;
                        }
                }
                return _onlyVerfiedQty;
            }
            set { _onlyVerfiedQty = value; }
        }

        [DataMember]
        public decimal? OnlyPackingQuantity
        {
            get
            {
                if (Delivery != null)
                {
                    decimal? totalPackingQuantity = 0;
                    if (WarehouseInLines != null && WarehouseInLines.Count > 0)
                    {
                        totalPackingQuantity += WarehouseInLines.Where(c => c.IsDeleted == false).Sum(o => o.PackingQuantity);
                    }
                    if (SalesDeliveryLines != null && SalesDeliveryLines.Count > 0)//对应的发货单列表
                    {
                        totalPackingQuantity += SalesDeliveryLines.Where(c => c.IsDeleted == false).Sum(o => o.PackingQuantity ?? 0);
                    }
                    _onlyPackingQuantity = (PackingQuantity ?? 0) - totalPackingQuantity;
                }
                return _onlyPackingQuantity;
            }

            set { _onlyPackingQuantity = value; }
        }

        [DataMember]
        public bool? DlvLineIsVerified { get; set; }
    }
}
