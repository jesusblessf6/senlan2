using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICurrencyService" in both code and config file together.
    [ServiceContract]
    public interface ICurrencyService : IService<Currency>
    {
        [OperationContract]
        Currency AddNewCurrency(Currency currency,int userId);

        [OperationContract]
        Currency UpdateCurrency(Currency currency, int userId);

        [OperationContract]
        Currency GetCurrencyByCode(string code);
    }
}