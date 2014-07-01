using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class HedgeGroupStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return string.Empty;
            }

            var statusId = (int) value;
            var result = EnumHelper.GetDesByValue<HedgeGroupStatus>(statusId);
            if (result == null)
                return string.Empty;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
