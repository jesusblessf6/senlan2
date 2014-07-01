using System.Collections.Generic;
using System.Linq;
using DBEntity;
using Services.Base;
using DBEntity.EnumEntity;

namespace Services.Physical.WarehouseOuts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PSQuotaRelService" in code, svc and config file together.
    public class PSQuotaRelService : BaseService<PSQuotaRel>, IPSQuotaRelService
    {
        private bool _isDelete;
        public bool IsDelete
        {
            get
            {
                return _isDelete;
            }
            set
            {
                _isDelete = value;
            }
        }
        public List<PSQuotaTempClass> GetPQuotaId(int sQuotaId, int userId)
        {
            var list = GetPurchaseQuotasBySalesQuota(userId, sQuotaId);
            return list;
        }

        public void SetPSQuotaRel(int sQuotaId, int userId)
        {
            var list = GetPurchaseQuotasBySalesQuota(userId, sQuotaId);
            RemovePSQuotaRel(sQuotaId, userId);
            foreach (var item in list)
            {
                //int pQuotaId = item.PQuotaId;
                //decimal qty = item.Value;
                CreatePSQuotaRel(item, sQuotaId, userId);
                SetRelStrBySaleQuotaId(userId, sQuotaId);
            }
            //if (IsDelete)
            //{
            //    //删除
            //    SetRelStrBySaleQuotaIdWithDelete(userId, sQuotaId);
            //}
        }



        /// <summary>
        /// 删除关系表
        /// </summary>
        /// <param name="sQuotaId"></param>
        /// <param name="userId"></param>
        private void RemovePSQuotaRel(int sQuotaId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<PSQuotaRel> quotaRels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.SQuotaId == sQuotaId).ToList();
                foreach (var quotaRel in quotaRels)
                {
                    quotaRel.IsDeleted = true;
                    Update(GetObjSet<PSQuotaRel>(ctx), quotaRel);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 新增采购销售批次对应关系
        /// </summary>
        /// <param name="pQuotaId"></param>
        /// <param name="sQuotaId"></param>
        /// <param name="qty"></param>
        /// <param name="userId"></param>
        private void CreatePSQuotaRel(PSQuotaTempClass temp, int sQuotaId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var rel = new PSQuotaRel { PQuotaId = temp.PQuotaId, SQuotaId = sQuotaId, P2SQuantity = temp.Qty,P2SVerQuantity = temp.VerQty };
                Create(GetObjSet<PSQuotaRel>(ctx), rel);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 根据销售批次找采购批次
        /// </summary>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        private List<PSQuotaTempClass> GetPurchaseQuotasBySalesQuota(int userId, int quotaId)
        {
            var list = new List<PSQuotaTempClass>();

            const string countCondition = "it.QuotaId = @p1 ";
            string countCondition1 = "it.QuotaId = @p1 and (it.DeliveryType=" + (int)DeliveryType.ExternalMDBOL + " or it.DeliveryType=" + (int)DeliveryType.ExternalMDWW + " or it.DeliveryType=" + (int)DeliveryType.InternalMDBOL + " or it.DeliveryType=" + (int)DeliveryType.InternalMDWW + ")";
            var countParams = new List<object> { quotaId };
            int deliveryCount = GetCount<Delivery>(countCondition1, countParams);
            int warehouseOutCount = GetCount<WarehouseOut>(countCondition, countParams);

            using (var ctx = new SenLan2Entities(userId))
            {
                if (deliveryCount > 0)
                {
                    //有发货单:销售批次--发货单--提单--采购批次
                    //发货单
                    List<Delivery> deliveries =
                        QueryForObjs(GetObjQuery<Delivery>(ctx, new List<string> { "DeliveryLines" }), o => o.QuotaId == quotaId).ToList();
                    foreach (Delivery delivery in deliveries)
                    {
                        Delivery tDelivery;
                        decimal dividedQuantity;
                        decimal dividedVerQty;
                        EntityUtil.FilterDeletedEntity(delivery.DeliveryLines);

                        if (delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW)
                        {
                            //内贸发货单
                            dividedQuantity = (decimal)delivery.DeliveryLines.Sum(o => o.NetWeight);
                            dividedVerQty = (decimal)delivery.DeliveryLines.Sum(o => o.VerifiedWeight);
                            int tdLineId = delivery.DeliveryLines[0].TDeliveryLineId.Value;

                            DeliveryLine tdLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == tdLineId);

                            tDelivery = QueryForObj(GetObjQuery<Delivery>(ctx,
                                                          new List<string>
                                                          {
                                                              "Quota",
                                                              "Quota.Contract.BusinessPartner",
                                                              "Quota.Commodity",
                                                              "Quota.Brand",
                                                              "Quota.Currency",
                                                              "Quota.QuotaBrandRels",
                                                              "Quota.QuotaBrandRels.Brand"
                                                          }), o => o.Id == tdLine.DeliveryId);
                        }
                        else
                        {
                            //外贸发货单
                            dividedQuantity = (decimal)delivery.DeliveryLines.Sum(o => o.GrossWeight);
                            dividedVerQty = (decimal)delivery.DeliveryLines.Sum(o => o.NetWeight);
                            int tdLineId = delivery.DeliveryLines[0].TDeliveryLineId.Value;

                            DeliveryLine tdLine = QueryForObj(GetObjQuery<DeliveryLine>(ctx), o => o.Id == tdLineId);

                            tDelivery = QueryForObj(GetObjQuery<Delivery>(ctx,
                                                     new List<string>
                                                          {
                                                              "Quota",
                                                              "Quota.Contract.BusinessPartner",
                                                              "Quota.Commodity",
                                                              "Quota.Brand",
                                                              "Quota.Currency",
                                                              "Quota.QuotaBrandRels",
                                                              "Quota.QuotaBrandRels.Brand"
                                                          }), o => o.Id == tdLine.DeliveryId);
                        }


                        Quota quota = tDelivery.Quota;
                        PSQuotaTempClass temp = list.Where(o => o.PQuotaId == quota.Id).FirstOrDefault();
                        if (temp != null)
                        {
                            temp.Qty += dividedQuantity;
                            temp.VerQty += dividedVerQty;
                        }
                        else
                        {
                            PSQuotaTempClass t = new PSQuotaTempClass();
                            t.PQuotaId = quota.Id;
                            t.Qty = dividedQuantity;
                            t.VerQty = dividedVerQty;
                            list.Add(t);
                        }
                        //if (list.ContainsKey(quota.Id))
                        //{
                        //    list[quota.Id] += dividedQuantity;
                        //}
                        //else
                        //{
                        //    list.Add(quota.Id, dividedQuantity);
                        //}
                    }
                }

                if (warehouseOutCount > 0)
                {
                    //有出库：销售批次--出库--出库行--入库行--提单行--提单--采购批次
                    List<WarehouseOutLine> outLines =
                       QueryForObjs(
                           GetObjQuery<WarehouseOutLine>(ctx,
                                                         new List<string>
                                                              {
                                                                  "WarehouseOut",
                                                                  "WarehouseInLine",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.Contract.BusinessPartner",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.Commodity",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.Brand",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.Currency",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.QuotaBrandRels",
                                                                  "WarehouseInLine.DeliveryLine.Delivery.Quota.QuotaBrandRels.Brand"
                                                              }), o => o.WarehouseOut.QuotaId == quotaId).ToList();

                    foreach (var warehouseOutLine in outLines)
                    {
                        Quota quota = warehouseOutLine.WarehouseInLine.DeliveryLine.Delivery.Quota;
                        if (warehouseOutLine.VerifiedQuantity.HasValue || warehouseOutLine.Quantity.HasValue)
                        {
                            PSQuotaTempClass temp = list.Where(o => o.PQuotaId == quota.Id).FirstOrDefault();
                            if (temp != null)
                            {
                                //累计
                                temp.Qty += warehouseOutLine.Quantity ?? 0;
                                temp.VerQty += warehouseOutLine.VerifiedQuantity ?? 0;
                            }
                            else
                            {
                                //只有出库
                                PSQuotaTempClass t = new PSQuotaTempClass();
                                t.PQuotaId = quota.Id;
                                t.Qty = warehouseOutLine.Quantity ?? 0;
                                t.VerQty = warehouseOutLine.VerifiedQuantity ?? 0;
                                list.Add(t);
                            }
                            //if (list.ContainsKey(quota.Id))
                            //{
                            //    //累计
                                
                            //    list[quota.Id] += warehouseOutLine.VerifiedQuantity.Value;
                            //}
                            //else
                            //{
                            //    //只有出库
                            //    list.Add(quota.Id, warehouseOutLine.VerifiedQuantity.Value);
                            //}
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 根据销售批次找到对应的所有的采购批次Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        private List<int> GetPurchaseQuotaIdListBySalesQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                List<PSQuotaRel> psQuotaRels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.SQuotaId == quotaId).ToList();
                List<int> pQuotaIds = psQuotaRels.Select(o => o.PQuotaId).Distinct().ToList();
                List<int> pIds = new List<int>();
                foreach (var id in pQuotaIds)
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == id);
                    if (quota.RelQuotaId.HasValue)
                    {
                        quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quota.RelQuotaId.Value);
                    }
                    if (!pIds.Contains(quota.Id))
                    {
                        pIds.Add(quota.Id);
                    }
                }
                return pIds;
            }
        }

        /// <summary>
        /// 根据采购批次找到对应的所有的销售批次Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="quotaId"></param>
        /// <returns></returns>
        private List<int> GetSaleQuotaIdListByPurchaseQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                List<Quota> quotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract" }), o => o.RelQuotaId == quotaId &&
                    o.Contract.ContractType == (int)ContractType.Purchase && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).OrderByDescending(o => o.RelQuotaStage).ToList();
                if (quotas.Count > 0)
                {
                    quota = quotas[0];
                }

                List<PSQuotaRel> psQuotaRels = QueryForObjs(GetObjQuery<PSQuotaRel>(ctx), o => o.PQuotaId == quota.Id).ToList();
                List<int> sQuotaIds = psQuotaRels.Select(o => o.SQuotaId).Distinct().ToList();
                return sQuotaIds;
            }
        }

        public void SetRelStrBySaleQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota saleQuota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract.InternalCustomer", "Contract.BusinessPartner" }),
                    o => o.Id == quotaId);
                if (saleQuota.RelQuotaId.HasValue)
                    return;
                List<int> purchaseQuotaIds = GetPurchaseQuotaIdListBySalesQuotaId(userId, quotaId);
                string saleRelQuotaStr = string.Empty;
                List<string> saleRelStrs = new List<string>();
                foreach (var purchaseQuotaId in purchaseQuotaIds)
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == purchaseQuotaId);
                    if (quota.RelQuotaId.HasValue)
                        continue;
                    string relQuotaStr = string.Empty;
                    List<string> relStrs = new List<string>();
                    string s = GetRelStr(userId, purchaseQuotaId);
                    List<int> saleQuotaIds = GetSaleQuotaIdListByPurchaseQuotaId(userId, purchaseQuotaId);
                    foreach (var saleQuotaId in saleQuotaIds)
                    {
                        string str = s + "->" + GetRelStr(userId, saleQuotaId);
                        if (!relStrs.Contains(str))
                        {
                            relStrs.Add(str);
                        }
                        if (saleQuota != null)
                        {
                            if (quotaId == saleQuotaId)
                            {
                                if (!saleRelStrs.Contains(str))
                                {
                                    saleRelStrs.Add(str);
                                }
                            }
                        }
                    }
                    foreach (var relStr in relStrs)
                    {
                        if (relQuotaStr.Length > 0)
                        {
                            relQuotaStr += "/";
                        }
                        relQuotaStr += relStr;
                    }
                    Quota purchaseQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == purchaseQuotaId);
                    purchaseQuota.RelQuotaStr = relQuotaStr;
                    Update(GetObjSet<Quota>(ctx), purchaseQuota);
                    List<Quota> purchaseQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == purchaseQuota.Id).ToList();
                    foreach (var q in purchaseQuotas)
                    {
                        q.RelQuotaStr = relQuotaStr;
                        Update(GetObjSet<Quota>(ctx), q);
                    }
                }
                if (saleQuota != null)
                {
                    foreach (var relStr in saleRelStrs)
                    {
                        if (saleRelQuotaStr.Length > 0)
                        {
                            saleRelQuotaStr += "/";
                        }
                        saleRelQuotaStr += relStr;
                    }

                    if (saleRelStrs.Count == 0)
                    {
                        saleRelQuotaStr = saleQuota.Contract.InternalCustomer.ShortName 
                            + "->" + saleQuota.Contract.BusinessPartner.ShortName;
                    }

                    saleQuota.RelQuotaStr = saleRelQuotaStr;
                    Update(GetObjSet<Quota>(ctx), saleQuota);
                }
                ctx.SaveChanges();
            }
        }

        public void SetRelStrByPurchaseQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota purchaseQuota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == quotaId);
                if (purchaseQuota.RelQuotaId.HasValue)
                    return;
                string saleRelQuotaStr = string.Empty;
                List<string> saleRelStrs = new List<string>();
                string relQuotaStr = string.Empty;
                List<string> relStrs = new List<string>();
                string s = GetRelStr(userId, quotaId);
                List<int> saleQuotaIds = GetSaleQuotaIdListByPurchaseQuotaId(userId, quotaId);
                foreach (var saleQuotaId in saleQuotaIds)
                {
                    string str = s + "->" + GetRelStr(userId, saleQuotaId);
                    if (!relStrs.Contains(str))
                    {
                        relStrs.Add(str);
                    }
                }
                foreach (var relStr in relStrs)
                {
                    if (relQuotaStr.Length > 0)
                    {
                        relQuotaStr += "/";
                    }
                    relQuotaStr += relStr;
                }
                if (relQuotaStr == string.Empty)
                {
                    relQuotaStr = GetRelStr(userId, quotaId);
                }
                purchaseQuota.RelQuotaStr = relQuotaStr;
                Update(GetObjSet<Quota>(ctx), purchaseQuota);
                List<Quota> purchaseQuotas = QueryForObjs(GetObjQuery<Quota>(ctx), o => o.RelQuotaId == purchaseQuota.Id).ToList();
               
                foreach (var q in purchaseQuotas)
                {
                    q.RelQuotaStr = relQuotaStr;
                    Update(GetObjSet<Quota>(ctx), q);
                }
                ctx.SaveChanges();
            }
        }

        private string GetRelStr(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                string str = string.Empty;
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Contract.BusinessPartner", "Contract.InternalCustomer" }),
                    o => o.Id == quotaId);
                if (quota.Contract.ContractType == (int)ContractType.Sales)
                {
                    //销售批次,返回下家的业务伙伴
                    str = quota.Contract.BusinessPartner.ShortName + " " + (quota.FinalPrice.HasValue ? quota.FinalPrice.Value.ToString(RoundRules.STR_PRICE) : "");
                }
                else
                {
                    //采购批次
                    if (quota.RelQuotaId.HasValue)
                    {
                        quota = QueryForObj(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Contract.InternalCustomer", "Contract.BusinessPartner" }),
                            o => o.Id == quota.RelQuotaId.Value);
                    }
                    List<Quota> relQuotas = QueryForObjs(GetObjQuery<Quota>(ctx, new List<string> { "Contract", "Contract.InternalCustomer" }),
                        o => o.RelQuotaId == quota.Id && o.Contract.TradeType == (int)TradeType.ShortDomesticTrade).ToList();
                    str = quota.Contract.BusinessPartner.ShortName + "->" + quota.Contract.InternalCustomer.ShortName + " " + (quota.FinalPrice.HasValue ? quota.FinalPrice.Value.ToString(RoundRules.STR_PRICE) : "");
                    if (relQuotas.Count > 0)
                    {
                        //有流转
                        List<Quota> purchaseQuotas = relQuotas.Where(o => o.Contract.ContractType == (int)ContractType.Purchase)
                            .OrderBy(o => o.RelQuotaStage).ToList();
                        foreach (var q in purchaseQuotas)
                        {
                            str += "->" + q.Contract.InternalCustomer.ShortName + " " + (q.FinalPrice.HasValue ? q.FinalPrice.Value.ToString(RoundRules.STR_PRICE) : "");
                        }
                    }
                }
                return str;
            }
        }

        public void SetRelStrByQuotaId(int userId, int quotaId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Quota quota = QueryForObj(GetObjQuery<Quota>(ctx,new List<string>{"Contract"}), o => o.Id == quotaId);
                if (quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    //采购批次
                    SetRelStrByPurchaseQuotaId(userId, quotaId);
                }
                else
                { 
                    //销售批次
                    SetRelStrBySaleQuotaId(userId, quotaId);
                }
            }
        }
    }

    public class PSQuotaTempClass
    {
        public int PQuotaId { get; set; }
        public decimal VerQty { get; set; }
        public decimal Qty { get; set; }
    }
}
