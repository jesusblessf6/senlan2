using System.ServiceModel;
using Services.Base;
using DBEntity;
using System.Collections.Generic;
using DBEntity.EnableProperty;

namespace Services.Physical.Deliveries
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDeliveryService”。
    [ServiceContract]
    public interface IDeliveryService : IService<Delivery>
    {
        [OperationContract]
        void UpdateDataForInternal(int userId, Delivery header, List<DeliveryLine> addedLines,
                                   List<DeliveryLine> updatedLines,
                                   List<DeliveryLine> deletedLines, List<Attachment> addedAttachments,
                                   List<Attachment> deletedAttachments);
        [OperationContract]
        void CreateDataForInternal(int userId, Delivery header, List<DeliveryLine> addedLines, List<Attachment> addedAttachments);
        [OperationContract]
        List<DeliveryLine> GetAllDeliveryLines();
        [OperationContract]
        void CreateData(int userId, List<Delivery> deliveryList, List<DeliveryLine> addedLines);
        [OperationContract]
        void CreateDocument(int userId, Delivery header, List<DeliveryLine> addedLines, List<Attachment> addedAttachments);

        [OperationContract]
        void UpdateData(int userId, List<Delivery> addDeliveryList, List<Delivery> deleteDeliveryList, List<DeliveryLine> addDeliveryLineList, List<DeliveryLine> deleteDeliveryLineList);
    
        [OperationContract]
        void UpdateDocument(int userId, Delivery header, List<DeliveryLine> addedLines, List<DeliveryLine> updatedLines,
                                            List<DeliveryLine> deletedLines, List<Attachment> addedAttachments, List<Attachment> deletedAttachments);
        [OperationContract]
        DeliveryEnableProperty SetElementsEnableProperty(int id);

        [OperationContract]
        decimal GetSaleDeliveryQuantityById(int deliveryId, int userId);

        [OperationContract]
        bool IsReexport(int id, int userId);

        //[OperationContract]
        //bool HasNotSplitMD(int id, int userId);
    }
}
