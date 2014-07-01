using System.Linq;
using DBEntity;
using DBEntity.EnumEntity;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Services.Helper.DocumentNoGenerator
{
    //中铜单据代码生成规则
    public class CCIGDocumentNoGenerator : DocumentNoGenerator
    {
        public override string ContractNoGenerator(DateTime signDate, int contractType, int commodityId, int businessPartnerId, int tradeType)
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

                int contractCount = ctx.Contracts.Where(o => o.SignDate >= startTime && o.SignDate < endTime && o.ContractType == contractType && o.InternalCustomerId == businessPartnerId).Count();

                contractCount++;

                if (contractType == (int)ContractType.Purchase)
                {
                    no = businessPartner.Code + "-" + "P" + datetime + "-" +
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                }
                else
                {
                    no = businessPartner.Code + "-" + "S" + datetime + "-" +
                            contractCount.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
                }

                return no;
            }
            //return base.ContractNoGenerator(signDate, contractType, commodityId, businessPartnerId, tradeType);
        }

        public override string QuotaNoGenerator(int contractId)
        {
            return base.QuotaNoGenerator(contractId);
        }

        public override string ProvisionalInvoiceNoGenerator(int quotaId)
        {
            return GetInvoiceNoByQuotaId(quotaId, (int)CommercialInvoiceType.Provisional, string.Empty);
        }

        public override string CommercialInvoiceNoGenerator(int quotaId)
        {
            return GetInvoiceNoByQuotaId(quotaId, (int)CommercialInvoiceType.FinalCommercial, "FINAL");
        }

        public override string FinalInvoiceNoGenerator(int quotaId)
        {
            return GetInvoiceNoByQuotaId(quotaId, (int)CommercialInvoiceType.Final, "FINAL");
        }

        private string GetInvoiceNoByQuotaId(int quotaId, int invoiceType, string invoiceStr)
        {
            using (var ctx = new SenLan2Entities())
            {
                Quota quota = ctx.Quotas.Where(q => q.Id == quotaId).FirstOrDefault();
                string quotaNo = quota.QuotaNo;
                string invoiceNo = quotaNo.Replace('-', '.');
                invoiceNo += (invoiceStr != string.Empty ? "." : "");

                int nextInvoicesCount = 0;
                if (invoiceType == (int)CommercialInvoiceType.Provisional)
                {
                    nextInvoicesCount = ctx.CommercialInvoices.Where(ci => ci.QuotaId == quotaId && ci.InvoiceType == (int)CommercialInvoiceType.Provisional).Count() + 1;
                }
                else
                {
                    nextInvoicesCount = ctx.CommercialInvoices.Where(ci => ci.QuotaId == quotaId && (ci.InvoiceType == (int)CommercialInvoiceType.FinalCommercial || ci.InvoiceType == (int)CommercialInvoiceType.Final)).Count() + 1;
                }

                if (nextInvoicesCount > 1)
                {
                    invoiceNo += invoiceStr + nextInvoicesCount;
                }
                else
                {
                    invoiceNo += invoiceStr;
                }
                return invoiceNo;
            }
        }
    }
}