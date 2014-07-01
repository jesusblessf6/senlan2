using System.Linq;

namespace DBEntity.ApprovalPlace
{
    public sealed class QuotaApprovalHandler : BaseApprovalHandler
    {
        public QuotaApprovalHandler(IApprovable entity, SenLan2Entities ctx) : 
            base(entity, ctx)
        {
            
        }

        public override int CheckCondition(decimal amount)
        {
            var sp = CTX.SystemParameters.FirstOrDefault();
            if(sp == null || !sp.QuotaApprove)
            {
                return 0;
            }

            var curId = Entity.CurrencyIdForApproval;
            var approvals4Quota = CTX.Approvals.Include("ApprovalConditions").Where(o => o.DocumentId == Entity.DocumentId && !o.IsDeleted).ToList();

            var approval4AllCurrency =
                approvals4Quota.FirstOrDefault(o => o.ApprovalConditions.Count == 0);
            if (approval4AllCurrency != null)
            {
                return approval4AllCurrency.Id;
            }

            var c4Currency =
                approvals4Quota.SelectMany(o => o.ApprovalConditions).Where(c => !c.IsDeleted).FirstOrDefault(
                    o => o.CurrencyId == curId && amount >= o.LowerLimit && amount <= o.UpperLimit);

            if (c4Currency == null)
            {
                return 0;
            }

            return c4Currency.Approval.Id;
        }
    }
}
