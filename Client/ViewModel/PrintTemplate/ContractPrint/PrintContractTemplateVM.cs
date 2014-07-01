using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base;
using Utility.ServiceManagement;
using Client.ContractServiceReference;
using DBEntity;
using DBEntity.EnumEntity;

namespace Client.ViewModel.PrintTemplate.ContractPrint
{
    public class PrintContractTemplateVM : BaseVM
    {
        #region Member
        public List<ContractReportProperty> _HeaderList;
        public List<QuotaList> _LineList;
        #endregion

        #region Property
        public List<ContractReportProperty> HeaderList
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

        public List<QuotaList> LineList
        {
            get { return _LineList; }
            set
            {
                if (_LineList != value)
                {
                    _LineList = value;
                    Notify("LineList");
                }
            }
        }
        #endregion

        #region Contructor
        public PrintContractTemplateVM(int contractID)
        {
            HeaderList = new List<ContractReportProperty>();
            LineList = new List<QuotaList>();
            GetValue(contractID);
        }
        #endregion

        #region Method
        public void GetValue(int contractID)
        {
            using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
            {
                string sql = "it.Id = @p1";
                List<object> parameters = new List<object>();
                parameters.Add(contractID);

                List<Contract> contractList = contractService.Select(sql, parameters, new List<string> { "BusinessPartner", "InternalCustomer", "Quotas", "Quotas.CommodityType", "Quotas.Brand", "Quotas.Specification" });
                if (contractList.Count > 0)
                {
                    Contract contract = contractList[0];

                    ContractReportProperty crp = new ContractReportProperty();

                    if (contract.ContractType == (int)ContractType.Purchase)
                    {
                        crp.SupplierName = contract.BusinessPartner.Name;
                        crp.SupplierAgent = contract.BusinessPartner.ContactPerson;
                        crp.SupplierPhone = contract.BusinessPartner.ContactPhone;
                        crp.SupplierFax = contract.BusinessPartner.Fax;
                        crp.NeedAgent = contract.InternalCustomer.ContactPerson;
                        crp.NeedFax = contract.InternalCustomer.Fax;
                        crp.NeedName = contract.InternalCustomer.Name;
                        crp.NeedPhone = contract.InternalCustomer.ContactPhone;
                    }
                    else if (contract.ContractType == (int)ContractType.Sales)
                    {
                        crp.SupplierName = contract.InternalCustomer.Name;
                        crp.SupplierAgent = contract.InternalCustomer.ContactPerson;
                        crp.SupplierPhone = contract.InternalCustomer.ContactPhone;
                        crp.SupplierFax = contract.InternalCustomer.Fax;
                        crp.NeedAgent = contract.BusinessPartner.ContactPerson;
                        crp.NeedFax = contract.BusinessPartner.Fax;
                        crp.NeedName = contract.BusinessPartner.Name;
                        crp.NeedPhone = contract.BusinessPartner.ContactPhone;
                    }
                    crp.ContractNo = contract.ContractNo;
                    crp.SignDate = contract.SignDate;
                    HeaderList.Add(crp);

                    if(contract.Quotas.Count > 0)
                    {
                        foreach(Quota q in contract.Quotas)
                        {
                            if(!q.IsDeleted)
                            {
                                QuotaList quota = new QuotaList();

                                quota.BrandName = q.Brand == null ? "" : q.Brand.Name;
                                quota.CommodityTypeName = q.CommodityType.Name;
                                quota.SpecificationName = q.Specification == null ? "" : q.Specification.Name;
                                quota.Unit = "";
                                quota.Quantity = Convert.ToDouble(q.Quantity);
                                quota.Price = Convert.ToDouble(q.Price);
                                quota.Amount = Convert.ToDouble(q.AmountForApproval);
                                quota.AmountConvert = "";

                                LineList.Add(quota);
                            }
                        }
                    }


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
        public DateTime? SignDate { get; set; }
        public string SupplierAgent { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string NeedAgent { get; set; }
        public string NeedPhone { get; set; }
        public string NeedFax { get; set; }
    }

    public class QuotaList
    {
        public string CommodityTypeName { get; set; }
        public string BrandName { get; set; }
        public string SpecificationName { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public string AmountConvert { get; set; }
    }
}
