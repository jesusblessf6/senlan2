using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommissionSetting
{
    public class CommissionHomeVM : BaseVM
    {
        #region Member

        private Dictionary<string, int> _commissionTypes;
        private List<Commodity> _commodityList;
        private int _customerID;
        private string _customerName;
        private List<BusinessPartner> _internalCustomerList;
        private CommissionSearchVM _searchVM;
        private int _selectCommodityID;
        private int _selectInternalCustomerID;
        private int _selectValue;

        #endregion

        #region Property

        public CommissionSearchVM SearchVM
        {
            get { return _searchVM; }
            set
            {
                if (_searchVM != value)
                {
                    _searchVM = value;
                    Notify("SearchVM");
                }
            }
        }

        public int SelectValue
        {
            get { return _selectValue; }
            set
            {
                if (_selectValue != value)
                {
                    _selectValue = value;
                    Notify("SelectValue");
                }
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    Notify("CustomerName");
                }
            }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                    Notify("CustomerID");
                }
            }
        }

        public int SelectInternalCustomerID
        {
            get { return _selectInternalCustomerID; }
            set
            {
                if (_selectInternalCustomerID != value)
                {
                    _selectInternalCustomerID = value;
                    Notify("SelectInternalCustomerID");
                }
            }
        }

        public List<BusinessPartner> InternalCustomerList
        {
            get { return _internalCustomerList; }
            set
            {
                if (_internalCustomerList != value)
                {
                    _internalCustomerList = value;
                    Notify("InternalCustomerList");
                }
            }
        }

        public int SelectCommodityID
        {
            get { return _selectCommodityID; }
            set
            {
                if (_selectCommodityID != value)
                {
                    _selectCommodityID = value;
                    Notify("SelectCommodityID");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                if (_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        public Dictionary<string, int> CommissionTypes
        {
            get { return _commissionTypes; }
            set
            {
                if (_commissionTypes != value)
                {
                    _commissionTypes = value;
                    Notify("CommissionTypes");
                }
            }
        }

        #endregion

        #region Constructor

        public CommissionHomeVM()
        {
            LoadCommissionType();
            LoadCommodity();
            LoadInternalCustomer();
        }

        #endregion

        #region Method

        private void LoadCommissionType()
        {
            CommissionTypes = new Dictionary<string, int>();
            CommissionTypes = EnumHelper.GetEnumDic<CommissionType>(CommissionTypes);
            SelectValue = (int) CommissionType.AgentCommission;
        }

        private void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetAll();
                if (CommodityList.Count > 0)
                {
                    CommodityList.Add(new Commodity {Name = "", Id = 0});
                    SelectCommodityID = CommodityList[0].Id;
                }
            }
        }

        private void LoadInternalCustomer()
        {
            using (
                var bpartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = bpartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (InternalCustomerList.Count > 0)
                {
                    InternalCustomerList.Add(new BusinessPartner {Name = "", Id = 0});
                    SelectInternalCustomerID = InternalCustomerList[0].Id;
                }
            }
        }

        public void LoadSearch()
        {
            SearchVM = new CommissionSearchVM
                           {
                               BPartnerID = CustomerID,
                               InternalCustomerID = SelectInternalCustomerID,
                               CommodityID = SelectCommodityID,
                               CommissionTypeValue = SelectValue
                           };
            SearchVM.Init();
        }

        #endregion
    }
}