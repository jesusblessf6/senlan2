using System.ServiceModel;
using Services.Base;
using DBEntity;
using System.Collections.Generic;

namespace Services.Attachments
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAttachmentService" in both code and config file together.
    [ServiceContract]
    public interface IAttachmentService:IService<Attachment>
    {
        [OperationContract]
        List<Attachment> ChangeAttachmentName(IEnumerable<Attachment> attachments);

        [OperationContract]
        List<Attachment> GetAttachments(int documentTypeId, int recId);
    }
}
