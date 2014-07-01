using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Client.DeliveryServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(decimal))]
    public class InvoiceNetWeightConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0.0M;
            }

            var invoiceId = (int) value;
            decimal netWeight = 0.0M;
            using (
                var deliveryService =
                    SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                List<Delivery> deliveries = deliveryService.Select("it.CommercialInvoiceId=" + invoiceId,
                                                                               null, new List<string> {"DeliveryLines"});
                if (deliveries.Count>0)
                {
                    netWeight = (decimal)deliveries.Sum(o => o.TotalNetWeight);
                }
            }
            return netWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}