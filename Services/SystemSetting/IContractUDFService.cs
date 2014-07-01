using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContractUDFService" in both code and config file together.
    [ServiceContract]
    public interface IContractUDFService : IService<ContractUDF>
    {
        [OperationContract]
        ContractUDF AddNewContractUDF(ContractUDF udf, int userId);

        [OperationContract]
        ContractUDF UpdateContractUDF(ContractUDF udf, int userId);
    }
}
