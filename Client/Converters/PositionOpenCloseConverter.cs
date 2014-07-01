using System;
using System.Globalization;
using System.Windows.Data;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class PositionOpenCloseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var openClose = (value == null ? 0 : (int)value);
            string result = openClose == 0 ? string.Empty : EnumHelper.GetDesByValue<DBEntity.EnumEntity.PositionOpenClose>(openClose);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
