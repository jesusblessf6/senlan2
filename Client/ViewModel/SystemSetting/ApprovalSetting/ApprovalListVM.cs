using System.Collections.Generic;
using Client.ApprovalServiceReference;
using Client.Base.BaseClientVM;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ApprovalSetting
{
    public class ApprovalListVM : BaseVM
    {
        #region Members

        private List<Approval> _approvals;

        #endregion

        #region Property

        public List<Approval> Approvals
        {
            get { return _approvals; }
            set
            {
                if (_approvals != value)
                {
                    _approvals = value;
                    Notify("Approvals");
                }
            }
        }

        public int ApprovalCount { get; set; }

        public int ApprovalFrom { get; set; }

        public int ApprovalTo { get; set; }

        #endregion

        #region Constructor

        public ApprovalListVM()
        {
            LoadCount();
        }

        #endregion

        #region Method

        public void LoadCount()
        {
            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                ApprovalCount = approvalService.GetAllCount();
            }
        }

        public void Load()
        {
            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                Approvals = approvalService.FetchByRangeWithOrder(new SortCol {ByDescending = true, ColName = "Id"},
                                                                  ApprovalFrom, ApprovalTo,
                                                                  new List<string> {"Document"});
            }
        }

        public bool CanEdit(int id)
        {
            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                return approvalService.CanEdit(id);
            }
        }

        public bool CanDelete(int id)
        {
            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                return approvalService.CanDelete(id);
            }
        }

        public void DeleteApproval(int id)
        {
            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                approvalService.DeleteApproval(id, CurrentUser.Id);
            }
        }

        #endregion
    }
}