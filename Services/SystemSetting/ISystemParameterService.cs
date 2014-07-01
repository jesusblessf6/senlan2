using System.ServiceModel;
using Services.Base;
using DBEntity;
using System.Collections.Generic;

namespace Services.SystemSetting
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISystemParameterService" in both code and config file together.
	[ServiceContract]
	public interface ISystemParameterService : IService<SystemParameter>
	{
        [OperationContract]
        List<string> GetDiskNameList();
	}
}
