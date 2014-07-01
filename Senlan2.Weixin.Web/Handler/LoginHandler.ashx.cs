using Senlan2.Weixin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senlan2.Weixin.Web.Handler
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {
        LoginService loginService = new LoginService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request["method"].ToString();
            if (method == "bind")
            {
                string userName = context.Request["userName"].ToString();
                string pwd = context.Request["pwd"].ToString();
                string openId = context.Request["openId"].ToString();
                string ret = loginService.Bind(userName, pwd, openId);
                if (string.IsNullOrEmpty(ret))
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write(ret);
                }
            }
            else if (method == "unbind")
            {
                string openId = context.Request["openId"].ToString();
                string ret = loginService.UnBind(openId);
                if (string.IsNullOrEmpty(ret))
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write(ret);
                }
            }
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