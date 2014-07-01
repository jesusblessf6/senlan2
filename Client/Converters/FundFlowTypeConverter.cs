using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class FundFlowTypeConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var rorP = (int) value;
            string result = rorP == 0 ? string.Empty : EnumHelper.GetDesByValue<FundFlowType>(rorP);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}