using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Utility.ServiceManagement;
using Client.CommercialInvoiceServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using System.Globalization;

namespace Client.ViewModel.PrintTemplate.DocumentsTemplate
{
    public class DocumentsTemplateVM : BaseVM
    {
        #region Property
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

        private List<DocumentsHeader> _headerList;
        public List<DocumentsHeader> HeaderList
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

        public DocumentsTemplateVM(int invoiceID)
        {
            HeaderList = new List<DocumentsHeader>();
            GetValue(invoiceID);
        }

        #region Method
        public void GetValue(int invoiceID)
        {
            using (var invoiceSerivce = SvcClientManager.GetSvcClient<CommercialInvoiceServiceClient>(SvcType.CommercialInvoiceSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {invoiceID};

                List<CommercialInvoice> invoiceList = invoiceSerivce.Select(str, parameters,
                                                                            new List<string>
                                                                                {
                                                                                    "Deliveries.DeliveryLines.Brand",
                                                                                    "LCCIRels",
                                                                                    "LCCIRels.LetterOfCredit",
                                                                                    "Deliveries",
                                                                                    "BankAccount.Currency",
                                                                                    "BankAccount",
                                                                                    "BankAccount.Bank",
                                                                                    "Quota.Commodity",
                                                                                    "ProvisionalInvoices",
                                                                                    "ProvisionalInvoices.LCCIRels",
                                                                                    "ProvisionalInvoices.LCCIRels.LetterOfCredit",
                                                                                    "Currency",
                                                                                    "Quota.CommodityType",
                                                                                    "Quota",
                                                                                    "Quota.Contract.BusinessPartner",
                                                                                    "Quota.Contract.InternalCustomer",
                                                                                    "ProvisionalInvoices.Deliveries",
                                                                                    "ProvisionalInvoices.Deliveries.DeliveryLines.Brand"
                                                                                });
                if (invoiceList.Count > 0)
                {
                    CommercialInvoice invoice = invoiceList[0];
                    FilterDeleted(invoice.Deliveries);
                    FilterDeleted(invoice.LCCIRels);
                    FilterDeleted(invoice.ProvisionalInvoices);
                    var header = new DocumentsHeader();
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

                    header.InternalAddress = invoice.Quota.Contract.InternalCustomer.EnglishAddress;
                    header.BPartnerAddress = invoice.Quota.Contract.BusinessPartner.EnglishAddress;
                    header.BPartnerEnglishName = invoice.Quota.Contract.BusinessPartner.EnglishName;
                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                    header.InvoiceDate = Convert.ToDateTime(invoice.InvoicedDate).Day + "-" + Convert.ToDateTime(invoice.InvoicedDate).ToString("MMMM", cultureInfo).Substring(0, 3) + "-" + Convert.ToDateTime(invoice.InvoicedDate).Year;
                    header.QualityDate = Convert.ToDateTime(invoice.InvoicedDate).Day + "-" + Convert.ToDateTime(invoice.InvoicedDate).Month + "-" + Convert.ToDateTime(invoice.InvoicedDate).Year;
                    header.QuotaNo = invoice.Quota.Contract.ExContractNo;
                    header.CommodityType = invoice.Quota.CommodityType.EnglishName;

                    decimal? gWeight = 0;
                    decimal? nWeight = 0;
                    decimal bundle = 0;

                    if (invoice.InvoiceType == (int)CommercialInvoiceType.Final)
                    {
                        if (invoice.ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice pInvoice in invoice.ProvisionalInvoices)
                            {
                                FilterDeleted(pInvoice.Deliveries);
                                FilterDeleted(pInvoice.LCCIRels);

                                if (pInvoice.Deliveries.Count > 0)
                                {
                                    int i = 0;
                                    foreach (Delivery delivery in pInvoice.Deliveries)
                                    {
                                        gWeight += delivery.TotalGrossWeight;
                                        nWeight += delivery.TotalNetWeight;
                                        foreach (DeliveryLine line in delivery.DeliveryLines)
                                        {
                                            if (i == 0)
                                            {
                                                if (line.Brand != null)
                                                {
                                                    header.Brands += line.Brand.Name;
                                                    i++;
                                                }
                                            }
                                            else if (i > 0)
                                            {
                                                if (line.Brand != null)
                                                {
                                                    header.Brands += "/" + line.Brand.Name;
                                                }
                                            }

                                            if (line.PackingQuantity.HasValue)
                                            {
                                                bundle += line.PackingQuantity.Value;
                                            }
                                        }

                                    }
                                }
                                List<string> lcNos = new List<string>();

                                if (pInvoice.LCCIRels != null && pInvoice.LCCIRels.Count > 0)
                                {
                                    int i = 0;
                                    foreach (var rel in pInvoice.LCCIRels)
                                    {
                                        string lcNo = rel.LetterOfCredit.LCNo;
                                        if (lcNos.Contains(lcNo))
                                            continue;
                                        if (i == 0)
                                        {
                                            header.LetterNos += rel.LetterOfCredit.LCNo;
                                            i++;
                                        }
                                        else if (i > 0)
                                        {
                                            header.LetterNos += ";" + rel.LetterOfCredit.LCNo;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (invoice.Deliveries.Count > 0)
                        {
                            int i = 0;
                            foreach (Delivery delivery in invoice.Deliveries)
                            {
                                gWeight += delivery.TotalGrossWeight;
                                nWeight += delivery.TotalNetWeight;

                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                {
                                    if (i == 0)
                                    {
                                        if (line.Brand != null)
                                        {
                                            header.Brands += line.Brand.Name;
                                            i++;
                                        }
                                    }
                                    else if (i > 0)
                                    {
                                        if (line.Brand != null)
                                        {
                                            header.Brands += "/" + line.Brand.Name;
                                        }
                                    }

                                    if (line.PackingQuantity.HasValue)
                                    {
                                        bundle += line.PackingQuantity.Value;
                                    }
                                }

                            }
                        }


                        List<string> lcNos = new List<string>();

                        if (invoice.LCCIRels != null && invoice.LCCIRels.Count > 0)
                        {
                            int i = 0;
                            foreach (var rel in invoice.LCCIRels)
                            {
                                string lcNo = rel.LetterOfCredit.LCNo;
                                if (lcNos.Contains(lcNo))
                                    continue;
                                if (i == 0)
                                {
                                    header.LetterNos += rel.LetterOfCredit.LCNo;
                                    i++;
                                }
                                else if (i > 0)
                                {
                                    header.LetterNos += ";" + rel.LetterOfCredit.LCNo;
                                }
                            }
                        }
                    }
                    string unit = invoice.Quota.Commodity.LMEUnit;
                    header.NetWeight = string.Format("{0:#,##0.0000}", nWeight) + " " + unit;
                    header.GrossWeight = string.Format("{0:#,##0.0000}", gWeight) + " " + unit;
                    header.Bundles = Math.Round(bundle).ToString(CultureInfo.InvariantCulture);
                    HeaderList.Add(header);
                }
            }
        }
        #endregion
    }
    public class DocumentsHeader
    {
        public string InternalEnglishName { get; set; }
        public string InternalAddress { get; set; }
        public string InternalNameUpper { get; set; }
        public string BPartnerEnglishName { get; set; }
        public string BPartnerAddress { get; set; }
        public string InvoiceDate { get; set; }
        public string QuotaNo { get; set; }
        public string LetterNos { get; set; }
        public string CommodityType { get; set; }
        public string Brands { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
        public string Bundles { get; set; }
        public string Origin { get; set; }
        public string Unit { get; set; }
        public string QualityDate { get; set; }
    }

}
