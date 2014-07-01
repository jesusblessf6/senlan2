using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRateService" in both code and config file together.
    [ServiceContract]
    public interface IRateService : IService<Rate>
    {
        [OperationContract]
        decimal? GetExchangeRate(int settleCurr, int curr, int userId);

        [OperationContract]
        Rate AddNewRate(Rate rate, int userId);

        [OperationContract]
        Rate UpdateRate(Rate rate, int userId);

        [OperationContract]
        decimal? GetExchangeRateByCode(string currencyCode, string baseCurrencyCode);
    }
}