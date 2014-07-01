using DBEntity;
using Senlan2.Weixin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Senlan2.Weixin.Web.Handler
{
	/// <summary>
	/// PaymentRequestHandler 的摘要说明
	/// </summary>
	public class PaymentRequestHandler : IHttpHandler
	{
		PaymentRequestApprovalService paymentRequestService = new PaymentRequestApprovalService();
		UserService userService = new UserService();
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			string method = context.Request["method"].ToString();
			if (method == "GetPaymentRequestList")
			{
				string openId = context.Request["openId"].ToString();
				List<PaymentRequest> list = paymentRequestService.GetPaymentRequestApprovalsByOpenId(openId);
				var retJson = GetPRJson(list);
				context.Response.Write(retJson);
			}
			else if (method == "Agree")
			{
				try
				{
					int prId = int.Parse(context.Request["prId"]);
					string openId = context.Request["openId"].ToString();
					User user = userService.GetUserByOpenId(openId);
					paymentRequestService.ApproveDocument(prId, user.LoginName);
					context.Response.Write("1");//成功
				}
				catch (Exception ex)
				{
					string m = ex.Message;
					context.Response.Write("0");//失败
				}


			}
			else if (method == "DisAgree")
			{
				try
				{
					int prId = int.Parse(context.Request["prId"]);
					string openId = context.Request["openId"].ToString();
					string reason = context.Request["reason"].ToString();
					User user = userService.GetUserByOpenId(openId);
					paymentRequestService.RejectDocument(prId, reason, user.LoginName);
					context.Response.Write("1");//成功
				}
				catch (Exception)
				{
					context.Response.Write("0");//失败
				}
			}
		}

		private string GetPRJson(List<PaymentRequest> list)
		{ 
			StringWriter sw = new StringWriter();
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				writer.Formatting = Formatting.None;

				writer.WriteStartArray();

				foreach (var pr in list)
				{
					writer.WriteStartObject();

					writer.WritePropertyName("id");
					writer.WriteValue(pr.Id);

					writer.WritePropertyName("receiver");
					writer.WriteValue(pr.ReceiveBusinessPartner.ShortName);

					writer.WritePropertyName("Currency");
					writer.WriteValue(pr.Currency==null?"":pr.Currency.Name);

					writer.WritePropertyName("RequestDate");
					writer.WriteValue(pr.RequestDate.Value.ToString("yy-M-d"));

					writer.WritePropertyName("RequestAmount");
					writer.WriteValue(pr.RequestAmount);

					writer.WritePropertyName("PaymentUsage");
					writer.WriteValue(pr.PaymentUsage.Name);

					writer.WritePropertyName("user");
					writer.WriteValue(pr.User.Name);

					writer.WritePropertyName("date");
					writer.WriteValue(pr.RequestDate.Value.ToString("yy-M-d"));

					writer.WritePropertyName("part1");
					writer.WriteValue(pr.CustomerStrField1);

					writer.WritePropertyName("part2");
					writer.WriteValue(pr.CustomerStrField2);

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