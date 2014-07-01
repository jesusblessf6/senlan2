using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class ArbitrageTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var arbitrageTypeId = (int) value;
            if (arbitrageTypeId <= 0)
                return string.Empty;

            return EnumHelper.GetDesByValue<ArbitrageType>(arbitrageTypeId);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
