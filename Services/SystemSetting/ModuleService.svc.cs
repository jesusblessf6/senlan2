using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using Utility.Misc;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ModuleService" in code, svc and config file together.
    public class ModuleService : BaseService<Module>, IModuleService
    {
        public override void RemoveById(int moduleId, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var module = QueryForObj(GetObjQuery<Module>(ctx).Include("Functions").Include("Functions.RoleFunctionLinks"), o => o.Id == moduleId);

                    if (module == null)
                    {
                        throw new FaultException(ErrCode.ObjectNotFound.ToString());
                    }

                    Delete(GetObjSet<Module>(ctx), module);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void UpdatePermOptions(int moduleId, Dictionary<string, bool> permState, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<Function> functions = QueryForObjs(GetObjQuery<Function>(ctx).Include("RoleFunctionLinks"), o => o.ModuleId == moduleId).ToList();
                    List<string> pageModes = functions.Select(o => o.PageMode).ToList();

                    foreach (KeyValuePair<string, bool> pair in permState)
                    {
                        if (pair.Value && !pageModes.Contains(pair.Key))
                        {
                            var f = new Function
                            {
                                ModuleId = moduleId,
                                PageMode = pair.Key,
                                Name = PageModeConverter.PageMode2Name(pair.Key)
                            };
                            Create(GetObjSet<Function>(ctx), f);
                        }
                        else if (pair.Value == false && pageModes.Contains(pair.Key))
                        {
                            Function f = functions.FirstOrDefault(o => o.PageMode == pair.Key);
                            Delete(GetObjSet<Function>(ctx), f);
                        }
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

    }
}
