using Client.ApprovalServiceReference;
using Client.Base.BaseClientVM;
using Utility.ServiceManagement;

namespace Client.ViewModel.Console.ApprovalCenter
{
	public class RejectReasonVM : BaseVM
	{
		#region Member

		private string _rejectReason;

		#endregion

		#region Property

		public string RejectReason
		{
			get { return _rejectReason; }
			set
			{
				if(_rejectReason != value)
				{
					_rejectReason = value;
					Notify("RejectReason");
				}
			}
		}

		public string TableCode { get; set; }

		#endregion

		#region Constrcutor

		public RejectReasonVM(int id, string tableCode)
		{
			ObjectId = id;
			TableCode = tableCode;
		}

		#endregion

		#region Method

		public void Reject()
		{
			switch (TableCode)
			{
				case "Quota":
					using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
					{
						approvalService.RejectQuota(ObjectId, RejectReason, CurrentUser.Id);
					}
					break;

				case "PaymentRequest":
					using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
					{
						approvalService.RejectPaymentRequest(ObjectId, RejectReason, CurrentUser.Id);
					}
					break;

				case "VATInvoiceRequestLine":
					using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
					{
						approvalService.RejectVATInvoiceRequestLine(ObjectId, RejectReason, CurrentUser.Id);
					}
					break;

				case "BusinessPartner":
					using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
					{
						approvalService.RejectBP(ObjectId, RejectReason, CurrentUser.Id);
					}
					break;

				default:
					return;

			}
		}

		#endregion
	}
}
