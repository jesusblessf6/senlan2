using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Senlan2.Weixin.Services;
using DBEntity;
using System.Transactions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Context;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;
using System.Web;

namespace Senlan2.Weixin.Test
{
    public partial class Form1 : Form
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private NotifierService _notifierSvc = new NotifierService();
        private readonly int _interval = 1000 * 10;
        private readonly string _appId = "wxe3be88b3096ec6fd";
        private readonly string _appSecret = "eed6de36e148a5c5c13d93ecd20a3769";
        public static Task _scanWeixinAlertsTask = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scanWeixinAlertsTask = new Task(ScanWeixinAlerts);
            _scanWeixinAlertsTask.Start();
        }
        private ResponseMessageNews Approval_Contract_News(DBEntity.User u, string fromUserName)
        {
            ResponseMessageNews news = new ResponseMessageNews();
            Article art = new Article();
            //art.Description = "您有" + _caSvc.GetQuotaApprovalsByName(u.LoginName).Count + "个要审批的合同，点击进入审批列表";
            art.Title = "上海益润微信公众号审批中心 - 待审合同";
            art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/approval.jpg";
            art.Url = "http://180.169.11.53/senlan2.weixin/pages/approval_contract.html?openid=" + fromUserName;
            news.Articles.Add(art);
            return news;
        }

        private ResponseMessageNews Approval_PaymentRequest_News(DBEntity.User u, string fromUserName)
        {
            ResponseMessageNews news = new ResponseMessageNews();
            Article art = new Article();
            //art.Description = "您有" + _praSvc.GetPaymentRequestApprovalsByName(u.LoginName).Count + "个要审批的付款申请，点击进入审批列表";
            art.Title = "上海益润微信公众号审批中心 - 待审付款申请";
            art.PicUrl = "http://180.169.11.53/senlan2.weixin/images/approval.jpg";
            art.Url = "http://180.169.11.53/senlan2.weixin/pages/approval_paymentrequest.html?openid=" + fromUserName;
            news.Articles.Add(art);
            return news;
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
                            if (alert.DocumentId == 4)
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
                            else if (alert.DocumentId == 9)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}
