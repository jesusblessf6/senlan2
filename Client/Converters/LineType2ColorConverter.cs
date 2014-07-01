using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Client.ViewModel.Reports;

namespace Client.Converters
{
    [ValueConversion(typeof(BrokerPLDetailLineType), typeof(SolidColorBrush))]
    public class LineType2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Brushes.Black;

            var lineType = (BrokerPLDetailLineType) value;
            switch (lineType)
            {
                case BrokerPLDetailLineType.BrokerFooter:
                    return Brushes.Crimson;

                case BrokerPLDetailLineType.GridFooter:
                    return Brushes.SteelBlue;

                case BrokerPLDetailLineType.PromptDateFooter:
                    return Brushes.SteelBlue;

                case BrokerPLDetailLineType.BrokerHeader:
                    return Brushes.Crimson;

                case BrokerPLDetailLineType.PromptDateHeader:
                    return Brushes.SteelBlue;

                case BrokerPLDetailLineType.ErrorWarning:
                    return Brushes.Red;

                case BrokerPLDetailLineType.NormalLine:
                    return Brushes.Black;

                default:
                    return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
