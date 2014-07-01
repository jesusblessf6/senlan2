using System.ComponentModel;
using Client.Base.BaseClientVM;

namespace Client.ViewModel.SystemSetting.RoleSetting
{
    public class RolePermLineVM : BaseVM
    {
        #region Properties

        private int _addFunctionId;
        private int _categoryId;

        private string _categoryName;
        private int _deleteFunctionId;
        private int _editFunctionId;
        private bool _isAddChecked;
        private bool _isAddExisted;
        private bool _isDeleteChecked;
        private bool _isDeleteExisted;
        private bool _isEditChecked;
        private bool _isEditExisted;
        private bool _isViewChecked;
        private bool _isViewExisted;
        private int _moduleId;
        private string _moduleName;
        private int _viewFunctionId;

        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                Notify("CategoryId");
            }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                Notify("CategoryName");
            }
        }

        public int ModuleId
        {
            get { return _moduleId; }
            set
            {
                _moduleId = value;
                Notify("ModuleId");
            }
        }

        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                _moduleName = value;
                Notify("ModuleName");
            }
        }

        public bool IsAddExisted
        {
            get { return _isAddExisted; }
            set
            {
                _isAddExisted = value;
                Notify("IsAddExisted");
            }
        }

        public int AddFunctionId
        {
            get { return _addFunctionId; }
            set
            {
                _addFunctionId = value;
                Notify("AddFunctionId");
            }
        }

        public bool IsEditExisted
        {
            get { return _isEditExisted; }
            set
            {
                _isEditExisted = value;
                Notify("IsEditExisted");
            }
        }

        public int EditFunctionId
        {
            get { return _editFunctionId; }
            set
            {
                _editFunctionId = value;
                Notify("EditFunctionId");
            }
        }

        public bool IsDeleteExisted
        {
            get { return _isDeleteExisted; }
            set
            {
                _isDeleteExisted = value;
                Notify("IsDeleteExisted");
            }
        }

        public int DeleteFunctionId
        {
            get { return _deleteFunctionId; }
            set
            {
                _deleteFunctionId = value;
                Notify("DeleteFunctionId");
            }
        }


        public bool IsViewExisted
        {
            get { return _isViewExisted; }
            set
            {
                _isViewExisted = value;
                Notify("IsViewExisted");
            }
        }

        public int ViewFunctionId
        {
            get { return _viewFunctionId; }
            set
            {
                _viewFunctionId = value;
                Notify("ViewFunctionId");
            }
        }

        public bool IsAddChecked
        {
            get { return _isAddChecked; }
            set
            {
                _isAddChecked = value;
                Notify("IsAddChecked");
            }
        }

        public bool IsEditChecked
        {
            get { return _isEditChecked; }
            set
            {
                _isEditChecked = value;
                Notify("IsEditChecked");
            }
        }

        public bool IsDeleteChecked
        {
            get { return _isDeleteChecked; }
            set
            {
                _isDeleteChecked = value;
                Notify("IsDeleteChecked");
            }
        }

        public bool IsViewChecked
        {
            get { return _isViewChecked; }
            set
            {
                _isViewChecked = value;
                Notify("IsViewChecked");
            }
        }

        #endregion

        #region Constructor

        public RolePermLineVM()
        {
            PropertyChanged += RolePermLineVMPropertyChanged;
        }

        #endregion

        #region Event

        protected void RolePermLineVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsViewChecked" && IsViewChecked == false)
            {
                IsAddChecked = false;
                IsEditChecked = false;
                IsDeleteChecked = false;
            }
            else if ((e.PropertyName == "IsEditChecked" && IsEditChecked) ||
                     (e.PropertyName == "IsAddChecked" && IsAddChecked) ||
                     (e.PropertyName == "IsDeleteChecked" && IsDeleteChecked))
            {
                IsViewChecked = true;
            }
        }

        #endregion
    }
}