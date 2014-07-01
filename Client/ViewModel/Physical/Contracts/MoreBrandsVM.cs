using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Utility.ServiceManagement;
using Client.BrandServiceReference;
using DBEntity;
using Client.QuotaServiceReference;

namespace Client.ViewModel.Physical.Contracts
{
    public class MoreBrandsVM : BaseVM
    {
        #region Member
        private List<QuotaBrandRel> _quotaBrandRels;

        #endregion

        #region Property

        public List<QuotaBrandRel> QuotaBrandRels
        {
            get { return _quotaBrandRels; }
            set
            {
                _quotaBrandRels = value;
                Notify("QuotaBrandRels");
            }
        }
        #endregion

        #region Constructor

        public MoreBrandsVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Constructor

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                {
                    Quota quota = quotaService.SelectById(new List<string>() {"QuotaBrandRels","QuotaBrandRels.Brand",
                        "QuotaBrandRels.Specification","QuotaBrandRels.Warehouse" }, ObjectId);
                    QuotaBrandRels = quota.QuotaBrandRels.Where(o => o.IsDeleted == false).ToList();
                }
            }
        }

        #endregion
    }
}
