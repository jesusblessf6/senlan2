namespace DBEntity.ApprovalPlace
{
    public class CommonApprovalHandler : BaseApprovalHandler
    {
        /// <summary>
        /// 没有审批条件的单据都走common的审批流程
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ctx"></param>
        public CommonApprovalHandler(IApprovable entity, SenLan2Entities ctx) :
            base(entity, ctx)
        {
        }

        /// <summary>
        /// Check if there is approval procedure for current document
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override int CheckCondition(decimal amount)
        {
            return GetDefaultApproval();
        }
    }
}
