using System;
using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Runtime.Serialization;

namespace Services.Futures.SHFE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISHFEPosition" in both code and config file together.
    [ServiceContract]
    public interface ISHFEPositionService : IService<SHFEPosition>
    {
        [OperationContract]
        void ImportSHFEPosition(SHFECapitalDetail capitalDetail, List<SHFEPosition> shfePositionList,
                                List<SHFEHoldingPosition> shfeHoldingPositions,List<SHFEFundFlow> shfeFundFlows, int userId);

        [OperationContract]
        SHFEPosition GetSHFEPositionById(int id);

        [OperationContract]
        decimal GetQtyByParameters(int positionDirection, int commodityID, int internalCustomerID, DateTime? date,
                                   string type, int userId);

        [OperationContract]
        List<SHFECapitalDetail> GetSHFECapitalDetailList(int? agentId, int internalBPId, DateTime? startDate,
                                                         DateTime endDate);

        [OperationContract]
        List<ForwardPositionReportClass> GetData(int? internalID, int? brokerID, int commodityID, int userId);
    }

    [DataContract]
    public class ForwardPositionReportClass
    {
        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public DateTime? TradeDate { get; set; }

        [DataMember]
        public decimal? Qty { get; set; }

        [DataMember]
        public decimal? Price { get; set; }

        [DataMember]
        public int? PositionDerection { get; set; }

        [DataMember]
        public string BrokerName { get; set; }

        [DataMember]
        public string InternalName { get; set; }
    }
}