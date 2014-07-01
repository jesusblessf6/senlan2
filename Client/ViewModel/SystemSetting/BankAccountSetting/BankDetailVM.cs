using System;
using Client.BankServiceReference;
using Client.Base.BaseClientVM;
using Client.View.SystemSetting.BankAccountSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.BankAccountSetting
{
    public class BankDetailVM : BaseVM
    {
        #region Member

        private string _address;
        private string _code;
        private string _description;
        private string _name;

        #endregion

        #region Property

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

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    Notify("Code");
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    Notify("Address");
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

        public BankDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public BankDetailVM(int bankId)
        {
            ObjectId = bankId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
                {
                    Bank bank = bankService.GetById(ObjectId);

                    if (bank != null)
                    {
                        Name = bank.Name;
                        Code = bank.Code;
                        Address = bank.Address;
                        Description = bank.Description;
                    }
                }
            }
        }

        protected override void Create()
        {
            var bank = new Bank
                           {
                               Name = Name,
                               Code = Code,
                               Description = Description,
                               Address = Address
                           };

            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                bankService.AddNewBank(bank, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var bankService = SvcClientManager.GetSvcClient<BankServiceClient>(SvcType.BankSvc))
            {
                Bank bank = bankService.GetById(ObjectId);
                if (bank != null)
                {
                    bank.Name = Name;
                    bank.Code = Code;
                    bank.Address = Address;
                    bank.Description = Description;

                    bankService.UpdateExistedBank(bank, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResBankAccountSetting.BankNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResBankAccountSetting.BankNameRequired);
            }

            return true;
        }

        #endregion
    }
}