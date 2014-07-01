using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBEntity;
using Services.Base;

namespace Services.Physical
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseInService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseInService : IService<WarehouseIn>
    {
        
    }
}
