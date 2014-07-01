using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;
using DBEntity.EnumEntity;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankAccountService" in both code and config file together.
    [ServiceContract]
    public interface IBankAccountService : IService<BankAccount>
    {
        [OperationContract]
        List<BankAccount> GetBankAccountsByCurrencyIdAndCustomerId(int currencyId, int userId, BankAccountType bankAccountType);

        [OperationContract]
        List<BankAccount> GetBankAccountsByPaymentMean(int? currencyId, int userId);

        [OperationContract]
        BankAccount UpdateExistedAccount(BankAccount account, int userId);

        [OperationContract]
        BankAccount AddNewAccount(BankAccount account, int userId);

        [OperationContract]
        BankAccount GetDefaultBankAccountByBusinessPartnerId(int userId, int businessPartnerId, int? currencyId);
    }
}