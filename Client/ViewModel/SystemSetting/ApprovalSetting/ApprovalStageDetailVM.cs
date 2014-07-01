using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.UserServiceReference;
using Client.View.SystemSetting.ApprovalSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ApprovalSetting
{
    public class ApprovalStageDetailVM : BaseVM
    {
        #region Member

        private int? _stageIndex;
        private int _userId;
        private string _userName;

        #endregion

        #region Property

        public int? StageIndex
        {
            get { return _stageIndex; }
            set
            {
                if (_stageIndex != value)
                {
                    _stageIndex = value;
                    Notify("StageIndex");
                }
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    Notify("UserName");
                }
            }
        }

        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    Notify("UserId");
                }
            }
        }

        public List<ApprovalStage> Stages { get; set; }

        public ApprovalStage NewStage { get; set; }

        #endregion

        #region Constructor

        public ApprovalStageDetailVM(List<ApprovalStage> stages)
        {
            Stages = stages;
            NewStage = null;
            UserName = string.Empty;
            UserId = 0;

            if (Stages == null || Stages.Count == 0)
            {
                StageIndex = 1;
            }
            else
            {
                StageIndex = Stages.Max(o => o.StageIndex) + 1;
            }
        }

        #endregion

        #region Method

        public override void Save()
        {
            if (StageIndex == null || StageIndex <= 0)
            {
                throw new Exception(ResApprovalSetting.NoInputWrong);
            }

            var userService = SvcClientManager.GetSvcClient<UserServiceClient>(SvcType.UserSvc);
            User user = userService.GetById(UserId);

            NewStage = new ApprovalStage {StageIndex = StageIndex, ApprovalUser = user};
            if (Stages.Count == 0)
            {
                NewStage.Id = 0;
            }
            else
            {
                int tmp = Stages.Max(o => o.Id);
                NewStage.Id = -(tmp + 1);
            }

            Stages.Add(NewStage);
            Stages = Stages.OrderBy(o => o.StageIndex).ToList();
        }

        #endregion
    }
}