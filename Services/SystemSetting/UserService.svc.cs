using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using Utility.Misc;
using System.Linq;
namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : BaseService<User>, IUserService
    {
        #region IUserService Members

        public User Login(string loginName, string password)
        {
            User user;

            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    user = QueryForObj(GetObjQuery<User>(ctx), o => o.LoginName == loginName);

                    if (user != null)
                    {
                        string encryptedPsw = Encrypt.Encode(password);
                        if (user.Password.Trim() != encryptedPsw)
                        {
                            user = null;
                        }
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }

            return user;
        }

        public User AddNewUser(User user, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    User tmp = QueryForObj(GetObjQuery<User>(ctx), o => o.LoginName == user.LoginName);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.LoginNameExisted.ToString());
                    }

                    string password = Encrypt.Encode("888888");
                    user.Password = password;

                    Create(GetObjSet<User>(ctx), user);
                    ctx.SaveChanges();
                    return user;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public User UpdateUser(User user, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    User tmp = QueryForObj(GetObjQuery<User>(ctx), o => o.LoginName == user.LoginName && o.Id != user.Id);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.LoginNameExisted.ToString());
                    }

                    User oldUser = GetById(GetObjQuery<User>(ctx), user.Id);
                    oldUser.Name = user.Name;
                    oldUser.LoginName = user.LoginName;
                    oldUser.RoleId = user.RoleId;
                    oldUser.Description = user.Description;
                    oldUser.IsSales = user.IsSales;

                    ctx.SaveChanges();
                    return oldUser;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 用户金属分配
        /// </summary>
        /// <param name="commodities">已分配金属</param>
        /// <param name="userId">分配用户</param>
        public void UserCommodityLinkChange(List<Commodity> commodities, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    //删除原始数据
                    ICollection<UserCommodityLink> x = QueryForObjs(GetObjQuery<UserCommodityLink>(ctx),
                                                                    o => o.UserId == userId);
                    foreach (UserCommodityLink item in x)
                    {
                        Delete(GetObjSet<UserCommodityLink>(ctx), item);
                    }
                    //建立新数据
                    foreach (Commodity item in commodities)
                    {
                        var userCommodityLink = new UserCommodityLink {UserId = userId, CommodityId = item.Id};
                        Create(GetObjSet<UserCommodityLink>(ctx), userCommodityLink);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 用户分公司分配
        /// </summary>
        /// <param name="businessPartners">已分配分公司</param>
        /// <param name="userId">分配用户</param>
        public void UserICLinkChange(List<BusinessPartner> businessPartners, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    //删除原始数据
                    ICollection<UserICLink> x = QueryForObjs(GetObjQuery<UserICLink>(ctx), o => o.UserId == userId);
                    foreach (UserICLink item in x)
                    {
                        Delete(GetObjSet<UserICLink>(ctx), item);
                    }
                    //建立新数据
                    foreach (BusinessPartner item in businessPartners)
                    {
                        var userICLink = new UserICLink {UserId = userId, BusinessPartnerId = item.Id};
                        Create(GetObjSet<UserICLink>(ctx), userICLink);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="userId"> </param>
        public void ChangePassword(string oldPassword, string newPassword, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var user = GetById(GetObjQuery<User>(ctx), userId);

                    if (user != null)
                    {
                        string encryptedPsw = Encrypt.Encode(oldPassword);
                        if (user.Password.Trim() != encryptedPsw)
                        {
                            throw new FaultException(ErrCode.OldPasswordErr.ToString());
                        }

                        user.Password = Encrypt.Encode(newPassword);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<User> GetIsSalesUsers(int userId)
        {
            try
            {
                using(var ctx = new SenLan2Entities(userId))
                {
                    var isSalesUsers = QueryForObjs(GetObjQuery<User>(ctx, null), c => !c.IsDeleted && c.IsSales.HasValue && c.IsSales.Value);
                    return isSalesUsers.ToList();
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