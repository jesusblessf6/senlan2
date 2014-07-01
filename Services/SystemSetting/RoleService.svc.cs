using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoleService" in code, svc and config file together.
    public class RoleService : BaseService<Role>, IRoleService
    {
        #region IRoleService Members

        public List<Function> GetRolesFunctions(int roleId)
        {
            var functions = new List<Function>();

            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var includes = new List<string> {"Function"};

                    List<RoleFunctionLink> roleFuncLinks =
                        QueryForObjs(GetObjQuery<RoleFunctionLink>(ctx, includes),
                                     o => o.RoleId == roleId).ToList();

                    functions.AddRange(roleFuncLinks.Select(l => l.Function));
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }

            return functions;
        }

        public bool UpdatePerms(List<RoleFunctionLink> links, int roleId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<RoleFunctionLink> oldLinks =
                        QueryForObjs(GetObjQuery<RoleFunctionLink>(ctx), o => o.RoleId == roleId).ToList();
                    foreach (RoleFunctionLink r in oldLinks)
                    {
                        Delete(GetObjSet<RoleFunctionLink>(ctx), r.Id);
                    }

                    ctx.SaveChanges();

                    foreach (RoleFunctionLink r in links)
                    {
                        Create(GetObjSet<RoleFunctionLink>(ctx), r);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }

            return true;
        }

        public List<Function> GetPermsByRole(int roleId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    List<RoleFunctionLink> links = QueryForObjs(
                        GetObjQuery<RoleFunctionLink>(ctx,
                                                      new List<string>
                                                          {"Function", "Function.Module", "Function.Module.Category"}),
                        o => o.RoleId == roleId).ToList();

                    return links.Select(o => o.Function).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Role AddNewRole(Role role, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObj(GetObjQuery<Role>(ctx), o => o.Name == role.Name);
                    if(tmp != null)
                    {
                        throw new FaultException(ErrCode.RoleNameExisted.ToString());
                    }
                    Create(GetObjSet<Role>(ctx), role);
                    ctx.SaveChanges();
                    return role;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public Role UpdateRole(Role role, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObj(GetObjQuery<Role>(ctx), o => o.Name == role.Name && o.Id != role.Id);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.RoleNameExisted.ToString());
                    }

                    var oldRole = QueryForObj(GetObjQuery<Role>(ctx), o => o.Id == role.Id);
                    oldRole.Description = role.Description;
                    oldRole.Name = role.Name;
                    ctx.SaveChanges();
                    return oldRole;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion
    }
}