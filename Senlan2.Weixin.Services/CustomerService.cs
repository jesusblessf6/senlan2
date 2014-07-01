using DBEntity;
using DBEntity.EnumEntity;
using Services.SystemSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senlan2.Weixin.Services
{
    public class CustomerService
    {
        public List<BusinessPartner> GetInternalCustomersByUserId(int userId)
        {
            BusinessPartnerService bpService = new BusinessPartnerService();
            return bpService.GetInternalCustomersByUser(userId);
        }

        public List<BusinessPartner> GetAll(string name)
        {
            BusinessPartnerService bpService = new BusinessPartnerService();
            List<BusinessPartner> list = new List<BusinessPartner>();
            List<object> parameters = new List<object>();
            string queryStr = "it.IsDeleted = false and (it.ApproveStatus = " + (int)ApproveStatus.Approved + " or it.ApproveStatus = " + (int)ApproveStatus.NoApproveNeeded + ")";
            if (!string.IsNullOrEmpty(name))
            {
                queryStr += " and it.ShortName Like @p1";
                parameters.Add("%" + name + "%");
            }
            list = bpService.Query(queryStr, parameters.Count > 0 ? parameters : null).ToList();
            return list;
        }
    }
}
