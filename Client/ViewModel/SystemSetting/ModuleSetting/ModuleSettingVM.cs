using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CategoryServiceReference;
using Client.ModuleServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ModuleSetting
{
    public class ModuleSettingVM : BaseVM
    {
        #region Members

        private ModuleTreeItem _currentSelection;
        private List<ModuleDetailLine> _moduleDetails;
        private List<ModuleTreeItem> _modules;
        private string _selectedModuleName;

        #endregion

        #region Property

        public List<ModuleTreeItem> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }

        public ModuleTreeItem CurrentSelection
        {
            get { return _currentSelection; }
            set { _currentSelection = value; }
        }

        public List<ModuleDetailLine> ModuleDetails
        {
            get { return _moduleDetails; }
            set { _moduleDetails = value; }
        }

        public string SelectedModuleName
        {
            get { return _selectedModuleName; }
            set
            {
                if (value != _selectedModuleName)
                {
                    _selectedModuleName = value;
                    Notify("SelectedModuleName");
                }
            }
        }

        #endregion

        #region Constructor

        public ModuleSettingVM()
        {
            _modules = new List<ModuleTreeItem>();
            _moduleDetails = new List<ModuleDetailLine>();
        }

        #endregion

        #region Method

        public void Load()
        {
            _currentSelection = null;
            LoadModuleTree();
            LoadSelectedModuleName();
        }

        public void LoadModuleTree()
        {
            _modules.Clear();
            using (var categoryService = SvcClientManager.GetSvcClient<CategoryServiceClient>(SvcType.CategorySvc))
            {
                var includes = new List<string> {"Modules"};
                List<Category> categories = categoryService.FetchAll(includes);

                foreach (Category c in categories)
                {
                    var ci = new ModuleTreeItem
                                 {
                                     Id = c.Id,
                                     Name = c.DisplayName,
                                     Parent = null,
                                     Type = "Category",
                                     Children = new List<ModuleTreeItem>()
                                 };
                    _modules.Add(ci);

                    foreach (Module m in c.Modules)
                    {
                        var mi = new ModuleTreeItem {Id = m.Id, Name = m.DisplayName, Parent = ci, Type = "Module"};
                        ci.Children.Add(mi);
                    }
                }
            }
        }

        public void LoadSelectedModuleName()
        {
            SelectedModuleName = CurrentSelection == null ? "" : CurrentSelection.Name;
        }

        public void LoadModuleDetails()
        {
            _moduleDetails.Clear();
            if (CurrentSelection != null)
            {
                if (CurrentSelection.Type == "Category")
                {
                    const string condition = "it.CategoryId = @p1";
                    var parameters = new List<object> {CurrentSelection.Id};
                    var includes = new List<string> {"Functions"};

                    using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
                    {
                        List<Module> modules = moduleService.Select(condition, parameters, includes);
                        foreach (Module m in modules)
                        {
                            var l = new ModuleDetailLine
                                        {
                                            Id = m.Id,
                                            ControlName = m.ControlName,
                                            ModuleName = m.DisplayName,
                                            Perms = m.Functions.OrderBy(o => o.PageMode).ToList()
                                        };
                            l.PermOption = String.Join("/", l.Perms.Select(o => o.Name));
                            _moduleDetails.Add(l);
                        }
                    }
                }
                else if (CurrentSelection.Type == "Module")
                {
                    const string condition = "it.Id = @p1";
                    var parameters = new List<object> {CurrentSelection.Id};
                    var includes = new List<string> {"Functions"};

                    using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
                    {
                        Module module = moduleService.Select(condition, parameters, includes).FirstOrDefault();
                        var l = new ModuleDetailLine();
                        if (module != null)
                        {
                            l.Id = module.Id;
                            l.ControlName = module.ControlName;
                            l.ModuleName = module.DisplayName;
                            l.Perms = module.Functions.ToList();
                            l.PermOption = String.Join("/", l.Perms.Select(o => o.Name));
                            _moduleDetails.Add(l);
                        }
                    }
                }
            }
        }

        #endregion
    }

    public class ModuleTreeItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ModuleTreeItem Parent { get; set; }
        public List<ModuleTreeItem> Children { get; set; }
        public string Name { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
    }

    public class ModuleDetailLine
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ControlName { get; set; }
        public string PermOption { get; set; }
        public List<Function> Perms { get; set; }
    }
}