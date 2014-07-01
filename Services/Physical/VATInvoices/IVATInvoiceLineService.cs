using System.ServiceModel;
using Services.Base;
using DBEntity;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVATInvoiceLineService”。
    [ServiceContract]
    public interface IVATInvoiceLineService:IService<VATInvoiceLine>
    {

    }
}
