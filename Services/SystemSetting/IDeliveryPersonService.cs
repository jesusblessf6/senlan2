﻿using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeliveryPersonService" in both code and config file together.
    [ServiceContract]
    public interface IDeliveryPersonService : IService<DeliveryPerson>
    {
        
    }
}
