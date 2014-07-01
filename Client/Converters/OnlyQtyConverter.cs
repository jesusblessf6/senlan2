using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Client.WarehouseInLineServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(decimal?))]
    public class OnlyQtyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int)value;
            decimal? result = 0;
            using (
                var warehouseInLineService =
                    SvcClientManager.GetSvcClient<WarehouseInLineServiceClient>(SvcType.WarehouseInLineSvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> {id};
                List<WarehouseInLine> warehouseInLines = warehouseInLineService.Select(str, parameters,
                                                                                       new List<string> { "WarehouseOutLines" });
                if (warehouseInLines.Count > 0)
                {
                    WarehouseInLine warehouseInLine = warehouseInLines[0];
                    decimal? qty = 0;
                    foreach (WarehouseOutLine outLine in warehouseInLine.WarehouseOutLines)
                    {
                        if (!outLine.IsDeleted)
                        {
                            decimal outLineQty = outLine.VerifiedQuantity == null ? 0 : (decimal)outLine.VerifiedQuantity;
                            qty += outLineQty;
                        }
                    }

                    result = warehouseInLine.VerifiedQuantity - qty;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}