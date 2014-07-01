using System;
using System.Collections.Generic;
using System.Globalization;
using Client.Base.BaseClientVM;
using Client.PaymentRequestServiceReference;
using Client.SystemParameterServiceReference;
using Client.UserServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.PrintTemplate.PaymentAppTemplate
{
    public class PaymentAppTemplateVM : BaseVM
    {
        #region Property

        private List<PaymentHeader> _headerList;
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

        public List<PaymentHeader> HeaderList
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

        #region Contructor

        public PaymentAppTemplateVM(int paymentID)
        {
            HeaderList = new List<PaymentHeader>();
            GetPath(paymentID);
            GetValue(paymentID);
        }

        #endregion

        #region Method

        public void GetPath(int paymentID)
        {
            using (
                var systemParameterService =
                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
            {
                SystemParameter systemParameter = systemParameterService.GetAll()[0];

                if (systemParameter != null)
                {
                    string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.PaymentRequestTemplate);
                    PathName = @"PrintTemplate\" + name + "\\" + systemParameter.PaymentRequestTemplatePath;
                }
            }
        }

        public void GetValue(int paymentID)
        {
            using (
                var paymentrequestService =
                    SvcClientManager.GetSvcClient<PaymentRequestServiceClient>(SvcType.PaymentRequestSvc))
            {
                PaymentRequest paymentRequest = paymentrequestService.SelectById(new List<string> { "Quota", "Quota.Contract" }, paymentID);
                string str = string.Empty;
                List<object> parameters = null;
                if (!paymentRequest.QuotaId.HasValue)
                {
                    str = "it.Id = @p1 ";
                    parameters = new List<object> { paymentID };
                }
                else
                {
                    if (paymentRequest.Quota.Contract.TradeType == (int)TradeType.LongDomesticTrade)
                    {
                        int contractId = paymentRequest.Quota.ContractId;
                        str = "it.Quota.ContractId = @p1 and (it.ApproveStatus == " + (int)DBEntity.EnumEntity.ApproveStatus.NoApproveNeeded
                            + " or it.ApproveStatus == " + (int)DBEntity.EnumEntity.ApproveStatus.Approved + ")";
                        parameters = new List<object> { contractId };
                    }
                    else
                    {
                        str = "it.Id = @p1 ";
                        parameters = new List<object> { paymentID };
                    }
                }
                List<PaymentRequest> paymentList = paymentrequestService.Select(str, parameters,
                                                                                new List<string>
                                                                                    {
                                                                                        "Quota",
                                                                                        "PayBusinessPartner",
                                                                                        "PayBankAccount",
                                                                                        "PayBankAccount.Bank",
                                                                                        "ReceiveBankAccount.Bank",
                                                                                        "ReceiveBusinessPartner",
                                                                                        "Currency",
                                                                                        "PaymentUsage",
                                                                                        "PaymentMean",
                                                                                        "PayBankAccount.Bank",
                                                                                        "PayBankAccount",
                                                                                        "Quota.Contract",
                                                                                        "PayBusinessPartner",
                                                                                        "Quota.Contract.InternalCustomer",
                                                                                        "Quota.QuotaBrandRels",
                                                                                        "Quota.CommodityType",
                                                                                        "Quota.Pricings",
                                                                                        "Quota.Commodity",
                                                                                        "Quota.Brand",
                                                                                        "Bank"
                                                                                    });
                if (paymentList.Count > 0)
                {
                    decimal paymentAmount = paymentList.Sum(o => o.RequestAmount ?? 0);
                    decimal requestQty = 0M;
                    foreach (var p in paymentList)
                    {
                        if (p.Quota != null)
                        {
                            requestQty += p.Quota.Quantity ?? 0;
                        }
                    }
                    PaymentRequest payment = paymentList.FirstOrDefault();
                    if (payment != null)
                    {
                        var header = new PaymentHeader
                                         {
                                             InternalEnglishName = payment.PayBusinessPartner.Name,
                                             InternalName = payment.PayBankAccount == null ? "" : payment.PayBankAccount.Bank.Name
                                             //InternalEnglishName =
                                             //    payment.Quota == null
                                             //        ? ""
                                             //        : payment.Quota.Contract.InternalCustomer.EnglishName,
                                             //InternalName = payment.Quota == null ? "" : payment.Quota.Contract.InternalCustomer.Name
                                         };
                        if (payment.CreatedBy.HasValue)
                        {
                            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
                            {
                                User user = userService.GetById(payment.CreatedBy.Value);
                                header.Applicant = user.Name;
                            }
                        }
                        header.SwiftCodeTitle = "Swift Code：";
                        if (header.InternalEnglishName == "全威（上海）有色金属有限公司")
                        {
                            header.SwiftCodeVisible = 0;
                            PathName = @"PrintTemplate\\付款申请单模板\\上海全威付款申请单.rdlc";
                        }
                        else
                        {
                            header.SwiftCodeVisible = 1;
                        }
                        header.ApplicantionDate = Convert.ToDateTime(payment.RequestDate).ToString("yyyy/MM/dd",
                                                                                                   DateTimeFormatInfo.
                                                                                                       InvariantInfo);
                        header.ApplicantionDateFormat = Convert.ToDateTime(payment.RequestDate).ToString("yyyy年MM月dd日",
                                                                                                   DateTimeFormatInfo.
                                                                                                       InvariantInfo);
                        header.PaymentBranch = payment.PayBankAccount == null ? "" : payment.PayBankAccount.Bank.Name;
                        header.PaymentBy = payment.PaymentMean.Name;
                        header.ContractNo = payment.Quota == null ? "" : payment.Quota.Contract.ContractNo;
                        header.Purpose = (payment.Quota == null ? "" : payment.Quota.CommodityType.Name) + " " + (payment.PaymentUsage == null ? "" : payment.PaymentUsage.Name) + (requestQty == 0 ? "" : "(" + RemoveZero(requestQty) + "吨)");
                        header.PaymentUsage = payment.PaymentUsage == null ? "" : payment.PaymentUsage.Name;
                        header.Currency = payment.Currency.Code + " " + string.Format("{0:#,##0.00}", paymentAmount);
                        header.OnlyCurrency = payment.Currency.Code;
                        header.Beneficiary = payment.ReceiveBusinessPartner.Name;
                        header.BankNo = payment.ReceiveBankAccount == null ? "" : payment.ReceiveBankAccount.Bank.Name;
                        header.SwiftCode = payment.ReceiveBankAccount == null ? "" : payment.ReceiveBankAccount.Bank.Code;
                        header.IntermediaryBankName = payment.Bank == null ? "" : payment.Bank.Name;
                        header.IntermediaryBankSwiftCode = payment.Bank == null ? "" : payment.Bank.Code;
                        header.AccountNo = payment.ReceiveBankAccount == null
                                               ? ""
                                               : payment.ReceiveBankAccount.AccountCode;

                        string amount = string.Format("{0:#,##0.00}", paymentAmount);
                        header.RequestAmount = amount + payment.Currency.Code;
                        header.UpAmount = NumberChange.GetCnString(paymentAmount.ToString()) + payment.Currency.Name;
                        header.RequestAmountForQW = payment.Currency.Code + amount;
                        header.UpAmountForQW = payment.Currency.Name + NumberChange.GetCnString(paymentAmount.ToString());
                        header.RequestNo = payment.PaymentRequestNo;
                        header.RequestBy = CurrentUser.Name;

                        if (payment.Quota != null)
                        {
                            if (payment.Quota.PricingType == (int)PricingType.Fixed)
                            {
                                Pricing firstOrDefault = payment.Quota.Pricings.FirstOrDefault();
                                if (firstOrDefault != null)
                                {
                                    payment.Quota.Price = firstOrDefault.FinalPrice ?? 0;
                                    header.QuotaPrice = payment.Quota.Price.ToString(RoundRules.STR_PRICE);
                                }
                            }
                            else if (payment.Quota.PricingType == (int)PricingType.Average)
                            {
                                //平均价点价
                                Pricing firstOrDefault = payment.Quota.Pricings.FirstOrDefault();
                                if (firstOrDefault != null)
                                {
                                    payment.Quota.Price = firstOrDefault.FinalPrice ?? 0;
                                    header.QuotaPrice = payment.Quota.Price.ToString(RoundRules.STR_PRICE);
                                }
                            }
                            //else if (quota.PricingType == (int)PricingType.Manual)
                            //{
                            //    quota.StrPrice = Resources.Detail;
                            //}

                            if (payment.Quota.TotalRequestAmount != null && payment.Quota.TotalRequestAmount != 0)
                            {
                                header.Percent = (paymentAmount / payment.Quota.TotalRequestAmount.Value) * 100;
                            }
                            if (payment.Quota.Brand != null)
                            {
                                header.BrandName = payment.Quota.Brand.Name;
                            }
                            header.QuotaQty = string.Format("{0:#,#00.0000}", payment.Quota.Quantity == null ? 0 : payment.Quota.Quantity.Value);

                            if (payment.Quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade || payment.Quota.Contract.TradeType == (int)TradeType.LongDomesticTrade)
                            {
                                header.IsVisible = 0;
                                foreach (var p in paymentList)
                                {
                                    if (p.Quota.QuotaBrandRels != null && p.Quota.QuotaBrandRels.Count > 0)
                                    {
                                        foreach (QuotaBrandRel brand in p.Quota.QuotaBrandRels)
                                        {
                                            header.Comment += (RemoveZero(brand.Price) + "*" + RemoveZero(brand.Quantity) + " ");
                                        }
                                    }
                                    else
                                    {
                                        if (p.Quota.FinalPrice != null)
                                        {
                                            header.Comment += (RemoveZero(p.Quota.FinalPrice) + "*" + RemoveZero(p.Quota.Quantity));
                                        }
                                    }
                                    header.Comment += "；";
                                }
                            }
                            else
                            {
                                header.IsVisible = 1;
                            }
                        }

                        header.Comment += "\n" + payment.Comment;
                        header.DESC = payment.Comment;
                        string userName = string.Empty;
                        using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
                        {
                            if (payment.CreatedBy.HasValue)
                            {
                                userName = userService.GetById(payment.CreatedBy.Value).Name;
                            }
                        }
                        header.CreatedBy = userName;
                        HeaderList.Add(header);
                    }
                }
            }
        }

        private string RemoveZero(decimal? dValue)
        {
            string sResult = dValue.ToString();
            if (sResult.IndexOf(".", StringComparison.Ordinal) < 0)
                return sResult;
            int iIndex = sResult.Length - 1;
            for (int i = sResult.Length - 1; i >= 0; i--)
            {
                if (sResult.Substring(i, 1) != "0")
                {
                    iIndex = i;
                    break;
                }
            }
            sResult = sResult.Substring(0, iIndex + 1);
            if (sResult.EndsWith("."))
                sResult = sResult.Substring(0, sResult.Length - 1);
            return sResult;
        }


        #endregion
    }

    public class PaymentHeader
    {
        public string InternalEnglishName { get; set; }
        public string Applicant { get; set; }
        public string ApplicantionDate { get; set; }//申请日期 yyyy/mm/dd
        public string PaymentBy { get; set; }
        public string ContractNo { get; set; }
        public string PaymentBranch { get; set; }
        public string Purpose { get; set; }
        public string Currency { get; set; }//金额+币种
        public string OnlyCurrency { get; set; }//币种
        public string Beneficiary { get; set; }//收款人
        public string BankNo { get; set; }//开户银行名称
        public string SwiftCode { get; set; }
        public string AccountNo { get; set; }
        public string Comment { get; set; }
        public string ApplicantionDateFormat { get; set; }//格式化日期 年 月 日
        public string PaymentUsage { get; set; }//付款用途
        public string BrandName { get; set; }//品牌
        public string QuotaQty { get; set; }//批次数量
        public string QuotaPrice { get; set; }//批次单价
        public string RequestAmount { get; set; }//申请金额
        public string UpAmount { get; set; }//申请金额大写
        public string CreatedBy { get; set; }//请款人 - 创建人
        public int Num { get; set; }//第几次付款
        public decimal? Percent { get; set; }//占总金额的百分比
        public string DESC { get; set; }
        public string InternalName { get; set; }
        public string IntermediaryBankName { get; set; }//中转行名称
        public string IntermediaryBankSwiftCode { get; set; }//中转行代码
        public int IsVisible { get; set; }//董事长显示隐藏
        public string SwiftCodeTitle { get; set; }
        public int SwiftCodeVisible { get; set; }
        public string UpAmountForQW { get; set; }//全威付款申请模板金额大写
        public string RequestAmountForQW { get; set; }//全威付款申请模板金额小写
        public string RequestNo { get; set; }//编号
        public string RequestBy { get; set; }//申请人
    }
}