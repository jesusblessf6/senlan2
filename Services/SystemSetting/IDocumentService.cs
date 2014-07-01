using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDocumentService" in both code and config file together.
    [ServiceContract]
    public interface IDocumentService : IService<Document>
    {
        [OperationContract]
        Document GetByName(string name);

        [OperationContract]
        Document GetByTableCode(string tableCode);
    }
}
