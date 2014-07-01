using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Utility.ServiceManagement;
using Client.CommercialInvoiceServiceReference;
using DBEntity;
using Client.SystemParameterServiceReference;
using Utility.Misc;
using DBEntity.EnumEntity;
using System.Globalization;
using System.Linq;

namespace Client.ViewModel.PrintTemplate.ProvisionalInvoiceTemplate
{
    public class ProvisionalInvoiceTemplateVM : BaseVM
    {
        #region Member
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

        private List<ProvisionalInvoiceHeader> _headerList;
        public List<ProvisionalInvoiceHeader> HeaderList
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
        #endregion

        #region Contrustor
        public ProvisionalInvoiceTemplateVM(int provisionalInvoiceID)
        {
            HeaderList = new List<ProvisionalInvoiceHeader>();
            GetPath(provisionalInvoiceID);
            GetValue(provisionalInvoiceID);
        }
        #endregion

        #region Method
        public void GetPath(int provisionalInvoiceID)
        {
            using (var provisionalInvoiceSerivce = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {provisionalInvoiceID};
                List<CommercialInvoice> invoiceList = provisionalInvoiceSerivce.Select(str, parameters, new List<string> { "Currency", "Deliveries", "Deliveries.DeliveryLines.Brand" });
                if (invoiceList.Count > 0)
                {
                    using (var systemParameterService = SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
                    {
                        SystemParameter systemParameter = systemParameterService.GetAll()[0];

                        if (systemParameter != null)
                        {
                            string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.ProvisionalInvoiceTemplate);
                            PathName = @"PrintTemplate\" + name + "\\" + systemParameter.ProvisionalInvoiceTemplatePath;
                        }
                    }
                }

            }
        }

        public void GetValue(int provisionalInvoiceID)
        {
            using (var provisionalInvoiceSerivce = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {provisionalInvoiceID};
                List<CommercialInvoice> invoiceList = provisionalInvoiceSerivce.Select(str, parameters, new List<string> { "LCCIRels.LetterOfCredit", "LCCIRels", "PaymentMean", "Quota.Commodity", "BankAccount.Bank", "BankAccount", "Quota.CommodityType", "Quota.Contract", "Quota.Contract.BusinessPartner", "Quota.Contract.InternalCustomer", "PaymentMean", "Currency", "Deliveries", "Deliveries.DeliveryLines.Country", "Deliveries.DeliveryLines.Brand", "BaseInvoice", "BaseInvoice.Deliveries", "BaseInvoice.Deliveries.DeliveryLines.Brand", "BaseInvoice.Deliveries.DeliveryLines.Country" });
                if (invoiceList.Count > 0)
                {
                    CommercialInvoice invoice = invoiceList[0];
                    var header = new ProvisionalInvoiceHeader();
                    if (string.IsNullOrEmpty(invoice.Quota.Contract.InternalCustomer.EnglishName))
                    {
                        header.InternalEnglishName = "";
                        header.InternalNameUpper = "";
                    }
                    else
                    {
                        header.InternalEnglishName = invoice.Quota.Contract.InternalCustomer.EnglishName;
                        header.InternalNameUpper = invoice.Quota.Contract.InternalCustomer.EnglishName.ToUpper();
                    }
                    header.InternalEnglishAddress = invoice.Quota.Contract.InternalCustomer.EnglishAddress;
                    header.BPartnerEnglishName = invoice.Quota.Contract.BusinessPartner.EnglishName;
                    header.BPartnerEnglishAddress = invoice.Quota.Contract.BusinessPartner.EnglishAddress;
                    header.Date = invoice.InvoicedDate.Value.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                    header.DateFormat = (invoice.InvoicedDate == null ? "" : invoice.InvoicedDate.Value.Day + "-" + Convert.ToDateTime(invoice.InvoicedDate.Value).ToString("MMM", cultureInfo) + "-" + invoice.InvoicedDate.Value.Year.ToString().Substring(2));
                    header.ContractNo = invoice.Quota.Contract.ContractNo;
                    header.InvoiceNo = invoice.InvoiceNo;
                    if(invoice.LCCIRels != null && invoice.LCCIRels.Count > 0)
                    {
                        for (int i = 0; i < invoice.LCCIRels.Count; i++ )
                        {
                            if (!invoice.LCCIRels[i].LetterOfCredit.IsDeleted)
                            {
                                    if (string.IsNullOrEmpty(header.LCNo))
                                    {
                                        header.LCNo = invoice.LCCIRels[i].LetterOfCredit.LCNo;
                                    }
                            }
                        }
                    }
                    header.PaymentBy = invoice.PaymentMean == null ? "" : invoice.PaymentMean.Name;
                    header.PriceTerm = invoice.DeliveryTerm;
                    header.CommodityType = invoice.Quota.CommodityType.EnglishName;
                    header.Amount = string.Format("{0:#,##0.00}", invoice.Amount);
                    header.BankName = invoice.BankAccount == null || invoice.BankAccount.Bank == null ? "" : invoice.BankAccount.Bank.Name;
                    header.BankAddress = invoice.BankAccount == null || invoice.BankAccount.Bank == null ? "" : invoice.BankAccount.Bank.Address;
                    header.BankAccount = invoice.BankAccount == null ? "" : invoice.BankAccount.AccountCode;
                    header.AccountCurrency = invoice.BankAccount == null || invoice.BankAccount.Currency == null ? "" : invoice.BankAccount.Currency.Code;
                    header.SwiftCode = invoice.BankAccount == null || invoice.BankAccount.Bank == null ? "" : invoice.BankAccount.Bank.Code;
                    header.Packing = "IN BUNDLES";
                    string unit = invoice.Quota.Commodity.LMEUnit;
                    string code = invoice.Currency.Code;
                    header.Brands = invoice.Brands;
                    header.Origin = invoice.Origins;
                    header.BundlesNum = invoice.TotalPackingQuantity;
                    header.Price = invoice.Price.HasValue == false ? code + " 0 " : code + string.Format("{0:#,##0.00}", invoice.Price.Value) +"/"+ unit;
                    header.PriceForAwin = invoice.Price.HasValue == false ? code + " 0 " : code + string.Format("{0:#,##0.00}", invoice.Price.Value);
                    header.Amount = invoice.Amount.HasValue == false ? code + "0" : code + string.Format("{0:#,##0.00}", invoice.Amount.Value);
                    header.TotalQty = Math.Round(invoice.NetWeights, RoundRules.QUANTITY, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
                    header.NetWeight = Math.Round(invoice.NetWeights, RoundRules.QUANTITY, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture) + unit;
                    header.GrossWeight = Math.Round(invoice.GrossWeights, RoundRules.QUANTITY, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture) + unit;
                    HeaderList.Add(header);
                }
            }
        }
        #endregion
    }

    public class ProvisionalInvoiceHeader
    {
        public string InternalEnglishName { get; set; }
        public string InternalEnglishAddress { get; set; }
        public string BPartnerEnglishName { get; set; }
        public string BPartnerEnglishAddress { get; set; }
        public string Date { get; set; }
        public string ContractNo { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentBy { get; set; }
        public string PriceTerm { get; set; }
        public string TotalQty { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string CommodityType { get; set; }
        public string Origin { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
        public string Packing { get; set; }
        public string Brands { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string AccountCurrency { get; set; }
        public string BankAccount { get; set; }
        public string SwiftCode { get; set; }
        public string InternalNameUpper { get; set; }
        public string LCNo { get; set; }
        public decimal? BundlesNum { get; set; }
        public string DateFormat { get; set; }
        public string PriceForAwin { get; set; }
    }
}
