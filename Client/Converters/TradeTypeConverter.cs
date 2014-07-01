using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    /// <summary>
    /// 贸易类型converter
    /// </summary>
    [ValueConversion(typeof(int?), typeof(string))]
    public class TradeTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tradeType = (int) value;
            string result = tradeType == 0 ? string.Empty : EnumHelper.GetDesByValue<TradeType>(tradeType);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}