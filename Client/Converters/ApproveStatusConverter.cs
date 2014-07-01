using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    [ValueConversion(typeof (int?), typeof (string))]
    public class ApproveStatusConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var approveStatus = (int) value;

            return (approveStatus == 0 ? string.Empty : EnumHelper.GetDesByValue<ApproveStatus>(approveStatus));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}