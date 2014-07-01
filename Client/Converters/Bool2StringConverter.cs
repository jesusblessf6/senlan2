using System;
using System.Globalization;
using System.Windows.Data;

namespace Client.Converters
{
    [ValueConversion(typeof (bool?), typeof (string))]
    public class Bool2StringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var bv = (bool) value;
            return bv ? Properties.Resources.Yes : Properties.Resources.No;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}