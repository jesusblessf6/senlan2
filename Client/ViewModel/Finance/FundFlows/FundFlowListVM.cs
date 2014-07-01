using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.FundFlowServiceReference;
using Client.View.Finance.FundFlows;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Finance.FundFlows
{
    public sealed class FundFlowListVM : ListBaseVM
    {
        #region Constructor

        public FundFlowListVM(List<QueryElement> cons) : base(cons)
        {
            InitService();
            RegisterIncludes();
            SortingCol = new SortCol {ByDescending = true, ColName = "TradeDate"};
        }

        #endregion

        #region Method

        public object GetDetailPage(int id)
        {
            var ff = Entities.Cast<FundFlow>().SingleOrDefault(o => o.Id == id);
            if (ff != null)
            {
                if (ff.RorP == (int)FundFlowType.Receive)
                {
                    return new ReceiptDetail(id, PageMode.EditMode);
                }

                if (ff.RorP == (int)FundFlowType.Pay)
                {
                    return new PaymentDetail(id, PageMode.EditMode);
                }
            }

            return null;
        }

        public override void InitService()
        {
            SvcClient = SvcClientManager.GetSvcClient<FundFlowServiceClient>(SvcType.FundFlowSvc);
        }

        public override void RegisterIncludes()
        {
            Includes = new List<string> { "Quota", "BusinessPartner", "InternalCustomer", "Currency", "FinancialAccount","PaymentMean" };
        }

        #endregion
    }
}