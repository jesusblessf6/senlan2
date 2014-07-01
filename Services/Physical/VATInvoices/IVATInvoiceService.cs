using System.Collections.Generic;
using System.ServiceModel;
using Services.Base;
using DBEntity;
using System.Runtime.Serialization;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVATInvoiceService”。
    [ServiceContract]
    public interface IVATInvoiceService : IService<VATInvoice>
    {
        [OperationContract]
        void CreateDocument(int userId, VATInvoice header, List<VATInvoiceLine> addedLines);

        [OperationContract]
        void UpdateDocument(int userId, VATInvoice header, List<VATInvoiceLine> addedLines,
                            List<VATInvoiceLine> updatedLines, List<VATInvoiceLine> deletedLines);

        [OperationContract]
        decimal OpenQty(int quotaId, int userId);

        [OperationContract]
        void CreateDocumentByVATInvoiceBatch(int userId, List<VATInvoiceBatchClass> batch);

        [OperationContract]
        List<VATInvoiceBatchClass> GetBatchInvoiceByLines(int userId,List<VATInvoiceRequestLine> list);
    }

    [DataContract]
    public class VATInvoiceBatchClass
    {
        [DataMember]
        public VATInvoice VATInvoice { get; set; }

        [DataMember]
        public List<VATInvoiceLine> VATInvoiceLines { get; set; }
    }
}
