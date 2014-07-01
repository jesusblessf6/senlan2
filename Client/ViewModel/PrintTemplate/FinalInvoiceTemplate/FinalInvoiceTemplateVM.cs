using System;
using System.Collections.Generic;
using System.Globalization;
using Client.Base.BaseClientVM;
using Client.CommercialInvoiceServiceReference;
using Client.SystemParameterServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.MarketPriceServiceReference;
using System.Linq;
using Client.CurrencyServiceReference;

namespace Client.ViewModel.PrintTemplate.FinalInvoiceTemplate
{
    public class FinalInvoiceTemplateVM : BaseVM
    {
        #region Member

        private List<FinalInvoiceHeader> _headerList;
        private List<LCProperties> _lcPropertyList;
        private string _pathName;

        public string PathName
        {
            get { return _pathName; }
            set
            {
                if (_pathName != value)
                {
                    _pathName = value;
                    Notify("PathName");
                }
            }
        }

        public List<FinalInvoiceHeader> HeaderList
        {
            get { return _headerList; }
            set
            {
                if (_headerList != value)
                {
                    _headerList = value;
                    Notify("HeaderList");
                }
            }
        }

        public List<LCProperties> LCPropertyList
        {
            get { return _lcPropertyList; }
            set
            {
                if (_lcPropertyList != value)
                {
                    _lcPropertyList = value;
                    Notify("LCPropertyList");
                }
            }
        }

        #endregion

        public FinalInvoiceTemplateVM(int finalInvoiceID)
        {
            HeaderList = new List<FinalInvoiceHeader>();
            LCPropertyList = new List<LCProperties>();
            GetValue(finalInvoiceID);
            GetPath(finalInvoiceID);
        }

        public void GetPath(int finalInvoiceID)
        {
            using (
                var finalInvoiceSerivce =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {finalInvoiceID};

                List<CommercialInvoice> invoiceList = finalInvoiceSerivce.Select(str, parameters,
                                                                                 new List<string>
                                                                                     {
                                                                                         "Currency",
                                                                                         "Deliveries",
                                                                                         "Deliveries.DeliveryLines.Brand"
                                                                                     });
                if (invoiceList.Count > 0)
                {
                    using (
                        var systemParameterService =
                            SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
                    {
                        SystemParameter systemParameter = systemParameterService.GetAll()[0];

                        if (systemParameter != null)
                        {
                            string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.FinalInvoiceTemplate);
                            PathName = @"PrintTemplate\" + name + "\\" + systemParameter.FinalInvoiceTemplatePath;
                        }
                    }
                }
            }
        }

        public void GetValue(int finalInvoiceID)
        {
            using (
                var finalInvoiceSerivce =
                    SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {finalInvoiceID};

                List<CommercialInvoice> invoiceList = finalInvoiceSerivce.Select(str, parameters,
                                                                                 new List<string>
                                                                                     {
                                                                                         "ClearBalanceCurrency",
                                                                                         "BankAccount.Currency",
                                                                                         "BankAccount",
                                                                                         "BankAccount.Bank",
                                                                                         "Quota.Commodity",
                                                                                         "ProvisionalInvoices",
                                                                                         "ProvisionalInvoices.LCCIRels",
                                                                                         "ProvisionalInvoices.LCCIRels.LetterOfCredit",
                                                                                         "Currency",
                                                                                         "LCCIRels",
                                                                                         "LCCIRels.LetterOfCredit",
                                                                                         "Quota.CommodityType",
                                                                                         "Quota",
                                                                                         "Quota.Currency",
                                                                                         "Quota.Contract.BusinessPartner",
                                                                                         "Quota.Contract.InternalCustomer",
                                                                                         "Deliveries.DeliveryLines",
                                                                                         "Deliveries",
                                                                                         "ProvisionalInvoices.Deliveries",
                                                                                         "ProvisionalInvoices.Deliveries.DeliveryLines.Brand",
                                                                                         "ProvisionalInvoices.BaseInvoice",
                                                                                         "ProvisionalInvoices.BaseInvoice.Deliveries",
                                                                                         "ProvisionalInvoices.BaseInvoice.Deliveries.DeliveryLines.Brand",
                                                                                         "ProvisionalInvoices.BaseInvoice.Deliveries.DeliveryLines.Country"
                                                                                     });
                if (invoiceList.Count > 0)
                {
                    CommercialInvoice invoice = invoiceList[0];
                    var header = new FinalInvoiceHeader();
                    if (string.IsNullOrEmpty(invoice.Quota.Contract.InternalCustomer.EnglishName))
                    {
                        header.InternalCustomerName = "";
                        header.InternalNameUpper = "";
                    }
                    else
                    {
                        header.InternalCustomerName = invoice.Quota.Contract.InternalCustomer.EnglishName;
                        header.InternalNameUpper = invoice.Quota.Contract.InternalCustomer.EnglishName.ToUpper();
                    }
                    header.InternalCustomerAddress = invoice.Quota.Contract.InternalCustomer.EnglishAddress;
                    header.BPartnerName = invoice.Quota.Contract.BusinessPartner.EnglishName;
                    header.BPartnerAddress = invoice.Quota.Contract.BusinessPartner.EnglishAddress;
                    header.BPartnerFAX = invoice.Quota.Contract.BusinessPartner.Fax;
                    header.BPartnerTEL = invoice.Quota.Contract.BusinessPartner.ContactPhone;
                    header.Date = invoice.InvoicedDate.Value.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                    header.DateFormat = (invoice.InvoicedDate == null ? "" : invoice.InvoicedDate.Value.Day + "-" + Convert.ToDateTime(invoice.InvoicedDate.Value).ToString("MMM", cultureInfo) + "-" + invoice.InvoicedDate.Value.Year.ToString().Substring(2));
                    header.PriceTerm = invoice.DeliveryTerm;
                    header.ContractNo = invoice.Quota.Contract.ContractNo;
                    header.BankName = invoice.BankAccount == null ? "" : invoice.BankAccount.Bank.Name;
                    header.BankAddress = invoice.BankAccount == null ? "" : invoice.BankAccount.Bank.Address;
                    header.BankAccount = invoice.BankAccount == null ? "" : invoice.BankAccount.AccountCode;
                    header.AccountCurrency = invoice.BankAccount == null ? "" : invoice.BankAccount.Currency.Code;
                    header.Code = invoice.BankAccount == null ? "" : invoice.BankAccount.Bank.Code;
                    string code = invoice.Currency.Code;
                    header.InvoiceCurrecyCode = code;
                    string pricingCode = invoice.Quota.Currency.Code;
                    decimal totalInterest = 0;
                    decimal totalInvoicesAmount = 0;

                    if (invoice.ProvisionalInvoices.Count > 0)
                    {
                        int i = 0;
                        foreach (CommercialInvoice commercialInvoice in invoice.ProvisionalInvoices)
                        {
                            FilterDeleted(commercialInvoice.LCCIRels);                       

                            if (commercialInvoice.LCCIRels != null && commercialInvoice.LCCIRels.Count > 0)
                            {
                                LetterOfCredit firstLetterOfCredit = commercialInvoice.LCCIRels.FirstOrDefault().LetterOfCredit;
                                if (firstLetterOfCredit.LCDays.HasValue)
                                {
                                  Dictionary<string, int>  promptBasis = new Dictionary<string, int>();
                                  promptBasis = EnumHelper.GetEnumDic<LCPromptBasis>(promptBasis);
                                  string basis = promptBasis.Where(c => c.Value == firstLetterOfCredit.PromptBasis.Value).FirstOrDefault().Key;
                                  header.PaymentTerm = firstLetterOfCredit.LCDays.Value + " DAYS AFTER " + basis + " FOR " + Convert.ToDouble(invoice.ProvisionalInvoices[0].Ratio) + "PCT OF INVOICE VALUE";
                                }
                                //foreach (var rel in commercialInvoice.LCCIRels)
                                //{
                                    var rel = commercialInvoice.LCCIRels.FirstOrDefault();
                                    LetterOfCredit lc = rel.LetterOfCredit;
                                    var lcProperty = new LCProperties();
                                    double rate = lc.IBORValue == null ? 0 : Convert.ToDouble(lc.IBORValue.Value);
                                    double floatLC = lc.Float == null ? 0 : Convert.ToDouble(lc.Float.Value);
                                    double result1 = rate + floatLC;
                                    string lmeCommodityName = string.Empty;
                                    if(lc.IBORType.HasValue)
                                    {
                                        using (var marketPriceService = SvcClientManager.GetSvcClient<MarketPriceServiceClient>(SvcType.MarketPriceSvc))
                                        {
                                            lmeCommodityName = marketPriceService.GetSelectLmeCommodity().Where(c => c.Key == lc.IBORType).FirstOrDefault().Value;
                                        }
                                    }
                                    //string type = lc.
                                    //lcProperty.InterestRate ="INTEREST RATE=" + rate + "%("+ lmeCommodityName + " of " + header.Date + ")+" + floatLC + "%=" + result1 + "%";
                                    //header.InterestRatePart1 = "INTEREST RATE=" + rate + "%(";
                                    //header.InterestRatePart2 = lmeCommodityName + " of " + header.Date + ")+";
                                    //header.InterestRatePart3 = floatLC + "%=" + result1 + "%";
                                    if (lc.IBORValue.HasValue && lc.Float.HasValue)
                                    {
                                        header.InterestRatePart2 = "INTEREST RATE=" + rate + "%";
                                        header.InterestRatePart3 = " +" + floatLC + "% = " + result1 + "%";
                                    }
                                    else
                                    {
                                        header.InterestRatePart2 = "INTEREST RATE=" + result1 + "%";
                                    }
                                    double allocationAmount = rel.AllocationAmount == null ? 0 : Convert.ToDouble(rel.AllocationAmount.Value);
                                    //交单金额
                                    decimal days = lc.LCDays == null ? 0 : lc.LCDays.Value;
                                    //lcProperty.Interest = code + allocationAmount + "*" + result1 + "%/360*" + days;
                                    header.Interest = code + allocationAmount + "*" + result1 + "%/360*" + days;
                                    double lInterest = lc.Interest == null ? 0 : Convert.ToDouble(lc.Interest.Value);
                                    double persentAmount = lc.PresentAmount == null ? 0 : Convert.ToDouble(lc.PresentAmount.Value);
                                    double interest = 0;
                                    if (persentAmount != 0 && allocationAmount != 0 && lInterest != 0)
                                    {
                                        interest = lInterest * allocationAmount / persentAmount;
                                    }
                                    //lcProperty.Result = code + string.Format("{0:#,##0.00}", interest);
                                    header.ResultForLC = code + string.Format("{0:#,##0.00}", interest);
                                    LCPropertyList.Add(lcProperty);

                                    if (lc.Interest.HasValue)
                                    {
                                        totalInterest += (decimal)interest;
                                    }

                                    if (i == 0)
                                    {
                                        header.LCNo += lc.LCNo;
                                        i++;
                                    }
                                    else if (i > 0)
                                    {
                                        header.LCNo += "," + lc.LCNo;
                                    }
                                //}
                            }
                        }
                    }

                    header.InvoiceNo = invoice.InvoiceNo;
                    header.Origin = invoice.Origins;
                    header.CommodityType = invoice.Quota.CommodityType.EnglishName;
                    string unit = invoice.Quota.Commodity.LMEUnit;
                    header.Brand = invoice.Brands;
                    header.Bundles = Convert.ToDouble(invoice.TotalPackingQuantity).ToString();
                    header.Quantity = string.Format("{0:#,##0.000}", invoice.NetWeights) + unit;
                    header.NetWeight = string.Format("{0:#,##0.000}", invoice.NetWeights) + unit;
                    header.QuantityForAwin = string.Format("{0:#,##0.000}", invoice.NetWeights);
                    header.GrossWeight = string.Format("{0:#,##0.000}", invoice.GrossWeights) + unit;
                    header.Price = invoice.Price.HasValue == false
                                       ? code + " 0 " + unit
                                       : code + string.Format("{0:#,##0.00}", invoice.Price.Value) + "/" + unit;
                    header.PriceForAwin = invoice.Price.HasValue == false
                                       ? code + " 0 " + unit
                                       : code + string.Format("{0:#,##0.00}", invoice.Price.Value);
                    header.Amount = invoice.Amount.HasValue == false
                                        ? code + "0"
                                        : code + string.Format("{0:#,##0.00}", invoice.Amount.Value - totalInterest);
                    header.LCInterest = code + string.Format("{0:#,##0.00}", totalInterest);
                    decimal totalAmount = (invoice.Amount == null ? 0 : invoice.Amount.Value);
                    header.TotalAmount = code + string.Format("{0:#,##0.00}", totalAmount);
                    using (
                        var invoiceService =
                            SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
                    {
                        List<CommercialInvoice> invoices = invoiceService.Select(
                            "it.FinalInvoiceId==" + finalInvoiceID, null, new List<string> {"Quota", "Quota.Currency"});
                        if (invoices.Count > 0)
                        {
                            foreach (CommercialInvoice i in invoices)
                            {
                                if (i.Amount.HasValue)
                                {
                                    totalInvoicesAmount += i.Amount.Value;
                                }
                            }
                        }
                    }
                    header.ProvisionalInvoiceAmount = code + string.Format("{0:#,##0.00}", totalInvoicesAmount);
                    decimal result = totalAmount - totalInvoicesAmount;
                    header.Type = result < 0 ? "BUYER" : "SELLER";
                    header.Packing = "IN BUNDLES";
                    header.Result = code + string.Format("{0:#,##0.00}", Math.Abs(result));
                    if(invoice.ClearBalanceCurrency != null)
                    {
                        if(invoice.CurrencyId != invoice.ClearBalanceCurrencyId)
                        {
                            header.ConvertBalanceTitle = "AMOUNT:";
                            Currency currency;
                            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                            {
                                currency = currencyService.GetById(invoice.CurrencyId.Value);
                            }
                            if (currency != null)
                            {
                                if (currency.Code == "CNY")
                                {
                                    header.ConvertBalance =  invoice.ClearBalanceCurrency.Code + string.Format("{0:#,##0.00}", Math.Abs(result) / invoice.ClearBalanceRate);
                                }
                                else if (currency.Code == "USD")
                                {
                                    header.ConvertBalance = invoice.ClearBalanceCurrency.Code + string.Format("{0:#,##0.00}", Math.Abs(result) * invoice.ClearBalanceRate);
                                }
                            }
                        }
                    }
                    if(invoice.CurrencyId != invoice.Quota.Currency.Id)
                    {
                        header.ConvertAmount = invoice.Amount == null ? pricingCode + 0 : pricingCode + string.Format("{0:#,##0.00}", ((invoice.Amount.Value - totalInterest) / invoice.ExchangeRate));
                        header.ConvertAmountTitle = "AMOUNT(" + pricingCode + "):";
                    }
                    HeaderList.Add(header);
                }
            }
        }
    }

    public class FinalInvoiceHeader
    {
        public string InternalCustomerName { get; set; }
        public string InternalCustomerAddress { get; set; }
        public string BPartnerName { get; set; }
        public string BPartnerAddress { get; set; }
        public string BPartnerTEL { get; set; }
        public string BPartnerFAX { get; set; }
        public string Date { get; set; }
        public string PriceTerm { get; set; }
        public string ContractNo { get; set; }
        public string LCNo { get; set; }
        public string InvoiceNo { get; set; }
        public string CommodityType { get; set; }
        public string Brand { get; set; }
        public string Quantity { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
        public string Bundles { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string LCInterest { get; set; }
        public string TotalAmount { get; set; }
        public string ProvisionalInvoiceAmount { get; set; }
        public string Result { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string AccountCurrency { get; set; }
        public string BankAccount { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string InternalNameUpper { get; set; }
        public string DateFormat { get; set; }
        public string Origin { get; set; }
        public string Packing { get; set; }
        public string PaymentTerm { get; set; }
        public string InterestRatePart1 { get; set; }
        public string InterestRatePart2 { get; set; }
        public string InterestRatePart3 { get; set; }
        public string Interest { get; set; }
        public string ResultForLC { get; set; }
        public string QuantityForAwin { get; set; }
        public string PriceForAwin { get; set; }
        public string ConvertAmount { get; set; }
        public string ConvertBalance { get; set; }
        public string PricingCode { get; set; }
        public string ConvertAmountTitle { get; set; }
        public string ConvertBalanceTitle { get; set; }
        public string InvoiceCurrecyCode { get; set; }
        public string ClearBalanceCurrency { get; set; }//2次计算币种
        public string APARAmount { get; set; }//应收应付金额2
    }

    public class LCProperties
    {
        public string InterestRate { get; set; }
        public string Interest { get; set; }
        public string Result { get; set; }
        public string LIBORType { get; set; }
    }
}