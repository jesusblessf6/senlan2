using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPortService" in both code and config file together.
    [ServiceContract]
    public interface IPortService : IService<Port>
    {
        [OperationContract]
        Port AddNewPort(Port port, int userId);

        [OperationContract]
        Port UpdatePort(Port port, int userId);

        [OperationContract]
        List<Port> GetPortsByCountry(int countryId);
    }
}