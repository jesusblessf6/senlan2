using System;
using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;

namespace Services.Helper.Pricings
{
    public class FixPricingHandler : BasePricingHandler
    {
        public FixPricingHandler(Quota quota, SenLan2Entities ctx)
            : base(quota, ctx)
        {
        }

        public override void Update()
        {
            var oldQuota = CTX.Quotas.Single(o => o.Id == Quota.Id);
            if (oldQuota != null && oldQuota.PricingType != Quota.PricingType)
            {
                base.Update();
            }
            else
            {
                var pricing = CTX.Pricings.FirstOrDefault(o => o.QuotaId == Quota.Id);
                if (pricing != null)
                {
                    pricing.BasicPrice = Quota.Price;
                    pricing.FinalPrice = Quota.Price;
                    pricing.PricingQuantity = Quota.Quantity;
                    pricing.CurrencyId = Quota.PricingCurrencyId;
					pricing.ExchangeRate = Quota.SettlementRate;
                }
            }
        }

        public override void Create()
        {
            var p = new Pricing
                        {
                            AdjustQPFee = 0,
                            BasicPrice = Quota.Price,
                            DeferFee = 0,
                            Description = string.Empty,
                            PricingQuantity = Quota.Quantity,
                            FinalPrice = Quota.Price,
                            PricingDate = Quota.ImplementedDate ?? DateTime.Today,
                            CurrencyId = Quota.PricingCurrencyId,
                            ExchangeRate = Quota.SettlementRate
                        };
            Quota.Pricings.Add(p);
            Quota.PricingStatus = (int)PricingStatus.Complete;
        }

        public override void Recreate()
        {
            var p = new Pricing
            {
                AdjustQPFee = 0,
                BasicPrice = Quota.Price,
                DeferFee = 0,
                Description = string.Empty,
                PricingQuantity = Quota.Quantity,
                FinalPrice = Quota.Price,
                PricingDate = Quota.ImplementedDate ?? DateTime.Today,
                QuotaId = Quota.Id,
                CurrencyId = Quota.PricingCurrencyId,
                ExchangeRate = Quota.SettlementRate
            };
            CTX.Pricings.AddObject(p);
            Quota.PricingStatus = (int)PricingStatus.Complete;
        }
    }
}