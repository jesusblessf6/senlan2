using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using DBEntity.EnumEntity;
using Senlan2.Weixin.Services;
using DBEntity;

namespace Senlan2.Weixin.Web.Handler
{
    /// <summary>
    /// InterCustomerHandler 的摘要说明
    /// </summary>
    public class InterCustomerHandler : IHttpHandler
    {
        CustomerService customerService = new CustomerService();
        UserService userService = new UserService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request["method"];
            string openId = context.Request["openId"];
            User user = userService.GetUserByOpenId(openId);
            if (method == "GetIC")
            {
                if (user != null)
                {
                    //List<BusinessPartner> list = customerService.GetAll();
                    List<BusinessPartner> list = customerService.GetInternalCustomersByUserId(user.Id);
                    string json = GetICJson(list);
                    context.Response.Write(json);
                }
                else
                {
                    context.Response.Write("-1");
                }
            }
        }

        private string GetICJson(List<BusinessPartner> list)
        {
            StringWriter sw = new StringWriter();
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.None;

                writer.WriteStartArray();

                foreach (var bp in list)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("id");
                    writer.WriteValue(bp.Id);

                    writer.WritePropertyName("name");
                    writer.WriteValue(bp.ShortName);

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