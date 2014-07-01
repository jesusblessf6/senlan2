using System.Collections.Generic;
using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using Senlan2.Weixin.Services.ApprovalServiceReference;
using Senlan2.Weixin.Services.BusinessPartnerServiceReference;
using Senlan2.Weixin.Services.UserServiceReference;
using Senlan2.Weixin.Services.VATInvoiceRequestLineServiceReference;
using Utility.ServiceManagement;

namespace Senlan2.Weixin.Services
{
	public class VATInvoiceRequestLineApprovalService : ApprovalServiceBase<VATInvoiceRequestLine>
	{
		public List<VATInvoiceRequestLine> GetVATInvoiceRequestLineApprovalsByName(string userName)
		{
			var vatInvoiceLineService = SvcClientManager.GetSvcClient<VATInvoicedRequestLineServiceClient>(SvcType.VATInvoiceRequestLineSvc);
			//Query the payment request in approval procedure
			string condition = "it.ApprovalId is not NULL and (it.ApproveStatus = @p1 or it.ApproveStatus = @p2)";
			var icList = new List<int>();
			int userId;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userId = userSvc.Query("it.LoginName = \'" + userName + "\'", null).First().Id;
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
					"VATInvoiceRequest",
					"Quota",
					"VATInvoiceRequest.BusinessPartner",
					"VATInvoiceRequest.InternalCustomer",
					"User",
					"Approval",
					"Approval.ApprovalStages",
					"Approval.ApprovalStages.ApprovalUser"
				};
			List<VATInvoiceRequestLine> tmpLines =
				vatInvoiceLineService.Select(condition, parameters, includes).Where(l =>
																					l.Approval.ApprovalStages.Any(
																						o =>
																						o.StageIndex ==
																						l.ApprovalStageIndex &&
																						o.ApprovalUserId ==
																						userId)).ToList();

			//Select the Payment Request to be approved by currenct user
			var lines = new List<VATInvoiceRequestLine>();

			foreach (var line in tmpLines)
			{
				var l = line;

				IEnumerable<int> approvalUserIds = l.Approval.ApprovalStages.Where(
					o => o.StageIndex == l.ApprovalStageIndex && !o.IsDeleted).Select(
						o => o.ApprovalUserId);

				if (approvalUserIds.Contains(userId))
				{
					//List<ApprovalStage> orderedStages = l.Approval.ApprovalStages.ToList();
					//string passed;
					//string notPassed;
					//ParseApprovalDetailString(orderedStages, l.ApprovalStageIndex ?? 0, out passed, out notPassed);

					//if (l.ApproveStatus == (int)ApproveStatus.Approved)
					//{
					//	l.CustomerStrField1 = passed + notPassed;
					//	l.CustomerStrField2 = string.Empty;
					//}
					//else
					//{
					//	l.CustomerStrField1 = passed;
					//	l.CustomerStrField2 = notPassed;
					//}

					lines.Add(l);
				}
			}

			return lines;
		}

		public List<VATInvoiceRequestLine> GetVATInvoiceRequestLineApprovalsByOpenId(string openId)
		{
			string userName;
			using (var userSvc = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
			{
				userName = userSvc.Query("it.WeixinOpenId = \'" + openId + "\'", null).First().LoginName;
			}

			return GetVATInvoiceRequestLineApprovalsByName(userName);
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
				appSvc.ApproveVATInvoiceRequestLine(id, userId);
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
				appSvc.RejectVATInvoiceRequestLine(id, rejectReason, userId);
			}
		}
	}
}
