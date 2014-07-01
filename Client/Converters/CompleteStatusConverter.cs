using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class CompleteStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return string.Empty;
            }

            var v = (int) value;
            if(v == (int) CompleteStatus.Complete)
            {
                return Properties.Resources.Completed;
            }

            if(v==(int)CompleteStatus.NotComplete)
            {
                return Properties.Resources.NotCompleted;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
