using System.Linq;

namespace DBEntity.ApprovalPlace
{
    public class PaymentRequestApprovalHandler : BaseApprovalHandler
    {
        /// <summary>
        /// Payment Request Approval Handler
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ctx"></param>
        public PaymentRequestApprovalHandler(IApprovable entity, SenLan2Entities ctx) :
            base(entity, ctx)
        {
        }

        /// <summary>
        /// Check the approval procedure
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override int CheckCondition(decimal amount)
        {
            var sp = CTX.SystemParameters.FirstOrDefault();
            if (sp == null || !sp.PaymentRequestApprove)
            {
                return 0;
            }

            return GetDefaultApproval();
        }
    }
}
