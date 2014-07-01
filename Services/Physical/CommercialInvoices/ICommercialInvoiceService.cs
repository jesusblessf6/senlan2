using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;

namespace Services.Physical.CommercialInvoices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommercialInvoiceService" in both code and config file together.
    [ServiceContract]
    public interface ICommercialInvoiceService : IService<CommercialInvoice>
    {
        [OperationContract]
        void CreateCommercialInvoice(int userId, CommercialInvoice header, List<LCCIRel> addLCCIRels,
                                   List<Delivery> addDelivery, List<Attachment> addedAttachments, bool isCIFinished);

        [OperationContract]
        void UpdateCommercialInvoice(int userId, CommercialInvoice header, List<LCCIRel> addLCCIRels, List<LCCIRel> deleteRels,
                                   List<Delivery> addDelivery, List<Delivery> deleteDelivery, List<Attachment> addedAttachments, List<Attachment> deletedAttachments, bool changeQuota, bool isCIFinished);



        [OperationContract]
        void CreateFinalCommercialInvoice(int userId, CommercialInvoice header, List<CommercialInvoice> addedInvoice, List<Attachment> addedAttachments, bool isCIFinished);

        [OperationContract]
        void UpdateFinalCommercialInvoice(int userId, CommercialInvoice header, List<CommercialInvoice> addedInvoice, List<CommercialInvoice> deletedInvoice, List<Attachment> addedAttachments, List<Attachment> deletedAttachments, bool changeQuota, bool isCIFinished);

        [OperationContract]
        void RemoveInvoice(int id, int userId);

        [OperationContract]
        PCommercialInvoiceEnableProperty SetElementsEnableProperty(int id);

        [OperationContract]
        List<Delivery> GetDeliveryByInvoiceId(int userId, int invoiceId);
    }
}
