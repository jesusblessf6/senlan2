using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVATInvoice”。
    [ServiceContract]
    public interface IVATInvoiceRequestService : IService<VATInvoiceRequest>
    {
        [OperationContract]
        void UpdateInvoiceRequestAndInvoiceRequestLines(VATInvoiceRequest vatRquest, int userId);

        [OperationContract]
        void CreateDocument(int userId, VATInvoiceRequest header, List<VATInvoiceRequestLine> addedLines,List<Quota> quotaList);

        [OperationContract]
        void UpdateDocument(int userId, VATInvoiceRequest header, List<VATInvoiceRequestLine> addedLines,
                            List<VATInvoiceRequestLine> updatedLines, List<VATInvoiceRequestLine> deletedLines, List<Quota> quotaList);
    }
}
