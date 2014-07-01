using System.Runtime.Serialization;

namespace DBEntity
{
    partial class VATInvoiceRequestLine : IApprovable
    {
        public string CustomerStrField1 { get; set; }
        public string CustomerStrField2 { get; set; }
        private decimal? _unOpenedQuantity;

        [DataMember]
        public decimal AmountForApproval { get; set; }

        [DataMember]
        public int CurrencyIdForApproval { get; set; }

        [DataMember]
        public decimal? UnOpenedQuantity {
            get
            {
                if (Quota != null)
                {
                    _unOpenedQuantity = Quota.VerifiedQuantity - Quota.VATInvoicedQuantity;
                }
                return _unOpenedQuantity;
            }

            set { _unOpenedQuantity = value; }
        }

        private bool _isSelected;
        [DataMember]
        public bool IsSelected 
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        private bool _invoiceSelectedEnable;

        [DataMember]
        public bool InvoiceSelectedEnable
        {
            get
            {
                if (UnOpenedQuantity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _invoiceSelectedEnable = value;
            }
        }
    }
}
