using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.ViewModel.Console.ApprovalCenter;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.BusinessPartnerSetting
{
	public class BusinessPartnerHomeVM : BaseVM
	{
		#region Member

		private List<EnumItem> _businessPartnerTypes;
		private int _id;
		private int _partnerForm;
		private int _partnerTo;
		private int _partnerTotalCount;
		private List<BusinessPartner> _partners;
		private string _searchName;
		private bool _searchState;
		private int _selectedType;

		#endregion

		#region Property

		public List<EnumItem> BusinessPartnerTypes
		{
			get { return _businessPartnerTypes; }
			set
			{
				if (_businessPartnerTypes != value)
				{
					_businessPartnerTypes = value;
					Notify("BusinessPartnerTypes");
				}
			}
		}

		public bool SearchState
		{
			get { return _searchState; }
			set
			{
				if (_searchState != value)
				{
					_searchState = value;
					Notify("SearchState");
				}
			}
		}

		public int SelectedType
		{
			get { return _selectedType; }
			set
			{
				if (_selectedType != value)
				{
					_selectedType = value;
					Notify("SelectedType");
				}
			}
		}

		public int Id
		{
			get { return _id; }
			set
			{
				if (_id != value)
				{
					_id = value;
					Notify("Id");
				}
			}
		}

		public List<BusinessPartner> Partners
		{
			get { return _partners; }
			set
			{
				if (_partners != value)
				{
					_partners = value;
					Notify("Partners");
				}
			}
		}

		public int PartnerTotalCount
		{
			get { return _partnerTotalCount; }
			set
			{
				if (_partnerTotalCount != value)
				{
					_partnerTotalCount = value;
					Notify("PartnerTotleCount");
				}
			}
		}

		public string SearchName
		{
			get { return _searchName; }
			set
			{
				if (_searchName != value)
				{
					_searchName = value;
					Notify("SearchName");
				}
			}
		}

		public int PartnerForm
		{
			get { return _partnerForm; }
			set
			{
				if (_partnerForm != value)
				{
					_partnerForm = value;
					Notify("PartnerForm");
				}
			}
		}

		public int PartnerTo
		{
			get { return _partnerTo; }
			set
			{
				if (_partnerTo != value)
				{
					_partnerTo = value;
					Notify("PartnerTo");
				}
			}
		}

		#endregion

		#region Constructor

		public BusinessPartnerHomeVM()
		{
			GetBusinessPartnerType();
			_partners = new List<BusinessPartner>();
			LoadPartnerCount();
		}

		#endregion

		#region Method

		/// <summary>
		/// 构造业务伙伴类型下拉框数据源
		/// </summary>
		public void GetBusinessPartnerType()
		{
			BusinessPartnerTypes = EnumHelper.GetEnumList<BusinessPartnerType>();
			BusinessPartnerTypes.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
		}

		public void LoadPartnerCount()
		{
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				_partnerTotalCount = partnerService.GetAllCount();
			}
		}

		public void LoadPartners(bool state)
		{
			SearchState = state;
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				string queryStr;
				List<object> parameters;
				BuildQueryStrAndParams(out queryStr, out parameters);
				var includes = new List<string>
							   {
								   "Approval",
								   "Approval.ApprovalStages",
								   "Approval.ApprovalStages.ApprovalUser"
							   };
				if (queryStr == string.Empty)
				{
					_partnerTotalCount = partnerService.GetAllCount();
					Partners = partnerService.SelectByRangeWithOrder("1=1", null, new SortCol {ByDescending = true, ColName = "Id"},
																  PartnerForm, PartnerTo, includes);
				}
				else
				{
					_partnerTotalCount = partnerService.GetCount(queryStr, parameters);
					Partners = partnerService.SelectByRangeWithOrder(queryStr, parameters,
																	new SortCol {ByDescending = true, ColName = "Id"},
																	PartnerForm, PartnerTo, includes);
				}

				foreach (var bp in Partners)
				{
					if (bp.ApproveStatus == (int) ApproveStatus.NoApproveNeeded || bp.Approval == null ||
					    bp.Approval.ApprovalStages == null) continue;
					FilterDeleted(bp.Approval.ApprovalStages);

					List<ApprovalStage> stages = bp.Approval.ApprovalStages.ToList();
					string passed;
					string notPassed;
					ApprovalCenterHomeVM.ParseApprovalDetailString(stages, bp.ApprovalStageIndex ?? 0, out passed,
					                                               out notPassed);

					if (bp.ApproveStatus == (int) ApproveStatus.Approved)
					{
						bp.CustomerStrField1 = passed + notPassed;
						bp.CustomerStrField2 = string.Empty;
					}
					else
					{
						bp.CustomerStrField1 = passed;
						bp.CustomerStrField2 = notPassed;
					}
				}
			}
		}

		private void BuildQueryStrAndParams(out string queryStr, out List<object> parameters)
		{
			queryStr = string.Empty;
			parameters = new List<object>();
			if (!SearchState)
				return;
			var sb = new StringBuilder();
			int num = 1;
			if (!string.IsNullOrEmpty(SearchName))
			{
				sb.AppendFormat("it.Name like @p{0} ", num++);
				parameters.Add("%" + SearchName.Trim() + "%");
			}

			if (SelectedType != 0)
			{
				if (sb.Length != 0)
				{
					sb.Append(" and ");
				}
				sb.AppendFormat("it.CustomerType = @p{0} ", num);
				parameters.Add(SelectedType);
			}
			queryStr = sb.ToString();
		}

		public void SearchPartners(bool state)
		{
			SearchState = state;
			string queryStr;
			List<object> parameters;
			BuildQueryStrAndParams(out queryStr, out parameters);
			var includes = new List<string>
							   {
								   "Approval",
								   "Approval.ApprovalStages",
								   "Approval.ApprovalStages.ApprovalUser"
							   };
			using (var client = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				if (queryStr != "")
				{
					_partnerTotalCount = client.GetCount(queryStr, parameters);
					Partners = client.SelectByRange(queryStr, parameters, PartnerForm,PartnerTo, includes);
				}
				else
				{
					_partnerTotalCount = client.GetAllCount();
					Partners = client.SelectByRangeWithOrder("1=1", null, new SortCol {ByDescending = true, ColName = "Id"}, PartnerForm,
														  PartnerTo, includes);
				}

				foreach (var bp in Partners)
				{
					if (bp.ApproveStatus == (int)ApproveStatus.NoApproveNeeded || bp.Approval == null ||
						bp.Approval.ApprovalStages == null) continue;
					FilterDeleted(bp.Approval.ApprovalStages);

					List<ApprovalStage> stages = bp.Approval.ApprovalStages.ToList();
					string passed;
					string notPassed;
					ApprovalCenterHomeVM.ParseApprovalDetailString(stages, bp.ApprovalStageIndex ?? 0, out passed,
																   out notPassed);

					if (bp.ApproveStatus == (int)ApproveStatus.Approved)
					{
						bp.CustomerStrField1 = passed + notPassed;
						bp.CustomerStrField2 = string.Empty;
					}
					else
					{
						bp.CustomerStrField1 = passed;
						bp.CustomerStrField2 = notPassed;
					}
				}
			}
		}

		public void Remove(int id)
		{
			using (
				var partnerService =
					SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
			{
				partnerService.DeletedById(id, CurrentUser.Id);
			}
		}

		#endregion
	}
}