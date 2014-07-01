using System;
using System.Collections.Generic;
using System.Linq;
using Client.CurrencyServiceReference;
using Client.HedgeGroupServiceReference;
using Client.RateServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.HedgeGroups
{
    public class Method4ChinaCopper : IPLCalculationMethod
    {
        public void Calculate(HedgeGroupDetailVM vm)
        {
            //Get Rate
            decimal rate;
            if (vm.Rate == null || vm.Rate == 0)
            {
                using (var rateService = SvcClientManager.GetSvcClient<RateServiceClient>(SvcType.RateSvc))
                {
                    rate = rateService.GetExchangeRateByCode("USD", "CNY") ?? 0;
                }
            }
            else
            {
                rate = (decimal)vm.Rate;
            }

            //quota
            var quotaGroups = vm.AddedQuotas.GroupBy(o => o.Quota.CommodityId);
            decimal? quotaTotalPL = 0;
            foreach (var quotaGroup in quotaGroups)
            {
                var quotasByComm = quotaGroup.ToList().Select(o => o.Quota).ToList();
                var quotasBuy = quotasByComm.Where(o => o.Contract.ContractType == (int) ContractType.Purchase).ToList();
                var quotasSell = quotasByComm.Where(o => o.Contract.ContractType == (int) ContractType.Sales).ToList();

                var buyQty = quotasBuy.Sum(o => o.ActualQuantity);
                var sellQty = quotasSell.Sum(o => o.ActualQuantity);
                var closedQty = buyQty < sellQty ? buyQty : sellQty;
                if (Math.Round(closedQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                {
                    continue;
                }

                decimal? sellAmount = 0;
                foreach (var quota in quotasSell)
                {
                    if(quota.Currency.Code == "USD" && vm.QuotaPLCurrency == "CNY")
                    {
                        sellAmount += quota.ActualQuantity*quota.AveragePrice*rate;
                    }
                    else
                    {
                        sellAmount += quota.ActualQuantity*quota.AveragePrice;
                    }
                }
                var avgSellPrice = sellAmount/sellQty;

                decimal? buyAmount = 0;
                foreach (var quota in quotasBuy)
                {
                    if (quota.Currency.Code == "USD" && vm.QuotaPLCurrency == "CNY")
                    {
                        buyAmount += quota.ActualQuantity * quota.AveragePrice * rate;
                    }
                    else
                    {
                        buyAmount += quota.ActualQuantity * quota.AveragePrice;
                    }
                }
                var avgBuyPrice = buyAmount / buyQty;

                quotaTotalPL += (avgSellPrice - avgBuyPrice)*closedQty;
            }

            vm.QuotaPLStr = (vm.AddedQuotas.Count == 0 || quotaTotalPL == null) ? "" : (quotaTotalPL.Value.ToString("N2") + " " + vm.QuotaPLCurrency);

            //LME PL
            var lmeGroups = vm.AddedLMEPositions.GroupBy(o => o.LMEPosition.CommodityId);
            decimal? lmePLAmount = 0;
            foreach (var lmeGroup in lmeGroups)
            {
                var lmesByComm = lmeGroup.ToList();
                var lmesGroupByPrompt = lmesByComm.GroupBy(o => o.LMEPosition.PromptDate);
                foreach (var lmeGroupByPrompt in lmesGroupByPrompt)
                {
                    var lmesByPrompt = lmeGroupByPrompt.ToList();
                    var lmesLong = lmesByPrompt.Where(o => o.LMEPosition.TradeDirection == (int) PositionDirection.Long).OrderBy(o => o.LMEPosition.TradeDate).ThenBy(o => o.LMEPositionId).ToList();
                    var lmesShort = lmesByPrompt.Where(o => o.LMEPosition.TradeDirection == (int) PositionDirection.Short).OrderBy(o => o.LMEPosition.TradeDate).ThenBy(o => o.LMEPositionId).ToList();

                    decimal longQty = lmesLong.Sum(o => o.AssignedLotAmount);
                    decimal shortQty = lmesShort.Sum(o => o.AssignedLotAmount);
                    decimal closeQty = longQty < shortQty ? longQty : shortQty;
                    if (Math.Round(closeQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) == 0)
                    {
                        continue;
                    }

                    decimal longAmount, longCommission, shortAmount, shortCommission;
                    LMEByPromptPL(out longAmount, out longCommission, lmesLong, closeQty);
                    LMEByPromptPL(out shortAmount, out shortCommission, lmesShort, closeQty);
                    lmePLAmount += shortAmount - longAmount - longCommission - shortCommission;
                }
            }
            vm.LMEPLStr = (vm.AddedLMEPositions.Count == 0 || lmePLAmount == null) ? "" : (lmePLAmount.Value.ToString("N2") + " " + vm.LMEPLCurrency);

            //SHFE PL
            var shfeGroups = vm.AddedSHFEPositions.GroupBy(o => o.SHFEPosition.CommodityId);
            decimal? shfePLAmount = 0;
            foreach (var shfeGroup in shfeGroups)
            {
                var shfesByComm = shfeGroup.ToList();
                var shfesGroupByContract = shfesByComm.GroupBy(o => o.SHFEPosition.SHFEId);
                foreach (var s in shfesGroupByContract)
                {
                    var shfesByContract = s.ToList();
                    var shfesOpenLong =
                        shfesByContract.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int) PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int) PositionOpenClose.Open).
                            OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ThenBy(o => o.SHFEPositionId).
                            ToList();
                    var shfesOpenShort =
                        shfesByContract.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Open).
                            OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ThenBy(o => o.SHFEPositionId).
                            ToList();
                    var shfesCloseLong =
                        shfesByContract.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Long &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).
                            OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ThenBy(o => o.SHFEPositionId).
                            ToList();
                    var shfesCloseShort =
                        shfesByContract.Where(
                            o =>
                            o.SHFEPosition.PositionDirection == (int)PositionDirection.Short &&
                            o.SHFEPosition.OpenClose == (int)PositionOpenClose.Close).
                            OrderBy(o => o.SHFEPosition.SHFECapitalDetail.TradeDate).ThenBy(o => o.SHFEPositionId).
                            ToList();

                    decimal openLongQty = shfesOpenLong.Sum(o => o.AssignedLotAmount);
                    decimal openShortQty = shfesOpenShort.Sum(o => o.AssignedLotAmount);
                    decimal closeLongQty = shfesCloseLong.Sum(o => o.AssignedLotAmount);
                    decimal closeShortQty = shfesCloseShort.Sum(o => o.AssignedLotAmount);

                    decimal minLongQty = openLongQty < closeShortQty ? openLongQty : closeShortQty;
                    decimal minShortQty = openShortQty < closeLongQty ? openShortQty : closeLongQty;

                    decimal openlongAmount = 0, openlongCommission = 0, closeshortAmount = 0, closeshortCommission = 0,
                        openshortAmount = 0, openshortCommission = 0, closelongAmount = 0, closelongCommission = 0;
                    if (Math.Round(minLongQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) > 0)
                    {
                        SHFEByContractPL(out openlongAmount, out openlongCommission, shfesOpenLong, minLongQty);
                        SHFEByContractPL(out closeshortAmount, out closeshortCommission, shfesCloseShort, minLongQty);
                    }

                    if (Math.Round(minShortQty, RoundRules.QUANTITY, MidpointRounding.AwayFromZero) > 0)
                    {
                        SHFEByContractPL(out openshortAmount, out openshortCommission, shfesOpenShort, minShortQty);
                        SHFEByContractPL(out closelongAmount, out closelongCommission, shfesCloseLong, minShortQty);
                    }

                    shfePLAmount += closeshortAmount - openlongAmount + openshortAmount - closelongAmount -
                                    openlongCommission - closeshortCommission - openshortCommission -
                                    closelongCommission;
                }
            }
            vm.SHFEPLStr = (vm.AddedSHFEPositions.Count == 0 || shfePLAmount == null) ? "" : (shfePLAmount.Value.ToString("N2") + " " + vm.SHFEPLCurrency);

            decimal totalPL = 0;
            if(vm.TotalPLCurrency == "USD")
            {
                totalPL = (lmePLAmount ?? 0) + (quotaTotalPL ?? 0);
            }
            else if(vm.TotalPLCurrency == "CNY")
            {
                if(vm.QuotaPLCurrency == "USD")
                {
                    quotaTotalPL *= rate;
                }

                lmePLAmount *= rate;
                totalPL = (quotaTotalPL??0) + (lmePLAmount??0) + (shfePLAmount??0);
            }
            vm.TotalPLStr = totalPL.ToString("N2") + " " + vm.TotalPLCurrency;

            Currency c;
            using (var curService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                c = curService.GetCurrencyByCode(vm.TotalPLCurrency);
            }

            using (var hgService = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                var hg = hgService.GetById(vm.ObjectId);
                hg.PLAmount = totalPL;
                hg.PLCurrencyId = c.Id;
                hg.Status = (int)HedgeGroupStatus.Settled;
                hgService.UpdateHedgeGroupHeader(hg, vm.CurrentUser.Id);
            }
        }

        private void LMEByPromptPL(out decimal amount, out decimal commission, IEnumerable<HedgeLineLMEPosition> lmes, decimal closeQty)
        {
            amount = 0;
            commission = 0;
            foreach (var line in lmes)
            {
                if(line.AssignedLotAmount < closeQty)
                {
                    amount += line.AssignedLotAmount*(line.LMEPosition.Commodity.LMEQtyPerHand ?? 0)*
                              (line.LMEPosition.AgentPrice ?? 0);
                    commission += (line.LMEPosition.AgentCommission ?? 0);
                    closeQty -= line.AssignedLotAmount;
                    continue;
                }

                if(line.AssignedLotAmount >= closeQty)
                {
                    amount += closeQty * (line.LMEPosition.Commodity.LMEQtyPerHand ?? 0) *
                              (line.LMEPosition.AgentPrice ?? 0);
                    commission += (line.LMEPosition.AgentCommission ?? 0) * closeQty / line.AssignedLotAmount;
                    break;
                }
            }
        }

        private void SHFEByContractPL(out decimal amount, out decimal commission, IEnumerable<HedgeLineSHFEPosition> shfes, decimal closeQty)
        {
            amount = 0;
            commission = 0;
            foreach (var line in shfes)
            {
                if (line.AssignedLotAmount < closeQty)
                {
                    amount += line.AssignedLotAmount * (line.SHFEPosition.Commodity.SHFEQtyPerHand ?? 0) *
                              (line.SHFEPosition.Price ?? 0);
                    commission += (line.SHFEPosition.Commission ?? 0);
                    closeQty -= line.AssignedLotAmount;
                    continue;
                }

                if (line.AssignedLotAmount >= closeQty)
                {
                    amount += closeQty * (line.SHFEPosition.Commodity.SHFEQtyPerHand ?? 0) *
                              (line.SHFEPosition.Price ?? 0);
                    commission += (line.SHFEPosition.Commission ?? 0) * closeQty / line.AssignedLotAmount;
                    break;
                }
            }
        }
    }
}