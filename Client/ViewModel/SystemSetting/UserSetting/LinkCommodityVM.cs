using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using Client.UserServiceReference;
using Client.View.SystemSetting.UserSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.UserSetting
{
    public class LinkCommodityVM : BaseVM
    {
        #region Member

        private List<Commodity> _allocated;
        private List<Commodity> _notAllocated;

        #endregion

        #region Constructor

        public LinkCommodityVM(int userId)
        {
            ObjectId = userId;
            Initialize();
        }

        #endregion

        #region Property

        public List<Commodity> NotAllocated
        {
            get { return _notAllocated; }
            set
            {
                _notAllocated = value;
                Notify("NotAllocated");
            }
        }

        public List<Commodity> Allocated
        {
            get { return _allocated; }
            set
            {
                _allocated = value;
                Notify("Allocated");
            }
        }

        #endregion

        #region Method

        protected void Initialize()
        {
            if (ObjectId > 0)
            {
                using (
                    var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
                {
                    List<Commodity> comms = commodityService.GetCommoditiesByUser(ObjectId);
                    List<Commodity> allComms = commodityService.GetAll();
                    IEnumerable<int> commids = comms.Select(o => o.Id);
                    List<Commodity> notAllocateds = allComms.Where(o => !(commids.Contains(o.Id))).ToList();

                    NotAllocated = notAllocateds;
                    Allocated = comms;
                }
            }
        }

        protected override void Update()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                userService.UserCommodityLinkChange(_allocated, ObjectId);
            }
        }

        public override bool Validate()
        {
            return true;
        }

        public void Link(Commodity c)
        {
            if (Allocated.Contains(c))
            {
                throw new Exception(ResUserSetting.CommodityDuplicated);
            }

            if (!NotAllocated.Contains(c))
            {
                throw new Exception(ResUserSetting.CommodityNotFound);
            }

            Allocated.Add(c);
            NotAllocated.Remove(c);
        }

        public void UnLink(Commodity c)
        {
            if (!Allocated.Contains(c))
            {
                throw new Exception(ResUserSetting.CommodityNotFound);
            }

            if (NotAllocated.Contains(c))
            {
                throw new Exception(ResUserSetting.CommodityDuplicated);
            }

            NotAllocated.Add(c);
            Allocated.Remove(c);
        }

        #endregion
    }
}