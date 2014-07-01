using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(bool?), typeof(string))]
    public class IsSystemTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int customerType;
            if (value == null)
            {
                customerType = 0;
            }
            else
            {
                customerType = (bool) value ? 1 : 0;
            }

            return EnumHelper.GetDesByValue<IsSystemType>(customerType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}