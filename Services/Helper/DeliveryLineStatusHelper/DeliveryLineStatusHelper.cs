using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBEntity;
using System.Data;
using System.ServiceModel;
using Utility.ErrorManagement;
using DBEntity.EnumEntity;

namespace Services.Helper.DeliveryLineStatusHelper
{
    public class DeliveryLineStatusHelper
    {
        public static void GetDeliveryLineStatus(int deliveryLineId, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    SystemParameter systemParameter = ctx.SystemParameters.FirstOrDefault(c => c.IsDeleted == false);
                    DeliveryLine deliveryLine = ctx.DeliveryLines.Include("Delivery").Include("SalesDeliveryLines").Include("SalesDeliveryLines.Delivery").Include("WarehouseInLines").Where(c => c.Id == deliveryLineId).FirstOrDefault();
                    Delivery delivery = ctx.Deliveries.Include("DeliveryLines").Where(c => c.Id == deliveryLine.DeliveryId).FirstOrDefault();
                    decimal totalQty = GetQtyByDeliveryLine(deliveryLine);
                    decimal qty;
                    if (deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW ||
                        deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL) //内贸提单
                    {
                        qty = deliveryLine.VerifiedWeight == null ? 0 : (decimal)deliveryLine.VerifiedWeight;
                    }
                    else
                    {
                        qty = deliveryLine.NetWeight == null ? 0 : (decimal)deliveryLine.NetWeight;
                    }

                    if(qty > 0)
                    {
                        if (Math.Abs((qty - totalQty) / qty) <= Math.Abs(systemParameter.Inventory2Delivery / 100))
                        {
                            deliveryLine.DeliveryStatus = true;
                        }
                        else
                        {
                            deliveryLine.DeliveryStatus = false;
                        }
                    }
                    if (delivery.DeliveryLines.Where(c => c.DeliveryStatus == false && !c.IsDeleted).Count() > 0)
                    {
                        delivery.DeliveryStatus = false;
                    }
                    else
                    {
                        delivery.DeliveryStatus = true;
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private static decimal GetQtyByDeliveryLine(DeliveryLine deliveryLine)
        {
            decimal totalQty = 0;
            foreach (WarehouseInLine line in deliveryLine.WarehouseInLines)
            {
                if (!line.IsDeleted)
                {
                    totalQty += (line.VerifiedQuantity == null ? 0 : line.VerifiedQuantity.Value);
                }
            }
            foreach(DeliveryLine saleLine in deliveryLine.SalesDeliveryLines)
            {
                if(!saleLine.IsDeleted)
                {
                    if (saleLine.Delivery.DeliveryType == (int)DeliveryType.InternalMDWW || saleLine.Delivery.DeliveryType == (int)DeliveryType.InternalMDBOL)
                    {
                        totalQty += (saleLine.VerifiedWeight == null ? 0 : saleLine.VerifiedWeight.Value);
                    }
                    else
                    { 
                        totalQty += (saleLine.NetWeight == null ? 0 : saleLine.NetWeight.Value);
                    }
                }
            }

            return totalQty;
        }
    }
}