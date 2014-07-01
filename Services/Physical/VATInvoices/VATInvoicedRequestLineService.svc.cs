using DBEntity;
using Services.Base;
using System.Collections.Generic;
using Services.Physical.Pricings;

namespace Services.Physical.VATInvoices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“VATInvoicedRequestLineService”。
    public class VATInvoicedRequestLineService : BaseService<VATInvoiceRequestLine>, IVATInvoicedRequestLineService
    {
        public List<VATInvoiceRequestLine> GetVATInvoiceRequestLinesByQuotaList(int userId, List<int> quotaIds,int vatId)
        {
            var lines = new List<VATInvoiceRequestLine>();

            foreach (var quotaId in quotaIds)
            {
                var line = GetVATInvoiceRequestLinesByQuotaId(userId, quotaId);
                line.Id = vatId--;
                lines.Add(line);
            }

            return lines;
        }

        private VATInvoiceRequestLine GetVATInvoiceRequestLinesByQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                VATInvoiceRequestLine line = new VATInvoiceRequestLine();
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Deliveries", "WarehouseOuts" }), 
                    o => o.Id == quotaId);
                EntityUtil.FilterDeletedEntity(quota.Deliveries);
                EntityUtil.FilterDeletedEntity(quota.WarehouseOuts);
                line.UnOpenedQuantity = quota.VerifiedQuantity - (quota.VATInvoicedQuantity ?? 0);
                decimal amt = (quota.FinalPrice ?? 0) * (line.UnOpenedQuantity ?? 0);
                line.RequestQuantity = line.UnOpenedQuantity;
                line.RequestAmount = amt;
                line.RequestPrice = quota.FinalPrice;
                quota.IsVatRequestFinished = true;
                line.QuotaId = quotaId;
                line.Quota = quota;
                //line.Quota.IsVatRequestFinished = true;
                line.ApproveStatus = 0;
                return line;
            }
        }
    }
}
