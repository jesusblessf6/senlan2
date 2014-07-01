using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using System.Collections.Generic;
using System.Data;
using Services.Helper.LogHelper;
using Utility.ErrorManagement;
using DBEntity.EnumEntity;

namespace Services.SystemSetting
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApprovalService" in code, svc and config file together.
	public class ApprovalService : BaseService<Approval>, IApprovalService
	{
		/// <summary>
		/// Get approvable document types
		/// </summary>
		/// <returns></returns>
		public List<Document> GetApprovableDocument()
		{
			try
			{
				using(var ctx = new SenLan2Entities())
				{
					return QueryForObjs(GetObjQuery<Document>(ctx), o => o.IsApprovable).ToList();
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Create
		/// </summary>
		/// <param name="approval"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public Approval AddNewApproval(Approval approval, int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities(userId))
				{
					//Same Name Issue
					if(QueryForObjs(GetObjQuery<Approval>(ctx), o => o.Name == approval.Name).Count > 0)
					{
						throw new FaultException(ErrCode.ApprovalNameExisted.ToString());
					}

					//Check the condition collapse
					//The conditions could only set for quota
					var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Quota");
					if(approval.DocumentId == doc.Id)
					{
						if (approval.ApprovalConditions == null || approval.ApprovalConditions.Count == 0)
						{
							if (QueryForObjs(GetObjQuery<Approval>(ctx), o => o.DocumentId == approval.DocumentId).Count > 0)
							{
								throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
							}
						}
						else
						{
							var apps = QueryForObjs(GetObjQuery<Approval>(ctx, new List<string> { "ApprovalConditions" }),
										 o => o.DocumentId == approval.DocumentId);

							if (apps.Any(app => app.ApprovalConditions.All(o => o.IsDeleted)))
							{
								throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
							}

							foreach (var condition in approval.ApprovalConditions)
							{
								ApprovalCondition condition1 = condition;
								if (condition1.IsDeleted) continue;

								var c = QueryForObjs(GetObjQuery<ApprovalCondition>(ctx, new Collection<string> { "Approval" }),
													 o => o.Approval.DocumentId == approval.DocumentId && o.CurrencyId == condition1.CurrencyId &&
														  ((o.LowerLimit >= condition1.LowerLimit && o.LowerLimit <= condition1.UpperLimit) ||
														   (o.UpperLimit >= condition1.LowerLimit && o.UpperLimit <= condition1.UpperLimit) ||
														   (o.LowerLimit <= condition1.LowerLimit && o.UpperLimit >= condition1.UpperLimit)));
								if (c.Count > 0)
								{
									throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
								}
							}
						}
					}
					else
					{
						if(approval.IsDefault)
						{
							var aps = QueryForObjs(GetObjQuery<Approval>(ctx), o => o.DocumentId == approval.DocumentId);
							foreach (var ap in aps)
							{
								ap.IsDefault = false;
							}
						}
					}
					
					if(approval.ApprovalConditions != null)
					{
						foreach (var condition in approval.ApprovalConditions)
						{
							condition.Currency = null;
						}
					}

					foreach (var stage in approval.ApprovalStages)
					{
						stage.ApprovalUser = null;
					}

					Create(GetObjSet<Approval>(ctx), approval);
					ctx.SaveChanges();
					return approval;
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="approval"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public Approval UpdateExistedApproval(Approval approval, int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities(userId))
				{
					if (QueryForObjs(GetObjQuery<Approval>(ctx), o => o.Name == approval.Name && o.Id != approval.Id).Count > 0)
					{
						throw new FaultException(ErrCode.ApprovalNameExisted.ToString());
					}

					var doc = QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == "Quota");
					if(doc == null)
					{
						throw new FaultException(ErrCode.ApprovalNameExisted.ToString());
					}
					
					if(approval.DocumentId == doc.Id)
					{
						//Check the condition collapse
						if (approval.ApprovalConditions == null || approval.ApprovalConditions.Count == 0)
						{
							if (QueryForObjs(GetObjQuery<Approval>(ctx), o => o.DocumentId == approval.DocumentId && o.Id != approval.Id).Count > 0)
							{
								throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
							}
						}
						else
						{
							var apps = QueryForObjs(GetObjQuery<Approval>(ctx, new List<string> { "ApprovalConditions" }),
										 o => o.DocumentId == approval.DocumentId && o.Id != approval.Id);

							if (apps.Any(app => app.ApprovalConditions.All(o => o.IsDeleted)))
							{
								throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
							}
							foreach (var condition in approval.ApprovalConditions)
							{
								if(condition.IsDeleted)
								{
									DeleteCondition(condition.Id, userId);
								}
							}
							foreach (var condition in approval.ApprovalConditions)
							{
								ApprovalCondition condition1 = condition;
								if (condition1.IsDeleted) continue;

								var c = QueryForObjs(GetObjQuery<ApprovalCondition>(ctx, new Collection<string> { "Approval" }),
													 o => o.Approval.DocumentId == approval.DocumentId && o.CurrencyId == condition1.CurrencyId && o.Id != condition1.Id &&
														  ((o.LowerLimit >= condition1.LowerLimit && o.LowerLimit <= condition1.UpperLimit) ||
														   (o.UpperLimit >= condition1.LowerLimit && o.UpperLimit <= condition1.UpperLimit) ||
														   (o.LowerLimit <= condition1.LowerLimit && o.UpperLimit >= condition1.UpperLimit)));
								if (c.Count > 0)
								{
									throw new FaultException(ErrCode.ApprovalConditionCollapsed.ToString());
								}
							}
						}
					}
					else
					{
						if(approval.IsDefault)
						{
							var approvals = QueryForObjs(GetObjQuery<Approval>(ctx),
										 o => o.DocumentId == approval.DocumentId && o.Id != approval.Id && o.IsDefault);
							foreach (var a in approvals)
							{
								a.IsDefault = false;
							}
						}
					}

					Update(GetObjSet<Approval>(ctx), approval);
					ctx.SaveChanges();
					return approval;
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		private void DeleteCondition(int conditionID, int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities(userId))
				{
					var condition = QueryForObj(GetObjQuery<ApprovalCondition>(ctx, null), o => o.Id == conditionID);
					if (condition != null)
					{
						condition.IsDeleted = true;
					}
					ctx.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Delete the approval logically
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userId"></param>
		public void DeleteApproval(int id, int userId)
		{
			try
			{
				using (var ctx = new SenLan2Entities(userId))
				{
					var x = QueryForObj(GetObjQuery<Approval>(ctx,
													  new Collection<string> {"ApprovalConditions", "ApprovalStages"}), o => o.Id == id);
					foreach (var c in x.ApprovalConditions)
					{
						c.IsDeleted = true;
					}

					foreach (var s in x.ApprovalStages)
					{
						s.IsDeleted = true;
					}

					x.IsDeleted = true;

					ctx.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Get the conditions of the approval together with the navigation properties in includes
		/// </summary>
		/// <param name="approvalId"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public List<ApprovalCondition> GetApprovalConditions(int approvalId, List<string> includes)
		{
			var incl = new List<string>{"Approval"};

			if(includes != null)
			{
				incl.InsertRange(1, includes);
			}

			using (var ctx = new SenLan2Entities())
			{
				return QueryForObjs(GetObjQuery<ApprovalCondition>(ctx, incl),
								  o => o.Approval.Id == approvalId).ToList();
			}
		}

		/// <summary>
		/// Get the stages of the approval together with the navigation properties in includes
		/// </summary>
		/// <param name="approvalId"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public List<ApprovalStage> GetApprovalStages(int approvalId, List<string> includes)
		{
			var incl = new List<string> { "Approval" };

			if (includes != null)
			{
				incl.InsertRange(1, includes);
			}

			using (var ctx = new SenLan2Entities())
			{
				return QueryForObjs(GetObjQuery<ApprovalStage>(ctx, incl),
								  o => o.Approval.Id == approvalId).ToList();
			}
		}

		/// <summary>
		/// Approve the quota by id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bool ApproveQuota(int id, int userId)
		{
			try
			{
				using (var ts = new TransactionScope())
				{
					var ctx = new SenLan2Entities(userId);

					Quota q = GetById(GetObjQuery<Quota>(ctx, new List<string> { "Approval", "Approval.ApprovalStages","Contract"}), id);
					ApproveDocument(q, userId, ctx);

					if (q.Contract.TradeType == (int)TradeType.LongForeignTrade || q.Contract.TradeType == (int)TradeType.ShortForeignTrade)
					{
						//外贸
						if (q.IsAutoGenerated == false && q.RelQuotaId.HasValue)
						{ 
							//有自动生成的单据
							Quota autoGeneratedQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == q.RelQuotaId.Value);
							ApproveDocument(autoGeneratedQuota, userId, ctx);
						}
					}
					else
					{ 
						//内贸
						if (q.Contract.ContractType == (int)ContractType.Purchase && q.Contract.TradeType == (int)TradeType.ShortDomesticTrade
						&& !q.RelQuotaId.HasValue)
						{
							List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx,
																				 new List<string>
																					 {
																						 "Approval",
																						 "Approval.ApprovalStages",
																						 "Contract"
																					 }),
															  o => o.RelQuotaId == q.Id)
								.OrderBy(o => o.RelQuotaStage).ToList();
							foreach (var quota in quotas)
							{
								ApproveDocument(quota, userId, ctx);
							}
						}
					}

					ctx.SaveChanges();

					var stage = q.Approval.ApprovalStages.FirstOrDefault(o => o.ApprovalUserId == userId && !o.IsDeleted);
					LogManager.WriteLog("Quota", "Approve", q.Id, userId, stage == null ? 0 : stage.Id);

					ts.Complete();

					return true;
				}
				
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Reject the quota by id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="rejectReason"> </param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bool RejectQuota(int id, string rejectReason, int userId)
		{
			try
			{
				using (var ts = new TransactionScope())
				{
					var ctx = new SenLan2Entities(userId);
					var q = GetById(GetObjQuery<Quota>(ctx, new List<string> { "Approval", "Approval.ApprovalStages", "Contract" }), id);
					RejectDocument(q, rejectReason, userId);

					if (q.Contract.TradeType == (int)TradeType.LongForeignTrade || q.Contract.TradeType == (int)TradeType.ShortForeignTrade)
					{
						//外贸
						if (q.IsAutoGenerated == false && q.RelQuotaId.HasValue)
						{
							//有自动生成的单据
							Quota autoGeneratedQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == q.RelQuotaId.Value);
							RejectDocument(autoGeneratedQuota,rejectReason, userId);
						}
					}
					else
					{
						//内贸
						if (q.Contract.ContractType == (int)ContractType.Purchase && q.Contract.TradeType == (int)TradeType.ShortDomesticTrade
						&& !q.RelQuotaId.HasValue)
						{
							List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx,
							new List<string> { "Approval", "Approval.ApprovalStages", "Contract" }), o => o.RelQuotaId == q.Id)
							.OrderBy(o => o.RelQuotaStage).ToList();
							foreach (var quota in quotas)
							{
								RejectDocument(quota, rejectReason, userId);
							}
						}
					}
					ctx.SaveChanges();

					var stage = q.Approval.ApprovalStages.FirstOrDefault(o => o.ApprovalUserId == userId && !o.IsDeleted);
					LogManager.WriteLog("Quota", "Reject", q.Id, userId, stage == null ? 0 : stage.Id);

					ts.Complete();

					return true;
				}
				
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Judge if the Approval could be edited
		/// </summary>
		/// <param name="approvalId"> </param>
		/// <returns></returns>
		public bool CanEdit(int approvalId)
		{
			using (var ctx = new SenLan2Entities())
			{
				var approval = QueryForObj(GetObjQuery<Approval>(ctx, new Collection<string> { "Document" }), o => o.Id == approvalId);
				bool result = false;

				if (approval != null && approval.Document != null)
				{

					switch (approval.Document.TableCode)
					{
						case "Quota":
							var quotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.ApprovalId == approvalId);
							result = !(quotas.Count > 0);
							break;

						case "PaymentRequest":
							var prs = QueryForObjs(GetObjQuery<PaymentRequest>(ctx), o => o.ApprovalId == approvalId);
							result = !(prs.Count > 0);
							break;

						case "VATInvoiceRequestLine":
							var virls = QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx), o => o.ApprovalId == approvalId);
							result = !(virls.Count > 0);
							break;
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Judge if the Approval could be deleted
		/// </summary>
		/// <param name="approvalId"> </param>
		/// <returns></returns>
		public bool CanDelete(int approvalId)
		{
			using (var ctx = new SenLan2Entities())
			{
				var approval = QueryForObj(GetObjQuery<Approval>(ctx, new Collection<string> { "Document" }), o => o.Id == approvalId);
				bool result = false;

				if (approval != null && approval.Document != null)
				{

					switch (approval.Document.TableCode)
					{
						case "Quota":
							var qs = QueryForObjs(GetObjQuery<Quota>(ctx),
									  o =>
									  (o.ApproveStatus == (int)ApproveStatus.ApproveNotStart ||
									   o.ApproveStatus == (int)ApproveStatus.InApprove) && o.ApprovalId == approvalId);
							result = !(qs.Count > 0);
							break;

						case "PaymentRequest":
							var prs = QueryForObjs(GetObjQuery<PaymentRequest>(ctx),
									  o =>
									  (o.ApproveStatus == (int)ApproveStatus.ApproveNotStart ||
									   o.ApproveStatus == (int)ApproveStatus.InApprove) && o.ApprovalId == approvalId);
							result = !(prs.Count > 0);
							break;

						case "VATInvoiceRequestLine":
							var virls = QueryForObjs(GetObjQuery<VATInvoiceRequestLine>(ctx),
									  o =>
									  (o.ApproveStatus == (int)ApproveStatus.ApproveNotStart ||
									   o.ApproveStatus == (int)ApproveStatus.InApprove) && o.ApprovalId == approvalId);
							result = !(virls.Count > 0);
							break;
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Approve the Payment Request By id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userId"> </param>
		/// <returns></returns>
		public bool ApprovePaymentRequest(int id, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				PaymentRequest p = GetById(GetObjQuery<PaymentRequest>(ctx, new List<string> { "Approval" }), id);
				ApproveDocument(p, userId, ctx);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Reject Payment Request
		/// </summary>
		/// <param name="id"></param>
		/// <param name="rejectReason"> </param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bool RejectPaymentRequest(int id, string rejectReason, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				PaymentRequest p = GetById(GetObjQuery<PaymentRequest>(ctx, new List<string> { "Approval" }), id);
				RejectDocument(p, rejectReason, userId);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Approve VAT Invoice Request Line
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bool ApproveVATInvoiceRequestLine(int id, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				VATInvoiceRequestLine p = GetById(GetObjQuery<VATInvoiceRequestLine>(ctx, new List<string> { "Approval" }), id);
				ApproveDocument(p, userId, ctx);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		public bool ApproveBP(int id, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				BusinessPartner p = GetById(GetObjQuery<BusinessPartner>(ctx, new List<string> { "Approval" }), id);
				ApproveDocument(p, userId, ctx);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
			
		}

		public bool RejectBP(int id, string rejectReason, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				BusinessPartner p = GetById(GetObjQuery<BusinessPartner>(ctx, new List<string> { "Approval" }), id);
				RejectDocument(p, rejectReason, userId);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Reject VAT Invoice Request Line
		/// </summary>
		/// <param name="id"></param>
		/// <param name="rejectReason"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bool RejectVATInvoiceRequestLine(int id, string rejectReason, int userId)
		{
			try
			{
				var ctx = new SenLan2Entities(userId);
				VATInvoiceRequestLine p = GetById(GetObjQuery<VATInvoiceRequestLine>(ctx, new List<string> { "Approval" }), id);
				RejectDocument(p, rejectReason, userId);
				ctx.SaveChanges();
				return true;
			}
			catch (OptimisticConcurrencyException)
			{
				throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
			}
		}

		/// <summary>
		/// Common method for approving document
		/// </summary>
		/// <param name="approvable"></param>
		/// <param name="userId"> </param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		private void ApproveDocument(IApprovable approvable, int userId, SenLan2Entities ctx)
		{
			if (approvable == null)
			{
				throw new FaultException(ErrCode.PaymentRequestNotFound.ToString());
			}

			if (approvable.Approval == null)
			{
				throw new FaultException(ErrCode.NotInApproval.ToString());
			}

			
			if (approvable.ApproveStatus == (int)ApproveStatus.ApproveRefused ||
				approvable.ApproveStatus == (int)ApproveStatus.Approved ||
				approvable.ApproveStatus == (int)ApproveStatus.NoApproveNeeded)
			{
				throw new FaultException(ErrCode.NotDuringApproval.ToString());
			}

			var currentStage = QueryForObjs(GetObjQuery<ApprovalStage>(ctx),
								o =>
								o.ApprovalId == approvable.Approval.Id && o.StageIndex == approvable.ApprovalStageIndex &&
								o.ApprovalUserId == userId).FirstOrDefault();

			if (currentStage == null)
			{
				throw new FaultException(ErrCode.ApprovalStageNotFound.ToString());
			}

			var nextStage =
				QueryForObjs(GetObjQuery<ApprovalStage>(ctx),
								o => o.ApprovalId == approvable.Approval.Id && o.StageIndex > approvable.ApprovalStageIndex).OrderBy(
									o => o.StageIndex).FirstOrDefault();

			if (nextStage == null)
			{
				//Finish Approval
				approvable.IsDraft = false;
				approvable.ApproveStatus = (int)ApproveStatus.Approved;
			}
			else
			{
				approvable.ApprovalStageIndex = nextStage.StageIndex;
				approvable.ApproveStatus = (int)ApproveStatus.InApprove;

				var nextStages = QueryForObjs(GetObjQuery<ApprovalStage>(ctx, new Collection<string>{"ApprovalUser"}),
					                            o => o.ApprovalId == approvable.Approval.Id && o.StageIndex == nextStage.StageIndex)
					.ToList();
				foreach (var approvalStage in nextStages)
				{
					if (!string.IsNullOrWhiteSpace(approvalStage.ApprovalUser.WeixinOpenId))
					{
						if (
							!ctx.WeixinAlerts.Any(
								o => o.UserId == approvalStage.ApprovalUser.Id && o.OpenId == approvalStage.ApprovalUser.WeixinOpenId && o.DocumentId == approvable.DocumentId))
						{
							ctx.WeixinAlerts.AddObject(new WeixinAlert { DocumentId = approvable.DocumentId ?? 0, UserId = approvalStage.ApprovalUserId, OpenId = approvalStage .ApprovalUser.WeixinOpenId});
						}
					}
						
				}
			}
		}

		/// <summary>
		/// Common Method for rejecting document
		/// </summary>
		/// <param name="approvable"></param>
		/// <param name="rejectReason"></param>
		/// <param name="userId"></param>
		private void RejectDocument(IApprovable approvable, string rejectReason, int userId)
		{
			if (approvable == null)
			{
				throw new FaultException(ErrCode.QuotaNotExisted.ToString());
			}

			if (approvable.Approval == null)
			{
				throw new FaultException(ErrCode.NotInApproval.ToString());
			}

			using (var ctx = new SenLan2Entities())
			{
				var currentStage = QueryForObjs(GetObjQuery<ApprovalStage>(ctx),
								   o =>
								   o.ApprovalId == approvable.Approval.Id && o.StageIndex == approvable.ApprovalStageIndex &&
								   o.ApprovalUserId == userId).FirstOrDefault();
				if (currentStage == null)
				{
					throw new FaultException(ErrCode.ApprovalStageNotFound.ToString());
				}

				approvable.ApproveStatus = (int)ApproveStatus.ApproveRefused;
				approvable.RejectReason = rejectReason;
			}
		}
	}
}
