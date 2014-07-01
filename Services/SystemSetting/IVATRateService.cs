using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVATRateService" in both code and config file together.
    [ServiceContract]
    public interface IVATRateService : IService<VATRate>
    {
        [OperationContract]
        VATRate AddNewVATRate(VATRate vatRate, int userId);

        [OperationContract]
        VATRate UpdateVATRate(VATRate vatRate, int userId);
    }
}