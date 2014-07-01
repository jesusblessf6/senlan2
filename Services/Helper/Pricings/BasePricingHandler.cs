using System.Linq;
using DBEntity;

namespace Services.Helper.Pricings
{
    public class BasePricingHandler : IPricingHandler
    {
        public virtual void Handle()
        {
            if(Quota.Id > 0)
            {
                Update();
            }
            else
            {
                if(Quota.Unpricings == null)
                {
                    Quota.Unpricings = new TrackableCollection<Unpricing>();
                }
                Create();
            }
        }

        public virtual void Create()
        {
            
        }

        public virtual void Recreate()
        {
            
        }

        public virtual void Update()
        {
            var ps = CTX.Pricings.Where(o => o.QuotaId == Quota.Id);
            foreach (var pricing in ps)
            {
                Pricing pricing1 = pricing;
                var relps = CTX.Pricings.Where(o => o.RelPricingId == pricing1.Id);
                foreach (var relp in relps)
                {
                    relp.RelPricingId = null;
                    CTX.SaveChanges();
                }

                CTX.Pricings.DeleteObject(pricing);
            }
            CTX.SaveChanges();

            var ups = CTX.Unpricings.Where(o => o.QuotaId == Quota.Id);
            foreach (var unpricing in ups)
            {
                Unpricing unpricing1 = unpricing;
                var relups = CTX.Unpricings.Where(o => o.RelUnpricingId == unpricing1.Id);
                foreach (var relup in relups)
                {
                    relup.RelUnpricingId = null;
                    CTX.SaveChanges();
                }

                CTX.Unpricings.DeleteObject(unpricing);
            }
            CTX.SaveChanges();

            Recreate();
        }

        public Quota Quota { get; set; }

        public SenLan2Entities CTX { get; set; }

        public BasePricingHandler(Quota quota, SenLan2Entities ctx)
        {
            Quota = quota;
            CTX = ctx;
        }
    }
}