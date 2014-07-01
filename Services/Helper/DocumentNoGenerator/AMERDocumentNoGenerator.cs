using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBEntity;
using DBEntity.EnumEntity;
using System.Globalization;

namespace Services.Helper.DocumentNoGenerator
{
    public class AMERDocumentNoGenerator : DocumentNoGenerator
    {
        public override string ContractNoGenerator(DateTime signDate, int contractType, int commodityId, int businessPartnerId, int tradeType)
        {
            //生成规则：公司代码 + 金属 + YYMMDD + D/L + 序号
            //D是短单，L是长单
            using (var ctx = new SenLan2Entities())
            {
                string no;
                string tradeTypeValue = string.Empty;
                string datetime = signDate.ToString("yyMMdd");
                BusinessPartner businessPartner = ctx.BusinessPartners.Where(b => b.Id == businessPartnerId).FirstOrDefault();
                Commodity commodity = ctx.Commodities.Where(c => c.Id == commodityId).FirstOrDefault();

                DateTime startTime = Convert.ToDateTime(signDate.ToShortDateString());
                DateTime endTime = startTime.AddDays(1);

                if (tradeType == (int)TradeType.ShortDomesticTrade || tradeType == (int)TradeType.ShortForeignTrade)
                {
                    tradeTypeValue = "D";
                }
                else if(tradeType == (int)TradeType.LongDomesticTrade || tradeType == (int)TradeType.LongForeignTrade)
                {
                    tradeTypeValue = "L";
                }

                int contractCount = ctx.Contracts.Where(o => o.SignDate >= startTime && o.SignDate < endTime && o.ContractType == contractType).Count();

                contractCount++;

                if (contractType == (int)ContractType.Purchase)
                {
                    no = businessPartner.Code + "-" + commodity.Code + "-"+ datetime + tradeTypeValue + 
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0') + "-" + "P";
                }
                else
                {
                    no = businessPartner.Code + "-" + commodity.Code + "-" + datetime + tradeTypeValue +
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0') + "-" + "S";
                }

                return no;
            }
        }

        public override string QuotaNoGenerator(int contractId)
        {
            return base.QuotaNoGenerator(contractId);
        }
    }
}