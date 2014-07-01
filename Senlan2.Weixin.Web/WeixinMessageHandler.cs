using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Context;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;
using System.IO;
using Senlan2.Weixin.Services;
using DBEntity;
using System.Transactions;
using DBEntity.EnumEntity;
using System.Threading;
using System.Threading.Tasks;

namespace Senlan2.Weixin.Web
{
    public class WeixinMessageHandler : MessageHandler<MessageContext>
    {
        private readonly string _error = "请输入正确指令！";
        private LoginService _logSvc = new LoginService();
        private PaymentRequestApprovalService _praSvc = new PaymentRequestApprovalService();
        private ContractApprovalService _caSvc = new ContractApprovalService();
        private NotifierService _notifierSvc = new NotifierService();
        private readonly string _appId = "wxe3be88b3096ec6fd";
        private readonly string _appSecret = "eed6de36e148a5c5c13d93ecd20a3769";
        private readonly int _interval = 1000 * 30;//30秒进行提醒
        public static Task _scanWeixinAlertsTask = null;

        public WeixinMessageHandler(Stream inputStream)
            : base(inputStream)
        {
            _scanWeixinAlertsTask = new Task(ScanWeixinAlerts);
            _scanWeixinAlertsTask.Start();
        }

        void ScanWeixinAlerts()
        {
            //扫描数据库 然后分发微信提醒
            //throw new NotImplementedException();
            try
            {
                while (true)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        List<WeixinAlert> alerts = _notifierSvc.GetWeixinAlerts();
                        List<WeixinAlert> toBeDeletedAlerts = new List<WeixinAlert>();
                        foreach (WeixinAlert alert in alerts)
                        {
                            if (alert.DocumentId == (int)DocumentType.Quota)
                            {
                                ResponseMessageNews news = Approval_Contract_News(alert.User, alert.User.WeixinOpenId);
                                AccessTokenResult access_token = CommonApi.GetToken(_appId, _appSecret);
                                if (access_token != null)
                                {
                                    WxJsonResult res = Custom.SendNews(access_token.access_token, alert.OpenId, news.Articles);
                                    if (res.errcode == ReturnCode.请求成功)
                                    {
                                        toBeDeletedAlerts.Add(alert);
                                    }
                                }
                            }
                            else if (alert.DocumentId == (int)DocumentType.PaymentRequest)
                            {
                                ResponseMessageNews news = Approval_PaymentRequest_News(alert.User, alert.User.WeixinOpenId);
                                AccessTokenResult access_token = CommonApi.GetToken(_appId, _appSecret);
                                if (access_token != null)
                                {
                                    WxJsonResult res = Custom.SendNews(access_token.access_token, alert.OpenId, news.Articles);
                                    if (res.errcode == ReturnCode.请求成功)
                                    {
                                        toBeDeletedAlerts.Add(alert);
                                    }
                                }
                            }
                        }
                        _notifierSvc.DeleteWeixinAlerts(toBeDeletedAlerts);
                        ts.Complete();
                    }
                    System.Threading.Thread.Sleep(_interval);
                }
            }
            catch (Exception)
            {
            }
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            ResponseMessageText text = base.CreateResponseMessage<ResponseMessageText>();
            text.Content = _error;
            return text;
        }

        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            ResponseMessageText text = base.CreateResponseMessage<ResponseMessageText>();
            text.Content = "欢迎您关注上海益润信息技术咨询公司微信公众号，请首先到报表及管理菜单下进行账号绑定";
            return text;
            //return base.OnEvent_SubscribeRequest(requestMessage);
        }

        private ResponseMessageNews Bind(string openId)
        {
            ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
            string access_token = CommonApi.GetToken(_appId, _appSecret).access_token;
            string nick = Senparc.Weixin.MP.AdvancedAPIs.User.Info(access_token, openId).nickname;
            Article art = new Article();
            art.Description = "您尚未绑定系统账号，点击进行绑定";
            art.Title = "上海益润微信公众号绑定";
            art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/bind.jpg";
            art.Url = "http://180.169.11.53/senlan2.weixin/pages/bind.html?openid=" + openId + "&nickname=" + Microsoft.JScript.GlobalObject.encodeURI(Microsoft.JScript.GlobalObject.encodeURI(nick));
            //art.Url = "http://180.169.11.53/senlan2.weixin/pages/bind.html?openid=o9nEBj0S0zENtwMWavyT1SjjHMg0&nickname=test";
            news.Articles.Add(art);
            return news;
        }

        private ResponseMessageNews Approval_Contract_News(DBEntity.User u, string fromUserName)
        {
            ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
            Article art = new Article();
            art.Description = "您有" + _caSvc.GetQuotaApprovalsByName(u.LoginName).Count + "个要审批的合同，点击进入审批列表";
            art.Title = "上海益润微信公众号审批中心 - 待审合同";
            art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/approval.jpg";
            art.Url = "http://180.169.11.53/senlan2.weixin/pages/approval_contract.html?openid=" + fromUserName;
            news.Articles.Add(art);
            return news;
        }

        private ResponseMessageNews Approval_PaymentRequest_News(DBEntity.User u, string fromUserName)
        {
            ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
            Article art = new Article();
            art.Description = "您有" + _praSvc.GetPaymentRequestApprovalsByName(u.LoginName).Count + "个要审批的付款申请，点击进入审批列表";
            art.Title = "上海益润微信公众号审批中心 - 待审付款申请";
            art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/approval.jpg";
            art.Url = "http://180.169.11.53/senlan2.weixin/pages/approval_paymentrequest.html?openid=" + fromUserName;
            news.Articles.Add(art);
            return news;
        }

        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            DBEntity.User u = _logSvc.IsBind(requestMessage.FromUserName);
            if (requestMessage.EventKey == "btnBind")
            {
                if (u != null)
                {
                    string access_token = CommonApi.GetToken(_appId, _appSecret).access_token;
                    string nick = Senparc.Weixin.MP.AdvancedAPIs.User.Info(access_token, requestMessage.FromUserName).nickname;
                    ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
                    Article art = new Article();
                    art.Description = "您已经绑定系统账号" + u.LoginName + "，点击查看详情或解绑定";
                    art.Title = "上海益润微信公众号绑定";
                    art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/bind.jpg";
                    art.Url = "http://180.169.11.53/senlan2.weixin/pages/unbind.html?openid=" + requestMessage.FromUserName + "&nickname=" + Microsoft.JScript.GlobalObject.encodeURI(Microsoft.JScript.GlobalObject.encodeURI(nick)) + "&username=" + Microsoft.JScript.GlobalObject.encodeURI(Microsoft.JScript.GlobalObject.encodeURI(u.LoginName));
                    news.Articles.Add(art);
                    return news;
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            if (requestMessage.EventKey == "btn_approval_contract")
            {
                if (u != null)
                {
                    return Approval_Contract_News(u, requestMessage.FromUserName);
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            if (requestMessage.EventKey == "btn_approval_paymentrequest")
            {
                if (u != null)
                {
                    return Approval_PaymentRequest_News(u, requestMessage.FromUserName);
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            if (requestMessage.EventKey == "btn_Contract")
            {
                if (u != null)
                {
                    ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
                    Article art = new Article();
                    art.Title = "上海益润微信公众号单据中心 - 合同";
                    if (u.IsSales == false)
                    {
                        art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/document.jpg";
                        art.Description = "您无权进入单据中心进行业务单据的制作";
                    }
                    else
                    {
                        art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/document.jpg";
                        art.Description = "您已授权进入单据中心进行业务单据的制作，点击进入";
                        art.Url = "http://180.169.11.53/senlan2.weixin/pages/contract.html?openid=" + requestMessage.FromUserName;
                    }
                    news.Articles.Add(art);
                    return news;
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            if (requestMessage.EventKey == "btn_customer_service")
            {
                if (u != null)
                {
                    ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
                    Article art = new Article();
                    art.Description = "订阅成功，您将在" + DateTime.Now.ToString() + "至" + DateTime.Now.AddDays(2).ToString() + "获取待审批单据的推送提醒！";
                    art.Title = "上海益润微信公众号审批中心 - 推送订阅";
                    art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/approval.jpg";
                    news.Articles.Add(art);
                    return news;
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            if (requestMessage.EventKey == "btnReport")
            {
                if (u != null)
                {
                    ResponseMessageNews news = base.CreateResponseMessage<ResponseMessageNews>();
                    Article art0 = new Article();
                    art0.Title = "上海益润微信公众号报表中心";
                    art0.PicUrl = "http://180.169.11.53/senlan2.weixin/images/reports.jpg";
                    news.Articles.Add(art0);

                    Article art1 = new Article();
                    art1.Title = "库存报表";
                    art1.PicUrl = "http://180.169.11.53/senlan2.weixin/images/stock.png";
                    art1.Url = "http://180.169.11.53/senlan2.weixin/pages/stock.html";
                    news.Articles.Add(art1);

                    Article art2 = new Article();
                    art2.Title = "业务员当日业绩明细";
                    art2.PicUrl = "http://180.169.11.53/senlan2.weixin/images/salesamount.png";
                    art2.Url = "http://180.169.11.53/senlan2.weixin/pages/salesamount.html";
                    news.Articles.Add(art2);

                    return news;
                }
                else
                {
                    return Bind(requestMessage.FromUserName);
                }
            }

            ResponseMessageText text = base.CreateResponseMessage<ResponseMessageText>();
            text.Content = "即将发布，敬请期待！";
            return text;
        }
    }
}