using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Utility.ServiceManagement;
using Client.UserServiceReference;
using DBEntity;
using System.Windows.Data;

namespace Client.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class CreatedByConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string loginName = string.Empty;
            var id = (int)value;
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                User user = userService.SelectById(null, id);
                if(user != null)
                {
                    loginName = user.LoginName;
                }
            }
            return loginName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
