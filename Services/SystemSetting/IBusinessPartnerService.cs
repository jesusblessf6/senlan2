using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;
using DBEntity.EnumEntity;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBusinessPartnerService" in both code and config file together.
    [ServiceContract]
    public interface IBusinessPartnerService : IService<BusinessPartner>
    {
        [OperationContract]
        List<BusinessPartner> GetInternalCustomersByUser(int userId);

        [OperationContract]
        List<BusinessPartner> GetBusinessPartnersByType(BusinessPartnerType businessPartnerType);

        [OperationContract]
        void DeletedById(int id, int userId);
    }
}