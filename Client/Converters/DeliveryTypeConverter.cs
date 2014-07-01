using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    /// <summary>
    /// 提单类型Converter
    /// </summary>
    [ValueConversion(typeof (int?), typeof (string))]
    public class DeliveryTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var deliveryType = (int) value;
            return deliveryType == 0 ? string.Empty : EnumHelper.GetDesByValue<DeliveryType>(deliveryType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}