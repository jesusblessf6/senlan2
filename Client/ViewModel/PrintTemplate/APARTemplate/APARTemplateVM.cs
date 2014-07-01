using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.ViewModel.Reports;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Utility.ServiceManagement;

namespace Client.ViewModel.PrintTemplate.APARTemplate
{
    public class APARTemplateVM : BaseVM
    {
        #region Property
        private List<ARAPHeader> _HeaderList;
        public List<ARAPHeader> HeaderList
        {
            get { return _HeaderList; }
            set
            {
                if (_HeaderList != value)
                {
                    _HeaderList = value;
                    Notify("HeaderList");
                }
            }
        }
        #endregion

        public APARTemplateVM(ARAPClassForPrint print)
        {
            GetValue(print);
        }

        public void GetValue(ARAPClassForPrint print)
        {
            if (print != null)
            {
                HeaderList = new List<ARAPHeader>();
                ARAPHeader header = new ARAPHeader();
                using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
                {
                    if (print.CustomerId.HasValue)
                    {
                        BusinessPartner businessPartner = bpService.GetById(print.CustomerId.Value);
                        header.CustomerFullName = businessPartner.Name;
                    }
                    if (print.InternalCustomerId.HasValue)
                    {
                        BusinessPartner internalCustomer = bpService.SelectById(new List<string> { "BankAccounts", "BankAccounts.Bank" }, print.InternalCustomerId.Value);
                        header.InternalCustomerFullName = internalCustomer.Name;
                        header.InternalCustomerFax = internalCustomer.Fax;
                        if (internalCustomer.BankAccounts != null && internalCustomer.BankAccounts.Count > 0)
                        {
                            BankAccount defaultAccount = internalCustomer.BankAccounts.Where(c => c.IsDefault ?? false).FirstOrDefault();
                            if (defaultAccount != null)
                            {
                                header.BankAccount = defaultAccount.AccountCode;
                                if (defaultAccount.Bank != null)
                                {
                                    header.BankName = defaultAccount.Bank.Name;
                                }
                            }
                        }
                        header.InternalCustomerPhoneNo = internalCustomer.ContactPhone;
                    }
                }
                if (print.EndDate.HasValue)
                {
                    header.SearchEndDate = print.EndDate.Value.ToLongDateString();
                }
                else
                {
                    header.SearchEndDate = DateTime.Now.ToLongDateString();
                }
                if (print.AmountRemain < 0)
                {
                    header.OnlyAmountStr = "本公司欠贵公司";
                }
                else
                {
                    header.OnlyAmountStr = "贵公司欠本公司";
                }
                header.OnlyAmount = string.Format("{0:#,##0.00}", Math.Abs(print.AmountRemain.Value));
                header.NowDate = DateTime.Now.ToString("yyy-M-dd", DateTimeFormatInfo.InvariantInfo);
                HeaderList.Add(header);
            }
        }
    }

    public class ARAPHeader
    {
        public string CustomerFullName { get; set; }//客户全称
        public string SearchEndDate { get; set; }//查询结束日期
        public string OnlyAmountStr { get; set; }
        public string OnlyAmount { get; set; }
        public string InternalCustomerFax { get; set; }
        public string InternalCustomerFullName { get; set; }
        public string InternalCustomerPhoneNo { get; set; }
        public string NowDate { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
    }
}