using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISpecificationService" in both code and config file together.
    [ServiceContract]
    public interface ISpecificationService : IService<Specification>
    {
        [OperationContract]
        Specification AddNewSpecification(Specification specification, int userId);

        [OperationContract]
        Specification UpdateExistedSpecification(Specification specification, int userId);

        [OperationContract]
        List<Specification> GetSpecificationsWith(int commodityId, int commodityTypeId);
    }
}