﻿using System.Data;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Transactions;
using Services.Physical.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using DBEntity.EnumEntity;
using Services.Helper.QuotaHelper;
using DBEntity.EnableProperty;
using System.Text;

namespace Services.Finance.FundFlows
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“FundFlowService”。
    public class FundFlowService : BaseService<FundFlow>, IFundFlowService
    {
        #region IFundFlowService Members

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="fundFlow"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public FundFlow UpdateFundFlow(bool isFundflowFinished,FundFlow fundFlow, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    //UpdateDocument(fundFlow, userId);

                    #region 判断是否有关联的自动生存数据 同时修改
                    using(var ctx = new SenLan2Entities())
                    {
                        var autoFundFlow = QueryForObj(GetObjQuery<FundFlow>(ctx), c => c.FundFlowId == fundFlow.Id && c.IsAutoGenerated);
                        if(autoFundFlow != null)
                        {
                            int quotaId = QuotaHelper.GetAutoGeneratedQuotaId(fundFlow.QuotaId ?? 0);
                            if (quotaId == 0)
                            {
                                autoFundFlow.QuotaId = null;
                            }
                            else
                            {
                                autoFundFlow.QuotaId = quotaId;
                            }
                            autoFundFlow.BPId = fundFlow.InternalBPId;
                            autoFundFlow.InternalBPId = fundFlow.BPId;
                            autoFundFlow.BankAccountId = fundFlow.BankAccountId;
                            autoFundFlow.Amount = fundFlow.Amount;
                            autoFundFlow.TradeDate = fundFlow.TradeDate;
                            autoFundFlow.CurrencyId = fundFlow.CurrencyId;
                            autoFundFlow.Rate = fundFlow.Rate;
                            autoFundFlow.FinancialAccountId = fundFlow.FinancialAccountId;
                            autoFundFlow.PaymentMeanId = fundFlow.PaymentMeanId;
                            autoFundFlow.PaymentRequestId = fundFlow.PaymentRequestId;
                            autoFundFlow.Description = fundFlow.Description;
                            autoFundFlow.FundFlowId = fundFlow.Id;
                            autoFundFlow.IsAutoGenerated = true;
                            UpdateDocument(isFundflowFinished, autoFundFlow, userId);
                        }
                        else {
                             #region 判断是否自动生成
                            if (IsInternalCustomer(fundFlow.InternalBPId, fundFlow.BPId,userId))
                            {
                                int quotaId = QuotaHelper.GetAutoGeneratedQuotaId(fundFlow.QuotaId ?? 0);
                                var newFundFlow = new FundFlow
                                                      {
                                                          BPId = fundFlow.InternalBPId,
                                                          InternalBPId = fundFlow.BPId,
                                                          TradeDate = fundFlow.TradeDate,
                                                          BankAccountId = fundFlow.BankAccountId,
                                                          Amount = fundFlow.Amount,
                                                          CurrencyId = fundFlow.CurrencyId,
                                                          Rate = fundFlow.Rate,
                                                          FinancialAccountId = fundFlow.FinancialAccountId,
                                                          PaymentMeanId = fundFlow.PaymentMeanId,
                                                          Description = fundFlow.Description,
                                                          FundFlowId = fundFlow.Id,
                                                          IsAutoGenerated = true
                                                      };
                                if (quotaId > 0)
                                {
                                    newFundFlow.QuotaId = quotaId;
                                }
                                if (fundFlow.RorP == (int)FundFlowType.Pay)
                                {
                                    newFundFlow.RorP = (int)FundFlowType.Receive;
                                }
                                else
                                {
                                    newFundFlow.RorP = (int)FundFlowType.Pay;
                                }

                                CreateFundFlow(isFundflowFinished,newFundFlow, userId);
                                fundFlow.FundFlowId = newFundFlow.Id;
                                fundFlow.IsAutoGenerated = false;
                            }
                         #endregion
                        }

                    }
                    UpdateDocument(isFundflowFinished,fundFlow, userId);
                    #endregion

                    ts.Complete();
                    return fundFlow;
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

        private void UpdateDocument(bool isFundflowFinished,FundFlow fundFlow, int userId)
        {
            try
            {
                int oldQuotaId = 0;
                using (var ctx = new SenLan2Entities(userId))
                {
                    var oldFundFlow = QueryForObj(GetObjQuery<FundFlow>(ctx), o => o.Id == fundFlow.Id);
                    if (oldFundFlow.QuotaId.HasValue)
                        oldQuotaId = oldFundFlow.QuotaId.Value;
                    oldFundFlow.Amount = fundFlow.Amount;
                    oldFundFlow.BankAccountId = fundFlow.BankAccountId;
                    oldFundFlow.BPId = fundFlow.BPId;
                    oldFundFlow.CurrencyId = fundFlow.CurrencyId;
                    oldFundFlow.Description = fundFlow.Description;
                    oldFundFlow.FinancialAccountId = fundFlow.FinancialAccountId;
                    oldFundFlow.InternalBPId = fundFlow.InternalBPId;
                    oldFundFlow.PaymentRequestId = fundFlow.PaymentRequestId;
                    oldFundFlow.QuotaId = fundFlow.QuotaId;
                    oldFundFlow.Rate = fundFlow.Rate;
                    oldFundFlow.RorP = fundFlow.RorP;
                    oldFundFlow.TradeDate = fundFlow.TradeDate;
                    oldFundFlow.PaymentMeanId = fundFlow.PaymentMeanId == 0 ? null : fundFlow.PaymentMeanId;
                    oldFundFlow.FundFlowId = fundFlow.FundFlowId;
                    oldFundFlow.IsAutoGenerated = fundFlow.IsAutoGenerated;
                    Update(GetObjSet<FundFlow>(ctx), oldFundFlow);
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == fundFlow.QuotaId);
                    if (quota != null && quota.Id > 0)
                    {
                        quota.IsFundflowFinished = isFundflowFinished;
                        Update(GetObjSet<Quota>(ctx), quota);
                    }
                    if (oldQuotaId != 0 && oldQuotaId != fundFlow.QuotaId.Value)
                    {
                        Quota oldQuota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == oldQuotaId);
                        oldQuota.IsFundflowFinished = false;
                        Update(GetObjSet<Quota>(ctx), oldQuota);
                    }
                    ctx.SaveChanges();
                }
                //修改批次的已收已付金额
                var quotaService = new QuotaService();
                quotaService.SetPaidAndReceivedAmount(fundFlow.QuotaId, userId);
                if (oldQuotaId != 0)
                {
                    //修改以前的批次的已收已付金额
                    if (fundFlow.QuotaId.HasValue)
                    {
                        if (oldQuotaId != fundFlow.QuotaId.Value)
                        {
                            quotaService.SetPaidAndReceivedAmount(oldQuotaId, userId);
                        }
                    }
                    else
                    {
                        quotaService.SetPaidAndReceivedAmount(oldQuotaId, userId);
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="fundFlow"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public FundFlow AddNewFundFlow(bool isFundflowFinished,FundFlow fundFlow, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateFundFlow(isFundflowFinished,fundFlow, userId);

                    #region 判断是否自动生成
                    if (IsInternalCustomer(fundFlow.InternalBPId, fundFlow.BPId,userId))
                    {
                        int quotaId = QuotaHelper.GetAutoGeneratedQuotaId(fundFlow.QuotaId ?? 0);
                        if (quotaId > 0)
                        {
                            var newFundFlow = new FundFlow
                                                  {
                                                      BPId = fundFlow.InternalBPId,
                                                      InternalBPId = fundFlow.BPId,
                                                      TradeDate = fundFlow.TradeDate,
                                                      BankAccountId = fundFlow.BankAccountId,
                                                      Amount = fundFlow.Amount,
                                                      CurrencyId = fundFlow.CurrencyId,
                                                      Rate = fundFlow.Rate,
                                                      FinancialAccountId = fundFlow.FinancialAccountId,
                                                      PaymentMeanId = fundFlow.PaymentMeanId,
                                                      //PaymentRequestId = fundFlow.PaymentRequestId,
                                                      Description = fundFlow.Description,
                                                      FundFlowId = fundFlow.Id,
                                                      IsAutoGenerated = true
                                                  };

                            newFundFlow.QuotaId = quotaId;

                            if (fundFlow.RorP == (int)FundFlowType.Pay)
                            {
                                newFundFlow.RorP = (int)FundFlowType.Receive;
                            }
                            else
                            {
                                newFundFlow.RorP = (int)FundFlowType.Pay;
                            }

                            CreateFundFlow(isFundflowFinished, newFundFlow, userId);
                            fundFlow.FundFlowId = newFundFlow.Id;
                            fundFlow.IsAutoGenerated = false;
                            UpdateDocument(isFundflowFinished, fundFlow, userId);
                        }
                    }
                    #endregion

                    ts.Complete();
                    return fundFlow;
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

        private void CreateFundFlow(bool isFundflowFinished,FundFlow fundFlow, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    Quota quota = QueryForObj(GetObjQuery<Quota>(ctx), c => c.Id == fundFlow.QuotaId);
                    if (quota != null && quota.Id > 0)
                    {
                        quota.IsFundflowFinished = isFundflowFinished;
                        Update(GetObjSet<Quota>(ctx), quota);
                    }
                    Create(GetObjSet<FundFlow>(ctx), fundFlow);
                    ctx.SaveChanges();
                }
                //修改批次的已收已付金额
                var quotaService = new QuotaService();
                quotaService.SetPaidAndReceivedAmount(fundFlow.QuotaId, userId);
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    DeleteFunFlow(id, userId);

                    #region 如果有自动生成的数据 同时删除
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        var autoFundflow = QueryForObj(GetObjQuery<FundFlow>(ctx), c => c.FundFlowId == id && c.IsAutoGenerated);
                        if(autoFundflow != null)
                        {
                            DeleteFunFlow(autoFundflow.Id, userId);
                        }
                    }
                    #endregion

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
            }
        }

        private void DeleteFunFlow(int id, int userId)
        {
            try
            {
                int quotaId = 0;
                using (var ctx = new SenLan2Entities(userId))
                {
                    //查找关联单据，由于现金收付无后续单据直接删除即可
                    FundFlow ff = QueryForObj(GetObjQuery<FundFlow>(ctx, new List<string> { "PaymentRequest","Quota" }), f => f.Id == id);
                    if (ff.QuotaId.HasValue)
                        quotaId = ff.QuotaId.Value;
                    ff.IsDeleted = true;
                    //如果是针对已经付款申请进行的收付款，删除后把付款申请的付款完成字段清掉
                    if (ff.PaymentRequest != null)
                    {
                        ff.PaymentRequest.IsPaid = false;
                    }
                    if(ff.Quota != null)
                    {
                        ff.Quota.IsFundflowFinished = false;
                    }
                    ctx.SaveChanges();
                }
                //修改批次的已收已付金额
                var quotaService = new QuotaService();
                quotaService.SetPaidAndReceivedAmount(quotaId, userId);
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// 应收应付报表页面数据
        /// </summary>
        /// <param name="internalCustomerId"></param>
        /// <param name="customerId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<FundFlow> GetListByParameter(int? internalCustomerId, int? customerId, DateTime? startDate, DateTime? endDate, int userId)
        {
            try
            {
                List<object> parameters = new List<object>();
                var sb = new StringBuilder();
                string queryStr;
                int num = 1;
                sb.AppendFormat("it.FinancialAccount.IsIncludedInAPAR = true and (it.QuotaId = 0 or it.QuotaId is NULL) ");
                if (internalCustomerId != null && internalCustomerId != 0)
                {
                    if(sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.InternalBPId = @p{0}", num++);
                    parameters.Add(internalCustomerId);
                }

                if (customerId != null && customerId != 0)
                {
                    if(sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.BPId = @p{0}", num++);
                    parameters.Add(customerId);
                }

                if (startDate.HasValue)
                {
                    if(sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.TradeDate >= @p{0}", num++);
                    parameters.Add(startDate.Value);
                }

                if (endDate.HasValue)
                {
                    if(sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.AppendFormat("it.TradeDate <= @p{0}", num);
                    parameters.Add(endDate.Value);
                }

                queryStr = sb.ToString();

                using (var ctx = new SenLan2Entities(userId))
                {
                    List<FundFlow> list = Select(queryStr, parameters, new List<string>
                                                      {
                                                          "BusinessPartner",
                                                          "InternalCustomer",
                                                          "Currency",
                                                          "FinancialAccount"
                                                      }).ToList();

                    User currentUser = QueryForObj(GetObjQuery<User>(ctx, new List<string> { "UserICLinks" }), o => o.Id == userId);
                    List<UserICLink> userICLink = currentUser.UserICLinks.ToList();
                    List<int> idList = userICLink.Select(o => o.BusinessPartnerId).ToList();
                    return list.Where(ff => idList.Contains(ff.InternalBPId)).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private bool IsInternalCustomer(int rId, int pId,int userId)
        { 
            bool isResult = false;
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    var x = QueryForObjs(GetObjQuery<UserICLink>(ctx), o => o.UserId == userId).ToList();
                    List<int> bps = x.Select(o => o.BusinessPartnerId).Distinct().ToList();

                    //BusinessPartner rCustomer = QueryForObj(GetObjQuery<BusinessPartner>(ctx), c => c.Id == rId);
                    //BusinessPartner pCustomer = QueryForObj(GetObjQuery<BusinessPartner>(ctx), c => c.Id == pId);
                    if (bps.Contains(rId) && bps.Contains(pId))
                    {
                        isResult = true;
                    }
                    return isResult;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
        #endregion

        #region 编辑属性
        public FundFlowEnableProperty SetElementsEnableProperty(int id)
        {
            try
            {
                var ffep = new FundFlowEnableProperty();
                using (var ctx = new SenLan2Entities())
                {
                    //有自动产生的单据，则不可以修改内部客户和客户
                    FundFlow fund = QueryForObj(GetObjQuery<FundFlow>(ctx), ff => ff.Id == id);
                    if (fund != null && fund.FundFlowId != null)
                    {
                        ffep.IsBPEnable = false;
                        ffep.IsInternalCustomerEnable = false;
                    }
                    return ffep;
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