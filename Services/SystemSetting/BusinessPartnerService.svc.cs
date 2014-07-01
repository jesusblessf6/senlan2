using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Utility.ErrorManagement;
using System.Linq;
using DBEntity.EnumEntity;
namespace Services.SystemSetting
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BusinessPartnerService" in code, svc and config file together.
	public class BusinessPartnerService : BaseService<BusinessPartner>, IBusinessPartnerService
	{
		public List<BusinessPartner> GetInternalCustomersByUser(int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities())
				{
					var x = QueryForObjs(GetObjQuery<UserICLink>(ctx, new Collection<string> { "InternalCustomer" }), o => o.UserId == userId).ToList();
					return x.Select(o => o.InternalCustomer).Where(c => c.IsDeleted == false && c.CustomerType == (int)BusinessPartnerType.InternalCustomer).OrderBy(o => o.ShortName).ToList();
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}


		/// <summary>
		/// 获取客户 根据客户类型
		/// </summary>
		/// <param name="businessPartnerType"> </param>
		/// <returns></returns>
		public List<BusinessPartner> GetBusinessPartnersByType(BusinessPartnerType businessPartnerType)
		{
			try
			{
				using (var ctx = new SenLan2Entities())
				{
					var cusIndex = (int)businessPartnerType;
					var x =
						QueryForObjs(GetObjQuery<BusinessPartner>(ctx),
									 o =>
									 o.CustomerType == cusIndex && !o.IsDraft &&
									 (o.ApproveStatus == (int) ApproveStatus.Approved ||
									  o.ApproveStatus == (int) ApproveStatus.NoApproveNeeded)).ToList();
					return x;
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		public void DeletedById(int id,int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities(userId))
				{
					var Bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx,new List<string>{"Contracts","Contracts1","BankAccounts"}), o => o.Id == id);
					if (Bp != null)
					{
						EntityUtil.FilterDeletedEntity(Bp.Contracts);
						EntityUtil.FilterDeletedEntity(Bp.Contracts1);
						EntityUtil.FilterDeletedEntity(Bp.BankAccounts);
						if (Bp.Contracts.Count > 0 || Bp.Contracts1.Count > 0)
						{
							throw new FaultException("该客户与合同关联，不能删除");
						}
						if (Bp.BankAccounts.Count > 0)
						{
							throw new FaultException("该客户与银行账户关联，不能删除");
						}
						Bp.IsDeleted = true;
						ctx.SaveChanges();
					}
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		public override BusinessPartner CreateNew(BusinessPartner obj, int userId)
		{
			var ctx = new SenLan2Entities();
			var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "BusinessPartner");
			obj.DocumentId = doc.Id;
			return base.CreateNew(obj, userId);
		}
	}
}