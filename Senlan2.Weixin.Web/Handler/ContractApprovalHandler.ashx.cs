using DBEntity;
using Senlan2.Weixin.Services;
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using DBEntity.EnumEntity;


namespace Senlan2.Weixin.Web.Handler
{
	/// <summary>
	/// ContractApprovalHandler 的摘要说明
	/// </summary>
	public class ContractApprovalHandler : IHttpHandler
	{
		ContractApprovalService contractApprovalService = new ContractApprovalService();
		UserService userService = new UserService();
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			string method = context.Request["method"].ToString();
			if (method == "GetApprovalList")
			{
				string openId = context.Request["openId"].ToString();
				List<Quota> list = contractApprovalService.GetQuotaApprovalsByOpenId(openId);
				string ret = GetQuotaJson(list);
				context.Response.Write(ret);
			}
			else if (method == "Agree")
			{
				try
				{
					int quotaId = int.Parse(context.Request["quotaId"]);
					string openId = context.Request["openId"].ToString();
					User user = userService.GetUserByOpenId(openId);
					contractApprovalService.ApproveDocument(quotaId, user.LoginName);
					context.Response.Write("1");//成功
				}
				catch (Exception)
				{
					context.Response.Write("0");//失败
				}


			}
			else if (method == "DisAgree")
			{
				try
				{
					int quotaId = int.Parse(context.Request["quotaId"]);
					string openId = context.Request["openId"].ToString();
					string reason = context.Request["reason"].ToString();
					User user = userService.GetUserByOpenId(openId);
					contractApprovalService.RejectDocument(quotaId, reason, user.LoginName);
					context.Response.Write("1");//成功
				}
				catch (Exception)
				{
					context.Response.Write("0");//失败
				}
			}
		}

		private string GetQuotaJson(List<Quota> list)
		{
			StringWriter sw = new StringWriter();
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				writer.Formatting = Formatting.None;

				writer.WriteStartArray();

				foreach (var quota in list)
				{
					writer.WriteStartObject();

					writer.WritePropertyName("id");
					writer.WriteValue(quota.Id);

					writer.WritePropertyName("contractType");
					writer.WriteValue(quota.Contract.ContractType);

					writer.WritePropertyName("com");
					writer.WriteValue(quota.Commodity.Name);

					writer.WritePropertyName("brand");
					writer.WriteValue(quota.Brand == null ? "" : quota.Brand.Name);

					writer.WritePropertyName("quantity");
					writer.WriteValue(quota.Quantity ?? 0);

					writer.WritePropertyName("price");
					if (quota.PricingType == (int)PricingType.Fixed)
					{
						writer.WriteValue(quota.FinalPrice ?? 0);
					}
					else
					{
						writer.WriteValue(quota.TempPrice ?? 0);
					}

					writer.WritePropertyName("date");
					writer.WriteValue(quota.Contract.SignDate.Value.ToString("yy-M-d"));

					//string userName = "";
					//if (quota.Contract.ContractType == (int)ContractType.Purchase)
					//{
					//	userName = quota.Contract.InternalCustomer.ShortName;
					//}
					//else
					//{
					//	userName = quota.Contract.BusinessPartner.ShortName;
					//}
					string userName = quota.Contract.BusinessPartner.ShortName;

					writer.WritePropertyName("user");
					writer.WriteValue(userName);

					writer.WritePropertyName("salesman");
					writer.WriteValue(quota.Contract.User == null ? "" : quota.Contract.User.Name);

					writer.WritePropertyName("part1");
					writer.WriteValue(quota.CustomerStrField1);

					writer.WritePropertyName("part2");
					writer.WriteValue(quota.CustomerStrField2);

					writer.WritePropertyName("unit");
					writer.WriteValue(quota.Commodity.SHFEUnit);

					writer.WritePropertyName("currency");
					writer.WriteValue(quota.Currency.Name);

					writer.WriteEndObject();
				}

				writer.WriteEndArray();

				writer.Flush();
				sw.Close();
			}
			return sw.GetStringBuilder().ToString();
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}