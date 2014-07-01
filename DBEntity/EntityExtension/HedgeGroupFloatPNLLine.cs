using System;
using System.Runtime.Serialization;

namespace DBEntity
{
    [DataContract(IsReference = true)]
    public class HedgeGroupFloatPNLLine
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime? HedgeDate { get; set; }

        [DataMember]
        public int HedgeTypeId { get; set; }

        [DataMember]
        public int HedgeStatusId { get; set; }

        [DataMember]
        public decimal? PhysicalFixedPNL { get; set; }

        [DataMember]
        public decimal? PhysicalFloatPNL { get; set; }

        [DataMember]
        public decimal? LMEFixedPNL { get; set; }

        [DataMember]
        public decimal? LMEFloatPNL { get; set; }

        [DataMember]
        public decimal? SHFEFixedPNL { get; set; }

        [DataMember]
        public decimal? SHFEFloatPNL { get; set; }

        [DataMember]
        public decimal? TotalPNL { get; set; }

        [DataMember]
        public decimal? BreakEvenSpread { get; set; }
    }
}
