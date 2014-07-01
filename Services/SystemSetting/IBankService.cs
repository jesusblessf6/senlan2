using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankService" in both code and config file together.
    [ServiceContract]
    public interface IBankService : IService<Bank>
    {
        [OperationContract]
        Bank AddNewBank(Bank bank, int userId);

        [OperationContract]
        Bank UpdateExistedBank(Bank bank, int userId);
    }
}