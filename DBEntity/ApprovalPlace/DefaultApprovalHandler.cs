namespace DBEntity.ApprovalPlace
{
    public class DefaultApprovalHandler : BaseApprovalHandler
    {
        /// <summary>
        /// 还没有纳入审批范畴的单据走该handler
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ctx"></param>
        public DefaultApprovalHandler(IApprovable entity, SenLan2Entities ctx) : 
            base(entity, ctx)
        {
            
        }
    }
}
