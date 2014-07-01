using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;
using Client.DeliveryLineServiceReference;
using Utility.ServiceManagement;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(decimal?))]
     public class TDOnlyQtyConverter : IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
         {
             var id = (int)value;
             decimal? onlyQty = 0;
             using (var deliveryLineService = SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
             {
                 const string str = "it.Id = @p1 ";
                 var parameters = new List<object> {id};
                 List<DeliveryLine> deliveryLineList = deliveryLineService.Select(str, parameters, new List<string> {"Delivery", "WarehouseInLines" });
                 if(deliveryLineList.Count > 0)
                 {
                     DeliveryLine deliveryLine = deliveryLineList[0];
                     decimal? qty = 0;
                     foreach(WarehouseInLine warehouseInLine in deliveryLine.WarehouseInLines)
                     {
                         if (!warehouseInLine.IsDeleted)
                        {
                            qty += warehouseInLine.VerifiedQuantity ?? 0;
                        }
                     }
                     if (deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || deliveryLine.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                     {
                         onlyQty = deliveryLine.VerifiedWeight - qty;
                     }
                     else if (deliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || deliveryLine.Delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
                     {
                         onlyQty = deliveryLine.NetWeight - qty;
                     }
                 }
             }

             return onlyQty;
         }

         public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
         {
             return null;
         }
    }
}
