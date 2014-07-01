using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICountryService" in both code and config file together.
    [ServiceContract]
    public interface ICountryService : IService<Country>
    {
        [OperationContract]
        Country AddNewCountry(Country country, int userId);

        [OperationContract]
        Country UpdateCountry(Country country, int userId);
    }
}