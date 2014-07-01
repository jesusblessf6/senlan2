using System;
using Client.Base.BaseClientVM;
using Client.FinancialAccountServiceReference;
using Client.View.SystemSetting.FinancialAccountSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.FinancialAccountSetting
{
    public class FinancialAccountDetailVM : BaseVM
    {
        #region Member

        private int _accountlevel;
        private string _description;
        private string _name;
        private int? _parentId;
        private string _parentname;
        private bool _IsIncludedInAPAR = false;

        #endregion

        #region Property
        public bool IsIncludedInAPAR
        {
            get { return _IsIncludedInAPAR; }
            set {
                if (_IsIncludedInAPAR != value)
                {
                    _IsIncludedInAPAR = value;
                    Notify("IsIncludedInAPAR");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public string ParentName
        {
            get { return _parentname; }
            set
            {
                if (_parentname != value)
                {
                    _parentname = value;
                    Notify("ParentName");
                }
            }
        }


        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != value)
                {
                    _parentId = value;
                    Notify("ParentId");
                }
            }
        }

        public int AccountLevel
        {
            get { return _accountlevel; }
            set
            {
                if (_accountlevel != value)
                {
                    _accountlevel = value;
                    Notify("AccountLevel");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        #endregion

        #region Constructor

        public FinancialAccountDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public FinancialAccountDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (
                    var financialaccountService =
                        SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
                {
                    FinancialAccount financialaccount = financialaccountService.GetById(ObjectId);

                    if (financialaccount != null)
                    {
                        Name = financialaccount.Name;
                        ParentId = financialaccount.ParentId;
                        ParentName = financialaccount.ParentId == null
                                         ? ""
                                         : financialaccountService.GetById(Convert.ToInt32(financialaccount.ParentId)).
                                               Name;
                        IsIncludedInAPAR = financialaccount.IsIncludedInAPAR;
                        Description = financialaccount.Description;
                    }
                }
            }
        }

        protected override void Create()
        {
            var financialaccount = new FinancialAccount
                                       {
                                           Name = Name,
                                           ParentId = ParentId,
                                           Description = Description,
                                           IsIncludedInAPAR = IsIncludedInAPAR
                                       };

            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                financialaccountService.AddNewFinancialAccount(financialaccount, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var financialaccountService =
                    SvcClientManager.GetSvcClient<FinancialAccountServiceClient>(SvcType.FinancialAccountSvc))
            {
                FinancialAccount financialaccount = financialaccountService.GetById(ObjectId);
                if (financialaccount != null)
                {
                    financialaccount.Name = Name;

                    financialaccount.ParentId = ParentId;
                    financialaccount.AccountLevel = AccountLevel;
                    financialaccount.Description = Description;
                    financialaccount.IsIncludedInAPAR = IsIncludedInAPAR;
                    financialaccountService.UpdateFinancialAccount(financialaccount, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResFinancialAccountSetting.AccountNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResFinancialAccountSetting.AccountNameRequired);
            }

            return true;
        }

        #endregion
    }
}