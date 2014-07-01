using System.Collections.Generic;
using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using Senlan2.Weixin.Services.ApprovalServiceReference;
using Senlan2.Weixin.Services.BusinessPartnerServiceReference;
using Senlan2.Weixin.Services.QuotaServiceReference;
using Senlan2.Weixin.Services.UserServiceReference;
using Utility.ServiceManagement;

namespace Senlan2.Weixin.Services
{
	public class ContractApprovalService : ApprovalServiceBase<Quota>
	{
		public List<Quota> GetQuotaApprovalsByName(string userName)
		{
			var quotas = new List<Quota>();
			var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc);
			string condition =
				"it.ApprovalId is not NULL and (it.ApproveStatus = @p1 or it.ApproveStatus = @p2)";
			var icList = new List<int>();
			int userId;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userId  = userSvc.Query("it.LoginName = \'" + userName + "\'", null).First().Id;
			}
			using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				icList = bpService.GetInternalCustomersByUser(userId).Select(o => o.Id).ToList();
			}

			if (icList.Count > 0)
			{
				condition += string.Format(" and (");
				for (int j = 0; j < icList.Count; j++)
				{
					if (j == 0)
					{
						condition += string.Format(" it.Contract.InternalCustomerId = {0} ", icList[j]);
					}
					else
					{
						condition += string.Format(" or it.Contract.InternalCustomerId = {0}", icList[j]);
					}
				}
				condition += string.Format(" )");
			}

			var parameters = new List<object> { (int)ApproveStatus.ApproveNotStart, (int)ApproveStatus.InApprove };
			var includes = new List<string>
				{
					"Contract",
					"Pricings",
					"User",
					"Approval",
					"Approval.ApprovalStages",
					"Approval.ApprovalStages.ApprovalUser",
					"Contract.BusinessPartner",
					"Contract.InternalCustomer",
					"Contract.User",
					"Commodity",
					"Brand",
					"Currency"
				};
			List<Quota> tmpQuotas = quotaService.Select(condition, parameters, includes);

			foreach (Quota q in tmpQuotas)
			{
				Quota quota = q;
				if (quota.Approval == null) continue;
				
				IEnumerable<int> approvalUserIds = quota.Approval.ApprovalStages.Where(
					o => o.StageIndex == quota.ApprovalStageIndex && !o.IsDeleted).Select(
						o => o.ApprovalUserId);
				if (approvalUserIds.Contains(userId))
				{
					if (quota.PricingType == (int)PricingType.Fixed)
					{
						Pricing p = quota.Pricings.FirstOrDefault(o => !o.IsDeleted);
						if (p != null)
							quota.StrPrice = p.FinalPrice == null
												 ? string.Empty
												 : p.FinalPrice.Value.ToString(RoundRules.STR_PRICE);
					}

					string passed, notPassed;
					List<ApprovalStage> stages = quota.Approval.ApprovalStages.Where(o => !o.IsDeleted).ToList();
					ParseApprovalDetailString(stages, quota.ApprovalStageIndex ?? 0, out passed, out notPassed);

					if (quota.ApproveStatus == (int)ApproveStatus.Approved)
					{
						quota.CustomerStrField1 = passed + notPassed;
						quota.CustomerStrField2 = string.Empty;
					}
					else
					{
						quota.CustomerStrField1 = passed;
						quota.CustomerStrField2 = notPassed;
					}

					quotas.Add(quota);
				}
			}
			
			return quotas;
		}


		public List<Quota> GetQuotaApprovalsByOpenId(string openId)
		{
			string userName;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userName = userSvc.Query("it.WeixinOpenId = \'" + openId + "\'", null).First().LoginName;
			}

			return GetQuotaApprovalsByName(userName);
		}

		public override void ApproveDocument(int id, string userName)
		{
			int userId;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userId = userSvc.Query("it.LoginName = \'" + userName + "\'", null).First().Id;
			}

			using (var appSvc = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
			{
				appSvc.ApproveQuota(id, userId);
			}
		}

		public override void RejectDocument(int id, string rejectReason, string userName)
		{
			int userId;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userId = userSvc.Query("it.LoginName = \'" + userName + "\'", null).First().Id;
			}

			using (var appSvc = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
			{
				appSvc.RejectQuota(id, rejectReason, userId);
			}
		}
	}
}
