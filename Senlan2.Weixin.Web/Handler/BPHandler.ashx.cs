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
    /// BPHandler 的摘要说明
    /// </summary>
    public class BPHandler : IHttpHandler
    {
        CustomerService customerService = new CustomerService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request["method"];

            if (method == "GetBP")
            {
                string key = context.Request["key"];
                List<BusinessPartner> list = customerService.GetAll(key);
                string json = GetBPJson(list);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write("-1");
            }
        }

        private string GetBPJson(List<BusinessPartner> list)
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