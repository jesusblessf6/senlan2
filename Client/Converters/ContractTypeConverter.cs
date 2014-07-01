using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.Converters
{
    /// <summary>
    /// 合同类型converter
    /// </summary>
    [ValueConversion(typeof (int?), typeof (string))]
    public class ContractTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var contractType = (int) value;
            string result = contractType == 0 ? string.Empty : EnumHelper.GetDesByValue<ContractType>(contractType);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}