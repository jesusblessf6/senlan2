using System;
using System.Globalization;
using System.Windows.Data;

namespace Client.Converters
{
    [ValueConversion(typeof (int?), typeof (bool))]
    public class NullEmptyInt2Bool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            var ivalue = (int) value;
            if (ivalue == 0)
            {
                return false;
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
