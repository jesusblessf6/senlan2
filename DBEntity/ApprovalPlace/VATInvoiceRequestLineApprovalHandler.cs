using System.Linq;

namespace DBEntity.ApprovalPlace
{
    public class VATInvoiceRequestLineApprovalHandler : BaseApprovalHandler
    {
        /// <summary>
        /// 没有审批条件的单据都走common的审批流程
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ctx"></param>
        public VATInvoiceRequestLineApprovalHandler(IApprovable entity, SenLan2Entities ctx) :
            base(entity, ctx)
        {
        }

        public override int CheckCondition(decimal amount)
        {
            var sp = CTX.SystemParameters.FirstOrDefault();
            if (sp == null || !sp.VATInvoiceApprove)
            {
                return 0;
            }

            return GetDefaultApproval();
        }
    }
}
