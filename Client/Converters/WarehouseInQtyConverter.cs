using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Client.DeliveryLineServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(decimal))]
    public class WarehouseInQtyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal? warehouseInQty = 0;
            if (value != null)
            {
                var id = (int) value;
                if (id > 0)
                {
                    using (
                        var deliveryLineService =
                            SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
                    {
                        const string str = "it.Id = @p1";
                        var parameters = new List<object> { id };
                        List<DeliveryLine> list = deliveryLineService.Select(str, parameters,
                                                                             new List<string> { "WarehouseInLines" });
                        if (list.Count > 0)
                        {
                            DeliveryLine deliveryLine = list[0];
                            foreach (WarehouseInLine line in deliveryLine.WarehouseInLines)
                            {
                                if (!line.IsDeleted)
                                {
                                    decimal qty = line.VerifiedQuantity == null ? 0 : (decimal)line.VerifiedQuantity;
                                    warehouseInQty += qty;
                                }
                            }
                        }
                    }
                }
                else
                {
                    warehouseInQty = null;
                }
            }
            return warehouseInQty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}