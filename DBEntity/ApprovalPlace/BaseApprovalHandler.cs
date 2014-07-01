using System.Linq;
using DBEntity.EnumEntity;

namespace DBEntity.ApprovalPlace
{
	public class BaseApprovalHandler 
	{
		public IApprovable Entity { get; set; }
		public SenLan2Entities CTX { get; set; }
		public int ApprovalId { get; set; }

		public virtual int CheckCondition(decimal amount)
		{
			return 0;
		}

		public virtual void StartApprove()
		{
			Entity.ApproveStatus = (int) ApproveStatus.NoApproveNeeded;
			Entity.IsDraft = false;
			
			if(ApprovalId > 0)
			{
				Entity.IsDraft = true;
				var a = CTX.Approvals.Include("ApprovalStages").Include("ApprovalStages.ApprovalUser").SingleOrDefault(o => o.Id == ApprovalId);
				if(a != null)
				{
					var firstStage = a.ApprovalStages.OrderBy(o => o.StageIndex).FirstOrDefault();
					if(firstStage != null)
					{
						Entity.ApproveStatus = (int) ApproveStatus.ApproveNotStart;
						Entity.IsDraft = true;
						Entity.ApprovalStageIndex = firstStage.StageIndex;
						Entity.ApprovalId = firstStage.ApprovalId;

						var users =
						a.ApprovalStages.Where(o => o.StageIndex == firstStage.StageIndex && !o.IsDeleted)
						 .Select(o => o.ApprovalUser).ToList();
						foreach (var user in users)
						{
							//CTX.WeixinAlerts.AddObject(new WeixinAlert { DocumentId = Entity.DocumentId??0, UserId = userId });
							if (!string.IsNullOrWhiteSpace(user.WeixinOpenId))
							{
								if (
									!CTX.WeixinAlerts.Any(
										o => o.UserId == user.Id && o.OpenId == user.WeixinOpenId && o.DocumentId == Entity.DocumentId))
								{
									CTX.WeixinAlerts.AddObject(new WeixinAlert { DocumentId = Entity.DocumentId ?? 0, UserId = user.Id, OpenId = user.WeixinOpenId });
								}
								
							}
						}
					}
				}
			}
		}

		public virtual void Handle()
		{
			ApprovalId = CheckCondition(Entity.AmountForApproval);

			if(ApprovalId > 0)
			{
				StartApprove();
			}
			else
			{
				Entity.ApproveStatus = (int)ApproveStatus.NoApproveNeeded;
				Entity.ApprovalId = null;
				Entity.ApprovalStageIndex = null;
			}
			Entity.RejectReason = string.Empty;
		}

		public BaseApprovalHandler(IApprovable entity, SenLan2Entities ctx)
		{
			Entity = entity;
			CTX = ctx;
		}

		protected int GetDefaultApproval()
		{
			var a =
				CTX.Approvals.Include("ApprovalConditions").Where(o => o.DocumentId == Entity.DocumentId && o.IsDefault && !o.IsDeleted)
					.ToList().FirstOrDefault();
			if (a == null)
			{
				return 0;
			}

			return a.Id;
		}
	}
}
