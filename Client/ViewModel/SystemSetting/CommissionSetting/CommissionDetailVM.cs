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
    public class CommissionDetailVM : BaseVM
    {
        #region Member

        private List<CommissionLine> _addCommissionLineList;
        private List<CommissionLine> _allCommissionLineList;
        private int _commissionTypeValue;
        private int _customerId;
        private string _customerName;
        private string _customerTypeName;
        private List<CommissionLine> _deleteCommissionLineList;
        private List<BusinessPartner> _internalCustomerList;
        private bool _isDefault;
        private int _selectInternalCustomerId;
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

        public int CustomerID
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    _customerId = value;
                    Notify("CustomerID");
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

        public int SelectInternalCustomerID
        {
            get { return _selectInternalCustomerId; }
            set
            {
                if (_selectInternalCustomerId != value)
                {
                    _selectInternalCustomerId = value;
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

        public CommissionDetailVM(int commissionType, bool isDefault)
        {
            ObjectId = 0;
            IsDefault = isDefault;
            CommissionTypeValue = commissionType;
            AddCommissionLineList = new List<CommissionLine>();
            UpdateCommissionLineList = new List<CommissionLine>();
            AllCommissionLineList = new List<CommissionLine>();
            if (CommissionTypeValue == (int) CommissionType.AgentCommission)
            {
                TitleName = "经纪行佣金规则";
                CustomerTypeName = Properties.Resources.Broker;
            }
            else if (CommissionTypeValue == (int) CommissionType.ClientCommission)
            {
                TitleName = "客户佣金规则";
                CustomerTypeName = Properties.Resources.Customer;
            }
            LoadInternalCustomerList();
        }

        public CommissionDetailVM(int commissionType, int commissionID, bool isDefault)
        {
            ObjectId = commissionID;
            IsDefault = isDefault;
            AddCommissionLineList = new List<CommissionLine>();
            UpdateCommissionLineList = new List<CommissionLine>();
            AllCommissionLineList = new List<CommissionLine>();
            DeleteCommissionLineList = new List<CommissionLine>();
            CommissionTypeValue = commissionType;
            if (CommissionTypeValue == (int) CommissionType.AgentCommission)
            {
                TitleName = "经济行佣金规则";
                CustomerTypeName = Properties.Resources.Broker;
            }
            else if (CommissionTypeValue == (int) CommissionType.ClientCommission)
            {
                TitleName = "客户佣金规则";
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
                        CustomerID = commission.BPId == null ? 0 : (int) commission.BPId;
                        CommissionTypeValue = commission.CommissionType;
                        AllCommissionLineList = commission.CommissionLines.Where(c => c.IsDeleted == false).ToList();
                        CustomerName = commission.BusinessPartner == null ? "" : commission.BusinessPartner.ShortName;
                        SelectInternalCustomerID = commission.InternalBPId;
                    }
                }
            }
        }

        protected override void Create()
        {
            var commission = new Commission
                                 {
                                     BPId = CustomerID,
                                     CommissionType = CommissionTypeValue,
                                     InternalBPId = SelectInternalCustomerID,
                                     IsDefaultRule = false
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
                    commission.BPId = CustomerID;
                    commission.CommissionType = CommissionTypeValue;
                    commission.InternalBPId = SelectInternalCustomerID;
                    commission.IsDefaultRule = false;
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
            if (CustomerID == 0)
            {
                if (CommissionTypeValue == (int)CommissionType.AgentCommission)
                {
                    throw new Exception(Properties.Resources.BrokerRequired);
                }
                
                if (CommissionTypeValue == (int)CommissionType.ClientCommission)
                {
                    throw new Exception(ResCommissionSetting.CustomerRequired);
                }
            }

            if (SelectInternalCustomerID == 0)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }

            return true;
        }

        public override bool Validate()
        {
            if (CustomerID == 0)
            {
                if (CommissionTypeValue == (int)CommissionType.AgentCommission)
                {
                    throw new Exception(Properties.Resources.BrokerRequired);
                }
                
                if(CommissionTypeValue == (int)CommissionType.ClientCommission)
                {
                    throw new Exception(ResCommissionSetting.CustomerRequired);
                }
            }

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