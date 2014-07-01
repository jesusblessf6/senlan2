using System.Collections.Generic;
using System.ComponentModel;
using Client.Base.BaseClientVM;
using Client.ModuleServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ModuleSetting
{
    public class ModulePermSettingVM : BaseVM
    {
        #region Member

        private bool _canAdd;
        private bool _canDelete;
        private bool _canEdit;
        private bool _canView;

        #endregion

        #region Property

        public bool CanView
        {
            get { return _canView; }
            set
            {
                if (_canView != value)
                {
                    _canView = value;
                    Notify("CanView");
                }
            }
        }

        public bool CanAdd
        {
            get { return _canAdd; }
            set
            {
                if (_canAdd != value)
                {
                    _canAdd = value;
                    Notify("CanAdd");
                }
            }
        }

        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                if (_canEdit != value)
                {
                    _canEdit = value;
                    Notify("CanEdit");
                }
            }
        }

        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    Notify("CanDelete");
                }
            }
        }

        #endregion

        #region Constructor

        public ModulePermSettingVM(int moduleId)
        {
            ObjectId = moduleId;
            Initialize();
            PropertyChanged += ModulePermSettingVMPropertyChanged;
        }

        public ModulePermSettingVM()
        {
            ObjectId = 0;
            Initialize();
        }

        #endregion

        #region Method

        protected void Initialize()
        {
            CanAdd = false;
            CanDelete = false;
            CanEdit = false;
            CanView = false;

            if (ObjectId > 0)
            {
                Module module;
                using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
                {
                    var includes = new List<string> {"Functions"};
                    module = moduleService.FetchById(ObjectId, includes);
                }

                if (module != null && module.Functions != null)
                {
                    foreach (Function f in module.Functions)
                    {
                        if (f.PageMode == PageMode.AddMode.ToString())
                        {
                            CanAdd = true;
                        }
                        else if (f.PageMode == PageMode.DeleteMode.ToString())
                        {
                            CanDelete = true;
                        }
                        else if (f.PageMode == PageMode.EditMode.ToString())
                        {
                            CanEdit = true;
                        }
                        else if (f.PageMode == PageMode.ViewMode.ToString())
                        {
                            CanView = true;
                        }
                    }
                }
            }
        }

        protected override void Update()
        {
            var permStates = new Dictionary<string, bool>
                                 {
                                     {PageMode.AddMode.ToString(), CanAdd},
                                     {PageMode.EditMode.ToString(), CanEdit},
                                     {PageMode.DeleteMode.ToString(), CanDelete},
                                     {PageMode.ViewMode.ToString(), CanView}
                                 };

            using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
            {
                moduleService.UpdatePermOptions(ObjectId, permStates, CurrentUser.Id);
            }

            base.Update();
        }

        public override bool Validate()
        {
            return true;
        }

        #endregion

        #region Event

        protected void ModulePermSettingVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanAdd" || e.PropertyName == "CanEdit" || e.PropertyName == "CanDelete")
            {
                if ((CanAdd || CanEdit || CanDelete) && !CanView)
                {
                    CanView = true;
                }
            }
            else if (e.PropertyName == "CanView")
            {
                if (!CanView)
                {
                    CanAdd = false;
                    CanEdit = false;
                    CanDelete = false;
                }
            }
        }

        #endregion
    }
}