using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.ContractServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using System.Windows.Forms;
using DBEntity.EnableProperty;

namespace Client.ViewModel.Physical.Contracts
{
    public class TransactionRelationVM : BaseVM
    {
        #region Member
        private RelQuota rel = new RelQuota();
        private List<BusinessPartner> innerCustomers;
        private int selectedInternalCustomerId;
        private decimal? price;
        private bool saveStatus = false;
        private DateTime? _signDate = DateTime.Now.Date;
        private DateTime? _vATInvoiceDate = DateTime.Today;
        #endregion

        #region Property
        public DateTime? SignDate
        {
            get { return _signDate; }
            set
            {
                if (_signDate != value)
                {
                    _signDate = value;
                    Notify("SignDate");
                }
            }
        }
        public RelQuota Rel
        {
            get { return rel; }
            set
            {
                if (rel != value)
                {
                    rel = value;
                    Notify("Rel");
                }
            }
        }
        public List<BusinessPartner> InnerCustomers
        {
            get { return innerCustomers; }
            set
            {
                if (innerCustomers != value)
                {
                    innerCustomers = value;
                    Notify("InnerCustomers");
                }
            }
        }

        public int SelectedInternalCustomerId
        {
            get { return selectedInternalCustomerId; }
            set
            {
                if (selectedInternalCustomerId != value)
                {
                    selectedInternalCustomerId = value;
                    Notify("SelectedInternalCustomerId");
                }
            }
        }

        public decimal? Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify("Price");
                }
            }
        }

        public bool SaveStatus
        {
            get { return saveStatus; }
            set
            {
                if (saveStatus != value)
                {
                    saveStatus = value;
                    Notify("SaveStatus");
                }
            }
        }

        public DateTime? VATInvoiceDate
        {
            get { return _vATInvoiceDate; }
            set
            {
                if (_vATInvoiceDate != value)
                {
                    _vATInvoiceDate = value;
                    Notify("VATInvoiceDate");
                }
            }
        }
        #endregion

        #region Constructor
        public TransactionRelationVM()
        {
            LoadInnerCustomer();
            LoadDocumentEnableProperty(true);
        }

        public TransactionRelationVM(RelQuota relQuota)
        {
            LoadInnerCustomer();
            Price = relQuota.Price;
            SelectedInternalCustomerId = relQuota.BusinessParnterId;
            SignDate = relQuota.SignDate;
            VATInvoiceDate = relQuota.VATInvoiceDate;
            LoadDocumentEnableProperty(false);
        }

        #endregion

        #region Method
        public void Cancel()
        {
            Rel = null;
        }

        public override void Save()
        {
            Validate();
            Rel.Price = Price;
            Rel.SignDate = SignDate.Value;
            Rel.BusinessParnterId = SelectedInternalCustomerId;
            rel.VATInvoiceDate = VATInvoiceDate;
            Rel.BusinessParnterName = InnerCustomers.Where(o => o.Id == SelectedInternalCustomerId).FirstOrDefault().ShortName;
            SaveStatus = true;
        }

        private void LoadInnerCustomer()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                innerCustomers = busService.GetInternalCustomersByUser(CurrentUser.Id);
                innerCustomers.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        public override bool Validate()
        {
            if (SelectedInternalCustomerId == 0)
            {
                throw new Exception("内部客户不能为空！");
            }

            if (!Price.HasValue)
            {
                throw new Exception("价格不能为空！");
            }
            if (!SignDate.HasValue)
            {
                throw new Exception("价签署日期不能为空！");
            }
            return true;
        }
        #endregion

#region 编辑属性
        private bool _isPriceEnable;
        private bool _isDateEnable;
        private bool _isRelBPEnable;

        public bool IsPriceEnable
        {
            get { return _isPriceEnable; }
            set
            {
                if (_isPriceEnable != value)
                {
                    _isPriceEnable = value;
                    Notify("IsPriceEnable");
                }
            }
        }

        public bool IsDateEnable
        {
            get { return _isDateEnable; }
            set
            {
                if (_isDateEnable != value)
                {
                    _isDateEnable = value;
                    Notify("IsDateEnable");
                }
            }
        }

        public bool IsRelBPEnable
        {
            get { return _isRelBPEnable; }
            set
            {
                if (_isRelBPEnable != value)
                {
                    _isRelBPEnable = value;
                    Notify("IsRelBPEnable");
                }
            }
        }

        private void LoadDocumentEnableProperty(bool isAdd)
        {
            if (isAdd)
            {
                IsPriceEnable = true;
                IsDateEnable = true;
                IsRelBPEnable = true;
            }
            else
            {
                using (var contractService = SvcClientManager.GetSvcClient<ContractServiceClient>(SvcType.ContractSvc))
                {
                    RelTransactionEnableProperty rtep = contractService.SetRelTransactionEnableProperty();
                    IsPriceEnable = rtep.IsPriceEnable;
                    IsDateEnable = rtep.IsDateEnable;
                    IsRelBPEnable = rtep.IsRelBPEnable;
                }
            }
        }
#endregion

    }
}
