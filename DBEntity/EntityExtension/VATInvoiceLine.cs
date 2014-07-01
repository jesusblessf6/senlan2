using System.Runtime.Serialization;

namespace DBEntity
{
    partial class VATInvoiceLine
    {
        private decimal? _unOpenedQuantity;

        [DataMember]
        public decimal? UnOpenedQuantity
        {
            get { 
                if(Quota != null)
                {
                    _unOpenedQuantity = Quota.VerifiedQuantity - Quota.VATInvoicedQuantity;
                }
                return _unOpenedQuantity;
            }

            set { _unOpenedQuantity = value; }
        }
    }
}
