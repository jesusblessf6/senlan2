using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(decimal?), typeof(SolidColorBrush))]
    public class AvailableHedgeLot2Color : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return Brushes.DarkGray;
            }

            var qty = (decimal) value;
            if (Math.Round(qty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
            {
                return Brushes.DarkGray;
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
