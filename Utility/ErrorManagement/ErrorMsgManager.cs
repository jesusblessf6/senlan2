using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;

namespace Utility.ErrorManagement
{
    public class ErrorMsgManager
    {
        private static readonly Dictionary<Type, ErrCode> ExErrMap;
        private static readonly Dictionary<ErrCode, string> ErrMsgMap;

        static ErrorMsgManager()
        {
            ExErrMap = new Dictionary<Type, ErrCode>
                           {
                               {typeof (EndpointNotFoundException), ErrCode.EndpointNotFound},
                               {typeof (TimeoutException), ErrCode.TimeoutErr},
                               //{typeof(GTS.Utility.CertException), ErrCode.CertNotFound}
                           };

            ErrMsgMap = new Dictionary<ErrCode, string>
                            {
                                {ErrCode.UnkownErr, "未知错误"},
                                {ErrCode.OptimisticConcurrencyErr, "数据已经被修改，请刷新后重试"},
                                {ErrCode.EndpointNotFound, "无法连接服务"},
                                {ErrCode.FetchUnreadTransErr, "获取未读的交易数量失败"},
                                {ErrCode.TimeoutErr, "连接服务超时，请稍后重试！"},
                                {ErrCode.LoginFailErr, "用户名或密码错误!"},
                                {ErrCode.ObjectNotFound, "找不到该对象！"},
                                {ErrCode.LoginNameExisted, "登录名已存在！"},
                                {ErrCode.CurrencyExisted, "币种名称或币种代码已存在！"},
                                {ErrCode.RateExisted, "币种汇率已存在！"},
                                {ErrCode.CountryExisted, "国家名称已存在！"},
                                {ErrCode.UdfExisted, "类型名称已存在！"},
                                {ErrCode.PortExisted, "港口名称已存在！"},
                                {ErrCode.DeleteFKErr, "删除失败，请检查关联对象！"},
                                {ErrCode.DeleteErr, "删除失败！"},
                                {ErrCode.PaymentMeanExisted,"付款方式已经存在"},
                                {ErrCode.VATRateExisted,"税率代码已经存在"},
                                {ErrCode.PaymentUsageExisted,"付款用途已经存在"},
                                {ErrCode.StringOverflow,"文本长度超出限定值"},
                                {ErrCode.RoleNameExisted, "角色名已存在！"},
                                {ErrCode.ApprovalConditionCollapsed, "审批流程条件有重叠！"},
                                {ErrCode.ApprovalNameExisted, "审批流程名称重复！"},
                                {ErrCode.FinancialAccountAddFKErr, "新增失败，已经跟付款用途进行关联！"},
                                {ErrCode.FinancialAccountUpdateFKErr, "修改失败，已经跟付款用途进行关联！"},
                                {ErrCode.FinancialAccountExisted, "会计科目名称已存在！"},
                                {ErrCode.FinancialAccountUpdate2FKErr, "修改失败，有子目录不能更改上级科目！"},
                                {ErrCode.PaymentUsagePAExisted, "保存失败，默认会计科目下不能有子级科目！"},
                                {ErrCode.BankNameExisted, "银行名称已存在！"},
                                {ErrCode.BankAccountUsed, "该银行账号已经被使用，不能更改！"},
                                {ErrCode.BankAccountExisted, "银行账户已存在！"},
                                {ErrCode.CommodityTypeExisted, "金属类型已存在！"},
                                {ErrCode.BrandExisted, "金属品牌已存在！"},
                                {ErrCode.SpecificationExisted, "金属规格已存在！"},
                                {ErrCode.QuotaCommercialInvoiceConnected, "该批次和商业发票关联，无法删除！"},
                                {ErrCode.QuotaDeliveryConnected, "该批次和提单或发货单关联，无法删除！"},
                                {ErrCode.QuotaFundFlowConnected, "该批次和现金收付关联，无法删除！"},
                                {ErrCode.QuotaLetterOfCreditConnected, "该批次和信用证关联，无法删除！"},
                                {ErrCode.QuotaPaymentRequestConnected, "该批次和付款申请关联，无法删除！"},
                                {ErrCode.QuotaVATInvoiceConnected, "该批次和增值税发票关联，无法删除！"},
                                {ErrCode.QuotaVATInvoiceRequestConnected, "该批次和增值税开票申请关联，无法删除！"},
                                {ErrCode.QuotaWarehouseOutConnected, "该批次和出库关联，无法删除！"},
                                {ErrCode.QuotaPricingConnected, "该批次和点价关联，无法删除！"},
                                {ErrCode.PaymentRequestFundFlowConnected, "该付款申请和现金收付关联，无法删除！"},
                                {ErrCode.PaymentRequestLCConnected, "该付款申请和信用证关联，无法删除！"},
                                {ErrCode.QuotaNotExisted, "批次不存在!"},
                                {ErrCode.NotInApproval, "找不到审批流程或当前审批步骤已通过!"},
                                {ErrCode.ApprovalStageNotFound, "找不到审批步骤！"},
                                {ErrCode.DeliveryWarehouseInConnected, "该提单和入库关联，无法删除！"},
                                {ErrCode.DeliveryPaymentRequestConnected, "该提单和付款申请关联，无法删除！"},
                                {ErrCode.DeliveryDeliveryConnected, "该提单和发货单关联，无法删除！"},
                                {ErrCode.DeliveryCommercialInvoiceConnected, "该提单和商业发票关联，无法删除！"},
                                {ErrCode.DeliveryLCConnected, "该提单和信用证关联，无法删除！"},
                                {ErrCode.WarehouseInWarehouseOutConnected, "该入库已经和出库关联，无法删除！"},
                                {ErrCode.UnpricingQuantityNotEnough, "点价数量超过未点价数量！"},
                                {ErrCode.PricingVATInvoiceConnected, "该批次已经点价完成并开具增值税发票，无法删除！"},
                                {ErrCode.UnpricingNotFound, "找不到相应的未点批次！"},
                                {ErrCode.PricingUnpricingConnected, "已经被点价，无法删除或编辑！"},
                                {ErrCode.UnpricingUnpricingConnected, "被再次延期，无法删除或编辑！"}, 
                                {ErrCode.FinalInvoiceIdExisted,"已关联最终发票，无法删除！"},
                                {ErrCode.OldPasswordErr, "旧密码不正确！"},
                                {ErrCode.PaymentRequestNotFound, "找不到相应的付款申请！"},
                                {ErrCode.DocumentNotFound, "找不到相应的单据！"},
                                {ErrCode.VATInvoiceRequestLineConnected, "该增值税发票申请和增值税发票关联，无法删除！"},
                                {ErrCode.SaleDeliveryConnected, "该单据与发货单关联，无法删除！"},
                                {ErrCode.LogActionNotFound, "找不到相应的日志事件！"},
                                {ErrCode.PricingCurrencyNotMatch, "点价币种与批次不一致！"},
                                {ErrCode.CurrencyNotFound, "找不到币种！"},
                                {ErrCode.LMEPositionNotFound, "找不到LME头寸！"},
                                {ErrCode.SHFEPositionNotFound, "占不到SHFE头寸！"},
                                {ErrCode.HedgeGroupNotFound, "找不到分组保值！"},
                                {ErrCode.HedgeGroupLineQuotaNotFound, "找不到分组保值中的该批次行！"},
                                {ErrCode.HedgeGroupLineLMEPositionNotFound, "找不到分组保值中的该LME头寸行！"},
                                {ErrCode.HedgeGroupLineSHFEPositionNotFound, "找不到分组保值中的该SHFE头寸行！"},
                                {ErrCode.QuotaHedgedNotAbleToDeleteModify, "已加入保值分组的批次不能删除或修改"},
                                {ErrCode.HedgeGroupSettledNotForModify, "已结算保值分组不能修改！"},
                                {ErrCode.LMEPositionHedged, "已参与保值LME头寸不能修改或删除！"},
                                {ErrCode.ExceedPricingDateRange, "点价日期超出批次点价日期范围！"},
                                {ErrCode.WarehouseExisted, "库存简称不能重复！"},
                                {ErrCode.FinancialAccountFundFlowConnected, "会计科目和现金收付关联，不能删除！"},
                                {ErrCode.FinancialAccountPaymentUsageConnected, "会计科目和付款用途关联，不能删除！"},
                                {ErrCode.LCCommercialInvoiceConnected, "信用证和商业发票关联，不能删除！"},
                                {ErrCode.DeliveryLineNotHasTempUnitPrice,"有提单行没有暂定价!"},
                                {ErrCode.DeleteRelQuotaConnected,"是自动生成的单据，不能删除!"},
                                {ErrCode.EditRelQuotaConnected,"是自动生成的单据，不能编辑!"},
                                {ErrCode.DuplicatedDeliveryPersonInfo, "提货人信息重复！"},
                                {ErrCode.NotDuringApproval, "不在审批流程中！"},
                                {ErrCode.DuplicatedDeliveryNo, "提单/仓单号已存在！"},
                                {ErrCode.InvoiceHasPayMentRequest, "发票与付款申请关联，不能删除！"}
                            };
        }

        public static ErrCode GetErrCode(Exception e)
        {
            if (e is FaultException<ServerErr>)
            {
                ServerErr err = (e as FaultException<ServerErr>).Detail;
                return err.ErrCode;
            }

            return GetErrCode(e.GetType());
        }

        public static ErrCode GetErrCode(Type type)
        {
            if (ExErrMap.ContainsKey(type))
            {
                return ExErrMap[type];
            }

            return ErrCode.UnkownErr;
        }

        public static string GetErrMsg(Exception e)
        {
            if (e is FaultException)
            {
                return (e as FaultException).Reason.ToString();
            }
            ErrCode errCode = GetErrCode(e);
            if (errCode != ErrCode.UnkownErr)
            {
                return GetErrMsg(errCode);
            }

            return e.Message;
        }

        public static string GetErrMsg(ErrCode errCode)
        {
            if (ErrMsgMap.ContainsKey(errCode))
            {
                return ErrMsgMap[errCode];
            }

            return ErrMsgMap[ErrCode.UnkownErr];
        }

        public static string GetClientErrMsg(Exception e, CultureInfo info)
        {
            if (e is FaultException)
            {
                var s = ResErrorMsg.ResourceManager.GetString((e as FaultException).Reason.ToString(), info);
                if (!string.IsNullOrWhiteSpace(s))
                {
                    return s;
                }
            }

            return e.Message;
        }
    }
}
