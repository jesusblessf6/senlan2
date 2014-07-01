using System.Runtime.Serialization;

namespace DBEntity
{
    partial class PaymentRequest : IApprovable
    {
        public string CustomerStrField1 { get; set; }
        public string CustomerStrField2 { get; set; }
        public decimal PaidAmount { get; set; }

        [DataMember]
        public decimal AmountForApproval { get; set; }

        [DataMember]
        public int CurrencyIdForApproval { get; set; }

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
        private bool _isSelected;

        private bool? _printable;
        public bool Printable
        {
            get
            {
                if (_printable == null)
                {
                    _printable = (ApproveStatus == (int)EnumEntity.ApproveStatus.NoApproveNeeded ||
                        ApproveStatus == (int)EnumEntity.ApproveStatus.Approved);
                }
                return _printable.Value;
            }
            set 
            {
                if (_printable != value)
                {
                    _printable = value;
                    OnPropertyChanged("Printable");
                }
            }
        }
    }
}
