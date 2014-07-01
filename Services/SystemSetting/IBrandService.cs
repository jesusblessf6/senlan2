using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBrandService" in both code and config file together.
    [ServiceContract]
    public interface IBrandService : IService<Brand>
    {
        [OperationContract]
        Brand AddNewBrand(Brand brand, int userId);

        [OperationContract]
        Brand UpdateExistedBrand(Brand brand, int userId);

        [OperationContract]
        List<Brand> GetBrandsWith(int commodityTypeId, int commodityId);
    }
}