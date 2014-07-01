using System;
using System.Windows.Data;
using System.Globalization;
using Utility.Misc;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class VATInvoiceTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vatInvoiceType = (int)value;
            string result = vatInvoiceType == 0 ? string.Empty : EnumHelper.GetDesByValue<VATInvoiceType>(vatInvoiceType);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion

    }
}
