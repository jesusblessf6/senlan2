using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.UserServiceReference;
using Client.View.SystemSetting.UserSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.UserSetting
{
    public class LinkICVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _allocated;
        private List<BusinessPartner> _notAllocated;

        #endregion

        #region Constructor

        public LinkICVM(int userId)
        {
            ObjectId = userId;
            Initialize();
        }

        #endregion

        #region Property

        public List<BusinessPartner> NotAllocated
        {
            get { return _notAllocated; }
            set
            {
                _notAllocated = value;
                Notify("NotAllocated");
            }
        }

        public List<BusinessPartner> Allocated
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
                    var businessPartnerService =
                        SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
                {
                    List<BusinessPartner> ics = businessPartnerService.GetInternalCustomersByUser(ObjectId);
                    IEnumerable<int> icids = ics.Select(o => o.Id);
                    List<BusinessPartner> allics =
                        businessPartnerService.GetBusinessPartnersByType(BusinessPartnerType.InternalCustomer);
                    List<BusinessPartner> notAllocateds = allics.Where(o => !icids.Contains(o.Id)).ToList();

                    NotAllocated = notAllocateds;
                    Allocated = ics;
                }
            }
        }

        protected override void Update()
        {
            using (var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc))
            {
                userService.UserICLinkChange(_allocated, ObjectId);
            }
        }

        public override bool Validate()
        {
            return true;
        }

        public void Link(BusinessPartner c)
        {
            if (Allocated.Contains(c))
            {
                throw new Exception(ResUserSetting.ICDuplicated);
            }

            if (!NotAllocated.Contains(c))
            {
                throw new Exception(ResUserSetting.ICNotFound);
            }

            Allocated.Add(c);
            NotAllocated.Remove(c);
        }

        public void UnLink(BusinessPartner c)
        {
            if (!Allocated.Contains(c))
            {
                throw new Exception(ResUserSetting.ICNotFound);
            }

            if (NotAllocated.Contains(c))
            {
                throw new Exception(ResUserSetting.ICDuplicated);
            }

            NotAllocated.Add(c);
            Allocated.Remove(c);
        }

        #endregion
    }
}