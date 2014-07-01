using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.ApprovalServiceReference;
using Client.Base.BaseClientVM;
using Client.DocumentServiceReference;
using Client.View.SystemSetting.ApprovalSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ApprovalSetting
{
    public class ApprovalDetailVM : BaseVM
    {
        #region Member

        private bool _conditionEnabled;
        private List<ApprovalCondition> _conditions;
        private string _description;
        private int _documentId;
        private List<Document> _documents;
        private bool _isDefault;
        private decimal? _lowerLimit;
        private string _name;
        private List<ApprovalStage> _stages;
        private decimal? _upperLimit;

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

        public List<Document> Documents
        {
            get { return _documents; }
            set
            {
                _documents = value;
                Notify("Documents");
            }
        }

        public int DocumentId
        {
            get { return _documentId; }
            set
            {
                if (_documentId != value)
                {
                    _documentId = value;
                    Notify("DocumentId");
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

        public decimal? LowerLimit
        {
            get { return _lowerLimit; }
            set
            {
                if (_lowerLimit != value)
                {
                    _lowerLimit = value;
                    Notify("LowerLimit");
                }
            }
        }

        public decimal? UpperLimit
        {
            get { return _upperLimit; }
            set
            {
                if (_upperLimit != value)
                {
                    _upperLimit = value;
                    Notify("UpperLimit");
                }
            }
        }

        public List<ApprovalStage> Stages
        {
            get { return _stages; }
            set
            {
                _stages = value;
                Notify("Stages");
            }
        }

        public List<ApprovalCondition> Conditions
        {
            get { return _conditions; }
            set
            {
                _conditions = value;
                Notify("Conditions");
            }
        }

        public bool ConditionEnabled
        {
            get { return _conditionEnabled; }
            set
            {
                if (_conditionEnabled != value)
                {
                    _conditionEnabled = value;
                    Notify("ConditionEnabled");
                }
            }
        }

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

        #endregion

        #region Constructor

        public ApprovalDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public ApprovalDetailVM(int approvalId)
        {
            ObjectId = approvalId;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            //Load Documents to Approve
            var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc);
            List<Document> d = approvalService.GetApprovableDocument();
            d.Insert(0, new Document {Id = 0, Name = ""});
            Documents = d;
            PropertyChanged += OnPropertyChanged;

            if (ObjectId > 0)
            {
                Approval approval = approvalService.GetById(ObjectId);
                if (approval != null)
                {
                    Name = approval.Name;
                    DocumentId = approval.DocumentId;
                    Description = approval.Description;

                    Conditions = approvalService.GetApprovalConditions(ObjectId, new List<string> {"Currency"});
                    Stages = approvalService.GetApprovalStages(ObjectId, new List<string> {"ApprovalUser"});
                    IsDefault = approval.IsDefault;
                }
            }
            else
            {
                Stages = new List<ApprovalStage>();
                Conditions = new List<ApprovalCondition>();
                DocumentId = 0;
                ConditionEnabled = false;
            }
        }

        public void RemoveStage(int id)
        {
            ApprovalStage tmp = Stages.FirstOrDefault(o => o.Id == id);
            Stages.Remove(tmp);
        }

        public void RemoveCondition(int id)
        {
            ApprovalCondition tmp = Conditions.FirstOrDefault(o => o.Id == id);
            Conditions.Remove(tmp);
        }

        protected override void Create()
        {
            var approval = new Approval
                               {
                                   Name = Name,
                                   DocumentId = DocumentId,
                                   Description = Description,
                                   IsDefault = IsDefault
                               };

            foreach (ApprovalStage approvalStage in Stages)
            {
                approvalStage.Id = 0;
                approval.ApprovalStages.Add(approvalStage);
            }

            if (Conditions != null)
            {
                foreach (ApprovalCondition approvalCondition in Conditions)
                {
                    approvalCondition.Id = 0;
                    approval.ApprovalConditions.Add(approvalCondition);
                }
            }

            using (var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc))
            {
                approvalService.AddNewApproval(approval, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            var approvalService = SvcClientManager.GetSvcClient<ApprovalServiceClient>(SvcType.ApprovalSvc);
            Approval a = approvalService.FetchById(ObjectId, new List<string> {"ApprovalConditions", "ApprovalStages"});

            a.Name = Name;
            a.DocumentId = DocumentId;
            a.Description = Description;
            a.IsDefault = IsDefault;

            foreach (ApprovalCondition c in a.ApprovalConditions)
            {
                c.IsDeleted = true;
            }

            foreach (ApprovalStage s in a.ApprovalStages)
            {
                s.IsDeleted = true;
            }

            foreach (ApprovalCondition c in Conditions)
            {
                if (c.Id > 0)
                {
                    a.ApprovalConditions.Single(o => o.Id == c.Id).IsDeleted = false;
                }
                else
                {
                    c.Id = 0;
                    a.ApprovalConditions.Add(c);
                }
            }

            foreach (ApprovalStage s in Stages)
            {
                if (s.Id > 0)
                {
                    a.ApprovalStages.Single(o => o.Id == s.Id).IsDeleted = false;
                }
                else
                {
                    s.Id = 0;
                    a.ApprovalStages.Add(s);
                }
            }

            approvalService.UpdateExistedApproval(a, CurrentUser.Id);
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResApprovalSetting.ApprovalNameRequired);
            }

            if (DocumentId == 0)
            {
                throw new Exception(ResApprovalSetting.DocumentTypeRequired);
            }

            if (Stages.Count == 0)
            {
                throw new Exception(ResApprovalSetting.ApprovalStageRequired);
            }

            return true;
        }

        #endregion

        #region Event

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DocumentId")
            {
                using (var docService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
                {
                    Document doc = docService.GetById(DocumentId);
                    if (doc == null)
                    {
                        ConditionEnabled = false;
                        Conditions = null;
                    }
                    else if (doc.TableCode == "Quota")
                    {
                        ConditionEnabled = true;
                        IsDefault = false;
                        Conditions = new List<ApprovalCondition>();
                    }
                    else
                    {
                        ConditionEnabled = false;
                        Conditions = null;
                    }
                }
            }
        }

        #endregion
    }
}