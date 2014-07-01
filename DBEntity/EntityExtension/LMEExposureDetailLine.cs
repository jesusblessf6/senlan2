using System;
using System.Runtime.Serialization;

namespace DBEntity
{
    [DataContract]
    public class LMEExposureDetailLine
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string BrokerName { get; set; }

        [DataMember]
        public DateTime? PromptDate { get; set; }

        [DataMember]
        public DateTime? TradeDate { get; set; }

        [DataMember]
        public decimal? LotNumber { get; set; }

        [DataMember]
        public int? Direction { get; set; }

        [DataMember]
        public decimal? Price { get; set; }

        [DataMember]
        public string InternalCustomerName { get; set; }
    }
}
