using System;
using System.Globalization;
using System.Windows.Data;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.LetterOfCreditServiceReference;
using DBEntity;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class LCPorSConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int) value;
            string result = string.Empty;
            using (
                     var letterOfCreditService =
                         SvcClientManager.GetSvcClient<LetterOfCreditServiceClient>(SvcType.LetterOfCreditSvc))
            {
                LetterOfCredit lc = letterOfCreditService.GetById(id);
                if(lc != null)
                {
                    string pOrs = lc.PorS == 0 ? string.Empty : EnumHelper.GetDesByValue<LCPorS>(lc.PorS);
                    string type = lc.LCType == 0 ? string.Empty : EnumHelper.GetDesByValue<LCType>(lc.LCType);
                    result = pOrs + "-" + type;
                }

            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}