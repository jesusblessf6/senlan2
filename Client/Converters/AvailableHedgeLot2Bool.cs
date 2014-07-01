using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(decimal?), typeof(bool))]
    public class AvailableHedgeLot2Bool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return false;
            }

            var v = (decimal) value;
            if (Math.Round(v, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
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
