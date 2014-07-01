using System;
using System.Windows.Data;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class PositionDirectionConverter : IValueConverter
    {
        #region IValueConverter 成员

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tradeType = (value == null ? 0 : (int)value);
            string result = tradeType == 0 ? string.Empty : EnumHelper.GetDesByValue<DBEntity.EnumEntity.PositionDirection>(tradeType);
            return result;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
