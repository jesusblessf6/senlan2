using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.ModuleServiceReference;
using Client.RoleServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.RoleSetting
{
    public class RolePermsVM : BaseVM
    {
        #region Members

        private List<RolePermLineVM> _permLines;

        public List<RolePermLineVM> PermLines
        {
            get { return _permLines; }
            set
            {
                _permLines = value;
                Notify("PermLines");
            }
        }

        #endregion

        #region Constructor

        public RolePermsVM()
        {
            ObjectId = 0;
            _permLines = new List<RolePermLineVM>();
        }

        public RolePermsVM(int roleId)
        {
            ObjectId = roleId;
            _permLines = new List<RolePermLineVM>();
        }

        #endregion

        #region Method

        public void Load()
        {
            List<Module> allModules;
            using (var moduleService = SvcClientManager.GetSvcClient<ModuleServiceClient>(SvcType.ModuleSvc))
            {
                var includes = new List<string> {"Category", "Functions"};
                allModules = moduleService.FetchAll(includes).OrderBy(o => o.CategoryId).ToList();
            }

            List<Function> rolesFuncs;
            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                rolesFuncs = roleService.GetRolesFunctions(ObjectId);
            }

            _permLines.Clear();
            foreach (Module m in allModules)
            {
                var l = new RolePermLineVM
                            {
                                CategoryId = m.CategoryId,
                                CategoryName = m.Category.DisplayName,
                                ModuleId = m.Id,
                                ModuleName = m.DisplayName,
                                IsAddChecked = false,
                                IsAddExisted = false,
                                IsDeleteChecked = false,
                                IsDeleteExisted = false,
                                IsEditChecked = false,
                                IsEditExisted = false,
                                IsViewChecked = false,
                                IsViewExisted = false
                            };

                foreach (Function f in m.Functions)
                {
                    if (f.PageMode == PageMode.AddMode.ToString())
                    {
                        l.IsAddExisted = true;
                        l.AddFunctionId = f.Id;
                    }
                    else if (f.PageMode == PageMode.DeleteMode.ToString())
                    {
                        l.IsDeleteExisted = true;
                        l.DeleteFunctionId = f.Id;
                    }
                    else if (f.PageMode == PageMode.EditMode.ToString())
                    {
                        l.IsEditExisted = true;
                        l.EditFunctionId = f.Id;
                    }
                    else if (f.PageMode == PageMode.ViewMode.ToString())
                    {
                        l.IsViewExisted = true;
                        l.ViewFunctionId = f.Id;
                    }
                }

                List<Function> enabledFuncs = rolesFuncs.Where(o => o.ModuleId == m.Id).ToList();
                foreach (Function f in enabledFuncs)
                {
                    if (f.PageMode == PageMode.AddMode.ToString())
                    {
                        l.IsAddChecked = true;
                    }
                    else if (f.PageMode == PageMode.DeleteMode.ToString())
                    {
                        l.IsDeleteChecked = true;
                    }
                    else if (f.PageMode == PageMode.EditMode.ToString())
                    {
                        l.IsEditChecked = true;
                    }
                    else if (f.PageMode == PageMode.ViewMode.ToString())
                    {
                        l.IsViewChecked = true;
                    }
                }

                _permLines.Add(l);
            }
        }

        public override bool Validate()
        {
            return true;
        }

        public override void Save()
        {
            var links = new List<RoleFunctionLink>();
            foreach (RolePermLineVM line in PermLines)
            {
                if (line.IsAddChecked && line.IsAddExisted)
                {
                    var l = new RoleFunctionLink {FunctionId = line.AddFunctionId, RoleId = ObjectId};
                    links.Add(l);
                }

                if (line.IsEditChecked && line.IsEditExisted)
                {
                    var l = new RoleFunctionLink {FunctionId = line.EditFunctionId, RoleId = ObjectId};
                    links.Add(l);
                }

                if (line.IsDeleteChecked && line.IsDeleteExisted)
                {
                    var l = new RoleFunctionLink {FunctionId = line.DeleteFunctionId, RoleId = ObjectId};
                    links.Add(l);
                }

                if (line.IsViewChecked && line.IsViewExisted)
                {
                    var l = new RoleFunctionLink {FunctionId = line.ViewFunctionId, RoleId = ObjectId};
                    links.Add(l);
                }
            }

            using (var roleService = SvcClientManager.GetSvcClient<RoleServiceClient>(SvcType.RoleSvc))
            {
                roleService.UpdatePerms(links, ObjectId);
            }
        }

        #endregion
    }
}