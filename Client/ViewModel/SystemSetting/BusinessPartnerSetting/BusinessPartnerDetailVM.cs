using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.View.SystemSetting.BusinessPartnerSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using System.ComponentModel;

namespace Client.ViewModel.SystemSetting.BusinessPartnerSetting
{
	public class BusinessPartnerDetailVM : BaseVM
	{
		#region Member

		private string _address;
		private TrackableCollection<BankAccount> _bankAccounts;
		private string _code;
		private string _englishName;
		private string _fax;
		private string _fullName;
		private string _person;
		private string _remark;
		private string _shortName;
		private string _telephone;
		private int _type;
		private bool _typeCustomer;
		private bool _typeFuturesCompany;
		private bool _typeInnerCustomer;
		private string _zipCode;
		private string _englishAddress;
		private string _taxNo;

		private int _bankForm;
		private int _bankTo;
		private int _bankTotalCount;

		private bool _isDefault;
		private string _isVisible;

		#endregion

		#region Property
		public string IsVisible
		{
			get { return _isVisible; }
			set { 
				if(_isVisible != value)
				{
					_isVisible = value;
					Notify("IsVisible");
				}
			}
		}

		public bool IsDefault
		{
			get { return _isDefault; }
			set { 
				if(_isDefault != value)
				{
					_isDefault = value;
					Notify("IsDefault");
				}
			}
		}

		public string ShortName
		{
			get { return _shortName; }
			set
			{
				if (_shortName != value)
				{
					_shortName = value;
					Notify("ShortName");
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

		public string Person
		{
			get { return _person; }
			set
			{
				if (_person != value)
				{
					_person = value;
					Notify("Person");
				}
			}
		}

		public string Telephone
		{
			get { return _telephone; }
			set
			{
				if (_telephone != value)
				{
					_telephone = value;
					Notify("Telephone");
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

		public string ZipCode
		{
			get { return _zipCode; }
			set
			{
				if (_zipCode != value)
				{
					_zipCode = value;
					Notify("ZipCode");
				}
			}
		}

		public string Remark
		{
			get { return _remark; }
			set
			{
				if (_remark != value)
				{
					_remark = value;
					Notify("Remark");
				}
			}
		}

		public bool TypeCustomer
		{
			get { return _typeCustomer; }
			set
			{
				if (_typeCustomer != value)
				{
					_typeCustomer = value;
					Notify("TypeCustomer");
				}
			}
		}

		public bool TypeFuturesCompany
		{
			get { return _typeFuturesCompany; }
			set
			{
				if (_typeFuturesCompany != value)
				{
					_typeFuturesCompany = value;
					Notify("TypeFuturesCompany");
				}
			}
		}

		public bool TypeInnerCustomer
		{
			get { return _typeInnerCustomer; }
			set
			{
				if (_typeInnerCustomer != value)
				{
					_typeInnerCustomer = value;
					Notify("TypeInnerCustomer");
				}
			}
		}

		public TrackableCollection<BankAccount> BankAccounts
		{
			get { return _bankAccounts; }
			set
			{
				if (_bankAccounts != value)
				{
					_bankAccounts = value;
					Notify("bankAccount");
				}
			}
		}

		public string EnglishName
		{
			get { return _englishName; }
			set
			{
				if (_englishName != value)
				{
					_englishName = value;
					Notify("EnglishName");
				}
			}
		}

		public string EnglishAddress
		{
			get { return _englishAddress; }
			set
			{
				if(_englishAddress != value)
				{
					_englishAddress = value;
					Notify("EnglishAddress");
				}
			}
		}


		public string TaxNo
		{
			get { return _taxNo; }
			set
			{
				if (_taxNo != value)
				{
					_taxNo = value;
					Notify("TaxNo");
				}
			}
		}

		public int BankForm
		{
			get { return _bankForm; }
			set
			{
				if (_bankForm != value)
				{
					_bankForm = value;
					Notify("BankForm");
				}
			}
		}

		public int BankTo
		{
			get { return _bankTo; }
			set
			{
				if (_bankTo != value)
				{
					_bankTo = value;
					Notify("BankTo");
				}
			}
		}

		public int BankTotalCount
		{
			get { return _bankTotalCount; }
			set
			{
				if (_bankTotalCount != value)
				{
					_bankTotalCount = value;
					Notify("BankTotalCount");
				}
			}
		}

		#endregion

		#region Constructor

		public BusinessPartnerDetailVM()
		{
			ObjectId = 0;
			SetCustomerType((int) BusinessPartnerType.Customer);
			PropertyChanged += TypePropertyChanged;
		}

		public BusinessPartnerDetailVM(int id)
		{
			ObjectId = id;
			LoadBankCount(id);
			GetPartnerById(id);
			PropertyChanged += TypePropertyChanged;
		}

		#endregion

		#region Method
		protected void TypePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "TypeInnerCustomer")
			{
				if (TypeInnerCustomer)
				{
					IsVisible = "Visible";
				}
				else
				{
					IsVisible = "Collapsed";
				}
			}
		}

		public void LoadBankCount(int id)
		{
			using (
			   var bankAccountService =
				   SvcClientManager.GetSvcClient<BankAccountServiceReference.BankAccountServiceClient>(SvcType.BankAccountSvc))
			{
				const string strQuery = "it.BusinessPartnerId = @p1 ";
				var parameters = new List<object> { id };
				BankTotalCount = bankAccountService.Select(strQuery, parameters,null).Count;
			}
		}

		/// <summary>
		/// 设置业务伙伴类型
		/// </summary>
		/// <param name="type"></param>
		private void SetCustomerType(int type)
		{
			switch (type)
			{
				case (int) BusinessPartnerType.Customer:
					TypeCustomer = true;
					TypeFuturesCompany = false;
					TypeInnerCustomer = false;
					IsVisible = "Collapsed";//控制默认复选框的显示隐藏
					break;
				case (int) BusinessPartnerType.Broker:
					TypeCustomer = false;
					TypeFuturesCompany = true;
					TypeInnerCustomer = false;
					IsVisible = "Collapsed";
					break;
				case (int) BusinessPartnerType.InternalCustomer:
					TypeCustomer = false;
					TypeFuturesCompany = false;
					TypeInnerCustomer = true;
					IsVisible = "Visible";
					break;
			}
		}

		/// <summary>
		/// 获取业务伙伴类型
		/// </summary>
		/// <returns></returns>
		private int GetCustomerType()
		{
			int type = 1;
			if (TypeCustomer)
			{
				type = (int) BusinessPartnerType.Customer;
			}
			else if (TypeFuturesCompany)
			{
				type = (int) BusinessPartnerType.Broker;
			}
			else if (TypeInnerCustomer)
			{
				type = (int) BusinessPartnerType.InternalCustomer;
			}
			return type;
		}

		/// <summary>
		/// 获取银行
		/// </summary>
		/// <returns></returns>
		public void SetBankAccounts(int id)
		{
			using (
				var bankAccountService =
					SvcClientManager.GetSvcClient<BankAccountServiceReference.BankAccountServiceClient>(SvcType.BankAccountSvc))
			{
				const string strQuery = "it.BusinessPartnerId = @p1 ";
				var parameters = new List<object> { id };
				List<BankAccount> baList = bankAccountService.SelectByRange(strQuery, parameters,
																	BankForm, BankTo, new List<string> { "Bank", "Currency" });
				if (BankAccounts == null) 
				{
					BankAccounts = new TrackableCollection<BankAccount>();
				}
				
				BankAccounts.Clear();
				foreach (var item in baList) 
				{
					BankAccounts.Add(item);
				}
			}
		}

		/// <summary>
		/// 根据Id获取业务伙伴信息
		/// </summary>
		/// <param name="id"></param>
		public void GetPartnerById(int id)
		{
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				const string strQuery = "it.id = @p1 ";
				var parameters = new List<object> {id};
				List<BusinessPartner> partners = partnerService.Select(strQuery, parameters,
																	   new List<string>
																		   {
																			   "BankAccounts",
																			   "BankAccounts.Bank",
																			   "BankAccounts.Currency"
																		   });
				if (partners.Count == 0)
					return;
				BusinessPartner partner = partners[0];
				ShortName = partner.ShortName;
				EnglishName = partner.EnglishName;
				FullName = partner.Name;
				Code = partner.Code;
				_type = partner.CustomerType;
				Address = partner.Address;
				Person = partner.ContactPerson;
				Telephone = partner.ContactPhone;
				Fax = partner.Fax;
				ZipCode = partner.ZipCode;
				Remark = partner.Remark;
				//BankAccounts = partner.BankAccounts;
				//SetBankAccounts(id);
				EnglishAddress = partner.EnglishAddress;
				TaxNo = partner.TaxNo;
				IsDefault = partner.IsDefault ?? false;
				SetCustomerType(_type);
			}
		}

		/// <summary>
		/// 新增业务伙伴
		/// </summary>
		protected override void Create()
		{
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				_type = GetCustomerType();
				
				var partner = new BusinessPartner
								  {
									  ShortName = ShortName,
									  EnglishName = EnglishName,
									  Address = Address,
									  Code = Code,
									  Fax = Fax,
									  Name = FullName,
									  Remark = Remark,
									  ContactPerson = Person,
									  ContactPhone = Telephone,
									  CustomerType = _type,
									  ZipCode = ZipCode,
									  EnglishAddress = EnglishAddress,
									  TaxNo=TaxNo,
									  IsDefault = IsDefault
								  };


				partnerService.CreateNew(partner, CurrentUser.Id);
			}
		}

		/// <summary>
		/// 修改业务伙伴
		/// </summary>
		protected override void Update()
		{
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				_type = GetCustomerType();
				BusinessPartner partner = partnerService.GetById(ObjectId);
				partner.ShortName = ShortName;
				partner.EnglishName = EnglishName;
				partner.Address = Address;
				partner.Code = Code;
				partner.Fax = Fax;
				partner.Name = FullName;
				partner.Remark = Remark;
				partner.ContactPerson = Person;
				partner.ContactPhone = Telephone;
				partner.CustomerType = _type;
				partner.ZipCode = ZipCode;
				partner.EnglishAddress = EnglishAddress;
				partner.TaxNo = TaxNo;
				partner.IsDefault = IsDefault;
				partnerService.UpdateExisted(partner, CurrentUser.Id);
			}
		}

		/// <summary>
		/// 验证
		/// </summary>
		/// <returns></returns>
		public override bool Validate()
		{
			if (string.IsNullOrWhiteSpace(ShortName))
			{
				throw new Exception(ResBusinessPartnerSetting.ShortNameRequired);
			}
			if (string.IsNullOrWhiteSpace(Code))
			{
				throw new Exception(ResBusinessPartnerSetting.BPCodeRequired);
			}
			if (string.IsNullOrWhiteSpace(FullName))
			{
				throw new Exception(ResBusinessPartnerSetting.FullNameRequired);
			}

			if (!string.IsNullOrEmpty(ZipCode) && !Regex.IsMatch(ZipCode, @"^\d{6}$"))
			{
				throw new Exception(Properties.Resources.PostCodeInputWrong);
			}

			if (ObjectId == 0)
			{
				CheckFullName();
				CheckShortName();
				CheckCode();
			}

			return true;
		}

		private void CheckShortName()
		{
			using (var partnerService =
				SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				const string queryStr = "it.ShortName=@p1";
				var parm = new List<object> {ShortName};
				List<BusinessPartner> partners = partnerService.Query(queryStr, parm);
				if (partners.Count > 0)
				{
					throw new Exception(ResBusinessPartnerSetting.ShortNameExisted);
				}
			}
		}

		private void CheckFullName()
		{
			using (var partnerService =
				SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				const string queryStr = "it.Name=@p1";
				var parm = new List<object> { FullName };
				List<BusinessPartner> partners = partnerService.Query(queryStr, parm);
				if (partners.Count > 0)
				{
					throw new Exception(ResBusinessPartnerSetting.FullNameExisted);
				}
			}
		}

		private void CheckCode()
		{
			using (var partnerService =
				SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				const string queryStr = "it.Code=@p1";
				var parm = new List<object> {Code};
				List<BusinessPartner> partners = partnerService.Query(queryStr, parm);
				if (partners.Count > 0)
				{
					throw new Exception(ResBusinessPartnerSetting.BPCodeExisted);
				}
			}
		}

		#endregion
	}
}