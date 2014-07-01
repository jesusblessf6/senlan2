using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Transactions;
using DBEntity;
using DBEntity.EnumEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommissionService" in code, svc and config file together.
    public class CommissionService : BaseService<Commission>, ICommissionService
    {
        #region ICommissionService Members

        public void CreateDocument(int userId, Commission header, List<CommissionLine> addedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateHeader(userId, header);
                    foreach (CommissionLine line in addedLines)
                    {
                        CreateLine(userId, header, line);
                    }
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

        public void UpdateDocument(int userId, Commission header, List<CommissionLine> addedLines,
                                   List<CommissionLine> updatedLines, List<CommissionLine> deletedLines)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(userId, header);
                    foreach (CommissionLine line in addedLines)
                    {
                        CreateLine(userId, header, line);
                    }
                    foreach (CommissionLine line in updatedLines)
                    {
                        UpdateLine(userId, line);
                    }
                    foreach (CommissionLine line in deletedLines)
                    {
                        DeleteLine(userId, line.Id);
                    }
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

        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    DeleteLine(userId, id);
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

        public decimal? GetCommissionValue(DateTime? startDate, int? internalCustomerID,
                                           int? commodityID, int? customerID, decimal? price, decimal? qty, int userId)
        {
            try
            {
                startDate = startDate ?? DateTime.Now;
                internalCustomerID = internalCustomerID ?? 0;
                commodityID = commodityID ?? 0;
                customerID = customerID ?? 0;
                price = price ?? 0;
                qty = qty ?? 0;
                using (var ctx = new SenLan2Entities(userId))
                {
                    decimal? value = 0;
                    decimal? value1 = 0;
                    decimal? value2 = 0;
                    int perHand = 0;
                    CommissionLine commissionLine = QueryForObj(GetObjQuery<CommissionLine>(ctx),
                                                                c =>
                                                                c.Commission.InternalBPId == internalCustomerID &&
                                                                c.CommodityId == commodityID && c.Commission.BPId == customerID &&
                                                                c.StartDate <= startDate && c.EndDate >= startDate &&
                                                                c.Commission.IsDefaultRule == false);
                    Commodity commodity = QueryForObj(GetObjQuery<Commodity>(ctx), c => c.Id == commodityID);
                    if (commodity != null)
                    {
                        perHand = commodity.LMEQtyPerHand == null ? 0 : (int) commodity.LMEQtyPerHand;
                    }
                    if (commissionLine == null) //如果佣金为空 则找默认佣金
                    {
                        BusinessPartner bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx), c => c.Id == customerID);
                        int customerType = (bp == null ? 0 : bp.CustomerType); //确定找出默认客户/经济行佣金
                        commissionLine = QueryForObj(GetObjQuery<CommissionLine>(ctx),
                                                     c =>
                                                     c.Commission.InternalBPId == internalCustomerID &&
                                                     c.CommodityId == commodityID && c.StartDate <= startDate &&
                                                     c.EndDate >= startDate && c.Commission.IsDefaultRule &&
                                                     c.Commission.CommissionType == customerType);
                    }

                    if (commissionLine != null)
                    {
                        if (commissionLine.RuleType == (int) CommissionRuleType.Percent)
                        {
                            value1 = qty*perHand*price*commissionLine.RuleValue/100;
                        }
                        else if (commissionLine.RuleType == (int) CommissionRuleType.PerUnit)
                        {
                            value1 = qty*perHand*commissionLine.RuleValue;
                        }

                        if (commissionLine.RuleType2 == (int)CommissionRuleType.Percent)
                        {
                            value2 = qty * perHand * price * commissionLine.RuleValue2 / 100;
                        }
                        else if (commissionLine.RuleType2 == (int)CommissionRuleType.PerUnit)
                        {
                            value2 = qty * perHand * commissionLine.RuleValue2;
                        }

                        value = value1 + value2;
                    }

                    return value;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void GetCarryCommissionValue(LMEPosition position1, LMEPosition position2, int? customerID, decimal? price1, decimal? price2, ref decimal? commissionValue1, ref decimal? commissionValue2, int userId)
        {
            try
            {
                DateTime? startDate = position1.TradeDate ?? DateTime.Now;
                int? internalCustomerID = position1.InternalBPId ?? 0;
                int? commodityID = position1.CommodityId ?? 0;
                customerID = customerID ?? 0;
                price1 = price1 ?? 0;
                price2 = price2 ?? 0;
                decimal? qty = position1.LotAmount ?? 0;
                using (var ctx = new SenLan2Entities(userId))
                {
                    int perHand = 0;
                    CommissionLine commissionLine = QueryForObj(GetObjQuery<CommissionLine>(ctx),
                                                                c =>
                                                                c.Commission.InternalBPId == internalCustomerID &&
                                                                c.CommodityId == commodityID && c.Commission.BPId == customerID &&
                                                                c.StartDate <= startDate && c.EndDate >= startDate &&
                                                                c.Commission.IsDefaultRule == false);
                    Commodity commodity = QueryForObj(GetObjQuery<Commodity>(ctx), c => c.Id == commodityID);
                    if (commodity != null)
                    {
                        perHand = commodity.LMEQtyPerHand == null ? 0 : (int)commodity.LMEQtyPerHand;
                    }
                    if (commissionLine == null) //如果佣金为空 则找默认佣金
                    {
                        BusinessPartner bp = QueryForObj(GetObjQuery<BusinessPartner>(ctx), c => c.Id == customerID);
                        int customerType = (bp == null ? 0 : bp.CustomerType); //确定找出默认客户/经济行佣金
                        commissionLine = QueryForObj(GetObjQuery<CommissionLine>(ctx),
                                                     c =>
                                                     c.Commission.InternalBPId == internalCustomerID &&
                                                     c.CommodityId == commodityID && c.StartDate <= startDate &&
                                                     c.EndDate >= startDate && c.Commission.IsDefaultRule &&
                                                     c.Commission.CommissionType == customerType);
                    }

                    if (commissionLine != null)
                    {
                        if (position1.PromptDate != null && position2.PromptDate != null)
                        {
                            decimal? positionValue1;
                            decimal? positionValue2;
                            double resultDay = Math.Abs((position1.PromptDate.Value - position2.PromptDate.Value).TotalDays);
                            decimal? value1;
                            decimal? value2;
                            decimal? value3;
                            decimal? value4;
                            if (resultDay <= commissionLine.CarryDaysLimit)//在调期头寸天数限制之内
                            {
                                #region 使用在天数限制之内的佣金规则
                                #region 第一个头寸 （客户或者经济行价格不同 计算的结果就不同）
                                value1 = GetValue(qty, perHand, price1, commissionLine.InLimitRuleType1, commissionLine.InLimitRuleValue1);
                                value2 = GetValue(qty, perHand, price1, commissionLine.InLimitRuleType2, commissionLine.InLimitRuleValue2);
                                #endregion
                                #region 第二个头寸 （客户或者经济行价格不同 计算的结果就不同）
                                value3 = GetValue(qty, perHand, price2, commissionLine.InLimitRuleType1, commissionLine.InLimitRuleValue1);
                                value4 = GetValue(qty, perHand, price2, commissionLine.InLimitRuleType2, commissionLine.InLimitRuleValue2);
                                #endregion
                                positionValue1 = value1 + value2;//第一个头寸的佣金
                                positionValue2 = value3 + value4;//第二个头寸的佣金
                                #endregion
                                if (commissionLine.InLimitIsOneLeg != null && commissionLine.InLimitIsOneLeg.Value)//单边收取
                                {
                                    SetPositionCommissionValue(CarryLegPickUpRules.FarPromptDateLeg, position1, position2, ref positionValue1, ref positionValue2);
                                }
                            }
                            else
                            {
                                #region 天数限制之外的佣金规则
                                #region 第一个头寸（客户或者经济行价格不同 计算的结果就不同）
                                value1 = GetValue(qty, perHand, price1, commissionLine.OutLimitRuleType1, commissionLine.OutLimitRuleValue1);
                                value2 = GetValue(qty, perHand, price1, commissionLine.OutLimitRuleType2, commissionLine.OutLimitRuleValue2);
                                #endregion
                                #region 第二个头寸（客户或者经济行价格不同 计算的结果就不同）
                                value3 = GetValue(qty, perHand, price2, commissionLine.OutLimitRuleType1, commissionLine.OutLimitRuleValue1);
                                value4 = GetValue(qty, perHand, price2, commissionLine.OutLimitRuleType2, commissionLine.OutLimitRuleValue2);
                                #endregion
                                positionValue1 = value1 + value2;
                                positionValue2 = value3 + value4;
                                #endregion
                                if (commissionLine.OutLimieIsOneLeg != null && commissionLine.OutLimieIsOneLeg.Value)//单边收取
                                {
                                    SetPositionCommissionValue(CarryLegPickUpRules.FarPromptDateLeg, position1, position2, ref positionValue1, ref positionValue2);
                                }
                            }
                            commissionValue1 = positionValue1;
                            commissionValue2 = positionValue2;
                        }
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private decimal? GetValue(decimal? qty, int perHand, decimal? price, int? ruleType, decimal? ruleValue)
        {
            decimal? value = 0;
            if (ruleType == (int)CommissionRuleType.Percent)
            {
                value = qty * perHand * price * ruleValue / 100;
            }
            else if (ruleType == (int)CommissionRuleType.PerUnit)
            {
                value = qty * perHand * ruleValue;
            }
            return value;
        }

        private void SetPositionCommissionValue(CarryLegPickUpRules rule, LMEPosition position1, LMEPosition position2, ref decimal? positionValue1, ref decimal? positionValue2)
        {
            if (rule == CarryLegPickUpRules.FarPromptDateLeg)
            {
                if (position1.PromptDate.Value > position2.PromptDate.Value)
                {
                    positionValue2 = 0;
                }
                else
                {
                    positionValue1 = 0;
                }
            }
        }
        #endregion

        private void CreateHeader(int userId, Commission header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Create(GetObjSet<Commission>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void CreateLine(int userId, Commission header, CommissionLine line)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var newLine = new CommissionLine
                                      {
                                          Comment = line.Comment,
                                          CommissionId = header.Id,
                                          CommodityId = line.CommodityId,
                                          EndDate = line.EndDate,
                                          RuleType = line.RuleType,
                                          RuleValue = line.RuleValue,
                                          RuleType2 = line.RuleType2,
                                          RuleValue2 = line.RuleValue2,
                                          CarryDaysLimit = line.CarryDaysLimit,
                                          InLimitIsOneLeg = line.InLimitIsOneLeg,
                                          InLimitRuleType1 = line.InLimitRuleType1,
                                          InLimitRuleValue1 = line.InLimitRuleValue1,
                                          InLimitRuleType2 = line.InLimitRuleType2,
                                          InLimitRuleValue2 = line.InLimitRuleValue2,
                                          OutLimieIsOneLeg = line.OutLimieIsOneLeg,
                                          OutLimitRuleType1 = line.OutLimitRuleType1,
                                          OutLimitRuleValue1 = line.OutLimitRuleValue1,
                                          OutLimitRuleType2 = line.OutLimitRuleType2,
                                          OutLimitRuleValue2 = line.OutLimitRuleValue2,
                                          StartDate = line.StartDate
                                      };
                    Create(GetObjSet<CommissionLine>(ctx), newLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void UpdateHeader(int userId, Commission header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Commission commission = QueryForObj(GetObjQuery<Commission>(ctx), c => c.Id == header.Id);
                    commission.BPId = header.BPId;
                    commission.CommissionType = header.CommissionType;
                    commission.InternalBPId = header.InternalBPId;
                    commission.IsDefaultRule = header.IsDefaultRule;
                    Update(GetObjSet<Commission>(ctx), commission);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void UpdateLine(int userId, CommissionLine commissionLine)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    CommissionLine oldLine = QueryForObj(GetObjQuery<CommissionLine>(ctx),
                                                         c => c.Id == commissionLine.Id);
                    oldLine.Comment = commissionLine.Comment;
                    oldLine.CommissionId = commissionLine.CommissionId;
                    oldLine.CommodityId = commissionLine.CommodityId;
                    oldLine.EndDate = commissionLine.EndDate;
                    oldLine.RuleType = commissionLine.RuleType;
                    oldLine.RuleValue = commissionLine.RuleValue;
                    oldLine.RuleType2 = commissionLine.RuleType2;
                    oldLine.RuleValue2 = commissionLine.RuleValue2;
                    oldLine.CarryDaysLimit = commissionLine.CarryDaysLimit;
                    oldLine.InLimitIsOneLeg = commissionLine.InLimitIsOneLeg;
                    oldLine.InLimitRuleType1 = commissionLine.InLimitRuleType1;
                    oldLine.InLimitRuleValue1 = commissionLine.InLimitRuleValue1;
                    oldLine.InLimitRuleType2 = commissionLine.InLimitRuleType2;
                    oldLine.InLimitRuleValue2 = commissionLine.InLimitRuleValue2;
                    oldLine.OutLimieIsOneLeg = commissionLine.OutLimieIsOneLeg;
                    oldLine.OutLimitRuleType1 = commissionLine.OutLimitRuleType1;
                    oldLine.OutLimitRuleValue1 = commissionLine.OutLimitRuleValue1;
                    oldLine.OutLimitRuleType2 = commissionLine.OutLimitRuleType2;
                    oldLine.OutLimitRuleValue2 = commissionLine.OutLimitRuleValue2;
                    oldLine.StartDate = commissionLine.StartDate;
                    Update(GetObjSet<CommissionLine>(ctx), oldLine);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void DeleteLine(int userId, int id)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                CommissionLine line = QueryForObj(GetObjQuery<CommissionLine>(ctx, new List<string> { "Commission" }), c => c.Id == id);
                line.IsDeleted = true;
                if (
                    QueryForObjs(GetObjQuery<CommissionLine>(ctx),
                                 w => w.CommissionId == line.CommissionId && w.Id != line.Id).Count == 0)
                {
                    line.Commission.IsDeleted = true;
                }
                ctx.SaveChanges();
            }
        }
    }
}