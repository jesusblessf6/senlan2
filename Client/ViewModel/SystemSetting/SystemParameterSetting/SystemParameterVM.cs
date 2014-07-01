using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.SystemParameterServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.SystemParameterSetting
{
	public class SystemParameterVM : BaseVM
	{
		#region Member

		private string _domesticContractTemplatePath;
		private List<string> _domesticContractTemplatePathList; //内贸合同
		private string _domesticWarehouseOutTemplatePath;
		private List<string> _domesticWarehouseOutTemplatePathList; //内贸出库单
		private string _finalInvoiceTemplatePath;
		private List<string> _finalInvoiceTemplatePathList; //最终商业发票
		private string _internationalContractTemplatePath;
		private string _pricingConfirmationTemplatePath;//点价确认单
		private List<string> _pricingConfirmationTemplatePathList;
		private List<string> _internationalContractTemplatePathList; //外贸合同
		private string _paymentRequestTemplatePath;
		private List<string> _paymentRequestTemplatePathList; //付款申请单模板
		private string _provisionalInvoiceTemplatePath;
		private List<string> _provisionalInvoiceTemplatePathList; //临时商业发票

		private decimal _delivery2Quota;
		private decimal _inventory2Delivery;
		private bool? _isLMEAgent;
		private bool _paymentRequestApprove;
		private decimal _pricing2Quota;
		private decimal? _pricingAlert;
		private bool _quotaApprove;
		private bool _vatInvoiceApprove;
		private bool _bpApprove;
		private string _warehouseOutNo;
		private decimal? _LCFinanceStatusParameter;
		private Dictionary<string, int> _DeliveryNoFormulas;
		private int? _SelectDeliveryNoFormula;
		private bool? _IsUseMultipleBrands;
		private List<string> _DiskNameList;
		private string _SelectedDiskName;
		#endregion

		#region property
		public string SelectedDiskName
		{
			get { return _SelectedDiskName; }
			set { 
				if(_SelectedDiskName != value)
				{
					_SelectedDiskName = value;
					Notify("SelectedDiskName");
				}
			}
		}

		public List<string> DiskNameList
		{
			get { return _DiskNameList; }
			set { 
				if(_DiskNameList != value)
				{
					_DiskNameList = value;
					Notify("DiskNameList");
				}
			}
		}

		public bool? IsUseMultipleBrands
		{
			get { return _IsUseMultipleBrands; }
			set {
				if (_IsUseMultipleBrands != value)
				{
					_IsUseMultipleBrands = value;
					Notify("IsUseMultipleBrands");
				}
			}
		}

		public int? SelectDeliveryNoFormula
		{
			get { return _SelectDeliveryNoFormula; }
			set {
				if (_SelectDeliveryNoFormula != value)
				{
					_SelectDeliveryNoFormula = value;
					Notify("SelectDeliveryNoFormula");
				}
			}
		}

		public Dictionary<string, int> DeliveryNoFormulas
		{
			get { return _DeliveryNoFormulas; }
			set { 
				if(_DeliveryNoFormulas != value)
				{
					_DeliveryNoFormulas = value;
					Notify("DeliveryNoFormulas");
				}
			}
		}

		public decimal? LCFinanceStatusParameter
		{
			get { return _LCFinanceStatusParameter; }
			set
			{
				if (_LCFinanceStatusParameter != value)
				{
					_LCFinanceStatusParameter = value;
					Notify("LCFinanceStatusParameter");
				}
			}
		}


		public List<string> PricingConfirmationTemplatePathList
		{
			get { return _pricingConfirmationTemplatePathList;}
			set { 
				if(_pricingConfirmationTemplatePathList != value)
				{
					_pricingConfirmationTemplatePathList = value;
					Notify("PricingConfirmationTemplatePathList");
				}
			}
		}

		public string PricingConfirmationTemplatePath
		{
			get { return _pricingConfirmationTemplatePath; }
			set { 
				if(_pricingConfirmationTemplatePath != value)
				{
					_pricingConfirmationTemplatePath = value;
					Notify("PricingConfirmationTemplatePath");
				}
			}
		}

		public string WarehouseOutNo
		{
			get { return _warehouseOutNo; }
			set {
				if (_warehouseOutNo != value)
				{
					_warehouseOutNo = value;
					Notify("WarehouseOutNo");
				}
			}
		}

		public List<string> FinalInvoiceTemplatePathList
		{
			get { return _finalInvoiceTemplatePathList; }
			set
			{
				if (_finalInvoiceTemplatePathList != value)
				{
					_finalInvoiceTemplatePathList = value;
					Notify("FinalInvoiceTemplatePathList");
				}
			}
		}

		public List<string> ProvisionalInvoiceTemplatePathList
		{
			get { return _provisionalInvoiceTemplatePathList; }
			set
			{
				if (_provisionalInvoiceTemplatePathList != value)
				{
					_provisionalInvoiceTemplatePathList = value;
					Notify("ProvisionalInvoiceTemplatePathList");
				}
			}
		}

		public List<string> PaymentRequestTemplatePathList
		{
			get { return _paymentRequestTemplatePathList; }
			set
			{
				if (_paymentRequestTemplatePathList != value)
				{
					_paymentRequestTemplatePathList = value;
					Notify("PaymentRequestTemplatePathList");
				}
			}
		}

		public List<string> DomesticWarehouseOutTemplatePathList
		{
			get { return _domesticWarehouseOutTemplatePathList; }
			set
			{
				if (_domesticWarehouseOutTemplatePathList != value)
				{
					_domesticWarehouseOutTemplatePathList = value;
					Notify("DomesticWarehouseOutTemplatePathList");
				}
			}
		}

		public List<string> InternationalContractTemplatePathList
		{
			get { return _internationalContractTemplatePathList; }
			set
			{
				if (_internationalContractTemplatePathList != value)
				{
					_internationalContractTemplatePathList = value;
					Notify("InternationalContractTemplatePathList");
				}
			}
		}

		public List<string> DomesticContractTemplatePathList
		{
			get { return _domesticContractTemplatePathList; }
			set
			{
				if (_domesticContractTemplatePathList != value)
				{
					_domesticContractTemplatePathList = value;
					Notify("DomesticContractTemplatePathList");
				}
			}
		}

		public decimal Inventory2Delivery
		{
			get { return _inventory2Delivery; }
			set
			{
				if (_inventory2Delivery != value)
				{
					_inventory2Delivery = value;
					Notify("Inventory2Delivery");
				}
			}
		}

		public decimal Delivery2Quota
		{
			get { return _delivery2Quota; }
			set
			{
				if (_delivery2Quota != value)
				{
					_delivery2Quota = value;
					Notify("Delivery2Quota");
				}
			}
		}

		public decimal Pricing2Quota
		{
			get { return _pricing2Quota; }
			set
			{
				if (_pricing2Quota != value)
				{
					_pricing2Quota = value;
					Notify("Pricing2Quota");
				}
			}
		}

		public bool QuotaApprove
		{
			get { return _quotaApprove; }
			set
			{
				if (_quotaApprove != value)
				{
					_quotaApprove = value;
					Notify("QuotaApprove");
				}
			}
		}

		public bool BPApprove
		{
			get { return _bpApprove; }
			set
			{
				if (_bpApprove != value)
				{
					_bpApprove = value;
					Notify("BPApprove");
				}
			}
		}

		public bool VATInvoiceApprove
		{
			get { return _vatInvoiceApprove; }
			set
			{
				if (_vatInvoiceApprove != value)
				{
					_vatInvoiceApprove = value;
					Notify("VATInvoiceApprove");
				}
			}
		}

		public bool PaymentRequestApprove
		{
			get { return _paymentRequestApprove; }
			set
			{
				if (_paymentRequestApprove != value)
				{
					_paymentRequestApprove = value;
					Notify("PaymentRequestApprove");
				}
			}
		}

		public decimal? PricingAlert
		{
			get { return _pricingAlert; }
			set
			{
				if (_pricingAlert != value)
				{
					_pricingAlert = value;
					Notify("PricingAlert");
				}
			}
		}

		public bool? IsLMEAgent
		{
			get { return _isLMEAgent; }
			set
			{
				if (_isLMEAgent != value)
				{
					_isLMEAgent = value;
					Notify("IsLMEAgent");
				}
			}
		}

		public string DomesticContractTemplatePath
		{
			get { return _domesticContractTemplatePath; }
			set
			{
				if (_domesticContractTemplatePath != value)
				{
					_domesticContractTemplatePath = value;
					Notify("DomesticContractTemplatePath");
				}
			}
		}

		public string InternationalContractTemplatePath
		{
			get { return _internationalContractTemplatePath; }
			set
			{
				if (_internationalContractTemplatePath != value)
				{
					_internationalContractTemplatePath = value;
					Notify("InternationalContractTemplatePath");
				}
			}
		}

		public string DomesticWarehouseOutTemplatePath
		{
			get { return _domesticWarehouseOutTemplatePath; }
			set
			{
				if (_domesticWarehouseOutTemplatePath != value)
				{
					_domesticWarehouseOutTemplatePath = value;
					Notify("DomesticWarehouseOutTemplatePath");
				}
			}
		}

		public string PaymentRequestTemplatePath
		{
			get { return _paymentRequestTemplatePath; }
			set
			{
				if (_paymentRequestTemplatePath != value)
				{
					_paymentRequestTemplatePath = value;
					Notify("PaymentRequestTemplatePath");
				}
			}
		}

		public string ProvisionalInvoiceTemplatePath
		{
			get { return _provisionalInvoiceTemplatePath; }
			set
			{
				if (_provisionalInvoiceTemplatePath != value)
				{
					_provisionalInvoiceTemplatePath = value;
					Notify("ProvisionalInvoiceTemplatePath");
				}
			}
		}

		public string FinalInvoiceTemplatePath
		{
			get { return _finalInvoiceTemplatePath; }
			set
			{
				if (_finalInvoiceTemplatePath != value)
				{
					_finalInvoiceTemplatePath = value;
					Notify("FinalInvoiceTemplatePath");
				}
			}
		}

		#endregion

		#region Constructor

		public SystemParameterVM()
		{
			loadDeliveryNoFormula();
			LoadSystemParameters();
			LoadPathList();
			GetDiskNameList();
		}

		#endregion

		#region Method
		public void loadDeliveryNoFormula()
		{
			DeliveryNoFormulas = new Dictionary<string, int>();
			DeliveryNoFormulas = EnumHelper.GetEnumDic<DeliveryNoFormula>(DeliveryNoFormulas);
		}

		public void LoadPathList()
		{
			DomesticContractTemplatePathList = GetTemplateNamesByType(PrintTemplateType.DomesticContractTemplate);
			DomesticWarehouseOutTemplatePathList = GetTemplateNamesByType(PrintTemplateType.DomesticWarehouseOutTemplate);
			InternationalContractTemplatePathList = GetTemplateNamesByType(PrintTemplateType.InternationalContractTemplate);
			//DomesticContractTemplatePathList = GetTemplateNamesByType(PrintTemplateType.DomesticContractTemplate);
			PaymentRequestTemplatePathList = GetTemplateNamesByType(PrintTemplateType.PaymentRequestTemplate);
			ProvisionalInvoiceTemplatePathList = GetTemplateNamesByType(PrintTemplateType.ProvisionalInvoiceTemplate);
			FinalInvoiceTemplatePathList = GetTemplateNamesByType(PrintTemplateType.FinalInvoiceTemplate);
			PricingConfirmationTemplatePathList = GetTemplateNamesByType(PrintTemplateType.PricingConfirmationTemplate);
		}

		/// <summary>
		/// Load currenct system parameters
		/// </summary>
		public void LoadSystemParameters()
		{
			using (
				var systemParameterService =
					SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
			{
				SystemParameter s = systemParameterService.GetAll().FirstOrDefault();

				if (s == null)
				{
					ObjectId = 0;
					_inventory2Delivery = 0;
					_delivery2Quota = 0;
					_pricing2Quota = 0;
					_pricingAlert = 0;
				}
				else
				{
					ObjectId = s.Id;
					LCFinanceStatusParameter = s.LCFinanceStatusParameter;
					Inventory2Delivery = s.Inventory2Delivery;
					Delivery2Quota = s.Delivery2Quota;
					Pricing2Quota = s.Pricing2Quota;
					QuotaApprove = s.QuotaApprove;
					BPApprove = s.BPApprove;
					VATInvoiceApprove = s.VATInvoiceApprove;
					PaymentRequestApprove = s.PaymentRequestApprove;
					PricingAlert = s.PricingAlert;
					IsLMEAgent = s.IsLMEAgent ?? false;
					WarehouseOutNo = s.WarehouseOutNo;
					DomesticContractTemplatePath = s.DomesticContractTemplatePath;
					DomesticWarehouseOutTemplatePath = s.DomesticWarehouseOutTemplatePath;
					ProvisionalInvoiceTemplatePath = s.ProvisionalInvoiceTemplatePath;
					InternationalContractTemplatePath = s.InternationalContractTemplatePath;
					PaymentRequestTemplatePath = s.PaymentRequestTemplatePath;
					FinalInvoiceTemplatePath = s.FinalInvoiceTemplatePath;
					PricingConfirmationTemplatePath = s.PricingConfirmationTemplatePath;
					SelectDeliveryNoFormula = s.DeliveryNoFormula;
					IsUseMultipleBrands = s.IsUseMultipleBrands;
					SelectedDiskName = s.UploadDirectory;
				}
			}
		}

		public override bool Validate()
		{
			if (Inventory2Delivery < 0 || Inventory2Delivery > 100)
			{
				throw new Exception("批次货运状态参数配置输入有误！");
			}

			if (Delivery2Quota < 0 || Delivery2Quota > 100)
			{
				throw new Exception("报关提单/内贸提单货运状态参数配置输入有误！");
			}

			if (Pricing2Quota < 0 || Pricing2Quota > 100)
			{
				throw new Exception("点价数量误差参数输入有误！");
			}
			if (PricingAlert < 0)
			{
				throw new Exception("预警天数不能小于零！");
			}
			if(SelectDeliveryNoFormula.HasValue)
			{
				if(SelectDeliveryNoFormula.Value == (int)DeliveryNoFormula.XXXXX)
				{
					int outNum = 0;
					if(WarehouseOutNo.Length != 5 || int.TryParse(WarehouseOutNo,out outNum) == false)
					{
						throw new Exception("出库编号不符合规则！");
					}
				}
				else if(SelectDeliveryNoFormula.Value == (int)DeliveryNoFormula.YYXXXX)
				{
					int index = WarehouseOutNo.IndexOf('-');
					if (index == -1)
					{
						throw new Exception("出库编号不符合规则！");
					}
					else if(index > 0)
					{
						string valueBefore = WarehouseOutNo.Substring(0, index);
						string valueBack = WarehouseOutNo.Substring(index + 1);
						int outNumBefore = 0;
						int outNumBack = 0;
						if (valueBefore.Length != 2 || valueBack.Length != 4 || int.TryParse(valueBefore, out outNumBefore) == false || int.TryParse(valueBack, out outNumBack) == false)
						{
							throw new Exception("出库编号不符合规则！");
						}
					}
				}
			}
			return true;
		}

		protected override void Create()
		{
			var systemParameter = new SystemParameter
									  {
										  Inventory2Delivery = Inventory2Delivery,
										  Delivery2Quota = Delivery2Quota,
										  Pricing2Quota = Pricing2Quota,
										  QuotaApprove = QuotaApprove,
										  VATInvoiceApprove = VATInvoiceApprove,
										  PaymentRequestApprove = PaymentRequestApprove,
										  PricingAlert = PricingAlert,
										  IsLMEAgent = IsLMEAgent,
										  DomesticContractTemplatePath = DomesticContractTemplatePath,
										  DomesticWarehouseOutTemplatePath = DomesticWarehouseOutTemplatePath,
										  ProvisionalInvoiceTemplatePath = ProvisionalInvoiceTemplatePath,
										  InternationalContractTemplatePath = InternationalContractTemplatePath,
										  PaymentRequestTemplatePath = PaymentRequestTemplatePath,
										  FinalInvoiceTemplatePath = FinalInvoiceTemplatePath,
										  PricingConfirmationTemplatePath = PricingConfirmationTemplatePath,
										  LCFinanceStatusParameter = LCFinanceStatusParameter,
										  DeliveryNoFormula = SelectDeliveryNoFormula,
										  UploadDirectory = SelectedDiskName,
										  IsUseMultipleBrands = IsUseMultipleBrands ?? false
									  };
			using (
				var systemParameterService =
					SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
			{
				systemParameterService.CreateNew(systemParameter, CurrentUser.Id);
			}
		}

		protected override void Update()
		{
			using (
				var systemParameterService =
					SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
			{
				SystemParameter systemParameter = systemParameterService.GetById(ObjectId);

				if (systemParameter != null)
				{
					systemParameter.Inventory2Delivery = Inventory2Delivery;
					systemParameter.Delivery2Quota = Delivery2Quota;
					systemParameter.Pricing2Quota = Pricing2Quota;
					systemParameter.QuotaApprove = QuotaApprove;
					systemParameter.BPApprove = BPApprove;
					systemParameter.VATInvoiceApprove = VATInvoiceApprove;
					systemParameter.PaymentRequestApprove = PaymentRequestApprove;
					systemParameter.PricingAlert = PricingAlert;
					systemParameter.IsLMEAgent = IsLMEAgent;
					systemParameter.WarehouseOutNo = WarehouseOutNo;
					systemParameter.IsUseMultipleBrands = IsUseMultipleBrands ?? false;

					systemParameter.DomesticContractTemplatePath = DomesticContractTemplatePath;
					systemParameter.DomesticWarehouseOutTemplatePath = DomesticWarehouseOutTemplatePath;
					systemParameter.ProvisionalInvoiceTemplatePath = ProvisionalInvoiceTemplatePath;
					systemParameter.InternationalContractTemplatePath = InternationalContractTemplatePath;
					systemParameter.PaymentRequestTemplatePath = PaymentRequestTemplatePath;
					systemParameter.FinalInvoiceTemplatePath = FinalInvoiceTemplatePath;
					systemParameter.PricingConfirmationTemplatePath = PricingConfirmationTemplatePath;
					systemParameter.LCFinanceStatusParameter = LCFinanceStatusParameter;
					systemParameter.DeliveryNoFormula = SelectDeliveryNoFormula;
					systemParameter.UploadDirectory = SelectedDiskName;
				}
				systemParameterService.UpdateExisted(systemParameter, CurrentUser.Id);
			}
		}

		public void UpdatePathNameByType(PrintTemplateType ptt)
		{
			using (
				var systemParameterService =
					SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
			{
				SystemParameter systemParameter = systemParameterService.GetById(ObjectId);

				if (systemParameter != null)
				{
					if (ptt == PrintTemplateType.DomesticContractTemplate)
					{
						systemParameter.DomesticContractTemplatePath = DomesticContractTemplatePath;
					}

					if (ptt == PrintTemplateType.DomesticWarehouseOutTemplate)
					{
						systemParameter.DomesticWarehouseOutTemplatePath = DomesticWarehouseOutTemplatePath;
					}

					if(ptt == PrintTemplateType.InternationalContractTemplate)
					{
						systemParameter.InternationalContractTemplatePath = InternationalContractTemplatePath;
					}

					if(ptt == PrintTemplateType.FinalInvoiceTemplate)
					{
						systemParameter.FinalInvoiceTemplatePath = FinalInvoiceTemplatePath;
					}

					if(ptt == PrintTemplateType.ProvisionalInvoiceTemplate)
					{
						systemParameter.ProvisionalInvoiceTemplatePath = ProvisionalInvoiceTemplatePath;
					}

					if(ptt == PrintTemplateType.PricingConfirmationTemplate)
					{
						systemParameter.PricingConfirmationTemplatePath = PricingConfirmationTemplatePath;
					}

					if(ptt == PrintTemplateType.PaymentRequestTemplate)
					{
						systemParameter.PaymentRequestTemplatePath = PaymentRequestTemplatePath;
					}
				}

				systemParameterService.UpdateExisted(systemParameter, CurrentUser.Id);
			}
		}

		public List<string> GetTemplateNamesByType(PrintTemplateType ptt)
		{
			var templates = new List<string>();
			string templatePath = GetTemplateDirectory(ptt);
			if (templatePath == string.Empty)
				return templates;
			string[] fileNames = Directory.GetFiles(templatePath);
			if (!fileNames.Any())
				return templates;
			templates.AddRange(fileNames.Select(Path.GetFileName));
			return templates;
		}

		private String GetTemplateDirectory(PrintTemplateType ptt)
		{
			string[] di = Directory.GetDirectories(Directory.GetCurrentDirectory(), "PrintTemplate");
			if (!di.Any())
				return string.Empty;
			string[] dii = Directory.GetDirectories(di[0], EnumHelper.GetDescription(ptt));
			if (!dii.Any())
				return string.Empty;
			return dii[0];
		}

		public void GetDiskNameList()
		{
			DiskNameList = new List<string>();
			using (
				var systemParameterService =
					SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
			{
				DiskNameList = systemParameterService.GetDiskNameList();
			}
			if (string.IsNullOrEmpty(SelectedDiskName))
			{
				SelectedDiskName = DiskNameList[0];
			}
		}
		#endregion
	}
}