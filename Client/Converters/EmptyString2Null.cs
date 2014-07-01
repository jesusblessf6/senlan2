using System;
using System.Globalization;
using System.Windows.Data;

namespace Client.Converters
{
    [ValueConversion(typeof (int?), typeof (string))]
    public class EmptyString2Null : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            return string.IsNullOrWhiteSpace(str) ? null : value;
        }

        #endregion
    }
}