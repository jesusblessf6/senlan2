using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;

namespace Senlan2.Weixin.Services
{
    public class LoginService
    {
        //public bool IsValid(string name, string password)
        //{
        //    password = Senlan2.Weixin.Services.EncryptService.Encode(password);
        //    using(Senlan2.Weixin.Models.Senlan2Entities ctx = new Models.Senlan2Entities())
        //    {
        //        int count = ctx.Users.Count(u => u.LoginName == name && u.Password == password);
        //        if (count > 0)
        //            return true;
        //        return false;
        //    }
        //}

        public User IsBind(string openId)
        {
            using (DBEntity.SenLan2Entities ctx = new DBEntity.SenLan2Entities())
            {
                return ctx.Users.Where(o => o.IsDeleted == false && o.WeixinOpenId == openId).FirstOrDefault();
            }
        }

        public string Bind(string name, string password, string openId)
        {
            password = Utility.Misc.Encrypt.Encode(password);
            using (DBEntity.SenLan2Entities ctx = new DBEntity.SenLan2Entities())
            {
                User u = ctx.Users.Where(o => o.IsDeleted == false && o.LoginName == name && o.Password == password).FirstOrDefault();
                if (u == null)
                    return "账号或者密码错误，请重试！";
                if(string.IsNullOrEmpty(u.WeixinOpenId) == false)
                {
                    return "系统账号" + u.LoginName + "已经绑定微信账号, 请解绑定后再进行新系统账号的绑定！";
                }
                if(ctx.Users.Count(o => o.IsDeleted == false && o.WeixinOpenId == openId) > 0)
                {
                    return "该微信账号已经绑定系统账号，请解绑定后再进行新系统账号的绑定！";
                }
                u.WeixinOpenId = openId;
                ctx.SaveChanges();
                return string.Empty;
            }
        }

        public string UnBind(string openId)
        {
            using (DBEntity.SenLan2Entities ctx = new DBEntity.SenLan2Entities())
            {
                User u = ctx.Users.Where(o => o.IsDeleted == false && o.WeixinOpenId == openId).FirstOrDefault();
                if (u == null)
                    return "解绑定失败，请重试！";
                u.WeixinOpenId = null;
                List<WeixinAlert> alerts = ctx.WeixinAlerts.Where(a => a.UserId == u.Id).ToList();
                foreach (WeixinAlert alert in alerts)
                {
                    ctx.DeleteObject(alert);
                }
                ctx.SaveChanges();
                return string.Empty;
            }
        }
    }
}
