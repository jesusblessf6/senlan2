using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;

namespace Client.Converters
{
    [ValueConversion(typeof (PageMode), typeof (string))]
    public class PageModeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }

            if ((PageMode) value == PageMode.AddMode)
            {
                return Properties.Resources.Add;
            }

            if ((PageMode) value == PageMode.DeleteMode)
            {
                return Properties.Resources.Delete;
            }

            if ((PageMode) value == PageMode.EditMode)
            {
                return Properties.Resources.Edit;
            }

            if ((PageMode) value == PageMode.ViewMode)
            {
                return Properties.Resources.View;
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}