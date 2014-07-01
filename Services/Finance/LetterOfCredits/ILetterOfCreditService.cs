using System.Collections.Generic;
using System.ServiceModel;
using Services.Base;
using DBEntity;
using DBEntity.EnableProperty;

namespace Services.Finance.LetterOfCredits
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ILetterOfCreditService”。
    [ServiceContract]
    public interface ILetterOfCreditService:IService<LetterOfCredit>
    {
        [OperationContract]
        void CreateNewLetterOfCredit(LetterOfCredit lc, int userId, List<Delivery> deliveries, List<Attachment> addedAttachments, bool isLCFinished);

        [OperationContract]
        void UpdateExistedLetterOfCredit(LetterOfCredit lc, int userId, List<Delivery> deliveries,List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments, bool isLCFinished);
        [OperationContract]
        LCEnableProperty SetElementsEnableProperty(int id);
    }
}
