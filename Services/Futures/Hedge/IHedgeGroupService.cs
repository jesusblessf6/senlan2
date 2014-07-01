using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.Misc;

namespace Services.Futures.Hedge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHedgeGroupService" in both code and config file together.
    [ServiceContract]
    public interface IHedgeGroupService : IService<HedgeGroup>
    {
        [OperationContract]
        List<HedgeLineQuota> GetQuotasInHedgeGroup(int groupId, List<string> includes);

        [OperationContract]
        List<HedgeLineLMEPosition> GetLMEsInHedgeGroup(int groupId, List<string> includes);

        [OperationContract]
        List<HedgeLineSHFEPosition> GetSHFEsInHedgeGroup(int groupId, List<string> includes);

        [OperationContract]
        int CreateHedgeGroup(HedgeGroup hg, List<HedgeLineQuota> quotas, List<HedgeLineLMEPosition> lmes,
                             List<HedgeLineSHFEPosition> shfes, int userId);

        [OperationContract]
        void UpdateHedgeGroup(HedgeGroup hg, List<HedgeLineQuota> newQuotas,
                              List<HedgeLineQuota> deletedQuotas,
                              List<HedgeLineLMEPosition> updatedLmes, List<HedgeLineLMEPosition> newLmes,
                              List<HedgeLineLMEPosition> deletedLmes,
                              List<HedgeLineSHFEPosition> updatedShfes, List<HedgeLineSHFEPosition> newShfes,
                              List<HedgeLineSHFEPosition> deletedShfes, int userId);

        [OperationContract]
        void UpdateHedgeGroupHeader(HedgeGroup hg, int userId);

        [OperationContract]
        void UpdatehedgeGroupPL(HedgeGroup hg, int userId);

        [OperationContract]
        List<HedgeGroupFloatPNLLine> SelectHedgeGroupPNLLine(string predicate, List<object> parameters, int from, int to, SortCol sortCol,int userId);
    }
}
