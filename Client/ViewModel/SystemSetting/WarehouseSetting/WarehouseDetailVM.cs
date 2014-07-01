using System;
using System.Text.RegularExpressions;
using Client.Base.BaseClientVM;
using Client.View.SystemSetting.WarehouseSetting;
using Client.WarehouseServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using System.Collections.Generic;
using System.Linq;
using Client.CurrencyServiceReference;

namespace Client.ViewModel.SystemSetting.WarehouseSetting
{
    public class WarehouseDetailVM : BaseVM
    {
        #region Member

        private string _address;
        private string _contactPerson;
        private string _description;
        private string _fax;
        private string _fullName;
        private string _name;
        private string _phone;
        private string _postCode;
        private int _CurrencyId;
        private List<Currency> _CurrencyList;

        private List<StorageFeeRule> _AddStorageFeeRules;
        private List<StorageFeeRule> _UpdateStorageFeeRules;
        private List<StorageFeeRule> _AllStorageFeeRules;
        private List<StorageFeeRule> _DeleteStorageFeeRules;
        #endregion

        #region Property
        public List<StorageFeeRule> DeleteStorageFeeRules
        {
            get { return _DeleteStorageFeeRules; }
            set { 
                if(_DeleteStorageFeeRules !=  value)
                {
                    _DeleteStorageFeeRules = value;
                    Notify("DeleteStorageFeeRules");
                }
            }
        }

        public List<Currency> CurrencyList
        {
            get { return _CurrencyList; }
            set { 
                if(_CurrencyList != value)
                {
                    _CurrencyList = value;
                    Notify("CurrencyList");
                }
            }
        }

        public int CurrencyId
        {
            get { return _CurrencyId; }
            set { 
                if(_CurrencyId !=  value)
                {
                    _CurrencyId = value;
                    Notify("CurrencyId");
                }
            }
        }

        public List<StorageFeeRule> AllStorageFeeRules
        {
            get { return _AllStorageFeeRules; }
            set { 
                if(_AllStorageFeeRules != value)
                {
                    _AllStorageFeeRules = value;
                    Notify("AllStorageFeeRules");
                }
            }
        }

        public List<StorageFeeRule> UpdateStorageFeeRules
        {
            get { return _UpdateStorageFeeRules; }
            set { 
                if(_UpdateStorageFeeRules != value)
                {
                    _UpdateStorageFeeRules = value;
                    Notify("UpdateStorageFeeRules");
                }
            }
        }

        public List<StorageFeeRule> AddStorageFeeRules
        {
            get { return _AddStorageFeeRules; }
            set { 
                if(_AddStorageFeeRules != value)
                {
                    _AddStorageFeeRules = value;
                    Notify("AddStorageFeeRules");
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

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    Notify("FullName");
                }
            }
        }

        public string PostCode
        {
            get { return _postCode; }
            set
            {
                if (_postCode != value)
                {
                    _postCode = value;
                    Notify("PostCode");
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

        public string ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                if (_contactPerson != value)
                {
                    _contactPerson = value;
                    Notify("ContactPerson");
                }
            }
        }

        public string Fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    _fax = value;
                    Notify("Fax");
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    Notify("Phone");
                }
            }
        }

        #endregion

        #region Constructor

        public WarehouseDetailVM()
        {
            ObjectId = 0;
            AddStorageFeeRules = new List<StorageFeeRule>();
            UpdateStorageFeeRules = new List<StorageFeeRule>();
            AllStorageFeeRules = new List<StorageFeeRule>();
            LoadCurrency();
            Initialize();
        }

        public WarehouseDetailVM(int bankId)
        {
            ObjectId = bankId;
            AddStorageFeeRules = new List<StorageFeeRule>();
            UpdateStorageFeeRules = new List<StorageFeeRule>();
            AllStorageFeeRules = new List<StorageFeeRule>();
            DeleteStorageFeeRules = new List<StorageFeeRule>();
            LoadCurrency();
            Initialize();
        }

        #endregion

        #region Method
        public void LoadCurrency()
        {
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                CurrencyList = currencyService.GetAll();
                CurrencyList.Insert(0, new Currency { Id = 0, Name = "" });
            }
        }

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (
                    var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                {
                    const string str = "it.Id = @p1 ";
                    var parameters = new List<object> { ObjectId };
                    List<Warehouse> warehouseList = warehouseService.Select(str, parameters, new List<string> { "StorageFeeRules", "StorageFeeRules.Commodity" }).ToList();

                    if (warehouseList != null && warehouseList.Count > 0)
                    {
                        Warehouse warehouse = warehouseList[0];
                        Name = warehouse.Name;
                        FullName = warehouse.FullName;
                        PostCode = warehouse.PostCode;
                        Address = warehouse.Address;
                        Description = warehouse.Description;
                        ContactPerson = warehouse.ContactPerson;
                        Fax = warehouse.Fax;
                        Phone = warehouse.Phone;
                        CurrencyId = warehouse.CurrencyId ?? 0;
                        AllStorageFeeRules = warehouse.StorageFeeRules.Where(c => c.IsDeleted == false).ToList();
                    }
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResWarehouseSetting.ShortNameRequired);
            }

            if (!string.IsNullOrEmpty(Phone) && !Regex.IsMatch(Phone, @"^(\d{3,4}-)?\d{6,8}$") &&
                !Regex.IsMatch(Phone, @"^[1]+[3,5]+\d{9}"))
            {
                throw new Exception(ResWarehouseSetting.TelInputWrong);
            }

            if (!string.IsNullOrEmpty(PostCode) && !Regex.IsMatch(PostCode, @"^\d{6}$"))
            {
                throw new Exception(Properties.Resources.PostCodeInputWrong);
            }

            if (!string.IsNullOrEmpty(Fax) && !Regex.IsMatch(Fax, @"^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$"))
            {
                throw new Exception(ResWarehouseSetting.FaxInputError);
            }

            if(CurrencyId == 0)
            {
                throw new Exception("币种不能为空");
            }
            return true;
        }


        protected override void Create()
        {
            var wh = new Warehouse
                         {
                             Name = Name,
                             FullName = FullName,
                             PostCode = PostCode,
                             Address = Address,
                             Description = Description,
                             ContactPerson = ContactPerson,
                             Fax = Fax,
                             Phone = Phone,
                             CurrencyId = CurrencyId
                         };

            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                warehouseService.AddNewWarehouse(wh,AddStorageFeeRules,CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var warehouseService = SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
            {
                Warehouse wh = warehouseService.GetById(ObjectId);
                if (wh != null)
                {
                    wh.Name = Name;
                    wh.FullName = FullName;
                    wh.PostCode = PostCode;
                    wh.Address = Address;
                    wh.Description = Description;
                    wh.ContactPerson = ContactPerson;
                    wh.Fax = Fax;
                    wh.Phone = Phone;
                    wh.CurrencyId = CurrencyId;
                }

                warehouseService.UpdateExistedWarehouse(wh, AddStorageFeeRules,UpdateStorageFeeRules,DeleteStorageFeeRules,CurrentUser.Id);
            }
        }

        public void DeleteStorageFeeRule(int ID)
        { 
            if(AllStorageFeeRules.Count > 0)
            {
                List<StorageFeeRule> storageFeeRules = AllStorageFeeRules.Where(c => c.Id == ID).ToList();
                if(storageFeeRules.Count > 0)
                {
                    StorageFeeRule rule = storageFeeRules[0];
                    AllStorageFeeRules.Remove(rule);
                    if (rule.Id > 0)
                    {
                        DeleteStorageFeeRules.Add(rule);
                    }
                    else
                    {
                        AddStorageFeeRules.Remove(rule);
                    }
                }
            }
        }

        #endregion
    }
}