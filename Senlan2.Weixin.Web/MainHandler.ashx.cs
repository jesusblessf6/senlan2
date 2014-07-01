using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MessageHandlers;
using Senlan2.Weixin.Web;

namespace Senlan2.Weixin.Web
{
    /// <summary>
    /// MainHandler 的摘要说明
    /// </summary>
    public class MainHandler : IHttpHandler
    {
        private readonly string _token = "eRun";

        public void ProcessRequest(HttpContext context)
        {
            string signature = HttpContext.Current.Request["signature"];
            string timestamp = HttpContext.Current.Request["timestamp"];
            string nonce = HttpContext.Current.Request["nonce"];
            string echostr = HttpContext.Current.Request["echostr"];

            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                if (CheckSignature.Check(signature, timestamp, nonce, _token))
                {
                    WriteContent(echostr); //返回随机字符串则表示验证通过
                }
                else
                {
                    WriteContent("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, _token));
                }
                HttpContext.Current.Response.End();
            }
            else
            {
                //post method - 当有用户想公众账号发送消息时触发
                if (!CheckSignature.Check(signature, timestamp, nonce, _token))
                {
                    WriteContent("参数错误！");
                    return;
                }

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new WeixinMessageHandler(HttpContext.Current.Request.InputStream);

                try
                {
                    //测试时可开启此记录，帮助跟踪数据
                    //_logSvc.Log(messageHandler.RequestMessage.FromUserName, messageHandler.RequestDocument.ToString(), (int)LogType.REQUEST);

                    //执行微信处理过程
                    messageHandler.Execute();


                    //测试时可开启，帮助跟踪数据
                    //_logSvc.Log(messageHandler.RequestMessage.ToUserName, messageHandler.ResponseDocument.ToString(), (int)LogType.RESPONSE);

                    WriteContent(messageHandler.ResponseDocument.ToString());
                    return;
                }
                catch (Exception)
                {
                    //_logSvc.Log(messageHandler.RequestMessage.ToUserName, ex.InnerException.Message + ex.InnerException.InnerException.StackTrace, (int)LogType.ERROR);

                    WriteContent("");
                }
                finally
                {
                    HttpContext.Current.Response.End();
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

        private void WriteContent(string str)
        {
            HttpContext.Current.Response.Output.Write(str);
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}