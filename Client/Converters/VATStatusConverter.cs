using System;
using System.Windows.Data;
using Utility.Misc;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class VATStatusConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tradeType =(value==null?0: (int)value);
            string result = tradeType == 0 ? string.Empty : EnumHelper.GetDesByValue<QuotaVATStatus>(tradeType);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
