using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService : IService<User>
    {
        [OperationContract]
        User Login(string loginName, string password);

        [OperationContract]
        User AddNewUser(User user, int userId);

        [OperationContract]
        User UpdateUser(User user, int userId);

        [OperationContract]
        void UserCommodityLinkChange(List<Commodity> commodities, int userId);

        [OperationContract]
        void UserICLinkChange(List<BusinessPartner> businessPartners, int userId);

        [OperationContract]
        void ChangePassword(string oldPassword, string newPassword, int userId);

        [OperationContract]
        List<User> GetIsSalesUsers(int userId);
    }
}