using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.Futures.SHFE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SHFEPosition" in code, svc and config file together.
    public class SHFEPositionService : BaseService<SHFEPosition>, ISHFEPositionService
    {
        #region ISHFEPositionService Members

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="capitalDetail">资金明细数据</param>
        /// <param name="shfePositionList">成交汇总数据</param>
        /// <param name="shfeHoldingPositions">持仓汇总数据</param>
        /// <param name="shfeFundFlows">出入金明细数据</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void ImportSHFEPosition(SHFECapitalDetail capitalDetail, List<SHFEPosition> shfePositionList,
                                       List<SHFEHoldingPosition> shfeHoldingPositions,List<SHFEFundFlow> shfeFundFlows, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    if (capitalDetail.TradeDate != null)
                    {
                        DateTime dateTime = capitalDetail.TradeDate.Value;
                        int brokerId = capitalDetail.AgentId.Value;
                        int innerCustomerId = capitalDetail.InternalBPId.Value;
                        bool isImported = IsImported(dateTime, brokerId, innerCustomerId, userId);
                        if (isImported)
                        {
                            //导入过，删掉重新导入
                            DeleteImportData(dateTime, brokerId, innerCustomerId, userId);
                        }
                    }
                    else
                    {
                        throw new Exception("交易日期不能为空");
                    }

                    StartImportData(capitalDetail, shfePositionList, shfeHoldingPositions,shfeFundFlows, userId);

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        public SHFEPosition GetSHFEPositionById(int id)
        {
            SHFEPosition position;
            using (var ctx = new SenLan2Entities())
            {
                position = QueryForObj(GetObjQuery<SHFEPosition>(ctx, new List<string> {"SHFECapitalDetail"}),
                                       o => o.Id == id);
            }
            return position;
        }

        public decimal GetQtyByParameters(int positionDirection, int commodityID, int internalCustomerID, DateTime? date,
                                          string type, int userId)
        {
            try
            {
                string sql =
                    "it.CommodityId = @p1 and it.SHFECapitalDetail.InternalBPId = @p2 and it.PositionDirection = @p3";
                if (type == "CurrentDay")
                {
                    sql += " and it.SHFECapitalDetail.TradeDate = @p4";
                }
                else if (type == "All")
                {
                    sql += " and it.SHFECapitalDetail.TradeDate <= @p4";
                }
                var parameters = new List<object> {commodityID, internalCustomerID, positionDirection, date};
                decimal qty = GetSum<SHFEPosition>(sql, parameters, o => o.LotQuantity);
                return qty;
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public List<SHFEPosition> GetQtyNew(int commodityID, int internalCustomerID, DateTime? date)
        {
            using (var ctx = new SenLan2Entities())
            {
                List<SHFEPosition> list = QueryForObjs(GetObjQuery<SHFEPosition>(ctx, new List<string> { "SHFECapitalDetail" }), o => o.CommodityId == commodityID
                    && o.SHFECapitalDetail.InternalBPId == internalCustomerID
                    && o.SHFECapitalDetail.TradeDate <= date).ToList();
                return list;
            }
        }

        /// <summary>
        /// 查询SHFE资金状况列表
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="internalBPId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<SHFECapitalDetail> GetSHFECapitalDetailList(int? agentId, int internalBPId, DateTime? startDate,
                                                                DateTime endDate)
        {
            List<SHFECapitalDetail> list;
            var strList = new List<string>
                              {"BusinessPartner", "BusinessPartner1", "SHFEPositions", "SHFEHoldingPositions"};
            using (var ctx = new SenLan2Entities())
            {
                if (agentId != 0)
                {
                    if (startDate != null)
                        list =
                            QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, strList),
                                         o =>
                                         o.AgentId == agentId && o.InternalBPId == internalBPId &&
                                         o.TradeDate >= startDate && o.TradeDate <= endDate).ToList();
                    else
                        list =
                            QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, strList),
                                         o =>
                                         o.AgentId == agentId && o.InternalBPId == internalBPId &&
                                         o.TradeDate <= endDate).ToList();
                }
                else
                {
                    if (startDate != null)
                        list =
                            QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, strList),
                                         o =>
                                         o.InternalBPId == internalBPId && o.TradeDate >= startDate &&
                                         o.TradeDate <= endDate).ToList();
                    else
                        list =
                            QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, strList),
                                         o => o.InternalBPId == internalBPId && o.TradeDate <= endDate).ToList();
                }
            }

            foreach (var item in list)
            {
                EntityUtil.FilterDeletedEntity(item.SHFEPositions);
                EntityUtil.FilterDeletedEntity(item.SHFEHoldingPositions);
            }

            return list;
        }

        #endregion

        /// <summary>
        /// 开始导入数据
        /// </summary>
        /// <param name="capitalDetail"></param>
        /// <param name="shfePositionList"></param>
        /// <param name="shfeHoldingPositions"></param>
        /// <param name="shfeFundFlows"></param>
        /// <param name="userId"></param>
        private void StartImportData(SHFECapitalDetail capitalDetail, IEnumerable<SHFEPosition> shfePositionList,
                                     IEnumerable<SHFEHoldingPosition> shfeHoldingPositions, IEnumerable<SHFEFundFlow> shfeFundFlows, int userId)
        {
            //资金明细
            AddCapitalDetail(capitalDetail, userId);
            int capitalDetailId = capitalDetail.Id;
            //成交记录
            foreach (SHFEPosition shfePosition in shfePositionList)
            {
                shfePosition.SHFECapitalDetailsId = capitalDetailId;
                AddSHFEPosition(shfePosition, userId);
            }
            //持仓记录
            foreach (SHFEHoldingPosition shfeHoldingPosition in shfeHoldingPositions)
            {
                shfeHoldingPosition.SHFECapitalDetailsId = capitalDetailId;
                AddSHFEHoldingPosition(shfeHoldingPosition, userId);
            }

            //出入金明细
            foreach (var fundFlow in shfeFundFlows)
            {
                fundFlow.SHFECapitalDetailsId = capitalDetailId;
                AddSHFEFundFlow(fundFlow, userId);
            }
        }

        /// <summary>
        /// 新增资金明细数据
        /// </summary>
        /// <param name="capitalDetail"></param>
        /// <param name="userId"></param>
        private void AddCapitalDetail(SHFECapitalDetail capitalDetail, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Create(GetObjSet<SHFECapitalDetail>(ctx), capitalDetail);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 新增出入金明细数据
        /// </summary>
        /// <param name="fundFlow"></param>
        /// <param name="userId"></param>
        private void AddSHFEFundFlow(SHFEFundFlow fundFlow, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Create(GetObjSet<SHFEFundFlow>(ctx), fundFlow);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 新增成交记录
        /// </summary>
        /// <param name="position"></param>
        /// <param name="userId"></param>
        private void AddSHFEPosition(SHFEPosition position, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Create(GetObjSet<SHFEPosition>(ctx), position);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 新增持仓记录
        /// </summary>
        /// <param name="position"></param>
        /// <param name="userId"></param>
        private void AddSHFEHoldingPosition(SHFEHoldingPosition position, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                Create(GetObjSet<SHFEHoldingPosition>(ctx), position);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 判断是否导入过
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="brokerId"></param>
        /// <param name="innerCustomerId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private bool IsImported(DateTime dateTime, int brokerId, int innerCustomerId, int userId)
        {
            bool flag = false;
            using (var ctx = new SenLan2Entities(userId))
            {
                SHFECapitalDetail capitalDetail = QueryForObj(GetObjQuery<SHFECapitalDetail>(ctx),
                                                              o =>
                                                              o.TradeDate == dateTime && o.AgentId == brokerId &&
                                                              o.InternalBPId == innerCustomerId);
                if (capitalDetail != null)
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 删除导入的数据
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="brokerId"></param>
        /// <param name="innerCustomerId"></param>
        /// <param name="userId"></param>
        private void DeleteImportData(DateTime dateTime, int brokerId, int innerCustomerId, int userId)
        {
            int capitalDetailsId = 0;
            using (var ctx = new SenLan2Entities(userId))
            {
                SHFECapitalDetail capitalDetail = QueryForObj(GetObjQuery<SHFECapitalDetail>(ctx),
                                                              o =>
                                                              o.TradeDate == dateTime && o.AgentId == brokerId &&
                                                              o.InternalBPId == innerCustomerId);
                if (capitalDetail != null)
                {
                    capitalDetailsId = capitalDetail.Id;
                }
            }
            if (capitalDetailsId != 0)
            {
                DeleteSHFEFundFlowData(capitalDetailsId, userId);

                DeleteSHFEPositionData(capitalDetailsId, userId);

                DeleteSHFEHoldingPositionData(capitalDetailsId, userId);

                DeleteSHFECapitalDetailData(capitalDetailsId, userId);
            }
        }

        /// <summary>
        /// 删除SHFE出入金明细
        /// </summary>
        /// <param name="capitalDetailsId"></param>
        /// <param name="userId"></param>
        private void DeleteSHFEFundFlowData(int capitalDetailsId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                ObjectSet<SHFEFundFlow> os = GetObjSet<SHFEFundFlow>(ctx);
                ICollection<SHFEFundFlow> fundFlows = QueryForObjs(GetObjQuery<SHFEFundFlow>(ctx),
                                                                   o => o.SHFECapitalDetailsId == capitalDetailsId);
                foreach (SHFEFundFlow fundFlow in fundFlows)
                {
                    fundFlow.IsDeleted = true;
                    Update(os, fundFlow);
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 删除SHFE成交汇总
        /// </summary>
        /// <param name="capitalDetailsId"></param>
        /// <param name="userId"></param>
        private void DeleteSHFEPositionData(int capitalDetailsId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                ObjectSet<SHFEPosition> os = GetObjSet<SHFEPosition>(ctx);
                ICollection<SHFEPosition> positions = QueryForObjs(GetObjQuery<SHFEPosition>(ctx),
                                                                   o => o.SHFECapitalDetailsId == capitalDetailsId);
                foreach (SHFEPosition position in positions)
                {
                    if (position.HedgedLotQuantity > 0)
                    {
                        throw new FaultException("已参与保值的SHFE头寸不能重复导入");
                    }
                    else
                    {
                        position.IsDeleted = true;
                        Update(os, position);
                    }
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 删除SHFE历史持仓
        /// </summary>
        /// <param name="capitalDetailsId"></param>
        /// <param name="userId"></param>
        private void DeleteSHFEHoldingPositionData(int capitalDetailsId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                ObjectSet<SHFEHoldingPosition> os = GetObjSet<SHFEHoldingPosition>(ctx);
                ICollection<SHFEHoldingPosition> positions = QueryForObjs(GetObjQuery<SHFEHoldingPosition>(ctx),
                                                                          o =>
                                                                          o.SHFECapitalDetailsId == capitalDetailsId);
                foreach (SHFEHoldingPosition position in positions)
                {
                    position.IsDeleted = true;
                    Update(os, position);
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 删除SHFE资金明细
        /// </summary>
        /// <param name="capitalDetailsId"></param>
        /// <param name="userId"></param>
        private void DeleteSHFECapitalDetailData(int capitalDetailsId, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                SHFECapitalDetail capitalDetail = QueryForObj(GetObjQuery<SHFECapitalDetail>(ctx),
                                                              o => o.Id == capitalDetailsId);
                capitalDetail.IsDeleted = true;
                Update(GetObjSet<SHFECapitalDetail>(ctx), capitalDetail);
                ctx.SaveChanges();
            }
        }

        public List<ForwardPositionReportClass> GetData(int? internalID, int? brokerID, int commodityID, int userId)
        {
            var list = new List<ForwardPositionReportClass>();
            using (var ctx = new SenLan2Entities(userId))
            {
                var details = new List<SHFECapitalDetail>();
                if (internalID > 0)
                {
                    details = QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, new List<string> { "BusinessPartner", "BusinessPartner1", "SHFEHoldingPositions" }), c => c.InternalBPId == internalID).ToList();
                }

                if (brokerID > 0)
                {
                    if (details.Count > 0)
                    {
                        details = details.Where(c => c.AgentId == brokerID).ToList();
                    }
                    else {
                        details = QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, new List<string> { "BusinessPartner", "BusinessPartner1", "SHFEHoldingPositions" }), c => c.AgentId == brokerID).ToList();
                    }
                }

                if(internalID <= 0 && brokerID <= 0)
                {
                    details = QueryForObjs(GetObjQuery<SHFECapitalDetail>(ctx, new List<string> { "BusinessPartner", "BusinessPartner1", "SHFEHoldingPositions" }), c => c.Id > 0).ToList();
                }

                if(details.Count > 0)
                {
                    var listByAgent = details.GroupBy(c => c.AgentId).ToList();
                    foreach(var item in listByAgent)
                    {
                        List<SHFECapitalDetail> listByAgentResult = item.ToList();
                        var listByInternal = listByAgentResult.GroupBy(c => c.InternalBPId).ToList();
                        foreach(var listInternal in listByInternal)
                        {
                            List<SHFECapitalDetail> listByInternalResult = listInternal.ToList();
                            if(listByInternalResult.Count > 0)
                            {
                                DateTime? maxDate = listByInternalResult.Max(c => c.TradeDate);
                                SHFECapitalDetail maxDateDetail = listByInternalResult.Where(c => c.TradeDate == maxDate).ToList()[0];
                                List<SHFEHoldingPosition> positions = maxDateDetail.SHFEHoldingPositions.Where(c => c.CommodityId == commodityID).ToList();
                                if (positions.Count > 0)
                                {
                                    list.AddRange(
                                        positions.Select(
                                            position => new ForwardPositionReportClass
                                                            {
                                                                Alias = position.Alias,
                                                                TradeDate = maxDateDetail.TradeDate,
                                                                Qty = position.LotQuantity,
                                                                Price = position.Price,
                                                                PositionDerection = position.PositionDirection,
                                                                BrokerName = maxDateDetail.BusinessPartner.ShortName,
                                                                InternalName = maxDateDetail.BusinessPartner1.ShortName
                                                            }));
                                }
                            }
                        }
                    }
                }

                return list;
            }
        }
    }
}