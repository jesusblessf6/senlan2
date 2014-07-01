using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class CommissionRuleTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int commissionTypeRule = (value == null ? 0 : (int) value);
            return commissionTypeRule == 0
                       ? string.Empty
                       : EnumHelper.GetDesByValue<CommissionRuleType>(commissionTypeRule);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}