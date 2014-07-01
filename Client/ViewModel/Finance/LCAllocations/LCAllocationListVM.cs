using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.LCAllocationServiceReference;
using DBEntity;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Finance.LCAllocations
{
    public class LCAllocationListVM : BaseVM
    {
        #region Members & Properties

        private readonly string _queryStr;
        private readonly List<object> _params;
 
        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<LCAllocation> LCAllocations { get; set; }

        private decimal _qtySum;
        public decimal QtySum
        {
            get { return _qtySum; }
            set
            {
                if (_qtySum != value)
                {
                    _qtySum = value;
                    Notify("QtySum");
                }
            }
        }

        private decimal _cnyAmountSum;
        public decimal CNYAmountSum
        {
            get { return _cnyAmountSum; }
            set
            {
                if (_cnyAmountSum != value)
                {
                    _cnyAmountSum = value;
                    Notify("CNYAmountSum");
                }
            }
        }

        private decimal _usdAmountSum;
        public decimal USDAmountSum
        {
            get { return _usdAmountSum; }
            set
            {
                if (_usdAmountSum != value)
                {
                    _usdAmountSum = value;
                    Notify("USDAmountSum");
                }
            }
        }

        #endregion

        #region Constructor

        public LCAllocationListVM(List<QueryElement> clauses)
        {
            QueryManager.BuildQueryStrAndParams(clauses, out _queryStr, out _params);
            if (string.IsNullOrWhiteSpace(_queryStr))
            {
                _queryStr = "1=1";
            }
        }

        #endregion

        #region Method

        public void LoadCount()
        {
            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                Count = lcaService.GetCount(_queryStr, _params);
                QtySum = lcaService.GetQuantitySum(_queryStr + " and it.IsCanceled = false", _params);
                CNYAmountSum = lcaService.GetAmountSum(_queryStr + " and it.Currency.Code = \'CNY\' and it.IsCanceled = false", _params,
                                                       new List<string> {"Currency"});
                USDAmountSum = lcaService.GetAmountSum(_queryStr + " and it.Currency.Code = \'USD\' and it.IsCanceled = false", _params,
                                                       new List<string> { "Currency" });
            }
        }

        public void Load()
        {
            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                LCAllocations = lcaService.SelectByRange(_queryStr, _params, From, To, 
                    new List<string>
                        {
                            "BusinessPartner", "InternalCustomer", "Commodity", 
                            "Currency", "Responsor"
                        });
            }
        }

        public void RemoveById(int id)
        {
            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                lcaService.RemoveById(id, CurrentUser.Id);
            }
        }

        public void CancelById(int id)
        {
            using (var lcaService = SvcClientManager.GetSvcClient<LCAllocationServiceClient>(SvcType.LCAllocationSvc))
            {
                var lca = lcaService.GetById(id);
                lca.IsCanceled = true;
                lcaService.UpdateExisted(lca, CurrentUser.Id);
            }
        }

        #endregion
    }
}
