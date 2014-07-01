using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.ForeignDeliveryPoolServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.QueryManagement;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.ViewModel.Physical.ForeignDeliveryPools
{
    public sealed class ForeignDeliveryListVM : ListBaseVM
    {
        #region Constructor

        public ForeignDeliveryListVM(List<QueryElement> cons) : base(cons)
        {
            InitService();
            RegisterIncludes();
        }

        #endregion

        #region Method

        public override void InitService()
        {
            SvcClient = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc);
        }

        public override void RegisterIncludes()
        {
            Includes = new List<string>
                           {
                               "ForeignDeliveryPoolLines",
                               "Commodity",
                               "Warehouse",
                               "ForeignDeliveryPoolLines.Brand",
                               "ForeignDeliveryPoolLines.CommodityType",
                               "ForeignDeliveryPoolLines.Specification",
                               "ForeignDeliveryPoolLines.OriginCountry"
                           };
        }

        public EnumItem GetDeliveryType(int id)
        {
            var line = (ForeignDeliveryPool)Entities.Cast<IEntity>().Single(o => o.Id == id);
            return EnumHelper.GetEnumItem<DeliveryType>(line.DeliveryType);
        }

        public override void FilterEntities()
        {
            foreach (var entity in Entities)
            {
                FilterDeleted(((ForeignDeliveryPool)entity).ForeignDeliveryPoolLines);
            }
        }

        #endregion
    }
}
