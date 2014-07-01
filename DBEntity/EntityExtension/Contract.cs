using System.Runtime.Serialization;
namespace DBEntity
{
    partial class Contract
    {

        private string _AutoContractNo;
        [DataMember]
        public string AutoContractNo
        {
            get { return _AutoContractNo; }
            set { 
                if(_AutoContractNo !=  value)
                {
                    _AutoContractNo = value;
                    OnPropertyChanged("AutoContractNo");
                }
            }
        }

        public int ContractTypeValue
        {
            get
            {
                if (ContractType == (int)EnumEntity.ContractType.Purchase)
                {
                    return -1;
                }

                return 1;
            }
        }

        public bool Printable
        {
            get
            {
                return TradeType == (int) EnumEntity.TradeType.LongDomesticTrade ||
                       TradeType == (int) EnumEntity.TradeType.ShortDomesticTrade;
            }
        }
    }
}
