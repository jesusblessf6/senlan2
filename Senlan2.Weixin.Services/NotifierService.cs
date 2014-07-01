using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;

namespace Senlan2.Weixin.Services
{
    public class NotifierService
    {
        public List<WeixinAlert> GetWeixinAlerts()
        {
            using (SenLan2Entities ctx = new SenLan2Entities())
            {
                return ctx.WeixinAlerts.Include("User").ToList();
            }
        }

        public void DeleteWeixinAlerts(List<WeixinAlert> alerts)
        {
            using (SenLan2Entities ctx = new SenLan2Entities())
            {
                foreach(WeixinAlert a in alerts)
                {
                    WeixinAlert al = ctx.WeixinAlerts.Where(x => x.Id == a.Id).FirstOrDefault();
                    if (al != null)
                    {
                        ctx.WeixinAlerts.DeleteObject(al);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }

    public class WeixinAlertComparer : IEqualityComparer<WeixinAlert>
    {
        // Products are equal if their names and product numbers are equal.
        public bool Equals(WeixinAlert x, WeixinAlert y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.UserId == y.UserId && x.DocumentId == y.DocumentId;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(WeixinAlert product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = product.DocumentId.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = product.UserId.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }

    }
}
