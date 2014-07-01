using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommissionServiceReference;
using Client.View.SystemSetting.CommissionSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommissionSetting
{
    public class DefaultCommissionDetailVM : BaseVM
    {
        #region Member

        private List<CommissionLine> _addCommissionLineList;
        private List<CommissionLine> _allCommissionLineList;
        private int _commissionTypeValue;
        private string _customerTypeName;
        private List<CommissionLine> _deleteCommissionLineList;
        private List<BusinessPartner> _internalCustomerList;

        private bool _isDefault;
        private int _selectInternalCustomerID;
        private string _titleName;
        private List<CommissionLine> _updateCommissionLineList;

        #endregion

        #region Property

        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    Notify("IsDefault");
                }
            }
        }

        public string CustomerTypeName
        {
            get { return _customerTypeName; }
            set
            {
                if (_customerTypeName != value)
                {
                    _customerTypeName = value;
                    Notify("CustomerTypeName");
                }
            }
        }

        public string TitleName
        {
            get { return _titleName; }
            set
            {
                if (_titleName != value)
                {
                    _titleName = value;
                    Notify("TitleName");
                }
            }
        }

        public int CommissionTypeValue
        {
            get { return _commissionTypeValue; }
            set
            {
                if (_commissionTypeValue != value)
                {
                    _commissionTypeValue = value;
                    Notify("CommissionTypeValue");
                }
            }
        }

        public List<CommissionLine> DeleteCommissionLineList
        {
            get { return _deleteCommissionLineList; }
            set
            {
                if (_deleteCommissionLineList != value)
                {
                    _deleteCommissionLineList = value;
                    Notify("DeleteCommissionLineList");
                }
            }
        }

        public List<CommissionLine> AllCommissionLineList
        {
            get { return _allCommissionLineList; }
            set
            {
                if (_allCommissionLineList != value)
                {
                    _allCommissionLineList = value;
                    Notify("AllCommissionLineList");
                }
            }
        }

        public List<CommissionLine> UpdateCommissionLineList
        {
            get { return _updateCommissionLineList; }
            set
            {
                if (_updateCommissionLineList != value)
                {
                    _updateCommissionLineList = value;
                    Notify("UpdateCommissionLineList");
                }
            }
        }

        public List<CommissionLine> AddCommissionLineList
        {
            get { return _addCommissionLineList; }
            set
            {
                if (_addCommissionLineList != value)
                {
                    _addCommissionLineList = value;
                    Notify("AddCommissionLineList");
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

        #endregion

        #region Constructor

        public DefaultCommissionDetailVM(int commissionType, bool isDefault)
        {
            ObjectId = 0;
            IsDefault = isDefault;
            CommissionTypeValue = commissionType;
            AddCommissionLineList = new List<CommissionLine>();
            UpdateCommissionLineList = new List<CommissionLine>();
            AllCommissionLineList = new List<CommissionLine>();
            if (CommissionTypeValue == (int) CommissionType.AgentCommission)
            {
                TitleName = ResCommissionSetting.DefaultBrokerCommissionSetting;
                CustomerTypeName = Properties.Resources.Broker;
            }
            else if (CommissionTypeValue == (int) CommissionType.ClientCommission)
            {
                TitleName = ResCommissionSetting.DefaultCustomerCommissionSetting;
                CustomerTypeName = Properties.Resources.Customer;
            }
            LoadInternalCustomerList();
        }

        public DefaultCommissionDetailVM(int id, int commissionType, bool isDefault)
        {
            ObjectId = id;
            IsDefault = isDefault;
            CommissionTypeValue = commissionType;
            AddCommissionLineList = new List<CommissionLine>();
            UpdateCommissionLineList = new List<CommissionLine>();
            DeleteCommissionLineList = new List<CommissionLine>();
            AllCommissionLineList = new List<CommissionLine>();
            if (CommissionTypeValue == (int) CommissionType.AgentCommission)
            {
                TitleName = ResCommissionSetting.DefaultBrokerCommissionSetting;
                CustomerTypeName = Properties.Resources.Broker;
            }
            else if (CommissionTypeValue == (int) CommissionType.ClientCommission)
            {
                TitleName = ResCommissionSetting.DefaultCustomerCommissionSetting;
                CustomerTypeName = Properties.Resources.Customer;
            }
            LoadInternalCustomerList();
            LoadCommission();
        }

        #endregion

        #region Method

        public void LoadInternalCustomerList()
        {
            using (
                var bpartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = bpartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (InternalCustomerList.Count > 0)
                {
                    if (SelectInternalCustomerID <= 0)
                    {
                        SelectInternalCustomerID = InternalCustomerList[0].Id;
                    }
                }
            }
        }

        public void LoadCommission()
        {
            if (ObjectId > 0)
            {
                using (
                    var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                    )
                {
                    const string str = "it.Id = @p1";
                    var parameters = new List<object> {ObjectId};
                    List<Commission> commissionList = commissionService.Select(str, parameters,
                                                                               new List<string>
                                                                                   {
                                                                                       "CommissionLines",
                                                                                       "BusinessPartner",
                                                                                       "CommissionLines.Commodity"
                                                                                   });
                    if (commissionList.Count > 0)
                    {
                        Commission commission = commissionList[0];
                        AllCommissionLineList = commission.CommissionLines.Where(c => c.IsDeleted == false).ToList();
                        SelectInternalCustomerID = commission.InternalBPId;
                    }
                }
            }
        }

        protected override void Create()
        {
            var commission = new Commission
                                 {
                                     CommissionType = CommissionTypeValue,
                                     InternalBPId = SelectInternalCustomerID,
                                     IsDefaultRule = true
                                 };
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                commissionService.CreateDocument(CurrentUser.Id, commission, AddCommissionLineList);
            }
        }

        protected override void Update()
        {
            using (var commissionService = SvcClientManager.GetSvcClient<CommissionServiceClient>(SvcType.CommissionSvc)
                )
            {
                Commission commission = commissionService.GetById(ObjectId);
                if (commission != null)
                {
                    commission.CommissionType = CommissionTypeValue;
                    commission.InternalBPId = SelectInternalCustomerID;
                    commission.IsDefaultRule = true;
                }
                commissionService.UpdateDocument(CurrentUser.Id, commission, AddCommissionLineList,
                                                 UpdateCommissionLineList, DeleteCommissionLineList);
            }
        }

        public void DelCommissionLine(int commissionLineID)
        {
            if (AllCommissionLineList.Count > 0)
            {
                List<CommissionLine> lines = AllCommissionLineList.Where(c => c.Id == commissionLineID).ToList();
                CommissionLine line = lines[0];
                AllCommissionLineList.Remove(line);
                if (line.Id > 0)
                {
                    DeleteCommissionLineList.Add(line);
                }
                else
                {
                    AddCommissionLineList.Remove(line);
                }
            }
        }

        public bool ValidateAdd()
        {
            if (SelectInternalCustomerID == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            return true;
        }

        public override bool Validate()
        {
            if (SelectInternalCustomerID == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            if (AllCommissionLineList.Count <= 0)
            {
                throw new Exception(ResCommissionSetting.CommissionLineRequired);
            }
            return true;
        }

        #endregion
    }
}