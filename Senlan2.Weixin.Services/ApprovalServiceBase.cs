using System;
using System.Collections.Generic;
using DBEntity;
using DBEntity.EnumEntity;
using System.Linq;

namespace Senlan2.Weixin.Services
{
	public abstract class ApprovalServiceBase<TEntity> where TEntity : class, IApprovable, IEntity, new()
	{
		//public List<TEntity> GetApprovalEntities(int userId, List<string> includes = null)
		//{
		//    try
		//    {
		//        using (var ctx = new Senlan2Entities())
		//        {
		//            var q = ctx.Set<TEntity>().Include("Approval")
		//                       .Include("Approval.ApprovalStages")
		//                       .Include("Approval.ApprovalStages.User");
					
		//            if (includes != null && includes.Count > 0)
		//            {
		//                q = includes.Aggregate(q, (current, include) => current.Include(include));
		//            }
					
		//            return
		//                   q.Where(
		//                       o =>!o.IsDeleted && 
		//                       o.ApprovalId != null &&
		//                       (o.ApproveStatus == (int) ApproveStatus.InApprove || o.ApproveStatus == (int) ApproveStatus.ApproveNotStart) &&
		//                       o.Approval.ApprovalStages.Where(t => t.StageIndex == o.ApprovalStageIndex && !t.IsDeleted)
		//                        .Select(t => t.ApprovalUserId)
		//                        .Contains(userId)).ToList();

		//        }
		//    }
		//    catch (Exception)
		//    {
		//        throw;
		//    }
		//}

		//protected int GetUserIdByName(string userName)
		//{
		//    using (var ctx = new Senlan2Entities())
		//    {
		//        var user = ctx.Users.Single(o => o.LoginName == userName);
		//        return user.Id;
		//    }
		//}

		//protected int GetUserIdByOpenId(string openId)
		//{
		//    using (var ctx = new Senlan2Entities())
		//    {
		//        var user = ctx.Users.Single(o => o.WeixinOpenId == openId);
		//        return user.Id;
		//    }
		//}

		public abstract void ApproveDocument(int id, string userName);

		public abstract void RejectDocument(int id, string rejectReason, string userName);

		public static void ParseApprovalDetailString(List<ApprovalStage> stages, int currentStageIndex, out string passed,
											  out string notPassed)
		{
			//todo replace the linq logic with more clear code
			stages = stages.OrderBy(o => o.StageIndex).ToList();
			List<IGrouping<int?, ApprovalStage>> stageGroup = stages.GroupBy(o => o.StageIndex).ToList();

			List<string> passedUsers =
				stageGroup.Select(
					g =>
					string.Join("/",
								g.Where(o => o.StageIndex < currentStageIndex).Select(
									o => o.ApprovalUser.Name))).ToList();

			passedUsers = passedUsers.Where(o => o.Trim().Length > 0).ToList();

			passed = string.Join("->", passedUsers);

			List<string> notPassedUsers =
				stageGroup.Select(
					g =>
					string.Join("/",
								g.Where(o => o.StageIndex >= currentStageIndex).Select(
									o => o.ApprovalUser.Name))).ToList();

			notPassedUsers = notPassedUsers.Where(o => o.Trim().Length > 0).ToList();

			notPassed = string.Join("->", notPassedUsers);
			if (!string.IsNullOrWhiteSpace(notPassed) &&
				!string.IsNullOrWhiteSpace(passed))
			{
				notPassed = "->" + notPassed;
			}
		}
	}
}
