using System.Linq;
using DBEntity.EnumEntity;

namespace DBEntity.ApprovalPlace
{
	public class BusinessPartnerApprovalHandler: BaseApprovalHandler
	{
		public BusinessPartnerApprovalHandler(IApprovable entity, SenLan2Entities ctx) : base(entity, ctx)
		{
		}

		/// <summary>
		/// Check if there is approval procedure for current document
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public override int CheckCondition(decimal amount)
		{
			var sp = CTX.SystemParameters.FirstOrDefault();
			if (sp == null || !sp.BPApprove)
			{
				return 0;
			}

			if (((BusinessPartner) Entity).CustomerType == (int)BusinessPartnerType.InternalCustomer)
			{
				return 0;
			}
			return GetDefaultApproval();
		}
	}
}
