using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Client.Base.BaseClientVM;
using Client.ContractServiceReference;
using Client.PricingServiceReference;
using Client.SystemParameterServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.UserServiceReference;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.PrintTemplate.DomesticContractTemplate
{
    public class PrintContractTemplateVM : BaseVM
    {
        #region Member

        private List<ContractReportProperty> _headerList;
        private List<QuotaList> _lineList;
        private string _pathName;

        #endregion

        #region Property

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

        public List<ContractReportProperty> HeaderList
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

        public List<QuotaList> LineList
        {
            get { return _lineList; }
            set
            {
                if (_lineList != value)
                {
                    _lineList = value;
                    Notify("LineList");
                }
            }
        }

        public string FileName { get; set; }

        #endregion

        #region Contructor

        public PrintContractTemplateVM(int contractID)
        {
            HeaderList = new List<ContractReportProperty>();
            LineList = new List<QuotaList>();
            GetValue(contractID);
            GetPath(contractID);
        }

        #endregion

        #region Method

        public void GetPath(int contractID)
        {
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                const string sql = "it.Id = @p1";
                var parameters = new List<object> {contractID};

                List<Contract> contractList = contractService.Select(sql, parameters,
                                                                     new List<string>
                                                                         {
                                                                             "BusinessPartner",
                                                                             "InternalCustomer",
                                                                             "Quotas",
                                                                             "Quotas.CommodityType",
                                                                             "Quotas.Brand",
                                                                             "Quotas.Specification"
                                                                         });
                if (contractList.Count > 0)
                {
                    Contract contract = contractList[0];
                    FilterDeleted(contract.Quotas);
                    if (contract != null)
                    {
                        if (contract.TradeType == (int) TradeType.LongDomesticTrade ||
                            contract.TradeType == (int) TradeType.ShortDomesticTrade) //内贸合同
                        {
                            using (
                                var systemParameterService =
                                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(
                                        SvcType.SystemParameterSvc))
                            {
                                SystemParameter systemParameter = systemParameterService.GetAll()[0];

                                if (systemParameter != null)
                                {
                                    string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.DomesticContractTemplate);
                                    PathName = @"PrintTemplate\" + name + "\\" +
                                               systemParameter.DomesticContractTemplatePath;
                                }
                            }
                        }
                        else if (contract.TradeType == (int) TradeType.LongForeignTrade ||
                                 contract.TradeType == (int) TradeType.ShortForeignTrade) //外贸合同
                        {
                            using (
                                var systemParameterService =
                                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(
                                        SvcType.SystemParameterSvc))
                            {
                                SystemParameter systemParameter = systemParameterService.GetAll()[0];

                                if (systemParameter != null)
                                {
                                    string name =
                                        EnumHelper.GetDescriptionByCulture(PrintTemplateType.InternationalContractTemplate);
                                    PathName = @"PrintTemplate\" + name + "\\" +
                                               systemParameter.InternationalContractTemplatePath;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GetValue(int contractID)
        {
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                const string sql = "it.Id = @p1";
                var parameters = new List<object> {contractID};

                List<Contract> contractList = contractService.Select(sql, parameters,
                                                                     new List<string>
                                                                         {
                                                                             "BusinessPartner",
                                                                             "InternalCustomer",
                                                                             "BusinessPartner.BankAccounts",
                                                                             "BusinessPartner.BankAccounts.Bank",
                                                                             "InternalCustomer.BankAccounts",
                                                                             "InternalCustomer.BankAccounts.Bank",
                                                                             "Quotas",
                                                                             "Quotas.CommodityType",
                                                                             "Quotas.Brand",
                                                                             "Quotas.Specification",
                                                                             "Quotas.Commodity",
                                                                             "Quotas.Warehouse",
                                                                             "Quotas.QuotaBrandRels",
                                                                             "Quotas.QuotaBrandRels.Brand",
                                                                             "Quotas.QuotaBrandRels.Specification",
                                                                             "Quotas.QuotaBrandRels.Warehouse",
                                                                             "BankAccount",
                                                                             "BankAccount.Bank"
                                                                         });
                if (contractList.Count > 0)
                {
                    Contract contract = contractList[0];
                    FilterDeleted(contract.Quotas);

                    if (contract.ContractType == (int) ContractType.Purchase)
                    {
                        FileName += contract.BusinessPartner.ShortName;
                        FileName += "-" + contract.InternalCustomer.ShortName;
                    }
                    else
                    {
                        FileName += contract.InternalCustomer.ShortName;
                        FileName += "-" + contract.BusinessPartner.ShortName;
                    }

                    if (contract.Quotas.Count > 0)
                    {
                        var q = contract.Quotas[0];
                        FileName += "-" + Math.Round(q.Quantity ?? 0, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                        FileName += "-" + Math.Round(q.FinalPrice ?? 0, RoundRules.PRICE, MidpointRounding.AwayFromZero);
                        if (q.Brand != null)
                        {
                            FileName += "-" + q.Brand.Name;
                        }
                    }

                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                    var crp = new ContractReportProperty();
                    
                    if (contract.ContractType == (int) ContractType.Purchase) //采购合同
                    {
                        crp.isVisible = 0;//不显示 （银行名称和银行账号）
                        crp.SupplierName = contract.BusinessPartner.Name;
                        crp.SupplierAgent = contract.BusinessPartner.ContactPerson;
                        crp.SupplierPhone = contract.BusinessPartner.ContactPhone;
                        crp.SupplierFax = contract.BusinessPartner.Fax;
                        crp.SupplierAddress = contract.BusinessPartner.Address;
                        crp.SupplierPostCode = contract.BusinessPartner.ZipCode;
                        if(contract.BusinessPartner.BankAccounts != null && contract.BusinessPartner.BankAccounts.Count > 0)
                        {
                            crp.SupplierBank = contract.BusinessPartner.BankAccounts[0].Bank == null ? "" : contract.BusinessPartner.BankAccounts[0].Bank.Name;
                            crp.SupplierAccount = contract.BusinessPartner.BankAccounts[0].AccountCode;
                        }
                        crp.NeedAgent = contract.InternalCustomer.ContactPerson;
                        crp.NeedFax = contract.InternalCustomer.Fax;
                        crp.NeedName = contract.InternalCustomer.Name;
                        crp.NeedPhone = contract.InternalCustomer.ContactPhone;
                        crp.NeedAddress = contract.InternalCustomer.Address;
                        crp.NeedPostCode = contract.InternalCustomer.ZipCode;
                        if (contract.InternalCustomer.BankAccounts != null && contract.InternalCustomer.BankAccounts.Count > 0)
                        {
                            crp.NeedBank = contract.InternalCustomer.BankAccounts[0].Bank == null ? "" : contract.InternalCustomer.BankAccounts[0].Bank.Name;
                            crp.NeedAccount = contract.InternalCustomer.BankAccounts[0].AccountCode;
                        }
                        crp.SupplierEnglishName = contract.BusinessPartner.EnglishName;
                        crp.CustomerType = "(seller)";
                    }
                    else if (contract.ContractType == (int) ContractType.Sales) //销售合同
                    {
                        crp.isVisible = 1;//显示
                        if(contract.BankAccount != null)
                        {
                            crp.BankAccountNo = contract.BankAccount.AccountCode;
                            if(contract.BankAccount.Bank != null)
                            {
                                crp.BankName = contract.BankAccount.Bank.Name;
                            }
                        }
                        crp.SupplierName = contract.InternalCustomer.Name;
                        crp.SupplierAgent = contract.InternalCustomer.ContactPerson;
                        crp.SupplierPhone = contract.InternalCustomer.ContactPhone;
                        crp.SupplierFax = contract.InternalCustomer.Fax;
                        crp.SupplierAddress = contract.InternalCustomer.Address;
                        crp.SupplierPostCode = contract.InternalCustomer.ZipCode;
                        if (contract.InternalCustomer.BankAccounts != null && contract.InternalCustomer.BankAccounts.Count > 0)
                        {
                            crp.SupplierBank = contract.InternalCustomer.BankAccounts[0].Bank == null ? "" : contract.InternalCustomer.BankAccounts[0].Bank.Name;
                            crp.SupplierAccount = contract.InternalCustomer.BankAccounts[0].AccountCode;
                        }
                        crp.NeedAgent = contract.BusinessPartner.ContactPerson;
                        crp.NeedFax = contract.BusinessPartner.Fax;
                        crp.NeedName = contract.BusinessPartner.Name;
                        crp.NeedPhone = contract.BusinessPartner.ContactPhone;
                        crp.NeedAddress = contract.BusinessPartner.Address;
                        crp.NeedPostCode = contract.BusinessPartner.ZipCode;
                        if (contract.BusinessPartner.BankAccounts != null && contract.BusinessPartner.BankAccounts.Count > 0)
                        {
                            crp.NeedBank = contract.BusinessPartner.BankAccounts[0].Bank == null ? "" : contract.BusinessPartner.BankAccounts[0].Bank.Name;
                            crp.NeedAccount = contract.BusinessPartner.BankAccounts[0].AccountCode;
                        }
                        crp.SupplierEnglishName = contract.InternalCustomer.EnglishName;
                        crp.CustomerType = "(buyer)";
                    }
                    crp.BPartnerEnglishName = contract.BusinessPartner.EnglishName;
                    crp.BPartnerEnglishAddress = contract.BusinessPartner.EnglishAddress;
                    crp.InternalEnglishName = contract.InternalCustomer.EnglishName;
                    crp.ContractNo = contract.ContractNo;
                    crp.QtyLimit = contract.QtyLimit == null ? "" : " plus or minus " + contract.QtyLimit.Value.ToString() + " percent in Seller’s option";
                    crp.Desc = contract.Description;
                    crp.SignDate = contract.SignDate == null
                                       ? ""
                                       : Convert.ToDateTime(contract.SignDate).GetDateTimeFormats('D')[0];
                    crp.SignEnglishDate = contract.SignDate == null ? "" : Convert.ToDateTime(contract.SignDate).Day + "th " + Convert.ToDateTime(contract.SignDate).ToString("MMMM", cultureInfo) + " " + Convert.ToDateTime(contract.SignDate).Year;

                    if (contract.Quotas.Count > 0)
                    {
                        Quota quotaFirst = contract.Quotas[0];
                        if (quotaFirst != null)
                        {
                            crp.QuotaYear = quotaFirst.DeliveryDate == null ? contract.SignDate.Value.Year.ToString(CultureInfo.InvariantCulture) : quotaFirst.DeliveryDate.Value.Year.ToString(CultureInfo.InvariantCulture);
                            int month = quotaFirst.DeliveryDate == null ? contract.SignDate.Value.Month : quotaFirst.DeliveryDate.Value.Month;
                            crp.QuotaMonth = quotaFirst.DeliveryDate == null ? contract.SignDate.Value.Month.ToString(CultureInfo.InvariantCulture) : quotaFirst.DeliveryDate.Value.Month.ToString(CultureInfo.InvariantCulture);
                            int day = quotaFirst.DeliveryDate == null ? contract.SignDate.Value.Day : quotaFirst.DeliveryDate.Value.Day;
                            crp.QuotaDay = quotaFirst.DeliveryDate == null ? contract.SignDate.Value.Day.ToString(CultureInfo.InvariantCulture) : quotaFirst.DeliveryDate.Value.Day.ToString(CultureInfo.InvariantCulture);
                            if (day > 25)
                            {
                                crp.QuotaMonth1 = (month + 1).ToString(CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                crp.QuotaMonth1 = month.ToString(CultureInfo.InvariantCulture);
                            }
                            crp.QuotaWarehouseName = quotaFirst.Warehouse == null ? "" : quotaFirst.Warehouse.Name;
                            if(!string.IsNullOrEmpty(quotaFirst.Commodity.Code))
                            {
                                if(quotaFirst.Commodity.Code == "AU")//黄金
                                {
                                    crp.QtyUnit = "克";
                                }
                                else if (quotaFirst.Commodity.Code == "AG")
                                {
                                    crp.QtyUnit = "千克";
                                }
                                else
                                {
                                    crp.QtyUnit = "吨";
                                }
                            }
                            crp.BrandName = quotaFirst.Brand == null ? "Any Brand" : quotaFirst.Brand.Name;
                            crp.CommodityTypeEnglishName = quotaFirst.CommodityType.EnglishName;
                            crp.PricingEndDate =quotaFirst.PricingEndDate == null ? "" :
                                Convert.ToDateTime(quotaFirst.PricingEndDate).ToString("MMMM", cultureInfo) + " " + Convert.ToDateTime(quotaFirst.PricingEndDate).Day+ "th," +
                                Convert.ToDateTime(quotaFirst.PricingEndDate).Year;
                            crp.PromptDate = quotaFirst.PricingEndDate == null
                                                 ? ""
                                                 : Convert.ToDateTime(quotaFirst.PricingEndDate).AddDays(2).ToString(
                                                     "MMMM", cultureInfo) + " "+ Convert.ToDateTime(quotaFirst.PricingEndDate).AddDays(2).Day + "th," +
                                                   Convert.ToDateTime(quotaFirst.PricingEndDate).AddDays(2).Year;
                            crp.Quantity = Convert.ToDouble(quotaFirst.Quantity);
                            crp.ContractTerm = quotaFirst.ShipTerm;
                            crp.Premium = quotaFirst.Premium == null ? "0" : string.Format("{0:#,##0.0000}", quotaFirst.Premium.Value);
                            crp.ImplementedDate = quotaFirst.ImplementedDate == null ? "" : Convert.ToDateTime(quotaFirst.ImplementedDate).ToString("MMMM", cultureInfo) + ", " + Convert.ToDateTime(quotaFirst.ImplementedDate).Year;
                        }
                        double totalAmount = 0;
                        
                        foreach (Quota q in contract.Quotas)
                        {
                            if (!q.IsDeleted)
                            {
                                var brandRelList = new List<QuotaBrandRel>();
                                if(q.QuotaBrandRels.Count > 0)
                                {
                                    brandRelList = q.QuotaBrandRels.Where(c => c.IsDeleted == false).ToList();
                                }
                                if (brandRelList.Count > 0 && q.PricingType == (int)PricingType.Fixed)
                                {
                                    foreach (QuotaBrandRel brandRel in brandRelList)
                                    {
                                        var line = new QuotaList
                                        {
                                            BrandName = brandRel.Brand.Name,
                                            SpecificationName = brandRel.Specification == null ? "" : brandRel.Specification.Name,
                                            Quantity = Convert.ToDouble(brandRel.Quantity.Value),
                                            CommodityTypeName = q.CommodityType.Name,
                                            Price = string.Format("{0:#,##0.00}", brandRel.Price.Value),
                                            Unit = q.Commodity.SHFEUnit,
                                            WarehouseName = brandRel.Warehouse == null ? "" : brandRel.Warehouse.Name
                                        };
                                        double qty = Convert.ToDouble(brandRel.Quantity.Value);
                                        double price = Convert.ToDouble(brandRel.Price.Value);
                                        line.Amount = string.Format("{0:#,##0.00}", Convert.ToDouble(qty * price));
                                        line.AmountForCY = "￥" +" "+ string.Format("{0:#,##0.00}", Convert.ToDouble(qty * price));
                                        totalAmount += Convert.ToDouble(qty * price);
                                        LineList.Add(line);
                                    }
                                }
                                else
                                {
                                    var quota = new QuotaList
                                                    {
                                                        BrandName = q.Brand == null ? "" : q.Brand.Name,
                                                        CommodityTypeName = q.CommodityType.Name,
                                                        SpecificationName = q.Specification == null ? "" : q.Specification.Name
                                                    };

                                    if (contract.TradeType == (int)TradeType.LongDomesticTrade ||
                                        contract.TradeType == (int)TradeType.ShortDomesticTrade) //内贸合同
                                    {
                                        quota.Unit = q.Commodity.SHFEUnit;
                                    }
                                    else
                                    {
                                        quota.Unit = q.Commodity.LMEUnit;
                                    }
                                    double qty = Convert.ToDouble(q.Quantity);
                                    double price;
                                    using (
                                        var pricingService =
                                            SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                                    {
                                        price = (double)pricingService.GetAvgPricing(q.Id);
                                    }
                                    if (q.PricingType != (int)PricingType.Fixed)
                                    {
                                        price = Convert.ToDouble(q.TempPrice ?? 0);
                                    }
                                    quota.Amount = string.Format("{0:#,##0.00}", Convert.ToDouble(qty * price));
                                    quota.AmountForCY = "￥ " + " " + string.Format("{0:#,##0.00}", Convert.ToDouble(qty * price));
                                    quota.WarehouseName = q.Warehouse == null ? "" : q.Warehouse.Name;
                                    quota.Quantity = qty;
                                    quota.Price = string.Format("{0:#,##0.00}", price);
                                    totalAmount += Convert.ToDouble(qty * price);

                                    LineList.Add(quota);
                                }
                            }
                        }
                        crp.SumAmount = string.Format("{0:#,##0.00}", totalAmount);
                        crp.TotalAmountForCY = "￥ " + " " + string.Format("{0:#,##0.00}", totalAmount);
                        crp.AmountConvert = NumberChange.GetNumberChange(totalAmount.ToString(CultureInfo.InvariantCulture));
                    }
                    HeaderList.Add(crp);
                }
            }
        }

        #endregion
    }


    public class ContractReportProperty
    {
        public string SupplierName { get; set; }
        public string ContractNo { get; set; }
        public string NeedName { get; set; }
        public string SignDate { get; set; }
        public string SupplierAgent { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string NeedAgent { get; set; }
        public string NeedPhone { get; set; }
        public string NeedFax { get; set; }
        public string Desc { get; set; }
        public string BPartnerEnglishName { get; set; }
        public string CommodityTypeEnglishName { get; set; }
        public string BrandName { get; set; }
        public double Quantity { get; set; }
        public string Premium { get; set; }
        public string PricingEndDate { get; set; }
        public string InternalEnglishName { get; set; }
        public string AmountConvert { get; set; }
        public string PromptDate { get; set; }
        public string SumAmount { get; set; }
        public string SignEnglishDate { get; set; }
        public string ContractTerm { get; set; }
        public string SupplierEnglishName { get; set; }
        public string NeedEnglishName { get; set; }
        public string ImplementedDate { get; set; }
        public string BPartnerEnglishAddress { get; set; }
        public string CustomerType { get; set; }
        public string QtyUnit { get; set; }
        public string QuotaYear { get; set; }//取合同第一个批次上提货日期的年份
        public string QuotaMonth { get; set; }//                         月份
        public string QuotaMonth1 { get; set; }
        public string QuotaDay { get; set; }
        public string QuotaWarehouseName { get; set; }//取合同第一个批次上的仓库
        public string SupplierAddress { get; set; }//提供方地址
        public string SupplierPostCode { get; set; }//   邮编
        public string SupplierBank { get; set; }//开户行
        public string SupplierAccount { get; set; }//账号
        public string NeedAddress { get; set; }//需方地址
        public string NeedPostCode { get; set; }
        public string NeedBank { get; set; }
        public string NeedAccount { get; set; }
        //public string SupplierFullName { get; set; }//供方全称
        //public string NeedFullName { get; set; }//需方全称
        public string TotalAmountForCY { get; set; }
        public string QtyLimit { get; set; }
        public string BankName { get; set; }//银行名称
        public string BankAccountNo { get; set; }//银行账号
        public int isVisible { get; set; }
    }

    public class QuotaList
    {
        public string CommodityTypeName { get; set; }
        public string BrandName { get; set; }
        public string SpecificationName { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string WarehouseName { get; set; }
        public string AmountForCY { get; set; }
    }
}