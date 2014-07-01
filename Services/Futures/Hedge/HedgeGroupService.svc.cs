using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Services.Helper.HedgeGroupHelper;
using Services.Helper.MarketPrice;
using Utility.ErrorManagement;
using Utility.Misc;
using Services.Physical.Contracts;

namespace Services.Futures.Hedge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HedgeGroupService" in code, svc and config file together.
    public class HedgeGroupService : BaseService<HedgeGroup>, IHedgeGroupService
    {
        #region Method implemeting the interface

        /// <summary>
        /// Get the quota lines in hedge group by group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<HedgeLineQuota> GetQuotasInHedgeGroup(int groupId, List<string> includes)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<HedgeLineQuota>(ctx, includes), o => o.HedgeGroupId == groupId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Get the LME Position lines in hedge group by group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<HedgeLineLMEPosition> GetLMEsInHedgeGroup(int groupId, List<string> includes)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<HedgeLineLMEPosition>(ctx, includes), o => o.HedgeGroupId == groupId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Get the SHFE Position lines in hedge group by group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<HedgeLineSHFEPosition> GetSHFEsInHedgeGroup(int groupId, List<string> includes)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObjs(GetObjQuery<HedgeLineSHFEPosition>(ctx, includes), o => o.HedgeGroupId == groupId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Create new hedge group
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="quotas"></param>
        /// <param name="lmes"></param>
        /// <param name="shfes"></param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public int CreateHedgeGroup(HedgeGroup hg, List<HedgeLineQuota> quotas, List<HedgeLineLMEPosition> lmes,
                             List<HedgeLineSHFEPosition> shfes, int userId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var hgId = CreateHedgeGroupHeader(hg, userId);
                    CreateHedgeGroupQuotaLines(quotas, hgId, userId);
                    CreateHedgeGroupLMEPositionLines(lmes, hgId, userId);
                    CreateHedgeGroupSHFEPositionLines(shfes, hgId, userId);
                    CalculateBreakEvenSpread(hgId, userId);
                    ts.Complete();

                    return hgId;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Calculate the break even spread for the hedge
        /// </summary>
        /// <param name="hgId"></param>
        /// <param name="userId"></param>
        private void CalculateBreakEvenSpread(int hgId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var hg = QueryForObj(GetObjQuery<HedgeGroup>(ctx), o => o.Id == hgId);
                var handlor = BreakEvenSpreadHandlorFactory.GetHandlor(hg);
                if (handlor != null)
                {
                    handlor.Handle(hg, ctx);
                    ctx.SaveChanges();
                }
                else
                {
                    hg.StopLossSpread = null;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update the Hedge Group
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="newQuotas"></param>
        /// <param name="deletedQuotas"></param>
        /// <param name="updatedLmes"></param>
        /// <param name="newLmes"></param>
        /// <param name="deletedLmes"></param>
        /// <param name="updatedShfes"></param>
        /// <param name="newShfes"></param>
        /// <param name="deletedShfes"></param>
        /// <param name="userId"> </param>
        public void UpdateHedgeGroup(HedgeGroup hg, List<HedgeLineQuota> newQuotas,
                              List<HedgeLineQuota> deletedQuotas,
                              List<HedgeLineLMEPosition> updatedLmes, List<HedgeLineLMEPosition> newLmes,
                              List<HedgeLineLMEPosition> deletedLmes,
                              List<HedgeLineSHFEPosition> updatedShfes, List<HedgeLineSHFEPosition> newShfes,
                              List<HedgeLineSHFEPosition> deletedShfes, int userId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    if (hg.Status == (int)HedgeGroupStatus.Settled)
                    {
                        throw new FaultException(ErrCode.HedgeGroupSettledNotForModify.ToString());
                    }

                    UpdateHedgeGroupHeader(hg, userId);
                    CreateHedgeGroupQuotaLines(newQuotas, hg.Id, userId);
                    DeleteHedgeGroupQuotaLines(deletedQuotas, userId);
                    CreateHedgeGroupLMEPositionLines(newLmes, hg.Id, userId);
                    UpdateHedgeGroupLMEPositionLines(updatedLmes, userId);
                    DeleteHedgeGroupLMEPositionLines(deletedLmes, userId);
                    CreateHedgeGroupSHFEPositionLines(newShfes, hg.Id, userId);
                    UpdateHedgeGroupSHFEPositionLines(updatedShfes, userId);
                    DeleteHedgeGroupSHFEPositionLines(deletedShfes, userId);
                    CalculateBreakEvenSpread(hg.Id, userId);
                    ts.Complete();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the header of the hedge group
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private int CreateHedgeGroupHeader(HedgeGroup hg, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var newhg = new HedgeGroup { Name = hg.Name, HedgeDate = hg.HedgeDate, Rate = hg.Rate, Status = (int)HedgeGroupStatus.NotSettled, ArbitrageType = hg.ArbitrageType };
                Create(GetObjSet<HedgeGroup>(ctx), newhg);
                ctx.SaveChanges();
                return newhg.Id;
            }
        }

        /// <summary>
        /// Update the header of the hedge group
        /// </summary>
        /// <param name="hg"></param>
        /// <param name="userId"></param>
        public void UpdateHedgeGroupHeader(HedgeGroup hg, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var header = QueryForObj(GetObjQuery<HedgeGroup>(ctx), o => o.Id == hg.Id);
                if (header == null)
                {
                    throw new FaultException(ErrCode.HedgeGroupNotFound.ToString());
                }

                header.Name = hg.Name;
                header.HedgeDate = hg.HedgeDate;
                header.Rate = hg.Rate;
                //编辑保存的时候清空盈亏字段
                header.PLAmount = 0;
                header.SHFEFixedPL = 0;
                header.SHFEFloatPL = 0;
                header.LMEFixedPL = 0;
                header.LMEFloatPL = 0;
                header.PhyFixedPL = 0;
                header.PhyFloatPL = 0;

                header.PLCurrencyId = hg.PLCurrencyId;
                header.Status = (int)HedgeGroupStatus.NotSettled;
                header.ArbitrageType = hg.ArbitrageType;

                ctx.SaveChanges();
            }
        }

        public void UpdatehedgeGroupPL(HedgeGroup hg, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                var header = QueryForObj(GetObjQuery<HedgeGroup>(ctx), o => o.Id == hg.Id);
                if (header == null)
                {
                    throw new FaultException(ErrCode.HedgeGroupNotFound.ToString());
                }

                header.PLAmount = hg.PLAmount;
                header.PhyFixedPL = hg.PhyFixedPL;
                header.SHFEFixedPL = hg.SHFEFixedPL;
                header.LMEFixedPL = hg.LMEFixedPL;
                header.PLCurrencyId = hg.PLCurrencyId;
                header.Status = hg.Status;
                header.StopLossSpread = null;

                ctx.SaveChanges();
            }
        }

        public List<HedgeGroupFloatPNLLine> SelectHedgeGroupPNLLine(string predicate, List<object> parameters, int from, int to, SortCol sortCol, int userId)
        {
            if (sortCol == null)
            {
                sortCol = new SortCol
                              {
                                  ColName = "HedgeDate",
                                  ByDescending = true
                              };
            }
            var hgs = SelectByRangeWithOrder(predicate, parameters, sortCol, from, to,
                                   new Collection<string>
                                       {
                                           "HedgeLineQuotas",
                                           "HedgeLineQuotas.Quota",
                                           "HedgeLineQuotas.Quota.Commodity",
                                           "HedgeLineQuotas.Quota.Contract",
                                           "HedgeLineQuotas.Quota.Pricings",
                                           "HedgeLineQuotas.Quota.UnPricings",
                                           "HedgeLineSHFEPositions",
                                           "HedgeLineSHFEPositions.SHFEPosition",
                                           "HedgeLineSHFEPositions.SHFEPosition.SHFECapitalDetail",
                                           "HedgeLineSHFEPositions.SHFEPosition.Commodity",
                                           "HedgeLineLMEPositions",
                                           "HedgeLineLMEPositions.LMEPosition",
                                           "HedgeLineLMEPositions.LMEPosition.Commodity"
                                       });

            var result = new List<HedgeGroupFloatPNLLine>();
            foreach (var hg in hgs)
            {
                if (hg.Status == (int)HedgeGroupStatus.Settled)
                {
                    result.Add(new HedgeGroupFloatPNLLine
                                   {
                                       HedgeDate = hg.HedgeDate,
                                       HedgeTypeId = hg.ArbitrageType,
                                       HedgeStatusId = hg.Status,
                                       Id = hg.Id,
                                       LMEFixedPNL = hg.LMEFixedPL,
                                       LMEFloatPNL = hg.LMEFloatPL,
                                       Name = hg.Name,
                                       PhysicalFixedPNL = hg.PhyFixedPL,
                                       PhysicalFloatPNL = hg.PhyFloatPL,
                                       SHFEFixedPNL = hg.SHFEFixedPL,
                                       SHFEFloatPNL = hg.SHFEFloatPL,
                                       TotalPNL = hg.PLAmount,
                                       BreakEvenSpread = hg.StopLossSpread
                                   });
                }
                else
                {
                    var tmp = new HedgeGroupFloatPNLLine
                    {
                        Id = hg.Id,
                        Name = hg.Name,
                        HedgeDate = hg.HedgeDate,
                        HedgeTypeId = hg.ArbitrageType,
                        HedgeStatusId = hg.Status,
                        BreakEvenSpread = hg.StopLossSpread
                    };

                    if (hg.Rate == null)
                    {
                        using (var ctx = new SenLan2Entities())
                        {
                            var rate = QueryForObj(GetObjQuery<Rate>(ctx, new List<string> { "Currency" }),
                                                   o => o.Currency.Code == "USD");
                            hg.Rate = rate.RateValue;
                        }
                    }

                    decimal fixPnl, floatPnl, totalPnl = 0;
                    GetQuotaPNLByQuota(hg, userId, out fixPnl, out floatPnl);
                    totalPnl += fixPnl + floatPnl;
                    tmp.PhysicalFixedPNL = fixPnl;
                    tmp.PhysicalFloatPNL = floatPnl;

                    GetLMEPositionPNL(hg, out fixPnl, out floatPnl);
                    totalPnl += fixPnl * (hg.Rate ?? 1) + floatPnl * (hg.Rate ?? 1);
                    tmp.LMEFixedPNL = fixPnl;
                    tmp.LMEFloatPNL = floatPnl;

                    GetSHFEPositionPNL(hg, out fixPnl, out floatPnl);
                    totalPnl += fixPnl + floatPnl;
                    tmp.SHFEFixedPNL = fixPnl;
                    tmp.SHFEFloatPNL = floatPnl;

                    tmp.TotalPNL = totalPnl;

                    result.Add(tmp);
                }
            }

            return result;
        }

        /// <summary>
        /// Create the hedge group line of quotas
        /// </summary>
        /// <param name="quotas"></param>
        /// <param name="hgId"> </param>
        /// <param name="userId"></param>
        private void CreateHedgeGroupQuotaLines(IEnumerable<HedgeLineQuota> quotas, int hgId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineQuota in quotas)
                {
                    HedgeLineQuota lineQuota = hedgeLineQuota;

                    var line = new HedgeLineQuota
                    {
                        HedgeGroupId = hgId,
                        QuotaId = lineQuota.QuotaId,
                        AssignedQuantity = lineQuota.AssignedQuantity
                    };
                    Create(GetObjSet<HedgeLineQuota>(ctx), line);

                    var quota = QueryForObj(GetObjQuery<Quota>(ctx), o => o.Id == lineQuota.QuotaId);
                    if (quota == null)
                    {
                        throw new FaultException(ErrCode.QuotaNotExisted.ToString());
                    }

                    quota.IsHedged = true;

                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// delete the removed quota lines in hedge group
        /// </summary>
        /// <param name="deletedQuotas"></param>
        /// <param name="userId"> </param>
        private void DeleteHedgeGroupQuotaLines(IEnumerable<HedgeLineQuota> deletedQuotas, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineQuota in deletedQuotas)
                {
                    int quotaId = hedgeLineQuota.QuotaId;
                    Delete(GetObjSet<HedgeLineQuota>(ctx), hedgeLineQuota.Id);

                    var quota = GetById(GetObjQuery<Quota>(ctx), quotaId);
                    if (quota == null)
                    {
                        throw new FaultException(ErrCode.QuotaNotExisted.ToString());
                    }

                    quota.IsHedged = false;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Create Hedge Group Line of LME Position
        /// </summary>
        /// <param name="lmes"></param>
        /// <param name="hgId"></param>
        /// <param name="userId"></param>
        private void CreateHedgeGroupLMEPositionLines(IEnumerable<HedgeLineLMEPosition> lmes, int hgId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineLMEPosition in lmes)
                {
                    var lineLme = hedgeLineLMEPosition;

                    var line = new HedgeLineLMEPosition
                    {
                        LMEPositionId = lineLme.LMEPositionId,
                        HedgeGroupId = hgId,
                        AssignedLotAmount = lineLme.AssignedLotAmount,
                        AssignedCommission = lineLme.AssignedCommission
                    };
                    Create(GetObjSet<HedgeLineLMEPosition>(ctx), line);

                    var lme = QueryForObj(GetObjQuery<LMEPosition>(ctx), o => o.Id == lineLme.LMEPositionId);
                    if (lme == null)
                    {
                        throw new FaultException(ErrCode.LMEPositionNotFound.ToString());
                    }

                    lme.HedgedLotQuantity += lineLme.AssignedLotAmount;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update the lme position lines in hedge group
        /// </summary>
        /// <param name="lmes"></param>
        /// <param name="userId"></param>
        private void UpdateHedgeGroupLMEPositionLines(IEnumerable<HedgeLineLMEPosition> lmes, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineLMEPosition in lmes)
                {
                    var lineLme = hedgeLineLMEPosition;
                    var lme = QueryForObj(GetObjQuery<HedgeLineLMEPosition>(ctx), o => o.Id == lineLme.Id);
                    if (lme == null)
                    {
                        throw new FaultException(ErrCode.HedgeGroupLineLMEPositionNotFound.ToString());
                    }

                    decimal deltaQty = lineLme.AssignedLotAmount - lme.AssignedLotAmount;
                    if (Math.Round(deltaQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                    {
                        continue;
                    }

                    lme.AssignedLotAmount = lineLme.AssignedLotAmount;
                    lme.AssignedCommission = lineLme.AssignedCommission;
                    ctx.SaveChanges();

                    var p = QueryForObj(GetObjQuery<LMEPosition>(ctx), o => o.Id == lineLme.LMEPositionId);
                    if (p == null)
                    {
                        throw new FaultException(ErrCode.LMEPositionNotFound.ToString());
                    }

                    p.HedgedLotQuantity += deltaQty;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete the lme position lines in hedge group
        /// </summary>
        /// <param name="lmes"></param>
        /// <param name="userId"></param>
        private void DeleteHedgeGroupLMEPositionLines(IEnumerable<HedgeLineLMEPosition> lmes, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineLMEPosition in lmes)
                {
                    var lineLme = hedgeLineLMEPosition;
                    decimal deltaQty = lineLme.AssignedLotAmount;

                    Delete(GetObjSet<HedgeLineLMEPosition>(ctx), lineLme.Id);
                    ctx.SaveChanges();

                    var p = QueryForObj(GetObjQuery<LMEPosition>(ctx), o => o.Id == lineLme.LMEPositionId);
                    if (p == null)
                    {
                        throw new FaultException(ErrCode.LMEPositionNotFound.ToString());
                    }

                    p.HedgedLotQuantity -= deltaQty;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Create Hedge Group Line of SHFE Position
        /// </summary>
        /// <param name="shfes"></param>
        /// <param name="hgId"></param>
        /// <param name="userId"></param>
        private void CreateHedgeGroupSHFEPositionLines(IEnumerable<HedgeLineSHFEPosition> shfes, int hgId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineSHFEPosition in shfes)
                {
                    var lineShfe = hedgeLineSHFEPosition;

                    var line = new HedgeLineSHFEPosition
                    {
                        SHFEPositionId = lineShfe.SHFEPositionId,
                        HedgeGroupId = hgId,
                        AssignedLotAmount = lineShfe.AssignedLotAmount,
                        AssignedCommission = lineShfe.AssignedCommission
                    };
                    Create(GetObjSet<HedgeLineSHFEPosition>(ctx), line);

                    var shfe = QueryForObj(GetObjQuery<SHFEPosition>(ctx), o => o.Id == lineShfe.SHFEPositionId);
                    if (shfe == null)
                    {
                        throw new FaultException(ErrCode.SHFEPositionNotFound.ToString());
                    }

                    shfe.HedgedLotQuantity = lineShfe.AssignedLotAmount + (shfe.HedgedLotQuantity ?? 0);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update Hedge Group Line of SHFE Position
        /// </summary>
        /// <param name="shfes"></param>
        /// <param name="userId"></param>
        private void UpdateHedgeGroupSHFEPositionLines(IEnumerable<HedgeLineSHFEPosition> shfes, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineSHFEPosition in shfes)
                {
                    var lineShfe = hedgeLineSHFEPosition;
                    var shfe = QueryForObj(GetObjQuery<HedgeLineSHFEPosition>(ctx), o => o.Id == lineShfe.Id);
                    if (shfe == null)
                    {
                        throw new FaultException(ErrCode.HedgeGroupLineSHFEPositionNotFound.ToString());
                    }

                    decimal deltaQty = lineShfe.AssignedLotAmount - shfe.AssignedLotAmount;
                    if (Math.Round(deltaQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                    {
                        continue;
                    }

                    shfe.AssignedLotAmount = lineShfe.AssignedLotAmount;
                    shfe.AssignedCommission = lineShfe.AssignedCommission;
                    ctx.SaveChanges();

                    var p = QueryForObj(GetObjQuery<SHFEPosition>(ctx), o => o.Id == lineShfe.SHFEPositionId);
                    if (p == null)
                    {
                        throw new FaultException(ErrCode.SHFEPositionNotFound.ToString());
                    }

                    p.HedgedLotQuantity = deltaQty + (p.HedgedLotQuantity ?? 0);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete Hedge Group Line of SHFE Position
        /// </summary>
        /// <param name="shfes"></param>
        /// <param name="userId"></param>
        private void DeleteHedgeGroupSHFEPositionLines(IEnumerable<HedgeLineSHFEPosition> shfes, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                foreach (var hedgeLineSHFEPosition in shfes)
                {
                    var lineShfe = hedgeLineSHFEPosition;
                    decimal deltaQty = lineShfe.AssignedLotAmount;

                    Delete(GetObjSet<HedgeLineSHFEPosition>(ctx), lineShfe.Id);
                    ctx.SaveChanges();

                    var p = QueryForObj(GetObjQuery<SHFEPosition>(ctx), o => o.Id == lineShfe.SHFEPositionId);
                    if (p == null)
                    {
                        throw new FaultException(ErrCode.SHFEPositionNotFound.ToString());
                    }

                    p.HedgedLotQuantity -= deltaQty;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remove 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var hg = GetById(GetObjQuery<HedgeGroup>(ctx), id);
                    if (hg == null)
                    {
                        throw new FaultException(ErrCode.HedgeGroupNotFound.ToString());
                    }

                    hg.IsDeleted = true;
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion

        #region 计算未结算分组保值的锁定及浮动盈亏

        /// <summary>
        /// 计算现货的锁定及浮动盈亏。传入的hedgeGroup要include批次及点价、未点价等信息
        /// </summary>
        /// <param name="hedgeGroup"></param>
        /// <param name="userId"></param>
        /// <param name="fixedPNL"></param>
        /// <param name="floatPNL"></param>
        private void GetQuotaPNLByQuota(HedgeGroup hedgeGroup, int userId, out decimal fixedPNL, out decimal floatPNL)
        {
            fixedPNL = 0;
            floatPNL = 0;
            if (hedgeGroup.HedgeLineQuotas.Count <= 0)
            {
                return;
            }

            //暂定现货只有一个金属
            Commodity comm = hedgeGroup.HedgeLineQuotas.First().Quota.Commodity;

            var hedgeLineQuotas = hedgeGroup.HedgeLineQuotas.ToList();
            var quotaService = new QuotaService();

            decimal buyVerQty = 0;
            decimal sellVerQty = 0;
            decimal buyAvgPriceSum = 0;
            decimal sellAvgPriceSum = 0;

            foreach (HedgeLineQuota hedgeLineQuota in hedgeLineQuotas)
            {
                Quota q = hedgeLineQuota.Quota;
                decimal verQty = q.VerifiedQuantity; //批次实际数量
                decimal qty = 0; //批次数量
                decimal avgPrice = 0;
                if (q.Contract.ContractType == (int)ContractType.Purchase)
                {
                    #region 采购

                    buyVerQty += verQty;
                    quotaService.GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userId, true, true, false);
                    buyAvgPriceSum += avgPrice * q.VerifiedQuantity;

                    #endregion
                }
                else
                {
                    #region 销售

                    sellVerQty += verQty;
                    quotaService.GetQuotaAmount(q, ref _comList, ref qty, ref avgPrice, userId, true, true, false);
                    sellAvgPriceSum += avgPrice * q.VerifiedQuantity;

                    #endregion
                }
            }

            decimal buyAvgPrice = buyVerQty == 0 ? 0 : buyAvgPriceSum / buyVerQty;
            decimal sellAvgPrice = sellVerQty == 0 ? 0 : sellAvgPriceSum / sellVerQty;
            //销售盈亏=（销售均价-采购均价）*min(销售数量，采购数量)

            decimal inventorySumQty = buyVerQty - sellVerQty;
            decimal latestPrice = quotaService.GetDomesticPhysicalPrice(comm, userId);
            if (sellVerQty < buyVerQty)
            {
                //(销售数量 < 采购数量),库存为正
                fixedPNL += (sellAvgPrice - buyAvgPrice) * sellVerQty;
                //浮动盈亏=(最新价 – 采购均价)* 库存
                floatPNL += inventorySumQty * (latestPrice - buyAvgPrice);
            }
            else
            {
                //库存为负
                fixedPNL += (sellAvgPrice - buyAvgPrice) * buyVerQty;
                //浮动盈亏=(销售均价 – 最新价)* 库存
                floatPNL += Math.Abs(inventorySumQty) * (sellAvgPrice - latestPrice);
            }
        }

        /// <summary>
        /// 计算LME头村的锁定及浮动盈亏。传入的hedgeGroup要include LME Position。
        /// </summary>
        /// <param name="hedgeGroup"></param>
        /// <param name="fixedPNL"></param>
        /// <param name="floatPNL"></param>
        private void GetLMEPositionPNL(HedgeGroup hedgeGroup, out decimal fixedPNL, out decimal floatPNL)
        {
            fixedPNL = 0;
            floatPNL = 0;

            if (hedgeGroup.HedgeLineLMEPositions.Count <= 0)
            {
                return;
            }

            Commodity comm = hedgeGroup.HedgeLineLMEPositions.First().LMEPosition.Commodity;
            decimal price = MarketPriceManager.GetLMELatestPrice(comm);

            var lmeGroups = hedgeGroup.HedgeLineLMEPositions.GroupBy(o => o.LMEPosition.PromptDate);
            foreach (var lmeGroup in lmeGroups)
            {
                var lmeList = lmeGroup.ToList().OrderByDescending(o => o.LMEPosition.TradeDate).ThenByDescending(o => o.Id);
                decimal exposure = lmeList.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue);

                if (exposure == 0)
                {
                    //No float PNL
                    //Firstly the net pnl of the positions
                    fixedPNL +=
                        -(decimal)
                         lmeList.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue * o.LMEPosition.AgentPrice * comm.LMEQtyPerHand) -
                        lmeList.Sum(o => o.AssignedCommission);
                }
                else
                {
                    var openLmes = new List<HedgeLineLMEPosition>();
                    var absExposure = Math.Abs(exposure);
                    foreach (var p in lmeList)
                    {
                        if (exposure * p.LMEPosition.TradeDirectionValue > 0)
                        {
                            if (p.AssignedLotAmount > absExposure)
                            {
                                var tmpCommission = absExposure / p.AssignedLotAmount * p.AssignedCommission;
                                var tmpLine = new HedgeLineLMEPosition
                                                  {
                                                      AssignedLotAmount = absExposure,
                                                      AssignedCommission = tmpCommission,
                                                      LMEPosition = p.LMEPosition
                                                  };
                                openLmes.Add(tmpLine);
                                p.AssignedLotAmount -= absExposure;
                                p.AssignedCommission -= tmpCommission;
                                absExposure = 0;
                            }
                            else
                            {
                                var tmpLine = new HedgeLineLMEPosition
                                                  {
                                                      AssignedCommission = p.AssignedCommission,
                                                      AssignedLotAmount = p.AssignedLotAmount,
                                                      LMEPosition = p.LMEPosition
                                                  };
                                openLmes.Add(tmpLine);
                                p.AssignedLotAmount = 0;
                                p.AssignedCommission = 0;
                                absExposure -= p.AssignedLotAmount;
                            }

                            if (absExposure <= 0)
                            {
                                break;
                            }
                        }
                    }

                    fixedPNL +=
                        -(decimal)
                         lmeList.Sum(o => o.AssignedLotAmount * o.LMEPosition.AgentPrice * o.LMEPosition.TradeDirectionValue * comm.LMEQtyPerHand) -
                        lmeList.Sum(o => o.AssignedCommission);

                    //float
                    floatPNL +=
                        -(decimal)
                         openLmes.Sum(
                             o =>
                             o.AssignedLotAmount * (o.LMEPosition.AgentPrice - price) * comm.LMEQtyPerHand *
                             o.LMEPosition.TradeDirectionValue) - openLmes.Sum(o => o.AssignedCommission);
                }
            }
        }

        /// <summary>
        /// 计算SHFE头村的锁定及浮动盈亏。传入的hedgeGroup要include SHFE Position。
        /// </summary>
        /// <param name="hedgeGroup"></param>
        /// <param name="fixedPNL"></param>
        /// <param name="floatPNL"></param>
        private void GetSHFEPositionPNL(HedgeGroup hedgeGroup, out decimal fixedPNL, out decimal floatPNL)
        {
            fixedPNL = 0;
            floatPNL = 0;

            if (hedgeGroup.HedgeLineSHFEPositions.Count <= 0)
            {
                return;
            }

            Commodity comm = hedgeGroup.HedgeLineSHFEPositions.First().SHFEPosition.Commodity;
            var shfeGroups = hedgeGroup.HedgeLineSHFEPositions.GroupBy(o => o.SHFEPosition.SHFEId);
            foreach (var shfeGroup in shfeGroups)
            {
                var shfeList = shfeGroup.ToList();
                var price = MarketPriceManager.GetSHFELatestPrice(comm,
                                                                  shfeList.First().SHFEPosition.PromptDate.Value.Month);

                var longShfeList =
                    shfeList.Where(
                        o =>
                        (o.SHFEPosition.PositionDirection == (int) PositionDirection.Long &&
                         o.SHFEPosition.OpenClose == (int) PositionOpenClose.Open)
                        ||
                        (o.SHFEPosition.PositionDirection == (int) PositionDirection.Short &&
                         o.SHFEPosition.OpenClose == (int) PositionOpenClose.Close))
                            .OrderByDescending(o => o.SHFEPosition.SHFECapitalDetail.TradeDate)
                            .ThenByDescending(o => o.SHFEPosition.Id).ToList();

                var shortShfeList =
                    shfeList.Where(
                        o =>
                        (o.SHFEPosition.PositionDirection == (int) PositionDirection.Short &&
                         o.SHFEPosition.OpenClose == (int) PositionOpenClose.Open)
                        ||
                        (o.SHFEPosition.PositionDirection == (int) PositionDirection.Long &&
                         o.SHFEPosition.OpenClose == (int) PositionOpenClose.Close))
                            .OrderByDescending(o => o.SHFEPosition.SHFECapitalDetail.TradeDate)
                            .ThenByDescending(o => o.SHFEPosition.Id).ToList();

                if (longShfeList.Count > 0)
                {
                    decimal longExposure = longShfeList.Sum(o => o.AssignedLotAmount * o.SHFEPosition.OpenCloseValue);
                    if (longExposure == 0)
                    {
                        fixedPNL +=
                            -(decimal)longShfeList.Sum(
                                o =>
                                o.AssignedLotAmount * o.SHFEPosition.Price * comm.SHFEQtyPerHand * o.SHFEPosition.OpenCloseValue) -
                            longShfeList.Sum(o => o.AssignedCommission);
                    }
                    else
                    {
                        var longExposeShfes = new List<HedgeLineSHFEPosition>();
                        decimal absExposure = Math.Abs(longExposure);
                        foreach (var s in longShfeList)
                        {
                            if (longExposure * s.SHFEPosition.OpenCloseValue > 0)
                            {
                                if (s.AssignedLotAmount > absExposure)
                                {
                                    var tmpCommission = absExposure / s.AssignedLotAmount * s.AssignedCommission;
                                    var tmpLine = new HedgeLineSHFEPosition
                                    {
                                        AssignedCommission = tmpCommission,
                                        AssignedLotAmount = absExposure,
                                        SHFEPosition = s.SHFEPosition
                                    };
                                    longExposeShfes.Add(tmpLine);
                                    s.AssignedLotAmount -= absExposure;
                                    s.AssignedCommission -= tmpCommission;
                                    absExposure = 0;
                                }
                                else
                                {
                                    var tmpLine = new HedgeLineSHFEPosition
                                    {
                                        AssignedLotAmount = s.AssignedLotAmount,
                                        AssignedCommission = s.AssignedCommission,
                                        SHFEPosition = s.SHFEPosition
                                    };
                                    absExposure -= s.AssignedLotAmount;
                                    s.AssignedLotAmount = 0;
                                    s.AssignedCommission = 0;
                                    longExposeShfes.Add(tmpLine);
                                }

                                if (absExposure == 0)
                                {
                                    break;
                                }
                            }
                        }

                        fixedPNL +=
                            -(decimal)longShfeList.Sum(
                                o =>
                                o.AssignedLotAmount * o.SHFEPosition.Price * o.SHFEPosition.OpenCloseValue * comm.SHFEQtyPerHand) -
                            longShfeList.Sum(o => o.AssignedCommission);

                        floatPNL +=
                            -(decimal)longExposeShfes.Sum(
                                o =>
                                o.AssignedLotAmount * (o.SHFEPosition.Price - price) * o.SHFEPosition.OpenCloseValue *
                                comm.SHFEQtyPerHand) - longExposeShfes.Sum(o => o.AssignedCommission);
                    }
                }
                
                if (shortShfeList.Count > 0)
                {
                    decimal shortExposure = shortShfeList.Sum(o => o.AssignedLotAmount * o.SHFEPosition.OpenCloseValue);
                    if (shortExposure == 0)
                    {
                        fixedPNL +=
                            (decimal)shortShfeList.Sum(
                                o =>
                                o.AssignedLotAmount * o.SHFEPosition.Price * comm.SHFEQtyPerHand * o.SHFEPosition.OpenCloseValue) -
                            shortShfeList.Sum(o => o.AssignedCommission);
                    }
                    else
                    {
                        var shortExposeShfes = new List<HedgeLineSHFEPosition>();
                        decimal absExposure = Math.Abs(shortExposure);
                        foreach (var s in shortShfeList)
                        {
                            if (shortExposure * s.SHFEPosition.OpenCloseValue > 0)
                            {
                                if (s.AssignedLotAmount > absExposure)
                                {
                                    var tmpCommission = absExposure / s.AssignedLotAmount * s.AssignedCommission;
                                    var tmpLine = new HedgeLineSHFEPosition
                                    {
                                        AssignedCommission = tmpCommission,
                                        AssignedLotAmount = absExposure,
                                        SHFEPosition = s.SHFEPosition
                                    };
                                    shortExposeShfes.Add(tmpLine);
                                    s.AssignedLotAmount -= absExposure;
                                    s.AssignedCommission -= tmpCommission;
                                    absExposure = 0;
                                }
                                else
                                {
                                    var tmpLine = new HedgeLineSHFEPosition
                                    {
                                        AssignedLotAmount = s.AssignedLotAmount,
                                        AssignedCommission = s.AssignedCommission,
                                        SHFEPosition = s.SHFEPosition
                                    };
                                    absExposure -= s.AssignedLotAmount;
                                    s.AssignedLotAmount = 0;
                                    s.AssignedCommission = 0;
                                    shortExposeShfes.Add(tmpLine);
                                }

                                if (absExposure == 0)
                                {
                                    break;
                                }
                            }
                        }

                        fixedPNL +=
                            (decimal)shortShfeList.Sum(
                                o =>
                                o.AssignedLotAmount * o.SHFEPosition.Price * o.SHFEPosition.OpenCloseValue * comm.SHFEQtyPerHand) -
                            shortShfeList.Sum(o => o.AssignedCommission);

                        floatPNL +=
                            -(decimal)shortExposeShfes.Sum(
                                o =>
                                o.AssignedLotAmount * (o.SHFEPosition.Price - price) * o.SHFEPosition.OpenCloseValue *
                                comm.SHFEQtyPerHand) - shortExposeShfes.Sum(o => o.AssignedCommission);
                    }
                }
            }
        }
        #endregion

        private Dictionary<string, decimal> _comList = new Dictionary<string, decimal>();
    }
}
