using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.PricingServiceReference;
using Client.SystemParameterServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.PrintTemplate.PricingConfirmationTemplate
{
    public class PricingConfirmationVM : BaseVM
    {
        #region Property

        private List<PricingHeader> _headerList;
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

        public List<PricingHeader> HeaderList
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

        public PricingConfirmationVM(int pricingID)
        {
            HeaderList = new List<PricingHeader>();
            GetPath(pricingID);
            GetValue(pricingID);
        }

        #endregion

        #region Method

        public void GetPath(int pricingID)
        {
            using (
                var systemParameterService =
                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
            {
                SystemParameter systemParameter = systemParameterService.GetAll()[0];

                if (systemParameter != null)
                {
                    string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.PricingConfirmationTemplate);
                    PathName = @"PrintTemplate\" + name + "\\" + systemParameter.PricingConfirmationTemplatePath;
                }
            }
        }

        public void GetValue(int pricingID)
        {
            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {pricingID};
                List<Pricing> pricingList = pricingService.Select(str, parameters,
                                                                  new List<string>
                                                                      {
                                                                          "Currency",
                                                                          "Quota.Commodity",
                                                                          "Quota.CommodityType",
                                                                          "Quota.Contract.BusinessPartner",
                                                                          "Quota.Contract.InternalCustomer"
                                                                      });
                if (pricingList.Count > 0)
                {
                    Pricing pricing = pricingList[0];
                    var header = new PricingHeader
                                     {
                                         InternalEnglishName = pricing.Quota.Contract.InternalCustomer.EnglishName,
                                         InternalEnglishAddress = pricing.Quota.Contract.InternalCustomer.EnglishAddress,
                                         BPartnerEnglishName = pricing.Quota.Contract.BusinessPartner.EnglishName,
                                         BPartnerEnglishAddress = pricing.Quota.Contract.BusinessPartner.EnglishAddress,
                                         CommodityTypeEnglishName = pricing.Quota.CommodityType.EnglishName,
                                         PricingDate = Convert.ToDateTime(pricing.PricingDate).ToString("yyyy-MM-dd",
                                                                                                        DateTimeFormatInfo
                                                                                                            .
                                                                                                            InvariantInfo)
                                     };
                    string unit = pricing.Quota.Commodity.LMEUnit;
                    header.PricingQty = string.Format("{0:#,##0.00}", pricing.PricingQuantity) + unit;
                    header.ContractNo = pricing.Quota.Contract.ExContractNo;//原始合同号
                    header.OurRef = pricing.Quota.Contract.ContractNo;//系统生成的合同号
                    if (pricing.PricingBasis.HasValue)
                    {
                        List<EnumItem> pList = EnumHelper.GetEnumList<PricingBasis>();
                        List<EnumItem> itemList = pList;
                        EnumItem item = itemList.Where(c => c.Id == pricing.PricingBasis.Value).ToList()[0];
                        header.PricingBase = item.Name;
                    }
                    if (pricing.Quota.Contract.ContractType == (int) ContractType.Purchase)
                    {
                        header.PricingBy = pricing.Quota.PricingSide == (int) PricingSide.OurSide ? "buyer" : "seller";
                    }
                    else
                    {
                        header.PricingBy = pricing.Quota.PricingSide == (int) PricingSide.OurSide ? "seller" : "buyer";
                    }

                    header.Currency = pricing.Currency.Code;
                    header.BasePrice = string.Format("{0:#,##0.00}", pricing.BasicPrice);
                    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                    header.DatePrice = pricing.PriceDate == null
                                           ? ""
                                           : "On " +
                                             Convert.ToDateTime(pricing.PriceDate).ToString("MMMM", cultureInfo).
                                                 Substring(0, 3) + " " + Convert.ToDateTime(pricing.PriceDate).Day + "," +
                                             Convert.ToDateTime(pricing.PriceDate).Year;
                    header.Premium = string.Format("{0:#,##0.00}", pricing.Premium);
                    header.Spread = string.Format("{0:#,##0.00}",
                                                  pricing.AdjustQPFee == null ? 0 : pricing.AdjustQPFee.Value);
                    header.FinalPrice = pricing.FinalPrice == null ? null : string.Format("{0:#,##0.00}", pricing.FinalPrice.Value);
                    header.Quantity = pricing.PricingQuantity == null ? null : string.Format("{0:#,##0.0000}", pricing.PricingQuantity.Value);
                    header.Unit = unit;
                    header.DeferFee = pricing.DeferFee == null ? "" : string.Format("{0:#,##0.00}", pricing.DeferFee.Value);
                    if(pricing.Quota.Contract.ContractType == (int)ContractType.Purchase)
                    {
                        header.Buyer = pricing.Quota.Contract.InternalCustomer.EnglishName;
                        header.Seller = pricing.Quota.Contract.BusinessPartner.EnglishName;
                    }
                    else if(pricing.Quota.Contract.ContractType == (int)ContractType.Sales)
                    {
                        header.Seller = pricing.Quota.Contract.InternalCustomer.EnglishName;
                        header.Buyer = pricing.Quota.Contract.BusinessPartner.EnglishName;
                    }
                    HeaderList.Add(header);
                }
            }
        }

        #endregion
    }

    public class PricingHeader
    {
        public string InternalEnglishName { get; set; }
        public string InternalEnglishAddress { get; set; }
        public string BPartnerEnglishName { get; set; }
        public string BPartnerEnglishAddress { get; set; }
        public string CommodityTypeEnglishName { get; set; }
        public string PricingDate { get; set; }//点价日期
        public string PricingQty { get; set; }
        public string ContractNo { get; set; }//原始合同号
        public string OurRef { get; set; }//系统生成的合同号
        public string PricingBase { get; set; }
        public string PricingBy { get; set; }
        public string Currency { get; set; }
        public string BasePrice { get; set; } //基准价
        public string DatePrice { get; set; } //价格日期
        public string Premium { get; set; }
        public string Spread { get; set; } //调期费用
        public string DeferFee { get; set; }//延期费用
        public string FinalPrice { get; set; } //最终价格
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string Buyer { get; set; }//买方
        public string Seller { get; set; }//卖方
    }
}