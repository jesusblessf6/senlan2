using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;
using System.Runtime.Serialization;
using System;

namespace Services.Physical.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContractService" in both code and config file together.
    [ServiceContract]
    public interface IContractService : IService<Contract>
    {
        [OperationContract]
        void CreateDocument(int userId, Contract header, List<Quota> addedQuotas,
                                   List<Attachment> addedAttachments, List<RelQuota> relQuotas, int? groupId);

        [OperationContract]
        void UpdateDocument(int userId, Contract header, List<Quota> addedQuotas,List<Quota> updatedQuotas,List<Quota> deletedQuotas,
                                   List<Attachment> addedAttachments, List<Attachment> deletedAttachments, List<RelQuota> relQuotas, int? groupId);

        [OperationContract]
        ContractEnableProperty SetElementsEnableProperty(int id);

        [OperationContract]
        void RemoveQuotaById(int id, int userId);

        [OperationContract]
        RelTransactionEnableProperty SetRelTransactionEnableProperty();

        [OperationContract]
        bool RelQuotaCanBeDelete(int userId, int stage, int contractId);
    }


    [DataContract]
    public class RelQuota
    {
        [DataMember]
        public int BusinessParnterId { get; set; }

        [DataMember]
        public string BusinessParnterName { get; set; }

        [DataMember]
        public decimal? Price { get; set; }

        [DataMember]
        public int QuotaStage { get; set; }

        [DataMember]
        public DateTime SignDate { get; set; }

        [DataMember]
        public DateTime? VATInvoiceDate { get; set; }
    }
}
