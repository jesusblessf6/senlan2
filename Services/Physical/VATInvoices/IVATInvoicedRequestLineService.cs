using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVATInvoicedRequestLineService”。
    [ServiceContract]
    public interface IVATInvoicedRequestLineService : IService<VATInvoiceRequestLine>
    {
        [OperationContract]
        List<VATInvoiceRequestLine> GetVATInvoiceRequestLinesByQuotaList(int userId, List<int> quotaIds, int vatId);
    }
}
