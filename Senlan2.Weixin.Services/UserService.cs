using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;

namespace Senlan2.Weixin.Services
{
    public class UserService
    {
        public User GetUserByOpenId(string openId)
        {
            using (DBEntity.SenLan2Entities ctx = new DBEntity.SenLan2Entities())
            {
                return ctx.Users.FirstOrDefault(o => o.WeixinOpenId == openId);
            }
        }
    }
}
