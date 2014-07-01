using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using System;
using System.Globalization;

namespace Services.Helper.DocumentNoGenerator
{
    //进行合同号，商业发票等单据号的生成
    public class DocumentNoGenerator
    {
        //合同号
        public virtual string ContractNoGenerator(DateTime signDate, int contractType, int commodityId, int businessPartnerId,int tradeType)
        {
            //使用目前的生成规则 关联公司代码 + 金属 + p/s + 年月日 + 序号
            using (var ctx = new SenLan2Entities())
            {
                string no;
                string datetime = signDate.ToString("yyyyMMdd");
                BusinessPartner businessPartner = ctx.BusinessPartners.Where(b => b.Id == businessPartnerId).FirstOrDefault();
                Commodity commodity = ctx.Commodities.Where(c => c.Id == commodityId).FirstOrDefault();

                DateTime startTime = Convert.ToDateTime(signDate.ToShortDateString());
                DateTime endTime = startTime.AddDays(1);

                int contractCount = ctx.Contracts.Where(o => o.SignDate >= startTime && o.SignDate < endTime && o.ContractType == contractType).Count();

                contractCount++;

                if (contractType == (int)ContractType.Purchase)
                {
                    no = businessPartner.Code + "-" + commodity.Code + "-" + "P" + datetime + "-" +
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                }
                else
                {
                    no = businessPartner.Code + "-" + commodity.Code + "-" + "S" + datetime + "-" +
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                }

                return no;
            }
        }

        //批次号
        public virtual string QuotaNoGenerator(int contractId)
        {
            //contract no + 序号
            using (var ctx = new SenLan2Entities())
            {
                Contract contract = ctx.Contracts.Where(o => o.Id == contractId).FirstOrDefault();
                if (contract.TradeType == (int)TradeType.ShortDomesticTrade || contract.TradeType == (int)TradeType.ShortForeignTrade)
                {
                    return contract.ContractNo;
                }
                int quotaCount = ctx.Quotas.Include("Contract").Where(o => o.ContractId == contractId
                    && o.Contract.ContractType == contract.ContractType
                    && o.Contract.TradeType == contract.TradeType).Count();
                quotaCount++;
                return contract.ContractNo + "/" + quotaCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            }
        }

        //商业发票号
        public virtual string CommercialInvoiceNoGenerator(int quotaId)
        {
            using (var ctx = new SenLan2Entities())
            {
                Quota quota = ctx.Quotas.Where(q => q.Id == quotaId).FirstOrDefault();
                return quota.QuotaNo + "-Commercial";
            }
        }

        //临时发票号
        public virtual string ProvisionalInvoiceNoGenerator(int quotaId)
        {
            using (var ctx = new SenLan2Entities())
            {
                Quota quota = ctx.Quotas.Where(q => q.Id == quotaId).FirstOrDefault();
                return quota.QuotaNo + "-Provisional";
            }
        }

        //最终发票号
        public virtual string FinalInvoiceNoGenerator(int quotaId)
        {
            using (var ctx = new SenLan2Entities())
            {
                Quota quota = ctx.Quotas.Where(q => q.Id == quotaId).FirstOrDefault();
                return quota.QuotaNo + "-Final";
            }
        }
    }
}