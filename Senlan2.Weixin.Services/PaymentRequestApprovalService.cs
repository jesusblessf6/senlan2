using System.Collections.Generic;
using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using Senlan2.Weixin.Services.ApprovalServiceReference;
using Senlan2.Weixin.Services.BusinessPartnerServiceReference;
using Senlan2.Weixin.Services.PaymentRequestServiceReference;
using Senlan2.Weixin.Services.UserServiceReference;
using Utility.ServiceManagement;

namespace Senlan2.Weixin.Services
{
	public class PaymentRequestApprovalService : ApprovalServiceBase<PaymentRequest>
	{
		public List<PaymentRequest> GetPaymentRequestApprovalsByName(string userName)
		{
			var requestService = SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc);

			//Query the payment request in approval procedure
			string condition = "it.ApprovalId is not NULL and (it.ApproveStatus = @p1 or it.ApproveStatus = @p2)";

			var IdList = new List<int>();
			int userId;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userId = userSvc.Query("it.LoginName = \'" + userName + "\'", null).First().Id;
			}
			using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				IdList = bpService.GetInternalCustomersByUser(userId).Select(o => o.Id).ToList();
			}

			if (IdList.Count > 0)
			{
				condition += string.Format(" and (");
				for (int j = 0; j < IdList.Count; j++)
				{

					if (j == 0)
					{
						condition += string.Format(" it.PayBusinessPartner.Id = {0} ", IdList[j]);
					}
					else
					{
						condition += string.Format(" or it.PayBusinessPartner.Id = {0}", IdList[j]);
					}
				}
				condition += string.Format(" )");
			}
			var parameters = new List<object> { (int)ApproveStatus.ApproveNotStart, (int)ApproveStatus.InApprove };
			var includes = new List<string>
				{
					"Quota",
					"Currency",
					"PayBankAccount",
					"PayBankAccount.Bank",
					"PayBusinessPartner",
					"ReceiveBankAccount",
					"ReceiveBankAccount.Bank",
					"ReceiveBusinessPartner",
					"PaymentMean",
					"PaymentUsage",
					"User",
					"Approval",
					"Approval.ApprovalStages",
					"Approval.ApprovalStages.ApprovalUser"
				};
			List<PaymentRequest> tmpRequests = requestService.Select(condition, parameters, includes).Where(r =>
					r.Approval.ApprovalStages.Any(
						o => o.StageIndex == r.ApprovalStageIndex && o.ApprovalUserId == userId)).ToList();

			//Select the Payment Request to be approved by currenct user
			var requests = new List<PaymentRequest>();

			foreach (var request in tmpRequests)
			{
				var r = request;

				IEnumerable<int> approvalUserIds = r.Approval.ApprovalStages.Where(
					o => o.StageIndex == r.ApprovalStageIndex && !o.IsDeleted).Select(
						o => o.ApprovalUserId);

				if (approvalUserIds.Contains(userId))
				{
					List<ApprovalStage> orderedStages = r.Approval.ApprovalStages.Where(o => !o.IsDeleted).ToList();
					string passed;
					string notPassed;
					ParseApprovalDetailString(orderedStages, r.ApprovalStageIndex ?? 0, out passed, out notPassed);

					if (r.ApproveStatus == (int)ApproveStatus.Approved)
					{
						r.CustomerStrField1 = passed + notPassed;
						r.CustomerStrField2 = string.Empty;
					}
					else
					{
						r.CustomerStrField1 = passed;
						r.CustomerStrField2 = notPassed;
					}

					requests.Add(r);
				}
			}

			return requests;
		}

		public List<PaymentRequest> GetPaymentRequestApprovalsByOpenId(string openId)
		{
			string userName;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userName = userSvc.Query("it.WeixinOpenId = \'" + openId + "\'", null).First().LoginName;
			}

			return GetPaymentRequestApprovalsByName(userName);
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
				appSvc.ApprovePaymentRequest(id, userId);
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
				appSvc.RejectPaymentRequest(id, rejectReason, userId);
			}
		}
	}
}
