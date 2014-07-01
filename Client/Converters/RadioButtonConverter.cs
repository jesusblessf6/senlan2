using System;
using System.Globalization;
using System.Windows.Data;

namespace Client.Converters
{
    public class RadioButtonConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if (value.ToString() == parameter.ToString())
                    return true;
                
                return false;
            }
            
            if (value is bool)
            {
                if (parameter.ToString() == "true")
                    return (bool) value;
                
                return !(bool) value;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is int)
            {
                if ((bool) value)
                    return (int) parameter;
            }
            else if (parameter.ToString() == "true")
            {
                return (bool) value;
            }
            else
            {
                return !(bool) value;
            }
            return 0;
        }

        #endregion
    }
}