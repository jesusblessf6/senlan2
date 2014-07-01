using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using DBEntity.EnumEntity;
using Senlan2.Weixin.Services;
using DBEntity;

namespace Senlan2.Weixin.Web.Handler
{
    /// <summary>
    /// ContractHandler 的摘要说明
    /// </summary>
    public class ContractHandler : IHttpHandler
    {
        Wx_ContractService contractService = new Wx_ContractService();
        UserService userService = new UserService();
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request["method"];
            string openId = context.Request["openId"];
            User user = userService.GetUserByOpenId(openId);
            if (user == null)
            {
                context.Response.Write("-1");
            }
            else
            {
                if (method == "save")
                {
                    DateTime today = DateTime.Today;
                    Currency cny = contractService.GetCurrencyByCode("CNY");
                    int bpId = int.Parse(context.Request["BPId"]);
                    int icId = int.Parse(context.Request["ICId"]);
                    int contractType = int.Parse(context.Request["contractType"]);
                    int commodityId = int.Parse(context.Request["com"]);
                    int commodityTypeId = int.Parse(context.Request["comType"]);
                    int brandId = int.Parse(context.Request["brand"]);
                    decimal price = decimal.Parse(context.Request["price"]);
                    decimal quantity = decimal.Parse(context.Request["quantity"]);
                    string remark = context.Request["remark"].ToString();
                    Contract contract = new Contract();
                    contract.BPId = bpId;
                    contract.InternalCustomerId = icId;
                    contract.SignDate = today;
                    contract.TradeType = (int)TradeType.ShortDomesticTrade;
                    contract.ContractType = contractType;
                    contract.Description = remark;
                    contract.Sales = user.Id;

                    Quota quota = new Quota();
                    if (brandId != 0)
                    {
                        quota.BrandId = brandId;
                    }
                    quota.CommodityId = commodityId;
                    quota.CommodityTypeId = commodityTypeId;
                    quota.PricingType = (int)PricingType.Fixed;
                    quota.Quantity = quantity;
                    quota.Price = price;
                    quota.ImplementedDate = today;
                    quota.PricingCurrencyId = cny.Id;
                    quota.VATStatus = (int)QuotaVATStatus.NotAtAll;
                    quota.FinanceStatus = false;
                    quota.DeliveryStatus = false;
                    quota.SettlementRate = 1;

                    bool flag = contractService.CreateContract(user.Id, contract, quota);
                    if (flag)
                    {
                        context.Response.Write("ok");
                    }
                    else
                    {
                        context.Response.Write("error");
                    }
                }
                else if (method == "GetCom")
                {
                    List<Commodity> list = contractService.GetAllCommodity(user.Id);
                    List<keyValuePair> kv = list.Select(o => new keyValuePair { id = o.Id, name = o.Name }).OrderBy(o=>o.id).ToList();
                    string json = GetJson(kv);
                    context.Response.Write(json);
                }
                else if (method == "GetComType")
                {
                    int commodityId = int.Parse(context.Request["comId"]);
                    List<CommodityType> list = contractService.GetAllCommodityTypeByCommodityId(commodityId);
                    List<keyValuePair> kv = list.Select(o => new keyValuePair { id = o.Id, name = o.Name }).ToList();
                    string json = GetJson(kv);
                    context.Response.Write(json);
                }
                else if (method == "GetBrand")
                {
                    int commodityId = int.Parse(context.Request["comId"]);
                    int commodityTypeId = int.Parse(context.Request["comTypeId"]);
                    List<Brand> list = contractService.GetBrand(commodityTypeId, commodityId);
                    List<keyValuePair> kv = list.Select(o => new keyValuePair { id = o.Id, name = o.Name }).ToList();
                    //if (kv.Count == 0)
                    //{
                        kv.Insert(0, new keyValuePair { id = 0, name = "无" });
                    //}
                    string json = GetJson(kv);
                    context.Response.Write(json);
                }
            }
        }

        private string GetJson(List<keyValuePair> list)
        {
            StringWriter sw = new StringWriter();
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.None;

                writer.WriteStartArray();

                foreach (var l in list)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("id");
                    writer.WriteValue(l.id);

                    writer.WritePropertyName("name");
                    writer.WriteValue(l.name);

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();

                writer.Flush();
                sw.Close();
            }
            return sw.GetStringBuilder().ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class keyValuePair
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}