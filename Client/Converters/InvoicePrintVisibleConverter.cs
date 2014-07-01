using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class InvoicePrintVisibleConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isVisible = "Visible";
            if (value == null)
            {
                return isVisible;
            }
            
            var result = (int)value;
            if (result == (int)ContractType.Purchase)
            {
                isVisible = "Hidden";
                return isVisible;
            }
            return isVisible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
