using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;

namespace Services.Futures.LME
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“LMEPositionService”。
    public class LMEPositionService : BaseService<LMEPosition>, ILMEPositionService
    {
        #region ILMEPositionService Members

        public void CreateNewCarryLMEPosition(LMEPosition leg1, LMEPosition leg2, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    //创建头寸leg1
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<LMEPosition> os = GetObjSet<LMEPosition>(ctx);
                        Create(os, leg1);
                        ctx.SaveChanges();
                    }
                    //创建头寸leg2
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<LMEPosition> os = GetObjSet<LMEPosition>(ctx);
                        leg2.CarryPositionId = leg1.Id;
                        Create(os, leg2);
                        ctx.SaveChanges();
                    }
                    //修改头寸leg1 外键 CarryPositionId 
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<LMEPosition> os = GetObjSet<LMEPosition>(ctx);
                        LMEPosition carryLeg =
                            QueryForObjs(GetObjQuery<LMEPosition>(ctx), o => o.Id == leg1.Id).FirstOrDefault();
                        if (carryLeg != null)
                        {
                            carryLeg.CarryPositionId = leg2.Id;
                            Update(os, carryLeg);
                        }
                        ctx.SaveChanges();
                    }

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException) ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        public void UpdateCarryLMEPosition(LMEPosition leg1, LMEPosition leg2, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    //修改头寸leg1
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<LMEPosition> os = GetObjSet<LMEPosition>(ctx);
                        Update(os, leg1);
                        ctx.SaveChanges();
                    }
                    //修改头寸leg2
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        ObjectSet<LMEPosition> os = GetObjSet<LMEPosition>(ctx);
                        Update(os, leg2);
                        ctx.SaveChanges();
                    }

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException) ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        public void DeleteLMEPosition(int id, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    LMEPosition leg = QueryForObj(GetObjQuery<LMEPosition>(ctx), l => l.Id == id);

                    if(leg.HedgedLotQuantity > 0)
                    {
                        throw new FaultException(ErrCode.LMEPositionHedged.ToString());
                    }

                    leg.IsDeleted = true;
                    Update(GetObjSet<LMEPosition>(ctx), leg);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException && ((SqlException) ex.InnerException).Number == 8152)
                {
                    throw new FaultException(ErrCode.StringOverflow.ToString());
                }

                throw;
            }
        }

        public void DeleteCarryLMEPosition(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    LMEPosition leg1;
                    //修改头寸leg1
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        leg1 = QueryForObj(GetObjQuery<LMEPosition>(ctx), l => l.Id == id);
                        leg1.IsDeleted = true;
                        ctx.SaveChanges();
                    }
                    //修改头寸leg2
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        LMEPosition leg2 = QueryForObj(GetObjQuery<LMEPosition>(ctx), l => l.Id == leg1.CarryPositionId);
                        leg2.IsDeleted = true;
                        ctx.SaveChanges();
                    }

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException) ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        public decimal GetQtyByParameters(int positionDirection, int commodityID, int internalCustomerID, DateTime? date,
                                          string type, int userId)
        {
            try
            {
                string sql = "it.CommodityId = @p1 and it.InternalBPId = @p2 and it.TradeDirection = @p3";
                if (type == "CurrentDay") //当天的点价数量
                {
                    sql += " and it.TradeDate = @p4";
                }
                else if (type == "All")
                {
                    sql += " and it.TradeDate <= @p4";
                }
                var parameters = new List<object> {commodityID, internalCustomerID, positionDirection, date};
                decimal qty = GetSum<LMEPosition>(sql, parameters, o => o.LotAmount);
                return qty;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<LMEPosition> GetQtyNew(int commodityID, int internalCustomerID, DateTime? date)
        {
            using (var ctx=new SenLan2Entities())
            {
                List<LMEPosition> list = QueryForObjs(GetObjQuery<LMEPosition>(ctx), o => o.CommodityId == commodityID
                    && o.InternalBPId == internalCustomerID
                    && o.TradeDate <= date).ToList();
                return list;
            }
        }

        public List<LMEPosition> GetDuedPositionSummary(string queryStr, List<object> parameters, List<string> includes)
        {
            var result = new List<LMEPosition>();
            var positions = Select(queryStr, parameters, includes);
            positions = positions.OrderBy(o => o.AgentId).ThenByDescending(o => o.PromptDate).ToList();
            var brokerGroups = positions.GroupBy(o => o.AgentId);
            foreach (var brokerGroup in brokerGroups)
            {
                var brokerList = brokerGroup.ToList();
                var promptGroups = brokerList.GroupBy(o => o.PromptDate);
                foreach (var promptGroup in promptGroups)
                {
                    var promptList = promptGroup.ToList();
                    var tmp = new LMEPosition
                    {
                        AgentId = promptList[0].AgentId,
                        Agent = promptList[0].Agent,
                        PromptDate = promptList[0].PromptDate,
                        LotAmount = promptList.Sum(o => o.LotAmount),
                        HedgedLotQuantity =
                            promptList.Sum(o => o.LotAmount * o.TradeDirectionValue),
                        AgentCommission = promptList.Sum(o => o.AgentCommission),
                        ClientCommission =
                            promptList.Sum(o => o.AgentPrice * o.LotAmount * o.TradeDirectionValue * o.Commodity.LMEQtyPerHand)
                    };
                    if (Math.Round(tmp.HedgedLotQuantity ?? 0, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) != 0)
                    {
                        tmp.LotAmount = null;
                        tmp.AgentCommission = null;
                        tmp.ClientCommission = null;
                    }
                    result.Add(tmp);
                }
            }
            return result;
        }

        public LMEPositionEnableProperty SetElementsEnableProperty(int id)
        {
            var lmeep = new LMEPositionEnableProperty();
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    //如果该头寸参与分组保值,头寸不可以修改
                    HedgeLineLMEPosition hllme = QueryForObjs(GetObjQuery<HedgeLineLMEPosition>(ctx, new List<string>{"HedgeGroup"}), q => q.LMEPositionId == id).FirstOrDefault();
                    if(hllme != null)
                    {
                        lmeep.IsTradeDirectionEnable = false;
                        lmeep.IsPriceEnable = false;
                        lmeep.IsLotQuantityEnable = false;
                        lmeep.IsCommodityEnable = false;
                        return lmeep;
                    }
                    return lmeep;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<LMEExposureDetailLine> GetLMEExposureLines(int commodityId, int internalCustomerId, int brokerId)
        {
            var result = new List<LMEExposureDetailLine>();

            var sb = new StringBuilder();
            var parameters = new List<object>();

            int i = 1;

            sb.AppendFormat("it.PromptDate > @p{0}", i);
            i++;
            parameters.Add(DateTime.Today);

            if (commodityId > 0)
            {
                sb.AppendFormat(" and it.CommodityId = @p{0}", i );
                i++;
                parameters.Add(commodityId);
            }

            if (internalCustomerId > 0)
            {
                sb.AppendFormat(" and it.InternalBPId = @p{0}", i);
                i++;
                parameters.Add(internalCustomerId);
            }

            if (brokerId > 0)
            {
                sb.AppendFormat(" and it.AgentId = @p{0}", i);
                parameters.Add(brokerId);
            }

            string condition = sb.ToString();

            var lmeGroups = Select(condition, parameters, new List<string> { "Agent", "InternalBP" }).GroupBy(o => o.PromptDate);
            foreach (var lmeGroup in lmeGroups)
            {
                var lmeList = lmeGroup.ToList().OrderByDescending(o => o.TradeDate).ThenByDescending(o => o.Id);
                var exposure = (decimal) lmeList.Sum(o => o.LotAmount*o.TradeDirectionValue);
                var absExposure = Math.Abs(exposure);

                if (exposure == 0)
                {
                    continue;
                }

                foreach (var lmePosition in lmeList)
                {
                    if (exposure*lmePosition.TradeDirectionValue > 0)
                    {
                        if (lmePosition.LotAmount > absExposure)
                        {
                            var tmpLine = new LMEExposureDetailLine
                                              {
                                                  BrokerName = lmePosition.Agent.ShortName,
                                                  Direction = lmePosition.TradeDirection,
                                                  LotNumber = absExposure,
                                                  Price =  lmePosition.AgentPrice,
                                                  PromptDate = lmePosition.PromptDate,
                                                  TradeDate = lmePosition.TradeDate,
                                                  InternalCustomerName = lmePosition.InternalBP.ShortName
                                              };
                            absExposure = 0;
                            result.Add(tmpLine);
                        }
                        else
                        {
                            var tmpLine = new LMEExposureDetailLine
                            {
                                BrokerName = lmePosition.Agent.ShortName,
                                Direction = lmePosition.TradeDirection,
                                LotNumber = lmePosition.LotAmount,
                                Price = lmePosition.AgentPrice,
                                PromptDate = lmePosition.PromptDate,
                                TradeDate = lmePosition.TradeDate,
                                InternalCustomerName = lmePosition.InternalBP.ShortName
                            };
                            absExposure -= lmePosition.LotAmount ?? 0;
                            result.Add(tmpLine);
                        }

                        if (absExposure == 0)
                        {
                            break;
                        }
                    }
                }
            }

            result = result.OrderBy(o => o.PromptDate).ToList();
            return result;
        }

        #endregion
    }
}