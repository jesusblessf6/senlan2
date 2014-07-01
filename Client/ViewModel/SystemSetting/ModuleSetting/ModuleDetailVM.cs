using System;
using System.Collections.Generic;
using System.Windows;
using Client.Base.BaseClientVM;
using Client.CategoryServiceReference;
using Client.ModuleServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ModuleSetting
{
    public class ModuleDetailVM : BaseVM
    {
        #region Member

        private List<Category> _categories;
        private string _controlName;
        private string _description;
        private string _displayName;
        private int? _id;
        private string _name;
        private int _selectedCategoryId;

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

        public List<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                Notify("Categories");
            }
        }

        public int SelectedCategoryId
        {
            get { return _selectedCategoryId; }
            set
            {
                if (_selectedCategoryId != value)
                {
                    _selectedCategoryId = value;
                    Notify("SelectedCategoryId");
                }
            }
        }

        #endregion

        #region Constructor

        public ModuleDetailVM()
        {
            ObjectId = 0;

            Initialize();
        }

        public ModuleDetailVM(int moduleId)
        {
            ObjectId = moduleId;

            Initialize();
        }

        #endregion

        #region Method

        protected override void Create()
        {
            using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
            {
                var module = new Module
                                 {
                                     Name = Name,
                                     DisplayName = DisplayName,
                                     ControlName = ControlName,
                                     Id = Id ?? 0,
                                     Description = Description,
                                     CategoryId = SelectedCategoryId
                                 };

                moduleService.Create(module);
            }
        }

        protected override void Update()
        {
            using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
            {
                Module module = moduleService.GetById(ObjectId);
                module.Name = Name;
                module.DisplayName = DisplayName;
                module.ControlName = ControlName;
                module.Id = Id ?? 0;
                module.CategoryId = SelectedCategoryId;
                module.Description = Description;

                moduleService.Update(module);
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception("模块名称不能为空！");
            }

            if (string.IsNullOrWhiteSpace(DisplayName))
            {
                throw new Exception("模块中文名不能为空！");
            }

            if (Id == null)
            {
                throw new Exception("Id不能为空！");
            }

            if (ObjectId == 0)
            {
                using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
                {
                    Module m = moduleService.GetById(ObjectId);
                    if (m != null)
                    {
                        throw new Exception("Id已存在！");
                    }
                }
            }


            if (SelectedCategoryId == 0)
            {
                throw new Exception("请选择模块分类！");
            }

            return true;
        }

        private void Initialize()
        {
            using (var categoryService = SvcClientManager.GetSvcClient<CategoryServiceClient>(SvcType.CategorySvc))
            {
                _categories = categoryService.GetAll();
            }

            _categories.Insert(0, new Category {Id = 0, Name = ""});

            var selectedTreeItem = Application.Current.Properties["SelectedTreeItem"] as ModuleTreeItem;

            if (selectedTreeItem == null)
            {
                SelectedCategoryId = 0;
            }
            else if (selectedTreeItem.Type == "Module")
            {
                SelectedCategoryId = selectedTreeItem.Parent.Id;
            }
            else
            {
                SelectedCategoryId = selectedTreeItem.Id;
            }

            if (ObjectId > 0)
            {
                using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
                {
                    Module module = moduleService.GetById(ObjectId);

                    Name = module.Name;
                    DisplayName = module.DisplayName;
                    ControlName = module.ControlName;
                    Description = module.Description;
                    Id = module.Id;
                }
            }
        }

        public void Reset()
        {
            Name = string.Empty;
            DisplayName = string.Empty;
            ControlName = string.Empty;
            Id = null;
            Description = string.Empty;
            SelectedCategoryId = 0;
        }

        #endregion
    }
}