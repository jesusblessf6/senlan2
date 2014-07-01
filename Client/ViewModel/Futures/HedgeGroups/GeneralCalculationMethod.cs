using System;
using System.Linq;
using Client.CurrencyServiceReference;
using Client.HedgeGroupServiceReference;
using Client.RateServiceReference;
using Client.View.Futures.HedgeGroups;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using System.Collections.Generic;

namespace Client.ViewModel.Futures.HedgeGroups
{
    public class GeneralCalculationMethod : IPLCalculationMethod
    {
        public void Calculate(HedgeGroupDetailVM vm)
        {
            if (CheckForSettlement(vm))
            {
                //CalculatePL(vm);
                CalculateTotalFixedPL(vm);
            }
        }

        private bool CheckForSettlement(HedgeGroupDetailVM vm)
        {
            //Check if it is ready to calculate PL

            #region ԭʼ����


            //if (vm.AddedQuotas.Any(o => o.Quota.PricingStatus != (int)PricingStatus.Complete))
            //{
            //    throw new Exception(ResHedgeGroup.NotAllPriced);
            //}

            //if (vm.AddedQuotas.Any(o => !o.Quota.DeliveryStatus))
            //{
            //    throw new Exception(ResHedgeGroup.NotAllDeliveryComplete);
            //}

            //var quotaGroups = vm.AddedQuotas.GroupBy(o => o.Quota.CommodityId);
            //foreach (var quotaGroup in quotaGroups)
            //{
            //    var quotaGroupList = quotaGroup.ToList();
            //    var comSum = (decimal)quotaGroupList.Sum(o => o.Quota.Contract.ContractTypeValue * o.Quota.Quantity);
            //    if (comSum != 0)
            //    {
            //        throw new Exception(ResHedgeGroup.QuotaNotEven);
            //    }
            //}

            //var lmeGroupByComms = vm.AddedLMEPositions.GroupBy(o => o.LMEPosition.CommodityId);
            //foreach (var lmeGroupByComm in lmeGroupByComms)
            //{
            //    var lmeListByComm = lmeGroupByComm.ToList();
            //    var lmeGroupByPrompts = lmeListByComm.GroupBy(o => o.LMEPosition.PromptDate);
            //    foreach (var lmeGroupByPrompt in lmeGroupByPrompts)
            //    {
            //        var lmeListByPrompt = lmeGroupByPrompt.ToList();
            //        if (Math.Round(lmeListByPrompt.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue), 2) != 0)
            //        {
            //            throw new Exception(ResHedgeGroup.LMENotEven);
            //        }
            //    }
            //}

            //var shfeGroupByComms = vm.AddedSHFEPositions.GroupBy(o => o.SHFEPosition.CommodityId);
            //foreach (var shfeGroupByComm in shfeGroupByComms)
            //{
            //    var shfeListByComm = shfeGroupByComm.ToList();
            //    var shfeGroupBySHFEs = shfeListByComm.GroupBy(o => o.SHFEPosition.SHFEId);
            //    foreach (var shfeGroupBySHFE in shfeGroupBySHFEs)
            //    {
            //        var shfeListBySHFE = shfeGroupBySHFE.ToList();
            //        var openLongSum =
            //            shfeListBySHFE.Where(
            //                o =>
            //                o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
            //                o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
            //        var closeLongSum =
            //            shfeListBySHFE.Where(
            //                o =>
            //                o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
            //                o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
            //        var openShortSum =
            //            shfeListBySHFE.Where(
            //                o =>
            //                o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
            //                o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
            //        var closeShortSum =
            //            shfeListBySHFE.Where(
            //                o =>
            //                o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
            //                o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
            //        if (Math.Round(openLongSum - closeShortSum, 2) != 0 || Math.Round(openShortSum - closeLongSum) != 0)
            //        {
            //            throw new Exception(ResHedgeGroup.SHFENotEven);
            //        }
            //    }
            //}

            #endregion

            switch (vm.SelectedArbitrageTypeId)
            {
                case (int)ArbitrageType.Common:
                    //��ͨ
                    CheckCommon(vm.AddedQuotas,vm.AddedSHFEPositions,vm.AddedLMEPositions);
                    break;
                case (int)ArbitrageType.FPArbitrage:
                //��������
                case (int)ArbitrageType.FPRevArbitrage:
                    //���ַ���
                    CheckFPArbitrage(vm.AddedQuotas, vm.AddedSHFEPositions, vm.AddedLMEPositions);
                    break;
                case (int)ArbitrageType.CarryArbitrage:
                //��������
                case (int)ArbitrageType.CarryRevArbitrage:
                    //���ڷ���
                    CheckCarryArbitrage(vm.AddedQuotas, vm.AddedSHFEPositions, vm.AddedLMEPositions);
                    break;
                case (int)ArbitrageType.MarketArbitrage:
                //��������
                case (int)ArbitrageType.MarketRevArbitrage:
                    //���з���
                    CheckMarketArbitrage(vm.AddedQuotas, vm.AddedSHFEPositions, vm.AddedLMEPositions);
                    break;
            }

            return true;
        }

        #region �ܷ������߼�
        /// <summary>
        /// ��֤��ͨ
        /// </summary>
        private void CheckCommon(IEnumerable<HedgeLineQuota> quotas, IEnumerable<HedgeLineSHFEPosition> shfes, IEnumerable<HedgeLineLMEPosition> lmes)
        {
            AllQuotaPriced(quotas);
            CheckSHFEEven(shfes);
            CheckLMEEven(lmes);
        }

        /// <summary>
        /// ��֤���ޱ�ֵ
        /// </summary>
        private void CheckFPArbitrage(IEnumerable<HedgeLineQuota> quotas, List<HedgeLineSHFEPosition> shfes, List<HedgeLineLMEPosition> lmes)
        {
            AllQuotaPriced(quotas);
            OnlyHasSHFEOrLME(shfes, lmes);
            CheckSHFEEven(shfes);
            CheckLMEEven(lmes);
        }

        /// <summary>
        /// ��֤���ڱ�ֵ
        /// </summary>
        private void CheckCarryArbitrage(List<HedgeLineQuota> quotas, List<HedgeLineSHFEPosition> shfes, List<HedgeLineLMEPosition> lmes)
        {
            HasQuota(quotas);
            OnlyHasSHFEOrLME(shfes, lmes);
            CheckSHFEEven(shfes);
            CheckLMEEven(lmes);
        }

        /// <summary>
        /// ��֤���б�ֵ
        /// </summary>
        private void CheckMarketArbitrage(List<HedgeLineQuota> quotas, List<HedgeLineSHFEPosition> shfes, List<HedgeLineLMEPosition> lmes)
        {
            HasSHFEAndLME(shfes, lmes);
            HasQuota(quotas);
            CheckSHFEEven(shfes);
            CheckLMEEven(lmes);
        }

        /// <summary>
        /// �ж��Ƿ����е��ֻ���ͬ��������
        /// </summary>
        /// <param name="quotas"></param>
        private void AllQuotaPriced(IEnumerable<HedgeLineQuota> quotas)
        {
            if (quotas == null) throw new ArgumentNullException("quotas");

            if (quotas.Any(o => o.Quota.PricingStatus != (int)PricingStatus.Complete))
            {
                throw new Exception(ResHedgeGroup.NotAllPriced);
            }
        }

        /// <summary>
        /// �ж��Ƿ����ֻ���ͬ
        /// </summary>
        /// <param name="quotas"></param>
        private void HasQuota(List<HedgeLineQuota> quotas)
        {
            if (quotas != null && quotas.Count > 0)
            {
                throw new Exception("�������ֻ���ͬ");
            }
        }

        /// <summary>
        /// �ж�ֻ������ͷ�����ֻ������ͷ��
        /// </summary>
        /// <param name="shfes"></param>
        /// <param name="lmes"></param>
        private void OnlyHasSHFEOrLME(List<HedgeLineSHFEPosition> shfes, List<HedgeLineLMEPosition> lmes)
        {
            if ((shfes.Count > 0 && lmes.Count > 0) || (shfes.Count == 0 && lmes.Count == 0))
            {
                throw new Exception("ֻ������ͷ�����ֻ������ͷ��");
            }
        }

        /// <summary>
        /// �жϱ����������ͷ�������ͷ��
        /// </summary>
        /// <param name="shfes"></param>
        /// <param name="lmes"></param>
        private void HasSHFEAndLME(List<HedgeLineSHFEPosition> shfes, List<HedgeLineLMEPosition> lmes)
        {
            if ((shfes.Count == 0 && lmes.Count == 0))
            {
                throw new Exception("�����������ͷ�������ͷ��");
            }
        }

        /// <summary>
        /// �ж�����ƽ��ƽ
        /// </summary>
        /// <param name="shfes"></param>
        private void CheckSHFEEven(IEnumerable<HedgeLineSHFEPosition> shfes)
        {
            var shfeGroupByComms = shfes.GroupBy(o => o.SHFEPosition.CommodityId);
            foreach (var shfeGroupByComm in shfeGroupByComms)
            {
                var shfeListByComm = shfeGroupByComm.ToList();
                var shfeGroupBySHFEs = shfeListByComm.GroupBy(o => o.SHFEPosition.SHFEId);
                foreach (var shfeGroupBySHFE in shfeGroupBySHFEs)
                {
                    var shfeListBySHFE = shfeGroupBySHFE.ToList();
                    var openLongSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                    var closeLongSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                    var openShortSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).Sum(o => o.AssignedLotAmount);
                    var closeShortSum =
                        shfeListBySHFE.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).Sum(o => o.AssignedLotAmount);
                    if (Math.Round(openLongSum - closeShortSum, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) != 0 || Math.Round(openShortSum - closeLongSum) != 0)
                    {
                        throw new Exception(ResHedgeGroup.SHFENotEven);
                    }
                }
            }
        }

        /// <summary>
        /// �ж�����ƽ��ƽ
        /// </summary>
        /// <param name="lmes"></param>
        private void CheckLMEEven(IEnumerable<HedgeLineLMEPosition> lmes)
        {
            var lmeGroupByComms = lmes.GroupBy(o => o.LMEPosition.CommodityId);
            foreach (var lmeGroupByComm in lmeGroupByComms)
            {
                var lmeListByComm = lmeGroupByComm.ToList();
                var lmeGroupByPrompts = lmeListByComm.GroupBy(o => o.LMEPosition.PromptDate);
                foreach (var lmeGroupByPrompt in lmeGroupByPrompts)
                {
                    var lmeListByPrompt = lmeGroupByPrompt.ToList();
                    if (Math.Round(lmeListByPrompt.Sum(o => o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue), RoundRules.QUANTITY, MidpointRounding.AwayFromZero) != 0)
                    {
                        throw new Exception(ResHedgeGroup.LMENotEven);
                    }
                }
            }
        }
        #endregion

        #region ��������ӯ��
        private Currency _cnyCurrency;
        private readonly Dictionary<int, decimal> _cnyRate = new Dictionary<int, decimal>();

        /// <summary>
        /// ���ص�۵�ƽ����
        /// </summary>
        /// <param name="quota"></param>
        /// <param name="userId"></param>
        /// <returns>��������ҵ�ƽ����</returns>
        private decimal GetAveragePrice(Quota quota,int userId)
        {
            decimal averagePrice = 0;
            decimal qtyCount = 0;
            if (quota.Pricings != null)
            {
                List<Pricing> pricingList = quota.Pricings.Where(o => o.IsDeleted == false).ToList();
                decimal amount;
                if (quota.Contract.TradeType == (int)TradeType.LongDomesticTrade ||
                        quota.Contract.TradeType == (int)TradeType.ShortDomesticTrade)
                {
                    //��ó,ֱ��ȡ��۱���ߵĻ���
                    amount = quota.Pricings.Where(o => o.IsDeleted == false).
                        Sum(o => (o.PricingQuantity ?? 0) * (o.FinalPrice ?? 0) * (o.ExchangeRate ?? 0));
                }
                else
                {
                    //��ó��ͨ����ۻ�׼������Ҽ������
                    if (_cnyCurrency == null)
                    {
                        using (var currencyService=SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                        {
                            _cnyCurrency = currencyService.GetCurrencyByCode("CNY");
                        }
                    }

                    decimal currencyRate = 0;
                    //���û�е�۵Ļ���amount���Ϊ0
                    if (pricingList.Count > 0)
                    {
                        if (!_cnyRate.ContainsKey(pricingList[0].CurrencyId.Value))
                        {
                            using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                            {
                                currencyRate = rateService.GetExchangeRate(_cnyCurrency.Id,pricingList[0].CurrencyId.Value, userId) ?? 0;
                            }
                            _cnyRate.Add(pricingList[0].CurrencyId.Value, currencyRate);
                        }
                        else
                        {
                            currencyRate = _cnyRate[pricingList[0].CurrencyId.Value];
                        }
                    }

                    amount = pricingList.Sum(o => (o.PricingQuantity * o.FinalPrice * currencyRate) ?? 0);


                }

                qtyCount += pricingList.Sum(o => o.PricingQuantity ?? 0);

                averagePrice = amount / qtyCount;
            }

            return averagePrice;
        }
        #region �ֻ�����ӯ��
        private decimal CalculatePhysicFixedPL(HedgeGroupDetailVM vm)
        {
            //�ֻ�����ӯ�� = ��(���ۺ�ͬʵ������ * ��ۼ۸� ) - ��(�ɹ���ͬʵ������ * ��ۼ۸� )
            decimal pl = 0;

            foreach (var q in vm.AddedQuotas)
            {
                decimal averagePrice = GetAveragePrice(q.Quota, vm.UserId);
                decimal sum = q.Quota.VerifiedQuantity * averagePrice;

                if (q.Quota.Contract.ContractType == (int)ContractType.Purchase)
                {
                    pl -= sum;
                }
                else
                {
                    pl += sum;
                }
            }
            vm.QuotaFixedPL = pl;
            vm.QuotaFixedPLStr = pl.ToString("N2") + " CNY";

            return pl;
        }
        #endregion

        #region SHFE�ڻ�����ӯ��
        private decimal CalculateSHFEFixedPL(HedgeGroupDetailVM vm)
        {
            //��(��ͷ���� * �۸� ) - ��(��ͷ���� * �۸� )
            decimal shfePL = (decimal)
                             vm.AddedSHFEPositions.Sum(
                                 o =>
                                 o.AssignedLotAmount * o.SHFEPosition.TradeDirectionValue * o.SHFEPosition.Price *
                                 o.SHFEPosition.Commodity.SHFEQtyPerHand) * -1 - vm.AddedSHFEPositions.Sum(o => o.AssignedCommission);
            vm.SHFEPLStr = shfePL.ToString("N2") + " " + vm.SHFEPLCurrency;

            return shfePL;
        }
        #endregion

        #region LME�ڻ�����ӯ��
        private decimal CalculateLMEFixedPL(HedgeGroupDetailVM vm)
        {
            ////��(��ͷ���� * �۸� ) - ��(��ͷ���� * �۸� )
            decimal lmePL = (decimal)vm.AddedLMEPositions.Sum(
                o =>
                o.AssignedLotAmount * o.LMEPosition.TradeDirectionValue * o.LMEPosition.AgentPrice *
                o.LMEPosition.Commodity.LMEQtyPerHand) * -1 -
                            vm.AddedLMEPositions.Sum(o => o.AssignedCommission);
            vm.LMEPLStr = lmePL.ToString("N2") + " " + vm.LMEPLCurrency;

            return lmePL;
        }
        #endregion

        #region �ܵ�����ӯ��
        private void CalculateTotalFixedPL(HedgeGroupDetailVM vm)
        {
            GetRate(vm);
            var quotaPL = CalculatePhysicFixedPL(vm);
            var lmePL = CalculateLMEFixedPL(vm);
            var shfePL = CalculateSHFEFixedPL(vm);

            decimal totalPL = quotaPL + lmePL * _rate + shfePL;
            vm.TotalPLStr = totalPL.ToString("N2") + " CNY";

            if (_cnyCurrency == null)
            {
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    _cnyCurrency = currencyService.GetCurrencyByCode("CNY");
                }
            }

            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                var hg = hgService.GetById(vm.ObjectId);
                hg.PLAmount = totalPL;
                hg.PLCurrencyId = _cnyCurrency.Id;
                hg.PhyFixedPL = quotaPL;
                hg.SHFEFixedPL = shfePL;
                hg.LMEFixedPL = lmePL;
                hg.Status = (int)HedgeGroupStatus.Settled;
                hgService.UpdatehedgeGroupPL(hg, vm.CurrentUser.Id);
            }
        }


        #endregion

        decimal _rate;
        private void GetRate(HedgeGroupDetailVM vm)
        {
            if (vm.Rate == null || vm.Rate == 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    _rate = rateService.GetExchangeRateByCode("USD", "CNY") ?? 0;
                }
            }
            else
            {
                _rate = (decimal)vm.Rate;
            }
        }

        #endregion
    }
}