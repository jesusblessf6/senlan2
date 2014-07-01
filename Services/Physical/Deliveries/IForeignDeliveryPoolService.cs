using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using System;
using DBEntity.EnableProperty;

namespace Services.Physical.Deliveries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IForeignDeliveryPoolService" in both code and config file together.
    [ServiceContract]
    public interface IForeignDeliveryPoolService : IService<ForeignDeliveryPool>
    {
        [OperationContract]
        List<ForeignDeliveryPoolLine> GetDetailLinesById(int id);

        [OperationContract]
        ForeignDeliveryPool CreateDocument(ForeignDeliveryPool dp, List<ForeignDeliveryPoolLine> lines,
                                           List<Attachment> attachments, List<FDPStorageFeeSEDate> storageDates, int userId);

        [OperationContract]
        ForeignDeliveryPool UpdateDocument(ForeignDeliveryPool dp, List<ForeignDeliveryPoolLine> newLines,
                                           List<ForeignDeliveryPoolLine> modifiedLines,
                                           List<ForeignDeliveryPoolLine> deletedLines, List<Attachment> newAttachments,
                                           List<Attachment> deletedAttachments, List<FDPStorageFeeSEDate> newStorageDates,
                                           List<FDPStorageFeeSEDate> modifiedStorageDates, List<FDPStorageFeeSEDate> deletedStorageDates, int userId);

        [OperationContract]
        List<FDPStorageFeeDetailReport> GetDataList(string deliveryNo, int? warehouseId, DateTime? startDate, DateTime? endDate, int userId);

        [OperationContract]
        List<FDPStorageFeeSEDate> GetStorageDates(int fdpId);

        [OperationContract]
        ForeignDeliveryPoolEnableProperty SetElementsEnableProperty(int id);
    }
}
