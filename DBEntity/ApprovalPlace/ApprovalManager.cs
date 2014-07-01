using System.Linq;

namespace DBEntity.ApprovalPlace
{
	public class ApprovalManager
	{
		public static void Handle(IApprovable approvable, SenLan2Entities ctx)
		{
			var handler = CreateHandler(approvable, ctx);
			if (handler != null) handler.Handle();
		}

		public static BaseApprovalHandler CreateHandler(IApprovable approvable, SenLan2Entities ctx)
		{
			var doc = ctx.Documents.SingleOrDefault(o => o.Id == approvable.DocumentId);
			BaseApprovalHandler result = null;

			if(approvable.IsDraft && approvable.ApprovalId == null)
			{
				return null;
			}

			if(doc != null)
			{
				switch(doc.TableCode)
				{
					case "Quota":
						result = new QuotaApprovalHandler(approvable, ctx);
						break;

					case "PaymentRequest":
						result = new PaymentRequestApprovalHandler(approvable, ctx);
						break;

					case "VATInvoiceRequestLine":
						result = new VATInvoiceRequestLineApprovalHandler(approvable, ctx);
						break;

					case "BusinessPartner":
						result = new BusinessPartnerApprovalHandler(approvable, ctx);
						break;

					default:
						result = new DefaultApprovalHandler(approvable, ctx);
						break;
				}
			}

			return result;
		}
	}
}
