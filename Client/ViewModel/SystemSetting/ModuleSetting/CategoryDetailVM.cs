using System;
using Client.Base.BaseClientVM;
using Client.CategoryServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ModuleSetting
{
    public class CategoryDetailVM : BaseVM
    {
        #region Members

        private string _controlName;
        private string _description;
        private string _displayName;
        private int? _id;
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

        public string ControlName
        {
            get { return _controlName; }
            set
            {
                if (_controlName != value)
                {
                    _controlName = value;
                    Notify("ControlName");
                }
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    Notify("DisplayName");
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

        public int? Id
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

        #endregion

        #region Constructor

        public CategoryDetailVM()
        {
            _id = null;
            ObjectId = 0;
        }

        #endregion

        #region Method

        protected override void Create()
        {
            var category = new Category
                               {
                                   Name = Name,
                                   Description = Description,
                                   ControlName = ControlName,
                                   Id = Id ?? 0,
                                   DisplayName = DisplayName
                               };

            using (var categoryService
                = SvcClientManager.GetSvcClient<CategoryServiceClient>(SvcType.CategorySvc))
            {
                categoryService.Create(category);
            }
        }

        protected override void Update()
        {
        }

        public void Reset()
        {
            Name = string.Empty;
            DisplayName = string.Empty;
            ControlName = string.Empty;
            Description = string.Empty;
            Id = null;
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("名称不能为空！");
            }

            if (string.IsNullOrEmpty(DisplayName))
            {
                throw new Exception("中文名不能为空！");
            }

            if (string.IsNullOrEmpty(ControlName))
            {
                throw new Exception("控件名不能为空！");
            }

            if (Id == null)
            {
                throw new Exception("Id不能为空！");
            }

            return true;
        }

        #endregion
    }
}