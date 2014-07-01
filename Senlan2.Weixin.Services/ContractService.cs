using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;
using Services.SystemSetting;
using Services;
using Services.Physical.Contracts;

namespace Senlan2.Weixin.Services
{
    public class Wx_ContractService
    {
        CommodityService commodityService = new CommodityService();
        CommodityTypeService commodityTypeService = new CommodityTypeService();
        BrandService brandService = new BrandService();
        CurrencyService currencyService = new CurrencyService();
        ContractService contractService = new ContractService();

        public List<Commodity> GetAllCommodity(int userId)
        {
            List<Commodity> list = commodityService.GetCommoditiesByUser(userId);
            
            return list;
        }

        public List<CommodityType> GetAllCommodityTypeByCommodityId(int commodityId)
        {
            List<CommodityType> list = commodityTypeService.GetCommodityTypesByCommodity(commodityId);
            return list;
        }

        public List<Brand> GetBrand(int commodityTypeId,int commodityId)
        {
            List<Brand> list = brandService.GetBrandsWith(commodityTypeId, commodityId);
            return list;
        }

        public bool CreateContract(int userId, Contract contract,Quota quota)
        {
            try
            {
                List<Quota> quotas = new List<Quota>();
                quotas.Add(quota);
                contractService.CreateDocument(userId, contract, quotas, null, null, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Currency GetCurrencyByCode(string code)
        {
            return currencyService.GetCurrencyByCode(code);
        }
    }
}
